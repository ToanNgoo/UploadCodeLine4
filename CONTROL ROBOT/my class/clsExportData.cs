using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CONTROL_ROBOT
{
    class clsExportData
    {
        public void exportData(DataGridView dtg1, string namFol, ComboBox namMol, string lik_Pc)
        {
            Excel._Application app = new Excel.Application();
            Excel._Workbook wB = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet wS = null;

            wS = wB.Sheets["Sheet1"];
            wS = wB.ActiveSheet;

            //Gán header cho file CSV
            for (int i = 1; i < dtg1.Columns.Count + 1; i++)
            {
                wS.Cells[1, i] = dtg1.Columns[i - 1].HeaderText;
            }

            //Gán phần tử cho file CSV
            for (int i = 0; i < dtg1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dtg1.Columns.Count; j++)
                {
                    if (dtg1.Rows[i].Cells[j].Value != null)
                    {
                        wS.Cells[i + 2, j + 1] = dtg1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        wS.Cells[i + 2, j + 1] = "";
                    }
                }
            }
            wB.SaveAs(lik_Pc + "\\Result\\" + namFol + "\\Boxing " + namMol.Text + " PCB V06 Ver01.CSV", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            app.Quit();
        }





        //Export DataGirdView sang CSV
        public void exportCsv(DataGridView dtg1, string path, bool check)
        {
            StringBuilder sb = new StringBuilder();

            //Export header text
            for (int i = 1; i < dtg1.Columns.Count + 1; i++)
            {
                if (check == false)  // Đã tồn tại file
                {
                    sb.Append(dtg1.Columns[i - 1].HeaderText);
                    sb.Append(",");//next sang cột bên cạnh
                }
            }
            if (check == false)
            {
                sb.Append("\n");
            }

            //Export data
            for (int n = 0; n < dtg1.Rows.Count - 1; n++)
            {
                for (int j = 0; j < dtg1.Columns.Count; j++)
                {
                    if (dtg1.Rows[n].Cells[j].Value != null)
                    {                       
                        sb.Append(dtg1.Rows[n].Cells[j].Value.ToString());
                        sb.Append(",");
                    }
                }
                sb.Append("\n");
            }

            if (check == false)  // Tạo mới file
            {
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            }
            else  // Ghi thêm data
            {
                File.AppendAllText(path, sb.ToString(), Encoding.UTF8);
            }
        }











        public void Check_Folder(string Folder_Name)
        {          
            string link_folder = Application.StartupPath + @"\" + Folder_Name + "";

            DirectoryInfo dir = new DirectoryInfo(link_folder);

            //Nếu folder chưa tồn tại mới tạo mới
            if (! dir.Exists)
            {
                dir.Create();
            }
        }




        public bool checkExitLog(string link_file)
        {
                        
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            //link_file = Application.StartupPath + @"\LOG\" + year + "" + month + "" + "_" + "Log.txt";
            if (!File.Exists(link_file))
            {
                return false;
            }
            else
            {
                return true;
            }












        }
    }
}
