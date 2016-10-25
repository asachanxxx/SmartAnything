//************************************************************************
//Developer  :PUBUDU
//Date       :2013/10/04
//Description:Login
//Module Name: smartOffice
//Modified By Nilmini 2013/10/28,29
//************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using SmartAnything;
using smartOffice_Models;
using Microsoft.VisualBasic;


namespace smartOffice_BL
{

    public class u_User_BL
    {
        public enum LoginStatus
        {
            InvalidUserId,
            Invalidpassword,
            RestrictedUser,
            Success
        }

        /// <summary>
        /// To check whether the entered password and user ID are correct or not
        /// </summary>
        /// <param name="strUserId"> userID of the user</param>
        /// <param name="strPassword">password of the user</param>
        /// <returns>Returns Login status</returns>
        public LoginStatus CheckAuthentication(string strUserId,string strPassword)
        {
            try
            {
                u_User objUser = new u_User_DL().getUser(strUserId);
                if (objUser == null)
                    return LoginStatus.InvalidUserId;

                if (CreateCheckPassword(true,strPassword)!=objUser.strPassword)
                    return LoginStatus.Invalidpassword;

                if (objUser.intIsActive == 0)
                    return LoginStatus.RestrictedUser;

                return LoginStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Decrypts the encrypted password in the database
        /// </summary>
        /// <param name="blnEncrypt"> encrypted or not</param>
        /// <param name="strPassword">password of user</param>
        /// <returns></returns>
        private string CreateCheckPassword(bool blnEncrypt, string strPassword)
        {
            try
            {
                string strHold = "";

                if (blnEncrypt == true)
                {
                    for (int intI = 1; intI <= strPassword.Length; intI++)
                    {
                        strHold = strHold + Strings.Chr(Strings.Asc(strPassword.Substring(intI - 1, 1)) + 96 + intI);
                        
                    }
                }
                else
                {
                    for (int intI = 1; intI <= strPassword.Length; intI++)
                    {
                        strHold = strHold + Strings.Chr(Strings.Asc(strPassword.Substring(intI-1, 1)) - 96 - intI);
                    }
                }
                return strHold;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Save new User or update existing User
        /// Modified By Nilmini 2013/10/28
        /// </summary>
        /// <param name="objUser">Object of a u_User class carried Employee ID</param>
        /// <returns>if saved or updated successfully, returns true, else false</returns>
        public bool SaveUser(u_User objUser)
        {
            try
            {
                u_User_DL objUserDL = new u_User_DL();
                objUser.strPassword = CreateCheckPassword(true, objUser.strPassword);
                if (objUserDL.isUserIDExistforEmployee(objUser) == true)
                {
                    return objUserDL.UpdateUser(objUser);
                }
                else return objUserDL.saveUser(objUser);
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
        /// <returns>if user exist in the u_User table, returns user details, else null</returns>
        public u_User GetUserDetailsforEmployeeID(u_User objUser)
        {
            try
            {
                u_User_DL objUserDL= new u_User_DL();

                if (objUserDL.isEmpExist(objUser) == true)
                {
                    objUser=objUserDL.GetExistingUserToEmpID(objUser);
                    objUser.strPassword = CreateCheckPassword(false, objUser.strPassword);
                    return objUser;
                   
                }
                else return null;

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
        /// <returns>if user exist in the u_User table, returns user details, else null</returns>
        public u_User GetUserDetailsforEmployeeIDToEdit(u_User objUser)
        {
            try
            {
                u_User_DL objUserDL = new u_User_DL();

                if (objUserDL.isEmpExist(objUser) == true)
                {
                    if (objUserDL.isEmpUserExist(objUser) == true)
                    {
                        objUser = objUserDL.GetExistingUserToEmpID(objUser);
                        objUser.strPassword = CreateCheckPassword(false, objUser.strPassword);
                        return objUser;
                    }
                        
                    else return null;
                }
                else return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Edit existing User
        /// Modified By Nilmini 2013/12/18
        /// </summary>
        /// <param name="objUser">Object of a u_User class carried Employee ID</param>
        /// <returns>if saved or updated successfully, returns true, else false</returns>
        public bool EditUser(u_User objUser)
        {
            try
            {
                u_User_DL objUserDL = new u_User_DL();
                objUser.strPassword = CreateCheckPassword(true, objUser.strPassword);
                //if (objUserDL.isUserIDExistforEmployee(objUser) == true)
                //{
                //    return objUserDL.UpdateUser(objUser);
                //}


                return objUserDL.UpdateUser(objUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Check whether there exist any employees to the entered EmployeeID
        /// Modified By Nilmini 2013/12/18
        /// </summary>
        /// <param name="objUser">object of a u_User class in the smartOffice_Models which carried Employee ID</param>
        /// <returns>if employee exist in the employee table, returns true, else false</returns>
        public bool isEmpExist(u_User objUser)
        {
            try
            {
                u_User_DL objUserDL = new u_User_DL();
                return objUserDL.isEmpExist(objUser);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Load All table details according to the user enterd userID
        /// </summary>
        /// <param name="strUserId"> User enterd userID</param>
        /// <returns>Object of a u_User filled with user details</returns>
        public u_User getUser(string strUserId)
        {
            try
            {
                u_User_DL objUserDL = new u_User_DL();
                return objUserDL.getUser(strUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Gets All menuRights for every Menutags and set visibility to menustrip items
        /// </summary>
        public bool checkUserPermission(u_User User, string g_MenuId,string oparation)
        {
            u_UserRights objUserRight = new u_UserRights();
            objUserRight.User = new u_User();
            objUserRight.MenuTag = new u_MenuTag();
            u_UserRights_BL objUserRghtsBL = new u_UserRights_BL();
            objUserRight.User.strUserID = User.strUserID;
           objUserRight.MenuTag.strMenuID = g_MenuId;
            DataTable dtAllMenuItems = objUserRghtsBL.GetUserRights(objUserRight);

            if (dtAllMenuItems.Rows.Count != 0)
            {
                for (int i = 0; i < dtAllMenuItems.Rows.Count; i++)
                {
                    switch (oparation) 
                    {
                        case "process":
                            if (Convert.ToBoolean(dtAllMenuItems.Rows[i]["dtPrint"].ToString()) == true)
                            {
                                return true;
                            }
                        break;
                    }
                }
            }
            return false;
        }
    }
}
