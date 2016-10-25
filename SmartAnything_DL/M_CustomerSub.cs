using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_CustomerSubDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_CustomerSub table.
        /// </summary>
        public Boolean Savem_CustomerSubSP(M_CustomerSub m_CustomerSub, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_CustomerSubSave";

                scom.Parameters.Add("@CussubID", SqlDbType.VarChar, 20).Value = m_CustomerSub.CussubID;
                scom.Parameters.Add("@CatID", SqlDbType.VarChar, 20).Value = m_CustomerSub.CatID;
                scom.Parameters.Add("@Description", SqlDbType.VarChar, 120).Value = m_CustomerSub.Description;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = m_CustomerSub.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_CustomerSub.Datex;
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


        public DataTable SelectAllm_CustomerSub(string catid)
        {
            try
            {
                strquery = @"SELECT cussubid AS 'Code' , DESCRIPTION FROM M_CustomerSub WHERE  catid = '" + catid.Trim() + "'";
                DataTable dtm_CustomerSub = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_CustomerSub;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_CustomerSub Selectm_CustomerSub(M_CustomerSub objm_CustomerSub)
        {
            try
            {
                strquery = @"select * from m_CustomerSub where CussubID = '" + objm_CustomerSub.CussubID + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_CustomerSub.CussubID = drType["CussubID"].ToString();
                    objm_CustomerSub.CatID = drType["CatID"].ToString();
                    objm_CustomerSub.Description = drType["Description"].ToString();
                    objm_CustomerSub.Userx = drType["Userx"].ToString();
                    objm_CustomerSub.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_CustomerSub;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_CustomerSub(string cussubcode,string catid)
        {
            try
            {
                string xstrquery = @"SELECT cussubid FROM M_CustomerSub WHERE cussubid = '" + cussubcode.Trim() + "' AND catid = '" + catid.Trim() + "'";
                DataRow drM_CustomerSub = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_CustomerSub != null)
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

        public List<M_CustomerSub> SelectM_CustomerSubMulti(M_CustomerSub objm_CustomerSub2)
        {
            List<M_CustomerSub> retval = new List<M_CustomerSub>();
            try
            {
                strquery = @"select * from m_CustomerSub where CussubID = '" + objm_CustomerSub2.CussubID + "'";
                DataTable dtm_CustomerSub = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_CustomerSub.Rows)
                {
                    if (drType != null)
                    {
                        M_CustomerSub objm_CustomerSub = new M_CustomerSub();
                        objm_CustomerSub.CussubID = drType["CussubID"].ToString();
                        objm_CustomerSub.CatID = drType["CatID"].ToString();
                        objm_CustomerSub.Description = drType["Description"].ToString();
                        objm_CustomerSub.Userx = drType["Userx"].ToString();
                        objm_CustomerSub.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objm_CustomerSub);
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
