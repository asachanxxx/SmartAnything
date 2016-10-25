using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_returnDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_return table.
        /// </summary>
        public Boolean Savet_returnSP(t_return t_return, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_returnSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 20).Value = t_return.no;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_return.date;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_return.refNo;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 150).Value = t_return.remarks;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_return.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 20).Value = t_return.processUser;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_return.locationId;
                scom.Parameters.Add("@supplierId", SqlDbType.VarChar, 20).Value = t_return.supplierId;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_return.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_return.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_return.grossAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_return.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_return.isProcessed;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_return.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_return.triggerVal;
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


        public DataTable SelectAllt_return()
        {
            try
            {
                strquery = @"select no,grossAmount from t_return";
                DataTable dtt_return = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_return Selectt_return(t_return objt_return)
        {
            try
            {
                strquery = @"select * from t_return where no = '" + objt_return.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_return.no = drType["no"].ToString();
                    objt_return.date = DateTime.Parse(drType["date"].ToString());
                    objt_return.refNo = drType["refNo"].ToString();
                    objt_return.remarks = drType["remarks"].ToString();
                    objt_return.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_return.processUser = drType["processUser"].ToString();
                    objt_return.locationId = drType["locationId"].ToString();
                    objt_return.supplierId = drType["supplierId"].ToString();
                    objt_return.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_return.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_return.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_return.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_return.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_return.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_return.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_return;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_return(string stringt_return)
        {
            try
            {
                string xstrquery = @"select no From T_return   WHERE no = '" + stringt_return + "' ";
                DataRow drT_return = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_return != null)
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

        public List<t_return> SelectT_returnMulti(t_return objt_return2)
        {
            List<t_return> retval = new List<t_return>();
            try
            {
                strquery = @"select * from t_return where no = '" + objt_return2.no + "'";
                DataTable dtt_return = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_return.Rows)
                {
                    if (drType != null)
                    {
                        t_return objt_return = new t_return();
                        objt_return.no = drType["no"].ToString();
                        objt_return.date = DateTime.Parse(drType["date"].ToString());
                        objt_return.refNo = drType["refNo"].ToString();
                        objt_return.remarks = drType["remarks"].ToString();
                        objt_return.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_return.processUser = drType["processUser"].ToString();
                        objt_return.locationId = drType["locationId"].ToString();
                        objt_return.supplierId = drType["supplierId"].ToString();
                        objt_return.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_return.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                        objt_return.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_return.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_return.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_return.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_return.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_return);
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
