using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_packingdetDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_packingdet table.
        /// </summary>
        public Boolean Savet_packingdetSP(T_packingdet t_packingdet, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_packingdetSave";

                scom.Parameters.Add("@PackingNo", SqlDbType.VarChar, 20).Value = t_packingdet.PackingNo;
                scom.Parameters.Add("@Dono", SqlDbType.VarChar, 20).Value = t_packingdet.Dono;
                scom.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = t_packingdet.Customer;
                scom.Parameters.Add("@Agent", SqlDbType.VarChar, 20).Value = t_packingdet.Agent;
                scom.Parameters.Add("@datex", SqlDbType.DateTime, 8).Value = t_packingdet.datex;
                scom.Parameters.Add("@TTLCartons", SqlDbType.Decimal, 9).Value = t_packingdet.TTLCartons;
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


        public DataTable SelectAllt_packingdet()
        {
            try
            {
                strquery = @"select packingno,Dono from T_packingdet";
                DataTable dtt_packingdet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_packingdet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_packingdet Selectt_packingdet(T_packingdet objt_packingdet)
        {
            try
            {
                strquery = @"select * from t_packingdet where PackingNo = '" + objt_packingdet.PackingNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_packingdet.PackingNo = drType["PackingNo"].ToString();
                    objt_packingdet.Dono = drType["Dono"].ToString();
                    objt_packingdet.Customer = drType["Customer"].ToString();
                    objt_packingdet.Agent = drType["Agent"].ToString();
                    objt_packingdet.datex = DateTime.Parse(drType["datex"].ToString());
                    objt_packingdet.TTLCartons = decimal.Parse(drType["TTLCartons"].ToString());
                    return objt_packingdet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_packingdet(string stringt_packingdet)
        {
            try
            {
                string xstrquery = @"select PackingNo From T_packingdet   WHERE PackingNo = '" + stringt_packingdet + "' ";
                DataRow drT_packingdet = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_packingdet != null)
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

        public List<T_packingdet> SelectT_packingdetMulti(T_packingdet objt_packingdet2)
        {
            List<T_packingdet> retval = new List<T_packingdet>();
            try
            {
                strquery = @"select * from T_packingdet where PackingNo = '" + objt_packingdet2.PackingNo + "'";
                DataTable dtt_packingdet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_packingdet.Rows)
                {
                    if (drType != null)
                    {
                        T_packingdet objt_packingdet = new T_packingdet();
                        objt_packingdet.PackingNo = drType["PackingNo"].ToString();
                        objt_packingdet.Dono = drType["Dono"].ToString();
                        objt_packingdet.Customer = drType["Customer"].ToString();
                        objt_packingdet.Agent = drType["Agent"].ToString();
                        objt_packingdet.datex = DateTime.Parse(drType["datex"].ToString());
                        objt_packingdet.TTLCartons = decimal.Parse(drType["TTLCartons"].ToString());
                        retval.Add(objt_packingdet);
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
