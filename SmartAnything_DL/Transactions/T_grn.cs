using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;
using SmartAnything;
using System.Transactions;

namespace SmartAnything
{
    public class T_grnDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_grn table.
        /// </summary>
        public Boolean Savet_grnSP(t_grn t_grn,List<t_grn_detail> grndets, int formMode,string screenname)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {

                using (TransactionScope transaction = new TransactionScope())
                {
                    scom = new SqlCommand();
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.CommandText = "T_grnSave";

                    scom.Parameters.Add("@no", SqlDbType.VarChar, 10).Value = t_grn.no;
                    scom.Parameters.Add("@locationId", SqlDbType.VarChar, 10).Value = t_grn.locationId;
                    scom.Parameters.Add("@poNo", SqlDbType.VarChar, 20).Value = t_grn.poNo;
                    scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_grn.date;
                    scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_grn.refNo;
                    scom.Parameters.Add("@expireDate", SqlDbType.DateTime, 8).Value = t_grn.expireDate;
                    scom.Parameters.Add("@supplierId", SqlDbType.VarChar, 20).Value = t_grn.supplierId;
                    scom.Parameters.Add("@supInvoiceNo", SqlDbType.VarChar, 20).Value = t_grn.supInvoiceNo;
                    scom.Parameters.Add("@supInvoiceDate", SqlDbType.DateTime, 8).Value = t_grn.supInvoiceDate;
                    scom.Parameters.Add("@supInvoiceValue", SqlDbType.Decimal, 9).Value = t_grn.supInvoiceValue;
                    scom.Parameters.Add("@supDoNo", SqlDbType.VarChar, 20).Value = t_grn.supDoNo;
                    scom.Parameters.Add("@supDoDate", SqlDbType.DateTime, 8).Value = t_grn.supDoDate;
                    scom.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = t_grn.remarks;
                    scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_grn.noOfItems;
                    scom.Parameters.Add("@noOfPieces", SqlDbType.Decimal, 9).Value = t_grn.noOfPieces;
                    scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_grn.grossAmount;
                    scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_grn.isSaved;
                    scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_grn.isProcessed;
                    scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_grn.processDate;
                    scom.Parameters.Add("@processUser", SqlDbType.VarChar, 30).Value = t_grn.processUser;
                    scom.Parameters.Add("@netDiscount", SqlDbType.Decimal, 9).Value = t_grn.netDiscount;
                    scom.Parameters.Add("@additions", SqlDbType.Decimal, 9).Value = t_grn.additions;
                    scom.Parameters.Add("@deductions", SqlDbType.Decimal, 9).Value = t_grn.deductions;
                    scom.Parameters.Add("@netAmount", SqlDbType.Decimal, 9).Value = t_grn.netAmount;
                    scom.Parameters.Add("@isAllReturned", SqlDbType.Bit, 1).Value = t_grn.isAllReturned;
                    scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_grn.GLUpdate;
                    scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_grn.triggerVal;
                    scom.Parameters.Add("@InsMode", SqlDbType.Int).Value = formMode; // For insert
                    scom.Parameters.Add("@RtnValue", SqlDbType.Int).Value = 0;
                    retvalue = new u_DBConnection().RunQuery(scom);


                    foreach (t_grn_detail t_grn_detail in grndets)
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
                        scom.Parameters.Add("@InsMode", SqlDbType.Int).Value = 1; // For insert
                        scom.Parameters.Add("@RtnValue", SqlDbType.Int).Value = 0;
                        retvalue = new u_DBConnection().RunQuery(scom);
                    }
                    //increment the serial
                    transaction.Complete();
                }
                return retvalue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public static void IncrementSerial(string screenname)
        {
            P_AutoNumberDL pal = new P_AutoNumberDL();
            P_AutoNumber pauto = new P_AutoNumber();
            pauto.Screen = screenname;
            pauto = pal.Selectp_AutoNumber(pauto);
            pauto.Serial += 1;
            pal.SaveP_AutoNumberSP(pauto, 3);
        }


        public Boolean Savet_grnSP_OneInstance(t_grn t_grn, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_grnSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 10).Value = t_grn.no;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 10).Value = t_grn.locationId;
                scom.Parameters.Add("@poNo", SqlDbType.VarChar, 20).Value = t_grn.poNo;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_grn.date;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_grn.refNo;
                scom.Parameters.Add("@expireDate", SqlDbType.DateTime, 8).Value = t_grn.expireDate;
                scom.Parameters.Add("@supplierId", SqlDbType.VarChar, 20).Value = t_grn.supplierId;
                scom.Parameters.Add("@supInvoiceNo", SqlDbType.VarChar, 20).Value = t_grn.supInvoiceNo;
                scom.Parameters.Add("@supInvoiceDate", SqlDbType.DateTime, 8).Value = t_grn.supInvoiceDate;
                scom.Parameters.Add("@supInvoiceValue", SqlDbType.Decimal, 9).Value = t_grn.supInvoiceValue;
                scom.Parameters.Add("@supDoNo", SqlDbType.VarChar, 20).Value = t_grn.supDoNo;
                scom.Parameters.Add("@supDoDate", SqlDbType.DateTime, 8).Value = t_grn.supDoDate;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = t_grn.remarks;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_grn.noOfItems;
                scom.Parameters.Add("@noOfPieces", SqlDbType.Decimal, 9).Value = t_grn.noOfPieces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_grn.grossAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_grn.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_grn.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_grn.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 30).Value = t_grn.processUser;
                scom.Parameters.Add("@netDiscount", SqlDbType.Decimal, 9).Value = t_grn.netDiscount;
                scom.Parameters.Add("@additions", SqlDbType.Decimal, 9).Value = t_grn.additions;
                scom.Parameters.Add("@deductions", SqlDbType.Decimal, 9).Value = t_grn.deductions;
                scom.Parameters.Add("@netAmount", SqlDbType.Decimal, 9).Value = t_grn.netAmount;
                scom.Parameters.Add("@isAllReturned", SqlDbType.Bit, 1).Value = t_grn.isAllReturned;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_grn.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_grn.triggerVal;
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

        public DataTable SelectAllt_grn()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_grn]";
                DataTable dtt_grn = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_grn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_grn Selectt_grn(t_grn objt_grn)
        {
            try
            {
                strquery = @"select * from t_grn where no = '" + objt_grn.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_grn.no = drType["no"].ToString();
                    objt_grn.locationId = drType["locationId"].ToString();
                    objt_grn.poNo = drType["poNo"].ToString();
                    objt_grn.date = DateTime.Parse(drType["date"].ToString());
                    objt_grn.refNo = drType["refNo"].ToString();
                    objt_grn.expireDate = DateTime.Parse(drType["expireDate"].ToString());
                    objt_grn.supplierId = drType["supplierId"].ToString();
                    objt_grn.supInvoiceNo = drType["supInvoiceNo"].ToString();
                    objt_grn.supInvoiceDate = DateTime.Parse(drType["supInvoiceDate"].ToString());
                    objt_grn.supInvoiceValue = decimal.Parse(drType["supInvoiceValue"].ToString());
                    objt_grn.supDoNo = drType["supDoNo"].ToString();
                    objt_grn.supDoDate = DateTime.Parse(drType["supDoDate"].ToString());
                    objt_grn.remarks = drType["remarks"].ToString();
                    objt_grn.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_grn.noOfPieces = decimal.Parse(drType["noOfPieces"].ToString());
                    objt_grn.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_grn.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_grn.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_grn.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_grn.processUser = drType["processUser"].ToString();
                    objt_grn.netDiscount = decimal.Parse(drType["netDiscount"].ToString());
                    objt_grn.additions = decimal.Parse(drType["additions"].ToString());
                    objt_grn.deductions = decimal.Parse(drType["deductions"].ToString());
                    objt_grn.netAmount = decimal.Parse(drType["netAmount"].ToString());
                    objt_grn.isAllReturned = bool.Parse(drType["isAllReturned"].ToString());
                    objt_grn.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_grn.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_grn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_grn(string stringt_grn)
        {
            try
            {
                string xstrquery = @"select no From T_grn   WHERE no = '" + stringt_grn + "' ";
                DataRow drT_grn = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_grn != null)
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

        public List<t_grn> SelectT_grnMulti(t_grn objt_grn2)
        {
            List<t_grn> retval = new List<t_grn>();
            try
            {
                strquery = @"select * from t_grn where no = '" + objt_grn2.no + "'";
                DataTable dtt_grn = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_grn.Rows)
                {
                    if (drType != null)
                    {
                        t_grn objt_grn = new t_grn();
                        objt_grn.no = drType["no"].ToString();
                        objt_grn.locationId = drType["locationId"].ToString();
                        objt_grn.poNo = drType["poNo"].ToString();
                        objt_grn.date = DateTime.Parse(drType["date"].ToString());
                        objt_grn.refNo = drType["refNo"].ToString();
                        objt_grn.expireDate = DateTime.Parse(drType["expireDate"].ToString());
                        objt_grn.supplierId = drType["supplierId"].ToString();
                        objt_grn.supInvoiceNo = drType["supInvoiceNo"].ToString();
                        objt_grn.supInvoiceDate = DateTime.Parse(drType["supInvoiceDate"].ToString());
                        objt_grn.supInvoiceValue = decimal.Parse(drType["supInvoiceValue"].ToString());
                        objt_grn.supDoNo = drType["supDoNo"].ToString();
                        objt_grn.supDoDate = DateTime.Parse(drType["supDoDate"].ToString());
                        objt_grn.remarks = drType["remarks"].ToString();
                        objt_grn.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_grn.noOfPieces = decimal.Parse(drType["noOfPieces"].ToString());
                        objt_grn.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_grn.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_grn.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_grn.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_grn.processUser = drType["processUser"].ToString();
                        objt_grn.netDiscount = decimal.Parse(drType["netDiscount"].ToString());
                        objt_grn.additions = decimal.Parse(drType["additions"].ToString());
                        objt_grn.deductions = decimal.Parse(drType["deductions"].ToString());
                        objt_grn.netAmount = decimal.Parse(drType["netAmount"].ToString());
                        objt_grn.isAllReturned = bool.Parse(drType["isAllReturned"].ToString());
                        objt_grn.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_grn.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_grn);
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
