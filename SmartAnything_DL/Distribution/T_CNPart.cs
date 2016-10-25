using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_CNPartDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_CNParts table.
        /// </summary>
        public Boolean Savet_CNPartSP(T_CNParts t_CNPart, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_CNPartsSave";

                scom.Parameters.Add("@CNno", SqlDbType.VarChar, 20).Value = t_CNPart.CNno;
                scom.Parameters.Add("@TagNumber", SqlDbType.VarChar, 20).Value = t_CNPart.TagNumber;
                scom.Parameters.Add("@ItemCode", SqlDbType.VarChar, 20).Value = t_CNPart.ItemCode;
                scom.Parameters.Add("@PartCode", SqlDbType.VarChar, 20).Value = t_CNPart.PartCode;
                scom.Parameters.Add("@QTY", SqlDbType.Decimal, 9).Value = t_CNPart.QTY;
                scom.Parameters.Add("@Saved", SqlDbType.Bit, 1).Value = t_CNPart.Saved;
                scom.Parameters.Add("@Processed", SqlDbType.Bit, 1).Value = t_CNPart.Processed;
                scom.Parameters.Add("@ProcessedDate", SqlDbType.DateTime, 8).Value = t_CNPart.ProcessedDate;
                scom.Parameters.Add("@ProcessedUser", SqlDbType.VarChar, 20).Value = t_CNPart.ProcessedUser;
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


        public DataTable SelectAllt_CNPart()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_CNPart]";
                DataTable dtt_CNPart = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_CNPart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_CNParts Selectt_CNPart(T_CNParts objt_CNPart)
        {
            try
            {
                strquery = @"SELECT     * FROM dbo.T_CNParts WHERE (CNno = '" + objt_CNPart.CNno.Trim() + "') AND (ItemCode = '" + objt_CNPart.ItemCode.Trim() + "') AND (PartCode = '" + objt_CNPart.PartCode.Trim() + "') and TagNumber  = '" + objt_CNPart.TagNumber.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_CNPart.CNno = drType["CNno"].ToString();
                    objt_CNPart.TagNumber = drType["TagNumber"].ToString();
                    objt_CNPart.ItemCode = drType["ItemCode"].ToString();
                    objt_CNPart.PartCode = drType["PartCode"].ToString();
                    objt_CNPart.QTY = decimal.Parse(drType["QTY"].ToString());
                    objt_CNPart.Saved = bool.Parse(drType["Saved"].ToString());
                    objt_CNPart.Processed = bool.Parse(drType["Processed"].ToString());
                    objt_CNPart.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                    objt_CNPart.ProcessedUser = drType["ProcessedUser"].ToString();
                    return objt_CNPart;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        
        public static bool ExistingT_CNPart(string CNno, string tag , string item, string part)
        {
            try
            {
                string xstrquery = @"SELECT     CNno FROM dbo.T_CNParts WHERE (CNno = '" + CNno.Trim() + "') AND (ItemCode = '" + item.Trim() + "') AND (PartCode = '" + part.Trim() + "') and TagNumber  = '" + tag.Trim() + "'";
                DataRow drT_CNPart = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_CNPart != null)
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



        public static void Delete_CNPart(string CNno, string item, string part, string tagno)
        {
            try
            {
                string xstrquery = @"DELETE FROM dbo.T_CNParts WHERE (CNno = '" + CNno.Trim() + "') AND (ItemCode = '" + item.Trim() + "') AND (PartCode = '" + part.Trim() + "') and TagNumber  = '" + tagno.Trim() + "'";
                u_DBConnection.ExecuteNonQuery(xstrquery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T_CNParts> SelectT_CNPartMulti(T_CNParts objt_CNPart2)
        {
            List<T_CNParts> retval = new List<T_CNParts>();
            try
            {
                strquery = @"select * from t_CNPart where CNno = '" + objt_CNPart2.CNno + "'";
                DataTable dtt_CNPart = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_CNPart.Rows)
                {
                    if (drType != null)
                    {
                        T_CNParts objt_CNPart = new T_CNParts();
                        objt_CNPart.CNno = drType["CNno"].ToString();
                        objt_CNPart.TagNumber = drType["TagNumber"].ToString();
                        objt_CNPart.ItemCode = drType["ItemCode"].ToString();
                        objt_CNPart.PartCode = drType["PartCode"].ToString();
                        objt_CNPart.QTY = decimal.Parse(drType["QTY"].ToString());
                        objt_CNPart.Saved = bool.Parse(drType["Saved"].ToString());
                        objt_CNPart.Processed = bool.Parse(drType["Processed"].ToString());
                        objt_CNPart.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                        objt_CNPart.ProcessedUser = drType["ProcessedUser"].ToString();
                        retval.Add(objt_CNPart);
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
