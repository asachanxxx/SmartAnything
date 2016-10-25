using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartAnything;
using smartOffice_Models;
using System.Data;


namespace smartOffice_BL
{
    public class u_UserRights_BL
    {
        bool boolAccess = false;
        bool boolCreate = false;
        bool boolModify = false;
        bool boolDelete = false;
        bool boolPrint = false;
        DataTable dtAuthorityBoolValues;
        string strRight;


        /// <summary>
        /// Call the GetUserRights method in the data Access Layer
        /// </summary>
        /// <param name="objURight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>DataTable filled with user rights</returns>
        public DataTable GetUserRights(u_UserRights objURight)
        {
            try
            {
                u_UserRights_DL objURightDL = new u_UserRights_DL();
                DataTable dtUserRights = objURightDL.GetUserRights(objURight);

                return CreateDataTable(dtUserRights);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Call the GetUserRoleRightsToUserID method in the data Access Layer
        /// </summary>
        /// <param name="objURight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>DataTable filled with user rights</returns>
        public DataTable GetUserRoleRightsToUserID(u_UserRights objURight)
        {
            try
            {
                u_UserRights_DL objURightDL = new u_UserRights_DL();
                DataTable dtUserRights = objURightDL.GetUserRoleRightsToUserID(objURight);

                return CreateDataTable(dtUserRights);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
             /// <summary>
        /// Save the Data By accessing the Data Access Layer
        /// </summary>
        /// <param name="objUserRight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>If saved Successfully,returns true, else false</returns>
        public bool SaveUserRights(u_UserRights objUserRight)
        {
            try
            {
                u_UserRights_DL objUserRightDL = new u_UserRights_DL();
                if (objUserRightDL.ExistingUserRights(objUserRight) == false)
                    return objUserRightDL.SaveUserRights(objUserRight);

                else return objUserRightDL.UpdateRights(objUserRight);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Call the GetUserRightsToMenuTag method in the data Access Layer
        /// </summary>
        /// <param name="objURight">Object of a u_UserRights class in smartOffice_Models</param>
        /// <returns>DataTable filled with user rights</returns>
        public DataTable GetUserRightsToMenuTag(u_UserRights objURight)
        {
            try
            {
                u_UserRights_DL objURightDL = new u_UserRights_DL();
                DataTable dtUserRights = objURightDL.GetUserRightsToMenuTag(objURight);


                return CreateDataTable(dtUserRights);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Original RIghts from the table and create separate table to leasy access to the rights
        /// </summary>
        /// <param name="dtUserRights">0000000001	Administrator	ADMIN	A0001	ACMDP	Agents</param>
        /// <returns></returns>
        public DataTable CreateDataTable( DataTable dtUserRights)
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
    }
}
