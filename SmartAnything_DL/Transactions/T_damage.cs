using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_damageDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_damage table.
        /// </summary>
        public Boolean Savet_damageSP(t_damage t_damage, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_damageSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 20).Value = t_damage.no;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_damage.date;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_damage.refNo;
                scom.Parameters.Add("@refDate", SqlDbType.DateTime, 8).Value = t_damage.refDate;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 150).Value = t_damage.remarks;
                scom.Parameters.Add("@locationId", SqlDbType.VarChar, 20).Value = t_damage.locationId;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_damage.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_damage.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_damage.grossAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_damage.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_damage.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_damage.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 20).Value = t_damage.processUser;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_damage.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_damage.triggerVal;
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


        public DataTable SelectAllt_damage()
        {
            try
            {
                strquery = @"select no,grossAmount from t_damage";
                DataTable dtt_damage = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_damage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_damage Selectt_damage(t_damage objt_damage)
        {
            try
            {
                strquery = @"select * from t_damage where no = '" + objt_damage.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_damage.no = drType["no"].ToString();
                    objt_damage.date = DateTime.Parse(drType["date"].ToString());
                    objt_damage.refNo = drType["refNo"].ToString();
                    objt_damage.refDate = DateTime.Parse(drType["refDate"].ToString());
                    objt_damage.remarks = drType["remarks"].ToString();
                    objt_damage.locationId = drType["locationId"].ToString();
                    objt_damage.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_damage.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_damage.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_damage.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_damage.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_damage.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_damage.processUser = drType["processUser"].ToString();
                    objt_damage.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_damage.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_damage;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_damage(string stringt_damage)
        {
            try
            {
                string xstrquery = @"select no From T_damage   WHERE no = '" + stringt_damage + "' ";
                DataRow drT_damage = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_damage != null)
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

        public List<t_damage> SelectT_damageMulti(t_damage objt_damage2)
        {
            List<t_damage> retval = new List<t_damage>();
            try
            {
                strquery = @"select * from t_damage where no = '" + objt_damage2.no + "'";
                DataTable dtt_damage = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_damage.Rows)
                {
                    if (drType != null)
                    {
                        t_damage objt_damage = new t_damage();
                        objt_damage.no = drType["no"].ToString();
                        objt_damage.date = DateTime.Parse(drType["date"].ToString());
                        objt_damage.refNo = drType["refNo"].ToString();
                        objt_damage.refDate = DateTime.Parse(drType["refDate"].ToString());
                        objt_damage.remarks = drType["remarks"].ToString();
                        objt_damage.locationId = drType["locationId"].ToString();
                        objt_damage.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_damage.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                        objt_damage.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_damage.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_damage.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_damage.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_damage.processUser = drType["processUser"].ToString();
                        objt_damage.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_damage.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_damage);
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
