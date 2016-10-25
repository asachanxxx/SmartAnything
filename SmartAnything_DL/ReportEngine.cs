using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAnything_DL
{
    public class ReportEngine
    {
        /// <summary>
        /// StockReports 
        /// </summary>
        /// <param name="paramtype"> if 0 - all , 1 - suuplier , 2 - category ,3 - category adn subcategory , 4 - item from to </param>
        /// <param name="code"></param>
        /// <param name="code2"></param>
        /// <returns></returns>
        public static String GetStockEvoSTR(string loca,int paramtype, string code , string code2)
        {
            string str = "";
            if (paramtype == 0)
            {
                     str = " SELECT     dbo.T_Stock.StockCode, dbo.T_Stock.ProductId, dbo.M_Products.Namex, dbo.T_Stock.Stock, dbo.T_Stock.ReservedStock, dbo.M_Products.UnitPrice,dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice " +
                             "FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX " +
                             "WHERE T_Stock.Compcode = '001' AND T_Stock.Locacode = '" + loca + "'";
            }
            else if (paramtype == 1) {
                     str =   "SELECT     dbo.T_Stock.StockCode, dbo.T_Stock.ProductId, dbo.M_Products.Namex, dbo.T_Stock.Stock, dbo.T_Stock.ReservedStock, dbo.M_Products.UnitPrice,dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice " +
                             "FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX " +
                             "WHERE  M_Products.Suplier = '" + code.Trim() + "' and T_Stock.Compcode = '001' AND T_Stock.Locacode = '" + loca + "'";
            }
            else if (paramtype == 2)
            {
                str = "SELECT     dbo.T_Stock.StockCode, dbo.T_Stock.ProductId, dbo.M_Products.Namex, dbo.T_Stock.Stock, dbo.T_Stock.ReservedStock, dbo.M_Products.UnitPrice,dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice " +
                            "FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX " +
                            "WHERE  M_Products.Category = '" + code.Trim() + "' and T_Stock.Compcode = '001' AND T_Stock.Locacode = '" + loca + "'";
            }
            else if (paramtype == 3)
            {
                //AND dbo.M_Products.SubCategory = '003'
                str = "SELECT     dbo.T_Stock.StockCode, dbo.T_Stock.ProductId, dbo.M_Products.Namex, dbo.T_Stock.Stock, dbo.T_Stock.ReservedStock, dbo.M_Products.UnitPrice,dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice " +
                           "FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX " +
                           "WHERE  M_Products.Category = '" + code.Trim() + "' AND dbo.M_Products.SubCategory = '" + code2 + "' and T_Stock.Compcode = '001' AND T_Stock.Locacode = '" + loca + "'";
            }
            else if (paramtype == 4)
            {
                str = "SELECT     dbo.T_Stock.StockCode, dbo.T_Stock.ProductId, dbo.M_Products.Namex, dbo.T_Stock.Stock, dbo.T_Stock.ReservedStock, dbo.M_Products.UnitPrice,dbo.M_Products.SellingPrice, dbo.M_Products.CostPrice " +
                        "FROM         dbo.T_Stock INNER JOIN dbo.M_Products ON dbo.T_Stock.ProductId = dbo.M_Products.IDX " +
                        "WHERE  M_Products.Suplier = '" + code.Trim() + "'";
            }
            return str;
        }





    }
}
