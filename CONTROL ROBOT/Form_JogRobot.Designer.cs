namespace CONTROL_ROBOT
{
    partial class Form_JogRobot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_JogRobot));
            this.panel_manual1 = new System.Windows.Forms.Panel();
            this.btnViewBarcode = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnBackPos = new System.Windows.Forms.Button();
            this.btnNextPos = new System.Windows.Forms.Button();
            this.txtManualDiemChay = new System.Windows.Forms.TextBox();
            this.btnMoveRandomPos = new System.Windows.Forms.Button();
            this.btnJogBuzzerStop = new System.Windows.Forms.Button();
            this.btnJogReset = new System.Windows.Forms.Button();
            this.btnJogServoON = new System.Windows.Forms.Button();
            this.btnJogServoOFF = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Jog_Y_Current = new System.Windows.Forms.Label();
            this.lbl_donviTime = new System.Windows.Forms.Label();
            this.lbl_Jog_X_Current = new System.Windows.Forms.Label();
            this.btnJogHome = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtJog_TocDo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnJogGiamTocX = new System.Windows.Forms.Button();
            this.btnJogTangTocX = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.pictureBox_Jog_Y_limit_Tru = new System.Windows.Forms.PictureBox();
            this.pictureBox_Jog_X_limit_Tru = new System.Windows.Forms.PictureBox();
            this.pictureBox_Jog_Y_limit_Cong = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox_Jog_X_limit_Cong = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnJogY_Cong = new System.Windows.Forms.Button();
            this.btnJogX_Tru = new System.Windows.Forms.Button();
            this.btnJogX_Cong = new System.Windows.Forms.Button();
            this.btnJogY_Tru = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_Jog_PLC = new System.Windows.Forms.Timer(this.components);
            this.panel_manual1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_Y_limit_Tru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_X_limit_Tru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_Y_limit_Cong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_X_limit_Cong)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_manual1
            // 
            this.panel_manual1.BackColor = System.Drawing.Color.Transparent;
            this.panel_manual1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_manual1.Controls.Add(this.btnViewBarcode);
            this.panel_manual1.Controls.Add(this.pictureBox8);
            this.panel_manual1.Controls.Add(this.btnBackPos);
            this.panel_manual1.Controls.Add(this.btnNextPos);
            this.panel_manual1.Controls.Add(this.txtManualDiemChay);
            this.panel_manual1.Controls.Add(this.btnMoveRandomPos);
            this.panel_manual1.Controls.Add(this.btnJogBuzzerStop);
            this.panel_manual1.Controls.Add(this.btnJogReset);
            this.panel_manual1.Controls.Add(this.btnJogServoON);
            this.panel_manual1.Controls.Add(this.btnJogServoOFF);
            this.panel_manual1.Controls.Add(this.panel6);
            this.panel_manual1.Controls.Add(this.btnJogHome);
            this.panel_manual1.Controls.Add(this.panel5);
            this.panel_manual1.Controls.Add(this.pictureBox_Jog_Y_limit_Tru);
            this.panel_manual1.Controls.Add(this.pictureBox_Jog_X_limit_Tru);
            this.panel_manual1.Controls.Add(this.pictureBox_Jog_Y_limit_Cong);
            this.panel_manual1.Controls.Add(this.label11);
            this.panel_manual1.Controls.Add(this.label5);
            this.panel_manual1.Controls.Add(this.pictureBox_Jog_X_limit_Cong);
            this.panel_manual1.Controls.Add(this.label3);
            this.panel_manual1.Controls.Add(this.panel1);
            this.panel_manual1.Controls.Add(this.label2);
            this.panel_manual1.ForeColor = System.Drawing.Color.Navy;
            this.panel_manual1.Location = new System.Drawing.Point(3, 2);
            this.panel_manual1.Name = "panel_manual1";
            this.panel_manual1.Size = new System.Drawing.Size(506, 491);
            this.panel_manual1.TabIndex = 16;
            // 
            // btnViewBarcode
            // 
            this.btnViewBarcode.BackColor = System.Drawing.Color.Gray;
            this.btnViewBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnViewBarcode.FlatAppearance.BorderSize = 2;
            this.btnViewBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnViewBarcode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnViewBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBarcode.ForeColor = System.Drawing.Color.White;
            this.btnViewBarcode.Location = new System.Drawing.Point(165, 444);
            this.btnViewBarcode.Name = "btnViewBarcode";
            this.btnViewBarcode.Size = new System.Drawing.Size(234, 40);
            this.btnViewBarcode.TabIndex = 272;
            this.btnViewBarcode.Text = "LIVE VIEW BARCODE";
            this.btnViewBarcode.UseVisualStyleBackColor = false;
            this.btnViewBarcode.Click += new System.EventHandler(this.btnViewBarcode_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(85, 428);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(70, 56);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 271;
            this.pictureBox8.TabStop = false;
            // 
            // btnBackPos
            // 
            this.btnBackPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBackPos.BackgroundImage")));
            this.btnBackPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackPos.Location = new System.Drawing.Point(341, 130);
            this.btnBackPos.Name = "btnBackPos";
            this.btnBackPos.Size = new System.Drawing.Size(31, 28);
            this.btnBackPos.TabIndex = 270;
            this.btnBackPos.UseVisualStyleBackColor = true;
            this.btnBackPos.Click += new System.EventHandler(this.btnBackPos_Click);
            // 
            // btnNextPos
            // 
            this.btnNextPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextPos.BackgroundImage")));
            this.btnNextPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNextPos.Location = new System.Drawing.Point(341, 104);
            this.btnNextPos.Name = "btnNextPos";
            this.btnNextPos.Size = new System.Drawing.Size(31, 28);
            this.btnNextPos.TabIndex = 269;
            this.btnNextPos.UseVisualStyleBackColor = true;
            this.btnNextPos.Click += new System.EventHandler(this.btnNextPos_Click);
            // 
            // txtManualDiemChay
            // 
            this.txtManualDiemChay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualDiemChay.ForeColor = System.Drawing.Color.Maroon;
            this.txtManualDiemChay.Location = new System.Drawing.Point(259, 116);
            this.txtManualDiemChay.Name = "txtManualDiemChay";
            this.txtManualDiemChay.Size = new System.Drawing.Size(81, 31);
            this.txtManualDiemChay.TabIndex = 268;
            this.txtManualDiemChay.Text = "0";
            this.txtManualDiemChay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtManualDiemChay.TextChanged += new System.EventHandler(this.txtManualDiemChay_TextChanged);
            // 
            // btnMoveRandomPos
            // 
            this.btnMoveRandomPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMoveRandomPos.BackgroundImage")));
            this.btnMoveRandomPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMoveRandomPos.Location = new System.Drawing.Point(375, 101);
            this.btnMoveRandomPos.Name = "btnMoveRandomPos";
            this.btnMoveRandomPos.Size = new System.Drawing.Size(124, 61);
            this.btnMoveRandomPos.TabIndex = 267;
            this.btnMoveRandomPos.UseVisualStyleBackColor = true;
            this.btnMoveRandomPos.Click += new System.EventHandler(this.btnMoveRandomPos_Click);
            // 
            // btnJogBuzzerStop
            // 
            this.btnJogBuzzerStop.BackColor = System.Drawing.Color.Gray;
            this.btnJogBuzzerStop.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnJogBuzzerStop.FlatAppearance.BorderSize = 2;
            this.btnJogBuzzerStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJogBuzzerStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnJogBuzzerStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogBuzzerStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogBuzzerStop.Location = new System.Drawing.Point(341, 39);
            this.btnJogBuzzerStop.Name = "btnJogBuzzerStop";
            this.btnJogBuzzerStop.Size = new System.Drawing.Size(158, 40);
            this.btnJogBuzzerStop.TabIndex = 241;
            this.btnJogBuzzerStop.Text = "BUZZER";
            this.btnJogBuzzerStop.UseVisualStyleBackColor = false;
            this.btnJogBuzzerStop.Click += new System.EventHandler(this.btnJogBuzzerStop_Click);
            // 
            // btnJogReset
            // 
            this.btnJogReset.BackColor = System.Drawing.Color.Gray;
            this.btnJogReset.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnJogReset.FlatAppearance.BorderSize = 2;
            this.btnJogReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJogReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnJogReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogReset.Location = new System.Drawing.Point(341, 3);
            this.btnJogReset.Name = "btnJogReset";
            this.btnJogReset.Size = new System.Drawing.Size(158, 40);
            this.btnJogReset.TabIndex = 240;
            this.btnJogReset.Text = "RESET";
            this.btnJogReset.UseVisualStyleBackColor = false;
            this.btnJogReset.Click += new System.EventHandler(this.btnJogReset_Click);
            // 
            // btnJogServoON
            // 
            this.btnJogServoON.BackColor = System.Drawing.Color.Gray;
            this.btnJogServoON.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnJogServoON.FlatAppearance.BorderSize = 2;
            this.btnJogServoON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJogServoON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnJogServoON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogServoON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogServoON.Location = new System.Drawing.Point(181, 3);
            this.btnJogServoON.Name = "btnJogServoON";
            this.btnJogServoON.Size = new System.Drawing.Size(158, 40);
            this.btnJogServoON.TabIndex = 54;
            this.btnJogServoON.Text = "SERVO ON";
            this.btnJogServoON.UseVisualStyleBackColor = false;
            this.btnJogServoON.Click += new System.EventHandler(this.btnJogServoON_Click);
            // 
            // btnJogServoOFF
            // 
            this.btnJogServoOFF.BackColor = System.Drawing.Color.Gray;
            this.btnJogServoOFF.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnJogServoOFF.FlatAppearance.BorderSize = 2;
            this.btnJogServoOFF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJogServoOFF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnJogServoOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogServoOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogServoOFF.Location = new System.Drawing.Point(181, 39);
            this.btnJogServoOFF.Name = "btnJogServoOFF";
            this.btnJogServoOFF.Size = new System.Drawing.Size(158, 40);
            this.btnJogServoOFF.TabIndex = 52;
            this.btnJogServoOFF.Text = "SERVO OFF";
            this.btnJogServoOFF.UseVisualStyleBackColor = false;
            this.btnJogServoOFF.Click += new System.EventHandler(this.btnJogTatServo_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.lbl_Jog_Y_Current);
            this.panel6.Controls.Add(this.lbl_donviTime);
            this.panel6.Controls.Add(this.lbl_Jog_X_Current);
            this.panel6.Location = new System.Drawing.Point(254, 183);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(247, 126);
            this.panel6.TabIndex = 239;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(34, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 19);
            this.label7.TabIndex = 257;
            this.label7.Text = "CURRENT POSITION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(216, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 16);
            this.label9.TabIndex = 241;
            this.label9.Text = "mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(216, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 240;
            this.label1.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(-2, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 19);
            this.label8.TabIndex = 25;
            this.label8.Text = "Trục Y";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Jog_Y_Current
            // 
            this.lbl_Jog_Y_Current.BackColor = System.Drawing.Color.White;
            this.lbl_Jog_Y_Current.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Jog_Y_Current.ForeColor = System.Drawing.Color.Black;
            this.lbl_Jog_Y_Current.Location = new System.Drawing.Point(62, 68);
            this.lbl_Jog_Y_Current.Name = "lbl_Jog_Y_Current";
            this.lbl_Jog_Y_Current.Size = new System.Drawing.Size(152, 33);
            this.lbl_Jog_Y_Current.TabIndex = 24;
            this.lbl_Jog_Y_Current.Text = "0";
            this.lbl_Jog_Y_Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_donviTime
            // 
            this.lbl_donviTime.AutoSize = true;
            this.lbl_donviTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_donviTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_donviTime.Location = new System.Drawing.Point(-2, 42);
            this.lbl_donviTime.Name = "lbl_donviTime";
            this.lbl_donviTime.Size = new System.Drawing.Size(55, 19);
            this.lbl_donviTime.TabIndex = 23;
            this.lbl_donviTime.Text = "Trục X";
            this.lbl_donviTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Jog_X_Current
            // 
            this.lbl_Jog_X_Current.BackColor = System.Drawing.Color.White;
            this.lbl_Jog_X_Current.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Jog_X_Current.ForeColor = System.Drawing.Color.Black;
            this.lbl_Jog_X_Current.Location = new System.Drawing.Point(62, 33);
            this.lbl_Jog_X_Current.Name = "lbl_Jog_X_Current";
            this.lbl_Jog_X_Current.Size = new System.Drawing.Size(152, 33);
            this.lbl_Jog_X_Current.TabIndex = 21;
            this.lbl_Jog_X_Current.Text = "0";
            this.lbl_Jog_X_Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJogHome
            // 
            this.btnJogHome.BackColor = System.Drawing.Color.Gray;
            this.btnJogHome.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnJogHome.FlatAppearance.BorderSize = 2;
            this.btnJogHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnJogHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnJogHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogHome.Location = new System.Drawing.Point(4, 3);
            this.btnJogHome.Name = "btnJogHome";
            this.btnJogHome.Size = new System.Drawing.Size(175, 76);
            this.btnJogHome.TabIndex = 41;
            this.btnJogHome.Text = "HOME";
            this.btnJogHome.UseVisualStyleBackColor = false;
            this.btnJogHome.Click += new System.EventHandler(this.btnJogHome_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.txtJog_TocDo);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.btnJogGiamTocX);
            this.panel5.Controls.Add(this.btnJogTangTocX);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Location = new System.Drawing.Point(254, 309);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(247, 101);
            this.panel5.TabIndex = 238;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(32, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 19);
            this.label10.TabIndex = 258;
            this.label10.Text = "JOG SPEED SETTING";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 239;
            this.pictureBox1.TabStop = false;
            // 
            // txtJog_TocDo
            // 
            this.txtJog_TocDo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtJog_TocDo.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJog_TocDo.ForeColor = System.Drawing.Color.Maroon;
            this.txtJog_TocDo.Location = new System.Drawing.Point(90, 47);
            this.txtJog_TocDo.Name = "txtJog_TocDo";
            this.txtJog_TocDo.Size = new System.Drawing.Size(116, 29);
            this.txtJog_TocDo.TabIndex = 236;
            this.txtJog_TocDo.Text = "20";
            this.txtJog_TocDo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJog_TocDo.TextChanged += new System.EventHandler(this.txtJog_TocDo_X_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(167, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "mm/s";
            // 
            // btnJogGiamTocX
            // 
            this.btnJogGiamTocX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJogGiamTocX.BackgroundImage")));
            this.btnJogGiamTocX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJogGiamTocX.Location = new System.Drawing.Point(210, 58);
            this.btnJogGiamTocX.Name = "btnJogGiamTocX";
            this.btnJogGiamTocX.Size = new System.Drawing.Size(31, 28);
            this.btnJogGiamTocX.TabIndex = 33;
            this.btnJogGiamTocX.UseVisualStyleBackColor = true;
            this.btnJogGiamTocX.Click += new System.EventHandler(this.btnJogGiamTocX_Click);
            // 
            // btnJogTangTocX
            // 
            this.btnJogTangTocX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJogTangTocX.BackgroundImage")));
            this.btnJogTangTocX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJogTangTocX.Location = new System.Drawing.Point(210, 32);
            this.btnJogTangTocX.Name = "btnJogTangTocX";
            this.btnJogTangTocX.Size = new System.Drawing.Size(31, 28);
            this.btnJogTangTocX.TabIndex = 32;
            this.btnJogTangTocX.UseVisualStyleBackColor = true;
            this.btnJogTangTocX.Click += new System.EventHandler(this.btnJogTangTocX_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(34, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 19);
            this.label23.TabIndex = 29;
            this.label23.Text = "speed";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox_Jog_Y_limit_Tru
            // 
            this.pictureBox_Jog_Y_limit_Tru.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Jog_Y_limit_Tru.Image")));
            this.pictureBox_Jog_Y_limit_Tru.Location = new System.Drawing.Point(146, 123);
            this.pictureBox_Jog_Y_limit_Tru.Name = "pictureBox_Jog_Y_limit_Tru";
            this.pictureBox_Jog_Y_limit_Tru.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_Jog_Y_limit_Tru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Jog_Y_limit_Tru.TabIndex = 54;
            this.pictureBox_Jog_Y_limit_Tru.TabStop = false;
            // 
            // pictureBox_Jog_X_limit_Tru
            // 
            this.pictureBox_Jog_X_limit_Tru.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Jog_X_limit_Tru.Image")));
            this.pictureBox_Jog_X_limit_Tru.Location = new System.Drawing.Point(77, 123);
            this.pictureBox_Jog_X_limit_Tru.Name = "pictureBox_Jog_X_limit_Tru";
            this.pictureBox_Jog_X_limit_Tru.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_Jog_X_limit_Tru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Jog_X_limit_Tru.TabIndex = 53;
            this.pictureBox_Jog_X_limit_Tru.TabStop = false;
            // 
            // pictureBox_Jog_Y_limit_Cong
            // 
            this.pictureBox_Jog_Y_limit_Cong.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Jog_Y_limit_Cong.Image")));
            this.pictureBox_Jog_Y_limit_Cong.Location = new System.Drawing.Point(204, 123);
            this.pictureBox_Jog_Y_limit_Cong.Name = "pictureBox_Jog_Y_limit_Cong";
            this.pictureBox_Jog_Y_limit_Cong.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_Jog_Y_limit_Cong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Jog_Y_limit_Cong.TabIndex = 52;
            this.pictureBox_Jog_Y_limit_Cong.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(135, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 16);
            this.label11.TabIndex = 51;
            this.label11.Text = "Y limit -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(192, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "Y limit +";
            // 
            // pictureBox_Jog_X_limit_Cong
            // 
            this.pictureBox_Jog_X_limit_Cong.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Jog_X_limit_Cong.Image")));
            this.pictureBox_Jog_X_limit_Cong.Location = new System.Drawing.Point(23, 123);
            this.pictureBox_Jog_X_limit_Cong.Name = "pictureBox_Jog_X_limit_Cong";
            this.pictureBox_Jog_X_limit_Cong.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_Jog_X_limit_Cong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Jog_X_limit_Cong.TabIndex = 50;
            this.pictureBox_Jog_X_limit_Cong.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(66, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "X limit -";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnJogY_Cong);
            this.panel1.Controls.Add(this.btnJogX_Tru);
            this.panel1.Controls.Add(this.btnJogX_Cong);
            this.panel1.Controls.Add(this.btnJogY_Tru);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Location = new System.Drawing.Point(2, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 227);
            this.panel1.TabIndex = 54;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(200, 118);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 16);
            this.label16.TabIndex = 48;
            this.label16.Text = "X+";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(10, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 16);
            this.label15.TabIndex = 47;
            this.label15.Text = "X-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(125, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 16);
            this.label14.TabIndex = 46;
            this.label14.Text = "Y+";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(125, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Y-";
            // 
            // btnJogY_Cong
            // 
            this.btnJogY_Cong.BackColor = System.Drawing.Color.Transparent;
            this.btnJogY_Cong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJogY_Cong.BackgroundImage")));
            this.btnJogY_Cong.Location = new System.Drawing.Point(80, 147);
            this.btnJogY_Cong.Name = "btnJogY_Cong";
            this.btnJogY_Cong.Size = new System.Drawing.Size(75, 75);
            this.btnJogY_Cong.TabIndex = 40;
            this.btnJogY_Cong.UseVisualStyleBackColor = false;
            this.btnJogY_Cong.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogY_Cong_MouseDown);
            this.btnJogY_Cong.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogY_Cong_MouseUp);
            // 
            // btnJogX_Tru
            // 
            this.btnJogX_Tru.BackColor = System.Drawing.Color.Transparent;
            this.btnJogX_Tru.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJogX_Tru.BackgroundImage")));
            this.btnJogX_Tru.Location = new System.Drawing.Point(4, 74);
            this.btnJogX_Tru.Name = "btnJogX_Tru";
            this.btnJogX_Tru.Size = new System.Drawing.Size(75, 75);
            this.btnJogX_Tru.TabIndex = 39;
            this.btnJogX_Tru.UseVisualStyleBackColor = false;
            this.btnJogX_Tru.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogX_Tru_MouseDown);
            this.btnJogX_Tru.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogX_Tru_MouseUp);
            // 
            // btnJogX_Cong
            // 
            this.btnJogX_Cong.BackColor = System.Drawing.Color.Transparent;
            this.btnJogX_Cong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJogX_Cong.BackgroundImage")));
            this.btnJogX_Cong.Location = new System.Drawing.Point(156, 74);
            this.btnJogX_Cong.Name = "btnJogX_Cong";
            this.btnJogX_Cong.Size = new System.Drawing.Size(75, 75);
            this.btnJogX_Cong.TabIndex = 38;
            this.btnJogX_Cong.UseVisualStyleBackColor = false;
            this.btnJogX_Cong.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogX_Cong_MouseDown);
            this.btnJogX_Cong.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogX_Cong_MouseUp);
            // 
            // btnJogY_Tru
            // 
            this.btnJogY_Tru.BackColor = System.Drawing.Color.Transparent;
            this.btnJogY_Tru.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJogY_Tru.BackgroundImage")));
            this.btnJogY_Tru.Location = new System.Drawing.Point(80, 2);
            this.btnJogY_Tru.Name = "btnJogY_Tru";
            this.btnJogY_Tru.Size = new System.Drawing.Size(75, 75);
            this.btnJogY_Tru.TabIndex = 37;
            this.btnJogY_Tru.UseVisualStyleBackColor = false;
            this.btnJogY_Tru.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogY_Tru_MouseDown);
            this.btnJogY_Tru.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogY_Tru_MouseUp);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(80, 74);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(75, 75);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 19;
            this.pictureBox6.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(8, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "X  limit +";
            // 
            // timer_Jog_PLC
            // 
            this.timer_Jog_PLC.Tick += new System.EventHandler(this.timer_Jog_PLC_Tick);
            // 
            // Form_JogRobot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(511, 500);
            this.Controls.Add(this.panel_manual1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_JogRobot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JOG MONITOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_JogRobot_FormClosing);
            this.Load += new System.EventHandler(this.Form_JogRobot_Load);
            this.panel_manual1.ResumeLayout(false);
            this.panel_manual1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_Y_limit_Tru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_X_limit_Tru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_Y_limit_Cong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Jog_X_limit_Cong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_manual1;
        private System.Windows.Forms.Button btnJogGiamTocX;
        private System.Windows.Forms.Button btnJogTangTocX;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Jog_Y_Current;
        private System.Windows.Forms.Label lbl_donviTime;
        private System.Windows.Forms.Label lbl_Jog_X_Current;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnJogY_Tru;
        private System.Windows.Forms.Button btnJogY_Cong;
        private System.Windows.Forms.Button btnJogX_Tru;
        private System.Windows.Forms.Button btnJogX_Cong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox_Jog_X_limit_Cong;
        private System.Windows.Forms.PictureBox pictureBox_Jog_Y_limit_Tru;
        private System.Windows.Forms.PictureBox pictureBox_Jog_X_limit_Tru;
        private System.Windows.Forms.PictureBox pictureBox_Jog_Y_limit_Cong;
        private System.Windows.Forms.TextBox txtJog_TocDo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_Jog_PLC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnJogHome;
        public System.Windows.Forms.Button btnJogServoOFF;
        public System.Windows.Forms.Button btnJogServoON;
        public System.Windows.Forms.Button btnJogReset;
        public System.Windows.Forms.Button btnJogBuzzerStop;
        private System.Windows.Forms.Button btnBackPos;
        private System.Windows.Forms.Button btnNextPos;
        private System.Windows.Forms.TextBox txtManualDiemChay;
        private System.Windows.Forms.Button btnMoveRandomPos;
        public System.Windows.Forms.Button btnViewBarcode;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}