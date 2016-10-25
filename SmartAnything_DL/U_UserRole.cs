using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class U_UserRolexDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the u_UserRoles table.
        /// </summary>
        public Boolean Saveu_UserRoleSP(u_UserRolex u_UserRole, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "U_UserRoleSave";

                scom.Parameters.Add("@roleId", SqlDbType.VarChar, 10).Value = u_UserRole.roleId;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = u_UserRole.description;
                scom.Parameters.Add("@userCreated", SqlDbType.VarChar, 10).Value = u_UserRole.userCreated;
                scom.Parameters.Add("@dateCreated", SqlDbType.DateTime, 8).Value = u_UserRole.dateCreated;
                scom.Parameters.Add("@userModified", SqlDbType.VarChar, 10).Value = u_UserRole.userModified;
                scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8).Value = u_UserRole.dateModified;
                scom.Parameters.Add("@activate", SqlDbType.Int, 4).Value = u_UserRole.activate;
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


        public DataTable SelectAllu_UserRole()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [U_UserRole]";
                DataTable dtu_UserRole = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtu_UserRole;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public u_UserRolex Selectu_UserRole(u_UserRolex obju_UserRole)
        {
            try
            {
                strquery = @"select * from u_UserRoles where roleId = '" + obju_UserRole.roleId + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    obju_UserRole.roleId = drType["roleId"].ToString();
                    obju_UserRole.description = drType["description"].ToString();
                    obju_UserRole.userCreated = drType["userCreated"].ToString();
                    obju_UserRole.dateCreated = DateTime.Parse(drType["dateCreated"].ToString());
                    obju_UserRole.userModified = drType["userModified"].ToString();
                    obju_UserRole.dateModified = DateTime.Parse(drType["dateModified"].ToString());
                    obju_UserRole.activate = int.Parse(drType["activate"].ToString());
                    return obju_UserRole;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingU_UserRole(string stringu_UserRole)
        {
            try
            {
                string xstrquery = @"select roleId From u_UserRoles   WHERE roleId = '" + stringu_UserRole + "' ";
                DataRow drU_UserRole = u_DBConnection.ReturnDataRow(xstrquery);
                if (drU_UserRole != null)
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

        public List<u_UserRolex> SelectU_UserRoleMulti(u_UserRolex obju_UserRole2)
        {
            List<u_UserRolex> retval = new List<u_UserRolex>();
            try
            {
                strquery = @"select * from u_UserRole where roleId = '" + obju_UserRole2.roleId + "'";
                DataTable dtu_UserRole = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtu_UserRole.Rows)
                {
                    if (drType != null)
                    {
                        u_UserRolex obju_UserRole = new u_UserRolex();
                        obju_UserRole.roleId = drType["roleId"].ToString();
                        obju_UserRole.description = drType["description"].ToString();
                        obju_UserRole.userCreated = drType["userCreated"].ToString();
                        obju_UserRole.dateCreated = DateTime.Parse(drType["dateCreated"].ToString());
                        obju_UserRole.userModified = drType["userModified"].ToString();
                        obju_UserRole.dateModified = DateTime.Parse(drType["dateModified"].ToString());
                        obju_UserRole.activate = int.Parse(drType["activate"].ToString());
                        retval.Add(obju_UserRole);
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
