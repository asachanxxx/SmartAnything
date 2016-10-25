/**********************************************************************
Developer   : S.G.Asanga Niranga Chandrakumara
Date        : 2015/07/24
Description : frm_po
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

namespace SmartAnything.UI
{
    //<add key="POSQL" value="select no,grossAmount from  t_purchaseOrder where isSaved = 1 and isProcessed = 0" />
    //<add key="POField0" value="no" />
    //<add key="POField1" value="deleveryDate" />
    //<add key="POFieldLength" value="2" />

    public partial class frm_po : Form
    {

        int formMode = 0;
        string formID = "A0024";
        string formHeadertext = "purchase Order form";
        DataTable dtx = new DataTable();
        bool already = false;
        

        #region Loading one instance

        private static frm_po objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_po getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_po();

            }
            return objSingleObject;

        }

        #endregion

        public frm_po()
        {
            InitializeComponent();
        }

        private void frm_po_Load(object sender, EventArgs e)
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
                txt_pReqNo.BackColor = Color.FromArgb(192, 192, 255);
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
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
                txt_reqLocationId.Text = "";
                txt_reqLocationId_name.Text = "";
                txt_DLocationID.Text = "";
                txt_DLocationID_name.Text = "";
                txt_pReqNo.Text = "";
                dte_date.Value = DateTime.Now;
                dte_DeliveryDate.Value = DateTime.Now;

                txt_code.Text = "";
                txt_cost.Text = "0.00";
                txt_selling.Text = "0.00";
                txt_qty.Text = "0.00";
                txt_amt.Text = "0.00";


                txt_supplierId.Enabled = true;
                txt_remarks.Enabled = true;
                txt_reqLocationId.Enabled = true;
                txt_DLocationID.Enabled = true;
                dte_date.Enabled = true;
                dte_DeliveryDate.Enabled = true;

                dataGridView1.Enabled = true;
            }
            else
            {
                txt_supplierId.Enabled = false;
                txt_remarks.Enabled = false;
                txt_reqLocationId.Enabled = false;
                txt_DLocationID.Enabled = false;
                dte_date.Enabled = false;
                dte_DeliveryDate.Enabled = false;

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
                        errorProvider1.SetError(txt_code, "Product you have entered not exist in the bin card");
                        commonFunctions.SetMDIStatusMessage("Product you have entered not exist in the bin card", 2);
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
                            if (!M_LocaDL.ExistingM_Loca(txt_reqLocationId.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_reqLocationId, "Requested location does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Requested location does not exists on the system ", 1);
                                return;
                            }

                            if (!M_LocaDL.ExistingM_Loca(txt_DLocationID.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_DLocationID, "Devlivery location does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Devlivery location does not exists on the system ", 1);
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

                            if (DateTime.Compare(dte_date.Value, dte_DeliveryDate.Value) > -1)
                            {
                                errorProvider1.SetError(dte_DeliveryDate, "Delivary date must be grater than request date");
                                commonFunctions.SetMDIStatusMessage("Delivary date must be grater than request date", 1);
                                return;
                            }


                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {
                                    //u_DBConnection.BeginTrans();
                                    //save header data
                                    t_purchaseOrder objt_purchaseOrder = new t_purchaseOrder();
                                    objt_purchaseOrder.no = txt_no.Text.Trim();
                                    objt_purchaseOrder.locationId =commonFunctions.GlobalLocation;
                                    objt_purchaseOrder.reqLocationId = txt_reqLocationId.Text.Trim();
                                    objt_purchaseOrder.pReqNo = txt_pReqNo.Text.Trim();
                                    objt_purchaseOrder.poMethod = "";//txt_poMethod.Text.Trim();
                                    objt_purchaseOrder.date = dte_date.Value;
                                    objt_purchaseOrder.supplierId = txt_supplierId.Text.Trim();
                                    objt_purchaseOrder.DeliveryDate = dte_DeliveryDate.Value;
                                    objt_purchaseOrder.DLocationID = txt_DLocationID.Text.Trim();
                                    objt_purchaseOrder.noOfItems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                    objt_purchaseOrder.noOfPeaces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                    objt_purchaseOrder.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                    objt_purchaseOrder.remarks = txt_remarks.Text.Trim();
                                    objt_purchaseOrder.isSaved = true;
                                    objt_purchaseOrder.isProcessed = false;
                                    objt_purchaseOrder.processDate = DateTime.Now;
                                    objt_purchaseOrder.processUser = "";
                                    objt_purchaseOrder.triggerVal = 1;
                                    T_purchaseOrderDL bal = new T_purchaseOrderDL();
                                    bal.Savet_purchaseOrderSP(objt_purchaseOrder, 1);

                                    //save details 
                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                        {
                                            t_PO_detail objt_PO_detail = new t_PO_detail();
                                            objt_PO_detail.poNo = txt_no.Text.Trim();
                                            objt_PO_detail.locationId = commonFunctions.GlobalLocation;
                                            objt_PO_detail.productId = drow.Cells["Product Code"].Value.ToString();
                                            objt_PO_detail.cost = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                            objt_PO_detail.quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                            objt_PO_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                            objt_PO_detail.priceLevel = "";
                                            objt_PO_detail.selling = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                            objt_PO_detail.triggerVal = 1;
                                            T_PO_detailDL baldet = new T_PO_detailDL();
                                            baldet.Savet_PO_detailSP(objt_PO_detail, 1);
                                        }

                                    }

                                    //increment the serial
                                    commonFunctions.IncrementSerial(formID);
                                    //u_DBConnection.CommitTrans();
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                                }
                                catch (Exception ex)
                                {
                                    // u_DBConnection.RollbackTrans();

                                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                    commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                                }

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    t_purchaseOrder objt_purchaseOrder2 = new t_purchaseOrder();
                                    objt_purchaseOrder2.no = txt_no.Text.Trim();

                                    T_purchaseOrderDL balprocess = new T_purchaseOrderDL();
                                    objt_purchaseOrder2 = balprocess.Selectt_purchaseOrder(objt_purchaseOrder2);

                                    objt_purchaseOrder2.isProcessed = true;
                                    objt_purchaseOrder2.processDate = DateTime.Now;
                                    objt_purchaseOrder2.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_purchaseOrderSP(objt_purchaseOrder2, 3);

                                    if (txt_pReqNo.Text.Trim() != "") {
                                        t_purchaseRequisition req = new t_purchaseRequisition();
                                        req.no = txt_pReqNo.Text.Trim();
                                        req = new T_purchaseRequisitionDL().Selectt_purchaseRequisition(req);
                                        req.triggerVal = 2;
                                        new T_purchaseRequisitionDL().SaveT_purchaseRequisitionSP(req, 3);

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
                                txt_no.Text = commonFunctions.GetSerial(formID.Trim());
                                txt_supplierId.Focus();
                            }
                        }
                        else if (formMode == 3)
                        {
                            t_purchaseOrder objt_purchaseOrder = new t_purchaseOrder();
                            objt_purchaseOrder.no = txt_no.Text.Trim();
                            T_purchaseOrderDL dl = new T_purchaseOrderDL();
                            objt_purchaseOrder = dl.Selectt_purchaseOrder(objt_purchaseOrder);
                            if (objt_purchaseOrder.isProcessed == false)
                            {

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    try
                                    {
                                        //u_DBConnection.BeginTrans();
                                        //save header data
                                        objt_purchaseOrder.locationId = txt_locationId.Text.Trim();
                                        objt_purchaseOrder.reqLocationId = txt_reqLocationId.Text.Trim();
                                        objt_purchaseOrder.pReqNo = txt_pReqNo.Text.Trim();
                                        objt_purchaseOrder.poMethod = "";//txt_poMethod.Text.Trim();
                                        objt_purchaseOrder.date = dte_date.Value;
                                        objt_purchaseOrder.supplierId = txt_supplierId.Text.Trim();
                                        objt_purchaseOrder.DeliveryDate = dte_DeliveryDate.Value;
                                        objt_purchaseOrder.DLocationID = txt_DLocationID.Text.Trim();
                                        objt_purchaseOrder.noOfItems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                        objt_purchaseOrder.noOfPeaces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                        objt_purchaseOrder.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                        objt_purchaseOrder.remarks = txt_remarks.Text.Trim();
                                        objt_purchaseOrder.triggerVal = 1;
                                        T_purchaseOrderDL bal = new T_purchaseOrderDL();
                                        bal.Savet_purchaseOrderSP(objt_purchaseOrder, 3);

                                        List<t_PO_detail> dets = new List<t_PO_detail>();
                                        t_PO_detail pox = new t_PO_detail();
                                        pox.poNo = txt_no.Text.Trim();
                                        dets = new T_PO_detailDL().SelectT_PO_detailMulti(pox);
                                        foreach (t_PO_detail det in dets) {
                                            new T_PO_detailDL().Savet_PO_detailSP(det, 4);
                                        }


                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                t_PO_detail objt_PO_detail = new t_PO_detail();
                                                objt_PO_detail.poNo = txt_no.Text.Trim();
                                                objt_PO_detail.locationId = txt_locationId.Text.Trim();
                                                objt_PO_detail.productId = drow.Cells["Product Code"].Value.ToString();
                                                objt_PO_detail.cost = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_PO_detail.quantity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_PO_detail.amount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                objt_PO_detail.priceLevel = "";
                                                objt_PO_detail.selling = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                                objt_PO_detail.triggerVal = 1;
                                                T_PO_detailDL baldet = new T_PO_detailDL();
                                                baldet.Savet_PO_detailSP(objt_PO_detail, 1);
                                            }

                                        }

                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                                    }
                                    catch (Exception ex)
                                    {
                                        // u_DBConnection.RollbackTrans();

                                        LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                        commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                                    }
                                }


                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    t_purchaseOrder objt_purchaseOrder2 = new t_purchaseOrder();
                                    objt_purchaseOrder2.no = txt_no.Text.Trim();

                                    T_purchaseOrderDL balprocess = new T_purchaseOrderDL();
                                    objt_purchaseOrder2 = balprocess.Selectt_purchaseOrder(objt_purchaseOrder2);

                                    objt_purchaseOrder2.isProcessed = true;
                                    objt_purchaseOrder2.processDate = DateTime.Now;
                                    objt_purchaseOrder2.processUser = commonFunctions.Loginuser;
                                    balprocess.Savet_purchaseOrderSP(objt_purchaseOrder2, 3);

                                    if (txt_pReqNo.Text.Trim() != "")
                                    {
                                        t_purchaseRequisition req = new t_purchaseRequisition();
                                        req.no = txt_pReqNo.Text.Trim();
                                        req = new T_purchaseRequisitionDL().Selectt_purchaseRequisition(req);
                                        req.triggerVal = 2;
                                        new T_purchaseRequisitionDL().SaveT_purchaseRequisitionSP(req, 3);

                                    }


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

        #region FindExisiting

        private void FindExisitingpo(string ReqNo)
        {
            try
            {
                if (T_purchaseOrderDL.ExistingT_purchaseOrder(ReqNo.Trim()))
                {
                    formMode = 3;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                    t_purchaseOrder cat = new t_purchaseOrder();
                    cat.no = ReqNo.Trim();
                    T_purchaseOrderDL dl = new T_purchaseOrderDL();
                    cat = dl.Selectt_purchaseOrder(cat);

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
                    txt_reqLocationId.Text = cat.reqLocationId.Trim();
                    txt_DLocationID.Text = cat.DLocationID.Trim();
                    dte_date.Value = cat.date.Value;
                    dte_DeliveryDate.Value = cat.DeliveryDate.Value;

                    //textareaFunctions(false);

                    t_PO_detail req = new t_PO_detail();
                    req.poNo = ReqNo.Trim();
                    T_PO_detailDL tdl = new T_PO_detailDL();
                    List<t_PO_detail> requests = new List<t_PO_detail>();
                    requests = tdl.SelectT_PO_detailMulti(req);

                    foreach (t_PO_detail det in requests)
                    {

                        commonFunctions.AddRow(dtx, det.productId, findExisting.FindExisitingProduct(det.productId).Trim(), det.cost.ToString(), det.selling.ToString(), det.quantity.ToString(), det.amount.ToString());
                    }

                    txt_net.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                    txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                    txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                    txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();

                    //txt_locaname.Text = cat.Locaname;
                }
                else
                {
                    if (formMode != 1)
                    {
                        errorProvider1.SetError(txt_no, "Purchase order number you have entered does not exists in the system.");
                        commonFunctions.SetMDIStatusMessage("Purchase order number you have entered does not exists in the system.", 1);

                    }
                }

            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 2);
            }

        }

        private void FindExisitingRequests(string ReqNo)
        {
            try
            {
                if (T_purchaseRequisitionDL.ExistingT_purchaseRequisition(ReqNo.Trim()))
                {

                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                    t_purchaseRequisition cat = new t_purchaseRequisition();
                    cat.no = ReqNo.Trim();
                    T_purchaseRequisitionDL dl = new T_purchaseRequisitionDL();
                    cat = dl.Selectt_purchaseRequisition(cat);

                    txt_supplierId.Text = cat.supplierId;
                    txt_locationId.Text = cat.locationId;
                    dte_DeliveryDate.Value = cat.deleveryDate.Value;

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
                    txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                    txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                    txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();

                    txt_supplierId.Focus();
                    formMode = 1;
                }
                else
                {
                    if (formMode != 1)
                    {
                        errorProvider1.SetError(txt_pReqNo, "Request Number you have entered does not exists in the system.");
                        commonFunctions.SetMDIStatusMessage("Request Number you have entered does not exists in the system.", 1);

                    }
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 2);
            }

        }

        #endregion

        #region Key Down events

        private void txt_reqLocationId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_reqLocationId.Name.Trim())
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

            }

            if (e.KeyCode == Keys.Enter)
            {
                txt_reqLocationId_name.Text = findExisting.FindExisitingLoca(txt_reqLocationId.Text);
                txt_DLocationID.Focus();
                errorProvider1.Clear();
            }

        }

        private void txt_DLocationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_DLocationID.Name.Trim())
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

            }

            if (e.KeyCode == Keys.Enter)
            {
                txt_DLocationID_name.Text = findExisting.FindExisitingLoca(txt_DLocationID.Text);
                txt_remarks.Focus();
                errorProvider1.Clear();
            }

        }

        private void txt_supplierId_KeyDown(object sender, KeyEventArgs e)
        {
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

            if (e.KeyCode == Keys.Enter)
            {
                txt_supplierId_name.Text = findExisting.FindExisitingSupplier(txt_supplierId.Text);
                dte_date.Focus();
                errorProvider1.Clear();
            }


        }

        private void txt_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingpo(txt_no.Text.Trim());
                txt_supplierId.Focus();
                errorProvider1.Clear();
            }


            if (e.KeyCode == Keys.F2)
            {

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

                FindExisitingpo(txt_no.Text.Trim());
            }
        }

        private void dte_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_DeliveryDate.Focus();
                errorProvider1.Clear();
            }
        }

        private void dte_DeliveryDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_reqLocationId.Focus();
                errorProvider1.Clear();
            }
        }

        private void txt_pReqNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_reqLocationId.Focus();
                errorProvider1.Clear();
                FindExisitingRequests(txt_pReqNo.Text.Trim());
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_pReqNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["PurreqRecallFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["PurreqRecallSQL"].ToString() + " AND locationId = '" + commonFunctions.GlobalLocation.Trim() +"'";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["PurreqRecallField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingRequests(txt_pReqNo.Text.Trim());
                txt_no.Text = commonFunctions.GetSerial(formID.Trim());
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

        private void txt_reqLocationId_TextChanged(object sender, EventArgs e)
        {
            txt_reqLocationId_name.Text = findExisting.FindExisitingLoca(txt_reqLocationId.Text);
        }

        private void txt_DLocationID_TextChanged(object sender, EventArgs e)
        {
            txt_DLocationID_name.Text = findExisting.FindExisitingLoca(txt_DLocationID.Text);
        }

        private void txt_supplierId_TextChanged(object sender, EventArgs e)
        {
            txt_supplierId_name.Text = findExisting.FindExisitingSupplier(txt_supplierId.Text);
        }


    }
}
