using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_PayModeDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_PayMode table.
        /// </summary>
        public Boolean Savem_PayModeSP(M_PayMode m_PayMode, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_PayModeSave";

                scom.Parameters.Add("@id", SqlDbType.VarChar, 10).Value = m_PayMode.id;
                scom.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = m_PayMode.description;
                scom.Parameters.Add("@isActive", SqlDbType.Int, 4).Value = m_PayMode.isActive;
                scom.Parameters.Add("@isSubPaymode", SqlDbType.Int, 4).Value = m_PayMode.isSubPaymode;
                scom.Parameters.Add("@isAddBalance", SqlDbType.Int, 4).Value = m_PayMode.isAddBalance;
                scom.Parameters.Add("@isAdvancePayment", SqlDbType.Int, 4).Value = m_PayMode.isAdvancePayment;
                scom.Parameters.Add("@isControlOverPayment", SqlDbType.Int, 4).Value = m_PayMode.isControlOverPayment;
                scom.Parameters.Add("@isVoucher", SqlDbType.Int, 4).Value = m_PayMode.isVoucher;
                scom.Parameters.Add("@accountCode", SqlDbType.VarChar, 15).Value = m_PayMode.accountCode;
                scom.Parameters.Add("@CommissionAccCode", SqlDbType.VarChar, 15).Value = m_PayMode.CommissionAccCode;
                scom.Parameters.Add("@isCredit", SqlDbType.Int, 4).Value = m_PayMode.isCredit;
                scom.Parameters.Add("@isPoint", SqlDbType.Int, 4).Value = m_PayMode.isPoint;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = m_PayMode.triggerVal;
                scom.Parameters.Add("@ischeque", SqlDbType.Int, 4).Value = m_PayMode.ischeque;
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


        public DataTable SelectAllm_PayMode()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [M_PayMode]";
                DataTable dtm_PayMode = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_PayMode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_PayMode Selectm_PayMode(M_PayMode objm_PayMode)
        {
            try
            {
                strquery = @"select * from m_PayMode where id = '" + objm_PayMode.id + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_PayMode.id = drType["id"].ToString();
                    objm_PayMode.description = drType["description"].ToString();
                    objm_PayMode.isActive = int.Parse(drType["isActive"].ToString());
                    objm_PayMode.isSubPaymode = int.Parse(drType["isSubPaymode"].ToString());
                    objm_PayMode.isAddBalance = int.Parse(drType["isAddBalance"].ToString());
                    objm_PayMode.isAdvancePayment = int.Parse(drType["isAdvancePayment"].ToString());
                    objm_PayMode.isControlOverPayment = int.Parse(drType["isControlOverPayment"].ToString());
                    objm_PayMode.isVoucher = int.Parse(drType["isVoucher"].ToString());
                    objm_PayMode.accountCode = drType["accountCode"].ToString();
                    objm_PayMode.CommissionAccCode = drType["CommissionAccCode"].ToString();
                    objm_PayMode.isCredit = int.Parse(drType["isCredit"].ToString());
                    objm_PayMode.isPoint = int.Parse(drType["isPoint"].ToString());
                    objm_PayMode.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    objm_PayMode.ischeque = int.Parse(drType["ischeque"].ToString());
                    return objm_PayMode;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_PayMode(string stringm_PayMode)
        {
            try
            {
                string xstrquery = @"select id From M_PayMode   WHERE id = '" + stringm_PayMode + "' ";
                DataRow drM_PayMode = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_PayMode != null)
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

        public List<M_PayMode> SelectM_PayModeMulti(M_PayMode objm_PayMode2)
        {
            List<M_PayMode> retval = new List<M_PayMode>();
            try
            {
                strquery = @"select * from m_PayMode where id = '" + objm_PayMode2.id + "'";
                DataTable dtm_PayMode = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_PayMode.Rows)
                {
                    if (drType != null)
                    {
                        M_PayMode objm_PayMode = new M_PayMode();
                        objm_PayMode.id = drType["id"].ToString();
                        objm_PayMode.description = drType["description"].ToString();
                        objm_PayMode.isActive = int.Parse(drType["isActive"].ToString());
                        objm_PayMode.isSubPaymode = int.Parse(drType["isSubPaymode"].ToString());
                        objm_PayMode.isAddBalance = int.Parse(drType["isAddBalance"].ToString());
                        objm_PayMode.isAdvancePayment = int.Parse(drType["isAdvancePayment"].ToString());
                        objm_PayMode.isControlOverPayment = int.Parse(drType["isControlOverPayment"].ToString());
                        objm_PayMode.isVoucher = int.Parse(drType["isVoucher"].ToString());
                        objm_PayMode.accountCode = drType["accountCode"].ToString();
                        objm_PayMode.CommissionAccCode = drType["CommissionAccCode"].ToString();
                        objm_PayMode.isCredit = int.Parse(drType["isCredit"].ToString());
                        objm_PayMode.isPoint = int.Parse(drType["isPoint"].ToString());
                        objm_PayMode.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        objm_PayMode.ischeque = int.Parse(drType["ischeque"].ToString());
                        retval.Add(objm_PayMode);
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
