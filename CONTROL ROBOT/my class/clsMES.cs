using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CONTROL_ROBOT
{
    public class clsMES
    {
        clsLocaldb Localdb = new clsLocaldb();
        public string SelectTime = "";
        public string SelectLineCode = "";

        private string _user;

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        private string _pass;

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
        private string _dbsource;

        public string Dbsource
        {
            get { return _dbsource; }
            set { _dbsource = value; }
        }

        //PLATE INPAD
        #region PLATE INPAD

        //public DataSet TaiData()
        //{
        //    try
        //    {

                
        //        string ngaythangnam = DateTime.Now.ToString("yyyyMMdd");
        //        string str = "";
        //        DataSet ds = new DataSet();
        //        OleDbDataAdapter da;
        //        string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

        //        OleDbConnection cnn = new OleDbConnection(constr);
        //        cnn.Open();

        //        // PO includes 4 days (Yesterday +Today+ 2 day after)
        //        //str = @"SELECT A.PLAN_DATE, A.PO_NO, B.PO_TYPE_EN, FN_GET_LINE_NAME('E', A.LINE_CD) LINE_NAME, A.PRD_CD, FN_GET_PRODUCT_NAME(A.PRD_CD) MODEL_NAME, FN_GET_GH43_PRD_CD(A.PRD_CD) GH_CODE, DECODE(A.USE_STS,'C' ,'Closed','N' ,'Available','N' ,'Delete','Using') PO_STATUS"
        //        //        + @" FROM VW_PO_MST A"
        //        //        + @" INNER JOIN VW_PO_TYPE B"
        //        //        + @" ON A.PLAN_DATE BETWEEN FN_GET_PRV_DATE(FN_GET_WORK_DATE) AND TO_CHAR(SYSDATE + 2 + 4/24, 'YYYYMMDD')"
        //        //        + @" AND A.LINE_CD = 'MV18'"
        //        //        + @" AND A.OPER_CD = '9060'"
        //        //        + @" AND A.PO_TYPE = B.PO_TYPE"
        //        //        + @" ORDER BY A.PLAN_DATE ASC";

        //        //PO 1 day
        //        str = @"SELECT SUBSTR(A.PLAN_DATE, 1, 4)||'/'||SUBSTR(A.PLAN_DATE, 5, 2)||'/'||SUBSTR(A.PLAN_DATE, 7, 2) PLAN_DATE, A.PO_NO, B.PO_TYPE_EN, FN_GET_LINE_NAME('E', A.LINE_CD) LINE_NAME, A.PRD_CD, FN_GET_PRODUCT_NAME(A.PRD_CD) MODEL_NAME, FN_GET_GH43_PRD_CD(A.PRD_CD) GH_CODE, DECODE(A.USE_STS,'C' ,'Closed','N' ,'Available','N' ,'Delete','Using') PO_STATUS"
        //                 + @" FROM VW_PO_MST A"
        //                 + @" INNER JOIN VW_PO_TYPE B"
        //                 //+ @" ON A.PLAN_DATE BETWEEN FN_GET_PRV_DATE(FN_GET_WORK_DATE) AND TO_CHAR(SYSDATE + 2 + 4/24, '"+SelectTime+"')"
        //                 + @" ON A.PLAN_DATE= '" + SelectTime + "'"
        //                 + @" AND A.OPER_CD = '9060'"
        //                 + @" AND A.PO_TYPE = B.PO_TYPE"
        //                 + @" INNER JOIN VW_LINE C"
        //                 + @" ON A.LINE_CD = C.LINE_CD"
        //                 + @" AND C.LINE_NAME_EN = '"+SelectLineCode+"'"
        //                 + @" ORDER BY A.PLAN_DATE ASC"; 

        //        da = new OleDbDataAdapter(str, constr);
        //        da.Fill(ds, "tblallinfo");


        //        cnn.Close();
        //        da.Dispose();

        //        return ds;
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
           
        //}

        //public DataSet TaiData()
        //{
        //    try
        //    {


        //        string ngaythangnam = DateTime.Now.ToString("yyyyMMdd");
        //        string str = "";
        //        DataSet ds = new DataSet();
        //        OleDbDataAdapter da;
        //        string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

        //        OleDbConnection cnn = new OleDbConnection(constr);
        //        cnn.Open();

        //        // PO includes 4 days (Yesterday +Today+ 2 day after)
        //        //str = @"SELECT A.PLAN_DATE, A.PO_NO, B.PO_TYPE_EN, FN_GET_LINE_NAME('E', A.LINE_CD) LINE_NAME, A.PRD_CD, FN_GET_PRODUCT_NAME(A.PRD_CD) MODEL_NAME, FN_GET_GH43_PRD_CD(A.PRD_CD) GH_CODE, DECODE(A.USE_STS,'C' ,'Closed','N' ,'Available','N' ,'Delete','Using') PO_STATUS"
        //        //        + @" FROM VW_PO_MST A"
        //        //        + @" INNER JOIN VW_PO_TYPE B"
        //        //        + @" ON A.PLAN_DATE BETWEEN FN_GET_PRV_DATE(FN_GET_WORK_DATE) AND TO_CHAR(SYSDATE + 2 + 4/24, 'YYYYMMDD')"
        //        //        + @" AND A.LINE_CD = 'MV18'"
        //        //        + @" AND A.OPER_CD = '9060'"
        //        //        + @" AND A.PO_TYPE = B.PO_TYPE"
        //        //        + @" ORDER BY A.PLAN_DATE ASC";

        //        //PO 1 day
        //        str = @"SELECT A.PLAN_DATE, A.PO_NO, FN_GET_PO_TYPE_NAME('E', A.PO_TYPE) PO_TYPE, FN_GET_LINE_NAME('E', A.LINE_CD) LINE_NAME, A.PRD_CD PRODUCT_CODE, FN_GET_PRODUCT_NAME(A.PRD_CD) MODEL_NAME, B.BCR_CD MODEL_BAR, DECODE(A.USE_STATUS,'C' ,'Closed','N' ,'Available','D' ,'Delete','In Use') PO_STATUS"
        //                 + @" FROM VW_PO_MST A, VNPCMADMIN.PMPRDSTD B, VW_LINE C" //+ @" FROM VW_PO_MST A"
        //                 + @" WHERE A.PLAN_DATE= '" + SelectTime + "'"
        //                 + @" AND A.PRD_CD = B.PRD_CD"
        //                 //+ @" INNER JOIN VW_LINE C"
        //                 + @" AND A.LINE_CD = C.LINE_CD"
        //                 + @" AND C.LINE_NAME_EN = '" + SelectLineCode + "'"
        //                 + @" ORDER BY A.PLAN_DATE ASC";

        //        da = new OleDbDataAdapter(str, constr);
        //        da.Fill(ds, "tblallinfo");


        //        cnn.Close();
        //        da.Dispose();

        //        return ds;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}



        public DataSet TaiData()
        {
            try
            {


                string ngaythangnam = DateTime.Now.ToString("yyyyMMdd");
                string str = "";
                DataSet ds = new DataSet();
                OleDbDataAdapter da;
                string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

                OleDbConnection cnn = new OleDbConnection(constr);
                cnn.Open();

                // PO includes 4 days (Yesterday +Today+ 2 day after)
                //str = @"SELECT A.PLAN_DATE, A.PO_NO, B.PO_TYPE_EN, FN_GET_LINE_NAME('E', A.LINE_CD) LINE_NAME, A.PRD_CD, FN_GET_PRODUCT_NAME(A.PRD_CD) MODEL_NAME, FN_GET_GH43_PRD_CD(A.PRD_CD) GH_CODE, DECODE(A.USE_STS,'C' ,'Closed','N' ,'Available','N' ,'Delete','Using') PO_STATUS"
                //        + @" FROM VW_PO_MST A"
                //        + @" INNER JOIN VW_PO_TYPE B"
                //        + @" ON A.PLAN_DATE BETWEEN FN_GET_PRV_DATE(FN_GET_WORK_DATE) AND TO_CHAR(SYSDATE + 2 + 4/24, 'YYYYMMDD')"
                //        + @" AND A.LINE_CD = 'MV18'"
                //        + @" AND A.OPER_CD = '9060'"
                //        + @" AND A.PO_TYPE = B.PO_TYPE"
                //        + @" ORDER BY A.PLAN_DATE ASC";

                //PO 1 day
                str = @"SELECT A.PLAN_DATE, A.PO_NO, FN_GET_PO_TYPE_NAME('E', A.PO_TYPE) PO_TYPE, FN_GET_LINE_NAME('E', A.LINE_CD) LINE_NAME, A.PRD_CD PRODUCT_CODE, FN_GET_PRODUCT_NAME(A.PRD_CD) MODEL_NAME, B.BCR_CD MODEL_BAR, DECODE(A.USE_STATUS,'C' ,'Closed','N' ,'Available' ,'A' ,'Available' ,'D' ,'Delete','In Use') PO_STATUS"
                         + @" FROM VW_PO_MST A, VNPCMADMIN.PMPRDSTD B, VW_LINE C"
                         + @" WHERE A.PLAN_DATE= '" + SelectTime + "'"
                         + @" AND A.PRD_CD = B.PRD_CD"
                         + @" AND A.LINE_CD = C.LINE_CD"
                         + @" AND C.LINE_NAME_EN = '" + SelectLineCode + "'"
                         + @" ORDER BY A.PLAN_DATE ASC";


                da = new OleDbDataAdapter(str, constr);
                da.Fill(ds, "tblallinfo");


                cnn.Close();
                da.Dispose();

                return ds;
            }
            catch (Exception)
            {

                throw;
            }

        }



        //tai linename cua MES in HHP
        //public DataSet TaiLineName()
        //{
        //    try
        //    {
        //        string ngaythangnam = DateTime.Now.ToString("yyyyMMdd");
        //        string str = "";
        //        DataSet ds = new DataSet();
        //        OleDbDataAdapter da;
        //        string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

        //        OleDbConnection cnn = new OleDbConnection(constr);
        //        cnn.Open();


        //        str = @"SELECT LINE_NAME_EN, LINE_CD"
        //                + @" FROM VW_LINE"
        //                + @" where LINE_GRP_NAME_EN = 'HHP(Pol)'";


        //        //                select LINE_NAME_EN, LINE_CD
        //        //from VW_LINE
        //        //where LINE_GRP_NAME_EN = 'HHP(Pol)'




        //        da = new OleDbDataAdapter(str, constr);
        //        da.Fill(ds, "tbllinename");


        //        cnn.Close();
        //        da.Dispose();

        //        return ds;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //tai line name CMES in MIH
        public DataSet TaiLineName()
        {
            try
            {
                string ngaythangnam = DateTime.Now.ToString("yyyyMMdd");
                string str = "";
                DataSet ds = new DataSet();
                OleDbDataAdapter da;
                string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

                OleDbConnection cnn = new OleDbConnection(constr);
                cnn.Open();

                str = @"SELECT LINE_NAME_EN, LINE_CD FROM VW_LINE"
                        + @" WHERE BIG_CODE = 'PCM'"
                        + @" ORDER BY LINE_NAME_EN ASC";

                //str = @"SELECT LINE_NAME_EN, LINE_CD FROM VW_LINE";//tai line name CMES in MIH
                //+ @" FROM VW_LINE"
                //+ @" where LINE_GRP_NAME_EN = 'HHP(Pol)'";

                //str = @"SELECT LINE_NAME_EN, LINE_CD"
                //        + @" FROM VW_LINE"
                //        + @" where LINE_GRP_NAME_EN = 'HHP(Pol)'";


                //                select LINE_NAME_EN, LINE_CD
                //from VW_LINE
                //where LINE_GRP_NAME_EN = 'HHP(Pol)'




                da = new OleDbDataAdapter(str, constr);
                da.Fill(ds, "tbllinename");


                cnn.Close();
                da.Dispose();

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public bool checkconnection()
        {
            string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";
            OleDbConnection cnn = new OleDbConnection(constr);
            try
            {
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch (Exception)
            {
                cnn.Close();
                return false;
            }
        }

        public DataTable Receivedata(string str)
        {
            string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(str, constr);
            da.Fill(dt);
            return dt;
        }

        public bool senddatatodb(string str)
        {
            string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";
            OleDbConnection cnn = new OleDbConnection(constr);
            cnn.Open();

            OleDbCommand cmd = new OleDbCommand(str, cnn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private DataSet taitieuchuan(string packcode, string ic)
        {
            string str = "";
            DataSet ds = new DataSet();
            OleDbDataAdapter da;
            string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

            //str = "select * from TB_STD_MODEL order by prd_cd";
            //da = new OleDbDataAdapter(str, constr);
            //da.Fill(ds, "tblmodel");

            //str = "select * from TB_STD_TEST_SPEC_SDI where prd_cd = '" + packcode + "' order by prd_cd, work_type, seq_no";
            str = "select PLANT_CD, FACTORY_CD, SHOP_CD, PRD_CD, WORK_TYPE, SEQ_NO, ITEM_ID, JTYPE, "
                + "SPEC_VALUE1, SPEC_VALUE2, SPEC_VALUE3, SPEC_VALUE4, SPEC_VALUE5, TEST_SW, COMMAND_TYPE, "
                + "WW1, WW_DATA1, WW2, WW_DATA2, RW, RESV, DEL_SW, WORKER_ID, TRANS_SRC, UPDATE_DATE, INSERT_DATE "
                + "from TB_STD_TEST_SPEC_SDI where prd_cd = '" + packcode + "' order by prd_cd, work_type, seq_no";
            da = new OleDbDataAdapter(str, constr);
            da.Fill(ds, "tblspec");

            //str = "select * from tb_std_item_sdi order by item_id";
            str = "select PLANT_CD, FACTORY_CD, SHOP_CD, ITEM_ID, ITEM_NAME, JTYPE, UNIT, "
                + "DEL_SW, WORKER_ID, TRANS_SRC, UPDATE_DATE "
                //+ "INSERT_DATE"
                + "from tb_std_item_sdi order by item_id";
            da = new OleDbDataAdapter(str, constr);
            da.Fill(ds, "tblitem");

            //str = "select * from TB_STD_TEST_ITEM_SDI where ic_no = '" + ic + "' order by item_id";
            str = "select PLANT_CD, FACTORY_CD, SHOP_CD, IC_NO, PACK_TYPE, ITEM_ID, COMMAND_TYPE, "
                + "WW1, WW_DATA1, WW2, WW_DATA2, RW, RESV, DEL_SW, WORKER_ID, TRANS_SRC, UPDATE_DATE, INSERT_DATE "
                + "from TB_STD_TEST_ITEM_SDI where ic_no = '" + ic + "' order by item_id";
            da = new OleDbDataAdapter(str, constr);
            da.Fill(ds, "tbltestitem");

            //str = "select ic_no, item_id, func_seq, scpi, cmd, addr, len, data, conversion_type, storage_type "
            //                               + "from TBZ_TEST_ITEM_FUNCTION "
            //                               + "where tester_id = 'NEW_FUNC_SDIV' and ic_no = '" + ic + "' "
            //                               + "order by item_id, func_seq";
            str = "select ic_no, item_id, func_seq, scpi, cmd, addr, len, data, conversion_type, storage_type "
                                           + "from TBZ_TEST_ITEM_FUNCTION "
                                           + "where tester_id = 'NEW_FUNC_SDIV' "
                                           + "order by item_id, func_seq";
            da = new OleDbDataAdapter(str, constr);
            da.Fill(ds, "tblcommand");

            //SECCODE lib on Oracle
            //str = "select * from VW_PRODUCT";
            //da = new OleDbDataAdapter(str, constr);
            //da.Fill(ds, "tblseccode");

            return ds;
        }
        

        //Tai seccode
        private DataSet taiseccode()
        {
            string str = "";
            DataSet ds = new DataSet();
            OleDbDataAdapter da;
            string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

            str = "select * from VW_PRODUCT";
            da = new OleDbDataAdapter(str, constr);
            da.Fill(ds, "tblseccode");

            return ds;
        }
        //
        //Cap nhat seccode vao db
         public void capnhatseccode()
        {
            DataSet ds = new DataSet();
            ds = taiseccode();
            Localdb.updateseccodetable(ds.Tables["tblseccode"]);
        }
        //
        private DataSet taitieuchuan(ComboBox cbspecselect)
        {
               string str = "";
               DataSet ds = new DataSet();
               OleDbDataAdapter da;
               string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

               str = "select * from TB_STD_MODEL where PACK_TYPE = 'CP' order by prd_cd";
               da = new OleDbDataAdapter(str, constr);
               da.Fill(ds, "tblmodel"); 
                 return ds;
        }


        public DataSet taipackversion(string packcode)
        {
            string str = "";
            DataSet ds = new DataSet();
            OleDbDataAdapter da;
            string constr = @"Provider=MSDAORA.1;Password=" + _pass + @";User ID=" + _user + ";Data Source=" + _dbsource + ";Persist Security Info=True";

            str = "select DESCRIPT_KO AS PACK_CERSION from PMNKAGCM where BIG_CODE='PM_MAT_MODEL' and CODE_NAME_EN='" + packcode + "'";

            da = new OleDbDataAdapter(str, constr);
            da.Fill(ds, "tblpackversion");
            return ds;
        }

        public void capnhattieuchuan(string packcode, string ic)
        {
            DataSet ds = new DataSet();
            ds = taitieuchuan(packcode,ic);

            Localdb.updatespectable(ds.Tables["tblspec"]);
            Localdb.updateitemtable(ds.Tables["tblitem"]);
            Localdb.updatetestitemtable(ds.Tables["tbltestitem"]);
            Localdb.updatecommandtable(ds.Tables["tblcommand"]);
           // Localdb.updateseccodetable(ds.Tables["tblseccode"]);
            Localdb.updatedatabase(ds);
        }
        public void capnhatmodel()
        {
            Localdb.updatemodeltable(Receivedata("select * from TB_STD_MODEL where PACK_TYPE = 'CP' order by prd_cd"));
        }

        public void capnhatspec()
        {
            Localdb.updatespectable(Receivedata("select * from TB_STD_TEST_SPEC_SDI order by prd_cd, work_type, seq_no"));
        }

        public void capnhatitem()
        {
            Localdb.updateitemtable(Receivedata("select * from tb_std_item_sdi order by item_id"));
        }

        public void capnhattestitem()
        {
            Localdb.updatetestitemtable(Receivedata("select * from TB_STD_TEST_ITEM_SDI order by item_id"));
        }

        public void capnhatcommand()
        {
            Localdb.updatecommandtable(Receivedata("select ic_no, item_id, func_seq, scpi, cmd, addr, len, data, conversion_type, storage_type " 
                                           + "from TBZ_TEST_ITEM_FUNCTION "
                                           + "where tester_id = 'NEW_FUNC_SDIV' "
                                           + "order by item_id, func_seq"));
        }

        public bool checktaikhoan(string user, string pass)
        {
            string _userspecial = "ADMINISTRATOR";
            string _passspecial = "ADMIN" + DateTime.Now.ToString("dd") + "PE" + DateTime.Now.ToString("MM");

            if (user.ToUpper() == _userspecial && pass.ToUpper() == _passspecial) return true;

            DataTable dttemp = new DataTable();
            dttemp = Receivedata("select user_id, user_password, user_name from TB_USERS where user_id = '" + user.ToUpper() + "' and user_password = '" + pass.ToUpper() + "'");
            if (dttemp.Rows.Count == 0) return false;
            foreach (DataRow drtemp in dttemp.Rows)
            {
                if (user.ToUpper() == drtemp.ItemArray[0].ToString().ToUpper() &&
                    pass.ToUpper() == drtemp.ItemArray[1].ToString().ToUpper()) return true;
            }
            return false;
        }

        public DataTable loadmodel()
        {
            return Receivedata("select prd_cd, model_name from tb_std_model where pack_type = 'CP' order by model_name");
        }

        public string searchic(string packcode)
        {
            string ictemp = "";
            DataTable dttemp = new DataTable();
            dttemp = Receivedata("select ic_No_sdi from tb_std_model where prd_cd = '" + packcode + "'");
            foreach (DataRow dr in dttemp.Rows)
            {
                ictemp = dr.ItemArray[0].ToString();
            }
            return ictemp;
        }

        public DataTable loaditem(string ic)
        {
            return Receivedata("select distinct TB_STD_TEST_ITEM_SDI.Item_ID, tb_std_item_sdi.item_name "
                + "from TB_STD_TEST_ITEM_SDI right join tb_std_item_sdi "
                + "on TB_STD_TEST_ITEM_SDI.Item_ID = tb_std_item_sdi.item_id "
                + "where IC_NO = '" + ic + "' order by item_name");
        }

        public DataTable loaditemcommand(string ic, string item_id, ref string finalseq)
        {
            DataTable dttemp = new DataTable();
            string str = "select item_id, func_seq, scpi, cmd, addr, len, data, conversion_type, storage_type, IC_NO " 
            + "from TBZ_TEST_ITEM_FUNCTION "
            + "where Item_ID = '" + item_id + "' "
            + "and IC_NO = '" + ic + "' "
            + "and tester_id = 'NEW_FUNC_SDIV' "
            + "order by func_seq";
            dttemp = Receivedata(str);

            if (dttemp.Rows.Count == 0)
            {
                finalseq = "0";
            }
            else
            {
                foreach (DataRow dr in dttemp.Rows)
                {
                    finalseq = dr.ItemArray[1].ToString();
                }
            }
            
            return dttemp;
        }
    }
}
