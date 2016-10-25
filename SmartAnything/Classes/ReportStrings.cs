using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SmartAnything.Reports;
using System.Data.SqlClient;
using System.Data;

namespace SmartAnything
{
    public class ReportStrings
    {

        public static String GetDOSTR(string DocNo)
        {
            string str = "SELECT     dbo.T_DIliveryHed.DoNo, dbo.T_DIliveryHed.InvNo, dbo.T_DIliveryHed.InvoiceAmount, dbo.T_DIliveryHed.Customer, dbo.M_Customers.CustName, dbo.T_DIliveryHed.Datex, dbo.T_DIliveryHed.Agent, dbo.T_DIliveryHed.Lorry, dbo.T_DIliveryHed.NoOfCartons, dbo.T_DIliveryHed.Checked, dbo.T_DIliveryHed.Checkeddate, dbo.T_DIliveryHed.Approved, dbo.T_DIliveryHed.ApprovedDate, dbo.T_DIliveryHed.ApprovedUser, dbo.T_DIliveryHed.HandoverCartons, dbo.T_DIliveryHed.Delivered, dbo.T_DIliveryHed.Remarks, dbo.T_DIliveryHed.PrintUser, dbo.T_DIliveryHed.Processed, dbo.T_DIliveryHed.Audited, dbo.T_DiliveryDet.Item, dbo.T_Stock.Descr AS ItemNamex, dbo.T_DiliveryDet.Unit, dbo.T_DiliveryDet.Qty, dbo.T_DiliveryDet.Carton FROM dbo.T_DIliveryHed INNER JOIN dbo.T_DiliveryDet ON dbo.T_DIliveryHed.DoNo = dbo.T_DiliveryDet.DoNo INNER JOIN dbo.M_Customers ON dbo.T_DIliveryHed.Customer = dbo.M_Customers.CusID INNER JOIN dbo.T_Stock ON dbo.T_DiliveryDet.Item = dbo.T_Stock.StockCode" +
                         " WHERE     (dbo.T_DIliveryHed.DoNo = '" + DocNo.Trim() + "')";
            return str;
        }


        public static String GetOrderPrintSTR(string orderno ,  string loca)
        {
            string str = " SELECT     dbo.T_OrderFormHead.DocNo, dbo.T_OrderFormHead.TRNType, dbo.T_OrderFormHead.Customer,dbo.M_Customers.CustName, dbo.T_OrderFormHead.Datex, dbo.T_OrderFormHead.RecivedBy, dbo.T_OrderFormHead.CheckedBy,dbo.T_OrderFormHead.Approved, dbo.T_OrderFormHead.ApprovedBy, dbo.T_OrderFormHead.ApprovedDate, dbo.T_OrderFormHead.RecivedDate,dbo.T_OrderFormHead.Userx, dbo.T_OrderFormHead.CreatedDate, dbo.T_OrderFormHead.CQNO, dbo.T_OrderFormHead.CQDate,dbo.T_OrderFormHead.BANK, dbo.T_OrderFormHead.BRANCH, dbo.T_OrderFormHead.Subtotal, dbo.T_OrderFormHead.DiscountPer, " +
                " dbo.T_OrderFormHead.SubtotalDisc, dbo.T_OrderFormHead.ItemdiscTotal, dbo.T_OrderFormHead.TotalDisc, dbo.T_OrderFormHead.NetTotal,dbo.T_OrderFormHead.Remarks, dbo.T_OrderFormHead.Processed, dbo.T_OrderFormHead.ProcessedDate, dbo.T_OrderFormHead.ProcessedUser,dbo.T_OrderFormDet.ItemCode, dbo.T_OrderFormDet.Quntity, dbo.T_OrderFormDet.Barcode, dbo.T_OrderFormDet.UnitPrice, dbo.T_OrderFormDet.CostPrice,dbo.T_OrderFormDet.Unit, dbo.T_OrderFormDet.Amountx, dbo.T_OrderFormDet.discper, dbo.T_OrderFormDet.discount, dbo.T_Stock.Descr as 'Namex'  " +
                " FROM         dbo.T_OrderFormHead INNER JOIN dbo.M_Customers ON dbo.T_OrderFormHead.Customer = dbo.M_Customers.CusID INNER JOIN dbo.T_OrderFormDet ON dbo.T_OrderFormHead.DocNo = dbo.T_OrderFormDet.Docno INNER JOIN dbo.T_Stock ON dbo.T_OrderFormDet.ItemCode = dbo.T_Stock.StockCode " +
                " WHERE     (dbo.T_OrderFormHead.DocNo = '" + orderno.Trim() + "') AND (dbo.T_Stock.Locacode = '"+loca.Trim()+"')";

            return str;
        }

        public static String GetInvoicePrintSTR(string InvNo, string loca)
        {
            string str = "SELECT     dbo.T_InvoiceHed.InvID, dbo.T_InvoiceHed.Customer, dbo.M_Customers.CustName, dbo.T_InvoiceHed.Paymeth, dbo.T_InvoiceHed.RefNo,dbo.T_InvoiceHed.ManualNo, dbo.T_InvoiceHed.OrderFormNo, dbo.T_InvoiceHed.DONumber, dbo.T_InvoiceHed.GrossAmt, dbo.T_InvoiceHed.SubtotaldiscPer, dbo.T_InvoiceHed.SubtotalDisc, dbo.T_InvoiceHed.ItemdiscTotal, dbo.T_InvoiceHed.TotalDisc, dbo.T_InvoiceHed.Tax, dbo.T_InvoiceHed.Vatamt,dbo.T_InvoiceHed.NetAmt, dbo.T_InvoiceHed.CreditPeriod, dbo.T_InvoiceHed.Noofitems, dbo.T_InvoiceHed.NoOfPieces, dbo.T_InvoiceHed.Datex, " +
                         "dbo.T_InvoiceHed.PrerairedBy, dbo.T_InvoiceHed.Checked, dbo.T_InvoiceHed.Processed, dbo.T_InvoiceHed.ProcessedDate, dbo.T_InvoiceHed.ProcessedUser,dbo.T_InvoiceHed.DueAmt, dbo.T_InvoiceHed.PaidAmt, dbo.T_InvoiceHed.IsSettled, dbo.T_InvoiceHed.Iscancelled, dbo.T_InvoiceHed.CancelledDate,dbo.T_InvoiceHed.CancelledUSer, dbo.T_InvoiceHed.CheckedBy, dbo.T_InvoiceHed.Approved, dbo.T_InvoiceHed.AprrovedBy, dbo.T_InvoiceHed.ApprovedDate,dbo.T_InvoiceHed.Remarks, dbo.T_InvoiceDet.ItemCode, dbo.T_Stock.Descr, dbo.T_InvoiceDet.CostPrice, dbo.T_InvoiceDet.SellingPrice, dbo.T_InvoiceDet.Qty, " +
                         "dbo.T_InvoiceDet.Unitx, dbo.T_InvoiceDet.DiscountPer, dbo.T_InvoiceDet.Discount, dbo.T_InvoiceDet.Total " +
                         "FROM         dbo.T_InvoiceHed INNER JOIN dbo.T_InvoiceDet ON dbo.T_InvoiceHed.InvID = dbo.T_InvoiceDet.InvNo INNER JOIN dbo.M_Customers ON dbo.T_InvoiceHed.Customer = dbo.M_Customers.CusID INNER JOIN dbo.T_Stock ON dbo.T_InvoiceDet.ItemCode = dbo.T_Stock.StockCode " +
                         "WHERE dbo.T_InvoiceHed.InvID = '" + InvNo.Trim() + "'  AND (dbo.T_Stock.Locacode = '" + loca.Trim() + "')";
            return str;
        }

        public static String GetDOPrintSTR(string DONo)
        {
            string str = "SELECT     dbo.T_DIliveryHed.DoNo, dbo.T_DIliveryHed.InvNo, dbo.T_DIliveryHed.Customer, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax,dbo.M_Customers.Email, dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_DIliveryHed.Datex, dbo.T_DiliveryDet.Item,dbo.T_DiliveryDet.ItemNamex, dbo.T_DiliveryDet.Unit, dbo.T_DiliveryDet.Qty, dbo.T_DiliveryDet.Carton, dbo.T_DiliveryDet.ActualCartons, dbo.T_DiliveryDet.Remarks,dbo.T_DIliveryHed.Agent, dbo.T_DIliveryHed.Lorry, dbo.T_DIliveryHed.NoOfCartons, dbo.M_Agents.Namex AS [Agent Name] FROM         dbo.T_DIliveryHed INNER JOIN " +
                         "dbo.T_DiliveryDet ON dbo.T_DIliveryHed.DoNo = dbo.T_DiliveryDet.DoNo INNER JOIN dbo.M_Customers ON dbo.T_DIliveryHed.Customer = dbo.M_Customers.CusID INNER JOIN dbo.M_Agents ON dbo.T_DIliveryHed.Agent = dbo.M_Agents.AgentCode " +
                         "WHERE dbo.T_DIliveryHed.DoNo = '" + DONo.Trim() + "'";
            return str;
        }

        public static String GetPAckingPrintSTR(string Packno)
        {
            string str = "SELECT     dbo.T_packinghead.PackingNo, dbo.T_packinghead.RefNumber, dbo.T_packinghead.Datex, dbo.T_packinghead.NoOfCartons, dbo.T_packinghead.Vehicle,dbo.T_packinghead.Driver, dbo.T_packinghead.CreatedUser, dbo.T_packinghead.CreatedTime, dbo.T_packingdet.Dono, dbo.T_packingdet.Customer,dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_packingdet.Agent,dbo.M_Agents.Namex, dbo.M_Agents.Address1 AS AgentAddress1, dbo.M_Agents.Address2 AS AgentAddress2, dbo.M_Agents.Address3 AS AgentAddress3,dbo.M_Agents.TPOffice, dbo.M_Agents.TPPersonal, dbo.T_packingdet.datex AS DateCreated, dbo.T_packingdet.TTLCartons " +
                         "FROM         dbo.T_packinghead INNER JOIN dbo.T_packingdet ON dbo.T_packinghead.PackingNo = dbo.T_packingdet.PackingNo INNER JOIN dbo.M_Customers ON dbo.T_packingdet.Customer = dbo.M_Customers.CusID LEFT OUTER JOIN  dbo.M_Agents ON dbo.T_packingdet.Agent = dbo.M_Agents.AgentCode " +
                         "WHERE dbo.T_packinghead.PackingNo = '" + Packno.Trim() + "'";
            return str;
        }


        public static String GetReceiptSTR(string recno)
        {
            string str = "SELECT     dbo.T_RecHed.Docno, dbo.T_RecHed.Datex AS 'ReceiptDate', dbo.T_RecHed.Customer, dbo.M_Customers.CustName, dbo.T_RecHed.Status, dbo.T_RecHed.refNo, dbo.T_RecHed.Memo,dbo.T_RecHed.Recivedfrom, dbo.T_RecHed.remarks, dbo.T_RecHed.Amount, dbo.T_RecHed.isProcessed, dbo.T_RecHed.processDate, dbo.T_RecHed.processUser,dbo.T_RecHed.CancelledUser, dbo.T_RecHed.CancelledDate, dbo.T_RecDet.Sequence, dbo.T_RecDet.Paytype, dbo.T_RecDet.HeadAmt, dbo.T_RecDet.Amt,dbo.T_RecDet.InvNo, dbo.T_RecDet.Datex, dbo.T_RecDet.CQno, dbo.T_RecDet.Bank, dbo.T_RecDet.BankBranch, dbo.T_RecDet.BankDate, dbo.T_RecDet.isReconsile,dbo.T_RecDet.ReconsileDate, dbo.T_RecDet.isreturned, dbo.T_RecDet.ReturnDate, dbo.T_CusSettle.RefNo AS settleRefno, dbo.T_CusSettle.NetAmt,dbo.T_CusSettle.PaidAmt, dbo.T_CusSettle.DueAmt, dbo.T_CusSettle.Settlement " +
                         "FROM       dbo.T_RecHed INNER JOIN dbo.T_RecDet ON dbo.T_RecHed.Docno = dbo.T_RecDet.Docno INNER JOIN dbo.M_Customers ON dbo.T_RecHed.Customer = dbo.M_Customers.CusID INNER JOIN dbo.T_CusSettle ON dbo.T_RecHed.Customer = dbo.T_CusSettle.Customer " +
                         "WHERE      dbo.T_RecHed.Docno = '" + recno.Trim() + "'";
            return str;
        }

        public static String GetPendingApprovaltSTR(string recno)
        {
            string str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.T_OrderTracking.SalesMan, dbo.u_User.userName,dbo.T_OrderTracking.OFApproved, dbo.T_OrderTracking.OFApprovedUser, dbo.T_OrderTracking.OFApprovedDate, dbo.T_OrderTracking.InvCreated,dbo.T_OrderTracking.InvNo, dbo.T_OrderTracking.InvAmount, dbo.T_OrderTracking.InvApproved, dbo.T_OrderTracking.InvApprovedUser,dbo.T_OrderTracking.InvApprovedDate, dbo.T_OrderTracking.DOCreated, dbo.T_OrderTracking.DONo, dbo.T_OrderTracking.DOAmount,dbo.T_OrderTracking.DOMultipleNO, dbo.T_OrderTracking.DOProcessed, dbo.T_OrderTracking.DOProcessedUser, dbo.T_OrderTracking.DOProcessedDate,dbo.T_OrderTracking.DOApproved, dbo.T_OrderTracking.DOApprovedUser, dbo.T_OrderTracking.DOApprovedDate, dbo.T_OrderTracking.Audited,dbo.T_OrderTracking.AuditDate, dbo.T_OrderTracking.AuditUser, dbo.T_OrderTracking.Dispatched, dbo.T_OrderTracking.DispatchedDate, dbo.T_OrderTracking.DispatchedUser, dbo.T_OrderTracking.Handedover, dbo.T_OrderTracking.HandedoverUser, dbo.T_OrderTracking.HandedoverDate,dbo.T_OrderTracking.Completed, dbo.T_OrderTracking.CompletedUser, dbo.T_OrderTracking.CompletedDate, dbo.T_OrderTracking.PackingListCreated,dbo.T_OrderTracking.PackingListNo, dbo.T_OrderTracking.PackingListDate, dbo.T_OrderTracking.PackingListUser, dbo.T_OrderTracking.Remarks,dbo.T_OrderTracking.HandOverLorry, dbo.T_OrderTracking.CompleteRemark, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.InvoiceDate,dbo.T_OrderTracking.Dodate " +
                         "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID INNER JOIN dbo.u_User ON dbo.T_OrderTracking.SalesMan = dbo.u_User.userId";
            return str;
        }

        public static String GetPendingApprovalOF(string value1 ,string val2, DateTime datefrom , DateTime dateto,int option)
        {
            string str = "";
            if (option == 1)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.OFApproved, dbo.T_OrderTracking.OFApprovedUser,dbo.T_OrderTracking.OFApprovedDate, dbo.T_OrderTracking.OFNoOfPrints, dbo.T_OrderTracking.OFPrintUser, dbo.T_OrderTracking.OrderDate " +
                         "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                         "WHERE     (dbo.T_OrderTracking.OFApproved = 0) AND (dbo.T_OrderTracking.Customer = '" + value1.Trim() + "')" +
                         "AND (dbo.T_OrderTracking.OrderDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103)) ";
            }
            else if(option ==2) {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.OFApproved, dbo.T_OrderTracking.OFApprovedUser,dbo.T_OrderTracking.OFApprovedDate, dbo.T_OrderTracking.OFNoOfPrints, dbo.T_OrderTracking.OFPrintUser, dbo.T_OrderTracking.OrderDate " +
                            "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                            "WHERE     (dbo.T_OrderTracking.OFApproved = 0) AND " +
                            "(dbo.M_Customers.cat = '" + value1 .Trim()+ "') " +
                            "AND (dbo.T_OrderTracking.OrderDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103)) ";
            }
            else if (option == 3)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.OFApproved, dbo.T_OrderTracking.OFApprovedUser,dbo.T_OrderTracking.OFApprovedDate, dbo.T_OrderTracking.OFNoOfPrints, dbo.T_OrderTracking.OFPrintUser, dbo.T_OrderTracking.OrderDate " +
                            "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                            "WHERE     (dbo.T_OrderTracking.OFApproved = 0) AND " +
                            "(dbo.M_Customers.cat = '" + value1.Trim() + "')  AND (dbo.M_Customers.subcat = '" + val2.Trim() +"') " +
                            "AND (dbo.T_OrderTracking.OrderDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103)) ";
            }
            if (option == 4)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.OFApproved, dbo.T_OrderTracking.OFApprovedUser,dbo.T_OrderTracking.OFApprovedDate, dbo.T_OrderTracking.OFNoOfPrints, dbo.T_OrderTracking.OFPrintUser, dbo.T_OrderTracking.OrderDate " +
                         "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                         "WHERE     (dbo.T_OrderTracking.OFApproved = 0)" +
                         "AND (dbo.T_OrderTracking.OrderDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103)) ";
            }
            return str;
        }

        public static String GetPendingApprovalInvoices(string value1, string val2, DateTime datefrom, DateTime dateto, int option)
        {
            string str = "";
            if (option == 1)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.T_OrderTracking.InvCreated, dbo.T_OrderTracking.InvNo,dbo.T_OrderTracking.InvAmount, dbo.T_OrderTracking.InvApproved, dbo.T_OrderTracking.InvApprovedUser, dbo.T_OrderTracking.InvApprovedDate,dbo.T_OrderTracking.InvNoOfPrints, dbo.T_OrderTracking.InvPrintUser, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.InvoiceDate " +
                             "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                             "WHERE     (dbo.T_OrderTracking.InvApproved = 0) AND (dbo.T_OrderTracking.InvCreated = 1) AND (dbo.T_OrderTracking.Customer = '" + value1.Trim() + "')" +
                             "AND (dbo.T_OrderTracking.InvoiceDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            }
            if (option == 2)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.T_OrderTracking.InvCreated, dbo.T_OrderTracking.InvNo,dbo.T_OrderTracking.InvAmount, dbo.T_OrderTracking.InvApproved, dbo.T_OrderTracking.InvApprovedUser, dbo.T_OrderTracking.InvApprovedDate,dbo.T_OrderTracking.InvNoOfPrints, dbo.T_OrderTracking.InvPrintUser, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.InvoiceDate " +
                             "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                             "WHERE     (dbo.T_OrderTracking.InvApproved = 0) AND (dbo.T_OrderTracking.InvCreated = 1) AND " +
                             "(dbo.M_Customers.cat = '" + value1.Trim() + "') " +
                             "AND (dbo.T_OrderTracking.InvoiceDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            }
            else if (option == 3)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.T_OrderTracking.InvCreated, dbo.T_OrderTracking.InvNo,dbo.T_OrderTracking.InvAmount, dbo.T_OrderTracking.InvApproved, dbo.T_OrderTracking.InvApprovedUser, dbo.T_OrderTracking.InvApprovedDate,dbo.T_OrderTracking.InvNoOfPrints, dbo.T_OrderTracking.InvPrintUser, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.InvoiceDate " +
                         "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                         "WHERE     (dbo.T_OrderTracking.InvApproved = 0) AND (dbo.T_OrderTracking.InvCreated = 1) AND " +
                         "(dbo.M_Customers.cat = '" + value1.Trim() + "')  AND (dbo.M_Customers.subcat = '" + val2.Trim() + "') " +
                         "AND (dbo.T_OrderTracking.InvoiceDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            }
            else if (option == 4)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.T_OrderTracking.InvCreated, dbo.T_OrderTracking.InvNo,dbo.T_OrderTracking.InvAmount, dbo.T_OrderTracking.InvApproved, dbo.T_OrderTracking.InvApprovedUser, dbo.T_OrderTracking.InvApprovedDate,dbo.T_OrderTracking.InvNoOfPrints, dbo.T_OrderTracking.InvPrintUser, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.InvoiceDate " +
                         "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                         "WHERE     (dbo.T_OrderTracking.InvApproved = 0) AND (dbo.T_OrderTracking.InvCreated = 1) " +
                         "AND (dbo.T_OrderTracking.InvoiceDate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            }

            return str;
        }

        public static String GetPendingApprovaldos(string value1, string val2, DateTime datefrom, DateTime dateto, int option)
        {
            string str = "";
            if (option == 1)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.T_OrderTracking.DOAmount, dbo.T_OrderTracking.DOMultipleNO, dbo.T_OrderTracking.DOProcessed,dbo.T_OrderTracking.DOProcessedUser, dbo.T_OrderTracking.DONo, dbo.T_OrderTracking.DOCreated, dbo.T_OrderTracking.DOProcessedDate,dbo.T_OrderTracking.DOApproved, dbo.T_OrderTracking.DOApprovedUser, dbo.T_OrderTracking.DOApprovedDate, dbo.T_OrderTracking.DONoOfPrints,dbo.T_OrderTracking.DOvPrintUser, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.Dodate " +
                       "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                       " WHERE DOCreated = 1 AND DOApproved = 0  AND (dbo.T_OrderTracking.Customer = '" + value1.Trim() + "')" +
                       "AND (dbo.T_OrderTracking.Dodate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            }
            if (option == 2)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.T_OrderTracking.DOAmount, dbo.T_OrderTracking.DOMultipleNO, dbo.T_OrderTracking.DOProcessed,dbo.T_OrderTracking.DOProcessedUser, dbo.T_OrderTracking.DONo, dbo.T_OrderTracking.DOCreated, dbo.T_OrderTracking.DOProcessedDate,dbo.T_OrderTracking.DOApproved, dbo.T_OrderTracking.DOApprovedUser, dbo.T_OrderTracking.DOApprovedDate, dbo.T_OrderTracking.DONoOfPrints,dbo.T_OrderTracking.DOvPrintUser, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.Dodate " +
                       "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                       " WHERE DOCreated = 1 AND DOApproved = 0 AND" +
                       "(dbo.M_Customers.cat = '" + value1.Trim() + "') " +
                       "AND (dbo.T_OrderTracking.Dodate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";

            }
            if (option == 3)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.T_OrderTracking.DOAmount, dbo.T_OrderTracking.DOMultipleNO, dbo.T_OrderTracking.DOProcessed,dbo.T_OrderTracking.DOProcessedUser, dbo.T_OrderTracking.DONo, dbo.T_OrderTracking.DOCreated, dbo.T_OrderTracking.DOProcessedDate,dbo.T_OrderTracking.DOApproved, dbo.T_OrderTracking.DOApprovedUser, dbo.T_OrderTracking.DOApprovedDate, dbo.T_OrderTracking.DONoOfPrints,dbo.T_OrderTracking.DOvPrintUser, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.Dodate " +
                       "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                       " WHERE DOCreated = 1 AND DOApproved = 0 " +
                       "(dbo.M_Customers.cat = '" + value1.Trim() + "')  AND (dbo.M_Customers.subcat = '" + val2.Trim() + "') " +
                       "AND (dbo.T_OrderTracking.Dodate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            
            }
            if (option == 4)
            {
                str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.T_OrderTracking.DOAmount, dbo.T_OrderTracking.DOMultipleNO, dbo.T_OrderTracking.DOProcessed,dbo.T_OrderTracking.DOProcessedUser, dbo.T_OrderTracking.DONo, dbo.T_OrderTracking.DOCreated, dbo.T_OrderTracking.DOProcessedDate,dbo.T_OrderTracking.DOApproved, dbo.T_OrderTracking.DOApprovedUser, dbo.T_OrderTracking.DOApprovedDate, dbo.T_OrderTracking.DONoOfPrints,dbo.T_OrderTracking.DOvPrintUser, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email,dbo.M_Customers.Address1, dbo.M_Customers.Address2, dbo.M_Customers.Address3, dbo.T_OrderTracking.Dodate " +
                       "FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                       " WHERE DOCreated = 1 AND DOApproved = 0 " +
                       "AND (dbo.T_OrderTracking.Dodate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";

            }
            return str;
        }

        public static String GetOrderTrackOne(string code)
        {
            string str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.InvoiceDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate,dbo.T_OrderTracking.InvoiceDate) AS 'INVvari', dbo.T_OrderTracking.Dodate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.Dodate)AS 'DOvari', dbo.T_OrderTracking.AuditDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.AuditDate) AS 'AUDITvari',dbo.T_OrderTracking.DispatchedDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.DispatchedDate) AS 'Dispatchvari',dbo.T_OrderTracking.HandedoverDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.HandedoverDate) AS HandoeverVari, dbo.T_OrderTracking.CompletedDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.CompletedDate) AS CompleteVari,dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email, dbo.M_Customers.Address1,dbo.M_Customers.Address2, dbo.M_Customers.Address3 "+
                         " FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID " +
                         " WHERE ofno = '" + code.Trim() + "' ";
            return str;
        }

        public static String GetOrderTrackSummary(string val1,bool val2,string val3, DateTime datefrom, DateTime dateto, int Headeroption , int trackingoption)
        {
            
            string str = "";
            str = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.InvoiceDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate,dbo.T_OrderTracking.InvoiceDate) AS 'INVvari', dbo.T_OrderTracking.Dodate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.Dodate)AS 'DOvari', dbo.T_OrderTracking.AuditDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.AuditDate) AS 'AUDITvari',dbo.T_OrderTracking.DispatchedDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.DispatchedDate) AS 'Dispatchvari',dbo.T_OrderTracking.HandedoverDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.HandedoverDate) AS HandoeverVari, dbo.T_OrderTracking.CompletedDate, DATEDIFF(DAY, dbo.T_OrderTracking.OrderDate, dbo.T_OrderTracking.CompletedDate) AS CompleteVari,dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.M_Customers.TP, dbo.M_Customers.Fax, dbo.M_Customers.Email, dbo.M_Customers.Address1,dbo.M_Customers.Address2, dbo.M_Customers.Address3 " +
                  " FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID WHERE " + 
                  "(dbo.T_OrderTracking.Dodate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            if (Headeroption == 1)
            {
                if (trackingoption == 1) {
                    str += " AND (dbo.T_OrderTracking.InvCreated = " + Convert.ToInt16(val2).ToString() + ")";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_OrderTracking.InvCreated  = 1 AND dbo.T_OrderTracking.DOCreated  = 0 )";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_OrderTracking.DOProcessed  = 1 AND dbo.T_OrderTracking.Audited  = 0 )";
                }
                else if (trackingoption == 4)
                {
                    str += " AND (dbo.T_OrderTracking.Audited  = 1 AND dbo.T_OrderTracking.Dispatched  = 0 )";
                }
                else if (trackingoption == 5)
                {
                    str += " AND (dbo.T_OrderTracking.Dispatched  = 1 AND dbo.T_OrderTracking.Handedover  = 0 )";
                }
                else if (trackingoption == 6)
                {
                    str += " AND (dbo.T_OrderTracking.Handedover  = 1 AND dbo.T_OrderTracking.Completed  = 0 )";
                }
                         
            }
            if (Headeroption == 2)
            {
                str += " AND dbo.T_OrderTracking.Customer = '"+val1.Trim()+"'";

                if (trackingoption == 1)
                {
                    str += " AND (dbo.T_OrderTracking.InvCreated = " + Convert.ToInt16(val2).ToString() + ")";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_OrderTracking.InvCreated  = 1 AND dbo.T_OrderTracking.DOCreated  = 0 )";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_OrderTracking.DOProcessed  = 1 AND dbo.T_OrderTracking.Audited  = 0 )";
                }
                else if (trackingoption == 4)
                {
                    str += " AND (dbo.T_OrderTracking.Audited  = 1 AND dbo.T_OrderTracking.Dispatched  = 0 )";
                }
                else if (trackingoption == 5)
                {
                    str += " AND (dbo.T_OrderTracking.Dispatched  = 1 AND dbo.T_OrderTracking.Handedover  = 0 )";
                }
                else if (trackingoption == 6)
                {
                    str += " AND (dbo.T_OrderTracking.Handedover  = 1 AND dbo.T_OrderTracking.Completed  = 0 )";
                }

            }
            if (Headeroption == 3)
            {
                str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "'";

                if (trackingoption == 1)
                {
                    str += " AND (dbo.T_OrderTracking.InvCreated = " + Convert.ToInt16(val2).ToString() + ")";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_OrderTracking.InvCreated  = 1 AND dbo.T_OrderTracking.DOCreated  = 0 )";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_OrderTracking.DOProcessed  = 1 AND dbo.T_OrderTracking.Audited  = 0 )";
                }
                else if (trackingoption == 4)
                {
                    str += " AND (dbo.T_OrderTracking.Audited  = 1 AND dbo.T_OrderTracking.Dispatched  = 0 )";
                }
                else if (trackingoption == 5)
                {
                    str += " AND (dbo.T_OrderTracking.Dispatched  = 1 AND dbo.T_OrderTracking.Handedover  = 0 )";
                }
                else if (trackingoption == 6)
                {
                    str += " AND (dbo.T_OrderTracking.Handedover  = 1 AND dbo.T_OrderTracking.Completed  = 0 )";
                }

            }
            if (Headeroption == 4)
            {
                str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "' AND dbo.M_Customers.subcat = '" + val3.Trim()+"'";

                if (trackingoption == 1)
                {
                    str += " AND (dbo.T_OrderTracking.InvCreated = " + Convert.ToInt16(val2).ToString() + ")";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_OrderTracking.InvCreated  = 1 AND dbo.T_OrderTracking.DOCreated  = 0 )";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_OrderTracking.DOProcessed  = 1 AND dbo.T_OrderTracking.Audited  = 0 )";
                }
                else if (trackingoption == 4)
                {
                    str += " AND (dbo.T_OrderTracking.Audited  = 1 AND dbo.T_OrderTracking.Dispatched  = 0 )";
                }
                else if (trackingoption == 5)
                {
                    str += " AND (dbo.T_OrderTracking.Dispatched  = 1 AND dbo.T_OrderTracking.Handedover  = 0 )";
                }
                else if (trackingoption == 6)
                {
                    str += " AND (dbo.T_OrderTracking.Handedover  = 1 AND dbo.T_OrderTracking.Completed  = 0 )";
                }

            }
          //  "(T_OrderTracking.Customer = '" + val1.Trim() + "') " +
          //" (dbo.T_OrderTracking.InvCreated = " + Convert.ToInt16(val2).ToString() + ")" +
          // "AND (dbo.T_OrderTracking.Dodate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";

           return str;
        }

        public static String GetCQDetails(string val1, bool val2, string val3, DateTime datefrom, DateTime dateto, int Headeroption, int trackingoption)
        {

            string str = "";
            str = "SELECT     dbo.T_RecDet.Docno AS [Receipt No],dbo.M_Customers.CusID, dbo.T_RecDet.CQno AS [Cheque No], dbo.T_RecDet.Amt, dbo.T_RecDet.Bank, dbo.M_Bank.BANK_NAME AS [Bank Name],dbo.T_RecDet.BankBranch AS Branch, dbo.T_RecDet.BankDate AS [Bank Date], dbo.T_RecDet.isReconsile AS Reconsiled, dbo.T_RecDet.isreturned AS Returned,'' AS 'Reason To Return', dbo.M_Customers.CustName, DATEDIFF(DAY, CONVERT(DATETIME, GETDATE(), 103), CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) AS 'DateDIF' FROM         dbo.T_RecDet INNER JOIN dbo.M_Bank ON dbo.T_RecDet.Bank = dbo.M_Bank.BANK_CODE INNER JOIN dbo.M_Customers ON dbo.T_RecDet.Customer = dbo.M_Customers.CusID WHERE   (dbo.T_RecDet.Paytype = 'CQ') ";
                  
            if (Headeroption == 1)
            {
                if (trackingoption == 1)
                {
                    str += " AND (DATEDIFF(DAY, CONVERT(DATETIME, GETDATE(), 103), CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0) AND (dbo.T_RecDet.isReconsile = 0) AND (dbo.T_RecDet.isreturned = 0)";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_RecDet.isreturned = 1)";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_RecDet.isReconsile = 1) ";
                }
                else if (trackingoption == 4)
                {
                    str += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                }
            }
            if (Headeroption == 2)
            {
                str += " AND dbo.M_Customers.CusID = '" + val1.Trim() + "'";

                if (trackingoption == 1)
                {
                    str += " AND (DATEDIFF(DAY, CONVERT(DATETIME, GETDATE(), 103), CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0) AND (dbo.T_RecDet.isReconsile = 0) AND (dbo.T_RecDet.isreturned = 0)";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_RecDet.isreturned = 1)";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_RecDet.isReconsile = 1) ";
                }
                else if (trackingoption == 4)
                {
                    str += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                }

            }
            if (Headeroption == 3)
            {
                str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "'";

                if (trackingoption == 1)
                {
                    str += " AND (DATEDIFF(DAY, CONVERT(DATETIME, GETDATE(), 103), CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0) AND (dbo.T_RecDet.isReconsile = 0) AND (dbo.T_RecDet.isreturned = 0)";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_RecDet.isreturned = 1)";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_RecDet.isReconsile = 1) ";
                }
                else if (trackingoption == 4)
                {
                    str += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                }

            }
            if (Headeroption == 4)
            {
                str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "' AND dbo.M_Customers.subcat = '" + val3.Trim() + "'";

                if (trackingoption == 1)
                {
                    str += " AND (DATEDIFF(DAY, CONVERT(DATETIME, GETDATE(), 103), CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0) AND (dbo.T_RecDet.isReconsile = 0) AND (dbo.T_RecDet.isreturned = 0)";
                }
                else if (trackingoption == 2)
                {
                    str += " AND (dbo.T_RecDet.isreturned = 1)";
                }
                else if (trackingoption == 3)
                {
                    str += " AND (dbo.T_RecDet.isReconsile = 1) ";
                }
                else if (trackingoption == 4)
                {
                    str += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                }

            }
            //  "(T_OrderTracking.Customer = '" + val1.Trim() + "') " +
            //" (dbo.T_OrderTracking.InvCreated = " + Convert.ToInt16(val2).ToString() + ")" +
            // "AND (dbo.T_OrderTracking.Dodate BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";

            return str;
        }

        public static String GetCusLiabilityDet(string val1, bool val2, string val3, DateTime datefrom, DateTime dateto, int Headeroption, int trackingoption)
        {

            RunCusLiability();
            string str = "";
            str = "SELECT     dbo.R_Customer_liabilitySum.Salesman, dbo.u_User.userName, dbo.R_Customer_liabilitySum.Customer, dbo.M_Customers.CustName,dbo.R_Customer_liabilitySum.Outstanding, dbo.R_Customer_liabilitySum.Pd, dbo.R_Customer_liabilitySum.Rtn, dbo.R_Customer_liabilitySum.Unreqalized, dbo.R_Customer_liabilitySum.Datex " +
                  " FROM         dbo.R_Customer_liabilitySum INNER JOIN dbo.M_Customers ON dbo.R_Customer_liabilitySum.Customer = dbo.M_Customers.CusID INNER JOIN dbo.u_User ON dbo.R_Customer_liabilitySum.Salesman = dbo.u_User.userId";

            if (Headeroption == 1)
            {
                if (trackingoption == 1)
                {
                    str += " ";
                }
                else if (trackingoption == 2)
                {
                    str += " WHERE customer BETWEEN '" + val1.Trim() + "' AND '" + val3.Trim() +"'";
                }
                else if (trackingoption == 3)
                {
                    str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "'";

                }
                else if (trackingoption == 4)
                {
                    str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "' AND dbo.M_Customers.subcat = '" + val3.Trim() + "'";

                }
                else if (trackingoption == 5)
                {
                    str += " WHERE salesman = '" + val1.Trim() + "'";
                }

            }
          
            return str;
        }

        public static String GetSalesSammaryNew(string val1, bool val2, string val3, DateTime datefrom, DateTime dateto, int Headeroption, int trackingoption)
        {

           RunSalesSammaryNew(commonFunctions.GlobalLocation, "001", datefrom, dateto);
            string str = "";
            str = "SELECT     CustomerID, Customername, Salesman,ISNULL(SUM(CASE [paytype] WHEN 'SL' THEN Amt ELSE 0 END), 0) AS 'Total Sale',ISNULL(SUM(CASE [paytype] WHEN 'CA' THEN Amt ELSE 0 END), 0) AS 'CA',ISNULL(SUM(CASE [paytype] WHEN 'CQ' THEN Amt ELSE 0 END), 0) AS 'CQ', ISNULL(SUM(CASE [paytype] WHEN 'CC' THEN Amt ELSE 0 END), 0) AS 'CC',ISNULL(SUM(CASE [paytype] WHEN 'CU' THEN Amt ELSE 0 END), 0) AS 'CU',ISNULL(SUM(CASE [paytype] WHEN 'DC' THEN Amt ELSE 0 END), 0) AS 'DC',ISNULL(SUM(CASE [paytype] WHEN 'DD' THEN Amt ELSE 0 END), 0) AS 'DD',ISNULL(SUM(CASE [paytype] WHEN 'OT' THEN Amt ELSE 0 END), 0) AS 'OT' FROM  dbo.Z_SalesSummaryNew GROUP BY CustomerID, Customername, Salesman";

            if (Headeroption == 1)
            {
                if (trackingoption == 1)
                {
                    str += " ";
                }
                else if (trackingoption == 2)
                {
                    str += " WHERE customer BETWEEN '" + val1.Trim() + "' AND '" + val3.Trim() + "'";
                }
                else if (trackingoption == 3)
                {
                    str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "'";

                }
                else if (trackingoption == 4)
                {
                    str += " AND dbo.M_Customers.cat = '" + val1.Trim() + "' AND dbo.M_Customers.subcat = '" + val3.Trim() + "'";

                }
                else if (trackingoption == 5)
                {
                    str += " WHERE salesman = '" + val1.Trim() + "'";
                }

            }

            return str;
        }
            

        public static String GetBinCard(string loca, int paramtype, string code, string code2)
        {
            RunBinCard(loca);
            string str = "";
            if (paramtype == 0)
            {
                //str = "SELECT     dbo.Z_BinCard.ItemCode, SUM(dbo.Z_BinCard.GRN) AS GRN, SUM(dbo.Z_BinCard.Sales) AS Sales, SUM(dbo.Z_BinCard.STKAdd) AS STKAdd, SUM(dbo.Z_BinCard.STKRed) AS STKRed, SUM(dbo.Z_BinCard.OpenSTK) AS OpenSTK " +
                //      "FROM         dbo.Z_BinCard INNER JOIN dbo.M_Products ON dbo.Z_BinCard.ItemCode = dbo.M_Products.IDX INNER JOIN dbo.T_Stock ON dbo.M_Products.IDX = dbo.T_Stock.ProductId WHERE     (dbo.T_Stock.Locacode = '" + loca.Trim() +"') GROUP BY dbo.Z_BinCard.ItemCode";

                str = "SELECT     dbo.Z_BinCard.ItemCode, SUM(dbo.Z_BinCard.GRN) AS GRN, SUM(dbo.Z_BinCard.Sales) AS Sales, SUM(dbo.Z_BinCard.STKAdd) AS STKAdd,SUM(dbo.Z_BinCard.STKRed) AS STKRed, SUM(dbo.Z_BinCard.OpenSTK) AS OpenSTK, SUM(dbo.Z_BinCard.CN) AS CN, SUM(dbo.Z_BinCard.Trans) AS Trans, SUM(dbo.Z_BinCard.SIH) AS SIH , dbo.M_Products.Namex ,SUM(dbo.Z_BinCard.TransOut) AS TransOut " +
                      "FROM         dbo.Z_BinCard INNER JOIN dbo.M_Products ON dbo.Z_BinCard.ItemCode = dbo.M_Products.IDX INNER JOIN dbo.T_Stock ON dbo.M_Products.IDX = dbo.T_Stock.ProductId " +
                      "WHERE     (dbo.T_Stock.Locacode = '" + loca.Trim() + "') GROUP BY dbo.Z_BinCard.ItemCode, dbo.M_Products.Namex";

            }
            else if (paramtype == 1)
            {
                //str += " WHERE customer BETWEEN '" + val1.Trim() + "' AND '" + val3.Trim() +"'";
                str = "SELECT     dbo.Z_BinCard.ItemCode, SUM(dbo.Z_BinCard.GRN) AS GRN, SUM(dbo.Z_BinCard.Sales) AS Sales, SUM(dbo.Z_BinCard.STKAdd) AS STKAdd,SUM(dbo.Z_BinCard.STKRed) AS STKRed, SUM(dbo.Z_BinCard.OpenSTK) AS OpenSTK, SUM(dbo.Z_BinCard.CN) AS CN, SUM(dbo.Z_BinCard.Trans) AS Trans, SUM(dbo.Z_BinCard.SIH) AS SIH , dbo.M_Products.Namex ,SUM(dbo.Z_BinCard.TransOut) AS TransOut  " +
                      "FROM         dbo.Z_BinCard INNER JOIN dbo.M_Products ON dbo.Z_BinCard.ItemCode = dbo.M_Products.IDX INNER JOIN  dbo.T_Stock ON dbo.M_Products.IDX = dbo.T_Stock.ProductId " +
                      "WHERE     (dbo.T_Stock.Locacode = '" + loca.Trim() + "') AND Category = '" + code.Trim() + "' AND SubCategory = '" +code2.Trim() +"' " +
                      "GROUP BY dbo.Z_BinCard.ItemCode, dbo.M_Products.Namex";
            }
            else if (paramtype == 2)
            {
                //str += " WHERE customer BETWEEN '" + val1.Trim() + "' AND '" + val3.Trim() +"'";
                str = "SELECT     dbo.Z_BinCard.ItemCode, SUM(dbo.Z_BinCard.GRN) AS GRN, SUM(dbo.Z_BinCard.Sales) AS Sales, SUM(dbo.Z_BinCard.STKAdd) AS STKAdd,SUM(dbo.Z_BinCard.STKRed) AS STKRed, SUM(dbo.Z_BinCard.OpenSTK) AS OpenSTK, SUM(dbo.Z_BinCard.CN) AS CN, SUM(dbo.Z_BinCard.Trans) AS Trans, SUM(dbo.Z_BinCard.SIH) AS SIH , dbo.M_Products.Namex ,SUM(dbo.Z_BinCard.TransOut) AS TransOut " +
                      "FROM         dbo.Z_BinCard INNER JOIN dbo.M_Products ON dbo.Z_BinCard.ItemCode = dbo.M_Products.IDX INNER JOIN  dbo.T_Stock ON dbo.M_Products.IDX = dbo.T_Stock.ProductId " +
                      "WHERE     (dbo.T_Stock.Locacode = '" + loca.Trim() + "') AND Category = '"+code.Trim()+"' "+
                      "GROUP BY dbo.Z_BinCard.ItemCode, dbo.M_Products.Namex";
            }
            else if (paramtype == 3)
            {
                //str += " WHERE customer BETWEEN '" + val1.Trim() + "' AND '" + val3.Trim() +"'";
                str = "SELECT     dbo.Z_BinCard.ItemCode, SUM(dbo.Z_BinCard.GRN) AS GRN, SUM(dbo.Z_BinCard.Sales) AS Sales, SUM(dbo.Z_BinCard.STKAdd) AS STKAdd,SUM(dbo.Z_BinCard.STKRed) AS STKRed, SUM(dbo.Z_BinCard.OpenSTK) AS OpenSTK, SUM(dbo.Z_BinCard.CN) AS CN, SUM(dbo.Z_BinCard.Trans) AS Trans, SUM(dbo.Z_BinCard.SIH) AS SIH , dbo.M_Products.Namex ,SUM(dbo.Z_BinCard.TransOut) AS TransOut " +
                      "FROM         dbo.Z_BinCard INNER JOIN dbo.M_Products ON dbo.Z_BinCard.ItemCode = dbo.M_Products.IDX INNER JOIN  dbo.T_Stock ON dbo.M_Products.IDX = dbo.T_Stock.ProductId " +
                      "WHERE     (dbo.T_Stock.Locacode = '" + loca.Trim() + "') and " +
                      " dbo.Z_BinCard.ItemCode BETWEEN '" + code.Trim() + "' AND '" + code2.Trim() + "'" +
                       "GROUP BY dbo.Z_BinCard.ItemCode, dbo.M_Products.Namex";
            }
            return str;
        }

        public static String GetStockCard(string loca, int paramtype, string code, string code2)
        {
            RunStockCard(code, loca,commonFunctions.GlobalCompany);
            string str = "";
            if (paramtype == 0)
            {
                str = "SELECT * FROM [Z_STOCKCARD]" +
                      "WHERE  (stk_location = '" + code2.Trim() + "')  AND stk_code = '" + code.Trim() + "'";
            }
            else if (paramtype == 1)
            {
                str = "SELECT * FROM [Z_STOCKCARD]" +
                      "WHERE stk_code = '" + code.Trim() + "'";
            }
            return str;
        }


        public static String GetStockEvoNew(string loca, string val1, string val2, string val3, int rangeoption, int filterOption)
        {

            string str = "";
            str = "SELECT     dbo.T_Stock.StockCode, dbo.M_Products.IDX, dbo.M_Products.Namex, dbo.T_Stock.Compcode, dbo.T_Stock.Locacode, dbo.M_Products.Category, dbo.M_Category.Descr, dbo.T_Stock.Stock, dbo.T_Stock.AvgCost, dbo.T_Stock.CostPrice, dbo.M_Products.SellingPrice FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX INNER JOIN dbo.M_Category ON dbo.M_Products.Category = dbo.M_Category.Codex " +
                   "WHERE     (dbo.T_Stock.Compcode = '001') AND (dbo.T_Stock.Locacode = '" + loca.Trim() + "') ";
            //full details
            if (rangeoption == 1)
            {
                if (filterOption == 1)
                {
                    str += "";
                }
               
            }
          
            return str;
        }


        public static DataTable GetSalesAlloc(string val1,  string val3,  int Headeroption)
        {
            DataTable det = new DataTable();
            try
            {
                det = smartOffice_Models.u_DBConnection.ReturnDataTable("SP_AllocationSal_cus", CommandType.StoredProcedure);
                return det;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable GetSalesAllocSalOnly(string val1, string val3, int Headeroption)
        {
            DataTable det = new DataTable();
            try
            {
                det = smartOffice_Models.u_DBConnection.ReturnDataTable("SP_AllocationSal_Only", CommandType.StoredProcedure);
                return det;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static String GetStockBalance(string val1, string val2, string val3, int Headeroption, int middleoption, int bottomoption)
        {

            string str = "";
           
            if (Headeroption == 1)
            {
                str = "SELECT     dbo.T_Stock.ProductId, dbo.M_Products.Namex, dbo.M_Products.Category, dbo.M_Category.Descr, SUM(dbo.T_Stock.Stock) AS SIH FROM dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX INNER JOIN dbo.M_Category ON dbo.M_Products.Category = dbo.M_Category.Codex " +
                    " WHERE dbo.T_Stock.Locacode = '" + commonFunctions.GlobalLocation.Trim()+"'";
                     
                //Show all
                if (middleoption == 1)
                {
                    
                }
                else if (middleoption == 2) // Location
                {
                    
                }

                str += " GROUP BY dbo.T_Stock.ProductId, dbo.M_Products.Namex, dbo.M_Products.Category, dbo.M_Category.Descr";
            }
            else if (Headeroption == 2) {
                str = "SELECT     dbo.T_Stock.StockCode, dbo.M_Products.Namex, dbo.M_Products.Category, dbo.M_Category.Descr, dbo.T_Stock.Stock FROM dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX INNER JOIN dbo.M_Category ON dbo.M_Products.Category = dbo.M_Category.Codex ";
                if (middleoption == 1)
                {

                }
                
            }

            
            return str;
        }


        public static String GetLiveStock(string loca, int paramtype, string code, string code2)
        {
         
            string str = "";
            if (paramtype == 0)
            {
                     str = "SELECT     dbo.T_Stock.StockCode, dbo.M_Products.Namex AS Description, dbo.T_Stock.Stock AS SIH, dbo.T_Stock.ReservedStock AS [Reserved SIH], dbo.T_Stock.Suppid AS Supplier,dbo.M_Suppliers.suppName AS [Supplier Name], dbo.M_Products.UnitPrice, dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice" +
                      " FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX INNER JOIN dbo.M_Suppliers ON dbo.T_Stock.Suppid = dbo.M_Suppliers.SupID INNER JOIN dbo.M_Loca ON dbo.T_Stock.Locacode = dbo.M_Loca.Locacode " +
                      " WHERE dbo.M_Loca.Locacode = '"+ commonFunctions.GlobalLocation +"' ";

            }
            else if (paramtype == 1)
            {
                str = "SELECT     dbo.T_Stock.StockCode, dbo.M_Products.Namex AS Description, dbo.T_Stock.Stock AS SIH, dbo.T_Stock.ReservedStock AS [Reserved SIH], dbo.T_Stock.Suppid AS Supplier,dbo.M_Suppliers.suppName AS [Supplier Name], dbo.M_Products.UnitPrice, dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice" +
                       " FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX INNER JOIN dbo.M_Suppliers ON dbo.T_Stock.Suppid = dbo.M_Suppliers.SupID INNER JOIN dbo.M_Loca ON dbo.T_Stock.Locacode = dbo.M_Loca.Locacode " +
                       " WHERE dbo.M_Loca.Locacode = '" + code.Trim() + "' ";
            }
            else if (paramtype == 2)
            {
                str = "SELECT     dbo.T_Stock.StockCode, dbo.M_Products.Namex AS Description, dbo.T_Stock.Stock AS SIH, dbo.T_Stock.ReservedStock AS [Reserved SIH], dbo.T_Stock.Suppid AS Supplier,dbo.M_Suppliers.suppName AS [Supplier Name], dbo.M_Products.UnitPrice, dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice " +
                       " FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX INNER JOIN dbo.M_Suppliers ON dbo.T_Stock.Suppid = dbo.M_Suppliers.SupID INNER JOIN dbo.M_Loca ON dbo.T_Stock.Locacode = dbo.M_Loca.Locacode " +
                       " WHERE dbo.M_Loca.Locacode = '" + commonFunctions.GlobalLocation + "' and  dbo.M_Products.IDX BETWEEN '" + code.Trim() + "' AND '" + code2.Trim() + "'";
            }
            return str;
        }

        public static frm_reportViwer PrintDoc(string reportHeader)
        {
            string reporttitle = reportHeader.ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramFields = commonFunctions.AddCrystalParamsWithLoca(reporttitle, commonFunctions.Loginuser.ToUpper(), commonFunctions.GlobalLocation, findExisting.FindExisitingLoca(commonFunctions.GlobalLocation));

            paramField.Name = "status";
            paramDiscreteValue.Value = "processed".ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            return rpt;
        }

        public static frm_reportViwer PrintDocWithstatus(string reportHeader,string status)
        {
            string reporttitle = reportHeader.ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramFields = commonFunctions.AddCrystalParamsWithLoca(reporttitle, commonFunctions.Loginuser.ToUpper(), commonFunctions.GlobalLocation, findExisting.FindExisitingLoca(commonFunctions.GlobalLocation));

            if (status.Trim() != "")
            {
                paramField.Name = "status";
                paramDiscreteValue.Value = status.ToUpper();
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
            }

            rpt.RepViewer.ParameterFieldInfo = paramFields;
            return rpt;
        }

        public static int RunCusLiability()
        {
            SqlCommand scom;
            int retvalue = 0;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "SP_customerLibSum";
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 10).Value = commonFunctions.GlobalLocation;
                smartOffice_Models.u_DBConnection dbcon = new smartOffice_Models.u_DBConnection();
                dbcon.RunQuery(scom);
                return retvalue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public static int RunSalesSammaryNew(string loca, string comp, DateTime fromdate, DateTime Todate)
        {
            SqlCommand scom;
            int retvalue = 0;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "SP_SalesSummary_new";
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 10).Value = loca.Trim();
                scom.Parameters.Add("@Companycode", SqlDbType.VarChar, 10).Value = comp.Trim();
                scom.Parameters.Add("@FDate", SqlDbType.DateTime, 10).Value = fromdate;
                scom.Parameters.Add("@TDate", SqlDbType.DateTime, 10).Value = Todate;
                smartOffice_Models.u_DBConnection dbcon = new smartOffice_Models.u_DBConnection();
                dbcon.RunQuery(scom);
                return retvalue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int RunBinCard(string loca)
        {
            SqlCommand scom;
            int retvalue = 0;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "Sp_BinCard";
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 10).Value = loca.Trim();
                smartOffice_Models.u_DBConnection dbcon = new smartOffice_Models.u_DBConnection();
                dbcon.RunQuery(scom);
                return retvalue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int RunStockCard(string stockcode, string loca, string comp)
        {
            SqlCommand scom;
            int retvalue = 0;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "SP_StockCard";
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 10).Value = loca.Trim();
                scom.Parameters.Add("@Companycode", SqlDbType.VarChar, 10).Value = comp.Trim();
                scom.Parameters.Add("@StockCode", SqlDbType.VarChar, 10).Value = stockcode.Trim();
                smartOffice_Models.u_DBConnection dbcon = new smartOffice_Models.u_DBConnection();
                dbcon.RunQuery(scom);
                return retvalue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
    }
}
