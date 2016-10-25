using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_SupplierDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Suppliers table.
        /// </summary>
        public Boolean SaveM_SupplierSP(M_Suppliers m_Supplier, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_SuppliersSave";

                scom.Parameters.Add("@SupID", SqlDbType.VarChar, 20).Value = m_Supplier.SupID;
                scom.Parameters.Add("@suppName", SqlDbType.VarChar, 50).Value = m_Supplier.suppName;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = m_Supplier.CompCode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Supplier.Locacode;
                scom.Parameters.Add("@TP", SqlDbType.VarChar, 20).Value = m_Supplier.TP;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 20).Value = m_Supplier.Fax;
                scom.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = m_Supplier.Email;
                scom.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = m_Supplier.Address1;
                scom.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = m_Supplier.Address2;
                scom.Parameters.Add("@Address3", SqlDbType.VarChar, 50).Value = m_Supplier.Address3;
                scom.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 50).Value = m_Supplier.ContactPerson;
                scom.Parameters.Add("@ContactPersonNo", SqlDbType.VarChar, 50).Value = m_Supplier.ContactPersonNo;
                scom.Parameters.Add("@CurrentStatus", SqlDbType.VarChar, 20).Value = m_Supplier.CurrentStatus;
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


        public DataTable SelectAllm_Supplier()
        {
            try
            {
                strquery = @"SELECT [SupID] as 'Supplier Code' ,[suppName] as 'Supplier Name' FROM [M_Suppliers]";
                DataTable dtm_Supplier = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Supplier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Suppliers Selectm_Supplier(M_Suppliers objm_Supplier)
        {
            try
            {
                strquery = @"SELECT * FROM [M_Suppliers] where [SupID] = '" + objm_Supplier.SupID.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Supplier.SupID = drType["SupID"].ToString();
                    objm_Supplier.suppName = drType["suppName"].ToString();
                    objm_Supplier.CompCode = drType["CompCode"].ToString();
                    objm_Supplier.Locacode = drType["Locacode"].ToString();
                    objm_Supplier.TP = drType["TP"].ToString();
                    objm_Supplier.Fax = drType["Fax"].ToString();
                    objm_Supplier.Email = drType["Email"].ToString();
                    objm_Supplier.Address1 = drType["Address1"].ToString();
                    objm_Supplier.Address2 = drType["Address2"].ToString();
                    objm_Supplier.Address3 = drType["Address3"].ToString();
                    objm_Supplier.ContactPerson = drType["ContactPerson"].ToString();
                    objm_Supplier.ContactPersonNo = drType["ContactPersonNo"].ToString();
                    objm_Supplier.CurrentStatus = drType["CurrentStatus"].ToString();
                    return objm_Supplier;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Supplier(string stringM_Supplier)
        {
            try
            {
                string xstrquery = @"select SupID From M_Suppliers   WHERE SupID = '" + stringM_Supplier.Trim() + "'";
                DataRow drM_Supplier = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Supplier != null)
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
