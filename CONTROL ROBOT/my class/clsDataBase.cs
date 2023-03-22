using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using app = Microsoft.Office.Interop.Excel.Application;

namespace CONTROL_ROBOT
{
   public class clsdatabase
    {

       public int autoID;
       public string UserName = "Chưa đăng nhập";

        #region Ban đầu có
       string constr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + Application.StartupPath + @"\Database.mdb";
        public bool checkConection()
        {
            OleDbConnection cnn = new OleDbConnection(constr);
            try
            {
                cnn.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
            }
        }
        public int login(string sql) // Hàm đăng nhập dùng Sql
        {
            OleDbConnection cnn = new OleDbConnection(constr);
            OleDbCommand cmd;
            OleDbDataAdapter da;
            DataTable dt;
            int maxrow = 0;
            try
            {
                cnn.Open();
                cmd = new OleDbCommand();
                da = new OleDbDataAdapter();
                dt = new DataTable();
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
                maxrow = dt.Rows.Count;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                cnn.Dispose();
                cnn.Close();
            }
            return maxrow;
        }
        public DataTable Receivedata(string str)
        {
            DataTable dt1 = new DataTable();
            try
            {                
                OleDbDataAdapter da = new OleDbDataAdapter(str, constr);
                da.Fill(dt1);
                return dt1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt1;
            }
            
        }
  
       
        public string getData(string st) // hàm lấy data từ sql
        {
            int i = 0;
            DataTable dt = new DataTable();
            dt = Receivedata(st);
            i = dt.Rows.Count;
            string[] new_str = new string[i];
            int j = 0;
            foreach (DataRow dr in dt.Rows)
            { 
                new_str[j] = dr.ItemArray[0].ToString();
                j++;
            }
            string str_re = new_str[0];
            return str_re;
        }
       
        
  

        public void inSertdata(DataGridView dgv, string cmd)
        {
            OleDbConnection cnn = new OleDbConnection(constr);
            try
            {
                cnn.Open();
                OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(cmd, cnn);
                DataSet Excel = new DataSet();
                da.Fill(Excel);
                dgv.DataSource = Excel.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error connection data :" + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnn.Close();
        }

        public void exportToExcel(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++) { obj.Cells[1, i] = g.Columns[i - 1].HeaderText; }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null) { obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }


       #endregion


        // Đoạn này cho quản lý Account

        #region   Quản lý  Account

        public void AddAccount(int ID) // ham thêm dữ liệu vào database
        {
            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {
                cnn.Open(); //mở kết nối               
                string str = "INSERT INTO Account VALUES (" + ID + ",'','','','','')";
                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                cmd.ExecuteNonQuery(); // thực hiện lênh SQL                      
                cnn.Close(); // Ngắt kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại \r\n" + ex.Message,"Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        public void EditAccount(DataGridView dgv) // ham thêm dữ liệu vào database
        {
            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {

                cnn.Open(); //mở kết nối   
                //string str = "Update Account set Account.User='" + User.Text + "', Account.Password='" + Pass.Text + "',Account.Name='" + Name.Text + "',Account.Mobile='" + Mobile.Text + "' where ID =" + int.Parse(ID.Text) + "";
                string str = "Update Account set Account.User='" 
                    + dgv.CurrentRow.Cells[1].Value.ToString() 
                    + "', Account.Password='" 
                    + dgv.CurrentRow.Cells[2].Value.ToString() 
                    + "',Account.Name='" 
                    + dgv.CurrentRow.Cells[3].Value.ToString() 
                    + "',Account.Mobile='" 
                    + dgv.CurrentRow.Cells[4].Value.ToString() 
                    + "',Account.Level='" 
                    + dgv.CurrentRow.Cells[5].Value.ToString() 
                    + "' where ID =" 
                    + int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()) + "";
                //string str = "UPDATE Account set Account.Password('" + Pass.Text + "')";// "','" + Name.Text + "','" + Mobile.Text + "')";
                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                //cmd.ExecuteNonQuery(); // thực hiện lênh SQL
                int result = (int)cmd.ExecuteNonQuery();
                if (result > 0)
                {

                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cnn.Close(); // Ngắt kết nối


            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void deleteData(DataGridView dgv) // hàm xóa data trong sql
        {
             DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string sql_delete = "DELETE FROM Account where ID =" + dgv.CurrentRow.Cells[0].Value.ToString() + "";
                    OleDbConnection cnn = new OleDbConnection(constr);
                    cnn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql_delete, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch
                {

                }
            }
            
        }

        public bool UserAccountCheck(DataGridView dgv, string user) // hàm kiểm tra User trong Account xem có chưa
        {
            OleDbConnection cnn = new OleDbConnection(constr);
            cnn.Open();
            string sql = "SELECT User from Account where ID =" + dgv.CurrentRow.Cells[0].Value.ToString() + "";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);
            cnn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                if (user == dr.ItemArray[0].ToString())
                {
                    MessageBox.Show("User đã tồn tại, hãy chọn User khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;



          
        }
       

        public void saveTableAccount(DataTable dt)
        {
            OleDbConnection cnn = new OleDbConnection(constr);
            cnn.Open();
            try
            {
                foreach (DataRow dr in dt.GetChanges().Rows)
                {               
                    string str = "Update Account set Account.User='" 
                        + dr.ItemArray[1] + "', Account.Password='" 
                        + dr.ItemArray[2] + "',Account.Name='" 
                        + dr.ItemArray[3] + "',Account.Mobile='"
                        + dr.ItemArray[4] + "',Account.Level='" 
                        + dr.ItemArray[5] + "' where ID =" 
                        + dr.ItemArray[0] + "";
                    OleDbCommand cmd = new OleDbCommand(str, cnn);
                    cmd.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi !");
            }
        }


        public string GetUserNameAccount(TextBox txtUser)
        {
            string sql = "SELECT *FROM [Account] WHERE ((Account.[User])='" + txtUser.Text + "')";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            foreach (DataRow dr in dt.Rows)
            {
                UserName = dr.ItemArray[3].ToString();
            }           
            return "";
        }

        public string CheckLevelAccount(TextBox txtUser)
        {
            string sql1 = "SELECT *FROM [Account] WHERE ((Account.[User])='" + txtUser.Text + "')";
            DataTable dt1 = new DataTable();
            dt1 = Receivedata(sql1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                return  dr1.ItemArray[5].ToString();
            }
            return "";
        }






        public DataTable tableAccountList()
        {
            string str = "select * from Account";
            return Receivedata(str); // đổ dữ liệu vào bảng
        }











        #endregion





        

        #region  Quản lý kho


        public DataTable tableKhoHang(TextBox txtTimKiem, RadioButton rdioNhom, RadioButton rdioLoai, RadioButton rdioTen)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                string str = "select * from KhoHang";
                return Receivedata(str); // đổ dữ liệu vào bảng
            }
            else
            {
                if (rdioNhom.Checked)
                {
                    string str = "select * from KhoHang WHERE NhomHang = '"+txtTimKiem.Text+"'";
                    return Receivedata(str); // đổ dữ liệu vào bảng
                }
                if (rdioLoai.Checked)
                {
                    string str = "select * from KhoHang WHERE LoaiHang = '" + txtTimKiem.Text + "'";
                    return Receivedata(str); // đổ dữ liệu vào bảng
                }
                if (rdioTen.Checked)
                {
                    string str = "select * from KhoHang WHERE TenHang = '" + txtTimKiem.Text + "'";
                    return Receivedata(str); // đổ dữ liệu vào bảng
                }
                
            }

            string str1 = "select * from KhoHang";
            return Receivedata(str1); // đổ dữ liệu vào bảng
        }

        public void ThemTableKhoHang(int ID,ComboBox cbx1,ComboBox cbx2, TextBox txt3, TextBox txt4, TextBox txt5, TextBox txt6, TextBox txt7,ComboBox txt8,TextBox txt9, TextBox txt10,TextBox txt11 ) // ham thêm dữ liệu vào database
        {
           
            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {
                cnn.Open(); //mở kết nối               
                string str = "INSERT INTO KhoHang VALUES (" 
                    + ID + ",'" 
                    + cbx1.Text + "','" 
                    + cbx2.Text + "','" 
                    + txt3.Text + "','" 
                    + txt4.Text + "','" 
                    + txt5.Text + "','" 
                    + txt6.Text + "','" 
                    + double.Parse((txt7.Text).Replace(",","")) + "','"
                    + txt8.Text + "','"
                    + double.Parse((txt9.Text).Replace(",", "")) + "','"
                    + double.Parse((txt10.Text).Replace(",", "")) + "','" 
                    + txt11.Text + "')";
                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                cmd.ExecuteNonQuery(); // thực hiện lênh SQL                      
                cnn.Close(); // Ngắt kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public void ThemTableHangXuat(int ID, TextBox txt1, TextBox txt2, TextBox txt3, TextBox txt4, TextBox txt5, TextBox txt6, TextBox txt7, TextBox txt8, TextBox txt9, TextBox txt10, TextBox txt11, TextBox txt12, int MaHoaDon) // ham thêm dữ liệu vào database
        {

            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {
                cnn.Open(); //mở kết nối               
                string str = "INSERT INTO XuatHang VALUES ("
                    + ID + ",'"
                    + txt1.Text + "','"
                    + txt2.Text + "','"
                    + txt3.Text + "','"
                    + txt4.Text + "','"
                    + double.Parse((txt5.Text).Replace(",", "")) + "','"
                    + txt6.Text + "','"
                    + double.Parse((txt7.Text).Replace(",", "")) + "','"
                    + double.Parse((txt8.Text).Replace(",", "")) + "','"
                    + double.Parse((txt9.Text).Replace(",", "")) + "','"
                    + double.Parse((txt10.Text).Replace(",", "")) + "','"
                    + double.Parse((txt11.Text).Replace(",", "")) + "','"
                    + txt12.Text + "','"
                    + MaHoaDon + "')";
                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                cmd.ExecuteNonQuery(); // thực hiện lênh SQL                      
                cnn.Close(); // Ngắt kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public void SuaTableHangXuat(TextBox txt0, TextBox txt1, TextBox txt2, TextBox txt3, TextBox txt4, TextBox txt5, TextBox txt6, TextBox txt7, TextBox txt8, TextBox txt9, TextBox txt10, TextBox txt11,TextBox txt12,int MaHoaDon) // ham thêm dữ liệu vào database
        {

            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {
                cnn.Open(); //mở kết nối               
                string str = "Update XuatHang set XuatHang.NhomHang='"
                   + txt1.Text
                   + "',XuatHang.LoaiHang='" + txt2.Text
                   + "',XuatHang.TenHang='" + txt3.Text
                   + "',XuatHang.KiHieuHang='" + txt4.Text
                   + "',XuatHang.SoLuongHang='" + (txt5.Text).Replace(",", "")
                    + "',XuatHang.DonVi='" + txt6.Text
                   + "',XuatHang.DonGiaHangNhap='" + (txt7.Text).Replace(",", "")
                   + "',XuatHang.DonGiaHangXuat='" + (txt8.Text).Replace(",", "")
                   + "',XuatHang.SoLuongXuat='" + (txt9.Text).Replace(",", "")
                   + "',XuatHang.GiaTriDonHang='" + (txt10.Text).Replace(",", "")
                   + "',XuatHang.KhoanLai='" + (txt11.Text).Replace(",", "")
                   + "',XuatHang.NgayXuat='" + txt12.Text
                   + "',XuatHang.MaHoaDon='" + MaHoaDon
                   + "' where ID =" + int.Parse(txt0.Text)
                   + "";
                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                cmd.ExecuteNonQuery(); // thực hiện lênh SQL                      
                cnn.Close(); // Ngắt kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }







        public DataTable tableHangXuat()
        {
            string str = "select * from XuatHang";
            return Receivedata(str); // đổ dữ liệu vào bảng
        }




        public bool AddItemComboBox(string cbxnumber,string tableName,ComboBox cbx)
        {

            cbx.Items.Clear();
            string sql = "SELECT " + cbxnumber + " from " + tableName + "";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[0].ToString() !="")
                {
                    cbx.Items.Add(dr.ItemArray[0].ToString());  
                }
                      
            }
            return true;
        }





        public void SuaHangXuat(DataGridView dgv) // ham thêm dữ liệu vào database
        {
            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {

                cnn.Open(); //mở kết nối                
                string str = "Update XuatHang set XuatHang.NhomHang='" 
                    + dgv.CurrentRow.Cells[1].Value.ToString()
                    + "',XuatHang.LoaiHang='" + dgv.CurrentRow.Cells[2].Value.ToString()
                    + "',XuatHang.TenHang='" + dgv.CurrentRow.Cells[3].Value.ToString()
                    + "',XuatHang.KiHieuHang='" + dgv.CurrentRow.Cells[4].Value.ToString()
                    + "',XuatHang.SoLuongHang='" + dgv.CurrentRow.Cells[5].Value.ToString()
                    + "',XuatHang.DonGiaHangNhap='" + dgv.CurrentRow.Cells[6].Value.ToString()
                    + "',XuatHang.DonGiaHangXuat='" + dgv.CurrentRow.Cells[7].Value.ToString()
                    + "',XuatHang.SoLuongXuat='" + dgv.CurrentRow.Cells[8].Value.ToString()
                    + "',XuatHang.GiaTriDonHang='" + dgv.CurrentRow.Cells[9].Value.ToString()
                    + "',XuatHang.KhoanLai='" + dgv.CurrentRow.Cells[10].Value.ToString()
                    + "',XuatHang.NgayXuat='" + dgv.CurrentRow.Cells[11].Value.ToString()
                    + "' where ID =" + int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()) 
                    + "";
                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                //cmd.ExecuteNonQuery(); // thực hiện lênh SQL
                int result = (int)cmd.ExecuteNonQuery();
                if (result > 0)
                {

                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cnn.Close(); // Ngắt kết nối


            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }






        public bool KiemTraIDXuatHang(DataGridView dgv, string ID) // kiem tra xem co ID nay chua
        {
           
            string sql = "SELECT ID from XuatHang";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);
            
            foreach (DataRow dr in dt.Rows)
            {
                if (ID == dr.ItemArray[0].ToString())
                {
                    MessageBox.Show(" ID hàng đã tồn tại trong danh sách \r\n hãy chọn ID hàng khác để xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;

        }


        public void deleteDataXuat(DataGridView dgv) // hàm xóa data trong sql
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa mục đã chọn", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
               try
               {
                   string sql_delete = "DELETE FROM XuatHang where ID =" + dgv.CurrentRow.Cells[0].Value.ToString() + "";
                   OleDbConnection cnn = new OleDbConnection(constr);
                   cnn.Open();
                   OleDbCommand cmd = new OleDbCommand(sql_delete, cnn);
                   cmd.ExecuteNonQuery();
                   cnn.Close();
               }
                catch
               {

               }
                
            }
            
        }

        public void TaoBanXuatMoi(DataGridView dgv) // hàm xóa data trong sql
        {
           
                string sql_delete = "DELETE FROM XuatHang";
                OleDbConnection cnn = new OleDbConnection(constr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand(sql_delete, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
          

        }



        public bool LoadDataXuatHang(string ID,TextBox txt1, TextBox txt2, TextBox txt3, TextBox txt4, TextBox txt5, TextBox txt6,TextBox txt7) // 
        {
            
           
                string sql = "SELECT * from KhoHang where ID = " + ID + "";
                DataTable dt = new DataTable();
                dt = Receivedata(sql);
              
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txt1.Text = dr.ItemArray[1].ToString();
                        txt2.Text = dr.ItemArray[2].ToString();
                        txt3.Text = dr.ItemArray[3].ToString();
                        txt4.Text = dr.ItemArray[4].ToString();
                        txt5.Text = dr.ItemArray[7].ToString();
                        txt6.Text = dr.ItemArray[8].ToString();
                        txt7.Text = dr.ItemArray[9].ToString();
                        
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show(" ID hàng không tồn tại trong kho hàng của bạn \r\n hãy chọn ID hàng khác để xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            
               
        }






        public bool XuatKho(ComboBox cbxCachGiaoHang, TextBox txtTen, TextBox txtDiaChi, TextBox txtSDT, ComboBox cbxMaHoaDon, TextBox txtMaKhachHang,TextBox txtTienHang, TextBox txtGiamGia, TextBox txtPhiVanChuyen, TextBox txtDieuChinhThemBot, TextBox txtDatCoc,TextBox txtTongTien )
        {
            int ID;
            double TonKho;
           
 
            string sql = "SELECT * from XuatHang";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                        

                    ID = int.Parse(dr.ItemArray[0].ToString());
                    TonKho = (double.Parse(dr.ItemArray[5].ToString()) - double.Parse(dr.ItemArray[9].ToString()));
                    cbxMaHoaDon.Text = (int.Parse(dr.ItemArray[13].ToString())).ToString();



                    OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn




                    try
                    {

                        cnn.Open(); //mở kết nối   



                        #region Out hàng trong kho

                        string sql1 = "Update KhoHang set KhoHang.SoLuongHang='"
                            + TonKho.ToString() + "' where ID =" + ID.ToString() + "";
                        OleDbCommand cmd1 = new OleDbCommand(sql1, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                        //cmd1.ExecuteNonQuery(); // thực hiện lênh SQL
                        int result1 = (int)cmd1.ExecuteNonQuery();
                        if (result1 > 0)
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Out kho thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        #endregion


                         #region Xuất ra danh sách hóa đơn


                      

                        string sql2 = "INSERT INTO HoaDon VALUES ("
                        + int.Parse(dr.ItemArray[13].ToString()) + ",'Thu Nguyễn','0977768058','Khu công nghiệp Quế Võ','19035078075014','Techcombank','"
                        + txtTen.Text + "','"
                        + txtDiaChi.Text + "','"
                        + txtSDT.Text + "','"
                        + cbxCachGiaoHang.Text + "','"
                        + int.Parse(dr.ItemArray[0].ToString()) + "','"
                        + dr.ItemArray[1].ToString() + "','"
                        + dr.ItemArray[2].ToString() + "','"
                        + dr.ItemArray[3].ToString() + "','"
                        + double.Parse(dr.ItemArray[9].ToString()) + "','"
                        + dr.ItemArray[6].ToString() + "','"
                        + double.Parse(dr.ItemArray[8].ToString()) + "','"
                        + double.Parse(dr.ItemArray[10].ToString()) + "','"
                        + dr.ItemArray[12].ToString() + "','"
                        + double.Parse(txtTienHang.Text.Replace(",", "")) + "','"
                        + double.Parse(txtGiamGia.Text.Replace(",", "")) + "','"
                        + double.Parse(txtPhiVanChuyen.Text.Replace(",", "")) + "','"
                        + double.Parse(txtDieuChinhThemBot.Text.Replace(",", "")) + "','"
                        + double.Parse(txtDatCoc.Text.Replace(",", "")) + "','"
                        + (double.Parse((txtTongTien.Text).Replace(",", "")) - double.Parse((txtDatCoc.Text).Replace(",", ""))) + "','"
                        + double.Parse(dr.ItemArray[7].ToString()) + "','"
                        + (double.Parse(dr.ItemArray[10].ToString()) - ((double.Parse(txtGiamGia.Text.Replace(",", "")) * double.Parse(dr.ItemArray[10].ToString()))/100)) + "','"
                        + ((double.Parse(dr.ItemArray[10].ToString()) - ((double.Parse(txtGiamGia.Text.Replace(",", "")) * double.Parse(dr.ItemArray[10].ToString())) / 100)) - (double.Parse(dr.ItemArray[7].ToString()) * double.Parse(dr.ItemArray[9].ToString()))) + "')";



                        OleDbCommand cmd2 = new OleDbCommand(sql2, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                        //cmd2.ExecuteNonQuery(); // thực hiện lênh SQL
                        int result2 = (int)cmd2.ExecuteNonQuery();
                        if (result2 > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Xuất hóa đơn thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                          



                        #endregion


                         #region Lưu lịch sử xuất

                        string sql4 = "INSERT INTO LichSuXuat VALUES ("
                       + int.Parse(dr.ItemArray[0].ToString()) + ",'"
                       + dr.ItemArray[1].ToString() + "','"
                       + dr.ItemArray[2].ToString() + "','"
                       + dr.ItemArray[3].ToString() + "','"
                       + dr.ItemArray[4].ToString() + "',"                      
                       + double.Parse(dr.ItemArray[5].ToString()) + ",'"
                       + dr.ItemArray[6].ToString() + "',"
                       + double.Parse(dr.ItemArray[7].ToString()) + ","
                       + double.Parse(dr.ItemArray[8].ToString()) + ","
                       + double.Parse(dr.ItemArray[9].ToString()) + ","
                       + double.Parse(dr.ItemArray[10].ToString()) + ","
                       + double.Parse(dr.ItemArray[11].ToString()) + ",'"
                       + dr.ItemArray[12].ToString() + "','"
                       + txtTen.Text + "','"
                       + cbxCachGiaoHang.Text + "')";                                        
                        OleDbCommand cmd4 = new OleDbCommand(sql4,cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                        //cmd2.ExecuteNonQuery(); // thực hiện lênh SQL
                        int result4 = (int)cmd4.ExecuteNonQuery();
                        if (result4 > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Lưu lịch sử xuất thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }



                        #endregion

  
                        #region Xuất ra doanh số

                        string sql5 = "INSERT INTO DoanhSo VALUES ("
                       + int.Parse(dr.ItemArray[0].ToString()) + ",'"
                       + dr.ItemArray[12].ToString().Substring(0,4) + "','"
                       + dr.ItemArray[12].ToString().Substring(4,2) + "','"
                       + dr.ItemArray[12].ToString().Substring(6,2) + "',"
                       + (double.Parse(dr.ItemArray[10].ToString()) - ((double.Parse(txtGiamGia.Text.Replace(",", "")) * double.Parse(dr.ItemArray[10].ToString())) / 100)) + ","
                       + ((double.Parse(dr.ItemArray[10].ToString()) - ((double.Parse(txtGiamGia.Text.Replace(",", "")) * double.Parse(dr.ItemArray[10].ToString())) / 100)) - (double.Parse(dr.ItemArray[7].ToString()) * double.Parse(dr.ItemArray[9].ToString()))) + ")";

                        

                        OleDbCommand cmd5 = new OleDbCommand(sql5, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                        //cmd2.ExecuteNonQuery(); // thực hiện lênh SQL
                        int result5 = (int)cmd5.ExecuteNonQuery();
                        if (result5 > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Lưu doanh số thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        






                        #endregion





                        #region
                        #endregion

                        cnn.Close(); // Ngắt kết nối                       
                    }
                    
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xẩy ra, có thất thoát thông tin. \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }   


                }
                
                return true;
            
            }
            else
            {
                MessageBox.Show(" Chưa có mã hàng nào để xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                
        }

        








        public bool LayTongGTvaTongLai(TextBox txtTienHang, TextBox txtGiamGia, TextBox txtPhiVanChuyen, TextBox txtDieuChinhThemBot, TextBox txtDatCoc, TextBox txtKhoanLaiThuc, TextBox txtTongGiaTriDonHang) // 
        {
            double KhoanLaiHang = 0;
            double TienHang = 0;
            double GiamGiaPhanTram = 0;
            double PhiVanChuyen = 0;
            double DieuChinhThemBot = 0;
            double DatCoc = 0;
            double KhoanLaiThuc = 0;
            double TongGiaTriDonHang = 0;

            double TienHangSauGiamGia = 0;
            try
            {
                string sql = "SELECT GiaTriDonHang,KhoanLai from XuatHang";
                DataTable dt = new DataTable();
                dt = Receivedata(sql);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        TienHang = TienHang + double.Parse(dr.ItemArray[0].ToString());
                        KhoanLaiHang = KhoanLaiHang + double.Parse(dr.ItemArray[1].ToString());
                    }

                }


                GiamGiaPhanTram = double.Parse(txtGiamGia.Text);
                PhiVanChuyen = double.Parse(txtPhiVanChuyen.Text);
                DieuChinhThemBot = double.Parse(txtDieuChinhThemBot.Text);
                DatCoc = double.Parse(txtDatCoc.Text);


                TienHangSauGiamGia = TienHang - (TienHang * GiamGiaPhanTram) / double.Parse("100");
                TongGiaTriDonHang = TienHangSauGiamGia + PhiVanChuyen + DieuChinhThemBot;
                KhoanLaiThuc = KhoanLaiHang + DieuChinhThemBot - ((TienHang * GiamGiaPhanTram) / double.Parse("100"));
            }
           catch
            {
                
            }

            txtTienHang.Text = TienHang.ToString();
            txtTongGiaTriDonHang.Text = TongGiaTriDonHang.ToString();
            txtKhoanLaiThuc.Text = KhoanLaiThuc.ToString();




           
            return true;
        }



        public void deleteDataKhoHang(DataGridView dgv) // hàm xóa data trong sql
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa mục đã chọn", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string sql_delete = "DELETE FROM KhoHang where ID =" + dgv.CurrentRow.Cells[0].Value.ToString() + "";
                    OleDbConnection cnn = new OleDbConnection(constr);
                    cnn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql_delete, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch
                {

                }

            }

        }

        public void XoaHangTonKhoVeKhong(DataGridView dgv) // hàm xóa data trong sql khi tồn kho = 0
        {


            string sql_delete = "DELETE FROM KhoHang where SoLuongHang = 0";
                OleDbConnection cnn = new OleDbConnection(constr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand(sql_delete, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();

            // sau khi xóa hàng stock = 0 , chuyển thông tin vừa xóa vào lịch sử hàng đã hết



            
        }
       






        public void EditKhoHang(DataGridView dgv) // ham thêm dữ liệu vào database
        {
            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {

                cnn.Open(); //mở kết nối   
                string str = "Update KhoHang set KhoHang.NhomHang='"
                    + dgv.CurrentRow.Cells[1].Value.ToString() 
                    + "',KhoHang.LoaiHang='" + dgv.CurrentRow.Cells[2].Value.ToString() 
                    + "',KhoHang.TenHang='" + dgv.CurrentRow.Cells[3].Value.ToString() 
                    + "',KhoHang.KiHieuHang='" + dgv.CurrentRow.Cells[4].Value.ToString()
                    + "',KhoHang.NhaCungCap='" + dgv.CurrentRow.Cells[5].Value.ToString()
                    + "',KhoHang.ViTriHang='" + dgv.CurrentRow.Cells[6].Value.ToString()
                    + "',KhoHang.SoLuongHang='" + dgv.CurrentRow.Cells[7].Value.ToString()
                    + "',KhoHang.DonVi='" + dgv.CurrentRow.Cells[8].Value.ToString()
                    + "',KhoHang.DonGiaHang='" + dgv.CurrentRow.Cells[9].Value.ToString()
                    + "',KhoHang.TongGiaHang=" + double.Parse(dgv.CurrentRow.Cells[7].Value.ToString()) * double.Parse(dgv.CurrentRow.Cells[9].Value.ToString())
                    + ",KhoHang.NgayNhapKho='" + dgv.CurrentRow.Cells[11].Value.ToString() 
                    + "' where ID =" + int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()) 
                    + "";
                
                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                //cmd.ExecuteNonQuery(); // thực hiện lênh SQL
                int result = (int)cmd.ExecuteNonQuery();
                if (result > 0)
                {

                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cnn.Close(); // Ngắt kết nối


            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }





        public bool CapNhatKhoHang(DataGridView dgv)
        {
           
            //double TongTien = 0;
           
            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            cnn.Open(); //mở kết nối 
 
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    //TongTien = (double.Parse(dgv.Rows[i].Cells[7].Value.ToString())) * (double.Parse(dgv.Rows[i].Cells[9].Value.ToString()));
                    

                    try
                    {

                        
                        string str = "Update KhoHang set KhoHang.NhomHang='"
                            + dgv.Rows[i].Cells[1].Value.ToString()
                            + "',KhoHang.LoaiHang='" + dgv.Rows[i].Cells[2].Value.ToString()
                            + "',KhoHang.TenHang='" + dgv.Rows[i].Cells[3].Value.ToString()
                            + "',KhoHang.KiHieuHang='" + dgv.Rows[i].Cells[4].Value.ToString()
                            + "',KhoHang.NhaCungCap='" + dgv.Rows[i].Cells[5].Value.ToString()
                            + "',KhoHang.ViTriHang='" + dgv.Rows[i].Cells[6].Value.ToString()
                            + "',KhoHang.SoLuongHang='" + dgv.Rows[i].Cells[7].Value.ToString()
                            + "',KhoHang.DonVi='" + dgv.Rows[i].Cells[8].Value.ToString()
                            + "',KhoHang.DonGiaHang='" + dgv.Rows[i].Cells[9].Value.ToString()
                            + "',KhoHang.TongGiaHang=" + double.Parse(dgv.Rows[i].Cells[7].Value.ToString()) * double.Parse(dgv.Rows[i].Cells[9].Value.ToString())
                            + ",KhoHang.NgayNhapKho='" + dgv.Rows[i].Cells[11].Value.ToString()
                            + "' where ID =" + int.Parse(dgv.Rows[i].Cells[0].Value.ToString())
                            + "";

                        OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                        //cmd.ExecuteNonQuery(); // thực hiện lênh SQL
                        int result = (int)cmd.ExecuteNonQuery();
                        if (result > 0)
                        {

                        }
                        else
                        {
                            
                            
                            MessageBox.Show("Cập nhật kho thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cnn.Close(); // Ngắt kết nối
                            return false;
                        
                        
                        }
                       


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xẩy ra khi cập nhật kho hàng \r\n", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cnn.Close(); // Ngắt kết nối
                        return false;
                    }

                }
                cnn.Close(); // Ngắt kết nối
           
  
            return true;
        }



























        #endregion

     









        #region Hóa đơn


        public DataTable tableHangTrongHoaDon(ComboBox cbxMaHoaDon)
        {
            string str = "select IDHangBan,TenHangBan,SoLuongHangBan,DonVi,DonGiaHangBan,ThanhTien from HoaDon where MaHoaDon = "+int.Parse(cbxMaHoaDon.Text)+"";
            return Receivedata(str); // đổ dữ liệu vào bảng
        }

        public DataTable HoaDon(TextBox txtTimKiem, RadioButton rdioNgayXuat, RadioButton rdioMaHoaDon, RadioButton rdioTenBenMua, ComboBox cbxThang,ComboBox cbxNam)
        {

            


            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                string str = "select * from HoaDon ORDER by MaHoaDon DESC";
                return Receivedata(str); // đổ dữ liệu vào bảng
            }
            else
            {
                if (rdioNgayXuat.Checked)
                {
                    string str = "select * from HoaDon WHERE NgayXuat = '" + txtTimKiem.Text + "' ORDER by MaHoaDon DESC ";
                    return Receivedata(str); // đổ dữ liệu vào bảng
                }
                if (rdioMaHoaDon.Checked)
                {
                    string str = "select * from HoaDon WHERE MaHoaDon = " + int.Parse(txtTimKiem.Text) + " ORDER by MaHoaDon DESC ";
                    return Receivedata(str); // đổ dữ liệu vào bảng
                }
                if (rdioTenBenMua.Checked)
                {
                     if (string.IsNullOrEmpty(cbxThang.Text))
                     {
                         string str = "select * from HoaDon WHERE TenBenMua = '" + txtTimKiem.Text + "'  ORDER by MaHoaDon DESC ";
                         return Receivedata(str); // đổ dữ liệu vào bảng
                     }
                     else
                     {
                         string str = "select * from HoaDon WHERE TenBenMua = '" + txtTimKiem.Text + "' AND NgayXuat BETWEEN '" + cbxNam.Text + "" + cbxThang.Text + "01' AND '" + cbxNam.Text + "" + cbxThang.Text + "31' ORDER by MaHoaDon DESC ";
                         return Receivedata(str); // đổ dữ liệu vào bảng
                     }
                    
                }

            }

            string str1 = "select * from HoaDon ORDER by MaHoaDon DESC";
            return Receivedata(str1); // đổ dữ liệu vào bảng
        }






        public bool LayDataTongHoaDon(TextBox txtSoMatHang, TextBox txtTongTien,TextBox txtTongLai, DataGridView dgv)
        {
            int SoMatHang = 0;
            double TongTien = 0;
            double TongLai = 0;


            try
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    TongTien += double.Parse(dgv.Rows[i].Cells[24].Value.ToString());
                    TongLai += double.Parse(dgv.Rows[i].Cells[25].Value.ToString());
                    SoMatHang = dgv.Rows.Count - 1;
                }
            }
            catch
            {
                //MessageBox.Show("Có lỗi xẩy ra hàm LayDataTongHoaDon \r\n", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


            txtSoMatHang.Text = SoMatHang.ToString();
            txtTongTien.Text = TongTien.ToString();
            txtTongLai.Text = TongLai.ToString();
            return true;
        }









        public bool LayThongTinChoHoaDon(ComboBox cbxMaHoaDon, Label lblTen, Label lblDiaChi, Label lblSoDT, Label lblPhuongThucThanhToan, TextBox txtTotalprice, Label lblNgay, TextBox txtTienHang, TextBox txtGiamGia, TextBox txtPhiVanChuyen, TextBox txtDieuChinhThembot, TextBox txtDatCoc, TextBox txtTongTienThanhToan) // 
        {
            
            string sql = "select TenBenMua,DiaChiBenMua,SoDienThoaiBenMua,HinhThucThanhToan,ThanhTien,NgayXuat,TienHangTheoMaHoaDon,GiamGiaTheoMaHoaDon,PhiVanChuyenTheoMaHoaDon,DieuChinhThemBotTheoMaHoaDon,DatCocTheoMaHoaDon,TongTienTheoHoaDon from HoaDon where MaHoaDon = " + int.Parse(cbxMaHoaDon.Text) + "";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {                                      
                    try
                    {
                        lblNgay.Text = dr.ItemArray[5].ToString();
                        lblTen.Text = dr.ItemArray[0].ToString();
                        lblDiaChi.Text = dr.ItemArray[1].ToString();
                        lblSoDT.Text = dr.ItemArray[2].ToString();
                        lblPhuongThucThanhToan.Text = dr.ItemArray[3].ToString();
                        txtTienHang.Text = dr.ItemArray[6].ToString();
                        txtGiamGia.Text = dr.ItemArray[7].ToString();
                        txtPhiVanChuyen.Text = dr.ItemArray[8].ToString();
                        txtDieuChinhThembot.Text = dr.ItemArray[9].ToString();
                        txtDatCoc.Text = dr.ItemArray[10].ToString();
                        txtTongTienThanhToan.Text = dr.ItemArray[11].ToString(); 
                     
                    }
                    catch
                    {

                    }
                    return true;
                }

            }            
            return true;
        }





        public void XoaHoaDon(DataGridView dgv) // hàm xóa data trong sql
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa mục đã chọn", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string sql_delete = "DELETE FROM HoaDon where MaHoaDon =" + dgv.CurrentRow.Cells[1].Value.ToString() + "";
                    OleDbConnection cnn = new OleDbConnection(constr);
                    cnn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql_delete, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
               catch
                {

                }

            }

        }





        public void CurrentMaHoaDon(DataGridView dgv, ComboBox cbxMaHoaDon) // hàm xóa data trong sql
        {
            cbxMaHoaDon.Text = dgv.CurrentRow.Cells[1].Value.ToString();                            
        }

        






















        #endregion








        #region Add item combobox


  

        public int LayMaIDCuaCombobox(ComboBox cbx) // hàm kiểm tra Mã ID của table combobox
        {
            OleDbConnection cnn = new OleDbConnection(constr);
            cnn.Open();
            string sql = "SELECT ID from ItemComboBox where NhomHang ='" + cbx.Text + "'";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);
            cnn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                return int.Parse(dr.ItemArray[0].ToString());
            }
            return 1;
        }



        public DataTable tableNhomHang()
        {
            string str = "select ID,NhomHang from ItemComboBox ORDER BY ID";
            return Receivedata(str); // đổ dữ liệu vào bảng                                 
        }

        public DataTable tableDonVi()
        {
            string str = "select ID,DonVi from ItemComboBox ORDER BY ID";
            return Receivedata(str); // đổ dữ liệu vào bảng                                 
        }

        public DataTable tableLoaiHang(int STT)
        {
            string str = "select ID,LoaiHang"+STT+" from ItemComboBox ORDER BY ID";
            return Receivedata(str); // đổ dữ liệu vào bảng                                 
        }



        public void SuaNhomLoaiDonVi(string TenCotSua,DataGridView dgv) // ham thêm dữ liệu vào database
        {
            OleDbConnection cnn = new OleDbConnection(constr);//khai báo và khởi tạo biến cnn
            try
            {

                cnn.Open(); //mở kết nối                 
                string str = "Update ItemComboBox set ItemComboBox."+TenCotSua+" ='"
                    + dgv.CurrentRow.Cells[1].Value.ToString() 
                    + "' where ID =" 
                    + int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()) + "";

                OleDbCommand cmd = new OleDbCommand(str, cnn); // Khai báo và khởi tạo bộ nhớ biến cmd
                //cmd.ExecuteNonQuery(); // thực hiện lênh SQL
                int result = (int)cmd.ExecuteNonQuery();
                if (result > 0)
                {

                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cnn.Close(); // Ngắt kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại \r\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


















        #endregion





































        public int AutoNumberID(string sql)
        {
            autoID = 0;
            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            foreach (DataRow dr in dt.Rows)
            {
                autoID = int.Parse(dr.ItemArray[0].ToString());
            }
            return autoID + 1;
        }


















    }
}
