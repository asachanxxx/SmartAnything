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
    public partial class frm_returns : Form
    {
        int formMode = 0;
        string formID = "A0028";
        string formHeadertext = "purchase Returns";
        DataTable dtx = new DataTable();
        bool already = false;

        #region Loading one instance

        private static frm_returns objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_returns getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_returns();

            }
            return objSingleObject;

        }

        #endregion

        public frm_returns()
        {
            InitializeComponent();
        }

        private void frm_returns_Load(object sender, EventArgs e)
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

                txt_locationId.Text = commonFunctions.GlobalLocation;
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_locationId.Text.Trim());
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }

        }

        #region textareaFunctions

        private void textareaFunctions(bool stype)
        {
            if (stype == true)
            {
                txt_supplierId.Text = "";
                txt_supplierId_name.Text = "";
                txt_remarks.Text = "";
                dte_date.Value = DateTime.Now;

                txt_code.Text = "";
                txt_cost.Text = "0.00";
                txt_selling.Text = "0.00";
                txt_qty.Text = "0.00";
                txt_amt.Text = "0.00";


                txt_supplierId.Enabled = true;
                txt_remarks.Enabled = true;
                txt_locationId.Enabled = true;
                dte_date.Enabled = true;

                dataGridView1.Enabled = true;
            }
            else
            {
                txt_supplierId.Enabled = false;
                txt_remarks.Enabled = false;
                txt_locationId.Enabled = false;
                dte_date.Enabled = false;
                dataGridView1.Enabled = false;

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

                    string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString() + " WHERE T_Stock.Locacode = '" + txt_locationId.Text.Trim() + "'";

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

                        txt_locationId.Text = commonFunctions.GlobalLocation;
                        txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_locationId.Text.Trim());

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
                            if (!M_LocaDL.ExistingM_Loca(txt_locationId.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_locationId, "Location does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Location does not exists on the system", 1);
                                return;
                            }

                            if (!M_SupplierDL.ExistingM_Supplier(txt_supplierId.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_supplierId, "Selected supplier does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Selected supplier does not exists on the system ", 1);
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
                                        t_return objt_return = new t_return();
                                        objt_return.no = txt_no.Text.Trim();
                                        objt_return.date = dte_date.Value;
                                        objt_return.refNo = txt_refNo.Text.Trim();
                                        objt_return.remarks = txt_remarks.Text.Trim();
                                        objt_return.processDate = DateTime.Now;
                                        objt_return.processUser = "";
                                        objt_return.locationId = commonFunctions.GlobalLocation;
                                        objt_return.supplierId = txt_supplierId.Text.Trim();
                                        objt_return.noOfItems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                        objt_return.noOfPeaces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                        objt_return.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                        objt_return.isSaved = true;
                                        objt_return.isProcessed = false;
                                        objt_return.GLUpdate = false;
                                        objt_return.triggerVal = 1;
                                        T_returnDL bal = new T_returnDL();
                                        bal.Savet_returnSP(objt_return, 1);


                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                t_return_detail objt_return_detail = new t_return_detail();
                                                objt_return_detail.returnNo = txt_no.Text.Trim();
                                                objt_return_detail.locationId = commonFunctions.GlobalLocation;
                                                objt_return_detail.stockCode = drow.Cells["Product Code"].Value.ToString(); //txt_stockCode.Text.Trim();
                                                objt_return_detail.productId =  StockEngine.GetProductCode(drow.Cells["Product Code"].Value.ToString());
                                                objt_return_detail.quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_return_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                objt_return_detail.costPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_return_detail.sellingPrice = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                                objt_return_detail.triggerVal = 1;
                                                T_return_detailDL bal2 = new T_return_detailDL();
                                                bal2.Savet_return_detailSP(objt_return_detail, 1);
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
                                    LogFile.WriteErrorLog("Save Transactions", "PO", ex.Message);
                                }

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    UpdateStock();
                                    t_return objt_purchaseOrder2 = new t_return();
                                    objt_purchaseOrder2.no = txt_no.Text.Trim();

                                    T_returnDL balprocess = new T_returnDL();
                                    objt_purchaseOrder2 = balprocess.Selectt_return(objt_purchaseOrder2);

                                    objt_purchaseOrder2.isProcessed = true;
                                    objt_purchaseOrder2.processDate = DateTime.Now;
                                    objt_purchaseOrder2.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_returnSP(objt_purchaseOrder2, 3);
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
                                txt_supplierId.Focus();
                            }
                        }
                        else if (formMode == 3)
                        {
                            t_return cat = new t_return();
                            cat.no = txt_no.Text.Trim();
                            T_returnDL dl = new T_returnDL();
                            cat = dl.Selectt_return(cat);
                            if (cat.isProcessed == false)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    UpdateStock();

                                    t_return objt_purchaseOrder2 = new t_return();
                                    objt_purchaseOrder2.no = txt_no.Text.Trim();

                                    T_returnDL balprocess = new T_returnDL();
                                    objt_purchaseOrder2 = balprocess.Selectt_return(objt_purchaseOrder2);

                                    objt_purchaseOrder2.isProcessed = true;
                                    objt_purchaseOrder2.processDate = DateTime.Now;
                                    objt_purchaseOrder2.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_returnSP(objt_purchaseOrder2, 3);
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    textareaFunctions(true);
                                    FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    txt_no.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_supplierId.Focus();

                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_no, "Request Number you have entered already processed.");
                                commonFunctions.SetMDIStatusMessage("Request Number you have entered already processed.", 1);
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

                        txt_supplierId.Text = "";
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
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
            }
        }

        #endregion


        #region stockrelatedNEws

        private void UpdateStock()
        {
            try
            {
                t_return_detail trans = new t_return_detail();
                trans.returnNo = txt_no.Text.Trim();
                List<t_return_detail> Transins = new List<t_return_detail>();
                Transins = new T_return_detailDL().SelectT_return_detailMulti(trans);

                foreach (t_return_detail det in Transins)
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

        private void txt_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingpo(txt_no.Text.Trim());
                txt_locationId.Focus();
                errorProvider1.Clear();
            }


            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_no.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ReturnFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ReturnSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ReturnField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingpo(txt_no.Text.Trim());
            }

        }
        private void txt_locationId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_supplierId.Focus();
                errorProvider1.Clear();
            }

        }

        private void txt_supplierId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_supplierId_name.Text = findExisting.FindExisitingSupplier(txt_supplierId.Text);
                dte_date.Focus();
                errorProvider1.Clear();
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_supplierId.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["SupplierFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["SupplierSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["SupplierField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }


            }
        }

        private void dte_date_KeyDown(object sender, KeyEventArgs e)
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

        #region FindExisitingpo

        private void FindExisitingpo(string ReqNo)
        {
            try
            {
                if (T_returnDL.ExistingT_return(ReqNo.Trim()))
                {
                    formMode = 3;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                    t_return cat = new t_return();
                    cat.no = ReqNo.Trim();
                    T_returnDL dl = new T_returnDL();
                    cat = dl.Selectt_return(cat);

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

                    txt_locationId.Text = cat.locationId.Trim();
                    txt_supplierId.Text = cat.supplierId.Trim();
                    txt_remarks.Text = cat.remarks;
                    dte_date.Value = cat.date.Value;

                    textareaFunctions(false);

                    t_return_detail req = new t_return_detail();
                    req.returnNo = ReqNo.Trim();
                    T_return_detailDL tdl = new T_return_detailDL();
                    List<t_return_detail> requests = new List<t_return_detail>();
                    requests = tdl.SelectT_return_detailMulti(req);

                    foreach (t_return_detail det in requests)
                    {

                        commonFunctions.AddRow(dtx, det.productId, findExisting.FindExisitingStock(det.stockCode).Trim(), det.costPrice.ToString(), det.sellingPrice.ToString(), det.quantity.ToString(), det.amount.ToString());
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
                        errorProvider1.SetError(txt_no, "Request Number you have entered does not exists in the system.");
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

        private void txt_supplierId_TextChanged(object sender, EventArgs e)
        {
            txt_supplierId_name.Text = findExisting.FindExisitingSupplier(txt_supplierId.Text);
        }

    }
}
