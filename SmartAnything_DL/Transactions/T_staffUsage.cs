using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_staffUsageDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_staffUsage table.
        /// </summary>
        public Boolean Savet_staffUsageSP(t_staffUsage t_staffUsage, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_staffUsageSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 20).Value = t_staffUsage.no;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_staffUsage.locationId;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_staffUsage.date;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_staffUsage.refNo;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 150).Value = t_staffUsage.remarks;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_staffUsage.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_staffUsage.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_staffUsage.grossAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_staffUsage.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_staffUsage.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_staffUsage.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 20).Value = t_staffUsage.processUser;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_staffUsage.triggerVal;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_staffUsage.GLUpdate;
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


        public DataTable SelectAllt_staffUsage()
        {
            try
            {
                strquery = @"select no,grossAmount from t_staffUsage";
                DataTable dtt_staffUsage = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_staffUsage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_staffUsage Selectt_staffUsage(t_staffUsage objt_staffUsage)
        {
            try
            {
                strquery = @"select * from t_staffUsage where no = '" + objt_staffUsage.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_staffUsage.no = drType["no"].ToString();
                    objt_staffUsage.locationId = drType["locationId"].ToString();
                    objt_staffUsage.date = DateTime.Parse(drType["date"].ToString());
                    objt_staffUsage.refNo = drType["refNo"].ToString();
                    objt_staffUsage.remarks = drType["remarks"].ToString();
                    objt_staffUsage.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_staffUsage.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_staffUsage.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_staffUsage.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_staffUsage.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_staffUsage.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_staffUsage.processUser = drType["processUser"].ToString();
                    objt_staffUsage.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    objt_staffUsage.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    return objt_staffUsage;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_staffUsage(string stringt_staffUsage)
        {
            try
            {
                string xstrquery = @"select no From T_staffUsage   WHERE no = '" + stringt_staffUsage + "' ";
                DataRow drT_staffUsage = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_staffUsage != null)
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

        public List<t_staffUsage> SelectT_staffUsageMulti(t_staffUsage objt_staffUsage2)
        {
            List<t_staffUsage> retval = new List<t_staffUsage>();
            try
            {
                strquery = @"select * from t_staffUsage where no = '" + objt_staffUsage2.no + "'";
                DataTable dtt_staffUsage = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_staffUsage.Rows)
                {
                    if (drType != null)
                    {
                        t_staffUsage objt_staffUsage = new t_staffUsage();
                        objt_staffUsage.no = drType["no"].ToString();
                        objt_staffUsage.locationId = drType["locationId"].ToString();
                        objt_staffUsage.date = DateTime.Parse(drType["date"].ToString());
                        objt_staffUsage.refNo = drType["refNo"].ToString();
                        objt_staffUsage.remarks = drType["remarks"].ToString();
                        objt_staffUsage.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_staffUsage.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                        objt_staffUsage.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_staffUsage.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_staffUsage.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_staffUsage.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_staffUsage.processUser = drType["processUser"].ToString();
                        objt_staffUsage.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        objt_staffUsage.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        retval.Add(objt_staffUsage);
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
