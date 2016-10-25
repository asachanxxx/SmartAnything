using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class P_AutoNumberDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the P_AutoNumber table.
        /// </summary>
        public Boolean SaveP_AutoNumberSP(P_AutoNumber p_AutoNumber, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "P_AutoNumberSave";

                scom.Parameters.Add("@Screen", SqlDbType.VarChar, 50).Value = p_AutoNumber.Screen;
                scom.Parameters.Add("@ID", SqlDbType.VarChar, 50).Value = p_AutoNumber.ID;
                scom.Parameters.Add("@Serial", SqlDbType.Int, 4).Value = p_AutoNumber.Serial;
                scom.Parameters.Add("@Mode", SqlDbType.Int, 4).Value = p_AutoNumber.Mode;
                scom.Parameters.Add("@Prefix", SqlDbType.VarChar, 5).Value = p_AutoNumber.Prefix;
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


        public DataTable SelectAllp_AutoNumber()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [M_Company]";
                DataTable dtp_AutoNumber = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtp_AutoNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public P_AutoNumber Selectp_AutoNumber(P_AutoNumber objp_AutoNumber)
        {
            try
            {
                strquery = @"SELECT * FROM P_AutoNumber where Screen = '" + objp_AutoNumber.Screen.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objp_AutoNumber.Screen = drType["Screen"].ToString();
                    objp_AutoNumber.ID = drType["ID"].ToString();
                    objp_AutoNumber.Serial = int.Parse(drType["Serial"].ToString());
                    objp_AutoNumber.Mode = int.Parse(drType["Mode"].ToString());
                    objp_AutoNumber.Prefix = drType["Prefix"].ToString();
                    return objp_AutoNumber;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingP_AutoNumber(string stringP_AutoNumber)
        {
            try
            {
                string xstrquery = @"select CompCode From M_Company   WHERE CompCode = ";
                DataRow drP_AutoNumber = u_DBConnection.ReturnDataRow(xstrquery);
                if (drP_AutoNumber != null)
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

















        #endregion
    }
}
