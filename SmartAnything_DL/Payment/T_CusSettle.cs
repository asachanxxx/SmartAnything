using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_CusSettleDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_CusSettle table.
        /// </summary>
        public Boolean Savet_CusSettleSP(T_CusSettle t_CusSettle, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_CusSettleSave";

                scom.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = t_CusSettle.DocNo;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_CusSettle.Customer;
                scom.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = t_CusSettle.Type;
                scom.Parameters.Add("@RefNo", SqlDbType.VarChar, 20).Value = t_CusSettle.RefNo;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_CusSettle.CompCode;
                scom.Parameters.Add("@LocaCode", SqlDbType.VarChar, 20).Value = t_CusSettle.LocaCode;
                scom.Parameters.Add("@NetAmt", SqlDbType.Decimal, 9).Value = t_CusSettle.NetAmt;
                scom.Parameters.Add("@PaidAmt", SqlDbType.Decimal, 9).Value = t_CusSettle.PaidAmt;
                scom.Parameters.Add("@DueAmt", SqlDbType.Decimal, 9).Value = t_CusSettle.DueAmt;
                scom.Parameters.Add("@Settlement", SqlDbType.Decimal, 9).Value = t_CusSettle.Settlement;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_CusSettle.Datex;
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


        public DataTable SelectAllt_CusSettle()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_CusSettle]";
                DataTable dtt_CusSettle = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_CusSettle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_CusSettle Selectt_CusSettle(T_CusSettle objt_CusSettle)
        {
            try
            {
                strquery = @"select * from t_CusSettle where Customer = '" + objt_CusSettle.Customer + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_CusSettle.DocNo = drType["DocNo"].ToString();
                    objt_CusSettle.Customer = drType["Customer"].ToString();
                    objt_CusSettle.Type = drType["Type"].ToString();
                    objt_CusSettle.RefNo = drType["RefNo"].ToString();
                    objt_CusSettle.CompCode = drType["CompCode"].ToString();
                    objt_CusSettle.LocaCode = drType["LocaCode"].ToString();
                    objt_CusSettle.NetAmt = decimal.Parse(drType["NetAmt"].ToString());
                    objt_CusSettle.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                    objt_CusSettle.DueAmt = decimal.Parse(drType["DueAmt"].ToString());
                    objt_CusSettle.Settlement = decimal.Parse(drType["Settlement"].ToString());
                    objt_CusSettle.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objt_CusSettle;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_CusSettle(string stringt_CusSettle)
        {
            try
            {
                string xstrquery = @"select Customer From T_CusSettle   WHERE Customer = '" + stringt_CusSettle + "' ";
                DataRow drT_CusSettle = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_CusSettle != null)
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

        public List<T_CusSettle> SelectT_CusSettleMulti(T_CusSettle objt_CusSettle2)
        {
            List<T_CusSettle> retval = new List<T_CusSettle>();
            try
            {
                strquery = @"select * from t_CusSettle where Customer = '" + objt_CusSettle2.Customer + "'";
                DataTable dtt_CusSettle = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_CusSettle.Rows)
                {
                    if (drType != null)
                    {
                        T_CusSettle objt_CusSettle = new T_CusSettle();
                        objt_CusSettle.DocNo = drType["DocNo"].ToString();
                        objt_CusSettle.Customer = drType["Customer"].ToString();
                        objt_CusSettle.Type = drType["Type"].ToString();
                        objt_CusSettle.RefNo = drType["RefNo"].ToString();
                        objt_CusSettle.CompCode = drType["CompCode"].ToString();
                        objt_CusSettle.LocaCode = drType["LocaCode"].ToString();
                        objt_CusSettle.NetAmt = decimal.Parse(drType["NetAmt"].ToString());
                        objt_CusSettle.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                        objt_CusSettle.DueAmt = decimal.Parse(drType["DueAmt"].ToString());
                        objt_CusSettle.Settlement = decimal.Parse(drType["Settlement"].ToString());
                        objt_CusSettle.Datex = DateTime.Parse(drType["Datex"].ToString());
                        retval.Add(objt_CusSettle);
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
