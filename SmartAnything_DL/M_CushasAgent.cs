using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_CushasAgentDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_CushasAgents table.
        /// </summary>
        public Boolean Savem_CushasAgentSP(M_CushasAgents m_CushasAgent, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_CushasAgentsSave";

                scom.Parameters.Add("@AgentCode", SqlDbType.VarChar, 20).Value = m_CushasAgent.AgentCode;
                scom.Parameters.Add("@CustomerCode", SqlDbType.VarChar, 20).Value = m_CushasAgent.CustomerCode;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_CushasAgent.Datex;
                scom.Parameters.Add("@userx", SqlDbType.VarChar, 20).Value = m_CushasAgent.userx;
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


        public DataTable SelectAllm_CushasAgent()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [M_CushasAgent]";
                DataTable dtm_CushasAgent = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_CushasAgent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_CushasAgents Selectm_CushasAgent(M_CushasAgents objm_CushasAgent)
        {
            try
            {
                strquery = @"select * from m_CushasAgent where AgentCode = '" + objm_CushasAgent.AgentCode + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_CushasAgent.AgentCode = drType["AgentCode"].ToString();
                    objm_CushasAgent.CustomerCode = drType["CustomerCode"].ToString();
                    objm_CushasAgent.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objm_CushasAgent.userx = drType["userx"].ToString();
                    return objm_CushasAgent;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_CushasAgent(string stringm_CushasAgent)
        {
            try
            {
                string xstrquery = @"select AgentCode From M_CushasAgent   WHERE AgentCode = '" + stringm_CushasAgent + "' ";
                DataRow drM_CushasAgent = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_CushasAgent != null)
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

        public List<M_CushasAgents> SelectM_CushasAgentMulti(M_CushasAgents objm_CushasAgent2)
        {
            List<M_CushasAgents> retval = new List<M_CushasAgents>();
            try
            {
                strquery = @"select * from M_CushasAgents where CustomerCode = '" + objm_CushasAgent2.CustomerCode + "'";
                DataTable dtm_CushasAgent = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_CushasAgent.Rows)
                {
                    if (drType != null)
                    {
                        M_CushasAgents objm_CushasAgent = new M_CushasAgents();
                        objm_CushasAgent.AgentCode = drType["AgentCode"].ToString();
                        objm_CushasAgent.CustomerCode = drType["CustomerCode"].ToString();
                        objm_CushasAgent.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objm_CushasAgent.userx = drType["userx"].ToString();
                        retval.Add(objm_CushasAgent);
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
