using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


namespace smartOffice_Models
{
    /// <summary>
    /// Description : Used to connect with database and for Common functions
    /// Author : 
    /// Date : 17/08/2012
    /// </summary>
    
    public class DBConnection
    {
        //private static DBConnection instance;
        private static SqlConnection DBConn;
        public static SqlTransaction sqlTrans;

        //*For Stock
        public static string strItemCode {get; set;}
        public static string strDesc {get; set;}
        public static string strLoc { get; set; }
        public static double dblSPrice { get; set; }
        public static double dblCPrice { get; set; }
        public static double dblAvgCost { get; set; }
        public static double dblSIH { get; set; }
        public static string strCat { get; set; }
        public static string strUnit{get; set;}
        public static string strGroup  {get; set;} 
        public static string strPSize  {get; set;}
        public static string strTSize {get; set;}
        public static string strColour {get; set;}
        public static string strSupplier  {get; set;}
        public static double dblSPriceSeasonal {get; set;}
        public static double dblCPriceIndirect { get; set; }
        public static double dblUnloadQty { get; set; }
        public static string strUnloadLoc{ get; set; }
        public static string strCreditperiod { get; set; }

        //*For HRM Employee Detail 
        public static string strEmpCode { get; set; }
        public static string strEmpName { get; set; }
        public static string strEmpNIC { get; set; }
        public static string strEmpComp { get; set; }
        public static string strEmpEPF { get; set; }
        public static string strEmpDesig{ get; set; }

        //*Customer Master File
        public static string strCustomer { get; set; }

        //*Used for Menu Rights
        public static string strUserCode { get; set; }
        public static string strMenuName { get; set; }
        //public static string strMenuTag { get; set; }
        public static bool blnAccess;
        public static bool blnCreate;
        public static bool blnDelete;
        public static bool blnModify;
        public static bool blnPrint;

        //*DelBased
        public static int intTag { get; set; }
        public static double dblLoadedQty { get; set; }
        public static double dblUnloadedQty { get; set; }
        public static double dblReturnedQty { get; set; }
        public static double dblInvoicedQty { get; set; }
        public static double dblBalanceQty { get; set; }
        public static double dblCreditPeriod { get; set; }
        //*

        public static SqlCommand cmd;

        /// <summary>
        /// to return a new instance of cmd SQL Command object
        /// </summary>
        public static void getNewCommand()
        {
            cmd = new SqlCommand();
            cmd.Connection =getConnection();
            return;
        }

        /// <summary>
        /// To check whether the Database connection is exist or not  
        /// </summary>
        /// <returns> If Database connection is null then create and return DBConnection</returns>
        public static SqlConnection getConnection()
        {
            try
            {
               string strConSettings;
               if (DBConn == null)
               {
                   strConSettings=ConfigurationManager.AppSettings["DBConnectionString"].ToString();
                   DBConn = new SqlConnection(strConSettings);

                    //*Check the current state of database
                   if (DBConn.State == ConnectionState.Open)
                   {
                      // MessageBox.Show("close");
                       DBConn.Close();
                   }

                  // MessageBox.Show("opened begin!");
                  
                   DBConn.Open();
                   
                  // MessageBox.Show("opened!");
               }        
               return DBConn;  
            }
            catch (Exception ex)
            {                
                throw ex;
                //MessageBox.Show(ex.Message.ToString(), "SQL Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  return null;
            }
            
        }

        /// <summary>
        /// Get Connection String
        /// </summary>
        /// <param name="strConnection"></param>
        /// <returns>If exist get connection string, else get null</returns>
        public static string GetConnectionString(string strConnection)
        {
            try
            {
                //*Declare a string to hold the connection string  
                string sReturn = "";

                //*Check to see if they provided a connection string name  
                if (!string.IsNullOrEmpty(strConnection))
                {
                    //*Retrieve the connection string fromt he app.config  
                    sReturn = ConfigurationManager.ConnectionStrings[strConnection].ConnectionString;
                }
                else
                {
                    //*Since they didnt provide the name of the connection string  
                    //*just grab the default on from app.config  
                    sReturn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                }
                //*Return the connection string to the calling method  
                return sReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BeginTrans()
        {
            if (DBConn == null)
                getConnection();
            
            sqlTrans= DBConn.BeginTransaction();
        }

        public static void CommitTrans()
        {
            sqlTrans.Commit();
            sqlTrans = null;
        }

        public static void RollbackTrans()
        {
            sqlTrans.Rollback();
            sqlTrans = null;
        }
    

        /// <summary> 
        /// Common Function to Get Last Running Number in Transactions
        /// By : Chamila 
        /// Date : 05/10/2012
        /// </summary>
        /// <param name="strRunField">The Selected Field going to be incremented as running number for selected table</param>
        /// <param name="TableName">The table name</param>
        /// <returns>If records exist then return largest number, else return value 0(zero) </returns>
        public static string LastRunNo(string strRunField,string TableName)
        {
            try
            {
                //string strSql="Select " +strRunField+" From " +TableName+" ORDER BY " + strRunField+"";
                string strSql = "Select max (" + strRunField + ") as LastNo From " + TableName + "";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, ""+ TableName +"");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables ["" + TableName + ""].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    int intRunNo;
                    if ((DRow["LastNo"].ToString()) != "")
                    {
                        intRunNo = Convert.ToInt32(DRow["LastNo"].ToString());
                        return intRunNo.ToString();
                    }
                    else
                    {
                        intRunNo = 0;
                        return intRunNo.ToString();
                    }
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Check whether the selected Product Code is exist or not in Stock Table 
        /// By : Chamila 
        /// Date : 05/10/2012
        /// </summary>
        /// <param name="strProductCode"></param>
        /// <returns>If exist then return true else return false</returns>
        public static bool ExistItem(string strItemCode)
        {
            try
            {
                string strSql = "Select * From TBLM_STOCK where [STOCK_CODE]='" + strItemCode + "'";
                SqlCommand cmd = new SqlCommand(strSql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;

                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Exist Product Code in Stock...    ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
                throw ex;
            }
        }

        ///****SELECT DISTINCT STOCK_CODE, STOCK_LOCATION, STOCK_SIH FROM dbo.TBLM_STOCK


        /// <summary>
        /// By : Chamila 
        /// Date : 05/10/2012
        /// View Stock Detail from Stock Table belongs to selected product code
        /// </summary>
        /// <param name="strProductCode"></param>
        /// <returns>If exist then returns data rows else return null</returns>
        /// /******************************************
        //public static string ViewItemDetails1(string strItemCode)
        //{
        //    try
        //    {
        //        string strSql = "Select * From TBLM_STOCK where STOCK_CODE='" + strItemCode + "'";
        //        SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
        //        DataSet DtSet = new DataSet();
        //        DtAdapter.Fill(DtSet, "TBLM_STOCK");
        //        if (DtSet.Tables[0].Rows.Count != 0)
        //        {
        //            DataRow[] ReturnedRows;
        //            ReturnedRows = DtSet.Tables["TBLM_STOCK"].Select();
        //            DataRow DRow;
        //            DRow = ReturnedRows[0];
        //            strDesc = (DRow["STOCK_DESC"].ToString());
        //            strLoc  = ((DRow["STOCK_LOCATION"].ToString()));
        //            dblSPrice = Convert.ToDouble((DRow["STOCK_SPRICENORMAL"].ToString()));
        //            dblCPrice = Convert.ToDouble((DRow["STOCK_CPRICEDIRECT"].ToString()));
        //            dblSIH = Convert.ToDouble((DRow["STOCK_SIH"].ToString()));
        //            strCat = (DRow["STOCK_PROCATEGORY"].ToString());
        //            strUnit = (DRow["STOCK_PROCATEGORY"].ToString());
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// By : Chamila 
        /// Date : 05/10/2012
        /// View Stock Detail from Stock Table belongs to selected Item code
        /// </summary>
        /// <param name="strItemCode">Stock Code</param>
        /// <returns></returns>
        public static string ViewItemDetail(string strItemCode)
        {
            try
            {
                //string strSql = "Select * From TBLM_STOCK where STOCK_CODE='" + strItemCode + "'";
                string strSql = "SELECT distinct dbo.TBLM_STOCK.STOCK_CODE, dbo.TBLM_STOCK.STOCK_SPRICENORMAL, dbo.TBLM_STOCK.STOCK_SPRICESEASONAL, dbo.TBLM_STOCK.STOCK_CPRICEDIRECT, dbo.TBLM_STOCK.STOCK_CPRICEINDIRECT, dbo.TBLM_STOCK.STOCK_PROCATEGORY, dbo.TBLM_STOCK.STOCK_DESC,dbo.TBLM_STOCK.STOCK_PROTCATEGORY,dbo.TBLM_PRODUCT.PRODUCT_UOM,dbo.TBLM_PRODUCT.PRODUCT_CREDITPERIOD FROM         dbo.TBLM_PRODUCT INNER JOIN dbo.TBLM_STOCK ON dbo.TBLM_PRODUCT.PRODUCT_CODE = LEFT(dbo.TBLM_STOCK.STOCK_CODE, 8) where dbo.TBLM_STOCK.STOCK_CODE='" + strItemCode + "' and (dbo.TBLM_STOCK.STOCK_SPRICENORMAL!=0.00 or dbo.TBLM_STOCK.STOCK_SPRICESEASONAL!=0.00)";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_STOCK"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    strDesc = (DRow["STOCK_DESC"].ToString());
                    dblSPrice = Convert.ToDouble((DRow["STOCK_SPRICENORMAL"].ToString()));
                    dblCPrice = Convert.ToDouble((DRow["STOCK_CPRICEDIRECT"].ToString()));
                    strCat = (DRow["STOCK_PROCATEGORY"].ToString());
                    strUnit = (DRow["PRODUCT_UOM"].ToString());
                    strCreditperiod = (DRow["PRODUCT_CREDITPERIOD"].ToString());
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// View item information related to selected item code in relavant location
        /// </summary>
        /// <param name="strItemCode">Item Code</param>
        /// <param name="strLocCode">Stock Location</param>
        /// <returns>Return dataset</returns>
        public static string ViewItemDetails(string strItemCode, string strLocCode)
        {
            try
            {
                string strSql = "Select STOCK_CODE, STOCK_LOCATION, STOCK_DESC, STOCK_SIH, STOCK_SPRICENORMAL, STOCK_SPRICESEASONAL, STOCK_CPRICEDIRECT, STOCK_CPRICEINDIRECT,STOCK_AVGCOST, STOCK_PROCATEGORY, STOCK_PROGROUP, STOCK_PSIZE, STOCK_TSUPPLIER, STOCK_TCOLOR, STOCK_TSIZE,dbo.TBLM_PRODUCT.PRODUCT_UOM FROM dbo.TBLM_PRODUCT INNER JOIN dbo.TBLM_STOCK ON dbo.TBLM_PRODUCT.PRODUCT_CODE = LEFT(dbo.TBLM_STOCK.STOCK_CODE, 8) where STOCK_CODE='" + strItemCode + "' AND STOCK_LOCATION='" + strLocCode + "'";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_STOCK"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    strDesc = (DRow["STOCK_DESC"].ToString());
                    //strLoc = ((DRow["STOCK_LOCATION"].ToString()));
                    dblSPrice = Convert.ToDouble((DRow["STOCK_SPRICENORMAL"].ToString()));             
                    dblSPriceSeasonal = Convert.ToDouble((DRow["STOCK_SPRICESEASONAL"].ToString()));
                    dblCPrice = Convert.ToDouble((DRow["STOCK_CPRICEDIRECT"].ToString()));
                    dblCPriceIndirect = Convert.ToDouble((DRow["STOCK_CPRICEINDIRECT"].ToString()));
                    dblAvgCost = Convert.ToDouble((DRow["STOCK_AVGCOST"].ToString()));
                    dblSIH = Convert.ToDouble((DRow["STOCK_SIH"].ToString()));
                    strCat   = (DRow["STOCK_PROCATEGORY"].ToString());
                    strUnit  = (DRow["PRODUCT_UOM"].ToString());
                    strGroup = (DRow["STOCK_PROGROUP"].ToString());
                    strPSize = (DRow["STOCK_PSIZE"].ToString());
                    strSupplier = (DRow["STOCK_TSUPPLIER"].ToString());
                    strColour = (DRow["STOCK_TCOLOR"].ToString());
                    strTSize  = (DRow["STOCK_TSIZE"].ToString());
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Common Function to Check whether the entered employee is exist or not in the View
        /// By : Chamila 
        /// Date : 01/11/2012
        /// </summary>
        /// <param name="strEmp">Employee Code</param>
        /// <returns>If exist return true, else return false</returns>
        public static bool ExistEmployee(string strEmp)
        {
            try
            {
                string strSql = "Select * From TBLM_EMPFROMHRM where [Emp_Code]= '"+ strEmp + "'";
                SqlCommand cmd = new SqlCommand(strSql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Exist Product Code in Stock...    ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
                throw ex;
            }
        }

        /// <summary>
        /// Common Function to view employee detail in the view
        /// By : Chamila 
        /// Date : 01/11/2012 
        /// </summary>
        /// <param name="strEmpCode">Employee Code</param>
        /// <returns>If exist return record set, else return null</returns>
        public static string ViewEmployeeDetails(string strEmpCode)
        {
            try
            {
                string strSql = "Select * From TBLM_EMPFROMHRM where [Emp_Code]='" + strEmpCode + "'";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet,"TBLM_EMPFROMHRM");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_EMPFROMHRM"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    strEmpName = DRow["Emp_NameInit"].ToString();
                    strEmpNIC = DRow["Emp_NIC"].ToString();
                    strEmpComp= DRow["Emp_Comp"].ToString();
                    strEmpEPF = DRow["Emp_EPF"].ToString();
                    strEmpDesig = DRow["Des_Desc"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Common Function to get EmpCode by Emp Name
        /// </summary>
        /// <param name="strEmpCode">Employee Code</param>
        /// <returns></returns>
        public static string ViewEmployeeCode(string strEmpName)
        {
            try
            {
                string strSql = "Select * From TBLM_EMPFROMHRM where [Emp_NameInit]='" + strEmpName + "'";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_EMPFROMHRM");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_EMPFROMHRM"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    strEmpCode = DRow["Emp_Code"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Stock table SIH for selected item in selected location
        /// </summary>
        /// <param name="strItemCode"></param>
        /// <param name="dblNewSIH"></param>
        /// <param name="strLoc"></param>
        /// <returns></returns>
        public static bool UpdateStock(string strItemCode,double dblNewSIH, string strLoc)
        {
            try
            {
                string strSql = "UPDATE TBLM_STOCK SET STOCK_SIH=" + dblNewSIH + " where [STOCK_CODE]='" + strItemCode + "' and [STOCK_LOCATION]='"+ strLoc +"'";
                getNewCommand();
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Stock table SIH for selected item in selected location
        /// UPDATED 2014.11.21
        /// BY SADUN KODAGODA
        /// ADD AVARAGE COST 
        /// </summary>
        /// <param name="strItemCode"></param>
        /// <param name="dblNewSIH"></param>
        /// <param name="strLoc"></param>
        /// <returns></returns>       
        public static bool UpdateStock(string strItemCode, double dblNewSIH, string strLoc, double dblAvgCost)
        {
            try
            {
                string strSql = "UPDATE TBLM_STOCK SET STOCK_SIH=" + dblNewSIH + ", STOCK_AVGCOST=" + dblAvgCost + " where [STOCK_CODE]='" + strItemCode + "' and [STOCK_LOCATION]='" + strLoc + "'";
                getNewCommand();
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Update Stock detail table SIH for selected item in selected location
        /// for head office transaction
        /// </summary>
        /// <param name="strItemCode"></param>
        /// <param name="dblNewSIH"></param>
        /// <param name="strLoc"></param>
        /// <returns></returns>
        public static bool UpdateStockDetail(string strItemCode, double dblNewSIH, string strLoc)
        {
            try
            {
                string strSql = "UPDATE TBLM_STOCKDETAIL SET STOCK_SIH=" + dblNewSIH + " where [STOCK_CODE]='" + strItemCode + "' and [STOCK_LOCATION]='" + strLoc + "'";
                getNewCommand();
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Stock detail table SIH for selected item in selected location
        /// for head office transaction
        /// UPDATED 2014.11.21
        /// BY SADUN KODAGODA
        /// ADD AVARAGE COST
        /// </summary>
        /// <param name="strItemCode"></param>
        /// <param name="dblNewSIH"></param>
        /// <param name="strLoc"></param>
        /// <returns></returns>
        public static bool UpdateStockDetail(string strItemCode, double dblNewSIH, string strLoc,  double dblAvgCost)
        {
            try
            {
                string strSql = "UPDATE TBLM_STOCKDETAIL SET STOCK_AVGCOST =" + dblAvgCost + ",  STOCK_SIH=" + dblNewSIH + " where [STOCK_CODE]='" + strItemCode + "' and [STOCK_LOCATION]='" + strLoc + "'";
                getNewCommand();
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get Stock SIH in stock table for the selected Item Code in Selected Location
        /// </summary>
        /// <param name="strLoc">Stock Location</param>
        /// <param name="strItemCode">Item Code</param>
        /// <returns></returns>
        public static double GetSIHQty(string strLoc, string strItemCode)
        {
            try
            {
                string strSql = "SELECT STOCK_SIH AS Qty FROM TBLM_STOCK  where [STOCK_CODE]='" + strItemCode + "' and STOCK_LOCATION='" + strLoc + "'";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_STOCK"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    double dblSIHQty;
                    dblSIHQty = Convert.ToDouble(DRow["Qty"].ToString());
                    return dblSIHQty;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static double GetAvgCost(string strLoc, string strItemCode)
        {
            try
            {
                string strSql = "SELECT STOCK_AVGCOST AS [Avarage] FROM TBLM_STOCK  where [STOCK_CODE]='" + strItemCode + "' and STOCK_LOCATION='" + strLoc + "'";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_STOCK"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    double dblSIHQty;
                    dblSIHQty = Convert.ToDouble(DRow["Avarage"].ToString());
                    return dblSIHQty;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        /// <summary>
        /// To get Stock SIH in Stock detail table for the selected Item Code in Selected Location
        /// </summary>
        /// <param name="strLoc">Stock Location</param>
        /// <param name="strItemCode">Item Code</param>
        /// <returns></returns>
        public static double GetSIHQtyinStockDetail(string strLoc, string strItemCode)
        {
            try
            {
                string strSql = "SELECT STOCK_SIH AS Qty FROM TBLM_STOCKDETAIL  where [STOCK_CODE]='" + strItemCode + "' and STOCK_LOCATION='" + strLoc + "'";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_STOCK"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    double dblSIHQty;
                    dblSIHQty = Convert.ToDouble(DRow["Qty"].ToString());
                    return dblSIHQty;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


        /// <summary>
        /// Common Function to Get Stock Locations where will be the selected product code in Transfer Note
        /// </summary>
        /// <param name="strProductCode"></param>
        /// <returns></returns>
        public static DataSet LoadStockLoc(string strItemCode)
        {
            try
            {
                string strSql = "Select STOCK_LOCATION From TBLM_STOCK inner join TBLM_LOCATION ON TBLM_STOCK.STOCK_LOCATION = TBLM_LOCATION.LOCATION_CODE where STOCK_CODE='" + strItemCode + "' order by STOCK_LOCATION";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                return DtSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //***************Invoice Class************
        //public static double GetTotInvQtyInLoc(string strLoc, string strItemCode)
        //{
        //    try
        //    {
        //        string strSql = "SELECT   SUM(dbo.TBLT_DIS_INVDETAIL.INV_QTY) AS Qty FROM dbo.TBLT_DIS_INVHEADER INNER JOIN dbo.TBLT_DIS_INVDETAIL ON dbo.TBLT_DIS_INVHEADER.INV_NO = dbo.TBLT_DIS_INVDETAIL.INV_NO AND dbo.TBLT_DIS_INVHEADER.INV_LOCATION = dbo.TBLT_DIS_INVDETAIL.INV_LOCATION WHERE (dbo.TBLT_DIS_INVHEADER.ISPROCESS = 1) AND (dbo.TBLT_DIS_INVHEADER.ISCANCEL = 0) AND (dbo.TBLT_DIS_INVDETAIL.ITEM_CODE = '" + strItemCode + "') AND (dbo.TBLT_DIS_INVHEADER.INV_LOCATION = '" + strLoc + "')GROUP BY dbo.TBLT_DIS_INVHEADER.INV_LOCATION, dbo.TBLT_DIS_INVDETAIL.ITEM_CODE";
        //        SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
        //        DataSet DtSet = new DataSet();
        //        DtAdapter.Fill(DtSet, "TBLT_DIS_INVDETAIL");
        //        if (DtSet.Tables[0].Rows.Count != 0)
        //        {
        //            DataRow[] ReturnedRows;
        //            ReturnedRows = DtSet.Tables["TBLT_DIS_INVDETAIL"].Select();
        //            DataRow DRow;
        //            DRow = ReturnedRows[0];
        //            double dblTotInvQtyInLoc;
        //            if (DRow["Qty"].ToString() != "")
        //            {
        //                dblTotInvQtyInLoc = Convert.ToDouble(DRow["Qty"].ToString());
        //                return dblTotInvQtyInLoc;
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //**************************************************************

        /// <summary>
        /// Common Function to check whether the selected item is exist in stock table
        /// </summary>
        /// <param name="strItemCode">Stock Code</param>
        /// <returns>If exist return true, else return false</returns>
        public static bool ExistLocStock(string strItemCode, string strLoc)
        {
            try
            {
                string strSql = "Select * From TBLM_STOCK where [STOCK_CODE]= '" + strItemCode + "' and STOCK_LOCATION='"+strLoc+"'";
                SqlCommand cmd = new SqlCommand(strSql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), "Exist Location Stock...    ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
                throw ex;
            }
        }
        

        /// <summary>
        /// Check whether the selected item in selected location is exist in stock table
        /// </summary>
        /// <param name="strLoc"></param>
        /// <param name="strItemCode"></param>
        /// <returns></returns>
        public static bool ExistLocInStock(string strLoc, string strItemCode)
        {
            try
            {
                string strSql = "Select * From TBLM_STOCK where [STOCK_LOCATION]= '" + strLoc + "' and [STOCK_CODE]= '" + strItemCode + "' ";
                SqlCommand cmd = new SqlCommand(strSql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistLocInStockDetail(string strLoc, string strItemCode)
        {
            try
            {
                string strSql = "Select * From TBLM_STOCKDETAIL where [STOCK_LOCATION]= '" + strLoc + "' and [STOCK_CODE]= '" + strItemCode + "' ";
                SqlCommand cmd = new SqlCommand(strSql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add new item to stock table
        /// </summary>
        /// <returns></returns>
        public static bool AddItemToStock()
        {
            try
            {
                //string strSql = "INSERT INTO  TBLM_STOCK (STOCK_CODE, STOCK_LOCATION, STOCK_SIH) VALUES ('" + strItemCode + "','" + strItemLoc + "'," + dblSIH + ")";
                string strSql = "INSERT INTO  TBLM_STOCK (STOCK_CODE, STOCK_LOCATION, STOCK_DESC, STOCK_SIH, STOCK_SPRICENORMAL, STOCK_SPRICESEASONAL, STOCK_CPRICEDIRECT, STOCK_CPRICEINDIRECT,STOCK_AVGCOST, STOCK_PROCATEGORY, STOCK_PROGROUP, STOCK_PSIZE, STOCK_TSUPPLIER, STOCK_TCOLOR, STOCK_TSIZE) VALUES ('" + strItemCode + "','" + strLoc + "','" + strDesc + "'," + dblSIH + "," + dblSPrice + "," + dblSPriceSeasonal + "," + dblCPrice + "," + dblCPriceIndirect + ","+ dblAvgCost +",'" + strCat + "','" + strGroup + "'," + Convert.ToDouble(strPSize) + ",'" + strSupplier + "','" + strColour + "','" + strTSize + "')";
                getNewCommand();
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add new item to stock deatail table
        /// </summary>
        /// <returns></returns>
        public static bool AddItemToStockDetail()
        {
            try
            {
                //string strSql = "INSERT INTO  TBLM_STOCK (STOCK_CODE, STOCK_LOCATION, STOCK_SIH) VALUES ('" + strItemCode + "','" + strItemLoc + "'," + dblSIH + ")";
                string strSql = "INSERT INTO TBLM_STOCKDETAIL (STOCK_CODE, STOCK_LOCATION, STOCK_DESC, STOCK_SIH, STOCK_SPRICENORMAL, STOCK_SPRICESEASONAL, STOCK_CPRICEDIRECT, STOCK_CPRICEINDIRECT,STOCK_AVGCOST,STOCK_PROCATEGORY, STOCK_PROGROUP, STOCK_PSIZE, STOCK_TSUPPLIER, STOCK_TCOLOR, STOCK_TSIZE) VALUES ('" + strItemCode + "','" + strLoc + "','" + strDesc + "'," + dblSIH + "," + dblSPrice + "," + dblSPriceSeasonal + "," + dblCPrice + "," + dblCPriceIndirect + "," + dblAvgCost + ",'" + strCat + "','" + strGroup + "'," + Convert.ToDouble(strPSize) + ",'" + strSupplier + "','" + strColour + "','" + strTSize + "')";
                getNewCommand();
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Function to get available item quantities in stock for selected item to make requisition
        /// This will consider all location without mobile locations (consider only fixed locations)
        /// </summary>
        /// <param name="strItemCode">Stock Code</param>
        /// <returns>if exist item then returns exist qty, else returns zero(0)</returns>
        public static double GetStockQty(string strItemCode, string strLoc)
        {
            try
            {
                string strSql = "SELECT SUM(dbo.TBLM_STOCK.STOCK_SIH) AS Qty FROM dbo.TBLM_LOCATION INNER JOIN dbo.TBLM_STOCK ON dbo.TBLM_LOCATION.LOCATION_CODE = dbo.TBLM_STOCK.STOCK_LOCATION WHERE (dbo.TBLM_LOCATION.LOCATION_TYPE = 'Fixed') AND (dbo.TBLM_LOCATION.LOCATION_ACTIVE = 1) AND (dbo.TBLM_STOCK.STOCK_LOCATION <> '" + strLoc + "') AND (dbo.TBLM_STOCK.STOCK_CODE = '" + strItemCode + "')";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["TBLM_STOCK"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    double dblStockQty;
                    if (DRow["Qty"].ToString() != "")
                    {
                        dblStockQty = Convert.ToDouble(DRow["Qty"].ToString());
                        return dblStockQty;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       /// <summary>
       /// View all Items to can be unloaded in the selected location, those have SIH in stock 
       /// </summary>
       /// <param name="strLoc">Location Code</param>
       /// <returns></returns>
        public static DataSet ViewUnloadableItem(string strLoc)
        {
            try
            {
                //string strSql = "Select * From TBLT_ITEMTRANSFER_DET where [TRANS_NO]=" + intTransNo + "";
                string strSql = "SELECT TBLM_STOCK.STOCK_CODE, TBLM_STOCK.STOCK_SIH, TBLM_STOCK.STOCK_SPRICENORMAL, TBLM_STOCK.STOCK_DESC,TBLM_PRODUCT.PRODUCT_UOM FROM TBLM_STOCK INNER JOIN TBLM_PRODUCT ON LEFT(TBLM_STOCK.STOCK_CODE, 8) = TBLM_PRODUCT.PRODUCT_CODE WHERE (TBLM_STOCK.STOCK_SIH > 0) AND (TBLM_STOCK.STOCK_LOCATION = '" + strLoc + "')ORDER BY TBLM_STOCK.STOCK_CODE";
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "TBLM_STOCK");
                return DtSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Function to get customer details
        /// </summary>
        /// <param name="Cuscode">Customer code </param>
        /// <returns> customer name </returns>
        public static string Getcustomerdetails(string Cuscode)
        {
            try
            {
                string sql = "select CUSTOMER_NAME from TBLM_CUSTOMER where CUSTOMER_CODE = '" + Cuscode + "' ";
                SqlCommand cmd = new SqlCommand(sql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();

                if (DtReader.Read())
                {
                    strCustomer = Convert.ToString(DtReader[0]);
                    DtReader.Close();
                    return strCustomer;
                    
                }
                else
                {
                    DtReader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Function to get customer credit period
        /// </summary>
        /// <param name="Cuscode">Customer code </param>
        /// <returns> customer name </returns>
        public static double GetCustomerCreditPeriod(string Cuscode)
        {
            try
            {
                string sql = "select CUSTOMER_CRPERIOD from TBLM_CUSTOMER where CUSTOMER_CODE = '" + Cuscode + "' ";
                SqlCommand cmd = new SqlCommand(sql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();

                if (DtReader.Read())
                {
                    dblCreditPeriod = Convert.ToDouble(DtReader[0]);
                    DtReader.Close();
                    return dblCreditPeriod;
                }
                else
                {
                    DtReader.Close();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        /// <summary>
        /// Function to check whether the exist customer or not
        /// </summary>
        /// <param name="Cuscode">Customer code </param>
        /// <returns> if exist return true, else return false </returns>
        public static bool IsExistCustomer (string Cuscode)
        {
            try
            {
                string sql = "select CUSTOMER_NAME from TBLM_CUSTOMER where CUSTOMER_CODE = '"+ Cuscode +"' ";
                SqlCommand cmd = new SqlCommand(sql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();

                if (DtReader.Read())
                {
                    strCustomer = Convert.ToString(DtReader[0]);
                    DtReader.Close();
                    return true;

                }
                else
                {
                    DtReader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Function to check whether the selected menu right is available for the selected user for the selected interface 
        /// </summary>
        /// <param name="strUserCode">Currently logged user code</param>
        /// <param name="strMenuTag">Menu Tag for the selected interface</param>
        /// <param name="chrMenuRight">Menu right as 'A','C','D','M','P'</param>
        /// <returns>If exist menu right returns true, else returns false</returns>
        public static bool IsExistMenuRight(string strUserCode,string strMenuTag, char chrMenuRight)
        {
            try
            {
                string sql = "SELECT USERDET_USERCODE FROM TBLU_USERDET WHERE (USERDET_MENUTAG = '" + strMenuTag + "') AND (USERDET_USERCODE = '" + strUserCode + "') AND (USERDET_MENURIGHT LIKE '%" + chrMenuRight + "%')";
                SqlCommand cmd = new SqlCommand(sql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();

                if (DtReader.Read())
                {
                    strUserCode = Convert.ToString(DtReader[0]);
                    DtReader.Close();
                    return true;
                }
                else
                {
                    DtReader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Common Function to get menu tag code
        /// </summary>
        /// <param name="strMenuName">Menu name which is displaed in menu strip for each interface</param>
        /// <returns>Return many tag belongs to selected menu name</returns>
        public static string GetMenuTag(string strMenuName)
                {
                    try
                    {
                        string sql = "SELECT MENUITEM_MENUTAG FROM TBLU_MENUITEM WHERE(MENUITEM_MENUTAG LIKE 'D%') AND (MENUITEM_MENUNAME = '" + strMenuName + "')";
                        SqlCommand cmd = new SqlCommand(sql, DBConnection.getConnection());
                        SqlDataReader DtReader = cmd.ExecuteReader();

                        if (DtReader.Read())
                        {
                            string strMenuTag = Convert.ToString(DtReader[0]);
                            DtReader.Close();
                            return strMenuTag;
                        }
                        else
                        {
                            DtReader.Close();
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }


        // <summary>
        /// Common Function to get menu tag code
        /// </summary>
        /// <param name="strMenuName">Menu name which is displaed in menu strip for each interface</param>
        /// <returns>Return many tag belongs to selected menu name</returns>
        public static string GetCategoryCode(string strProductCode)
        {
            try
            {
                string sql = "SELECT PRODUCT_PROCATEGORY FROM TBLM_PRODUCT WHERE PRODUCT_CODE='" + strProductCode + "' ";
                SqlCommand cmd = new SqlCommand(sql, DBConnection.getConnection());
                SqlDataReader DtReader = cmd.ExecuteReader();

                if (DtReader.Read())
                {
                    string strCategoryCode = Convert.ToString(DtReader[0]);
                    DtReader.Close();
                    return strCategoryCode;                   
                }
                else
                {
                    DtReader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Common Function to Get Menu Rights Status
        /// </summary>
        public static void GetMenuRightsStatus()
        {
            string strMenuTag = GetMenuTag(strMenuName);

            if (DBConnection.IsExistMenuRight(strUserCode, strMenuTag, 'A') == true)
            {
                blnAccess = true;
            }
            else
            {
                blnAccess = false;
            }

            if (DBConnection.IsExistMenuRight(strUserCode, strMenuTag, 'C') == true)
            {
                blnCreate = true;
            }
            else
            {
                blnCreate = false;
            }

            if (DBConnection.IsExistMenuRight(strUserCode, strMenuTag, 'D') == true)
            {
                blnDelete = true;
            }
            else
            {
                blnDelete = false;
            }

            if (DBConnection.IsExistMenuRight(strUserCode, strMenuTag, 'M') == true)
            {
                blnModify = true;
            }
            else
            {
                blnModify = false;
            }

            if (DBConnection.IsExistMenuRight(strUserCode, strMenuTag, 'P') == true)
            {
                blnPrint = true;
            }
            else
            {
                blnPrint = false;
            }
        }

        /// <summary>
        /// Check wheather the delivery number is exist or not
        /// </summary>
        /// <param name="strDeliveryNo">The deliver number</param>
        /// <returns>If exist then returns true else retuns false</returns>
        public static bool ExistDeliveryNoInDeliveryList(string strDeliveryNo)
        {
            try
            {
                string strSql = "SELECT [LASTLOADINGNO] FROM [dbo].[TBLU_DIS_DELIVERYLIST] where DELIVERYNO='" + strDeliveryNo + "'";
                getNewCommand();
                cmd.CommandText = strSql;

                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //*//////////////////////////////////////////////////////////////////////////////////////////////////////
        //*Delivery  & Loading Wise Stock Change
        //*//////////////////////////////////////////////////////////////////////////////////////////////////////
        public static DataSet ViewLoadedItems(string strLoc,string strDelNo, string strLoadNo)
        {
            try
            {
                string strSql = " SELECT * from View_Dis_StockChange " +
                                " WHERE   Balance >0";

                if (intTag == 1)
                {
                    strSql = strSql + " AND (View_Dis_StockChange.DELIVERY_NO = '" + strDelNo + "')";
                }

                if (intTag == 0)
                {
                    strSql = strSql + " AND (View_Dis_StockChange.DELIVERY_NO = '" + strDelNo + "') AND " +
                                      " (View_Dis_StockChange.LOAD_NO = '" + strLoadNo + "')";
                }

                if (intTag == 2)
                {
                    strSql = strSql + " AND (View_Dis_StockChange.LOAD_LOCATION = '" + strLoc + "')";
                }


                strSql = strSql + " ORDER BY View_Dis_StockChange.LOAD_LOCATION, View_Dis_StockChange.DELIVERY_NO, View_Dis_StockChange.LOAD_NO, View_Dis_StockChange.ITEM_CODE";
                

                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "View_Dis_StockChange");
                return DtSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
        public static double GetStockChangedQty(string strItemCode, string strDelNo,string strLoadNo)
        {
            try
            {
                //sadun edit 2014.05.06
                //string strSql = "select  * from View_Dis_StockChange where ITEM_CODE='" + strItemCode + "' AND DELIVERY_NO='" + strDelNo + "' AND LOAD_NO='" + strLoadNo + "'";
                  string strSql = "select DISTINCT * from View_Dis_StockChange where ITEM_CODE='" + strItemCode + "' AND DELIVERY_NO='" + strDelNo + "' AND LOAD_NO='" + strLoadNo + "'";

                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "View_Dis_StockChange");
                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["View_Dis_StockChange"].Select();
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    dblLoadedQty   = Convert.ToDouble(DRow["Loading"].ToString());
                    dblUnloadedQty = Convert.ToDouble(DRow["Unloading"].ToString());
                    dblReturnedQty = Convert.ToDouble(DRow["Returns"].ToString());
                    dblInvoicedQty = Convert.ToDouble(DRow["Invoicing"].ToString());
                    dblBalanceQty  = Convert.ToDouble(DRow["Balance"].ToString());
                    
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        public static double GetStockChangedQty(string strItemCode, string strDelNo, string strLoadNo)
        {
            try
            {
                //sadun edit 2014.05.06
                //string strSql = "select  * from View_Dis_StockChange where ITEM_CODE='" + strItemCode + "' AND DELIVERY_NO='" + strDelNo + "' AND LOAD_NO='" + strLoadNo + "'";
                string strSql = "select DISTINCT * from View_Dis_StockChange where ITEM_CODE='" + strItemCode + "' AND DELIVERY_NO='" + strDelNo + "' AND LOAD_NO='" + strLoadNo + "'";
               
                //string strSql = "SELECT ITEM_CODE, DESCRIPTION, SUM(QTY) AS QTY, SPRICE, UNIT, LOAD_LOCATION, DELIVERY_NO, LOAD_NO ,STOCK_LOCATION FROM TBLT_ITEMLOAD_DET  " +
                //                " where ITEM_CODE='" + strItemCode + "' AND DELIVERY_NO='" + strDelNo + "' AND LOAD_NO='" + strLoadNo + "'"+
                //                " GROUP BY ITEM_CODE, DESCRIPTION, SPRICE, UNIT, QTY, LOAD_LOCATION, DELIVERY_NO, LOAD_NO, STOCK_LOCATION";

               
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataSet DtSet = new DataSet();
                DtAdapter.Fill(DtSet, "View_Dis_StockChange");
               // DtAdapter.Fill(DtSet);

                //DataTable dt = new DataTable();

                //dt = DtSet.Tables[0];

                if (DtSet.Tables[0].Rows.Count != 0)
                {
                    DataRow[] ReturnedRows;
                    ReturnedRows = DtSet.Tables["View_Dis_StockChange"].Select();
                   
                    DataRow DRow;
                    DRow = ReturnedRows[0];
                    dblLoadedQty = Convert.ToDouble(DRow["Loading"].ToString());
                    dblUnloadedQty = Convert.ToDouble(DRow["Unloading"].ToString());
                    dblReturnedQty = Convert.ToDouble(DRow["Returns"].ToString());
                    dblInvoicedQty = Convert.ToDouble(DRow["Invoicing"].ToString());
                    dblBalanceQty = Convert.ToDouble(DRow["Balance"].ToString());

                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool IsUnloadableDel(string strDelNo)
        {
            try
            {
                string strSql = "SELECT DELIVERY_NO FROM  View_Dis_StockChange WHERE DELIVERY_NO='" + strDelNo + "' AND Balance>0";
                getNewCommand();
                cmd.CommandText = strSql;

                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsUnloadableLoading(string strDelNo,string strLoadNo)
        {
            try
            {
                string strSql = "SELECT DELIVERY_NO FROM  View_Dis_StockChange WHERE DELIVERY_NO='" + strDelNo + "' AND LOAD_NO='"+strLoadNo+"' AND Balance>0";
                getNewCommand();
                cmd.CommandText = strSql;

                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsExistDelforLoc(string strLoc, string strDelNo)
        {
            try
            {
                string strSql = "SELECT DELIVERY_NO FROM  TBLT_ITEMLOAD_HED WHERE LOAD_LOCATION='" + strLoc + "' AND DELIVERY_NO='" + strDelNo + "'";
                getNewCommand();
                cmd.CommandText = strSql;

                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool IsExistLoadingForDel(string strDelNo,string strLoadNo)
        {
            try
            {
                string strSql = "SELECT DELIVERY_NO FROM  TBLT_ITEMLOAD_HED WHERE DELIVERY_NO='" + strDelNo + "' AND LOAD_NO='"+strLoadNo+"' ";
                getNewCommand();
                cmd.CommandText = strSql;

                SqlDataReader DtReader = cmd.ExecuteReader();
                if (DtReader.Read())
                {
                    DtReader.Close();
                    return true;
                }
                DtReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDataTable(string strSql)
        {
            try
            {                
                SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
                DataTable Dt = new DataTable();
                DtAdapter.Fill(Dt);

                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




     //   /// <summary>
     //   /// Loading Qty(+) to Location
     //   /// </summary>
     //   /// <param name="strItemCode"></param>
     //   /// <param name="strDelNo"></param>
     //   /// <param name="strLoadNo"></param>
     //   /// <returns></returns>
     //   public static double GetLoadPlusQty(string strItemCode, string strDelNo,string strLoadNo)
     //   {
     //       try
     //       {
     //           string strSql = "  SELECT dbo.TBLT_ITEMLOAD_HED.TRANSPORT_LOCATION, "+
     //                           " dbo.TBLT_ITEMLOAD_DET.ITEM_CODE, SUM(dbo.TBLT_ITEMLOAD_DET.QTY) AS LoadQty,"+
     //                           " dbo.TBLT_ITEMLOAD_DET.DELIVERY_NO, dbo.TBLT_ITEMLOAD_DET.LOAD_NO "+ 
     //                           " FROM dbo.TBLT_ITEMLOAD_DET INNER JOIN dbo.TBLT_ITEMLOAD_HED ON "+
     //                           " dbo.TBLT_ITEMLOAD_DET.LOAD_NO = dbo.TBLT_ITEMLOAD_HED.LOAD_NO AND "+
     //                           " dbo.TBLT_ITEMLOAD_DET.DELIVERY_NO = dbo.TBLT_ITEMLOAD_HED.DELIVERY_NO "+
     //                           /* " AND dbo.TBLT_ITEMLOAD_DET.TRANSPORT_LOCATION = dbo.TBLT_ITEMLOAD_HED.TRANSPORT_LOCATION "+ */
     //                           " WHERE(dbo.TBLT_ITEMLOAD_HED.ISPROCESS = 1) AND (dbo.TBLT_ITEMLOAD_HED.ISCANCEL = 0)"+
     //                           " AND dbo.TBLT_ITEMLOAD_DET.ITEM_CODE='" + strItemCode + "' AND dbo.TBLT_ITEMLOAD_DET.DELIVERY_NO ='" + strDelNo + "' AND dbo.TBLT_ITEMLOAD_DET.LOAD_NO='" + strLoadNo + "' " +
     //                           " GROUP BY dbo.TBLT_ITEMLOAD_DET.ITEM_CODE, dbo.TBLT_ITEMLOAD_HED.TRANSPORT_LOCATION,"+
     //                           " dbo.TBLT_ITEMLOAD_DET.DELIVERY_NO, dbo.TBLT_ITEMLOAD_DET.LOAD_NO";

     //           SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
     //           DataSet DtSet = new DataSet();
     //           DtAdapter.Fill(DtSet, "TBLT_ITEMLOAD_HED");
     //           if (DtSet.Tables[0].Rows.Count != 0)
     //           {
     //               DataRow[] ReturnedRows;
     //               ReturnedRows = DtSet.Tables["TBLT_ITEMLOAD_HED"].Select();
     //               DataRow DRow;
     //               DRow = ReturnedRows[0];
     //               double dblLoadPlusQty;
     //               dblLoadPlusQty = Convert.ToDouble(DRow["LoadQty"].ToString());
     //               return dblLoadPlusQty;
     //           }
     //           else
     //           {
     //               return 0;
     //           }
     //       }
     //       catch (Exception ex)
     //       {
     //           throw ex;
     //       }
     //   }


     ////public static double GetLoadMinusQty(string strItemCode, string strDelNo,string strLoadNo)
     ////   {
     ////       try
     ////       {
     ////           string strSql = " SELECT dbo.TBLT_ITEMLOAD_DET.STOCK_LOCATION, dbo.TBLT_ITEMLOAD_DET.ITEM_CODE, "+
     ////                           " SUM(dbo.TBLT_ITEMLOAD_DET.QTY) AS LoadMinusQty,dbo.TBLT_ITEMLOAD_DET.DELIVERY_NO, "+  
     ////                           " dbo.TBLT_ITEMLOAD_DET.LOAD_NO FROM dbo.TBLT_ITEMLOAD_DET INNER JOIN "+
     ////                           " dbo.TBLT_ITEMLOAD_HED ON dbo.TBLT_ITEMLOAD_DET.LOAD_NO = dbo.TBLT_ITEMLOAD_HED.LOAD_NO AND  "+
     ////                           " dbo.TBLT_ITEMLOAD_DET.TRANSPORT_LOCATION = dbo.TBLT_ITEMLOAD_HED.TRANSPORT_LOCATION "+
     ////                           " WHERE (dbo.TBLT_ITEMLOAD_HED.ISPROCESS = 1) AND (dbo.TBLT_ITEMLOAD_HED.ISCANCEL = 0) "+
     ////                           " AND dbo.TBLT_ITEMLOAD_DET.ITEM_CODE='" + strItemCode + "' AND dbo.TBLT_ITEMLOAD_DET.DELIVERY_NO ='" + strDelNo + "' AND dbo.TBLT_ITEMLOAD_DET.LOAD_NO='" + strLoadNo + "' " +
     ////                           " GROUP BY dbo.TBLT_ITEMLOAD_DET.ITEM_CODE,dbo.TBLT_ITEMLOAD_DET.STOCK_LOCATION, "+
     ////                           " dbo.TBLT_ITEMLOAD_DET.DELIVERY_NO, dbo.TBLT_ITEMLOAD_DET.LOAD_NO ";

     ////           SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
     ////           DataSet DtSet = new DataSet();
     ////           DtAdapter.Fill(DtSet, "TBLT_ITEMLOAD_HED");
     ////           if (DtSet.Tables[0].Rows.Count != 0)
     ////           {
     ////               DataRow[] ReturnedRows;
     ////               ReturnedRows = DtSet.Tables["TBLT_ITEMLOAD_HED"].Select();
     ////               DataRow DRow;
     ////               DRow = ReturnedRows[0];
     ////               double dblLoadMinusQty;
     ////               dblLoadMinusQty = Convert.ToDouble(DRow["LoadMinusQty"].ToString());
     ////               return dblLoadMinusQty;
     ////           }
     ////           else
     ////           {
     ////               return 0;
     ////           }
     ////       }
     ////       catch (Exception ex)
     ////       {
     ////           throw ex;
     ////       }
     ////   }


     ////public static double GetUnloadPlusQty(string strItemCode, string strDelNo, string strLoadNo)
     ////{
     ////    try
     ////    {
     ////        string strSql = " SELECT dbo.TBLT_ITEMUNLOAD_DET.ITEM_CODE, SUM(dbo.TBLT_ITEMUNLOAD_DET.QTY) AS UnloadPlusQty,"+ 
     ////                        " dbo.TBLT_ITEMUNLOAD_DET.ITEM_LOCATION,dbo.TBLT_ITEMUNLOAD_DET.DELIVERY_NO,dbo.TBLT_ITEMUNLOAD_DET.LOAD_NO "+ 
     ////                        " FROM dbo.TBLT_ITEMUNLOAD_DET INNER JOIN "+ 
     ////                        " dbo.TBLT_ITEMUNLOAD_HED ON dbo.TBLT_ITEMUNLOAD_DET.UNLOAD_NO = dbo.TBLT_ITEMUNLOAD_HED.UNLOAD_NO AND  "+ 
     ////                        " dbo.TBLT_ITEMUNLOAD_DET.UNLOAD_LOCATION = dbo.TBLT_ITEMUNLOAD_HED.UNLOAD_LOCATION "+ 
     ////                        " WHERE(dbo.TBLT_ITEMUNLOAD_HED.ISCANCEL = 0) AND (dbo.TBLT_ITEMUNLOAD_HED.ISPROCESS = 1) "+
     ////                        " AND dbo.TBLT_ITEMUNLOAD_DET.ITEM_CODE='" + strItemCode + "' AND dbo.TBLT_ITEMUNLOAD_DET.DELIVERY_NO ='" + strDelNo + "' AND dbo.TBLT_ITEMUNLOAD_DET.LOAD_NO='" + strLoadNo + "'  " +
     ////                        " GROUP BY dbo.TBLT_ITEMUNLOAD_DET.ITEM_CODE, dbo.TBLT_ITEMUNLOAD_DET.ITEM_LOCATION, " + 
     ////                        " dbo.TBLT_ITEMUNLOAD_DET.DELIVERY_NO,dbo.TBLT_ITEMUNLOAD_DET.LOAD_NO ";

     ////        SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
     ////        DataSet DtSet = new DataSet();
     ////        DtAdapter.Fill(DtSet, "TBLT_ITEMUNLOAD_HED");
     ////        if (DtSet.Tables[0].Rows.Count != 0)
     ////        {
     ////            DataRow[] ReturnedRows;
     ////            ReturnedRows = DtSet.Tables["TBLT_ITEMUNLOAD_HED"].Select();
     ////            DataRow DRow;
     ////            DRow = ReturnedRows[0];
     ////            double dblUnloadPlusQty;
     ////            dblUnloadPlusQty = Convert.ToDouble(DRow["UnloadPlusQty"].ToString());
     ////            return dblUnloadPlusQty;
     ////        }
     ////        else
     ////        {
     ////            return 0;
     ////        }
     ////    }
     ////    catch (Exception ex)
     ////    {
     ////        throw ex;
     ////    }
     ////}

     //public static double GetUnloadMinusQty(string strItemCode, string strDelNo, string strLoadNo)
     //{
     //    try
     //    {
     //        string strSql = " SELECT dbo.TBLT_ITEMUNLOAD_HED.UNLOAD_LOCATION, "+
     //                        " dbo.TBLT_ITEMUNLOAD_DET.ITEM_CODE, SUM(dbo.TBLT_ITEMUNLOAD_DET.QTY) AS UnloadQty,"+
     //                        " dbo.TBLT_ITEMUNLOAD_DET.DELIVERY_NO,dbo.TBLT_ITEMUNLOAD_DET.LOAD_NO "+
     //                        " FROM dbo.TBLT_ITEMUNLOAD_DET INNER JOIN dbo.TBLT_ITEMUNLOAD_HED ON  "+
     //                        " dbo.TBLT_ITEMUNLOAD_DET.UNLOAD_NO = dbo.TBLT_ITEMUNLOAD_HED.UNLOAD_NO  "+
     //                        /*" AND dbo.TBLT_ITEMUNLOAD_DET.DELIVERY_NO = dbo.TBLT_ITEMUNLOAD_HED.DELIVERY_NO AND " +
     //                        " dbo.TBLT_ITEMUNLOAD_DET.LOAD_NO = dbo.TBLT_ITEMUNLOAD_HED.LOAD_NO  " +
     //                         " AND dbo.TBLT_ITEMUNLOAD_DET.UNLOAD_LOCATION = dbo.TBLT_ITEMUNLOAD_HED.UNLOAD_LOCATION "+ */
     //                        " WHERE (dbo.TBLT_ITEMUNLOAD_HED.ISCANCEL = 0) AND (dbo.TBLT_ITEMUNLOAD_HED.ISPROCESS = 1) "+
     //                        " AND dbo.TBLT_ITEMUNLOAD_DET.ITEM_CODE='" + strItemCode + "' AND dbo.TBLT_ITEMUNLOAD_DET.DELIVERY_NO ='" + strDelNo + "' AND dbo.TBLT_ITEMUNLOAD_DET.LOAD_NO='" + strLoadNo + "'  " +
     //                        " GROUP BY dbo.TBLT_ITEMUNLOAD_HED.UNLOAD_LOCATION, dbo.TBLT_ITEMUNLOAD_DET.ITEM_CODE, " +
     //                        " dbo.TBLT_ITEMUNLOAD_DET.DELIVERY_NO,dbo.TBLT_ITEMUNLOAD_DET.LOAD_NO ";

     //        SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
     //        DataSet DtSet = new DataSet();
     //        DtAdapter.Fill(DtSet, "TBLT_ITEMUNLOAD_HED");
     //        if (DtSet.Tables[0].Rows.Count != 0)
     //        {
     //            DataRow[] ReturnedRows;
     //            ReturnedRows = DtSet.Tables["TBLT_ITEMUNLOAD_HED"].Select();
     //            DataRow DRow;
     //            DRow = ReturnedRows[0];
     //            double dblUnloadMinusQty;
     //            dblUnloadMinusQty = Convert.ToDouble(DRow["UnloadQty"].ToString());
     //            return dblUnloadMinusQty;
     //        }
     //        else
     //        {
     //            return 0;
     //        }
     //    }
     //    catch (Exception ex)
     //    {
     //        throw ex;
     //    }
     //}

     //public static double GetInvoicedQty(string strItemCode, string strDelNo, string strLoadNo)
     //{
     //    try
     //    {
     //        string strSql = " SELECT    dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ITEMCODE,  "+
     //                        " dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_LOCATIONMOBILE, "+  
     //                        " SUM(dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_QTY) AS InvQty, dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO, dbo.TBLT_DIS_INVDETAIL.LOAD_NO "+
     //                        " FROM dbo.TBLT_DIS_INVDETAIL INNER JOIN  dbo.TBLT_DIS_INVHEADER ON "+
     //                        " dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_INVNO = dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_INVNO  "+
     //                        /* "  AND dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO = dbo.TBLT_DIS_INVHEADER.DELIVERY_NO  AND " +
     //                        " dbo.TBLT_DIS_INVDETAIL.LOAD_NO = dbo.TBLT_DIS_INVHEADER.LOAD_NO "+ */
     //                        " WHERE (dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ISVOID = 0) AND (dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_ISHOLD = 0) AND  "+
     //                        " dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ITEMCODE='" + strItemCode + "' AND dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO ='" + strDelNo + "' AND dbo.TBLT_DIS_INVDETAIL.LOAD_NO='" + strLoadNo + "'  " +
     //                        " AND (dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_ISCANCEL = 0) AND (NOT (dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_INVNO LIKE '%c%')) "+
     //                        " GROUP BY  dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_LOCATIONMOBILE, dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ITEMCODE, " +
     //                        " dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO,dbo.TBLT_DIS_INVDETAIL.LOAD_NO";

     //        SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
     //        DataSet DtSet = new DataSet();
     //        DtAdapter.Fill(DtSet, "TBLT_DIS_INVHEADER");
     //        if (DtSet.Tables[0].Rows.Count != 0)
     //        {
     //            DataRow[] ReturnedRows;
     //            ReturnedRows = DtSet.Tables["TBLT_DIS_INVHEADER"].Select();
     //            DataRow DRow;
     //            DRow = ReturnedRows[0];
     //            double dblInvoicedQty;
     //            dblInvoicedQty = Convert.ToDouble(DRow["InvQty"].ToString());
     //            return dblInvoicedQty;
     //        }
     //        else
     //        {
     //            return 0;
     //        }
     //    }
     //    catch (Exception ex)
     //    {
     //        throw ex;
     //    }
     //}


     //public static double GetReturnedQty(string strItemCode, string strDelNo, string strLoadNo)
     //{
     //    try
     //    {
     //        string strSql = " SELECT    dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ITEMCODE,  " +
     //                        " dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_LOCATIONMOBILE, " +
     //                        " SUM(dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_QTY) AS ReturnedQty, dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO, dbo.TBLT_DIS_INVDETAIL.LOAD_NO " +
     //                        " FROM dbo.TBLT_DIS_INVDETAIL INNER JOIN  dbo.TBLT_DIS_INVHEADER ON " +
     //                        " dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_INVNO = dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_INVNO " +
     //                        /* " AND dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO = dbo.TBLT_DIS_INVHEADER.DELIVERY_NO  AND " +
     //                        " dbo.TBLT_DIS_INVDETAIL.LOAD_NO = dbo.TBLT_DIS_INVHEADER.LOAD_NO " + */
     //                        " WHERE (dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ISVOID = 0) AND (dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_ISHOLD = 0) " +
     //                        " AND dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ITEMCODE='" + strItemCode + "' AND dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO ='" + strDelNo + "' AND dbo.TBLT_DIS_INVDETAIL.LOAD_NO='" + strLoadNo + "'  " +
     //                        " AND (dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_ISCANCEL = 0) AND (dbo.TBLT_DIS_INVHEADER.DIS_INVHEADER_INVNO LIKE '%c%') " +
     //                        " GROUP BY  dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_LOCATIONMOBILE, dbo.TBLT_DIS_INVDETAIL.DIS_INVDET_ITEMCODE, " +
     //                        " dbo.TBLT_DIS_INVDETAIL.DELIVERY_NO,dbo.TBLT_DIS_INVDETAIL.LOAD_NO";

     //        SqlDataAdapter DtAdapter = new SqlDataAdapter(strSql, DBConnection.getConnection());
     //        DataSet DtSet = new DataSet();
     //        DtAdapter.Fill(DtSet, "TBLT_DIS_INVHEADER");
     //        if (DtSet.Tables[0].Rows.Count != 0)
     //        {
     //            DataRow[] ReturnedRows;
     //            ReturnedRows = DtSet.Tables["TBLT_DIS_INVHEADER"].Select();
     //            DataRow DRow;
     //            DRow = ReturnedRows[0];
     //            double dblReturnedQty;
     //            dblReturnedQty = Convert.ToDouble(DRow["ReturnedQty"].ToString());
     //            return dblReturnedQty;
     //        }
     //        else
     //        {
     //            return 0;
     //        }
     //    }
     //    catch (Exception ex)
     //    {
     //        throw ex;
     //    }
     //}






    }
}
