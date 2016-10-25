using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_AgentDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Agents table.
        /// </summary>
        public Boolean SaveM_AgentSP(M_Agents m_Agent, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_AgentsSave";

                scom.Parameters.Add("@AgentCode", SqlDbType.VarChar, 20).Value = m_Agent.AgentCode;
                scom.Parameters.Add("@Namex", SqlDbType.VarChar, 50).Value = m_Agent.Namex;
                scom.Parameters.Add("@Address1", SqlDbType.VarChar, 150).Value = m_Agent.Address1;
                scom.Parameters.Add("@Address2", SqlDbType.VarChar, 150).Value = m_Agent.Address2;
                scom.Parameters.Add("@Address3", SqlDbType.VarChar, 150).Value = m_Agent.Address3;
                scom.Parameters.Add("@TPOffice", SqlDbType.VarChar, 50).Value = m_Agent.TPOffice;
                scom.Parameters.Add("@TPPersonal", SqlDbType.VarChar, 50).Value = m_Agent.TPPersonal;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 50).Value = m_Agent.Fax;
                scom.Parameters.Add("@Email", SqlDbType.VarChar, 20).Value = m_Agent.Email;
                scom.Parameters.Add("@AccNo", SqlDbType.VarChar, 20).Value = m_Agent.AccNo;
                scom.Parameters.Add("@NICno", SqlDbType.VarChar, 20).Value = m_Agent.NICno;
                scom.Parameters.Add("@PassportNo", SqlDbType.VarChar, 20).Value = m_Agent.PassportNo;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_Agent.Datex;
                scom.Parameters.Add("@userx", SqlDbType.VarChar, 20).Value = m_Agent.userx;
                scom.Parameters.Add("@TimeFrom", SqlDbType.DateTime, 8).Value = m_Agent.TimeFrom;
                scom.Parameters.Add("@TimeTo", SqlDbType.DateTime, 8).Value = m_Agent.TimeTo;
                scom.Parameters.Add("@District", SqlDbType.VarChar, 20).Value = m_Agent.District;
                scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 150).Value = m_Agent.Remarks;
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


        public DataTable SelectAllm_Agent()
        {
            try
            {
                strquery = @"select AgentCode as 'Agent Code' , Namex as 'Agent Name' from M_Agents";
                DataTable dtm_Agent = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Agent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Agents Selectm_Agent(M_Agents objm_Agent)
        {
            try
            {
                strquery = @"select * from M_Agents where AgentCode = '" + objm_Agent .AgentCode + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Agent.AgentCode = drType["AgentCode"].ToString();
                    objm_Agent.Namex = drType["Namex"].ToString();
                    objm_Agent.Address1 = drType["Address1"].ToString();
                    objm_Agent.Address2 = drType["Address2"].ToString();
                    objm_Agent.Address3 = drType["Address3"].ToString();
                    objm_Agent.TPOffice = drType["TPOffice"].ToString();
                    objm_Agent.TPPersonal = drType["TPPersonal"].ToString();
                    objm_Agent.Fax = drType["Fax"].ToString();
                    objm_Agent.Email = drType["Email"].ToString();
                    objm_Agent.AccNo = drType["AccNo"].ToString();
                    objm_Agent.NICno = drType["NICno"].ToString();
                    objm_Agent.PassportNo = drType["PassportNo"].ToString();
                    objm_Agent.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objm_Agent.userx = drType["userx"].ToString();
                    objm_Agent.TimeFrom = DateTime.Parse(drType["TimeFrom"].ToString());
                    objm_Agent.TimeTo = DateTime.Parse(drType["TimeTo"].ToString());
                    objm_Agent.District = drType["District"].ToString();
                    objm_Agent.Remarks = drType["Remarks"].ToString();
                    return objm_Agent;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Agent(string stringM_Agent)
        {
            try
            {
                string xstrquery = @"select AgentCode From M_Agents   WHERE AgentCode = '" + stringM_Agent + "'";
                DataRow drM_Agent = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Agent != null)
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
