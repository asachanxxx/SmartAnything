using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_CNGroupingDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_CNGrouping table.
        /// </summary>
        public Boolean Savet_CNGroupingSP(T_CNGrouping t_CNGrouping, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_CNGroupingSave";

                scom.Parameters.Add("@Docno", SqlDbType.VarChar, 20).Value = t_CNGrouping.Docno;
                scom.Parameters.Add("@ItemCode", SqlDbType.VarChar, 20).Value = t_CNGrouping.ItemCode;
                scom.Parameters.Add("@Name", SqlDbType.VarChar, 150).Value = t_CNGrouping.Name;
                scom.Parameters.Add("@CNType", SqlDbType.VarChar, 20).Value = t_CNGrouping.CNType;
                scom.Parameters.Add("@CNReason", SqlDbType.VarChar, 20).Value = t_CNGrouping.CNReason;
                scom.Parameters.Add("@InvoiceQty", SqlDbType.Decimal, 9).Value = t_CNGrouping.InvoiceQty;
                scom.Parameters.Add("@CNQTY", SqlDbType.Decimal, 9).Value = t_CNGrouping.CNQTY;
                scom.Parameters.Add("@BreakdownQTY", SqlDbType.Decimal, 9).Value = t_CNGrouping.BreakdownQTY;
                scom.Parameters.Add("@TagNumber", SqlDbType.VarChar, 50).Value = t_CNGrouping.TagNumber;
                scom.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = t_CNGrouping.Selected;
                scom.Parameters.Add("@SelectedQTY", SqlDbType.Decimal, 9).Value = t_CNGrouping.SelectedQTY;
                scom.Parameters.Add("@balanceQTY", SqlDbType.Decimal, 9).Value = t_CNGrouping.balanceQTY;
                scom.Parameters.Add("@Shipped", SqlDbType.Bit, 1).Value = t_CNGrouping.Shipped;
                scom.Parameters.Add("@ShippedDate", SqlDbType.DateTime, 8).Value = t_CNGrouping.ShippedDate;
                scom.Parameters.Add("@ShippedDO", SqlDbType.VarChar, 20).Value = t_CNGrouping.ShippedDO;
                scom.Parameters.Add("@CNnumber", SqlDbType.VarChar, 20).Value = t_CNGrouping.CNnumber;
                scom.Parameters.Add("@PartEntered", SqlDbType.Bit, 1).Value = t_CNGrouping.PartEntered;
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


        public DataTable SelectAllt_CNGrouping()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_CNGrouping]";
                DataTable dtt_CNGrouping = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_CNGrouping;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_CNGrouping Selectt_CNGrouping(T_CNGrouping objt_CNGrouping,string cnnum, string itemcode)
        {
            try
            {
                strquery = @"SELECT * FROM dbo.T_CNGrouping WHERE Docno = '" + cnnum + "' AND ItemCode = '" + itemcode + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_CNGrouping.Docno = drType["Docno"].ToString();
                    objt_CNGrouping.ItemCode = drType["ItemCode"].ToString();
                    objt_CNGrouping.Name = drType["Name"].ToString();
                    objt_CNGrouping.CNType = drType["CNType"].ToString();
                    objt_CNGrouping.CNReason = drType["CNReason"].ToString();
                    objt_CNGrouping.InvoiceQty = decimal.Parse(drType["InvoiceQty"].ToString());
                    objt_CNGrouping.CNQTY = decimal.Parse(drType["CNQTY"].ToString());
                    objt_CNGrouping.BreakdownQTY = decimal.Parse(drType["BreakdownQTY"].ToString());
                    objt_CNGrouping.TagNumber = drType["TagNumber"].ToString();
                    objt_CNGrouping.Selected = bool.Parse(drType["Selected"].ToString());
                    objt_CNGrouping.SelectedQTY = decimal.Parse(drType["SelectedQTY"].ToString());
                    objt_CNGrouping.balanceQTY = decimal.Parse(drType["balanceQTY"].ToString());
                    objt_CNGrouping.Shipped = bool.Parse(drType["Shipped"].ToString());
                    objt_CNGrouping.ShippedDate = DateTime.Parse(drType["ShippedDate"].ToString());
                    objt_CNGrouping.ShippedDO = drType["ShippedDO"].ToString();
                    objt_CNGrouping.CNnumber = drType["CNnumber"].ToString();
                    objt_CNGrouping.PartEntered = bool.Parse(drType["PartEntered"].ToString());
                    return objt_CNGrouping;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_CNGrouping(string stringt_CNGrouping)
        {
            try
            {
                string xstrquery = @"select CompCode From T_CNGrouping   WHERE CompCode = '" + stringt_CNGrouping + "' ";
                DataRow drT_CNGrouping = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_CNGrouping != null)
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

        public List<T_CNGrouping> SelectT_CNGroupingMulti(T_CNGrouping objt_CNGrouping2)
        {
            List<T_CNGrouping> retval = new List<T_CNGrouping>();
            try
            {
                strquery = @"select * from t_CNGrouping where Docno = '" + objt_CNGrouping2.Docno + "'";
                DataTable dtt_CNGrouping = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_CNGrouping.Rows)
                {
                    if (drType != null)
                    {
                        T_CNGrouping objt_CNGrouping = new T_CNGrouping();
                        objt_CNGrouping.Docno = drType["Docno"].ToString();
                        objt_CNGrouping.ItemCode = drType["ItemCode"].ToString();
                        objt_CNGrouping.Name = drType["Name"].ToString();
                        objt_CNGrouping.CNType = drType["CNType"].ToString();
                        objt_CNGrouping.CNReason = drType["CNReason"].ToString();
                        objt_CNGrouping.InvoiceQty = decimal.Parse(drType["InvoiceQty"].ToString());
                        objt_CNGrouping.CNQTY = decimal.Parse(drType["CNQTY"].ToString());
                        objt_CNGrouping.BreakdownQTY = decimal.Parse(drType["BreakdownQTY"].ToString());
                        objt_CNGrouping.TagNumber = drType["TagNumber"].ToString();
                        objt_CNGrouping.Selected = bool.Parse(drType["Selected"].ToString());
                        objt_CNGrouping.SelectedQTY = decimal.Parse(drType["SelectedQTY"].ToString());
                        objt_CNGrouping.balanceQTY = decimal.Parse(drType["balanceQTY"].ToString());
                        objt_CNGrouping.Shipped = bool.Parse(drType["Shipped"].ToString());
                        objt_CNGrouping.ShippedDate = DateTime.Parse(drType["ShippedDate"].ToString());
                        objt_CNGrouping.ShippedDO = drType["ShippedDO"].ToString();
                        objt_CNGrouping.CNnumber = drType["CNnumber"].ToString();
                        objt_CNGrouping.PartEntered = bool.Parse(drType["PartEntered"].ToString());
                        retval.Add(objt_CNGrouping);
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
