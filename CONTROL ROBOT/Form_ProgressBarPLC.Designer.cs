namespace CONTROL_ROBOT
{
    partial class Form_ProgressBarPLC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProgressBarPLC));
            this.progressBarPLC_LOAD = new System.Windows.Forms.ProgressBar();
            this.timer_ProgressBar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBarPLC_LOAD
            // 
            this.progressBarPLC_LOAD.Location = new System.Drawing.Point(-3, 0);
            this.progressBarPLC_LOAD.Name = "progressBarPLC_LOAD";
            this.progressBarPLC_LOAD.Size = new System.Drawing.Size(536, 33);
            this.progressBarPLC_LOAD.TabIndex = 0;
            // 
            // timer_ProgressBar
            // 
            this.timer_ProgressBar.Tick += new System.EventHandler(this.timer_ProgressBar_Tick);
            // 
            // Form_ProgressBarPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(532, 31);
            this.Controls.Add(this.progressBarPLC_LOAD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ProgressBarPLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOAD DATA TO PLC";
            this.Load += new System.EventHandler(this.Form_ProgressBarPLC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_ProgressBar;
        public System.Windows.Forms.ProgressBar progressBarPLC_LOAD;
    }
}