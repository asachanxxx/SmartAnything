using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_RecHedDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_RecHed table.
        /// </summary>
        public Boolean Savet_RecHedSP(T_RecHed t_RecHed, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_RecHedSave";

                scom.Parameters.Add("@Docno", SqlDbType.VarChar, 10).Value = t_RecHed.Docno;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 10).Value = t_RecHed.locationId;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_RecHed.Datex;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_RecHed.Customer;
                scom.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = t_RecHed.Status;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_RecHed.refNo;
                scom.Parameters.Add("@Memo", SqlDbType.VarChar, 150).Value = t_RecHed.Memo;
                scom.Parameters.Add("@Recivedfrom", SqlDbType.VarChar, 150).Value = t_RecHed.Recivedfrom;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = t_RecHed.remarks;
                scom.Parameters.Add("@Amount", SqlDbType.Decimal, 9).Value = t_RecHed.Amount;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_RecHed.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_RecHed.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 30).Value = t_RecHed.processUser;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_RecHed.isSaved;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_RecHed.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_RecHed.triggerVal;
                scom.Parameters.Add("@iscancelled", SqlDbType.Bit, 1).Value = t_RecHed.iscancelled;
                scom.Parameters.Add("@CancelledUser", SqlDbType.VarChar, 20).Value = t_RecHed.CancelledUser;
                scom.Parameters.Add("@CancelledDate", SqlDbType.DateTime, 8).Value = t_RecHed.CancelledDate;
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


        public DataTable SelectAllt_RecHed()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_RecHed]";
                DataTable dtt_RecHed = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_RecHed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_RecHed Selectt_RecHed(T_RecHed objt_RecHed)
        {
            try
            {
                strquery = @"select * from t_RecHed where Docno = '" + objt_RecHed.Docno + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_RecHed.Docno = drType["Docno"].ToString();
                    objt_RecHed.locationId = drType["locationId"].ToString();
                    objt_RecHed.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_RecHed.Customer = drType["Customer"].ToString();
                    objt_RecHed.Status = drType["Status"].ToString();
                    objt_RecHed.refNo = drType["refNo"].ToString();
                    objt_RecHed.Memo = drType["Memo"].ToString();
                    objt_RecHed.Recivedfrom = drType["Recivedfrom"].ToString();
                    objt_RecHed.remarks = drType["remarks"].ToString();
                    objt_RecHed.Amount = decimal.Parse(drType["Amount"].ToString());
                    objt_RecHed.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_RecHed.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_RecHed.processUser = drType["processUser"].ToString();
                    objt_RecHed.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_RecHed.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_RecHed.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    objt_RecHed.iscancelled = bool.Parse(drType["iscancelled"].ToString());
                    objt_RecHed.CancelledUser = drType["CancelledUser"].ToString();
                    objt_RecHed.CancelledDate = DateTime.Parse(drType["CancelledDate"].ToString());
                    return objt_RecHed;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_RecHed(string stringt_RecHed)
        {
            try
            {
                string xstrquery = @"select Docno From T_RecHed   WHERE Docno = '" + stringt_RecHed.Trim() + "' ";
                DataRow drT_RecHed = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_RecHed != null)
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

        public List<T_RecHed> SelectT_RecHedMulti(T_RecHed objt_RecHed2)
        {
            List<T_RecHed> retval = new List<T_RecHed>();
            try
            {
                strquery = @"select * from t_RecHed where Docno = '" + objt_RecHed2.Docno + "'";
                DataTable dtt_RecHed = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_RecHed.Rows)
                {
                    if (drType != null)
                    {
                        T_RecHed objt_RecHed = new T_RecHed();
                        objt_RecHed.Docno = drType["Docno"].ToString();
                        objt_RecHed.locationId = drType["locationId"].ToString();
                        objt_RecHed.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_RecHed.Customer = drType["Customer"].ToString();
                        objt_RecHed.Status = drType["Status"].ToString();
                        objt_RecHed.refNo = drType["refNo"].ToString();
                        objt_RecHed.Memo = drType["Memo"].ToString();
                        objt_RecHed.Recivedfrom = drType["Recivedfrom"].ToString();
                        objt_RecHed.remarks = drType["remarks"].ToString();
                        objt_RecHed.Amount = decimal.Parse(drType["Amount"].ToString());
                        objt_RecHed.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_RecHed.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_RecHed.processUser = drType["processUser"].ToString();
                        objt_RecHed.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_RecHed.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_RecHed.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        objt_RecHed.iscancelled = bool.Parse(drType["iscancelled"].ToString());
                        objt_RecHed.CancelledUser = drType["CancelledUser"].ToString();
                        objt_RecHed.CancelledDate = DateTime.Parse(drType["CancelledDate"].ToString());
                        retval.Add(objt_RecHed);
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
