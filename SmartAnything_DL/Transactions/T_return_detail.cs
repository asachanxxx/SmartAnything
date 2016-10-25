using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_return_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_return_detail table.
        /// </summary>
        public Boolean Savet_return_detailSP(t_return_detail t_return_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_return_detailSave";

                scom.Parameters.Add("@returnNo", SqlDbType.VarChar, 20).Value = t_return_detail.returnNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_return_detail.locationId;
                scom.Parameters.Add("@stockCode", SqlDbType.VarChar, 20).Value = t_return_detail.stockCode;
                scom.Parameters.Add("@productId", SqlDbType.VarChar, 20).Value = t_return_detail.productId;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_return_detail.quantity;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_return_detail.amount;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_return_detail.costPrice;
                scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal, 9).Value = t_return_detail.sellingPrice;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_return_detail.triggerVal;
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


        public DataTable SelectAllt_return_detail()
        {
            try
            {
                strquery = @"select returnNo ,amount  from t_return_detail";
                DataTable dtt_return_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_return_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_return_detail Selectt_return_detail(t_return_detail objt_return_detail)
        {
            try
            {
                strquery = @"select * from t_return_detail where returnNo = '" + objt_return_detail.returnNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_return_detail.returnNo = drType["returnNo"].ToString();
                    objt_return_detail.locationId = drType["locationId"].ToString();
                    objt_return_detail.stockCode = drType["stockCode"].ToString();
                    objt_return_detail.productId = drType["productId"].ToString();
                    objt_return_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_return_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_return_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_return_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                    objt_return_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_return_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_return_detail(string stringt_return_detail)
        {
            try
            {
                string xstrquery = @"select returnNo From T_return_detail   WHERE returnNo = '" + stringt_return_detail + "' ";
                DataRow drT_return_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_return_detail != null)
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

        public List<t_return_detail> SelectT_return_detailMulti(t_return_detail objt_return_detail2)
        {
            List<t_return_detail> retval = new List<t_return_detail>();
            try
            {
                strquery = @"select * from t_return_detail where returnNo = '" + objt_return_detail2.returnNo + "'";
                DataTable dtt_return_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_return_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_return_detail objt_return_detail = new t_return_detail();
                        objt_return_detail.returnNo = drType["returnNo"].ToString();
                        objt_return_detail.locationId = drType["locationId"].ToString();
                        objt_return_detail.stockCode = drType["stockCode"].ToString();
                        objt_return_detail.productId = drType["productId"].ToString();
                        objt_return_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_return_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_return_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_return_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                        objt_return_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_return_detail);
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
