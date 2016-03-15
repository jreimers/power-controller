using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerController
{
    public struct DriveCyclePoint
    {
        public ConverterMode Mode;
        public float Setpoint;
        public int Time;

        public DriveCyclePoint(ConverterMode mode, float setpoint, int time)
        {
            this.Mode = mode;
            this.Setpoint = setpoint;
            this.Time = time;
        }
    }
    public class DriveCycle
    {
        public bool Running { get; set; }
        public bool Playing { get; set; }
        
        public DriveCycle(Stream driveCycleData)
        {
            
            timer = new Stopwatch();
        }
        public void Play()
        {
            timer.Start();
        }
        public void Pause()
        {
            timer.Stop();
        }
        public void Restart()
        {
            timer.Restart();
        }

        public delegate void CycleUpdateHandler(DriveCyclePoint point);
        public event CycleUpdateHandler CycleUpdate;

        private Stopwatch timer;

        private List<DriveCyclePoint> read(Stream driveCycleData)
        {
            StreamReader sr = new StreamReader(driveCycleData);
            List<DriveCyclePoint> points = new List<DriveCyclePoint>();
            while(!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                float time;
                float setpoint;
                if(!float.TryParse(line[0], out time))
                {
                    continue;
                }
                if(!float.TryParse(line[1], out setpoint))
                {
                    continue;
                }
                ConverterMode mode = ConverterMode.Off;
                if(setpoint < 0)
                {
                    mode = ConverterMode.ReverseCC;
                } else if(setpoint > 0)
                {
                    mode = ConverterMode.ForwardCC;
                } else if(setpoint == 0)
                {
                    mode = ConverterMode.Off;
                }
                points.Add(new DriveCyclePoint(mode, setpoint, (int)time * 1000));
            }
            return points;
        }

        private void loop()
        {
            Thread t = new Thread(new ParameterizedThreadStart(
                delegate (object driveCycleData)
                {
                    List<DriveCyclePoint> data = (List<DriveCyclePoint>)driveCycleData;
                    int dataIndex = 0;
                    while(timer.IsRunning)
                    {
                        if (data[dataIndex].Time > timer.ElapsedMilliseconds)
                        {
                            if(CycleUpdate != null)
                            {
                                CycleUpdate.Invoke(data[dataIndex]);
                            }
                            dataIndex++;
                        }
                        Thread.Sleep(1);
                    }
                }
            ));
        }
    }
}
