using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class U_UserxDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the u_User table.
        /// </summary>
        public Boolean Saveu_UserSP(u_Userxcc u_User, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "U_UserSaveNew";

                scom.Parameters.Add("@userId", SqlDbType.VarChar, 10).Value = u_User.userId;
                scom.Parameters.Add("@userName", SqlDbType.VarChar, 40).Value = u_User.userName;
                scom.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = u_User.password;
                scom.Parameters.Add("@roleId", SqlDbType.VarChar, 10).Value = u_User.roleId;
                scom.Parameters.Add("@userCreated", SqlDbType.VarChar, 10).Value = u_User.userCreated;
                scom.Parameters.Add("@dateCreated", SqlDbType.DateTime, 8).Value = u_User.dateCreated;
                scom.Parameters.Add("@userModified", SqlDbType.VarChar, 10).Value = u_User.userModified;
                scom.Parameters.Add("@dateModified", SqlDbType.DateTime, 8).Value = u_User.dateModified;
                scom.Parameters.Add("@isActive", SqlDbType.Int, 4).Value = u_User.isActive;
                scom.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = u_User.Type;
                scom.Parameters.Add("@Compcode", SqlDbType.VarChar, 20).Value = u_User.Compcode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = u_User.Locacode;
                scom.Parameters.Add("@TP", SqlDbType.VarChar, 20).Value = u_User.TP;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 20).Value = u_User.Fax;
                scom.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = u_User.Email;
                scom.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = u_User.Address1;
                scom.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = u_User.Address2;
                scom.Parameters.Add("@Address3", SqlDbType.VarChar, 50).Value = u_User.Address3;
                scom.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 20).Value = u_User.ContactPerson;
                scom.Parameters.Add("@ContactPersonNo", SqlDbType.VarChar, 50).Value = u_User.ContactPersonNo;
                scom.Parameters.Add("@CurrentStatus", SqlDbType.VarChar, 20).Value = u_User.CurrentStatus;
                scom.Parameters.Add("@Gradex", SqlDbType.VarChar, 20).Value = u_User.Gradex;
                scom.Parameters.Add("@NICNo", SqlDbType.VarChar, 20).Value = u_User.NICNo;
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


        public DataTable SelectAllu_User()
        {
            try
            {
                strquery = @"SELECT userId AS 'User Code' , userName AS 'User Name' , type AS 'User Type' FROM  dbo.u_User";
                DataTable dtu_User = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtu_User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public u_Userxcc Selectu_User(u_Userxcc obju_User)
        {
            try
            {
                strquery = @"select * from u_User where userId = '" + obju_User.userId + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    obju_User.userId = drType["userId"].ToString();
                    obju_User.userName = drType["userName"].ToString();
                    obju_User.password = drType["password"].ToString();
                    obju_User.roleId = drType["roleId"].ToString();
                    obju_User.userCreated = drType["userCreated"].ToString();
                    obju_User.dateCreated = DateTime.Parse(drType["dateCreated"].ToString());
                    obju_User.userModified = drType["userModified"].ToString();
                    obju_User.dateModified = DateTime.Parse(drType["dateModified"].ToString());
                    obju_User.isActive = int.Parse(drType["isActive"].ToString());
                    obju_User.Type = drType["Type"].ToString();
                    obju_User.Compcode = drType["Compcode"].ToString();
                    obju_User.Locacode = drType["Locacode"].ToString();
                    obju_User.TP = drType["TP"].ToString();
                    obju_User.Fax = drType["Fax"].ToString();
                    obju_User.Email = drType["Email"].ToString();
                    obju_User.Address1 = drType["Address1"].ToString();
                    obju_User.Address2 = drType["Address2"].ToString();
                    obju_User.Address3 = drType["Address3"].ToString();
                    obju_User.ContactPerson = drType["ContactPerson"].ToString();
                    obju_User.ContactPersonNo = drType["ContactPersonNo"].ToString();
                    obju_User.CurrentStatus = drType["CurrentStatus"].ToString();
                    obju_User.Gradex = drType["Gradex"].ToString();
                    obju_User.NICNo = drType["NICNo"].ToString();
                    return obju_User;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingU_User(string stringu_User)
        {
            try
            {
                string xstrquery = @"select userId From U_User   WHERE userId = '" + stringu_User + "' ";
                DataRow drU_User = u_DBConnection.ReturnDataRow(xstrquery);
                if (drU_User != null)
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


        public static bool ApplyDefaultSec(string stringu_User)
        {
            try
            {
                string xstrquery = "INSERT INTO [RIT_AT].[dbo].[u_UserRights] ([userId] ,[menuId] ,[menuRights]) " + 
                                   "SELECT     dbo.u_User.userId, dbo.u_MenuTag.menuId, dbo.u_MenuTag.menuRights " +
                                   "FROM         dbo.u_User CROSS JOIN dbo.u_MenuTag WHERE dbo.u_User.userId = '" + stringu_User.Trim() + "'";
                int drU_User = u_DBConnection.ExecuteNonQuery(xstrquery);
                if (drU_User >0)
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

        public static bool DeleteAllrights(string stringu_User)
        {
            try
            {
                string xstrquery = "DELETE FROM [u_UserRights] WHERE userId = '" + stringu_User + "'";
                int drU_User = u_DBConnection.ExecuteNonQuery(xstrquery);
                if (drU_User > 0)
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

        //DELETE FROM [u_UserRights] WHERE userId = 'Asang';
        public List<u_Userxcc> SelectU_UserMulti(u_Userxcc obju_User2)
        {
            List<u_Userxcc> retval = new List<u_Userxcc>();
            try
            {
                strquery = @"select * from u_User where roleId = '" + obju_User2.roleId + "'";
                DataTable dtu_User = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtu_User.Rows)
                {
                    if (drType != null)
                    {
                        u_Userxcc obju_User = new u_Userxcc();
                        obju_User.userId = drType["userId"].ToString();
                        obju_User.userName = drType["userName"].ToString();
                        obju_User.password = drType["password"].ToString();
                        obju_User.roleId = drType["roleId"].ToString();
                        obju_User.userCreated = drType["userCreated"].ToString();
                        obju_User.dateCreated = DateTime.Parse(drType["dateCreated"].ToString());
                        obju_User.userModified = drType["userModified"].ToString();
                        obju_User.dateModified = DateTime.Parse(drType["dateModified"].ToString());
                        obju_User.isActive = int.Parse(drType["isActive"].ToString());
                        obju_User.Type = drType["Type"].ToString();
                        obju_User.Compcode = drType["Compcode"].ToString();
                        obju_User.Locacode = drType["Locacode"].ToString();
                        obju_User.TP = drType["TP"].ToString();
                        obju_User.Fax = drType["Fax"].ToString();
                        obju_User.Email = drType["Email"].ToString();
                        obju_User.Address1 = drType["Address1"].ToString();
                        obju_User.Address2 = drType["Address2"].ToString();
                        obju_User.Address3 = drType["Address3"].ToString();
                        obju_User.ContactPerson = drType["ContactPerson"].ToString();
                        obju_User.ContactPersonNo = drType["ContactPersonNo"].ToString();
                        obju_User.CurrentStatus = drType["CurrentStatus"].ToString();
                        obju_User.Gradex = drType["Gradex"].ToString();
                        obju_User.NICNo = drType["NICNo"].ToString();
                        retval.Add(obju_User);
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<u_Userxcc> SelectU_UserMultiAll()
        {
            List<u_Userxcc> retval = new List<u_Userxcc>();
            try
            {
                strquery = @"SELECT * FROM dbo.u_User WHERE Type = 'SAL'";
                DataTable dtu_User = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtu_User.Rows)
                {
                    if (drType != null)
                    {
                        u_Userxcc obju_User = new u_Userxcc();
                        obju_User.userId = drType["userId"].ToString();
                        obju_User.userName = drType["userName"].ToString();
                        obju_User.password = drType["password"].ToString();
                        obju_User.roleId = drType["roleId"].ToString();
                        obju_User.userCreated = drType["userCreated"].ToString();
                        obju_User.dateCreated = DateTime.Parse(drType["dateCreated"].ToString());
                        obju_User.userModified = drType["userModified"].ToString();
                        obju_User.dateModified = DateTime.Parse(drType["dateModified"].ToString());
                        obju_User.isActive = int.Parse(drType["isActive"].ToString());
                        obju_User.Type = drType["Type"].ToString();
                        obju_User.Compcode = drType["Compcode"].ToString();
                        obju_User.Locacode = drType["Locacode"].ToString();
                        obju_User.TP = drType["TP"].ToString();
                        obju_User.Fax = drType["Fax"].ToString();
                        obju_User.Email = drType["Email"].ToString();
                        obju_User.Address1 = drType["Address1"].ToString();
                        obju_User.Address2 = drType["Address2"].ToString();
                        obju_User.Address3 = drType["Address3"].ToString();
                        obju_User.ContactPerson = drType["ContactPerson"].ToString();
                        obju_User.ContactPersonNo = drType["ContactPersonNo"].ToString();
                        obju_User.CurrentStatus = drType["CurrentStatus"].ToString();
                        obju_User.Gradex = drType["Gradex"].ToString();
                        obju_User.NICNo = drType["NICNo"].ToString();
                        retval.Add(obju_User);
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
