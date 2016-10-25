using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_AreaDL
    {

        string strquery = "";

        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Area table.
        /// </summary>
        public Boolean SaveM_AreaSP(M_Area m_Area, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_AreaSave";

                scom.Parameters.Add("@AreaCode", SqlDbType.VarChar, 20).Value = m_Area.AreaCode;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 50).Value = m_Area.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 50).Value = m_Area.Locacode;
                scom.Parameters.Add("@Descri", SqlDbType.VarChar, 120).Value = m_Area.Descri;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_Area.Datex;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = m_Area.Userx;
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


        public DataTable SelectAllm_Area()
        {
            try
            {
                strquery = @"select AreaCode as 'Area Code' , Descri as 'Area Name' from M_Area";
                DataTable dtm_Area = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Area;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Area Selectm_Area(M_Area objm_Area)
        {
            try
            {
                strquery = @"select * from M_Area where AreaCode = '" + objm_Area.AreaCode + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Area.AreaCode = drType["AreaCode"].ToString();
                    objm_Area.Compcode = drType["Compcode"].ToString();
                    objm_Area.Locacode = drType["Locacode"].ToString();
                    objm_Area.Descri = drType["Descri"].ToString();
                    objm_Area.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objm_Area.Userx = drType["Userx"].ToString();
                    return objm_Area;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Area(string stringM_Area)
        {
            try
            {
                string xstrquery = @"select AreaCode From M_Area   WHERE AreaCode = '" + stringM_Area  + "'";
                DataRow drM_Area = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Area != null)
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
