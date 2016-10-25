using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_DiliveryDetDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the T_DiliveryDet table.
        /// </summary>
        public Boolean Savet_DiliveryDetSP(T_DiliveryDet t_DiliveryDet, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_DiliveryDetSave";

                scom.Parameters.Add("@DoNo", SqlDbType.VarChar, 20).Value = t_DiliveryDet.DoNo;
                scom.Parameters.Add("@Item", SqlDbType.VarChar, 20).Value = t_DiliveryDet.Item;
                scom.Parameters.Add("@ItemNamex", SqlDbType.VarChar, 50).Value = t_DiliveryDet.ItemNamex;
                scom.Parameters.Add("@Unit", SqlDbType.VarChar, 10).Value = t_DiliveryDet.Unit;
                scom.Parameters.Add("@Qty", SqlDbType.Decimal, 9).Value = t_DiliveryDet.Qty;
                scom.Parameters.Add("@Carton", SqlDbType.Decimal, 9).Value = t_DiliveryDet.Carton;
                scom.Parameters.Add("@ActualCartons", SqlDbType.Decimal, 9).Value = t_DiliveryDet.ActualCartons;
                scom.Parameters.Add("@Remarks", SqlDbType.VarChar, 150).Value = t_DiliveryDet.Remarks;
                scom.Parameters.Add("@Pass", SqlDbType.Bit, 1).Value = t_DiliveryDet.Pass;
                scom.Parameters.Add("@IsCNitem", SqlDbType.Bit, 1).Value = t_DiliveryDet.IsCNitem;
                scom.Parameters.Add("@CNNumber", SqlDbType.VarChar, 20).Value = t_DiliveryDet.CNNumber;
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


        public DataTable SelectAllt_DiliveryDet()
        {
            try
            {
                strquery = @"select DoNo,Item  from T_DiliveryDet";
                DataTable dtt_DiliveryDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_DiliveryDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T_DiliveryDet Selectt_DiliveryDet(T_DiliveryDet objt_DiliveryDet)
        {
            try
            {
                strquery = @"SELECT * FROM dbo.T_DiliveryDet WHERE DoNo = '" + objt_DiliveryDet.DoNo.Trim() + "' AND Item = '" + objt_DiliveryDet.Item.Trim()+ "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_DiliveryDet.DoNo = drType["DoNo"].ToString();
                    objt_DiliveryDet.Item = drType["Item"].ToString();
                    objt_DiliveryDet.ItemNamex = drType["ItemNamex"].ToString();
                    objt_DiliveryDet.Unit = drType["Unit"].ToString();
                    objt_DiliveryDet.Qty = decimal.Parse(drType["Qty"].ToString());
                    objt_DiliveryDet.Carton = decimal.Parse(drType["Carton"].ToString());
                    objt_DiliveryDet.ActualCartons = decimal.Parse(drType["ActualCartons"].ToString());
                    objt_DiliveryDet.Remarks = drType["Remarks"].ToString();
                    objt_DiliveryDet.Pass = bool.Parse(drType["Pass"].ToString());
                    objt_DiliveryDet.IsCNitem = bool.Parse(drType["IsCNitem"].ToString());
                    objt_DiliveryDet.CNNumber = drType["CNNumber"].ToString();
                    return objt_DiliveryDet;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_DiliveryDet(string stringt_DiliveryDet)
        {
            try
            {
                string xstrquery = @"select CompCode From T_DiliveryDet   WHERE DoNo = '" + stringt_DiliveryDet + "' ";
                DataRow drT_DiliveryDet = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_DiliveryDet != null)
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

        public List<T_DiliveryDet> SelectT_DiliveryDetMulti(T_DiliveryDet objt_DiliveryDet2)
        {
            List<T_DiliveryDet> retval = new List<T_DiliveryDet>();
            try
            {
                strquery = @"select * from t_DiliveryDet where DoNo = '" + objt_DiliveryDet2.DoNo + "'";
                DataTable dtt_DiliveryDet = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_DiliveryDet.Rows)
                {
                    if (drType != null)
                    {
                        T_DiliveryDet objt_DiliveryDet = new T_DiliveryDet();
                        objt_DiliveryDet.DoNo = drType["DoNo"].ToString();
                        objt_DiliveryDet.Item = drType["Item"].ToString();
                        objt_DiliveryDet.ItemNamex = drType["ItemNamex"].ToString();
                        objt_DiliveryDet.Unit = drType["Unit"].ToString();
                        objt_DiliveryDet.Qty = decimal.Parse(drType["Qty"].ToString());
                        objt_DiliveryDet.Carton = decimal.Parse(drType["Carton"].ToString());
                        objt_DiliveryDet.ActualCartons = decimal.Parse(drType["ActualCartons"].ToString());
                        objt_DiliveryDet.Remarks = drType["Remarks"].ToString();
                        objt_DiliveryDet.Pass = bool.Parse(drType["Pass"].ToString());
                        objt_DiliveryDet.IsCNitem = bool.Parse(drType["IsCNitem"].ToString());
                        objt_DiliveryDet.CNNumber = drType["CNNumber"].ToString();
                        retval.Add(objt_DiliveryDet);
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
