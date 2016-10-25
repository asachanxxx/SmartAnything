using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_InvoiceHedDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_InvoiceHed table.
        /// </summary>
        public Boolean Savet_InvoiceHedSP(T_InvoiceHed t_InvoiceHed, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_InvoiceHedSave";

                scom.Parameters.Add("@InvID", SqlDbType.VarChar, 20).Value = t_InvoiceHed.InvID;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_InvoiceHed.CompCode;
                scom.Parameters.Add("@LocaCode", SqlDbType.VarChar, 20).Value = t_InvoiceHed.LocaCode;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_InvoiceHed.Customer;
                scom.Parameters.Add("@Paymeth", SqlDbType.VarChar, 10).Value = t_InvoiceHed.Paymeth;
                scom.Parameters.Add("@RefNo", SqlDbType.VarChar, 20).Value = t_InvoiceHed.RefNo;
                scom.Parameters.Add("@ManualNo", SqlDbType.VarChar, 20).Value = t_InvoiceHed.ManualNo;
                scom.Parameters.Add("@OrderFormNo", SqlDbType.VarChar, 20).Value = t_InvoiceHed.OrderFormNo;
                scom.Parameters.Add("@DONumber", SqlDbType.VarChar, 20).Value = t_InvoiceHed.DONumber;
                scom.Parameters.Add("@GrossAmt", SqlDbType.Decimal, 9).Value = t_InvoiceHed.GrossAmt;
                scom.Parameters.Add("@SubtotaldiscPer", SqlDbType.Decimal, 9).Value = t_InvoiceHed.SubtotaldiscPer;
                scom.Parameters.Add("@SubtotalDisc", SqlDbType.Decimal, 9).Value = t_InvoiceHed.SubtotalDisc;
                scom.Parameters.Add("@ItemdiscTotal", SqlDbType.Decimal, 9).Value = t_InvoiceHed.ItemdiscTotal;
                scom.Parameters.Add("@TotalDisc", SqlDbType.Decimal, 9).Value = t_InvoiceHed.TotalDisc;
                scom.Parameters.Add("@Tax", SqlDbType.Decimal, 9).Value = t_InvoiceHed.Tax;
                scom.Parameters.Add("@Vatamt", SqlDbType.Decimal, 9).Value = t_InvoiceHed.Vatamt;
                scom.Parameters.Add("@NetAmt", SqlDbType.Decimal, 9).Value = t_InvoiceHed.NetAmt;
                scom.Parameters.Add("@CreditPeriod", SqlDbType.Decimal, 9).Value = t_InvoiceHed.CreditPeriod;
                scom.Parameters.Add("@Noofitems", SqlDbType.Decimal, 9).Value = t_InvoiceHed.Noofitems;
                scom.Parameters.Add("@NoOfPieces", SqlDbType.Decimal, 9).Value = t_InvoiceHed.NoOfPieces;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_InvoiceHed.Datex;
                scom.Parameters.Add("@PrerairedBy", SqlDbType.VarChar, 20).Value = t_InvoiceHed.PrerairedBy;
                scom.Parameters.Add("@Checked", SqlDbType.Int, 4).Value = t_InvoiceHed.Checked;
                scom.Parameters.Add("@CheckedBy", SqlDbType.VarChar, 20).Value = t_InvoiceHed.CheckedBy;
                scom.Parameters.Add("@Approved", SqlDbType.Int, 4).Value = t_InvoiceHed.Approved;
                scom.Parameters.Add("@AprrovedBy", SqlDbType.VarChar, 20).Value = t_InvoiceHed.AprrovedBy;
                scom.Parameters.Add("@ApprovedDate", SqlDbType.DateTime, 8).Value = t_InvoiceHed.ApprovedDate;
                scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 150).Value = t_InvoiceHed.Remarks;
                scom.Parameters.Add("@CQNO", SqlDbType.VarChar, 20).Value = t_InvoiceHed.CQNO;
                scom.Parameters.Add("@CQDate", SqlDbType.DateTime, 8).Value = t_InvoiceHed.CQDate;
                scom.Parameters.Add("@BANK", SqlDbType.VarChar, 20).Value = t_InvoiceHed.BANK;
                scom.Parameters.Add("@BRANCH", SqlDbType.VarChar, 20).Value = t_InvoiceHed.BRANCH;
                scom.Parameters.Add("@Processed", SqlDbType.Int, 4).Value = t_InvoiceHed.Processed;
                scom.Parameters.Add("@ProcessedDate", SqlDbType.DateTime, 8).Value = t_InvoiceHed.ProcessedDate;
                scom.Parameters.Add("@ProcessedUser", SqlDbType.VarChar, 20).Value = t_InvoiceHed.ProcessedUser;
                scom.Parameters.Add("@Glupdated", SqlDbType.Bit, 1).Value = t_InvoiceHed.Glupdated;
                scom.Parameters.Add("@MultipleDO", SqlDbType.Int, 4).Value = t_InvoiceHed.MultipleDO;
                scom.Parameters.Add("@DueAmt", SqlDbType.Decimal, 9).Value = t_InvoiceHed.DueAmt;
                scom.Parameters.Add("@PaidAmt", SqlDbType.Decimal, 9).Value = t_InvoiceHed.PaidAmt;
                scom.Parameters.Add("@IsSettled", SqlDbType.Bit, 1).Value = t_InvoiceHed.IsSettled;
                scom.Parameters.Add("@Iscancelled", SqlDbType.Bit, 1).Value = t_InvoiceHed.Iscancelled;
                scom.Parameters.Add("@CancelledDate", SqlDbType.DateTime, 8).Value = t_InvoiceHed.CancelledDate;
                scom.Parameters.Add("@CancelledUSer", SqlDbType.VarChar, 20).Value = t_InvoiceHed.CancelledUSer;
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


        public DataTable SelectAllt_InvoiceHed()
        {
            try
            {
                strquery = @"select InvID,NetAmt from T_InvoiceHed";
                DataTable dtt_InvoiceHed = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_InvoiceHed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable SelectAllt_InvoiceHedApproval()
        {
            try
            {
                DataTable dtt_OrderFormHead = u_DBConnection.ReturnDataTable(@"select InvID as 'Invoice No',NetAmt as 'Net Amount' from T_InvoiceHed where Processed = 1 and Approved =0", CommandType.Text);
                return dtt_OrderFormHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_InvoiceHed Selectt_InvoiceHed(T_InvoiceHed objt_InvoiceHed)
        {
            try
            {
                strquery = @"select * from t_InvoiceHed where InvID = '" + objt_InvoiceHed.InvID + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_InvoiceHed.InvID = drType["InvID"].ToString();
                    objt_InvoiceHed.CompCode = drType["CompCode"].ToString();
                    objt_InvoiceHed.LocaCode = drType["LocaCode"].ToString();
                    objt_InvoiceHed.Customer = drType["Customer"].ToString();
                    objt_InvoiceHed.Paymeth = drType["Paymeth"].ToString();
                    objt_InvoiceHed.RefNo = drType["RefNo"].ToString();
                    objt_InvoiceHed.ManualNo = drType["ManualNo"].ToString();
                    objt_InvoiceHed.OrderFormNo = drType["OrderFormNo"].ToString();
                    objt_InvoiceHed.DONumber = drType["DONumber"].ToString();
                    objt_InvoiceHed.GrossAmt = decimal.Parse(drType["GrossAmt"].ToString());
                    objt_InvoiceHed.SubtotaldiscPer = decimal.Parse(drType["SubtotaldiscPer"].ToString());
                    objt_InvoiceHed.SubtotalDisc = decimal.Parse(drType["SubtotalDisc"].ToString());
                    objt_InvoiceHed.ItemdiscTotal = decimal.Parse(drType["ItemdiscTotal"].ToString());
                    objt_InvoiceHed.TotalDisc = decimal.Parse(drType["TotalDisc"].ToString());
                    objt_InvoiceHed.Tax = decimal.Parse(drType["Tax"].ToString());
                    objt_InvoiceHed.Vatamt = decimal.Parse(drType["Vatamt"].ToString());
                    objt_InvoiceHed.NetAmt = decimal.Parse(drType["NetAmt"].ToString());
                    objt_InvoiceHed.CreditPeriod = decimal.Parse(drType["CreditPeriod"].ToString());
                    objt_InvoiceHed.Noofitems = decimal.Parse(drType["Noofitems"].ToString());
                    objt_InvoiceHed.NoOfPieces = decimal.Parse(drType["NoOfPieces"].ToString());
                    objt_InvoiceHed.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_InvoiceHed.PrerairedBy = drType["PrerairedBy"].ToString();
                    objt_InvoiceHed.Checked = int.Parse(drType["Checked"].ToString());
                    objt_InvoiceHed.CheckedBy = drType["CheckedBy"].ToString();
                    objt_InvoiceHed.Approved = int.Parse(drType["Approved"].ToString());
                    objt_InvoiceHed.AprrovedBy = drType["AprrovedBy"].ToString();
                    objt_InvoiceHed.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                    objt_InvoiceHed.Remarks = drType["Remarks"].ToString();
                    objt_InvoiceHed.CQNO = drType["CQNO"].ToString();
                    objt_InvoiceHed.CQDate = DateTime.Parse(drType["CQDate"].ToString());
                    objt_InvoiceHed.BANK = drType["BANK"].ToString();
                    objt_InvoiceHed.BRANCH = drType["BRANCH"].ToString();
                    objt_InvoiceHed.Processed = int.Parse(drType["Processed"].ToString());
                    objt_InvoiceHed.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                    objt_InvoiceHed.ProcessedUser = drType["ProcessedUser"].ToString();
                    objt_InvoiceHed.Glupdated = bool.Parse(drType["Glupdated"].ToString());
                    objt_InvoiceHed.MultipleDO = int.Parse(drType["MultipleDO"].ToString());
                    objt_InvoiceHed.DueAmt = decimal.Parse(drType["DueAmt"].ToString());
                    objt_InvoiceHed.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                    objt_InvoiceHed.IsSettled = bool.Parse(drType["IsSettled"].ToString());
                    objt_InvoiceHed.Iscancelled = bool.Parse(drType["Iscancelled"].ToString());
                    objt_InvoiceHed.CancelledDate = DateTime.Parse(drType["CancelledDate"].ToString());
                    objt_InvoiceHed.CancelledUSer = drType["CancelledUSer"].ToString();
                    return objt_InvoiceHed;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_InvoiceHed(string stringt_InvoiceHed)
        {
            try
            {
                string xstrquery = @"select InvID From T_InvoiceHed   WHERE InvID = '" + stringt_InvoiceHed + "' ";
                DataRow drT_InvoiceHed = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_InvoiceHed != null)
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

        public List<T_InvoiceHed> SelectT_InvoiceHedMulti(string customercode)
        {
            List<T_InvoiceHed> retval = new List<T_InvoiceHed>();
            try
            {
                strquery = @"SELECT * FROM T_InvoiceHed WHERE Processed = 1 AND Approved = 1 AND Customer = '"+ customercode +"'";
                DataTable dtt_InvoiceHed = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_InvoiceHed.Rows)
                {
                    if (drType != null)
                    {
                        T_InvoiceHed objt_InvoiceHed = new T_InvoiceHed();
                        objt_InvoiceHed.InvID = drType["InvID"].ToString();
                        objt_InvoiceHed.CompCode = drType["CompCode"].ToString();
                        objt_InvoiceHed.LocaCode = drType["LocaCode"].ToString();
                        objt_InvoiceHed.Customer = drType["Customer"].ToString();
                        objt_InvoiceHed.Paymeth = drType["Paymeth"].ToString();
                        objt_InvoiceHed.RefNo = drType["RefNo"].ToString();
                        objt_InvoiceHed.ManualNo = drType["ManualNo"].ToString();
                        objt_InvoiceHed.OrderFormNo = drType["OrderFormNo"].ToString();
                        objt_InvoiceHed.DONumber = drType["DONumber"].ToString();
                        objt_InvoiceHed.GrossAmt = decimal.Parse(drType["GrossAmt"].ToString());
                        objt_InvoiceHed.SubtotaldiscPer = decimal.Parse(drType["SubtotaldiscPer"].ToString());
                        objt_InvoiceHed.SubtotalDisc = decimal.Parse(drType["SubtotalDisc"].ToString());
                        objt_InvoiceHed.ItemdiscTotal = decimal.Parse(drType["ItemdiscTotal"].ToString());
                        objt_InvoiceHed.TotalDisc = decimal.Parse(drType["TotalDisc"].ToString());
                        objt_InvoiceHed.Tax = decimal.Parse(drType["Tax"].ToString());
                        objt_InvoiceHed.Vatamt = decimal.Parse(drType["Vatamt"].ToString());
                        objt_InvoiceHed.NetAmt = decimal.Parse(drType["NetAmt"].ToString());
                        objt_InvoiceHed.CreditPeriod = decimal.Parse(drType["CreditPeriod"].ToString());
                        objt_InvoiceHed.Noofitems = decimal.Parse(drType["Noofitems"].ToString());
                        objt_InvoiceHed.NoOfPieces = decimal.Parse(drType["NoOfPieces"].ToString());
                        objt_InvoiceHed.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_InvoiceHed.PrerairedBy = drType["PrerairedBy"].ToString();
                        objt_InvoiceHed.Checked = int.Parse(drType["Checked"].ToString());
                        objt_InvoiceHed.CheckedBy = drType["CheckedBy"].ToString();
                        objt_InvoiceHed.Approved = int.Parse(drType["Approved"].ToString());
                        objt_InvoiceHed.AprrovedBy = drType["AprrovedBy"].ToString();
                        objt_InvoiceHed.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                        objt_InvoiceHed.Remarks = drType["Remarks"].ToString();
                        objt_InvoiceHed.CQNO = drType["CQNO"].ToString();
                        objt_InvoiceHed.CQDate = DateTime.Parse(drType["CQDate"].ToString());
                        objt_InvoiceHed.BANK = drType["BANK"].ToString();
                        objt_InvoiceHed.BRANCH = drType["BRANCH"].ToString();
                        objt_InvoiceHed.Processed = int.Parse(drType["Processed"].ToString());
                        objt_InvoiceHed.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                        objt_InvoiceHed.ProcessedUser = drType["ProcessedUser"].ToString();
                        objt_InvoiceHed.Glupdated = bool.Parse(drType["Glupdated"].ToString());
                        objt_InvoiceHed.MultipleDO = int.Parse(drType["MultipleDO"].ToString());
                        objt_InvoiceHed.DueAmt = decimal.Parse(drType["DueAmt"].ToString());
                        objt_InvoiceHed.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                        objt_InvoiceHed.IsSettled = bool.Parse(drType["IsSettled"].ToString());
                        objt_InvoiceHed.Iscancelled = bool.Parse(drType["Iscancelled"].ToString());
                        objt_InvoiceHed.CancelledDate = DateTime.Parse(drType["CancelledDate"].ToString());
                        objt_InvoiceHed.CancelledUSer = drType["CancelledUSer"].ToString();
                        retval.Add(objt_InvoiceHed);
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
