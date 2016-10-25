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
    public partial class frm_adjustment : Form
    {
        int formMode = 0;
        string formID = "A0027";
        string formHeadertext = "Stock Adjustments";
        DataTable dtx = new DataTable();
        bool already = false;


        #region Loading one instance

        private static frm_adjustment objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_adjustment getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_adjustment();

            }
            return objSingleObject;

        }

        #endregion


        public frm_adjustment()
        {
            InitializeComponent();
        }

        private void frm_adjustment_Load(object sender, EventArgs e)
        {
         try{   
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
             commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
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
                            if (!M_LocaDL.ExistingM_Loca(txt_sourceLocId.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_sourceLocId, "Location does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Location does not exists on the system", 1);
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
                                        t_adjustment_head objt_adjustment_head = new t_adjustment_head();

                                        objt_adjustment_head.adju_no = txt_no.Text.Trim();
                                        objt_adjustment_head.location_id = commonFunctions.GlobalLocation;
                                        objt_adjustment_head.adjsment_date = dte_date.Value;
                                        objt_adjustment_head.remarks = txt_remarks.Text.Trim();
                                        objt_adjustment_head.user_id = commonFunctions.Loginuser;
                                        objt_adjustment_head.batch_no = txt_batch_no.Text.Trim();
                                        objt_adjustment_head.process = false;
                                        objt_adjustment_head.process_user = commonFunctions.Loginuser;
                                        objt_adjustment_head.process_date = DateTime.Now;
                                        objt_adjustment_head.triggerVal = 1;
                                        T_adjustment_headDL bal = new T_adjustment_headDL();
                                        bal.Savet_adjustment_headSP(objt_adjustment_head, 1);


                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {

                                                //have to implement the logic. this is only saving the data to the system
                                                t_adjustment_details objt_adjustment_detail = new t_adjustment_details();
                                                objt_adjustment_detail.adju_no = txt_no.Text.Trim();
                                                objt_adjustment_detail.location_id = commonFunctions.GlobalLocation;
                                                objt_adjustment_detail.line_no = 1;
                                                objt_adjustment_detail.item_code = drow.Cells["Product Code"].Value.ToString();
                                                objt_adjustment_detail.cost = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_adjustment_detail.stock = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_adjustment_detail.physical_quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());//txt_physical_quantity.Text.Trim();
                                                objt_adjustment_detail.variance = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                if (rdo_add.Checked) {
                                                    objt_adjustment_detail.triggerVal = 1;
                                                }
                                                if (rdo_reduce.Checked)
                                                {
                                                    objt_adjustment_detail.triggerVal = 2;
                                                }
                                                T_adjustment_detailDL bal2 = new T_adjustment_detailDL();
                                                bal2.Savet_adjustment_detailSP(objt_adjustment_detail, 1);


                                            }

                                        }

                                        //increment the serial
                                        commonFunctions.IncrementSerial(formID);
                                        transaction.Complete();
                                    }
                                    //u_DBConnection.CommitTrans();
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());

                                }
                                catch (Exception ex)
                                {
                                    // u_DBConnection.RollbackTrans();
                                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                    commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
                                }

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    UpdateStock();

                                    t_adjustment_head objt_trnsferNote = new t_adjustment_head();
                                    objt_trnsferNote.adju_no = txt_no.Text.Trim();

                                    T_adjustment_headDL balprocess = new T_adjustment_headDL();
                                    objt_trnsferNote = balprocess.Selectt_adjustment_head(objt_trnsferNote);

                                    objt_trnsferNote.process = true;
                                    objt_trnsferNote.process_date = DateTime.Now;
                                    objt_trnsferNote.process_user = commonFunctions.Loginuser;
                                    balprocess.Savet_adjustment_headSP(objt_trnsferNote, 3);
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
                            t_adjustment_head cat = new t_adjustment_head();
                            cat.adju_no = txt_no.Text.Trim();
                            T_adjustment_headDL dl = new T_adjustment_headDL();
                            cat = dl.Selectt_adjustment_head(cat);
                            if (cat.process == false)
                            {

                                 if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    cat.location_id = txt_sourceLocId.Text.Trim();
                                    cat.adjsment_date = dte_date.Value;
                                    cat.remarks = txt_remarks.Text.Trim();
                                    cat.user_id = commonFunctions.Loginuser;
                                    cat.batch_no = txt_batch_no.Text.Trim();
                                    new T_adjustment_headDL().Savet_adjustment_headSP(cat, 3);

                                    List<t_adjustment_details> detsx = new List<t_adjustment_details>();
                                    t_adjustment_details detx = new t_adjustment_details();
                                    detx.adju_no = cat.adju_no.Trim();
                                    detsx = new T_adjustment_detailDL().SelectT_adjustment_detailMulti(detx);
                                    foreach (t_adjustment_details det in detsx) {
                                        new T_adjustment_detailDL().Savet_adjustment_detailSP(det, 4);
                                    }
                                    //save details 
                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                        {

                                            //have to implement the logic. this is only saving the data to the system
                                            t_adjustment_details objt_adjustment_detail = new t_adjustment_details();
                                            objt_adjustment_detail.adju_no = txt_no.Text.Trim();
                                            objt_adjustment_detail.location_id = txt_sourceLocId.Text.Trim();
                                            objt_adjustment_detail.line_no = 1;
                                            objt_adjustment_detail.item_code = drow.Cells["Product Code"].Value.ToString();
                                            objt_adjustment_detail.cost = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                            objt_adjustment_detail.stock = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                            objt_adjustment_detail.physical_quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());//txt_physical_quantity.Text.Trim();
                                            objt_adjustment_detail.variance = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                            if (rdo_add.Checked)
                                            {
                                                objt_adjustment_detail.triggerVal = 1;
                                            }
                                            if (rdo_reduce.Checked)
                                            {
                                                objt_adjustment_detail.triggerVal = 2;
                                            }
                                            T_adjustment_detailDL bal2 = new T_adjustment_detailDL();
                                            bal2.Savet_adjustment_detailSP(objt_adjustment_detail, 1);
                                        }

                                    }

                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        cat.process = true;
                                        cat.process_date = DateTime.Now;
                                        cat.process_user = commonFunctions.Loginuser;
                                        new T_adjustment_headDL().Savet_adjustment_headSP(cat, 3);
                                        UpdateStock();
                                    }

                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    textareaFunctions(true);
                                    FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    txt_no.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_code.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_no, "Adjustment Number you have entered already processed.");
                                commonFunctions.SetMDIStatusMessage("Adjustment Number you have entered already processed", 1);
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
                        //txt_remarks.Text = "";

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
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
            }

        }

        #endregion

        #region stockrelatedNEws

        private void UpdateStock()
        {
            try
            {
                t_adjustment_details trans = new t_adjustment_details();
                trans.adju_no = txt_no.Text.Trim();
                List<t_adjustment_details> Transins = new List<t_adjustment_details>();
                Transins = new T_adjustment_detailDL().SelectT_adjustment_detailMulti(trans);

                foreach (t_adjustment_details det in Transins)
                {


                    T_Stock objt_Stock = new T_Stock();
                    objt_Stock.StockCode = det.item_code;
                    objt_Stock.Compcode = commonFunctions.GlobalCompany;
                    objt_Stock.Locacode = commonFunctions.GlobalLocation;
                    objt_Stock = new T_StockDL().Selectt_Stock_new(objt_Stock);

                    decimal currentst = decimal.Zero;
                    //currentst = commonFunctions.ToDecimal(objt_Stock.Stock.ToString()) + commonFunctions.ToDecimal(det.stock.ToString());
                    currentst = objt_Stock.Stock.Value;
                    if (det.triggerVal == 1)
                    {
                        currentst += det.stock.Value;
                    }
                    if (det.triggerVal == 2)
                    {
                        currentst -= det.stock.Value;
                    }
                    objt_Stock.Stock = currentst;

                    new T_StockDL().SaveT_StockSP(objt_Stock, 3,1);
                }
            }
            catch (Exception ex)
            {
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                throw ex;
            }
        }

        private void GetStockdetails()
        {
            try
            {
                T_Stock stk = new T_Stock();
                stk.Locacode = commonFunctions.GlobalLocation;
                stk.Compcode = commonFunctions.GlobalCompany;
                stk.StockCode = txt_code.Text;
                stk = new T_StockDL().Selectt_Stock_new(stk);

                txt_cost.Text = stk.CostPrice.ToString();
                txt_selling.Text = stk.SellingPrice.ToString();
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
                if (ActiveControl.Name.Trim() == txt_code.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductStockFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString() + " WHERE T_Stock.Locacode = '" + txt_sourceLocId.Text.Trim() + "'";

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
                    if (T_StockDL.ExistingT_Stock_new(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {
                        if (!commonFunctions.IsExist(dataGridView1, txt_code.Text))
                        {

                            GetStockdetails();
                            txt_qty.Text = "0";
                            txt_qty.Focus();

                            errorProvider1.Clear();
                            already = false;
                        }
                        else
                        {
                            already = true;
                            GetStockdetails();

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

        #region FindExisitingTransfer

        private void FindExisitingTransfer(string ReqNo)
        {
            try
            {
                if (T_adjustment_headDL.ExistingT_adjustment_head(ReqNo.Trim()))
                {
                    formMode = 3;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                    t_adjustment_head cat = new t_adjustment_head();
                    cat.adju_no = ReqNo.Trim();
                    T_adjustment_headDL dl = new T_adjustment_headDL();
                    cat = dl.Selectt_adjustment_head(cat);

                    //set the process message and mode to edit mode
                    if (cat.process == false)
                    {
                        lbl_processes.Visible = false;
                        performButtons(xEnums.PerformanceType.Edit);
                    }
                    else
                    {
                        lbl_processes.Visible = true;

                    }

                    //load and disable the data fields

                    //txt_destinationLocId.Text = cat.destinationLocId.Trim();
                    //txt_sourceLocId.Text = cat.sourceLocId.Trim();
                    //txt_supplierId.Text = cat.supplierId.Trim();
                    txt_remarks.Text = cat.remarks;
                    //dte_date.Value = cat.process_date.Value;

                    textareaFunctions(false);

                    t_adjustment_details req = new t_adjustment_details();
                    req.adju_no = ReqNo.Trim();
                    T_adjustment_detailDL tdl = new T_adjustment_detailDL();
                    List<t_adjustment_details> requests = new List<t_adjustment_details>();
                    requests = tdl.SelectT_adjustment_detailMulti(req);

                    foreach (t_adjustment_details det in requests)
                    {

                        commonFunctions.AddRow(dtx, det.item_code, findExisting.FindExisitingStock(det.item_code).Trim(), det.cost.ToString(), det.cost.ToString(), det.physical_quantity.ToString(), det.variance.ToString());
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
                        errorProvider1.SetError(txt_no, "Adjutmnt Number you have entered does not exists in the system.");
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
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ADJTransferInFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ADJTransferInSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ADJTransferInField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingTransfer(txt_no.Text.Trim());
            }
        }

        private void txt_sourceLocId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_batch_no.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_batch_no_KeyDown(object sender, KeyEventArgs e)
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
