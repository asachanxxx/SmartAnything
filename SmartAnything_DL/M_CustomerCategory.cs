using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_CustomerCategoryDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_CustomerCategory table.
        /// </summary>
        public Boolean Savem_CustomerCategorySP(M_CustomerCategory m_CustomerCategory, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_CustomerCategorySave";

                scom.Parameters.Add("@CusCateID", SqlDbType.VarChar, 20).Value = m_CustomerCategory.CusCateID;
                scom.Parameters.Add("@Description", SqlDbType.VarChar, 120).Value = m_CustomerCategory.Description;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = m_CustomerCategory.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_CustomerCategory.Datex;
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


        public DataTable SelectAllm_CustomerCategory()
        {
            try
            {
                strquery = @"SELECT CUScateid  AS 'Category Code' , Description  FROM M_CustomerCategory";
                DataTable dtm_CustomerCategory = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_CustomerCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_CustomerCategory Selectm_CustomerCategory(M_CustomerCategory objm_CustomerCategory)
        {
            try
            {
                strquery = @"select * from m_CustomerCategory where CusCateID = '" + objm_CustomerCategory.CusCateID + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_CustomerCategory.CusCateID = drType["CusCateID"].ToString();
                    objm_CustomerCategory.Description = drType["Description"].ToString();
                    objm_CustomerCategory.Userx = drType["Userx"].ToString();
                    objm_CustomerCategory.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_CustomerCategory;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_CustomerCategory(string stringm_CustomerCategory)
        {
            try
            {
                string xstrquery = @"select CusCateID From M_CustomerCategory   WHERE CusCateID = '" + stringm_CustomerCategory + "' ";
                DataRow drM_CustomerCategory = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_CustomerCategory != null)
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

        public List<M_CustomerCategory> SelectM_CustomerCategoryMulti(M_CustomerCategory objm_CustomerCategory2)
        {
            List<M_CustomerCategory> retval = new List<M_CustomerCategory>();
            try
            {
                strquery = @"select * from m_CustomerCategory where CusCateID = '" + objm_CustomerCategory2.CusCateID + "'";
                DataTable dtm_CustomerCategory = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_CustomerCategory.Rows)
                {
                    if (drType != null)
                    {
                        M_CustomerCategory objm_CustomerCategory = new M_CustomerCategory();
                        objm_CustomerCategory.CusCateID = drType["CusCateID"].ToString();
                        objm_CustomerCategory.Description = drType["Description"].ToString();
                        objm_CustomerCategory.Userx = drType["Userx"].ToString();
                        objm_CustomerCategory.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objm_CustomerCategory);
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
