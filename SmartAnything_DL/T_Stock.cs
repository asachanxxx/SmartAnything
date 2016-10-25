using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_StockDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_Stock table.
        /// </summary>
        public Boolean SaveT_StockSP(T_Stock t_Stock, int formMode,int StockType)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                if (StockType == 1)
                {
                    scom.CommandText = "T_StockSave";
                }
                else {
                    scom.CommandText = "T_StockDamageSave";
                }


                scom.Parameters.Add("@StockCode", SqlDbType.VarChar, 20).Value = t_Stock.StockCode;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = t_Stock.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = t_Stock.Locacode;
                scom.Parameters.Add("@Suppid", SqlDbType.VarChar, 20).Value = t_Stock.Suppid;
                scom.Parameters.Add("@ProductId", SqlDbType.VarChar, 20).Value = t_Stock.ProductId;
                scom.Parameters.Add("@Stock", SqlDbType.Decimal, 9).Value = t_Stock.Stock;
                scom.Parameters.Add("@OpnStock", SqlDbType.Decimal, 9).Value = t_Stock.OpnStock;
                scom.Parameters.Add("@InitialStock", SqlDbType.Decimal, 9).Value = t_Stock.InitialStock;
                scom.Parameters.Add("@ReservedStock", SqlDbType.Decimal, 9).Value = t_Stock.ReservedStock;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = t_Stock.CostPrice;
                scom.Parameters.Add("@SellingPrice", SqlDbType.Decimal, 9).Value = t_Stock.SellingPrice;
                scom.Parameters.Add("@WholeSalePrice", SqlDbType.Decimal, 9).Value = t_Stock.WholeSalePrice;
                scom.Parameters.Add("@MrpPrice", SqlDbType.Decimal, 9).Value = t_Stock.MrpPrice;
                scom.Parameters.Add("@CompanyPrice", SqlDbType.Decimal, 9).Value = t_Stock.CompanyPrice;
                scom.Parameters.Add("@AvgCost", SqlDbType.Decimal, 9).Value = t_Stock.AvgCost;
                scom.Parameters.Add("@InitialCost", SqlDbType.Decimal, 9).Value = t_Stock.InitialCost;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 150).Value = t_Stock.Descr;
                scom.Parameters.Add("@FixedGP", SqlDbType.Decimal, 9).Value = t_Stock.FixedGP;
                scom.Parameters.Add("@SIH", SqlDbType.Decimal, 9).Value = t_Stock.SIH;
                scom.Parameters.Add("@EXPDate", SqlDbType.DateTime, 8).Value = t_Stock.EXPDate;
                scom.Parameters.Add("@Usercode", SqlDbType.VarChar, 20).Value = t_Stock.Usercode;
                scom.Parameters.Add("@DateCr", SqlDbType.DateTime, 8).Value = t_Stock.DateCr;
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

        public Boolean Savet_StockDamageSP(T_StockDamage t_StockDamage, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_StockDamageSave";

                scom.Parameters.Add("@StockCode", SqlDbType.VarChar, 20).Value = t_StockDamage.StockCode;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = t_StockDamage.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = t_StockDamage.Locacode;
                scom.Parameters.Add("@Suppid", SqlDbType.VarChar, 20).Value = t_StockDamage.Suppid;
                scom.Parameters.Add("@ProductId", SqlDbType.VarChar, 20).Value = t_StockDamage.ProductId;
                scom.Parameters.Add("@Stock", SqlDbType.Decimal, 9).Value = t_StockDamage.Stock;
                scom.Parameters.Add("@OpnStock", SqlDbType.Decimal, 9).Value = t_StockDamage.OpnStock;
                scom.Parameters.Add("@InitialStock", SqlDbType.Decimal, 9).Value = t_StockDamage.InitialStock;
                scom.Parameters.Add("@ReservedStock", SqlDbType.Decimal, 9).Value = t_StockDamage.ReservedStock;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = t_StockDamage.CostPrice;
                scom.Parameters.Add("@SellingPrice", SqlDbType.Decimal, 9).Value = t_StockDamage.SellingPrice;
                scom.Parameters.Add("@WholeSalePrice", SqlDbType.Decimal, 9).Value = t_StockDamage.WholeSalePrice;
                scom.Parameters.Add("@MrpPrice", SqlDbType.Decimal, 9).Value = t_StockDamage.MrpPrice;
                scom.Parameters.Add("@CompanyPrice", SqlDbType.Decimal, 9).Value = t_StockDamage.CompanyPrice;
                scom.Parameters.Add("@AvgCost", SqlDbType.Decimal, 9).Value = t_StockDamage.AvgCost;
                scom.Parameters.Add("@InitialCost", SqlDbType.Decimal, 9).Value = t_StockDamage.InitialCost;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 150).Value = t_StockDamage.Descr;
                scom.Parameters.Add("@FixedGP", SqlDbType.Decimal, 9).Value = t_StockDamage.FixedGP;
                scom.Parameters.Add("@SIH", SqlDbType.Decimal, 9).Value = t_StockDamage.SIH;
                scom.Parameters.Add("@EXPDate", SqlDbType.DateTime, 8).Value = t_StockDamage.EXPDate;
                scom.Parameters.Add("@Usercode", SqlDbType.VarChar, 20).Value = t_StockDamage.Usercode;
                scom.Parameters.Add("@DateCr", SqlDbType.DateTime, 8).Value = t_StockDamage.DateCr;
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


        public DataTable SelectAllt_Stock(int typex,string compcode, string loca)
        {
            try
            {
                if (typex == 1)
                {
                    strquery = @"select [CompCode],	[Descr] from [T_Stock]";
                }
                else if (typex == 2)
                {
                    strquery = @"select * from [T_Stock] where Compcode = '"+compcode+"' and Locacode = '" + loca +"' ";
                }

                DataTable dtt_Stock = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_Stock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //select * from [T_Stock] where Compcode = '001' and Locacode = '01' 
        }

        public T_Stock Selectt_Stock(T_Stock objt_Stock)
        {
            try
            {
                string xstrquery = @"select * from  T_Stock where ProductId = '" + objt_Stock.ProductId + "' and Compcode = '" + objt_Stock.Compcode.Trim() + "' and Locacode = '" + objt_Stock.Locacode.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(xstrquery);
                if (drType != null)
                {
                    objt_Stock.StockCode = drType["StockCode"].ToString();
                    objt_Stock.Compcode = drType["Compcode"].ToString();
                    objt_Stock.Locacode = drType["Locacode"].ToString();
                    objt_Stock.Suppid = drType["Suppid"].ToString();
                    objt_Stock.ProductId = drType["ProductId"].ToString();
                    objt_Stock.Stock = decimal.Parse(drType["Stock"].ToString());
                    objt_Stock.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                    objt_Stock.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                    objt_Stock.ReservedStock = decimal.Parse(drType["ReservedStock"].ToString());
                    objt_Stock.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_Stock.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_Stock.WholeSalePrice = decimal.Parse(drType["WholeSalePrice"].ToString());
                    objt_Stock.MrpPrice = decimal.Parse(drType["MrpPrice"].ToString());
                    objt_Stock.CompanyPrice = decimal.Parse(drType["CompanyPrice"].ToString());
                    objt_Stock.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                    objt_Stock.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                    objt_Stock.Descr = drType["Descr"].ToString();
                    objt_Stock.FixedGP = decimal.Parse(drType["FixedGP"].ToString());
                    objt_Stock.SIH = decimal.Parse(drType["SIH"].ToString());
                    objt_Stock.EXPDate = DateTime.Parse(drType["EXPDate"].ToString());
                    objt_Stock.Usercode = drType["Usercode"].ToString();
                    objt_Stock.DateCr = DateTime.Parse(drType["DateCr"].ToString());
                    return objt_Stock;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T_StockDamage Selectt_DamageStock(T_StockDamage objt_Stock)
        {
            try
            {
                string xstrquery = @"select * from  T_StockDamage where ProductId = '" + objt_Stock.ProductId + "' and Compcode = '" + objt_Stock.Compcode.Trim() + "' and Locacode = '" + objt_Stock.Locacode.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(xstrquery);
                if (drType != null)
                {
                    objt_Stock.StockCode = drType["StockCode"].ToString();
                    objt_Stock.Compcode = drType["Compcode"].ToString();
                    objt_Stock.Locacode = drType["Locacode"].ToString();
                    objt_Stock.Suppid = drType["Suppid"].ToString();
                    objt_Stock.ProductId = drType["ProductId"].ToString();
                    objt_Stock.Stock = decimal.Parse(drType["Stock"].ToString());
                    objt_Stock.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                    objt_Stock.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                    objt_Stock.ReservedStock = decimal.Parse(drType["ReservedStock"].ToString());
                    objt_Stock.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_Stock.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_Stock.WholeSalePrice = decimal.Parse(drType["WholeSalePrice"].ToString());
                    objt_Stock.MrpPrice = decimal.Parse(drType["MrpPrice"].ToString());
                    objt_Stock.CompanyPrice = decimal.Parse(drType["CompanyPrice"].ToString());
                    objt_Stock.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                    objt_Stock.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                    objt_Stock.Descr = drType["Descr"].ToString();
                    objt_Stock.FixedGP = decimal.Parse(drType["FixedGP"].ToString());
                    objt_Stock.SIH = decimal.Parse(drType["SIH"].ToString());
                    objt_Stock.EXPDate = DateTime.Parse(drType["EXPDate"].ToString());
                    objt_Stock.Usercode = drType["Usercode"].ToString();
                    objt_Stock.DateCr = DateTime.Parse(drType["DateCr"].ToString());
                    return objt_Stock;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T_Stock Selectt_Stock_ByStockCode(T_Stock objt_Stock)
        {
            try
            {
                string xstrquery = @"select * from  T_Stock where StockCode = '" + objt_Stock.StockCode + "' and Compcode = '" + objt_Stock.Compcode.Trim() + "' and Locacode = '" + objt_Stock.Locacode.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(xstrquery);
                if (drType != null)
                {
                    objt_Stock.StockCode = drType["StockCode"].ToString();
                    objt_Stock.Compcode = drType["Compcode"].ToString();
                    objt_Stock.Locacode = drType["Locacode"].ToString();
                    objt_Stock.Suppid = drType["Suppid"].ToString();
                    objt_Stock.ProductId = drType["ProductId"].ToString();
                    objt_Stock.Stock = decimal.Parse(drType["Stock"].ToString());
                    objt_Stock.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                    objt_Stock.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                    objt_Stock.ReservedStock = decimal.Parse(drType["ReservedStock"].ToString());
                    objt_Stock.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_Stock.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_Stock.WholeSalePrice = decimal.Parse(drType["WholeSalePrice"].ToString());
                    objt_Stock.MrpPrice = decimal.Parse(drType["MrpPrice"].ToString());
                    objt_Stock.CompanyPrice = decimal.Parse(drType["CompanyPrice"].ToString());
                    objt_Stock.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                    objt_Stock.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                    objt_Stock.Descr = drType["Descr"].ToString();
                    objt_Stock.FixedGP = decimal.Parse(drType["FixedGP"].ToString());
                    objt_Stock.SIH = decimal.Parse(drType["SIH"].ToString());
                    objt_Stock.EXPDate = DateTime.Parse(drType["EXPDate"].ToString());
                    objt_Stock.Usercode = drType["Usercode"].ToString();
                    objt_Stock.DateCr = DateTime.Parse(drType["DateCr"].ToString());
                    return objt_Stock;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T_Stock Get_StockObj(string stkcode,string company,string loca)
        {
            try
            {
                T_Stock stk = new T_Stock();
                stk.StockCode = stkcode.Trim();
                stk.Compcode = company;
                stk.Locacode = loca;
                stk = new T_StockDL().Selectt_Stock_ByStockCode(stk);
                return stk;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public static string Get_ProductName(string stkcode, string company, string loca)
        {
            try
            {
                T_Stock stk = new T_Stock();
                stk.StockCode = stkcode.Trim();
                stk.Compcode = company;
                stk.Locacode = loca;
                stk = new T_StockDL().Selectt_Stock_ByStockCode(stk);
                return stk.Descr.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetLastStockCode(string productCode, string company, string loca)
        {
            try
            {
                
                DataRow dt = u_DBConnection.ReturnDataRow("select TOP 1 StockCode from  T_Stock where ProductId = '" + productCode.Trim() + "' AND Locacode = '"+loca.Trim()+"'  ORDER BY StockCode DESC");
                if (dt == null)
                {
                    return string.Empty;
                }
                else
                {
                    return dt["StockCode"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T_Stock Selectt_Stock_new(T_Stock objt_Stock)
        {
            try
            {
                string xstrquery = @"select * from  T_Stock where StockCode = '" + objt_Stock.StockCode + "' and Compcode = '" + objt_Stock.Compcode.Trim() + "' and Locacode = '" + objt_Stock.Locacode.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(xstrquery);
                if (drType != null)
                {
                    objt_Stock.StockCode = drType["StockCode"].ToString();
                    objt_Stock.Compcode = drType["Compcode"].ToString();
                    objt_Stock.Locacode = drType["Locacode"].ToString();
                    objt_Stock.Suppid = drType["Suppid"].ToString();
                    objt_Stock.ProductId = drType["ProductId"].ToString();
                    objt_Stock.Stock = decimal.Parse(drType["Stock"].ToString());
                    objt_Stock.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                    objt_Stock.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                    objt_Stock.ReservedStock = decimal.Parse(drType["ReservedStock"].ToString());
                    objt_Stock.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_Stock.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_Stock.WholeSalePrice = decimal.Parse(drType["WholeSalePrice"].ToString());
                    objt_Stock.MrpPrice = decimal.Parse(drType["MrpPrice"].ToString());
                    objt_Stock.CompanyPrice = decimal.Parse(drType["CompanyPrice"].ToString());
                    objt_Stock.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                    objt_Stock.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                    objt_Stock.Descr = drType["Descr"].ToString();
                    objt_Stock.FixedGP = decimal.Parse(drType["FixedGP"].ToString());
                    objt_Stock.SIH = decimal.Parse(drType["SIH"].ToString());
                    objt_Stock.EXPDate = DateTime.Parse(drType["EXPDate"].ToString());
                    objt_Stock.Usercode = drType["Usercode"].ToString();
                    objt_Stock.DateCr = DateTime.Parse(drType["DateCr"].ToString());
                    return objt_Stock;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T_StockDamage Selectt_Stock_new(T_StockDamage objt_Stock)
        {
            try
            {
                string xstrquery = @"select * from  T_StockDamage where StockCode = '" + objt_Stock.StockCode + "' and Compcode = '" + objt_Stock.Compcode.Trim() + "' and Locacode = '" + objt_Stock.Locacode.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(xstrquery);
                if (drType != null)
                {
                    objt_Stock.StockCode = drType["StockCode"].ToString();
                    objt_Stock.Compcode = drType["Compcode"].ToString();
                    objt_Stock.Locacode = drType["Locacode"].ToString();
                    objt_Stock.Suppid = drType["Suppid"].ToString();
                    objt_Stock.ProductId = drType["ProductId"].ToString();
                    objt_Stock.Stock = decimal.Parse(drType["Stock"].ToString());
                    objt_Stock.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                    objt_Stock.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                    objt_Stock.ReservedStock = decimal.Parse(drType["ReservedStock"].ToString());
                    objt_Stock.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_Stock.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_Stock.WholeSalePrice = decimal.Parse(drType["WholeSalePrice"].ToString());
                    objt_Stock.MrpPrice = decimal.Parse(drType["MrpPrice"].ToString());
                    objt_Stock.CompanyPrice = decimal.Parse(drType["CompanyPrice"].ToString());
                    objt_Stock.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                    objt_Stock.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                    objt_Stock.Descr = drType["Descr"].ToString();
                    objt_Stock.FixedGP = decimal.Parse(drType["FixedGP"].ToString());
                    objt_Stock.SIH = decimal.Parse(drType["SIH"].ToString());
                    objt_Stock.EXPDate = DateTime.Parse(drType["EXPDate"].ToString());
                    objt_Stock.Usercode = drType["Usercode"].ToString();
                    objt_Stock.DateCr = DateTime.Parse(drType["DateCr"].ToString());
                    return objt_Stock;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_Stock(string stringt_Stock, string compcode, string loca)
        {
            try
            {
                string xstrquery = @"select ProductId from  T_Stock where ProductId = '" + stringt_Stock + "' and Compcode = '" + compcode + "' and Locacode = '" + loca + "'";
                DataRow drT_Stock = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Stock != null)
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

        public static bool ExistingT_Stock_new(string stringt_Stock, string compcode, string loca)
        {
            try
            {
                string xstrquery = @"select StockCode from  T_Stock where StockCode = '" + stringt_Stock + "' and Compcode = '" + compcode + "' and Locacode = '" + loca + "'";
                DataRow drT_Stock = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Stock != null)
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

        public static bool ExistingT_StockDamage_new(string stringt_Stock, string compcode, string loca)
        {
            try
            {
                string xstrquery = @"select StockCode from  T_StockDamage where StockCode = '" + stringt_Stock + "' and Compcode = '" + compcode + "' and Locacode = '" + loca + "'";
                DataRow drT_Stock = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Stock != null)
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

        public static bool ExistingT_Stock_Product(string stringt_Stock, string compcode, string loca)
        {
            try
            {
                string xstrquery = @"select idx from  M_Products where idx = '" + stringt_Stock + "' and Compcode = '" + compcode + "'"; //and Locacode = '" + loca + "'";
                DataRow drT_Stock = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Stock != null)
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

        public static string GetMaxStockcode(string productid, string loca)
        {
            try
            {
                string retval = "";
                string xstrquery = @"select MAX(CAST(SUBSTRING(StockCode,12,16) AS INT)) maxStockCode  From T_Stock where SUBSTRING(StockCode,0,11) ='" + productid.Trim() + "' AND (Locacode= '" + loca.Trim() + "') ";
                DataRow drT_Stock = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Stock != null)
                {
                    retval = drT_Stock[0].ToString();
                    return retval;
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddStock_Update(string StockCode,string comp, string loca, decimal qty)
        {
            try
            {
                string xstrquery = @"UPDATE T_Stock SET stock = (stock+" + qty.ToString() + ") where StockCode = '" + StockCode.Trim() + "' and Compcode = '" + comp.Trim() + "' and Locacode = '" + loca.Trim() + "'";
                int drT_Stock = u_DBConnection.ExecuteNonQuery(xstrquery);
                if (drT_Stock != null)
                {
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ReduceStock_Update(string StockCode, string comp, string loca, decimal qty)
        {
            try
            {
                string xstrquery = @"UPDATE T_Stock SET stock = (stock-" + qty.ToString() + ") where StockCode = '" + StockCode.Trim() + "' and Compcode = '" + comp.Trim() + "' and Locacode = '" + loca.Trim() + "'";
                int drT_Stock = u_DBConnection.ExecuteNonQuery(xstrquery);
                if (drT_Stock != null)
                {
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddStock_Insert(T_Stock exstock, string comp, string loca, decimal qty)
        {
            try
            {
                exstock.Compcode = comp;
                exstock.Locacode = loca;
                exstock.Stock= qty;
                new T_StockDL().SaveT_StockSP(exstock,1,1);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion
    }
}
