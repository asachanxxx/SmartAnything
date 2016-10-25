using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_ProductPriceChangeDL
    {

        string strquery = "";

        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_ProductPriceChange table.
        /// </summary>
        public Boolean SaveM_ProductPriceChangeSP(M_ProductPriceChange m_ProductPriceChange, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_ProductPriceChangeSave";

                scom.Parameters.Add("@Id", SqlDbType.VarChar, 20).Value = m_ProductPriceChange.Id;
                scom.Parameters.Add("@Product", SqlDbType.VarChar, 20).Value = m_ProductPriceChange.Product;
                scom.Parameters.Add("@ChangedPlace", SqlDbType.VarChar, 30).Value = m_ProductPriceChange.ChangedPlace;
                scom.Parameters.Add("@Currentcost", SqlDbType.Decimal, 9).Value = m_ProductPriceChange.Currentcost;
                scom.Parameters.Add("@NewCost", SqlDbType.Decimal, 9).Value = m_ProductPriceChange.NewCost;
                scom.Parameters.Add("@CurrentSelling", SqlDbType.Decimal, 9).Value = m_ProductPriceChange.CurrentSelling;
                scom.Parameters.Add("@NewSelling", SqlDbType.Decimal, 9).Value = m_ProductPriceChange.NewSelling;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = m_ProductPriceChange.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_ProductPriceChange.Datex;
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


        public DataTable SelectAllm_ProductPriceChange()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [M_Company]";
                DataTable dtm_ProductPriceChange = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_ProductPriceChange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_ProductPriceChange Selectm_ProductPriceChange(M_ProductPriceChange objm_ProductPriceChange)
        {
            try
            {
                strquery = @"select * from M_Company where CompCode = '";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_ProductPriceChange.Id = drType["Id"].ToString();
                    objm_ProductPriceChange.Product = drType["Product"].ToString();
                    objm_ProductPriceChange.ChangedPlace = drType["ChangedPlace"].ToString();
                    objm_ProductPriceChange.Currentcost = decimal.Parse(drType["Currentcost"].ToString());
                    objm_ProductPriceChange.NewCost = decimal.Parse(drType["NewCost"].ToString());
                    objm_ProductPriceChange.CurrentSelling = decimal.Parse(drType["CurrentSelling"].ToString());
                    objm_ProductPriceChange.NewSelling = decimal.Parse(drType["NewSelling"].ToString());
                    objm_ProductPriceChange.Userx = drType["Userx"].ToString();
                    objm_ProductPriceChange.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_ProductPriceChange;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_ProductPriceChange(string stringM_ProductPriceChange)
        {
            try
            {
                string xstrquery = @"select CompCode From M_Company   WHERE CompCode = ";
                DataRow drM_ProductPriceChange = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_ProductPriceChange != null)
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

        #endregion
    }
}
