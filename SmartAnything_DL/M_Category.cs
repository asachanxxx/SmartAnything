using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_CategoryDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Category table.
        /// </summary>
        public Boolean SaveM_CategorySP(M_Category m_Category, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_CategorySave";

                scom.Parameters.Add("@Codex", SqlDbType.VarChar, 20).Value = m_Category.Codex;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 50).Value = m_Category.Descr;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = m_Category.date;
                scom.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = m_Category.type;
                scom.Parameters.Add("@Lockedby", SqlDbType.VarChar, 20).Value = m_Category.Lockedby;
                scom.Parameters.Add("@Locked", SqlDbType.Bit, 1).Value = m_Category.Locked;
                scom.Parameters.Add("@Userx", SqlDbType.NChar, 10).Value = m_Category.Userx;
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


        public DataTable SelectAllm_Category()
        {
            try
            {
                strquery = @"SELECT   Codex as 'Category Code',Descr as 'Description' FROM M_Category";
                DataTable dtm_Category = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Category Selectm_Category(M_Category objm_Category)
        {
            try
            {
                strquery = @"SELECT   * FROM M_Category where Codex = '" + objm_Category.Codex.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Category.Codex = drType["Codex"].ToString();
                    objm_Category.Descr = drType["Descr"].ToString();
                    objm_Category.date = DateTime.Parse(drType["date"].ToString());
                    objm_Category.type = drType["type"].ToString();
                    objm_Category.Lockedby = drType["Lockedby"].ToString();
                    objm_Category.Locked = bool.Parse(drType["Locked"].ToString());
                    objm_Category.Userx = drType["Userx"].ToString();
                    return objm_Category;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Category(string stringM_Category)
        {
            try
            {
                string xstrquery = @"SELECT   Codex FROM M_Category where Codex = '" + stringM_Category.Trim() + "'";
                DataRow drM_Category = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Category != null)
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
