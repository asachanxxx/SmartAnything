using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_PO_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_PO_detail table.
        /// </summary>
        public Boolean Savet_PO_detailSP(t_PO_detail t_PO_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_PO_detailSave";

                scom.Parameters.Add("@poNo", SqlDbType.VarChar, 20).Value = t_PO_detail.poNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_PO_detail.locationId;
                scom.Parameters.Add("@productId", SqlDbType.VarChar, 20).Value = t_PO_detail.productId;
                scom.Parameters.Add("@cost", SqlDbType.Decimal, 9).Value = t_PO_detail.cost;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_PO_detail.quantity;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_PO_detail.amount;
                scom.Parameters.Add("@priceLevel", SqlDbType.VarChar, 10).Value = t_PO_detail.priceLevel;
                scom.Parameters.Add("@selling", SqlDbType.Decimal, 9).Value = t_PO_detail.selling;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_PO_detail.triggerVal;
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


        public DataTable SelectAllt_PO_detail()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_PO_detail]";
                DataTable dtt_PO_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_PO_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_PO_detail Selectt_PO_detail(t_PO_detail objt_PO_detail)
        {
            try
            { //select poNo from  t_PO_detail
                strquery = @"select * from t_PO_detail where poNo = '" + objt_PO_detail.poNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_PO_detail.poNo = drType["poNo"].ToString();
                    objt_PO_detail.locationId = drType["locationId"].ToString();
                    objt_PO_detail.productId = drType["productId"].ToString();
                    objt_PO_detail.cost = decimal.Parse(drType["cost"].ToString());
                    objt_PO_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_PO_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_PO_detail.priceLevel = drType["priceLevel"].ToString();
                    objt_PO_detail.selling = decimal.Parse(drType["selling"].ToString());
                    objt_PO_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_PO_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_PO_detail(string stringt_PO_detail)
        {
            try
            {
                string xstrquery = @"select poNo From T_PO_detail   WHERE poNo = '" + stringt_PO_detail + "' ";
                DataRow drT_PO_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_PO_detail != null)
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

        public List<t_PO_detail> SelectT_PO_detailMulti(t_PO_detail objt_PO_detail2)
        {
            List<t_PO_detail> retval = new List<t_PO_detail>();
            try
            {
                strquery = @"select * from t_PO_detail where poNo = '" + objt_PO_detail2.poNo + "'";
                DataTable dtt_PO_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_PO_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_PO_detail objt_PO_detail = new t_PO_detail();
                        objt_PO_detail.poNo = drType["poNo"].ToString();
                        objt_PO_detail.locationId = drType["locationId"].ToString();
                        objt_PO_detail.productId = drType["productId"].ToString();
                        objt_PO_detail.cost = decimal.Parse(drType["cost"].ToString());
                        objt_PO_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_PO_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_PO_detail.priceLevel = drType["priceLevel"].ToString();
                        objt_PO_detail.selling = decimal.Parse(drType["selling"].ToString());
                        objt_PO_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_PO_detail);
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
