using CONTROL_ROBOT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Keyence.AutoID.SDK;

namespace CONTROL_ROBOT
{
    public partial class fMain : Form
    {
        // Tạo region = cách #region sau đó ấn Tab

        #region Khai báo FORM, CLASS

        Form_Login Login = new Form_Login();
        Form_JogRobot fJogRobot;
        //Form_AlarmPLC Alarm = new Form_AlarmPLC();
        Form_AlarmPLC fAlarm; // khởi tạo tại form load
        //Form_ProgressBarPLC ProgressBarPLC = new Form_ProgressBarPLC();
        Form_ProgressBarPLC fProgressBarPLC;
        Process aProcess = Process.GetCurrentProcess();
        public clsPLC PLC;
        clshienthidata HienThi = new clshienthidata();
        clsTable Table = new clsTable();
        clsModel Model = new clsModel();
        clsFile_txt TEXT = new clsFile_txt();
        clsExportData DATA = new clsExportData();
        clsSocket socket;
        Scanner_Ethernet Scaner1;
        Scanner_Ethernet Scaner2;





        clsMES MES = new clsMES();
        clsLocaldb localdb;








        List<NicSearchResult> m_nicList = new List<NicSearchResult>();

        public ReaderAccessor m_reader1 = new ReaderAccessor();
        public ReaderAccessor m_reader2 = new ReaderAccessor();
        //private ReaderSearcher m_searcher = new ReaderSearcher();




        OptionDefine.clsCheckTrungInformation checkData = new OptionDefine.clsCheckTrungInformation();
        List<string> Listbarcode = new List<string>();
        List<string> ListTest = new List<string>();





        #endregion



        #region Khai báo Thread

        Thread thread_Update_Date_Time;     // Tạo thread để update ngày tháng
        Thread thread_Quet_PLC1;             // Tạo thread để quét PLC
        Thread thread_Quet_PLC2;             // Tạo thread để quét PLC
        Thread thread_Quet_PLC_Alarm;       // Luồng xử lý alarm PLC
        Thread Thread_Input_Monitor;
        Thread Thread_Output_Monitor;

        Thread Thread_XuLyData;
        Thread Thread_ReadCodeJig;
        Thread Monitor;

        Thread thread_KetNoiScanner;

        Thread thread_ManualInput;


        #endregion



        #region Khai báo biến
        public int cycletime = 0;



        public int counter_total_input = 0;
        public int counter_total_OK = 0;
        public int counter_total_NG = 0;




        bool KhoaCheoQuetScannerView = false;




        public bool KIEM_TRA_MODEL = false;
        //bool MonitorIsRunning = false;


        public bool AllowSendToMes = true;
        public bool OfflineMode = false;
        //public Int32 Current_X_value = 0;
        //public Int32 Current_Y_value = 0;

        //public int Current_X_value = 0;
        //public int Current_Y_value = 0;

        public short Current_X_value = 0;
        public short Current_Y_value = 0;

        //public decimal Current_X_value = 0;
        //public decimal Current_Y_value = 0;

        public bool Update_Date_Time = true;
        public bool tab_monitor_on = false;
        public bool input_monitor = true;
        public bool output_monitor = true;
        public bool quet_PLC_1 = true;
        public bool quet_PLC_2 = true;
        public bool monitor_Alram = true;
        public bool alarm_detect_on = false;

        public bool isStop = true;
        public bool isScan = false;
        public bool isAlarm = false;
        public bool MES_change_status = false;
        public bool ArrayUse = false;
        public bool Double_Check_Code = true;


        public int Array_Khoang_Cach_X = 0;
        public int Array_Khoang_Cach_Y = 0;
        public int Array_X = 0;
        public int Array_Y = 0;
        public int TotalArray = 0;
        public int KieuSapXepArrayPCMTheoScanner = 0;
        public int Select_Mode_Array = 1;




        public int DiemChayManual = 1;


        //public bool DieuKien_Save = false;
        public bool Teaching_Ready_Enable = false;

        public string CodeJig = "";
        public string Type_Jig = "";
        public string FileNameModel;
        public string MES_Connecting = "CANT";
        public string Current_Position_Robot = "";
        public string ScanReadyToRun = "";
        public string Auto_Stop_Mode = "";
        public string ResetButtomIsOn = "";


        //public string[] barcode = new string[41];
        public string[] errorCode = new string[41];
        public string[] ArrayCode = new string[41];
        public string[] ManualArrayCode;
        public string[] ManualArrayCode_DaInput;

        public int[] status_PCM = new int[41];
        public int[] PCM_Pos_ReadCode_Scan1 = new int[100];
        public int[] PCM_Pos_ReadCode_Scan2 = new int[100];


        public int Scanning_Step = 0;
        public int Error_Mes = 0; // Biến lỗi từ mes trả về
        public bool mes_send = true;
        public bool WaitingScan = true;
        public bool ScanningIsOn = false;


        public bool Oracle_Connect = false;
        //public 
        public int final_Pos_run = 0;
        #endregion

        Int32 port = 9004;

        // Khai báo biến PLC 


        public int Error_Set_ON = 0; // Biến lỗi từ mes trả về



        #region Khai báo device PLC


        public string PLC_PROGRAM_ON = "M5";



        public string PLC_CycleTime = "D60";
        public string PLC_Reset_CycleTime = "M104";
        public string PLC_Counter = "D62";
        public string PLC_Reset_Counter = "M105";
        public string PLC_AUTO_ON = "M60";
        public string PLC_AUTO_OFF = "M61";
        public string PLC_READY_ON = "M62";
        public string PLC_ALARM_ON = "M1100";
        public string PLC_DEMO_MODE_ON = "M65";


        public string PLC_Ready = "M86";
        public string PLC_Scan_Read_PCM_OK = "M80";
        public string PLC_Scan_Read_PCM_NG = "M81";
        public string PLC_Scan_Read_Jig_OK = "M82";
        public string PLC_Scan_Read_Jig_NG = "M83";
        public string PLC_Final_OK = "M84";
        public string PLC_Final_NG = "M85";


        // Menubar
        public string PLC_MenuBar_Ready = "M120";
        public string PLC_MenuBar_Run = "M121";
        public string PLC_MenuBar_Demo_Run = "M122";
        public string PLC_MenuBar_Stop = "M123";
        public string PLC_MenuBar_Reset = "M124";
        public string PLC_MenuBar_BuzzerStop = "M125";
        public string PLC_ManuBar_By_Pass = "M126";

        public string PLC_MenuBar_Button_Main = "M130";
        public string PLC_MenuBar_Button_Manual = "M131";
        public string PLC_MenuBar_Button_Teach = "M132";
        public string PLC_MenuBar_Button_Setting = "M133";
        public string PLC_MenuBar_Button_Calibration = "M134";
        public string PLC_MenuBar_Button_IO = "M135";

        // Servo_X
        public string PLC_Servo_Alarm_X_COMMEND = "NORMAL";
        public string PLC_Servo_CodeLoiTruc_X = "D10";
        public string PLC_Servo_MomenTaiTruc_X = "D12";
        public string PLC_Servo_MomenMaxTruc_X = "D14";

        // Servo_Y
        public string PLC_Servo_Alarm_Y_COMMEND = "NORMAL";
        public string PLC_Servo_CodeLoiTruc_Y = "D20";
        public string PLC_Servo_MomenTaiTruc_Y = "D22";
        public string PLC_Servo_MomenMaxTruc_Y = "D24";

        // Monitor servo
        public string PLC_Servo_X_Current = "D800";
        public string PLC_Servo_Y_Current = "D900";
        public string PLC_Servo_Current_Position = "D820";


        // Manual PLC
        public string PLC_MANUAL_ROBOT_MOVE = "M140";
        public string PLC_MANUAL_ROBOT_POS_NO = "D402";

        public string PLC_MANUAL_CLAMP_1_UP = "M142";
        public string PLC_MANUAL_CLAMP_1_DOWN = "M143";
        public string PLC_MANUAL_CLAMP_2_UP = "M144";
        public string PLC_MANUAL_CLAMP_2_DOWN = "M145";
        public string PLC_MANUAL_STOPPER_3_UP = "M146";
        public string PLC_MANUAL_STOPPER_3_DOWN = "M147";
        public string PLC_MANUAL_CNV_RUN = "M148";
        public string PLC_MANUAL_CNV_STOP = "M149";
        public string PLC_MANUAL_SCANNER_1_READ = "M110";
        public string PLC_MANUAL_SCANNER_2_READ = "M111";








        // Đầu vào  (LOAD TỪ FILE IO.TXT)
        public string PLC_INPUT_EMG_BUTTON;
        public string PLC_INPUT_READY_BUTTON;
        public string PLC_INPUT_START_BUTTON;
        public string PLC_INPUT_STOP_BUTTON;
        public string PLC_INPUT_RESET_BUTTON;
        public string PLC_INPUT_BUZZER_BUTTON;
        public string PLC_INPUT_SENSOR_1;
        public string PLC_INPUT_SENSOR_2;
        public string PLC_INPUT_SENSOR_3;
        public string PLC_INPUT_CLAMP_1_UP;
        public string PLC_INPUT_CLAMP_2_UP;
        public string PLC_INPUT_STOPPER_3_UP;
        public string PLC_INPUT_STOPPER_3_DOWN;
        public string PLC_INPUT_DOOR;
        public string PLC_INPUT_LIGHTCURTAIN;

        // Đầu ra (LOAD TỪ FILE IO.TXT)
        public string PLC_OUTPUT_TL_R;
        public string PLC_OUTPUT_TL_Y;
        public string PLC_OUTPUT_TL_G;
        public string PLC_OUTPUT_TL_B;
        public string PLC_OUTPUT_CLAMP1;
        public string PLC_OUTPUT_CLAMP2;
        public string PLC_OUTPUT_STOPPER3;
        public string PLC_OUTPUT_CONVEYOR;
        public string PLC_OUTPUT_SCANNER1;
        public string PLC_OUTPUT_SCANNER2;
        public string PLC_OUTPUT_LAMP_READY;
        public string PLC_OUTPUT_LAMP_START;
        public string PLC_OUTPUT_LAMP_STOP;
        public string PLC_OUTPUT_LAMP_RESET;
        public string PLC_OUTPUT_LAMP_BZ;






        // DEVIVE SETTING TOWER LAMP
        // AUTO
        public string PLC_TL_AUTO_R = "D300.0";
        public string PLC_TL_AUTO_Y = "D301.0";
        public string PLC_TL_AUTO_G = "D302.0";
        public string PLC_TL_AUTO_B = "D303.0";
        // STOP
        public string PLC_TL_STOP_R = "D310.0";
        public string PLC_TL_STOP_Y = "D311.0";
        public string PLC_TL_STOP_G = "D312.0";
        public string PLC_TL_STOP_B = "D313.0";
        // ALARM
        public string PLC_TL_ALARM_R = "D320.0";
        public string PLC_TL_ALARM_Y = "D321.0";
        public string PLC_TL_ALARM_G = "D322.0";
        public string PLC_TL_ALARM_B = "D323.0";
        // WAITING
        public string PLC_TL_WAITING_R = "D330.0";
        public string PLC_TL_WAITING_Y = "D331.0";
        public string PLC_TL_WAITING_G = "D332.0";
        public string PLC_TL_WAITING_B = "D333.0";
        // SCANNING
        public string PLC_TL_SCANNING_R = "D340.0";
        public string PLC_TL_SCANNING_Y = "D341.0";
        public string PLC_TL_SCANNING_G = "D342.0";
        public string PLC_TL_SCANNING_B = "D343.0";
        // SCAN_DONE RESULT OK
        public string PLC_TL_SCAN_RESULT_OK_R = "D350.0";
        public string PLC_TL_SCAN_RESULT_OK_Y = "D351.0";
        public string PLC_TL_SCAN_RESULT_OK_G = "D352.0";
        public string PLC_TL_SCAN_RESULT_OK_B = "D353.0";
        // SCAN_DONE RESULT NG
        public string PLC_TL_SCAN_RESULT_NG_R = "D360.0";
        public string PLC_TL_SCAN_RESULT_NG_Y = "D361.0";
        public string PLC_TL_SCAN_RESULT_NG_G = "D362.0";
        public string PLC_TL_SCAN_RESULT_NG_B = "D363.0";












        #endregion



        #region Khai báo biến tạo commend log

        string COMMEND_LOG = "MACHINE OK";



        #endregion



        #region Khai báo device bộ nhớ đệm servo PLC
        // Từ Device D1000 ~ D9000

        //~~~~~~~~~~~~~~~~~~~~~~~~~ 32 bit ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // D1000 X_P_READY
        // D1002 X_P1

        // D2500 Y_P_READY
        // D2502 Y_P1

        // D4000 SPPEED_READY
        // D4001 SPEED_P1


        //~~~~~~~~~~~~~~~~~~~~~~~~~ 16 bit ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // D5000 DELAY_READY
        // D5001 DELAY_P1

        // D6001 SCANNER_P1
        // D7001 SCANNER_P2


        // D8000   END OF POSITION AUTO




        public int Vi_Tri_Run_Cuoi_Cung = 0; // Vị trí này để dừng servo
        public string PLC_RUNNING_DEVICE_END_OF_POSITION = "D8000";

        // Vị trí ready
        public string PLC_RUNNING_DEVICE_READY_POS_X = "D1000";
        public string PLC_RUNNING_DEVICE_READY_POS_Y = "D2000";
        public string PLC_RUNNING_DEVICE_Ready_Speed = "D3000";
        public string PLC_RUNNING_DEVICE_Ready_Delay = "D4000";


        // Vị trí chạy auto
        // POS 1
        public string PLC_RUNNING_DEVICE_POS_X_P1 = "D1001";
        public string PLC_RUNNING_DEVICE_POS_Y_P1 = "D2001";
        public string PLC_RUNNING_DEVICE_SPEED_P1 = "D3001";
        public string PLC_RUNNING_DEVICE_DELAY_P1 = "D4001";
        public string PLC_RUNNING_DEVICE_SCANNER_1_P1 = "D5001";
        public string PLC_RUNNING_DEVICE_SCANNER_2_P1 = "D6001";

        #endregion


        #region Khai báo device alarm PLC
        public string PLC_ALARM_SERVO_X_LIMIT_CONG = "M5000";
        public string PLC_ALARM_SERVO_X_LIMIT_TRU = "M5001";
        public string PLC_ALARM_SERVO_Y_LIMIT_CONG = "M5002";
        public string PLC_ALARM_SERVO_Y_LIMIT_TRU = "M5003";

        public string PLC_ALARM_EMG = "M5004";


        public string PLC_ALARM_LIGHT_CURTAIN = "M5005";


        public string PLC_ALARM_SERVO_X_OVER_LOAD = "M5006";
        public string PLC_ALARM_SERVO_Y_OVER_LOAD = "M5007";

        public string PLC_ALARM_READ_CODE_JIG_NG = "M5013";

        public string PLC_ALARM_TOTAL_RESULT_READ_NG = "M5014";

        public string PLC_ALARM_STOPPER_UP_ERROR = "M5015";




        #endregion










































































































        // MAIN PROGRAM CONTROL ROBOT


        public fMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;        // Cho phep cross du lieu  khi chạy thread  
        }



        private bool programrunning()
        {
            string aProcName = aProcess.ProcessName;
            if (Process.GetProcessesByName(aProcName).Length > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        // Form load ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void fMain_Load(object sender, EventArgs e)
        {


            #region Kiểm tra chương trình đã bật chưa
            if (programrunning() == true) // Kiểm tra chương trình đã mở hay chưa
            {
                //MessageBox.Show("Chương trình này đã được mở. Hãy kiểm tra lại!", "Lỗi");
                MessageBox.Show("Chương trình đang mở rồi nhé !!! ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Dispose();
            }
            #endregion

            #region Version info
            string ver = "";
            ver = "VER20220524"; //make origin           
            ver = "VER20220617"; //Ver hiện tại đang chạy
            ver = "VER20220619"; //Ver Mr Phú cải tiến
            ver = "VER20220620"; //Update giao diện
            ver = "VER20220624"; //Update giao diện mới nhất, tối ưu 
            ver = "VER20220628"; //Fix một số lỗi
            ver = "VER20220629"; //Fix một số lỗi (Huy cải tiến)
            ver = "VER20220701"; //Cải tiến đọc code NG, lưu log đọc code
            ver = "VER20220705"; //Thêm lựa chọn xuất file kết quả cho từng loại máy function
            ver = "VER20220711"; //Update nhân array thêm cách sắp xếp pcm , thêm admin đăng nhập quyền thay đổi setting
            ver = "VER20220817"; //Update kiểm tra lỗi double code, chọn nếu double thì bỏ qua lỗi và vẫn tạo file
            ver = "VER20221013AF8"; //Update thêm PO vào trước mã các barcode để phân loại code theo model
            ver = "VER20221015AF9"; //Update thêm đẩy code manual lên mes và sửa lại next PO từ 20h trở đi
            ver = "VER20221019AF10"; //Update thêm đẩy code manual lên mes lưu file vào link
            ver = "VER20221021AF11"; //Update tách lot hàng 
            ver = "VER20221022AF12"; //Update tách lot hàng lưu theo model
            ver = "VER20221026AF13"; //Update thông báo code PCM OK là OK
            ver = "VER20221101AF14"; //Update vấn đề đọc code jig NG sau đó không chạy lại được và tách lot hàng nếu thiếu data cũng ko chạy được 
            ver = "VER20221101AF15"; //Update vấn đề load link file folder chứa add code nếu không tồn tại sẽ alarm
            ver = "VER20221101AF16"; //Test có lỗi
            ver = "VER20221101AF17"; //Thêm phần hiển thị trạng thái của chế độ các mode running




            lblVersion.Text = ver;
            //this.Text = this.Text + " " + ver;
            #endregion

            #region Khởi tạo cls
            PLC = new clsPLC(this); // This để có thể truy cập fmain từ cls PLC
            fJogRobot = new Form_JogRobot(this);
            fAlarm = new Form_AlarmPLC(this);
            socket = new clsSocket(this); // Khởi tạo cls socket mes
            localdb = new clsLocaldb();

            //MES.Dbsource = "VNMES";
            //MES.User = "vncmesadm";
            //MES.Pass = "thgkr007~";
            #endregion

            #region Khởi tạo bộ nhớ
            // Load check box mes data
            LoadCheckBoxMes();
            // Load data counter
            LoadDataCounter();
            // Load kết nối MES
            LoadMesConfig();
            //// Load link save file
            //LoadCaiDatSaveLog();
            // Load scannner config
            LoadScannerConfig();
            // Load data cũ
            LoadPLCconfig();
            // Load tower lamp setting
            LoadTowerLampConfig();
            // Load deveice setting
            LoadDevivePLCConfig();


            // Load setting tach lot
            //LOAD_SETTING_TACH_LOT();
            TEXT.Load_Setting_Tach_Lot_Hang_Theo_Data
               (
               txtLinkFIleDataSoSanhDeTachLot
               );






            // Load data oracel setting
            LoadOracelSetting();
            KetNoiOracel(); // Kết nối mạng oracel để tải data PO

            // Load manual input to mes setting
            Load_Manual_Input();









            // Load IO Device PLC
            Load_IO_PLC();
            // Kết nối PLC
            khoiTao_PLC();
            // Chưa làm gì
            KhoiTaoDevicePLC();
            // Load form login
            login_program();
            // Load setting tower lamp
            Call_Setting_TowerLamp();
            #endregion

            #region Mở các thread và timer
            KhoiTaoTimer(); // ON timer quét để chạy các thread
            #endregion

            #region Kết nối scanner và mes
            KetNoiScanner(); // Kết nối scanner
            KetNoiMes(); // Kết nối mes nếu điều kiện OK

            #endregion











            if (string.IsNullOrEmpty(txtOracel_PO_InUse.Text))
            {
                txtOracel_PO_InUse.BackColor = Color.Red;
            }
            else
            {
                txtOracel_PO_InUse.BackColor = Color.Green;
            }









            Update_DateTimePikerDaySelect();




            Double_Check_Code = true;
            checkBox_Double_Check.Checked = true;
            checkBox_Double_Check.ForeColor = Color.Blue;

            checkBox_typeCodeJig_DateTime.Checked = false; // Khởi tạo check box nhưng sau đó lại load theo model
            checkBox_Mode_1.Checked = true; // Mặc định chọn khi load sẽ thay đổi theo model
            PLC.Writeplc(PLC_PROGRAM_ON, 1); // Biến PLC biết chương trình mở chưa

            HienThiModeRunning();

            // Tạo log file          
            Tao_Log_Voi_Noi_Dung_La("FORM OPEN COMPLETED");
        }


        public void KetNoiScanner()
        {
            // tạo thread chạy kết nối scanner 
            thread_KetNoiScanner = new Thread(Run_thread_KetNoiScanner);
            thread_KetNoiScanner.IsBackground = true;
            thread_KetNoiScanner.Start();
        }



        #region Oracel

        public void KetNoiOracel()
        {
            //MES.Dbsource = "VNMES";
            //MES.User = "vncmesadm";
            //MES.Pass = "thgkr007~";

            MES.Dbsource = txtOracleMesDBSource.Text;
            MES.User = txtOracleMesUser.Text;
            MES.Pass = txtOracleMesPass.Text;




            if (MES.checkconnection())
            {
                //lbl_Oracel
                lbl_Oracle.BackColor = Color.Green;


                //Tải tên line vào combobox
                DataSet dsLine = new DataSet();
                dsLine = MES.TaiLineName();//show linename in MIH
                updateAllLineName(dsLine.Tables["tbllinename"], cbxOracleMesLineNo, 0);
                Oracle_Connect = true;
            }
            else
            {
                lbl_Oracle.BackColor = Color.Red;
                Oracle_Connect = false;
            }
        }

        public void updateAllLineName(DataTable dtoracle, ComboBox comBox, int noColumm)
        {

            foreach (DataRow myrow in dtoracle.Rows)
            {
                comBox.Items.Add(myrow.ItemArray[noColumm].ToString());
            }

        }


        public void LoadOracelSetting()
        {
            TEXT.LoadOracleSetting
               (
               txtOracleMesDBSource,
               txtOracleMesUser,
               txtOracleMesPass,
               cbxOracleMesLineNo,
               cbxLuaChonAddThemMaProduct,
               txtManualAddProduct,
               checkBox_AutoAddProduct

               );
        }


        public void UpdateAllToGrid(DataTable dtOracle, DataGridView dtView)
        {

            dtView.Columns.Clear();

            dtView.DataSource = dtOracle;

            //Add more 1 colum o cot dau tien
            DataGridViewButtonColumn EXCUTE = new DataGridViewButtonColumn();
            EXCUTE.HeaderText = "EXCUTE";
            dtView.Columns.Insert(0, EXCUTE);

            //Font 
            //dtView.Font = new Font("Times New Roman", 12);
            dtView.Font = new Font("Segoe UI", 12);

            //Label all Cells of the first column
            for (int i = 0; i < dtView.Rows.Count - 1; i++)
            {
                dtView.Rows[i].Cells[0].Value = "TRANSFER";


            }

        }

        public void TaiDataOracle(TextBox txtName, DataGridView dgvData) // tải khi ấn nút tải, khi ấn nút start, khi call model, time hiện tại bằng 8h01,
        {

            txtName.Text = "";
            if (Oracle_Connect == true)
            {
                try
                {
                    MES.SelectTime = dateTimePickerDaySelect.Value.ToString("yyyyMMdd");

                    //Line CODE
                    MES.SelectLineCode = cbxOracleMesLineNo.Text;

                    //****************
                    //Tai thong tin vao Grid

                    //Tai tat ca cac thong tin tu MES/CMES
                    DataSet ds = new DataSet();
                    ds = MES.TaiData();
                    UpdateAllToGrid(ds.Tables["tblallinfo"], dgvOracleData);


                    for (int i = 0; i < dgvData.RowCount - 1; i++)
                    {
                        if (dgvData.Rows[i].Cells[8].Value.ToString() == "In Use") // PO đang sử dụng
                        {
                            txtName.Text = dgvData.Rows[i].Cells[5].Value.ToString();
                            i = dgvData.RowCount + 1;
                        }

                    }


                }
                catch
                {
                    MessageBox.Show("Tải thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối oracle", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }






























































































        #endregion












        public void KetNoiMes()
        {
            if (checkBox_MesON.Checked)
            {
                Connect_MES();
            }
        }



        public void KhoiTaoTimer() // Timer này quét khởi tạo các thread
        {
            timerMain.Enabled = true;
            timerMain.Interval = 100;
            timerMain.Start();



            timer_Barcode.Enabled = true; // Timer quét liên quan đọc data barcode
            timer_Barcode.Interval = 300;
            timer_Barcode.Start();




        }


        public void Run_thread_KetNoiScanner()
        {
            Scaner1 = new Scanner_Ethernet();
            Scaner2 = new Scanner_Ethernet();

            Connect_Scanner();



            ViewScanner(liveviewForm1, tb_IPscanner1.Text, m_reader1);
            ViewScanner(liveviewForm2, tb_IPscanner2.Text, m_reader2);







        }




        public void LoadDevivePLCConfig()
        {
            TEXT.LoadDevivePLC
                (
                tb_CurrentPositionDevice,
                tb_ScanningDevive,
                tb_codeJigOKDevice,
                tb_CodeJigNGDevice,
                tb_ReadOKDevice,
                tb_ReadNGDevice,
                tb_Scan_Done_Device,
                tb_TotalOKDevice,
                tb_TotalNGDevice,
                tb_StopModeDevice,
                tb_CycleTimeScan,
                txtDelayTimeNormally,
                txtDelayTimeWhenHaveNG
                );
        }

        //public void LOAD_SETTING_TACH_LOT()
        //{
        //    TEXT.Load_Setting_Tach_Lot_Hang
        //    (
        //        txtViTriKiTuNAM,
        //        txtYEAR_NG1,
        //        txtYEAR_NG2,
        //        txtYEAR_NG3,
        //        txtYEAR_NG4,
        //        txtYEAR_NG5,
        //        txtYEAR_NG6,
        //        txtViTriKiTuTHANG,
        //        txtMONTH_NG1,
        //        txtMONTH_NG2,
        //        txtMONTH_NG3,
        //        txtMONTH_NG4,
        //        txtMONTH_NG5,
        //        txtMONTH_NG6,
        //        txtMONTH_NG7,
        //        txtMONTH_NG8,
        //        txtMONTH_NG9,
        //        txtMONTH_NG10,
        //        txtMONTH_NG11,
        //        txtMONTH_NG12,
        //        txtYEAR_OK
        //    );

        //    TEXT.Load_Setting_Tach_Lot_Hang_Theo_Data
        //        (
        //        txtLinkFIleDataSoSanhDeTachLot
        //        );



        //}




        public void LoadMesConfig() // Load setting mes 
        {
            TEXT.Load_Setting_Mes(tb_IPMES, tb_LineNo, tb_MCID, tb_StnID, tb_PortMES, tb_WorkerID);
        }

        //public void LoadCaiDatSaveLog() // Load setting save log
        //{
        //    TEXT.Load_Log_Barcode(checkBox_SaveLogFileBarcodePCM);
        //}


        public void LoadScannerConfig() // Load setting scanner
        {
            TEXT.LoadScannerSettingConfig(tb_IPscanner1, tb_IPscanner2);
        }

        public void KhoiTaoDevicePLC()
        {
            // Khởi tạo toàn bộ các devive (đang sử dụng là các biến tạo sẵn khi nào rảnh thì update)
        }



        public void SaveModel()
        {
            if (KiemTraDataTachLot())
            {
                string DuongDan;

                DuongDan = lblLinkModel.Text;
                try
                {
                    Model.TaoModel(
                        dgvTeachingSub,
                        dgvTeachingMain,
                        DuongDan,
                        // Array
                        checkBox_Use_NoUse_Array,
                        checkBox_Mode_1,
                        checkBox_Mode_2,
                        checkBox_Mode_3,
                        checkBox_Mode_4,
                        txtKhoangCach_X_aray,
                        txtKhoangCach_Y_aray,
                        txt_X_aray,
                        txt_Y_aray,
                        checkBox_KhongCanSapXep,
                        checkBox_SapXepKieuTinhTien,
                        checkBox_SapXepKieuZicZac,
                        // Ready
                        txtReady_X,
                        txtReady_Y,
                        txtReady_Speed,
                        txtReady_DelayTime,
                        txtChonScannerDocCodeJig,
                        // Offset
                        txtOffsetX,
                        txtOffsetY,
                        txtOffsetSpeed,
                        txtOffsetDelayTime,
                        checkBox_typeCodeJig_DateTime,
                        checkBox_CodeJig_Only,
                        tb_LinkAddCode,
                        // Tách lot phân loại
                            checkBox_TachLotTheoNgayThangON,
                            checkBox_TachLotTheoFileDataON,
                            txtViTriKiTuNAM,
                            txtYEAR_NG1,
                            txtYEAR_NG2,
                            txtYEAR_NG3,
                            txtYEAR_NG4,
                            txtYEAR_NG5,
                            txtYEAR_NG6,
                            txtViTriKiTuTHANG,
                            txtMONTH_NG1,
                            txtMONTH_NG2,
                            txtMONTH_NG3,
                            txtMONTH_NG4,
                            txtMONTH_NG5,
                            txtMONTH_NG6,
                            txtMONTH_NG7,
                            txtMONTH_NG8,
                            txtMONTH_NG9,
                            txtMONTH_NG10,
                            txtMONTH_NG11,
                            txtMONTH_NG12,
                            txtYEAR_OK
                        );

                    lblLinkModel.Text = DuongDan;
                    Tao_Log_Voi_Noi_Dung_La("MODEL SAVE OK");

                    MessageBox.Show("Lưu model thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lưu model thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void SaveAsModel()
        {
            if (KiemTraDataTachLot())
            {
                string DuongDan;
                SaveFileDialog SaveNewModel = new SaveFileDialog();
                SaveNewModel.FileName = "Tên_model";
                if (SaveNewModel.ShowDialog() == DialogResult.OK)
                {
                    DuongDan = SaveNewModel.FileName + ".ini";
                    try
                    {
                        Model.TaoModel(
                        dgvTeachingSub,
                        dgvTeachingMain,
                        DuongDan,
                            // Array
                        checkBox_Use_NoUse_Array,
                        checkBox_Mode_1,
                        checkBox_Mode_2,
                        checkBox_Mode_3,
                        checkBox_Mode_4,
                        txtKhoangCach_X_aray,
                        txtKhoangCach_Y_aray,
                        txt_X_aray,
                        txt_Y_aray,
                        checkBox_KhongCanSapXep,
                        checkBox_SapXepKieuTinhTien,
                        checkBox_SapXepKieuZicZac,
                            // Ready
                        txtReady_X,
                        txtReady_Y,
                        txtReady_Speed,
                        txtReady_DelayTime,
                        txtChonScannerDocCodeJig,
                            // Offset
                        txtOffsetX,
                        txtOffsetY,
                        txtOffsetSpeed,
                        txtOffsetDelayTime,
                        checkBox_typeCodeJig_DateTime,
                        checkBox_CodeJig_Only,
                        tb_LinkAddCode,

                            // Tách lot phân loại
                            checkBox_TachLotTheoNgayThangON,
                            checkBox_TachLotTheoFileDataON,
                            txtViTriKiTuNAM,
                            txtYEAR_NG1,
                            txtYEAR_NG2,
                            txtYEAR_NG3,
                            txtYEAR_NG4,
                            txtYEAR_NG5,
                            txtYEAR_NG6,
                            txtViTriKiTuTHANG,
                            txtMONTH_NG1,
                            txtMONTH_NG2,
                            txtMONTH_NG3,
                            txtMONTH_NG4,
                            txtMONTH_NG5,
                            txtMONTH_NG6,
                            txtMONTH_NG7,
                            txtMONTH_NG8,
                            txtMONTH_NG9,
                            txtMONTH_NG10,
                            txtMONTH_NG11,
                            txtMONTH_NG12,
                            txtYEAR_OK
                        );


                        lblLinkModel.Text = DuongDan;
                        MessageBox.Show("Lưu model thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Tao_Log_Voi_Noi_Dung_La("SAVE AS NEW MODEL OK");
                    }
                    catch
                    {
                        Tao_Log_Voi_Noi_Dung_La("SAVE_AS THẤT BẠI");
                        MessageBox.Show("Lưu model thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        public void Tao_Log_Voi_Noi_Dung_La(string commend)
        {
            try
            {
                COMMEND_LOG = commend;
                Tao_Log_Ghi_Log(COMMEND_LOG);
            }
            catch
            {

            }

        }







        public void Call_Model()
        {
            if (isStop)   // Kiểm tra máy đã dừng chưa
            {

                if (
                Model.LOAD_MODEL
               (
               dgvTeachingSub,
               dgvTeachingMain,
               lblLinkModel,
                    // Array
               checkBox_Use_NoUse_Array,
               checkBox_Mode_1,
               checkBox_Mode_2,
               checkBox_Mode_3,
               checkBox_Mode_4,
               txtKhoangCach_X_aray,
               txtKhoangCach_Y_aray,
               txt_X_aray,
               txt_Y_aray,
               checkBox_KhongCanSapXep,
               checkBox_SapXepKieuTinhTien,
               checkBox_SapXepKieuZicZac,
                    // Ready
               txtReady_X,
               txtReady_Y,
               txtReady_Speed,
               txtReady_DelayTime,
               txtChonScannerDocCodeJig,
                    // Offset
               txtOffsetX,
               txtOffsetY,
               txtOffsetSpeed,
               txtOffsetDelayTime,
               checkBox_typeCodeJig_DateTime,
               checkBox_CodeJig_Only,
               tb_LinkAddCode,

                    // Tách lot phân loại
                        checkBox_TachLotTheoNgayThangON,
                        checkBox_TachLotTheoFileDataON,
                        txtViTriKiTuNAM,
                        txtYEAR_NG1,
                        txtYEAR_NG2,
                        txtYEAR_NG3,
                        txtYEAR_NG4,
                        txtYEAR_NG5,
                        txtYEAR_NG6,
                        txtViTriKiTuTHANG,
                        txtMONTH_NG1,
                        txtMONTH_NG2,
                        txtMONTH_NG3,
                        txtMONTH_NG4,
                        txtMONTH_NG5,
                        txtMONTH_NG6,
                        txtMONTH_NG7,
                        txtMONTH_NG8,
                        txtMONTH_NG9,
                        txtMONTH_NG10,
                        txtMONTH_NG11,
                        txtMONTH_NG12,
                        txtYEAR_OK


               ))
                {
                    LOAD_DATA_TO_PLC(); // Load to device PLC
                    KIEM_TRA_MODEL = true;  // Đã gọi model rồi 
                    timerShowMonitor.Enabled = true; // Timer show monitor code


                    if (cbxLuaChonAddThemMaProduct.Text == "YES")
                    {
                        TaiDataOracle(txtOracel_PO_InUse, dgvOracleData); // Tải thông tin PO
                    }





                    // Kiểm tra kiểu sắp xếp nhân array
                    if (checkBox_KhongCanSapXep.Checked == true)
                    {
                        KieuSapXepArrayPCMTheoScanner = 0;
                    }
                    //
                    if (checkBox_SapXepKieuTinhTien.Checked == true)
                    {
                        KieuSapXepArrayPCMTheoScanner = 1;
                    }

                    //
                    if (checkBox_SapXepKieuZicZac.Checked == true)
                    {
                        KieuSapXepArrayPCMTheoScanner = 2;
                    }







                    // Load data từng vị trí position robot ứng với PCM số nào
                    // Ví dụ : Pos_1  Scan1 đọc PCM No 1 , Scan2 đọc PCM No 6                   
                    try
                    {
                        for (int i = 0; i < dgvTeachingMain.RowCount - 1; i++)
                        {
                            PCM_Pos_ReadCode_Scan1[i + 1] = int.Parse(dgvTeachingMain.Rows[i].Cells[5].Value.ToString());
                            PCM_Pos_ReadCode_Scan2[i + 1] = int.Parse(dgvTeachingMain.Rows[i].Cells[6].Value.ToString());
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Không load được thứ tự vị trí pcm đọc code\r\nXem lại file model thiếu thông tin số pcm theo scanner#1 scanner#2", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (txtSoDiemChayRoBot.Text != "")
                    {
                        final_Pos_run = int.Parse(txtSoDiemChayRoBot.Text); // Điểm cuối running
                    }
                    else
                    {
                        MessageBox.Show("Không load được tổng số vị trí đọc code cho chương trình", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {

                }

            }
        }






        // Chọn auto mở model đang chạy tạm ko dùng option này nữa
        public void Open_Last_Model()
        {
            Model.OpenLastModel
                (
                dgvTeachingSub,
                lblLinkModel,
                // Array
                checkBox_Use_NoUse_Array,
                checkBox_Mode_2,
                txtKhoangCach_X_aray,
                txtKhoangCach_Y_aray,
                txt_X_aray,
                txt_Y_aray,
                // Ready
                txtReady_X,
                txtReady_Y,
                txtReady_Speed,
                txtReady_DelayTime,
                // Offset
                txtOffsetX,
                txtOffsetY,
                txtOffsetSpeed,
                txtOffsetDelayTime,
                Type_Jig
                );
        }



        public void ShowMainArrayTeaching()
        {
            HienThi.hienthiFileTeaching
                (
                dgvTeachingMain,
                Table.Table_Nhan_Array_Main_Add_OFFSET
                (
                dgvTeachingSub,
                //Array
                Select_Mode_Array,
                Array_Khoang_Cach_X,
                Array_Khoang_Cach_Y,
                Array_X,
                Array_Y,
                KieuSapXepArrayPCMTheoScanner,
                //Offset
                int.Parse(txtOffsetX.Text),
                int.Parse(txtOffsetY.Text),
                int.Parse(txtOffsetSpeed.Text),
                int.Parse(txtOffsetDelayTime.Text)
                )
                );
        }

        public void ShowSubTeaching()
        {
            HienThi.hienthiFileTeaching
                (
                dgvTeachingMain,
                Table.Table_Nhan_Array_Main_Add_OFFSET
                (
                dgvTeachingSub,
                //Array
                Select_Mode_Array,
                0,
                0,
                1,
                1,
                KieuSapXepArrayPCMTheoScanner,
                // Offset
                int.Parse(txtOffsetX.Text),
                int.Parse(txtOffsetY.Text),
                int.Parse(txtOffsetSpeed.Text),
                int.Parse(txtOffsetDelayTime.Text)
                )
                );
        }





        public void TaoChuongTrinh_Main_Tu_Sub()
        {
            if (ArrayUse)  // Nếu chọn nhân array 
            {
                ShowMainArrayTeaching(); // Hàm nhân array MAIN từ SUB
            }
            else  // Nếu chọn ko nhân array
            {
                ShowSubTeaching(); // Hàm gán MAIN = SUB
            }

            Vi_Tri_Run_Cuoi_Cung = dgvTeachingMain.Rows.Count - 1;    // M code servo pos cuối cùng 
            txtSoDiemChayRoBot.Text = Vi_Tri_Run_Cuoi_Cung.ToString(); // Số điểm chạy hiển thị ra màn hình

        }




        public void Load_EndPosition(DataGridView dgv, TextBox txt)
        {
            txt.Text = (dgv.Rows.Count - 2).ToString();
        }




        public void HienThiLaiData()
        {
            HienThi.hienthiFileTeaching(dgvTeachingSub, Table.Table_dgvTeaching(dgvTeachingSub));
        }

        public void HienThi_Tao_New_Model()
        {
            HienThi.hienthiFileTeaching(dgvTeachingSub, Table.NewTable());

        }





        public void SaveTeaching(DataGridView dgv_sub)
        {
            try
            {
                int row = int.Parse(txtPos.Text) - 1;

                dgv_sub.Rows[row].Cells[0].Value = (row + 1).ToString();
                dgv_sub.Rows[row].Cells[1].Value = txtXvalue.Text;
                dgv_sub.Rows[row].Cells[2].Value = txtYvalue.Text;
                dgv_sub.Rows[row].Cells[3].Value = txt_speed.Text;

                dgv_sub.Rows[row].Cells[4].Value = txtDelayTime.Text;
                dgv_sub.Rows[row].Cells[5].Value = txtScaner01_PCM_NUM.Text;

                dgv_sub.Rows[row].Cells[6].Value = txtScaner02_PCM_NUM.Text;




            }
            catch (Exception)
            {
                //MessageBox.Show("Hãy chọn vị trí muốn thay đổi ");
            }
        }

        public void SaveChangeTowerlampSetting()
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\TowerLamp.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[TOWER_LAMP_SETTING]");
                ProductionQtyWrite.WriteLine("");


                ProductionQtyWrite.WriteLine("MODE AUTO");
                ProductionQtyWrite.WriteLine("AUTO_R=" + AUTO_RUN_RED.Checked.ToString());
                ProductionQtyWrite.WriteLine("AUTO_Y=" + AUTO_RUN_YELLOW.Checked.ToString());
                ProductionQtyWrite.WriteLine("AUTO_G=" + AUTO_RUN_GREEN.Checked.ToString());
                ProductionQtyWrite.WriteLine("AUTO_B=" + AUTO_RUN_BUZZER.Checked.ToString());
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("MODE STOP");
                ProductionQtyWrite.WriteLine("STOP_R=" + STOP_RED.Checked.ToString());
                ProductionQtyWrite.WriteLine("STOP_Y=" + STOP_YELLOW.Checked.ToString());
                ProductionQtyWrite.WriteLine("STOP_G=" + STOP_GREEN.Checked.ToString());
                ProductionQtyWrite.WriteLine("STOP_B=" + STOP_BUZZER.Checked.ToString());
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("MODE ALARM");
                ProductionQtyWrite.WriteLine("ALARM_R=" + ALARM_RED.Checked.ToString());
                ProductionQtyWrite.WriteLine("ALARM_Y=" + ALARM_YELLOW.Checked.ToString());
                ProductionQtyWrite.WriteLine("ALARM_G=" + ALARM_GREEN.Checked.ToString());
                ProductionQtyWrite.WriteLine("ALARM_B=" + ALARM_BUZZER.Checked.ToString());
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("MODE WAITING");
                ProductionQtyWrite.WriteLine("WAITING_R=" + WAITING_RED.Checked.ToString());
                ProductionQtyWrite.WriteLine("WAITING_Y=" + WAITING_YELLOW.Checked.ToString());
                ProductionQtyWrite.WriteLine("WAITING_G=" + WAITING_GREEN.Checked.ToString());
                ProductionQtyWrite.WriteLine("WAITING_B=" + WAITING_BUZZER.Checked.ToString());
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("MODE SCANNING");
                ProductionQtyWrite.WriteLine("SCANNING_R=" + SCANNING_RED.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCANNING_Y=" + SCANNING_YELLOW.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCANNING_G=" + SCANNING_GREEN.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCANNING_B=" + SCANNING_BUZZER.Checked.ToString());
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("MODE SCAN_RESULT_OK");
                ProductionQtyWrite.WriteLine("SCAN_RESULT_OK_R=" + SCAN_OK_RED.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCAN_RESULT_OK_Y=" + SCAN_OK_YELLOW.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCAN_RESULT_OK_G=" + SCAN_OK_GREEN.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCAN_RESULT_OK_B=" + SCAN_OK_BUZZER.Checked.ToString());
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("MODE SCAN_RESULT_NG");
                ProductionQtyWrite.WriteLine("SCAN_RESULT_NG_R=" + SCAN_NG_RED.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCAN_RESULT_NG_Y=" + SCAN_NG_YELLOW.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCAN_RESULT_NG_G=" + SCAN_NG_GREEN.Checked.ToString());
                ProductionQtyWrite.WriteLine("SCAN_RESULT_NG_B=" + SCAN_NG_BUZZER.Checked.ToString());


                ProductionQtyWrite.WriteLine("[END]");



                ProductionQtyWrite.Close();
            }
        }




        private void SaveDataIsRunning()
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\DataIsRuning.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[RUNING DATA]");
                ProductionQtyWrite.WriteLine("[END]");

                ProductionQtyWrite.Close();
            }
        }

        private void SavePLCSetting()
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\PLC_config.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[PLC SETTING]");
                ProductionQtyWrite.WriteLine("PLC_IP=" + txtPLC_IP.Text);
                ProductionQtyWrite.WriteLine("PLC_CPU_CODE=" + txtPLC_CPU_CODE.Text);
                ProductionQtyWrite.WriteLine("PLC_RECONNECT=" + cbxChonKhoiTaoLaiPLC.Text);
                ProductionQtyWrite.WriteLine("[END]");

                ProductionQtyWrite.Close();
            }
        }

        private void SaveDataCounter()
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\Counter.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[COUNTER]");
                ProductionQtyWrite.WriteLine("TOTAL_INPUT=" + txtCounterTotal_Input.Text);
                ProductionQtyWrite.WriteLine("TOTAL_INPUT_OK=" + txtCounterTotal_Input_OK.Text);
                ProductionQtyWrite.WriteLine("TOTAL_INPUT_NG=" + txtCounterTotal_Input_NG.Text);
                ProductionQtyWrite.WriteLine("[END]");

                ProductionQtyWrite.Close();
            }
        }


        //private void SaveCheckBoxMes()
        //{
        //    FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\CheckBoxMes.ini", FileMode.Create);

        //    using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
        //    {
        //        ProductionQtyWrite.WriteLine("[CHECKBOX_DATA]");
        //        ProductionQtyWrite.WriteLine("Mes_ON=" + checkBox_MesON.Checked);
        //        ProductionQtyWrite.WriteLine("[END]");

        //        ProductionQtyWrite.Close();
        //    }
        //}
        private void SaveCheckBoxMes()
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\CheckBoxMes.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[CHECKBOX_DATA]");
                ProductionQtyWrite.WriteLine("Mes_ON=" + checkBox_MesON.Checked);
                ProductionQtyWrite.WriteLine("Tach_Lot_Theo_Year_Month=" + checkBox_TachLotTheoNgayThangON.Checked);
                ProductionQtyWrite.WriteLine("Tach_Lot_Theo_Data=" + checkBox_TachLotTheoFileDataON.Checked);
                ProductionQtyWrite.WriteLine("[END]");

                ProductionQtyWrite.Close();
            }
        }




        public void LoadTowerLampConfig()
        {

            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\TowerLamp.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {
                        // Load data setting tower lamp

                        // Mode auto run
                        case "AUTO_R":
                            AUTO_RUN_RED.Checked = bool.Parse(data[1]);
                            break;
                        case "AUTO_Y":
                            AUTO_RUN_YELLOW.Checked = bool.Parse(data[1]);
                            break;
                        case "AUTO_G":
                            AUTO_RUN_GREEN.Checked = bool.Parse(data[1]);
                            break;
                        case "AUTO_B":
                            AUTO_RUN_BUZZER.Checked = bool.Parse(data[1]);
                            break;
                        // Mode stop machine
                        case "STOP_R":
                            STOP_RED.Checked = bool.Parse(data[1]);
                            break;
                        case "STOP_Y":
                            STOP_YELLOW.Checked = bool.Parse(data[1]);
                            break;
                        case "STOP_G":
                            STOP_GREEN.Checked = bool.Parse(data[1]);
                            break;
                        case "STOP_B":
                            STOP_BUZZER.Checked = bool.Parse(data[1]);
                            break;
                        // Mode alarm
                        case "ALARM_R":
                            ALARM_RED.Checked = bool.Parse(data[1]);
                            break;
                        case "ALARM_Y":
                            ALARM_YELLOW.Checked = bool.Parse(data[1]);
                            break;
                        case "ALARM_G":
                            ALARM_GREEN.Checked = bool.Parse(data[1]);
                            break;
                        case "ALARM_B":
                            ALARM_BUZZER.Checked = bool.Parse(data[1]);
                            break;
                        // Mode waiting input
                        case "WAITING_R":
                            WAITING_RED.Checked = bool.Parse(data[1]);
                            break;
                        case "WAITING_Y":
                            WAITING_YELLOW.Checked = bool.Parse(data[1]);
                            break;
                        case "WAITING_G":
                            WAITING_GREEN.Checked = bool.Parse(data[1]);
                            break;
                        case "WAITING_B":
                            WAITING_BUZZER.Checked = bool.Parse(data[1]);
                            break;
                        // Mode scanning
                        case "SCANNING_R":
                            SCANNING_RED.Checked = bool.Parse(data[1]);
                            break;
                        case "SCANNING_Y":
                            SCANNING_YELLOW.Checked = bool.Parse(data[1]);
                            break;
                        case "SCANNING_G":
                            SCANNING_GREEN.Checked = bool.Parse(data[1]);
                            break;
                        case "SCANNING_B":
                            SCANNING_BUZZER.Checked = bool.Parse(data[1]);
                            break;
                        // Result scan OK
                        case "SCAN_RESULT_OK_R=":
                            SCAN_OK_RED.Checked = bool.Parse(data[1]);
                            break;
                        case "SCAN_RESULT_OK_Y":
                            SCAN_OK_YELLOW.Checked = bool.Parse(data[1]);
                            break;
                        case "SCAN_RESULT_OK_G":
                            SCAN_OK_GREEN.Checked = bool.Parse(data[1]);
                            break;
                        case "SCAN_RESULT_OK_B":
                            SCAN_OK_BUZZER.Checked = bool.Parse(data[1]);
                            break;

                        // Result scan NG
                        case "SCAN_RESULT_NG_R":
                            SCAN_NG_RED.Checked = bool.Parse(data[1]);
                            break;
                        case "SCAN_RESULT_NG_Y":
                            SCAN_NG_YELLOW.Checked = bool.Parse(data[1]);
                            break;
                        case "SCAN_RESULT_NG_G":
                            SCAN_NG_GREEN.Checked = bool.Parse(data[1]);
                            break;
                        case "SCAN_RESULT_NG_B":
                            SCAN_NG_BUZZER.Checked = bool.Parse(data[1]);
                            break;



                        default:
                            break;
                    }
                }
                CounterRead.Close();
                FS.Close();

            }
            catch
            {
            }
        }






        private void LoadPLCconfig()
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\PLC_config.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {

                        case "PLC_IP":
                            txtPLC_IP.Text = data[1];
                            break;
                        case "PLC_CPU_CODE":
                            txtPLC_CPU_CODE.Text = data[1];
                            break;
                        case "PLC_RECONNECT":
                            cbxChonKhoiTaoLaiPLC.Text = data[1];
                            break;

                        default:
                            break;
                    }
                }
                CounterRead.Close();
                FS.Close();

            }
            catch
            {
            }
        }


        private void LoadDataCounter()
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\Counter.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {

                        case "TOTAL_INPUT":
                            counter_total_input = int.Parse(data[1]);
                            txtCounterTotal_Input.Text = counter_total_input.ToString();
                            break;
                        case "TOTAL_INPUT_OK":
                            counter_total_OK = int.Parse(data[1]);
                            txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                            break;
                        case "TOTAL_INPUT_NG":
                            counter_total_NG = int.Parse(data[1]);
                            txtCounterTotal_Input_NG.Text = counter_total_NG.ToString();
                            break;

                        default:
                            break;
                    }
                }
                CounterRead.Close();
                FS.Close();

            }
            catch
            {
            }
        }





        //private void LoadCheckBoxMes()
        //{
        //    try
        //    {
        //        string[] data = null;
        //        string str = "";
        //        FileStream FS = new FileStream(Application.StartupPath + @"\DATA\CheckBoxMes.ini", FileMode.Open);
        //        StreamReader CounterRead = new StreamReader(FS);
        //        while (CounterRead.EndOfStream == false)
        //        {
        //            str = CounterRead.ReadLine();
        //            data = str.Split('=');

        //            switch (data[0])
        //            {

        //                case "Mes_ON":
        //                    checkBox_MesON.Checked = bool.Parse(data[1]);

        //                    if (checkBox_MesON.Checked)
        //                    {
        //                        Tao_Log_Voi_Noi_Dung_La("MES ON");
        //                        checkBox_MesON.Text = "MES ON";
        //                        checkBox_MesON.ForeColor = Color.Blue;
        //                    }
        //                    else
        //                    {
        //                        Tao_Log_Voi_Noi_Dung_La("MES OFF");
        //                        checkBox_MesON.Text = "MES OFF";
        //                        checkBox_MesON.ForeColor = Color.Red;
        //                    }

        //                    break;


        //                default:
        //                    break;
        //            }
        //        }
        //        CounterRead.Close();
        //        FS.Close();

        //    }
        //    catch
        //    {
        //    }
        //    MES_change_status = true;
        //}

        private void LoadCheckBoxMes()
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\CheckBoxMes.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {

                        case "Mes_ON":
                            checkBox_MesON.Checked = bool.Parse(data[1]);

                            if (checkBox_MesON.Checked)
                            {
                                Tao_Log_Voi_Noi_Dung_La("MES ON");
                                checkBox_MesON.Text = "MES ON";
                                checkBox_MesON.ForeColor = Color.Blue;
                            }
                            else
                            {
                                Tao_Log_Voi_Noi_Dung_La("MES OFF");
                                checkBox_MesON.Text = "MES OFF";
                                checkBox_MesON.ForeColor = Color.Red;
                            }

                            break;



                        case "Tach_Lot_Theo_Year_Month":
                            checkBox_TachLotTheoNgayThangON.Checked = bool.Parse(data[1]);

                            if (checkBox_TachLotTheoNgayThangON.Checked)
                            {
                                checkBox_TachLotTheoNgayThangON.Text = "ON";
                                checkBox_TachLotTheoNgayThangON.ForeColor = Color.Blue;
                            }
                            else
                            {
                                checkBox_TachLotTheoNgayThangON.Text = "OFF";
                                checkBox_TachLotTheoNgayThangON.ForeColor = Color.Red;
                            }

                            break;


                        case "Tach_Lot_Theo_Data":
                            checkBox_TachLotTheoFileDataON.Checked = bool.Parse(data[1]);

                            if (checkBox_TachLotTheoFileDataON.Checked)
                            {
                                checkBox_TachLotTheoFileDataON.Text = "ON";
                                checkBox_TachLotTheoFileDataON.ForeColor = Color.Blue;
                                //Load_data_for_ListBarcode();
                            }
                            else
                            {
                                checkBox_TachLotTheoFileDataON.Text = "OFF";
                                checkBox_TachLotTheoFileDataON.ForeColor = Color.Red;
                            }

                            break;


                        default:
                            break;
                    }
                }
                CounterRead.Close();
                FS.Close();

            }
            catch
            {
            }
            MES_change_status = true;
        }


        private void Load_IO_PLC()     // Chú ý file txt IO phải có dấu =
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\IO.txt", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[1])
                    {
                        // LOAD INPUT
                        case "PLC_INPUT_EMG_BUTTON":
                            PLC_INPUT_EMG_BUTTON = data[0];
                            break;
                        case "PLC_INPUT_READY_BUTTON":
                            PLC_INPUT_READY_BUTTON = data[0];
                            break;
                        case "PLC_INPUT_START_BUTTON":
                            PLC_INPUT_START_BUTTON = data[0];
                            break;
                        case "PLC_INPUT_STOP_BUTTON":
                            PLC_INPUT_STOP_BUTTON = data[0];
                            break;
                        case "PLC_INPUT_RESET_BUTTON":
                            PLC_INPUT_RESET_BUTTON = data[0];
                            break;
                        case "PLC_INPUT_BUZZER_BUTTON":
                            PLC_INPUT_BUZZER_BUTTON = data[0];
                            break;
                        case "PLC_INPUT_SENSOR_1":
                            PLC_INPUT_SENSOR_1 = data[0];
                            break;
                        case "PLC_INPUT_SENSOR_2":
                            PLC_INPUT_SENSOR_2 = data[0];
                            break;
                        case "PLC_INPUT_SENSOR_3":
                            PLC_INPUT_SENSOR_3 = data[0];
                            break;
                        case "PLC_INPUT_CLAMP_1_UP":
                            PLC_INPUT_CLAMP_1_UP = data[0];
                            break;
                        case "PLC_INPUT_CLAMP_2_UP":
                            PLC_INPUT_CLAMP_2_UP = data[0];
                            break;
                        case "PLC_INPUT_STOPPER_3_UP":
                            PLC_INPUT_STOPPER_3_UP = data[0];
                            break;
                        case "PLC_INPUT_STOPPER_3_DOWN":
                            PLC_INPUT_STOPPER_3_DOWN = data[0];
                            break;
                        case "PLC_INPUT_DOOR":
                            PLC_INPUT_DOOR = data[0];
                            break;
                        case "PLC_INPUT_LIGHTCURTAIN":
                            PLC_INPUT_LIGHTCURTAIN = data[0];
                            break;

                        // LOAD OUTPUT
                        case "PLC_OUTPUT_TL_R":
                            PLC_OUTPUT_TL_R = data[0];
                            break;
                        case "PLC_OUTPUT_TL_Y":
                            PLC_OUTPUT_TL_Y = data[0];
                            break;
                        case "PLC_OUTPUT_TL_G":
                            PLC_OUTPUT_TL_G = data[0];
                            break;
                        case "PLC_OUTPUT_TL_B":
                            PLC_OUTPUT_TL_B = data[0];
                            break;
                        case "PLC_OUTPUT_CLAMP1":
                            PLC_OUTPUT_CLAMP1 = data[0];
                            break;
                        case "PLC_OUTPUT_CLAMP2":
                            PLC_OUTPUT_CLAMP2 = data[0];
                            break;
                        case "PLC_OUTPUT_STOPPER3":
                            PLC_OUTPUT_STOPPER3 = data[0];
                            break;
                        case "PLC_OUTPUT_CONVEYOR":
                            PLC_OUTPUT_CONVEYOR = data[0];
                            break;
                        case "PLC_OUTPUT_SCANNER1":
                            PLC_OUTPUT_SCANNER1 = data[0];
                            break;
                        case "PLC_OUTPUT_SCANNER2":
                            PLC_OUTPUT_SCANNER2 = data[0];
                            break;
                        case "PLC_OUTPUT_LAMP_READY":
                            PLC_OUTPUT_LAMP_READY = data[0];
                            break;
                        case "PLC_OUTPUT_LAMP_START":
                            PLC_OUTPUT_LAMP_START = data[0];
                            break;
                        case "PLC_OUTPUT_LAMP_STOP":
                            PLC_OUTPUT_LAMP_STOP = data[0];
                            break;
                        case "PLC_OUTPUT_LAMP_RESET":
                            PLC_OUTPUT_LAMP_RESET = data[0];
                            break;
                        case "PLC_OUTPUT_LAMP_BZ":
                            PLC_OUTPUT_LAMP_BZ = data[0];
                            break;






                        default:
                            break;
                    }
                }
                CounterRead.Close();
                FS.Close();

            }
            catch
            {
                MessageBox.Show("Load I/O thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        public bool Nhac_Nho_Tu_Chuong_Trinh()
        {
            DialogResult result = MessageBox.Show(" Bạn có muốn thay đổi kết nối MES không, nếu thay đổi thì chọn OK, nếu không thay đổi thì chọn CANCEL? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                return true;
            }

            if (result == DialogResult.Cancel) // Bỏ bước này
            {
                return false;
                // Không làm gì cả
            }
            return false;
        }




        public void FORM_CLOSE() // Khi tắt chương trình
        {
            Tao_Log_Voi_Noi_Dung_La("FORM CLOSED");
            PLC.Writeplc(PLC_PROGRAM_ON, 0);



            // Lưu counter
            SaveDataCounter();



            // Lưu checkbox mes
            SaveCheckBoxMes();




            // Stop AUTO mode PLC
            STOP();



            //this.Close();
        }







        public bool KiemTraViTriChenThemDiem()
        {
            if (string.IsNullOrEmpty(txtPos.Text))
            {
                MessageBox.Show("Bạn chưa chọn vị trí để chèn thêm data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPos.Focus();
                return false;
            }

            return true;
        }

        public bool KiemTraViTriXoaDiem()
        {
            if (string.IsNullOrEmpty(txtPos.Text))
            {
                MessageBox.Show("Bạn chưa chọn vị trí để xóa data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPos.Focus();
                return false;
            }

            return true;
        }

        public bool KiemTraDuLieuTruocKhiSave()
        {
            if (string.IsNullOrEmpty(txtPos.Text))
            {
                MessageBox.Show("Bạn chưa chọn vị trí để teach", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPos.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtXvalue.Text))
            {
                MessageBox.Show("X value lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtXvalue.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtYvalue.Text))
            {
                MessageBox.Show("Y value lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtYvalue.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_speed.Text))
            {
                MessageBox.Show("Tốc độ X lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txt_speed.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDelayTime.Text))
            {
                MessageBox.Show("Nhập delay time lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtDelayTime.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtScaner01_PCM_NUM.Text))
            {
                MessageBox.Show("Chọn số thứ tự pcm sẽ đọc ở scan số 01", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtScaner01_PCM_NUM.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtScaner02_PCM_NUM.Text))
            {
                MessageBox.Show("Chọn số thứ tự pcm sẽ đọc ở scan số 02", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtScaner02_PCM_NUM.Focus();
                return false;
            }

            try
            {
                int X = int.Parse(txtXvalue.Text);
                int Y = int.Parse(txtYvalue.Text);
                int Sp = int.Parse(txt_speed.Text);
            }
            catch
            {
                MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }


            return true;
        }





        public bool KiemTraDuLieuTruocKhiTeachReadyPosition()
        {

            if (string.IsNullOrEmpty(txtReady_X.Text))
            {
                MessageBox.Show("X value lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtReady_X.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtReady_Y.Text))
            {
                MessageBox.Show("Y value lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtReady_Y.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtReady_Speed.Text))
            {
                MessageBox.Show("Tốc độ X lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtReady_Speed.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtReady_DelayTime.Text))
            {
                MessageBox.Show("Delay time lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtReady_DelayTime.Focus();
                return false;
            }


            try
            {
                int X = int.Parse(txtReady_X.Text);
                int Y = int.Parse(txtReady_Y.Text);
                int Sp = int.Parse(txtReady_Speed.Text);
                int t = int.Parse(txtReady_DelayTime.Text);


            }
            catch
            {
                MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }


            return true;
        }



        public bool KiemTraDuLieuTruocKhiSaveOffset()
        {

            if (string.IsNullOrEmpty(txtOffsetX.Text))
            {
                MessageBox.Show("X value lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtOffsetX.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtOffsetY.Text))
            {
                MessageBox.Show("Y value lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtOffsetY.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtOffsetSpeed.Text))
            {
                MessageBox.Show("Tốc độ X lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtOffsetSpeed.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtOffsetDelayTime.Text))
            {
                MessageBox.Show("Tốc độ Y lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtOffsetDelayTime.Focus();
                return false;
            }




            return true;
        }


        public bool KiemTraDuLieuTruocKhiXuatMainProgram()
        {
            if (string.IsNullOrEmpty(txtKhoangCach_X_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập khoảng cách X", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtKhoangCach_X_aray.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtKhoangCach_Y_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập khoảng cách Y", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtKhoangCach_Y_aray.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_X_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lần nhân X array", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txt_X_aray.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_Y_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lần nhân Y array", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txt_Y_aray.Focus();
                return false;
            }
            if ((checkBox_Mode_1.Checked == false) && (checkBox_Mode_2.Checked == false) && (checkBox_Mode_3.Checked == false) && (checkBox_Mode_4.Checked == false))
            {
                MessageBox.Show("Bạn chưa chọn kiểu nhân array", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                checkBox_Mode_1.Checked = true;
                Select_Mode_Array = 1;
            }

            if ((checkBox_SapXepKieuTinhTien.Checked == false) && (checkBox_SapXepKieuZicZac.Checked == false) && (checkBox_KhongCanSapXep.Checked == false))
            {
                MessageBox.Show("Bạn chưa chọn kiểu sắp xếp PCM", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                checkBox_KhongCanSapXep.Checked = true;
                KieuSapXepArrayPCMTheoScanner = 0;
            }




            return true;
        }










































        //public void Question_KhiClose()
        //{
        //    DialogResult result = MessageBox.Show(" Bạn có muốn tắt chương trình không? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        //    if (result == DialogResult.OK)
        //    {
        //        //SaveModel();
        //        //SavePLCSetting();
        //        //Close_All_Thread();
        //        Tao_Log_Voi_Noi_Dung_La("FORM CLOSED");
        //        PLC.Writeplc(PLC_PROGRAM_ON, 0);

        //        this.Close();

        //    }
        //    if (result == DialogResult.No)
        //    {


        //        //SavePLCSetting();
        //        //Close_All_Thread();


        //        Tao_Log_Voi_Noi_Dung_La("NOT SAVE MODEL");

        //        Tao_Log_Voi_Noi_Dung_La("FORM CLOSED");
        //        this.Close();
        //    }


        //    if (result == DialogResult.Cancel)
        //    {
        //        // Không làm gì cả
        //    }



        //}






        void Run_thread_Quet_PLC2() // Quét PLC luồng 2
        {

            #region Quét PLC

            if (PLC.readplc(PLC_AUTO_ON) == "1")  // Kiểm tra PLC auto chưa? 
            {
                if (KIEM_TRA_MODEL) // Kiểm tra đã gọi model hay chưa
                {
                    isStop = false; // 

                    if ((btnRun_By_Pass.BackColor == Color.Gray) && (btnDemoRun.BackColor == Color.Gray)) // Kiểm tra có bật chế độ demo hay by_pass hay không
                    {
                        isScan = true;
                    }
                    else
                    {
                        isScan = false;
                    }
                }
                else // Nếu chưa gọi model thì stop máy và báo lỗi
                {
                    isStop = true;
                    STOP();
                    MessageBox.Show("Chưa gọi model, hãy chọn model để chạy bạn nhé", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }



                if (KhoaCheoQuetScannerView) // Kiểm tra chế độ view liên tục ON thì stop máy
                {
                    isStop = true;
                    STOP();
                }






            }
            else // Nếu PLC AUTO đang stop
            {
                isStop = true;
            }





            // Quét đèn ready

            if (PLC.readplc(PLC_OUTPUT_LAMP_READY) == "1")
            {
                btnReady.BackColor = Color.Blue;
            }
            else
            {
                btnReady.BackColor = Color.Gray;
            }

            // Quét đèn start
            if (PLC.readplc(PLC_OUTPUT_LAMP_START) == "1")
            {
                btnRun.BackColor = Color.Green;
                //btnStop.BackColor = Color.Gray;
            }
            else
            {
                btnRun.BackColor = Color.Gray;
            }

            // Quét đèn stop
            if (PLC.readplc(PLC_OUTPUT_LAMP_STOP) == "1")
            {
                btnStop.BackColor = Color.Red;

            }
            else
            {
                btnStop.BackColor = Color.Gray;
            }


            // Quét đèn chế độ by pass

            if (PLC.readplc(PLC_ManuBar_By_Pass) == "1")
            {
                btnRun_By_Pass.BackColor = Color.Blue;
            }
            else
            {
                btnRun_By_Pass.BackColor = Color.Gray;
            }



            // Quét alarm
            if (PLC.readplc(PLC_OUTPUT_LAMP_RESET) == "1")
            {
                btnReset.BackColor = Color.Blue;
                ClearStatus(); // Xóa monitor hiển thị
            }
            else
            {
                btnReset.BackColor = Color.Gray;
            }


            // Quét đèn buzzer
            if (PLC.readplc(PLC_OUTPUT_LAMP_BZ) == "1")
            {
                btnBuzzerStop.BackColor = Color.Tomato;
            }
            else
            {
                btnBuzzerStop.BackColor = Color.Gray;
            }




            Thread.Sleep(200);

            #endregion

            quet_PLC_2 = true;

        }


        void Run_thread_Quet_PLC1()
        {

            #region Quét PLC
            Current_X_value = PLC.Read_Array_Devive(PLC_Servo_X_Current, 2)[0];
            Current_Y_value = PLC.Read_Array_Devive(PLC_Servo_Y_Current, 2)[0];

            // Update servo system
            #region Update Servo Info

            // Tọa độ
            lblToaDoTruc_X.Text = Current_X_value.ToString("0,0");
            lblManualToaDoTrucX.Text = Current_X_value.ToString("0,0");

            lblToaDoTruc_Y.Text = Current_Y_value.ToString("0,0");
            lblManualToaDoTrucY.Text = Current_Y_value.ToString("0,0");

            lblViTriHienTai.Text = PLC.readplc(PLC_Servo_Current_Position);

            // Code lỗi
            txtCodeLoiTruc_X.Text = PLC.readplc(PLC_Servo_CodeLoiTruc_X);
            if (txtCodeLoiTruc_X.Text == "0")
            {
                lbl_AlarmServo_X.Text = "SERVO READY";
                lbl_AlarmServo_X.BackColor = Color.LawnGreen;
                lbl_AlarmServo_X.ForeColor = Color.White;
            }
            else
            {
                lbl_AlarmServo_X.Text = "SERVO ERROR";
                lbl_AlarmServo_X.BackColor = Color.Gray;
                lbl_AlarmServo_X.ForeColor = Color.Red;
            }

            txtCodeLoiTruc_Y.Text = PLC.readplc(PLC_Servo_CodeLoiTruc_Y);
            if (txtCodeLoiTruc_Y.Text == "0")
            {
                lbl_AlarmServo_Y.Text = "SERVO READY";
                lbl_AlarmServo_Y.BackColor = Color.LawnGreen;
                lbl_AlarmServo_Y.ForeColor = Color.White;
            }
            else
            {
                lbl_AlarmServo_Y.Text = "SERVO ERROR";
                lbl_AlarmServo_Y.BackColor = Color.Gray;
                lbl_AlarmServo_Y.ForeColor = Color.Red;
            }

            // Momen 
            txtMomenXoanTaiTruc_X.Text = PLC.readplc(PLC_Servo_MomenTaiTruc_X);
            txtMomenXoanTaiTruc_Y.Text = PLC.readplc(PLC_Servo_MomenTaiTruc_Y);
            txtMomenXoanCucDai_X.Text = PLC.readplc(PLC_Servo_MomenMaxTruc_X);
            txtMomenXoanCucDai_Y.Text = PLC.readplc(PLC_Servo_MomenMaxTruc_Y);

            #endregion



            #region Update cycletime, counter


            try
            {
                // Update cycle time  
                cycletime = int.Parse(PLC.readplc(tb_CycleTimeScan.Text));
                txtCycletime.Text = (cycletime / 10).ToString("0,0");



                // Quét alarm, nếu có thì cho phép điều kiện thread chạy quét chi tiết alarm là gì
                if (PLC.readplc(PLC_ALARM_ON) == "1")
                {
                    alarm_detect_on = true;
                }
                else
                {
                    alarm_detect_on = false;
                }

            }
            catch { }

            //// Update counter  
            //txtCounterTotal_Input.Text = counter_total_input.ToString();
            //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
            //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString();


            #endregion

            #endregion

            Thread.Sleep(100);
            quet_PLC_1 = true;
        }

        public delegate void DelegateControlTextChange(Control ctr, string value);

        public void ControlTextChange(Control ctr, string value)
        {
            if (ctr.InvokeRequired)
            {
                ctr.Invoke(new DelegateControlTextChange(ControlTextChange), new object[] { ctr, value });
            }
            else
            {
                ctr.Text = value;
            }
        }




















        // Khai báo các biến tạm cho quét alarm machine

        public int temp_EMG = 0;
        public int temp_LightCurtain = 0;
        public int temp_limit_X_Cong = 0;
        public int temp_limit_X_Tru = 0;
        public int temp_limit_Y_Cong = 0;
        public int temp_limit_Y_Tru = 0;
        public int temp_X_OVER_LOAD = 0;
        public int temp_Y_OVER_LOAD = 0;
        public int temp_Read_Code_Jig_NG = 0;
        public int temp_Total_Result_Read_NG = 0;
        public int temp_Stopper_Up_Error = 0;




        void Run_thread_Quet_PLC_Alarm()
        {

            try
            {
                #region Quét PLC
                // Quét lỗi EMERGENCY STOP
                // so sánh vs giá trị chính nó trước đó nếu khác thì "Do something...."
                if (int.Parse(PLC.readplc(PLC_ALARM_EMG)) != temp_EMG)
                {
                    temp_EMG = int.Parse(PLC.readplc(PLC_ALARM_EMG));

                    if (int.Parse(PLC.readplc(PLC_ALARM_EMG)) == 1)
                    {
                        fAlarm.Name_Alarm = "EMERGENCY STOP ON";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();
                    }
                }


                //Quét lỗi light curtain 
                if (int.Parse(PLC.readplc(PLC_ALARM_LIGHT_CURTAIN)) != temp_LightCurtain)
                {
                    temp_LightCurtain = int.Parse(PLC.readplc(PLC_ALARM_LIGHT_CURTAIN));

                    if (int.Parse(PLC.readplc(PLC_ALARM_LIGHT_CURTAIN)) == 1)
                    {
                        fAlarm.Name_Alarm = "LIGHT CURTAIN ON";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();
                    }
                }



                // Quét lỗi limit X+ 
                if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_LIMIT_CONG)) != temp_limit_X_Cong)
                {
                    temp_limit_X_Cong = int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_LIMIT_CONG));
                    if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_LIMIT_CONG)) == 1)
                    {
                        fAlarm.Name_Alarm = "LIMIT X+";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();
                    }
                }



                // Quét lỗi limit X- 
                if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_LIMIT_TRU)) != temp_limit_X_Tru)
                {
                    temp_limit_X_Tru = int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_LIMIT_TRU));
                    if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_LIMIT_TRU)) == 1)
                    {
                        fAlarm.Name_Alarm = "LIMIT X-";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();
                    }
                }




                // Quét lỗi limit Y+ 
                if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_LIMIT_CONG)) != temp_limit_Y_Cong)
                {
                    temp_limit_Y_Cong = int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_LIMIT_CONG));
                    if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_LIMIT_CONG)) == 1)
                    {
                        fAlarm.Name_Alarm = "LIMIT Y+";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();
                    }
                }



                // Quét lỗi limit Y-
                if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_LIMIT_TRU)) != temp_limit_Y_Tru)
                {
                    temp_limit_Y_Tru = int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_LIMIT_TRU));
                    if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_LIMIT_TRU)) == 1)
                    {
                        fAlarm.Name_Alarm = "LIMIT Y-";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();
                    }
                }



                // Quét lỗi SERVO X OVER LOAD
                if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_OVER_LOAD)) != temp_X_OVER_LOAD)
                {
                    temp_X_OVER_LOAD = int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_OVER_LOAD));
                    if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_X_OVER_LOAD)) == 1)
                    {
                        fAlarm.Name_Alarm = "SERVO X OVER LOAD";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();
                    }
                }



                // Quét lỗi SERVO Y OVER LOAD
                if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_OVER_LOAD)) != temp_Y_OVER_LOAD)
                {
                    temp_Y_OVER_LOAD = int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_OVER_LOAD));
                    if (int.Parse(PLC.readplc(PLC_ALARM_SERVO_Y_OVER_LOAD)) == 1)
                    {
                        fAlarm.Name_Alarm = "SERVO Y OVER LOAD";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        fAlarm.ShowDialog();

                    }
                }

                //// Quét lỗi đọc code jig NG
                //if (int.Parse(PLC.readplc(PLC_ALARM_READ_CODE_JIG_NG)) != temp_Read_Code_Jig_NG)
                //{
                //    temp_Read_Code_Jig_NG = int.Parse(PLC.readplc(PLC_ALARM_READ_CODE_JIG_NG));
                //    if (int.Parse(PLC.readplc(PLC_ALARM_READ_CODE_JIG_NG)) == 1)
                //    {
                //        fAlarm.Name_Alarm = "READ CODE JIG NG";
                //        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                //        //fAlarm.ShowDialog();

                //    }
                //}


                //// Quét lỗi đọc code total NG
                //if (int.Parse(PLC.readplc(PLC_ALARM_TOTAL_RESULT_READ_NG)) != temp_Total_Result_Read_NG)
                //{
                //    temp_Total_Result_Read_NG = int.Parse(PLC.readplc(PLC_ALARM_TOTAL_RESULT_READ_NG));
                //    if (int.Parse(PLC.readplc(PLC_ALARM_TOTAL_RESULT_READ_NG)) == 1)
                //    {
                //        fAlarm.Name_Alarm = "HAVE PCM BARCODE NG";
                //        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                //        //fAlarm.ShowDialog();

                //    }
                //}




                // Quét lỗi stopper up error
                if (int.Parse(PLC.readplc(PLC_ALARM_STOPPER_UP_ERROR)) != temp_Stopper_Up_Error)
                {
                    temp_Stopper_Up_Error = int.Parse(PLC.readplc(PLC_ALARM_STOPPER_UP_ERROR));
                    if (int.Parse(PLC.readplc(PLC_ALARM_STOPPER_UP_ERROR)) == 1)
                    {
                        fAlarm.Name_Alarm = "STOPPER UP ERROR";
                        Tao_Log_Voi_Noi_Dung_La(fAlarm.Name_Alarm);
                        //fAlarm.ShowDialog();

                    }
                }


                #endregion
            }
            catch
            { }


            Thread.Sleep(200);



            monitor_Alram = true;

        }




        public void Update_DateTimePikerDaySelect() // Update thời gian chạy theo PO
        {

            if (DateTime.Now.Hour >= 20)  // Kiểm tra thời gian hiện tại nếu lớn hơn hoặc bằng 20h thì cộng thêm 1 ngày vào piker day                               
            {
                dateTimePickerDaySelect.Value = DateTime.Now.AddDays(1);
            }
            else
            {
                dateTimePickerDaySelect.Value = DateTime.Now;
            }


        }















        void Run_thread_Update_Date_Time()
        {

            #region Update ngày tháng

            txt_day_time.Text = DateTime.Now.ToLongTimeString() + " / " + DateTime.Now.ToLongDateString();

            // Next day nếu time hiện tại bằng 20h00 thì update vào piker date, cái này để lấy đúng PO đang chạy
            if (
                (DateTime.Now.Hour == 20)
                && (DateTime.Now.Minute == 00)
                && ((DateTime.Now.Second == 01) || (DateTime.Now.Second == 02))
                )
            {
                Update_DateTimePikerDaySelect();
                TaiDataOracle(txtOracel_PO_InUse, dgvOracleData); // Tải thông tin PO 
            }


            #endregion


            // Hiển thị kết quả đẩy file sang máy FCT ra list box
            try
            {
                listBox_Result_List.Items.Clear();
                if (string.IsNullOrEmpty(tb_LinkAddCode.Text)) { }
                else
                {
                    string[] AllFileName;
                    AllFileName = Directory.GetFiles(tb_LinkAddCode.Text);
                    txtSoLuongJigDaDocDuoc.Text = AllFileName.Length.ToString();

                    for (int i = 0; i < AllFileName.Length; i++)
                    {
                        string[] FileNameIs = AllFileName[i].Split('\\');

                        listBox_Result_List.Items.Add(FileNameIs[FileNameIs.Length - 1]);
                    }
                }
            }
            catch 
            {
                listBox_Result_List.Items.Clear();
            }


            // Hiển thị kết nối mes ra thanh statusStrip
            switch (MES_Connecting)
            {
                case "CAN":
                    lbl_MES_status.BackColor = Color.Green;
                    break;
                case "CANT":
                    lbl_MES_status.BackColor = Color.Red;
                    break;
            }











            //// Làm mới màn hình monitor 
            //if (((Auto_Stop_Mode == "1") || (ResetButtomIsOn == "1")) && ScanningIsOn == true)
            //{
            //    LamMoiManHinhHienThiBarcode();
            //}








            Thread.Sleep(100);
            Update_Date_Time = true;
            //}
        }





        public void Close_All_Thread()
        {
            thread_Quet_PLC1.Abort();  // Đóng luồng quét PLC
            thread_Quet_PLC2.Abort();  // Đóng luồng quét PLC
            thread_Update_Date_Time.Abort(); // Đóng luồng update ngày tháng
            thread_Quet_PLC_Alarm.Abort(); // Đóng luồng quét alarm
        }






        void khoiTao_PLC()
        {
        khoi_tao_lai:
            //pictureBox_status.Enabled = false;
            PLC.thietlap(txtPLC_IP, txtPLC_CPU_CODE);
            PLC.ketnoi();
            if (PLC.PLC_Connect == true)
            {
                //lbl_PLC_status.Text = "PLC CONNECTED";       // hien thi label ket noi ok
                lbl_PLC_status.ForeColor = Color.White;
                lbl_PLC_status.BackColor = Color.Green;
                //lbl_GUIconect.Visible = false;
                //pictureBox_status.Enabled = true;           // picture PLC LINK  

                Tao_Log_Voi_Noi_Dung_La("PLC CONNECT OK");
            }
            else                                            // ket noi that bai
            {
                Tao_Log_Voi_Noi_Dung_La("PLC CONNECT NG");

                if (cbxChonKhoiTaoLaiPLC.Text == "YES")
                {


                    DialogResult result = MessageBox.Show(" Kết nối PLC thất bại, \r\n Chọn OK để kết nối lại PLC ", "Thông báo lỗi kết nối PC - PLC", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                    if (result == DialogResult.No)   // Chọn ko kết nối lại
                    {
                        DialogResult result1 = MessageBox.Show(" Bạn chắc chắn không muốn kết nối, \r\n Chương trình sẽ không hoạt động đúng, \r\n =>Chọn OK để kết nối lại PLC, \r\n =>Chọn No để vào chương trình mà ko kết nối PLC ", "Thông báo lỗi kết nối PC - PLC", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (result1 == DialogResult.No)
                        {
                            // Thoát ra
                        }
                        else
                        {
                            // Kết nối lại PLC
                            goto khoi_tao_lai;
                        }
                    }
                    else
                    {
                        // Kết nối lại PLC
                        goto khoi_tao_lai;
                    }

                }
            }
        }



        public string LINK_FILE_LOG() // 1 tháng file
        {
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();

            //string day = DateTime.Now.Day.ToString();
            //string link_file = Application.StartupPath + @"\LOG\" + year + "" + month + "" + day + "" + "_" + "log.txt";
            string link_file = Application.StartupPath + @"\LOG\Machine_log" + month + "_" + year + ".txt";
            return link_file;
        }




        public string LINK_FILE_LOG_RESULT_READ_BARCODE() // Data lưu theo model
        {
            string Model_Name = Get_Model_Name();
            string link_file = Application.StartupPath + @"\Result_Barcode\Result_Read_Model_" + Model_Name + ".txt";
            return link_file;
        }





        public void LoadToDataGridView(DataGridView dgv, string link_file)
        {
            //dgv.AutoGenerateColumns = false;
            dgv.EnableHeadersVisualStyles = false;


            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersVisible = true;


            dgv.DataSource = Table.LOG_FILE(link_file);


        }






        public void Tao_Log_Ghi_Log(string commend)
        {
            string link_file = LINK_FILE_LOG();
            DATA.Check_Folder("LOG");
            TEXT.Add_Data_Log(commend, link_file);
            LoadToDataGridView(dgvLOG, link_file);






            //HienThi.hienthi_Log_File(dgvLOG, Table.LOG_FILE(link_file));


        }

        //public void Load_Data_Ready_Offset()
        //{


        //    Ready_X = int.Parse(txtReady_X.Text);
        //    Ready_Y = int.Parse(txtReady_Y.Text);
        //    Ready_Speed = int.Parse(txtReady_Speed.Text);
        //    Ready_Delay = int.Parse(txtReady_DelayTime.Text);

        //    Offset_X = int.Parse(txtOffsetX.Text);
        //    Offset_Y = int.Parse(txtOffsetY.Text);
        //    Offset_Speed = int.Parse(txtOffsetSpeed.Text);
        //    Offset_Delay = int.Parse(txtOffsetDelayTime.Text);
        //}



        // Biến tạm tăng giá trị cho process bar
        int temp_processbar_Value;


        public void LOAD_DATA_TO_PLC()
        {
            fProgressBarPLC = new Form_ProgressBarPLC(this);

            this.Enabled = false;
            temp_processbar_Value = 0;


            // Gửi lệnh xóa bộ nhớ PLC
            PLC.Writeplc("M115", 1);
            Thread.Sleep(300);
            PLC.Writeplc("M115", 0);




            try
            {
                // Tọa độ ready
                PLC.Writeplc(PLC_RUNNING_DEVICE_READY_POS_X, int.Parse(txtReady_X.Text));
                PLC.Writeplc(PLC_RUNNING_DEVICE_READY_POS_Y, int.Parse(txtReady_Y.Text));
                PLC.Writeplc(PLC_RUNNING_DEVICE_Ready_Speed, int.Parse(txtReady_Speed.Text));
                PLC.Writeplc(PLC_RUNNING_DEVICE_Ready_Delay, int.Parse(txtReady_DelayTime.Text));

            }
            catch
            {
                MessageBox.Show("Điểm đọc code jig đang không đúng format", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }









            // Tách Device lấy phần số
            string[] START_X_P1 = null;
            START_X_P1 = PLC_RUNNING_DEVICE_POS_X_P1.Split('D');

            string[] START_Y_P1 = null;
            START_Y_P1 = PLC_RUNNING_DEVICE_POS_Y_P1.Split('D');

            string[] START_SPEED_P1 = null;
            START_SPEED_P1 = PLC_RUNNING_DEVICE_SPEED_P1.Split('D');

            string[] START_DELAY_P1 = null;
            START_DELAY_P1 = PLC_RUNNING_DEVICE_DELAY_P1.Split('D');

            string[] START_SCANNER_1_P1 = null;
            START_SCANNER_1_P1 = PLC_RUNNING_DEVICE_SCANNER_1_P1.Split('D');

            string[] START_SCANNER_2_P1 = null;
            START_SCANNER_2_P1 = PLC_RUNNING_DEVICE_SCANNER_2_P1.Split('D');




            int START_X = int.Parse(START_X_P1[1]);
            int START_Y = int.Parse(START_Y_P1[1]);
            int START_SPEED = int.Parse(START_SPEED_P1[1]);
            int START_DELAY = int.Parse(START_DELAY_P1[1]);
            int START_SCANNER_1 = int.Parse(START_SCANNER_1_P1[1]);
            int START_SCANNER_2 = int.Parse(START_SCANNER_1_P1[1]);

            int INDEX1 = 0;   // Index + 1
            int INDEX2 = 0;   // Index + 2

            if (dgvTeachingMain.Rows.Count - 1 > 0)
            {
                Vi_Tri_Run_Cuoi_Cung = dgvTeachingMain.Rows.Count - 1;    // M code cuối cùng
            }
            else
            {
                Vi_Tri_Run_Cuoi_Cung = 0;
            }


            txtSoDiemChayRoBot.Text = Vi_Tri_Run_Cuoi_Cung.ToString();

            // Process Bar load vào PLC hiện ra
            fProgressBarPLC.progressBarPLC_LOAD.Maximum = Vi_Tri_Run_Cuoi_Cung;
            fProgressBarPLC.progressBarPLC_LOAD.Minimum = 0; ;
            fProgressBarPLC.progressBarPLC_LOAD.Value = 0;




            if (fProgressBarPLC.IsDisposed == false)
            {
                fProgressBarPLC.Show();

            }



            // Vòng lặp đưa data vào device running robot
            try
            {
                PLC.Writeplc(PLC_RUNNING_DEVICE_END_OF_POSITION, Vi_Tri_Run_Cuoi_Cung);

                for (int i = 0; i < dgvTeachingMain.Rows.Count - 1; i++)
                {
                    // X Position
                    PLC.Writeplc("D" + (START_X + INDEX1).ToString(), int.Parse(dgvTeachingMain.Rows[i].Cells[1].Value.ToString()));
                    // Y Position
                    PLC.Writeplc("D" + (START_Y + INDEX1).ToString(), int.Parse(dgvTeachingMain.Rows[i].Cells[2].Value.ToString()));
                    // X Tốc độ
                    PLC.Writeplc("D" + (START_SPEED + INDEX1).ToString(), int.Parse(dgvTeachingMain.Rows[i].Cells[3].Value.ToString()));
                    // DELAY
                    PLC.Writeplc("D" + (START_DELAY + INDEX1).ToString(), int.Parse(dgvTeachingMain.Rows[i].Cells[4].Value.ToString()));


                    // SCANNER 1
                    // Kiểm tra nếu ON thì = 1
                    if (dgvTeachingMain.Rows[i].Cells[5].Value.ToString() == "ON")
                    {
                        PLC.Writeplc("D" + (START_SCANNER_1 + INDEX1).ToString(), 1);
                    }
                    // Kiểm tra nếu OFF thì = 0
                    else
                    {
                        PLC.Writeplc("D" + (START_SCANNER_1 + INDEX1).ToString(), 0);
                    }


                    // SCANNER 2
                    // Kiểm tra nếu ON thì = 1
                    if (dgvTeachingMain.Rows[i].Cells[6].Value.ToString() == "ON")
                    {
                        PLC.Writeplc("D" + (START_SCANNER_2 + INDEX1).ToString(), 1);
                    }
                    // Kiểm tra nếu OFF thì = 0
                    else
                    {
                        PLC.Writeplc("D" + (START_SCANNER_2 + INDEX1).ToString(), 0);
                    }

                    // Tăng value process bar PLC LOAD


                    temp_processbar_Value++;
                    fProgressBarPLC.progressBarPLC_LOAD.Value = temp_processbar_Value;


                    INDEX1 = INDEX1 + 1;    // DEVICE Using 16 bit
                    INDEX2 = INDEX2 + 2;    // DEVICE Using 32 bit

                }

            }
            catch
            {
                Tao_Log_Voi_Noi_Dung_La("LOAD TO PLC FAIL");
                fProgressBarPLC.Close();
                this.Enabled = true;
            }

            Tao_Log_Voi_Noi_Dung_La("LOAD TO PLC OK");

            fProgressBarPLC.CloseForm();
            this.Enabled = true;

        }




        public void HienThiModeRunning()
        {
            // Mode by-pass
            if (PLC.readplc(PLC_ManuBar_By_Pass) == "1")
            {
                btnRun_By_Pass.BackColor = Color.Blue;
            }
            else
            {
                btnRun_By_Pass.BackColor = Color.Gray;
            }

            // Mode DEMO
            if (PLC.readplc(PLC_MenuBar_Demo_Run) == "1")
            {
                btnDemoRun.BackColor = Color.Blue;
            }
            else
            {
                btnDemoRun.BackColor = Color.Gray;
            }

        }







































































































        public void HidetabPageSetting()
        {
            lblSettingPLC.Enabled = false;
            lblSettingMes.Enabled = false;
            lblScannerSetting.Enabled = false;
            panelDeviceSetting.Enabled = false;
            panelTowerLamp.Enabled = false;


        }

        public void ShowtabPageSetting()
        {
            lblSettingPLC.Enabled = true;
            lblSettingMes.Enabled = true;
            lblScannerSetting.Enabled = true;
            panelDeviceSetting.Enabled = true;
            panelTowerLamp.Enabled = true;


        }





















        public void login_program()
        {
            if (Login.login_status == false)
            {
                Login.ShowDialog();         // show man hinh dang nhap

                if (Login.login_status == true)    // login OK
                {
                    btnMain.Enabled = true;
                    panel_monitor.Visible = true;
                    btnManual.Enabled = true;
                    btnIO.Enabled = true;
                    btnSetting.Enabled = true;
                    btnCalibrationOffset.Enabled = true;
                    btnReady.Enabled = true;
                    btnRun.Enabled = true;
                    btnDemoRun.Enabled = true;
                    tabControl_main.Enabled = true;
                    ptbbtn_CallScreenJogRobot.Enabled = true;
                    btnTeaching.Enabled = true;
                    lblLinkModel.Enabled = true;
                    pictureBox_lock_unlock.Image = Properties.Resources.unlock;

                    if (Login.parameter == true)
                    {
                        btnSaveSettingPLC.Enabled = true;
                        btnSaveSettingMES.Enabled = true;
                        btnSaveSettingScanner.Enabled = true;
                        btnSaveSettingDevice.Enabled = true;
                        btnChangeTowerLamp.Enabled = true;
                        //btnSaveSettingLinkSaveFile.Enabled = true;
                        ShowtabPageSetting();
                        panel_Oracel.Enabled = true;
                        panel_TachHang.Enabled = true;
                        panel_Tach_Hang.Enabled = true;
                        //panel_Setting.Enabled = true;
                        Tao_Log_Voi_Noi_Dung_La("ADMIN INPUT");
                    }
                    else
                    {
                        btnSaveSettingPLC.Enabled = false;
                        btnSaveSettingMES.Enabled = false;
                        btnSaveSettingScanner.Enabled = false;
                        btnSaveSettingDevice.Enabled = false;
                        btnChangeTowerLamp.Enabled = false;
                        //btnSaveSettingLinkSaveFile.Enabled = false;
                        panel_TachHang.Enabled = false;
                        panel_Tach_Hang.Enabled = false;
                        HidetabPageSetting();
                        panel_Oracel.Enabled = false;
                        //panel_Setting.Enabled = false;
                    }

                    Tao_Log_Voi_Noi_Dung_La("LOCK ON");

                }
                else
                {
                    btnMain.Enabled = false;
                    panel_monitor.Visible = false;
                    btnManual.Enabled = false;
                    btnIO.Enabled = false;
                    btnSetting.Enabled = false;
                    btnCalibrationOffset.Enabled = false;
                    btnReady.Enabled = false;
                    btnRun.Enabled = false;
                    btnDemoRun.Enabled = false;
                    tabControl_main.Enabled = false;
                    pictureBox_lock_unlock.Image = Properties.Resources._lock;
                    Login.login_status = false;
                    ptbbtn_CallScreenJogRobot.Enabled = false;
                    btnTeaching.Enabled = false;
                    lblLinkModel.Enabled = false;
                    Login.parameter = false;

                    Tao_Log_Voi_Noi_Dung_La("LOCK OFF");
                }




            }
            else                            // login out           
            {
                btnMain.Enabled = false;
                panel_monitor.Visible = false;
                btnManual.Enabled = false;
                btnIO.Enabled = false;
                btnSetting.Enabled = false;
                btnCalibrationOffset.Enabled = false;
                btnReady.Enabled = false;
                btnRun.Enabled = false;
                btnDemoRun.Enabled = false;
                tabControl_main.Enabled = false;
                pictureBox_lock_unlock.Image = Properties.Resources._lock;
                Login.login_status = false;
                ptbbtn_CallScreenJogRobot.Enabled = false;
                btnTeaching.Enabled = false;
                lblLinkModel.Enabled = false;
                Login.parameter = false;
                Tao_Log_Voi_Noi_Dung_La("LOCK OFF");
            }
        }

        private void pictureBox_lock_unlock_Click(object sender, EventArgs e)
        {
            login_program();
        }

        private void pictureBox_JogRobot_Click(object sender, EventArgs e)
        {
            fJogRobot.ShowDialog();
        }

        private void btn_JogRobot_Click(object sender, EventArgs e)
        {
            fJogRobot.ShowDialog();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {

            tabPage_manual.Hide();
            tabPage_Setting.Hide();
            tabPage_IO.Hide();
            tabPage_Teaching.Hide();
            tabPage_LOG_MES.Hide();
            tabPage_OracleSeting.Hide();
            tabPage_TachLot.Hide();
            tabPage_Auto.Show();
            tab_monitor_on = false;
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                tabPage_Auto.Hide();
                tabPage_Setting.Hide();
                tabPage_IO.Hide();
                tabPage_Teaching.Hide();
                tabPage_LOG_MES.Hide();
                tabPage_OracleSeting.Hide();
                tabPage_TachLot.Hide();
                tabPage_manual.Show();

            }
            tab_monitor_on = false;
        }

        private void btnTeaching_Click(object sender, EventArgs e)
        {
            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                tabPage_Auto.Hide();
                tabPage_manual.Hide();
                tabPage_Setting.Hide();
                tabPage_IO.Hide();

                tabPage_Teaching.Show();

                tabPage_LOG_MES.Hide();
                tabPageProgramSub.Hide();
                tabPageProgramReady.Hide();
                tabPageProgramOffset.Hide();
                tabPage_OracleSeting.Hide();
                tabPage_TachLot.Hide();
                tabPageProgramMain.Show();

            }
            tab_monitor_on = false;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                tabPage_Auto.Hide();
                tabPage_manual.Hide();
                tabPage_IO.Hide();
                tabPage_Teaching.Hide();
                tabPage_LOG_MES.Hide();
                tabPage_OracleSeting.Hide();
                tabPage_TachLot.Hide();
                tabPage_Setting.Show();

            }
            tab_monitor_on = false;
        }

        private void btnIO_Click(object sender, EventArgs e)
        {

            tabPage_Auto.Hide();
            tabPage_manual.Hide();
            tabPage_Setting.Hide();
            tabPage_Teaching.Hide();
            tabPage_LOG_MES.Hide();
            tabPage_OracleSeting.Hide();
            tabPage_TachLot.Hide();
            tabPage_IO.Show();

            tab_monitor_on = true;



        }


        private void btnCalibrationOffset_Click(object sender, EventArgs e)
        {
            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                tabPage_Auto.Hide();
                tabPage_manual.Hide();
                tabPage_Setting.Hide();
                tabPage_IO.Hide();

                tabPage_Teaching.Show();


                tabPageProgramMain.Hide();
                tabPageProgramSub.Hide();
                tabPageProgramReady.Hide();
                tabPage_LOG_MES.Hide();
                tabPage_OracleSeting.Hide();
                tabPage_TachLot.Hide();
                tabPageProgramOffset.Show();

            }
            tab_monitor_on = false;
        }


        private void btn_CallScreenJogRobot1_Click(object sender, EventArgs e)
        {
            fJogRobot.ShowDialog();
        }

        private void btnManualPrew_Click(object sender, EventArgs e)
        {
            DiemChayManual = DiemChayManual - 1;
            if (DiemChayManual < 0)
            {
                DiemChayManual = 0;
            }
            txtManualDiemChayRobot.Text = DiemChayManual.ToString();
            PLC.Writeplc(PLC_MANUAL_ROBOT_POS_NO, DiemChayManual + 1);

        }

        private void btnManualNext_Click(object sender, EventArgs e)
        {
            DiemChayManual = DiemChayManual + 1;
            if (DiemChayManual > int.Parse(txtSoDiemChayRoBot.Text))
            {
                DiemChayManual = int.Parse(txtSoDiemChayRoBot.Text);
            }

            txtManualDiemChayRobot.Text = DiemChayManual.ToString();
            PLC.Writeplc(PLC_MANUAL_ROBOT_POS_NO, DiemChayManual + 1);
        }

        private void btnManualClamp1_Up_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_CLAMP_1_DOWN, 0);
            PLC.Writeplc(PLC_MANUAL_CLAMP_1_UP, 1);
        }

        private void btnManualClamp1_Down_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_CLAMP_1_UP, 0);
            PLC.Writeplc(PLC_MANUAL_CLAMP_1_DOWN, 1);
        }

        private void btnManualClamp2_Up_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_CLAMP_2_DOWN, 0);
            PLC.Writeplc(PLC_MANUAL_CLAMP_2_UP, 1);
        }

        private void btnManualClamp2_Down_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_CLAMP_2_UP, 0);
            PLC.Writeplc(PLC_MANUAL_CLAMP_2_DOWN, 1);
        }

        private void btnManualStopper3_Up_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_STOPPER_3_DOWN, 0);
            PLC.Writeplc(PLC_MANUAL_STOPPER_3_UP, 1);
        }

        private void btnManualStopper3_Down_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_STOPPER_3_UP, 0);
            PLC.Writeplc(PLC_MANUAL_STOPPER_3_DOWN, 1);
        }

        private void btnManualCNV_Run_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_CNV_STOP, 0);
            PLC.Writeplc(PLC_MANUAL_CNV_RUN, 1);
        }

        private void btnManualCNV_Stop_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_CNV_RUN, 0);
            PLC.Writeplc(PLC_MANUAL_CNV_STOP, 1);
        }

        private void btnManualScanner1_Read_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_SCANNER_1_READ, 1);
            Thread.Sleep(200);
            PLC.Writeplc(PLC_MANUAL_SCANNER_1_READ, 0);
        }

        private void btnManualScanner2_Read_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_SCANNER_2_READ, 1);
            Thread.Sleep(200);
            PLC.Writeplc(PLC_MANUAL_SCANNER_2_READ, 0);
        }

        private void pictureBox_XemIO_Click(object sender, EventArgs e)
        {

        }

        private void btnTeachingAdd_Click(object sender, EventArgs e)
        {
            tabPageProgramMain.Hide();
            tabPageProgramSub.Show();
            HienThi.hienthiFileTeaching(dgvTeachingSub, Table.Table_Add_New_Row(dgvTeachingSub));
            Load_EndPosition(dgvTeachingSub, txtPos);
            Tao_Log_Voi_Noi_Dung_La("ADD POINT TEACHING OK");

        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            SaveModel();

        }

        private void MenuOpenModel_Click(object sender, EventArgs e)
        {


        }

        private void dgvTeaching_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtPos.Text = dgvTeachingSub.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtXvalue.Text = dgvTeachingSub.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtYvalue.Text = dgvTeachingSub.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_speed.Text = dgvTeachingSub.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDelayTime.Text = dgvTeachingSub.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtScaner01_PCM_NUM.Text = dgvTeachingSub.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtScaner02_PCM_NUM.Text = dgvTeachingSub.Rows[e.RowIndex].Cells[6].Value.ToString();

            }
            catch (Exception)
            {
                //MessageBox.Show("Hãy chọn vị trí muốn thay đổi ");
            }
        }

        private void btnSaveTeaching_Click(object sender, EventArgs e)
        {
            tabPageProgramMain.Hide();
            tabPageProgramSub.Show();

            if (KiemTraDuLieuTruocKhiSave())
            {
                SaveTeaching(dgvTeachingSub);
                Tao_Log_Voi_Noi_Dung_La("SUB POINT CHANGE OK");
            }

        }

        private void btnTeach_Click(object sender, EventArgs e)
        {
            tabPageProgramMain.Hide();
            tabPageProgramSub.Show();
            if (PLC.PLC_Connect)
            {
                txtXvalue.Text = Current_X_value.ToString();
                txtYvalue.Text = Current_Y_value.ToString();
                txt_speed.Text = "100";
                txt_speed.Text = "100";

            }


        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FORM_CLOSE();

        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            Call_Model();

        }

        private void btnJogTeaching_Click(object sender, EventArgs e)
        {
            fJogRobot.ShowDialog();
        }

        private void btnXoaPos_Click(object sender, EventArgs e)
        {
            tabPageProgramMain.Hide();
            tabPageProgramSub.Show();
            if (KiemTraViTriXoaDiem())
            {
                Model.XoaPosTeaching(dgvTeachingSub, txtPos);
                HienThiLaiData();
                Tao_Log_Voi_Noi_Dung_La("DELETE POINT OK");
            }

        }

        private void MenuSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsModel();
        }

        private void btnTeachingInsertPos_Click(object sender, EventArgs e)
        {
            tabPageProgramMain.Hide();
            tabPageProgramSub.Show();
            if (KiemTraViTriChenThemDiem())
            {
                HienThi.hienthiFileTeaching(dgvTeachingSub, Table.Table_Insert_Row(dgvTeachingSub, txtPos));
                Tao_Log_Voi_Noi_Dung_La("INSERT POINT OK");
            }

        }




        private void txt_X_aray_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_X_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txt_X_aray.Focus();
            }
            else
            {
                try
                {

                    Array_X = int.Parse(txt_X_aray.Text);
                    if (Array_X > 0)
                    {
                        Array_Y = int.Parse(txt_Y_aray.Text);

                        TotalArray = Array_X * Array_Y;
                        txtTongSoLuongArray.Text = TotalArray.ToString();
                        txt_X_aray.Text = Array_X.ToString();
                        txt_Y_aray.Text = Array_Y.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_X_aray.Focus();
                    }



                }
                catch
                {
                    MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txt_X_aray.Focus();
                }
            }
        }

        private void txt_Y_aray_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_Y_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txt_Y_aray.Focus();
            }
            else
            {

                try
                {
                    Array_Y = int.Parse(txt_Y_aray.Text);
                    if (Array_Y > 0)
                    {
                        Array_X = int.Parse(txt_X_aray.Text);

                        TotalArray = Array_X * Array_Y;
                        txtTongSoLuongArray.Text = TotalArray.ToString();

                        txt_X_aray.Text = Array_X.ToString();
                        txt_Y_aray.Text = Array_Y.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_Y_aray.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txt_Y_aray.Focus();
                }


            }
        }

        private void checkBox_Use_NoUse_Array_CheckedChanged(object sender, EventArgs e)
        {
            // Chọn nhân array hay không
            if (checkBox_Use_NoUse_Array.Checked == true)
            {
                ArrayUse = true;
                Array_Khoang_Cach_X = int.Parse(txtKhoangCach_X_aray.Text);
                Array_Khoang_Cach_Y = int.Parse(txtKhoangCach_Y_aray.Text);
                Array_X = int.Parse(txt_X_aray.Text);
                Array_Y = int.Parse(txt_Y_aray.Text);
            }
            else
            {
                ArrayUse = false;
            }
        }

        private void txtKhoangCach_X_aray_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtKhoangCach_X_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtKhoangCach_X_aray.Focus();
            }
            else
            {
                if (ArrayUse)
                {
                    try
                    {
                        Array_Khoang_Cach_X = int.Parse(txtKhoangCach_X_aray.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtKhoangCach_X_aray.Focus();
                    }
                }
            }
        }

        private void txtKhoangCach_Y_aray_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKhoangCach_Y_aray.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtKhoangCach_Y_aray.Focus();
            }
            else
            {
                if (ArrayUse)
                {
                    try
                    {
                        Array_Khoang_Cach_Y = int.Parse(txtKhoangCach_Y_aray.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtKhoangCach_Y_aray.Focus();
                    }
                }
            }
        }

        private void btnArraySettingSave_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuTruocKhiXuatMainProgram())
            {
                TaoChuongTrinh_Main_Tu_Sub();
                Tao_Log_Voi_Noi_Dung_La("NEW TEACHING PROGRAM");
            }

        }



        private void Menu_DownLoadToPLC_Click(object sender, EventArgs e)
        {
            if (PLC.PLC_Connect == true)
            {
                LOAD_DATA_TO_PLC();
            }
            else
            {
                MessageBox.Show("PLC chưa kết nối", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }



        private void MenuNewModel_Click(object sender, EventArgs e)
        {
            // Tạo file teaching mới
            txtKhoangCach_X_aray.Text = "0";
            txtKhoangCach_Y_aray.Text = "0";
            txt_X_aray.Text = "1";
            txt_Y_aray.Text = "1";

            HienThi_Tao_New_Model();


            checkBox_SapXepKieuTinhTien.Checked = false;
            checkBox_SapXepKieuZicZac.Checked = false;
            checkBox_KhongCanSapXep.Checked = true;
            checkBox_TachLotTheoNgayThangON.Checked = false;
            checkBox_TachLotTheoFileDataON.Enabled = false;


            // Làm mới main data
            TaoChuongTrinh_Main_Tu_Sub();
        }



        private void btnSaveOffset_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuTruocKhiSaveOffset())
            {
                //Thay_Doi_Gia_Tri_Offset();
                Tao_Log_Voi_Noi_Dung_La("SAVE OFFSET OK");
                TaoChuongTrinh_Main_Tu_Sub();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đúng data", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void btnTeachReadyPos_Click(object sender, EventArgs e)
        {
            if (PLC.PLC_Connect)
            {
                txtReady_X.Text = Current_X_value.ToString();
                txtReady_Y.Text = Current_Y_value.ToString();
            }





            if (KiemTraDuLieuTruocKhiTeachReadyPosition())
            {
                Teaching_Ready_Enable = true;
            }
            else
            {
                Teaching_Ready_Enable = false;
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                PLC.Writeplc(PLC_MenuBar_Ready, 1);
                Thread.Sleep(200);
                PLC.Writeplc(PLC_MenuBar_Ready, 0);


                // Viết log READY ON

            }


        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {

                if (DangInputManual == true)
                {

                }
                else
                {
                    PLC.Writeplc(PLC_MenuBar_Run, 1);
                    Thread.Sleep(200);
                    PLC.Writeplc(PLC_MenuBar_Run, 0);


                    alarm_PO_OFF = false;

                    if (cbxLuaChonAddThemMaProduct.Text == "YES")
                    {
                        TaiDataOracle(txtOracel_PO_InUse, dgvOracleData); // Tải thông tin PO
                    }


                }



                // Viết log AUTO RUN ON

            }

        }

        private void btnDemoRun_Click(object sender, EventArgs e)
        {
            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                if (PLC.readplc(PLC_MenuBar_Demo_Run) == "0")
                {
                    PLC.Writeplc(PLC_MenuBar_Demo_Run, 1);
                    btnDemoRun.BackColor = Color.Blue;
                }
                else
                {
                    PLC.Writeplc(PLC_MenuBar_Demo_Run, 0);
                    btnDemoRun.BackColor = Color.Gray;
                }
                // Viết log DEMO RUN
            }

        }

        public void STOP ()
        {
            PLC.Writeplc(PLC_MenuBar_Stop, 1);
            Thread.Sleep(200);
            PLC.Writeplc(PLC_MenuBar_Stop, 0);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            STOP();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MenuBar_Reset, 1);
            Thread.Sleep(200);
            PLC.Writeplc(PLC_MenuBar_Reset, 0);



        }

        private void btnBuzzerStop_Click(object sender, EventArgs e)
        {
            if (PLC.readplc(PLC_MenuBar_BuzzerStop) == "1")
            {
                PLC.Writeplc(PLC_MenuBar_BuzzerStop, 0);
                btnBuzzerStop.BackColor = Color.Gray;
                fJogRobot.btnJogBuzzerStop.BackColor = Color.Gray;
            }
            else
            {
                PLC.Writeplc(PLC_MenuBar_BuzzerStop, 1);
                btnBuzzerStop.BackColor = Color.Orange;
                fJogRobot.btnJogBuzzerStop.BackColor = Color.Orange;
            }
        }

        private void btnPLC_Write_DeviceRandom_Click(object sender, EventArgs e)
        {
            try
            {
                PLC.Writeplc(txt_PLC_Write_Device.Text, int.Parse(txt_PLC_Write_Value.Text));
            }
            catch
            {
                MessageBox.Show("Write Device Random thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnPLC_Read_DeviceRandom_Click(object sender, EventArgs e)
        {
            try
            {
                txt_PLC_Read_Value.Text = (PLC.readplc(txt_PLC_Read_Device.Text)).ToString();
                if (txt_PLC_Read_Value.Text == "FAIL")
                {
                    txt_PLC_Read_Value.BackColor = Color.Tomato;
                }

            }
            catch
            {
                txt_PLC_Read_Value.BackColor = Color.Tomato;
                MessageBox.Show("Read Device Random thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void txt_PLC_Write_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txt_PLC_Write_Value.Text);
            }
            catch
            {
                MessageBox.Show("Nhập sai", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PLC_Write_Value.Focus();
            }
        }

        private void txt_PLC_Write_Device_MouseDown(object sender, MouseEventArgs e)
        {
            txt_PLC_Write_Device.Text = "";
            txt_PLC_Write_Value.Text = "0";
        }

        private void txt_PLC_Read_Device_MouseDown(object sender, MouseEventArgs e)
        {
            txt_PLC_Read_Device.Text = "";
            txt_PLC_Read_Value.Text = "";
        }

        private void timerQuet_IO_PLC_Tick(object sender, EventArgs e)
        {

            if (Update_Date_Time)
            {
                Update_Date_Time = false;
                thread_Update_Date_Time = new Thread(Run_thread_Update_Date_Time);
                thread_Update_Date_Time.IsBackground = true;
                thread_Update_Date_Time.Start();
            }

            if ((input_monitor) && (tab_monitor_on))
            {
                input_monitor = false;
                Thread_Input_Monitor = new Thread(new ThreadStart(INPUT_MONITOR_PLC));
                Thread_Input_Monitor.IsBackground = true;
                Thread_Input_Monitor.Start();
            }

            if ((output_monitor) && (tab_monitor_on))
            {
                output_monitor = false;
                Thread_Output_Monitor = new Thread(new ThreadStart(OUTPUT_MONITOR_PLC));
                Thread_Output_Monitor.IsBackground = true;
                Thread_Output_Monitor.Start();
            }

            if (quet_PLC_1)
            {
                quet_PLC_1 = false;
                thread_Quet_PLC1 = new Thread(new ThreadStart(Run_thread_Quet_PLC1));
                thread_Quet_PLC1.IsBackground = true;
                thread_Quet_PLC1.Start();
            }

            if (quet_PLC_2)
            {
                quet_PLC_2 = false;
                thread_Quet_PLC2 = new Thread(new ThreadStart(Run_thread_Quet_PLC2));
                thread_Quet_PLC2.IsBackground = true;
                thread_Quet_PLC2.Start();
            }

            if ((monitor_Alram) && (alarm_detect_on))
            {
                monitor_Alram = false;
                thread_Quet_PLC_Alarm = new Thread(new ThreadStart(Run_thread_Quet_PLC_Alarm));
                thread_Quet_PLC_Alarm.IsBackground = true;
                thread_Quet_PLC_Alarm.Start();
            }
        }

        #region INPUT MONITOR
        public void INPUT_MONITOR_PLC()
        {

            if (PLC.readplc(PLC_INPUT_EMG_BUTTON) == "1")
            {
                INPUT_EMG_Button.BackColor = Color.Red;
            }
            else
            {
                INPUT_EMG_Button.BackColor = Color.Silver;
            }
            // READY          
            if (PLC.readplc(PLC_INPUT_READY_BUTTON) == "1")
            {
                INPUT_Ready_Button.BackColor = Color.Red;
            }
            else
            {
                INPUT_Ready_Button.BackColor = Color.Silver;
            }
            // START          
            if (PLC.readplc(PLC_INPUT_START_BUTTON) == "1")
            {
                INPUT_Start_Button.BackColor = Color.Red;
            }
            else
            {
                INPUT_Start_Button.BackColor = Color.Silver;
            }
            // STOP          
            if (PLC.readplc(PLC_INPUT_STOP_BUTTON) == "1")
            {
                INPUT_Stop_Button.BackColor = Color.Red;
            }
            else
            {
                INPUT_Stop_Button.BackColor = Color.Silver;
            }
            // RESET          
            if (PLC.readplc(PLC_INPUT_RESET_BUTTON) == "1")
            {
                INPUT_Reset_Button.BackColor = Color.Red;
            }
            else
            {
                INPUT_Reset_Button.BackColor = Color.Silver;
            }
            // BUZZER STOP         
            if (PLC.readplc(PLC_INPUT_BUZZER_BUTTON) == "1")
            {
                INPUT_Buzzer_Button.BackColor = Color.Red;
            }
            else
            {
                INPUT_Buzzer_Button.BackColor = Color.Silver;
            }
            // SENSOR 1        
            if (PLC.readplc(PLC_INPUT_SENSOR_1) == "1")
            {
                INPUT_Sensor1.BackColor = Color.Red;
            }
            else
            {
                INPUT_Sensor1.BackColor = Color.Silver;
            }
            // SENSOR 2        
            if (PLC.readplc(PLC_INPUT_SENSOR_2) == "1")
            {
                INPUT_Sensor2.BackColor = Color.Red;
            }
            else
            {
                INPUT_Sensor2.BackColor = Color.Silver;
            }
            // SENSOR 3        
            if (PLC.readplc(PLC_INPUT_SENSOR_3) == "1")
            {
                INPUT_Sensor3.BackColor = Color.Red;
            }
            else
            {
                INPUT_Sensor3.BackColor = Color.Silver;
            }
            // CLAMP 1 UP        
            if (PLC.readplc(PLC_INPUT_CLAMP_1_UP) == "1")
            {
                INPUT_Clamp1_Up.BackColor = Color.Red;
            }
            else
            {
                INPUT_Clamp1_Up.BackColor = Color.Silver;
            }
            // CLAMP 2 UP        
            if (PLC.readplc(PLC_INPUT_CLAMP_2_UP) == "1")
            {
                INPUT_Clamp2_Up.BackColor = Color.Red;
            }
            else
            {
                INPUT_Clamp2_Up.BackColor = Color.Silver;
            }
            // STOPPER 3 UP        
            if (PLC.readplc(PLC_INPUT_STOPPER_3_UP) == "1")
            {
                INPUT_Stopper3_Up.BackColor = Color.Red;
            }
            else
            {
                INPUT_Stopper3_Up.BackColor = Color.Silver;
            }
            // STOPPER 3 DOWN        
            if (PLC.readplc(PLC_INPUT_STOPPER_3_DOWN) == "1")
            {
                INPUT_Stopper3_Down.BackColor = Color.Red;
            }
            else
            {
                INPUT_Stopper3_Down.BackColor = Color.Silver;
            }

            // DOOR OPEN        
            if (PLC.readplc(PLC_INPUT_DOOR) == "1")
            {
                INPUT_Door.BackColor = Color.Red;
            }
            else
            {
                INPUT_Door.BackColor = Color.Silver;
            }

            // LIGHT_CURTAIN        
            if (PLC.readplc(PLC_INPUT_LIGHTCURTAIN) == "1")
            {
                INPUT_Light_Curtain.BackColor = Color.Red;
            }
            else
            {
                INPUT_Light_Curtain.BackColor = Color.Silver;
            }



            Thread.Sleep(200);
            input_monitor = true;
        }
        #endregion


        #region OUTPUT MONITOR
        public void OUTPUT_MONITOR_PLC()
        {

            if (PLC.readplc(PLC_OUTPUT_TL_R) == "1")
            {
                OUTPUT_TowerLamp_R.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_TowerLamp_R.BackColor = Color.Silver;
            }
            // T/L Yellow        
            if (PLC.readplc(PLC_OUTPUT_TL_Y) == "1")
            {
                OUTPUT_TowerLamp_Y.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_TowerLamp_Y.BackColor = Color.Silver;
            }
            // T/L Green        
            if (PLC.readplc(PLC_OUTPUT_TL_G) == "1")
            {
                OUTPUT_TowerLamp_G.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_TowerLamp_G.BackColor = Color.Silver;
            }
            // T/L Buzzer        
            if (PLC.readplc(PLC_OUTPUT_TL_B) == "1")
            {
                OUTPUT_TowerLamp_BZ.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_TowerLamp_BZ.BackColor = Color.Silver;
            }
            // CLAMP 1       
            if (PLC.readplc(PLC_OUTPUT_CLAMP1) == "1")
            {
                OUTPUT_Clamp1.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_Clamp1.BackColor = Color.Silver;
            }
            // CLAMP 2       
            if (PLC.readplc(PLC_OUTPUT_CLAMP2) == "1")
            {
                OUTPUT_Clamp2.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_Clamp2.BackColor = Color.Silver;
            }
            // STOPPER 3      
            if (PLC.readplc(PLC_OUTPUT_STOPPER3) == "1")
            {
                OUTPUT_Stopper3.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_Stopper3.BackColor = Color.Silver;
            }
            // CONVEYOR    
            if (PLC.readplc(PLC_OUTPUT_CONVEYOR) == "1")
            {
                OUTPUT_CNV.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_CNV.BackColor = Color.Silver;
            }
            // SCANNER 1    
            if (PLC.readplc(PLC_OUTPUT_SCANNER1) == "1")
            {
                OUTPUT_Scanner1.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_Scanner1.BackColor = Color.Silver;
            }
            // SCANNER 2    
            if (PLC.readplc(PLC_OUTPUT_SCANNER2) == "1")
            {
                OUTPUT_Scanner2.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_Scanner2.BackColor = Color.Silver;
            }

            // READY LAMP    
            if (PLC.readplc(PLC_OUTPUT_LAMP_READY) == "1")
            {
                OUTPUT_ReadyLamp.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_ReadyLamp.BackColor = Color.Silver;
            }

            //  START LAMP
            if (PLC.readplc(PLC_OUTPUT_LAMP_START) == "1")
            {
                OUTPUT_StartLamp.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_StartLamp.BackColor = Color.Silver;
            }

            //  STOP LAMP
            if (PLC.readplc(PLC_OUTPUT_LAMP_STOP) == "1")
            {
                OUTPUT_StopLamp.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_StopLamp.BackColor = Color.Silver;
            }
            //  RESET LAMP
            if (PLC.readplc(PLC_OUTPUT_LAMP_RESET) == "1")
            {
                OUTPUT_ResetLamp.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_ResetLamp.BackColor = Color.Silver;
            }
            //  Buzzer LAMP
            if (PLC.readplc(PLC_OUTPUT_LAMP_BZ) == "1")
            {
                OUTPUT_BuzzerStopLamp.BackColor = Color.Red;
            }
            else
            {
                OUTPUT_BuzzerStopLamp.BackColor = Color.Silver;
            }


            Thread.Sleep(200);
            output_monitor = true;
        }
        #endregion





        public void ResetCounter()
        {
            counter_total_input = 0;
            counter_total_OK = 0;
            counter_total_NG = 0;

            txtCounterTotal_Input.Text = counter_total_input.ToString();
            txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
            txtCounterTotal_Input_NG.Text = counter_total_NG.ToString();
        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {

            ResetCounter();
            Tao_Log_Voi_Noi_Dung_La("RESET COUNTER");
        }

        private void btnResetCycletime_Click(object sender, EventArgs e)
        {
            try
            {
                PLC.Writeplc(PLC_Reset_CycleTime, 1);
                Thread.Sleep(200);
                PLC.Writeplc(PLC_Reset_CycleTime, 0);
            }
            catch
            {

            }
        }

        private void btnCompleteReadyPos_Click(object sender, EventArgs e)
        {

            PLC.Writeplc(PLC_RUNNING_DEVICE_READY_POS_X, int.Parse(txtReady_X.Text));
            PLC.Writeplc(PLC_RUNNING_DEVICE_READY_POS_Y, int.Parse(txtReady_Y.Text));
            PLC.Writeplc(PLC_RUNNING_DEVICE_Ready_Speed, int.Parse(txtReady_Speed.Text));
            PLC.Writeplc(PLC_RUNNING_DEVICE_Ready_Delay, int.Parse(txtReady_DelayTime.Text));
            Tao_Log_Voi_Noi_Dung_La("READY POSITION CHANGE");

        }

        private void btnMoveReadyPos_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_ROBOT_POS_NO, 1);
            Thread.Sleep(100);
            PLC.Writeplc(PLC_MANUAL_ROBOT_MOVE, 1);
            Thread.Sleep(200);
            PLC.Writeplc(PLC_MANUAL_ROBOT_MOVE, 0);

        }



        private void ptbbtn_CallScreenJogRobot_Click(object sender, EventArgs e)
        {
            fJogRobot.ShowDialog();
            Tao_Log_Voi_Noi_Dung_La("JOG MODE ON");
        }

        private void ptbbtn_CallScreenJogRobot_MouseDown(object sender, MouseEventArgs e)
        {
            ptbbtn_CallScreenJogRobot.Image = Properties.Resources.JogOFF;
        }

        private void ptbbtn_CallScreenJogRobot_MouseUp(object sender, MouseEventArgs e)
        {
            ptbbtn_CallScreenJogRobot.Image = Properties.Resources.JogON;
        }


        private void lblLinkModel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)  // Chuột phải chọn model
            {
                Call_Model();


            }

            //    if (e.Button == MouseButtons.Left)  // Chuột trái
            //    {
            //        Call_Model();
            //    }

            //    if (e.Button == MouseButtons.Middle)  // Chuột giữa
            //    {
            //        Call_Model();
            //    }

        }





        public void Call_Setting_TowerLamp()
        {
            // AUTO
            if (AUTO_RUN_RED.Checked == true)
            {
                PLC.Writeplc(PLC_TL_AUTO_R, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_AUTO_R, 0);
            }

            if (AUTO_RUN_YELLOW.Checked == true)
            {
                PLC.Writeplc(PLC_TL_AUTO_Y, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_AUTO_Y, 0);
            }

            if (AUTO_RUN_GREEN.Checked == true)
            {
                PLC.Writeplc(PLC_TL_AUTO_G, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_AUTO_G, 0);
            }
            if (AUTO_RUN_BUZZER.Checked == true)
            {
                PLC.Writeplc(PLC_TL_AUTO_B, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_AUTO_B, 0);
            }






            // STOP
            if (STOP_RED.Checked == true)
            {
                PLC.Writeplc(PLC_TL_STOP_R, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_STOP_R, 0);
            }
            if (STOP_YELLOW.Checked == true)
            {
                PLC.Writeplc(PLC_TL_STOP_Y, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_STOP_Y, 0);
            }
            if (STOP_GREEN.Checked == true)
            {
                PLC.Writeplc(PLC_TL_STOP_G, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_STOP_G, 0);
            }
            if (STOP_BUZZER.Checked == true)
            {
                PLC.Writeplc(PLC_TL_STOP_B, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_STOP_B, 0);
            }
            // ALARM
            if (ALARM_RED.Checked == true)
            {
                PLC.Writeplc(PLC_TL_ALARM_R, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_ALARM_R, 0);
            }
            if (ALARM_YELLOW.Checked == true)
            {
                PLC.Writeplc(PLC_TL_ALARM_Y, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_ALARM_Y, 0);
            }
            if (ALARM_GREEN.Checked == true)
            {
                PLC.Writeplc(PLC_TL_ALARM_G, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_ALARM_G, 0);
            }
            if (ALARM_BUZZER.Checked == true)
            {
                PLC.Writeplc(PLC_TL_ALARM_B, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_ALARM_B, 0);
            }



            // WAITING
            if (WAITING_RED.Checked == true)
            {
                PLC.Writeplc(PLC_TL_WAITING_R, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_WAITING_R, 0);
            }
            if (WAITING_YELLOW.Checked == true)
            {
                PLC.Writeplc(PLC_TL_WAITING_Y, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_WAITING_Y, 0);
            }
            if (WAITING_GREEN.Checked == true)
            {
                PLC.Writeplc(PLC_TL_WAITING_G, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_WAITING_G, 0);
            }
            if (WAITING_BUZZER.Checked == true)
            {
                PLC.Writeplc(PLC_TL_WAITING_B, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_WAITING_B, 0);
            }



            // SCANNNING
            if (SCANNING_RED.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCANNING_R, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCANNING_R, 0);
            }
            if (SCANNING_YELLOW.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCANNING_Y, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCANNING_Y, 0);
            }
            if (SCANNING_GREEN.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCANNING_G, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCANNING_G, 0);
            }
            if (SCANNING_BUZZER.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCANNING_B, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCANNING_B, 0);
            }



            // RESULT OK
            if (SCAN_OK_RED.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_R, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_R, 0);
            }
            if (SCAN_OK_YELLOW.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_Y, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_Y, 0);
            }
            if (SCAN_OK_GREEN.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_G, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_G, 0);
            }
            if (SCAN_OK_BUZZER.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_B, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_OK_B, 0);
            }


            // RESULT NG
            if (SCAN_NG_RED.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_R, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_R, 0);
            }
            if (SCAN_NG_YELLOW.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_Y, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_Y, 0);
            }
            if (SCAN_NG_GREEN.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_G, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_G, 0);
            }
            if (SCAN_NG_BUZZER.Checked == true)
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_B, 1);
            }
            else
            {
                PLC.Writeplc(PLC_TL_SCAN_RESULT_NG_B, 0);
            }



        }





        private void btnManualMoveRobot_Click(object sender, EventArgs e)
        {
            PLC.Writeplc(PLC_MANUAL_ROBOT_MOVE, 1);
            Thread.Sleep(200);
            PLC.Writeplc(PLC_MANUAL_ROBOT_MOVE, 0);
        }

        private void txtManualDiemChayRobot_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(txtManualDiemChayRobot.Text);
                if (temp < 0)
                {
                    temp = 0;
                    txtManualDiemChayRobot.Text = temp.ToString();
                }
                if (temp > int.Parse(txtSoDiemChayRoBot.Text))
                {
                    temp = int.Parse(txtSoDiemChayRoBot.Text);
                    txtManualDiemChayRobot.Text = temp.ToString();
                }
                DiemChayManual = temp;

                //txtManualDiemChayRobot.Text = DiemChayManual.ToString();
                PLC.Writeplc(PLC_MANUAL_ROBOT_POS_NO, DiemChayManual + 1);
            }
            catch
            {
                MessageBox.Show("Data nhập không đúng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DiemChayManual = 0;
                txtManualDiemChayRobot.Text = "0";
            }

        }

        private void btnRun_By_Pass_Click(object sender, EventArgs e)
        {
            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                if (PLC.readplc(PLC_ManuBar_By_Pass) == "0")
                {
                    PLC.Writeplc(PLC_ManuBar_By_Pass, 1);
                }
                else
                {
                    PLC.Writeplc(PLC_ManuBar_By_Pass, 0);
                }
            }
        }





        private void btnConnectPLC_Click(object sender, EventArgs e)
        {
            if (PLC.PLC_Connect == false)
            {
                PLC.thietlap(txtPLC_IP, txtPLC_CPU_CODE);
                PLC.ketnoi();
            }

            if (PLC.PLC_Connect == true)
            {
                MessageBox.Show("Kết nối thành công", "Thông báo kết nối PC - PLC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_PLC_status.ForeColor = Color.White;
                lbl_PLC_status.BackColor = Color.Green;

                //pictureBox_status.Enabled = true;
            }
            else
            {
                MessageBox.Show("Kết nối thất bại, hãy thử lại sau.", "Thông báo lỗi kết nối PC - PLC", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btnSelectModeRunning_Click(object sender, EventArgs e)
        {
            if (AllowSendToMes == true)
            {
                AllowSendToMes = false;
                btnSelectModeRunning.BackColor = Color.Red;
                btnSelectModeRunning.Text = "OFFLINE\r\nOBA/TEST_FAKE";
                Tao_Log_Voi_Noi_Dung_La("OFFLINE MODE ON");
            }
            else
            {
                AllowSendToMes = true;
                btnSelectModeRunning.BackColor = Color.SeaGreen;
                btnSelectModeRunning.Text = "ONLINE\r\nPO RUNNING";
                Tao_Log_Voi_Noi_Dung_La("ONLINE MODE ON");
            }

        }

        private void checkBox_Mode_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mode_1.Checked == true)
            {
                checkBox_Mode_1.Checked = true;
                checkBox_Mode_2.Checked = false;
                checkBox_Mode_3.Checked = false;
                checkBox_Mode_4.Checked = false;
                Select_Mode_Array = 1;
            }
        }

        private void checkBox_Mode_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mode_2.Checked == true)
            {
                checkBox_Mode_1.Checked = false;
                checkBox_Mode_2.Checked = true;
                checkBox_Mode_3.Checked = false;
                checkBox_Mode_4.Checked = false;
                Select_Mode_Array = 2;
            }
        }

        private void checkBox_Mode_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mode_3.Checked == true)
            {
                checkBox_Mode_1.Checked = false;
                checkBox_Mode_2.Checked = false;
                checkBox_Mode_3.Checked = true;
                checkBox_Mode_4.Checked = false;
                Select_Mode_Array = 3;
            }
        }

        private void checkBox_Mode_4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Mode_4.Checked == true)
            {
                checkBox_Mode_1.Checked = false;
                checkBox_Mode_2.Checked = false;
                checkBox_Mode_3.Checked = false;
                checkBox_Mode_4.Checked = true;
                Select_Mode_Array = 4;
            }
        }

        private void btnChangeTowerLamp_Click_1(object sender, EventArgs e)
        {
            DATA.Check_Folder("DATA");
            SaveChangeTowerlampSetting();
            Call_Setting_TowerLamp();
            Tao_Log_Voi_Noi_Dung_La("TOWER LAMP SETTING CHANGE");
        }

        private void btnSaveSettingPLC_Click(object sender, EventArgs e)
        {
            DATA.Check_Folder("DATA");
            SavePLCSetting();
            Tao_Log_Voi_Noi_Dung_La("SETTING PLC CHANGE");
        }

        private void btnSaveSettingMES_Click(object sender, EventArgs e)
        {
            DATA.Check_Folder("DATA");
            TEXT.SaveMesSetting(tb_IPMES, tb_LineNo, tb_MCID, tb_StnID, tb_PortMES, tb_WorkerID);
            Tao_Log_Voi_Noi_Dung_La("MES SETTING CHANGE");
        }

        private void btnSaveSettingScanner_Click(object sender, EventArgs e)
        {
            DATA.Check_Folder("DATA");
            TEXT.SaveScannerSetting(tb_IPscanner1, tb_IPscanner2);
            Tao_Log_Voi_Noi_Dung_La("SCANNER SETTING CHANGE");
        }

        private void btnSaveSettingDevice_Click(object sender, EventArgs e)
        {
            DATA.Check_Folder("DATA");
            TEXT.SaveDeviceSetting
                (
                tb_CurrentPositionDevice,
                tb_ScanningDevive,
                tb_codeJigOKDevice,
                tb_CodeJigNGDevice,
                tb_ReadOKDevice,
                tb_ReadNGDevice,
                tb_Scan_Done_Device,
                tb_TotalOKDevice,
                tb_TotalNGDevice,
                tb_StopModeDevice,
                tb_CycleTimeScan,
                txtDelayTimeNormally,
                txtDelayTimeWhenHaveNG

                );

            Tao_Log_Voi_Noi_Dung_La("PLC DEVICE CHANGE");
        }

        //private void btnSaveSettingLinkSaveFile_Click(object sender, EventArgs e)
        //{
        //    DATA.Check_Folder("DATA");
        //    TEXT.Save_Log_Barcode(checkBox_SaveLogFileBarcodePCM);
        //    Tao_Log_Voi_Noi_Dung_La("LINK SAVE FILE RESULT CHANGE");
        //}

        private void checkBox_MesON_CheckedChanged_1(object sender, EventArgs e)
        {


        }


        private delegate void delegateUserControl(string str);

        public void ViewScanner(LiveviewForm Monitor, string IP, ReaderAccessor m_reader)
        {

            //Stop liveview.
            Monitor.EndReceive();
            //Set ip address of liveview.
            Monitor.IpAddress = IP;
            //Start liveview.
            Monitor.BeginReceive();
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





        #region Show monitor data


        //public void showMonitor()  // Quét liên tục hiển thị trạng thái code
        //{
        //    MonitorIsRunning = true;  // Biến cài để khóa chéo
        //    while (true)
        //    {
        //        for (int i = 1; i < 41; i++)
        //        {
        //            display(i, status_PCM[i]);
        //        }

        //        Thread.Sleep(100);
        //    }
        //}













        public void display(int CH, int status)
        {
            Color monitor_default = Color.FromName("DimGray");  // Color hiển thị default
            Color monitor_OK = Color.FromName("Green");  // Color hiển thị lúc OK
            Color monitor_NG = Color.FromName("Red"); // Color hiển thị lúc NG




            switch (CH) // Kiểm tra từng kênh
            {




                case 1: //Kênh 1
                    lblResultCode_01.Text = ArrayCode[1];
                    lblErrorCode_01.Text = errorCode[1];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_01.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_01.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_01.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    lblResultCode_02.Text = ArrayCode[2];
                    lblErrorCode_02.Text = errorCode[2];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_02.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_02.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_02.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    lblResultCode_03.Text = ArrayCode[3];
                    lblErrorCode_03.Text = errorCode[3];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_03.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_03.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_03.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    lblResultCode_04.Text = ArrayCode[4];
                    lblErrorCode_04.Text = errorCode[4];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_04.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_04.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_04.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    lblResultCode_05.Text = ArrayCode[5];
                    lblErrorCode_05.Text = errorCode[5];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_05.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_05.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_05.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 6:
                    lblResultCode_06.Text = ArrayCode[6];
                    lblErrorCode_06.Text = errorCode[6];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_06.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_06.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_06.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 7:
                    lblResultCode_07.Text = ArrayCode[7];
                    lblErrorCode_07.Text = errorCode[7];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_07.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_07.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_07.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 8:
                    lblResultCode_08.Text = ArrayCode[8];
                    lblErrorCode_08.Text = errorCode[8];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_08.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_08.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_08.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 9:
                    lblResultCode_09.Text = ArrayCode[9];
                    lblErrorCode_09.Text = errorCode[9];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_09.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_09.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_09.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 10:
                    lblResultCode_10.Text = ArrayCode[10];
                    lblErrorCode_10.Text = errorCode[10];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_10.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_10.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_10.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 11:
                    lblResultCode_11.Text = ArrayCode[11];
                    lblErrorCode_11.Text = errorCode[11];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_11.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_11.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_11.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 12:
                    lblResultCode_12.Text = ArrayCode[12];
                    lblErrorCode_12.Text = errorCode[12];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_12.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_12.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_12.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 13:
                    lblResultCode_13.Text = ArrayCode[13];
                    lblErrorCode_13.Text = errorCode[13];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_13.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_13.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_13.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 14:
                    lblResultCode_14.Text = ArrayCode[14];
                    lblErrorCode_14.Text = errorCode[14];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_14.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_14.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_14.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 15:
                    lblResultCode_15.Text = ArrayCode[15];
                    lblErrorCode_15.Text = errorCode[15];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_15.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_15.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_15.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 16:
                    lblResultCode_16.Text = ArrayCode[16];
                    lblErrorCode_16.Text = errorCode[16];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_16.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_16.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_16.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 17:
                    lblResultCode_17.Text = ArrayCode[17];
                    lblErrorCode_17.Text = errorCode[17];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_17.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_17.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_17.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 18:
                    lblResultCode_18.Text = ArrayCode[18];
                    lblErrorCode_18.Text = errorCode[18];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_18.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_18.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_18.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 19:
                    lblResultCode_19.Text = ArrayCode[19];
                    lblErrorCode_19.Text = errorCode[19];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_19.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_19.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_19.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 20:
                    lblResultCode_20.Text = ArrayCode[20];
                    lblErrorCode_20.Text = errorCode[20];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_20.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_20.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_20.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 21:
                    lblResultCode_21.Text = ArrayCode[21];
                    lblErrorCode_21.Text = errorCode[21];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_21.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_21.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_21.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 22:
                    lblResultCode_22.Text = ArrayCode[22];
                    lblErrorCode_22.Text = errorCode[22];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_22.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_22.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_22.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 23:
                    lblResultCode_23.Text = ArrayCode[23];
                    lblErrorCode_23.Text = errorCode[23];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_23.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_23.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_23.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 24:
                    lblResultCode_24.Text = ArrayCode[24];
                    lblErrorCode_24.Text = errorCode[24];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_24.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_24.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_24.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 25:
                    lblResultCode_25.Text = ArrayCode[25];
                    lblErrorCode_25.Text = errorCode[25];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_25.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_25.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_25.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 26:
                    lblResultCode_26.Text = ArrayCode[26];
                    lblErrorCode_26.Text = errorCode[26];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_26.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_26.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_26.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 27:
                    lblResultCode_27.Text = ArrayCode[27];
                    lblErrorCode_27.Text = errorCode[27];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_27.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_27.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_27.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 28:
                    lblResultCode_28.Text = ArrayCode[28];
                    lblErrorCode_28.Text = errorCode[28];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_28.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_28.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_28.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 29:
                    lblResultCode_29.Text = ArrayCode[29];
                    lblErrorCode_29.Text = errorCode[29];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_29.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_29.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_29.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 30:
                    lblResultCode_30.Text = ArrayCode[30];
                    lblErrorCode_30.Text = errorCode[30];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_30.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_30.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_30.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 31:
                    lblResultCode_31.Text = ArrayCode[31];
                    lblErrorCode_31.Text = errorCode[31];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_31.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_31.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_31.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 32:
                    lblResultCode_32.Text = ArrayCode[32];
                    lblErrorCode_32.Text = errorCode[32];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_32.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_32.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_32.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 33:
                    lblResultCode_33.Text = ArrayCode[33];
                    lblErrorCode_33.Text = errorCode[33];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_33.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_33.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_33.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 34:
                    lblResultCode_34.Text = ArrayCode[34];
                    lblErrorCode_34.Text = errorCode[34];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_34.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_34.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_34.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 35:
                    lblResultCode_35.Text = ArrayCode[35];
                    lblErrorCode_35.Text = errorCode[35];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_35.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_35.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_35.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 36:
                    lblResultCode_36.Text = ArrayCode[36];
                    lblErrorCode_36.Text = errorCode[36];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_36.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_36.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_36.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 37:
                    lblResultCode_37.Text = ArrayCode[37];
                    lblErrorCode_37.Text = errorCode[37];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_37.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_37.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_37.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 38:
                    lblResultCode_38.Text = ArrayCode[38];
                    lblErrorCode_38.Text = errorCode[38];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_38.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_38.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_38.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 39:
                    lblResultCode_39.Text = ArrayCode[39];
                    lblErrorCode_39.Text = errorCode[39];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_39.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_39.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_39.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                case 40:
                    lblResultCode_40.Text = ArrayCode[40];
                    lblErrorCode_40.Text = errorCode[40];
                    switch (status)
                    {
                        case 1://Default status
                            panel_pcm_40.BackColor = monitor_default;
                            break;
                        case 2://OK status
                            panel_pcm_40.BackColor = monitor_OK;
                            break;
                        case 3://NG status
                            panel_pcm_40.BackColor = monitor_NG;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Kết nối C-MES
        public void Connect_MES()
        {
            socket = new clsSocket(this);
            socket.Lineno = tb_LineNo.Text;
            socket.Mcid = tb_MCID.Text;
            socket.Portprocess = "001";
            socket.Stnid1 = tb_MCID.Text;
            socket.Stnid2 = "";
            socket.Stnid3 = "";
            socket.Workerid = tb_WorkerID.Text;
            socket.Ipadd = tb_IPMES.Text;
            socket.Port = int.Parse(tb_PortMES.Text);
            socket.start(tb_IPMES.Text);
        }

        #endregion

        #region Kết nối scaner
        public void Connect_Scanner()
        {
            if (Scaner1.connect(tb_IPscanner1.Text, port, lbl_Scanner1_status) == true)
                Tao_Log_Voi_Noi_Dung_La("SCANNER#1 CONNECT OK");

            else
                Tao_Log_Voi_Noi_Dung_La("SCANNER#1 CONNECT NG");



            if (Scaner2.connect(tb_IPscanner2.Text, port, lbl_Scanner2_status) == true)
                Tao_Log_Voi_Noi_Dung_La("SCANNER#2 CONNECT OK");
            else
                Tao_Log_Voi_Noi_Dung_La("SCANNER#2 CONNECT NG");
        }

        #endregion


        bool KhoaCheoWarningCodeJigNG = false;
        #region Đọc code Jig
        public void readCodeJig() // Đọc code jig (thread)
        {
            CodeJig = "";

            if (txtChonScannerDocCodeJig.Text == "1")
            {
                CodeJig = Scaner1.read_data(); // Đọc code jig bằng scanner 01
            }
            if (txtChonScannerDocCodeJig.Text == "2")
            {
                CodeJig = Scaner2.read_data(); // Đọc code jig bằng scanner 02 
            }




            if (CodeJig != "ERROR" && CodeJig != "" && CodeJig != null)  // Kiểm tra code jig đọc OK không
            {
                if (checkCodeJig(CodeJig)) // Kiểm tra code jig đã được đọc trùng không
                {
                    // Nếu code jig là mới
                    PLC.Writeplc(tb_codeJigOKDevice.Text, 1); // Trả về PLC biến code jig OK
                    Thread.Sleep(200);

                    Scanning_Step++;  // Tăng điểm scan step lên 1 đơn vị
                    WaitingScan = true;  // Cho phép đọc tiếp điểm kế tiếp
                }
                else
                {
                    ScanningIsOn = false;
                    KhoaCheoWarningCodeJigNG = true;
                    Scanning_Step = 0;  //
                    //Scanning_Step++;  // Tăng điểm scan step lên 1 đơn vị
                    WaitingScan = false;  // Cho phép đọc tiếp điểm kế tiếp
                    // Code bị trùng tên
                    CodeJig = "";
                    PLC.Writeplc(tb_CodeJigNGDevice.Text, 1); // Trả về PLC biến code jig NG
                    Thread.Sleep(1000);
                    if (KhoaCheoWarningCodeJigNG)
                    {
                        DialogResult rs = MessageBox.Show("Maskboard này đã được đọc code rồi, vui lòng không đọc lại nữa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (rs == DialogResult.OK)
                        {
                            
                            KhoaCheoWarningCodeJigNG = false;
                            ScanningIsOn = true;
                            return;

                        }
                    }

                }
            }
            else  // Trường hợp ko đọc được code, code error
            {
                KhoaCheoWarningCodeJigNG2 = false;
                //Thread_ReadCodeJig.Abort();
                Scanning_Step = 1000;



                PLC.Writeplc(PLC_MenuBar_Stop, 1);
                //Thread.Sleep(200);
                PLC.Writeplc(tb_CodeJigNGDevice.Text, 1); // Trả về PLC biến code jig NG

                if (KhoaCheoWarningCodeJigNG2 == false)
                {
                    DialogResult rs = MessageBox.Show("Không đọc được code jig maskboard, Kiểm tra lại vị trí đọc hoặc code in trên jig bị NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (rs == DialogResult.OK)
                    {
                        Scanning_Step = 0;  // Reset step đọc code
                        //Scanning_Step = 1000;  // Tăng điểm scan step lên 1 đơn vị
                        WaitingScan = true;  // Cho phép đọc tiếp điểm kế tiếp
                        
                        ScanningIsOn = false;
                        CodeJig = "";

                        PLC.Writeplc(PLC_MenuBar_Stop, 0);

                        KhoaCheoWarningCodeJigNG2 = true;
                        return;

                    }


                }
            }
        }







        public bool checkCodeJig(string barcode)  // Kiểm tra code jig đã được đọc hay chưa
        {
            try
            {
                int tmp = 0;
                string[] ListFile = Directory.GetFiles(tb_LinkAddCode.Text);

                if (ListFile.Length > 0)
                {
                    for (int i = 0; i < ListFile.Length; i++)
                    {
                        string[] str = ListFile[i].Split('\\');
                        string[] str1 = str[str.Length - 1].Split('-');

                        if (checkBox_typeCodeJig_DateTime.Checked)
                        {
                            if (barcode == str1[0])
                            {
                                tmp++;
                                break;
                            }
                        }
                        if (checkBox_CodeJig_Only.Checked)
                        {
                            string codejig = barcode.ToUpper() + ".txt";
                            if (codejig == str1[0])
                            {
                                tmp++;
                                break;
                            }
                        }

                    }
                    if (tmp > 0)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
            catch
            {

                STOP();

                MessageBox.Show("Link folder add barcode không tồn tại, Kiểm tra lại link trong phần teaching, hoặc kết nối mạng máy Function NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
        }

        #endregion






        #region Xử lý data đọc từ scanner
        public bool SCAN_NORMALY = true;
        public int time_delay_normal = 200;   // Delay xuất tín hiệu  Read OK khi mà đọc xong 1 PCM
        public int time_delay_when_have_NG = 1000; // Delay xuất tín hiệu  Read OK khi mà đọc xong 1 PCM, phải tăng lên để đọc dc 40 pcm


        public void xuLyDataScanner()
        {


            string scan1 = "";
            string scan2 = "";
            scan1 = Scaner1.read_data();   // Kết quả đọc từ scan1
            scan2 = Scaner2.read_data();   // Kết quả đọc từ scan2

            if (scan1 != "ERROR" && scan2 != "ERROR")
            {
                //// Gán code cho các PCM tương ứng tại các vị trí đọc code
                //ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = txtOracel_PO_InUse.Text + scan1;
                //ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = txtOracel_PO_InUse.Text + scan2;

                if (cbxLuaChonAddThemMaProduct.Text == "NO") // Nếu chọn không add thêm mã product thì nhận trực tiếp từ scanner
                {
                    ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = scan1;
                    ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = scan2;
                }
                else // Nếu có chọn add thêm mã product thì sẽ xét tiếp add manual hay auto
                {
                    if (checkBox_AutoAddProduct.Checked == true) // Add thêm mã auto nhận từ cmes auto
                    {
                        ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = txtOracel_PO_InUse.Text + scan1;
                        ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = txtOracel_PO_InUse.Text + scan2;
                    }
                    else // Add thêm mã manual từ text box manual
                    {
                        ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = txtManualAddProduct.Text + scan1;
                        ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = txtManualAddProduct.Text + scan2;
                    }
                }


                // Màu hiển thị tại monitor
                status_PCM[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = 1;  // Khi nhận data từng kênh thì monitor hiển thị default color
                status_PCM[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = 1;  // Khi nhận data từng kênh thì monitor hiển thị default color



                if (Scanning_Step < final_Pos_run)  // Nếu điểm chạy robot nhỏ hơn điểm cuối cùng list tọa độ
                {
                    Scanning_Step++;  // Tăng step chạy
                    WaitingScan = true; // Cho phép quét tiếp


                    if (SCAN_NORMALY) // Nếu những lần scan trước đó là bình thường thì delay ít, nếu có NG thì tăng delay lên để PLC chạy dc hết 40 pcm
                    {
                        Thread.Sleep(time_delay_normal); // Delay để chờ PLC refrest sau đó mới set biến Read OK thì PLC mới chạy trục tiếp
                    }
                    else
                    {
                        Thread.Sleep(time_delay_when_have_NG); // Delay để chờ PLC refrest sau đó mới set biến Read OK thì PLC mới chạy trục tiếp
                    }


                    PLC.Writeplc(tb_ReadOKDevice.Text, 1);   // Send kết quả OK lên PLC
                }
                else  // Sau khi đọc hết jig 40 pcm  // Xử lý data khi đọc hoàn thành 40 PCM
                {
                    Error_Set_ON = 0; // Reset biến error code

                    try
                    {
                        #region Tách lot hàng NG

                        int j = 1;
                        if ((checkBox_TachLotTheoNgayThangON.Text == "ON") || (checkBox_TachLotTheoFileDataON.Text == "ON"))
                        {
                            while (j <= 41) // 40 PCM bắt đầu từ 1
                            {
                                if (j < 41)
                                {
                                    if (ArrayCode[j] != "ERROR") // Kiểm tra code OK hay không đọc được
                                    {

                                        if (checkBox_TachLotTheoFileDataON.Text == "ON")
                                        {
                                            if (checkData.CheckDuplicateInforamation(ArrayCode[j], Listbarcode)) // Kiểm tra double code tại list đã load ra
                                            {
                                                // Không có double code
                                                // Kiểm tra tiếp điều kiện ngày tháng nếu được chọn
                                                if (checkBox_TachLotTheoNgayThangON.Text == "ON") // Nếu chọn thì check
                                                {
                                                    string YEAR = ArrayCode[j].Substring(int.Parse(txtViTriKiTuNAM.Text), 1);

                                                    if ((YEAR == (txtYEAR_NG1.Text))
                                                        || (YEAR == (txtYEAR_NG2.Text))
                                                        || (YEAR == (txtYEAR_NG3.Text))
                                                        || (YEAR == (txtYEAR_NG4.Text))
                                                        || (YEAR == (txtYEAR_NG5.Text))
                                                        || (YEAR == (txtYEAR_NG6.Text))
                                                        )
                                                    {
                                                        status_PCM[j] = 3;  // lỗi code
                                                        errorCode[j] = "Lot_hàng_NG_Year";
                                                        //counter_total_NG++; // đếm counter NG + 1 PCM
                                                        //counter_total_OK--;
                                                        Error_Set_ON++;
                                                        //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                        //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter 

                                                    }

                                                    else
                                                    {
                                                        if (YEAR == (txtYEAR_OK.Text))
                                                        {
                                                            string MONTH = ArrayCode[j].Substring(int.Parse(txtViTriKiTuTHANG.Text), 1);
                                                            if ((MONTH == (txtMONTH_NG1.Text))
                                                                 || (MONTH == (txtMONTH_NG2.Text))
                                                                 || (MONTH == (txtMONTH_NG3.Text))
                                                                 || (MONTH == (txtMONTH_NG4.Text))
                                                                 || (MONTH == (txtMONTH_NG5.Text))
                                                                 || (MONTH == (txtMONTH_NG6.Text))
                                                                 || (MONTH == (txtMONTH_NG7.Text))
                                                                 || (MONTH == (txtMONTH_NG8.Text))
                                                                 || (MONTH == (txtMONTH_NG9.Text))
                                                                 || (MONTH == (txtMONTH_NG10.Text))
                                                                 || (MONTH == (txtMONTH_NG11.Text))
                                                                 || (MONTH == (txtMONTH_NG12.Text))
                                                                 )
                                                            {
                                                                status_PCM[j] = 3;  // lỗi code
                                                                errorCode[j] = "Lot_hàng_NG_Month";
                                                                //counter_total_NG++; // đếm counter NG + 1 PCM
                                                                //counter_total_OK--;
                                                                Error_Set_ON++;
                                                                //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                                //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter   
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else // Double code
                                            {
                                                status_PCM[j] = 3;  // lỗi code
                                                errorCode[j] = "DOUBLE BARCODE";
                                                Error_Set_ON++;
                                            }
                                        }

                                        else // Trường hợp không kiểm tra theo data thì kiểm tra theo ngày tháng
                                        {
                                            if (checkBox_TachLotTheoNgayThangON.Text == "ON") // Nếu chọn thì check theo ngày tháng
                                            {
                                                string YEAR = ArrayCode[j].Substring(int.Parse(txtViTriKiTuNAM.Text), 1);

                                                if ((YEAR == (txtYEAR_NG1.Text))
                                                    || (YEAR == (txtYEAR_NG2.Text))
                                                    || (YEAR == (txtYEAR_NG3.Text))
                                                    || (YEAR == (txtYEAR_NG4.Text))
                                                    || (YEAR == (txtYEAR_NG5.Text))
                                                    || (YEAR == (txtYEAR_NG6.Text))
                                                    )
                                                {
                                                    status_PCM[j] = 3;  // lỗi code
                                                    errorCode[j] = "Lot_hàng_NG_Year";
                                                    //counter_total_NG++; // đếm counter NG + 1 PCM
                                                    //counter_total_OK--;
                                                    Error_Set_ON++;
                                                    //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                    //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter 

                                                }

                                                else
                                                {
                                                    if (YEAR == (txtYEAR_OK.Text))
                                                    {
                                                        string MONTH = ArrayCode[j].Substring(int.Parse(txtViTriKiTuTHANG.Text), 1);
                                                        if ((MONTH == (txtMONTH_NG1.Text))
                                                             || (MONTH == (txtMONTH_NG2.Text))
                                                             || (MONTH == (txtMONTH_NG3.Text))
                                                             || (MONTH == (txtMONTH_NG4.Text))
                                                             || (MONTH == (txtMONTH_NG5.Text))
                                                             || (MONTH == (txtMONTH_NG6.Text))
                                                             || (MONTH == (txtMONTH_NG7.Text))
                                                             || (MONTH == (txtMONTH_NG8.Text))
                                                             || (MONTH == (txtMONTH_NG9.Text))
                                                             || (MONTH == (txtMONTH_NG10.Text))
                                                             || (MONTH == (txtMONTH_NG11.Text))
                                                             || (MONTH == (txtMONTH_NG12.Text))
                                                             )
                                                        {
                                                            status_PCM[j] = 3;  // lỗi code
                                                            errorCode[j] = "Lot_hàng_NG_Month";
                                                            //counter_total_NG++; // đếm counter NG + 1 PCM
                                                            //counter_total_OK--;
                                                            Error_Set_ON++;
                                                            //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                            //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter   
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    Thread.Sleep(5);
                                    j++;
                                }
                                else
                                {
                                    j++;
                                    break;
                                }
                            }
                        }
                        else // Không kiểm tra tách lot
                        {
                            Error_Set_ON = 0;
                        }
                        #endregion
                    }
                    catch
                    {
                        Error_Set_ON++;
                        STOP();                     
                        MessageBox.Show("Tách lot hàng lỗi, kiểm tra lại data tách lot đã đầy đủ hay chưa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    

                    if (Error_Set_ON == 0) // Kiểm tra có lỗi tách lot hay không
                    {
                        if (checkBox_MesON.Checked) // Kiểm tra kết nối mes 
                        {
                            if (SCAN_NORMALY)   // Kết quả scan 40 pcm không có NG 
                            {
                                Error_Mes = 0;
                                counter_total_input = counter_total_input + 40;  // Bộ đếm counter total input
                                txtCounterTotal_Input.Text = counter_total_input.ToString();

                                // Send data to C-MES & Check Error Code
                                int i = 1;
                                if (AllowSendToMes) // Bật chế độ online PO running (lên mes)
                                {
                                    while (i <= 41) // 40 PCM bắt đầu từ 1
                                    {
                                        if (i < 41)
                                        {
                                            if (mes_send)
                                            {
                                                mes_send = false;
                                                socket.sent_input_HHP_PBA(1, ArrayCode[i]); // Send từng PCM lên mes tại đây (Bộ đếm counter hoạt động tong cls socket)
                                                Thread.Sleep(10);
                                                i++;
                                            }
                                        }
                                        else
                                        {
                                            if (mes_send)
                                                break;
                                        }
                                    }
                                }
                                else // Bật chế độ OBA, TEST FAKE (không lên mes)
                                {
                                    counter_total_OK = counter_total_OK + 40;  // Nếu không send mes thì + 40 vào total OK luôn (hàng test lại)
                                    txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                }



                                //Luu_Ket_Qua_Doc_Code(); // Lưu kết quả vào file log nội bộ phục vụ check double về sau phát triển thêm

                                if (Error_Mes == 0)  // Không có lỗi trả về từ mes thì tạo log và xuất tín hiệu OK
                                {
                                    CreateLog(tb_LinkAddCode.Text, ArrayCode, CodeJig, checkBox_typeCodeJig_DateTime, checkBox_CodeJig_Only); // Xuất file array code sang máy FCT
                                    PLC.Writeplc(tb_TotalOKDevice.Text, 1); // Xuất tín hiệu OK cho PLC
                                    Scanning_Step = 0; // Clear step đọc code
                                    WaitingScan = true;
                                }


                                // ______________________________________________________________________________________________________

                                else // Nếu có lỗi trả về từ mes
                                {
                                    PLC.Writeplc(tb_TotalNGDevice.Text, 1);
                                    //Tao_Log_Voi_Noi_Dung_La("Read barcode NG");
                                }
                            }
                            else // Kết quả đọc 40pcm mà có từ 1 vị trí NG không đọc được
                            {
                                PLC.Writeplc(tb_TotalNGDevice.Text, 1);
  

                            }

                        }


                        else // Không kết nối mes  / checkBox_MesON.Checked = false
                        {

                            DialogResult result = MessageBox.Show(" Bạn có muốn tạo file kết quả đọc code không? \r\n Hãy xóa file thủ công sau đó nhé ...", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                            if (result == DialogResult.OK) // chọn make file txt
                            {
                                CreateLog(tb_LinkAddCode.Text, ArrayCode, CodeJig, checkBox_typeCodeJig_DateTime, checkBox_CodeJig_Only); // Xuất file array code sang máy FCT
                            }

                            if (result == DialogResult.Cancel) // Nếu chọn không  make file txt
                            {

                                // Không làm gì cả
                            }

                            PLC.Writeplc(tb_TotalOKDevice.Text, 1); // Xuất tín hiệu OK cho PLC
                            Scanning_Step = 0; // Clear step đọc code
                            WaitingScan = true; // 
                        }

                    }
                    else // Có lỗi xuất hiện khi chạy function tách hàng theo lot
                    {
                        PLC.Writeplc(tb_TotalNGDevice.Text, 1);
                    }


                }
            }
            // NG  ______________________________________________________________________________________________________________________________
            else //Khi kết quả đọc code bị NG (không đọc được code) ERROR
            {
                SCAN_NORMALY = false;

                if (cbxLuaChonAddThemMaProduct.Text == "NO") // Nếu chọn không add thêm mã product thì nhận trực tiếp từ scanner
                {
                    ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = scan1;
                    ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = scan2;
                }
                else // Nếu có chọn add thêm mã product thì sẽ xét tiếp add manual hay auto
                {
                    if (checkBox_AutoAddProduct.Checked == true) // Add thêm mã auto nhận từ cmes auto
                    {
                        ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = txtOracel_PO_InUse.Text + scan1;
                        ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = txtOracel_PO_InUse.Text + scan2;
                    }
                    else // Add thêm mã manual từ text box manual
                    {
                        ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = txtManualAddProduct.Text + scan1;
                        ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = txtManualAddProduct.Text + scan2;
                    }
                }

                //ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = scan1;
                //ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = scan2;
                status_PCM[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = 1;  // Khi nhận data từng kênh thì monitor hiển thị default color
                status_PCM[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = 1;  // Khi nhận data từng kênh thì monitor hiển thị default color

                if (scan1 == "ERROR")
                {
                    ArrayCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = scan1;
                    status_PCM[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = 3;  // lỗi code
                    errorCode[PCM_Pos_ReadCode_Scan1[Scanning_Step]] = "Read Code Error";
                    //PLC.Writeplc(tb_ReadNGDevice.Text, 1);
                    //Tao_Log_Voi_Noi_Dung_La("Scanner #1 Error");
                }

                if (scan2 == "ERROR")
                {
                    ArrayCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = scan2;
                    status_PCM[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = 3; // lỗi code
                    errorCode[PCM_Pos_ReadCode_Scan2[Scanning_Step]] = "Read Code Error";
                    //PLC.Writeplc(tb_ReadNGDevice.Text, 1);
                    //Tao_Log_Voi_Noi_Dung_La("Scanner #2 Error");
                }



                if (Scanning_Step < final_Pos_run)  // Nếu điểm chạy robot nhỏ hơn điểm cuối cùng list tọa độ
                {
                    Scanning_Step++;  // Tăng step chạy
                    WaitingScan = true; // Cho phép quét tiếp

                    Thread.Sleep(time_delay_when_have_NG); // Delay tăng lên để PLC đọc dc hết 40 pcm
                    PLC.Writeplc(tb_ReadNGDevice.Text, 1);   // Send kết quả OK lên PLC
                }










                else // Đã đọc xong hết 40 PCM thì stop machine
                {
                    Error_Set_ON = 0; // Reset biến error code


                    try
                    {
                        #region Tách lot hàng NG

                        int j = 1;
                        if ((checkBox_TachLotTheoNgayThangON.Text == "ON") || (checkBox_TachLotTheoFileDataON.Text == "ON"))
                        {
                            while (j <= 41) // 40 PCM bắt đầu từ 1
                            {
                                if (j < 41)
                                {
                                    if (ArrayCode[j] != "ERROR") // Kiểm tra code OK hay không đọc được
                                    {

                                        if (checkBox_TachLotTheoFileDataON.Text == "ON")
                                        {
                                            if (checkData.CheckDuplicateInforamation(ArrayCode[j], Listbarcode)) // Kiểm tra double code tại list đã load ra
                                            {
                                                // Không có double code
                                                // Kiểm tra tiếp điều kiện ngày tháng nếu được chọn
                                                if (checkBox_TachLotTheoNgayThangON.Text == "ON") // Nếu chọn thì check
                                                {
                                                    string YEAR = ArrayCode[j].Substring(int.Parse(txtViTriKiTuNAM.Text), 1);

                                                    if ((YEAR == (txtYEAR_NG1.Text))
                                                        || (YEAR == (txtYEAR_NG2.Text))
                                                        || (YEAR == (txtYEAR_NG3.Text))
                                                        || (YEAR == (txtYEAR_NG4.Text))
                                                        || (YEAR == (txtYEAR_NG5.Text))
                                                        || (YEAR == (txtYEAR_NG6.Text))
                                                        )
                                                    {
                                                        status_PCM[j] = 3;  // lỗi code
                                                        errorCode[j] = "Lot_hàng_NG_Year";
                                                        //counter_total_NG++; // đếm counter NG + 1 PCM
                                                        //counter_total_OK--;
                                                        Error_Set_ON++;
                                                        //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                        //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter 

                                                    }

                                                    else
                                                    {
                                                        if (YEAR == (txtYEAR_OK.Text))
                                                        {
                                                            string MONTH = ArrayCode[j].Substring(int.Parse(txtViTriKiTuTHANG.Text), 1);
                                                            if ((MONTH == (txtMONTH_NG1.Text))
                                                                 || (MONTH == (txtMONTH_NG2.Text))
                                                                 || (MONTH == (txtMONTH_NG3.Text))
                                                                 || (MONTH == (txtMONTH_NG4.Text))
                                                                 || (MONTH == (txtMONTH_NG5.Text))
                                                                 || (MONTH == (txtMONTH_NG6.Text))
                                                                 || (MONTH == (txtMONTH_NG7.Text))
                                                                 || (MONTH == (txtMONTH_NG8.Text))
                                                                 || (MONTH == (txtMONTH_NG9.Text))
                                                                 || (MONTH == (txtMONTH_NG10.Text))
                                                                 || (MONTH == (txtMONTH_NG11.Text))
                                                                 || (MONTH == (txtMONTH_NG12.Text))
                                                                 )
                                                            {
                                                                status_PCM[j] = 3;  // lỗi code
                                                                errorCode[j] = "Lot_hàng_NG_Month";
                                                                //counter_total_NG++; // đếm counter NG + 1 PCM
                                                                //counter_total_OK--;
                                                                Error_Set_ON++;
                                                                //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                                //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter   
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else // Double code
                                            {
                                                status_PCM[j] = 3;  // lỗi code
                                                errorCode[j] = "DOUBLE BARCODE";
                                                Error_Set_ON++;
                                            }
                                        }

                                        else // Trường hợp không kiểm tra theo data thì kiểm tra theo ngày tháng
                                        {
                                            if (checkBox_TachLotTheoNgayThangON.Text == "ON") // Nếu chọn thì check theo ngày tháng
                                            {
                                                string YEAR = ArrayCode[j].Substring(int.Parse(txtViTriKiTuNAM.Text), 1);

                                                if ((YEAR == (txtYEAR_NG1.Text))
                                                    || (YEAR == (txtYEAR_NG2.Text))
                                                    || (YEAR == (txtYEAR_NG3.Text))
                                                    || (YEAR == (txtYEAR_NG4.Text))
                                                    || (YEAR == (txtYEAR_NG5.Text))
                                                    || (YEAR == (txtYEAR_NG6.Text))
                                                    )
                                                {
                                                    status_PCM[j] = 3;  // lỗi code
                                                    errorCode[j] = "Lot_hàng_NG_Year";
                                                    //counter_total_NG++; // đếm counter NG + 1 PCM
                                                    //counter_total_OK--;
                                                    Error_Set_ON++;
                                                    //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                    //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter 

                                                }

                                                else
                                                {
                                                    if (YEAR == (txtYEAR_OK.Text))
                                                    {
                                                        string MONTH = ArrayCode[j].Substring(int.Parse(txtViTriKiTuTHANG.Text), 1);
                                                        if ((MONTH == (txtMONTH_NG1.Text))
                                                             || (MONTH == (txtMONTH_NG2.Text))
                                                             || (MONTH == (txtMONTH_NG3.Text))
                                                             || (MONTH == (txtMONTH_NG4.Text))
                                                             || (MONTH == (txtMONTH_NG5.Text))
                                                             || (MONTH == (txtMONTH_NG6.Text))
                                                             || (MONTH == (txtMONTH_NG7.Text))
                                                             || (MONTH == (txtMONTH_NG8.Text))
                                                             || (MONTH == (txtMONTH_NG9.Text))
                                                             || (MONTH == (txtMONTH_NG10.Text))
                                                             || (MONTH == (txtMONTH_NG11.Text))
                                                             || (MONTH == (txtMONTH_NG12.Text))
                                                             )
                                                        {
                                                            status_PCM[j] = 3;  // lỗi code
                                                            errorCode[j] = "Lot_hàng_NG_Month";
                                                            //counter_total_NG++; // đếm counter NG + 1 PCM
                                                            //counter_total_OK--;
                                                            Error_Set_ON++;
                                                            //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                            //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter   
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    Thread.Sleep(5);
                                    j++;
                                }
                                else
                                {
                                    j++;
                                    break;
                                }
                            }
                        }
                        else // Không kiểm tra tách lot
                        {
                            Error_Set_ON = 0;
                        }
                        #endregion
                    }
                    catch
                    {
                        Error_Set_ON++;
                        STOP();


                        MessageBox.Show("Tách lot hàng lỗi, kiểm tra lại data tách lot đã đầy đủ hay chưa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    




                    PLC.Writeplc(tb_TotalNGDevice.Text, 1); // Xuất tín hiệu đọc jig NG

 
                }
            }
        }
        #endregion


        #region Format File BarCode PCM
        public void CreateLog(string FilePath, string[] ArrayBarcode, string codeJig, CheckBox typeCode_datetime, CheckBox typeCodeJig_Only)
        {
            try
            {
                if (typeCode_datetime.Checked)
                {
                    DateTime dt = DateTime.Now;
                    string file = codeJig + "-" + dt.Year.ToString() + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00") + dt.Millisecond.ToString("000") + ".txt";

                    FileStream FS = new FileStream(@FilePath + @"\" + file, FileMode.Create);
                    StreamWriter SW = new StreamWriter(FS);

                    for (int i = 1; i < ArrayBarcode.Length; i++)
                    {
                        SW.WriteLine(ArrayBarcode[i]);
                    }

                    SW.Close();
                    FS.Close();
                }

                if (typeCodeJig_Only.Checked)
                {
                    //DateTime dt = DateTime.Now;
                    string file = codeJig.ToUpper() + ".txt"; // +"-" + dt.Year.ToString() + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00") + dt.Millisecond.ToString("000") + ".txt";

                    FileStream FS = new FileStream(@FilePath + @"\" + file, FileMode.Create);
                    StreamWriter SW = new StreamWriter(FS);

                    for (int i = 1; i < ArrayBarcode.Length; i++)
                    {
                        SW.WriteLine(ArrayBarcode[i]);
                    }

                    SW.Close();
                    FS.Close();
                }
            }
            catch
            {
                STOP();
                MessageBox.Show("Link folder add barcode không tồn tại, Kiểm tra lại link trong phần teaching, hoặc kết nối mạng máy Function NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



        }














        public string Get_Model_Name()
        {
            try
            {
                if (string.IsNullOrEmpty(lblLinkModel.Text)) { }
                else
                {

                    string[] Name = lblLinkModel.Text.Split('\\');
                    return Name[Name.Length - 1];
                }
            }
            catch { }
            return "unknow";
        }











        //public void Luu_Ket_Qua_Doc_Code() // hàm này chưa chạy đúng (không lưu được file)
        //{
        //    if (checkBox_SaveLogFileBarcodePCM.Checked)
        //    {
        //        string link_file = LINK_FILE_LOG_RESULT_READ_BARCODE();
        //        DATA.Check_Folder("Result_Barcode");  // Kiểm tra folder lưu kết quả
        //        TEXT.Save_Result_Read_Code_To_Log_File(ArrayCode, link_file); // Lưu kết quả nội bộ
        //    }

        //}







        #endregion

        public void ClearStatus() // Xóa array code hiện tại
        {
            Array.Clear(ArrayCode, 0, 41);
            Array.Clear(errorCode, 0, 41); // Reset Error từ mes

            for (int i = 0; i < 41; i++) // Hiển thị status  code jig trên màn hình main
            {
                status_PCM[i] = 1; // Hiển thị [1] Default status
            }
        }










        public bool alarm_PO_OFF = false;
        public bool KhoaCheoWarningCodeJigNG2 = true;
        private void timer_Barcode_Tick(object sender, EventArgs e)
        {
            Auto_Stop_Mode = PLC.readplc(tb_StopModeDevice.Text); // Đọc từ PLC tín hiệu stop auto            
            ResetButtomIsOn = PLC.readplc(PLC_OUTPUT_LAMP_RESET); // Có tín hiệu ấn nút reset click



            #region Kiểm tra làm mới monitor

            // Kiểm tra các điều kiện để reset monitor
            if (((Auto_Stop_Mode == "1") || (ResetButtomIsOn == "1")) && ScanningIsOn == true) // Làm mới các biến gài khóa chéo
            {
                LamMoiManHinhHienThiBarcode();
            }
            #endregion

            #region Kiểm tra máy chạy auto run
            if (isStop == false)  // Kiểm tra máy chạy auto OK
            {
                if (WaitingScan)     // Đang waiting chờ đọc code 
                {
                    Current_Position_Robot = PLC.readplc(tb_CurrentPositionDevice.Text);  // tọa độ hiện tại PLC
                    ScanReadyToRun = PLC.readplc(tb_ScanningDevive.Text);  // PLC sẵn sàng đọc code
                }


                if (ScanReadyToRun == "1" && WaitingScan)               // Bắt đầu đọc code khi PLC auto và đang ở chế độ chờ đọc
                {
                    ScanningIsOn = true; // khóa chéo quá trình đọc code (Cho phép clear)
            #endregion

                    #region Đọc code jig
                    // -------------------------------------------------------------------------------------------------------------

                    // Scanning_Step = 0 : bước đầu tiên đọc code jig

                    if (Scanning_Step == 0 && Current_Position_Robot == "1000") // Robot ở vị trí đọc code jig và step 0
                    {

                        // Kiểm tra PO đã được tạo hay chưa?
                        if (cbxLuaChonAddThemMaProduct.Text == "YES")
                        {

                            if (checkBox_AutoAddProduct.Text == "AUTO")
                            {
                                // Kiểm tra PO đã được tạo hay chưa?
                                if ((string.IsNullOrEmpty(txtOracel_PO_InUse.Text)) && (alarm_PO_OFF == false))
                                {

                                    alarm_PO_OFF = true; // Chỉ tạo alarm 1 lần
                                    STOP();
                                    //PLC.Writeplc(PLC_MenuBar_Stop, 1);
                                    //Thread.Sleep(200);
                                    //PLC.Writeplc(PLC_MenuBar_Stop, 0);
                                    MessageBox.Show("Chưa tạo PO running", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }



                        WaitingScan = false; // khóa chéo quá trình đọc code 
                        ClearStatus(); // Xóa array và làm mới monitor hiển thị

                        if (KhoaCheoWarningCodeJigNG2)
                        {
                            Thread_ReadCodeJig = new Thread(new ThreadStart(readCodeJig)); // Gọi hàm đọc code jig
                            Thread_ReadCodeJig.IsBackground = true;
                            Thread_ReadCodeJig.Start();
                        }


                        SCAN_NORMALY = true;  // Set biến đọc bình thường , biến này set false khi có từ 1 ea đọc NG và ko tạo file txt

                    }
                    #endregion

                    #region Đọc code PCM
                    // -------------------------------------------------------------------------------------------------------------
                    // Scanning_Step = 1 : Đọc code PCM đầu tiên sau đó tự cộng 1 đơn vị


                    else // Đọc code aray PCM từ bước này
                    {
                        if (Scanning_Step == int.Parse(Current_Position_Robot)) // Nếu step bằng tọa độ robot hiện tại
                        {
                            WaitingScan = false; // khóa chéo quá trình đọc code
                            Thread_XuLyData = new Thread(new ThreadStart(xuLyDataScanner)); // Xử lý data đọc code của 2 scanner
                            Thread_XuLyData.IsBackground = true;
                            Thread_XuLyData.Start();
                        }
                    }
                    #endregion



                }
            }

            else
            {
                Scanning_Step = 0;
            }
        }




        public void LamMoiManHinhHienThiBarcode()
        {
            ScanningIsOn = false;
            Scanning_Step = 0;
            CodeJig = "";
            Error_Mes = 0;
            WaitingScan = true;
        }





        private void btnConnectMes_Click(object sender, EventArgs e)
        {
            Connect_MES();
        }

        private void btnConnectScanner01_Click(object sender, EventArgs e)
        {
            if (Scaner1.connect(tb_IPscanner1.Text, port, lbl_Scanner1_status) == true)
                Tao_Log_Voi_Noi_Dung_La("SCANNER#1 CONNECT OK");
            else
                Tao_Log_Voi_Noi_Dung_La("SCANNER#1 CONNECT NG");
        }

        private void btnConnectScanner02_Click(object sender, EventArgs e)
        {
            if (Scaner2.connect(tb_IPscanner2.Text, port, lbl_Scanner2_status) == true)
                Tao_Log_Voi_Noi_Dung_La("SCANNER#2 CONNECT OK");
            else
                Tao_Log_Voi_Noi_Dung_La("SCANNER#2 CONNECT NG");
        }

        private void checkBox_MesON_Click(object sender, EventArgs e)
        {
            if (MES_change_status)
            {

                if (checkBox_MesON.Checked == true)
                {
                    if (Nhac_Nho_Tu_Chuong_Trinh())
                    {
                        Tao_Log_Voi_Noi_Dung_La("MES ON REQUEST");
                        checkBox_MesON.Text = "MES ON ";
                        checkBox_MesON.ForeColor = Color.Blue;
                        //FORM_CLOSE();
                    }
                    else
                    {
                        checkBox_MesON.Checked = false;
                        checkBox_MesON.Text = "MES OFF";
                        checkBox_MesON.ForeColor = Color.Red;
                    }



                }
                else
                {

                    if (Nhac_Nho_Tu_Chuong_Trinh())
                    {
                        Tao_Log_Voi_Noi_Dung_La("MES OFF REQUEST");
                        checkBox_MesON.Text = "MES OFF";
                        checkBox_MesON.ForeColor = Color.Red;
                        //FORM_CLOSE();
                    }
                    else
                    {
                        checkBox_MesON.Checked = true;
                        checkBox_MesON.Text = "MES ON";
                        checkBox_MesON.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void btnClearListBox_Click(object sender, EventArgs e)
        {
            listBox_PCtoMES.Items.Clear();
            listBox_MEStoPC.Items.Clear();
        }






        private void timerShowMonitor_Tick(object sender, EventArgs e)
        {
            try
            {
                time_delay_normal = int.Parse(txtDelayTimeNormally.Text);
                time_delay_when_have_NG = int.Parse(txtDelayTimeWhenHaveNG.Text);
            }
            catch { }
            for (int i = 1; i < 41; i++)
            {
                display(i, status_PCM[i]);
            }



            if (fJogRobot.SCANNER_VIEW)
            {
                KhoaCheoQuetScannerView = true;
                if (lbl_Scanner1_status.BackColor == Color.Green)
                {
                    Scaner1.read_data_for_Live_View();
                    //string SCANNER1 = Scaner1.read_data(); // Đọc manual code scanner 1
                    //m_reader1.ExecCommand("LON");
                }
                if (lbl_Scanner2_status.BackColor == Color.Green)
                {
                    Scaner2.read_data_for_Live_View();
                    //string SCANNER2 = Scaner2.read_data(); // Đọc manual code scanner 2
                    //m_reader2.ExecCommand("LON");
                }
            }
            else
            {
                if (KhoaCheoQuetScannerView)
                {
                    if (lbl_Scanner1_status.BackColor == Color.Green)
                    {
                        // Tắt đọc code 1 // Ngắt kết nối scanner
                        Scaner1.Off_read_data_for_Live_View();
                        string a = Scaner1.read_data_1();
                        //Scaner1.disconnect_Scanner(tb_IPscanner1.Text, port, lbl_Scanner1_status);
                    }

                    if (lbl_Scanner2_status.BackColor == Color.Green)
                    {
                        // Tắt đọc code 2 // Ngắt kết nối scanner
                        Scaner2.Off_read_data_for_Live_View();
                        string b = Scaner2.read_data_1();
                        //Scaner2.disconnect_Scanner(tb_IPscanner2.Text, port, lbl_Scanner2_status);
                    }



                    Thread.Sleep(500);

                    // Kêt nối lại scanner
                    // Connect_Scanner();


                    KhoaCheoQuetScannerView = false;  // Khóa chéo để ko đọc lại hàm này nữa


                }
            }





        }

        private void pictureBoxMesViewDataTransfer_Click(object sender, EventArgs e)
        {
            tabPage_Auto.Hide();
            tabPage_manual.Hide();
            tabPage_Setting.Hide();
            tabPage_Teaching.Hide();

            tabPage_IO.Hide();
            tabPage_LOG_MES.Show();
            tab_monitor_on = true;
        }


        private void txtDelayTimeNormally_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtDelayTimeNormally.Text);
                if (a < 0)
                {
                    MessageBox.Show("Nhập sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDelayTimeNormally.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Nhập sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDelayTimeNormally.Focus();
            }
        }

        private void txtDelayTimeWhenHaveNG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtDelayTimeWhenHaveNG.Text);
                if (a < 0)
                {
                    MessageBox.Show("Nhập sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDelayTimeWhenHaveNG.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Nhập sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDelayTimeWhenHaveNG.Focus();
            }
        }

        private void checkBox_typeCodeJig_DateTime_Click(object sender, EventArgs e)
        {
            if (checkBox_typeCodeJig_DateTime.Checked)
            {
                checkBox_CodeJig_Only.Checked = false;
            }
        }

        private void checkBox_CodeJig_Only_Click(object sender, EventArgs e)
        {
            if (checkBox_CodeJig_Only.Checked)
            {
                checkBox_typeCodeJig_DateTime.Checked = false;
            }
        }

        private void pictureBox_delete_file_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tb_LinkAddCode.Text)) { }
                else
                {
                    string[] AllFileName;
                    AllFileName = Directory.GetFiles(tb_LinkAddCode.Text);
                    if (AllFileName.Length == 0)
                    {
                        MessageBox.Show("Không có gì để xóa nhé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        for (int i = 0; i < AllFileName.Length; i++)
                        {
                            System.IO.File.Delete(AllFileName[i]);
                        }

                        MessageBox.Show("Xóa file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xóa file không thành công, hãy kiểm tra và xóa manual nhé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_SapXepKieuTinhTien_Click(object sender, EventArgs e)
        {
            if (checkBox_SapXepKieuTinhTien.Checked)
            {
                KieuSapXepArrayPCMTheoScanner = 1;
                checkBox_SapXepKieuZicZac.Checked = false;
                checkBox_KhongCanSapXep.Checked = false;
            }
            else
            {
                if (KieuSapXepArrayPCMTheoScanner == 0)
                {
                    checkBox_KhongCanSapXep.Checked = true;
                    checkBox_SapXepKieuTinhTien.Checked = false;
                    checkBox_SapXepKieuZicZac.Checked = false;
                }
                if (KieuSapXepArrayPCMTheoScanner == 1)
                {
                    checkBox_KhongCanSapXep.Checked = false;
                    checkBox_SapXepKieuTinhTien.Checked = true;
                    checkBox_SapXepKieuZicZac.Checked = false;
                }
                if (KieuSapXepArrayPCMTheoScanner == 2)
                {
                    checkBox_KhongCanSapXep.Checked = false;
                    checkBox_SapXepKieuTinhTien.Checked = false;
                    checkBox_SapXepKieuZicZac.Checked = true;
                }

            }
        }

        private void checkBox_SapXepKieuZicZac_Click(object sender, EventArgs e)
        {
            if (checkBox_SapXepKieuZicZac.Checked)
            {
                KieuSapXepArrayPCMTheoScanner = 2;
                checkBox_SapXepKieuTinhTien.Checked = false;
                checkBox_KhongCanSapXep.Checked = false;
            }
            else
            {
                if (KieuSapXepArrayPCMTheoScanner == 0)
                {
                    checkBox_KhongCanSapXep.Checked = true;
                    checkBox_SapXepKieuTinhTien.Checked = false;
                    checkBox_SapXepKieuZicZac.Checked = false;
                }
                if (KieuSapXepArrayPCMTheoScanner == 1)
                {
                    checkBox_KhongCanSapXep.Checked = false;
                    checkBox_SapXepKieuTinhTien.Checked = true;
                    checkBox_SapXepKieuZicZac.Checked = false;
                }
                if (KieuSapXepArrayPCMTheoScanner == 2)
                {
                    checkBox_KhongCanSapXep.Checked = false;
                    checkBox_SapXepKieuTinhTien.Checked = false;
                    checkBox_SapXepKieuZicZac.Checked = true;
                }
            }
        }

        private void checkBox_KhongCanSapXep_Click(object sender, EventArgs e)
        {
            if (checkBox_KhongCanSapXep.Checked)
            {
                KieuSapXepArrayPCMTheoScanner = 0;
                checkBox_SapXepKieuTinhTien.Checked = false;
                checkBox_SapXepKieuZicZac.Checked = false;
            }
            else
            {
                if (KieuSapXepArrayPCMTheoScanner == 0)
                {
                    checkBox_KhongCanSapXep.Checked = true;
                    checkBox_SapXepKieuTinhTien.Checked = false;
                    checkBox_SapXepKieuZicZac.Checked = false;
                }
                if (KieuSapXepArrayPCMTheoScanner == 1)
                {
                    checkBox_KhongCanSapXep.Checked = false;
                    checkBox_SapXepKieuTinhTien.Checked = true;
                    checkBox_SapXepKieuZicZac.Checked = false;
                }
                if (KieuSapXepArrayPCMTheoScanner == 2)
                {
                    checkBox_KhongCanSapXep.Checked = false;
                    checkBox_SapXepKieuTinhTien.Checked = false;
                    checkBox_SapXepKieuZicZac.Checked = true;
                }
            }
        }

        private void btnClearListBox_Click_1(object sender, EventArgs e)
        {
            listBox_PCtoMES.Items.Clear();
            listBox_MEStoPC.Items.Clear();
        }

        private void checkBox_Double_Check_Click(object sender, EventArgs e)
        {
            if (checkBox_Double_Check.Checked == true)
            {
                Double_Check_Code = true;
                checkBox_Double_Check.ForeColor = Color.Blue;
            }
            else
            {
                Double_Check_Code = false;
                checkBox_Double_Check.ForeColor = Color.Tomato;
            }
        }

        private void btnOracelMesSaveChange_Click(object sender, EventArgs e)
        {
            if (checkBox_AutoAddProduct.Checked == false)
            {
                if (string.IsNullOrEmpty(txtManualAddProduct.Text))
                {
                    MessageBox.Show("Bạn chưa tạo mã add thêm rồi", "Cảnh báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtManualAddProduct.Focus();
                }
                else
                {
                    DATA.Check_Folder("DATA");
                    TEXT.SaveOracleSetting
                        (
                        txtOracleMesDBSource,
                        txtOracleMesUser,
                        txtOracleMesPass,
                        cbxOracleMesLineNo,
                        cbxLuaChonAddThemMaProduct,
                        txtManualAddProduct,
                        checkBox_AutoAddProduct

                        );
                    Tao_Log_Voi_Noi_Dung_La("Oracel setting thay đổi");
                }

            }
            else
            {
                DATA.Check_Folder("DATA");
                TEXT.SaveOracleSetting
                    (
                    txtOracleMesDBSource,
                    txtOracleMesUser,
                    txtOracleMesPass,
                    cbxOracleMesLineNo,
                    cbxLuaChonAddThemMaProduct,
                    txtManualAddProduct,
                    checkBox_AutoAddProduct

                    );
                Tao_Log_Voi_Noi_Dung_La("Oracel setting thay đổi");
            }



        }

        private void btnOracelMesTaiData_Click(object sender, EventArgs e)
        {
            TaiDataOracle(txtOracel_PO_InUse, dgvOracleData);

        }


        private void cbxOracelMesLineNo_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtOracel_PO_InUse_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOracel_PO_InUse.Text))
            {
                txtOracel_PO_InUse.BackColor = Color.Red;
            }
            else
            {
                txtOracel_PO_InUse.BackColor = Color.Green;
            }
        }

        private void lblViewOracel_Click_1(object sender, EventArgs e)
        {
            tabPage_manual.Hide();
            tabPage_Setting.Hide();
            tabPage_IO.Hide();
            tabPage_Teaching.Hide();
            tabPage_LOG_MES.Hide();
            tabPage_Auto.Hide();
            tabPage_TachLot.Hide();
            tabPage_OracleSeting.Show();
            tab_monitor_on = false;
        }

        private void cbxLuaChonAddThemMaProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLuaChonAddThemMaProduct.Text == "YES")
            {
                cbxLuaChonAddThemMaProduct.BackColor = Color.Green;
            }
            if (cbxLuaChonAddThemMaProduct.Text == "NO")
            {
                cbxLuaChonAddThemMaProduct.BackColor = Color.Red;
            }
        }

        private void checkBox_AutoAddProduct_Click(object sender, EventArgs e)
        {
            if (checkBox_AutoAddProduct.Checked == true)
            {
                checkBox_AutoAddProduct.Text = "AUTO";
                checkBox_AutoAddProduct.ForeColor = Color.Blue;
            }
            else
            {
                if (string.IsNullOrEmpty(txtManualAddProduct.Text))
                {
                    MessageBox.Show("Bạn chưa tạo mã add thêm rồi", "Cảnh báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtManualAddProduct.Focus();

                    checkBox_AutoAddProduct.Checked = true;
                    checkBox_AutoAddProduct.Text = "AUTO";
                    checkBox_AutoAddProduct.ForeColor = Color.Blue;


                }
                else
                {


                    checkBox_AutoAddProduct.Text = "MANUAL";
                    checkBox_AutoAddProduct.ForeColor = Color.Yellow;
                }




            }
        }













        #region Tách hàng





        public void Load_data_for_ListBarcode()
        {
            try
            {
                Listbarcode.Clear();
                //checkData.LoadList(cbx_Model.Text, ref Listbarcode);
                checkData.LoadList(ref Listbarcode, txtLinkFIleDataSoSanhDeTachLot.Text);
                //checkData.CheckDuplicateInforamation("barcode", Listbarcode);

                if (Listbarcode.Count == 0) // List trống
                {
                    MessageBox.Show("Load list barcode thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }



            }
            catch
            {
                MessageBox.Show("Load list barcode thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }



        public void Test_Tach_Lot_Tu_File_Tu_Tao()
        {
            #region Tách lot hàng NG
            int j = 0;



            try
            {

                if ((checkBox_TachLotTheoNgayThangON.Text == "ON") || (checkBox_TachLotTheoFileDataON.Text == "ON"))
                {
                    while (j <= 40) // 40 PCM bắt đầu từ 1
                    {
                        if (j < 40)
                        {
                            if (ListTest[j] != "ERROR") // Kiểm tra code OK hay không đọc được
                            {

                                if (checkBox_TachLotTheoFileDataON.Text == "ON")
                                {
                                    if (checkData.CheckDuplicateInforamation(ListTest[j], Listbarcode)) // Kiểm tra double code tại list đã load ra
                                    {
                                        // Không có double code
                                        // Kiểm tra tiếp điều kiện ngày tháng nếu được chọn
                                        if (checkBox_TachLotTheoNgayThangON.Text == "ON") // Nếu chọn thì check
                                        {
                                            string YEAR = ListTest[j].Substring(int.Parse(txtViTriKiTuNAM.Text), 1);

                                            if ((YEAR == (txtYEAR_NG1.Text))
                                                || (YEAR == (txtYEAR_NG2.Text))
                                                || (YEAR == (txtYEAR_NG3.Text))
                                                || (YEAR == (txtYEAR_NG4.Text))
                                                || (YEAR == (txtYEAR_NG5.Text))
                                                || (YEAR == (txtYEAR_NG6.Text))
                                                )
                                            {
                                                status_PCM[j] = 3;  // lỗi code
                                                errorCode[j] = "Lot_hàng_NG_Year";
                                                //counter_total_NG++; // đếm counter NG + 1 PCM
                                                //counter_total_OK--;
                                                Error_Set_ON++;
                                                //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter 

                                            }

                                            else
                                            {
                                                if (YEAR == (txtYEAR_OK.Text))
                                                {
                                                    string MONTH = ListTest[j].Substring(int.Parse(txtViTriKiTuTHANG.Text), 1);
                                                    if ((MONTH == (txtMONTH_NG1.Text))
                                                         || (MONTH == (txtMONTH_NG2.Text))
                                                         || (MONTH == (txtMONTH_NG3.Text))
                                                         || (MONTH == (txtMONTH_NG4.Text))
                                                         || (MONTH == (txtMONTH_NG5.Text))
                                                         || (MONTH == (txtMONTH_NG6.Text))
                                                         || (MONTH == (txtMONTH_NG7.Text))
                                                         || (MONTH == (txtMONTH_NG8.Text))
                                                         || (MONTH == (txtMONTH_NG9.Text))
                                                         || (MONTH == (txtMONTH_NG10.Text))
                                                         || (MONTH == (txtMONTH_NG11.Text))
                                                         || (MONTH == (txtMONTH_NG12.Text))
                                                         )
                                                    {
                                                        status_PCM[j] = 3;  // lỗi code
                                                        errorCode[j] = "Lot_hàng_NG_Month";
                                                        //counter_total_NG++; // đếm counter NG + 1 PCM
                                                        //counter_total_OK--;
                                                        Error_Set_ON++;
                                                        //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                        //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter   
                                                    }
                                                }


                                            }
                                        }

                                    }
                                    else // Double code
                                    {
                                        status_PCM[j] = 3;  // lỗi code
                                        errorCode[j] = "DOUBLE BARCODE";
                                        Error_Set_ON++;
                                    }
                                }



                                else // Trường hợp không kiểm tra theo data thì kiểm tra theo ngày tháng
                                {
                                    if (checkBox_TachLotTheoNgayThangON.Text == "ON") // Nếu chọn thì check theo ngày tháng
                                    {
                                        string YEAR = ListTest[j].Substring(int.Parse(txtViTriKiTuNAM.Text), 1);

                                        if ((YEAR == (txtYEAR_NG1.Text))
                                            || (YEAR == (txtYEAR_NG2.Text))
                                            || (YEAR == (txtYEAR_NG3.Text))
                                            || (YEAR == (txtYEAR_NG4.Text))
                                            || (YEAR == (txtYEAR_NG5.Text))
                                            || (YEAR == (txtYEAR_NG6.Text))
                                            )
                                        {
                                            status_PCM[j] = 3;  // lỗi code
                                            errorCode[j] = "Lot_hàng_NG_Year";
                                            //counter_total_NG++; // đếm counter NG + 1 PCM
                                            //counter_total_OK--;
                                            Error_Set_ON++;
                                            //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                            //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter 

                                        }

                                        else
                                        {
                                            if (YEAR == (txtYEAR_OK.Text))
                                            {
                                                string MONTH = ListTest[j].Substring(int.Parse(txtViTriKiTuTHANG.Text), 1);
                                                if ((MONTH == (txtMONTH_NG1.Text))
                                                     || (MONTH == (txtMONTH_NG2.Text))
                                                     || (MONTH == (txtMONTH_NG3.Text))
                                                     || (MONTH == (txtMONTH_NG4.Text))
                                                     || (MONTH == (txtMONTH_NG5.Text))
                                                     || (MONTH == (txtMONTH_NG6.Text))
                                                     || (MONTH == (txtMONTH_NG7.Text))
                                                     || (MONTH == (txtMONTH_NG8.Text))
                                                     || (MONTH == (txtMONTH_NG9.Text))
                                                     || (MONTH == (txtMONTH_NG10.Text))
                                                     || (MONTH == (txtMONTH_NG11.Text))
                                                     || (MONTH == (txtMONTH_NG12.Text))
                                                     )
                                                {
                                                    status_PCM[j] = 3;  // lỗi code
                                                    errorCode[j] = "Lot_hàng_NG_Month";
                                                    //counter_total_NG++; // đếm counter NG + 1 PCM
                                                    //counter_total_OK--;
                                                    Error_Set_ON++;
                                                    //txtCounterTotal_Input_OK.Text = counter_total_OK.ToString();
                                                    //txtCounterTotal_Input_NG.Text = counter_total_NG.ToString(); // Hiển thị counter   
                                                }
                                            }


                                        }
                                    }
                                }






                            }

                            Thread.Sleep(10);
                            j++;
                        }
                        else
                        {
                            j++;
                            //if (mes_send)
                            break;
                        }
                    }
                }
            #endregion
            }
            catch
            {
                MessageBox.Show("So sánh thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }




        public bool KiemTraDataDuongLinkSoSanh()
        {
            if (string.IsNullOrEmpty(txtLinkFIleDataSoSanhDeTachLot.Text))
            {
                MessageBox.Show("Bạn chưa chọn file data, hãy chọn đúng đường link nhé", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtLinkFIleDataSoSanhDeTachLot.Focus();
                return false;
            }
            return true;

        }





        public bool KiemTraDataTachLot() // kiểm tra thông tin tách lot trước khi save model
        {
            if (checkBox_TachLotTheoNgayThangON.Checked) // Có sài tách lot  theo ngày tháng hay không
            { // có sài thì kiểm tra
                if (string.IsNullOrEmpty(txtViTriKiTuNAM.Text))
                {
                    MessageBox.Show("Data số thứ tự input sai, hãy chọn đúng số vị trí kí tự năm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtViTriKiTuNAM.Focus();
                    return false;
                }
                else
                {
                    try
                    {
                        int a = int.Parse(txtViTriKiTuNAM.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Data số thứ tự input sai, hãy chọn đúng số vị trí kí tự năm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtViTriKiTuNAM.Focus();
                        return false;
                    }
                }


                if (string.IsNullOrEmpty(txtViTriKiTuTHANG.Text))
                {
                    MessageBox.Show("Data số thứ tự input sai, hãy chọn đúng số vị trí kí tự tháng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtViTriKiTuTHANG.Focus();
                    return false;
                }
                else
                {
                    try
                    {
                        int a = int.Parse(txtViTriKiTuTHANG.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Data số thứ tự input sai, hãy chọn đúng số vị trí kí tự tháng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtViTriKiTuTHANG.Focus();
                        return false;
                    }
                }


                if (string.IsNullOrEmpty(txtYEAR_NG1.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự năm mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtYEAR_NG1.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtYEAR_NG2.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự năm mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtYEAR_NG2.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtYEAR_NG3.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự năm mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtYEAR_NG3.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtYEAR_NG4.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự năm mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtYEAR_NG4.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtYEAR_NG5.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự năm mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtYEAR_NG5.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtYEAR_NG6.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự năm mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtYEAR_NG6.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(txtMONTH_NG1.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG1.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG2.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG2.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG3.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG3.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG4.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG4.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG5.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG5.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG6.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG6.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG7.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG7.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG8.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG8.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG9.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG9.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG10.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG10.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG11.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG11.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMONTH_NG12.Text))
                {
                    MessageBox.Show("Chưa nhập kí tự tháng mẫu NG", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMONTH_NG12.Focus();
                    return false;
                }

                return true;
            }
            else // Không sài thì cũng return true luôn không cần kiểm tra
            {
                return true;
            }

        }














































        #endregion






























        // MANUAL INPUT BARCODE


        #region Manual Input Barcode To CMES

        public string KiTuNam = "";
        public string KiTuThang = "";
        public string KiTuNgay = "";

        public int TongSL_InputManual = 0;
        public bool Stop_Send = false;
        public bool DangInputManual = false;



        public void XuatKiTuThoiGianTuDong()
        {










            switch (cbxManualInputKiTuNam.Text)
            {
                case "2021":
                    KiTuNam = "M";
                    break;
                case "2022":
                    KiTuNam = "N";
                    break;
                case "2023":
                    KiTuNam = "R";
                    break;
                case "2024":
                    KiTuNam = "S";
                    break;
                case "2025":
                    KiTuNam = "T";
                    break;
                case "2026":
                    KiTuNam = "U";
                    break;
                case "2027":
                    KiTuNam = "V";
                    break;
                case "2028":
                    KiTuNam = "W";
                    break;

                default:
                    break;
            }



            switch (cbxManualInputKiTuThang.Text)
            {
                case "1":
                    KiTuThang = "1";
                    break;
                case "2":
                    KiTuThang = "2";
                    break;
                case "3":
                    KiTuThang = "3";
                    break;
                case "4":
                    KiTuThang = "4";
                    break;
                case "5":
                    KiTuThang = "5";
                    break;
                case "6":
                    KiTuThang = "6";
                    break;
                case "7":
                    KiTuThang = "7";
                    break;
                case "8":
                    KiTuThang = "8";
                    break;
                case "9":
                    KiTuThang = "9";
                    break;
                case "10":
                    KiTuThang = "A";
                    break;
                case "11":
                    KiTuThang = "B";
                    break;
                case "12":
                    KiTuThang = "C";
                    break;

                default:
                    break;
            }



            switch (cbxManualInputKiTuNgay.Text)
            {
                case "1":
                    KiTuNgay = "1";
                    break;
                case "2":
                    KiTuNgay = "2";
                    break;
                case "3":
                    KiTuNgay = "3";
                    break;
                case "4":
                    KiTuNgay = "4";
                    break;
                case "5":
                    KiTuNgay = "5";
                    break;
                case "6":
                    KiTuNgay = "6";
                    break;
                case "7":
                    KiTuNgay = "7";
                    break;
                case "8":
                    KiTuNgay = "8";
                    break;
                case "9":
                    KiTuNgay = "9";
                    break;
                case "10":
                    KiTuNgay = "A";
                    break;
                case "11":
                    KiTuNgay = "B";
                    break;
                case "12":
                    KiTuNgay = "C";
                    break;
                case "13":
                    KiTuNgay = "D";
                    break;
                case "14":
                    KiTuNgay = "E";
                    break;
                case "15":
                    KiTuNgay = "F";
                    break;
                case "16":
                    KiTuNgay = "G";
                    break;
                case "17":
                    KiTuNgay = "H";
                    break;
                case "18":
                    KiTuNgay = "J";
                    break;
                case "19":
                    KiTuNgay = "K";
                    break;
                case "20":
                    KiTuNgay = "L";
                    break;
                case "21":
                    KiTuNgay = "M";
                    break;
                case "22":
                    KiTuNgay = "N";
                    break;
                case "23":
                    KiTuNgay = "R";
                    break;
                case "24":
                    KiTuNgay = "S";
                    break;
                case "25":
                    KiTuNgay = "T";
                    break;
                case "26":
                    KiTuNgay = "U";
                    break;
                case "27":
                    KiTuNgay = "V";
                    break;
                case "28":
                    KiTuNgay = "W";
                    break;
                case "29":
                    KiTuNgay = "X";
                    break;
                case "30":
                    KiTuNgay = "Y";
                    break;
                case "31":
                    KiTuNgay = "Z";
                    break;

                default:
                    break;
            }



        }



        public void MonitorFormatBarcode()
        {

            string Barcode = "";
            Barcode = (txtManualInputKiTuCoDinh1.Text + txtManualInputKiTuCoDinh2.Text + KiTuNam + KiTuThang + KiTuNgay);
            txtManualInputMonitorFormatCode.Text = Barcode;

        }


        public void MakeListBarcodeManual()
        {
            try
            {
                int stnum = Convert.ToInt32(txtManualInputSoThuTuBatDau.Text);
                int ednum = Convert.ToInt32(txtManualInputSoThuTuKetThuc.Text);

                int count = ednum - stnum + 1;
                txtManualInputTongSoLuongInput.Text = count.ToString();

                for (int i = 0; i < int.Parse(txtManualInputTongSoLuongInput.Text); i++)
                {
                    ListViewItem item = new ListViewItem(string.Format("{0:000000}", i + 1));
                    string temp = txtManualInputMonitorFormatCode.Text;
                    temp += string.Format("{0:000000}", stnum + i);
                    item.SubItems.Add(temp);
                    item.SubItems.Add("N"); ;
                    list_markingdata.Items.Add(item);

                }
            }
            catch
            {
                MessageBox.Show("Tạo list thất bại, hãy xem lại các thông số cài đặt đủ chưa?", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }



        public bool KiemTraTruocKhiTaoList()
        {
            if (string.IsNullOrEmpty(cbxManualInputKiTuNam.Text))
            {
                MessageBox.Show("Bạn chưa chọn năm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbxManualInputKiTuNam.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbxManualInputKiTuThang.Text))
            {
                MessageBox.Show("Bạn chưa chọn tháng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbxManualInputKiTuThang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbxManualInputKiTuNgay.Text))
            {
                MessageBox.Show("Bạn chưa chọn ngày", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbxManualInputKiTuNgay.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(txtManualInputSoThuTuBatDau.Text))
            {
                MessageBox.Show("Bạn chưa chọn số thứ tự bắt đầu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtManualInputSoThuTuBatDau.Focus();
                return false;
            }



            if (string.IsNullOrEmpty(txtManualInputTongSoLuongInput.Text))
            {
                MessageBox.Show("Bạn chưa chọn tổng số lượng muốn tạo mã", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtManualInputTongSoLuongInput.Focus();
                return false;
            }



            if (string.IsNullOrEmpty(txtManualInputSoThuTuKetThuc.Text))
            {
                MessageBox.Show("Bạn chưa chọn số thứ tự kết thúc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtManualInputSoThuTuKetThuc.Focus();
                return false;
            }

            return true;
        }



        public void Load_Manual_Input()
        {
            TEXT.Load_ManualInput(txtManualInputKiTuCoDinh1, txtManualInputKiTuCoDinh2, txtManualInputSoThuTuBatDau, txtManualInputTongSoLuongInput, txtManualInputSoThuTuKetThuc, txtManualInputLinkSaveFileUpload, cbxManualInputChonLuuKetQua);
        }



        public void Duyet_ListView(ListView list)
        {
            ManualArrayCode = new string[list.Items.Count];

            for (int i = 0; i < list.Items.Count; i++)
            {

                if (list.Items[i].SubItems[2].Text == "N")
                {
                    ManualArrayCode[i] = list.Items[i].SubItems[1].Text;
                }
                if (list.Items[i].SubItems[2].Text == "Y")
                {
                    list.Items[i].BackColor = Color.Green;
                    ManualArrayCode[i] = "ERROR";
                }

                if (Stop_Send)
                    break;
            }
        }


        public void Duyet_ListView_LayDataBarcodeXanh(ListView list)
        {
            ManualArrayCode_DaInput = new string[40];
            int j = 0;
            for (int i = 0; i < list.Items.Count; i++)
            {

                if (list.Items[i].SubItems[2].Text == "Y")
                {
                    if (string.IsNullOrEmpty(list.Items[i].SubItems[1].Text))
                    {

                    }
                    else
                    {
                        ManualArrayCode_DaInput[j] = list.Items[i].SubItems[1].Text;
                        j++;




                        if (j >= 40)
                        {
                            CreateLog_ManualInputInspection(txtManualInputLinkSaveFileUpload.Text, ManualArrayCode_DaInput);
                            ManualArrayCode_DaInput = new string[40];
                            j = 0;
                        }



                    }

                }

            }
            if (j > 0)
            {
                CreateLog_ManualInputInspection(txtManualInputLinkSaveFileUpload.Text, ManualArrayCode_DaInput);
                ManualArrayCode_DaInput = new string[40];
                j = 0;
            }
        }



        public void CreateLog_ManualInputInspection(string FilePath, string[] ArrayBarcode)
        {
            try
            {
                if (KiemTraLinhSaveFileManualInput()) // Kiểm tra link save có hay không
                {
                    DateTime dt = DateTime.Now;
                    string file = dt.Year.ToString() + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00") + dt.Millisecond.ToString("000") + ".txt";

                    FileStream FS = new FileStream(@FilePath + @"\" + file, FileMode.Create);
                    //FileStream FS = new FileStream(@FilePath + @"\" + file + ".txt", FileMode.Create);
                    StreamWriter SW = new StreamWriter(FS);

                    for (int i = 0; i < ArrayBarcode.Length; i++)
                    {
                        if (string.IsNullOrEmpty(ArrayBarcode[i]))
                        {
                            SW.WriteLine("");
                        }
                        else
                        {
                            SW.WriteLine(ArrayBarcode[i] + "-OK");
                        }

                    }

                    SW.Close();
                    FS.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lưu kết quả thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        //public void Duyet_ListView_LayDataBarcodeXanh(ListView list)
        //{
        //    ManualArrayCode_DaInput = new string[list.Items.Count];
        //    int j = 0;
        //    for (int i = 0; i < list.Items.Count; i++)
        //    {

        //        if (list.Items[i].SubItems[2].Text == "Y")
        //        {
        //            if (string.IsNullOrEmpty(list.Items[i].SubItems[1].Text))
        //            {

        //            }
        //            else
        //            {
        //                ManualArrayCode_DaInput[j] = list.Items[i].SubItems[1].Text;
        //                j++;
        //            }

        //        }

        //    }
        //}




        public void Input_To_Mes(ListView list)
        {
            int i = 0;
            //if ((checkBox_MesON.Checked == false) || (lbl_MES_status.BackColor == Color.Red)) // Kiểm tra kết nối mes 
            if ((checkBox_MesON.Checked == false) || (lbl_MES_status.BackColor == Color.Blue)) // Kiểm tra kết nối mes 
            {
                MessageBox.Show("Bạn chưa kết nối MES", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (AllowSendToMes) // Bật chế độ online PO running (lên mes)
                {
                    while (i <= ManualArrayCode.Count()) // Đẩy lên theo list manual
                    {
                        if (i < ManualArrayCode.Count())
                        {
                            if (mes_send)
                            {
                                if (ManualArrayCode[i] == "ERROR")
                                {
                                    // Bỏ qua code ERROR là đã đẩy trước đó
                                }
                                else
                                {
                                    mes_send = false;
                                    socket.sent_input_HHP_PBA(1, ManualArrayCode[i]); // Send từng PCM lên mes
                                    txtManualInputMaCuoiCungInput.Text = ManualArrayCode[i];
                                    list.Items[i].SubItems[2].Text = "Y";
                                    list.Items[i].BackColor = Color.Green;
                                    progressBarManualInput.Value = i + 1;
                                    TongSL_InputManual = i + 1;
                                    txtManualInputCounterTotal_Input.Text = TongSL_InputManual.ToString();
                                }

                                Thread.Sleep(10);
                                if (Stop_Send)
                                {
                                    //CreateFileLog_ManualInput();
                                    break;
                                }

                                i++;




                                //mes_send = true; // Xóa cái này đi





                            }



                        }
                        else
                        {
                            if (mes_send)
                                break;
                        }
                    }

                    CreateFileLog_ManualInput();
                }
                else
                {
                    MessageBox.Show("Bạn chưa cho phép đẩy code lên hệ thống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            DangInputManual = false;
        }



        public void Manual_Input_Barcode()
        {
            // tạo thread chạy đẩy code manual 
            thread_ManualInput = new Thread(Run_thread_ManualInput);
            thread_ManualInput.IsBackground = true;
            thread_ManualInput.Start();
        }




        void Run_thread_ManualInput()
        {
            DangInputManual = true;



            if (list_markingdata.Items.Count == 0)
            {
                MessageBox.Show("List barcode trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Duyet_ListView(list_markingdata); // tải mã barcode vào mảng array

                int max = ManualArrayCode.Count(); // tạo process bar
                if (max == 0)
                {
                    max = 1;
                }

                progressBarManualInput.Maximum = max;
                progressBarManualInput.Minimum = 0; ;
                progressBarManualInput.Value = 0;



                Input_To_Mes(list_markingdata); // Tải lên mes
                Thread.Sleep(200);
                DangInputManual = false;



            }



        }

        public bool KiemTraLinhSaveFileManualInput()
        {
            if (string.IsNullOrEmpty(txtManualInputLinkSaveFileUpload.Text))
            {
                MessageBox.Show("Link lưu file không tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                if (txtManualInputLinkSaveFileUpload.Text == "Link không tồn tại")
                {
                    MessageBox.Show("Link lưu file không tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                return true;
            }

        }



        //public void CreateLog_ManualInput(string FilePath, string[] ArrayBarcode)
        //{
        //    try
        //    {
        //        if (KiemTraLinhSaveFileManualInput()) // Kiểm tra link save có hay không
        //        {
        //            DateTime dt = DateTime.Now;
        //            string file = dt.Year.ToString() + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00") + dt.Millisecond.ToString("000") + ".txt";

        //            FileStream FS = new FileStream(@FilePath + @"\" + file, FileMode.Create);
        //            StreamWriter SW = new StreamWriter(FS);

        //            for (int i = 0; i < ArrayBarcode.Length; i++)
        //            {
        //                SW.WriteLine(ArrayBarcode[i]);
        //            }

        //            SW.Close();
        //            FS.Close();
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Lưu kết quả thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }


        //}


        //public void CreateFileLog_ManualInput()
        //{
        //    Duyet_ListView_LayDataBarcodeXanh(list_markingdata); // tải mã barcode vào mảng array
        //    CreateLog_ManualInput(txtManualInputLinkSaveFileUpload.Text, ManualArrayCode_DaInput);
        //}



        public void CreateFileLog_ManualInput()
        {


            if (cbxManualInputChonLuuKetQua.Checked)
                Duyet_ListView_LayDataBarcodeXanh(list_markingdata); // tải mã barcode vào mảng array

        }





















        #endregion




















































        private void btnManualInputToday_Click(object sender, EventArgs e)
        {
            cbxManualInputKiTuNam.Text = DateTime.Now.Year.ToString();
            cbxManualInputKiTuThang.Text = DateTime.Now.Month.ToString();
            cbxManualInputKiTuNgay.Text = DateTime.Now.Day.ToString();






        }


















        private void btnManualInputXoaHet_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn đã chắc chắn xóa list barcode này chưa", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                list_markingdata.Items.Clear();
            }

        }

        private void btnManualInputBatDau_Click(object sender, EventArgs e)
        {

            if (isStop) // Kiểm tra xem máy đã dừng chưa
            {
                if (cbxManualInputChonLuuKetQua.Checked)
                {

                    if (KiemTraLinhSaveFileManualInput())
                    {
                        // Kiểm tra đã đẩy hết list chưa

                        if (progressBarManualInput.Value == progressBarManualInput.Maximum)
                        {
                            MessageBox.Show("Bạn đã input hết list này rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            Stop_Send = false;
                            Manual_Input_Barcode();
                        }


                    }
                }
                else
                {
                    if (progressBarManualInput.Value == progressBarManualInput.Maximum)
                    {
                        MessageBox.Show("Bạn đã input hết list này rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        Stop_Send = false;
                        Manual_Input_Barcode();
                    }
                }





            }
            else
            {
                MessageBox.Show("Hãy stop auto để thực hiện thao tác này nhé", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }




        }

        private void btnManualInputKetThuc_Click(object sender, EventArgs e)
        {
            Stop_Send = true;
            mes_send = true;
            DangInputManual = false;
        }

        private void txtManualInputKiTuCoDinh1_TextChanged(object sender, EventArgs e)
        {
            MonitorFormatBarcode();
        }

        private void txtManualInputKiTuCoDinh2_TextChanged(object sender, EventArgs e)
        {
            MonitorFormatBarcode();
        }

        private void cbxManualInputKiTuNam_TextChanged(object sender, EventArgs e)
        {
            XuatKiTuThoiGianTuDong();
            MonitorFormatBarcode();
        }

        private void cbxManualInputKiTuThang_TextChanged(object sender, EventArgs e)
        {
            XuatKiTuThoiGianTuDong();
            MonitorFormatBarcode();
        }

        private void cbxManualInputKiTuNgay_TextChanged(object sender, EventArgs e)
        {
            XuatKiTuThoiGianTuDong();
            MonitorFormatBarcode();
        }








        private void txtManualInputSoThuTuBatDau_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int a = int.Parse(txtManualInputSoThuTuBatDau.Text);
                if (a > 999999)
                {
                    MessageBox.Show("Overload số thứ tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtManualInputTongSoLuongInput.Text))
                    {

                    }
                    else
                    {
                        txtManualInputSoThuTuKetThuc.Text = (a + (int.Parse(txtManualInputTongSoLuongInput.Text) - 1)).ToString();
                    }

                    txtManualInputFormatStt.Text = a.ToString("000000");
                    //txtManualInputSoThuTuBatDau.Text = a.ToString("000000");
                }

            }
            catch
            {
                MessageBox.Show("Số thứ tự bắt đầu sai rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            MonitorFormatBarcode();
        }

        private void txtManualInputTongSoLuongInput_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int a = int.Parse(txtManualInputTongSoLuongInput.Text);
                if (string.IsNullOrEmpty(txtManualInputSoThuTuBatDau.Text))
                {

                }
                else
                {
                    int STT_Ketthuc = (int.Parse(txtManualInputSoThuTuBatDau.Text) + (int.Parse(txtManualInputTongSoLuongInput.Text) - 1));
                    if (STT_Ketthuc > 999999)
                    {
                        MessageBox.Show("Overload số thứ tự max", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtManualInputTongSoLuongInput.Text = "";
                        txtManualInputTongSoLuongInput.Focus();
                    }
                    else
                    {
                        txtManualInputSoThuTuKetThuc.Text = STT_Ketthuc.ToString();
                    }

                }



            }
            catch
            {
                MessageBox.Show("Tổng số lượng sai rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }



        }

        private void txtManualInputSoThuTuKetThuc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtManualInputSoThuTuKetThuc.Text);
            }
            catch
            {
                MessageBox.Show("Số thứ tự kết thúc sai rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtManualInputMonitorFormatCode_TextChanged(object sender, EventArgs e)
        {
            txtManualInputSoKiTu.Text = (txtManualInputMonitorFormatCode.TextLength + txtManualInputFormatStt.TextLength).ToString();
        }


        private void txtManualInputFormatStt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnManualInputTaoList_Click(object sender, EventArgs e)
        {

            if (KiemTraTruocKhiTaoList())
            {
                DialogResult rs = MessageBox.Show("Bạn đã chắc chắn tạo list barcode này chưa? Data ở bảng bên cạnh sẽ bị xóa hết", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    list_markingdata.Items.Clear();
                    MakeListBarcodeManual();
                    progressBarManualInput.Value = 0;
                    TEXT.SaveManualInput(txtManualInputKiTuCoDinh1, txtManualInputKiTuCoDinh2, txtManualInputSoThuTuBatDau, txtManualInputTongSoLuongInput, txtManualInputSoThuTuKetThuc, txtManualInputLinkSaveFileUpload, cbxManualInputChonLuuKetQua);
                }

            }
        }



        private void btnManualInput_LoadKiTuCoDinh1_Click(object sender, EventArgs e)
        {
            if (checkBox_AutoAddProduct.Text == "AUTO")
            {
                txtManualInputKiTuCoDinh1.Text = txtOracel_PO_InUse.Text;
            }
            else
            {
                txtManualInputKiTuCoDinh1.Text = txtManualAddProduct.Text;
            }

        }



        private void lblLoadLinkLuuKetQua_Click(object sender, EventArgs e)
        {
            //OpenFileDialog OpenFile = new OpenFileDialog();
            //SaveFileDialog SaveFile = new SaveFileDialog();
            //if (SaveFile.ShowDialog() == DialogResult.OK)
            //{
            //    string FileNameModel;
            //    FileNameModel = SaveFile.FileName;
            //    txtManualInputLinkSaveFileUpload.Text = FileNameModel;
            //    txtManualInputLinkSaveFileUpload.ForeColor = Color.Blue;

            //}
        }

        private void cbxManualInputKiTuNam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxManualInputChonLuuKetQua_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxManualInputChonLuuKetQua.Checked)
            {
                cbxManualInputChonLuuKetQua.ForeColor = Color.Blue;
            }
            else
            {
                cbxManualInputChonLuuKetQua.ForeColor = Color.Red;
            }
        }





        private void btnChangeLinkFileSoSanh_Click(object sender, EventArgs e)
        {
            if (KiemTraDataDuongLinkSoSanh())
            {
                DATA.Check_Folder("DATA");

                TEXT.Save_Link_FileData_So_sanh
                    (
                    txtLinkFIleDataSoSanhDeTachLot
                    );


                Tao_Log_Voi_Noi_Dung_La("THAY DOI FILE DATA SO SANH QRCODE");





                if (checkBox_TachLotTheoFileDataON.Checked == true)
                {

                    checkBox_TachLotTheoFileDataON.Text = "ON";
                    checkBox_TachLotTheoFileDataON.ForeColor = Color.Blue;

                    Load_data_for_ListBarcode();



                }
                else
                {
                    checkBox_TachLotTheoFileDataON.Text = "OFF";
                    checkBox_TachLotTheoFileDataON.ForeColor = Color.Red;

                }







            }
        }

        //private void btnChangeTachLotHangTheoNgayThang_Click(object sender, EventArgs e)
        //{
        //    if (KiemTraDataTachLot())
        //    {
        //        DATA.Check_Folder("DATA");

        //        TEXT.Save_TachLotHangNG_Setting
        //            (
        //            txtViTriKiTuNAM,
        //            txtYEAR_NG1,
        //            txtYEAR_NG2,
        //            txtYEAR_NG3,
        //            txtYEAR_NG4,
        //            txtYEAR_NG5,
        //            txtYEAR_NG6,
        //            txtViTriKiTuTHANG,
        //            txtMONTH_NG1,
        //            txtMONTH_NG2,
        //            txtMONTH_NG3,
        //            txtMONTH_NG4,
        //            txtMONTH_NG5,
        //            txtMONTH_NG6,
        //            txtMONTH_NG7,
        //            txtMONTH_NG8,
        //            txtMONTH_NG9,
        //            txtMONTH_NG10,
        //            txtMONTH_NG11,
        //            txtMONTH_NG12,
        //            txtYEAR_OK
        //            );

        //        Tao_Log_Voi_Noi_Dung_La("THONG SO TACH LOT HANG LUU THAY DOI");
        //    }

        //}

        private void btnTestDouble_Click(object sender, EventArgs e)
        {
            ListTest.Clear();
            checkData.LoadList(ref ListTest, txtLinkFIleDataForTest.Text);


            Test_Tach_Lot_Tu_File_Tu_Tao();
        }

        private void checkBox_TachLotTheoNgayThangON_Click_1(object sender, EventArgs e)
        {
            if (checkBox_TachLotTheoNgayThangON.Checked == true)
            {

                checkBox_TachLotTheoNgayThangON.Text = "ON";
                checkBox_TachLotTheoNgayThangON.ForeColor = Color.Blue;
            }
            else
            {
                checkBox_TachLotTheoNgayThangON.Text = "OFF";
                checkBox_TachLotTheoNgayThangON.ForeColor = Color.Red;

            }
        }

        private void checkBox_TachLotTheoFileDataON_Click_1(object sender, EventArgs e)
        {
            if (checkBox_TachLotTheoFileDataON.Checked == true)
            {

                checkBox_TachLotTheoFileDataON.Text = "ON";
                checkBox_TachLotTheoFileDataON.ForeColor = Color.Blue;

                Load_data_for_ListBarcode();



            }
            else
            {
                checkBox_TachLotTheoFileDataON.Text = "OFF";
                checkBox_TachLotTheoFileDataON.ForeColor = Color.Red;

            }
        }

        private void btnSettingPhanLoaiTachHang_Click_1(object sender, EventArgs e)
        {
            tabPage_Auto.Hide();
            tabPage_manual.Hide();
            tabPage_Setting.Hide();
            tabPage_IO.Hide();
            tabPage_Teaching.Hide();
            tabPage_LOG_MES.Hide();
            tabPage_Auto.Hide();
            tabPage_OracleSeting.Hide();

            tabPage_TachLot.Show();
            tab_monitor_on = false;
        }



































    }
}
