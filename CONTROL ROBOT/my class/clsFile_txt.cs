using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using app = Microsoft.Office.Interop.Excel.Application;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace CONTROL_ROBOT
{
    class clsFile_txt
    {




        public void Load_Setting_Mes
            (
            TextBox tb_IP,
            TextBox tb_LineNo,
            TextBox tb_McID,
            TextBox tb_StnID,
            TextBox tb_Port,
            TextBox tb_workerID


            )
        {
            try
            {
                string[] data = null;
                string str;
                FileStream FS = new FileStream(@Application.StartupPath + @"\DATA\MesSetting.ini", FileMode.Open);
                StreamReader SR = new StreamReader(FS);
                while (SR.EndOfStream == false)
                {
                    str = SR.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {
                        case "IP_MES":
                            tb_IP.Text = data[1];
                            break;
                        case "LineNo":
                            tb_LineNo.Text = data[1];
                            break;
                        case "MCID":
                            tb_McID.Text = data[1];
                            break;
                        case "STNID1":
                            tb_StnID.Text = data[1];
                            break;
                        case "Port":
                            tb_Port.Text = data[1];
                            break;
                        case "WorkerID":
                            tb_workerID.Text = data[1];
                            break;


                        default:
                            break;

                    }
                }
                SR.Close();
                FS.Close();
            }
            catch
            {

            }
        }



        //public void SaveDataRunning
        //    (
        //    Label link_model,
        //    TextBox PLC_IP,
        //    TextBox PLC_CPU,
        //    TextBox PLC_KhoiTaoLai,
        //    TextBox Counter
        //    )
        //{
        //    FileStream ProductionQty = new FileStream(Application.StartupPath + @"\Data\DataIsRuning.ini", FileMode.Create);

        //    using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
        //    {
        //        ProductionQtyWrite.WriteLine("**************************************************************");
        //        ProductionQtyWrite.WriteLine("RUNING DATA");
        //        ProductionQtyWrite.WriteLine("");
        //        ProductionQtyWrite.WriteLine("Model_link=" + link_model.Text);
        //        ProductionQtyWrite.WriteLine("");
        //        ProductionQtyWrite.WriteLine("PLC_IP=" + PLC_IP.Text);
        //        ProductionQtyWrite.WriteLine("PLC_CPU_CODE=" + PLC_CPU.Text);
        //        ProductionQtyWrite.WriteLine("PLC_RECONNECT=" + PLC_KhoiTaoLai.Text);
        //        ProductionQtyWrite.WriteLine("");
        //        ProductionQtyWrite.WriteLine("COUNTER=" + Counter.Text);
        //        ProductionQtyWrite.WriteLine("");
        //        ProductionQtyWrite.WriteLine("");


        //        ProductionQtyWrite.WriteLine("****************END*******************************************");
        //        ProductionQtyWrite.Close();
        //    }
        //}



        //public void Load_Last_Data_Running
        //    (
        //    Label link_model,
        //    TextBox PLC_IP,
        //    TextBox PLC_CPU,
        //    TextBox PLC_KhoiTaoLai,
        //    TextBox Counter
        //    )
        //{
        //    try
        //    {
        //        string[] data = null;
        //        string str = "";
        //        FileStream FS = new FileStream(Application.StartupPath + @"\Data\DataIsRuning.ini", FileMode.Open);
        //        StreamReader CounterRead = new StreamReader(FS);
        //        while (CounterRead.EndOfStream == false)
        //        {
        //            str = CounterRead.ReadLine();
        //            data = str.Split('=');

        //            switch (data[0])
        //            {
        //                case "Model_link":
        //                    link_model.Text = data[1];
        //                    break;
        //                case "PLC_IP":
        //                    PLC_IP.Text = data[1];
        //                    break;
        //                case "PLC_CPU_CODE":
        //                    PLC_CPU.Text = data[1];
        //                    break;
        //                case "PLC_RECONNECT":
        //                    PLC_KhoiTaoLai.Text = data[1];
        //                    break;
        //                // Load counter
        //                case "COUNTER":
        //                    Counter.Text = data[1];
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
        //}







        public void Add_Data_Log(string commend, string link_file)
        {
            try
            {
                string[] data = { DateTime.Now.ToString() + ", " + commend };
                // Ghi thêm vào cuối file
                File.AppendAllLines(link_file, data);
            }
            catch { }
        }




        public void Save_Result_Read_Code_To_Log_File(string[] ArrCode, string link_file)
        {

            try
            {
                // Ghi thêm vào cuối file
                for (int i = 0; i < ArrCode.Length - 1; i++)
                {
                    File.AppendAllText(link_file, ArrCode[i] + "\r\n");
                }

                //File.AppendAllLines(link_file, ArrCode);       
            }
            catch { }
        }









        public void SavePLCSetting(
            TextBox IP,
            TextBox CPU,
            TextBox ReConnect
            )
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\PLCSetting.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[PLC Setting]");
                ProductionQtyWrite.WriteLine("PLC_IP=" + IP.Text);
                ProductionQtyWrite.WriteLine("PLC_CPU_CODE=" + CPU.Text);
                ProductionQtyWrite.WriteLine("PLC_RECONNECT=" + ReConnect.Text);
                ProductionQtyWrite.WriteLine("[END]");
                ProductionQtyWrite.Close();
            }
        }



        public void SaveMesSetting
            (
          TextBox tb_IP,
          TextBox tb_LineNo,
          TextBox tb_McID,
          TextBox tb_StnID,
          TextBox tb_port,
          TextBox tb_workerID

            )
        {
            try
            {
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\MesSetting.ini", FileMode.Create);
                StreamWriter SW = new StreamWriter(FS);

                SW.WriteLine("[MES_SETTING]");
                SW.WriteLine("");
                SW.WriteLine("IP_MES=" + tb_IP.Text);
                SW.WriteLine("LineNo=" + tb_LineNo.Text);
                SW.WriteLine("MCID=" + tb_McID.Text);
                SW.WriteLine("STNID1=" + tb_StnID.Text);
                SW.WriteLine("STNID2="); // KSD
                SW.WriteLine("Port=" + tb_port.Text);
                SW.WriteLine("WorkerID=" + tb_workerID.Text);
                SW.WriteLine("");

                SW.Close();
                FS.Close();
            }
            catch
            {
            }
        }



        public void SaveDeviceSetting
           (
         TextBox txtCurrentPos,
         TextBox txtScanning,
         TextBox txtReadCodeJigOK,
         TextBox txtReadCodeJigNG,
         TextBox txtReadPcmOK,
         TextBox txtReadPcmNG,
         TextBox txtScanDone,
         TextBox txtReadTotalOK,
         TextBox txtReadTotalNG,
         TextBox txtStopMachine,
         TextBox txtCycletime,
         TextBox txtDelayNornal,
         TextBox txtDelayNG
            )
        {
            try
            {
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\DevicePLC_Config.ini", FileMode.Create);
                StreamWriter SW = new StreamWriter(FS);

                SW.WriteLine("[DEVICE_PLC_CONFIG]");
                SW.WriteLine("CurrenPossition=" + txtCurrentPos.Text);
                SW.WriteLine("Scanning=" + txtScanning.Text);
                SW.WriteLine("Read_Code_Jig_OK=" + txtReadCodeJigOK.Text);
                SW.WriteLine("Read_Code_Jig_NG=" + txtReadCodeJigNG.Text);
                SW.WriteLine("Read_PCM_OK=" + txtReadPcmOK.Text);
                SW.WriteLine("Read_PCM_NG=" + txtReadPcmNG.Text);
                SW.WriteLine("Scan_Done=" + txtScanDone.Text);
                SW.WriteLine("Total_Read_OK=" + txtReadTotalOK.Text);
                SW.WriteLine("Total_Read_NG=" + txtReadTotalNG.Text);
                SW.WriteLine("Stop_Machine=" + txtStopMachine.Text);
                SW.WriteLine("Cycle_time=" + txtCycletime.Text);
                SW.WriteLine("Delay_Normal=" + txtDelayNornal.Text);
                SW.WriteLine("Delay_NG=" + txtDelayNG.Text);

                SW.WriteLine("[END]");
                SW.Close();
                FS.Close();
            }
            catch
            {
            }
        }



        public void Save_Link_FileData_So_sanh
          (
            //TextBox linkFolderCode,
          TextBox txtLink
          )
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\TachLotSetingTheoData.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[TACH_HANG_THEO_DATA]");
                ProductionQtyWrite.WriteLine("Link_Data=" + txtLink.Text);

                ProductionQtyWrite.WriteLine("[END]");
                ProductionQtyWrite.Close();
            }
        }




      //  public void Save_TachLotHangNG_Setting
      //  (
      //TextBox txtViTriKiTuNam,
      //TextBox txtNam1,
      //TextBox txtNam2,
      //TextBox txtNam3,
      //TextBox txtNam4,
      //TextBox txtNam5,
      //TextBox txtNam6,
      //TextBox txtViTriKiTuThang,
      //TextBox txtThang1,
      //TextBox txtThang2,
      //TextBox txtThang3,
      //TextBox txtThang4,
      //TextBox txtThang5,
      //TextBox txtThang6,
      //TextBox txtThang7,
      //TextBox txtThang8,
      //TextBox txtThang9,
      //TextBox txtThang10,
      //TextBox txtThang11,
      //TextBox txtThang12,
      //TextBox txtyear_OK
      //   )
      //  {
      //      try
      //      {
      //          FileStream FS = new FileStream(Application.StartupPath + @"\DATA\TachLotSeting.ini", FileMode.Create);
      //          StreamWriter SW = new StreamWriter(FS);

      //          SW.WriteLine("[TACH_LOT_HANG]");
      //          SW.WriteLine("Vi_Tri_Ki_Tu_Nam=" + txtViTriKiTuNam.Text);
      //          SW.WriteLine("Mau_Nam_NG_1=" + txtNam1.Text);
      //          SW.WriteLine("Mau_Nam_NG_2=" + txtNam2.Text);
      //          SW.WriteLine("Mau_Nam_NG_3=" + txtNam3.Text);
      //          SW.WriteLine("Mau_Nam_NG_4=" + txtNam4.Text);
      //          SW.WriteLine("Mau_Nam_NG_5=" + txtNam5.Text);
      //          SW.WriteLine("Mau_Nam_NG_6=" + txtNam6.Text);

      //          SW.WriteLine("Vi_Tri_Ki_Tu_Thang=" + txtViTriKiTuThang.Text);
      //          SW.WriteLine("Mau_Thang_NG_1=" + txtThang1.Text);
      //          SW.WriteLine("Mau_Thang_NG_2=" + txtThang2.Text);
      //          SW.WriteLine("Mau_Thang_NG_3=" + txtThang3.Text);
      //          SW.WriteLine("Mau_Thang_NG_4=" + txtThang4.Text);
      //          SW.WriteLine("Mau_Thang_NG_5=" + txtThang5.Text);
      //          SW.WriteLine("Mau_Thang_NG_6=" + txtThang6.Text);
      //          SW.WriteLine("Mau_Thang_NG_7=" + txtThang7.Text);
      //          SW.WriteLine("Mau_Thang_NG_8=" + txtThang8.Text);
      //          SW.WriteLine("Mau_Thang_NG_9=" + txtThang9.Text);
      //          SW.WriteLine("Mau_Thang_NG_10=" + txtThang10.Text);
      //          SW.WriteLine("Mau_Thang_NG_11=" + txtThang11.Text);
      //          SW.WriteLine("Mau_Thang_NG_12=" + txtThang12.Text);
      //          SW.WriteLine("Nam_OK_Can_Tach_Theo_Thang=" + txtyear_OK.Text);

      //          SW.WriteLine("[END]");
      //          SW.Close();
      //          FS.Close();
      //      }
      //      catch
      //      {
      //      }
      //  }











        public void SaveOracleSetting
        (
      TextBox txtSource,
      TextBox txtUser,
      TextBox txtPass,
      ComboBox cbxLineNo,
      ComboBox cbxChonYesNo,
      TextBox txtMaAddManual,
      CheckBox checkboxAutoManual

         )
        {
            try
            {
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\OracleSetting.ini", FileMode.Create);
                StreamWriter SW = new StreamWriter(FS);

                SW.WriteLine("[Oracle]");
                SW.WriteLine("Oracle_DBsource=" + txtSource.Text);
                SW.WriteLine("Oracle_User=" + txtUser.Text);
                SW.WriteLine("Oracle_Pass=" + txtPass.Text);
                SW.WriteLine("Oracle_LineNo=" + cbxLineNo.Text);

                SW.WriteLine("Oracle_AddProductID_YesNo=" + cbxChonYesNo.Text);
                SW.WriteLine("Oracle_AddProductName=" + txtMaAddManual.Text);
                SW.WriteLine("Oracle_AddAuto_Manual=" + (checkboxAutoManual.Checked).ToString());

                SW.WriteLine("[END]");
                SW.Close();
                FS.Close();
            }
            catch
            {
            }
        }



        public void SaveManualInput
         (
             TextBox txtKitu1,
             TextBox txtKitu2,
             TextBox numstart,
             TextBox Totalnum,
             TextBox numend,
             TextBox link,
             CheckBox SaveLog

          )
        {
            try
            {
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\ManualInputSetting.ini", FileMode.Create);
                StreamWriter SW = new StreamWriter(FS);

                SW.WriteLine("[ManualInput]");
                SW.WriteLine("MaKiTu1=" + txtKitu1.Text);
                SW.WriteLine("MaKiTu2=" + txtKitu2.Text);
                SW.WriteLine("NumberStart=" + numstart.Text);
                SW.WriteLine("TotalCode=" + Totalnum.Text);
                SW.WriteLine("NumberEnd=" + numend.Text);
                SW.WriteLine("Link=" + link.Text);
                SW.WriteLine("SaveLog=" + SaveLog.Checked.ToString());
                SW.WriteLine("[END]");
                SW.Close();
                FS.Close();
            }
            catch
            {
            }
        }




        public void SaveScannerSetting
            (
            TextBox IP_Scanner1,
            TextBox IP_Scanner2
            )
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\ScannerSetting.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[SCANNER_SETTING]");
                ProductionQtyWrite.WriteLine("Scanner_01_IP=" + IP_Scanner1.Text);
                ProductionQtyWrite.WriteLine("Scanner_02_IP=" + IP_Scanner2.Text);
                ProductionQtyWrite.WriteLine("[END]");
                ProductionQtyWrite.Close();
            }
        }


        public void Save_Log_Barcode
            (
            //TextBox linkFolderCode,
            CheckBox checkbox
            )
        {
            FileStream ProductionQty = new FileStream(Application.StartupPath + @"\DATA\LinkFolderSave.ini", FileMode.Create);

            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                ProductionQtyWrite.WriteLine("[SAVE_LOG_BARCODE]");
                //ProductionQtyWrite.WriteLine("FOLDER_LINK_ADD_CODE_JIG=" + linkFolderCode.Text);
                ProductionQtyWrite.WriteLine("SAVE_LOG=" + checkbox.Checked.ToString());
                ProductionQtyWrite.WriteLine("[END]");
                ProductionQtyWrite.Close();
            }
        }



        public void Load_Log_Barcode
            (
            //TextBox linkFolderCodeJig,
             CheckBox checkbox
            )
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\LinkFolderSave.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {
                        //case "FOLDER_LINK_ADD_CODE_JIG":
                        //    linkFolderCodeJig.Text = data[1];
                        //    break;
                        case "SAVE_LOG":
                            checkbox.Checked = bool.Parse(data[1]);
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


        public void Load_ManualInput
          (
           TextBox txtKitu1,
            TextBox txtKitu2,
            TextBox numstart,
            TextBox Totalnum,
            TextBox numend,
            TextBox link,
            CheckBox SaveLog
          )
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\ManualInputSetting.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {

                        case "MaKiTu1":
                            txtKitu1.Text = data[1];
                            break;
                        case "MaKiTu2":
                            txtKitu2.Text = data[1];
                            break;
                        case "NumberStart":
                            numstart.Text = data[1];
                            break;
                        case "TotalCode":
                            Totalnum.Text = data[1];
                            break;
                        case "NumberEnd":
                            numend.Text = data[1];
                            break;
                        case "Link":
                            link.Text = data[1];
                            break;
                        case "SaveLog":
                            SaveLog.Checked = bool.Parse(data[1]);
                            if (SaveLog.Checked)
                            {
                                SaveLog.ForeColor = Color.Blue;
                            }
                            else
                            {
                                SaveLog.ForeColor = Color.Red;
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
        }



        public void LoadDevivePLC
         (
         TextBox txtCurrentPos,
         TextBox txtScanning,
         TextBox txtReadCodeJigOK,
         TextBox txtReadCodeJigNG,
         TextBox txtReadPcmOK,
         TextBox txtReadPcmNG,
         TextBox txtScanDone,
         TextBox txtReadTotalOK,
         TextBox txtReadTotalNG,
         TextBox txtStopMachine,
         TextBox txtCycletime,
         TextBox txtDelayNornal,
         TextBox txtDelayNG
         )
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\DevicePLC_Config.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {
                        case "CurrenPossition":
                            txtCurrentPos.Text = data[1];
                            break;
                        case "Scanning":
                            txtScanning.Text = data[1];
                            break;
                        case "Read_Code_Jig_OK":
                            txtReadCodeJigOK.Text = data[1];
                            break;
                        case "Read_Code_Jig_NG":
                            txtReadCodeJigNG.Text = data[1];
                            break;
                        case "Read_PCM_OK":
                            txtReadPcmOK.Text = data[1];
                            break;
                        case "Read_PCM_NG":
                            txtReadPcmNG.Text = data[1];
                            break;
                        case "Scan_Done":
                            txtScanDone.Text = data[1];
                            break;
                        case "Total_Read_OK":
                            txtReadTotalOK.Text = data[1];
                            break;
                        case "Total_Read_NG":
                            txtReadTotalNG.Text = data[1];
                            break;
                        case "Stop_Machine":
                            txtStopMachine.Text = data[1];
                            break;
                        case "Cycle_time":
                            txtCycletime.Text = data[1];
                            break;
                        case "Delay_Normal":
                            txtDelayNornal.Text = data[1];
                            break;
                        case "Delay_NG":
                            txtDelayNG.Text = data[1];
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



        public void LoadOracleSetting
     (
     TextBox txtSource,
      TextBox txtUser,
      TextBox txtPass,
      ComboBox cbxLineNo,
      ComboBox cbxChonYesNo,
      TextBox txtMaAddManual,
      CheckBox checkboxAutoManual

     )
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\OracleSetting.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {
                        case "Oracle_DBsource":
                            txtSource.Text = data[1];
                            break;
                        case "Oracle_User":
                            txtUser.Text = data[1];
                            break;
                        case "Oracle_Pass":
                            txtPass.Text = data[1];
                            break;
                        case "Oracle_LineNo":
                            cbxLineNo.Text = data[1];
                            break;

                        case "Oracle_AddProductID_YesNo":
                            cbxChonYesNo.Text = data[1];
                            break;

                        case "Oracle_AddProductName":
                            txtMaAddManual.Text = data[1];
                            break;

                        case "Oracle_AddAuto_Manual":
                            checkboxAutoManual.Checked = bool.Parse(data[1]);
                            if (checkboxAutoManual.Checked == true)
                            {
                                checkboxAutoManual.Text = "AUTO";
                                checkboxAutoManual.ForeColor = Color.Blue;
                            }
                            else
                            {
                                checkboxAutoManual.Text = "MANUAL";
                                checkboxAutoManual.ForeColor = Color.Yellow;
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
        }






      //  public void Load_Setting_Tach_Lot_Hang
      //(
      // TextBox txtViTriKiTuNam,
      // TextBox txtNam1,
      // TextBox txtNam2,
      // TextBox txtNam3,
      // TextBox txtNam4,
      // TextBox txtNam5,
      // TextBox txtNam6,
      // TextBox txtViTriKiTuThang,
      // TextBox txtThang1,
      // TextBox txtThang2,
      // TextBox txtThang3,
      // TextBox txtThang4,
      // TextBox txtThang5,
      // TextBox txtThang6,
      // TextBox txtThang7,
      // TextBox txtThang8,
      // TextBox txtThang9,
      // TextBox txtThang10,
      // TextBox txtThang11,
      // TextBox txtThang12,
      // TextBox txtyear_OK
      //)
      //  {
      //      try
      //      {
      //          string[] data = null;
      //          string str = "";
      //          FileStream FS = new FileStream(Application.StartupPath + @"\DATA\TachLotSeting.ini", FileMode.Open);
      //          StreamReader CounterRead = new StreamReader(FS);
      //          while (CounterRead.EndOfStream == false)
      //          {
      //              str = CounterRead.ReadLine();
      //              data = str.Split('=');





      //              switch (data[0])
      //              {
      //                  case "Vi_Tri_Ki_Tu_Nam":
      //                      txtViTriKiTuNam.Text = data[1];
      //                      break;
      //                  case "Mau_Nam_NG_1":
      //                      txtNam1.Text = data[1];
      //                      break;
      //                  case "Mau_Nam_NG_2":
      //                      txtNam2.Text = data[1];
      //                      break;
      //                  case "Mau_Nam_NG_3":
      //                      txtNam3.Text = data[1];
      //                      break;
      //                  case "Mau_Nam_NG_4":
      //                      txtNam4.Text = data[1];
      //                      break;
      //                  case "Mau_Nam_NG_5":
      //                      txtNam5.Text = data[1];
      //                      break;
      //                  case "Mau_Nam_NG_6":
      //                      txtNam6.Text = data[1];
      //                      break;
      //                  case "Vi_Tri_Ki_Tu_Thang":
      //                      txtViTriKiTuThang.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_1":
      //                      txtThang1.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_2":
      //                      txtThang2.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_3":
      //                      txtThang3.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_4":
      //                      txtThang4.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_5":
      //                      txtThang5.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_6":
      //                      txtThang6.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_7":
      //                      txtThang7.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_8":
      //                      txtThang8.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_9":
      //                      txtThang9.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_10":
      //                      txtThang10.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_11":
      //                      txtThang11.Text = data[1];
      //                      break;
      //                  case "Mau_Thang_NG_12":
      //                      txtThang12.Text = data[1];
      //                      break;
      //                  case "Nam_OK_Can_Tach_Theo_Thang":
      //                      txtyear_OK.Text = data[1];
      //                      break;

      //                  default:
      //                      break;




      //              }
      //          }
      //          CounterRead.Close();
      //          FS.Close();

      //      }
      //      catch
      //      {
      //      }
      //  }





        public void Load_Setting_Tach_Lot_Hang_Theo_Data
   (
    TextBox txtLink

   )
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\TachLotSetingTheoData.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');





                    switch (data[0])
                    {
                        case "Link_Data":
                            txtLink.Text = data[1];
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




        public void LoadScannerSettingConfig
           (
           TextBox IP_Scanner1,
            TextBox IP_Scanner2
           )
        {
            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(Application.StartupPath + @"\DATA\ScannerSetting.ini", FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();
                    data = str.Split('=');

                    switch (data[0])
                    {
                        case "Scanner_01_IP":
                            IP_Scanner1.Text = data[1];
                            break;
                        case "Scanner_02_IP":
                            IP_Scanner2.Text = data[1];
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




















        //public void Load_Data_Log(DataGridView dgv)
        //{
        //    string month = DateTime.Now.Month.ToString();
        //    string year = DateTime.Now.Year.ToString();
        //    string link_file = Application.StartupPath + @"\LOG\" + year + "" + month + "" + "_" + "Log.txt";

        //    try
        //    {
        //        string[] data = { DateTime.Now.ToString() + ", " + commend };
        //        File.AppendAllLines(link_file, data);
        //    }
        //    catch { }
        //}




















    }
}
