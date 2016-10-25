using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_CNReasonDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_CNReason table.
        /// </summary>
        public Boolean Savem_CNReasonSP(M_CNReason m_CNReason, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_CNReasonSave";

                scom.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = m_CNReason.ID;
                scom.Parameters.Add("@Reason", SqlDbType.VarChar, 40).Value = m_CNReason.Reason;
                scom.Parameters.Add("@NeedToUpdateStock", SqlDbType.Bit, 1).Value = m_CNReason.NeedToUpdateStock;
                scom.Parameters.Add("@StockType", SqlDbType.VarChar, 10).Value = m_CNReason.StockType;
                scom.Parameters.Add("@UserCode", SqlDbType.VarChar, 20).Value = m_CNReason.UserCode;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_CNReason.Datex;
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


        public DataTable SelectAllm_CNReason()
        {
            try
            {
                strquery = @"select ID,Reason ,StockType AS 'Stock Type' , NeedToUpdateStock AS 'Update Stock' from M_CNReason";
                DataTable dtm_CNReason = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_CNReason;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_CNReason Selectm_CNReason(M_CNReason objm_CNReason)
        {
            try
            {
                strquery = @"select * from M_CNReason where ID = '" + objm_CNReason.ID + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_CNReason.ID = drType["ID"].ToString();
                    objm_CNReason.Reason = drType["Reason"].ToString();
                    objm_CNReason.NeedToUpdateStock = bool.Parse(drType["NeedToUpdateStock"].ToString());
                    objm_CNReason.StockType = drType["StockType"].ToString();
                    objm_CNReason.UserCode = drType["UserCode"].ToString();
                    objm_CNReason.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_CNReason;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_CNReason(string stringm_CNReason)
        {
            try
            {
                string xstrquery = @"select ID From M_CNReason   WHERE ID = '" + stringm_CNReason + "' ";
                DataRow drM_CNReason = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_CNReason != null)
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

        public List<M_CNReason> SelectM_CNReasonMulti(M_CNReason objm_CNReason2)
        {
            List<M_CNReason> retval = new List<M_CNReason>();
            try
            {
                strquery = @"select * from M_CNReason where ID = '" + objm_CNReason2.ID + "'";
                DataTable dtm_CNReason = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_CNReason.Rows)
                {
                    if (drType != null)
                    {
                        M_CNReason objm_CNReason = new M_CNReason();
                        objm_CNReason.ID = drType["ID"].ToString();
                        objm_CNReason.Reason = drType["Reason"].ToString();
                        objm_CNReason.NeedToUpdateStock = bool.Parse(drType["NeedToUpdateStock"].ToString());
                        objm_CNReason.StockType = drType["StockType"].ToString();
                        objm_CNReason.UserCode = drType["UserCode"].ToString();
                        objm_CNReason.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objm_CNReason);
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
