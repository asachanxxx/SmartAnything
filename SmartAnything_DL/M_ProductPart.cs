using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class M_ProductPartDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the M_ProductParts table.
        /// </summary>
        public Boolean Savem_ProductPartSP(M_ProductParts m_ProductPart, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "M_ProductPartsSave";

                scom.Parameters.Add("@IDX", SqlDbType.VarChar, 20).Value = m_ProductPart.IDX;
                scom.Parameters.Add("@PartNo", SqlDbType.VarChar, 20).Value = m_ProductPart.PartNo;
                scom.Parameters.Add("@PartName", SqlDbType.VarChar, 100).Value = m_ProductPart.PartName;
                scom.Parameters.Add("@ModelNO", SqlDbType.VarChar, 20).Value = m_ProductPart.ModelNO;
                scom.Parameters.Add("@SerialNo", SqlDbType.VarChar, 20).Value = m_ProductPart.SerialNo;
                scom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = m_ProductPart.SKU;
                scom.Parameters.Add("@SuppCode", SqlDbType.VarChar, 20).Value = m_ProductPart.SuppCode;
                scom.Parameters.Add("@MfctCode", SqlDbType.VarChar, 20).Value = m_ProductPart.MfctCode;
                scom.Parameters.Add("@UnitOfMeasure", SqlDbType.VarChar, 10).Value = m_ProductPart.UnitOfMeasure;
                scom.Parameters.Add("@Color", SqlDbType.VarChar, 10).Value = m_ProductPart.Color;
                scom.Parameters.Add("@Brand", SqlDbType.VarChar, 10).Value = m_ProductPart.Brand;
                scom.Parameters.Add("@Capacity", SqlDbType.VarChar, 10).Value = m_ProductPart.Capacity;
                scom.Parameters.Add("@UnitPrice", SqlDbType.Decimal, 9).Value = m_ProductPart.UnitPrice;
                scom.Parameters.Add("@SellingPrice", SqlDbType.Decimal, 9).Value = m_ProductPart.SellingPrice;
                scom.Parameters.Add("@CostPrice", SqlDbType.Decimal, 9).Value = m_ProductPart.CostPrice;
                scom.Parameters.Add("@AvgPrice", SqlDbType.Decimal, 9).Value = m_ProductPart.AvgPrice;
                scom.Parameters.Add("@PackSize", SqlDbType.Decimal, 9).Value = m_ProductPart.PackSize;
                scom.Parameters.Add("@ReOrderLevel", SqlDbType.Decimal, 9).Value = m_ProductPart.ReOrderLevel;
                scom.Parameters.Add("@MinQty", SqlDbType.Decimal, 9).Value = m_ProductPart.MinQty;
                scom.Parameters.Add("@EOQty", SqlDbType.Decimal, 9).Value = m_ProductPart.EOQty;
                scom.Parameters.Add("@ReOrderQty", SqlDbType.Decimal, 9).Value = m_ProductPart.ReOrderQty;
                scom.Parameters.Add("@CreateUser", SqlDbType.VarChar, 20).Value = m_ProductPart.CreateUser;
                scom.Parameters.Add("@CreateDate", SqlDbType.DateTime, 8).Value = m_ProductPart.CreateDate;
                scom.Parameters.Add("@ModifyUser", SqlDbType.VarChar, 20).Value = m_ProductPart.ModifyUser;
                scom.Parameters.Add("@ModifyDate", SqlDbType.DateTime, 8).Value = m_ProductPart.ModifyDate;
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


        public DataTable SelectAllm_ProductPart()
        {
            try
            {
                strquery = @"SELECT idx AS 'Part Code' , PartNo AS 'Part Number' , PartName AS 'Part Name' FROM dbo.M_ProductParts";
                DataTable dtm_ProductPart = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_ProductPart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public M_ProductParts Selectm_ProductPart(M_ProductParts objm_ProductPart)
        {
            try
            {
                strquery = @"select * from m_ProductParts where IDX = '" + objm_ProductPart.IDX + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objm_ProductPart.IDX = drType["IDX"].ToString();
                    objm_ProductPart.PartNo = drType["PartNo"].ToString();
                    objm_ProductPart.PartName = drType["PartName"].ToString();
                    objm_ProductPart.ModelNO = drType["ModelNO"].ToString();
                    objm_ProductPart.SerialNo = drType["SerialNo"].ToString();
                    objm_ProductPart.SKU = drType["SKU"].ToString();
                    objm_ProductPart.SuppCode = drType["SuppCode"].ToString();
                    objm_ProductPart.MfctCode = drType["MfctCode"].ToString();
                    objm_ProductPart.UnitOfMeasure = drType["UnitOfMeasure"].ToString();
                    objm_ProductPart.Color = drType["Color"].ToString();
                    objm_ProductPart.Brand = drType["Brand"].ToString();
                    objm_ProductPart.Capacity = drType["Capacity"].ToString();
                    objm_ProductPart.UnitPrice = decimal.Parse(drType["UnitPrice"].ToString());
                    objm_ProductPart.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                    objm_ProductPart.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                    objm_ProductPart.AvgPrice = decimal.Parse(drType["AvgPrice"].ToString());
                    objm_ProductPart.PackSize = decimal.Parse(drType["PackSize"].ToString());
                    objm_ProductPart.ReOrderLevel = decimal.Parse(drType["ReOrderLevel"].ToString());
                    objm_ProductPart.MinQty = decimal.Parse(drType["MinQty"].ToString());
                    objm_ProductPart.EOQty = decimal.Parse(drType["EOQty"].ToString());
                    objm_ProductPart.ReOrderQty = decimal.Parse(drType["ReOrderQty"].ToString());
                    objm_ProductPart.CreateUser = drType["CreateUser"].ToString();
                    objm_ProductPart.CreateDate = DateTime.Parse(drType["CreateDate"].ToString());
                    objm_ProductPart.ModifyUser = drType["ModifyUser"].ToString();
                    objm_ProductPart.ModifyDate = DateTime.Parse(drType["ModifyDate"].ToString());
                    return objm_ProductPart;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingM_ProductPart(string stringm_ProductPart)
        {
            try
            {
                string xstrquery = @"select IDX From M_ProductParts   WHERE IDX = '" + stringm_ProductPart + "' ";
                DataRow drM_ProductPart = u_DBConnection.ReturnDataRow(xstrquery);
                if (drM_ProductPart != null)
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

        public List<M_ProductParts> SelectM_ProductPartMulti(M_ProductParts objm_ProductPart2)
        {
            List<M_ProductParts> retval = new List<M_ProductParts>();
            try
            {
                strquery = @"select * from m_ProductPart where purchaseReqNo = '" + objm_ProductPart2.Capacity + "'";
                DataTable dtm_ProductPart = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtm_ProductPart.Rows)
                {
                    if (drType != null)
                    {
                        M_ProductParts objm_ProductPart = new M_ProductParts();
                        objm_ProductPart.IDX = drType["IDX"].ToString();
                        objm_ProductPart.PartNo = drType["PartNo"].ToString();
                        objm_ProductPart.PartName = drType["PartName"].ToString();
                        objm_ProductPart.ModelNO = drType["ModelNO"].ToString();
                        objm_ProductPart.SerialNo = drType["SerialNo"].ToString();
                        objm_ProductPart.SKU = drType["SKU"].ToString();
                        objm_ProductPart.SuppCode = drType["SuppCode"].ToString();
                        objm_ProductPart.MfctCode = drType["MfctCode"].ToString();
                        objm_ProductPart.UnitOfMeasure = drType["UnitOfMeasure"].ToString();
                        objm_ProductPart.Color = drType["Color"].ToString();
                        objm_ProductPart.Brand = drType["Brand"].ToString();
                        objm_ProductPart.Capacity = drType["Capacity"].ToString();
                        objm_ProductPart.UnitPrice = decimal.Parse(drType["UnitPrice"].ToString());
                        objm_ProductPart.SellingPrice = decimal.Parse(drType["SellingPrice"].ToString());
                        objm_ProductPart.CostPrice = decimal.Parse(drType["CostPrice"].ToString());
                        objm_ProductPart.AvgPrice = decimal.Parse(drType["AvgPrice"].ToString());
                        objm_ProductPart.PackSize = decimal.Parse(drType["PackSize"].ToString());
                        objm_ProductPart.ReOrderLevel = decimal.Parse(drType["ReOrderLevel"].ToString());
                        objm_ProductPart.MinQty = decimal.Parse(drType["MinQty"].ToString());
                        objm_ProductPart.EOQty = decimal.Parse(drType["EOQty"].ToString());
                        objm_ProductPart.ReOrderQty = decimal.Parse(drType["ReOrderQty"].ToString());
                        objm_ProductPart.CreateUser = drType["CreateUser"].ToString();
                        objm_ProductPart.CreateDate = DateTime.Parse(drType["CreateDate"].ToString());
                        objm_ProductPart.ModifyUser = drType["ModifyUser"].ToString();
                        objm_ProductPart.ModifyDate = DateTime.Parse(drType["ModifyDate"].ToString());
                        retval.Add(objm_ProductPart);
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
