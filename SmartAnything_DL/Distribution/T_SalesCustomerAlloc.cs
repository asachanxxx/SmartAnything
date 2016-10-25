using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_SalesCustomerAllocDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_SalesCustomerAlloc table.
        /// </summary>
        public Boolean Savet_SalesCustomerAllocSP(T_SalesCustomerAlloc t_SalesCustomerAlloc, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_SalesCustomerAllocSave";

                scom.Parameters.Add("@SalesMan", SqlDbType.VarChar, 20).Value = t_SalesCustomerAlloc.SalesMan;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_SalesCustomerAlloc.Customer;
                scom.Parameters.Add("@Item", SqlDbType.VarChar, 20).Value = t_SalesCustomerAlloc.Item;
                scom.Parameters.Add("@AllocQTY", SqlDbType.Decimal, 9).Value = t_SalesCustomerAlloc.AllocQTY;
                scom.Parameters.Add("@DateFrom", SqlDbType.DateTime, 8).Value = t_SalesCustomerAlloc.DateFrom;
                scom.Parameters.Add("@Dateto", SqlDbType.DateTime, 8).Value = t_SalesCustomerAlloc.Dateto;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = t_SalesCustomerAlloc.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_SalesCustomerAlloc.Datex;
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


        public DataTable SelectAllt_SalesCustomerAlloc()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_SalesCustomerAlloc]";
                DataTable dtt_SalesCustomerAlloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_SalesCustomerAlloc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_SalesCustomerAlloc Selectt_SalesCustomerAlloc(T_SalesCustomerAlloc objt_SalesCustomerAlloc)
        {
            try
            {
                strquery = @"select * from t_SalesCustomerAlloc where CompCode = '" + objt_SalesCustomerAlloc + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_SalesCustomerAlloc.SalesMan = drType["SalesMan"].ToString();
                    objt_SalesCustomerAlloc.Customer = drType["Customer"].ToString();
                    objt_SalesCustomerAlloc.Item = drType["Item"].ToString();
                    objt_SalesCustomerAlloc.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                    objt_SalesCustomerAlloc.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                    objt_SalesCustomerAlloc.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                    objt_SalesCustomerAlloc.Userx = drType["Userx"].ToString();
                    objt_SalesCustomerAlloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_SalesCustomerAlloc;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_SalesCustomerAlloc(string stringt_SalesCustomerAlloc)
        {
            try
            {
                string xstrquery = @"select CompCode From T_SalesCustomerAlloc   WHERE CompCode = '" + stringt_SalesCustomerAlloc + "' ";
                DataRow drT_SalesCustomerAlloc = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_SalesCustomerAlloc != null)
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

        public List<T_SalesCustomerAlloc> SelectT_SalesCustomerAllocMulti(T_SalesCustomerAlloc objt_SalesCustomerAlloc2)
        {
            List<T_SalesCustomerAlloc> retval = new List<T_SalesCustomerAlloc>();
            try
            {
                strquery = @"select * from t_SalesCustomerAlloc where purchaseReqNo = '" + objt_SalesCustomerAlloc2.Item + "'";
                DataTable dtt_SalesCustomerAlloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_SalesCustomerAlloc.Rows)
                {
                    if (drType != null)
                    {
                        T_SalesCustomerAlloc objt_SalesCustomerAlloc = new T_SalesCustomerAlloc();
                        objt_SalesCustomerAlloc.SalesMan = drType["SalesMan"].ToString();
                        objt_SalesCustomerAlloc.Customer = drType["Customer"].ToString();
                        objt_SalesCustomerAlloc.Item = drType["Item"].ToString();
                        objt_SalesCustomerAlloc.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                        objt_SalesCustomerAlloc.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                        objt_SalesCustomerAlloc.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                        objt_SalesCustomerAlloc.Userx = drType["Userx"].ToString();
                        objt_SalesCustomerAlloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objt_SalesCustomerAlloc);
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
