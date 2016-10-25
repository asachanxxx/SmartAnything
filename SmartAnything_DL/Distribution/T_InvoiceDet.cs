using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_InvoiceDetDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_InvoiceDet table.
        /// </summary>
        public Boolean Savet_InvoiceDetSP(T_InvoiceDet t_InvoiceDet, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_InvoiceDetSave";

                scom.Parameters.Add("@InvNo", SqlDbType.VarChar, 20).Value = t_InvoiceDet.InvNo;
                scom.Parameters.Add("@ItemCode", SqlDbType.VarChar, 20).Value = t_InvoiceDet.ItemCode;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = t_InvoiceDet.CostPrice;
                scom.Parameters.Add("@SellingPrice", SqlDbType.Decimal, 9).Value = t_InvoiceDet.SellingPrice;
                scom.Parameters.Add("@Qty", SqlDbType.Decimal, 9).Value = t_InvoiceDet.Qty;
                scom.Parameters.Add("@Unitx", SqlDbType.VarChar, 10).Value = t_InvoiceDet.Unitx;
                scom.Parameters.Add("@DiscountPer", SqlDbType.Decimal, 9).Value = t_InvoiceDet.DiscountPer;
                scom.Parameters.Add("@Discount", SqlDbType.Decimal, 9).Value = t_InvoiceDet.Discount;
                scom.Parameters.Add("@Total", SqlDbType.Decimal, 9).Value = t_InvoiceDet.Total;
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


        public DataTable SelectAllt_InvoiceDet()
        {
            try
            {
                strquery = @"select InvNo,ItemCode from T_InvoiceDet";
                DataTable dtt_InvoiceDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_InvoiceDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_InvoiceDet Selectt_InvoiceDet(T_InvoiceDet objt_InvoiceDet)
        {
            try
            {
                strquery = @"select * from t_InvoiceDet where CompCode = '" + objt_InvoiceDet + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_InvoiceDet.InvNo = drType["InvNo"].ToString();
                    objt_InvoiceDet.ItemCode = drType["ItemCode"].ToString();
                    objt_InvoiceDet.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_InvoiceDet.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_InvoiceDet.Qty = decimal.Parse(drType["Qty"].ToString());
                    objt_InvoiceDet.Unitx = drType["Unitx"].ToString();
                    objt_InvoiceDet.DiscountPer = decimal.Parse(drType["DiscountPer"].ToString());
                    objt_InvoiceDet.Discount = decimal.Parse(drType["Discount"].ToString());
                    objt_InvoiceDet.Total = decimal.Parse(drType["Total"].ToString());
                    return objt_InvoiceDet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_InvoiceDet(string stringt_InvoiceDet)
        {
            try
            {
                string xstrquery = @"select CompCode From T_InvoiceDet   WHERE CompCode = '" + stringt_InvoiceDet + "' ";
                DataRow drT_InvoiceDet = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_InvoiceDet != null)
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

        public List<T_InvoiceDet> SelectT_InvoiceDetMulti(T_InvoiceDet objt_InvoiceDet2)
        {
            List<T_InvoiceDet> retval = new List<T_InvoiceDet>();
            try
            {
                strquery = @"select * from t_InvoiceDet where InvNo = '" + objt_InvoiceDet2.InvNo + "'";
                DataTable dtt_InvoiceDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_InvoiceDet.Rows)
                {
                    if (drType != null)
                    {
                        T_InvoiceDet objt_InvoiceDet = new T_InvoiceDet();
                        objt_InvoiceDet.InvNo = drType["InvNo"].ToString();
                        objt_InvoiceDet.ItemCode = drType["ItemCode"].ToString();
                        objt_InvoiceDet.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                        objt_InvoiceDet.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                        objt_InvoiceDet.Qty = decimal.Parse(drType["Qty"].ToString());
                        objt_InvoiceDet.Unitx = drType["Unitx"].ToString();
                        objt_InvoiceDet.DiscountPer = decimal.Parse(drType["DiscountPer"].ToString());
                        objt_InvoiceDet.Discount = decimal.Parse(drType["Discount"].ToString());
                        objt_InvoiceDet.Total = decimal.Parse(drType["Total"].ToString());
                        retval.Add(objt_InvoiceDet);
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
