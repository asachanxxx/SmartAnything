using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_CustomerItemAllocDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_CustomerItemAlloc table.
        /// </summary>
        public Boolean Savet_CustomerItemAllocSP(T_CustomerItemAlloc t_CustomerItemAlloc, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_CustomerItemAllocSave";

                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_CustomerItemAlloc.Customer;
                scom.Parameters.Add("@Item", SqlDbType.VarChar, 20).Value = t_CustomerItemAlloc.Item;
                scom.Parameters.Add("@AllocQTY", SqlDbType.Decimal, 9).Value = t_CustomerItemAlloc.AllocQTY;
                scom.Parameters.Add("@DateFrom", SqlDbType.DateTime, 8).Value = t_CustomerItemAlloc.DateFrom;
                scom.Parameters.Add("@Dateto", SqlDbType.DateTime, 8).Value = t_CustomerItemAlloc.Dateto;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = t_CustomerItemAlloc.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_CustomerItemAlloc.Datex;
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


        public DataTable SelectAllt_CustomerItemAlloc()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_CustomerItemAlloc]";
                DataTable dtt_CustomerItemAlloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_CustomerItemAlloc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_CustomerItemAlloc Selectt_CustomerItemAlloc(T_CustomerItemAlloc objt_CustomerItemAlloc)
        {
            try
            {
                strquery = @"select * from t_CustomerItemAlloc where CompCode = '" + objt_CustomerItemAlloc + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_CustomerItemAlloc.Customer = drType["Customer"].ToString();
                    objt_CustomerItemAlloc.Item = drType["Item"].ToString();
                    objt_CustomerItemAlloc.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                    objt_CustomerItemAlloc.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                    objt_CustomerItemAlloc.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                    objt_CustomerItemAlloc.Userx = drType["Userx"].ToString();
                    objt_CustomerItemAlloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_CustomerItemAlloc;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_CustomerItemAlloc(string stringt_CustomerItemAlloc)
        {
            try
            {
                string xstrquery = @"select CompCode From T_CustomerItemAlloc   WHERE CompCode = '" + stringt_CustomerItemAlloc + "' ";
                DataRow drT_CustomerItemAlloc = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_CustomerItemAlloc != null)
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

        public List<T_CustomerItemAlloc> SelectT_CustomerItemAllocMulti(T_CustomerItemAlloc objt_CustomerItemAlloc2)
        {
            List<T_CustomerItemAlloc> retval = new List<T_CustomerItemAlloc>();
            try
            {
                strquery = @"select * from t_CustomerItemAlloc where purchaseReqNo = '" + objt_CustomerItemAlloc2.Item + "'";
                DataTable dtt_CustomerItemAlloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_CustomerItemAlloc.Rows)
                {
                    if (drType != null)
                    {
                        T_CustomerItemAlloc objt_CustomerItemAlloc = new T_CustomerItemAlloc();
                        objt_CustomerItemAlloc.Customer = drType["Customer"].ToString();
                        objt_CustomerItemAlloc.Item = drType["Item"].ToString();
                        objt_CustomerItemAlloc.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                        objt_CustomerItemAlloc.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                        objt_CustomerItemAlloc.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                        objt_CustomerItemAlloc.Userx = drType["Userx"].ToString();
                        objt_CustomerItemAlloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objt_CustomerItemAlloc);
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
