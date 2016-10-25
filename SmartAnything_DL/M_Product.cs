using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_ProductDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Products table.
        /// </summary>
        public Boolean SaveM_ProductSP(M_Products m_Product, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_ProductsSave";

                scom.Parameters.Add("@IDX", SqlDbType.VarChar, 20).Value = m_Product.IDX;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = m_Product.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Product.Locacode;
                scom.Parameters.Add("@Namex", SqlDbType.VarChar, 150).Value = m_Product.Namex;
                scom.Parameters.Add("@PrintName", SqlDbType.VarChar, 150).Value = m_Product.PrintName;
                scom.Parameters.Add("@Category", SqlDbType.VarChar, 30).Value = m_Product.Category;
                scom.Parameters.Add("@Make", SqlDbType.VarChar, 30).Value = m_Product.Make;
                scom.Parameters.Add("@Model", SqlDbType.VarChar, 30).Value = m_Product.Model;
                scom.Parameters.Add("@Brand", SqlDbType.VarChar, 30).Value = m_Product.Brand;
                scom.Parameters.Add("@Color", SqlDbType.VarChar, 30).Value = m_Product.Color;
                scom.Parameters.Add("@Unitx", SqlDbType.VarChar, 30).Value = m_Product.Unitx;
                scom.Parameters.Add("@Suplier", SqlDbType.VarChar, 30).Value = m_Product.Suplier;
                scom.Parameters.Add("@UnitPrice", SqlDbType.Decimal, 9).Value = m_Product.UnitPrice;
                scom.Parameters.Add("@SellingPrice", SqlDbType.Decimal, 9).Value = m_Product.SellingPrice;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = m_Product.CostPrice;
                scom.Parameters.Add("@ReorderQTY", SqlDbType.Decimal, 9).Value = m_Product.ReorderQTY;
                scom.Parameters.Add("@ReorderLevel", SqlDbType.Decimal, 9).Value = m_Product.ReorderLevel;
                scom.Parameters.Add("@MaxDisc", SqlDbType.Decimal, 9).Value = m_Product.MaxDisc;
                scom.Parameters.Add("@MinDisc", SqlDbType.Decimal, 9).Value = m_Product.MinDisc;
                scom.Parameters.Add("@ApplyingDisc", SqlDbType.Decimal, 9).Value = m_Product.ApplyingDisc;
                scom.Parameters.Add("@LockItem", SqlDbType.Bit, 1).Value = m_Product.LockItem;
                scom.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = m_Product.IsActive;
                scom.Parameters.Add("@FrezzItem", SqlDbType.Bit, 1).Value = m_Product.FrezzItem;
                scom.Parameters.Add("@DiscountAllowed", SqlDbType.Bit, 1).Value = m_Product.DiscountAllowed;
                scom.Parameters.Add("@SalesCommAllowed", SqlDbType.Bit, 1).Value = m_Product.SalesCommAllowed;
                scom.Parameters.Add("@NegativeQTY", SqlDbType.Bit, 1).Value = m_Product.NegativeQTY;
                scom.Parameters.Add("@VatApplicable", SqlDbType.Bit, 1).Value = m_Product.VatApplicable;
                scom.Parameters.Add("@Norefundable", SqlDbType.Bit, 1).Value = m_Product.Norefundable;
                scom.Parameters.Add("@OpenPrice", SqlDbType.Bit, 1).Value = m_Product.OpenPrice;
                scom.Parameters.Add("@StockLot", SqlDbType.Bit, 1).Value = m_Product.StockLot;
                scom.Parameters.Add("@isOpenPrice", SqlDbType.Bit, 1).Value = m_Product.isOpenPrice;
                scom.Parameters.Add("@IsMaintainStockLot", SqlDbType.Bit, 1).Value = m_Product.IsMaintainStockLot;
                scom.Parameters.Add("@WholesalePrice", SqlDbType.Decimal, 9).Value = m_Product.WholesalePrice;
                scom.Parameters.Add("@SupplierWarrenty", SqlDbType.Decimal, 9).Value = m_Product.SupplierWarrenty;
                scom.Parameters.Add("@CustomerWarrenty", SqlDbType.Decimal, 9).Value = m_Product.CustomerWarrenty;
                scom.Parameters.Add("@CommissionAmount", SqlDbType.Decimal, 9).Value = m_Product.CommissionAmount;
                scom.Parameters.Add("@CommissionPer", SqlDbType.Decimal, 9).Value = m_Product.CommissionPer;
                scom.Parameters.Add("@CreateUser", SqlDbType.VarChar, 20).Value = m_Product.CreateUser;
                scom.Parameters.Add("@CreateDate", SqlDbType.DateTime, 8).Value = m_Product.CreateDate;
                scom.Parameters.Add("@ModifyUser", SqlDbType.VarChar, 20).Value = m_Product.ModifyUser;
                scom.Parameters.Add("@ModifyDate", SqlDbType.DateTime, 8).Value = m_Product.ModifyDate;
                scom.Parameters.Add("@SubCategory", SqlDbType.VarChar, 20).Value = m_Product.SubCategory;
                scom.Parameters.Add("@AutoIndex", SqlDbType.Int, 4).Value = m_Product.AutoIndex;
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

        public static string getMaxStockCode(string strStockCode, string strLocationID)
        {
            try
            {
                string strquery = "select MAX(CAST(SUBSTRING(StockCode,CHARINDEX('-',StockCode)+1,5) AS INT)) maxStockCode From dbo.T_Stock where SUBSTRING(StockCode,0,CHARINDEX('-',StockCode)) ='"+ strStockCode.Trim() + "' AND (Locacode = '"+ strLocationID.Trim() + "')";
                //string strquery = @"select MAX(CAST(SUBSTRING(stockCode,12,10) AS INT)) maxStockCode  From m_stock where SUBSTRING(stockCode,0,11) ='" + strStockCode + "' AND " +
                //            "(locationId = '" + strLocationID + "') ";

                DataRow drStock = u_DBConnection.ReturnDataRow(strquery);

                if (drStock != null)
                {
                    if (string.IsNullOrEmpty(drStock["maxStockCode"].ToString()))
                    {

                        return "0";
                    }
                    else
                        return drStock["maxStockCode"].ToString();

                }
                return "";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static  bool GetMaintainStockLot(string strId)
        {
            string strquery = @"select IsMaintainStockLot from M_Products where IDX='" + strId + "'";
            DataRow drSL = u_DBConnection.ReturnDataRow(strquery);
            if (drSL != null)
            {
                return (bool.Parse(drSL["IsMaintainStockLot"].ToString()));
            }
            else return false;
        }
        public DataTable SelectAllm_Product()
        {
            try
            {
                strquery = @"select IDX as 'Product Code', Namex as 'Description',UnitPrice as 'Unit Price' , CostPrice as 'Cost Price' ,SellingPrice as 'Selling Price' from  M_Products";
                DataTable dtm_Product = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Products Selectm_Product(M_Products objm_Product)
        {
            try
            {
                strquery = @"select * from M_Products where IDX = '" + objm_Product.IDX + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Product.IDX = drType["IDX"].ToString();
                    objm_Product.Compcode = drType["Compcode"].ToString();
                    objm_Product.Locacode = drType["Locacode"].ToString();
                    objm_Product.Namex = drType["Namex"].ToString();
                    objm_Product.PrintName = drType["PrintName"].ToString();
                    objm_Product.Category = drType["Category"].ToString();
                    objm_Product.Make = drType["Make"].ToString();
                    objm_Product.Model = drType["Model"].ToString();
                    objm_Product.Brand = drType["Brand"].ToString();
                    objm_Product.Color = drType["Color"].ToString();
                    objm_Product.Unitx = drType["Unitx"].ToString();
                    objm_Product.Suplier = drType["Suplier"].ToString();
                    objm_Product.UnitPrice = decimal.Parse(drType["UnitPrice"].ToString());
                    objm_Product.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objm_Product.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objm_Product.ReorderQTY = decimal.Parse(drType["ReorderQTY"].ToString());
                    objm_Product.ReorderLevel = decimal.Parse(drType["ReorderLevel"].ToString());
                    objm_Product.MaxDisc = decimal.Parse(drType["MaxDisc"].ToString());
                    objm_Product.MinDisc = decimal.Parse(drType["MinDisc"].ToString());
                    objm_Product.ApplyingDisc = decimal.Parse(drType["ApplyingDisc"].ToString());
                    objm_Product.LockItem = bool.Parse(drType["LockItem"].ToString());
                    objm_Product.IsActive = bool.Parse(drType["IsActive"].ToString());
                    objm_Product.FrezzItem = bool.Parse(drType["FrezzItem"].ToString());
                    objm_Product.DiscountAllowed = bool.Parse(drType["DiscountAllowed"].ToString());
                    objm_Product.SalesCommAllowed = bool.Parse(drType["SalesCommAllowed"].ToString());
                    objm_Product.NegativeQTY = bool.Parse(drType["NegativeQTY"].ToString());
                    objm_Product.VatApplicable = bool.Parse(drType["VatApplicable"].ToString());
                    objm_Product.Norefundable = bool.Parse(drType["Norefundable"].ToString());
                    objm_Product.OpenPrice = bool.Parse(drType["OpenPrice"].ToString());
                    objm_Product.StockLot = bool.Parse(drType["StockLot"].ToString());
                    objm_Product.isOpenPrice = bool.Parse(drType["isOpenPrice"].ToString());
                    objm_Product.IsMaintainStockLot = bool.Parse(drType["IsMaintainStockLot"].ToString());
                    objm_Product.WholesalePrice = decimal.Parse(drType["WholesalePrice"].ToString());
                    objm_Product.SupplierWarrenty = decimal.Parse(drType["SupplierWarrenty"].ToString());
                    objm_Product.CustomerWarrenty = decimal.Parse(drType["CustomerWarrenty"].ToString());
                    objm_Product.CommissionAmount = decimal.Parse(drType["CommissionAmount"].ToString());
                    objm_Product.CommissionPer = decimal.Parse(drType["CommissionPer"].ToString());
                    objm_Product.CreateUser = drType["CreateUser"].ToString();
                    objm_Product.CreateDate = DateTime.Parse(drType["CreateDate"].ToString());
                    objm_Product.ModifyUser = drType["ModifyUser"].ToString();
                    objm_Product.ModifyDate = DateTime.Parse(drType["ModifyDate"].ToString());
                    objm_Product.SubCategory = drType["SubCategory"].ToString();
                    objm_Product.AutoIndex = int.Parse(drType["AutoIndex"].ToString());
                    return objm_Product;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Product(string stringM_Product)
        {
            try
            {
                string xstrquery = @"select IDX From M_Products   WHERE IDX = '" + stringM_Product + "'";
                DataRow drM_Product = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Product != null)
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


        public static decimal GetCostPrice(string code) {
            decimal dec = decimal.Zero;
            if (M_ProductDL.ExistingM_Product(code))
            {
                M_Products pro = new M_Products();
                pro.IDX = code;
                pro = new M_ProductDL().Selectm_Product(pro);
                dec = decimal.Round(pro.CostPrice.Value, 2);
            }
            return dec;
        }

        public static decimal GetSellingPrice(string code)
        {
            decimal dec = decimal.Zero;
            if (M_ProductDL.ExistingM_Product(code))
            {
                M_Products pro = new M_Products();
                pro.IDX = code;
                pro = new M_ProductDL().Selectm_Product(pro);
                dec = decimal.Round(pro.SellingPrice.Value, 2);
            }
            return dec;
        }

        









        #endregion
    }
}
