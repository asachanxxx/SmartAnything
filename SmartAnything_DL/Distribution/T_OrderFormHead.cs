using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_OrderFormHeadDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_OrderFormHead table.
        /// </summary>
        public Boolean Savet_OrderFormHeadSP(T_OrderFormHead t_OrderFormHead, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_OrderFormHeadSave";

                scom.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = t_OrderFormHead.DocNo;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = t_OrderFormHead.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = t_OrderFormHead.Locacode;
                scom.Parameters.Add("@TRNType", SqlDbType.VarChar, 10).Value = t_OrderFormHead.TRNType;
                scom.Parameters.Add("@SalesMan", SqlDbType.VarChar, 20).Value = t_OrderFormHead.SalesMan;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_OrderFormHead.Customer;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_OrderFormHead.Datex;
                scom.Parameters.Add("@RecivedBy", SqlDbType.VarChar, 20).Value = t_OrderFormHead.RecivedBy;
                scom.Parameters.Add("@CheckedBy", SqlDbType.VarChar, 20).Value = t_OrderFormHead.CheckedBy;
                scom.Parameters.Add("@Approved", SqlDbType.Int, 4).Value = t_OrderFormHead.Approved;
                scom.Parameters.Add("@ApprovedBy", SqlDbType.VarChar, 20).Value = t_OrderFormHead.ApprovedBy;
                scom.Parameters.Add("@ApprovedDate", SqlDbType.DateTime, 8).Value = t_OrderFormHead.ApprovedDate;
                scom.Parameters.Add("@RecivedDate", SqlDbType.DateTime, 8).Value = t_OrderFormHead.RecivedDate;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = t_OrderFormHead.Userx;
                scom.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = t_OrderFormHead.CreatedDate;
                scom.Parameters.Add("@CQNO", SqlDbType.VarChar, 20).Value = t_OrderFormHead.CQNO;
                scom.Parameters.Add("@CQDate", SqlDbType.DateTime, 8).Value = t_OrderFormHead.CQDate;
                scom.Parameters.Add("@BANK", SqlDbType.VarChar, 20).Value = t_OrderFormHead.BANK;
                scom.Parameters.Add("@BRANCH", SqlDbType.VarChar, 20).Value = t_OrderFormHead.BRANCH;
                scom.Parameters.Add("@Subtotal", SqlDbType.Decimal, 9).Value = t_OrderFormHead.Subtotal;
                scom.Parameters.Add("@DiscountPer", SqlDbType.Decimal, 9).Value = t_OrderFormHead.DiscountPer;
                scom.Parameters.Add("@SubtotalDisc", SqlDbType.Decimal, 9).Value = t_OrderFormHead.SubtotalDisc;
                scom.Parameters.Add("@ItemdiscTotal", SqlDbType.Decimal, 9).Value = t_OrderFormHead.ItemdiscTotal;
                scom.Parameters.Add("@TotalDisc", SqlDbType.Decimal, 9).Value = t_OrderFormHead.TotalDisc;
                scom.Parameters.Add("@NetTotal", SqlDbType.Decimal, 9).Value = t_OrderFormHead.NetTotal;
                scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = t_OrderFormHead.Remarks;
                scom.Parameters.Add("@Processed", SqlDbType.Int, 4).Value = t_OrderFormHead.Processed;
                scom.Parameters.Add("@ProcessedDate", SqlDbType.DateTime, 8).Value = t_OrderFormHead.ProcessedDate;
                scom.Parameters.Add("@ProcessedUser", SqlDbType.VarChar, 20).Value = t_OrderFormHead.ProcessedUser;
                scom.Parameters.Add("@InvCreated", SqlDbType.Int, 4).Value = t_OrderFormHead.InvCreated;
                scom.Parameters.Add("@InvCreatedDate", SqlDbType.DateTime, 8).Value = t_OrderFormHead.InvCreatedDate;
                scom.Parameters.Add("@INVCreatedUser", SqlDbType.VarChar, 20).Value = t_OrderFormHead.INVCreatedUser;
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


        public DataTable SelectAllt_OrderFormHead()
        {
            try
            {
                strquery = @"select DocNo, NetTotal from T_OrderFormHead";
                DataTable dtt_OrderFormHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_OrderFormHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetInvoiceDetails(string CusID)
        {
            try
            {
                string strx = "SELECT     dbo.T_InvoiceHed.InvID AS [Invoice ID],dbo.T_InvoiceHed.NetAmt AS [Net Amount],dbo.T_InvoiceHed.DueAmt AS [Due Amount],dbo.T_InvoiceHed.PaidAmt AS [Paid Amount] " +
                                 "FROM         dbo.T_InvoiceHed INNER JOIN dbo.M_Customers ON dbo.T_InvoiceHed.Customer = dbo.M_Customers.CusID WHERE CusID = '" + CusID + "'";
                DataTable dtt_OrderFormHead = u_DBConnection.ReturnDataTable(strx, CommandType.Text);
                return dtt_OrderFormHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCreditNoteItems(string CusID)
        {
            try
            {
                
                string str = "SELECT     dbo.T_CreditNoteHead.DocNo AS 'Doc No', dbo.T_CNGrouping.ItemCode AS 'Item', dbo.T_Stock.Descr AS 'Description', dbo.M_CNTypes.TypeName AS 'Type',dbo.M_CNReason.Reason AS 'Reason', dbo.T_CNGrouping.CNQTY AS 'CN Quntity', dbo.T_CNGrouping.BreakdownQTY AS 'BreakDown' , dbo.T_CNGrouping.TagNumber AS 'Tag Number' " +
                           " FROM         dbo.T_CreditNoteHead INNER JOIN dbo.T_CNGrouping ON dbo.T_CreditNoteHead.DocNo = dbo.T_CNGrouping.Docno INNER JOIN dbo.M_CNTypes ON dbo.T_CNGrouping.CNType = dbo.M_CNTypes.TypeID INNER JOIN dbo.M_CNReason ON dbo.T_CNGrouping.CNReason = dbo.M_CNReason.ID INNER JOIN dbo.M_Customers ON dbo.T_CreditNoteHead.CustomerID = dbo.M_Customers.CusID INNER JOIN  dbo.T_Stock ON dbo.T_CNGrouping.ItemCode = dbo.T_Stock.StockCode " +
                           " WHERE dbo.T_CreditNoteHead.CustomerID  = '" + CusID + "'  AND dbo.T_CNGrouping.Shipped = 0";
                DataTable dtt_OrderFormHead = u_DBConnection.ReturnDataTable(str, CommandType.Text);
                return dtt_OrderFormHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SelectAllt_OrderFormHeadApproval()
        {
            try
            {
                DataTable dtt_OrderFormHead = u_DBConnection.ReturnDataTable(@"  select DocNo, NetTotal from T_OrderFormHead where Approved = 0 and Processed = 1", CommandType.Text);
                return dtt_OrderFormHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T_OrderFormHead Selectt_OrderFormHead(T_OrderFormHead objt_OrderFormHead)
        {
            try
            {
                strquery = @"select * from T_OrderFormHead where DocNo = '" + objt_OrderFormHead.DocNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_OrderFormHead.DocNo = drType["DocNo"].ToString();
                    objt_OrderFormHead.Compcode = drType["Compcode"].ToString();
                    objt_OrderFormHead.Locacode = drType["Locacode"].ToString();
                    objt_OrderFormHead.TRNType = drType["TRNType"].ToString();
                    objt_OrderFormHead.SalesMan = drType["SalesMan"].ToString();
                    objt_OrderFormHead.Customer = drType["Customer"].ToString();
                    objt_OrderFormHead.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_OrderFormHead.RecivedBy = drType["RecivedBy"].ToString();
                    objt_OrderFormHead.CheckedBy = drType["CheckedBy"].ToString();
                    objt_OrderFormHead.Approved = int.Parse(drType["Approved"].ToString());
                    objt_OrderFormHead.ApprovedBy = drType["ApprovedBy"].ToString();
                    objt_OrderFormHead.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                    objt_OrderFormHead.RecivedDate = DateTime.Parse(drType["RecivedDate"].ToString());
                    objt_OrderFormHead.Userx = drType["Userx"].ToString();
                    objt_OrderFormHead.CreatedDate = DateTime.Parse(drType["CreatedDate"].ToString());
                    objt_OrderFormHead.CQNO = drType["CQNO"].ToString();
                    objt_OrderFormHead.CQDate = DateTime.Parse(drType["CQDate"].ToString());
                    objt_OrderFormHead.BANK = drType["BANK"].ToString();
                    objt_OrderFormHead.BRANCH = drType["BRANCH"].ToString();
                    objt_OrderFormHead.Subtotal = decimal.Parse(drType["Subtotal"].ToString());
                    objt_OrderFormHead.DiscountPer = decimal.Parse(drType["DiscountPer"].ToString());
                    objt_OrderFormHead.SubtotalDisc = decimal.Parse(drType["SubtotalDisc"].ToString());
                    objt_OrderFormHead.ItemdiscTotal = decimal.Parse(drType["ItemdiscTotal"].ToString());
                    objt_OrderFormHead.TotalDisc = decimal.Parse(drType["TotalDisc"].ToString());
                    objt_OrderFormHead.NetTotal = decimal.Parse(drType["NetTotal"].ToString());
                    objt_OrderFormHead.Remarks = drType["Remarks"].ToString();
                    objt_OrderFormHead.Processed = int.Parse(drType["Processed"].ToString());
                    objt_OrderFormHead.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                    objt_OrderFormHead.ProcessedUser = drType["ProcessedUser"].ToString();
                    objt_OrderFormHead.InvCreated = int.Parse(drType["InvCreated"].ToString());
                    objt_OrderFormHead.InvCreatedDate = DateTime.Parse(drType["InvCreatedDate"].ToString());
                    objt_OrderFormHead.INVCreatedUser = drType["INVCreatedUser"].ToString();
                    return objt_OrderFormHead;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_OrderFormHead(string stringt_OrderFormHead)
        {
            try
            {
                string xstrquery = @"select DocNo From T_OrderFormHead   WHERE DocNo = '" + stringt_OrderFormHead + "' ";
                DataRow drT_OrderFormHead = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_OrderFormHead != null)
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

        public List<T_OrderFormHead> SelectT_OrderFormHeadMulti(T_OrderFormHead objt_OrderFormHead2)
        {
            List<T_OrderFormHead> retval = new List<T_OrderFormHead>();
            try
            {
                strquery = @"select * from t_OrderFormHead where DocNo = '" + objt_OrderFormHead2.DocNo + "'";
                DataTable dtt_OrderFormHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_OrderFormHead.Rows)
                {
                    if (drType != null)
                    {
                        T_OrderFormHead objt_OrderFormHead = new T_OrderFormHead();
                        objt_OrderFormHead.DocNo = drType["DocNo"].ToString();
                        objt_OrderFormHead.Compcode = drType["Compcode"].ToString();
                        objt_OrderFormHead.Locacode = drType["Locacode"].ToString();
                        objt_OrderFormHead.TRNType = drType["TRNType"].ToString();
                        objt_OrderFormHead.SalesMan = drType["SalesMan"].ToString();
                        objt_OrderFormHead.Customer = drType["Customer"].ToString();
                        objt_OrderFormHead.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_OrderFormHead.RecivedBy = drType["RecivedBy"].ToString();
                        objt_OrderFormHead.CheckedBy = drType["CheckedBy"].ToString();
                        objt_OrderFormHead.Approved = int.Parse(drType["Approved"].ToString());
                        objt_OrderFormHead.ApprovedBy = drType["ApprovedBy"].ToString();
                        objt_OrderFormHead.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                        objt_OrderFormHead.RecivedDate = DateTime.Parse(drType["RecivedDate"].ToString());
                        objt_OrderFormHead.Userx = drType["Userx"].ToString();
                        objt_OrderFormHead.CreatedDate = DateTime.Parse(drType["CreatedDate"].ToString());
                        objt_OrderFormHead.CQNO = drType["CQNO"].ToString();
                        objt_OrderFormHead.CQDate = DateTime.Parse(drType["CQDate"].ToString());
                        objt_OrderFormHead.BANK = drType["BANK"].ToString();
                        objt_OrderFormHead.BRANCH = drType["BRANCH"].ToString();
                        objt_OrderFormHead.Subtotal = decimal.Parse(drType["Subtotal"].ToString());
                        objt_OrderFormHead.DiscountPer = decimal.Parse(drType["DiscountPer"].ToString());
                        objt_OrderFormHead.SubtotalDisc = decimal.Parse(drType["SubtotalDisc"].ToString());
                        objt_OrderFormHead.ItemdiscTotal = decimal.Parse(drType["ItemdiscTotal"].ToString());
                        objt_OrderFormHead.TotalDisc = decimal.Parse(drType["TotalDisc"].ToString());
                        objt_OrderFormHead.NetTotal = decimal.Parse(drType["NetTotal"].ToString());
                        objt_OrderFormHead.Remarks = drType["Remarks"].ToString();
                        objt_OrderFormHead.Processed = int.Parse(drType["Processed"].ToString());
                        objt_OrderFormHead.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                        objt_OrderFormHead.ProcessedUser = drType["ProcessedUser"].ToString();
                        objt_OrderFormHead.InvCreated = int.Parse(drType["InvCreated"].ToString());
                        objt_OrderFormHead.InvCreatedDate = DateTime.Parse(drType["InvCreatedDate"].ToString());
                        objt_OrderFormHead.INVCreatedUser = drType["INVCreatedUser"].ToString();
                        retval.Add(objt_OrderFormHead);
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
