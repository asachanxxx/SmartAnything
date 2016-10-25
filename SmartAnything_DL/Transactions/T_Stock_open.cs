using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_Stock_openDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_Stock_open table.
        /// </summary>
        public Boolean Savet_Stock_openSP(T_Stock_open t_Stock_open, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_Stock_openSave";
                scom.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = t_Stock_open.DocNo;
                scom.Parameters.Add("@StockCode", SqlDbType.VarChar, 20).Value = t_Stock_open.StockCode;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = t_Stock_open.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = t_Stock_open.Locacode;
                scom.Parameters.Add("@Suppid", SqlDbType.VarChar, 20).Value = t_Stock_open.Suppid;
                scom.Parameters.Add("@ProductId", SqlDbType.VarChar, 20).Value = t_Stock_open.ProductId;
                scom.Parameters.Add("@Stock", SqlDbType.Decimal, 9).Value = t_Stock_open.Stock;
                scom.Parameters.Add("@OpnStock", SqlDbType.Decimal, 9).Value = t_Stock_open.OpnStock;
                scom.Parameters.Add("@InitialStock", SqlDbType.Decimal, 9).Value = t_Stock_open.InitialStock;
                scom.Parameters.Add("@ReservedStock", SqlDbType.Decimal, 9).Value = t_Stock_open.ReservedStock;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = t_Stock_open.CostPrice;
                scom.Parameters.Add("@SellingPrice", SqlDbType.Decimal, 9).Value = t_Stock_open.SellingPrice;
                scom.Parameters.Add("@WholeSalePrice", SqlDbType.Decimal, 9).Value = t_Stock_open.WholeSalePrice;
                scom.Parameters.Add("@MrpPrice", SqlDbType.Decimal, 9).Value = t_Stock_open.MrpPrice;
                scom.Parameters.Add("@CompanyPrice", SqlDbType.Decimal, 9).Value = t_Stock_open.CompanyPrice;
                scom.Parameters.Add("@AvgCost", SqlDbType.Decimal, 9).Value = t_Stock_open.AvgCost;
                scom.Parameters.Add("@InitialCost", SqlDbType.Decimal, 9).Value = t_Stock_open.InitialCost;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 150).Value = t_Stock_open.Descr;
                scom.Parameters.Add("@FixedGP", SqlDbType.Decimal, 9).Value = t_Stock_open.FixedGP;
                scom.Parameters.Add("@SIH", SqlDbType.Decimal, 9).Value = t_Stock_open.SIH;
                scom.Parameters.Add("@EXPDate", SqlDbType.DateTime, 8).Value = t_Stock_open.EXPDate;
                scom.Parameters.Add("@Usercode", SqlDbType.VarChar, 20).Value = t_Stock_open.Usercode;
                scom.Parameters.Add("@DateCr", SqlDbType.DateTime, 8).Value = t_Stock_open.DateCr;
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


        public DataTable SelectAllt_Stock_open()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_Stock_open]";
                DataTable dtt_Stock_open = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_Stock_open;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_Stock_open Selectt_Stock_open(T_Stock_open objt_Stock_open)
        {
            try
            {
                strquery = @"select * from t_Stock_open where StockCode = '" + objt_Stock_open.StockCode + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_Stock_open.DocNo = drType["DocNo"].ToString();
                    objt_Stock_open.StockCode = drType["StockCode"].ToString();
                    objt_Stock_open.Compcode = drType["Compcode"].ToString();
                    objt_Stock_open.Locacode = drType["Locacode"].ToString();
                    objt_Stock_open.Suppid = drType["Suppid"].ToString();
                    objt_Stock_open.ProductId = drType["ProductId"].ToString();
                    objt_Stock_open.Stock = decimal.Parse(drType["Stock"].ToString());
                    objt_Stock_open.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                    objt_Stock_open.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                    objt_Stock_open.ReservedStock = decimal.Parse(drType["ReservedStock"].ToString());
                    objt_Stock_open.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_Stock_open.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objt_Stock_open.WholeSalePrice = decimal.Parse(drType["WholeSalePrice"].ToString());
                    objt_Stock_open.MrpPrice = decimal.Parse(drType["MrpPrice"].ToString());
                    objt_Stock_open.CompanyPrice = decimal.Parse(drType["CompanyPrice"].ToString());
                    objt_Stock_open.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                    objt_Stock_open.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                    objt_Stock_open.Descr = drType["Descr"].ToString();
                    objt_Stock_open.FixedGP = decimal.Parse(drType["FixedGP"].ToString());
                    objt_Stock_open.SIH = decimal.Parse(drType["SIH"].ToString());
                    objt_Stock_open.EXPDate = DateTime.Parse(drType["EXPDate"].ToString());
                    objt_Stock_open.Usercode = drType["Usercode"].ToString();
                    objt_Stock_open.DateCr = DateTime.Parse(drType["DateCr"].ToString());
                    return objt_Stock_open;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_Stock_open(string stringt_Stock_open)
        {
            try
            {
                string xstrquery = @"select StockCode From T_Stock_open   WHERE StockCode = '" + stringt_Stock_open + "' ";
                DataRow drT_Stock_open = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Stock_open != null)
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

        public List<T_Stock_open> SelectT_Stock_openMulti(T_Stock_open objt_Stock_open2)
        {
            List<T_Stock_open> retval = new List<T_Stock_open>();
            try
            {
                strquery = @"select * from t_Stock_open where DocNo = '" + objt_Stock_open2.DocNo + "'";
                DataTable dtt_Stock_open = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_Stock_open.Rows)
                {
                    if (drType != null)
                    {
                        T_Stock_open objt_Stock_open = new T_Stock_open();
                        objt_Stock_open.DocNo = drType["DocNo"].ToString();
                        objt_Stock_open.StockCode = drType["StockCode"].ToString();
                        objt_Stock_open.Compcode = drType["Compcode"].ToString();
                        objt_Stock_open.Locacode = drType["Locacode"].ToString();
                        objt_Stock_open.Suppid = drType["Suppid"].ToString();
                        objt_Stock_open.ProductId = drType["ProductId"].ToString();
                        objt_Stock_open.Stock = decimal.Parse(drType["Stock"].ToString());
                        objt_Stock_open.OpnStock = decimal.Parse(drType["OpnStock"].ToString());
                        objt_Stock_open.InitialStock = decimal.Parse(drType["InitialStock"].ToString());
                        objt_Stock_open.ReservedStock = decimal.Parse(drType["ReservedStock"].ToString());
                        objt_Stock_open.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                        objt_Stock_open.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                        objt_Stock_open.WholeSalePrice = decimal.Parse(drType["WholeSalePrice"].ToString());
                        objt_Stock_open.MrpPrice = decimal.Parse(drType["MrpPrice"].ToString());
                        objt_Stock_open.CompanyPrice = decimal.Parse(drType["CompanyPrice"].ToString());
                        objt_Stock_open.AvgCost = decimal.Parse(drType["AvgCost"].ToString());
                        objt_Stock_open.InitialCost = decimal.Parse(drType["InitialCost"].ToString());
                        objt_Stock_open.Descr = drType["Descr"].ToString();
                        objt_Stock_open.FixedGP = decimal.Parse(drType["FixedGP"].ToString());
                        objt_Stock_open.SIH = decimal.Parse(drType["SIH"].ToString());
                        objt_Stock_open.EXPDate = DateTime.Parse(drType["EXPDate"].ToString());
                        objt_Stock_open.Usercode = drType["Usercode"].ToString();
                        objt_Stock_open.DateCr = DateTime.Parse(drType["DateCr"].ToString());
                        retval.Add(objt_Stock_open);
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
