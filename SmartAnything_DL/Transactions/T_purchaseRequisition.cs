using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_purchaseRequisitionDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_purchaseRequisition table.
        /// </summary>
        public Boolean SaveT_purchaseRequisitionSP(t_purchaseRequisition t_purchaseRequisition, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_purchaseRequisitionSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 10).Value = t_purchaseRequisition.no;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_purchaseRequisition.date;
                scom.Parameters.Add("@deleveryDate", SqlDbType.DateTime, 8).Value = t_purchaseRequisition.deleveryDate;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 150).Value = t_purchaseRequisition.remarks;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_purchaseRequisition.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 20).Value = t_purchaseRequisition.processUser;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_purchaseRequisition.locationId;
                scom.Parameters.Add("@supplierId", SqlDbType.VarChar, 20).Value = t_purchaseRequisition.supplierId;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_purchaseRequisition.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_purchaseRequisition.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_purchaseRequisition.grossAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_purchaseRequisition.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_purchaseRequisition.isProcessed;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_purchaseRequisition.triggerVal;
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


        public DataTable SelectAllt_purchaseRequisition()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_purchaseRequisition]";
                DataTable dtt_purchaseRequisition = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_purchaseRequisition;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_purchaseRequisition Selectt_purchaseRequisition(t_purchaseRequisition objt_purchaseRequisition)
        {
            try
            {
                strquery = @"select * from T_purchaseRequisition where no = '" + objt_purchaseRequisition.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_purchaseRequisition.no = drType["no"].ToString();
                    objt_purchaseRequisition.date = DateTime.Parse(drType["date"].ToString());
                    objt_purchaseRequisition.deleveryDate = DateTime.Parse(drType["deleveryDate"].ToString());
                    objt_purchaseRequisition.remarks = drType["remarks"].ToString();
                    objt_purchaseRequisition.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_purchaseRequisition.processUser = drType["processUser"].ToString();
                    objt_purchaseRequisition.locationId = drType["locationId"].ToString();
                    objt_purchaseRequisition.supplierId = drType["supplierId"].ToString();
                    objt_purchaseRequisition.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_purchaseRequisition.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_purchaseRequisition.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_purchaseRequisition.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_purchaseRequisition.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_purchaseRequisition.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_purchaseRequisition;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_purchaseRequisition(string stringt_purchaseRequisition)
        {
            try
            {
                string xstrquery = @"select no from t_purchaseRequisition where no  = '" + stringt_purchaseRequisition + "' ";
                DataRow drT_purchaseRequisition = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_purchaseRequisition != null)
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




        #endregion
    }
}
