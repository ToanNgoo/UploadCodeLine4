using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ACTETHERLib;
using System.Threading;


namespace CONTROL_ROBOT
{
    public class clsPLC
    {
        //public ACTETHERLib.ActFXENETTCP PLC = new ACTETHERLib.ActFXENETTCP();
        //public ActMLQNUDECPUTCP PLC = new ActMLQNUDECPUTCP();
        //public ACTETHERLib.ActQNUDECPUTCP PLC = new ACTETHERLib.ActQNUDECPUTCP();
        //public ACTETHERLib.IActQNUDECPUTCP PLC = new ACTETHERLib.ActQNUDECPUTCP();
        public ACTETHERLib.IActQJ71E71TCP3 PLC = new ACTETHERLib.ActQJ71E71TCP();
     
        private int IRet = 0;
        private bool _PLC_Connect = false;
        private int _ActCpuType1;
        private int _ActDestinationPortNumber1;
        private string _ActHostAddress1;
        private int _ActTimeOut1;

        fMain fmain;





        public bool PLC_Connect
        {
            get { return _PLC_Connect; }
            set { _PLC_Connect = value; }
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Tự động tạo get , set   (Ctrl + R + E)


       





        public int ActCpuType1
        {
            get { return _ActCpuType1; }
            set { _ActCpuType1 = value; }
        }
        public int ActDestinationPortNumber1
        {
            get { return _ActDestinationPortNumber1; }
            set { _ActDestinationPortNumber1 = value; }
        }
        public string ActHostAddress1
        {
            get { return _ActHostAddress1; }
            set { _ActHostAddress1 = value; }
        }
        public int ActTimeOut1
        {
            get { return _ActTimeOut1; }
            set { _ActTimeOut1 = value; }
        }
       
       


        // Đọc dữ liệu
        public string getData(string add)
        {
            int result;
            string data = string.Empty;
            PLC.GetDevice(add, out result);
            data = result.ToString();
            return data;
        }




        // Hàm tạo cls PLC
        public clsPLC(fMain _fmain)
        {
            // thietlap();
            fmain = _fmain;
        }











        #region Read / Write PLC


        public string readplc(string address)
        {

            if (string.IsNullOrEmpty(address))           
            {
                return "FAIL";
            }
            else
            {
                if (PLC_Connect)
                {
                    string adrall = address;
                    string[] adr = adrall.Split('\n');
                    int IRET_read;
                    int[] addlength = new int[adr.Length];

                    IRET_read = PLC.ReadDeviceRandom(adrall, adr.Length, out addlength[0]);

                    if (IRET_read == 0)
                    {
                        return addlength[0].ToString();
                    }
                    else
                    {
                        return "FAIL";
                    }
                }
                else
                {
                    return "FAIL";
                }
            }
            

        }


        // Cách này read được thanh ghi world 16 bit 

        public short[] Read_Array_Devive(string Start_Device, int SL_Device)
        {
            int Result;
            short[] Result_Array_Data;
            Result_Array_Data = new short[SL_Device];

            if (string.IsNullOrEmpty(Start_Device))
            {
                return Result_Array_Data;
            }
            else
            {
                if (PLC_Connect)
                {

                    try
                    {
                        Result = PLC.ReadDeviceBlock2(Start_Device, SL_Device, out Result_Array_Data[0]);
                        return Result_Array_Data;
                    }
                    catch
                    {
                        return Result_Array_Data;
                    }
                }
                else
                {
                    return Result_Array_Data;
                }
            }
            

           
        }


        //public short[] ReadBlock2(string Start_Device, int Block_Number)
        //{
        //    int Result;
        //    short[] Result_Array_Data;
        //    System.String[] ardata;
        //    Result_Array_Data = new short[Block_Number];
        //    try
        //    {
        //        for (int i = 0; i < Block_Number; i++)
        //        {
        //            Result = PLC.ReadDeviceBlock2(Start_Device, Block_Number, out Result_Array_Data[i]);
        //            //return arraydata[0].ToString() + "  " + arraydata[1].ToString();

        //        }
        //        return Result_Array_Data;
        //    }
        //    catch
        //    {
        //        return Result_Array_Data;
        //    }
        //}
        //public string ReadBlock2(string Start_Device, int Block_Number)
        //{
        //    int Result_Value;
        //    short[] Result_Array_Data;
        //    //System.String[] ardata;
        //    Result_Array_Data = new short[Block_Number];
        //    try
        //    {
        //        //for (int i = 0; i < Block_Number; i++)
        //        //{
        //        Result_Value = PLC.ReadDeviceBlock2(Start_Device, 2, out Result_Array_Data[0]);
        //        //return arraydata[0].ToString() + "  " + arraydata[1].ToString();
        //        return Result_Array_Data[0].ToString();
        //        //}

        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}



        public void Writeplc(string address, int value)
        {
            if (PLC_Connect)
            {
                string adrall = address;
                string[] adr = adrall.Split('\n');
                int IRET_read;
                int[] addlength = new int[adr.Length];
                addlength[0] = value;
                IRET_read = PLC.WriteDeviceRandom(adrall, adr.Length, ref addlength[0]);
            }
        }

        #endregion

        public bool ketnoi()
        {
            IRet = PLC.Open();
            if (IRet == 0)
            {
                _PLC_Connect = true;
                return true;
            }
            else
            {
                _PLC_Connect = false;
                return false;
            }
        }

       





        //public string readplc(string address)
        //{
        //    if (PLC_Connect)
        //    {
        //        string adrall = address;
        //        string[] adr = adrall.Split('\n');
        //        int IRET_read;
        //        int[] addlength = new int[adr.Length];

        //        IRET_read = PLC.ReadDeviceRandom(adrall, adr.Length, out addlength[0]);

        //        if (IRET_read == 0)
        //        {
        //            return addlength[0].ToString();
        //        }
        //        else
        //        {
        //            return "FAIL";
        //        }
        //    }
        //    else
        //    {
        //        return "FAIL";
        //    }

        //}






     
        //public void thietlap(int cputype, int portnumber,string IP,int timeout)
        //{
        //    PLC.ActCpuType = 520;
        //    PLC.ActDestinationPortNumber = 5002;
        //    PLC.ActDestinationIONumber
        //    PLC.ActHostAddress = IP;
        //    PLC.ActTimeOut = 5000;
        //}
        //public void thietlap(TextBox IP_PLC)
        //{
        //    PLC.ActUnitNumber = 26;
        //    PLC.ActNetworkNumber = 1;
        //    PLC.ActStationNumber = 1;            
        //    PLC.ActIONumber = 1023;
        //    PLC.ActCpuType = 144;
        //    //PLC.ActSourceNetworkNumber = 2;
        //    //PLC.ActSourceStationNumber = 1;
        //    PLC.ActDestinationIONumber = 0;
        //    PLC.ActMultiDropChannelNumber = 0;
        //    PLC.ActThroughNetworkType = 0;
        //    //PLC.ActDestinationPortNumber = 5002;
        //    PLC.ActHostAddress = IP_PLC.Text;
        //    PLC.ActTimeOut = 6000;
        //}

        //public void thietlap(TextBox IP)
        //{
            

        //    PLC.ActUnitNumber = 26;
        //    PLC.ActNetworkNumber = 1;
        //    PLC.ActStationNumber = 1;
        //    PLC.ActIONumber = 1023;
        //    PLC.ActCpuType = 144;
        //    //PLC.ActSourceNetworkNumber = 2;
        //    //PLC.ActSourceStationNumber = 1;
        //    PLC.ActDestinationIONumber = 0;
        //    PLC.ActMultiDropChannelNumber = 0;
        //    PLC.ActThroughNetworkType = 0;
        //    //PLC.ActDestinationPortNumber = 5002;
        //    PLC.ActHostAddress = IP.Text;
        //    PLC.ActTimeOut = 6000;

            
        //}

        public void thietlap(TextBox IP_PLC,TextBox CPU_Code)     // 
        {
            PLC.ActUnitNumber = 0;
            PLC.ActNetworkNumber = 1;
            PLC.ActStationNumber = 2;
            PLC.ActIONumber = 992;
            //PLC.ActIONumber = 1023;
            PLC.ActCpuType = int.Parse(CPU_Code.Text);
            //PLC.ActCpuType = 34;
            PLC.ActSourceNetworkNumber = 1;
            PLC.ActSourceStationNumber = 1;
            PLC.ActDestinationIONumber = 0;
            PLC.ActMultiDropChannelNumber = 0;
            PLC.ActThroughNetworkType = 0;
            //PLC.ActDestinationPortNumber = 5002;
            PLC.ActHostAddress = IP_PLC.Text;
            PLC.ActTimeOut = 6000;
        }



      

















        public bool PLC_Status()
        {
            return true;
        }
    }
}
