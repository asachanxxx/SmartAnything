using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_LocaDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Loca table.
        /// </summary>
        public Boolean SaveM_LocaSP(M_Loca m_Loca, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_LocaSave";

                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Loca.Locacode;
                scom.Parameters.Add("@Companycode", SqlDbType.VarChar, 20).Value = m_Loca.Companycode;
                scom.Parameters.Add("@StockCode", SqlDbType.VarChar, 20).Value = m_Loca.StockCode;
                scom.Parameters.Add("@Locaname", SqlDbType.VarChar, 50).Value = m_Loca.Locaname;
                scom.Parameters.Add("@Add1", SqlDbType.VarChar, 50).Value = m_Loca.Add1;
                scom.Parameters.Add("@Add2", SqlDbType.VarChar, 50).Value = m_Loca.Add2;
                scom.Parameters.Add("@Add3", SqlDbType.VarChar, 50).Value = m_Loca.Add3;
                scom.Parameters.Add("@Tpno", SqlDbType.VarChar, 20).Value = m_Loca.Tpno;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 20).Value = m_Loca.Fax;
                scom.Parameters.Add("@Emailx", SqlDbType.VarChar, 50).Value = m_Loca.Emailx;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = m_Loca.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_Loca.Datex;
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


        public DataTable SelectAllm_Loca()
        {
            try
            {
                strquery = @"SELECT Locacode,Locaname FROM dbo.M_Loca";
                DataTable dtm_Loca = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Loca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Loca Selectm_Loca(M_Loca objm_Loca)
        {
            try
            {
                strquery = @"SELECT * FROM dbo.M_Loca  WHERE Locacode = '" + objm_Loca.Locacode.Trim() + "' ";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Loca.Locacode = drType["Locacode"].ToString();
                    objm_Loca.Companycode = drType["Companycode"].ToString();
                    objm_Loca.StockCode = drType["StockCode"].ToString();
                    objm_Loca.Locaname = drType["Locaname"].ToString();
                    objm_Loca.Add1 = drType["Add1"].ToString();
                    objm_Loca.Add2 = drType["Add2"].ToString();
                    objm_Loca.Add3 = drType["Add3"].ToString();
                    objm_Loca.Tpno = drType["Tpno"].ToString();
                    objm_Loca.Fax = drType["Fax"].ToString();
                    objm_Loca.Emailx = drType["Emailx"].ToString();
                    objm_Loca.Userx = drType["Userx"].ToString();
                    objm_Loca.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_Loca;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Loca(string stringM_Loca)
        {
            try
            {
                string xstrquery = @"select Locacode from M_Loca where Locacode = '" + stringM_Loca.Trim() + "'";
                DataRow drM_Loca = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Loca != null)
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
