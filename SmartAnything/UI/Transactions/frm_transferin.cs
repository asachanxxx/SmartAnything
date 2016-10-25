using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAnything;
using SmartAnything_DL;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything.UI
{
    public partial class frm_transferin : Form
    {

        int formMode = 0;
        string formID = "A0044";
        string formHeadertext = "Transfer In Note";
        DataTable dtx = new DataTable();
        bool already = false;

        #region Loading one instance

        private static frm_transferin objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_transferin getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_transferin();

            }
            return objSingleObject;

        }

        #endregion

        public frm_transferin()
        {
            InitializeComponent();
        }

        private void frm_transferin_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);


                dtx = commonFunctions.CreateDatatable(1);
                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                dataGridView1.Columns[0].Width = 120;
                dataGridView1.Columns[1].Width = 280;
                txt_code.Focus();
                dataGridView1.AllowUserToAddRows = false;

                txt_sourceLocId.Text = commonFunctions.GlobalLocation;
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_sourceLocId.Text.Trim());
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }

        }

        #region buttons Click events

        private void btn_new_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.New);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Edit);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Delete);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Print);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Cancel);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Save);
        }

        #endregion

        #region textareaFunctions

        private void textareaFunctions(bool stype)
        {
            if (stype == true)
            {

                txt_remarks.Text = "";
                dte_date.Value = DateTime.Now;


                txt_code.Text = "";
                txt_cost.Text = "0.00";
                txt_selling.Text = "0.00";
                txt_qty.Text = "0.00";
                txt_amt.Text = "0.00";

                txt_remarks.Enabled = true;
                txt_sourceLocId.Enabled = true;
                dte_date.Enabled = true;

                dataGridView1.Enabled = true;
            }
            else
            {

                txt_remarks.Enabled = false;
                txt_sourceLocId.Enabled = false;
                dte_date.Enabled = false;
                dataGridView1.Enabled = false;

            }
        }

        #endregion 

        #region performButtons Area

        private void performButtons(xEnums.PerformanceType xenum)
        {

            try
            {
                switch (xenum)
                {
                    case xEnums.PerformanceType.View:
                        if (ActiveControl.Name.Trim() == txt_no.Name.Trim())
                        {
                            int length = Convert.ToInt32(ConfigurationManager.AppSettings["POFieldLength"]);
                            string[] strSearchField = new string[length];

                            string strSQL = ConfigurationManager.AppSettings["POSQL"].ToString();

                            for (int i = 0; i < length; i++)
                            {
                                string m;
                                m = i.ToString();
                                strSearchField[i] = ConfigurationManager.AppSettings["POField" + m + ""].ToString();
                            }

                            frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                            find.ShowDialog(this);
                        }

                        break;

                    case xEnums.PerformanceType.New:
                        FunctionButtonStatus(xEnums.PerformanceType.New);
                        formMode = 1;
                        txt_no.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_no.Focus();

                        txt_sourceLocId.Text = commonFunctions.GlobalLocation;
                        txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_sourceLocId.Text.Trim());

                        errorProvider1.Clear();

                        lbl_processes.Visible = false;
                        break;

                    case xEnums.PerformanceType.Edit:
                        FunctionButtonStatus(xEnums.PerformanceType.Edit);
                        formMode = 3;
                        //txt_VehicleID.Enabled = false;
                        //txt_VehicleNo.Focus();
                        errorProvider1.Clear();
                        break;

                    case xEnums.PerformanceType.Save:
                        errorProvider1.Clear();
                        if (formMode == 1)
                        {
                            if (txt_sourceLocId.Text.Trim().ToUpper() == txt_destinationLocId.Text.Trim().ToUpper())
                            {
                                errorProvider1.SetError(txt_destinationLocId, "Destination location cannot same as login location");
                                return;
                            }


                            if (!M_LocaDL.ExistingM_Loca(txt_sourceLocId.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_sourceLocId, "Location does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Location does not exists on the system", 1);
                                return;
                            }


                            if (!M_LocaDL.ExistingM_Loca(txt_destinationLocId.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_destinationLocId, "Destination Location does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Destination Location does not exists on the system", 1);

                                return;
                            }

                            if (commonFunctions.GetNoofItems(dataGridView1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                commonFunctions.SetMDIStatusMessage("Please enter some items to the details grid", 1);

                                return;
                            }



                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {

                                    using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                    {
                                        //u_DBConnection.BeginTrans();
                                        //save header data
                                        t_trnsferInNote objt_trnsferInNote = new t_trnsferInNote();
                                        objt_trnsferInNote.transinNo = txt_no.Text.Trim();
                                        objt_trnsferInNote.sourceLocId = commonFunctions.GlobalLocation;
                                        objt_trnsferInNote.date = dte_date.Value;
                                        objt_trnsferInNote.refNo = txt_refNo.Text.Trim();
                                        objt_trnsferInNote.remarks = txt_remarks.Text.Trim();
                                        objt_trnsferInNote.destinationLocId = txt_destinationLocId.Text.Trim();
                                        objt_trnsferInNote.purchaseReqNo = txt_purchaseReqNo.Text.Trim();
                                        objt_trnsferInNote.noOfItems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                        objt_trnsferInNote.noOfPeaces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                        objt_trnsferInNote.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                        objt_trnsferInNote.isProcessed = false;
                                        objt_trnsferInNote.processDate = DateTime.Now;
                                        objt_trnsferInNote.processUser = "";
                                        objt_trnsferInNote.GLUpdate = false;
                                        objt_trnsferInNote.triggerVal = 1;
                                        T_trnsferInNoteDL bal = new T_trnsferInNoteDL();
                                        bal.Savet_trnsferInNoteSP(objt_trnsferInNote, 1);


                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {

                                                t_transferIn_detail objt_transferIn_detail = new t_transferIn_detail();
                                                objt_transferIn_detail.transinrNo = txt_no.Text.Trim();
                                                objt_transferIn_detail.sourceLocId = commonFunctions.GlobalLocation;
                                                objt_transferIn_detail.destinationLocId = txt_destinationLocId.Text.Trim();
                                                objt_transferIn_detail.transferDate = dte_date.Value;
                                                objt_transferIn_detail.stockCode = drow.Cells["Product Code"].Value.ToString();
                                                objt_transferIn_detail.description = drow.Cells["Product Name"].Value.ToString();
                                                objt_transferIn_detail.quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_transferIn_detail.costPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_transferIn_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                objt_transferIn_detail.triggerVal = 1;
                                                T_transferIn_detailDL bal2 = new T_transferIn_detailDL();
                                                bal2.Savet_transferIn_detailSP(objt_transferIn_detail, 1);


                                            }

                                        }

                                        //increment the serial
                                        commonFunctions.IncrementSerial(formID);
                                        transaction.Complete();
                                        //u_DBConnection.CommitTrans();
                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // u_DBConnection.RollbackTrans();
                                    LogFile.WriteErrorLog("Save Transactions", "Transfer In", ex.Message);
                                    LogFile.WriteErrorLog("Save Transactions", "Transfer Out", ex.Message);
                                    commonFunctions.SetMDIStatusMessage("Transfer Number you have entered already processed", 1);
                                }

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    UpdateStock();

                                    t_trnsferInNote objt_trnsferNote = new t_trnsferInNote();
                                    objt_trnsferNote.transinNo = txt_no.Text.Trim();

                                    T_trnsferInNoteDL balprocess = new T_trnsferInNoteDL();
                                    objt_trnsferNote = balprocess.Selectt_trnsferInNote(objt_trnsferNote);

                                    objt_trnsferNote.isProcessed = true;
                                    objt_trnsferNote.processDate = DateTime.Now;
                                    objt_trnsferNote.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_trnsferInNoteSP(objt_trnsferNote, 3);
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                }


                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();
                                //clear text fields
                                textareaFunctions(true);

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_no.Text = commonFunctions.GetSerial(formID.Trim());
                                //txt_supplierId.Focus();
                            }
                        }
                        else if (formMode == 3)
                        {
                            t_trnsferInNote cat = new t_trnsferInNote();
                            cat.transinNo = txt_no.Text.Trim();
                            T_trnsferInNoteDL dl = new T_trnsferInNoteDL();
                            cat = dl.Selectt_trnsferInNote(cat);
                            if (cat.isProcessed == false)
                            {

                               if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    UpdateStock();

                                    t_trnsferInNote objt_trnsferNote = new t_trnsferInNote();
                                    objt_trnsferNote.transinNo = txt_no.Text.Trim();

                                    T_trnsferInNoteDL balprocess = new T_trnsferInNoteDL();
                                    objt_trnsferNote = balprocess.Selectt_trnsferInNote(objt_trnsferNote);

                                    objt_trnsferNote.isProcessed = true;
                                    objt_trnsferNote.processDate = DateTime.Now;
                                    objt_trnsferNote.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_trnsferInNoteSP(objt_trnsferNote, 3);
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                

                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    textareaFunctions(true);
                                    FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    txt_no.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_refNo.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_no, "Transfer IN Number you have entered already processed.");
                            }
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_no.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Default);
                        errorProvider1.Clear();
                        //clear text fields
                        textareaFunctions(true);
                        //clear Datagrid
                        dtx.Clear();
                        dataGridView1.Refresh();

                        //txt_supplierId.Text = "";
                        txt_remarks.Text = "";

                        lbl_processes.Visible = false;

                        break;
                    case xEnums.PerformanceType.Print:
                        UserDefineMessages.ShowMsg1("Print still in process", UserDefineMessages.Msg_Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

        #endregion

        #region ProcessDialogKey events

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {

                case Keys.Control | Keys.N:
                    performButtons(xEnums.PerformanceType.New);
                    break;
                case Keys.Control | Keys.E:
                    performButtons(xEnums.PerformanceType.Edit);
                    break;
                case Keys.Control | Keys.S:
                    if (formMode == 1 || formMode == 3)
                    {
                        performButtons(xEnums.PerformanceType.Save);
                    }
                    break;
                case Keys.Escape:
                    performButtons(xEnums.PerformanceType.Exit);
                    break;
                case Keys.Control | Keys.P:
                    performButtons(xEnums.PerformanceType.Print);
                    break;
                case Keys.Control | Keys.C:
                    performButtons(xEnums.PerformanceType.Cancel);
                    break;
                case Keys.Control | Keys.D:
                    performButtons(xEnums.PerformanceType.Delete);
                    break;
            }


            return false;
        }

        #endregion

        #region FunctionButtonStatus Area
        /*FunctionButtonStatus Was created by Asanga Chandrakumara on 12:18 PM 6/24/2015*/
        /// <summary>
        /// THis function will enable and disable the button status as required
        /// </summary>
        /// <param name="typex">Enumaration to function type</param>
        public void FunctionButtonStatus(xEnums.PerformanceType typex)
        {

            u_UserRights objUserRight = new u_UserRights();
            objUserRight.User = new u_User();
            objUserRight.MenuTag = new u_MenuTag();
            objUserRight.User.strUserID = Globals.g_strUser;
            objUserRight.MenuTag.strMenuID = formID.Trim();

            u_UserRights_DL objURightDL = new u_UserRights_DL();
            u_UserRights_DL dtAllMenuItems = objURightDL.GetUserRightsForOneMenu(objUserRight);



            switch (typex)
            {
                case xEnums.PerformanceType.Save:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;

                    }
                    break;
                case xEnums.PerformanceType.Delete: //when press the delete button
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;

                    }
                    break;
                case xEnums.PerformanceType.Existing: //enter existing item to system
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = false;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;

                    }
                    break;
                case xEnums.PerformanceType.Edit: //enter existing item to system and press edit
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = dtAllMenuItems.boolCreate;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        // dataGridView1.Enabled = false;
                        //txt_IDX.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        //dataGridView1.Enabled = false;
                        //txt_IDX.Enabled = false;
                    }
                    break;
                case xEnums.PerformanceType.Exit:
                    break;
                case xEnums.PerformanceType.New:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = false;
                        //txt_IDX.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        //dataGridView1.Enabled = false;
                        //txt_IDX.Enabled = false;

                    }
                    break;
                case xEnums.PerformanceType.Default:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        btn_save.Enabled = false;
                        btn_cancel.Enabled = false;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }


                    break;
                case xEnums.PerformanceType.Cancel:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;

                    }
                    break;
            }

        }

        #endregion

        #region Detail functions

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (txt_destinationLocId.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txt_destinationLocId, "Please enter destination location code");
                    return;
                }
                    if (ActiveControl.Name.Trim() == txt_code.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductStockFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString() + " WHERE T_Stock.Locacode = '" + txt_destinationLocId.Text.Trim() + "'";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ProductStockField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
                errorProvider1.Clear();
            }

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //txt_code.Text = commonFunctions.GetProcutCode(txt_code.Text.Trim());
                    if (T_StockDL.ExistingT_Stock_new(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {
                        if (!commonFunctions.IsExist(dataGridView1, txt_code.Text))
                        {

                            GetStockdetails(txt_destinationLocId.Text.Trim());
                            txt_qty.Text = "0";
                            txt_qty.Focus();

                            errorProvider1.Clear();
                            already = false;
                        }
                        else
                        {
                            already = true;
                            GetStockdetails(txt_destinationLocId.Text.Trim());

                            DataGridViewRow drowx = new DataGridViewRow();
                            drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                            txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();

                            txt_qty.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txt_code, "Product you have entered not exist in the bin card");
                        commonFunctions.SetMDIStatusMessage("Product you have entered not exist in the bin card", 1);
                    }
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
                    throw ex;
                }
            }
        }

        #region stockrelatedNEws

        private void UpdateStock()
        {
            try
            {
                t_transferIn_detail trans = new t_transferIn_detail();
                trans.transinrNo = txt_no.Text.Trim();
                List<t_transferIn_detail> Transins = new List<t_transferIn_detail>();
                Transins = new T_transferIn_detailDL().SelectT_transferIn_detailMulti(trans);

                foreach (t_transferIn_detail det in Transins)
                {

                    //reduce stock from this location
                    T_StockDL.AddStock_Update(det.stockCode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation, det.quantity.Value);

                    //update stock on destination
                    if (T_StockDL.ExistingT_Stock_new(det.stockCode.Trim(), commonFunctions.GlobalCompany, txt_destinationLocId.Text.Trim()))
                    {
                        //modify is already has record
                        T_StockDL.ReduceStock_Update(det.stockCode, commonFunctions.GlobalCompany, txt_destinationLocId.Text.Trim(), det.quantity.Value);
                    }
                    else
                    {
                        //insert
                        T_Stock objt_Stock = new T_Stock();
                        objt_Stock.StockCode = det.stockCode;
                        objt_Stock.Compcode = commonFunctions.GlobalCompany;
                        objt_Stock.Locacode = commonFunctions.GlobalLocation;
                        objt_Stock = new T_StockDL().Selectt_Stock_new(objt_Stock);
                        T_StockDL.AddStock_Insert(objt_Stock, commonFunctions.GlobalCompany, txt_destinationLocId.Text.Trim(), det.quantity.Value);

                    }
                }
            }
            catch (Exception ex)
            {
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                throw ex;
            }
        }

        private void GetStockdetails(string location)
        {
            try
            {
                T_Stock stk = StockEngine.GetStockdetails(txt_code.Text, location);
                txt_cost.Text = StockEngine.GetProductCostPrice(stk.ProductId).ToString();
                txt_selling.Text = StockEngine.GetProductSellingPrice(stk.ProductId).ToString();
                lbl_name.Text = stk.Descr;
                lbl_available.Text = stk.Stock.ToString();

            }
            catch (Exception ex)
            {
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                throw ex;
            }
        }

        #endregion
        
        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_selling.Text.Trim() != "")
                {
                    if (txt_qty.Text.Trim() != "")
                    {
                        if ((commonFunctions.ToDecimal(txt_qty.Text.Trim()) != decimal.Zero))
                        {

                            if (already == false)
                            {
                                decimal amount = commonFunctions.ToDecimal(txt_cost.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                txt_amt.Text = amount.ToString();
                                commonFunctions.AddRow(dtx, txt_code.Text, lbl_name.Text.Trim(), txt_cost.Text.Trim(), txt_selling.Text.Trim(), txt_qty.Text.Trim(), txt_amt.Text.Trim());
                                txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                txt_code.Focus();
                            }
                            else
                            {
                                decimal amount = commonFunctions.ToDecimal(txt_cost.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                txt_amt.Text = amount.ToString();
                                commonFunctions.AddRowtogrid(dataGridView1, txt_code.Text.Trim(), txt_qty.Text.Trim(), amount.ToString());
                                txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                txt_code.Focus();
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_qty, "Please enter quntity");
                        }

                    }

                }
                else
                {
                    txt_amt.Text = "0.00";

                }
            }
        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
            txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
        }

        #endregion

        private void txt_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingTransfer(txt_no.Text.Trim());
                txt_sourceLocId.Focus();
                errorProvider1.Clear();
            }


            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_no.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["TransferInFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["TransferInSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["TransferInField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingTransfer(txt_no.Text.Trim());
            }
        }

        #region FindExisitingTransfer

        private void FindExisitingTransfer(string ReqNo)
        {
            try{
            if (T_trnsferInNoteDL.ExistingT_trnsferInNote(ReqNo.Trim()))
            {
                formMode = 3;
                //clear datagrid
                dtx.Clear();
                dataGridView1.Refresh();

                //clear error fields
                errorProvider1.Clear();

                t_trnsferInNote cat = new t_trnsferInNote();
                cat.transinNo = ReqNo.Trim();
                T_trnsferInNoteDL dl = new T_trnsferInNoteDL();
                cat = dl.Selectt_trnsferInNote(cat);

                //set the process message and mode to edit mode
                if (cat.isProcessed == false)
                {
                    lbl_processes.Visible = false;
                    performButtons(xEnums.PerformanceType.Edit);
                }
                else
                {
                    lbl_processes.Visible = true;

                }

                //load and disable the data fields

                txt_destinationLocId.Text = cat.destinationLocId.Trim();
                txt_sourceLocId.Text = cat.sourceLocId.Trim();
                //txt_supplierId.Text = cat.supplierId.Trim();
                txt_remarks.Text = cat.remarks;
                dte_date.Value = cat.date;

                textareaFunctions(false);

                t_transferIn_detail req = new t_transferIn_detail();
                req.transinrNo = ReqNo.Trim();
                T_transferIn_detailDL tdl = new T_transferIn_detailDL();
                List<t_transferIn_detail> requests = new List<t_transferIn_detail>();
                requests = tdl.SelectT_transferIn_detailMulti(req);

                foreach (t_transferIn_detail det in requests)
                {

                    commonFunctions.AddRow(dtx, det.stockCode, findExisting.FindExisitingStock(det.stockCode).Trim(), det.costPrice.ToString(), det.costPrice.ToString(), det.quantity.ToString(), det.amount.ToString());
                }

                txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
            }
            else
            {
                if (formMode != 1)
                {
                    errorProvider1.SetError(txt_no, "Transfer In Number you have entered does not exists in the system.");
                }
            }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }

        }

        #endregion 

        private void txt_sourceLocId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_refNo.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_refNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_date.Focus();
                errorProvider1.Clear();
            }
        }

        private void dte_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_purchaseReqNo.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_purchaseReqNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_destinationLocId.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_destinationLocId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_destinationLocId.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["LocaFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["LocaSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["LocaField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
                txt_reqLocationId_name.Text = findExisting.FindExisitingLoca(txt_destinationLocId.Text);
            }

            if (e.KeyCode == Keys.Enter)
            {
                txt_reqLocationId_name.Text = findExisting.FindExisitingLoca(txt_destinationLocId.Text);
                txt_remarks.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
                errorProvider1.Clear();
            }
        }



    }
}
