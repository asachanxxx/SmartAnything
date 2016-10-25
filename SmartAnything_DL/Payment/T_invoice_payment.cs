using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_invoice_paymentDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_invoice_payment table.
        /// </summary>
        public Boolean Savet_invoice_paymentSP(t_invoice_payment t_invoice_payment, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_invoice_paymentSave";

                scom.Parameters.Add("@invNo", SqlDbType.VarChar, 10).Value = t_invoice_payment.invNo;
                scom.Parameters.Add("@location", SqlDbType.VarChar, 3).Value = t_invoice_payment.location;
                scom.Parameters.Add("@teminalId", SqlDbType.VarChar, 3).Value = t_invoice_payment.teminalId;
                scom.Parameters.Add("@paymodeId", SqlDbType.VarChar, 10).Value = t_invoice_payment.paymodeId;
                scom.Parameters.Add("@subPayMode", SqlDbType.VarChar, 20).Value = t_invoice_payment.subPayMode;
                scom.Parameters.Add("@rate", SqlDbType.Decimal, 9).Value = t_invoice_payment.rate;
                scom.Parameters.Add("@number", SqlDbType.VarChar, 50).Value = t_invoice_payment.number;
                scom.Parameters.Add("@subPayAmount", SqlDbType.Decimal, 9).Value = t_invoice_payment.subPayAmount;
                scom.Parameters.Add("@datex", SqlDbType.DateTime, 8).Value = t_invoice_payment.datex;
                scom.Parameters.Add("@voucherNumber", SqlDbType.VarChar, 50).Value = t_invoice_payment.voucherNumber;
                scom.Parameters.Add("@totalAmount", SqlDbType.Decimal, 9).Value = t_invoice_payment.totalAmount;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_invoice_payment.triggerVal;
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


        public DataTable SelectAllt_invoice_payment()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_invoice_payment]";
                DataTable dtt_invoice_payment = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_invoice_payment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_invoice_payment Selectt_invoice_payment(t_invoice_payment objt_invoice_payment)
        {
            try
            {
                strquery = @"select * from t_invoice_payment where invNo = '" + objt_invoice_payment.invNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_invoice_payment.invNo = drType["invNo"].ToString();
                    objt_invoice_payment.location = drType["location"].ToString();
                    objt_invoice_payment.teminalId = drType["teminalId"].ToString();
                    objt_invoice_payment.paymodeId = drType["paymodeId"].ToString();
                    objt_invoice_payment.subPayMode = drType["subPayMode"].ToString();
                    objt_invoice_payment.rate = decimal.Parse(drType["rate"].ToString());
                    objt_invoice_payment.number = drType["number"].ToString();
                    objt_invoice_payment.subPayAmount = decimal.Parse(drType["subPayAmount"].ToString());
                    objt_invoice_payment.datex = DateTime.Parse(drType["datex"].ToString());
                    objt_invoice_payment.voucherNumber = drType["voucherNumber"].ToString();
                    objt_invoice_payment.totalAmount = decimal.Parse(drType["totalAmount"].ToString());
                    objt_invoice_payment.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_invoice_payment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_invoice_payment(string stringt_invoice_payment)
        {
            try
            {
                string xstrquery = @"select invNo From T_invoice_payment   WHERE invNo = '" + stringt_invoice_payment + "' ";
                DataRow drT_invoice_payment = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_invoice_payment != null)
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

        public List<t_invoice_payment> SelectT_invoice_paymentMulti(t_invoice_payment objt_invoice_payment2)
        {
            List<t_invoice_payment> retval = new List<t_invoice_payment>();
            try
            {
                strquery = @"select * from t_invoice_payment where invNo = '" + objt_invoice_payment2.invNo + "'";
                DataTable dtt_invoice_payment = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_invoice_payment.Rows)
                {
                    if (drType != null)
                    {
                        t_invoice_payment objt_invoice_payment = new t_invoice_payment();
                        objt_invoice_payment.invNo = drType["invNo"].ToString();
                        objt_invoice_payment.location = drType["location"].ToString();
                        objt_invoice_payment.teminalId = drType["teminalId"].ToString();
                        objt_invoice_payment.paymodeId = drType["paymodeId"].ToString();
                        objt_invoice_payment.subPayMode = drType["subPayMode"].ToString();
                        objt_invoice_payment.rate = decimal.Parse(drType["rate"].ToString());
                        objt_invoice_payment.number = drType["number"].ToString();
                        objt_invoice_payment.subPayAmount = decimal.Parse(drType["subPayAmount"].ToString());
                        objt_invoice_payment.datex = DateTime.Parse(drType["datex"].ToString());
                        objt_invoice_payment.voucherNumber = drType["voucherNumber"].ToString();
                        objt_invoice_payment.totalAmount = decimal.Parse(drType["totalAmount"].ToString());
                        objt_invoice_payment.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_invoice_payment);
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
