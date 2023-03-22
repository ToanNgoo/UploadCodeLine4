using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Drawing; 
using System.Windows.Forms;
namespace CONTROL_ROBOT
{
    class Scanner_Ethernet
    {
        private const Int32 BUFFER_SIZE = 1024;
        private const Int32 PORT_NUMBER = 5025;
        static ASCIIEncoding encoding = new ASCIIEncoding();
        TcpClient client = new TcpClient();
        Stream stream;

        fMain frmmain;






        //public Scanner_Ethernet(fMain _frmmain)
        //{
        //    frmmain = _frmmain;

        //}


        public bool connect(string IP, Int32 PORT_NUM, ToolStripStatusLabel lbl)
        {
            try
            {
                client.Connect(IP, PORT_NUM);
                stream = client.GetStream();
                if (client.Connected)
                {
                    lbl.BackColor = Color.Green;
                    return true;                   
                }
                else
                {
                    lbl.BackColor = Color.Red;
                    return false;
                }
            }
            catch (Exception)
            {
                lbl.BackColor = Color.Red;
                return false;                
            }            
        }

        public void disconnect_Scanner(string IP, Int32 PORT_NUM, ToolStripStatusLabel lbl)
        {
            if (client.Connected)
            {
                client.Close();
                lbl.BackColor = Color.Red;
            }
            //else
            //{
            //    client.Connect(IP, PORT_NUM);
            //    stream = client.GetStream();
            //    lbl.BackColor = Color.Green;
            //}
        }

        public void setup_ethernet()
        {
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
        }
        public string read_data_SR2000()
        {
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine("LON");
            string data = string.Empty;
            data = reader.ReadLine();
            return data;
        }

        public void OFF_Scan()
        {
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;               
            writer.WriteLine("LOFF");            
        }

        public string setConfig(int config)
        {
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine("BLOAD," + config.ToString());
            Thread.Sleep(3000);
            writer.WriteLine("LON");
            Thread.Sleep(300);
            writer.WriteLine("LOFF");
            string data = string.Empty;
            data = reader.ReadLine();
            return data;
            
        }

        public string read_config()
        {
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            string data = string.Empty;
            data = reader.ReadLine();
            return data;
        }

        // Đoc manual
        public void read_data_for_Live_View()
        {
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine("LON");
           
        }

        public void Off_read_data_for_Live_View()
        {
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine("LOFF");
            //writer.Close();
        }

        // Đọc code

        public string read_data()
        {
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine("LON");
            string data = string.Empty;
            data = reader.ReadLine();
            return data;
        }

        public string read_data_1()
        {
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
 
            string data = string.Empty;
            data = reader.ReadLine();
            return data;
        }
    }
}
