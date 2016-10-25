using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_TerritoryDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Territory table.
        /// </summary>
        public Boolean SaveM_TerritorySP(M_Territory m_Territory, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_TerritorySave";

                scom.Parameters.Add("@TerritoryCode", SqlDbType.VarChar, 20).Value = m_Territory.TerritoryCode;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = m_Territory.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Territory.Locacode;
                scom.Parameters.Add("@AreaCode", SqlDbType.VarChar, 20).Value = m_Territory.AreaCode;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 50).Value = m_Territory.Descr;
                scom.Parameters.Add("@UserNamex", SqlDbType.VarChar, 20).Value = m_Territory.UserNamex;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_Territory.Datex;
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


        public DataTable SelectAllm_Territory()
        {
            try
            {
                strquery = @"select TerritoryCode as 'Territory Code' , Descr as 'Territory Name' from M_Territory";
                DataTable dtm_Territory = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Territory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Territory Selectm_Territory(M_Territory objm_Territory)
        {
            try
            {
                strquery = @"select * from M_Territory where TerritoryCode = '" + objm_Territory.TerritoryCode + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Territory.TerritoryCode = drType["TerritoryCode"].ToString();
                    objm_Territory.Compcode = drType["Compcode"].ToString();
                    objm_Territory.Locacode = drType["Locacode"].ToString();
                    objm_Territory.AreaCode = drType["AreaCode"].ToString();
                    objm_Territory.Descr = drType["Descr"].ToString();
                    objm_Territory.UserNamex = drType["UserNamex"].ToString();
                    objm_Territory.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_Territory;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Territory(string stringM_Territory)
        {
            try
            {
                string xstrquery = @"select TerritoryCode From M_Territory   WHERE TerritoryCode = '" + stringM_Territory + "'";
                DataRow drM_Territory = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Territory != null)
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
