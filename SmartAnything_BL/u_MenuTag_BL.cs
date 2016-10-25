//*************************************************************
//Developer  :Nilmini Paragahawaththage
//Date       :2013/11/01
//Description:Business Logic for the insert, delete, update and get data of user menutags
//Module Name: smartOffice
//*************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smartOffice_Models;
using SmartAnything;
using System.Data;

namespace smartOffice_BL
{
    public class u_MenuTag_BL
    {
        bool boolCreate = false;
        bool boolModify = false;
        bool boolDelete = false;
        bool boolPrint = false;
        DataTable dtAuthorityBoolValues;
        /// <summary>
        /// Gets the User menu tags from the u_MenuTag_DL class
        /// </summary>
        /// <returns>DataTable filled with User menu tags;</returns>
        public DataTable GetUMenuTags()
        {
            try
            {
                u_MenuTag_DL objmenuDL = new u_MenuTag_DL();
                DataTable dtUITag = objmenuDL.GetUMenuTags();
                string strRight;
                DataRow drRight;

                dtAuthorityBoolValues = new DataTable();
                dtAuthorityBoolValues.Columns.Add("UIName", typeof(string));
                dtAuthorityBoolValues.Columns.Add("dtAccess", typeof(bool));
                dtAuthorityBoolValues.Columns.Add("dtCreate", typeof(bool));
                dtAuthorityBoolValues.Columns.Add("dtModify", typeof(bool));
                dtAuthorityBoolValues.Columns.Add("dtDelete", typeof(bool));
                dtAuthorityBoolValues.Columns.Add("dtPrint", typeof(bool));
                dtAuthorityBoolValues.Columns.Add("menuRights", typeof(string));

                for (int i = 0; i < dtUITag.Rows.Count; i++)
                {
                    strRight = dtUITag.Rows[i]["menuRights"].ToString();
                    char[] chrArray = strRight.ToCharArray();

                    for (int j = 1; j < strRight.Length; j++)
                    {
                        if (strRight[j] == 'C')
                            boolCreate = true;
                        if (strRight[j] == 'M')
                            boolModify = true;
                        if (strRight[j] == 'D')
                            boolDelete = true;
                        if (strRight[j] == 'P')
                            boolPrint = true;
                    }

                    dtAuthorityBoolValues.Rows.Add(dtUITag.Rows[i]["description"].ToString(), true, boolCreate, boolModify, boolDelete, boolPrint, strRight);
                    boolCreate = false;
                    boolModify = false;
                    boolDelete = false;
                    boolPrint = false;


                }


                return dtAuthorityBoolValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetMenuID(string strMenuText)
        {
            try
            {
                u_MenuTag_DL objmenuDL = new u_MenuTag_DL();
                return objmenuDL.GetMenuID(strMenuText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
