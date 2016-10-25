using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_CustomerDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Customers table.
        /// </summary>
        public Boolean SaveM_CustomerSP(M_Customers m_Customer, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_CustomersSave";

                scom.Parameters.Add("@CusID", SqlDbType.VarChar, 20).Value = m_Customer.CusID;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = m_Customer.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Customer.Locacode;
                scom.Parameters.Add("@CustName", SqlDbType.VarChar, 50).Value = m_Customer.CustName;
                scom.Parameters.Add("@TP", SqlDbType.VarChar, 50).Value = m_Customer.TP;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 50).Value = m_Customer.Fax;
                scom.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = m_Customer.Email;
                scom.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = m_Customer.Address1;
                scom.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = m_Customer.Address2;
                scom.Parameters.Add("@Address3", SqlDbType.VarChar, 50).Value = m_Customer.Address3;
                scom.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 20).Value = m_Customer.ContactPerson;
                scom.Parameters.Add("@ContactPersonNo", SqlDbType.VarChar, 20).Value = m_Customer.ContactPersonNo;
                scom.Parameters.Add("@CurrentStatus", SqlDbType.VarChar, 10).Value = m_Customer.CurrentStatus;
                scom.Parameters.Add("@Gradex", SqlDbType.VarChar, 20).Value = m_Customer.Gradex;
                scom.Parameters.Add("@CreditLimit", SqlDbType.Decimal, 9).Value = m_Customer.CreditLimit;
                scom.Parameters.Add("@CreditPeriod", SqlDbType.Int, 4).Value = m_Customer.CreditPeriod;
                scom.Parameters.Add("@MaxDisc", SqlDbType.Decimal, 9).Value = m_Customer.MaxDisc;
                scom.Parameters.Add("@MinDisc", SqlDbType.Decimal, 9).Value = m_Customer.MinDisc;
                scom.Parameters.Add("@ApplyingDisc", SqlDbType.Decimal, 9).Value = m_Customer.ApplyingDisc;
                scom.Parameters.Add("@CusOpenBal", SqlDbType.Decimal, 9).Value = m_Customer.CusOpenBal;
                scom.Parameters.Add("@CusCurBal", SqlDbType.Decimal, 9).Value = m_Customer.CusCurBal;
                scom.Parameters.Add("@customerOS", SqlDbType.Decimal, 9).Value = m_Customer.customerOS;
                scom.Parameters.Add("@pointsEarned", SqlDbType.Decimal, 9).Value = m_Customer.pointsEarned;
                scom.Parameters.Add("@controlAccountCode", SqlDbType.VarChar, 15).Value = m_Customer.controlAccountCode;
                scom.Parameters.Add("@customerAccountCode", SqlDbType.VarChar, 15).Value = m_Customer.customerAccountCode;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = m_Customer.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = m_Customer.triggerVal;
                scom.Parameters.Add("@SalesMan", SqlDbType.VarChar, 20).Value = m_Customer.SalesMan;
                scom.Parameters.Add("@Area", SqlDbType.VarChar, 20).Value = m_Customer.Area;
                scom.Parameters.Add("@cat", SqlDbType.VarChar, 20).Value = m_Customer.cat;
                scom.Parameters.Add("@subcat", SqlDbType.VarChar, 20).Value = m_Customer.subcat;
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


        public DataTable SelectAllm_Customer()
        {
            try
            {
                //strquery = @"select CusID,CustName from M_Customers";
                strquery = @"select CusID,CustName,customerOS from M_Customers ORDER BY CustName";
                DataTable dtm_Customer = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectAllm_CustomerAll()
        {
            try
            {
                strquery = @"select * from M_Customers";
                DataTable dtm_Customer = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public M_Customers Selectm_Customer(M_Customers objm_Customer)
        {
            try
            {
                strquery = @"SELECT * FROM dbo.M_Customers  WHERE CusID = '" + objm_Customer.CusID.Trim() + "' ";

                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Customer.CusID = drType["CusID"].ToString();
                    objm_Customer.Compcode = drType["Compcode"].ToString();
                    objm_Customer.Locacode = drType["Locacode"].ToString();
                    objm_Customer.CustName = drType["CustName"].ToString();
                    objm_Customer.TP = drType["TP"].ToString();
                    objm_Customer.Fax = drType["Fax"].ToString();
                    objm_Customer.Email = drType["Email"].ToString();
                    objm_Customer.Address1 = drType["Address1"].ToString();
                    objm_Customer.Address2 = drType["Address2"].ToString();
                    objm_Customer.Address3 = drType["Address3"].ToString();
                    objm_Customer.ContactPerson = drType["ContactPerson"].ToString();
                    objm_Customer.ContactPersonNo = drType["ContactPersonNo"].ToString();
                    objm_Customer.CurrentStatus = drType["CurrentStatus"].ToString();
                    objm_Customer.Gradex = drType["Gradex"].ToString();
                    objm_Customer.CreditLimit = decimal.Parse(drType["CreditLimit"].ToString());
                    objm_Customer.CreditPeriod =  drType["CreditPeriod"]==null ? 0: int.Parse(drType["CreditPeriod"].ToString());
                    objm_Customer.MaxDisc = decimal.Parse(drType["MaxDisc"].ToString());
                    objm_Customer.MinDisc = decimal.Parse(drType["MinDisc"].ToString());
                    objm_Customer.ApplyingDisc = decimal.Parse(drType["ApplyingDisc"].ToString());
                    objm_Customer.CusOpenBal = decimal.Parse(drType["CusOpenBal"].ToString());
                    objm_Customer.CusCurBal = decimal.Parse(drType["CusCurBal"].ToString());
                    objm_Customer.customerOS = decimal.Parse(drType["customerOS"].ToString());
                    objm_Customer.pointsEarned = decimal.Parse(drType["pointsEarned"].ToString());
                    objm_Customer.controlAccountCode = drType["controlAccountCode"].ToString();
                    objm_Customer.customerAccountCode = drType["customerAccountCode"].ToString();
                    objm_Customer.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objm_Customer.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    objm_Customer.SalesMan = drType["SalesMan"].ToString();
                    objm_Customer.Area = drType["Area"].ToString();
                    objm_Customer.cat = drType["cat"].ToString();
                    objm_Customer.subcat = drType["subcat"].ToString();
                    return objm_Customer;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static bool ExistingM_Customer(string stringM_Customer)
        {
            try
            {
                string xstrquery = @"select [CusID] from [M_Customers] where [CusID] = '" + stringM_Customer.Trim() + "'";
                DataRow drM_Customer = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Customer != null)
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

        public List<M_Customers> SelectM_CustomerMulti(string salesman)
        {
            List<M_Customers> retval = new List<M_Customers>();
            try
            {
                strquery = @"SELECT * FROM dbo.M_Customers WHERE SalesMan = '" + salesman.Trim() + "'";
                DataTable dtm_Customer = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_Customer.Rows)
                {
                    if (drType != null)
                    {
                        M_Customers objm_Customer = new M_Customers();
                        objm_Customer.CusID = drType["CusID"].ToString();
                        objm_Customer.Compcode = drType["Compcode"].ToString();
                        objm_Customer.Locacode = drType["Locacode"].ToString();
                        objm_Customer.CustName = drType["CustName"].ToString();
                        objm_Customer.TP = drType["TP"].ToString();
                        objm_Customer.Fax = drType["Fax"].ToString();
                        objm_Customer.Email = drType["Email"].ToString();
                        objm_Customer.Address1 = drType["Address1"].ToString();
                        objm_Customer.Address2 = drType["Address2"].ToString();
                        objm_Customer.Address3 = drType["Address3"].ToString();
                        objm_Customer.ContactPerson = drType["ContactPerson"].ToString();
                        objm_Customer.ContactPersonNo = drType["ContactPersonNo"].ToString();
                        objm_Customer.CurrentStatus = drType["CurrentStatus"].ToString();
                        objm_Customer.Gradex = drType["Gradex"].ToString();
                        objm_Customer.CreditLimit = decimal.Parse(drType["CreditLimit"].ToString());
                        objm_Customer.CreditPeriod = int.Parse(drType["CreditPeriod"].ToString());
                        objm_Customer.MaxDisc = decimal.Parse(drType["MaxDisc"].ToString());
                        objm_Customer.MinDisc = decimal.Parse(drType["MinDisc"].ToString());
                        objm_Customer.ApplyingDisc = decimal.Parse(drType["ApplyingDisc"].ToString());
                        objm_Customer.CusOpenBal = decimal.Parse(drType["CusOpenBal"].ToString());
                        objm_Customer.CusCurBal = decimal.Parse(drType["CusCurBal"].ToString());
                        objm_Customer.customerOS = decimal.Parse(drType["customerOS"].ToString());
                        objm_Customer.pointsEarned = decimal.Parse(drType["pointsEarned"].ToString());
                        objm_Customer.controlAccountCode = drType["controlAccountCode"].ToString();
                        objm_Customer.customerAccountCode = drType["customerAccountCode"].ToString();
                        objm_Customer.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objm_Customer.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        objm_Customer.SalesMan = drType["SalesMan"].ToString();
                        objm_Customer.Area = drType["Area"].ToString();
                        objm_Customer.cat = drType["cat"].ToString();
                        objm_Customer.subcat = drType["subcat"].ToString();
                        retval.Add(objm_Customer);
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
