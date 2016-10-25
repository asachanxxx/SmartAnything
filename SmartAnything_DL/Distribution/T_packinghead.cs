using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_packingheadDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_packinghead table.
        /// </summary>
        public Boolean Savet_packingheadSP(T_packinghead t_packinghead, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_packingheadSave";

                scom.Parameters.Add("@PackingNo", SqlDbType.VarChar, 20).Value = t_packinghead.PackingNo;
                scom.Parameters.Add("@RefNumber", SqlDbType.VarChar, 20).Value = t_packinghead.RefNumber;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = t_packinghead.CompCode;
                scom.Parameters.Add("@LocaCode", SqlDbType.VarChar, 20).Value = t_packinghead.LocaCode;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = t_packinghead.Datex;
                scom.Parameters.Add("@NoOfCartons", SqlDbType.Decimal, 9).Value = t_packinghead.NoOfCartons;
                scom.Parameters.Add("@Vehicle", SqlDbType.VarChar, 20).Value = t_packinghead.Vehicle;
                scom.Parameters.Add("@Driver", SqlDbType.VarChar, 20).Value = t_packinghead.Driver;
                scom.Parameters.Add("@CreatedUser", SqlDbType.VarChar, 20).Value = t_packinghead.CreatedUser;
                scom.Parameters.Add("@CreatedTime", SqlDbType.DateTime, 8).Value = t_packinghead.CreatedTime;
                scom.Parameters.Add("@Processed", SqlDbType.Int, 4).Value = t_packinghead.Processed;
                scom.Parameters.Add("@ProcessedDate", SqlDbType.DateTime, 8).Value = t_packinghead.ProcessedDate;
                scom.Parameters.Add("@ProcessedUser", SqlDbType.VarChar, 20).Value = t_packinghead.ProcessedUser;
                scom.Parameters.Add("@Glupdated", SqlDbType.Bit, 1).Value = t_packinghead.Glupdated;
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


        public DataTable SelectAllt_packinghead()
        {
            try
            {
                strquery = @"select packingNo , NoOfCartons from T_packinghead ";
                DataTable dtt_packinghead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_packinghead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_packinghead Selectt_packinghead(T_packinghead objt_packinghead)
        {
            try
            {
                strquery = @"select * from t_packinghead where packingNo = '" + objt_packinghead.PackingNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {

                    objt_packinghead.PackingNo = drType["PackingNo"].ToString();
                    objt_packinghead.RefNumber = drType["RefNumber"].ToString();
                    objt_packinghead.CompCode = drType["CompCode"].ToString();
                    objt_packinghead.LocaCode = drType["LocaCode"].ToString();
                    objt_packinghead.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objt_packinghead.NoOfCartons = decimal.Parse(drType["NoOfCartons"].ToString());
                    objt_packinghead.Vehicle = drType["Vehicle"].ToString();
                    objt_packinghead.Driver = drType["Driver"].ToString();
                    objt_packinghead.CreatedUser = drType["CreatedUser"].ToString();
                    objt_packinghead.CreatedTime = DateTime.Parse(drType["CreatedTime"].ToString());
                    objt_packinghead.Processed = int.Parse(drType["Processed"].ToString());
                    objt_packinghead.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                    objt_packinghead.ProcessedUser = drType["ProcessedUser"].ToString();
                    objt_packinghead.Glupdated = bool.Parse(drType["Glupdated"].ToString());

                    return objt_packinghead;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_packinghead(string stringt_packinghead)
        {
            try
            {
                string xstrquery = @"select packingNo From T_packinghead   WHERE packingNo = '" + stringt_packinghead + "' ";
                DataRow drT_packinghead = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_packinghead != null)
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

        public List<T_packinghead> SelectT_packingheadMulti(T_packinghead objt_packinghead2)
        {
            List<T_packinghead> retval = new List<T_packinghead>();
            try
            {
                strquery = @"select * from t_packinghead where PackingNo = '" + objt_packinghead2.PackingNo + "'";
                DataTable dtt_packinghead = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_packinghead.Rows)
                {
                    if (drType != null)
                    {
                        T_packinghead objt_packinghead = new T_packinghead();
                        objt_packinghead.PackingNo = drType["PackingNo"].ToString();
                        objt_packinghead.RefNumber = drType["RefNumber"].ToString();
                        objt_packinghead.CompCode = drType["CompCode"].ToString();
                        objt_packinghead.LocaCode = drType["LocaCode"].ToString();
                        objt_packinghead.Datex = DateTime.Parse(drType["Datex"].ToString());
                        objt_packinghead.NoOfCartons = decimal.Parse(drType["NoOfCartons"].ToString());
                        objt_packinghead.Vehicle = drType["Vehicle"].ToString();
                        objt_packinghead.Driver = drType["Driver"].ToString();
                        objt_packinghead.CreatedUser = drType["CreatedUser"].ToString();
                        objt_packinghead.CreatedTime = DateTime.Parse(drType["CreatedTime"].ToString());
                        objt_packinghead.Processed = int.Parse(drType["Processed"].ToString());
                        objt_packinghead.ProcessedDate = DateTime.Parse(drType["ProcessedDate"].ToString());
                        objt_packinghead.ProcessedUser = drType["ProcessedUser"].ToString();
                        objt_packinghead.Glupdated = bool.Parse(drType["Glupdated"].ToString());
                        retval.Add(objt_packinghead);
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
