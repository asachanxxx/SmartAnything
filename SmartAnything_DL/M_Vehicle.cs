using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_VehicleDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_Vehicles table.
        /// </summary>
        public Boolean SaveM_VehicleSP(M_Vehicles m_Vehicle, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_VehiclesSave";

                scom.Parameters.Add("@VehicleID", SqlDbType.VarChar, 20).Value = m_Vehicle.VehicleID;
                scom.Parameters.Add("@VehicleNo", SqlDbType.VarChar, 20).Value = m_Vehicle.VehicleNo;
                scom.Parameters.Add("@CompCode", SqlDbType.VarChar, 20).Value = m_Vehicle.CompCode;
                scom.Parameters.Add("@Locacode", SqlDbType.VarChar, 20).Value = m_Vehicle.Locacode;
                scom.Parameters.Add("@Make", SqlDbType.VarChar, 30).Value = m_Vehicle.Make;
                scom.Parameters.Add("@Model", SqlDbType.VarChar, 30).Value = m_Vehicle.Model;
                scom.Parameters.Add("@Driver", SqlDbType.VarChar, 50).Value = m_Vehicle.Driver;
                scom.Parameters.Add("@Milage", SqlDbType.VarChar, 50).Value = m_Vehicle.Milage;
                scom.Parameters.Add("@FuelEfficiency", SqlDbType.Decimal, 9).Value = m_Vehicle.FuelEfficiency;
                scom.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = m_Vehicle.Status;
                scom.Parameters.Add("@Route", SqlDbType.VarChar, 20).Value = m_Vehicle.Route;
                scom.Parameters.Add("@Userx", SqlDbType.VarChar, 20).Value = m_Vehicle.Userx;
                scom.Parameters.Add("@Datex", SqlDbType.DateTime, 8).Value = m_Vehicle.Datex;
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


        public DataTable SelectAllm_Vehicle()
        {
            try
            {
                strquery = @"select VehicleID ,VehicleNo from M_Vehicles";
                DataTable dtm_Vehicle = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Vehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_Vehicles Selectm_Vehicle(M_Vehicles objm_Vehicle)
        {
            try
            {
                strquery = @"select * from M_Vehicles where VehicleID = '" + objm_Vehicle.VehicleID.Trim() + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_Vehicle.VehicleID = drType["VehicleID"].ToString();
                    objm_Vehicle.VehicleNo = drType["VehicleNo"].ToString();
                    objm_Vehicle.CompCode = drType["CompCode"].ToString();
                    objm_Vehicle.Locacode = drType["Locacode"].ToString();
                    objm_Vehicle.Make = drType["Make"].ToString();
                    objm_Vehicle.Model = drType["Model"].ToString();
                    objm_Vehicle.Driver = drType["Driver"].ToString();
                    objm_Vehicle.Milage = drType["Milage"].ToString();
                    objm_Vehicle.FuelEfficiency = decimal.Parse(drType["FuelEfficiency"].ToString());
                    objm_Vehicle.Status = drType["Status"].ToString();
                    objm_Vehicle.Route = drType["Route"].ToString();
                    objm_Vehicle.Userx = drType["Userx"].ToString();
                    objm_Vehicle.Datex = DateTime.Parse(drType["Datex"].ToString());
                    return objm_Vehicle;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_Vehicle(string stringM_Vehicle)
        {
            try
            {
                string xstrquery = @"select VehicleID From M_Vehicles   WHERE VehicleID = '" + stringM_Vehicle .Trim() + "'";
                DataRow drM_Vehicle = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Vehicle != null)
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

        public static bool ExistingM_VehicleNo(string VehicleNo)
        {
            try
            {
                string xstrquery = @"select VehicleNo From M_Vehicles   WHERE VehicleNo = '" + VehicleNo.Trim() + "'";
                DataRow drM_Vehicle = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_Vehicle != null)
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
















        #endregion
    }
}
