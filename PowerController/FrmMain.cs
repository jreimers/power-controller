using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace PowerController
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Operating modes of the controller
        /// </summary>
        public enum ControllerMode
        {
            Off = 0,
            ForwardCV = 1,
            ForwardCC = 2,
            ReverseCV = 3,
            ReverseCC = 4
        }
        const byte PACKET_START = 0x53; // packet header
        const byte PACKET_END = 0x45; // packet terminator
        const byte FLOAT_SIZE = 4; // bytes in a float
        const byte PAYLOAD_LENGTH = 4; // floats in a packet
        const byte PAYLOAD_BYTES = FLOAT_SIZE*PAYLOAD_LENGTH; // bytes in a payload
        const byte PACKET_LENGTH = PAYLOAD_BYTES + 2; // bytes in packet plus 2 bytes for start/end

        /// <summary>
        /// Packet structure to unpack raw bytes into float array
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = PAYLOAD_BYTES)]
        struct Packet
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PAYLOAD_LENGTH, ArraySubType = UnmanagedType.R4)]
            public float[] data;
        }

        const int PLOT_BUFFER = 128; // number of data points to plot

        /// <summary>
        /// List of serial port names
        /// </summary>
        public String[] SerialPortsList
        {
            get;
            private set;
        }
        public bool Running
        {
            get;
            set;
        }
        public SerialPort Port
        {
            get;
            set;
        }
        /// <summary>
        /// Currently active controller mode
        /// </summary>
        public ControllerMode Mode
        {
            get;
            set;
        }

        // line series for data plot
        public LineSeries InputVoltage { get; set; }
        public LineSeries InputCurrent { get; set; }
        public LineSeries OutputVoltage { get; set; }
        public LineSeries OutputCurrent { get; set; }

        private CheckBox[] modeSelectors; // mode selector buttons
        private NumericTextBox[] modeValues; // mode numeric inputs

        /// <summary>
        /// Oxyplot model for data plotting
        /// </summary>
        public PlotModel Model
        {
            get;
            set;
        }

        public FrmMain()
        {
            InitializeComponent();

            this.Mode = ControllerMode.Off;
            modeSelectors = new CheckBox[] { btnFwdCC, btnFwdCV, btnRevCC, btnRevCV };
            modeValues = new NumericTextBox[] { tbFwdCurrent, tbFwdVoltage, tbRevVoltage, tbRevCurrent };

            InputVoltage = new LineSeries() { Title = "Input Voltage" };
            InputCurrent = new LineSeries() { Title = "Input Current" };
            OutputVoltage = new LineSeries() { Title = "Output Voltage" };
            OutputCurrent = new LineSeries() { Title = "Output Current" };
            Model = new PlotModel { };
            Model.Series.Add(InputVoltage);
            Model.Series.Add(InputCurrent);
            Model.Series.Add(OutputVoltage);
            Model.Series.Add(OutputCurrent);
            this.plotAmplitude.Model = Model;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.SerialPortsList = SerialPort.GetPortNames();
            cbComPorts.DataSource = this.SerialPortsList;
            this.Running = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Port != null && Port.IsOpen)
            {
                Port.Close();
                btnConnect.Text = "Connect";
                return;
            }
            if (cbComPorts.SelectedItem == null || String.IsNullOrEmpty((string)cbComPorts.SelectedItem))
            {
                return;
            }
            string comPort = (string)cbComPorts.SelectedItem;

            Port = new SerialPort(comPort, 115200);

            try
            {
                Port.Open();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                return;
            }

            Thread t = new Thread(new ParameterizedThreadStart(
                delegate (object serialPort)
                {
                    SerialPort sp = (SerialPort)serialPort;
                    while (this.Running)
                    {
                        try
                        {
                            List<Packet> data = new List<Packet>();
                            while (sp.BytesToRead > PACKET_LENGTH)
                            {
                                int input = sp.ReadByte();
                                if (input != PACKET_START)
                                {
                                    continue;
                                }

                                byte[] packetBytes = new byte[PAYLOAD_BYTES];
                                sp.Read(packetBytes, 0, PAYLOAD_BYTES);

                                GCHandle handle = GCHandle.Alloc(packetBytes, GCHandleType.Pinned);
                                Packet p = Marshal.PtrToStructure<Packet>(handle.AddrOfPinnedObject());
                                    
                                input = sp.ReadByte();
                                if(input == PACKET_END)
                                {
                                    data.Add(p);
                                }
                                else
                                {
                                    Console.WriteLine("Packet Read Error: {0:X}", input);
                                }
                            }
                            if (data.Count > 0)
                            {
                                Invoke(new EventHandler(ProcessData), data, EventArgs.Empty);
                            }
                        }
                        catch (Exception)
                        {
                            sp.Close();
                            return;
                        }
                    }
                }
            ));
            t.Start(Port);

            this.btnConnect.Text = "Disconnect";

            lblError.Text = "";
        }
        int x = 0;
        private void ProcessData(object sender, EventArgs e)
        {
            List<Packet> dataPoints = (List<Packet>)sender;
            foreach(Packet p in dataPoints)
            {
                x++;
                addToMovingWindow(InputVoltage, x, p.data[0]);
                addToMovingWindow(InputCurrent, x, p.data[1]);
                addToMovingWindow(OutputVoltage, x, p.data[2]);
                addToMovingWindow(OutputCurrent, x, p.data[3]);
            }
            Model.InvalidatePlot(true);
        }
        private void addToMovingWindow(LineSeries data, int x, float y)
        {
            if(data.Points.Count > PLOT_BUFFER)
            {
                data.Points.RemoveAt(0);
            }
            data.Points.Add(new DataPoint((double)x, (double)y));
        }

        private bool controllerTransmit()
        {
            try
            {
                float mode = (float)this.Mode;
                float value = 0;
                foreach (var tb in modeValues)
                {
                    if ((ControllerMode)tb.Tag == this.Mode)
                    {
                        value = tb.getFloatValue();
                    }
                }
                this.Port.Write(new byte[] { PACKET_START }, 0, 1);
                this.Port.Write(BitConverter.GetBytes(mode), 0, FLOAT_SIZE);
                this.Port.Write(BitConverter.GetBytes(value), 0, FLOAT_SIZE);
                this.Port.Write(new byte[] { PACKET_END }, 0, 1);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Running = false;
        }

        private void OnControllerModeChange(ControllerMode newMode)
        {
            lblStatus.Text = "Mode: " + newMode.ToString();
            this.Mode = newMode;
            if(!controllerTransmit())
            {
                foreach (CheckBox cb in modeSelectors)
                {
                        cb.Checked = false;
                }
                return;
            }
            foreach (CheckBox cb in modeSelectors)
            {
                if((ControllerMode)cb.Tag != newMode)
                {
                    cb.Checked = false;
                }
            }
        }

        private void modeBtn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox btn = (CheckBox)sender;
            ControllerMode newMode = (ControllerMode)btn.Tag;
            gbForward.Focus();
            if(this.Mode == newMode && btn.Checked == false)
            {
                OnControllerModeChange(ControllerMode.Off);
            }
            else if (btn.Checked)
            {
                OnControllerModeChange(newMode);
            }
        }
    }
}
