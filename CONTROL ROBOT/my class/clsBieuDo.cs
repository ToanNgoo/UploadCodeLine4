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
    class clsbieudo
    {


        #region Biến biểu đồ Top 10 sản phẩm trên Main


        public string TenTop1 = "";
        public string TenTop2 = "";
        public string TenTop3 = "";
        public string TenTop4 = "";
        public string TenTop5 = "";
        public string TenTop6 = "";
        public string TenTop7 = "";
        public string TenTop8 = "";
        public string TenTop9 = "";
        public string TenTop10 = "";


        public double TienTop1 = 0;
        public double TienTop2 = 0;
        public double TienTop3 = 0;
        public double TienTop4 = 0;
        public double TienTop5 = 0;
        public double TienTop6 = 0;
        public double TienTop7 = 0;
        public double TienTop8 = 0;
        public double TienTop9 = 0;
        public double TienTop10 = 0;

        #endregion


        #region Biến biểu đồ doanh thu hàng ngày
        public double clsN1ThuNhap = 0;
        public double clsN2ThuNhap = 0;
        public double clsN3ThuNhap = 0;
        public double clsN4ThuNhap = 0;
        public double clsN5ThuNhap = 0;
        public double clsN6ThuNhap = 0;
        public double clsN7ThuNhap = 0;
        public double clsN8ThuNhap = 0;
        public double clsN9ThuNhap = 0;
        public double clsN10ThuNhap = 0;
        public double clsN11ThuNhap = 0;
        public double clsN12ThuNhap = 0;
        public double clsN13ThuNhap = 0;
        public double clsN14ThuNhap = 0;
        public double clsN15ThuNhap = 0;
        public double clsN16ThuNhap = 0;
        public double clsN17ThuNhap = 0;
        public double clsN18ThuNhap = 0;
        public double clsN19ThuNhap = 0;
        public double clsN20ThuNhap = 0;
        public double clsN21ThuNhap = 0;
        public double clsN22ThuNhap = 0;
        public double clsN23ThuNhap = 0;
        public double clsN24ThuNhap = 0;
        public double clsN25ThuNhap = 0;
        public double clsN26ThuNhap = 0;
        public double clsN27ThuNhap = 0;
        public double clsN28ThuNhap = 0;
        public double clsN29ThuNhap = 0;
        public double clsN30ThuNhap = 0;
        public double clsN31ThuNhap = 0;


        public double clsN1Lai = 0;
        public double clsN2Lai = 0;
        public double clsN3Lai = 0;
        public double clsN4Lai = 0;
        public double clsN5Lai = 0;
        public double clsN6Lai = 0;
        public double clsN7Lai = 0;
        public double clsN8Lai = 0;
        public double clsN9Lai = 0;
        public double clsN10Lai = 0;
        public double clsN11Lai = 0;
        public double clsN12Lai = 0;
        public double clsN13Lai = 0;
        public double clsN14Lai = 0;
        public double clsN15Lai = 0;
        public double clsN16Lai = 0;
        public double clsN17Lai = 0;
        public double clsN18Lai = 0;
        public double clsN19Lai = 0;
        public double clsN20Lai = 0;
        public double clsN21Lai = 0;
        public double clsN22Lai = 0;
        public double clsN23Lai = 0;
        public double clsN24Lai = 0;
        public double clsN25Lai = 0;
        public double clsN26Lai = 0;
        public double clsN27Lai = 0;
        public double clsN28Lai = 0;
        public double clsN29Lai = 0;
        public double clsN30Lai = 0;
        public double clsN31Lai = 0;






        void resetDataBieuDoDoanhThu()
        {
            clsN1ThuNhap = 0;
            clsN2ThuNhap = 0;
            clsN3ThuNhap = 0;
            clsN4ThuNhap = 0;
            clsN5ThuNhap = 0;
            clsN6ThuNhap = 0;
            clsN7ThuNhap = 0;
            clsN8ThuNhap = 0;
            clsN9ThuNhap = 0;
            clsN10ThuNhap = 0;
            clsN11ThuNhap = 0;
            clsN12ThuNhap = 0;
            clsN13ThuNhap = 0;
            clsN14ThuNhap = 0;
            clsN15ThuNhap = 0;
            clsN16ThuNhap = 0;
            clsN17ThuNhap = 0;
            clsN18ThuNhap = 0;
            clsN19ThuNhap = 0;
            clsN20ThuNhap = 0;
            clsN21ThuNhap = 0;
            clsN22ThuNhap = 0;
            clsN23ThuNhap = 0;
            clsN24ThuNhap = 0;
            clsN25ThuNhap = 0;
            clsN26ThuNhap = 0;
            clsN27ThuNhap = 0;
            clsN28ThuNhap = 0;
            clsN29ThuNhap = 0;
            clsN30ThuNhap = 0;
            clsN31ThuNhap = 0;


            clsN1Lai = 0;
            clsN2Lai = 0;
            clsN3Lai = 0;
            clsN4Lai = 0;
            clsN5Lai = 0;
            clsN6Lai = 0;
            clsN7Lai = 0;
            clsN8Lai = 0;
            clsN9Lai = 0;
            clsN10Lai = 0;
            clsN11Lai = 0;
            clsN12Lai = 0;
            clsN13Lai = 0;
            clsN14Lai = 0;
            clsN15Lai = 0;
            clsN16Lai = 0;
            clsN17Lai = 0;
            clsN18Lai = 0;
            clsN19Lai = 0;
            clsN20Lai = 0;
            clsN21Lai = 0;
            clsN22Lai = 0;
            clsN23Lai = 0;
            clsN24Lai = 0;
            clsN25Lai = 0;
            clsN26Lai = 0;
            clsN27Lai = 0;
            clsN28Lai = 0;
            clsN29Lai = 0;
            clsN30Lai = 0;
            clsN31Lai = 0;
        }




            #endregion


        #region Biến biểu đồ tồn kho 12 tháng trong năm
        public int T1MucHangTonKho;
        public double T1TongTienTonKho;
        //     
        public int T2MucHangTonKho;
        public double T2TongTienTonKho;
        //
        public int T3MucHangTonKho;
        public double T3TongTienTonKho;
        //
        public int T4MucHangTonKho;
        public double T4TongTienTonKho;
        //
        public int T5MucHangTonKho;
        public double T5TongTienTonKho;
        //
        public int T6MucHangTonKho;
        public double T6TongTienTonKho;
        //
        public int T7MucHangTonKho;
        public double T7TongTienTonKho;
        //
        public int T8MucHangTonKho;
        public double T8TongTienTonKho;
        //
        public int T9MucHangTonKho;
        public double T9TongTienTonKho;
        //
        public int T10MucHangTonKho;
        public double T10TongTienTonKho;
        //
        public int T11MucHangTonKho;
        public double T11TongTienTonKho;
        //
        public int T12MucHangTonKho;
        public double T12TongTienTonKho;
        //




        void resetDataBieuDoTonKho()
        {

            T1MucHangTonKho = 0;
            T1TongTienTonKho = 0;
            //
            T2MucHangTonKho = 0;
            T2TongTienTonKho = 0;
            //
            T3MucHangTonKho = 0;
            T3TongTienTonKho = 0;
            //
            T4MucHangTonKho = 0;
            T4TongTienTonKho = 0;
            //
            T5MucHangTonKho = 0;
            T5TongTienTonKho = 0;
            //
            T6MucHangTonKho = 0;
            T6TongTienTonKho = 0;
            //
            T7MucHangTonKho = 0;
            T7TongTienTonKho = 0;
            //
            T8MucHangTonKho = 0;
            T8TongTienTonKho = 0;
            //
            T9MucHangTonKho = 0;
            T9TongTienTonKho = 0;
            //
            T10MucHangTonKho = 0;
            T10TongTienTonKho = 0;
            //
            T11MucHangTonKho = 0;
            T11TongTienTonKho = 0;
            //
            T12MucHangTonKho = 0;
            T12TongTienTonKho = 0;
            
           
        }







        #endregion




        #region ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        string constr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + Application.StartupPath + @"\Database.mdb";
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









        public bool Top10BanChay() // 
        {

            string sql = "SELECT HoaDon.TenHangBan, Sum(HoaDon.ThanhTien) AS SumOfThanhTien FROM HoaDon GROUP BY HoaDon.TenHangBan ORDER BY Sum(HoaDon.ThanhTien) DESC";
            // SELECT HoaDon.TenHangBan, Sum(HoaDon.ThanhTien) AS SumOfThanhTien FROM HoaDon GROUP BY HoaDon.TenHangBan HAVING  Sum(HoaDon.ThanhTien)>100 ORDER BY Sum(HoaDon.ThanhTien) DESC;
            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            if (dt.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        if (i == 1) //top1
                        {
                            TenTop1 = dr.ItemArray[0].ToString();
                            TienTop1 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 2) //top2
                        {
                            TenTop2 = dr.ItemArray[0].ToString();
                            TienTop2 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 3) //top3
                        {
                            TenTop3 = dr.ItemArray[0].ToString();
                            TienTop3 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 4) //top4
                        {
                            TenTop4 = dr.ItemArray[0].ToString();
                            TienTop4 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 5) //top5
                        {
                            TenTop5 = dr.ItemArray[0].ToString();
                            TienTop5 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 6) //top6
                        {
                            TenTop6 = dr.ItemArray[0].ToString();
                            TienTop6 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 7) //top7
                        {
                            TenTop7 = dr.ItemArray[0].ToString();
                            TienTop7 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 8) //top8
                        {
                            TenTop8 = dr.ItemArray[0].ToString();
                            TienTop8 = double.Parse(dr.ItemArray[1].ToString());

                        }
                        if (i == 9) //top9
                        {
                            TenTop9 = dr.ItemArray[0].ToString();
                            TienTop9 = double.Parse(dr.ItemArray[1].ToString());

                        }

                        if (i == 10) //top10
                        {
                            TenTop10 = dr.ItemArray[0].ToString();
                            TienTop10 = double.Parse(dr.ItemArray[1].ToString());

                        }


                        i++;
                    }
                    catch
                    {

                    }

                }

            }
            return true;
        }



        public bool DoanhThuHangNgay(string nam, string thang) // 
        {
            int Ngay = 1;
            string ngay = "";

            resetDataBieuDoDoanhThu();
            VongLap:

            if (Ngay <10)
            {
                ngay = "0" + Ngay.ToString();
            }
            else
            {
                ngay = Ngay.ToString();
            }


            string sql = "SELECT Sum(TongTienGiaoDich) AS Expr1, Sum(TongLaiGiaoDich) AS Expr2 FROM DoanhSo WHERE (((DoanhSo.[NamGiaoDich])='" 
                + nam + "') AND ((DoanhSo.[ThangGiaoDich])='" 
                + thang + "') AND ((DoanhSo.[NgayGiaoDich])='" 
                + ngay + "'))";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        if (Ngay == 1)
                        {
                            clsN1ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN1Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 2)
                        {
                            clsN2ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN2Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 3)
                        {
                            clsN3ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN3Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 4)
                        {
                            clsN4ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN4Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 5)
                        {
                            clsN5ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN5Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 6)
                        {
                            clsN6ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN6Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 7)
                        {
                            clsN7ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN7Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 8)
                        {
                            clsN8ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN8Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 9)
                        {
                            clsN9ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN9Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 10)
                        {
                            clsN10ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN10Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 11)
                        {
                            clsN11ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN11Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 12)
                        {
                            clsN12ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN12Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 13)
                        {
                            clsN13ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN13Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 14)
                        {
                            clsN14ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN14Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 15)
                        {
                            clsN15ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN15Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 16)
                        {
                            clsN16ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN16Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 17)
                        {
                            clsN17ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN17Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 18)
                        {
                            clsN18ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN18Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 19)
                        {
                            clsN19ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN19Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 20)
                        {
                            clsN20ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN20Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 21)
                        {
                            clsN21ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN21Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 22)
                        {
                            clsN22ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN22Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 23)
                        {
                            clsN23ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN23Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 24)
                        {
                            clsN24ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN24Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 25)
                        {
                            clsN25ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN25Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 26)
                        {
                            clsN26ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN26Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 27)
                        {
                            clsN27ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN27Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 28)
                        {
                            clsN28ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN28Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 29)
                        {
                            clsN29ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN29Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 30)
                        {
                            clsN30ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN30Lai = double.Parse(dr.ItemArray[1].ToString());
                        }
                        if (Ngay == 31)
                        {
                            clsN31ThuNhap = double.Parse(dr.ItemArray[0].ToString());
                            clsN31Lai = double.Parse(dr.ItemArray[1].ToString());
                        }

                        
                        
                    }
                    catch
                    {

                    }

                    if (Ngay < 32)
                    {
                        Ngay++;
                        goto VongLap;
                    }
                }
            }
            return true;
        }







        public bool LayDataTonKho(string nam) // 
        {           
            resetDataBieuDoTonKho();

        int thang = 1;
        VongLap:

          

        string sql = "SELECT TongMucHangTrongKho,TongTienHangTheoGiaNhap FROM TonKho WHERE Nam = '"+nam+"' AND Thang = '"+thang+"'";

            DataTable dt = new DataTable();
            dt = Receivedata(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                       
                        if (thang == 1)
                        {
                           
                                T1MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T1TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                                               
                        }
                        if (thang == 2)
                        {
                           
                                T2MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T2TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 3)
                        {
                           
                                T3MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T3TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 4)
                        {
                           
                                T4MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T4TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 5)
                        {
                           
                                T5MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T5TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                            
                        }
                        if (thang == 6)
                        {
                           
                                T6MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T6TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 7)
                        {
                           
                                T7MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T7TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 8)
                        {
                            
                                T8MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T8TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 9)
                        {
                           
                                T9MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T9TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                            
                        }
                        if (thang == 10)
                        {
                            
                                T10MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T10TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 11)
                        {
                            
                                T11MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T11TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                        if (thang == 12)
                        {
                            
                                T12MucHangTonKho = int.Parse(dr.ItemArray[0].ToString());
                                T12TongTienTonKho = double.Parse(dr.ItemArray[1].ToString());
                           
                        }
                    }
                    catch
                    {

                    }        
                }
                
            }
            

            if (thang < 13)
            {
                thang++;
                goto VongLap;
            }
            return true;
        }


















        public DataTable ThiPhanTheoNhomHang() // 
        {

            string sql = "SELECT NhomHang,SUM(TongGiaHang) AS 'TONG' FROM KhoHang GROUP BY NhomHang ORDER BY 'TONG' DESC";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);
            return dt;
          
        }
        public DataTable ThiPhanTheoLoaiHang() // 
        {

            string sql = "SELECT LoaiHang,SUM(TongGiaHang) AS 'TONG' FROM KhoHang GROUP BY LoaiHang ORDER BY 'TONG' DESC";
            DataTable dt = new DataTable();
            dt = Receivedata(sql);
            return dt;

        }


































        #endregion




































































    }
}
