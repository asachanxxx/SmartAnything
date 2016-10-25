//*************************************************************************************
//Developer  :Nilmini Paragahawaththage
//Date       :2013/11/01
//Description:Data Access for the insert, delete, update and get data of user menutags
//Module Name: smartOffice
//*************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smartOffice_Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SmartAnything
{
   public class u_MenuTag_DL
    {
       string strSql;
       DataTable dtUITag;
       DataRow drMenuId;

       /// <summary>
       /// Gets the User menu tags from the u_MenuTag table
       /// </summary>
       /// <returns>DataTable filled with User menu tags;</returns>
       public DataTable GetUMenuTags()
       {
           try
           {
               strSql = "select t.menuId,t.description,t.menuRights,t.mainOrder,t.subOrder from u_MenuTag t";
              

              dtUITag= u_DBConnection.ReturnDataTable(strSql, CommandType.Text);
              return dtUITag;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public String GetMenuID(string strMenuText)
       {
           try
           {
               strSql = "select t.menuId,t.description,t.menuRights,t.mainOrder,t.subOrder from u_MenuTag t where t.description='"+strMenuText+"'";

               drMenuId= u_DBConnection.ReturnDataRow(strSql);
               if(drMenuId!=null)
                   return drMenuId["menuId"].ToString();
               return "";
           }

           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
