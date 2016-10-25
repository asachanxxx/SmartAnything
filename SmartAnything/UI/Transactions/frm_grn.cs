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
    public partial class frm_grn : Form
    {
        int formMode = 0;
        string formID = "A0025";
        string formHeadertext = "Goods receiving note";
        DataTable dtx = new DataTable();
        bool already = false;
        string PriceLvlIndex = "";

        #region Loading one instance

        private static frm_grn objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_grn getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_grn();

            }
            return objSingleObject;

        }

        #endregion

        public frm_grn()
        {
            InitializeComponent();
        }

        private void frm_grn_Load(object sender, EventArgs e)
        {
            try{
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            FunctionButtonStatus(xEnums.PerformanceType.Default);
            commonFunctions.HandleTextBoxesInTransactions(panel3);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);


            dtx = commonFunctions.CreateDatatableGRN(1);
            dataGridView1.DataSource = dtx;
            commonFunctions.FormatDataGrid(dataGridView1);
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[8].Width = 80;
            dataGridView1.Columns[3].Width = 50;
            txt_code.Focus();
            dataGridView1.AllowUserToAddRows = false;

            txt_locationId.Text = commonFunctions.GlobalLocation;
            txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_locationId.Text.Trim());
            txt_poNo.BackColor = Color.FromArgb(192, 192, 255);

            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }


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
                        if (ActiveControl.Name.Trim() == txt_grnno.Name.Trim())
                        {
                            int length = Convert.ToInt32(ConfigurationManager.AppSettings["GrnRecallFieldLength"]);
                            string[] strSearchField = new string[length];

                            string strSQL = ConfigurationManager.AppSettings["GrnRecallSQL"].ToString();

                            for (int i = 0; i < length; i++)
                            {
                                string m;
                                m = i.ToString();
                                strSearchField[i] = ConfigurationManager.AppSettings["GrnRecallField" + m + ""].ToString();
                            }

                            frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                            find.ShowDialog(this);
                        }

                        break;

                    case xEnums.PerformanceType.New:
                        FunctionButtonStatus(xEnums.PerformanceType.New);
                        formMode = 1;
                        txt_grnno.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_grnno.Focus();

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
                        if (formMode == 1 || formMode == 3)
                        {
                           
                            if (!M_SupplierDL.ExistingM_Supplier(txt_supplierId.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_supplierId, "Selected supplier does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Selected supplier does not exists on the system .", 1);
                                return;
                            }

                            if (commonFunctions.GetNoofItems(dataGridView1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                commonFunctions.SetMDIStatusMessage("Please enter some items to the details grid.", 1);
                                return;
                            }

                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                t_grn objt_grn = new t_grn();
                                objt_grn.no = txt_grnno.Text.Trim();
                                objt_grn = new T_grnDL().Selectt_grn(objt_grn);
                                bool alread = true;
                                if (objt_grn == null) {
                                    objt_grn = new t_grn();
                                    alread = false;
                                }

                                using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                {
                                   
                                    objt_grn.no = txt_grnno.Text.Trim();
                                    objt_grn.locationId = commonFunctions.GlobalLocation;
                                    objt_grn.poNo = txt_poNo.Text.Trim();
                                    objt_grn.date = dte_date.Value;
                                    objt_grn.refNo = txt_refNo.Text.Trim();
                                    objt_grn.expireDate = dte_expireDate.Value;
                                    objt_grn.supplierId = txt_supplierId.Text.Trim();
                                    objt_grn.supInvoiceNo = txt_supInvoiceNo.Text.Trim();
                                    objt_grn.supInvoiceDate = dte_supInvoiceDate.Value;
                                    objt_grn.supInvoiceValue = decimal.Zero; //txt_supInvoiceValue.Text.Trim();
                                    objt_grn.supDoNo = txt_supDoNo.Text.Trim();
                                    objt_grn.supDoDate = dte_supDoDate.Value;
                                    objt_grn.remarks = txt_remarks.Text.Trim();
                                    objt_grn.noOfItems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                    objt_grn.noOfPieces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                    objt_grn.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                    objt_grn.isSaved = true;
                                    objt_grn.isProcessed = false;
                                    objt_grn.processDate = DateTime.Now;
                                    objt_grn.processUser = "";
                                    objt_grn.netDiscount = commonFunctions.ToDecimal(txt_totdiscount.Text.Trim());
                                    objt_grn.additions = commonFunctions.ToDecimal(txt_additions.Text.Trim());
                                    objt_grn.deductions = commonFunctions.ToDecimal(txt_deductions.Text.Trim());
                                    objt_grn.netAmount = commonFunctions.ToDecimal(txt_net.Text.Trim());
                                    objt_grn.isAllReturned = false;//txt_isAllReturned.Text.Trim();
                                    objt_grn.GLUpdate = false;
                                    objt_grn.triggerVal = 1;


                                    //save details 
                                    if (alread == true)
                                    {
                                        List<t_grn_detail> dets = new List<t_grn_detail>();
                                        t_grn_detail pox = new t_grn_detail();
                                        pox.grnNo = txt_grnno.Text.Trim();
                                        dets = new T_grn_detailDL().SelectT_grn_detailMulti(pox);
                                        foreach (t_grn_detail det in dets)
                                        {
                                            new T_grn_detailDL().Savet_grn_detailSP(det, 4);
                                        }
                                    }
                                    List<t_grn_detail> grnDets = new List<t_grn_detail>();
                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                        {
                                            t_grn_detail objt_grn_detail = new t_grn_detail();
                                            objt_grn_detail.grnNo = txt_grnno.Text.Trim();
                                            objt_grn_detail.locationId = commonFunctions.GlobalLocation;
                                            objt_grn_detail.productId = drow.Cells["Product Code"].Value.ToString();
                                            objt_grn_detail.stock = decimal.Zero;//txt_stock.Text.Trim();
                                            objt_grn_detail.tax = decimal.Zero;//txt_tax.Text.Trim();
                                            objt_grn_detail.priceLevel = txt_pricelevel.Text.Trim();
                                            objt_grn_detail.quantity = commonFunctions.ToInt(drow.Cells["Quntity"].Value.ToString());
                                            objt_grn_detail.freeQty = commonFunctions.ToInt(drow.Cells["Free Quntity"].Value.ToString());
                                            objt_grn_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                            objt_grn_detail.disPerc = commonFunctions.ToDecimal(drow.Cells["Discount%"].Value.ToString());// txt_disPerc.Text.Trim();
                                            objt_grn_detail.disAmount = decimal.Zero;// txt_disAmount.Text.Trim();
                                            objt_grn_detail.batchNo = "";//txt_batchNo.Text.Trim();
                                            objt_grn_detail.expDate = DateTime.Now;//txt_expDate.Text.Trim();
                                            objt_grn_detail.stockCode = drow.Cells["Product Code"].Value.ToString();                                    
                                            objt_grn_detail.costPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                            objt_grn_detail.sellingPrice = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                            objt_grn_detail.returnedQuantity = 1;//txt_returnedQuantity.Text.Trim();
                                            objt_grn_detail.remainingQuantity = 1;//txt_remainingQuantity.Text.Trim();
                                            objt_grn_detail.triggerVal = 1;//txt_triggerVal.Text.Trim();
                                            
                                            if (M_ProductDL.GetMaintainStockLot(drow.Cells["Product Code"].Value.ToString()))
                                            {
                                                if (objt_grn_detail.priceLevel.ToString() == "")
                                                    PriceLvlIndex = "1";
                                                else
                                                    PriceLvlIndex = (objt_grn_detail.priceLevel.ToString());
                                                objt_grn_detail.stockCode = drow.Cells["Product Code"].Value.ToString().Trim() + "-" + PriceLvlIndex;
                                            }
                                            else
                                            {
                                                int maxID = Convert.ToInt32(M_ProductDL.getMaxStockCode(objt_grn_detail.productId.ToString(), commonFunctions.GlobalLocation));
                                                maxID++;
                                                objt_grn_detail.stockCode = drow.Cells["Product Code"].Value.ToString().Trim() + "-" + maxID.ToString();
                                            }

                                            grnDets.Add(objt_grn_detail);
                                        }
                                    }
                                    //save the grn 
                                    if (new T_grnDL().Savet_grnSP(objt_grn, grnDets, formMode, formID))
                                    {
                                        commonFunctions.SetMDIStatusMessage("GRN saved successfully.", 2);
                                        commonFunctions.IncrementSerial(formID);
                                        transaction.Complete();
                                    }

                                
                                }
                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    //UpdateStock();
                                    StockUpdate();

                                        t_grn objt_grn_Process = new t_grn();
                                        objt_grn_Process.no = txt_grnno.Text.Trim();
                                        objt_grn_Process = new T_grnDL().Selectt_grn(objt_grn_Process);

                                        objt_grn_Process.isProcessed = true;
                                        objt_grn_Process.processDate = DateTime.Now;
                                        objt_grn_Process.processUser = commonFunctions.Loginuser;
                                        new T_grnDL().Savet_grnSP_OneInstance(objt_grn_Process, 3);
                                 

                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                }
                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();
                                //clear text fields
                                textareaFunctions(true);

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_grnno.Text = commonFunctions.GetSerial(formID.Trim());
                                txt_supplierId.Focus();
                            }


                        }
                        else if (formMode == 3)
                        {
                            t_grn objt_grn = new t_grn();
                            objt_grn.no = txt_grnno.Text.Trim();
                            objt_grn = new T_grnDL().Selectt_grn(objt_grn);
                            if (objt_grn.isProcessed == false)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                    {
                                        //save header data

                                        objt_grn.locationId = txt_locationId.Text.Trim();
                                        objt_grn.poNo = txt_poNo.Text.Trim();
                                        objt_grn.date = dte_date.Value;
                                        objt_grn.refNo = txt_refNo.Text.Trim();
                                        objt_grn.expireDate = dte_expireDate.Value;
                                        objt_grn.supplierId = txt_supplierId.Text.Trim();
                                        objt_grn.supInvoiceNo = txt_supInvoiceNo.Text.Trim();
                                        objt_grn.supInvoiceDate = dte_supInvoiceDate.Value;
                                        objt_grn.supInvoiceValue = decimal.Zero; //txt_supInvoiceValue.Text.Trim();
                                        objt_grn.supDoNo = txt_supDoNo.Text.Trim();
                                        objt_grn.supDoDate = dte_supDoDate.Value;
                                        objt_grn.remarks = txt_remarks.Text.Trim();
                                        objt_grn.noOfItems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                        objt_grn.noOfPieces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                        objt_grn.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                        objt_grn.isSaved = true;
                                        objt_grn.isProcessed = false;
                                        objt_grn.processDate = DateTime.Now;
                                        objt_grn.processUser = "";
                                        objt_grn.netDiscount = commonFunctions.ToDecimal(txt_totdiscount.Text.Trim());
                                        objt_grn.additions = commonFunctions.ToDecimal(txt_additions.Text.Trim());
                                        objt_grn.deductions = commonFunctions.ToDecimal(txt_deductions.Text.Trim());
                                        objt_grn.netAmount = commonFunctions.ToDecimal(txt_net.Text.Trim());
                                        objt_grn.isAllReturned = false;//txt_isAllReturned.Text.Trim();
                                        objt_grn.GLUpdate = false;
                                        objt_grn.triggerVal = 1;
                                        //save details 


                                        List<t_grn_detail> dets = new List<t_grn_detail>();
                                        t_grn_detail pox = new t_grn_detail();
                                        pox.grnNo = txt_grnno.Text.Trim();
                                        dets = new T_grn_detailDL().SelectT_grn_detailMulti(pox);
                                        foreach (t_grn_detail det in dets)
                                        {
                                            new T_grn_detailDL().Savet_grn_detailSP(det, 4);
                                        }

                                        List<t_grn_detail> grnDets = new List<t_grn_detail>();
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                t_grn_detail objt_grn_detail = new t_grn_detail();
                                                objt_grn_detail.grnNo = txt_grnno.Text.Trim();
                                                objt_grn_detail.locationId = txt_locationId.Text.Trim();
                                                objt_grn_detail.productId = drow.Cells["Product Code"].Value.ToString();
                                                objt_grn_detail.stockCode = drow.Cells["Product Code"].Value.ToString();     
                                                objt_grn_detail.stock = decimal.Zero;//txt_stock.Text.Trim();
                                                objt_grn_detail.tax = decimal.Zero;//txt_tax.Text.Trim();
                                                objt_grn_detail.priceLevel = txt_pricelevel.Text.Trim();
                                                objt_grn_detail.quantity = commonFunctions.ToInt(drow.Cells["Quntity"].Value.ToString());
                                                objt_grn_detail.freeQty = commonFunctions.ToInt(drow.Cells["Free Quntity"].Value.ToString());
                                                objt_grn_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                objt_grn_detail.disPerc = commonFunctions.ToDecimal(drow.Cells["Discount%"].Value.ToString());// txt_disPerc.Text.Trim();
                                                objt_grn_detail.disAmount = decimal.Zero;// txt_disAmount.Text.Trim();
                                                objt_grn_detail.batchNo = "";//txt_batchNo.Text.Trim();
                                                objt_grn_detail.expDate = DateTime.Now;//txt_expDate.Text.Trim();
                                                objt_grn_detail.costPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_grn_detail.sellingPrice = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                                objt_grn_detail.returnedQuantity = 1;//txt_returnedQuantity.Text.Trim();
                                                objt_grn_detail.remainingQuantity = 1;//txt_remainingQuantity.Text.Trim();
                                                objt_grn_detail.triggerVal = 1;//txt_triggerVal.Text.Trim();
                                                grnDets.Add(objt_grn_detail);
                                            }
                                        }
                                        //save the grn 
                                        if (new T_grnDL().Savet_grnSP(objt_grn, grnDets, 1, formID))
                                        {
                                            commonFunctions.SetMDIStatusMessage("GRN saved successfully.", 2);
                                            commonFunctions.IncrementSerial(formID);
                                            transaction.Complete();
                                        }
                                    }
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());

                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {

                                        UpdateStock();

                                        t_grn objt_grn_Process = new t_grn();
                                        objt_grn_Process.no = txt_grnno.Text.Trim();
                                        objt_grn_Process = new T_grnDL().Selectt_grn(objt_grn_Process);

                                        objt_grn_Process.isProcessed = true;
                                        objt_grn_Process.processDate = DateTime.Now;
                                        objt_grn_Process.processUser = commonFunctions.Loginuser;
                                        new T_grnDL().Savet_grnSP_OneInstance(objt_grn_Process, 3);

                                        if (txt_poNo.Text.Trim() != "")
                                        {
                                            t_purchaseOrder req = new t_purchaseOrder();
                                            req.no = txt_poNo.Text.Trim();
                                            req = new T_purchaseOrderDL().Selectt_purchaseOrder(req);
                                            req.triggerVal = 2;
                                            new T_purchaseOrderDL().Savet_purchaseOrderSP(req, 3);

                                        }


                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                    }
                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    textareaFunctions(true);

                                    FunctionButtonStatus(xEnums.PerformanceType.Save);
                                    //increment the serial
                                    txt_grnno.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_supplierId.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_grnno, "GRN Number you have entered already processed.");
                                commonFunctions.SetMDIStatusMessage("GRN Number you have entered already processed.", 1);
                            }
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_grnno.Enabled = true;
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


        public void StockUpdate()
        {
            try
            {
                T_Stock objStock = new T_Stock();
                t_grn_detail detg = new t_grn_detail();
                detg.grnNo = txt_grnno.Text.Trim();
                List<t_grn_detail> lstGRNDetail = new List<t_grn_detail>();
                lstGRNDetail = new T_grn_detailDL().SelectT_grn_detailMulti(detg);

                for (int i = 0; i < lstGRNDetail.Count; i++)
                {
                    //objStock.strStockCode=lstGRNDetail[i].strStockCode;
                    //intAvailableStock = (objStockBL.getExistingStockDetails(objStock)).intStock;
                    M_Products pro = new M_Products();
                    pro.IDX = lstGRNDetail[i].productId;
                    pro = new M_ProductDL().Selectm_Product(pro);

                    objStock.StockCode = lstGRNDetail[i].stockCode;
                    objStock.Locacode = commonFunctions.GlobalLocation;
                    objStock.ProductId = lstGRNDetail[i].productId;
                    objStock.Suppid = pro.Suplier;
                    objStock.Compcode = commonFunctions.GlobalCompany;
                    objStock.OpnStock = decimal.Zero;
                    objStock.InitialStock = decimal.Zero;
                    objStock.ReservedStock = decimal.Zero;
                    objStock.CostPrice = lstGRNDetail[i].costPrice;
                    objStock.SellingPrice = lstGRNDetail[i].sellingPrice;
                    objStock.WholeSalePrice = lstGRNDetail[i].sellingPrice;
                    objStock.MrpPrice = lstGRNDetail[i].sellingPrice;
                    objStock.CompanyPrice = lstGRNDetail[i].sellingPrice;
                    objStock.InitialCost = lstGRNDetail[i].costPrice;
                    objStock.Descr = pro.Namex;
                    objStock.FixedGP = decimal.Zero;
                    objStock.EXPDate = DateTime.Now;
                    objStock.Usercode = commonFunctions.Loginuser;
                    objStock.DateCr = DateTime.Now;
                    objStock.SellingPrice = lstGRNDetail[i].sellingPrice;
                    objStock.CostPrice = lstGRNDetail[i].costPrice;

                    if (T_StockDL.ExistingT_Stock_new(objStock.StockCode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation) == false)
                    {
                        objStock.AvgCost = lstGRNDetail[i].costPrice;
                        objStock.Stock = lstGRNDetail[i].quantity + lstGRNDetail[i].freeQty;
                        new T_StockDL().SaveT_StockSP(objStock, 1, 1);
                    }
                    else
                    {
                        objStock = new T_StockDL().Selectt_Stock_ByStockCode(objStock);
                        decimal intStock = decimal.Parse(objStock.Stock.ToString());
                        decimal decCostPrice = decimal.Parse(objStock.CostPrice.ToString());
                        decimal decPresentCost = intStock * decCostPrice;
                        decimal decNewCost = lstGRNDetail[i].costPrice.Value * lstGRNDetail[i].quantity.Value;
                        decimal intAllStock = intStock + lstGRNDetail[i].quantity.Value;
                        objStock.AvgCost = (decPresentCost + decNewCost) / intAllStock;
                        objStock.Stock += lstGRNDetail[i].quantity + lstGRNDetail[i].freeQty;
                        new T_StockDL().SaveT_StockSP(objStock,3, 1);
                    }
                }

            }
            catch (Exception ex)
            {

                // Globals.generateErrorMsg(ex.Message.ToString(), "StockUpdate");
                LogFile.WriteErrorLog("StockUpdate", "frmT_GReceivedNote", ex.Message.ToString());
                Globals.generateCommonErrorMsg();

            }

        }

        private void UpdateStock()
        {

            //using (TransactionScope scope = new TransactionScope())
            //{
                t_grn_detail detg = new t_grn_detail();
                detg.grnNo = txt_grnno.Text.Trim();
                List<t_grn_detail> grndets = new List<t_grn_detail>();
                grndets = new T_grn_detailDL().SelectT_grn_detailMulti(detg);

                foreach (t_grn_detail det in grndets)
                {
                    T_Stock objt_Stock = new T_Stock();
                 

                    M_Products pro = new M_Products();
                    pro.IDX = det.productId;
                    pro = new M_ProductDL().Selectm_Product(pro);
                    /*
                     A LOGIC HAS TO IMPLEMENT HERE IS,
                     * IF (commonFunctions.Maintainstocklot == true)
                     * THEN HAS TO DO A LOT OF THINGS
                     * IF IT WAS FALSE
                     * THEN ... THERE IS ONE STOCK CODE FOR EVERY PRODUCT AND 
                     * AVARAGE COST METHOD MUST IMPLEMENT
                 
                     */

                
                    string stockcode = "";
                    if (pro.IsMaintainStockLot == false)
                    {
                        int x = 1;
                        stockcode = commonFunctions.GetStockCode(det.productId, x.ToString("00"));
                        if (T_StockDL.ExistingT_Stock_new(stockcode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                        {
                            objt_Stock.StockCode = stockcode;
                            objt_Stock.Compcode = commonFunctions.GlobalCompany;
                            objt_Stock.Locacode = commonFunctions.GlobalLocation;
                            objt_Stock = new T_StockDL().Selectt_Stock_ByStockCode(objt_Stock);

                            //calculating avarage cost;
                            decimal commingtot = det.costPrice.Value * det.quantity.Value;
                            objt_Stock.AvgCost = GetAvaragecost(objt_Stock.Stock.Value, objt_Stock.CostPrice.Value, commingtot, det.quantity.Value);

                            // add entry to products avarage cost
                            pro.CostPrice = objt_Stock.AvgCost;

                            objt_Stock.Stock += det.quantity;
                            objt_Stock.OpnStock = decimal.Zero;
                            objt_Stock.InitialStock = decimal.Zero;
                            objt_Stock.ReservedStock = decimal.Zero;
                            objt_Stock.CostPrice = det.costPrice;
                            objt_Stock.SellingPrice = det.sellingPrice;
                            objt_Stock.WholeSalePrice = det.sellingPrice;
                            objt_Stock.MrpPrice = det.sellingPrice;
                            objt_Stock.CompanyPrice = det.sellingPrice;
                            objt_Stock.InitialCost = det.costPrice;
                            objt_Stock.Descr = pro.Namex;
                            objt_Stock.FixedGP = decimal.Zero;
                            objt_Stock.EXPDate = DateTime.Now;
                            objt_Stock.Usercode = commonFunctions.Loginuser;
                            objt_Stock.DateCr = DateTime.Now;
                            T_StockDL bal = new T_StockDL();
                            bal.SaveT_StockSP(objt_Stock, 3, 1);
                          
                        }
                        else
                        {
                           
                            objt_Stock.StockCode = stockcode;
                            objt_Stock.Compcode = commonFunctions.GlobalCompany;
                            objt_Stock.Locacode = commonFunctions.GlobalLocation;
                            objt_Stock.Suppid = pro.Suplier;
                            objt_Stock.ProductId = det.productId;
                            objt_Stock.Stock = det.quantity;
                            objt_Stock.OpnStock = decimal.Zero;
                            objt_Stock.InitialStock = decimal.Zero;
                            objt_Stock.ReservedStock = decimal.Zero;
                            objt_Stock.CostPrice = det.costPrice;
                            objt_Stock.SellingPrice = det.sellingPrice;
                            objt_Stock.WholeSalePrice = det.sellingPrice;
                            objt_Stock.MrpPrice = det.sellingPrice;
                            objt_Stock.CompanyPrice = det.sellingPrice;

                            //calculating avarage cost;
                            decimal commingtot = det.costPrice.Value * det.quantity.Value;
                            objt_Stock.AvgCost = GetAvaragecost(objt_Stock.Stock.Value, objt_Stock.CostPrice.Value, commingtot, det.quantity.Value);

                            // add entry to products avarage cost
                            pro.CostPrice = objt_Stock.AvgCost;

                            objt_Stock.InitialCost = det.costPrice;
                            objt_Stock.Descr = pro.Namex;
                            objt_Stock.FixedGP = decimal.Zero;
                            objt_Stock.SIH = decimal.Zero;
                            objt_Stock.EXPDate = DateTime.Now;
                            objt_Stock.Usercode = commonFunctions.Loginuser;
                            objt_Stock.DateCr = DateTime.Now;
                            T_StockDL bal = new T_StockDL();
                            bal.SaveT_StockSP(objt_Stock, 1, 1);
                        }
                    }
                    else
                    {
                        string laststockcode = T_StockDL.GetLastStockCode(pro.IDX, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation);
                        string xxx = laststockcode.Trim().Substring(laststockcode.Trim().IndexOf('-') + 1, 4);
                        int x = commonFunctions.ToInt(xxx);
                        x += 1;
                        stockcode = commonFunctions.GetStockCode(pro.IDX, x.ToString("00"));
                        objt_Stock.StockCode = stockcode;

                        //update product cost price
                        pro.CostPrice = det.costPrice;

                        objt_Stock.Compcode = commonFunctions.GlobalCompany;
                        objt_Stock.Locacode = commonFunctions.GlobalLocation;
                        objt_Stock.Suppid = pro.Suplier;
                        objt_Stock.ProductId = det.productId;
                        objt_Stock.Stock = det.quantity;
                        objt_Stock.OpnStock = decimal.Zero;
                        objt_Stock.InitialStock = decimal.Zero;
                        objt_Stock.ReservedStock = decimal.Zero;
                        objt_Stock.CostPrice = det.costPrice;
                        objt_Stock.SellingPrice = det.sellingPrice;
                        objt_Stock.WholeSalePrice = det.sellingPrice;
                        objt_Stock.MrpPrice = det.sellingPrice;
                        objt_Stock.CompanyPrice = det.sellingPrice;
                        objt_Stock.AvgCost = det.costPrice;
                        objt_Stock.InitialCost = det.costPrice;
                        objt_Stock.Descr = pro.Namex;
                        objt_Stock.FixedGP = decimal.Zero;
                        objt_Stock.SIH = decimal.Zero;
                        objt_Stock.EXPDate = DateTime.Now;
                        objt_Stock.Usercode = commonFunctions.Loginuser;
                        objt_Stock.DateCr = DateTime.Now;
                        T_StockDL bal = new T_StockDL();
                        bal.SaveT_StockSP(objt_Stock, 1, 1);
                    }
                    if ((pro.CostPrice != det.costPrice) || (pro.SellingPrice != det.sellingPrice))
                    {

                        //save data to price change
                        M_ProductPriceChange objm_ProductPriceChange = new M_ProductPriceChange();
                        objm_ProductPriceChange.Id = commonFunctions.GetSerial("A0029");
                        objm_ProductPriceChange.Product = det.productId;
                        objm_ProductPriceChange.ChangedPlace = "PMS";
                        objm_ProductPriceChange.Currentcost = pro.CostPrice;
                        objm_ProductPriceChange.NewCost = det.costPrice;
                        objm_ProductPriceChange.CurrentSelling = pro.SellingPrice;
                        objm_ProductPriceChange.NewSelling = det.sellingPrice;
                        objm_ProductPriceChange.Userx = commonFunctions.Loginuser;
                        objm_ProductPriceChange.Datex = DateTime.Now;
                        M_ProductPriceChangeDL bal2 = new M_ProductPriceChangeDL();
                        bal2.SaveM_ProductPriceChangeSP(objm_ProductPriceChange, 1);
                        commonFunctions.IncrementSerial("A0029");


                    }

                   
                    new M_ProductDL().SaveM_ProductSP(pro, 3);
                //    scope.Complete();
                //}
            }
        }


        private decimal GetAvaragecost(decimal curentstock, decimal cucost, decimal comingtotal,decimal comingqty)
        {
            decimal currentamt = curentstock * cucost;
            decimal figure = (currentamt + comingtotal) / (curentstock + comingqty);
            figure = decimal.Round(figure, 2);
            return figure;
        }

        #endregion

        #region textareaFunctions
        private void textareaFunctions(bool stype)
        {
            if (stype == true)
            {
                txt_supplierId.Text = "";
                txt_supplierId_name.Text = "";
                txt_remarks.Text = "";
                txt_locationId.Text = "";
                txt_locationId_name.Text = "";
                txt_net.Text = "0.00";
                txt_noOfItems.Text = "0.00";
                txt_noOfPeaces.Text = "0.00";
                txt_poNo.Text = "0.00";
                txt_additions.Text = "0.00";
                txt_deductions.Text = "0.00";
                txt_totdiscount.Text = "0.00";
                dte_date.Value = DateTime.Now;

                txt_code.Text = "";
                txt_cost.Text = "0.00";
                txt_selling.Text = "0.00";
                txt_qty.Text = "0.00";
                txt_amt.Text = "0.00";

                //txt_supplierId.Enabled = true;
                //txt_remarks.Enabled = true;
                //txt_reqLocationId.Enabled = true;
                //txt_DLocationID.Enabled = true;
                //dte_date.Enabled = true;
                //dte_DeliveryDate.Enabled = true;

                dataGridView1.Enabled = true;
            }
            else
            {
                //txt_supplierId.Enabled = false;
                //txt_remarks.Enabled = false;
                //txt_reqLocationId.Enabled = false;
                //txt_DLocationID.Enabled = false;
                //dte_date.Enabled = false;
                //dte_DeliveryDate.Enabled = false;

                dataGridView1.Enabled = false;

            }
        }
        #endregion


        #region txt_grnno_KeyDown

        private void txt_grnno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingGRN(txt_grnno.Text.Trim());
                txt_refNo.Focus();
                errorProvider1.Clear();
            }


            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_grnno.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["GRNFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["GRNSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["GRNField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingGRN(txt_grnno.Text.Trim());
            }
        }

        #endregion

        #region text box key down events

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
                dte_expireDate.Focus();
                errorProvider1.Clear();
            }
        }

        private void dte_expireDate_KeyDown(object sender, KeyEventArgs e)
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
                txt_supInvoiceNo.Focus();
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

                txt_supplierId_name.Text = findExisting.FindExisitingSupplier(txt_supplierId.Text);
            }
        }

        private void txt_supInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_supInvoiceDate.Focus();
                errorProvider1.Clear();
            }
        }

        private void dte_supInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_supDoNo.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_supDoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_supDoDate.Focus();
                errorProvider1.Clear();
            }
        }

        private void dte_supDoDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_value.Focus();
                errorProvider1.Clear();
            }

        }

        private void txt_value_KeyDown(object sender, KeyEventArgs e)
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

        #endregion

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
                errorProvider1.Clear();
            }

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //txt_code.Text = commonFunctions.GetProcutCode(txt_code.Text.Trim());
                    txt_pricelevel.Text = "";
                    if (T_StockDL.ExistingT_Stock_Product(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {
                        if (!commonFunctions.IsExist(dataGridView1, txt_code.Text))
                        {
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk = new M_ProductDL().Selectm_Product(stk);

                            txt_cost.Text = stk.CostPrice.ToString();
                            txt_selling.Text = stk.SellingPrice.ToString();
                            lbl_name.Text = stk.Namex;

                            
                            if (stk.IsMaintainStockLot == true)
                            {
                                //ismaintainstock = true;
                                txt_pricelevel.ReadOnly = false;
                                lbl_stocklot.Visible = true;
                                txt_pricelevel.Focus();
                            }
                            else
                            {
                                //ismaintainstock = false;
                                txt_pricelevel.ReadOnly = true;
                                lbl_stocklot.Visible = false;
                                txt_qty.Text = "0";
                                txt_qty.Focus();
                            }
                            errorProvider1.Clear();
                            already = false;
                        }
                        else
                        {
                            already = true;
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk = new M_ProductDL().Selectm_Product(stk);

                            txt_cost.Text = stk.CostPrice.ToString();
                            txt_selling.Text = stk.SellingPrice.ToString();
                            lbl_name.Text = stk.Namex;

                            if (stk.IsMaintainStockLot == true)
                            {
                                //ismaintainstock = true;
                                txt_pricelevel.ReadOnly = false;
                                lbl_stocklot.Visible = true;
                                txt_pricelevel.Focus();
                            }
                            else
                            {
                                //ismaintainstock = false;
                                txt_pricelevel.ReadOnly = true;
                                lbl_stocklot.Visible = false;
                                txt_qty.Focus();
                            }

                            DataGridViewRow drowx = new DataGridViewRow();
                            drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                            txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txt_code, "Product you have entered not exist in the bin card");
                    }
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
                }
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal x = commonFunctions.ToDecimal(txt_qty.Text.Trim());
                if (x > 0) 
                {
                    txt_cost.Focus();
                }
                else
                {
                    errorProvider1.SetError(txt_qty, "Please enter quntity");
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

        private void txt_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_selling_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_cost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_selling.Focus();
            }
        }

        private void txt_selling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_discount.Focus();
            }
        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
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
                                decimal totamt = commonFunctions.ToDecimal(txt_cost.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                decimal discount = (totamt * commonFunctions.ToDecimal(txt_discount.Text.Trim())) / 100;
                                //totamt = totamt;
                                lbl_discountamt.Text = discount.ToString();
                                txt_amt.Text = totamt.ToString();
                                commonFunctions.AddRowGrn(dtx, txt_code.Text, lbl_name.Text.Trim(), txt_pricelevel.Text, txt_sih.Text.Trim(), txt_cost.Text.Trim(), txt_selling.Text.Trim(), txt_qty.Text.Trim(), txt_amt.Text.Trim(),txt_freeqty.Text,txt_discount.Text.Trim());
                                txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, txt_deductions.Text.Trim(), txt_additions.Text.Trim()).ToString();
                                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                txt_totdiscount.Text = commonFunctions.GetTotalDisc(dataGridView1).ToString();
                                txt_code.Focus();
                            }
                            else
                            {
                                decimal totamt = commonFunctions.ToDecimal(txt_cost.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                decimal discount = (totamt * commonFunctions.ToDecimal(txt_discount.Text.Trim())) / 100;
                                //totamt = totamt;
                                lbl_discountamt.Text = discount.ToString();
                                txt_amt.Text = totamt.ToString();
                                commonFunctions.AddRowtogridGRN(dataGridView1, txt_code.Text.Trim(), txt_qty.Text.Trim(), totamt.ToString(), txt_discount.Text.Trim());
                                txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, txt_deductions.Text.Trim(), txt_additions.Text.Trim()).ToString();
                                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                txt_totdiscount.Text = commonFunctions.GetTotalDisc(dataGridView1).ToString();

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


                txt_code.Focus();

            }
        }

        private void txt_additions_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) {
                txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, txt_deductions.Text.Trim(), txt_additions.Text.Trim()).ToString();
                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            }

        }

        private void txt_deductions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, txt_deductions.Text.Trim(), txt_additions.Text.Trim()).ToString();
                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            }
        }

        private void txt_poNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_poNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["POForGRNFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["POForGRNSQL"].ToString() + " AND locationId = '" + commonFunctions.GlobalLocation.Trim() +"'";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["POForGRNField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingpo(txt_poNo.Text.Trim());
            }
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingpo(txt_poNo.Text.Trim());
                txt_poNo.Focus();
            }
        }

        #region FindExisitingpo

        private void FindExisitingpo(string ReqNo)
        {
            try
            {
                if (T_purchaseOrderDL.ExistingT_purchaseOrder(ReqNo.Trim()))
                {
                    formMode = 1;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                    t_purchaseOrder cat = new t_purchaseOrder();
                    cat.no = ReqNo.Trim();
                    T_purchaseOrderDL dl = new T_purchaseOrderDL();
                    cat = dl.Selectt_purchaseOrder(cat);


                    //load and disable the data fields

                    txt_locationId.Text = cat.locationId.Trim();
                    txt_supplierId.Text = cat.supplierId.Trim();
                    txt_remarks.Text = cat.remarks;
                    //txt_reqLocationId.Text = cat.reqLocationId.Trim();
                    //txt_DLocationID.Text = cat.DLocationID.Trim();
                    dte_date.Value = cat.date.Value;
                    //dte_DeliveryDate.Value = cat.DeliveryDate.Value;

                    //textareaFunctions(false);

                    t_PO_detail req = new t_PO_detail();
                    req.poNo = ReqNo.Trim();
                    T_PO_detailDL tdl = new T_PO_detailDL();
                    List<t_PO_detail> requests = new List<t_PO_detail>();
                    requests = tdl.SelectT_PO_detailMulti(req);

                    foreach (t_PO_detail det in requests)
                    {

                        //commonFunctions.AddRow(dtx, det.productId, findExisting.FindExisitingProduct(det.productId).Trim(), det.cost.ToString(), det.selling.ToString(), det.quantity.ToString(), det.amount.ToString());
                        commonFunctions.AddRowGrn(dtx, det.productId, findExisting.FindExisitingProduct(det.productId).Trim(), "", "", det.cost.ToString(), M_ProductDL.GetSellingPrice(det.productId).ToString(), det.quantity.ToString(), det.amount.ToString(), "0", "0");
                    }

                    txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, txt_deductions.Text.Trim(), txt_additions.Text.Trim()).ToString();
                    txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                    txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                    txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                    txt_totdiscount.Text = commonFunctions.GetTotalDisc(dataGridView1).ToString();

                    //txt_locaname.Text = cat.Locaname;
                }
                else
                {
                    if (formMode != 1)
                    {
                        errorProvider1.SetError(txt_poNo, "Request Number you have entered does not exists in the system.");
                        commonFunctions.SetMDIStatusMessage("Request Number you have entered does not exists in the system.", 1);
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

        #region FindExisitingpo

        private void FindExisitingGRN(string GrnNo)
        {
            try
            {
                if (T_grnDL.ExistingT_grn(GrnNo.Trim()))
                {
                    formMode = 3;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                    t_grn cat = new t_grn();
                    cat.no = GrnNo.Trim();
                    T_grnDL dl = new T_grnDL();
                    cat = dl.Selectt_grn(cat);

                    ////set the process message and mode to edit mode
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
                    //txt_reqLocationId.Text = cat.reqLocationId.Trim();
                    //txt_DLocationID.Text = cat.DLocationID.Trim();
                    dte_date.Value = cat.date.Value;
                    //dte_DeliveryDate.Value = cat.DeliveryDate.Value;

                    textareaFunctions(false);

                    t_grn_detail req = new t_grn_detail();
                    req.grnNo = GrnNo.Trim();
                    T_grn_detailDL tdl = new T_grn_detailDL();
                    List<t_grn_detail> requests = new List<t_grn_detail>();
                    requests = tdl.SelectT_grn_detailMulti(req);

                    foreach (t_grn_detail det in requests)
                    {

                        commonFunctions.AddRowGrn(dtx, det.productId, findExisting.FindExisitingProduct(det.productId).Trim(), "", "", det.costPrice.ToString(), det.sellingPrice.ToString(), det.quantity.ToString(), det.amount.ToString(), "0", det.disPerc.ToString());
                    }

                    txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, txt_deductions.Text.Trim(), txt_additions.Text.Trim()).ToString();
                    txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                    txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                    txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                    txt_totdiscount.Text = commonFunctions.GetTotalDisc(dataGridView1).ToString();

                    //txt_locaname.Text = cat.Locaname;
                }
                else
                {
                    if (formMode != 1)
                    {
                        errorProvider1.SetError(txt_poNo, "Request Number you have entered does not exists in the system.");
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

        private void txt_sih_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_pricelevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (txt_pricelevel.Text.Trim().Length > 10) {
                e.Handled = true;   
            }
        }

        private void txt_pricelevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_pricelevel.Text.Trim() == "") {
                    commonFunctions.SetMDIStatusMessage("Please enter price lvel index", 2);
                    return;
                }
                string stcode = commonFunctions.GetStockCode(txt_code.Text.Trim(), txt_pricelevel.Text.Trim());
                if (T_StockDL.ExistingT_Stock(stcode,"001","001") == true)
                {

                }



                txt_qty.Focus();
            }


        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
