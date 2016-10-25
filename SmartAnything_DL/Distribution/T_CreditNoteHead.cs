using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_CreditNoteHeadDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_CreditNoteHead table.
        /// </summary>
        public Boolean Savet_CreditNoteHeadSP(T_CreditNoteHead t_CreditNoteHead, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_CreditNoteHeadSave";

                scom.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.DocNo;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.CompCode;
                scom.Parameters.Add("@LocaCode", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.LocaCode;
                scom.Parameters.Add("@OFNo", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.OFNo;
                scom.Parameters.Add("@InvNo", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.InvNo;
                scom.Parameters.Add("@Dono", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.Dono;
                scom.Parameters.Add("@CustomerID", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.CustomerID;
                scom.Parameters.Add("@TypeX", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.TypeX;
                scom.Parameters.Add("@AuditUser", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.AuditUser;
                scom.Parameters.Add("@Statusx", SqlDbType.VarChar, 10).Value = t_CreditNoteHead.Statusx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_CreditNoteHead.Datex;
                scom.Parameters.Add("@ManualID", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.ManualID;
                scom.Parameters.Add("@DeliveredDate", SqlDbType.DateTime, 8).Value = t_CreditNoteHead.DeliveredDate;
                scom.Parameters.Add("@PackingList", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.PackingList;
                scom.Parameters.Add("@DeliveryStatus", SqlDbType.VarChar, 10).Value = t_CreditNoteHead.DeliveryStatus;
                scom.Parameters.Add("@AgentStatus", SqlDbType.VarChar, 10).Value = t_CreditNoteHead.AgentStatus;
                scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 150).Value = t_CreditNoteHead.Remarks;
                scom.Parameters.Add("@Processed", SqlDbType.Bit, 1).Value = t_CreditNoteHead.Processed;
                scom.Parameters.Add("@ProcessedDate", SqlDbType.DateTime, 8).Value = t_CreditNoteHead.ProcessedDate;
                scom.Parameters.Add("@ProcessedUser", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.ProcessedUser;
                scom.Parameters.Add("@Grouped", SqlDbType.Bit, 1).Value = t_CreditNoteHead.Grouped;
                scom.Parameters.Add("@GroupedDate", SqlDbType.DateTime, 8).Value = t_CreditNoteHead.GroupedDate;
                scom.Parameters.Add("@GroupedUser", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.GroupedUser;
                scom.Parameters.Add("@Approved", SqlDbType.Bit, 1).Value = t_CreditNoteHead.Approved;
                scom.Parameters.Add("@ApprovedDate", SqlDbType.DateTime, 8).Value = t_CreditNoteHead.ApprovedDate;
                scom.Parameters.Add("@ApprovedUser", SqlDbType.VarChar, 20).Value = t_CreditNoteHead.ApprovedUser;
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


        public DataTable SelectAllt_CreditNoteHead()
        {
            try
            {
                strquery = @"SELECT     dbo.T_CreditNoteHead.DocNo, dbo.M_Customers.CustName FROM  dbo.T_CreditNoteHead INNER JOIN  dbo.M_Customers ON dbo.T_CreditNoteHead.CustomerID = dbo.M_Customers.CusID";
                DataTable dtt_CreditNoteHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_CreditNoteHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_CreditNoteHead Selectt_CreditNoteHead(T_CreditNoteHead objt_CreditNoteHead)
        {
            try
            {
                strquery = @"select * from t_CreditNoteHead where DocNo = '" + objt_CreditNoteHead.DocNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_CreditNoteHead.DocNo = drType["DocNo"].ToString();
                    objt_CreditNoteHead.CompCode = drType["CompCode"].ToString();
                    objt_CreditNoteHead.LocaCode = drType["LocaCode"].ToString();
                    objt_CreditNoteHead.OFNo = drType["OFNo"].ToString();
                    objt_CreditNoteHead.InvNo = drType["InvNo"].ToString();
                    objt_CreditNoteHead.Dono = drType["Dono"].ToString();
                    objt_CreditNoteHead.CustomerID = drType["CustomerID"].ToString();
                    objt_CreditNoteHead.TypeX = drType["TypeX"].ToString();
                    objt_CreditNoteHead.AuditUser = drType["AuditUser"].ToString();
                    objt_CreditNoteHead.Statusx = drType["Statusx"].ToString();
                    objt_CreditNoteHead.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_CreditNoteHead.ManualID = drType["ManualID"].ToString();
                    objt_CreditNoteHead.DeliveredDate = DateTime.Parse(drType["DeliveredDate"].ToString());
                    objt_CreditNoteHead.PackingList = drType["PackingList"].ToString();
                    objt_CreditNoteHead.DeliveryStatus = drType["DeliveryStatus"].ToString();
                    objt_CreditNoteHead.AgentStatus = drType["AgentStatus"].ToString();
                    objt_CreditNoteHead.Remarks = drType["Remarks"].ToString();
                    objt_CreditNoteHead.Processed = bool.Parse(drType["Processed"].ToString());
                    objt_CreditNoteHead.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                    objt_CreditNoteHead.ProcessedUser = drType["ProcessedUser"].ToString();
                    objt_CreditNoteHead.Grouped = bool.Parse(drType["Grouped"].ToString());
                    objt_CreditNoteHead.GroupedDate = DateTime.Parse(drType["GroupedDate"].ToString());
                    objt_CreditNoteHead.GroupedUser = drType["GroupedUser"].ToString();
                    objt_CreditNoteHead.Approved = bool.Parse(drType["Approved"].ToString());
                    objt_CreditNoteHead.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                    objt_CreditNoteHead.ApprovedUser = drType["ApprovedUser"].ToString();
                    return objt_CreditNoteHead;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T_CreditNoteHead Selectt_CreditNoteHeadApproval(string codex)
        {
            try
            {
                T_CreditNoteHead objt_CreditNoteHead = new T_CreditNoteHead();
                strquery = @"select * from t_CreditNoteHead where DocNo = '" + codex.Trim() + "' and Processed =1";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_CreditNoteHead.DocNo = drType["DocNo"].ToString();
                    objt_CreditNoteHead.CompCode = drType["CompCode"].ToString();
                    objt_CreditNoteHead.LocaCode = drType["LocaCode"].ToString();
                    objt_CreditNoteHead.OFNo = drType["OFNo"].ToString();
                    objt_CreditNoteHead.InvNo = drType["InvNo"].ToString();
                    objt_CreditNoteHead.Dono = drType["Dono"].ToString();
                    objt_CreditNoteHead.CustomerID = drType["CustomerID"].ToString();
                    objt_CreditNoteHead.TypeX = drType["TypeX"].ToString();
                    objt_CreditNoteHead.AuditUser = drType["AuditUser"].ToString();
                    objt_CreditNoteHead.Statusx = drType["Statusx"].ToString();
                    objt_CreditNoteHead.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_CreditNoteHead.ManualID = drType["ManualID"].ToString();
                    objt_CreditNoteHead.DeliveredDate = DateTime.Parse(drType["DeliveredDate"].ToString());
                    objt_CreditNoteHead.PackingList = drType["PackingList"].ToString();
                    objt_CreditNoteHead.DeliveryStatus = drType["DeliveryStatus"].ToString();
                    objt_CreditNoteHead.AgentStatus = drType["AgentStatus"].ToString();
                    objt_CreditNoteHead.Remarks = drType["Remarks"].ToString();
                    objt_CreditNoteHead.Processed = bool.Parse(drType["Processed"].ToString());
                    objt_CreditNoteHead.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                    objt_CreditNoteHead.ProcessedUser = drType["ProcessedUser"].ToString();
                    objt_CreditNoteHead.Grouped = bool.Parse(drType["Grouped"].ToString());
                    objt_CreditNoteHead.GroupedDate = DateTime.Parse(drType["GroupedDate"].ToString());
                    objt_CreditNoteHead.GroupedUser = drType["GroupedUser"].ToString();
                    objt_CreditNoteHead.Approved = bool.Parse(drType["Approved"].ToString());
                    objt_CreditNoteHead.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                    objt_CreditNoteHead.ApprovedUser = drType["ApprovedUser"].ToString();
                    return objt_CreditNoteHead;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool ExistingT_CreditNoteHead(string stringt_CreditNoteHead)
        {
            try
            {
                string xstrquery = @"select DocNo From T_CreditNoteHead   WHERE DocNo = '" + stringt_CreditNoteHead + "' ";
                DataRow drT_CreditNoteHead = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_CreditNoteHead != null)
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

        public List<T_CreditNoteHead> SelectT_CreditNoteHeadMulti(T_CreditNoteHead objt_CreditNoteHead2)
        {
            List<T_CreditNoteHead> retval = new List<T_CreditNoteHead>();
            try
            {
                strquery = @"select * from t_CreditNoteHead where DocNo = '" + objt_CreditNoteHead2.DocNo + "'";
                DataTable dtt_CreditNoteHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_CreditNoteHead.Rows)
                {
                    if (drType != null)
                    {
                        T_CreditNoteHead objt_CreditNoteHead = new T_CreditNoteHead();
                        objt_CreditNoteHead.DocNo = drType["DocNo"].ToString();
                        objt_CreditNoteHead.CompCode = drType["CompCode"].ToString();
                        objt_CreditNoteHead.LocaCode = drType["LocaCode"].ToString();
                        objt_CreditNoteHead.OFNo = drType["OFNo"].ToString();
                        objt_CreditNoteHead.InvNo = drType["InvNo"].ToString();
                        objt_CreditNoteHead.Dono = drType["Dono"].ToString();
                        objt_CreditNoteHead.CustomerID = drType["CustomerID"].ToString();
                        objt_CreditNoteHead.TypeX = drType["TypeX"].ToString();
                        objt_CreditNoteHead.AuditUser = drType["AuditUser"].ToString();
                        objt_CreditNoteHead.Statusx = drType["Statusx"].ToString();
                        objt_CreditNoteHead.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_CreditNoteHead.ManualID = drType["ManualID"].ToString();
                        objt_CreditNoteHead.DeliveredDate = DateTime.Parse(drType["DeliveredDate"].ToString());
                        objt_CreditNoteHead.PackingList = drType["PackingList"].ToString();
                        objt_CreditNoteHead.DeliveryStatus = drType["DeliveryStatus"].ToString();
                        objt_CreditNoteHead.AgentStatus = drType["AgentStatus"].ToString();
                        objt_CreditNoteHead.Remarks = drType["Remarks"].ToString();
                        objt_CreditNoteHead.Processed = bool.Parse(drType["Processed"].ToString());
                        objt_CreditNoteHead.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                        objt_CreditNoteHead.ProcessedUser = drType["ProcessedUser"].ToString();
                        objt_CreditNoteHead.Grouped = bool.Parse(drType["Grouped"].ToString());
                        objt_CreditNoteHead.GroupedDate = DateTime.Parse(drType["GroupedDate"].ToString());
                        objt_CreditNoteHead.GroupedUser = drType["GroupedUser"].ToString();
                        objt_CreditNoteHead.Approved = bool.Parse(drType["Approved"].ToString());
                        objt_CreditNoteHead.ApprovedDate = DateTime.Parse(drType["ApprovedDate"].ToString());
                        objt_CreditNoteHead.ApprovedUser = drType["ApprovedUser"].ToString();
                        retval.Add(objt_CreditNoteHead);
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
