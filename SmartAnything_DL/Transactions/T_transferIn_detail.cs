using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_transferIn_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_transferIn_detail table.
        /// </summary>
        public Boolean Savet_transferIn_detailSP(t_transferIn_detail t_transferIn_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_transferIn_detailSave";

                scom.Parameters.Add("@transinrNo", SqlDbType.VarChar, 20).Value = t_transferIn_detail.transinrNo;
                scom.Parameters.Add("@sourceLocId", SqlDbType.VarChar, 20).Value = t_transferIn_detail.sourceLocId;
                scom.Parameters.Add("@destinationLocId", SqlDbType.VarChar, 20).Value = t_transferIn_detail.destinationLocId;
                scom.Parameters.Add("@transferDate", SqlDbType.DateTime, 8).Value = t_transferIn_detail.transferDate;
                scom.Parameters.Add("@stockCode", SqlDbType.VarChar, 20).Value = t_transferIn_detail.stockCode;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 150).Value = t_transferIn_detail.description;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_transferIn_detail.quantity;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_transferIn_detail.costPrice;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_transferIn_detail.amount;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_transferIn_detail.triggerVal;
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


        public DataTable SelectAllt_transferIn_detail()
        {
            try
            {
                strquery = @"select transinrNo,amount from t_transferIn_detail";
                DataTable dtt_transferIn_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_transferIn_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_transferIn_detail Selectt_transferIn_detail(t_transferIn_detail objt_transferIn_detail)
        {
            try
            {
                strquery = @"select * from t_transferIn_detail where transinrNo = '" + objt_transferIn_detail.transinrNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_transferIn_detail.transinrNo = drType["transinrNo"].ToString();
                    objt_transferIn_detail.sourceLocId = drType["sourceLocId"].ToString();
                    objt_transferIn_detail.destinationLocId = drType["destinationLocId"].ToString();
                    objt_transferIn_detail.transferDate = DateTime.Parse(drType["transferDate"].ToString());
                    objt_transferIn_detail.stockCode = drType["stockCode"].ToString();
                    objt_transferIn_detail.description = drType["description"].ToString();
                    objt_transferIn_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_transferIn_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_transferIn_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_transferIn_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_transferIn_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_transferIn_detail(string stringt_transferIn_detail)
        {
            try
            {
                string xstrquery = @"select transinrNo From T_transferIn_detail   WHERE transinrNo = '" + stringt_transferIn_detail + "' ";
                DataRow drT_transferIn_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_transferIn_detail != null)
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

        public List<t_transferIn_detail> SelectT_transferIn_detailMulti(t_transferIn_detail objt_transferIn_detail2)
        {
            List<t_transferIn_detail> retval = new List<t_transferIn_detail>();
            try
            {
                strquery = @"select * from t_transferIn_detail where transinrNo = '" + objt_transferIn_detail2.transinrNo + "'";
                DataTable dtt_transferIn_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_transferIn_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_transferIn_detail objt_transferIn_detail = new t_transferIn_detail();
                        objt_transferIn_detail.transinrNo = drType["transinrNo"].ToString();
                        objt_transferIn_detail.sourceLocId = drType["sourceLocId"].ToString();
                        objt_transferIn_detail.destinationLocId = drType["destinationLocId"].ToString();
                        objt_transferIn_detail.transferDate = DateTime.Parse(drType["transferDate"].ToString());
                        objt_transferIn_detail.stockCode = drType["stockCode"].ToString();
                        objt_transferIn_detail.description = drType["description"].ToString();
                        objt_transferIn_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_transferIn_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_transferIn_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_transferIn_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_transferIn_detail);
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
