using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smartOffice_Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SmartAnything_DL
{
    public class M_BankDL
    {

        string strquery = "";

        public Boolean SaveBankSP(M_Bank oBank, int formMode)
        {
            
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "Bank_Save";

                scom.Parameters.Add("@BANK_CODE", SqlDbType.VarChar, 10).Value = oBank.BANK_CODE;
                scom.Parameters.Add("@BANK_NAME", SqlDbType.VarChar, 50).Value = oBank.BANK_NAME;
                scom.Parameters.Add("@BANK_DTRANSFER", SqlDbType.Int).Value = 0;
                scom.Parameters.Add("@BANK_EXBATCH", SqlDbType.Int).Value = 0;
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

        public DataTable SelectAllBanks()
        {
            try
            {
                strquery = @"SELECT [BANK_CODE],[BANK_NAME]  FROM M_Bank";

                DataTable dtBank = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtBank;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public M_Bank SelectBank(M_Bank objBank)
        {
            try
            {
                strquery = @"select * From M_Bank where BANK_CODE = '" + objBank.BANK_CODE + "'";

                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objBank.BANK_CODE = drType["BANK_CODE"].ToString();
                    objBank.BANK_NAME = drType["BANK_NAME"].ToString();
                    return objBank;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingBank(string  stringBank)
        {
            try
            {
                string xstrquery = @"select BANK_CODE From M_Bank   WHERE BANK_CODE = '" + stringBank.Trim() + "'";
                DataRow drBank = u_DBConnection.ReturnDataRow(xstrquery);

                if (drBank != null)
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
    }
}
