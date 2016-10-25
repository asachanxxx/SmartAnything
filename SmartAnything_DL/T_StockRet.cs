using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_StockRetDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_StockRet table.
        /// </summary>
        public Boolean SaveT_StockRetSP(T_StockDamage t_StockRet, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_StockRetSave";

                scom.Parameters.Add("@StockCode", SqlDbType.VarChar, 20).Value = t_StockRet.StockCode;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = t_StockRet.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = t_StockRet.Locacode;
                scom.Parameters.Add("@Suppid", SqlDbType.VarChar, 20).Value = t_StockRet.Suppid;
                scom.Parameters.Add("@ProductId", SqlDbType.VarChar, 20).Value = t_StockRet.ProductId;
                //scom.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = t_StockRet.Type;
                //scom.Parameters.Add("@Qty", SqlDbType.Decimal, 9).Value = t_StockRet.Qty;
                scom.Parameters.Add("@SellingPrice", SqlDbType.Decimal, 9).Value = t_StockRet.SellingPrice;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = t_StockRet.CostPrice;
                scom.Parameters.Add("@AvgCost", SqlDbType.Decimal, 9).Value = t_StockRet.AvgCost;
                scom.Parameters.Add("@OpnStock", SqlDbType.Decimal, 9).Value = t_StockRet.OpnStock;
                scom.Parameters.Add("@InitialCost", SqlDbType.Decimal, 9).Value = t_StockRet.InitialCost;
                scom.Parameters.Add("@InitialStock", SqlDbType.Decimal, 9).Value = t_StockRet.InitialStock;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 150).Value = t_StockRet.Descr;
                scom.Parameters.Add("@Usercode", SqlDbType.VarChar, 20).Value = t_StockRet.Usercode;
                //scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_StockRet.Datex;
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


        public DataTable SelectAllt_StockRet()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [M_Company]";
                DataTable dtt_StockRet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_StockRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_StockDamage Selectt_StockRet(T_StockDamage objt_StockRet)
        {
            try
            {
                strquery = @"select * from M_Company where CompCode = '";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_StockRet.StockCode = drType["StockCode"].ToString();
                    objt_StockRet.Compcode = drType["Compcode"].ToString();
                    objt_StockRet.Locacode = drType["Locacode"].ToString();
                    objt_StockRet.Suppid = drType["Suppid"].ToString();
                    objt_StockRet.ProductId = drType["ProductId"].ToString();
                    //objt_StockRet.Type = drType["Type"].ToString();
                    //objt_StockRet.Qty = decimal.Parse(drType["Qty"].ToString());
                    objt_StockRet.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_StockRet.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_StockRet.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                    objt_StockRet.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                    objt_StockRet.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                    objt_StockRet.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                    objt_StockRet.Descr = drType["Descr"].ToString();
                    objt_StockRet.Usercode = drType["Usercode"].ToString();
                    //objt_StockRet.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_StockRet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_StockRet(string stringT_StockRet)
        {
            try
            {
                string xstrquery = @"select CompCode From M_Company   WHERE CompCode = ";
                DataRow drT_StockRet = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_StockRet != null)
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
