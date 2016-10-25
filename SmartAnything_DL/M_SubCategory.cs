using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_SubCategoryDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_SubCategory table.
        /// </summary>
        public Boolean Savem_SubCategorySP(M_SubCategory m_SubCategory, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_SubCategorySave";

                scom.Parameters.Add("@Codex", SqlDbType.VarChar, 20).Value = m_SubCategory.Codex;
                scom.Parameters.Add("@CategoryID", SqlDbType.VarChar, 20).Value = m_SubCategory.CategoryID;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 50).Value = m_SubCategory.Descr;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = m_SubCategory.date;
                scom.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = m_SubCategory.type;
                scom.Parameters.Add("@Lockedby", SqlDbType.VarChar, 20).Value = m_SubCategory.Lockedby;
                scom.Parameters.Add("@Locked", SqlDbType.Bit, 1).Value = m_SubCategory.Locked;
                scom.Parameters.Add("@Userx", SqlDbType.NChar, 10).Value = m_SubCategory.Userx;
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


        public DataTable SelectAllm_SubCategory(string subcat)
        {
            try
            {
                strquery = @"SELECT Codex AS 'SubCategory Code' , Descr AS 'Description' FROM dbo.M_SubCategory WHERE CategoryID = '" + subcat.Trim() + "'";
                DataTable dtm_SubCategory = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_SubCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_SubCategory Selectm_SubCategory(M_SubCategory objm_SubCategory)
        {
            try
            {
                strquery = @"select * FROM M_subcategory WHERE codex = '" + objm_SubCategory .Codex.Trim()+ "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_SubCategory.Codex = drType["Codex"].ToString();
                    objm_SubCategory.CategoryID = drType["CategoryID"].ToString();
                    objm_SubCategory.Descr = drType["Descr"].ToString();
                    objm_SubCategory.date = DateTime.Parse(drType["date"].ToString());
                    objm_SubCategory.type = drType["type"].ToString();
                    objm_SubCategory.Lockedby = drType["Lockedby"].ToString();
                    objm_SubCategory.Locked = bool.Parse(drType["Locked"].ToString());
                    objm_SubCategory.Userx = drType["Userx"].ToString();
                    return objm_SubCategory;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_SubCategory Selectm_SubCategory_one(M_SubCategory objm_SubCategory)
        {
            try
            {
                strquery = @"select * FROM M_subcategory WHERE codex = '" + objm_SubCategory.Codex.Trim() + "'  CategoryID = '" + objm_SubCategory.CategoryID.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_SubCategory.Codex = drType["Codex"].ToString();
                    objm_SubCategory.CategoryID = drType["CategoryID"].ToString();
                    objm_SubCategory.Descr = drType["Descr"].ToString();
                    objm_SubCategory.date = DateTime.Parse(drType["date"].ToString());
                    objm_SubCategory.type = drType["type"].ToString();
                    objm_SubCategory.Lockedby = drType["Lockedby"].ToString();
                    objm_SubCategory.Locked = bool.Parse(drType["Locked"].ToString());
                    objm_SubCategory.Userx = drType["Userx"].ToString();
                    return objm_SubCategory;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool ExistingM_SubCategory(string category , string subcat)
        {
            try
            {
                string xstrquery = @"select Codex From M_SubCategory   WHERE categoryID = '" + category.Trim() + "' AND codex = '" + subcat.Trim() + "'";
                DataRow drM_SubCategory = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_SubCategory != null)
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

        public static bool ExistingM_SubCategory(string subcat)
        {
            try
            {
                string xstrquery = @"select Codex From M_SubCategory   WHERE codex = '" + subcat.Trim() + "'";
                DataRow drM_SubCategory = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_SubCategory != null)
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

        public List<M_SubCategory> SelectM_SubCategoryMulti(string caytegory )
        {
            List<M_SubCategory> retval = new List<M_SubCategory>();
            try
            {
                strquery = @"select * from m_SubCategory where CategoryID = '" + caytegory.Trim() + "'";
                DataTable dtm_SubCategory = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_SubCategory.Rows)
                {
                    if (drType != null)
                    {
                        M_SubCategory objm_SubCategory = new M_SubCategory();
                        objm_SubCategory.Codex = drType["Codex"].ToString();
                        objm_SubCategory.CategoryID = drType["CategoryID"].ToString();
                        objm_SubCategory.Descr = drType["Descr"].ToString();
                        objm_SubCategory.date = DateTime.Parse(drType["date"].ToString());
                        objm_SubCategory.type = drType["type"].ToString();
                        objm_SubCategory.Lockedby = drType["Lockedby"].ToString();
                        objm_SubCategory.Locked = bool.Parse(drType["Locked"].ToString());
                        objm_SubCategory.Userx = drType["Userx"].ToString();
                        retval.Add(objm_SubCategory);
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
