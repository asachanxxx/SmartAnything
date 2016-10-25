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
    public partial class frm_staffusage : Form
    {

        int formMode = 0;
        string formID = "A0048";
        string formHeadertext = "Staff Usage";
        DataTable dtx = new DataTable();
        bool already = false; 

        public frm_staffusage()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_staffusage objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_staffusage getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_staffusage();

            }
            return objSingleObject;

        }

        #endregion

        private void frm_staffusage_Load(object sender, EventArgs e)
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
                            int length = Convert.ToInt32(ConfigurationManager.AppSettings["StaffUSFieldLength"]);
                            string[] strSearchField = new string[length];

                            string strSQL = ConfigurationManager.AppSettings["StaffUSSQL"].ToString();

                            for (int i = 0; i < length; i++)
                            {
                                string m;
                                m = i.ToString();
                                strSearchField[i] = ConfigurationManager.AppSettings["StaffUSField" + m + ""].ToString();
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
                                return;
                            }

                            if (commonFunctions.GetNoofItems(dataGridView1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
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
                                        t_staffUsage objt_staffUsage = new t_staffUsage();
                                        objt_staffUsage.no = txt_no.Text.Trim();
                                        objt_staffUsage.locationId = commonFunctions.GlobalLocation;
                                        objt_staffUsage.date = dte_date.Value;
                                        objt_staffUsage.refNo = txt_refNo.Text.Trim();
                                        objt_staffUsage.remarks = txt_remarks.Text.Trim();
                                        objt_staffUsage.noOfItems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                        objt_staffUsage.noOfPeaces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                        objt_staffUsage.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                        objt_staffUsage.isSaved = true;
                                        objt_staffUsage.isProcessed = false;
                                        objt_staffUsage.processDate = DateTime.Now;
                                        objt_staffUsage.processUser = "";
                                        objt_staffUsage.triggerVal = 1;
                                        objt_staffUsage.GLUpdate = false;
                                        T_staffUsageDL bal = new T_staffUsageDL();
                                        bal.Savet_staffUsageSP(objt_staffUsage, 1);

                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {

                                                //have to implement the logic. this is only saving the data to the system
                                                t_staffUsage_detail objt_staffUsage_detail = new t_staffUsage_detail();
                                                objt_staffUsage_detail.staffUsageNo = txt_no.Text.Trim();
                                                objt_staffUsage_detail.locationId = commonFunctions.GlobalLocation;
                                                objt_staffUsage_detail.Date = dte_date.Value;
                                                objt_staffUsage_detail.stockCode = drow.Cells["Product Code"].Value.ToString();
                                                objt_staffUsage_detail.description = findExisting.FindExisitingProduct(drow.Cells["Product Code"].Value.ToString());
                                                objt_staffUsage_detail.quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_staffUsage_detail.costPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_staffUsage_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                objt_staffUsage_detail.triggerVal = 1;
                                                T_staffUsage_detailDL bal22 = new T_staffUsage_detailDL();
                                                bal22.Savet_staffUsage_detailSP(objt_staffUsage_detail, 1);

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
                                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                    commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                                }

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    UpdateStock();
                                    t_staffUsage objt_trnsferNote = new t_staffUsage();
                                    objt_trnsferNote.no = txt_no.Text.Trim();

                                    T_staffUsageDL balprocess = new T_staffUsageDL();
                                    objt_trnsferNote = balprocess.Selectt_staffUsage(objt_trnsferNote);

                                    objt_trnsferNote.isProcessed = true;
                                    objt_trnsferNote.processDate = DateTime.Now;
                                    objt_trnsferNote.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_staffUsageSP(objt_trnsferNote, 3);
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
                            t_staffUsage cat = new t_staffUsage();
                            cat.no = txt_no.Text.Trim();
                            T_staffUsageDL dl = new T_staffUsageDL();
                            cat = dl.Selectt_staffUsage(cat);
                            if (cat.isProcessed == false)
                            {

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    UpdateStock();

                                    t_staffUsage objt_trnsferNote = new t_staffUsage();
                                    objt_trnsferNote.no = txt_no.Text.Trim();

                                    T_staffUsageDL balprocess = new T_staffUsageDL();
                                    objt_trnsferNote = balprocess.Selectt_staffUsage(objt_trnsferNote);

                                    objt_trnsferNote.isProcessed = true;
                                    objt_trnsferNote.processDate = DateTime.Now;
                                    objt_trnsferNote.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_staffUsageSP(objt_trnsferNote, 3);
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
                                errorProvider1.SetError(txt_no, "Wastage number you have entered already processed.");
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
                LogFile.WriteErrorLog("performButtons", "frm_purchaserequest", ex.Message.ToString());
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

        #region stockrelatedNEws

        private void UpdateStock()
        {
            try
            {
                t_staffUsage_detail trans = new t_staffUsage_detail();
                trans.staffUsageNo = txt_no.Text.Trim();
                List<t_staffUsage_detail> Transins = new List<t_staffUsage_detail>();
                Transins = new T_staffUsage_detailDL().SelectT_staffUsage_detailMulti(trans);

                foreach (t_staffUsage_detail det in Transins)
                {
                    T_Stock objt_Stock = new T_Stock();
                    objt_Stock.StockCode = det.stockCode;
                    objt_Stock.Compcode = commonFunctions.GlobalCompany;
                    objt_Stock.Locacode = commonFunctions.GlobalLocation;
                    objt_Stock = new T_StockDL().Selectt_Stock_new(objt_Stock);

                    decimal currentst = decimal.Zero;
                    currentst = commonFunctions.ToDecimal(objt_Stock.Stock.ToString()) - commonFunctions.ToDecimal(det.quantity.ToString());
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
                T_Stock stk = StockEngine.GetStockdetails(txt_code.Text);
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
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["StaffUSFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["StaffUSSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["StaffUSField" + m + ""].ToString();
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

            if (T_staffUsageDL.ExistingT_staffUsage(ReqNo.Trim()))
            {
                formMode = 3;
                //clear datagrid
                dtx.Clear();
                dataGridView1.Refresh();

                //clear error fields
                errorProvider1.Clear();

                t_staffUsage cat = new t_staffUsage();
                cat.no = ReqNo.Trim();
                T_staffUsageDL dl = new T_staffUsageDL();
                cat = dl.Selectt_staffUsage(cat);

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

                //txt_destinationLocId.Text = cat.destinationLocId.Trim();
                txt_sourceLocId.Text = cat.locationId.Trim();
                //txt_supplierId.Text = cat.supplierId.Trim();
                txt_remarks.Text = cat.remarks;
                //dte_date.Value = cat.process_date.Value;

                textareaFunctions(false);

                t_staffUsage_detail req = new t_staffUsage_detail();
                req.staffUsageNo = ReqNo.Trim();
                T_staffUsage_detailDL tdl = new T_staffUsage_detailDL();
                List<t_staffUsage_detail> requests = new List<t_staffUsage_detail>();
                requests = tdl.SelectT_staffUsage_detailMulti(req);

                foreach (t_staffUsage_detail det in requests)
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
                    errorProvider1.SetError(txt_no, "Wastage Number you have entered does not exists in the system.");
                }
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
