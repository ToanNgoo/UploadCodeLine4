//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using app = Microsoft.Office.Interop.Excel.Application;
using System.IO;

namespace CONTROL_ROBOT
{
    class clsTable
    {



        public DataTable NewTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("POS");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Speed");           
            table.Columns.Add("Delay");
            table.Columns.Add("Scanner1");
            table.Columns.Add("Scanner2");

            DataRow row = table.NewRow();
            row["POS"] = "1";
            row["X"] = "";
            row["Y"] = "";
            row["Speed"] = "20";
            row["Delay"] = "0";
            row["Scanner1"] = "OFF";
            row["Scanner2"] = "OFF";
            table.Rows.Add(row);

            return table;     
        }




        public DataTable Table_Sub_LoadTuFileModeltxt(string duongdanluufile_tenfile)
        {
                DataTable table = new DataTable();
                table.Columns.Add("POS");
                table.Columns.Add("X");
                table.Columns.Add("Y");
                table.Columns.Add("Speed");
                table.Columns.Add("Delay");
                table.Columns.Add("Scanner1");
                table.Columns.Add("Scanner2");
            try
            {
                string[] data = null;               
                data = File.ReadAllLines(duongdanluufile_tenfile);
                for (int i = 0; i < data.Length ; i++)
                {
                    string[] data_point = null;
                    if (data[i] == "[SUB_POINT]")
                    {
                        int j = 1;                       
                        while (true)
                        {
                            if (string.IsNullOrEmpty(data[i + 1]))
                            {
                                i = data.Length;
                                break;
                            }
                            else
                            {
                                data_point = data[i + 1].Split(',');
                                DataRow row = table.NewRow();
                                row["POS"] = j.ToString();
                                row["X"] = data_point[1];
                                row["Y"] = data_point[2];
                                row["Speed"] = data_point[3];
                                row["Delay"] = data_point[4];
                                row["Scanner1"] = data_point[5];
                                row["Scanner2"] = data_point[6];
                                table.Rows.Add(row);
                                i++;
                                j++;
                            }
                            
                        }
                    }
                }              
            }
            catch
            {
                MessageBox.Show("Load data thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return table;        
        }





        public DataTable Table_Main_LoadTuFileModeltxt(string duongdanluufile_tenfile)
        {
            DataTable table = new DataTable();
            table.Columns.Add("POS");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Speed");
            table.Columns.Add("Delay");
            table.Columns.Add("Scanner1");
            table.Columns.Add("Scanner2");
            try
            {
                string[] data = null;
                data = File.ReadAllLines(duongdanluufile_tenfile);
                for (int i = 0; i < data.Length; i++)
                {
                    string[] data_point = null;
                    if (data[i] == "[MAIN_POINT]")
                    {
                        int j = 1;
                        while (true)
                        {
                            if (string.IsNullOrEmpty(data[i + 1]))
                            {
                                i = data.Length;
                                break;
                            }
                            else
                            {
                                data_point = data[i + 1].Split(',');
                                DataRow row = table.NewRow();
                                row["POS"] = j.ToString();
                                row["X"] = data_point[1];
                                row["Y"] = data_point[2];
                                row["Speed"] = data_point[3];
                                row["Delay"] = data_point[4];
                                row["Scanner1"] = data_point[5];
                                row["Scanner2"] = data_point[6];
                                table.Rows.Add(row);
                                i++;
                                j++;
                            }

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Load data thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return table;
        }










        //  Nhân array ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public DataTable Table_Nhan_Array_Main_Add_OFFSET
            (
            DataGridView dgv_sub,
            int Kieu_Array, 
            int X_KhoangCach, 
            int Y_KhoangCach, 
            int x_array, 
            int y_array,
            int KieuSapXepPCM,
            // Add offset
            int offset_X,
            int offset_y,
            int speed_Servo,           
            int offset_Delay
        
         
            )

        {
            DataTable table = new DataTable();
            int TotalArray = x_array * y_array;

            table.Columns.Add("POS");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Speed");
            table.Columns.Add("Delay");
            table.Columns.Add("Scanner1");
            table.Columns.Add("Scanner2");

            // 111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
            if (Kieu_Array == 1)  // Kieu array 1 (mặc định)
            {
                try
                {
                    int pcm_sap_xep_tinh_tien = 0;
                    int Position = 1;
                    int he_so_sap_xep_zic_zac = 0;
                    for (int x = 0; x < x_array; x++)
                    {
                        he_so_sap_xep_zic_zac = x * 2;
                        for (int y = 0; y < y_array; y++)
                        {
                            for (int i = 0; i < dgv_sub.Rows.Count - 1; i++)
                            {
                                int pcm_sap_xep_zic_zac = 1;
                                DataRow row = table.NewRow();
                                row["POS"] = Position.ToString();
                                row["X"] = (int.Parse(dgv_sub.Rows[i].Cells[1].Value.ToString()) + (X_KhoangCach * x) + offset_X).ToString();
                                row["Y"] = (int.Parse(dgv_sub.Rows[i].Cells[2].Value.ToString()) + (Y_KhoangCach * y) + offset_y).ToString();
                                                                
                                // Nếu tốc độ nhỏ hơn 0 thì set  = 1
                                int speed = (int.Parse(dgv_sub.Rows[i].Cells[3].Value.ToString()) + speed_Servo);                               
                                if (speed > 0)
                                {
                                    row["Speed"] = speed.ToString();
                                }
                                else
                                {
                                    row["Speed"] = "1";
                                }                                
                                // Nếu Delay nhỏ hơn 0 thì set = 0
                                int Delay = (int.Parse(dgv_sub.Rows[i].Cells[4].Value.ToString()) + offset_Delay);
                                if (Delay >= 0)
                                {
                                    row["Delay"] = Delay.ToString();
                                }
                                else
                                {
                                    row["Delay"] = "0";
                                }                               
 
                                

                                #region Sắp xếp PCM theo scanner
                                // Không cần sắp xếp PCM
                                if (KieuSapXepPCM == 0)
                                {
                                    //row["Scanner1"] = dgv_sub.Rows[i].Cells[5].Value.ToString();
                                    //row["Scanner2"] = dgv_sub.Rows[i].Cells[6].Value.ToString();
                                }
                                // Sắp xếp kiểu tịnh tiến
                                if (KieuSapXepPCM == 1)
                                {
                                    row["Scanner1"] = (int.Parse(dgv_sub.Rows[i].Cells[5].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                    row["Scanner2"] = (int.Parse(dgv_sub.Rows[i].Cells[6].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                }
                                // Săp xếp kiểu zic zắc
                                if (KieuSapXepPCM == 2)
                                {
                                    row["Scanner1"] = (y_array * he_so_sap_xep_zic_zac + pcm_sap_xep_zic_zac + y).ToString();
                                    row["Scanner2"] = (y_array * (he_so_sap_xep_zic_zac + 1) + pcm_sap_xep_zic_zac + y).ToString();
                                }
                                table.Rows.Add(row);
                                Position++;
                                pcm_sap_xep_zic_zac++;
                                pcm_sap_xep_tinh_tien++;
                                #endregion
                            }
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Load data thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            // 22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222

            if (Kieu_Array == 2)  // Kieu array 2            
            {
                try
                {
                    int pcm_sap_xep_tinh_tien = 0;
                    int Position = 1;
                    int he_so_sap_xep_zic_zac = 0;
                    for (int y = 0; y < y_array; y++)
                    {
                        he_so_sap_xep_zic_zac = y * 2;
                        for (int x = 0; x < x_array; x++)
                        {
                            for (int i = 0; i < dgv_sub.Rows.Count - 1; i++)
                            {
                                int pcm_sap_xep_zic_zac = 1;
                                DataRow row = table.NewRow();
                                row["POS"] = Position.ToString();
                                row["X"] = (int.Parse(dgv_sub.Rows[i].Cells[1].Value.ToString()) + (X_KhoangCach * x) + offset_X).ToString();
                                row["Y"] = (int.Parse(dgv_sub.Rows[i].Cells[2].Value.ToString()) + (Y_KhoangCach * y) + offset_y).ToString();

                                // Nếu tốc độ nhỏ hơn 0 thì set  = 1
                                int speed = (int.Parse(dgv_sub.Rows[i].Cells[3].Value.ToString()) + speed_Servo);
                                if (speed > 0)
                                {
                                    row["Speed"] = speed.ToString();
                                }
                                else
                                {
                                    row["Speed"] = "1";
                                }
                                // Nếu Delay nhỏ hơn 0 thì set = 0
                                int Delay = (int.Parse(dgv_sub.Rows[i].Cells[4].Value.ToString()) + offset_Delay);
                                if (Delay >= 0)
                                {
                                    row["Delay"] = Delay.ToString();
                                }
                                else
                                {
                                    row["Delay"] = "0";
                                }


                                #region Sắp xếp PCM theo scanner
                                // Không cần sắp xếp PCM
                                if (KieuSapXepPCM == 0)
                                {
                                    //row["Scanner1"] = dgv_sub.Rows[i].Cells[5].Value.ToString();
                                    //row["Scanner2"] = dgv_sub.Rows[i].Cells[6].Value.ToString();
                                }
                                // Sắp xếp kiểu tịnh tiến
                                if (KieuSapXepPCM == 1)
                                {
                                    row["Scanner1"] = (int.Parse(dgv_sub.Rows[i].Cells[5].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                    row["Scanner2"] = (int.Parse(dgv_sub.Rows[i].Cells[6].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                }
                                // Săp xếp kiểu zic zắc
                                if (KieuSapXepPCM == 2)
                                {
                                    row["Scanner1"] = (x_array * he_so_sap_xep_zic_zac + pcm_sap_xep_zic_zac + x).ToString();
                                    row["Scanner2"] = (x_array * (he_so_sap_xep_zic_zac + 1) + pcm_sap_xep_zic_zac + x).ToString();
                                }
                                table.Rows.Add(row);
                                Position++;
                                pcm_sap_xep_zic_zac++;
                                pcm_sap_xep_tinh_tien++;
                                #endregion

                            }
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Load data thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            //333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333

            if (Kieu_Array == 3)  // Kieu array 3            
            {
                
                try
                {
                    int pcm_sap_xep_tinh_tien = 0;
                    int Position = 1;
                    int he_so_sap_xep_zic_zac = 0;
                    for (int x = 0; x < x_array; x++)
                    {
                        he_so_sap_xep_zic_zac = x * 2;
                        for (int y = 0; y < y_array; y++)
                        {
                            for (int i = 0; i < dgv_sub.Rows.Count - 1; i++)
                            {
                                int pcm_sap_xep_zic_zac = 1;
                                DataRow row = table.NewRow();
                                row["POS"] = Position.ToString();
                                row["X"] = (int.Parse(dgv_sub.Rows[i].Cells[1].Value.ToString()) + (X_KhoangCach * x) + offset_X).ToString();
                                row["Y"] = (int.Parse(dgv_sub.Rows[i].Cells[2].Value.ToString()) - (Y_KhoangCach * y) + offset_y).ToString();
                                                                
                                // Nếu tốc độ nhỏ hơn 0 thì set  = 1
                                int speed = (int.Parse(dgv_sub.Rows[i].Cells[3].Value.ToString()) + speed_Servo);                               
                                if (speed > 0)
                                {
                                    row["Speed"] = speed.ToString();
                                }
                                else
                                {
                                    row["Speed"] = "1";
                                }                                
                                // Nếu Delay nhỏ hơn 0 thì set = 0
                                int Delay = (int.Parse(dgv_sub.Rows[i].Cells[4].Value.ToString()) + offset_Delay);
                                if (Delay >= 0)
                                {
                                    row["Delay"] = Delay.ToString();
                                }
                                else
                                {
                                    row["Delay"] = "0";
                                }


                                #region Sắp xếp PCM theo scanner
                                // Không cần sắp xếp PCM
                                if (KieuSapXepPCM == 0)
                                {
                                    //row["Scanner1"] = dgv_sub.Rows[i].Cells[5].Value.ToString();
                                    //row["Scanner2"] = dgv_sub.Rows[i].Cells[6].Value.ToString();
                                }
                                // Sắp xếp kiểu tịnh tiến
                                if (KieuSapXepPCM == 1)
                                {
                                    row["Scanner1"] = (int.Parse(dgv_sub.Rows[i].Cells[5].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                    row["Scanner2"] = (int.Parse(dgv_sub.Rows[i].Cells[6].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                }
                                // Săp xếp kiểu zic zắc
                                if (KieuSapXepPCM == 2)
                                {
                                    row["Scanner1"] = (y_array * he_so_sap_xep_zic_zac + pcm_sap_xep_zic_zac + y).ToString();
                                    row["Scanner2"] = (y_array * (he_so_sap_xep_zic_zac + 1) + pcm_sap_xep_zic_zac + y).ToString();
                                }
                                table.Rows.Add(row);
                                Position++;
                                pcm_sap_xep_zic_zac++;
                                pcm_sap_xep_tinh_tien++;
                                #endregion
                              
                            }                            
                        }                        
                    }
                }
                catch
                {
                    //MessageBox.Show("Load data thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }


            //444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444

            if (Kieu_Array == 4)  // Kieu array 4          
            {
                try
                {
                    int pcm_sap_xep_tinh_tien = 0;
                    int Position = 1;
                    int he_so_sap_xep_zic_zac = 0;
                   for (int y = 0; y < y_array; y++)                    
                    {
                        he_so_sap_xep_zic_zac = y * 2;
                        for (int x = 0; x < x_array; x++)
                        {
                            for (int i = 0; i < dgv_sub.Rows.Count - 1; i++)
                            {
                                int pcm_sap_xep_zic_zac = 1;
                                DataRow row = table.NewRow();
                                row["POS"] = Position.ToString();
                                row["X"] = (int.Parse(dgv_sub.Rows[i].Cells[1].Value.ToString()) + (X_KhoangCach * x) + offset_X).ToString();
                                row["Y"] = (int.Parse(dgv_sub.Rows[i].Cells[2].Value.ToString()) - (Y_KhoangCach * y) + offset_y).ToString();
                                                                
                                // Nếu tốc độ nhỏ hơn 0 thì set  = 1
                                int speed = (int.Parse(dgv_sub.Rows[i].Cells[3].Value.ToString()) + speed_Servo);                               
                                if (speed > 0)
                                {
                                    row["Speed"] = speed.ToString();
                                }
                                else
                                {
                                    row["Speed"] = "1";
                                }                                
                                // Nếu Delay nhỏ hơn 0 thì set = 0
                                int Delay = (int.Parse(dgv_sub.Rows[i].Cells[4].Value.ToString()) + offset_Delay);
                                if (Delay >= 0)
                                {
                                    row["Delay"] = Delay.ToString();
                                }
                                else
                                {
                                    row["Delay"] = "0";
                                }                               
 
                              
                                #region Sắp xếp PCM theo scanner
                                // Không cần sắp xếp PCM
                                if (KieuSapXepPCM == 0)
                                {
                                    //row["Scanner1"] = dgv_sub.Rows[i].Cells[5].Value.ToString();
                                    //row["Scanner2"] = dgv_sub.Rows[i].Cells[6].Value.ToString();
                                }
                                // Sắp xếp kiểu tịnh tiến
                                if (KieuSapXepPCM == 1)
                                {
                                    row["Scanner1"] = (int.Parse(dgv_sub.Rows[i].Cells[5].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                    row["Scanner2"] = (int.Parse(dgv_sub.Rows[i].Cells[6].Value.ToString()) + pcm_sap_xep_tinh_tien).ToString();
                                }
                                // Săp xếp kiểu zic zắc
                                if (KieuSapXepPCM == 2)
                                {
                                    row["Scanner1"] = (x_array * he_so_sap_xep_zic_zac + pcm_sap_xep_zic_zac + x).ToString();
                                    row["Scanner2"] = (x_array * (he_so_sap_xep_zic_zac + 1) + pcm_sap_xep_zic_zac + x).ToString();
                                }
                                table.Rows.Add(row);
                                Position++;
                                pcm_sap_xep_zic_zac++;
                                pcm_sap_xep_tinh_tien++;
                                #endregion
                            }
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Load data thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }



            return table;
        } // END


































        public DataTable Table_dgvTeaching(DataGridView dgv)
        {
            DataTable table = new DataTable();

            table.Columns.Add("POS");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Speed");
            table.Columns.Add("Delay");
            table.Columns.Add("Scanner1");
            table.Columns.Add("Scanner2");

            try
            {
                int Position = 1;

                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {                  
                    DataRow row = table.NewRow();
                   
                    row["POS"] = Position.ToString();
                    row["X"] = dgv.Rows[i].Cells[1].Value.ToString();
                    row["Y"] = dgv.Rows[i].Cells[2].Value.ToString();
                    row["Speed"] = dgv.Rows[i].Cells[3].Value.ToString();
                    row["Delay"] = dgv.Rows[i].Cells[4].Value.ToString();
                    row["Scanner1"] = dgv.Rows[i].Cells[5].Value.ToString();
                    row["Scanner2"] = dgv.Rows[i].Cells[6].Value.ToString();
                    table.Rows.Add(row);
                    Position++;

                }
              

            }
            catch
            {
                MessageBox.Show("Load data thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return table;
        }


        public DataTable Table_Add_New_Row(DataGridView dgv)
        {
            DataTable table = new DataTable();

            table.Columns.Add("POS");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Speed");
            table.Columns.Add("Delay");
            table.Columns.Add("Scanner1");
            table.Columns.Add("Scanner2");

            
            try
            {
                int Position = 1;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    // Tạo hàng mới data trống ở cuối
                    DataRow row = table.NewRow();
                    if (i > dgv.Rows.Count - 2)
                    {
                        row["POS"] = Position.ToString();
                        row["X"] = "";
                        row["Y"] = "";
                        row["Speed"] = "20";
                        row["Delay"] = "0";
                        row["Scanner1"] = "";
                        row["Scanner2"] = "";
                        table.Rows.Add(row);
                        Position++;
                    }
                    else
                    {
                        // 
                        row["POS"] = Position.ToString();
                        row["X"] = dgv.Rows[i].Cells[1].Value.ToString();
                        row["Y"] = dgv.Rows[i].Cells[2].Value.ToString();
                        row["Speed"] = dgv.Rows[i].Cells[3].Value.ToString();
                        row["Delay"] = dgv.Rows[i].Cells[4].Value.ToString();
                        row["Scanner1"] = dgv.Rows[i].Cells[5].Value.ToString();
                        row["Scanner2"] = dgv.Rows[i].Cells[6].Value.ToString();
                        table.Rows.Add(row);
                        Position++;
                    }


                }


            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return table;
        }

        public DataTable Table_Insert_Row(DataGridView dgv, TextBox txt)
        {
            DataTable table = new DataTable();

            table.Columns.Add("POS");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Speed");
            table.Columns.Add("Delay");
            table.Columns.Add("Scanner1");
            table.Columns.Add("Scanner2");

            try
            {
                int Position = 1;
                int DiemInsert = (int.Parse(txt.Text)) - 1;
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    //DataRow row = table.NewRow();
                    DataRow row;
                    if (i >= DiemInsert) 
                    {
                        if (i == DiemInsert)  // Tại điểm insert
                        {
                            // Load data dòng hiện tại
                            row = table.NewRow();
                            row["POS"] = Position.ToString();
                            row["X"] = dgv.Rows[i].Cells[1].Value.ToString();
                            row["Y"] = dgv.Rows[i].Cells[2].Value.ToString();
                            row["Speed"] = dgv.Rows[i].Cells[3].Value.ToString();
                            row["Delay"] = dgv.Rows[i].Cells[4].Value.ToString();
                            row["Scanner1"] = dgv.Rows[i].Cells[5].Value.ToString();
                            row["Scanner2"] = dgv.Rows[i].Cells[6].Value.ToString();
                            table.Rows.Add(row);
                            Position++;
                         
                            // Tạo 1 dòng mới giống dòng hiện tại (insert)
                            row = table.NewRow();
                            row["POS"] = Position.ToString();
                            row["X"] = dgv.Rows[i].Cells[1].Value.ToString();
                            row["Y"] = dgv.Rows[i].Cells[2].Value.ToString();
                            row["Speed"] = dgv.Rows[i].Cells[3].Value.ToString();
                            row["Delay"] = dgv.Rows[i].Cells[4].Value.ToString();
                            row["Scanner1"] = dgv.Rows[i].Cells[5].Value.ToString();
                            row["Scanner2"] = dgv.Rows[i].Cells[6].Value.ToString();
                            table.Rows.Add(row);
                            Position++;

                        }

                        if (i > DiemInsert)
                        {
                            row = table.NewRow();
                            row["POS"] = Position.ToString();
                            row["X"] = dgv.Rows[i].Cells[1].Value.ToString();
                            row["Y"] = dgv.Rows[i].Cells[2].Value.ToString();
                            row["Speed"] = dgv.Rows[i].Cells[3].Value.ToString();
                            row["Delay"] = dgv.Rows[i].Cells[4].Value.ToString();
                            row["Scanner1"] = dgv.Rows[i].Cells[5].Value.ToString();
                            row["Scanner2"] = dgv.Rows[i].Cells[6].Value.ToString();
                            table.Rows.Add(row);
                            Position++;
                        } 
                    }
                    else
                    {
                        row = table.NewRow();
                        row["POS"] = Position.ToString();
                        row["X"] = dgv.Rows[i].Cells[1].Value.ToString();
                        row["Y"] = dgv.Rows[i].Cells[2].Value.ToString();
                        row["Speed"] = dgv.Rows[i].Cells[3].Value.ToString();
                        row["Delay"] = dgv.Rows[i].Cells[4].Value.ToString();
                        row["Scanner1"] = dgv.Rows[i].Cells[5].Value.ToString();
                        row["Scanner2"] = dgv.Rows[i].Cells[6].Value.ToString();
                        table.Rows.Add(row);
                        Position++;
                    }


                }


            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return table;
        }





        public DataTable LOG_FILE(string link_file)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Time");
            table.Columns.Add("Commend");


            try
            {
                string[] data = null;
                string str = "";
                FileStream FS = new FileStream(link_file, FileMode.Open);
                StreamReader CounterRead = new StreamReader(FS);

                int i = 0;            
                while (CounterRead.EndOfStream == false)
                {
                    str = CounterRead.ReadLine();

                        data = str.Split(',');
                        DataRow row = table.NewRow();
                        row["Time"] = data[0];
                        row["Commend"] = data[1];
                        table.Rows.Add(row);
                        i++;
                   
                }
                CounterRead.Close();
                FS.Close();

            }
            catch
            {
                //MessageBox.Show("Load lịch sử machine thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


           

            return table;
        }
















    }
}
