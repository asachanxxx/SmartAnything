using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_DIliveryAuditDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_DIliveryAudit table.
        /// </summary>
        public Boolean Savet_DIliveryAuditSP(T_DIliveryAudit t_DIliveryAudit, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_DIliveryAuditSave";

                scom.Parameters.Add("@Dono", SqlDbType.VarChar, 20).Value = t_DIliveryAudit.Dono;
                scom.Parameters.Add("@Item", SqlDbType.VarChar, 20).Value = t_DIliveryAudit.Item;
                scom.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = t_DIliveryAudit.Name;
                scom.Parameters.Add("@DoQty", SqlDbType.Decimal, 9).Value = t_DIliveryAudit.DoQty;
                scom.Parameters.Add("@ActualQTY", SqlDbType.Decimal, 9).Value = t_DIliveryAudit.ActualQTY;
                scom.Parameters.Add("@Variance", SqlDbType.Decimal, 9).Value = t_DIliveryAudit.Variance;
                scom.Parameters.Add("@Pass", SqlDbType.Int, 4).Value = t_DIliveryAudit.Pass;
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


        public DataTable SelectAllt_DIliveryAudit()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [T_DIliveryAudit]";
                DataTable dtt_DIliveryAudit = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_DIliveryAudit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_DIliveryAudit Selectt_DIliveryAudit(T_DIliveryAudit objt_DIliveryAudit)
        {
            try
            {
                strquery = @"select * from t_DIliveryAudit where Dono = '" + objt_DIliveryAudit.Dono + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_DIliveryAudit.Dono = drType["Dono"].ToString();
                    objt_DIliveryAudit.Item = drType["Item"].ToString();
                    objt_DIliveryAudit.Name = drType["Name"].ToString();
                    objt_DIliveryAudit.DoQty = decimal.Parse(drType["DoQty"].ToString());
                    objt_DIliveryAudit.ActualQTY = decimal.Parse(drType["ActualQTY"].ToString());
                    objt_DIliveryAudit.Variance = decimal.Parse(drType["Variance"].ToString());
                    objt_DIliveryAudit.Pass = int.Parse(drType["Pass"].ToString());
                    return objt_DIliveryAudit;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_DIliveryAudit(string stringt_DIliveryAudit)
        {
            try
            {
                string xstrquery = @"select Dono From T_DIliveryAudit   WHERE Dono = '" + stringt_DIliveryAudit + "' ";
                DataRow drT_DIliveryAudit = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_DIliveryAudit != null)
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

        public List<T_DIliveryAudit> SelectT_DIliveryAuditMulti(T_DIliveryAudit objt_DIliveryAudit2)
        {
            List<T_DIliveryAudit> retval = new List<T_DIliveryAudit>();
            try
            {
                strquery = @"select * from t_DIliveryAudit where Dono = '" + objt_DIliveryAudit2.Dono + "'";
                DataTable dtt_DIliveryAudit = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_DIliveryAudit.Rows)
                {
                    if (drType != null)
                    {
                        T_DIliveryAudit objt_DIliveryAudit = new T_DIliveryAudit();
                        objt_DIliveryAudit.Dono = drType["Dono"].ToString();
                        objt_DIliveryAudit.Item = drType["Item"].ToString();
                        objt_DIliveryAudit.Name = drType["Name"].ToString();
                        objt_DIliveryAudit.DoQty = decimal.Parse(drType["DoQty"].ToString());
                        objt_DIliveryAudit.ActualQTY = decimal.Parse(drType["ActualQTY"].ToString());
                        objt_DIliveryAudit.Variance = decimal.Parse(drType["Variance"].ToString());
                        objt_DIliveryAudit.Pass = int.Parse(drType["Pass"].ToString());
                        retval.Add(objt_DIliveryAudit);
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
