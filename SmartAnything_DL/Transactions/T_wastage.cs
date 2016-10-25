using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_wastageDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_wastage table.
        /// </summary>
        public Boolean Savet_wastageSP(t_wastage t_wastage, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_wastageSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 20).Value = t_wastage.no;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_wastage.date;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_wastage.refNo;
                scom.Parameters.Add("@refDate", SqlDbType.DateTime, 8).Value = t_wastage.refDate;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = t_wastage.remarks;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_wastage.locationId;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_wastage.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_wastage.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_wastage.grossAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_wastage.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_wastage.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_wastage.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 30).Value = t_wastage.processUser;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_wastage.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_wastage.triggerVal;
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


        public DataTable SelectAllt_wastage()
        {
            try
            {
                strquery = @"select no,grossAmount from t_wastage";
                DataTable dtt_wastage = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_wastage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_wastage Selectt_wastage(t_wastage objt_wastage)
        {
            try
            {
                strquery = @"select * from t_wastage where no = '" + objt_wastage.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_wastage.no = drType["no"].ToString();
                    objt_wastage.date = DateTime.Parse(drType["date"].ToString());
                    objt_wastage.refNo = drType["refNo"].ToString();
                    objt_wastage.refDate = DateTime.Parse(drType["refDate"].ToString());
                    objt_wastage.remarks = drType["remarks"].ToString();
                    objt_wastage.locationId = drType["locationId"].ToString();
                    objt_wastage.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_wastage.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_wastage.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_wastage.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_wastage.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_wastage.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_wastage.processUser = drType["processUser"].ToString();
                    objt_wastage.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_wastage.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_wastage;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_wastage(string stringt_wastage)
        {
            try
            {
                string xstrquery = @"select no From T_wastage   WHERE no = '" + stringt_wastage + "' ";
                DataRow drT_wastage = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_wastage != null)
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

        public List<t_wastage> SelectT_wastageMulti(t_wastage objt_wastage2)
        {
            List<t_wastage> retval = new List<t_wastage>();
            try
            {
                strquery = @"select * from t_wastage where no = '" + objt_wastage2.no + "'";
                DataTable dtt_wastage = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_wastage.Rows)
                {
                    if (drType != null)
                    {
                        t_wastage objt_wastage = new t_wastage();
                        objt_wastage.no = drType["no"].ToString();
                        objt_wastage.date = DateTime.Parse(drType["date"].ToString());
                        objt_wastage.refNo = drType["refNo"].ToString();
                        objt_wastage.refDate = DateTime.Parse(drType["refDate"].ToString());
                        objt_wastage.remarks = drType["remarks"].ToString();
                        objt_wastage.locationId = drType["locationId"].ToString();
                        objt_wastage.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_wastage.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                        objt_wastage.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_wastage.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_wastage.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_wastage.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_wastage.processUser = drType["processUser"].ToString();
                        objt_wastage.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_wastage.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_wastage);
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
