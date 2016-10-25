using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;
using SmartAnything;

namespace SmartAnything
{
    public class T_OrderTrackingDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_OrderTracking table.
        /// </summary>
        public Boolean Savet_OrderTrackingSP(T_OrderTracking t_OrderTracking, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_OrderTrackingSave";

                scom.Parameters.Add("@OFNo", SqlDbType.VarChar, 20).Value = t_OrderTracking.OFNo;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_OrderTracking.CompCode;
                scom.Parameters.Add("@LocaCode", SqlDbType.VarChar, 20).Value = t_OrderTracking.LocaCode;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_OrderTracking.Customer;
                scom.Parameters.Add("@CustomerDIscRate", SqlDbType.Decimal, 9).Value = t_OrderTracking.CustomerDIscRate;
                scom.Parameters.Add("@SalesMan", SqlDbType.VarChar, 20).Value = t_OrderTracking.SalesMan;
                scom.Parameters.Add("@OFApproved", SqlDbType.Int, 4).Value = t_OrderTracking.OFApproved;
                scom.Parameters.Add("@OFApprovedUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.OFApprovedUser;
                scom.Parameters.Add("@OFApprovedDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.OFApprovedDate;
                scom.Parameters.Add("@OFNoOfPrints", SqlDbType.Decimal, 9).Value = t_OrderTracking.OFNoOfPrints;
                scom.Parameters.Add("@OFPrintUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.OFPrintUser;
                scom.Parameters.Add("@InvCreated", SqlDbType.Int, 4).Value = t_OrderTracking.InvCreated;
                scom.Parameters.Add("@InvNo", SqlDbType.VarChar, 20).Value = t_OrderTracking.InvNo;
                scom.Parameters.Add("@InvAmount", SqlDbType.Decimal, 9).Value = t_OrderTracking.InvAmount;
                scom.Parameters.Add("@InvApproved", SqlDbType.Int, 4).Value = t_OrderTracking.InvApproved;
                scom.Parameters.Add("@InvApprovedUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.InvApprovedUser;
                scom.Parameters.Add("@InvApprovedDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.InvApprovedDate;
                scom.Parameters.Add("@InvNoOfPrints", SqlDbType.Decimal, 9).Value = t_OrderTracking.InvNoOfPrints;
                scom.Parameters.Add("@InvPrintUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.InvPrintUser;
                scom.Parameters.Add("@DOCreated", SqlDbType.Int, 4).Value = t_OrderTracking.DOCreated;
                scom.Parameters.Add("@DONo", SqlDbType.VarChar, 20).Value = t_OrderTracking.DONo;
                scom.Parameters.Add("@DOAmount", SqlDbType.Decimal, 9).Value = t_OrderTracking.DOAmount;
                scom.Parameters.Add("@DOMultipleNO", SqlDbType.VarChar, 20).Value = t_OrderTracking.DOMultipleNO;
                scom.Parameters.Add("@DOProcessed", SqlDbType.Int, 4).Value = t_OrderTracking.DOProcessed;
                scom.Parameters.Add("@DOProcessedUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.DOProcessedUser;
                scom.Parameters.Add("@DOProcessedDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.DOProcessedDate;
                scom.Parameters.Add("@DOApproved", SqlDbType.Int, 4).Value = t_OrderTracking.DOApproved;
                scom.Parameters.Add("@DOApprovedUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.DOApprovedUser;
                scom.Parameters.Add("@DOApprovedDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.DOApprovedDate;
                scom.Parameters.Add("@DONoOfPrints", SqlDbType.Decimal, 9).Value = t_OrderTracking.DONoOfPrints;
                scom.Parameters.Add("@DOvPrintUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.DOvPrintUser;
                scom.Parameters.Add("@Audited", SqlDbType.Int, 4).Value = t_OrderTracking.Audited;
                scom.Parameters.Add("@AuditDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.AuditDate;
                scom.Parameters.Add("@AuditUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.AuditUser;
                scom.Parameters.Add("@Dispatched", SqlDbType.Int, 4).Value = t_OrderTracking.Dispatched;
                scom.Parameters.Add("@DispatchedDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.DispatchedDate;
                scom.Parameters.Add("@DispatchedUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.DispatchedUser;
                scom.Parameters.Add("@Handedover", SqlDbType.Int, 4).Value = t_OrderTracking.Handedover;
                scom.Parameters.Add("@HandedoverUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.HandedoverUser;
                scom.Parameters.Add("@HandedoverDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.HandedoverDate;
                scom.Parameters.Add("@Completed", SqlDbType.Int, 4).Value = t_OrderTracking.Completed;
                scom.Parameters.Add("@CompletedUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.CompletedUser;
                scom.Parameters.Add("@CompletedDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.CompletedDate;
                scom.Parameters.Add("@PackingListCreated", SqlDbType.Int, 4).Value = t_OrderTracking.PackingListCreated;
                scom.Parameters.Add("@PackingListNo", SqlDbType.VarChar, 20).Value = t_OrderTracking.PackingListNo;
                scom.Parameters.Add("@PackingListDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.PackingListDate;
                scom.Parameters.Add("@PackingListUser", SqlDbType.VarChar, 20).Value = t_OrderTracking.PackingListUser;
                scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = t_OrderTracking.Remarks;
                scom.Parameters.Add("@HandOverLorry", SqlDbType.VarChar, 20).Value = t_OrderTracking.HandOverLorry;
                scom.Parameters.Add("@CompleteRemark", SqlDbType.VarChar, 250).Value = t_OrderTracking.CompleteRemark;
                scom.Parameters.Add("@OrderDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.OrderDate;
                scom.Parameters.Add("@InvoiceDate", SqlDbType.DateTime, 8).Value = t_OrderTracking.InvoiceDate;
                scom.Parameters.Add("@Dodate", SqlDbType.DateTime, 8).Value = t_OrderTracking.Dodate;
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


        public DataTable SelectAllt_OrderTracking()
        {
            try
            {
                strquery = @"SELECT * FROM T_OrderTracking";
                DataTable dtt_OrderTracking = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_OrderTracking;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public T_OrderTracking Selectt_OrderTracking(T_OrderTracking objt_OrderTracking ,SmartAnything.xEnums.OrderTrackingTypes typex )
        {
            try
            {

                switch (typex) { 
                    case xEnums.OrderTrackingTypes.DoNumber:
                        strquery = @"select * from T_OrderTracking where DONo = '" + objt_OrderTracking.DONo + "'";
                        break;
                    case xEnums.OrderTrackingTypes.InvoiceNO:
                        strquery = @"select * from T_OrderTracking where InvNo = '" + objt_OrderTracking.InvNo + "'";
                        break;
                    case xEnums.OrderTrackingTypes.OrderNo:
                        strquery = @"select * from T_OrderTracking where OFNo = '" + objt_OrderTracking.OFNo + "'";
                        break;
                    case xEnums.OrderTrackingTypes.PackingList:
                        strquery = @"select * from T_OrderTracking where PackingListNo = '" + objt_OrderTracking.PackingListNo + "'";
                        break;
                }
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_OrderTracking.OFNo = drType["OFNo"].ToString();
                    objt_OrderTracking.CompCode = drType["CompCode"].ToString();
                    objt_OrderTracking.LocaCode = drType["LocaCode"].ToString();
                    objt_OrderTracking.Customer = drType["Customer"].ToString();
                    objt_OrderTracking.CustomerDIscRate = decimal.Parse(drType["CustomerDIscRate"].ToString());
                    objt_OrderTracking.SalesMan = drType["SalesMan"].ToString();
                    objt_OrderTracking.OFApproved = int.Parse(drType["OFApproved"].ToString());
                    objt_OrderTracking.OFApprovedUser = drType["OFApprovedUser"].ToString();
                    objt_OrderTracking.OFApprovedDate = DateTime.Parse(drType["OFApprovedDate"].ToString());
                    objt_OrderTracking.OFNoOfPrints = decimal.Parse(drType["OFNoOfPrints"].ToString());
                    objt_OrderTracking.OFPrintUser = drType["OFPrintUser"].ToString();
                    objt_OrderTracking.InvCreated = int.Parse(drType["InvCreated"].ToString());
                    objt_OrderTracking.InvNo = drType["InvNo"].ToString();
                    objt_OrderTracking.InvAmount = decimal.Parse(drType["InvAmount"].ToString());
                    objt_OrderTracking.InvApproved = int.Parse(drType["InvApproved"].ToString());
                    objt_OrderTracking.InvApprovedUser = drType["InvApprovedUser"].ToString();
                    objt_OrderTracking.InvApprovedDate = DateTime.Parse(drType["InvApprovedDate"].ToString());
                    objt_OrderTracking.InvNoOfPrints = decimal.Parse(drType["InvNoOfPrints"].ToString());
                    objt_OrderTracking.InvPrintUser = drType["InvPrintUser"].ToString();
                    objt_OrderTracking.DOCreated = int.Parse(drType["DOCreated"].ToString());
                    objt_OrderTracking.DONo = drType["DONo"].ToString();
                    objt_OrderTracking.DOAmount = decimal.Parse(drType["DOAmount"].ToString());
                    objt_OrderTracking.DOMultipleNO = drType["DOMultipleNO"].ToString();
                    objt_OrderTracking.DOProcessed = int.Parse(drType["DOProcessed"].ToString());
                    objt_OrderTracking.DOProcessedUser = drType["DOProcessedUser"].ToString();
                    objt_OrderTracking.DOProcessedDate = DateTime.Parse(drType["DOProcessedDate"].ToString());
                    objt_OrderTracking.DOApproved = int.Parse(drType["DOApproved"].ToString());
                    objt_OrderTracking.DOApprovedUser = drType["DOApprovedUser"].ToString();
                    objt_OrderTracking.DOApprovedDate = DateTime.Parse(drType["DOApprovedDate"].ToString());
                    objt_OrderTracking.DONoOfPrints = decimal.Parse(drType["DONoOfPrints"].ToString());
                    objt_OrderTracking.DOvPrintUser = drType["DOvPrintUser"].ToString();
                    objt_OrderTracking.Audited = int.Parse(drType["Audited"].ToString());
                    objt_OrderTracking.AuditDate = DateTime.Parse(drType["AuditDate"].ToString());
                    objt_OrderTracking.AuditUser = drType["AuditUser"].ToString();
                    objt_OrderTracking.Dispatched = int.Parse(drType["Dispatched"].ToString());
                    objt_OrderTracking.DispatchedDate = DateTime.Parse(drType["DispatchedDate"].ToString());
                    objt_OrderTracking.DispatchedUser = drType["DispatchedUser"].ToString();
                    objt_OrderTracking.Handedover = int.Parse(drType["Handedover"].ToString());
                    objt_OrderTracking.HandedoverUser = drType["HandedoverUser"].ToString();
                    objt_OrderTracking.HandedoverDate = DateTime.Parse(drType["HandedoverDate"].ToString());
                    objt_OrderTracking.Completed = int.Parse(drType["Completed"].ToString());
                    objt_OrderTracking.CompletedUser = drType["CompletedUser"].ToString();
                    objt_OrderTracking.CompletedDate = DateTime.Parse(drType["CompletedDate"].ToString());
                    objt_OrderTracking.PackingListCreated = int.Parse(drType["PackingListCreated"].ToString());
                    objt_OrderTracking.PackingListNo = drType["PackingListNo"].ToString();
                    objt_OrderTracking.PackingListDate = DateTime.Parse(drType["PackingListDate"].ToString());
                    objt_OrderTracking.PackingListUser = drType["PackingListUser"].ToString();
                    objt_OrderTracking.Remarks = drType["Remarks"].ToString();
                    objt_OrderTracking.HandOverLorry = drType["HandOverLorry"].ToString();
                    objt_OrderTracking.CompleteRemark = drType["CompleteRemark"].ToString();
                    objt_OrderTracking.OrderDate = DateTime.Parse(drType["OrderDate"].ToString());
                    objt_OrderTracking.InvoiceDate = DateTime.Parse(drType["InvoiceDate"].ToString());
                    objt_OrderTracking.Dodate = DateTime.Parse(drType["Dodate"].ToString());
                    return objt_OrderTracking;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_OrderTracking(string stringt_OrderTracking)
        {
            try
            {
                string xstrquery = @"select OFNo From T_OrderTracking   WHERE OFNo = '" + stringt_OrderTracking + "' ";
                DataRow drT_OrderTracking = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_OrderTracking != null)
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

        public List<T_OrderTracking> SelectT_OrderTrackingMulti(T_OrderTracking objt_OrderTracking2)
        {
            List<T_OrderTracking> retval = new List<T_OrderTracking>();
            try
            {
                strquery = @"select * from t_OrderTracking where OFNo = '" + objt_OrderTracking2.OFNo + "'";
                DataTable dtt_OrderTracking = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_OrderTracking.Rows)
                {
                    if (drType != null)
                    {
                        T_OrderTracking objt_OrderTracking = new T_OrderTracking();
                        objt_OrderTracking.OFNo = drType["OFNo"].ToString();
                        objt_OrderTracking.CompCode = drType["CompCode"].ToString();
                        objt_OrderTracking.LocaCode = drType["LocaCode"].ToString();
                        objt_OrderTracking.Customer = drType["Customer"].ToString();
                        objt_OrderTracking.CustomerDIscRate = decimal.Parse(drType["CustomerDIscRate"].ToString());
                        objt_OrderTracking.SalesMan = drType["SalesMan"].ToString();
                        objt_OrderTracking.OFApproved = int.Parse(drType["OFApproved"].ToString());
                        objt_OrderTracking.OFApprovedUser = drType["OFApprovedUser"].ToString();
                        objt_OrderTracking.OFApprovedDate = DateTime.Parse(drType["OFApprovedDate"].ToString());
                        objt_OrderTracking.OFNoOfPrints = decimal.Parse(drType["OFNoOfPrints"].ToString());
                        objt_OrderTracking.OFPrintUser = drType["OFPrintUser"].ToString();
                        objt_OrderTracking.InvCreated = int.Parse(drType["InvCreated"].ToString());
                        objt_OrderTracking.InvNo = drType["InvNo"].ToString();
                        objt_OrderTracking.InvAmount = decimal.Parse(drType["InvAmount"].ToString());
                        objt_OrderTracking.InvApproved = int.Parse(drType["InvApproved"].ToString());
                        objt_OrderTracking.InvApprovedUser = drType["InvApprovedUser"].ToString();
                        objt_OrderTracking.InvApprovedDate = DateTime.Parse(drType["InvApprovedDate"].ToString());
                        objt_OrderTracking.InvNoOfPrints = decimal.Parse(drType["InvNoOfPrints"].ToString());
                        objt_OrderTracking.InvPrintUser = drType["InvPrintUser"].ToString();
                        objt_OrderTracking.DOCreated = int.Parse(drType["DOCreated"].ToString());
                        objt_OrderTracking.DONo = drType["DONo"].ToString();
                        objt_OrderTracking.DOAmount = decimal.Parse(drType["DOAmount"].ToString());
                        objt_OrderTracking.DOMultipleNO = drType["DOMultipleNO"].ToString();
                        objt_OrderTracking.DOProcessed = int.Parse(drType["DOProcessed"].ToString());
                        objt_OrderTracking.DOProcessedUser = drType["DOProcessedUser"].ToString();
                        objt_OrderTracking.DOProcessedDate = DateTime.Parse(drType["DOProcessedDate"].ToString());
                        objt_OrderTracking.DOApproved = int.Parse(drType["DOApproved"].ToString());
                        objt_OrderTracking.DOApprovedUser = drType["DOApprovedUser"].ToString();
                        objt_OrderTracking.DOApprovedDate = DateTime.Parse(drType["DOApprovedDate"].ToString());
                        objt_OrderTracking.DONoOfPrints = decimal.Parse(drType["DONoOfPrints"].ToString());
                        objt_OrderTracking.DOvPrintUser = drType["DOvPrintUser"].ToString();
                        objt_OrderTracking.Audited = int.Parse(drType["Audited"].ToString());
                        objt_OrderTracking.AuditDate = DateTime.Parse(drType["AuditDate"].ToString());
                        objt_OrderTracking.AuditUser = drType["AuditUser"].ToString();
                        objt_OrderTracking.Dispatched = int.Parse(drType["Dispatched"].ToString());
                        objt_OrderTracking.DispatchedDate = DateTime.Parse(drType["DispatchedDate"].ToString());
                        objt_OrderTracking.DispatchedUser = drType["DispatchedUser"].ToString();
                        objt_OrderTracking.Handedover = int.Parse(drType["Handedover"].ToString());
                        objt_OrderTracking.HandedoverUser = drType["HandedoverUser"].ToString();
                        objt_OrderTracking.HandedoverDate = DateTime.Parse(drType["HandedoverDate"].ToString());
                        objt_OrderTracking.Completed = int.Parse(drType["Completed"].ToString());
                        objt_OrderTracking.CompletedUser = drType["CompletedUser"].ToString();
                        objt_OrderTracking.CompletedDate = DateTime.Parse(drType["CompletedDate"].ToString());
                        objt_OrderTracking.PackingListCreated = int.Parse(drType["PackingListCreated"].ToString());
                        objt_OrderTracking.PackingListNo = drType["PackingListNo"].ToString();
                        objt_OrderTracking.PackingListDate = DateTime.Parse(drType["PackingListDate"].ToString());
                        objt_OrderTracking.PackingListUser = drType["PackingListUser"].ToString();
                        objt_OrderTracking.Remarks = drType["Remarks"].ToString();
                        objt_OrderTracking.HandOverLorry = drType["HandOverLorry"].ToString();
                        objt_OrderTracking.CompleteRemark = drType["CompleteRemark"].ToString();
                        objt_OrderTracking.OrderDate = DateTime.Parse(drType["OrderDate"].ToString());
                        objt_OrderTracking.InvoiceDate = DateTime.Parse(drType["InvoiceDate"].ToString());
                        objt_OrderTracking.Dodate = DateTime.Parse(drType["Dodate"].ToString());
                        retval.Add(objt_OrderTracking);
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
