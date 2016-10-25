using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_trnsferInNoteDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_trnsferInNote table.
        /// </summary>
        public Boolean Savet_trnsferInNoteSP(t_trnsferInNote t_trnsferInNote, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_trnsferInNoteSave";

                scom.Parameters.Add("@transinNo", SqlDbType.VarChar, 20).Value = t_trnsferInNote.transinNo;
                scom.Parameters.Add("@sourceLocId", SqlDbType.VarChar, 20).Value = t_trnsferInNote.sourceLocId;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_trnsferInNote.date;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_trnsferInNote.refNo;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 150).Value = t_trnsferInNote.remarks;
                scom.Parameters.Add("@destinationLocId", SqlDbType.VarChar, 20).Value = t_trnsferInNote.destinationLocId;
                scom.Parameters.Add("@purchaseReqNo", SqlDbType.VarChar, 20).Value = t_trnsferInNote.purchaseReqNo;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_trnsferInNote.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_trnsferInNote.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_trnsferInNote.grossAmount;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_trnsferInNote.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_trnsferInNote.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 30).Value = t_trnsferInNote.processUser;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_trnsferInNote.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_trnsferInNote.triggerVal;
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


        public DataTable SelectAllt_trnsferInNote()
        {
            try
            {
                strquery = @"select transinNo,grossAmount from t_trnsferInNote";
                DataTable dtt_trnsferInNote = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_trnsferInNote;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_trnsferInNote Selectt_trnsferInNote(t_trnsferInNote objt_trnsferInNote)
        {
            try
            {
                strquery = @"select * from t_trnsferInNote where transinNo = '" + objt_trnsferInNote.transinNo + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_trnsferInNote.transinNo = drType["transinNo"].ToString();
                    objt_trnsferInNote.sourceLocId = drType["sourceLocId"].ToString();
                    objt_trnsferInNote.date = DateTime.Parse(drType["date"].ToString());
                    objt_trnsferInNote.refNo = drType["refNo"].ToString();
                    objt_trnsferInNote.remarks = drType["remarks"].ToString();
                    objt_trnsferInNote.destinationLocId = drType["destinationLocId"].ToString();
                    objt_trnsferInNote.purchaseReqNo = drType["purchaseReqNo"].ToString();
                    objt_trnsferInNote.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_trnsferInNote.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_trnsferInNote.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_trnsferInNote.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_trnsferInNote.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_trnsferInNote.processUser = drType["processUser"].ToString();
                    objt_trnsferInNote.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_trnsferInNote.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_trnsferInNote;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_trnsferInNote(string stringt_trnsferInNote)
        {
            try
            {
                string xstrquery = @"select transinNo From T_trnsferInNote   WHERE transinNo = '" + stringt_trnsferInNote + "' ";
                DataRow drT_trnsferInNote = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_trnsferInNote != null)
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

        public List<t_trnsferInNote> SelectT_trnsferInNoteMulti(t_trnsferInNote objt_trnsferInNote2)
        {
            List<t_trnsferInNote> retval = new List<t_trnsferInNote>();
            try
            {
                strquery = @"select * from t_trnsferInNote where transinNo = '" + objt_trnsferInNote2.transinNo + "'";
                DataTable dtt_trnsferInNote = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_trnsferInNote.Rows)
                {
                    if (drType != null)
                    {
                        t_trnsferInNote objt_trnsferInNote = new t_trnsferInNote();
                        objt_trnsferInNote.transinNo = drType["transinNo"].ToString();
                        objt_trnsferInNote.sourceLocId = drType["sourceLocId"].ToString();
                        objt_trnsferInNote.date = DateTime.Parse(drType["date"].ToString());
                        objt_trnsferInNote.refNo = drType["refNo"].ToString();
                        objt_trnsferInNote.remarks = drType["remarks"].ToString();
                        objt_trnsferInNote.destinationLocId = drType["destinationLocId"].ToString();
                        objt_trnsferInNote.purchaseReqNo = drType["purchaseReqNo"].ToString();
                        objt_trnsferInNote.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_trnsferInNote.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                        objt_trnsferInNote.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_trnsferInNote.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_trnsferInNote.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_trnsferInNote.processUser = drType["processUser"].ToString();
                        objt_trnsferInNote.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_trnsferInNote.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_trnsferInNote);
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
