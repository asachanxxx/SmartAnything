using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_RouteDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Route table.
        /// </summary>
        public Boolean SaveM_RouteSP(M_Route m_Route, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_RouteSave";

                scom.Parameters.Add("@Routecode", SqlDbType.VarChar, 20).Value = m_Route.Routecode;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = m_Route.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Route.Locacode;
                scom.Parameters.Add("@TerritoryCode", SqlDbType.VarChar, 20).Value = m_Route.TerritoryCode;
                scom.Parameters.Add("@AreaCode", SqlDbType.VarChar, 20).Value = m_Route.AreaCode;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 50).Value = m_Route.Descr;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_Route.Datex;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 50).Value = m_Route.Userx;
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


        public DataTable SelectAllm_Route()
        {
            try
            {
                strquery = @"select Routecode as 'Route Code' , Descr as 'Route Name' from M_Route";
                DataTable dtm_Route = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Route;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Route Selectm_Route(M_Route objm_Route)
        {
            try
            {
                strquery = @"select * from M_Route where Routecode = '" + objm_Route.Routecode.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Route.Routecode = drType["Routecode"].ToString();
                    objm_Route.Compcode = drType["Compcode"].ToString();
                    objm_Route.Locacode = drType["Locacode"].ToString();
                    objm_Route.TerritoryCode = drType["TerritoryCode"].ToString();
                    objm_Route.AreaCode = drType["AreaCode"].ToString();
                    objm_Route.Descr = drType["Descr"].ToString();
                    objm_Route.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objm_Route.Userx = drType["Userx"].ToString();
                    return objm_Route;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Route(string stringM_Route)
        {
            try
            {
                string xstrquery = @"select Routecode From M_Route   WHERE Routecode = '" + stringM_Route  + "'";
                DataRow drM_Route = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Route != null)
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
