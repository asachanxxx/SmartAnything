using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_adjustment_headDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_adjustment_head table.
        /// </summary>
        public Boolean Savet_adjustment_headSP(t_adjustment_head t_adjustment_head, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_adjustment_headSave";

                scom.Parameters.Add("@adju_no", SqlDbType.VarChar, 20).Value = t_adjustment_head.adju_no;
                scom.Parameters.Add("@location_id", SqlDbType.VarChar, 20).Value = t_adjustment_head.location_id;
                scom.Parameters.Add("@adjsment_date", SqlDbType.DateTime, 8).Value = t_adjustment_head.adjsment_date;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 150).Value = t_adjustment_head.remarks;
                scom.Parameters.Add("@user_id", SqlDbType.VarChar, 20).Value = t_adjustment_head.user_id;
                scom.Parameters.Add("@batch_no", SqlDbType.VarChar, 20).Value = t_adjustment_head.batch_no;
                scom.Parameters.Add("@process", SqlDbType.Bit, 1).Value = t_adjustment_head.process;
                scom.Parameters.Add("@process_user", SqlDbType.VarChar, 20).Value = t_adjustment_head.process_user;
                scom.Parameters.Add("@process_date", SqlDbType.DateTime, 8).Value = t_adjustment_head.process_date;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_adjustment_head.triggerVal;
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


        public DataTable SelectAllt_adjustment_head()
        {
            try
            {
                strquery = @"select adju_no,adjsment_date from t_adjustment_head";
                DataTable dtt_adjustment_head = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_adjustment_head;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_adjustment_head Selectt_adjustment_head(t_adjustment_head objt_adjustment_head)
        {
            try
            {
                strquery = @"select * from t_adjustment_head where adju_no = '" + objt_adjustment_head.adju_no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_adjustment_head.adju_no = drType["adju_no"].ToString();
                    objt_adjustment_head.location_id = drType["location_id"].ToString();
                    objt_adjustment_head.adjsment_date = DateTime.Parse(drType["adjsment_date"].ToString());
                    objt_adjustment_head.remarks = drType["remarks"].ToString();
                    objt_adjustment_head.user_id = drType["user_id"].ToString();
                    objt_adjustment_head.batch_no = drType["batch_no"].ToString();
                    objt_adjustment_head.process = bool.Parse(drType["process"].ToString());
                    objt_adjustment_head.process_user = drType["process_user"].ToString();
                    objt_adjustment_head.process_date = DateTime.Parse(drType["process_date"].ToString());
                    objt_adjustment_head.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_adjustment_head;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_adjustment_head(string stringt_adjustment_head)
        {
            try
            {
                string xstrquery = @"select adju_no From T_adjustment_head   WHERE adju_no = '" + stringt_adjustment_head + "' ";
                DataRow drT_adjustment_head = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_adjustment_head != null)
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

        public List<t_adjustment_head> SelectT_adjustment_headMulti(t_adjustment_head objt_adjustment_head2)
        {
            List<t_adjustment_head> retval = new List<t_adjustment_head>();
            try
            {
                strquery = @"select * from t_adjustment_head where adju_no = '" + objt_adjustment_head2.adju_no + "'";
                DataTable dtt_adjustment_head = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_adjustment_head.Rows)
                {
                    if (drType != null)
                    {
                        t_adjustment_head objt_adjustment_head = new t_adjustment_head();
                        objt_adjustment_head.adju_no = drType["adju_no"].ToString();
                        objt_adjustment_head.location_id = drType["location_id"].ToString();
                        objt_adjustment_head.adjsment_date = DateTime.Parse(drType["adjsment_date"].ToString());
                        objt_adjustment_head.remarks = drType["remarks"].ToString();
                        objt_adjustment_head.user_id = drType["user_id"].ToString();
                        objt_adjustment_head.batch_no = drType["batch_no"].ToString();
                        objt_adjustment_head.process = bool.Parse(drType["process"].ToString());
                        objt_adjustment_head.process_user = drType["process_user"].ToString();
                        objt_adjustment_head.process_date = DateTime.Parse(drType["process_date"].ToString());
                        objt_adjustment_head.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_adjustment_head);
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
