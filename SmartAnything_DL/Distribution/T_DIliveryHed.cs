using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_DIliveryHedDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_DIliveryHed table.
        /// </summary>
        public Boolean Savet_DIliveryHedSP(T_DIliveryHed t_DIliveryHed, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_DIliveryHedSave";

                scom.Parameters.Add("@DoNo", SqlDbType.VarChar, 20).Value = t_DIliveryHed.DoNo;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_DIliveryHed.CompCode;
                scom.Parameters.Add("@LocaCode", SqlDbType.VarChar, 20).Value = t_DIliveryHed.LocaCode;
                scom.Parameters.Add("@InvNo", SqlDbType.VarChar, 20).Value = t_DIliveryHed.InvNo;
                scom.Parameters.Add("@InvoiceAmount", SqlDbType.Decimal, 9).Value = t_DIliveryHed.InvoiceAmount;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_DIliveryHed.Customer;
                scom.Parameters.Add("@CustomerDIscRate", SqlDbType.Decimal, 9).Value = t_DIliveryHed.CustomerDIscRate;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_DIliveryHed.Datex;
                scom.Parameters.Add("@Agent", SqlDbType.VarChar, 20).Value = t_DIliveryHed.Agent;
                scom.Parameters.Add("@Lorry", SqlDbType.VarChar, 20).Value = t_DIliveryHed.Lorry;
                scom.Parameters.Add("@NoOfCartons", SqlDbType.Decimal, 9).Value = t_DIliveryHed.NoOfCartons;
                scom.Parameters.Add("@Dispatched", SqlDbType.Int, 4).Value = t_DIliveryHed.Dispatched;
                scom.Parameters.Add("@DispatchedDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.DispatchedDate;
                scom.Parameters.Add("@DispatchedUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.DispatchedUser;
                scom.Parameters.Add("@Checked", SqlDbType.Int, 4).Value = t_DIliveryHed.Checked;
                scom.Parameters.Add("@CheckedUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.CheckedUser;
                scom.Parameters.Add("@Checkeddate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.Checkeddate;
                scom.Parameters.Add("@Approved", SqlDbType.Int, 4).Value = t_DIliveryHed.Approved;
                scom.Parameters.Add("@ApprovedUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.ApprovedUser;
                scom.Parameters.Add("@ApprovedDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.ApprovedDate;
                scom.Parameters.Add("@Handovered", SqlDbType.Int, 4).Value = t_DIliveryHed.Handovered;
                scom.Parameters.Add("@HandoverdUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.HandoverdUser;
                scom.Parameters.Add("@HandoverDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.HandoverDate;
                scom.Parameters.Add("@HandoverCartons", SqlDbType.Decimal, 9).Value = t_DIliveryHed.HandoverCartons;
                scom.Parameters.Add("@Delivered", SqlDbType.Int, 4).Value = t_DIliveryHed.Delivered;
                scom.Parameters.Add("@DiliveredUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.DiliveredUser;
                scom.Parameters.Add("@DiliveryDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.DiliveryDate;
                scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 150).Value = t_DIliveryHed.Remarks;
                scom.Parameters.Add("@NoOfPrints", SqlDbType.Decimal, 9).Value = t_DIliveryHed.NoOfPrints;
                scom.Parameters.Add("@PrintUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.PrintUser;
                scom.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = t_DIliveryHed.Status;
                scom.Parameters.Add("@Processed", SqlDbType.Int, 4).Value = t_DIliveryHed.Processed;
                scom.Parameters.Add("@ProcessedDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.ProcessedDate;
                scom.Parameters.Add("@ProcessedUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.ProcessedUser;
                scom.Parameters.Add("@Audited", SqlDbType.Int, 4).Value = t_DIliveryHed.Audited;
                scom.Parameters.Add("@AuditDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.AuditDate;
                scom.Parameters.Add("@AuditUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.AuditUser;
                scom.Parameters.Add("@Completed", SqlDbType.Int, 4).Value = t_DIliveryHed.Completed;
                scom.Parameters.Add("@CompletedDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.CompletedDate;
                scom.Parameters.Add("@PackingListCreated", SqlDbType.Int, 4).Value = t_DIliveryHed.PackingListCreated;
                scom.Parameters.Add("@PackingListNo", SqlDbType.VarChar, 20).Value = t_DIliveryHed.PackingListNo;
                scom.Parameters.Add("@PackingListDate", SqlDbType.DateTime, 8).Value = t_DIliveryHed.PackingListDate;
                scom.Parameters.Add("@PackingListUser", SqlDbType.VarChar, 20).Value = t_DIliveryHed.PackingListUser;
                scom.Parameters.Add("@ReportedProblems", SqlDbType.VarChar, 250).Value = t_DIliveryHed.ReportedProblems;
                scom.Parameters.Add("@AuditRemarks", SqlDbType.VarChar, 250).Value = t_DIliveryHed.AuditRemarks;
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


        public DataTable SelectAllt_DIliveryHed()
        {
            try
            {
                strquery = @"select DoNo , InvoiceAmount from T_DIliveryHed";
                DataTable dtt_DIliveryHed = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_DIliveryHed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public T_DIliveryHed Selectt_DIliveryHed(T_DIliveryHed objt_DIliveryHed , int isdispatched)
        {
            try
            {
                strquery = @"select * from t_DIliveryHed where DoNo = '" + objt_DIliveryHed.DoNo + "' and LocaCode = '" + objt_DIliveryHed.LocaCode.Trim() + "'";

                //if (isdispatched == 1)
                //{
                //    strquery = @"select * from t_DIliveryHed where DoNo = '" + objt_DIliveryHed.DoNo + "'";
                //}
                //else {
                //    strquery = @"select * from t_DIliveryHed where DoNo = '" + objt_DIliveryHed.DoNo + "' and Dispatched = 0";
                //}
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_DIliveryHed.DoNo = drType["DoNo"].ToString();
                    objt_DIliveryHed.CompCode = drType["CompCode"].ToString();
                    objt_DIliveryHed.LocaCode = drType["LocaCode"].ToString();
                    objt_DIliveryHed.InvNo = drType["InvNo"].ToString();
                    objt_DIliveryHed.InvoiceAmount = decimal.Parse(drType["InvoiceAmount"].ToString());
                    objt_DIliveryHed.Customer = drType["Customer"].ToString();
                    objt_DIliveryHed.CustomerDIscRate = decimal.Parse(drType["CustomerDIscRate"].ToString());
                    objt_DIliveryHed.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_DIliveryHed.Agent = drType["Agent"].ToString();
                    objt_DIliveryHed.Lorry = drType["Lorry"].ToString();
                    objt_DIliveryHed.NoOfCartons = decimal.Parse(drType["NoOfCartons"].ToString());
                    objt_DIliveryHed.Dispatched = int.Parse(drType["Dispatched"].ToString());
                    objt_DIliveryHed.DispatchedDate = DateTime.Parse(drType["DispatchedDate"].ToString());
                    objt_DIliveryHed.DispatchedUser = drType["DispatchedUser"].ToString();
                    objt_DIliveryHed.Checked = int.Parse(drType["Checked"].ToString());
                    objt_DIliveryHed.CheckedUser = drType["CheckedUser"].ToString();
                    objt_DIliveryHed.Checkeddate = DateTime.Parse(drType["Checkeddate"].ToString());
                    objt_DIliveryHed.Approved = int.Parse(drType["Approved"].ToString());
                    objt_DIliveryHed.ApprovedUser = drType["ApprovedUser"].ToString();
                    objt_DIliveryHed.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                    objt_DIliveryHed.Handovered = int.Parse(drType["Handovered"].ToString());
                    objt_DIliveryHed.HandoverdUser = drType["HandoverdUser"].ToString();
                    objt_DIliveryHed.HandoverDate = DateTime.Parse(drType["HandoverDate"].ToString());
                    objt_DIliveryHed.HandoverCartons = decimal.Parse(drType["HandoverCartons"].ToString());
                    objt_DIliveryHed.Delivered = int.Parse(drType["Delivered"].ToString());
                    objt_DIliveryHed.DiliveredUser = drType["DiliveredUser"].ToString();
                    objt_DIliveryHed.DiliveryDate = DateTime.Parse(drType["DiliveryDate"].ToString());
                    objt_DIliveryHed.Remarks = drType["Remarks"].ToString();
                    objt_DIliveryHed.NoOfPrints = decimal.Parse(drType["NoOfPrints"].ToString());
                    objt_DIliveryHed.PrintUser = drType["PrintUser"].ToString();
                    objt_DIliveryHed.Status = drType["Status"].ToString();
                    objt_DIliveryHed.Processed = int.Parse(drType["Processed"].ToString());
                    objt_DIliveryHed.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                    objt_DIliveryHed.ProcessedUser = drType["ProcessedUser"].ToString();
                    objt_DIliveryHed.Audited = int.Parse(drType["Audited"].ToString());
                    objt_DIliveryHed.AuditDate = DateTime.Parse(drType["AuditDate"].ToString());
                    objt_DIliveryHed.AuditUser = drType["AuditUser"].ToString();
                    objt_DIliveryHed.Completed = int.Parse(drType["Completed"].ToString());
                    objt_DIliveryHed.CompletedDate = DateTime.Parse(drType["CompletedDate"].ToString());
                    objt_DIliveryHed.PackingListCreated = int.Parse(drType["PackingListCreated"].ToString());
                    objt_DIliveryHed.PackingListNo = drType["PackingListNo"].ToString();
                    objt_DIliveryHed.PackingListDate = DateTime.Parse(drType["PackingListDate"].ToString());
                    objt_DIliveryHed.PackingListUser = drType["PackingListUser"].ToString();
                    objt_DIliveryHed.ReportedProblems = drType["ReportedProblems"].ToString();
                    objt_DIliveryHed.AuditRemarks = drType["AuditRemarks"].ToString();
                    return objt_DIliveryHed;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_DIliveryHed(string stringt_DIliveryHed)
        {
            try
            {
                string xstrquery = @"select DoNo From T_DIliveryHed   WHERE DoNo = '" + stringt_DIliveryHed + "' ";
                DataRow drT_DIliveryHed = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_DIliveryHed != null)
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

        public List<T_DIliveryHed> SelectT_DIliveryHedMulti(T_DIliveryHed objt_DIliveryHed2)
        {
            List<T_DIliveryHed> retval = new List<T_DIliveryHed>();
            try
            {
                strquery = @"select * from t_DIliveryHed where DoNo = '" + objt_DIliveryHed2.DoNo + "'";
                DataTable dtt_DIliveryHed = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_DIliveryHed.Rows)
                {
                    if (drType != null)
                    {
                        T_DIliveryHed objt_DIliveryHed = new T_DIliveryHed();
                        objt_DIliveryHed.DoNo = drType["DoNo"].ToString();
                        objt_DIliveryHed.CompCode = drType["CompCode"].ToString();
                        objt_DIliveryHed.LocaCode = drType["LocaCode"].ToString();
                        objt_DIliveryHed.InvNo = drType["InvNo"].ToString();
                        objt_DIliveryHed.InvoiceAmount = decimal.Parse(drType["InvoiceAmount"].ToString());
                        objt_DIliveryHed.Customer = drType["Customer"].ToString();
                        objt_DIliveryHed.CustomerDIscRate = decimal.Parse(drType["CustomerDIscRate"].ToString());
                        objt_DIliveryHed.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_DIliveryHed.Agent = drType["Agent"].ToString();
                        objt_DIliveryHed.Lorry = drType["Lorry"].ToString();
                        objt_DIliveryHed.NoOfCartons = decimal.Parse(drType["NoOfCartons"].ToString());
                        objt_DIliveryHed.Dispatched = int.Parse(drType["Dispatched"].ToString());
                        objt_DIliveryHed.DispatchedDate = DateTime.Parse(drType["DispatchedDate"].ToString());
                        objt_DIliveryHed.DispatchedUser = drType["DispatchedUser"].ToString();
                        objt_DIliveryHed.Checked = int.Parse(drType["Checked"].ToString());
                        objt_DIliveryHed.CheckedUser = drType["CheckedUser"].ToString();
                        objt_DIliveryHed.Checkeddate = DateTime.Parse(drType["Checkeddate"].ToString());
                        objt_DIliveryHed.Approved = int.Parse(drType["Approved"].ToString());
                        objt_DIliveryHed.ApprovedUser = drType["ApprovedUser"].ToString();
                        objt_DIliveryHed.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                        objt_DIliveryHed.Handovered = int.Parse(drType["Handovered"].ToString());
                        objt_DIliveryHed.HandoverdUser = drType["HandoverdUser"].ToString();
                        objt_DIliveryHed.HandoverDate = DateTime.Parse(drType["HandoverDate"].ToString());
                        objt_DIliveryHed.HandoverCartons = decimal.Parse(drType["HandoverCartons"].ToString());
                        objt_DIliveryHed.Delivered = int.Parse(drType["Delivered"].ToString());
                        objt_DIliveryHed.DiliveredUser = drType["DiliveredUser"].ToString();
                        objt_DIliveryHed.DiliveryDate = DateTime.Parse(drType["DiliveryDate"].ToString());
                        objt_DIliveryHed.Remarks = drType["Remarks"].ToString();
                        objt_DIliveryHed.NoOfPrints = decimal.Parse(drType["NoOfPrints"].ToString());
                        objt_DIliveryHed.PrintUser = drType["PrintUser"].ToString();
                        objt_DIliveryHed.Status = drType["Status"].ToString();
                        objt_DIliveryHed.Processed = int.Parse(drType["Processed"].ToString());
                        objt_DIliveryHed.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                        objt_DIliveryHed.ProcessedUser = drType["ProcessedUser"].ToString();
                        objt_DIliveryHed.Audited = int.Parse(drType["Audited"].ToString());
                        objt_DIliveryHed.AuditDate = DateTime.Parse(drType["AuditDate"].ToString());
                        objt_DIliveryHed.AuditUser = drType["AuditUser"].ToString();
                        objt_DIliveryHed.Completed = int.Parse(drType["Completed"].ToString());
                        objt_DIliveryHed.CompletedDate = DateTime.Parse(drType["CompletedDate"].ToString());
                        objt_DIliveryHed.PackingListCreated = int.Parse(drType["PackingListCreated"].ToString());
                        objt_DIliveryHed.PackingListNo = drType["PackingListNo"].ToString();
                        objt_DIliveryHed.PackingListDate = DateTime.Parse(drType["PackingListDate"].ToString());
                        objt_DIliveryHed.PackingListUser = drType["PackingListUser"].ToString();
                        objt_DIliveryHed.ReportedProblems = drType["ReportedProblems"].ToString();
                        objt_DIliveryHed.AuditRemarks = drType["AuditRemarks"].ToString();
                        retval.Add(objt_DIliveryHed);
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
