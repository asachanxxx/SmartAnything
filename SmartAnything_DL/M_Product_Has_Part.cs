using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_Product_Has_PartDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Product_Has_Parts table.
        /// </summary>
        public Boolean Savem_Product_Has_PartSP(M_Product_Has_Parts m_Product_Has_Part, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_Product_Has_PartsSave";

                scom.Parameters.Add("@productId", SqlDbType.VarChar, 10).Value = m_Product_Has_Part.productId;
                scom.Parameters.Add("@PartId", SqlDbType.VarChar, 10).Value = m_Product_Has_Part.PartId;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = m_Product_Has_Part.triggerVal;
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


        public DataTable SelectAllm_Product_Has_Part()
        {
            try
            {
                strquery = @"SELECT productid , partid FROM M_Product_Has_Parts";
                DataTable dtm_Product_Has_Part = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Product_Has_Part;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Product_Has_Parts Selectm_Product_Has_Part(M_Product_Has_Parts objm_Product_Has_Part)
        {
            try
            {
                strquery = @"select * from M_Product_Has_Parts where CompCode = '" + objm_Product_Has_Part.productId + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Product_Has_Part.productId = drType["productId"].ToString();
                    objm_Product_Has_Part.PartId = drType["PartId"].ToString();
                    objm_Product_Has_Part.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objm_Product_Has_Part;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Product_Has_Part(string stringm_Product_Has_Part)
        {
            try
            {
                string xstrquery = @"select CompCode From M_Product_Has_Part   WHERE CompCode = '" + stringm_Product_Has_Part + "' ";
                DataRow drM_Product_Has_Part = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Product_Has_Part != null)
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

        public List<M_Product_Has_Parts> SelectM_Product_Has_PartMulti(M_Product_Has_Parts objm_Product_Has_Part2)
        {
            List<M_Product_Has_Parts> retval = new List<M_Product_Has_Parts>();
            try
            {
                strquery = @"select * from m_Product_Has_Parts where productId = '" + objm_Product_Has_Part2.productId + "'";
                DataTable dtm_Product_Has_Part = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_Product_Has_Part.Rows)
                {
                    if (drType != null)
                    {
                        M_Product_Has_Parts objm_Product_Has_Part = new M_Product_Has_Parts();
                        objm_Product_Has_Part.productId = drType["productId"].ToString();
                        objm_Product_Has_Part.PartId = drType["PartId"].ToString();
                        objm_Product_Has_Part.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objm_Product_Has_Part);
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
