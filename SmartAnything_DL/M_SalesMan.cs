using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_SalesManDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_SalesMan table.
        /// </summary>
        public Boolean SaveM_SalesManSP(M_SalesMan m_SalesMan, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_SalesManSave";

                scom.Parameters.Add("@SalesmanID", SqlDbType.VarChar, 20).Value = m_SalesMan.SalesmanID;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = m_SalesMan.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_SalesMan.Locacode;
                scom.Parameters.Add("@SalesmanName", SqlDbType.VarChar, 50).Value = m_SalesMan.SalesmanName;
                scom.Parameters.Add("@TP", SqlDbType.VarChar, 20).Value = m_SalesMan.TP;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 20).Value = m_SalesMan.Fax;
                scom.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = m_SalesMan.Email;
                scom.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = m_SalesMan.Address1;
                scom.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = m_SalesMan.Address2;
                scom.Parameters.Add("@Address3", SqlDbType.VarChar, 50).Value = m_SalesMan.Address3;
                scom.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 20).Value = m_SalesMan.ContactPerson;
                scom.Parameters.Add("@ContactPersonNo", SqlDbType.VarChar, 50).Value = m_SalesMan.ContactPersonNo;
                scom.Parameters.Add("@CurrentStatus", SqlDbType.VarChar, 20).Value = m_SalesMan.CurrentStatus;
                scom.Parameters.Add("@Gradex", SqlDbType.VarChar, 20).Value = m_SalesMan.Gradex;
                scom.Parameters.Add("@NICNo", SqlDbType.VarChar, 20).Value = m_SalesMan.NICNo;
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


        public DataTable SelectAllm_SalesMan()
        {
            try
            {
                strquery = @"select SalesmanID as 'Salesman Code' , SalesmanName as 'Salesman Name' from M_SalesMan";
                DataTable dtm_SalesMan = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_SalesMan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_SalesMan Selectm_SalesMan(M_SalesMan objm_SalesMan)
        {
            try
            {
                strquery = @"select * from M_SalesMan where SalesmanID = '" + objm_SalesMan.SalesmanID  + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_SalesMan.SalesmanID = drType["SalesmanID"].ToString();
                    objm_SalesMan.Compcode = drType["Compcode"].ToString();
                    objm_SalesMan.Locacode = drType["Locacode"].ToString();
                    objm_SalesMan.SalesmanName = drType["SalesmanName"].ToString();
                    objm_SalesMan.TP = drType["TP"].ToString();
                    objm_SalesMan.Fax = drType["Fax"].ToString();
                    objm_SalesMan.Email = drType["Email"].ToString();
                    objm_SalesMan.Address1 = drType["Address1"].ToString();
                    objm_SalesMan.Address2 = drType["Address2"].ToString();
                    objm_SalesMan.Address3 = drType["Address3"].ToString();
                    objm_SalesMan.ContactPerson = drType["ContactPerson"].ToString();
                    objm_SalesMan.ContactPersonNo = drType["ContactPersonNo"].ToString();
                    objm_SalesMan.CurrentStatus = drType["CurrentStatus"].ToString();
                    objm_SalesMan.Gradex = drType["Gradex"].ToString();
                    objm_SalesMan.NICNo = drType["NICNo"].ToString();
                    return objm_SalesMan;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_SalesMan(string stringM_SalesMan)
        {
            try
            {
                string xstrquery = @"select SalesmanID from M_SalesMan where SalesmanID = '" + stringM_SalesMan  + "'";
                DataRow drM_SalesMan = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_SalesMan != null)
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
