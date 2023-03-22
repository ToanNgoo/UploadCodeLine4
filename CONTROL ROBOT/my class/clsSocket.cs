using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SetSystemTime;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace CONTROL_ROBOT
{
    public class clsSocket
    {
        private const string MES_SETDATETIME = "0001";          //MES -> PC
        private const string MES_HEARTBIT = "0002";            //MES -> PC
       
        private const string MES_INPUTHHP = "1205";             //PC -> MES
        private const string MES_INPUTPBA = "1300";              //PC -> MES  
        private const string MES_REQUEST_SN_NPC = "1203";       //PC -> MES
        private const string MES_SENDRESULT_NPC = "1204";       //PC -> MES
        private const string MES_SENDRESULT_PT = "1222";        //PC -> MES
        private const string MES_SENDRESULT_HHP = "1209";       //PC -> MES
        private const string MES_SEND_IROCV_HHP = "1236";       //PC -> MES
       
        
        private const string MES_REQUEST_FUNCTIONRESULT_HHP_1208 = "1208";

        private const string MES_SETDATETIME_RES = "1001";      //PC -> MES
        private const string MES_HEARTBIT_RES = "1002";         //PC -> MES
        
        private const string MES_INPUTHHP_RES = "0205";         //MES -> PC
        private const string MES_REQUEST_SN_NPC_RES = "0203";   //MES -> PC
        private const string MES_SENDRESULT_NPC_RES = "0204";   //MES -> PC
        private const string MES_SENDRESULT_PT_RES = "0222";    //MES -> PC
        private const string MES_SENDRESULT_HHP_RES = "0209";   //MES -> PC
        private const string MES_SEND_IROCV_HHP_RES = "1236";  //MES -> PC
        private const string MES_SEND_PBA= "0300";  //MES -> PC
        
        private const string MES_REQUEST_FUNCTIONRESULT_HHP_0208_RES = "0208";

        // PBA Veb
        private const string MES_WORKER = "1101";               //PC -> MES
        private const string MES_INPUTHHP_PBA = "1211";         //PC -> MES
        private const string MES_INPUTINSPEC_PBA = "1212";         //PC -> MES


        private const string MES_WORKER_RES = "0101";           //MES -> PC
        private const string MES_INPUTHHP_PBA_RES = "0211";     //MES -> PC
        private const string MES_INPUTINSPEC_PBA_RES = "0212";  //PC -> MES

        Socket server;
        IPEndPoint ipe;
        List<Socket> lstclient;

        DatNgayGioHeThong setsystemtime = new DatNgayGioHeThong();
        clsdataconvert dataconvert = new clsdataconvert();       
        
        fMain frmmain;
        Thread socketstart;
        Thread clientProcess;
        Boolean _resulttest;

        string _testtime;
        string _ir;
        string _ocv;

        public string data_1;

        public string Ir
        {
            get { return _ir; }
            set { _ir = value; }
        }

        public string Ocv
        {
            get { return _ocv; }
            set { _ocv = value; }
        }

        public string Testtime
        {
            get { return _testtime; }
            set { _testtime = value; }
        }

        public Boolean Resulttest
        {
            get { return _resulttest; }
            set { _resulttest = value; }
        }
        private string _myIP;
        private int _port;
        private bool _connectstate;
        private string _mcid;
        private string _portprocess;
        private string _lineno;
        private string _stnid1;
        private string _stnid2;
        private string _stnid3;
        private string _stnid4;
        private string _stnid5;
        private string _workerid;
        private string _ipadd;
        private string _Packcode;
        private string _modelver;
        //private string _a;

        public string Modelver
        {
            get { return _modelver; }
            set { _modelver = value; }
        }
        private string _specver;

        public string Specver
        {
            get { return _specver; }
            set { _specver = value; }
        }
        private string _functionver;

        public string Functionver
        {
            get { return _functionver; }
            set { _functionver = value; }
        }

        public string Packcode
        {
            get { return _Packcode; }
            set { _Packcode = value; }
        }

        public string Ipadd
        {
            get { return _ipadd; }
            set { _ipadd = value; }
        }

        public string Workerid
        {
            get { return _workerid; }
            set { _workerid = value; }
        }
        public string Stnid5
        {
            get { return _stnid5; }
            set { _stnid5 = value; }
        }
        public string Stnid4
        {
            get { return _stnid4; }
            set { _stnid4 = value; }
        }
        public string Stnid3
        {
            get { return _stnid3; }
            set { _stnid3 = value; }
        }

        public string Stnid2
        {
            get { return _stnid2; }
            set { _stnid2 = value; }
        }

        public string Stnid1
        {
            get { return _stnid1; }
            set { _stnid1 = value; }
        }

        public string Lineno
        {
            get { return _lineno; }
            set { _lineno = value; }
        }

        public string Portprocess
        {
            get { return _portprocess; }
            set { _portprocess = value; }
        }

        public string Mcid
        {
            get { return _mcid; }
            set { _mcid = value; }
        }

        public bool Connectstate
        {
            get { return _connectstate; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public string MyIP
        {
            get { return _myIP; }
        }

        //public string A { get => _a; set => _a = value; }

        public void start(string IP)
        {
            LayIP(IP);
            socketstart = new Thread(new ThreadStart(listensocket));
            socketstart.IsBackground = true;
            socketstart.Start();
        }

        public clsSocket(fMain _frmmain)
        {
            _connectstate = false;
            frmmain = _frmmain;
            lstclient = new List<Socket>();
            setsystemtime = new DatNgayGioHeThong();
            socketstart = new Thread(new ThreadStart(listensocket));
            clientProcess = new Thread(myThreadClient);
            if (socketstart.IsAlive == true) socketstart.Abort();
            if (clientProcess.IsAlive == true) clientProcess.Abort();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }

        public void LayIP(string IP)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress diachi in host.AddressList)
            {
                if (diachi.AddressFamily.ToString() == "InterNetwork")
                {
                    _myIP = diachi.ToString();
                }
            }
            ipe = new IPEndPoint(IPAddress.Parse(IP), _port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }

        private void listensocket()
        {
            try
            {
                server.Bind(ipe);
                server.Listen(100);
                lstclient.Clear();
                while (true)
                {
                    Socket sk = server.Accept();
                    lstclient.Add(sk);
                    clientProcess = new Thread(myThreadClient);
                    clientProcess.IsBackground = true;
                    clientProcess.Start(sk);
                }
            }
            catch (Exception)
            {
                frmmain.lblThongBaoLoiMes.Text = "MES LỖI XỬ LÝ DATA";
                frmmain.lblThongBaoLoiMes.ForeColor = Color.Black;
                frmmain.lblThongBaoLoiMes.BackColor = Color.Red;


                frmmain.MES_Connecting = "CANT";
                _connectstate = false;
                return;
            }
        }

        private void myThreadClient(object obj)
        {
            Socket clientsk = (Socket)obj;
            while (true)                                 // Vòng lặp quét tín hiệu mes trả về 
            {
                try
                {
                    byte[] buff = new byte[1024];
                    int recv = clientsk.Receive(buff);
                    foreach (Socket sk in lstclient)
                    {
                        string str = dataconvert.removenull(System.Text.Encoding.ASCII.GetString(buff));
                        _connectstate = true;
                        xulydatasocket(str);

                        frmmain.lblThongBaoLoiMes.Text = "MES CONNECTION";
                        frmmain.lblThongBaoLoiMes.ForeColor = Color.Maroon;
                        frmmain.lblThongBaoLoiMes.BackColor = Color.Silver;
                    }
                }
                catch 
                {
                    frmmain.lblThongBaoLoiMes.Text = "MES LỖI XỬ LÝ DATA";
                    frmmain.lblThongBaoLoiMes.ForeColor = Color.Black;
                    frmmain.lblThongBaoLoiMes.BackColor = Color.Red;

                    _connectstate = false;
                    break;
                }
            }
        }

        public void senddata(string str)
        {
            foreach (Socket sk in lstclient)
            {
                byte[] datasendbyte = new byte[1024];
                datasendbyte = System.Text.Encoding.ASCII.GetBytes(str);
                sk.Send(datasendbyte);
            }
        }
       





        private void xulydatasocket(string str) // Xử lý data từ mes trả về
        {
            string[] data = new string[1024]; // mảng độ dài 1024 (theo mes)
            string commandcode = str.Substring(21, 4);       // cắt chuỗi str từ kí tự 21 và dài 4 kí tự 
            data = str.Split(';');           // tách chuỗi bởi kí tự ; thành các phần tử của mảng
           
            
            
            
            switch (commandcode)  // Lọc theo biến 
            {
                case MES_INPUTHHP_PBA_RES: // 0211
                    /* Mes return kết quả input barcode HHP model */
                    string code = data[0].Substring(91, 50);  // cắt chuỗi từ kí tự 91 và lấy 50 kí tự
                    int errorcode = int.Parse(data[0].Substring(39, 4)); // // cắt chuỗi từ kí tự 39 và lấy 4 kí tự

                    for (int i = 1; i < frmmain.ArrayCode.Length; i++)
                    {
                        if (code.Trim() == frmmain.ArrayCode[i]) // Code trả về tương ứng array code vừa gửi
                        {
                            if (errorcode != 0) // Mes trả về khác 0 là NG có lỗi phát sinh
                            {
                                if (frmmain.Double_Check_Code == false)
                                {
                                    if (errorcode != 88) // Mes trả về code khác 88 : đã input trước đó (double) nếu có lỗi 88 thì bỏ qua
                                    {
                                        frmmain.Error_Mes++; // Set biến lỗi
                                        frmmain.status_PCM[i] = 3;  // Monitor hiển thị mầu nền đỏ 
                                        frmmain.errorCode[i] = errorcode.ToString(); // Hiển thị tên code lỗi ra màn hình tương ứng
                                        frmmain.counter_total_NG++; // đếm counter NG + 1 PCM
                                        frmmain.txtCounterTotal_Input_NG.Text = frmmain.counter_total_NG.ToString(); // Hiển thị counter
                                    }
                                    else // Nếu code lỗi là 88 thì coi như OK
                                    {
                                        frmmain.status_PCM[i] = 2;  // Monitor hiển thị mầu nền xanh nếu có lỗi 88 thì bỏ qua coi như OK
                                        frmmain.errorCode[i] = errorcode.ToString(); // Hiển thị tên code lỗi ra màn hình tương ứng
                                        frmmain.counter_total_OK++; // đếm counter OK + 1
                                        //frmmain.counter_total_NG++; // đếm counter NG + 1 PCM
                                        frmmain.txtCounterTotal_Input_OK.Text = frmmain.counter_total_OK.ToString(); // Hiển thị counter
                                    }
                                }
                                else
                                {
                                    frmmain.Error_Mes++; // Set biến lỗi
                                    frmmain.status_PCM[i] = 3;  // Monitor hiển thị mầu nền đỏ 
                                    frmmain.errorCode[i] = errorcode.ToString(); // Hiển thị tên code lỗi ra màn hình tương ứng

                                    frmmain.counter_total_NG++; // đếm counter NG + 1 PCM
                                    frmmain.txtCounterTotal_Input_NG.Text = frmmain.counter_total_NG.ToString(); // Hiển thị counter
                                }
                                



                            }
                            else                // Mes trả về = 0 là OK
                            {
                                frmmain.status_PCM[i] = 2;  // Monitor hiển thị mầu nền xanh
                                frmmain.errorCode[i] = "OK"; // Bằng 0 là không có lỗi phát sinh

                                frmmain.counter_total_OK++; // đếm counter OK + 1
                                frmmain.txtCounterTotal_Input_OK.Text = frmmain.counter_total_OK.ToString(); // Hiển thị counter
                            }
                        }
                    }


                    frmmain.listBox_MEStoPC.Items.Add(data[0] + ";");           // Hiển thị ra listbox màn setup       
                    frmmain.MES_Connecting = "CAN";            
                    saveRec(data[0] + ";");
                    frmmain.mes_send = true;
                    break;



                case MES_WORKER_RES:  /*Lấy Worker_name từ Mes*/      //0101              
                    frmmain.MES_Connecting = "CAN";                   
                    break;



                //case MES_INPUTINSPEC_PBA_RES:  //0212
                //    //frmmain.textBox5.Text = data[0];
                //    frmmain.MES_Connecting = "CAN";
                //    break; 
                case MES_INPUTINSPEC_PBA_RES:  //0212
                    string _code = data[0].Substring(81, 50);  // cắt chuỗi từ kí tự 81 và lấy 50 kí tự
                    int _errorcode = int.Parse(data[0].Substring(39, 4)); // // cắt chuỗi từ kí tự 39 và lấy 4 kí tự

                    for (int i = 1; i < frmmain.ArrayCode.Length; i++)
                    {
                        if (_code.Trim() == frmmain.ArrayCode[i]) // Code trả về tương ứng array code vừa gửi
                        {


                            if (_errorcode != 0) // Mes trả về khác 0 là NG
                            {

                                if (_errorcode != 154) // Mes trả về code khác 154 : đã inspection trước đó
                                {
                                    frmmain.Error_Mes++; // Set biến lỗi
                                    frmmain.status_PCM[i] = 3;  // Monitor hiển thị mầu nền đỏ 
                                    frmmain.errorCode[i] = _errorcode.ToString(); // Hiển thị tên code lỗi ra màn hình tương ứng
                                    frmmain.counter_total_NG++; // đếm counter NG + 1 PCM
                                    frmmain.txtCounterTotal_Input_NG.Text = frmmain.counter_total_NG.ToString(); // Hiển thị counter
                                }
                                else // Nếu code lỗi là 154 thì coi như OK
                                {
                                    frmmain.status_PCM[i] = 2;  // Monitor hiển thị mầu nền xanh
                                    frmmain.errorCode[i] = _errorcode.ToString(); // Hiển thị tên code lỗi ra màn hình tương ứng
                                    frmmain.counter_total_OK++; // đếm counter OK + 1
                                    frmmain.txtCounterTotal_Input_OK.Text = frmmain.counter_total_OK.ToString(); // Hiển thị counter
                                }

                            }
                            else                // Mes trả về = 0 là OK
                            {
                                frmmain.status_PCM[i] = 2;  // Monitor hiển thị mầu nền xanh
                                frmmain.errorCode[i] = "OK"; // Bằng 0 là không có lỗi phát sinh
                                frmmain.counter_total_OK++; // đếm counter OK + 1
                                frmmain.txtCounterTotal_Input_OK.Text = frmmain.counter_total_OK.ToString(); // Hiển thị counter
                            }
                        }
                    }


                    frmmain.listBox_MEStoPC.Items.Add(data[0] + ";");           // Hiển thị ra listbox màn setup       
                    frmmain.MES_Connecting = "CAN";
                    saveRec(data[0] + ";");
                    frmmain.mes_send = true;
                    break;





                case MES_SETDATETIME: //0001
                    string thoigian = data[0].Substring(25, 14);
                    string nam = thoigian.Substring(0, 4);
                    string thang = thoigian.Substring(4, 2);
                    string ngay = thoigian.Substring(6, 2);
                    string gio = thoigian.Substring(8, 2);
                    string phut = thoigian.Substring(10, 2);
                    string giay = thoigian.Substring(12, 2);
                    setsystemtime.DatNgay(ngay, thang, nam);
                    //setsystemtime.DatGio(gio, phut, giay);
                    Response_DateTimeSet();
                    frmmain.MES_Connecting = "CAN";                   
                    _connectstate = true;
                    break;



                case MES_HEARTBIT: // 0002
                    frmmain.MES_Connecting = "CAN";
                    RESPONSE_HEARBIT(data[0].Substring(39, 4));
                    break;



                case MES_HEARTBIT_RES: // 1002
                    frmmain.MES_Connecting = "CAN";
                    RESPONSE_HEARBIT(data[0].Substring(39, 4));
                    break; 
                    


                default:                    
                    break;
            }
        }

        private void Response_DateTimeSet()
        {
            string msg;
            msg = "";
            msg = "@";
            msg += _lineno;
            msg += _mcid;
            msg += dataconvert.insert_Blank_Right("COMMSVR", 8);
            msg += MES_SETDATETIME_RES;
            msg += DateTime.Now.ToString("yyyyMMddHHmmss");
            msg += dataconvert.insert_Blank_Left("0", 4);
            msg += dataconvert.insert_Blank_Left("0", 6);
            msg += ":";
            msg += "*;";
            senddata(msg);
           // Request_WorkerID();
        }

        private void RESPONSE_HEARBIT(string Responsebit)
        {
            string msg;
            msg = "";
            msg = "@";
            msg += _lineno;
            msg += _mcid;
            msg += dataconvert.insert_Blank_Right("COMMSVR", 8);
            msg += MES_HEARTBIT_RES;
            msg += DateTime.Now.ToString("yyyyMMddHHmmss");
            switch (int.Parse(Responsebit))
            {
                case 0:
                    msg += dataconvert.insert_Blank_Left("1", 4);
                    break;
                case 1:
                    msg += dataconvert.insert_Blank_Left("0", 4);
                    break;
            }

            msg += dataconvert.insert_Blank_Left("0", 6);
            msg += ":";
            msg += "*;";
            senddata(msg);
        }














        public void sent_input_HHP_PBA(int kenh, string barcode)
        {
            string stnid = "";
            stnid = Stnid1;
            string msg;
            msg = "@"; //
            msg += _lineno;//
            msg += _mcid;//
            msg += dataconvert.insert_Blank_Right("MES", 8);//
            msg += MES_INPUTHHP_PBA; //
            msg += DateTime.Now.ToString("yyyyMMddHHmmss"); //
            msg += dataconvert.insert_Blank_Left("0", 4);   //           
            msg += dataconvert.insert_Blank_Left("109", 6);
            msg += ":";//
            msg += dataconvert.insert_Blank_Left(stnid, 8); //
            msg += dataconvert.insert_Blank_Left(_portprocess, 3); //
            msg += dataconvert.insert_Blank_Right(_workerid, 30); //
            msg += dataconvert.insert_Blank_Right(barcode, 50); //array barcode 
            msg += dataconvert.insert_Blank_Right("1", 3); //Array size 
            msg += dataconvert.insert_Blank_Right("1", 4); //PCM no
            msg += "O";
            msg += dataconvert.insert_Blank_Right("", 10); //ItemData
            msg += "*;";

            saveSend(msg);  // Lưu log gửi lên mes
            frmmain.listBox_PCtoMES.Items.Add(msg); // Hiển thị thông tin ra listbox màn hình setup
            senddata(msg, kenh);
        }


















        public void sent_inputInspection_HHP_PBA(int kenh, string barcode)
        {
            string stnid = "";
            stnid = Stnid1;
            string msg;
            msg = "@"; //
            msg += _lineno;//
            msg += _mcid;//
            msg += dataconvert.insert_Blank_Right("MES", 8);//
            msg += MES_INPUTINSPEC_PBA; //
            msg += DateTime.Now.ToString("yyyyMMddHHmmss"); //
            msg += dataconvert.insert_Blank_Right("0", 4);  //           
            msg += dataconvert.insert_Blank_Left("119", 6);
            msg += ":";//
            msg += dataconvert.insert_Blank_Left(stnid, 8); //
            msg += dataconvert.insert_Blank_Left(_portprocess, 3);//
            msg += dataconvert.insert_Blank_Right(_workerid, 30);//
            msg += dataconvert.insert_Blank_Right(barcode, 50);// array barcode 
            msg += dataconvert.insert_Blank_Right("1", 3);  // Array size 
            msg += dataconvert.insert_Blank_Right("1", 4);// PCM no
            msg += "O";
            msg += dataconvert.insert_Blank_Right(stnid, 20); // ItemData 
            msg += "*;";            

            saveSend(msg);
            senddata(msg, kenh);          
        }

        public void Request_WorkerID(string ID)
        {
            string msg;
            msg = "@";
            msg += _lineno;
            msg += _mcid;
            msg += dataconvert.insert_Blank_Right("MES", 8);
            msg += MES_WORKER;
            msg += DateTime.Now.ToString("yyyyMMddHHmmss");            
            msg += dataconvert.insert_Blank_Right("0", 4);
            msg += dataconvert.insert_Blank_Left("88", 6);
            msg += ":";
            msg += _stnid1;
            msg += _portprocess;
            msg += dataconvert.insert_Blank_Left("", 30);
            msg += DateTime.Now.ToString("yyyyMMddHHmmss");
            msg += "000";
            msg += dataconvert.insert_Blank_Right(ID, 30);               
            msg += "*;";            
            senddata(msg);
        }

        //protocol sent CMES in MIH




        public void saveSend(string msg)   // Lưu log gửi lên mes
        {
            string DataReadTime1 = DateTime.Now.ToString("yyyyMMddHHmmss");
            DirectoryInfo DayDataFolder1 = new DirectoryInfo(@Application.StartupPath + "\\Log\\MES\\" + DataReadTime1.Remove(4) + "\\" + DataReadTime1.Substring(4, 2));
            if (DayDataFolder1.Exists == false)
            {
                DayDataFolder1.Create();
            }

            FileStream MESLog = new FileStream(@Application.StartupPath + "\\Log\\MES\\" + DataReadTime1.Remove(4) + "\\" + DataReadTime1.Substring(4, 2) + "\\" + DataReadTime1.Substring(4, 4) + "LOG(Send).txt", FileMode.Append);

            using (StreamWriter MESLogWrite = new StreamWriter(MESLog))
            {
                MESLogWrite.Write("[SEND]" + DateTime.Now.ToString("HHmmss.ff") + " " + msg + "\r\n");
                MESLogWrite.Close();
            }
        }

        public void saveRec(string msg)  // Lưu log RECEIVE nhận từ mes
        {
            string DataReadTime1 = DateTime.Now.ToString("yyyyMMddHHmmss");
            DirectoryInfo DayDataFolder1 = new DirectoryInfo(@Application.StartupPath + "\\Log\\MES\\" + DataReadTime1.Remove(4) + "\\" + DataReadTime1.Substring(4, 2));
            if (DayDataFolder1.Exists == false)
            {
                DayDataFolder1.Create();
            }

            FileStream MESLog = new FileStream(@Application.StartupPath + "\\Log\\MES\\" + DataReadTime1.Remove(4) + "\\" + DataReadTime1.Substring(4, 2) + "\\" + DataReadTime1.Substring(4, 4) + "LOG(Rec).txt", FileMode.Append);

            using (StreamWriter MESLogWrite = new StreamWriter(MESLog))
            {
                MESLogWrite.Write("[RECEIVE]" + DateTime.Now.ToString("HHmmss.ff") + " " + msg + "\r\n");
                MESLogWrite.Close();
            }
        }



        public void senddata(string str, int channel)
        {
            foreach (Socket sk in lstclient)
            {
                byte[] datasendbyte = new byte[1024];
                datasendbyte = System.Text.Encoding.ASCII.GetBytes(str);
                sk.Send(datasendbyte);
                //Makelog.savelogsocket("[ SEND  ][" + DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss") + "][" + str + "]", channel);
            }
        }

        public void stop()
        {
            if (socketstart.IsAlive == true) socketstart.Abort();
            if (clientProcess.IsAlive == true) clientProcess.Abort();
        }
    }
}
