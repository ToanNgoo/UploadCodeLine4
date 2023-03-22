using Keyence.AutoID.SDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROL_ROBOT
{
    public partial class Form_JogRobot : Form
    {
        //private ReaderAccessor m_reader1 = new ReaderAccessor();
        //private ReaderAccessor m_reader2 = new ReaderAccessor();
        //private ReaderSearcher m_searcher = new ReaderSearcher();

        //public ReaderAccessor m_reader1 = new ReaderAccessor();
        //public ReaderAccessor m_reader2 = new ReaderAccessor();
        //public ReaderSearcher m_searcher = new ReaderSearcher();

        //List<NicSearchResult> m_nicList = new List<NicSearchResult>();


        private ReaderAccessor reader1 = new ReaderAccessor();
        private ReaderAccessor reader2 = new ReaderAccessor();
        // clsPLC PLC = new clsPLC();

        fMain fmain;
        public Form_JogRobot(fMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
        }








        // Khai báo biến PLC
        public string PLC_Home_Device = "M120";
        public string PLC_Home_DONE_Device = "M10";
        public string PLC_Home_Homing_Device = "M9";
        public string PLC_ServoOFF_Device_Set = "M20";
        public string PLC_ServoON_Device_Set = "M21";
        public string PLC_JogModeON_OFF_Device = "M50";
        public string PLC_Scanner1_Device = "M110";
        public string PLC_Scanner2_Device = "M111";

        public string PLC_X_limit_Cong_Device = "M40";
        public string PLC_X_limit_Tru_Device = "M41";
        public string PLC_Y_limit_Cong_Device = "M42";
        public string PLC_Y_limit_Tru_Device = "M43";

        public string PLC_X_Current_Device = "D800";
        public string PLC_Y_Current_Device = "D802";
        public string PLC_Jog_TocDo_Device = "D804";

        public string PLC_Jog_X_Tru_Device = "M100";
        public string PLC_Jog_X_Cong_Device = "M101";
        public string PLC_Jog_Y_Tru_Device = "M102";
        public string PLC_Jog_Y_Cong_Device = "M103";

        public string PLC_ServoON_Ready_Output = "Y060";


        public short PLC_X_Current_Value;
        public short PLC_Y_Current_Value;

        public int Jog_Speed = 10;

        //public bool SCANNER_1_ON = false;
        //public bool SCANNER_2_ON = false;
        public bool SCANNER_VIEW = false;


        private void Form_JogRobot_Load(object sender, EventArgs e)
        {

            if (fmain.PLC.PLC_Connect)
            {
                fmain.PLC.Writeplc(PLC_JogModeON_OFF_Device, 1);
                timer_Jog_PLC.Enabled = true;
                timer_Jog_PLC.Interval = 100;
            }
            else
            {
                timer_Jog_PLC.Enabled = false;
                timer_Jog_PLC.Interval = 100;
            }

            btnJogServoON.BackColor = Color.Blue;
            btnJogServoON.ForeColor = Color.White;

            btnJogServoOFF.BackColor = Color.Gray;
            btnJogServoOFF.ForeColor = Color.Navy;

        }


        private delegate void delegateUserControl(string str);



        public void KetNoi_SR2000(LiveviewForm Form, string IP, ReaderAccessor m_reader)
        {

            //Stop liveview.
            Form.EndReceive();
            //Set ip address of liveview.
            Form.IpAddress = IP;
            //Start liveview.
            Form.BeginReceive();
            //Set ip address of ReaderAccessor.
            m_reader.IpAddress = IP;
            //Connect TCP/IP.
            m_reader.Connect((data) =>
            {
                //Define received data actions here.Defined actions work asynchronously.
                //"ReceivedDataWrite" works when reading data was received.
                //BeginInvoke(new delegateUserControl(ReceivedDataWrite), Encoding.ASCII.GetString(data));
            });

        }

        private void ReceivedDataWrite(string receivedData, ReaderAccessor m_reader, TextBox txt)
        {
            txt.Text = ("[" + m_reader.IpAddress + "][" + DateTime.Now + "]" + receivedData);
            //txtDataTextScan2.Text = ("[" + m_reader.IpAddress + "][" + DateTime.Now + "]" + receivedData);
        }



        private void btnThoatJogRobot_Click(object sender, EventArgs e)
        {
            fmain.PLC.Writeplc(PLC_JogModeON_OFF_Device, 0);
            this.Close();
        }

        private void btnJogHome_Click(object sender, EventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Home_Device, 1);

            Thread.Sleep(300);
            fmain.PLC.Writeplc(PLC_Home_Device, 0);
        }

        private void btnJogTatServo_Click(object sender, EventArgs e)
        {
            fmain.PLC.Writeplc(PLC_ServoON_Device_Set, 0);
            fmain.PLC.Writeplc(PLC_ServoOFF_Device_Set, 1);

        }

        private void txtJog_TocDo_X_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Jog_Speed = int.Parse(txtJog_TocDo.Text);

                if (Jog_Speed > 100)
                    Jog_Speed = 100;

                if (Jog_Speed < 1)
                    Jog_Speed = 1;



                fmain.PLC.Writeplc(PLC_Jog_TocDo_Device, Jog_Speed);
            }
            catch
            {
                MessageBox.Show("Nhập sai", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJog_TocDo.Focus();
            }

        }



        private void btnJogTangTocX_Click(object sender, EventArgs e)
        {
            Jog_Speed = Jog_Speed + 1;
            if (Jog_Speed > 100)
                Jog_Speed = 100;
        }

        private void btnJogGiamTocX_Click(object sender, EventArgs e)
        {
            Jog_Speed = Jog_Speed - 1;
            if (Jog_Speed < 1)
                Jog_Speed = 1;
        }



        private void btnJogY_Tru_MouseDown(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_Y_Tru_Device, 1);

        }

        private void btnJogY_Tru_MouseUp(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_Y_Tru_Device, 0);

        }

        private void btnJogY_Cong_MouseDown(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_Y_Cong_Device, 1);

        }

        private void btnJogY_Cong_MouseUp(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_Y_Cong_Device, 0);

        }

        private void btnJogX_Tru_MouseDown(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_X_Tru_Device, 1);

        }

        private void btnJogX_Tru_MouseUp(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_X_Tru_Device, 0);
        }

        private void btnJogX_Cong_MouseDown(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_X_Cong_Device, 1);

        }

        private void btnJogX_Cong_MouseUp(object sender, MouseEventArgs e)
        {
            fmain.PLC.Writeplc(PLC_Jog_X_Cong_Device, 0);
        }

        private void btnJogServoON_Click(object sender, EventArgs e)
        {
            fmain.PLC.Writeplc(PLC_ServoOFF_Device_Set, 0);
            fmain.PLC.Writeplc(PLC_ServoON_Device_Set, 1);
        }

        private void Form_JogRobot_FormClosing(object sender, FormClosingEventArgs e)
        {

            fmain.PLC.Writeplc(PLC_JogModeON_OFF_Device, 0);
            timer_Jog_PLC.Dispose();
            timer_Jog_PLC.Enabled = false;

            SCANNER_VIEW = false;

            fmain.Tao_Log_Voi_Noi_Dung_La("JOG MODE OFF");

        }

        private void timer_Jog_PLC_Tick(object sender, EventArgs e)
        {
            //Jog_Speed = int.Parse(txtJog_TocDo.Text);

            txtManualDiemChay.Text = fmain.DiemChayManual.ToString();
            fmain.PLC.Writeplc(fmain.PLC_MANUAL_ROBOT_POS_NO, fmain.DiemChayManual + 1);


            txtJog_TocDo.Text = Jog_Speed.ToString();
            fmain.PLC.Writeplc(PLC_Jog_TocDo_Device, Jog_Speed);

            lbl_Jog_X_Current.Text = fmain.Current_X_value.ToString("0,0");
            lbl_Jog_Y_Current.Text = fmain.Current_Y_value.ToString("0,0");


            // Limit X+
            if (fmain.PLC.readplc(PLC_X_limit_Cong_Device) == "1")
            {
                pictureBox_Jog_X_limit_Cong.Image = Properties.Resources.LampON;
            }
            else
            {
                pictureBox_Jog_X_limit_Cong.Image = Properties.Resources.LampOFF;
            }

            // Limit X_
            if (fmain.PLC.readplc(PLC_X_limit_Tru_Device) == "1")
            {
                pictureBox_Jog_X_limit_Tru.Image = Properties.Resources.LampON;
            }
            else
            {
                pictureBox_Jog_X_limit_Tru.Image = Properties.Resources.LampOFF;
            }

            // Limit Y+
            if (fmain.PLC.readplc(PLC_Y_limit_Cong_Device) == "1")
            {
                pictureBox_Jog_Y_limit_Cong.Image = Properties.Resources.LampON;
            }
            else
            {
                pictureBox_Jog_Y_limit_Cong.Image = Properties.Resources.LampOFF;
            }

            // Limit Y_
            if (fmain.PLC.readplc(PLC_Y_limit_Tru_Device) == "1")
            {
                pictureBox_Jog_Y_limit_Tru.Image = Properties.Resources.LampON;
            }
            else
            {
                pictureBox_Jog_Y_limit_Tru.Image = Properties.Resources.LampOFF;
            }

            if (fmain.PLC.readplc(fmain.PLC_ALARM_ON) == "1")
            {
                btnJogReset.BackColor = Color.Yellow;
            }
            else
            {
                btnJogReset.BackColor = Color.Gray;
            }




            // Đèn HOME OK
            if (fmain.PLC.readplc(PLC_Home_DONE_Device) == "1")
            {
                btnJogHome.BackColor = Color.Blue;
            }
            else
            {
                btnJogHome.BackColor = Color.Gray;
            }

            // Đèn SERVO ON
            if (fmain.PLC.readplc(PLC_ServoON_Ready_Output) == "1")
            {
                btnJogServoON.BackColor = Color.Green;
                btnJogServoOFF.BackColor = Color.Gray;
            }
            else
            {
                btnJogServoON.BackColor = Color.Gray;
                btnJogServoOFF.BackColor = Color.Red;
            }



        }

        private void btnJogReset_Click(object sender, EventArgs e)
        {
            fmain.PLC.Writeplc(fmain.PLC_MenuBar_Reset, 1);
            Thread.Sleep(200);
            fmain.PLC.Writeplc(fmain.PLC_MenuBar_Reset, 0);

        }

        private void btnJogBuzzerStop_Click(object sender, EventArgs e)
        {
            if (fmain.PLC.readplc(fmain.PLC_MenuBar_BuzzerStop) == "1")
            {
                fmain.PLC.Writeplc(fmain.PLC_MenuBar_BuzzerStop, 0);
                btnJogBuzzerStop.BackColor = Color.Gray;
                fmain.btnBuzzerStop.BackColor = Color.Gray;
            }
            else
            {
                fmain.PLC.Writeplc(fmain.PLC_MenuBar_BuzzerStop, 1);
                btnJogBuzzerStop.BackColor = Color.Orange;
                fmain.btnBuzzerStop.BackColor = Color.Orange;
            }
        }

        private void btnNextPos_Click(object sender, EventArgs e)
        {
            fmain.DiemChayManual = fmain.DiemChayManual + 1;
            if (fmain.DiemChayManual > int.Parse(fmain.txtSoDiemChayRoBot.Text))
            {
                fmain.DiemChayManual = int.Parse(fmain.txtSoDiemChayRoBot.Text);
            }

            txtManualDiemChay.Text = fmain.DiemChayManual.ToString();
            fmain.PLC.Writeplc(fmain.PLC_MANUAL_ROBOT_POS_NO, fmain.DiemChayManual + 1);
        }

        private void btnBackPos_Click(object sender, EventArgs e)
        {


            fmain.DiemChayManual = fmain.DiemChayManual - 1;
            if (fmain.DiemChayManual < 0)
            {
                fmain.DiemChayManual = 0;
            }
            txtManualDiemChay.Text = fmain.DiemChayManual.ToString();
            fmain.PLC.Writeplc(fmain.PLC_MANUAL_ROBOT_POS_NO, fmain.DiemChayManual + 1);


        }

        private void btnMoveRandomPos_Click(object sender, EventArgs e)
        {
            fmain.PLC.Writeplc(fmain.PLC_MANUAL_ROBOT_MOVE, 1);
            Thread.Sleep(200);
            fmain.PLC.Writeplc(fmain.PLC_MANUAL_ROBOT_MOVE, 0);

        }

        private void txtManualDiemChay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(txtManualDiemChay.Text);
                if (temp < 0)
                {
                    temp = 0;
                    txtManualDiemChay.Text = temp.ToString();
                }
                if (temp > int.Parse(fmain.txtSoDiemChayRoBot.Text))
                {
                    temp = int.Parse(fmain.txtSoDiemChayRoBot.Text);
                    txtManualDiemChay.Text = temp.ToString();
                }
                fmain.DiemChayManual = temp;

                //txtManualDiemChayRobot.Text = DiemChayManual.ToString();
                fmain.PLC.Writeplc(fmain.PLC_MANUAL_ROBOT_POS_NO, fmain.DiemChayManual + 1);
            }
            catch
            {
                MessageBox.Show("Data nhập không đúng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fmain.DiemChayManual = 0;
                txtManualDiemChay.Text = "0";
            }
        }

        private void btnViewBarcode_Click(object sender, EventArgs e)
        {
            if (SCANNER_VIEW)
            {
                SCANNER_VIEW = false;
                btnViewBarcode.BackColor = Color.Gray;
                btnViewBarcode.ForeColor = Color.White;

            }

            else
            {
                SCANNER_VIEW = true;
                btnViewBarcode.BackColor = Color.Blue;
                btnViewBarcode.ForeColor = Color.White;

            }

        }










    }
}
