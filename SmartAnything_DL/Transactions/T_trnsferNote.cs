using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything
{
    public class T_trnsferNoteDL
    {

        string strquery = "";
        #region Fields

        private string connectionStringName;

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the t_trnsferNote table.
        /// </summary>
        public Boolean Savet_trnsferNoteSP(t_trnsferNote t_trnsferNote, int formMode)
        {
            SqlCommand scom;
            bool retvalue = false;
            try
            {
                scom = new SqlCommand();
                scom.CommandType = CommandType.StoredProcedure;
                scom.CommandText = "T_trnsferNoteSave";

                scom.Parameters.Add("@no", SqlDbType.VarChar, 20).Value = t_trnsferNote.no;
                scom.Parameters.Add("@sourceLocId", SqlDbType.VarChar, 20).Value = t_trnsferNote.sourceLocId;
                scom.Parameters.Add("@date", SqlDbType.DateTime, 8).Value = t_trnsferNote.date;
                scom.Parameters.Add("@refNo", SqlDbType.VarChar, 20).Value = t_trnsferNote.refNo;
                scom.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = t_trnsferNote.remarks;
                scom.Parameters.Add("@destinationLocId", SqlDbType.VarChar, 20).Value = t_trnsferNote.destinationLocId;
                scom.Parameters.Add("@purchaseReqNo", SqlDbType.VarChar, 20).Value = t_trnsferNote.purchaseReqNo;
                scom.Parameters.Add("@noOfItems", SqlDbType.Decimal, 9).Value = t_trnsferNote.noOfItems;
                scom.Parameters.Add("@noOfPeaces", SqlDbType.Decimal, 9).Value = t_trnsferNote.noOfPeaces;
                scom.Parameters.Add("@grossAmount", SqlDbType.Decimal, 9).Value = t_trnsferNote.grossAmount;
                scom.Parameters.Add("@isSaved", SqlDbType.Bit, 1).Value = t_trnsferNote.isSaved;
                scom.Parameters.Add("@isProcessed", SqlDbType.Bit, 1).Value = t_trnsferNote.isProcessed;
                scom.Parameters.Add("@processDate", SqlDbType.DateTime, 8).Value = t_trnsferNote.processDate;
                scom.Parameters.Add("@processUser", SqlDbType.VarChar, 20).Value = t_trnsferNote.processUser;
                scom.Parameters.Add("@GLUpdate", SqlDbType.Bit, 1).Value = t_trnsferNote.GLUpdate;
                scom.Parameters.Add("@triggerVal", SqlDbType.Int, 4).Value = t_trnsferNote.triggerVal;
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


        public DataTable SelectAllt_trnsferNote()
        {
            try
            {
                strquery = @"select no,grossAmount from t_trnsferNote";
                DataTable dtt_trnsferNote = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtt_trnsferNote;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public t_trnsferNote Selectt_trnsferNote(t_trnsferNote objt_trnsferNote)
        {
            try
            {
                strquery = @"select * from t_trnsferNote where no = '" + objt_trnsferNote.no + "'";
                DataRow drType = u_DBConnection.ReturnDataRow(strquery);
                if (drType != null)
                {
                    objt_trnsferNote.no = drType["no"].ToString();
                    objt_trnsferNote.sourceLocId = drType["sourceLocId"].ToString();
                    objt_trnsferNote.date = DateTime.Parse(drType["date"].ToString());
                    objt_trnsferNote.refNo = drType["refNo"].ToString();
                    objt_trnsferNote.remarks = drType["remarks"].ToString();
                    objt_trnsferNote.destinationLocId = drType["destinationLocId"].ToString();
                    objt_trnsferNote.purchaseReqNo = drType["purchaseReqNo"].ToString();
                    objt_trnsferNote.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                    objt_trnsferNote.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                    objt_trnsferNote.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                    objt_trnsferNote.isSaved = bool.Parse(drType["isSaved"].ToString());
                    objt_trnsferNote.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                    objt_trnsferNote.processDate = DateTime.Parse(drType["processDate"].ToString());
                    objt_trnsferNote.processUser = drType["processUser"].ToString();
                    objt_trnsferNote.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                    objt_trnsferNote.triggerVal = int.Parse(drType["triggerVal"].ToString());
                    return objt_trnsferNote;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExistingT_trnsferNote(string stringt_trnsferNote)
        {
            try
            {
                string xstrquery = @"select no From T_trnsferNote   WHERE no = '" + stringt_trnsferNote + "' ";
                DataRow drT_trnsferNote = u_DBConnection.ReturnDataRow(xstrquery);
                if (drT_trnsferNote != null)
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

        public List<t_trnsferNote> SelectT_trnsferNoteMulti(t_trnsferNote objt_trnsferNote2)
        {
            List<t_trnsferNote> retval = new List<t_trnsferNote>();
            try
            {
                strquery = @"select * from t_trnsferNote where no = '" + objt_trnsferNote2.no + "'";
                DataTable dtt_trnsferNote = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                foreach (DataRow drType in dtt_trnsferNote.Rows)
                {
                    if (drType != null)
                    {
                        t_trnsferNote objt_trnsferNote = new t_trnsferNote();
                        objt_trnsferNote.no = drType["no"].ToString();
                        objt_trnsferNote.sourceLocId = drType["sourceLocId"].ToString();
                        objt_trnsferNote.date = DateTime.Parse(drType["date"].ToString());
                        objt_trnsferNote.refNo = drType["refNo"].ToString();
                        objt_trnsferNote.remarks = drType["remarks"].ToString();
                        objt_trnsferNote.destinationLocId = drType["destinationLocId"].ToString();
                        objt_trnsferNote.purchaseReqNo = drType["purchaseReqNo"].ToString();
                        objt_trnsferNote.noOfItems = decimal.Parse(drType["noOfItems"].ToString());
                        objt_trnsferNote.noOfPeaces = decimal.Parse(drType["noOfPeaces"].ToString());
                        objt_trnsferNote.grossAmount = decimal.Parse(drType["grossAmount"].ToString());
                        objt_trnsferNote.isSaved = bool.Parse(drType["isSaved"].ToString());
                        objt_trnsferNote.isProcessed = bool.Parse(drType["isProcessed"].ToString());
                        objt_trnsferNote.processDate = DateTime.Parse(drType["processDate"].ToString());
                        objt_trnsferNote.processUser = drType["processUser"].ToString();
                        objt_trnsferNote.GLUpdate = bool.Parse(drType["GLUpdate"].ToString());
                        objt_trnsferNote.triggerVal = int.Parse(drType["triggerVal"].ToString());
                        retval.Add(objt_trnsferNote);
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
