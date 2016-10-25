using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_SalesAllocDetDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_SalesAllocDet table.
        /// </summary>
        public Boolean Savet_SalesAllocDetSP(T_SalesAllocDet t_SalesAllocDet, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_SalesAllocDetSave";

                scom.Parameters.Add("@Docno", SqlDbType.VarChar, 20).Value = t_SalesAllocDet.Docno;
                scom.Parameters.Add("@SalesMan", SqlDbType.VarChar, 20).Value = t_SalesAllocDet.SalesMan;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_SalesAllocDet.Customer;
                scom.Parameters.Add("@Item", SqlDbType.VarChar, 20).Value = t_SalesAllocDet.Item;
                scom.Parameters.Add("@AllowedQTY", SqlDbType.Decimal, 9).Value = t_SalesAllocDet.AllowedQTY;
                scom.Parameters.Add("@AllocQTY", SqlDbType.Decimal, 9).Value = t_SalesAllocDet.AllocQTY;
                scom.Parameters.Add("@DateFrom", SqlDbType.DateTime, 8).Value = t_SalesAllocDet.DateFrom;
                scom.Parameters.Add("@Dateto", SqlDbType.DateTime, 8).Value = t_SalesAllocDet.Dateto;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = t_SalesAllocDet.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_SalesAllocDet.Datex;
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


        public DataTable SelectAllt_SalesAllocDet()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_SalesAllocDet]";
                DataTable dtt_SalesAllocDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_SalesAllocDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_SalesAllocDet Selectt_SalesAllocDet(T_SalesAllocDet objt_SalesAllocDet)
        {
            try
            {
                strquery = @"select *  FROM T_SalesAllocDet WHERE Docno = '" + objt_SalesAllocDet.Docno + "' AND SalesMan = '" + objt_SalesAllocDet.SalesMan + "' AND Customer = '" + objt_SalesAllocDet.Customer + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_SalesAllocDet.Docno = drType["Docno"].ToString();
                    objt_SalesAllocDet.SalesMan = drType["SalesMan"].ToString();
                    objt_SalesAllocDet.Customer = drType["Customer"].ToString();
                    objt_SalesAllocDet.Item = drType["Item"].ToString();
                    objt_SalesAllocDet.AllowedQTY = decimal.Parse(drType["AllowedQTY"].ToString());
                    objt_SalesAllocDet.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                    objt_SalesAllocDet.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                    objt_SalesAllocDet.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                    objt_SalesAllocDet.Userx = drType["Userx"].ToString();
                    objt_SalesAllocDet.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_SalesAllocDet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T_SalesAllocDet Selectt_SalesAllocDetUsingDoc(T_SalesAllocDet objt_SalesAllocDet)
        {
            try
            {
                strquery = @"select *  FROM T_SalesAllocDet WHERE Docno = '" + objt_SalesAllocDet.Docno + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_SalesAllocDet.Docno = drType["Docno"].ToString();
                    objt_SalesAllocDet.SalesMan = drType["SalesMan"].ToString();
                    objt_SalesAllocDet.Customer = drType["Customer"].ToString();
                    objt_SalesAllocDet.Item = drType["Item"].ToString();
                    objt_SalesAllocDet.AllowedQTY = decimal.Parse(drType["AllowedQTY"].ToString());
                    objt_SalesAllocDet.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                    objt_SalesAllocDet.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                    objt_SalesAllocDet.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                    objt_SalesAllocDet.Userx = drType["Userx"].ToString();
                    objt_SalesAllocDet.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_SalesAllocDet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_SalesAllocDet(string stringt_SalesAllocDet)
        {
            try
            {
                string xstrquery = @"select CompCode From T_SalesAllocDet   WHERE CompCode = '" + stringt_SalesAllocDet + "' ";
                DataRow drT_SalesAllocDet = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_SalesAllocDet != null)
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

        public List<T_SalesAllocDet> SelectT_SalesAllocDetMulti(T_SalesAllocDet objt_SalesAllocDet2)
        {
            List<T_SalesAllocDet> retval = new List<T_SalesAllocDet>();
            try
            {
                strquery = @"select * from t_SalesAllocDet where Docno = '" + objt_SalesAllocDet2.Docno + "'";
                DataTable dtt_SalesAllocDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_SalesAllocDet.Rows)
                {
                    if (drType != null)
                    {
                        T_SalesAllocDet objt_SalesAllocDet = new T_SalesAllocDet();
                        objt_SalesAllocDet.Docno = drType["Docno"].ToString();
                        objt_SalesAllocDet.SalesMan = drType["SalesMan"].ToString();
                        objt_SalesAllocDet.Customer = drType["Customer"].ToString();
                        objt_SalesAllocDet.Item = drType["Item"].ToString();
                        objt_SalesAllocDet.AllowedQTY = decimal.Parse(drType["AllowedQTY"].ToString());
                        objt_SalesAllocDet.AllocQTY = decimal.Parse(drType["AllocQTY"].ToString());
                        objt_SalesAllocDet.DateFrom = DateTime.Parse(drType["DateFrom"].ToString());
                        objt_SalesAllocDet.Dateto = DateTime.Parse(drType["Dateto"].ToString());
                        objt_SalesAllocDet.Userx = drType["Userx"].ToString();
                        objt_SalesAllocDet.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objt_SalesAllocDet);
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
