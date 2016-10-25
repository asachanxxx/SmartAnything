using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_CNBreakDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_CNBreak table.
        /// </summary>
        public Boolean Savet_CNBreakSP(T_CNBreak t_CNBreak, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_CNBreakSave";

                scom.Parameters.Add("@DocNo", SqlDbType.VarChar, 20).Value = t_CNBreak.DocNo;
                scom.Parameters.Add("@ItemCode", SqlDbType.VarChar, 20).Value = t_CNBreak.ItemCode;
                scom.Parameters.Add("@Namex", SqlDbType.VarChar, 150).Value = t_CNBreak.Namex;
                scom.Parameters.Add("@InvQTY", SqlDbType.Decimal, 9).Value = t_CNBreak.InvQTY;
                scom.Parameters.Add("@QTY", SqlDbType.Decimal, 9).Value = t_CNBreak.QTY;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_CNBreak.Datex;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = t_CNBreak.Userx;
                scom.Parameters.Add("@Grouped", SqlDbType.Bit, 1).Value = t_CNBreak.Grouped;
                scom.Parameters.Add("@BalanceQty", SqlDbType.Decimal, 9).Value = t_CNBreak.BalanceQty;
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


        public DataTable SelectAllt_CNBreak()
        {
            try
            {
                strquery = @"select DocNo , ItemCode from T_CNBreak";
                DataTable dtt_CNBreak = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_CNBreak;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_CNBreak Selectt_CNBreak(T_CNBreak objt_CNBreak)
        {
            try
            {
                strquery = @"select * from t_CNBreak where DocNo = '" + objt_CNBreak.DocNo.Trim() + "' and ItemCode = '" + objt_CNBreak.ItemCode.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_CNBreak.DocNo = drType["DocNo"].ToString();
                    objt_CNBreak.ItemCode = drType["ItemCode"].ToString();
                    objt_CNBreak.Namex = drType["Namex"].ToString();
                    objt_CNBreak.InvQTY = decimal.Parse(drType["InvQTY"].ToString());
                    objt_CNBreak.QTY = decimal.Parse(drType["QTY"].ToString());
                    objt_CNBreak.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_CNBreak.Userx = drType["Userx"].ToString();
                    objt_CNBreak.Grouped = bool.Parse(drType["Grouped"].ToString());
                    objt_CNBreak.BalanceQty = decimal.Parse(drType["BalanceQty"].ToString());
                    return objt_CNBreak;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_CNBreak(string stringt_CNBreak)
        {
            try
            {
                string xstrquery = @"select DocNo From T_CNBreak   WHERE DocNo = '" + stringt_CNBreak + "' ";
                DataRow drT_CNBreak = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_CNBreak != null)
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

        public List<T_CNBreak> SelectT_CNBreakMulti(T_CNBreak objt_CNBreak2)
        {
            List<T_CNBreak> retval = new List<T_CNBreak>();
            try
            {
                strquery = @"select * from t_CNBreak where DocNo = '" + objt_CNBreak2.DocNo + "'";
                DataTable dtt_CNBreak = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_CNBreak.Rows)
                {
                    if (drType != null)
                    {
                        T_CNBreak objt_CNBreak = new T_CNBreak();
                        objt_CNBreak.DocNo = drType["DocNo"].ToString();
                        objt_CNBreak.ItemCode = drType["ItemCode"].ToString();
                        objt_CNBreak.Namex = drType["Namex"].ToString();
                        objt_CNBreak.InvQTY = decimal.Parse(drType["InvQTY"].ToString());
                        objt_CNBreak.QTY = decimal.Parse(drType["QTY"].ToString());
                        objt_CNBreak.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_CNBreak.Userx = drType["Userx"].ToString();
                        objt_CNBreak.Grouped = bool.Parse(drType["Grouped"].ToString());
                        objt_CNBreak.BalanceQty = decimal.Parse(drType["BalanceQty"].ToString());
                        retval.Add(objt_CNBreak);
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
