using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_EmployeeDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Employees table.
        /// </summary>
        public Boolean Savem_EmployeeSP(M_Employees m_Employee, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_EmployeeSave";

                scom.Parameters.Add("@EmpID", SqlDbType.VarChar, 20).Value = m_Employee.EmpID;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = m_Employee.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Employee.Locacode;
                scom.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = m_Employee.Name;
                scom.Parameters.Add("@TP", SqlDbType.VarChar, 30).Value = m_Employee.TP;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 30).Value = m_Employee.Fax;
                scom.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = m_Employee.Email;
                scom.Parameters.Add("@Address1", SqlDbType.VarChar, 100).Value = m_Employee.Address1;
                scom.Parameters.Add("@Address2", SqlDbType.VarChar, 100).Value = m_Employee.Address2;
                scom.Parameters.Add("@Address3", SqlDbType.VarChar, 100).Value = m_Employee.Address3;
                scom.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 50).Value = m_Employee.ContactPerson;
                scom.Parameters.Add("@ContactPersonNo", SqlDbType.VarChar, 50).Value = m_Employee.ContactPersonNo;
                scom.Parameters.Add("@CurrentStatus", SqlDbType.VarChar, 20).Value = m_Employee.CurrentStatus;
                scom.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = m_Employee.type;
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


        public DataTable SelectAllm_Employee()
        {
            try
            {
                strquery = @"select empid , name  from [M_Employees]";
                DataTable dtm_Employee = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Employees Selectm_Employee(M_Employees objm_Employee)
        {
            try
            {
                strquery = @"select * from M_Employees where empid = '" + objm_Employee.EmpID + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Employee.EmpID = drType["EmpID"].ToString();
                    objm_Employee.Compcode = drType["Compcode"].ToString();
                    objm_Employee.Locacode = drType["Locacode"].ToString();
                    objm_Employee.Name = drType["Name"].ToString();
                    objm_Employee.TP = drType["TP"].ToString();
                    objm_Employee.Fax = drType["Fax"].ToString();
                    objm_Employee.Email = drType["Email"].ToString();
                    objm_Employee.Address1 = drType["Address1"].ToString();
                    objm_Employee.Address2 = drType["Address2"].ToString();
                    objm_Employee.Address3 = drType["Address3"].ToString();
                    objm_Employee.ContactPerson = drType["ContactPerson"].ToString();
                    objm_Employee.ContactPersonNo = drType["ContactPersonNo"].ToString();
                    objm_Employee.CurrentStatus = drType["CurrentStatus"].ToString();
                    objm_Employee.type = drType["type"].ToString();
                    return objm_Employee;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Employee(string stringm_Employee)
        {
            try
            {
                string xstrquery = @"select empid From M_Employees   WHERE empid = '" + stringm_Employee + "' ";
                DataRow drM_Employee = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Employee != null)
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

        public List<M_Employees> SelectM_EmployeeMulti(M_Employees objm_Employee2)
        {
            List<M_Employees> retval = new List<M_Employees>();
            try
            {
                strquery = @"select * from m_Employee where empid = '" + objm_Employee2.EmpID + "'";
                DataTable dtm_Employee = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_Employee.Rows)
                {
                    if (drType != null)
                    {
                        M_Employees objm_Employee = new M_Employees();
                        objm_Employee.EmpID = drType["EmpID"].ToString();
                        objm_Employee.Compcode = drType["Compcode"].ToString();
                        objm_Employee.Locacode = drType["Locacode"].ToString();
                        objm_Employee.Name = drType["Name"].ToString();
                        objm_Employee.TP = drType["TP"].ToString();
                        objm_Employee.Fax = drType["Fax"].ToString();
                        objm_Employee.Email = drType["Email"].ToString();
                        objm_Employee.Address1 = drType["Address1"].ToString();
                        objm_Employee.Address2 = drType["Address2"].ToString();
                        objm_Employee.Address3 = drType["Address3"].ToString();
                        objm_Employee.ContactPerson = drType["ContactPerson"].ToString();
                        objm_Employee.ContactPersonNo = drType["ContactPersonNo"].ToString();
                        objm_Employee.CurrentStatus = drType["CurrentStatus"].ToString();
                        objm_Employee.type = drType["type"].ToString();
                        retval.Add(objm_Employee);
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
