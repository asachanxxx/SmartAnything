/**********************************************************************
Developer   : S.G.Asanga Niranga Chandrakumara
Date        : 2015/07/24
Description : frm_purchaserequest
Module Name : SmartDistibution
**********************************************************************/

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
using System.Transactions;

namespace SmartAnything.UI
{
    public partial class frm_purchaserequest : Form
    {

        int formMode = 0;
        string formID = "A0042";
        string formHeadertext = "purchase requisition form";
        DataTable dtx = new DataTable();
        bool already = false;

        #region Loading one instance

        private static frm_purchaserequest objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_purchaserequest getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_purchaserequest();

            }
            return objSingleObject;

        }

        #endregion

        public frm_purchaserequest()
        {
            InitializeComponent();
        }

        private void frm_purchaserequest_Load(object sender, EventArgs e)
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

            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error On loading", 1);
            }
        }

        #region Detail functions

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_code.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ProductField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                //FindExisitingSupplier();
                errorProvider1.Clear();
            }

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //txt_code.Text = commonFunctions.GetProcutCode(txt_code.Text.Trim());
                    if (T_StockDL.ExistingT_Stock_Product(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {
                        if (!commonFunctions.IsExistINV(dataGridView1, txt_code.Text))
                        {
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk =  new M_ProductDL().Selectm_Product(stk);

                            txt_cost.Text = stk.CostPrice.ToString();
                            txt_selling.Text = stk.SellingPrice.ToString();
                            lbl_name.Text = stk.Namex;

                            txt_qty.Text = "0";
                            txt_qty.Focus();

                            errorProvider1.Clear();
                            already = false;
                        }
                        else
                        {
                            already = true;
                            //errorProvider1.SetError(txt_code, "Already exists");
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk = new M_ProductDL().Selectm_Product(stk);

                            txt_cost.Text = stk.CostPrice.ToString();
                            txt_selling.Text = stk.SellingPrice.ToString();
                            lbl_name.Text = stk.Namex;

                            DataGridViewRow drowx = new DataGridViewRow();
                            drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                            txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();

                            txt_qty.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txt_code, "Product you have entered not exist in the product master file");
                        commonFunctions.SetMDIStatusMessage("Product you have entered not exist in the product master file", 1);
                    }
                }
                catch (Exception ex)
                {

                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error", 2);
                }

            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
                                    txt_gross.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                    txt_pices.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                    txt_items.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                    txt_code.Focus();
                                }
                                else
                                {
                                    decimal amount = commonFunctions.ToDecimal(txt_cost.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                    txt_amt.Text = amount.ToString();
                                    commonFunctions.AddRowtogrid(dataGridView1, txt_code.Text.Trim(), txt_qty.Text.Trim(), amount.ToString());
                                    txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                    txt_gross.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                    txt_pices.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                    txt_items.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                    txt_code.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_qty, "Please enter quntity");
                                commonFunctions.SetMDIStatusMessage("Please enter quntity", 1);
                            }

                        }

                    }
                    else
                    {
                        txt_amt.Text = "0.00";

                    }
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 2);
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
        {try{
            txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_gross.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_pices.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
            txt_items.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
        }
        catch (Exception ex)
        {

            LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
            commonFunctions.SetMDIStatusMessage("Genaral Error", 2);
        }
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

                        if (ActiveControl.Name.Trim() == txt_reqno.Name.Trim())
                        {
                            int length = Convert.ToInt32(ConfigurationManager.AppSettings["PurreqFieldLength"]);
                            string[] strSearchField = new string[length];

                            string strSQL = ConfigurationManager.AppSettings["PurreqField"].ToString();

                            for (int i = 0; i < length; i++)
                            {
                                string m;
                                m = i.ToString();
                                strSearchField[i] = ConfigurationManager.AppSettings["VehicleField" + m + ""].ToString();
                            }

                            frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                            find.ShowDialog(this);
                        }

                        break;

                    case xEnums.PerformanceType.New:
                        FunctionButtonStatus(xEnums.PerformanceType.New);
                        formMode = 1;
                        txt_reqno.Text = commonFunctions.GetSerial(formID.Trim());

                        txt_reqno.Focus();
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
                            if (T_purchaseRequisitionDL.ExistingT_purchaseRequisition(txt_reqno.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_reqno, "Selected request No already exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Selected request No already exists on the system ", 1);
                                return;
                            }

                            if (!M_LocaDL.ExistingM_Loca(txt_location.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_location, "Selected location does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Selected location does not exists on the system", 1);
                                return;
                            }

                            if (!M_SupplierDL.ExistingM_Supplier(txt_Suplier.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_Suplier, "Selected supplier does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Selected supplier does not exists on the system ", 1);
                                return;
                            }

                            if (commonFunctions.GetNoofItems(dataGridView1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                commonFunctions.SetMDIStatusMessage("Please enter some items to the details grid ", 1);
                                return;
                            }

                            if (DateTime.Compare(dte_request.Value, dte_dilivary.Value) > -1)
                            {
                                errorProvider1.SetError(dte_dilivary, "Delivary date must be grater than request date");
                                commonFunctions.SetMDIStatusMessage("Delivary date must be grater than request date ", 1);
                                return;
                            }


                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                using (TransactionScope transaction = new TransactionScope())
                                {
                                    //save header data
                                    t_purchaseRequisition objt_purchaseRequisition = new t_purchaseRequisition();
                                    objt_purchaseRequisition.no = txt_reqno.Text.Trim();
                                    objt_purchaseRequisition.date = dte_request.Value;
                                    objt_purchaseRequisition.deleveryDate = dte_dilivary.Value;
                                    objt_purchaseRequisition.remarks = txt_remark.Text.Trim();
                                    objt_purchaseRequisition.processDate = DateTime.Now;
                                    objt_purchaseRequisition.processUser = "";
                                    objt_purchaseRequisition.locationId = commonFunctions.GlobalLocation;
                                    objt_purchaseRequisition.supplierId = txt_Suplier.Text.Trim();
                                    objt_purchaseRequisition.noOfItems = commonFunctions.ToDecimal(txt_items.Text.Trim());
                                    objt_purchaseRequisition.noOfPeaces = commonFunctions.ToDecimal(txt_pices.Text.Trim());
                                    objt_purchaseRequisition.grossAmount = commonFunctions.ToDecimal(txt_gross.Text.Trim());
                                    objt_purchaseRequisition.isSaved = true;
                                    objt_purchaseRequisition.isProcessed = false;
                                    objt_purchaseRequisition.triggerVal = 1;
                                    T_purchaseRequisitionDL bal = new T_purchaseRequisitionDL();
                                    bal.SaveT_purchaseRequisitionSP(objt_purchaseRequisition, 1);

                                    //save details 
                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                        {
                                            t_purchaseReq_detail objt_purchaseReq_detail = new t_purchaseReq_detail();
                                            objt_purchaseReq_detail.purchaseReqNo = txt_reqno.Text.Trim();
                                            objt_purchaseReq_detail.locationId = commonFunctions.GlobalLocation;
                                            objt_purchaseReq_detail.ReqDate = dte_request.Value;
                                            objt_purchaseReq_detail.deleveryDate = dte_dilivary.Value;
                                            objt_purchaseReq_detail.productId = drow.Cells["Product Code"].Value.ToString();
                                            objt_purchaseReq_detail.description = drow.Cells["Product Name"].Value.ToString();
                                            objt_purchaseReq_detail.quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                            objt_purchaseReq_detail.costPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                            objt_purchaseReq_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                            objt_purchaseReq_detail.release = 0;
                                            objt_purchaseReq_detail.r_value = 0;
                                            objt_purchaseReq_detail.triggerVal = 0;
                                            T_purchaseReq_detailDL bal2 = new T_purchaseReq_detailDL();
                                            bal2.SaveT_purchaseReq_detailSP(objt_purchaseReq_detail, 1);
                                        }

                                    }

                                    //increment the serial
                                    commonFunctions.IncrementSerial(formID);
                                    transaction.Complete();
                                }

                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    t_purchaseRequisition objt_purchaseRequisitionxc = new t_purchaseRequisition();
                                    objt_purchaseRequisitionxc.no = txt_reqno.Text.Trim();

                                    T_purchaseRequisitionDL bal2 = new T_purchaseRequisitionDL();
                                    objt_purchaseRequisitionxc = bal2.Selectt_purchaseRequisition(objt_purchaseRequisitionxc);
                                    objt_purchaseRequisitionxc.isProcessed = true;
                                    objt_purchaseRequisitionxc.processDate = DateTime.Now;
                                    objt_purchaseRequisitionxc.processUser = commonFunctions.Loginuser;
                                    bal2.SaveT_purchaseRequisitionSP(objt_purchaseRequisitionxc, 3);
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                }


                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();
                                //clear text fields
                                txt_Suplier.Text = "";
                                txt_suppliername.Text = "";
                                txt_location.Text = "";
                                txt_locaname.Text = "";
                                txt_remark.Text = "";

                                txt_code.Text = "";
                                txt_cost.Text = "0.00";
                                txt_selling.Text = "0.00";
                                txt_qty.Text = "0.00";
                                txt_amt.Text = "0.00";


                                txt_reqno.Enabled = true;
                                txt_Suplier.Enabled = true;
                                txt_location.Enabled = true;
                                txt_remark.Enabled = true;
                                dataGridView1.Enabled = true;

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_reqno.Text = commonFunctions.GetSerial(formID.Trim());
                                txt_location.Focus();
                            }
                        }
                        else if (formMode == 3)
                        {
                            t_purchaseRequisition cat = new t_purchaseRequisition();
                            cat.no = txt_reqno.Text.Trim();
                            T_purchaseRequisitionDL dl = new T_purchaseRequisitionDL();
                            cat = dl.Selectt_purchaseRequisition(cat);
                            if (cat.isProcessed == false)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    t_purchaseRequisition objt_purchaseRequisitionxc = new t_purchaseRequisition();
                                    objt_purchaseRequisitionxc.no = txt_reqno.Text.Trim();

                                    T_purchaseRequisitionDL bal2 = new T_purchaseRequisitionDL();
                                    objt_purchaseRequisitionxc = bal2.Selectt_purchaseRequisition(objt_purchaseRequisitionxc);
                                    objt_purchaseRequisitionxc.isProcessed = true;
                                    objt_purchaseRequisitionxc.processDate = DateTime.Now;
                                    objt_purchaseRequisitionxc.processUser = commonFunctions.Loginuser;
                                    bal2.SaveT_purchaseRequisitionSP(objt_purchaseRequisitionxc, 3);
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());



                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    txt_Suplier.Text = "";
                                    txt_suppliername.Text = "";
                                    txt_location.Text = "";
                                    txt_locaname.Text = "";
                                    txt_remark.Text = "";

                                    txt_reqno.Enabled = true;
                                    txt_Suplier.Enabled = true;
                                    txt_location.Enabled = true;
                                    txt_remark.Enabled = true;
                                    dataGridView1.Enabled = true;

                                    FunctionButtonStatus(xEnums.PerformanceType.Save);
                                    //increment the serial
                                    txt_reqno.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_location.Focus();

                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_reqno, "Request Number you have entered already processed.");
                                commonFunctions.SetMDIStatusMessage("Request Number you have entered already processed.", 1);
                            }




                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_reqno.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Default);
                        errorProvider1.Clear();
                        txt_Suplier.Enabled = true;
                        txt_location.Enabled = true;
                        txt_remark.Enabled = true;
                        dataGridView1.Enabled = true;

                        dtx.Clear();
                        dataGridView1.Refresh();
                        txt_Suplier.Text = "";
                        txt_location.Text = "";
                        txt_remark.Text = "";

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

        private void txt_location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_location.Name.Trim())
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

                FindExisitingLoca(txt_location.Text.Trim());
            }

            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingLoca(txt_location.Text.Trim());
                txt_Suplier.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_Suplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_Suplier.Name.Trim())
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

                FindExisitingSupplier();
                errorProvider1.Clear();
            }
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingSupplier();
                dte_request.Focus();
            }
        }

        private void FindExisitingSupplier()
        {
            try{
            if (M_SupplierDL.ExistingM_Supplier(txt_Suplier.Text.Trim()))
            {
                M_Suppliers cat = new M_Suppliers();
                cat.SupID = txt_Suplier.Text.Trim();
                M_SupplierDL dl = new M_SupplierDL();
                cat = dl.Selectm_Supplier(cat);
                txt_Suplier.Text = cat.SupID.Trim();
                txt_suppliername.Text = cat.suppName.Trim();
            }
            else
            {
                txt_suppliername.Text = "<Supplier Not Exists.>";
            }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }
        }

        private void FindExisitingLoca(string locacode)
        {
            try{
            if (M_LocaDL.ExistingM_Loca(locacode.Trim()))
            {
                M_Loca cat = new M_Loca();
                cat.Locacode = locacode.Trim();
                M_LocaDL dl = new M_LocaDL();
                cat = dl.Selectm_Loca(cat);
                txt_location.Text = cat.Locacode.Trim();
                txt_locaname.Text = cat.Locaname;
            }
            else
            {
                txt_locaname.Text = "<Location Not Exists.>";
            }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }
        }

        private void FindExisitingRequests(string ReqNo)
        {
            try{
            if (T_purchaseRequisitionDL.ExistingT_purchaseRequisition(ReqNo.Trim()))
            {
                formMode = 3;
                //clear datagrid
                dtx.Clear();
                dataGridView1.Refresh();

                //clear error fields
                errorProvider1.Clear();

                t_purchaseRequisition cat = new t_purchaseRequisition();
                cat.no = ReqNo.Trim();
                T_purchaseRequisitionDL dl = new T_purchaseRequisitionDL();
                cat = dl.Selectt_purchaseRequisition(cat);

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

                txt_location.Text = cat.locationId.Trim();
                txt_Suplier.Text = cat.supplierId.Trim();
                txt_remark.Text = cat.remarks;

                txt_Suplier.Enabled = false;
                txt_location.Enabled = false;
                txt_remark.Enabled = false;
                dataGridView1.Enabled = false;

                t_purchaseReq_detail req = new t_purchaseReq_detail();
                req.purchaseReqNo = ReqNo.Trim();
                T_purchaseReq_detailDL tdl = new T_purchaseReq_detailDL();
                List<t_purchaseReq_detail> requests = new List<t_purchaseReq_detail>();
                requests = tdl.Selectt_purchaseReq_detailMulti(req);

                foreach (t_purchaseReq_detail det in requests)
                {
                    
                    commonFunctions.AddRow(dtx, det.productId, det.description, det.costPrice.ToString(), M_ProductDL.GetSellingPrice(det.productId).ToString(), det.quantity.ToString(), det.amount.ToString());
                }

                txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                txt_gross.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                txt_pices.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                txt_items.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();

                //txt_locaname.Text = cat.Locaname;
            }
            else
            {
                if (formMode != 1)
                {
                    errorProvider1.SetError(txt_reqno, "Request Number you have entered does not exists in the system.");
                }
            }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtx.Rows.Clear();
            dataGridView1.Refresh();
            MessageBox.Show(DateTime.Compare(dte_request.Value, dte_dilivary.Value).ToString());
        }

        private void txt_reqno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_location.Focus();
                FindExisitingRequests(txt_reqno.Text.Trim());
            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_reqno.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["PurreqFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["PurreqSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["PurreqField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingRequests(txt_reqno.Text.Trim());
            }

        }

        private void dte_request_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_dilivary.Focus();
            }
        }

        private void dte_dilivary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_remark.Focus();
            }
        }

        private void txt_remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
            }
        }


    }
}
