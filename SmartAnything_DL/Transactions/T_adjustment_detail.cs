using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_adjustment_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_adjustment_details table.
        /// </summary>
        public Boolean Savet_adjustment_detailSP(t_adjustment_details t_adjustment_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_adjustment_detailsSave";

                scom.Parameters.Add("@adju_no", SqlDbType.VarChar, 20).Value = t_adjustment_detail.adju_no;
                scom.Parameters.Add("@location_id", SqlDbType.VarChar, 20).Value = t_adjustment_detail.location_id;
                scom.Parameters.Add("@line_no", SqlDbType.Int, 4).Value = t_adjustment_detail.line_no;
                scom.Parameters.Add("@item_code", SqlDbType.VarChar, 20).Value = t_adjustment_detail.item_code;
                scom.Parameters.Add("@cost", SqlDbType.Decimal, 9).Value = t_adjustment_detail.cost;
                scom.Parameters.Add("@stock", SqlDbType.Decimal, 9).Value = t_adjustment_detail.stock;
                scom.Parameters.Add("@physical_quantity", SqlDbType.Decimal, 9).Value = t_adjustment_detail.physical_quantity;
                scom.Parameters.Add("@variance", SqlDbType.Decimal, 9).Value = t_adjustment_detail.variance;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_adjustment_detail.triggerVal;
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


        public DataTable SelectAllt_adjustment_detail()
        {
            try
            {
                strquery = @"select adju_no,item_code from t_adjustment_details";
                DataTable dtt_adjustment_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_adjustment_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_adjustment_details Selectt_adjustment_detail(t_adjustment_details objt_adjustment_detail)
        {
            try
            {
                strquery = @"select * from t_adjustment_detail where adju_no = '" + objt_adjustment_detail.adju_no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_adjustment_detail.adju_no = drType["adju_no"].ToString();
                    objt_adjustment_detail.location_id = drType["location_id"].ToString();
                    objt_adjustment_detail.line_no = int.Parse(drType["line_no"].ToString());
                    objt_adjustment_detail.item_code = drType["item_code"].ToString();
                    objt_adjustment_detail.cost = decimal.Parse(drType["cost"].ToString());
                    objt_adjustment_detail.stock = decimal.Parse(drType["stock"].ToString());
                    objt_adjustment_detail.physical_quantity = decimal.Parse(drType["physical_quantity"].ToString());
                    objt_adjustment_detail.variance = decimal.Parse(drType["variance"].ToString());
                    objt_adjustment_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_adjustment_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_adjustment_detail(string stringt_adjustment_detail)
        {
            try
            {
                string xstrquery = @"select adju_no From T_adjustment_detail   WHERE adju_no = '" + stringt_adjustment_detail + "' ";
                DataRow drT_adjustment_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_adjustment_detail != null)
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

        public List<t_adjustment_details> SelectT_adjustment_detailMulti(t_adjustment_details objt_adjustment_detail2)
        {
            List<t_adjustment_details> retval = new List<t_adjustment_details>();
            try
            {
                strquery = @"select * from t_adjustment_details where adju_no = '" + objt_adjustment_detail2.adju_no + "'";
                DataTable dtt_adjustment_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_adjustment_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_adjustment_details objt_adjustment_detail = new t_adjustment_details();
                        objt_adjustment_detail.adju_no = drType["adju_no"].ToString();
                        objt_adjustment_detail.location_id = drType["location_id"].ToString();
                        objt_adjustment_detail.line_no = int.Parse(drType["line_no"].ToString());
                        objt_adjustment_detail.item_code = drType["item_code"].ToString();
                        objt_adjustment_detail.cost = decimal.Parse(drType["cost"].ToString());
                        objt_adjustment_detail.stock = decimal.Parse(drType["stock"].ToString());
                        objt_adjustment_detail.physical_quantity = decimal.Parse(drType["physical_quantity"].ToString());
                        objt_adjustment_detail.variance = decimal.Parse(drType["variance"].ToString());
                        objt_adjustment_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_adjustment_detail);
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
