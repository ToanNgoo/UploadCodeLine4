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
    class clsModel
    {

        clshienthidata HienThiData = new clshienthidata();
        clsTable table = new clsTable();


            //public int X_ready = 0;
            //public int Y_ready = 0;
            //public int Ready_Speed = 0;
            //public int Ready_Delay = 0;
            //// Offset

            //public int X_offset = 0;
            //public int Y_offset = 0;
            //public int Offset_Speed = 0;
            //public int Offset_Delay = 0;
    







        // Tạo model
        public void TaoModel

            (          
            DataGridView dgv_sub,
            DataGridView dgv_Main,
            string duongdanluufile_tenfile, 
            // Array
            CheckBox use_array,
            CheckBox Kieu_Array_1,
            CheckBox Kieu_Array_2,
            CheckBox Kieu_Array_3,
            CheckBox Kieu_Array_4,   
            TextBox X_KC, 
            TextBox Y_KC, 
            TextBox X_AR, 
            TextBox Y_AR,           
            CheckBox khong_sap_xep_pcm,
            CheckBox sap_xep_tinh_tien,
            CheckBox sap_xep_zic_zac,
            // Read code jig pos
            TextBox X_ready,
            TextBox Y_ready,
            TextBox Ready_Speed,
            TextBox Ready_Delay,
            TextBox Chon_Scanner,
            // Offset
            TextBox X_offset,
            TextBox Y_offset,
            TextBox Offset_Speed,
            TextBox Offset_Delay,

            // Other
            CheckBox type_codejig_datetime,
            CheckBox type_codejig,
            TextBox linksave,

            // Tách lot - phân loại
            CheckBox TachTheoNgayThang,
            CheckBox TachTheoData,

            TextBox ViTriKiTuNam,
            TextBox MauKiTuNam1,
            TextBox MauKiTuNam2,
            TextBox MauKiTuNam3,
            TextBox MauKiTuNam4,
            TextBox MauKiTuNam5,
            TextBox MauKiTuNam6,

            TextBox ViTriKiTuThang,
            TextBox MauKiTuThang1,
            TextBox MauKiTuThang2,
            TextBox MauKiTuThang3,
            TextBox MauKiTuThang4,
            TextBox MauKiTuThang5,
            TextBox MauKiTuThang6,
            TextBox MauKiTuThang7,
            TextBox MauKiTuThang8,
            TextBox MauKiTuThang9,
            TextBox MauKiTuThang10,
            TextBox MauKiTuThang11,
            TextBox MauKiTuThang12,
            TextBox NamXetKiTuThang
           
           
            )
        {
            //FileStream ProductionQty = new FileStream(Application.StartupPath + @"\MODEL\Model1.ini", FileMode.Create);
            FileStream ProductionQty = new FileStream(duongdanluufile_tenfile, FileMode.Create);
            using (StreamWriter ProductionQtyWrite = new StreamWriter(ProductionQty))
            {
                // SUB POINT
                ProductionQtyWrite.WriteLine("[SUB_POINT]");
                try
                {
                    for (int i = 0; i < dgv_sub.Rows.Count - 1; i++)
                    {
                        dgv_sub.Rows[i].Cells[0].Value.ToString();
                        ProductionQtyWrite.WriteLine
                            (
                            dgv_sub.Rows[i].Cells[0].Value.ToString() + "," +
                            dgv_sub.Rows[i].Cells[1].Value.ToString() + "," +
                            dgv_sub.Rows[i].Cells[2].Value.ToString() + "," +
                            dgv_sub.Rows[i].Cells[3].Value.ToString() + "," +
                            dgv_sub.Rows[i].Cells[4].Value.ToString() + "," +
                            dgv_sub.Rows[i].Cells[5].Value.ToString() + "," +
                            dgv_sub.Rows[i].Cells[6].Value.ToString()
                            );
                    }
                }
                catch (NullReferenceException) { }         
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");


                // MAIN POINT
                ProductionQtyWrite.WriteLine("[MAIN_POINT]");
                try
                {
                    for (int i = 0; i < dgv_Main.Rows.Count - 1; i++)
                    {
                        dgv_Main.Rows[i].Cells[0].Value.ToString();

                        ProductionQtyWrite.WriteLine
                            (
                            dgv_Main.Rows[i].Cells[0].Value.ToString() + "," +
                            dgv_Main.Rows[i].Cells[1].Value.ToString() + "," +
                            dgv_Main.Rows[i].Cells[2].Value.ToString() + "," +
                            dgv_Main.Rows[i].Cells[3].Value.ToString() + "," +
                            dgv_Main.Rows[i].Cells[4].Value.ToString() + "," +
                            dgv_Main.Rows[i].Cells[5].Value.ToString() + "," +
                            dgv_Main.Rows[i].Cells[6].Value.ToString()
                            );
                    }
                }
                catch (NullReferenceException) { }             
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");


                // ARRAY SETTING
                ProductionQtyWrite.WriteLine("[ARRAY_SETTING]");
                ProductionQtyWrite.WriteLine("Use_Array=" + (use_array.Checked).ToString());
                ProductionQtyWrite.WriteLine("KhoangCach_X=" + X_KC.Text);
                ProductionQtyWrite.WriteLine("KhoangCach_Y=" + Y_KC.Text);
                ProductionQtyWrite.WriteLine("Array_X=" + X_AR.Text);
                ProductionQtyWrite.WriteLine("Array_Y=" + Y_AR.Text);               
                ProductionQtyWrite.WriteLine("Select_Mode_1=" + (Kieu_Array_1.Checked).ToString());
                ProductionQtyWrite.WriteLine("Select_Mode_2=" + (Kieu_Array_2.Checked).ToString());
                ProductionQtyWrite.WriteLine("Select_Mode_3=" + (Kieu_Array_3.Checked).ToString());
                ProductionQtyWrite.WriteLine("Select_Mode_4=" + (Kieu_Array_4.Checked).ToString());
                ProductionQtyWrite.WriteLine("Khong_Sap_Xep_So_PCM_Theo_Scanner=" + (khong_sap_xep_pcm.Checked).ToString());
                ProductionQtyWrite.WriteLine("Sap_Xep_So_PCM_Theo_Scanner_Kieu_Tinh_Tien=" + (sap_xep_tinh_tien.Checked).ToString());
                ProductionQtyWrite.WriteLine("Sap_Xep_So_PCM_Theo_Scanner_Kieu_Zic_Zac=" + (sap_xep_zic_zac.Checked).ToString());
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");


                // READ CODE JIG POS
                ProductionQtyWrite.WriteLine("[READ_CODE_JIG_POS]");
                ProductionQtyWrite.WriteLine("Ready_X=" + X_ready.Text);
                ProductionQtyWrite.WriteLine("Ready_Y=" + Y_ready.Text);
                ProductionQtyWrite.WriteLine("Ready_Speed=" + Ready_Speed.Text);
                ProductionQtyWrite.WriteLine("Ready_Delay=" + Ready_Delay.Text);
                ProductionQtyWrite.WriteLine("Scanner_Read=" + Chon_Scanner.Text);               
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");


                // CALIBRATION OFFSET
                ProductionQtyWrite.WriteLine("[CALIBRATION_OFFSET]");
                ProductionQtyWrite.WriteLine("Offset_X=" + X_offset.Text);
                ProductionQtyWrite.WriteLine("Offset_Y=" + Y_offset.Text);
                ProductionQtyWrite.WriteLine("Offset_speed=" + Offset_Speed.Text);
                ProductionQtyWrite.WriteLine("Offset_Delay=" + Offset_Delay.Text);
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");


                // ORTHER SETTING
                ProductionQtyWrite.WriteLine("[ORTHER_SETTING]");
                ProductionQtyWrite.WriteLine("Type_CodeJig_DateTime=" + type_codejig_datetime.Checked.ToString());  
                ProductionQtyWrite.WriteLine("Type_CodeJig_Only=" + type_codejig.Checked.ToString());
                ProductionQtyWrite.WriteLine("LinkSaveFile=" + linksave.Text); 
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");


                // TÁCH LOT PHÂN LOẠI
                ProductionQtyWrite.WriteLine("[TACH_LOT_PHAN_LOAI]");
                ProductionQtyWrite.WriteLine("TachTheoNgayThang=" + TachTheoNgayThang.Checked.ToString());
                ProductionQtyWrite.WriteLine("TachTheoFileData=" + TachTheoData.Checked.ToString());

                ProductionQtyWrite.WriteLine("ViTriKiTuNam=" + ViTriKiTuNam.Text);
                ProductionQtyWrite.WriteLine("Nam1=" + MauKiTuNam1.Text);
                ProductionQtyWrite.WriteLine("Nam2=" + MauKiTuNam2.Text);
                ProductionQtyWrite.WriteLine("Nam3=" + MauKiTuNam3.Text);
                ProductionQtyWrite.WriteLine("Nam4=" + MauKiTuNam4.Text);
                ProductionQtyWrite.WriteLine("Nam5=" + MauKiTuNam5.Text);
                ProductionQtyWrite.WriteLine("Nam6=" + MauKiTuNam6.Text);

                ProductionQtyWrite.WriteLine("ViTriKiTuThang=" + ViTriKiTuThang.Text);
                ProductionQtyWrite.WriteLine("Thang1=" + MauKiTuThang1.Text);
                ProductionQtyWrite.WriteLine("Thang2=" + MauKiTuThang2.Text);
                ProductionQtyWrite.WriteLine("Thang3=" + MauKiTuThang3.Text);
                ProductionQtyWrite.WriteLine("Thang4=" + MauKiTuThang4.Text);
                ProductionQtyWrite.WriteLine("Thang5=" + MauKiTuThang5.Text);
                ProductionQtyWrite.WriteLine("Thang6=" + MauKiTuThang6.Text);
                ProductionQtyWrite.WriteLine("Thang7=" + MauKiTuThang7.Text);
                ProductionQtyWrite.WriteLine("Thang8=" + MauKiTuThang8.Text);
                ProductionQtyWrite.WriteLine("Thang9=" + MauKiTuThang9.Text);
                ProductionQtyWrite.WriteLine("Thang10=" + MauKiTuThang10.Text);
                ProductionQtyWrite.WriteLine("Thang11=" + MauKiTuThang11.Text);
                ProductionQtyWrite.WriteLine("Thang12=" + MauKiTuThang12.Text);
                ProductionQtyWrite.WriteLine("NamKiemTra=" + NamXetKiTuThang.Text);
                

                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");


                // KET THUC
                ProductionQtyWrite.WriteLine("[END]");
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.WriteLine("");
                ProductionQtyWrite.Close();
            }
        }


        public void XoaPosTeaching(DataGridView dgv, TextBox txt)   // Xóa hàng datagridview
        {          
            
                try
                {
                    int row = int.Parse(txt.Text);
                    dgv.Rows.Remove(dgv.Rows[row-1]);
                }
                catch
                {

                }


            
        }



        public bool LOAD_MODEL
            (
            
            DataGridView dgv_sub,
            DataGridView dgv_Main,
            Label link_hien_thi,

            // Array
            CheckBox Use_array,
            CheckBox Kieu_Array_1,
            CheckBox Kieu_Array_2,
            CheckBox Kieu_Array_3,
            CheckBox Kieu_Array_4,   
            TextBox KhoangCach_X,
            TextBox KhoangCach_Y,
            TextBox X_array,
            TextBox Y_array,           
            CheckBox khong_sap_xep_pcm,
            CheckBox sap_xep_tinh_tien,
            CheckBox sap_xep_zic_zac,
            // Read code jig pos
            TextBox X_ready,
            TextBox Y_ready,
            TextBox Ready_Speed,
            TextBox Ready_Delay,
            TextBox Chon_Scanner, 
            // Offset

            TextBox X_offset,
            TextBox Y_offset,
            TextBox Offset_Speed,
            TextBox Offset_Delay,
            CheckBox type_codejig_datetime,
            CheckBox type_codejig,
            TextBox linksave,

            // Tách lot - phân loại
            CheckBox TachTheoNgayThang,
            CheckBox TachTheoData,

            TextBox ViTriKiTuNam,
            TextBox MauKiTuNam1,
            TextBox MauKiTuNam2,
            TextBox MauKiTuNam3,
            TextBox MauKiTuNam4,
            TextBox MauKiTuNam5,
            TextBox MauKiTuNam6,

            TextBox ViTriKiTuThang,
            TextBox MauKiTuThang1,
            TextBox MauKiTuThang2,
            TextBox MauKiTuThang3,
            TextBox MauKiTuThang4,
            TextBox MauKiTuThang5,
            TextBox MauKiTuThang6,
            TextBox MauKiTuThang7,
            TextBox MauKiTuThang8,
            TextBox MauKiTuThang9,
            TextBox MauKiTuThang10,
            TextBox MauKiTuThang11,
            TextBox MauKiTuThang12,
            TextBox NamXetKiTuThang
            
            
            )
        {        
            OpenFileDialog OpenFile = new OpenFileDialog();           
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                string FileNameModel;
                FileNameModel = OpenFile.FileName;
                link_hien_thi.Text = FileNameModel;
                link_hien_thi.ForeColor = Color.Blue;

                try
                {
                    string[] data = null;
                    string str = "";
                    FileStream FS = new FileStream(FileNameModel, FileMode.Open);
                    StreamReader CounterRead = new StreamReader(FS);
                    while (CounterRead.EndOfStream == false)
                    {
                        str = CounterRead.ReadLine();
                        data = str.Split('=');

                        switch (data[0])
                        {
                                
                                // Array
                            case "Use_Array":
                                Use_array.Checked = bool.Parse(data[1]);
                                break;
                            case "Select_Mode_1":
                                Kieu_Array_1.Checked = bool.Parse(data[1]);
                                break;
                            case "Select_Mode_2":
                                Kieu_Array_2.Checked = bool.Parse(data[1]);
                                break;
                            case "Select_Mode_3":
                                Kieu_Array_3.Checked = bool.Parse(data[1]);
                                break;
                            case "Select_Mode_4":
                                Kieu_Array_4.Checked = bool.Parse(data[1]);
                                break;                        
                            case "KhoangCach_X":
                                KhoangCach_X.Text = data[1].ToString();
                                break;
                            case "KhoangCach_Y":
                                KhoangCach_Y.Text = data[1].ToString();
                                break;
                            case "Array_X":
                                X_array.Text = data[1].ToString();
                                break;
                            case "Array_Y":
                                Y_array.Text = data[1].ToString();
                                break;
                            case "Khong_Sap_Xep_So_PCM_Theo_Scanner":
                                khong_sap_xep_pcm.Checked = bool.Parse(data[1].ToString());
                                break;
                            case "Sap_Xep_So_PCM_Theo_Scanner_Kieu_Tinh_Tien":
                                sap_xep_tinh_tien.Checked = bool.Parse(data[1].ToString());               
                                break;
                            case "Sap_Xep_So_PCM_Theo_Scanner_Kieu_Zic_Zac":
                                sap_xep_zic_zac.Checked = bool.Parse(data[1].ToString());
                                break;


                                
                                // Ready

                            case "Ready_X":
                                X_ready.Text = data[1].ToString();
                                break;
                            case "Ready_Y":
                                Y_ready.Text = data[1].ToString();
                                break;
                            case "Ready_Speed":
                                Ready_Speed.Text = data[1].ToString();
                                break;                           
                            case "Ready_Delay":
                                Ready_Delay.Text = data[1].ToString();
                                break;
                            case "Scanner_Read":
                                Chon_Scanner.Text = data[1].ToString();
                                break;
                                // Offset

                            case "Offset_X":
                                X_offset.Text = data[1].ToString();
                                break;
                            case "Offset_Y":
                                Y_offset.Text = data[1].ToString();
                                break;
                            case "Offset_speed":
                                Offset_Speed.Text = data[1].ToString();
                                break;
                            case "Offset_Delay":
                                Offset_Delay.Text = data[1].ToString();
                                break;
                            case "Type_CodeJig_DateTime":
                                type_codejig_datetime.Checked = bool.Parse(data[1].ToString());
                                break;
                            case "Type_CodeJig_Only":
                                type_codejig.Checked = bool.Parse(data[1].ToString());
                                break;
                            case "LinkSaveFile":
                                linksave.Text = data[1].ToString();
                                break;

                                // Tách lot phân loại

                            case "TachTheoNgayThang":
                                TachTheoNgayThang.Checked = bool.Parse(data[1].ToString());
                                if (TachTheoNgayThang.Checked)
                                {
                                    TachTheoNgayThang.ForeColor = Color.Blue;
                                    TachTheoNgayThang.Text = "ON";

                                }
                                else
                                {
                                    TachTheoNgayThang.ForeColor = Color.Red;
                                    TachTheoNgayThang.Text = "OFF";
                                }
                                break;
                            case "TachTheoFileData":
                                TachTheoData.Checked = bool.Parse(data[1].ToString());
                                if (TachTheoData.Checked)
                                {
                                    TachTheoData.ForeColor = Color.Blue;
                                    TachTheoData.Text = "ON";

                                }
                                else
                                {
                                    TachTheoData.ForeColor = Color.Red;
                                    TachTheoData.Text = "OFF";
                                }
                                break;

                            case "ViTriKiTuNam":
                                ViTriKiTuNam.Text = data[1].ToString();
                                break;
                            case "Nam1":
                                MauKiTuNam1.Text = data[1].ToString();
                                break;
                            case "Nam2":
                                MauKiTuNam2.Text = data[1].ToString();
                                break;
                            case "Nam3":
                                MauKiTuNam3.Text = data[1].ToString();
                                break;
                            case "Nam4":
                                MauKiTuNam4.Text = data[1].ToString();
                                break;
                            case "Nam5":
                                MauKiTuNam5.Text = data[1].ToString();
                                break;
                            case "Nam6":
                                MauKiTuNam6.Text = data[1].ToString();
                                break;

                            case "ViTriKiTuThang":
                                ViTriKiTuThang.Text = data[1].ToString();
                                break;
                            case "Thang1":
                                MauKiTuThang1.Text = data[1].ToString();
                                break;
                            case "Thang2":
                                MauKiTuThang2.Text = data[1].ToString();
                                break;
                            case "Thang3":
                                MauKiTuThang3.Text = data[1].ToString();
                                break;
                            case "Thang4":
                                MauKiTuThang4.Text = data[1].ToString();
                                break;
                            case "Thang5":
                                MauKiTuThang5.Text = data[1].ToString();
                                break;
                            case "Thang6":
                                MauKiTuThang6.Text = data[1].ToString();
                                break;
                            case "Thang7":
                                MauKiTuThang7.Text = data[1].ToString();
                                break;
                            case "Thang8":
                                MauKiTuThang8.Text = data[1].ToString();
                                break;
                            case "Thang9":
                                MauKiTuThang9.Text = data[1].ToString();
                                break;
                            case "Thang10":
                                MauKiTuThang10.Text = data[1].ToString();
                                break;
                            case "Thang11":
                                MauKiTuThang11.Text = data[1].ToString();
                                break;
                            case "Thang12":
                                MauKiTuThang12.Text = data[1].ToString();
                                break;
                            case "NamKiemTra":
                                NamXetKiTuThang.Text = data[1].ToString();
                                break;

 
                            default:
                                break;
                        }
                    }
                    CounterRead.Close();
                    FS.Close();
                    // Load sub program
                    HienThiData.hienthiFileTeaching(dgv_sub, table.Table_Sub_LoadTuFileModeltxt(FileNameModel));
                    // Load main program
                    HienThiData.hienthiFileTeaching(dgv_Main, table.Table_Main_LoadTuFileModeltxt(FileNameModel));

                    return true;
                }
                catch
                {
                    return false;
                }               
            }


            else
            {
                return false;
            }
        }






        public void OpenLastModel
            (
            DataGridView dgv,
            Label link_hien_thi,           
            CheckBox Use_array,
            CheckBox Mode_array,
            TextBox KhoangCach_X,
            TextBox KhoangCach_Y,
            TextBox X_array,
            TextBox Y_array,
            // Ready
            TextBox X_ready,
            TextBox Y_ready,
            TextBox Ready_Speed,
            TextBox Ready_Delay,
            // Offset
            TextBox X_offset,
            TextBox Y_offset,
            TextBox Offset_Speed,
            TextBox Offset_Delay,             
            string Type_Jig
            )
        {
            
                string FileNameModel;
                FileNameModel = link_hien_thi.Text;               

                try
                {
                    string[] data = null;
                    string str = "";
                    FileStream FS = new FileStream(FileNameModel, FileMode.Open);
                    StreamReader CounterRead = new StreamReader(FS);
                    while (CounterRead.EndOfStream == false)
                    {
                        str = CounterRead.ReadLine();
                        data = str.Split('=');

                        switch (data[0])
                        {
                            // Array
                            case "Use_Array":
                                Use_array.Checked = bool.Parse(data[1]);
                                break;
                            case "Select_Mode_Array":
                                Mode_array.Checked = bool.Parse(data[1]);
                                break;
                            case "KhoangCach_X":
                                KhoangCach_X.Text = data[1].ToString();
                                break;
                            case "KhoangCach_Y":
                                KhoangCach_Y.Text = data[1].ToString();
                                break;
                            case "Array_X":
                                X_array.Text = data[1].ToString();
                                break;
                            case "Array_Y":
                                Y_array.Text = data[1].ToString();
                                break;

                            // Ready

                            case "Ready_X":
                                X_ready.Text = data[1].ToString();
                                break;
                            case "Ready_Y":
                                Y_ready.Text = data[1].ToString();
                                break;
                            case "Ready_Speed":
                                Ready_Speed.Text = data[1].ToString();
                                break;
                            case "Ready_Delay":
                                Ready_Delay.Text = data[1].ToString();
                                break;
                            // Offset

                            case "Offset_X":
                                X_offset.Text = data[1].ToString();
                                break;
                            case "Offset_Y":
                                Y_offset.Text = data[1].ToString();
                                break;
                            case "Offset_speed":
                                Offset_Speed.Text = data[1].ToString();
                                break;
                            case "Offset_Delay":
                                Offset_Delay.Text = data[1].ToString();
                                break;

                            case "Format Jig":
                                Type_Jig = data[1];
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

                HienThiData.hienthiFileTeaching(dgv, table.Table_Sub_LoadTuFileModeltxt(FileNameModel));
            }


            
        























    }
}
