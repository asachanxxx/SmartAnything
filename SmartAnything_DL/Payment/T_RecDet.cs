using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_RecDetDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_RecDet table.
        /// </summary>
        public Boolean Savet_RecDetSP(T_RecDet t_RecDet, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_RecDetSave";

                scom.Parameters.Add("@Docno", SqlDbType.VarChar, 10).Value = t_RecDet.Docno;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 10).Value = t_RecDet.locationId;
                scom.Parameters.Add("@Sequence", SqlDbType.Int, 4).Value = t_RecDet.Sequence;
                scom.Parameters.Add("@Paytype", SqlDbType.VarChar, 20).Value = t_RecDet.Paytype;
                scom.Parameters.Add("@HeadAmt", SqlDbType.Decimal, 9).Value = t_RecDet.HeadAmt;
                scom.Parameters.Add("@Amt", SqlDbType.Decimal, 9).Value = t_RecDet.Amt;
                scom.Parameters.Add("@InvNo", SqlDbType.VarChar, 20).Value = t_RecDet.InvNo;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_RecDet.Datex;
                scom.Parameters.Add("@CQno", SqlDbType.VarChar, 20).Value = t_RecDet.CQno;
                scom.Parameters.Add("@Bank", SqlDbType.VarChar, 20).Value = t_RecDet.Bank;
                scom.Parameters.Add("@BankBranch", SqlDbType.VarChar, 20).Value = t_RecDet.BankBranch;
                scom.Parameters.Add("@BankDate", SqlDbType.DateTime, 8).Value = t_RecDet.BankDate;
                scom.Parameters.Add("@isReconsile", SqlDbType.Bit, 1).Value = t_RecDet.isReconsile;
                scom.Parameters.Add("@ReconsileDate", SqlDbType.DateTime, 8).Value = t_RecDet.ReconsileDate;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_RecDet.Customer;
                scom.Parameters.Add("@isreturned", SqlDbType.Bit, 1).Value = t_RecDet.isreturned;
                scom.Parameters.Add("@ReturnDate", SqlDbType.DateTime, 8).Value = t_RecDet.ReturnDate;
                scom.Parameters.Add("@ReturnUpdateUSer", SqlDbType.VarChar, 20).Value = t_RecDet.ReturnUpdateUSer;
                scom.Parameters.Add("@ReasontoRtn", SqlDbType.VarChar, 120).Value = t_RecDet.ReasontoRtn;
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


        public DataTable SelectAllt_RecDet()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_RecDet]";
                DataTable dtt_RecDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_RecDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCQ(string customer,bool daterange, bool ispostdated ,bool isretured, bool isunrealized, bool realized, DateTime todate, DateTime fromdate)
        {
            string strquery1 = "";
            try
            {
                strquery1 = "SELECT     dbo.T_RecDet.Docno AS [Receipt No], dbo.T_RecDet.CQno AS [Cheque No], Amt AS 'Amount', dbo.T_RecDet.Bank, dbo.M_Bank.BANK_NAME AS [Bank Name],dbo.T_RecDet.BankBranch AS Branch, dbo.T_RecDet.BankDate AS [Bank Date], dbo.T_RecDet.isReconsile AS Reconsiled, dbo.T_RecDet.isreturned AS Returned ,'' as 'Reason To Return'   FROM dbo.T_RecDet INNER JOIN dbo.M_Bank ON dbo.T_RecDet.Bank = dbo.M_Bank.BANK_CODE WHERE (dbo.T_RecDet.Paytype = 'CQ') ";
                            //"AND (dbo.T_RecDet.BankDate BETWEEN CONVERT(DATETIME, '" + fromdate.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + todate.ToShortDateString() + "', 103)) ";

                if (customer.Trim() != "")
                {
                    strquery1 += "AND (dbo.T_RecDet.Customer = '" + customer.Trim() + "') ";
                    if (daterange == true)
                    {
                        strquery1 += " AND (dbo.T_RecDet.BankDate BETWEEN CONVERT(DATETIME, '" + fromdate.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + todate.ToShortDateString() + "', 103)) ";

                    }
                    if (isunrealized == true) // calculation based on bankdate - today < 0
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";

                    }
                    if (isretured == true)
                    {
                        strquery1 += "AND (dbo.T_RecDet.isreturned = 1) ";
                    }
                    if (ispostdated == true)
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                    }
                    if (realized == true) //Calculation based on bankdate - today >0
                    {
                        strquery1 += "AND (dbo.T_RecDet.isReconsile = 1) ";
                    }

                }
                else
                {
                    if (daterange == true)
                    {
                        strquery1 += " AND (dbo.T_RecDet.BankDate BETWEEN CONVERT(DATETIME, '" + fromdate.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + todate.ToShortDateString() + "', 103)) "; 

                    }
                    if (isunrealized == true) // calculation based on bankdate - today < 0
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";

                    }
                    if (isretured == true)
                    {
                        strquery1 += "AND (dbo.T_RecDet.isreturned = 1) ";
                    }
                    if (ispostdated == true)
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                    }
                    if (realized == true) //Calculation based on bankdate - today >0
                    {
                        strquery1 += "AND (dbo.T_RecDet.isReconsile = 1) ";
                    }
                }
                DataTable dtt_RecDet = u_DBConnection.ReturnDataTable(strquery1, CommandType.Text);
                return dtt_RecDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetCQForPrint(string customer, bool daterange, bool ispostdated, bool isretured, bool isunrealized, bool realized, DateTime todate, DateTime fromdate)
        {
            string strquery1 = "";
            try
            {
                strquery1 = "SELECT     dbo.T_RecDet.Docno AS [Receipt No], dbo.T_RecDet.CQno AS [Cheque No], dbo.T_RecDet.Bank, dbo.M_Bank.BANK_NAME AS [Bank Name],dbo.T_RecDet.BankBranch AS Branch, dbo.T_RecDet.BankDate AS [Bank Date], dbo.T_RecDet.isReconsile AS Reconsiled, dbo.T_RecDet.isreturned AS Returned ,'' as 'Reason To Return'   FROM dbo.T_RecDet INNER JOIN dbo.M_Bank ON dbo.T_RecDet.Bank = dbo.M_Bank.BANK_CODE WHERE (dbo.T_RecDet.Paytype = 'CQ') ";
                //"AND (dbo.T_RecDet.BankDate BETWEEN CONVERT(DATETIME, '" + fromdate.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + todate.ToShortDateString() + "', 103)) ";

                if (customer.Trim() != "")
                {
                    strquery1 += "AND (dbo.T_RecDet.Customer = '" + customer.Trim() + "') ";
                    if (daterange == true)
                    {
                        strquery1 += " AND (dbo.T_RecDet.BankDate BETWEEN CONVERT(DATETIME, '" + fromdate.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + todate.ToShortDateString() + "', 103)) ";

                    }
                    if (isunrealized == true) // calculation based on bankdate - today < 0
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";

                    }
                    if (isretured == true)
                    {
                        strquery1 += "AND (dbo.T_RecDet.isreturned = 1) ";
                    }
                    if (ispostdated == true)
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                    }
                    if (realized == true) //Calculation based on bankdate - today >0
                    {
                        strquery1 += "AND (dbo.T_RecDet.isReconsile = 1) ";
                    }

                }
                else
                {
                    if (daterange == true)
                    {
                        strquery1 += " AND (dbo.T_RecDet.BankDate BETWEEN CONVERT(DATETIME, '" + fromdate.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + todate.ToShortDateString() + "', 103)) ";

                    }
                    if (isunrealized == true) // calculation based on bankdate - today < 0
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) < 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";

                    }
                    if (isretured == true)
                    {
                        strquery1 += "AND (dbo.T_RecDet.isreturned = 1) ";
                    }
                    if (ispostdated == true)
                    {
                        strquery1 += " AND DATEDIFF(DAY,CONVERT(DATETIME, GETDATE() , 103),CONVERT(DATETIME, dbo.T_RecDet.BankDate, 103)) > 0 AND dbo.T_RecDet.isReconsile = 0 AND dbo.T_RecDet.isreturned = 0";
                    }
                    if (realized == true) //Calculation based on bankdate - today >0
                    {
                        strquery1 += "AND (dbo.T_RecDet.isReconsile = 1) ";
                    }
                }
                DataTable dtt_RecDet = u_DBConnection.ReturnDataTable(strquery1, CommandType.Text);
                return dtt_RecDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public T_RecDet Selectt_RecDet(T_RecDet objt_RecDet, string docno , string cqno)
        {
            try
            {
                strquery = @"select * from t_RecDet where Docno = '" + docno.Trim() + "' AND CQno = '" + cqno.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_RecDet.Docno = drType["Docno"].ToString();
                    objt_RecDet.locationId = drType["locationId"].ToString();
                    objt_RecDet.Sequence = int.Parse(drType["Sequence"].ToString());
                    objt_RecDet.Paytype = drType["Paytype"].ToString();
                    objt_RecDet.HeadAmt = decimal.Parse(drType["HeadAmt"].ToString());
                    objt_RecDet.Amt = decimal.Parse(drType["Amt"].ToString());
                    objt_RecDet.InvNo = drType["InvNo"].ToString();
                    objt_RecDet.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_RecDet.CQno = drType["CQno"].ToString();
                    objt_RecDet.Bank = drType["Bank"].ToString();
                    objt_RecDet.BankBranch = drType["BankBranch"].ToString();
                    objt_RecDet.BankDate = DateTime.Parse(drType["BankDate"].ToString());
                    objt_RecDet.isReconsile = bool.Parse(drType["isReconsile"].ToString());
                    objt_RecDet.ReconsileDate = DateTime.Parse(drType["ReconsileDate"].ToString());
                    objt_RecDet.Customer = drType["Customer"].ToString();
                    objt_RecDet.isreturned = bool.Parse(drType["isreturned"].ToString());
                    objt_RecDet.ReturnDate = DateTime.Parse(drType["ReturnDate"].ToString());
                    objt_RecDet.ReturnUpdateUSer = drType["ReturnUpdateUSer"].ToString();
                    objt_RecDet.ReasontoRtn = drType["ReasontoRtn"].ToString();
                    return objt_RecDet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_RecDet(string stringt_RecDet)
        {
            try
            {
                string xstrquery = @"select CompCode From T_RecDet   WHERE CompCode = '" + stringt_RecDet + "' ";
                DataRow drT_RecDet = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_RecDet != null)
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

        public List<T_RecDet> SelectT_RecDetMulti(T_RecDet objt_RecDet2)
        {
            List<T_RecDet> retval = new List<T_RecDet>();
            try
            {
                strquery = @"select * from t_RecDet where Docno = '" + objt_RecDet2.Docno + "'";
                DataTable dtt_RecDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_RecDet.Rows)
                {
                    if (drType != null)
                    {
                        T_RecDet objt_RecDet = new T_RecDet();
                        objt_RecDet.Docno = drType["Docno"].ToString();
                        objt_RecDet.locationId = drType["locationId"].ToString();
                        objt_RecDet.Sequence = int.Parse(drType["Sequence"].ToString());
                        objt_RecDet.Paytype = drType["Paytype"].ToString();
                        objt_RecDet.HeadAmt = decimal.Parse(drType["HeadAmt"].ToString());
                        objt_RecDet.Amt = decimal.Parse(drType["Amt"].ToString());
                        objt_RecDet.InvNo = drType["InvNo"].ToString();
                        objt_RecDet.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_RecDet.CQno = drType["CQno"].ToString();
                        objt_RecDet.Bank = drType["Bank"].ToString();
                        objt_RecDet.BankBranch = drType["BankBranch"].ToString();
                        objt_RecDet.BankDate = DateTime.Parse(drType["BankDate"].ToString());
                        objt_RecDet.isReconsile = bool.Parse(drType["isReconsile"].ToString());
                        objt_RecDet.ReconsileDate = DateTime.Parse(drType["ReconsileDate"].ToString());
                        objt_RecDet.Customer = drType["Customer"].ToString();
                        objt_RecDet.isreturned = bool.Parse(drType["isreturned"].ToString());
                        objt_RecDet.ReturnDate = DateTime.Parse(drType["ReturnDate"].ToString());
                        objt_RecDet.ReturnUpdateUSer = drType["ReturnUpdateUSer"].ToString();
                        objt_RecDet.ReasontoRtn = drType["ReasontoRtn"].ToString();
                        retval.Add(objt_RecDet);
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
