using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_OpenStkHeadDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_OpenStkHead table.
        /// </summary>
        public Boolean Savet_OpenStkHeadSP(T_OpenStkHead t_OpenStkHead, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_OpenStkHeadSave";

                scom.Parameters.Add("@Docno", SqlDbType.VarChar, 10).Value = t_OpenStkHead.Docno;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 10).Value = t_OpenStkHead.locationId;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_OpenStkHead.date;
                scom.Parameters.Add("@supplier", SqlDbType.VarChar, 20).Value = t_OpenStkHead.supplier;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = t_OpenStkHead.remarks;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_OpenStkHead.grossAmount;
                scom.Parameters.Add("@netAmount", SqlDbType.Decimal, 9).Value = t_OpenStkHead.netAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_OpenStkHead.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_OpenStkHead.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_OpenStkHead.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 30).Value = t_OpenStkHead.processUser;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_OpenStkHead.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_OpenStkHead.triggerVal;
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


        public DataTable SelectAllt_OpenStkHead()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_OpenStkHead]";
                DataTable dtt_OpenStkHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_OpenStkHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_OpenStkHead Selectt_OpenStkHead(T_OpenStkHead objt_OpenStkHead)
        {
            try
            {
                strquery = @"select * from t_OpenStkHead where Docno = '" + objt_OpenStkHead.Docno + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_OpenStkHead.Docno = drType["Docno"].ToString();
                    objt_OpenStkHead.locationId = drType["locationId"].ToString();
                    objt_OpenStkHead.date = DateTime.Parse(drType["date"].ToString());
                    objt_OpenStkHead.supplier = drType["supplier"].ToString();
                    objt_OpenStkHead.remarks = drType["remarks"].ToString();
                    objt_OpenStkHead.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_OpenStkHead.netAmount = decimal.Parse(drType["netAmount"].ToString());
                    objt_OpenStkHead.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_OpenStkHead.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_OpenStkHead.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_OpenStkHead.processUser = drType["processUser"].ToString();
                    objt_OpenStkHead.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_OpenStkHead.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_OpenStkHead;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_OpenStkHead(string stringt_OpenStkHead)
        {
            try
            {
                string xstrquery = @"select Docno From T_OpenStkHead   WHERE Docno = '" + stringt_OpenStkHead + "' ";
                DataRow drT_OpenStkHead = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_OpenStkHead != null)
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

        public List<T_OpenStkHead> SelectT_OpenStkHeadMulti(T_OpenStkHead objt_OpenStkHead2)
        {
            List<T_OpenStkHead> retval = new List<T_OpenStkHead>();
            try
            {
                strquery = @"select * from t_OpenStkHead where Docno = '" + objt_OpenStkHead2.Docno + "'";
                DataTable dtt_OpenStkHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_OpenStkHead.Rows)
                {
                    if (drType != null)
                    {
                        T_OpenStkHead objt_OpenStkHead = new T_OpenStkHead();
                        objt_OpenStkHead.Docno = drType["Docno"].ToString();
                        objt_OpenStkHead.locationId = drType["locationId"].ToString();
                        objt_OpenStkHead.date = DateTime.Parse(drType["date"].ToString());
                        objt_OpenStkHead.supplier = drType["supplier"].ToString();
                        objt_OpenStkHead.remarks = drType["remarks"].ToString();
                        objt_OpenStkHead.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_OpenStkHead.netAmount = decimal.Parse(drType["netAmount"].ToString());
                        objt_OpenStkHead.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_OpenStkHead.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_OpenStkHead.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_OpenStkHead.processUser = drType["processUser"].ToString();
                        objt_OpenStkHead.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_OpenStkHead.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_OpenStkHead);
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
