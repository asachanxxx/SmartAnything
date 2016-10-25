using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_SalesItemAllocDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_SalesItemAlloc table.
        /// </summary>
        public Boolean Savet_SalesItemAllocSP(T_SalesItemAlloc t_SalesItemAlloc, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_SalesItemAllocSave";

                scom.Parameters.Add("@Salesman", SqlDbType.VarChar, 20).Value = t_SalesItemAlloc.Salesman;
                scom.Parameters.Add("@Item", SqlDbType.VarChar, 20).Value = t_SalesItemAlloc.Item;
                scom.Parameters.Add("@AllocQTY", SqlDbType.Decimal, 9).Value = t_SalesItemAlloc.AllocQTY;
                scom.Parameters.Add("@DateFrom", SqlDbType.DateTime, 8).Value = t_SalesItemAlloc.DateFrom;
                scom.Parameters.Add("@Dateto", SqlDbType.DateTime, 8).Value = t_SalesItemAlloc.Dateto;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = t_SalesItemAlloc.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_SalesItemAlloc.Datex;
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


        public DataTable SelectAllt_SalesItemAlloc()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_SalesItemAlloc]";
                DataTable dtt_SalesItemAlloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_SalesItemAlloc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_SalesItemAlloc Selectt_SalesItemAlloc(T_SalesItemAlloc objt_SalesItemAlloc)
        {
            try
            {
                strquery = @"select * from t_SalesItemAlloc where CompCode = '" + objt_SalesItemAlloc.Salesman + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_SalesItemAlloc.Salesman = drType["Salesman"].ToString();
                    objt_SalesItemAlloc.Item = drType["Item"].ToString();
                    objt_SalesItemAlloc.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                    objt_SalesItemAlloc.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                    objt_SalesItemAlloc.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                    objt_SalesItemAlloc.Userx = drType["Userx"].ToString();
                    objt_SalesItemAlloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_SalesItemAlloc;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_SalesItemAlloc(string stringt_SalesItemAlloc)
        {
            try
            {
                string xstrquery = @"select CompCode From T_SalesItemAlloc   WHERE CompCode = '" + stringt_SalesItemAlloc + "' ";
                DataRow drT_SalesItemAlloc = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_SalesItemAlloc != null)
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

        public List<T_SalesItemAlloc> SelectT_SalesItemAllocMulti(T_SalesItemAlloc objt_SalesItemAlloc2)
        {
            List<T_SalesItemAlloc> retval = new List<T_SalesItemAlloc>();
            try
            {
                strquery = @"select * from t_SalesItemAlloc where Item = '" + objt_SalesItemAlloc2.Item + "'";
                DataTable dtt_SalesItemAlloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_SalesItemAlloc.Rows)
                {
                    if (drType != null)
                    {
                        T_SalesItemAlloc objt_SalesItemAlloc = new T_SalesItemAlloc();
                        objt_SalesItemAlloc.Salesman = drType["Salesman"].ToString();
                        objt_SalesItemAlloc.Item = drType["Item"].ToString();
                        objt_SalesItemAlloc.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                        objt_SalesItemAlloc.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                        objt_SalesItemAlloc.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                        objt_SalesItemAlloc.Userx = drType["Userx"].ToString();
                        objt_SalesItemAlloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objt_SalesItemAlloc);
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
