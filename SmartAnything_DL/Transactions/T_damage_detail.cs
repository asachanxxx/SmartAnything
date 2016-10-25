using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_damage_detailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_damage_detail table.
        /// </summary>
        public Boolean Savet_damage_detailSP(t_damage_detail t_damage_detail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_damage_detailSave";

                scom.Parameters.Add("@damageNo", SqlDbType.VarChar, 20).Value = t_damage_detail.damageNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_damage_detail.locationId;
                scom.Parameters.Add("@damageDate", SqlDbType.DateTime, 8).Value = t_damage_detail.damageDate;
                scom.Parameters.Add("@itemCode", SqlDbType.VarChar, 20).Value = t_damage_detail.itemCode;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 150).Value = t_damage_detail.description;
                scom.Parameters.Add("@quantity", SqlDbType.Decimal, 9).Value = t_damage_detail.quantity;
                scom.Parameters.Add("@uom", SqlDbType.VarChar, 15).Value = t_damage_detail.uom;
                scom.Parameters.Add("@costPrice", SqlDbType.Decimal, 9).Value = t_damage_detail.costPrice;
                scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal, 9).Value = t_damage_detail.sellingPrice;
                scom.Parameters.Add("@amount", SqlDbType.Decimal, 9).Value = t_damage_detail.amount;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_damage_detail.triggerVal;
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


        public DataTable SelectAllt_damage_detail()
        {
            try
            {
                strquery = @"select damageNo,itemCode from t_damage_detail";
                DataTable dtt_damage_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_damage_detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_damage_detail Selectt_damage_detail(t_damage_detail objt_damage_detail)
        {
            try
            {
                strquery = @"select * from t_damage_detail where damageNo = '" + objt_damage_detail.damageNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_damage_detail.damageNo = drType["damageNo"].ToString();
                    objt_damage_detail.locationId = drType["locationId"].ToString();
                    objt_damage_detail.damageDate = DateTime.Parse(drType["damageDate"].ToString());
                    objt_damage_detail.itemCode = drType["itemCode"].ToString();
                    objt_damage_detail.description = drType["description"].ToString();
                    objt_damage_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                    objt_damage_detail.uom = drType["uom"].ToString();
                    objt_damage_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                    objt_damage_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                    objt_damage_detail.amount = decimal.Parse(drType["amount"].ToString());
                    objt_damage_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_damage_detail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_damage_detail(string stringt_damage_detail)
        {
            try
            {
                string xstrquery = @"select damageNo From T_damage_detail   WHERE damageNo = '" + stringt_damage_detail + "' ";
                DataRow drT_damage_detail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_damage_detail != null)
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

        public List<t_damage_detail> SelectT_damage_detailMulti(t_damage_detail objt_damage_detail2)
        {
            List<t_damage_detail> retval = new List<t_damage_detail>();
            try
            {
                strquery = @"select * from t_damage_detail where damageNo = '" + objt_damage_detail2.damageNo + "'";
                DataTable dtt_damage_detail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_damage_detail.Rows)
                {
                    if (drType != null)
                    {
                        t_damage_detail objt_damage_detail = new t_damage_detail();
                        objt_damage_detail.damageNo = drType["damageNo"].ToString();
                        objt_damage_detail.locationId = drType["locationId"].ToString();
                        objt_damage_detail.damageDate = DateTime.Parse(drType["damageDate"].ToString());
                        objt_damage_detail.itemCode = drType["itemCode"].ToString();
                        objt_damage_detail.description = drType["description"].ToString();
                        objt_damage_detail.quantity = decimal.Parse(drType["quantity"].ToString());
                        objt_damage_detail.uom = drType["uom"].ToString();
                        objt_damage_detail.costPrice = decimal.Parse(drType["costPrice"].ToString());
                        objt_damage_detail.sellingPrice = decimal.Parse(drType["sellingPrice"].ToString());
                        objt_damage_detail.amount = decimal.Parse(drType["amount"].ToString());
                        objt_damage_detail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_damage_detail);
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
