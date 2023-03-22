using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace CONTROL_ROBOT
{
    class clshienthidata
    {

        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");



        

        public void ProgressBarModifyColor ()
        {
                
        }







        public clshienthidata()
        {
           
        }

        #region (KHONG SU DUNG)



        //public void hienthispec(DataGridView dtvSpec, DataTable Spectable)
        //{
        //    dtvSpec.AutoGenerateColumns = false;
        //    dtvSpec.DataSource = Spectable;
        //    dtvSpec.Columns.Clear();

        //    DataGridViewTextBoxColumn col_seq = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_itemid = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_itemname = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_jtype = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_min = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_max = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_CH1 = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_CH2 = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_CH3 = new DataGridViewTextBoxColumn();

        //    col_seq.DataPropertyName = "seq_no";
        //    col_itemid.DataPropertyName = "item_id";
        //    col_itemname.DataPropertyName = "item_name";
        //    col_jtype.DataPropertyName = "jtype";
        //    col_min.DataPropertyName = "spec_value1";
        //    col_max.DataPropertyName = "spec_value2";

        //    col_seq.HeaderText = "STT";
        //    col_itemid.HeaderText = "Item ID";
        //    col_itemname.HeaderText = "Hạng Mục";
        //    col_jtype.HeaderText = "Đ/Giá";
        //    col_min.HeaderText = "Min";
        //    col_max.HeaderText = "Max";
        //    col_CH1.HeaderText = "CH1";
        //    col_CH2.HeaderText = "CH2";
        //    col_CH3.HeaderText = "CH3";

        //    col_seq.Name = "seq_no";
        //    col_itemid.Name = "item_id";
        //    col_itemname.Name = "item_name";
        //    col_jtype.Name = "jtype";
        //    col_min.Name = "spec_value1";
        //    col_max.Name = "spec_value2";

        //    col_seq.ReadOnly = true;
        //    col_itemid.ReadOnly = true;
        //    col_itemname.ReadOnly = true;
        //    col_jtype.ReadOnly = true;
        //    col_min.ReadOnly = true;
        //    col_max.ReadOnly = true;
        //    col_CH1.ReadOnly = true;
        //    col_CH2.ReadOnly = true;
        //    col_CH3.ReadOnly = true;

        //    col_seq.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_itemid.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_itemname.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_jtype.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_min.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_max.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_CH1.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_CH2.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_CH3.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    col_seq.Width = 40;
        //    col_itemid.Width = 40;
        //    col_itemname.Width = 136;
        //    col_jtype.Width = 40;
        //    col_min.Width = 46;
        //    col_max.Width = 46;
        //    col_CH1.Width = 146;
        //    col_CH2.Width = 146;
        //    col_CH3.Width = 146;

        //    col_seq.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_itemid.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_itemname.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_jtype.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_min.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_max.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_CH1.CellTemplate.Style.BackColor = Color.White;
        //    col_CH2.CellTemplate.Style.BackColor = Color.White;
        //    col_CH3.CellTemplate.Style.BackColor = Color.White;

        //    col_seq.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_itemid.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_itemname.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_jtype.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_min.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_max.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_CH1.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_CH2.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_CH3.CellTemplate.Style.Font = new Font("Times New Roman", 7);

        //    col_seq.CellTemplate.Style.ForeColor = Color.Black;
        //    col_itemid.CellTemplate.Style.ForeColor = Color.Black;
        //    col_itemname.CellTemplate.Style.ForeColor = Color.Black;
        //    col_jtype.CellTemplate.Style.ForeColor = Color.Black;
        //    col_min.CellTemplate.Style.ForeColor = Color.Black;
        //    col_max.CellTemplate.Style.ForeColor = Color.Black;
        //    col_CH1.CellTemplate.Style.ForeColor = Color.Black;
        //    col_CH2.CellTemplate.Style.ForeColor = Color.Black;
        //    col_CH3.CellTemplate.Style.ForeColor = Color.Black;

        //    dtvSpec.Columns.Add(col_seq);
        //    dtvSpec.Columns.Add(col_itemid);
        //    dtvSpec.Columns.Add(col_itemname);
        //    dtvSpec.Columns.Add(col_jtype);
        //    dtvSpec.Columns.Add(col_min);
        //    dtvSpec.Columns.Add(col_max);
        //    dtvSpec.Columns.Add(col_CH1);
        //    dtvSpec.Columns.Add(col_CH2);
        //    dtvSpec.Columns.Add(col_CH3);
        //}

        //public void insertresult(DataGridView dtvspec, int dong, string data, Color maunen, Color mauchu, int kenh)
        //{
        //    dtvspec.Rows[dong].Cells[kenh + 5].Style.BackColor = maunen;
        //    dtvspec.Rows[dong].Cells[kenh + 5].Style.ForeColor = mauchu;
        //    dtvspec.Rows[dong].Cells[kenh + 5].Value = data;
        //}

        //public void clearresult(DataGridView dtvspec, Label lb, ProgressBar pgb, int kenh)
        //{
        //    for (int iRow = 0; iRow < dtvspec.RowCount; iRow++)
        //    {
        //        dtvspec.Rows[iRow].Cells[kenh + 5].Style.BackColor = Color.White;
        //        dtvspec.Rows[iRow].Cells[kenh + 5].Value = "";
        //    }
        //    lb.Text = "SẴN SÀNG";
        //    lb.Font = new Font(FontFamily.GenericSansSerif, 14);
        //    lb.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        //    lb.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
        //    pgb.Value = 0;
        //}
        //public void hienthiitemcommandtheomodel(DataGridView dtvitemcommand, DataTable itemcommandtable)
        //{
        //    dtvitemcommand.AutoGenerateColumns = false;
        //    dtvitemcommand.DataSource = itemcommandtable;
        //    dtvitemcommand.Columns.Clear();

        //    //DataGridViewTextBoxColumn col_itemid = new DataGridViewTextBoxColumn();
        //    //DataGridViewTextBoxColumn col_seq = new DataGridViewTextBoxColumn();
        //    //DataGridViewComboBoxColumn col_scpi = new DataGridViewComboBoxColumn();
        //    //DataGridViewTextBoxColumn col_cmd = new DataGridViewTextBoxColumn();
        //    //DataGridViewTextBoxColumn col_addr = new DataGridViewTextBoxColumn();
        //    //DataGridViewTextBoxColumn col_len = new DataGridViewTextBoxColumn();
        //    //DataGridViewTextBoxColumn col_data = new DataGridViewTextBoxColumn();
        //    //DataGridViewComboBoxColumn col_conv = new DataGridViewComboBoxColumn();
        //    //DataGridViewComboBoxColumn col_storage = new DataGridViewComboBoxColumn();

        //    DataGridViewTextBoxColumn col_itemid = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_seq = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_scpi = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_cmd = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_addr = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_len = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_data = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_conv = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_storage = new DataGridViewTextBoxColumn();

        //    col_itemid.DataPropertyName = "Item_ID";
        //    col_seq.DataPropertyName = "FUNC_SEQ";
        //    col_scpi.DataPropertyName = "SCPI";
        //    col_cmd.DataPropertyName = "CMD";
        //    col_addr.DataPropertyName = "ADDR";
        //    col_len.DataPropertyName = "LEN";
        //    col_data.DataPropertyName = "Data";
        //    col_conv.DataPropertyName = "CONVERSION_TYPE";
        //    col_storage.DataPropertyName = "Storage_type";

        //    col_itemid.HeaderText = "Item_ID";
        //    col_seq.HeaderText = "STT";
        //    col_scpi.HeaderText = "SCPI";
        //    col_cmd.HeaderText = "CMD";
        //    col_addr.HeaderText = "ADDR";
        //    col_len.HeaderText = "LEN";
        //    col_data.HeaderText = "Data";
        //    col_conv.HeaderText = "Chuyển Đổi";
        //    col_storage.HeaderText = "Lưu Trữ";

        //    col_itemid.Name = "Item_ID";
        //    col_seq.Name = "FUNC_SEQ";
        //    col_scpi.Name = "SCPI";
        //    col_cmd.Name = "CMD";
        //    col_addr.Name = "ADDR";
        //    col_len.Name = "LEN";
        //    col_data.Name = "Data";
        //    col_conv.Name = "CONVERSION_TYPE";
        //    col_storage.Name = "Storage_type";

        //    col_itemid.ReadOnly = true;
        //    col_seq.ReadOnly = true;
        //    col_scpi.ReadOnly = true;
        //    col_cmd.ReadOnly = true;
        //    col_addr.ReadOnly = true;
        //    col_len.ReadOnly = true;
        //    col_data.ReadOnly = true;
        //    col_conv.ReadOnly = true;
        //    col_storage.ReadOnly = true;

        //    col_itemid.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_seq.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_scpi.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_cmd.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_addr.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_len.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_data.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_conv.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_storage.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    col_itemid.Width = 50;
        //    col_seq.Width = 40;
        //    col_scpi.Width = 120;
        //    col_cmd.Width = 100;
        //    col_addr.Width = 100;
        //    col_len.Width = 100;
        //    col_data.Width = 120;
        //    col_conv.Width = 120;
        //    col_storage.Width = 120;

        //    //col_scpi.FlatStyle = FlatStyle.Popup;
        //    //col_conv.FlatStyle = FlatStyle.Popup;
        //    //col_storage.FlatStyle = FlatStyle.Popup;

        //    col_itemid.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_seq.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_scpi.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_cmd.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_addr.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_len.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_data.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_conv.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_storage.CellTemplate.Style.BackColor = Color.LightCyan;

        //    col_itemid.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_seq.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_scpi.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_cmd.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_addr.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_len.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_data.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_conv.CellTemplate.Style.Font = new Font("Times New Roman", 7);
        //    col_storage.CellTemplate.Style.Font = new Font("Times New Roman", 7);


        //    col_itemid.CellTemplate.Style.ForeColor = Color.Black;
        //    col_seq.CellTemplate.Style.ForeColor = Color.Black;
        //    col_scpi.CellTemplate.Style.ForeColor = Color.Black;
        //    col_cmd.CellTemplate.Style.ForeColor = Color.Black;
        //    col_addr.CellTemplate.Style.ForeColor = Color.Black;
        //    col_len.CellTemplate.Style.ForeColor = Color.Black;
        //    col_data.CellTemplate.Style.ForeColor = Color.Black;
        //    col_conv.CellTemplate.Style.ForeColor = Color.Black;
        //    col_storage.CellTemplate.Style.ForeColor = Color.Black;

        //    dtvitemcommand.Columns.Add(col_itemid);
        //    dtvitemcommand.Columns.Add(col_seq);
        //    dtvitemcommand.Columns.Add(col_scpi);
        //    dtvitemcommand.Columns.Add(col_cmd);
        //    dtvitemcommand.Columns.Add(col_addr);
        //    dtvitemcommand.Columns.Add(col_len);
        //    dtvitemcommand.Columns.Add(col_data);
        //    dtvitemcommand.Columns.Add(col_conv);
        //    dtvitemcommand.Columns.Add(col_storage);
        //}
        //public void hienthiitemcommand(DataGridView dtvitemcommand, DataTable itemcommandtable)
        //{
        //    dtvitemcommand.AutoGenerateColumns = false;
        //    dtvitemcommand.DataSource = itemcommandtable;
        //    dtvitemcommand.Columns.Clear();

        //    DataGridViewTextBoxColumn col_itemid = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_seq = new DataGridViewTextBoxColumn();
        //    DataGridViewComboBoxColumn col_scpi = new DataGridViewComboBoxColumn();
        //    DataGridViewTextBoxColumn col_cmd = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_addr = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_len = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_data = new DataGridViewTextBoxColumn();
        //    DataGridViewComboBoxColumn col_conv = new DataGridViewComboBoxColumn();
        //    DataGridViewComboBoxColumn col_storage = new DataGridViewComboBoxColumn();

        //    col_itemid.DataPropertyName = "Item_ID";
        //    col_seq.DataPropertyName = "SEQ";
        //    col_scpi.DataPropertyName = "SCPI";
        //    col_cmd.DataPropertyName = "CMD";
        //    col_addr.DataPropertyName = "ADDR";
        //    col_len.DataPropertyName = "LEN";
        //    col_data.DataPropertyName = "Data";
        //    col_conv.DataPropertyName = "CONV";
        //    col_storage.DataPropertyName = "STORAGE";

        //    col_itemid.HeaderText = "Item_ID";
        //    col_seq.HeaderText = "STT";
        //    col_scpi.HeaderText = "SCPI";
        //    col_cmd.HeaderText = "CMD";
        //    col_addr.HeaderText = "ADDR";
        //    col_len.HeaderText = "LEN";
        //    col_data.HeaderText = "Data";
        //    col_conv.HeaderText = "Chuyển Đổi";
        //    col_storage.HeaderText = "Lưu Trữ";

        //    col_itemid.Name = "Item_ID";
        //    col_seq.Name = "SEQ";
        //    col_scpi.Name = "SCPI";
        //    col_cmd.Name = "CMD";
        //    col_addr.Name = "ADDR";
        //    col_len.Name = "LEN";
        //    col_data.Name = "Data";
        //    col_conv.Name = "CONVERSION";
        //    col_storage.Name = "Storage_type";

        //    col_itemid.ReadOnly = true;
        //    col_seq.ReadOnly = true;
        //    col_scpi.ReadOnly = false;
        //    col_cmd.ReadOnly = false;
        //    col_addr.ReadOnly = false;
        //    col_len.ReadOnly = false;
        //    col_data.ReadOnly = false;
        //    col_conv.ReadOnly = false;
        //    col_storage.ReadOnly = false;

        //    col_itemid.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_seq.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_scpi.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_cmd.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_addr.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_len.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_data.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_conv.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_storage.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    col_itemid.Width = 50;
        //    col_seq.Width = 50;
        //    col_scpi.Width = 100;
        //    col_cmd.Width = 75;
        //    col_addr.Width = 70;
        //    col_len.Width = 70;
        //    col_data.Width = 70;
        //    col_conv.Width = 100;
        //    col_storage.Width = 70;

        //    col_scpi.FlatStyle = FlatStyle.Popup;
        //    col_conv.FlatStyle = FlatStyle.Popup;
        //    col_storage.FlatStyle = FlatStyle.Popup;

        //    col_scpi.Items.Add("JUDGEMENT_TYPE");
        //    col_scpi.Items.Add("BARCODE_SCAN");
        //    col_scpi.Items.Add("WAKEUP");
        //    col_scpi.Items.Add("DELAY");
        //    col_scpi.Items.Add("DAQ");
        //    col_scpi.Items.Add("DVM");
        //    col_scpi.Items.Add("HIOKI");
        //    col_scpi.Items.Add("POWER_SUPPLY");
        //    col_scpi.Items.Add("1W-RB?");
        //    col_scpi.Items.Add("1W-WC?");
        //    col_scpi.Items.Add("1W-WB?");
        //    col_scpi.Items.Add("SMB-RW?");
        //    col_scpi.Items.Add("SMB-WW?");
        //    col_scpi.Items.Add("SMB-RB?");
        //    col_scpi.Items.Add("SMB-WB?");
        //    col_scpi.Items.Add("CALL");
        //    col_scpi.Items.Add("CALC");
        //    col_scpi.Items.Add("MSG");
        //    col_scpi.Items.Add("MSG Y/N?");
        //    col_scpi.Items.Add("REPEAT");


        //    col_conv.Items.Add("NO");
        //    col_conv.Items.Add("PCMDATE");
        //    col_conv.Items.Add("PACKDATE");
        //    col_conv.Items.Add("HEX2DEC");
        //    col_conv.Items.Add("C");
        //    col_conv.Items.Add("HEX2BIN");
        //    col_conv.Items.Add("LLHH");
        //    col_conv.Items.Add("LLHH_HEX");

        //    col_storage.Items.Add("NO");
        //    col_storage.Items.Add("PUSH");
        //    col_storage.Items.Add("PVM");

        //    col_itemid.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_seq.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_scpi.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_cmd.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_addr.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_len.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_data.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_conv.CellTemplate.Style.BackColor = Color.LightCyan;
        //    col_storage.CellTemplate.Style.BackColor = Color.LightCyan;

        //    col_itemid.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_seq.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_scpi.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_cmd.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_addr.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_len.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_data.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_conv.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_storage.CellTemplate.Style.Font = new Font("Times New Roman", 9);

        //    col_itemid.CellTemplate.Style.ForeColor = Color.Black;
        //    col_seq.CellTemplate.Style.ForeColor = Color.Black;
        //    col_scpi.CellTemplate.Style.ForeColor = Color.Black;
        //    col_cmd.CellTemplate.Style.ForeColor = Color.Black;
        //    col_addr.CellTemplate.Style.ForeColor = Color.Black;
        //    col_len.CellTemplate.Style.ForeColor = Color.Black;
        //    col_data.CellTemplate.Style.ForeColor = Color.Black;
        //    col_conv.CellTemplate.Style.ForeColor = Color.Black;
        //    col_storage.CellTemplate.Style.ForeColor = Color.Black;

        //    dtvitemcommand.Columns.Add(col_itemid);
        //    dtvitemcommand.Columns.Add(col_seq);
        //    dtvitemcommand.Columns.Add(col_scpi);
        //    dtvitemcommand.Columns.Add(col_cmd);
        //    dtvitemcommand.Columns.Add(col_addr);
        //    dtvitemcommand.Columns.Add(col_len);
        //    dtvitemcommand.Columns.Add(col_data);
        //    dtvitemcommand.Columns.Add(col_conv);
        //    dtvitemcommand.Columns.Add(col_storage);
        //}

        //public void hienthicaidatspec(DataGridView dtvSpec,DataTable Spectable,DataTable dt)
        //{
        //    dtvSpec.AutoGenerateColumns = false;
        //    dtvSpec.DataSource = Spectable;
        //    dtvSpec.Columns.Clear();

        //    DataGridViewTextBoxColumn col_seq = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_itemid = new DataGridViewTextBoxColumn();
        //    DataGridViewComboBoxColumn col_itemname = new DataGridViewComboBoxColumn();
        //    DataGridViewComboBoxColumn col_jtype = new DataGridViewComboBoxColumn();
        //    DataGridViewTextBoxColumn col_min = new DataGridViewTextBoxColumn();
        //    DataGridViewTextBoxColumn col_max = new DataGridViewTextBoxColumn();
        //    DataGridViewComboBoxColumn col_testsw = new DataGridViewComboBoxColumn();

        //    col_itemname.FlatStyle = FlatStyle.Popup;
        //    col_jtype.FlatStyle = FlatStyle.Popup;
        //    col_testsw.FlatStyle = FlatStyle.Popup;

        //    col_jtype.Items.Add("=");
        //    col_jtype.Items.Add("B");
        //    col_jtype.Items.Add("<");
        //    col_jtype.Items.Add(">");
        //    col_jtype.Items.Add("D");
        //    col_jtype.Items.Add("C");
        //    col_jtype.Items.Add("N");
        //    col_jtype.Items.Add("BS");
        //    col_jtype.Items.Add("Y/N");

        //    col_testsw.Items.Add("Y");
        //    col_testsw.Items.Add("N");

        //    //col_itemname.Items.Add("1");
        //    //col_itemname.Items.Add("2");
        //    //col_itemname.Items.Add("3");
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        col_itemname.Items.Add(dr.ItemArray[0]);
        //    }
            
        //    col_seq.DataPropertyName = "seq_no";
        //    col_itemid.DataPropertyName = "item_id";
        //    col_itemname.DataPropertyName = "item_name";
        //    col_jtype.DataPropertyName = "jtype";
        //    col_min.DataPropertyName = "spec_value1";
        //    col_max.DataPropertyName = "spec_value2";
        //    col_testsw.DataPropertyName = "test_sw";

        //    col_seq.HeaderText = "STT";
        //    col_itemid.HeaderText = "Item ID";
        //    col_itemname.HeaderText = "Hạng Mục";
        //    col_jtype.HeaderText = "Đ/Giá";
        //    col_min.HeaderText = "Min";
        //    col_max.HeaderText = "Max";
        //    col_testsw.HeaderText = "Test/Không";

        //    col_seq.Name = "seq_no";
        //    col_itemid.Name = "item_id";
        //    col_itemname.Name = "item_name";
        //    col_jtype.Name = "jtype";
        //    col_min.Name = "spec_value1";
        //    col_max.Name = "spec_value2";
        //    col_testsw.Name = "test_sw";

        //    col_seq.ReadOnly = true;
        //    col_itemid.ReadOnly = true;
        //    col_itemname.ReadOnly = false;
        //    col_jtype.ReadOnly = false;
        //    col_min.ReadOnly = false;
        //    col_max.ReadOnly = false;
        //    col_testsw.ReadOnly = false;

        //    col_seq.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_itemid.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_itemname.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_jtype.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_min.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_max.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    col_testsw.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    col_seq.Width = 80;
        //    col_itemid.Width = 80;
        //    col_itemname.Width = 280;
        //    col_jtype.Width = 80;
        //    col_min.Width = 80;
        //    col_max.Width = 80;
        //    col_testsw.Width = 80;


        //    col_seq.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_itemid.CellTemplate.Style.BackColor = Color.AliceBlue;
        //    col_itemname.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_jtype.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_min.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_max.CellTemplate.Style.BackColor = Color.Yellow;
        //    col_testsw.CellTemplate.Style.BackColor = Color.Yellow;

        //    col_seq.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_itemid.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_itemname.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_jtype.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_min.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_max.CellTemplate.Style.Font = new Font("Times New Roman", 9);
        //    col_testsw.CellTemplate.Style.Font = new Font("Times New Roman", 9);

        //    col_seq.CellTemplate.Style.ForeColor = Color.Black;
        //    col_itemid.CellTemplate.Style.ForeColor = Color.Black;
        //    col_itemname.CellTemplate.Style.ForeColor = Color.Black;
        //    col_jtype.CellTemplate.Style.ForeColor = Color.Black;
        //    col_min.CellTemplate.Style.ForeColor = Color.Black;
        //    col_max.CellTemplate.Style.ForeColor = Color.Black;
        //    col_testsw.CellTemplate.Style.ForeColor = Color.Black;
            
        //    dtvSpec.Columns.Add(col_seq);
        //    dtvSpec.Columns.Add(col_itemid);
        //    dtvSpec.Columns.Add(col_itemname);
        //    dtvSpec.Columns.Add(col_jtype);
        //    dtvSpec.Columns.Add(col_min);
        //    dtvSpec.Columns.Add(col_max);
        //    dtvSpec.Columns.Add(col_testsw);
        //}

        //public void hienthiitemtheoic(DataGridView dtv, DataTable table)
        //{
        //    dtv.AutoGenerateColumns = false;  // Setup thuộc tính autogenerate colums là false
        //    dtv.DataSource = table;  // setup nguồn dữ liệu của gridview
        //    dtv.Columns.Clear();  // xóa dữ liệu của gridview

        //    DataGridViewTextBoxColumn col_icno = new DataGridViewTextBoxColumn(); //khai báo và khởi tạo bộ nhớ cho cột
        //    DataGridViewTextBoxColumn col_itemid = new DataGridViewTextBoxColumn();//khai báo và khởi tạo bộ nhớ cho cột
        //    DataGridViewTextBoxColumn col_itemname = new DataGridViewTextBoxColumn();//khai báo và khởi tạo bộ nhớ cho cột

        //    col_icno.DataPropertyName = "IC_NO"; //khai báo tên của cột
        //    col_itemid.DataPropertyName = "Item_ID";//khai báo tên của cột
        //    col_itemname.DataPropertyName = "item_name";//khai báo tên của cột

        //    col_icno.HeaderText = "IC";//khai báo tên header của cột
        //    col_itemid.HeaderText = "Item ID";//khai báo tên header của cột
        //    col_itemname.HeaderText = "Tên Hạng Mục";//khai báo tên header của cột

        //    col_icno.Name = "IC_NO";//khai báo tên của cột
        //    col_itemid.Name = "Item_ID";//khai báo tên của cột
        //    col_itemname.Name = "item_name";//khai báo tên của cột

        //    col_icno.ReadOnly = true;//thiết lập chế độ chỉ đọc của cột
        //    col_itemid.ReadOnly = true;//thiết lập chế độ chỉ đọc của cột
        //    col_itemname.ReadOnly = false;//thiết lập chế độ chỉ đọc của cột

        //    col_icno.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;//thiết lập vị trí chữ của cột
        //    col_itemid.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;//thiết lập vị trí chữ của cột
        //    col_itemname.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;//thiết lập vị trí chữ của cột

        //    col_icno.Width = 100;//thiết lập độ rộng của cột
        //    col_itemid.Width = 100;//thiết lập độ rộng của cột
        //    col_itemname.Width = 300;//thiết lập độ rộng của cột

        //    col_icno.CellTemplate.Style.BackColor = Color.Yellow;//thiết lập màu nền của từng cell
        //    col_itemid.CellTemplate.Style.BackColor = Color.Yellow;//thiết lập màu nền của từng cell
        //    col_itemname.CellTemplate.Style.BackColor = Color.Yellow;//thiết lập màu nền của từng cell

        //    col_icno.CellTemplate.Style.Font = new Font("Times New Roman", 7);//thiết lập cỡ chữ cho từng cell
        //    col_itemid.CellTemplate.Style.Font = new Font("Times New Roman", 7);//thiết lập cỡ chữ cho từng cell
        //    col_itemname.CellTemplate.Style.Font = new Font("Times New Roman", 7);//thiết lập cỡ chữ cho từng cell

        //    col_icno.CellTemplate.Style.ForeColor = Color.Black;//thiết lập màu chữ cho từng cell
        //    col_itemid.CellTemplate.Style.ForeColor = Color.Black;//thiết lập màu chữ cho từng cell
        //    col_itemname.CellTemplate.Style.ForeColor = Color.Black;//thiết lập màu chữ cho từng cell

        //    dtv.Columns.Add(col_icno);// add dữ liệu cho từng cột
        //    dtv.Columns.Add(col_itemid);// add dữ liệu cho từng cột
        //    dtv.Columns.Add(col_itemname);// add dữ liệu cho từng cột

        //}


        #endregion



        public void hienthiAccount(DataGridView dgv, DataTable table)
        {
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = table;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns.Clear();
            dgv.ColumnHeadersVisible = true;
            //dgvAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle { BackColor=Color [Blue], ForeColor=Color [White], SelectionBackColor=Color [Blue], SelectionForeColor=Color [HighlightText], Font=[Font: Name=Microsoft Sans Serif, Size=9.75, Units=3, GdiCharSet=0, GdiVerticalFont=False], WrapMode=True, Alignment=MiddleLeft }

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colUsser = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPass = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colMobile = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colLevel = new DataGridViewTextBoxColumn();

            colID.DataPropertyName = "ID";
            colUsser.DataPropertyName = "User";
            colPass.DataPropertyName = "Password";
            colName.DataPropertyName = "Name";
            colMobile.DataPropertyName = "Mobile";
            colLevel.DataPropertyName = "Level";

            colID.HeaderText = "Mã tài khoản";
            colUsser.HeaderText = "Tên tài khoản";
            colPass.HeaderText = "Mật khẩu";
            colName.HeaderText = "Tên người dùng";
            colMobile.HeaderText = "Số điện thoại";
            colLevel.HeaderText = "Cấp độ truy cập";


            colID.Name = "ID";
            colUsser.Name = "User";
            colPass.Name = "Password";
            colName.Name = "Name";
            colMobile.Name = "Mobile";
            colLevel.Name = "Level";


            colID.ReadOnly = true;
            colUsser.ReadOnly = false;
            colPass.ReadOnly = false;
            colName.ReadOnly = false;
            colMobile.ReadOnly = false;
            colLevel.ReadOnly = false;

            colID.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUsser.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPass.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colName.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMobile.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLevel.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            colID.Width = 85;
            colUsser.Width = 125;
            colPass.Width = 125;
            colName.Width = 150;
            colMobile.Width = 100;
            colLevel.Width = 140;

            colID.CellTemplate.Style.BackColor = Color.White;
            colUsser.CellTemplate.Style.BackColor = Color.White;
            colPass.CellTemplate.Style.BackColor = Color.White;
            colName.CellTemplate.Style.BackColor = Color.White;
            colMobile.CellTemplate.Style.BackColor = Color.White;
            colLevel.CellTemplate.Style.BackColor = Color.White;

            colID.CellTemplate.Style.Font = new Font("Tahoma", 10);
            colUsser.CellTemplate.Style.Font = new Font("Tahoma", 10);
            colPass.CellTemplate.Style.Font = new Font("Tahoma", 10);
            colName.CellTemplate.Style.Font = new Font("Tahoma", 10);
            colMobile.CellTemplate.Style.Font = new Font("Tahoma", 10);
            colLevel.CellTemplate.Style.Font = new Font("Tahoma", 10);


            colID.CellTemplate.Style.ForeColor = Color.Blue;
            colUsser.CellTemplate.Style.ForeColor = Color.Black;
            colPass.CellTemplate.Style.ForeColor = Color.Black;
            colName.CellTemplate.Style.ForeColor = Color.Black;
            colMobile.CellTemplate.Style.ForeColor = Color.Black;
            colLevel.CellTemplate.Style.ForeColor = Color.Black;

            dgv.Columns.Add(colID);
            dgv.Columns.Add(colUsser);
            dgv.Columns.Add(colPass);
            dgv.Columns.Add(colName);
            dgv.Columns.Add(colMobile);
            dgv.Columns.Add(colLevel);
        }






        public void hienthiFileTeaching(DataGridView dgv, DataTable table)
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = table;
            dgv.EnableHeadersVisualStyles = false;
            //dgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;           
            dgv.ColumnHeadersVisible = true;
            //dgvAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle { BackColor=Color [Blue], ForeColor=Color [White], SelectionBackColor=Color [Blue], SelectionForeColor=Color [HighlightText], Font=[Font: Name=Microsoft Sans Serif, Size=9.75, Units=3, GdiCharSet=0, GdiVerticalFont=False], WrapMode=True, Alignment=MiddleLeft }

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();

            col1.DataPropertyName = "POS";
            col2.DataPropertyName = "X";
            col3.DataPropertyName = "Y";
            col4.DataPropertyName = "Speed";
            col5.DataPropertyName = "Delay";
            col6.DataPropertyName = "Scanner1";
            col7.DataPropertyName = "Scanner2";

            col1.Name = "POS";
            col2.Name = "X";
            col3.Name = "Y";
            col4.Name = "Speed";
            col5.Name = "Delay";
            col6.Name = "Scanner1";
            col7.Name = "Scanner2";
         
            col1.HeaderText = "POSITION";
            col2.HeaderText = "Tọa độ X";
            col3.HeaderText = "Tọa độ Y";
            col4.HeaderText = "Tốc độ";
            col5.HeaderText = "Delay";
            col6.HeaderText = "Scanner 1";
            col7.HeaderText = "Scanner 2";
        
            col1.ReadOnly = true;
            col2.ReadOnly = false;
            col3.ReadOnly = false;
            col4.ReadOnly = false;
            col5.ReadOnly = false;
            col6.ReadOnly = false;
            col7.ReadOnly = false;
                            
            col1.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col2.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col3.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col4.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col5.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col6.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col7.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
         
            col1.Width = 100;
            col2.Width = 150;
            col3.Width = 150;
            col4.Width = 150;
            col5.Width = 150;
            col6.Width = 150;
            col7.Width = 150;
      
            col1.CellTemplate.Style.BackColor = Color.White;
            col2.CellTemplate.Style.BackColor = Color.White;
            col3.CellTemplate.Style.BackColor = Color.White;
            col4.CellTemplate.Style.BackColor = Color.White;
            col5.CellTemplate.Style.BackColor = Color.White;
            col6.CellTemplate.Style.BackColor = Color.White;
            col7.CellTemplate.Style.BackColor = Color.White;
          
            col1.CellTemplate.Style.Font = new Font("Tahoma", 10);
            col2.CellTemplate.Style.Font = new Font("Tahoma", 10);
            col3.CellTemplate.Style.Font = new Font("Tahoma", 10);
            col4.CellTemplate.Style.Font = new Font("Tahoma", 10);
            col5.CellTemplate.Style.Font = new Font("Tahoma", 10);
            col6.CellTemplate.Style.Font = new Font("Tahoma", 10);
            col7.CellTemplate.Style.Font = new Font("Tahoma", 10);          

            col1.CellTemplate.Style.ForeColor = Color.Red;
            col2.CellTemplate.Style.ForeColor = Color.Blue;
            col3.CellTemplate.Style.ForeColor = Color.Blue;
            col4.CellTemplate.Style.ForeColor = Color.Blue;
            col5.CellTemplate.Style.ForeColor = Color.Blue;
            col6.CellTemplate.Style.ForeColor = Color.Blue;
            col7.CellTemplate.Style.ForeColor = Color.Blue;
          
            dgv.Columns.Add(col1);
            dgv.Columns.Add(col2);
            dgv.Columns.Add(col3);
            dgv.Columns.Add(col4);
            dgv.Columns.Add(col5);
            dgv.Columns.Add(col6);
            dgv.Columns.Add(col7);
       
        }



      







        public void hienthi_Log_File(DataGridView dgv, DataTable table)
        {
           
                //dgv.Columns.Clear();
                dgv.Columns.Clear();
                //Thread.Sleep(100);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = table;
                dgv.EnableHeadersVisualStyles = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgv.Columns.Clear();
                dgv.ColumnHeadersVisible = true;



                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();


                col1.DataPropertyName = "Time";
                col2.DataPropertyName = "Commend";


                col1.Name = "Time";
                col2.Name = "Commend";


                col1.HeaderText = "TIME";
                col2.HeaderText = "COMMEND";


                col1.ReadOnly = true;
                col2.ReadOnly = true;


                col1.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col2.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


                col1.Width = 300;
                col2.Width = 300;


                col1.CellTemplate.Style.BackColor = Color.White;
                col2.CellTemplate.Style.BackColor = Color.White;


                col1.CellTemplate.Style.Font = new Font("Tahoma", 10);
                col2.CellTemplate.Style.Font = new Font("Tahoma", 10);


                col1.CellTemplate.Style.ForeColor = Color.Gray;
                col2.CellTemplate.Style.ForeColor = Color.Gray;


                dgv.Columns.Add(col1);
                dgv.Columns.Add(col2);
           
            
           

        }















             public void hienthiDauPhay(TextBox txt) // theo hàng nghìn 000,000,000
        {
                 try
                 {
                     decimal value = decimal.Parse(txt.Text, System.Globalization.NumberStyles.AllowThousands);
                     txt.Text = String.Format(culture, "{0:N0}", value);
                     txt.Select(txt.Text.Length, 0);
                 }
                 catch
                 {

                 }            
        }
             public void hienthidatalabel(Label lbl) // theo hàng nghìn 000,000,000
             {
                 try
                 {
                     decimal value = decimal.Parse(lbl.Text, System.Globalization.NumberStyles.AllowThousands);
                     lbl.Text = String.Format(culture, "{0:N0}", value);
                     lbl.Select();
                 }
                 catch
                 {

                 }
             }


    }

}
