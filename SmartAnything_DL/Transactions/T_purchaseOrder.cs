using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_purchaseOrderDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_purchaseOrder table.
        /// </summary>
        public Boolean Savet_purchaseOrderSP(t_purchaseOrder t_purchaseOrder, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_purchaseOrderSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 20).Value = t_purchaseOrder.no;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_purchaseOrder.locationId;
                scom.Parameters.Add("@reqLocationId", SqlDbType.VarChar, 20).Value = t_purchaseOrder.reqLocationId;
                scom.Parameters.Add("@pReqNo", SqlDbType.VarChar, 20).Value = t_purchaseOrder.pReqNo;
                scom.Parameters.Add("@poMethod", SqlDbType.VarChar, 20).Value = t_purchaseOrder.poMethod;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_purchaseOrder.date;
                scom.Parameters.Add("@supplierId", SqlDbType.VarChar, 20).Value = t_purchaseOrder.supplierId;
                scom.Parameters.Add("@DeliveryDate", SqlDbType.DateTime, 8).Value = t_purchaseOrder.DeliveryDate;
                scom.Parameters.Add("@DLocationID", SqlDbType.VarChar, 20).Value = t_purchaseOrder.DLocationID;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_purchaseOrder.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_purchaseOrder.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_purchaseOrder.grossAmount;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Value = t_purchaseOrder.remarks;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_purchaseOrder.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_purchaseOrder.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_purchaseOrder.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 20).Value = t_purchaseOrder.processUser;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_purchaseOrder.triggerVal;
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


        public DataTable SelectAllt_purchaseOrder()
        {
            try
            {
                strquery = @"select no,grossAmount from  t_purchaseOrder";
                DataTable dtt_purchaseOrder = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_purchaseOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_purchaseOrder Selectt_purchaseOrder(t_purchaseOrder objt_purchaseOrder)
        {
            try
            {
                strquery = @"select * from t_purchaseOrder where no = '" + objt_purchaseOrder.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_purchaseOrder.no = drType["no"].ToString();
                    objt_purchaseOrder.locationId = drType["locationId"].ToString();
                    objt_purchaseOrder.reqLocationId = drType["reqLocationId"].ToString();
                    objt_purchaseOrder.pReqNo = drType["pReqNo"].ToString();
                    objt_purchaseOrder.poMethod = drType["poMethod"].ToString();
                    objt_purchaseOrder.date = DateTime.Parse(drType["date"].ToString());
                    objt_purchaseOrder.supplierId = drType["supplierId"].ToString();
                    objt_purchaseOrder.DeliveryDate = DateTime.Parse(drType["DeliveryDate"].ToString());
                    objt_purchaseOrder.DLocationID = drType["DLocationID"].ToString();
                    objt_purchaseOrder.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_purchaseOrder.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_purchaseOrder.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_purchaseOrder.remarks = drType["remarks"].ToString();
                    objt_purchaseOrder.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_purchaseOrder.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_purchaseOrder.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_purchaseOrder.processUser = drType["processUser"].ToString();
                    objt_purchaseOrder.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_purchaseOrder;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_purchaseOrder(string stringt_purchaseOrder)
        {
            try
            {
                string xstrquery = @"select no From T_purchaseOrder   WHERE no = '" + stringt_purchaseOrder + "' ";
                DataRow drT_purchaseOrder = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_purchaseOrder != null)
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

        public List<t_purchaseOrder> SelectT_purchaseOrderMulti(t_purchaseOrder objt_purchaseOrder2)
        {
            List<t_purchaseOrder> retval = new List<t_purchaseOrder>();
            try
            {
                strquery = @"select * from t_purchaseOrder where no = '" + objt_purchaseOrder2.no + "'";
                DataTable dtt_purchaseOrder = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_purchaseOrder.Rows)
                {
                    if (drType != null)
                    {
                        t_purchaseOrder objt_purchaseOrder = new t_purchaseOrder();
                        objt_purchaseOrder.no = drType["no"].ToString();
                        objt_purchaseOrder.locationId = drType["locationId"].ToString();
                        objt_purchaseOrder.reqLocationId = drType["reqLocationId"].ToString();
                        objt_purchaseOrder.pReqNo = drType["pReqNo"].ToString();
                        objt_purchaseOrder.poMethod = drType["poMethod"].ToString();
                        objt_purchaseOrder.date = DateTime.Parse(drType["date"].ToString());
                        objt_purchaseOrder.supplierId = drType["supplierId"].ToString();
                        objt_purchaseOrder.DeliveryDate = DateTime.Parse(drType["DeliveryDate"].ToString());
                        objt_purchaseOrder.DLocationID = drType["DLocationID"].ToString();
                        objt_purchaseOrder.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_purchaseOrder.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                        objt_purchaseOrder.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_purchaseOrder.remarks = drType["remarks"].ToString();
                        objt_purchaseOrder.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_purchaseOrder.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_purchaseOrder.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_purchaseOrder.processUser = drType["processUser"].ToString();
                        objt_purchaseOrder.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_purchaseOrder);
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
