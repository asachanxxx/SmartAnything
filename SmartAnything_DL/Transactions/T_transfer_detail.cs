using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_transfer_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_transfer_detail table.
        /// </summary>
        public Boolean Savet_transfer_detailSP(t_transfer_detail t_transfer_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_transfer_detailSave";

                scom.Parameters.Add("@transferNoteNo", SqlDbType.VarChar, 20).Value = t_transfer_detail.transferNoteNo;
                scom.Parameters.Add("@sourceLocId", SqlDbType.VarChar, 20).Value = t_transfer_detail.sourceLocId;
                scom.Parameters.Add("@transferDate", SqlDbType.DateTime, 8).Value = t_transfer_detail.transferDate;
                scom.Parameters.Add("@stockCode", SqlDbType.VarChar, 20).Value = t_transfer_detail.stockCode;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 150).Value = t_transfer_detail.description;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_transfer_detail.quantity;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_transfer_detail.costPrice;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_transfer_detail.amount;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_transfer_detail.triggerVal;
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


        public DataTable SelectAllt_transfer_detail()
        {
            try
            {
                strquery = @"select transferNoteNo ,amount from t_transfer_detail";
                DataTable dtt_transfer_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_transfer_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_transfer_detail Selectt_transfer_detail(t_transfer_detail objt_transfer_detail)
        {
            try
            {
                strquery = @"select * from t_transfer_detail where transferNoteNo = '" + objt_transfer_detail.transferNoteNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_transfer_detail.transferNoteNo = drType["transferNoteNo"].ToString();
                    objt_transfer_detail.sourceLocId = drType["sourceLocId"].ToString();
                    objt_transfer_detail.transferDate = DateTime.Parse(drType["transferDate"].ToString());
                    objt_transfer_detail.stockCode = drType["stockCode"].ToString();
                    objt_transfer_detail.description = drType["description"].ToString();
                    objt_transfer_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_transfer_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_transfer_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_transfer_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_transfer_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_transfer_detail(string stringt_transfer_detail)
        {
            try
            {
                string xstrquery = @"select transferNoteNo From T_transfer_detail   WHERE transferNoteNo = '" + stringt_transfer_detail + "' ";
                DataRow drT_transfer_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_transfer_detail != null)
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

        public List<t_transfer_detail> SelectT_transfer_detailMulti(t_transfer_detail objt_transfer_detail2)
        {
            List<t_transfer_detail> retval = new List<t_transfer_detail>();
            try
            {
                strquery = @"select * from t_transfer_detail where transferNoteNo = '" + objt_transfer_detail2.transferNoteNo + "'";
                DataTable dtt_transfer_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_transfer_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_transfer_detail objt_transfer_detail = new t_transfer_detail();
                        objt_transfer_detail.transferNoteNo = drType["transferNoteNo"].ToString();
                        objt_transfer_detail.sourceLocId = drType["sourceLocId"].ToString();
                        objt_transfer_detail.transferDate = DateTime.Parse(drType["transferDate"].ToString());
                        objt_transfer_detail.stockCode = drType["stockCode"].ToString();
                        objt_transfer_detail.description = drType["description"].ToString();
                        objt_transfer_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_transfer_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_transfer_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_transfer_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_transfer_detail);
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
