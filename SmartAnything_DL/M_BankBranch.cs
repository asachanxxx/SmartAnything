using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_BankBranchDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_BankBranch table.
        /// </summary>
        public Boolean Savem_BankBranchSP(M_BankBranch m_BankBranch, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_BankBranchSave";

                scom.Parameters.Add("@BBRANCH_BANK", SqlDbType.VarChar, 10).Value = m_BankBranch.BBRANCH_BANK;
                scom.Parameters.Add("@BBRANCH_CODE", SqlDbType.VarChar, 4).Value = m_BankBranch.BBRANCH_CODE;
                scom.Parameters.Add("@BBRANCH_NAME", SqlDbType.VarChar, 50).Value = m_BankBranch.BBRANCH_NAME;
                scom.Parameters.Add("@BBRANCH_CTIME", SqlDbType.Decimal, 5).Value = m_BankBranch.BBRANCH_CTIME;
                scom.Parameters.Add("@BBRANCH_DTRANSFER", SqlDbType.Decimal, 5).Value = m_BankBranch.BBRANCH_DTRANSFER;
                scom.Parameters.Add("@BBRANCH_EXBATCH", SqlDbType.VarChar, 7).Value = m_BankBranch.BBRANCH_EXBATCH;
                scom.Parameters.Add("@InsMode", SqlDbType.Int).Value = formMode; // For insert
                scom.Parameters.Add("@RtnValue", SqlDbType.Int).Value = 0;

                u_DBConnection dbcon = new u_DBConnection();
                retvalue = dbcon.RunQuery(scom);
                return retvalue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public DataTable SelectAllm_BankBranch()
        {
            try
            {
                strquery = @"select BBRANCH_CODE,BBRANCH_NAME from M_BankBranch";
                DataTable dtm_BankBranch = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_BankBranch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_BankBranch Selectm_BankBranch(M_BankBranch objm_BankBranch)
        {
            try
            {
                //strquery = @"select * from m_BankBranch where BBRANCH_CODE = '" + objm_BankBranch.BBRANCH_CODE + "'";
                strquery = "select * from M_BankBranch where BBRANCH_BANK = '" + objm_BankBranch.BBRANCH_BANK + "' and BBRANCH_CODE = '" + objm_BankBranch.BBRANCH_CODE+ "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_BankBranch.BBRANCH_BANK = drType["BBRANCH_BANK"].ToString();
                    objm_BankBranch.BBRANCH_CODE = drType["BBRANCH_CODE"].ToString();
                    objm_BankBranch.BBRANCH_NAME = drType["BBRANCH_NAME"].ToString();
                    objm_BankBranch.BBRANCH_CTIME = decimal.Parse(drType["BBRANCH_CTIME"].ToString());
                    objm_BankBranch.BBRANCH_DTRANSFER = decimal.Parse(drType["BBRANCH_DTRANSFER"].ToString());
                    objm_BankBranch.BBRANCH_EXBATCH = drType["BBRANCH_EXBATCH"].ToString();
                    return objm_BankBranch;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_BankBranch(string stringm_BankBranch)
        {
            try
            {
                string xstrquery = @"select BBRANCH_CODE From M_BankBranch   WHERE BBRANCH_CODE = '" + stringm_BankBranch + "' ";
                DataRow drM_BankBranch = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_BankBranch != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<M_BankBranch> SelectM_BankBranchMulti(M_BankBranch objm_BankBranch2)
        {
            List<M_BankBranch> retval = new List<M_BankBranch>();
            try
            {
                strquery = @"select * from m_BankBranch where BBRANCH_CODE = '" + objm_BankBranch2.BBRANCH_CODE + "'";
                DataTable dtm_BankBranch = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_BankBranch.Rows)
                {
                    if (drType != null)
                    {
                        M_BankBranch objm_BankBranch = new M_BankBranch();
                        objm_BankBranch.BBRANCH_BANK = drType["BBRANCH_BANK"].ToString();
                        objm_BankBranch.BBRANCH_CODE = drType["BBRANCH_CODE"].ToString();
                        objm_BankBranch.BBRANCH_NAME = drType["BBRANCH_NAME"].ToString();
                        objm_BankBranch.BBRANCH_CTIME = decimal.Parse(drType["BBRANCH_CTIME"].ToString());
                        objm_BankBranch.BBRANCH_DTRANSFER = decimal.Parse(drType["BBRANCH_DTRANSFER"].ToString());
                        objm_BankBranch.BBRANCH_EXBATCH = drType["BBRANCH_EXBATCH"].ToString();
                        retval.Add(objm_BankBranch);
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        #endregion
    }
}
