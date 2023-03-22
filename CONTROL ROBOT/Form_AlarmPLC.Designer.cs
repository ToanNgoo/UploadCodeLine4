namespace CONTROL_ROBOT
{
    partial class Form_AlarmPLC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AlarmPLC));
            this.lblNameAlarm = new System.Windows.Forms.Label();
            this.ptb_Close_Form_Alarm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Close_Form_Alarm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameAlarm
            // 
            this.lblNameAlarm.BackColor = System.Drawing.Color.Yellow;
            this.lblNameAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAlarm.ForeColor = System.Drawing.Color.Maroon;
            this.lblNameAlarm.Location = new System.Drawing.Point(4, 4);
            this.lblNameAlarm.Name = "lblNameAlarm";
            this.lblNameAlarm.Size = new System.Drawing.Size(875, 553);
            this.lblNameAlarm.TabIndex = 0;
            this.lblNameAlarm.Text = "EMERGENCY STOP ON";
            this.lblNameAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptb_Close_Form_Alarm
            // 
            this.ptb_Close_Form_Alarm.BackColor = System.Drawing.Color.Transparent;
            this.ptb_Close_Form_Alarm.Image = ((System.Drawing.Image)(resources.GetObject("ptb_Close_Form_Alarm.Image")));
            this.ptb_Close_Form_Alarm.Location = new System.Drawing.Point(366, 492);
            this.ptb_Close_Form_Alarm.Name = "ptb_Close_Form_Alarm";
            this.ptb_Close_Form_Alarm.Size = new System.Drawing.Size(151, 57);
            this.ptb_Close_Form_Alarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_Close_Form_Alarm.TabIndex = 1;
            this.ptb_Close_Form_Alarm.TabStop = false;
            this.ptb_Close_Form_Alarm.Click += new System.EventHandler(this.ptb_Close_Form_Alarm_Click);
            // 
            // Form_AlarmPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.ptb_Close_Form_Alarm);
            this.Controls.Add(this.lblNameAlarm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_AlarmPLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAlarmPLC";
            this.Load += new System.EventHandler(this.Form_AlarmPLC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Close_Form_Alarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_Close_Form_Alarm;
        public System.Windows.Forms.Label lblNameAlarm;
    }
}