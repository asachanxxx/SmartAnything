using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smartOffice_Models;
using SmartAnything;
using System.Data;


namespace SmartAnything
{
    public class u_UserRights_DL
    {
        string strQuery = "";
        public bool boolAccess = false;
        public bool boolCreate = false;
        public bool boolModify = false;
        public bool boolDelete = false;
        public bool boolPrint = false;
        DataTable dtAuthorityBoolValues;
        string strRight;

        /// <summary>
        /// Gets the User rights from the u_UserRights table
        /// </summary>
        /// <param name="objURight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>DataTable filled with User rights</returns>
        public DataTable GetUserRights(u_UserRights objURight)
        {
            try
            {
                if (objURight.User.strUserID == "")
                {
                    strQuery = "select t.menuId as [Menu ID],t.description as [Menu Name],t.menuRights as [Menu Rights],t.mainOrder,t.subOrder from u_MenuTag t";
                }
                else
                {
                    strQuery = "select u.roleId as [Role ID],url.description as [Role Name], ur.userId as [User ID]," +
                                  "ur.menuId as [Menu ID],ur.menuRights as [Menu Rights],m.description as [Menu Name] " +
                            "from u_UserRights ur inner join u_MenuTag m on m.menuId=ur.menuId " +
                                                  "inner join u_User u on u.userId=ur.userId " +
                                                  "right outer join u_UserRoles url on url.roleId=u.roleId " +
                             "where ur.userId='" + objURight.User.strUserID + "'";

                }
                DataTable dtURights = u_DBConnection.ReturnDataTable(strQuery, CommandType.Text);
                return CreateDataTable(dtURights);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetUserRightsSecCenter(String userID)
        {
            try
            {
                strQuery = "select u.roleId as [Role ID],url.description as [Role Name], ur.userId as [User ID]," +
                               "ur.menuId as [Menu ID],ur.menuRights as [Menu Rights],m.description as [Menu Name] ,ur.menuId as [Menu ID] " +
                         "from u_UserRights ur inner join u_MenuTag m on m.menuId=ur.menuId " +
                                               "inner join u_User u on u.userId=ur.userId " +
                                               "right outer join u_UserRoles url on url.roleId=u.roleId " +
                          "where ur.userId='" + userID + "'";

                DataTable dtURights = u_DBConnection.ReturnDataTable(strQuery, CommandType.Text);
                return CreateDataTableNEw(dtURights);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public u_UserRights_DL GetUserRightsForOneMenu(u_UserRights objURight)
        {
            try
            {

                strQuery = "select ur.menuRights as [Menu Rights] from u_UserRights ur inner join u_MenuTag m on m.menuId=ur.menuId inner join u_User u on u.userId=ur.userId" + 
                           " right outer join u_UserRoles url on url.roleId=u.roleId where ur.userId='" + 
                           objURight.User.strUserID.Trim() + 
                           "' and ur.menuId = '" + 
                           objURight.MenuTag.strMenuID.Trim() + "'";

                DataTable dtURights = u_DBConnection.ReturnDataTable(strQuery, CommandType.Text);
                return CreateUserRights_DL(dtURights);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CreateDataTable(DataTable dtUserRights)
        {
            dtAuthorityBoolValues = new DataTable();
            dtAuthorityBoolValues.Columns.Add("UIName", typeof(string));
            dtAuthorityBoolValues.Columns.Add("role name", typeof(string));
            dtAuthorityBoolValues.Columns.Add("Role ID", typeof(string));
            dtAuthorityBoolValues.Columns.Add("menuRights", typeof(string));
            dtAuthorityBoolValues.Columns.Add("dtAccess", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("dtCreate", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("dtModify", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("dtDelete", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("dtPrint", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("Code", typeof(string));

            for (int i = 0; i < dtUserRights.Rows.Count; i++)
            {

                strRight = dtUserRights.Rows[i]["Menu Rights"].ToString();
                if (strRight == null)
                    return dtUserRights;

                for (int j = 0; j < (strRight.Trim()).Length; j++)
                {
                    if (strRight[j] == 'A')
                        boolAccess = true;
                    if (strRight[j] == 'C')
                        boolCreate = true;
                    if (strRight[j] == 'M')
                        boolModify = true;
                    if (strRight[j] == 'D')
                        boolDelete = true;
                    if (strRight[j] == 'P')
                        boolPrint = true;
                }


                dtAuthorityBoolValues.Rows.Add(dtUserRights.Rows[i]["Menu Name"].ToString(), dtUserRights.Rows[i]["Role Name"].ToString(), dtUserRights.Rows[i]["Role ID"].ToString(), dtUserRights.Rows[i]["Menu Rights"].ToString(), boolAccess, boolCreate, boolModify, boolDelete, boolPrint, dtUserRights.Rows[i]["Menu ID"].ToString());
                boolAccess = false;
                boolCreate = false;
                boolModify = false;
                boolDelete = false;
                boolPrint = false;
            }
            return dtAuthorityBoolValues;
        }

           //strQuery = "select u.roleId as [Role ID], ur.userId as [User ID]," +
           //                   "ur.menuId as [Menu ID],ur.menuRights as [Menu Rights],m.description as [Menu Name] " +
           //             "from u_UserRights ur inner join u_MenuTag m on m.menuId=ur.menuId " +
           //                                   "inner join u_User u on u.userId=ur.userId " +
           //                                   "right outer join u_UserRoles url on url.roleId=u.roleId " +
           //              "where ur.userId='" + userID + "'";



        public DataTable CreateDataTableNEw (DataTable dtUserRights)
        {
            dtAuthorityBoolValues = new DataTable();
            dtAuthorityBoolValues.Columns.Add("Menu Id", typeof(string));
            dtAuthorityBoolValues.Columns.Add("Menu Name", typeof(string));
            dtAuthorityBoolValues.Columns.Add("Access", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("Create", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("Modify", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("Delete", typeof(bool));
            dtAuthorityBoolValues.Columns.Add("Print", typeof(bool));
            

            for (int i = 0; i < dtUserRights.Rows.Count; i++)
            {

                strRight = dtUserRights.Rows[i]["Menu Rights"].ToString();
                if (strRight == null)
                    return dtUserRights;

                for (int j = 0; j < (strRight.Trim()).Length; j++)
                {
                    if (strRight[j] == 'A')
                        boolAccess = true;
                    if (strRight[j] == 'C')
                        boolCreate = true;
                    if (strRight[j] == 'M')
                        boolModify = true;
                    if (strRight[j] == 'D')
                        boolDelete = true;
                    if (strRight[j] == 'P')
                        boolPrint = true;
                }


                dtAuthorityBoolValues.Rows.Add(dtUserRights.Rows[i]["Menu ID"].ToString(), dtUserRights.Rows[i]["Menu Name"].ToString(), boolAccess, boolCreate, boolModify, boolDelete, boolPrint);
                boolAccess = false;
                boolCreate = false;
                boolModify = false;
                boolDelete = false;
                boolPrint = false;
            }
            return dtAuthorityBoolValues;
        }

        public u_UserRights_DL CreateUserRights_DL(DataTable dtUserRights)
        {
            u_UserRights_DL bl = new u_UserRights_DL();
            for (int i = 0; i < dtUserRights.Rows.Count; i++)
            {

                strRight = dtUserRights.Rows[i]["Menu Rights"].ToString();
                //if (strRight == null)
                //    //return dtUserRights;

                for (int j = 0; j < (strRight.Trim()).Length; j++)
                {
                    if (strRight[j] == 'A')
                        bl.boolAccess= true;
                    if (strRight[j] == 'C')
                        bl.boolCreate = true;
                    if (strRight[j] == 'M')
                        bl.boolModify = true;
                    if (strRight[j] == 'D')
                        bl.boolDelete = true;
                    if (strRight[j] == 'P')
                        bl.boolPrint = true;
                }
            }
            return bl;
        }

        //select ur.menuRights as [Menu Rights] from u_UserRights ur inner join u_MenuTag m on m.menuId=ur.menuId inner join u_User u on u.userId=ur.userId right outer join u_UserRoles url on url.roleId=u.roleId where ur.userId='Admin' and ur.menuId = 'A0003'

        /// <summary>
        /// Gets the User rights from the u_UserRoleRights table
        /// </summary>
        /// <param name="objURight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>DataTable filled with User Role rights</returns>
        public DataTable GetUserRoleRightsToUserID(u_UserRights objURight)
        {
            try
            {
                
                
                    strQuery = "select ur.roleId as [Role ID],ur.menuId as [Menu ID],ur.menuRights as [Menu Rights],m.description as [Menu Name],url.description as [Role Name] " +
                               "from u_UserRoleRights ur inner join u_MenuTag m on m.menuId=ur.menuId inner join u_UserRoles url on url.roleId=ur.roleId " +
                               "where ur.roleId=(select roleId from u_User where userId='" + objURight.User.strUserID + "')";

                
                DataTable dtURights = u_DBConnection.ReturnDataTable(strQuery, CommandType.Text);
                return dtURights;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check whether user enterd UserID and menuID is exist or not
        /// </summary>
        /// <param name="objUserRight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>If exist in the database,returns true, else false</returns>
        public bool ExistingUserRights(u_UserRights objUserRight)
        {
            try
            {
                strQuery = "select menuRights from u_UserRights where userId='"+objUserRight.User.strUserID+"'"+
                                 " and menuId=(select menuId from u_MenuTag where description='"+objUserRight.MenuTag.strDescription+"')";

                DataRow drUserRight = u_DBConnection.ReturnDataRow(strQuery);

                if (drUserRight != null) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Save the Data in the u_UserRights table in the database
        /// </summary>
        /// <param name="objUserRight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>If saved Successfully,returns true, else false</returns>
        public bool SaveUserRights(u_UserRights objUserRight)
        {
            try
            {
                strQuery = "insert into u_UserRights(userId,menuId,menuRights) "+
                            "values('"+objUserRight.User.strUserID+"',(select menuId from u_MenuTag where description='"+objUserRight.MenuTag.strDescription+"'),"+
                            "'"+objUserRight.strMenuRights+"')";

                u_DBConnection.ExecuteNonQuery(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool SaveUserRightsNEw(string userif, string menuid,string menurights)
        {
            try
            {
                strQuery = "UPDATE [RIT_AT].[dbo].[u_UserRights]   SET [menuRights] = '" + menurights + "'  WHERE  userId = '" + userif + "' AND menuId = '" + menuid.Trim() + "'";
                u_DBConnection.ExecuteNonQuery(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         /// <summary>
        /// Update the Data in the u_UserRights table in the database
        /// </summary>
        /// <param name="objUserRight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>If Updated Successfully,returns true, else false</returns>
        public bool UpdateRights(u_UserRights objUserRight)
        {
            try
            {
                strQuery = "update u_UserRights set menuRights='"+objUserRight.strMenuRights+"' "+
                           "where userId='"+objUserRight.User.strUserID+"' and "+ 
                           "menuId=(select menuId from u_MenuTag where description='"+objUserRight.MenuTag.strDescription+"')";
                u_DBConnection.ExecuteNonQuery(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the User rights from the u_UserRights table  according to MenuTag
        /// </summary>
        /// <param name="objURight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>DataTable filled with User rights</returns>
        public DataTable GetUserRightsToMenuTag(u_UserRights objURight)
        {
            try
            {
                if (objURight.User.strUserID == "")
                {
                    strQuery = "select t.menuId as [Menu ID],t.description as [Menu Name],t.menuRights as [Menu Rights],t.mainOrder,t.subOrder from u_MenuTag t";
                }
                else
                {
                    strQuery = "select u.roleId as [Role ID],url.description as [Role Name], ur.userId as [User ID]," +
                                  "ur.menuId as [Menu ID],ur.menuRights as [Menu Rights],m.description as [Menu Name] " +
                            "from u_UserRights ur inner join u_MenuTag m on m.menuId=ur.menuId " +
                                                  "inner join u_User u on u.userId=ur.userId " +
                                                  "right outer join u_UserRoles url on url.roleId=u.roleId " +
                             "where ur.userId='" + objURight.User.strUserID + "'  and ur.menuId='" + objURight.MenuTag.strMenuID + "'";

                }
                DataTable dtURights = u_DBConnection.ReturnDataTable(strQuery, CommandType.Text);
                return dtURights;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


     
    }
}
