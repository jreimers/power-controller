namespace PowerController
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plotAmplitude = new OxyPlot.WindowsForms.PlotView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbComPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.gbForward = new System.Windows.Forms.GroupBox();
            this.btnFwdCV = new System.Windows.Forms.CheckBox();
            this.btnFwdCC = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFwdCurrent = new NumericTextBox();
            this.tbFwdVoltage = new NumericTextBox();
            this.btnRevCV = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbReverse = new System.Windows.Forms.GroupBox();
            this.btnRevCC = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRevCurrent = new NumericTextBox();
            this.tbRevVoltage = new NumericTextBox();
            this.gbForward.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gbReverse.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotAmplitude
            // 
            this.plotAmplitude.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotAmplitude.BackColor = System.Drawing.Color.White;
            this.plotAmplitude.Location = new System.Drawing.Point(0, 39);
            this.plotAmplitude.Name = "plotAmplitude";
            this.plotAmplitude.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotAmplitude.Size = new System.Drawing.Size(872, 494);
            this.plotAmplitude.TabIndex = 0;
            this.plotAmplitude.Text = "plot1";
            this.plotAmplitude.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotAmplitude.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotAmplitude.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // cbComPorts
            // 
            this.cbComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPorts.FormattingEnabled = true;
            this.cbComPorts.Location = new System.Drawing.Point(71, 12);
            this.cbComPorts.Name = "cbComPorts";
            this.cbComPorts.Size = new System.Drawing.Size(94, 21);
            this.cbComPorts.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(171, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 21);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(252, 16);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 4;
            // 
            // gbForward
            // 
            this.gbForward.Controls.Add(this.btnFwdCV);
            this.gbForward.Controls.Add(this.btnFwdCC);
            this.gbForward.Controls.Add(this.label3);
            this.gbForward.Controls.Add(this.label2);
            this.gbForward.Controls.Add(this.tbFwdCurrent);
            this.gbForward.Controls.Add(this.tbFwdVoltage);
            this.gbForward.Location = new System.Drawing.Point(15, 547);
            this.gbForward.Name = "gbForward";
            this.gbForward.Size = new System.Drawing.Size(202, 79);
            this.gbForward.TabIndex = 7;
            this.gbForward.TabStop = false;
            this.gbForward.Text = "Forward Mode";
            // 
            // btnFwdCV
            // 
            this.btnFwdCV.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnFwdCV.AutoSize = true;
            this.btnFwdCV.FlatAppearance.BorderSize = 0;
            this.btnFwdCV.Location = new System.Drawing.Point(94, 16);
            this.btnFwdCV.Name = "btnFwdCV";
            this.btnFwdCV.Size = new System.Drawing.Size(98, 23);
            this.btnFwdCV.TabIndex = 10;
            this.btnFwdCV.Tag = PowerController.FrmMain.ControllerMode.ForwardCV;
            this.btnFwdCV.Text = "Constant Voltage";
            this.btnFwdCV.UseVisualStyleBackColor = true;
            this.btnFwdCV.CheckedChanged += new System.EventHandler(this.modeBtn_CheckedChanged);
            // 
            // btnFwdCC
            // 
            this.btnFwdCC.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnFwdCC.AutoSize = true;
            this.btnFwdCC.Location = new System.Drawing.Point(94, 45);
            this.btnFwdCC.Name = "btnFwdCC";
            this.btnFwdCC.Size = new System.Drawing.Size(96, 23);
            this.btnFwdCC.TabIndex = 14;
            this.btnFwdCC.Tag = PowerController.FrmMain.ControllerMode.ForwardCC;
            this.btnFwdCC.Text = "Constant Current";
            this.btnFwdCC.UseVisualStyleBackColor = true;
            this.btnFwdCC.CheckedChanged += new System.EventHandler(this.modeBtn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "V";
            // 
            // tbFwdCurrent
            // 
            this.tbFwdCurrent.DecimalNumbers = 2;
            this.tbFwdCurrent.ForeColor = System.Drawing.Color.Black;
            this.tbFwdCurrent.Format = "^(\\-?)(\\d*)(\\.?)(\\d?)(\\d?)$";
            this.tbFwdCurrent.HasNegatives = true;
            this.tbFwdCurrent.Location = new System.Drawing.Point(6, 47);
            this.tbFwdCurrent.Name = "tbFwdCurrent";
            this.tbFwdCurrent.Size = new System.Drawing.Size(61, 20);
            this.tbFwdCurrent.TabIndex = 9;
            this.tbFwdCurrent.Tag = PowerController.FrmMain.ControllerMode.ForwardCC;

            // 
            // tbFwdVoltage
            // 
            this.tbFwdVoltage.DecimalNumbers = 2;
            this.tbFwdVoltage.ForeColor = System.Drawing.Color.Black;
            this.tbFwdVoltage.Format = "^(\\-?)(\\d*)(\\.?)(\\d?)(\\d?)$";
            this.tbFwdVoltage.HasNegatives = true;
            this.tbFwdVoltage.Location = new System.Drawing.Point(6, 18);
            this.tbFwdVoltage.Name = "tbFwdVoltage";
            this.tbFwdVoltage.Size = new System.Drawing.Size(61, 20);
            this.tbFwdVoltage.TabIndex = 8;
            this.tbFwdVoltage.Tag = PowerController.FrmMain.ControllerMode.ForwardCV;
            // 
            // btnRevCV
            // 
            this.btnRevCV.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnRevCV.AutoSize = true;
            this.btnRevCV.Location = new System.Drawing.Point(94, 16);
            this.btnRevCV.Name = "btnRevCV";
            this.btnRevCV.Size = new System.Drawing.Size(98, 23);
            this.btnRevCV.TabIndex = 11;
            this.btnRevCV.Tag = PowerController.FrmMain.ControllerMode.ReverseCV;
            this.btnRevCV.Text = "Constant Voltage";
            this.btnRevCV.UseVisualStyleBackColor = true;
            this.btnRevCV.CheckedChanged += new System.EventHandler(this.modeBtn_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 637);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(874, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 17);
            this.lblStatus.Text = "Mode: Off";
            // 
            // gbReverse
            // 
            this.gbReverse.Controls.Add(this.btnRevCV);
            this.gbReverse.Controls.Add(this.btnRevCC);
            this.gbReverse.Controls.Add(this.label4);
            this.gbReverse.Controls.Add(this.label5);
            this.gbReverse.Controls.Add(this.tbRevCurrent);
            this.gbReverse.Controls.Add(this.tbRevVoltage);
            this.gbReverse.Location = new System.Drawing.Point(223, 547);
            this.gbReverse.Name = "gbReverse";
            this.gbReverse.Size = new System.Drawing.Size(202, 79);
            this.gbReverse.TabIndex = 9;
            this.gbReverse.TabStop = false;
            this.gbReverse.Text = "Reverse Mode";
            // 
            // btnRevCC
            // 
            this.btnRevCC.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnRevCC.AutoSize = true;
            this.btnRevCC.Location = new System.Drawing.Point(94, 45);
            this.btnRevCC.Name = "btnRevCC";
            this.btnRevCC.Size = new System.Drawing.Size(96, 23);
            this.btnRevCC.TabIndex = 15;
            this.btnRevCC.Tag = PowerController.FrmMain.ControllerMode.ReverseCC;
            this.btnRevCC.Text = "Constant Current";
            this.btnRevCC.UseVisualStyleBackColor = true;
            this.btnRevCC.CheckedChanged += new System.EventHandler(this.modeBtn_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "V";
            // 
            // tbRevCurrent
            // 
            this.tbRevCurrent.DecimalNumbers = 2;
            this.tbRevCurrent.ForeColor = System.Drawing.Color.Black;
            this.tbRevCurrent.Format = "^(\\-?)(\\d*)(\\.?)(\\d?)(\\d?)$";
            this.tbRevCurrent.HasNegatives = true;
            this.tbRevCurrent.Location = new System.Drawing.Point(6, 47);
            this.tbRevCurrent.Name = "tbRevCurrent";
            this.tbRevCurrent.Tag = PowerController.FrmMain.ControllerMode.ReverseCC;
            this.tbRevCurrent.Size = new System.Drawing.Size(61, 20);
            this.tbRevCurrent.TabIndex = 9;
            // 
            // tbRevVoltage
            // 
            this.tbRevVoltage.DecimalNumbers = 2;
            this.tbRevVoltage.ForeColor = System.Drawing.Color.Black;
            this.tbRevVoltage.Format = "^(\\-?)(\\d*)(\\.?)(\\d?)(\\d?)$";
            this.tbRevVoltage.HasNegatives = true;
            this.tbRevVoltage.Location = new System.Drawing.Point(6, 18);
            this.tbRevVoltage.Name = "tbRevVoltage";
            this.tbRevVoltage.Tag = PowerController.FrmMain.ControllerMode.ReverseCV;
            this.tbRevVoltage.Size = new System.Drawing.Size(61, 20);
            this.tbRevVoltage.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 659);
            this.Controls.Add(this.gbReverse);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbForward);
            this.Controls.Add(this.plotAmplitude);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbComPorts);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Power Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gbForward.ResumeLayout(false);
            this.gbForward.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbReverse.ResumeLayout(false);
            this.gbReverse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbComPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblError;
        private OxyPlot.WindowsForms.PlotView plotAmplitude;
        private System.Windows.Forms.GroupBox gbForward;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private NumericTextBox tbFwdCurrent;
        private NumericTextBox tbFwdVoltage;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox gbReverse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private NumericTextBox tbRevCurrent;
        private NumericTextBox tbRevVoltage;
        private System.Windows.Forms.CheckBox btnRevCV;
        private System.Windows.Forms.CheckBox btnFwdCV;
        private System.Windows.Forms.CheckBox btnRevCC;
        private System.Windows.Forms.CheckBox btnFwdCC;
    }
}