using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_purchaseReq_detailDL
    {

        string strquery = "";

        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_purchaseReq_detail table.
        /// </summary>
        public Boolean SaveT_purchaseReq_detailSP(t_purchaseReq_detail t_purchaseReq_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_purchaseReq_detailSave";

                scom.Parameters.Add("@purchaseReqNo", SqlDbType.VarChar, 20).Value = t_purchaseReq_detail.purchaseReqNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_purchaseReq_detail.locationId;
                scom.Parameters.Add("@ReqDate", SqlDbType.DateTime, 8).Value = t_purchaseReq_detail.ReqDate;
                scom.Parameters.Add("@deleveryDate", SqlDbType.DateTime, 8).Value = t_purchaseReq_detail.deleveryDate;
                scom.Parameters.Add("@productId", SqlDbType.VarChar, 20).Value = t_purchaseReq_detail.productId;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 150).Value = t_purchaseReq_detail.description;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_purchaseReq_detail.quantity;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_purchaseReq_detail.costPrice;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_purchaseReq_detail.amount;
                scom.Parameters.Add("@release", SqlDbType.Int, 4).Value = t_purchaseReq_detail.release;
                scom.Parameters.Add("@r_value", SqlDbType.Int, 4).Value = t_purchaseReq_detail.r_value;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_purchaseReq_detail.triggerVal;
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


        public DataTable SelectAllt_purchaseReq_detail()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_purchaseReq_detail]";
                DataTable dtt_purchaseReq_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_purchaseReq_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<t_purchaseReq_detail> Selectt_purchaseReq_detailMulti(t_purchaseReq_detail objt_purchaseReq_detail2)
        {
            List<t_purchaseReq_detail> retval = new List<t_purchaseReq_detail>();
            try
            {
                strquery = @"select * from T_purchaseReq_detail where purchaseReqNo = '" + objt_purchaseReq_detail2.purchaseReqNo + "'";
                DataTable dtt_purchaseReq_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_purchaseReq_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_purchaseReq_detail objt_purchaseReq_detail = new t_purchaseReq_detail();
                        objt_purchaseReq_detail.purchaseReqNo = drType["purchaseReqNo"].ToString();
                        objt_purchaseReq_detail.locationId = drType["locationId"].ToString();
                        objt_purchaseReq_detail.ReqDate = DateTime.Parse(drType["ReqDate"].ToString());
                        objt_purchaseReq_detail.deleveryDate = DateTime.Parse(drType["deleveryDate"].ToString());
                        objt_purchaseReq_detail.productId = drType["productId"].ToString();
                        objt_purchaseReq_detail.description = drType["description"].ToString();
                        objt_purchaseReq_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_purchaseReq_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_purchaseReq_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_purchaseReq_detail.release = int.Parse(drType["release"].ToString());
                        objt_purchaseReq_detail.r_value = int.Parse(drType["r_value"].ToString());
                        objt_purchaseReq_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_purchaseReq_detail);
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public t_purchaseReq_detail Selectt_purchaseReq_detail(t_purchaseReq_detail objt_purchaseReq_detail)
        {
            try
            {
                strquery = @"select * from T_purchaseReq_detail where purchaseReqNo = '" + objt_purchaseReq_detail.purchaseReqNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_purchaseReq_detail.purchaseReqNo = drType["purchaseReqNo"].ToString();
                    objt_purchaseReq_detail.locationId = drType["locationId"].ToString();
                    objt_purchaseReq_detail.ReqDate = DateTime.Parse(drType["ReqDate"].ToString());
                    objt_purchaseReq_detail.deleveryDate = DateTime.Parse(drType["deleveryDate"].ToString());
                    objt_purchaseReq_detail.productId = drType["productId"].ToString();
                    objt_purchaseReq_detail.description = drType["description"].ToString();
                    objt_purchaseReq_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_purchaseReq_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_purchaseReq_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_purchaseReq_detail.release = int.Parse(drType["release"].ToString());
                    objt_purchaseReq_detail.r_value = int.Parse(drType["r_value"].ToString());
                    objt_purchaseReq_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_purchaseReq_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_purchaseReq_detail(string stringt_purchaseReq_detail)
        {
            try
            {
                string xstrquery = @"select purchaseReqNo From T_purchaseReq_detail   WHERE purchaseReqNo = '" + stringt_purchaseReq_detail + "' ";
                DataRow drT_purchaseReq_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_purchaseReq_detail != null)
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
