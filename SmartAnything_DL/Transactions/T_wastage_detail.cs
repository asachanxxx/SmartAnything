using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_wastage_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_wastage_detail table.
        /// </summary>
        public Boolean Savet_wastage_detailSP(t_wastage_detail t_wastage_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_wastage_detailSave";

                scom.Parameters.Add("@wastageNo", SqlDbType.VarChar, 20).Value = t_wastage_detail.wastageNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_wastage_detail.locationId;
                scom.Parameters.Add("@wastageDate", SqlDbType.DateTime, 8).Value = t_wastage_detail.wastageDate;
                scom.Parameters.Add("@itemCode", SqlDbType.VarChar, 20).Value = t_wastage_detail.itemCode;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 150).Value = t_wastage_detail.description;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_wastage_detail.quantity;
                scom.Parameters.Add("@uom", SqlDbType.VarChar, 15).Value = t_wastage_detail.uom;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_wastage_detail.costPrice;
                scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal, 9).Value = t_wastage_detail.sellingPrice;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_wastage_detail.amount;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_wastage_detail.triggerVal;
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


        public DataTable SelectAllt_wastage_detail()
        {
            try
            {
                strquery = @"select wastageNo,itemCode from t_wastage_detail";
                DataTable dtt_wastage_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_wastage_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_wastage_detail Selectt_wastage_detail(t_wastage_detail objt_wastage_detail)
        {
            try
            {
                strquery = @"select * from t_wastage_detail where wastageNo = '" + objt_wastage_detail.wastageNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_wastage_detail.wastageNo = drType["wastageNo"].ToString();
                    objt_wastage_detail.locationId = drType["locationId"].ToString();
                    objt_wastage_detail.wastageDate = DateTime.Parse(drType["wastageDate"].ToString());
                    objt_wastage_detail.itemCode = drType["itemCode"].ToString();
                    objt_wastage_detail.description = drType["description"].ToString();
                    objt_wastage_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_wastage_detail.uom = drType["uom"].ToString();
                    objt_wastage_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_wastage_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                    objt_wastage_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_wastage_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_wastage_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_wastage_detail(string stringt_wastage_detail)
        {
            try
            {
                string xstrquery = @"select wastageNo From T_wastage_detail   WHERE wastageNo = '" + stringt_wastage_detail + "' ";
                DataRow drT_wastage_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_wastage_detail != null)
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

        public List<t_wastage_detail> SelectT_wastage_detailMulti(t_wastage_detail objt_wastage_detail2)
        {
            List<t_wastage_detail> retval = new List<t_wastage_detail>();
            try
            {
                strquery = @"select * from t_wastage_detail where wastageNo = '" + objt_wastage_detail2.wastageNo + "'";
                DataTable dtt_wastage_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_wastage_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_wastage_detail objt_wastage_detail = new t_wastage_detail();
                        objt_wastage_detail.wastageNo = drType["wastageNo"].ToString();
                        objt_wastage_detail.locationId = drType["locationId"].ToString();
                        objt_wastage_detail.wastageDate = DateTime.Parse(drType["wastageDate"].ToString());
                        objt_wastage_detail.itemCode = drType["itemCode"].ToString();
                        objt_wastage_detail.description = drType["description"].ToString();
                        objt_wastage_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_wastage_detail.uom = drType["uom"].ToString();
                        objt_wastage_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_wastage_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                        objt_wastage_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_wastage_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_wastage_detail);
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
