//**********************************************************************
//Developer  :PUBUDU
//Date       :2013/10/04
//Description:Login
//Module Name: smartOffice
//Modified By Nilmini 2013/10/28,29
//**********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smartOffice_Models;
using System.Data;

namespace SmartAnything
{
    public class u_User_DL
    {
        string strquery="";
        DataRow drUser;
        DataRow drExistUser;
        DataRow drExistEmp;

        /// <summary>
        /// Load All table details according to the user enterd userID
        /// </summary>
        /// <param name="strUserId"> User enterd userID</param>
        /// <returns>Object of a u_User filled with user details</returns>
        public u_User getUser(string strUserId)
        {
            try
            {

                if (u_DBConnection.strDBType == DBEngine.MSSQL)
                    strquery = @"SELECT * FROM u_User WHERE userId='" + strUserId + "' ";
                else if (u_DBConnection.strDBType == DBEngine.MYSQL)
                    strquery = @"SELECT * FROM u_User WHERE userId='" + strUserId + "' ";
                else
                    strquery = @"SELECT * FROM u_User WHERE userId='" + strUserId + "' ";

                DataRow dr = u_DBConnection.ReturnDataRow(strquery);

                if (dr != null)
                {
                    u_User objUser = new u_User();
                    objUser.UserRole = new u_UserRole();
                    objUser.strUserID = dr["userId"].ToString();
                    objUser.strPassword = dr["password"].ToString();
                    objUser.intIsActive = Convert.ToInt32(dr["isActive"]);
                    objUser.UserRole.strRoleID = dr["roleId"].ToString();
                    return objUser;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ///// <summary>
        ///// Check whether there exist any users for the user entered ID
        ///// Modified By Nilmini 2013/10/28
        ///// </summary>
        ///// <param name="objUser">Object of a u_User class carried user ID</param>
        ///// <returns></returns>
        //public bool ExistingUser(u_User objUserDL)
        //{
        //    try
        //    {
        //        strquery = "select u.userId,u.userName,u.roleId,ur.description,u.isActive,u.empId ,e.name as [Employee Name] "+
        //                    "from u_User u inner join u_UserRoles ur on ur.roleId= u.roleId "+ 
        //                    "right outer join u_employee e on e.empId=u.empId where e.empId='" + objUserDL.Employee.strEmpID + "'";

        //        drUser = u_DBConnection.ReturnDataRow(strquery);

        //        if (drUser != null )
        //        {
        //            if(objUserDL.strUserID != "")
        //                return true;
        //            else objUserDL.strUserID = drUser["userId"].ToString();
                    
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        /// <summary>
        /// Update existing user in the  u_User table in the database
        /// Modified By Nilmini 2013/10/28
        /// </summary>
        /// <param name="objUser">Object of a u_User class carried Employee ID</param>
        /// <returns>if updated successfully, returns true, else false</returns>
        public bool UpdateUser(u_User objUser)
        {
            try
            {
                if (objUser.strPassword != "")
                {
                    strquery = "update u_User set userId='" + objUser.strUserID + "',userName='" + objUser.strUserName + "'," +
                                      "roleId='" + objUser.UserRole.strRoleID + "'," +
                                      "password='" + objUser.strPassword + "',isActive='" + objUser.intIsActive + "'," +
                                      "userModified='" + objUser.strEditUserID + "',dateModified='" + DateTime.Today + "'" +
                               "where empId='" + objUser.Employee.strEmpID + "'";
                }else
                    strquery = "update u_User set userId='" + objUser.strUserID + "',userName='" + objUser.strUserName + "'," +
                                      "roleId='" + objUser.UserRole.strRoleID + "'," +
                                      "isActive='" + objUser.intIsActive + "'," +
                                      "userModified='" + objUser.strEditUserID + "',dateModified='" + DateTime.Today + "'" +
                               "where empId='" + objUser.Employee.strEmpID + "'";

                u_DBConnection.ExecuteNonQuery(strquery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Add new user to the  u_User table in the database
        /// Modified By Nilmini 2013/10/28
        /// </summary>
        /// <param name="objUser">Object of a u_User class carried user details</param>
        /// <returns>If saved successfully returns true, else false</returns>
        public bool saveUser(u_User objUser)
        {
            try
            {
                strquery = "insert into u_User(userId,userName,"+
                                    "password,roleId,dateCreated,userCreated,isActive,empId) " +
                           "values ('" + objUser.strUserID + "','"+objUser.strUserName+"','"+objUser.strPassword+"',"+
                           "'"+objUser.UserRole.strRoleID+"','"+DateTime.Today+"','"+objUser.strEditUserID+"',"+
                           "'"+objUser.intIsActive+"','"+objUser.Employee.strEmpID+"')";

                u_DBConnection.ExecuteNonQuery(strquery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Gets User Details from the u_User table and u_UserRoles table in the database
        /// Modified By Nilmini 2013/10/28
        /// </summary>
        /// <param name="objUser">object of a u_User class in the smartOffice_Models which carried Employee ID</param>
        /// <returns>object of a u_User class in the smartOffice_Models which carried user details</returns>
        public u_User GetExistingUserToEmpID(u_User objUser)
        {
            try
            {
                strquery = "select u.userId,u.password,u.userName,u.roleId,ur.description,u.isActive,u.empId ,e.name as [Employee Name] " +
                            "from u_User u inner join u_UserRoles ur on ur.roleId= u.roleId "+ 
                            "right outer join u_employee e on e.empId=u.empId where e.empId='" + objUser.Employee.strEmpID + "'";

                drUser = u_DBConnection.ReturnDataRow(strquery);

                if (drUser != null)
                {
                    objUser.strUserID = drUser["userId"].ToString();
                    objUser.strUserName = drUser["userName"].ToString();
                    objUser.UserRole.strRoleID = drUser["roleId"].ToString();
                    objUser.UserRole.strDescription = drUser["description"].ToString();
                    objUser.Employee.strEmpName = drUser["Employee Name"].ToString();
                    objUser.strPassword = drUser["password"].ToString();
                    if (drUser["isActive"].ToString()!="")
                    objUser.intIsActive = Convert.ToInt32(drUser["isActive"].ToString());

                    return objUser;
                }
                return null;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check whether there exist any employees to the entered EmployeeID
        /// Modified By Nilmini 2013/10/29
        /// </summary>
        /// <param name="objUser">object of a u_User class in the smartOffice_Models which carried Employee ID</param>
        /// <returns>if employee exist in the employee table, returns true, else false</returns>
        public bool isEmpExist(u_User objUser)
        {
            try
            {
                strquery = "select name as [Employee Name],"+
                                  "empId as [Employee ID] "+
                           "from u_employee where empId='" + objUser.Employee.strEmpID + "'";

                drExistEmp = u_DBConnection.ReturnDataRow(strquery);
                if (drExistEmp != null) return true;
                return false;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check whether there exist any users to the entered EmployeeID
        /// Modified By Nilmini 2013/10/29
        /// </summary>
        /// <param name="objUser">object of a u_User class in the smartOffice_Models which carried Employee ID</param>
        /// <returns>if employee exist in the employee table, returns true, else false</returns>
        public bool isEmpUserExist(u_User objUser)
        {
            try
            {
                strquery = "select u.empId as [Employee ID],e.name as [Employee Name]," +
                                  "e.designation as [Designation] from u_User u inner join " +
                           "u_employee e on e.empId=u.empId where u.empId='" + objUser.Employee.strEmpID + "'";

                drExistEmp = u_DBConnection.ReturnDataRow(strquery);
                if (drExistEmp != null) return true;
                return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check whether there exist any Users to the entered EmployeeID in the u_User table
        /// Modified By Nilmini 2013/10/29
        /// </summary>
        /// <param name="objUser">object of a u_User class in the smartOffice_Models which carried Employee ID</param>
        /// <returns>if user exist in the u_User table, returns true, else false</returns>
        public bool isUserIDExistforEmployee(u_User objUser)
        {
            try
            {
                strquery="select userId,empId from u_User where empId='"+objUser.Employee.strEmpID+"'";

                drExistUser = u_DBConnection.ReturnDataRow(strquery);
                if (drExistUser != null) return true;
                return false;

            }
            catch (Exception ex)
            { 
                throw ex; 
            }
        }


        ///// <summary>
        ///// check whether an employee already has a userID or not
        ///// Modified By Nilmini 2013/10/28
        ///// </summary>
        ///// <param name="objUser">object of a u_User class in the smartOffice_Models which carried Employee ID</param>
        ///// <returns>if exist return true, else false</returns>
        //public bool IsUserExistForEmployee(u_User objUser)
        //{
        //    try
        //    {
        //        strquery = "select name as [Employee Name],(select userId from u_User where empId='" + objUser.Employee.strEmpID + "' ) as [User ID] " +
        //                   "from u_employee where empId='" + objUser.Employee.strEmpID + "'";

        //         drExistUser = u_DBConnection.ReturnDataRow(strquery);

        //         if (drExistUser != null)
        //        {
        //            objUser.strUserID = drExistUser["User ID"].ToString();
        //            if (objUser.strUserID != "") return true;
        //            else return false;
        //        }
        //        return false;
        //    }
        //    catch(Exception ex) 
        //    {
        //        throw ex;

        //    }
        //}

    }
}
