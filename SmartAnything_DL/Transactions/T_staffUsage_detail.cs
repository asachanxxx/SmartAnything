using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_staffUsage_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_staffUsage_detail table.
        /// </summary>
        public Boolean Savet_staffUsage_detailSP(t_staffUsage_detail t_staffUsage_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_staffUsage_detailSave";

                scom.Parameters.Add("@staffUsageNo", SqlDbType.VarChar, 20).Value = t_staffUsage_detail.staffUsageNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_staffUsage_detail.locationId;
                scom.Parameters.Add("@Date", SqlDbType.DateTime, 8).Value = t_staffUsage_detail.Date;
                scom.Parameters.Add("@stockCode", SqlDbType.VarChar, 20).Value = t_staffUsage_detail.stockCode;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 150).Value = t_staffUsage_detail.description;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_staffUsage_detail.quantity;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_staffUsage_detail.costPrice;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_staffUsage_detail.amount;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_staffUsage_detail.triggerVal;
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


        public DataTable SelectAllt_staffUsage_detail()
        {
            try
            {
                strquery = @"select staffUsageNo,amount from t_staffUsage_detail";
                DataTable dtt_staffUsage_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_staffUsage_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_staffUsage_detail Selectt_staffUsage_detail(t_staffUsage_detail objt_staffUsage_detail)
        {
            try
            {
                strquery = @"select * from t_staffUsage_detail where staffUsageNo = '" + objt_staffUsage_detail.staffUsageNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_staffUsage_detail.staffUsageNo = drType["staffUsageNo"].ToString();
                    objt_staffUsage_detail.locationId = drType["locationId"].ToString();
                    objt_staffUsage_detail.Date = DateTime.Parse(drType["Date"].ToString());
                    objt_staffUsage_detail.stockCode = drType["stockCode"].ToString();
                    objt_staffUsage_detail.description = drType["description"].ToString();
                    objt_staffUsage_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_staffUsage_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_staffUsage_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_staffUsage_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_staffUsage_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_staffUsage_detail(string stringt_staffUsage_detail)
        {
            try
            {
                string xstrquery = @"select staffUsageNo From T_staffUsage_detail   WHERE staffUsageNo = '" + stringt_staffUsage_detail + "' ";
                DataRow drT_staffUsage_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_staffUsage_detail != null)
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

        public List<t_staffUsage_detail> SelectT_staffUsage_detailMulti(t_staffUsage_detail objt_staffUsage_detail2)
        {
            List<t_staffUsage_detail> retval = new List<t_staffUsage_detail>();
            try
            {
                strquery = @"select * from t_staffUsage_detail where staffUsageNo = '" + objt_staffUsage_detail2.staffUsageNo + "'";
                DataTable dtt_staffUsage_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_staffUsage_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_staffUsage_detail objt_staffUsage_detail = new t_staffUsage_detail();
                        objt_staffUsage_detail.staffUsageNo = drType["staffUsageNo"].ToString();
                        objt_staffUsage_detail.locationId = drType["locationId"].ToString();
                        objt_staffUsage_detail.Date = DateTime.Parse(drType["Date"].ToString());
                        objt_staffUsage_detail.stockCode = drType["stockCode"].ToString();
                        objt_staffUsage_detail.description = drType["description"].ToString();
                        objt_staffUsage_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_staffUsage_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_staffUsage_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_staffUsage_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_staffUsage_detail);
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
