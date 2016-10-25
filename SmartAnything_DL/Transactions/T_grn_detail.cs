using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_grn_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_grn_detail table.
        /// </summary>
        public Boolean Savet_grn_detailSP(t_grn_detail t_grn_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_grn_detailSave";

                scom.Parameters.Add("@grnNo", SqlDbType.VarChar, 20).Value = t_grn_detail.grnNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_grn_detail.locationId;
                scom.Parameters.Add("@productId", SqlDbType.VarChar, 20).Value = t_grn_detail.productId;
                scom.Parameters.Add("@stock", SqlDbType.Decimal, 9).Value = t_grn_detail.stock;
                scom.Parameters.Add("@tax", SqlDbType.Decimal, 9).Value = t_grn_detail.tax;
                scom.Parameters.Add("@priceLevel", SqlDbType.VarChar, 10).Value = t_grn_detail.priceLevel;
                scom.Parameters.Add("@quantity", SqlDbType.Int, 4).Value = t_grn_detail.quantity;
                scom.Parameters.Add("@freeQty", SqlDbType.Int, 4).Value = t_grn_detail.freeQty;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_grn_detail.amount;
                scom.Parameters.Add("@disPerc", SqlDbType.Decimal, 9).Value = t_grn_detail.disPerc;
                scom.Parameters.Add("@disAmount", SqlDbType.Decimal, 9).Value = t_grn_detail.disAmount;
                scom.Parameters.Add("@batchNo", SqlDbType.VarChar, 20).Value = t_grn_detail.batchNo;
                scom.Parameters.Add("@expDate", SqlDbType.DateTime, 8).Value = t_grn_detail.expDate;
                scom.Parameters.Add("@stockCode", SqlDbType.VarChar, 20).Value = t_grn_detail.stockCode;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_grn_detail.costPrice;
                scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal, 9).Value = t_grn_detail.sellingPrice;
                scom.Parameters.Add("@returnedQuantity", SqlDbType.Int, 4).Value = t_grn_detail.returnedQuantity;
                scom.Parameters.Add("@remainingQuantity", SqlDbType.Int, 4).Value = t_grn_detail.remainingQuantity;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_grn_detail.triggerVal;
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


        public DataTable SelectAllt_grn_detail()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_grn_detail]";
                DataTable dtt_grn_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_grn_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_grn_detail Selectt_grn_detail(t_grn_detail objt_grn_detail)
        {
            try
            {
                strquery = @"select * from t_grn_detail where grnNo = '" + objt_grn_detail.grnNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_grn_detail.grnNo = drType["grnNo"].ToString();
                    objt_grn_detail.locationId = drType["locationId"].ToString();
                    objt_grn_detail.productId = drType["productId"].ToString();
                    objt_grn_detail.stock = decimal.Parse(drType["stock"].ToString());
                    objt_grn_detail.tax = decimal.Parse(drType["tax"].ToString());
                    objt_grn_detail.priceLevel = drType["priceLevel"].ToString();
                    objt_grn_detail.quantity = int.Parse(drType["quantity"].ToString());
                    objt_grn_detail.freeQty = int.Parse(drType["freeQty"].ToString());
                    objt_grn_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_grn_detail.disPerc = decimal.Parse(drType["disPerc"].ToString());
                    objt_grn_detail.disAmount = decimal.Parse(drType["disAmount"].ToString());
                    objt_grn_detail.batchNo = drType["batchNo"].ToString();
                    objt_grn_detail.expDate = DateTime.Parse(drType["expDate"].ToString());
                    objt_grn_detail.stockCode = drType["stockCode"].ToString();
                    objt_grn_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_grn_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                    objt_grn_detail.returnedQuantity = int.Parse(drType["returnedQuantity"].ToString());
                    objt_grn_detail.remainingQuantity = int.Parse(drType["remainingQuantity"].ToString());
                    objt_grn_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_grn_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_grn_detail(string stringt_grn_detail)
        {
            try
            {
                string xstrquery = @"select CompCode From T_grn_detail   WHERE CompCode = '" + stringt_grn_detail + "'";
                DataRow drT_grn_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_grn_detail != null)
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

        public List<t_grn_detail> SelectT_grn_detailMulti(t_grn_detail objt_grn_detail2)
        {
            List<t_grn_detail> retval = new List<t_grn_detail>();
            try
            {
                strquery = @"select * from t_grn_detail where grnNo = '" + objt_grn_detail2.grnNo + "'";
                DataTable dtt_grn_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_grn_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_grn_detail objt_grn_detail = new t_grn_detail();
                        objt_grn_detail.grnNo = drType["grnNo"].ToString();
                        objt_grn_detail.locationId = drType["locationId"].ToString();
                        objt_grn_detail.productId = drType["productId"].ToString();
                        objt_grn_detail.stock = decimal.Parse(drType["stock"].ToString());
                        objt_grn_detail.tax = decimal.Parse(drType["tax"].ToString());
                        objt_grn_detail.priceLevel = drType["priceLevel"].ToString();
                        objt_grn_detail.quantity = int.Parse(drType["quantity"].ToString());
                        objt_grn_detail.freeQty = int.Parse(drType["freeQty"].ToString());
                        objt_grn_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_grn_detail.disPerc = decimal.Parse(drType["disPerc"].ToString());
                        objt_grn_detail.disAmount = decimal.Parse(drType["disAmount"].ToString());
                        objt_grn_detail.batchNo = drType["batchNo"].ToString();
                        objt_grn_detail.expDate = DateTime.Parse(drType["expDate"].ToString());
                        objt_grn_detail.stockCode = drType["stockCode"].ToString();
                        objt_grn_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_grn_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                        objt_grn_detail.returnedQuantity = int.Parse(drType["returnedQuantity"].ToString());
                        objt_grn_detail.remainingQuantity = int.Parse(drType["remainingQuantity"].ToString());
                        objt_grn_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_grn_detail);
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
