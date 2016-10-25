using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smartOffice_Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SmartAnything_DL
{
    public class M_CompanyDL
    {

        string strquery = "";

        public Boolean SaveBankSP(M_Company m_Company, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "Company_Save";

                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = m_Company.CompCode;
                scom.Parameters.Add("@Descr", SqlDbType.VarChar, 50).Value = m_Company.Descr;
                scom.Parameters.Add("@Add1", SqlDbType.VarChar, 50).Value = m_Company.Add1;
                scom.Parameters.Add("@Add2", SqlDbType.VarChar, 50).Value = m_Company.Add2;
                scom.Parameters.Add("@Add3", SqlDbType.VarChar, 50).Value = m_Company.Add3;
                scom.Parameters.Add("@Fax", SqlDbType.VarChar, 50).Value = m_Company.Fax;
                scom.Parameters.Add("@Emailx", SqlDbType.VarChar, 50).Value = m_Company.Emailx;
                scom.Parameters.Add("@Tpno", SqlDbType.VarChar, 20).Value = m_Company.Tpno;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = m_Company.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_Company.Datex;
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


        public DataTable SelectAllCompanies()
        {
            try
            {
                strquery = @"select [CompCode],	[Descr] from [M_Company]";
                DataTable dtBank = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtBank;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public M_Company SelectCompany(string code)
        {
            try
            {
                M_Company objBank = new M_Company();
                strquery = @"select * from M_Company where CompCode = '" + code.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objBank.Add1 = drType["Add1"].ToString();
                    objBank.Add2 = drType["Add2"].ToString();
                    objBank.Add3 = drType["Add3"].ToString();
                    objBank.CompCode = drType["CompCode"].ToString();
                    objBank.Datex = DateTime.Parse(drType["Datex"].ToString());
                    objBank.Descr = drType["Descr"].ToString();
                    objBank.Emailx = drType["Emailx"].ToString();
                    objBank.Fax = drType["Fax"].ToString();
                    objBank.Tpno = drType["Tpno"].ToString();
                    objBank.Userx = drType["Userx"].ToString();

                    return objBank;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingBank(string stringBank)
        {
            try
            {
                string xstrquery = @"select compcode from M_Company where compcode = '" + stringBank.Trim() + "'";
                DataRow drBank = u_DBConnection.ReturnDataRow(xstrquery);

                if (drBank != null)
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
    }
}
