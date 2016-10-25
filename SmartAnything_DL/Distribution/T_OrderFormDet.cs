using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_OrderFormDetDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_OrderFormDet table.
        /// </summary>
        public Boolean Savet_OrderFormDetSP(T_OrderFormDet t_OrderFormDet, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_OrderFormDetSave";

                scom.Parameters.Add("@Docno", SqlDbType.VarChar, 20).Value = t_OrderFormDet.Docno;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_OrderFormDet.CompCode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = t_OrderFormDet.Locacode;
                scom.Parameters.Add("@OFNo", SqlDbType.VarChar, 20).Value = t_OrderFormDet.OFNo;
                scom.Parameters.Add("@ItemCode", SqlDbType.VarChar, 20).Value = t_OrderFormDet.ItemCode;
                scom.Parameters.Add("@Quntity", SqlDbType.Decimal, 9).Value = t_OrderFormDet.Quntity;
                scom.Parameters.Add("@Barcode", SqlDbType.VarChar, 20).Value = t_OrderFormDet.Barcode;
                scom.Parameters.Add("@UnitPrice", SqlDbType.Decimal, 9).Value = t_OrderFormDet.UnitPrice;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = t_OrderFormDet.CostPrice;
                scom.Parameters.Add("@Unit", SqlDbType.VarChar, 20).Value = t_OrderFormDet.Unit;
                scom.Parameters.Add("@Amountx", SqlDbType.Decimal, 9).Value = t_OrderFormDet.Amountx;
                scom.Parameters.Add("@discper", SqlDbType.Decimal, 9).Value = t_OrderFormDet.discper;
                scom.Parameters.Add("@discount", SqlDbType.Decimal, 9).Value = t_OrderFormDet.discount;
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


        public DataTable SelectAllt_OrderFormDet()
        {
            try
            {
                strquery = @"select Docno ,ItemCode from T_OrderFormDet";
                DataTable dtt_OrderFormDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_OrderFormDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_OrderFormDet Selectt_OrderFormDet(T_OrderFormDet objt_OrderFormDet)
        {
            try
            {
                strquery = @"select * from t_OrderFormDet where Docno = '" + objt_OrderFormDet.Docno + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_OrderFormDet.Docno = drType["Docno"].ToString();
                    objt_OrderFormDet.CompCode = drType["CompCode"].ToString();
                    objt_OrderFormDet.Locacode = drType["Locacode"].ToString();
                    objt_OrderFormDet.OFNo = drType["OFNo"].ToString();
                    objt_OrderFormDet.ItemCode = drType["ItemCode"].ToString();
                    objt_OrderFormDet.Quntity = decimal.Parse(drType["Quntity"].ToString());
                    objt_OrderFormDet.Barcode = drType["Barcode"].ToString();
                    objt_OrderFormDet.UnitPrice = decimal.Parse(drType["UnitPrice"].ToString());
                    objt_OrderFormDet.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objt_OrderFormDet.discper = decimal.Parse(drType["discper"].ToString());
                    objt_OrderFormDet.discount = decimal.Parse(drType["discount"].ToString());
                    objt_OrderFormDet.Unit = drType["Unit"].ToString();
                    objt_OrderFormDet.Amountx = decimal.Parse(drType["Amountx"].ToString());
                    return objt_OrderFormDet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_OrderFormDet(string stringt_OrderFormDet)
        {
            try
            {
                string xstrquery = @"select Docno From T_OrderFormDet   WHERE Docno = '" + stringt_OrderFormDet + "' ";
                DataRow drT_OrderFormDet = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_OrderFormDet != null)
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

        public List<T_OrderFormDet> SelectT_OrderFormDetMulti(T_OrderFormDet objt_OrderFormDet2)
        {
            List<T_OrderFormDet> retval = new List<T_OrderFormDet>();
            try
            {
                strquery = @"select * from t_OrderFormDet where Docno = '" + objt_OrderFormDet2.Docno + "'";
                DataTable dtt_OrderFormDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_OrderFormDet.Rows)
                {
                    if (drType != null)
                    {
                        T_OrderFormDet objt_OrderFormDet = new T_OrderFormDet();
                        objt_OrderFormDet.Docno = drType["Docno"].ToString();
                        objt_OrderFormDet.CompCode = drType["CompCode"].ToString();
                        objt_OrderFormDet.Locacode = drType["Locacode"].ToString();
                        objt_OrderFormDet.OFNo = drType["OFNo"].ToString();
                        objt_OrderFormDet.ItemCode = drType["ItemCode"].ToString();
                        objt_OrderFormDet.Quntity = decimal.Parse(drType["Quntity"].ToString());
                        objt_OrderFormDet.Barcode = drType["Barcode"].ToString();
                        objt_OrderFormDet.UnitPrice = decimal.Parse(drType["UnitPrice"].ToString());
                        objt_OrderFormDet.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                        objt_OrderFormDet.discper = decimal.Parse(drType["discper"].ToString());
                        objt_OrderFormDet.discount = decimal.Parse(drType["discount"].ToString());
                        objt_OrderFormDet.Unit = drType["Unit"].ToString();
                        objt_OrderFormDet.Amountx = decimal.Parse(drType["Amountx"].ToString());
                        retval.Add(objt_OrderFormDet);
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
