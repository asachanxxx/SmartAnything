using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_SettlementDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_Settlement table.
        /// </summary>
        public Boolean Savet_SettlementSP(T_Settlement t_Settlement, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_SettlementSave";

                scom.Parameters.Add("@Reciptno", SqlDbType.VarChar, 20).Value = t_Settlement.Reciptno;
                scom.Parameters.Add("@InvNo", SqlDbType.VarChar, 20).Value = t_Settlement.InvNo;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_Settlement.CompCode;
                scom.Parameters.Add("@LocaCode", SqlDbType.VarChar, 20).Value = t_Settlement.LocaCode;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_Settlement.Customer;
                scom.Parameters.Add("@InvAmt", SqlDbType.Decimal, 9).Value = t_Settlement.InvAmt;
                scom.Parameters.Add("@PaidAmt", SqlDbType.Decimal, 9).Value = t_Settlement.PaidAmt;
                scom.Parameters.Add("@DueAmt", SqlDbType.Decimal, 9).Value = t_Settlement.DueAmt;
                scom.Parameters.Add("@Settlement", SqlDbType.Decimal, 9).Value = t_Settlement.Settlement;
                scom.Parameters.Add("@Iscancelled", SqlDbType.Bit, 1).Value = t_Settlement.Iscancelled;
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


        public DataTable SelectAllt_Settlement()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_Settlement]";
                DataTable dtt_Settlement = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_Settlement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_Settlement Selectt_Settlement(T_Settlement objt_Settlement)
        {
            try
            {
                strquery = @"select * from t_Settlement where Reciptno = '" + objt_Settlement.Reciptno + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_Settlement.Reciptno = drType["Reciptno"].ToString();
                    objt_Settlement.InvNo = drType["InvNo"].ToString();
                    objt_Settlement.CompCode = drType["CompCode"].ToString();
                    objt_Settlement.LocaCode = drType["LocaCode"].ToString();
                    objt_Settlement.Customer = drType["Customer"].ToString();
                    objt_Settlement.InvAmt = decimal.Parse(drType["InvAmt"].ToString());
                    objt_Settlement.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                    objt_Settlement.DueAmt = decimal.Parse(drType["DueAmt"].ToString());
                    objt_Settlement.Settlement = decimal.Parse(drType["Settlement"].ToString());
                    objt_Settlement.Iscancelled = bool.Parse(drType["Iscancelled"].ToString());
                    return objt_Settlement;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_Settlement(string stringt_Settlement)
        {
            try
            {
                string xstrquery = @"select Reciptno From T_Settlement   WHERE Reciptno = '" + stringt_Settlement + "' ";
                DataRow drT_Settlement = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_Settlement != null)
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

        public List<T_Settlement> SelectT_SettlementMulti(T_Settlement objt_Settlement2)
        {
            List<T_Settlement> retval = new List<T_Settlement>();
            try
            {
                strquery = @"select * from t_Settlement where Reciptno = '" + objt_Settlement2.Reciptno + "'";
                DataTable dtt_Settlement = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_Settlement.Rows)
                {
                    if (drType != null)
                    {
                        T_Settlement objt_Settlement = new T_Settlement();
                        objt_Settlement.Reciptno = drType["Reciptno"].ToString();
                        objt_Settlement.InvNo = drType["InvNo"].ToString();
                        objt_Settlement.CompCode = drType["CompCode"].ToString();
                        objt_Settlement.LocaCode = drType["LocaCode"].ToString();
                        objt_Settlement.Customer = drType["Customer"].ToString();
                        objt_Settlement.InvAmt = decimal.Parse(drType["InvAmt"].ToString());
                        objt_Settlement.PaidAmt = decimal.Parse(drType["PaidAmt"].ToString());
                        objt_Settlement.DueAmt = decimal.Parse(drType["DueAmt"].ToString());
                        objt_Settlement.Settlement = decimal.Parse(drType["Settlement"].ToString());
                        objt_Settlement.Iscancelled = bool.Parse(drType["Iscancelled"].ToString());
                        retval.Add(objt_Settlement);
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
