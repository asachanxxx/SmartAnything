using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_SalesAllocHeadDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_SalesAllocHead table.
        /// </summary>
        public Boolean Savet_SalesAllocHeadSP(T_SalesAllocHead t_SalesAllocHead, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_SalesAllocHeadSave";

                scom.Parameters.Add("@Docno", SqlDbType.VarChar, 20).Value = t_SalesAllocHead.Docno;
                scom.Parameters.Add("@Salesman", SqlDbType.VarChar, 20).Value = t_SalesAllocHead.Salesman;
                scom.Parameters.Add("@Item", SqlDbType.VarChar, 20).Value = t_SalesAllocHead.Item;
                scom.Parameters.Add("@AllocQTY", SqlDbType.Decimal, 9).Value = t_SalesAllocHead.AllocQTY;
                scom.Parameters.Add("@DateFrom", SqlDbType.DateTime, 8).Value = t_SalesAllocHead.DateFrom;
                scom.Parameters.Add("@Dateto", SqlDbType.DateTime, 8).Value = t_SalesAllocHead.Dateto;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = t_SalesAllocHead.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_SalesAllocHead.Datex;
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


        public DataTable SelectAllt_SalesAllocHead()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_SalesAllocHead]";
                DataTable dtt_SalesAllocHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_SalesAllocHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_SalesAllocHead Selectt_SalesAllocHead(T_SalesAllocHead objt_SalesAllocHead)
        {
            try
            {
                strquery = @"select * from t_SalesAllocHead where Docno = '" + objt_SalesAllocHead.Docno + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_SalesAllocHead.Docno = drType["Docno"].ToString();
                    objt_SalesAllocHead.Salesman = drType["Salesman"].ToString();
                    objt_SalesAllocHead.Item = drType["Item"].ToString();
                    objt_SalesAllocHead.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                    objt_SalesAllocHead.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                    objt_SalesAllocHead.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                    objt_SalesAllocHead.Userx = drType["Userx"].ToString();
                    objt_SalesAllocHead.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_SalesAllocHead;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_SalesAllocHead(string stringt_SalesAllocHead)
        {
            try
            {
                string xstrquery = @"select CompCode From T_SalesAllocHead   WHERE CompCode = '" + stringt_SalesAllocHead + "' ";
                DataRow drT_SalesAllocHead = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_SalesAllocHead != null)
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

        public List<T_SalesAllocHead> SelectT_SalesAllocHeadMulti(T_SalesAllocHead objt_SalesAllocHead2)
        {
            List<T_SalesAllocHead> retval = new List<T_SalesAllocHead>();
            try
            {
                strquery = @"select * from t_SalesAllocHead where Docno = '" + objt_SalesAllocHead2.Docno + "'";
                DataTable dtt_SalesAllocHead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_SalesAllocHead.Rows)
                {
                    if (drType != null)
                    {
                        T_SalesAllocHead objt_SalesAllocHead = new T_SalesAllocHead();
                        objt_SalesAllocHead.Docno = drType["Docno"].ToString();
                        objt_SalesAllocHead.Salesman = drType["Salesman"].ToString();
                        objt_SalesAllocHead.Item = drType["Item"].ToString();
                        objt_SalesAllocHead.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                        objt_SalesAllocHead.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                        objt_SalesAllocHead.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                        objt_SalesAllocHead.Userx = drType["Userx"].ToString();
                        objt_SalesAllocHead.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objt_SalesAllocHead);
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
