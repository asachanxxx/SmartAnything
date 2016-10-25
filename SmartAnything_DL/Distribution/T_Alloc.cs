using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_AllocDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_Alloc table.
        /// </summary>
        public Boolean Savet_AllocSP(T_Alloc t_Alloc, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_AllocSave";

                scom.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = t_Alloc.DocNo;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_Alloc.locationId;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_Alloc.Datex;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_Alloc.Customer;
                scom.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = t_Alloc.Type;
                scom.Parameters.Add("@RefNo", SqlDbType.VarChar, 20).Value = t_Alloc.RefNo;
                scom.Parameters.Add("@InvNo", SqlDbType.VarChar, 20).Value = t_Alloc.InvNo;
                scom.Parameters.Add("@NetAmt", SqlDbType.Decimal, 9).Value = t_Alloc.NetAmt;
                scom.Parameters.Add("@PaidAmt", SqlDbType.Decimal, 9).Value = t_Alloc.PaidAmt;
                scom.Parameters.Add("@Dueamt", SqlDbType.Decimal, 9).Value = t_Alloc.Dueamt;
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


        public DataTable SelectAllt_Alloc()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_Alloc]";
                DataTable dtt_Alloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_Alloc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_Alloc Selectt_Alloc(T_Alloc objt_Alloc)
        {
            try
            {
                strquery = @"select * from T_Alloc where Customer = '" + objt_Alloc.Customer + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_Alloc.DocNo = drType["DocNo"].ToString();
                    objt_Alloc.locationId = drType["locationId"].ToString();
                    objt_Alloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_Alloc.Customer = drType["Customer"].ToString();
                    objt_Alloc.Type = drType["Type"].ToString();
                    objt_Alloc.RefNo = drType["RefNo"].ToString();
                    objt_Alloc.InvNo = drType["InvNo"].ToString();
                    objt_Alloc.NetAmt = decimal.Parse(drType["NetAmt"].ToString());
                    objt_Alloc.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                    objt_Alloc.Dueamt = decimal.Parse(drType["Dueamt"].ToString());
                    return objt_Alloc;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_Alloc(string cstomer)
        {
            try
            {
                string xstrquery = @"SELECT * FROM T_Alloc WHERE customer = '" +cstomer.Trim() +"'";
                DataRow drT_Alloc = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Alloc != null)
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

        public List<T_Alloc> SelectT_AllocMulti(T_Alloc objt_Alloc2)
        {
            List<T_Alloc> retval = new List<T_Alloc>();
            try
            {
                strquery = @"select * from t_Alloc where DocNo = '" + objt_Alloc2.DocNo + "'";
                DataTable dtt_Alloc = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_Alloc.Rows)
                {
                    if (drType != null)
                    {
                        T_Alloc objt_Alloc = new T_Alloc();
                        objt_Alloc.DocNo = drType["DocNo"].ToString();
                        objt_Alloc.locationId = drType["locationId"].ToString();
                        objt_Alloc.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_Alloc.Customer = drType["Customer"].ToString();
                        objt_Alloc.Type = drType["Type"].ToString();
                        objt_Alloc.RefNo = drType["RefNo"].ToString();
                        objt_Alloc.InvNo = drType["InvNo"].ToString();
                        objt_Alloc.NetAmt = decimal.Parse(drType["NetAmt"].ToString());
                        objt_Alloc.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                        objt_Alloc.Dueamt = decimal.Parse(drType["Dueamt"].ToString());
                        retval.Add(objt_Alloc);
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
