using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_CNTypeDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_CNTypes table.
        /// </summary>
        public Boolean Savem_CNTypeSP(M_CNTypes m_CNType, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_CNTypesSave";

                scom.Parameters.Add("@TypeID", SqlDbType.VarChar, 20).Value = m_CNType.TypeID;
                scom.Parameters.Add("@TypeName", SqlDbType.VarChar, 40).Value = m_CNType.TypeName;
                scom.Parameters.Add("@UserCode", SqlDbType.VarChar, 20).Value = m_CNType.UserCode;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_CNType.Datex;
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


        public DataTable SelectAllm_CNType()
        {
            try
            {
                strquery = @"select TypeID,TypeName from M_CNTypes";
                DataTable dtm_CNType = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_CNType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_CNTypes Selectm_CNType(M_CNTypes objm_CNType)
        {
            try
            {
                strquery = @"select * from M_CNTypes where TypeID = '" + objm_CNType.TypeID + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_CNType.TypeID = drType["TypeID"].ToString();
                    objm_CNType.TypeName = drType["TypeName"].ToString();
                    objm_CNType.UserCode = drType["UserCode"].ToString();
                    objm_CNType.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_CNType;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_CNType(string stringm_CNType)
        {
            try
            {
                string xstrquery = @"select TypeID From M_CNTypes   WHERE TypeID = '" + stringm_CNType + "' ";
                DataRow drM_CNType = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_CNType != null)
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

        public List<M_CNTypes> SelectM_CNTypeMulti(M_CNTypes objm_CNType2)
        {
            List<M_CNTypes> retval = new List<M_CNTypes>();
            try
            {
                strquery = @"select * from M_CNTypes where TypeID = '" + objm_CNType2.TypeID + "'";
                DataTable dtm_CNType = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_CNType.Rows)
                {
                    if (drType != null)
                    {
                        M_CNTypes objm_CNType = new M_CNTypes();
                        objm_CNType.TypeID = drType["TypeID"].ToString();
                        objm_CNType.TypeName = drType["TypeName"].ToString();
                        objm_CNType.UserCode = drType["UserCode"].ToString();
                        objm_CNType.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objm_CNType);
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
