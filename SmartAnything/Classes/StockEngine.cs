using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartAnything;
using SmartAnything_DL;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class StockEngine
    {


        public static decimal GetCurrentStock(string stockcode) {
            decimal stock = decimal.Zero;
            try
            {
                T_Stock stk = new T_Stock();
                stk.Locacode = commonFunctions.GlobalLocation;
                stk.Compcode = commonFunctions.GlobalCompany;
                stk.StockCode = stockcode.Trim();
                stk = new T_StockDL().Selectt_Stock_new(stk);
                stock = stk.Stock.Value;
            }
            catch (Exception ex) { 
            
            }
            return stock;
        }

        public static  string GetProductCode(string stockcode)
        {
            string  stock = "";
            try
            {
                T_Stock stk = new T_Stock();
                stk.Locacode = commonFunctions.GlobalLocation;
                stk.Compcode = commonFunctions.GlobalCompany;
                stk.StockCode = stockcode.Trim();
                stk = new T_StockDL().Selectt_Stock_new(stk);
                stock = stk.ProductId.Trim();
            }
            catch (Exception ex)
            {

            }
            return stock;
        }

        public static decimal GetCurrentStockForOneProduct(string ProductID)
        {

            return decimal.Zero;
        }

        public static decimal GetProductCostPrice(string ProductID)
        {

            decimal stock = decimal.Zero;
            try
            {
                M_Products stk = new M_Products();
                stk.IDX = ProductID;

                stk = new M_ProductDL().Selectm_Product(stk);
                stock = stk.CostPrice.Value;
            }
            catch (Exception ex)
            {

            }
            return stock;
        }

        public static decimal GetProductSellingPrice(string ProductID)
        {

            decimal stock = decimal.Zero;
            try
            {
                M_Products stk = new M_Products();
                stk.IDX = ProductID;

                stk = new M_ProductDL().Selectm_Product(stk);
                stock = stk.SellingPrice.Value;
            }
            catch (Exception ex)
            {

            }
            return stock;
        }

        public static decimal GetProductAvarageCost(string ProductID)
        {

            return decimal.Zero;
        }


        public static T_Stock GetStockdetails(string stockcode)
        {
            T_Stock stk = new T_Stock();
            try
            {
                stk.Locacode = commonFunctions.GlobalLocation;
                stk.Compcode = commonFunctions.GlobalCompany;
                stk.StockCode = stockcode;
                stk = new T_StockDL().Selectt_Stock_new(stk);


            }
            catch (Exception ex)
            {
            }
            return stk;
        }

        public static T_Stock GetStockdetails(string stockcode, string location)
        {
            T_Stock stk = new T_Stock();
            try
            {
                stk.Locacode = location;
                stk.Compcode = commonFunctions.GlobalCompany;
                stk.StockCode = stockcode;
                stk = new T_StockDL().Selectt_Stock_new(stk);


            }
            catch (Exception ex)
            {
            }
            return stk;
        }
    }
}
