using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_PayModeDetailDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_PayModeDetails table.
        /// </summary>
        public Boolean Savem_PayModeDetailSP(M_PayModeDetails m_PayModeDetail, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_PayModeDetailsSave";

                scom.Parameters.Add("@pay_modeId", SqlDbType.VarChar, 10).Value = m_PayModeDetail.pay_modeId;
                scom.Parameters.Add("@sub_payModeCode", SqlDbType.VarChar, 20).Value = m_PayModeDetail.sub_payModeCode;
                scom.Parameters.Add("@sub_payDes", SqlDbType.VarChar, 30).Value = m_PayModeDetail.sub_payDes;
                scom.Parameters.Add("@format", SqlDbType.Int, 4).Value = m_PayModeDetail.format;
                scom.Parameters.Add("@exchangeRate", SqlDbType.Decimal, 9).Value = m_PayModeDetail.exchangeRate;
                scom.Parameters.Add("@accountCode", SqlDbType.VarChar, 15).Value = m_PayModeDetail.accountCode;
                scom.Parameters.Add("@CommissionAccCode", SqlDbType.VarChar, 15).Value = m_PayModeDetail.CommissionAccCode;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = m_PayModeDetail.triggerVal;
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


        public DataTable SelectAllm_PayModeDetail()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [M_PayModeDetail]";
                DataTable dtm_PayModeDetail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_PayModeDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_PayModeDetails Selectm_PayModeDetail(M_PayModeDetails objm_PayModeDetail)
        {
            try
            {
                strquery = @"select * from m_PayModeDetail where sub_payModeCode = '" + objm_PayModeDetail.sub_payModeCode + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_PayModeDetail.pay_modeId = drType["pay_modeId"].ToString();
                    objm_PayModeDetail.sub_payModeCode = drType["sub_payModeCode"].ToString();
                    objm_PayModeDetail.sub_payDes = drType["sub_payDes"].ToString();
                    objm_PayModeDetail.format = int.Parse(drType["format"].ToString());
                    objm_PayModeDetail.exchangeRate = decimal.Parse(drType["exchangeRate"].ToString());
                    objm_PayModeDetail.accountCode = drType["accountCode"].ToString();
                    objm_PayModeDetail.CommissionAccCode = drType["CommissionAccCode"].ToString();
                    objm_PayModeDetail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objm_PayModeDetail;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_PayModeDetail(string stringm_PayModeDetail)
        {
            try
            {
                string xstrquery = @"select sub_payModeCode From M_PayModeDetail   WHERE sub_payModeCode = '" + stringm_PayModeDetail + "' ";
                DataRow drM_PayModeDetail = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_PayModeDetail != null)
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

        public List<M_PayModeDetails> SelectM_PayModeDetailMulti(M_PayModeDetails objm_PayModeDetail2)
        {
            List<M_PayModeDetails> retval = new List<M_PayModeDetails>();
            try
            {
                strquery = @"select * from m_PayModeDetail where pay_modeId = '" + objm_PayModeDetail2.pay_modeId + "'";
                DataTable dtm_PayModeDetail = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_PayModeDetail.Rows)
                {
                    if (drType != null)
                    {
                        M_PayModeDetails objm_PayModeDetail = new M_PayModeDetails();
                        objm_PayModeDetail.pay_modeId = drType["pay_modeId"].ToString();
                        objm_PayModeDetail.sub_payModeCode = drType["sub_payModeCode"].ToString();
                        objm_PayModeDetail.sub_payDes = drType["sub_payDes"].ToString();
                        objm_PayModeDetail.format = int.Parse(drType["format"].ToString());
                        objm_PayModeDetail.exchangeRate = decimal.Parse(drType["exchangeRate"].ToString());
                        objm_PayModeDetail.accountCode = drType["accountCode"].ToString();
                        objm_PayModeDetail.CommissionAccCode = drType["CommissionAccCode"].ToString();
                        objm_PayModeDetail.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objm_PayModeDetail);
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
