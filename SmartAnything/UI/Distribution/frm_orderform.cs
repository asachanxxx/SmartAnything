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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SmartAnything.Reports;
using SmartAnything.Reports.DistributionRpt;
using SmartAnything.Reports.SalesRpt;
using SmartAnything.Reports.StockRpt;

namespace SmartAnything.UI
{
    public partial class frm_orderform : Form
    {
        int formMode = 0;
        string formID = "A0017";
        string formHeadertext = "Customer Order Form";
        DataTable dtx = new DataTable();
        bool already = false;

        #region Loading one instance

        private static frm_orderform objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_orderform getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_orderform();

            }
            return objSingleObject;

        }

        #endregion

        public frm_orderform()
        {
            InitializeComponent();
            
        }

        private void frm_orderform_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);


                ApplyDiscMeth();

                dtx = commonFunctions.CreateDatatableDIstribution();
                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[1].Width = 260;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 100;
                txt_code.Focus();

                commonFunctions.FormatDataGrid(dataGridView2);
                commonFunctions.FormatDataGrid(dataGridView3);
                commonFunctions.FormatDataGrid(dte_cheques);

                txt_RecivedBy.Text = commonFunctions.Loginuser;

                cmb_TRNType.SelectedIndex = 0;
                txt_Locacode.Text = commonFunctions.GlobalLocation;
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

        private void ApplyDiscMeth() {
            string discmeth = ConfigurationManager.AppSettings["DiscMethod"].ToString();
            switch (discmeth.Trim())
            {
                case "ITM":
                    txt_discount.ReadOnly = false;
                    txt_subtotaldisc.ReadOnly = true;
                    txt_subtotaldisc.Text = "0.00";
                    break;
                case "SUB":
                    txt_discount.ReadOnly = true;
                    txt_subtotaldisc.ReadOnly = false;
                    break;
                case "BOT":
                    txt_discount.ReadOnly = false;
                    txt_subtotaldisc.ReadOnly = false;
                    break;
            }
        }

        #region performButtons Area

        private void performButtons(xEnums.PerformanceType xenum)
        {

            try
            {
                switch (xenum)
                {
                    case xEnums.PerformanceType.View:
                        if (ActiveControl.Name.Trim() == txt_DocNo.Name.Trim())
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
                        txt_DocNo.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_DocNo.Focus();

                        txt_Locacode.Text = commonFunctions.GlobalLocation;
                        txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
                        textareaFunctions(true);
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
                            if (!M_LocaDL.ExistingM_Loca(txt_Locacode.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_Locacode, "Location does not exists on the system ");
                                return;
                            }

                            if (!M_CustomerDL.ExistingM_Customer(txt_Customer.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_Customer, "Customer does not exists on the system ");
                                return;
                            }

                            //if (!M_SalesManDL.ExistingM_SalesMan(txt_RecivedBy.Text.Trim()))
                            //{
                            //    errorProvider1.SetError(txt_RecivedBy, "Salesman does not exists on the system ");
                            //    return;
                            //}

                            if (commonFunctions.GetNoofItems(dataGridView1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                return;
                            }



                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {

                                    using (var scope = new System.Transactions.TransactionScope())
                                    {
                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                T_OrderFormDet objt_OrderFormDet = new T_OrderFormDet();
                                                objt_OrderFormDet.Docno = txt_DocNo.Text.Trim();
                                                objt_OrderFormDet.CompCode = commonFunctions.GlobalCompany;
                                                objt_OrderFormDet.Locacode = commonFunctions.GlobalLocation;
                                                objt_OrderFormDet.OFNo = txt_DocNo.Text.Trim();
                                                objt_OrderFormDet.ItemCode = drow.Cells["Product Code"].Value.ToString();
                                                objt_OrderFormDet.Quntity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_OrderFormDet.Barcode = drow.Cells["Product Code"].Value.ToString();
                                                objt_OrderFormDet.UnitPrice = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                                objt_OrderFormDet.CostPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_OrderFormDet.discper = commonFunctions.ToDecimal(drow.Cells["Disc%"].Value.ToString());
                                                objt_OrderFormDet.discount = commonFunctions.ToDecimal(drow.Cells["Disc Amt"].Value.ToString());
                                                objt_OrderFormDet.Unit = "PCS";
                                                objt_OrderFormDet.Amountx = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                T_OrderFormDetDL bal2 = new T_OrderFormDetDL();
                                                bal2.Savet_OrderFormDetSP(objt_OrderFormDet, 1);

                                                T_Stock stk = new T_Stock();
                                                T_StockDL stkdl = new T_StockDL();
                                                stk.StockCode = drow.Cells["Product Code"].Value.ToString();
                                                stk.Compcode = commonFunctions.GlobalCompany;
                                                stk.Locacode = commonFunctions.GlobalLocation;
                                                stk = stkdl.Selectt_Stock_new(stk);
                                                decimal resstk = commonFunctions.ToDecimal(lbl_reserved.Text.Trim());
                                                resstk += objt_OrderFormDet.Quntity.Value;
                                                stk.ReservedStock = resstk;
                                                stkdl.SaveT_StockSP(stk, 3,1);
                                            }

                                        }

                                        //u_DBConnection.BeginTrans();
                                        //save header data
                                        T_OrderFormHead objt_OrderFormHead = new T_OrderFormHead();
                                        objt_OrderFormHead.DocNo = txt_DocNo.Text.Trim();
                                        objt_OrderFormHead.Compcode = commonFunctions.Loginuser;//txt_Compcode.Text.Trim();
                                        objt_OrderFormHead.Locacode = commonFunctions.GlobalLocation;
                                        objt_OrderFormHead.TRNType = cmb_TRNType.Text.Trim().Substring(0, 2);
                                        objt_OrderFormHead.Customer = txt_Customer.Text.Trim();
                                        objt_OrderFormHead.SalesMan = txt_RecivedBy.Text.Trim();
                                        objt_OrderFormHead.Datex = dte_date.Value;
                                        objt_OrderFormHead.RecivedBy = txt_RecivedBy.Text.Trim();
                                        objt_OrderFormHead.CheckedBy = "";//txt_CheckedBy.Text.Trim();
                                        objt_OrderFormHead.Approved = 0;//txt_Approved.Text.Trim();
                                        objt_OrderFormHead.ApprovedBy = "";//txt_ApprovedBy.Text.Trim();
                                        objt_OrderFormHead.ApprovedDate = DateTime.Now;
                                        objt_OrderFormHead.RecivedDate = dte_RecivedDate.Value;
                                        objt_OrderFormHead.Userx = commonFunctions.Loginuser;//txt_Userx.Text.Trim();
                                        objt_OrderFormHead.CreatedDate = DateTime.Now;
                                        objt_OrderFormHead.CQNO = "";//txt_CQNO.Text.Trim();
                                        objt_OrderFormHead.CQDate = DateTime.Now;//txt_CQDate.Text.Trim();
                                        objt_OrderFormHead.BANK = ""; //txt_BANK.Text.Trim();
                                        objt_OrderFormHead.BRANCH = "";// txt_BRANCH.Text.Trim();
                                        objt_OrderFormHead.DiscountPer = commonFunctions.ToDecimal(txt_subtotaldisc.Text.Trim());
                                        objt_OrderFormHead.TotalDisc = commonFunctions.ToDecimal(txt_TotalDisc.Text.Trim());
                                        objt_OrderFormHead.Subtotal = commonFunctions.ToDecimal(txt_Subtotal.Text.Trim());
                                        objt_OrderFormHead.NetTotal = commonFunctions.ToDecimal(txt_NetTotal.Text.Trim());
                                        objt_OrderFormHead.SubtotalDisc = commonFunctions.ToDecimal(txt_subtotaldisc.Text.Trim());
                                        objt_OrderFormHead.ItemdiscTotal = decimal.Zero;
                                        objt_OrderFormHead.Remarks = txt_Remarks11.Text.Trim();
                                        objt_OrderFormHead.Processed = 0; //txt_Processed.Text.Trim();
                                        objt_OrderFormHead.ProcessedDate = DateTime.Now;
                                        objt_OrderFormHead.ProcessedUser = "";
                                        objt_OrderFormHead.InvCreated = 0; //txt_Processed.Text.Trim();
                                        objt_OrderFormHead.InvCreatedDate = DateTime.Now;
                                        objt_OrderFormHead.INVCreatedUser = "";
                                        T_OrderFormHeadDL bal = new T_OrderFormHeadDL();
                                        bal.Savet_OrderFormHeadSP(objt_OrderFormHead, 1);


                                    
                                        //increment the serial
                                        commonFunctions.IncrementSerial(formID);

                                        scope.Complete();
                                        //u_DBConnection.CommitTrans();
                                    }
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
                                    T_OrderFormHead objt_trnsferNote = new T_OrderFormHead();
                                    objt_trnsferNote.DocNo = txt_DocNo.Text.Trim();

                                    T_OrderFormHeadDL balprocess = new T_OrderFormHeadDL();
                                    objt_trnsferNote = balprocess.Selectt_OrderFormHead(objt_trnsferNote);

                                    objt_trnsferNote.Processed = 1;
                                    objt_trnsferNote.ProcessedDate = DateTime.Now;
                                    objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                    balprocess.Savet_OrderFormHeadSP(objt_trnsferNote, 3);

                                    //save order tracking data on the table if processed is true
                                    CreateOrderTracking();


                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                    if (objt_trnsferNote.Processed == 1)
                                    {
                                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            PrintDoc(txt_DocNo.Text.Trim());
                                        }
                                    }
                                }


                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();
                                //clear text fields
                                textareaFunctions(true);

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_DocNo.Text = commonFunctions.GetSerial(formID.Trim());
                                txt_Customer.Focus();
                            }
                        }
                        else if (formMode == 3)
                        {
                            T_OrderFormHead objt_trnsferNote = new T_OrderFormHead();
                            objt_trnsferNote.DocNo = txt_DocNo.Text.Trim();
                            T_OrderFormHeadDL dl = new T_OrderFormHeadDL();
                            objt_trnsferNote = dl.Selectt_OrderFormHead(objt_trnsferNote);


                            if (objt_trnsferNote.Processed == 0)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    T_OrderFormDet objt_OrderFormDet = new T_OrderFormDet();
                                    T_OrderFormDetDL bal2 = new T_OrderFormDetDL();
                                    objt_OrderFormDet.Docno = txt_DocNo.Text;
                                    List<T_OrderFormDet> list = new List<T_OrderFormDet>();
                                    list = bal2.SelectT_OrderFormDetMulti(objt_OrderFormDet);

                                    //update header details

                                    objt_trnsferNote.TRNType = cmb_TRNType.Text.Trim().Substring(0, 2);
                                    objt_trnsferNote.Customer = txt_Customer.Text.Trim();
                                    objt_trnsferNote.SalesMan = txt_RecivedBy.Text.Trim();
                                    objt_trnsferNote.Datex = dte_date.Value;
                                    objt_trnsferNote.DiscountPer = commonFunctions.ToDecimal(txt_subtotaldisc.Text.Trim());
                                    objt_trnsferNote.TotalDisc = commonFunctions.ToDecimal(txt_TotalDisc.Text.Trim());
                                    objt_trnsferNote.Subtotal = commonFunctions.ToDecimal(txt_Subtotal.Text.Trim());
                                    objt_trnsferNote.NetTotal = commonFunctions.ToDecimal(txt_NetTotal.Text.Trim());
                                    objt_trnsferNote.SubtotalDisc = commonFunctions.ToDecimal(txt_subtotaldisc.Text.Trim());
                                    objt_trnsferNote.ItemdiscTotal = decimal.Zero;
                                    objt_trnsferNote.Remarks = txt_Remarks11.Text.Trim();

                                    dl.Savet_OrderFormHeadSP(objt_trnsferNote,3);


                                    foreach (T_OrderFormDet detx in list)
                                    {
                                        bal2.Savet_OrderFormDetSP(detx, 4);
                                    }

                                    //save details 
                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                        {

                                            objt_OrderFormDet.Docno = txt_DocNo.Text.Trim();
                                            objt_OrderFormDet.CompCode = commonFunctions.GlobalCompany;
                                            objt_OrderFormDet.Locacode = commonFunctions.GlobalLocation;
                                            objt_OrderFormDet.OFNo = txt_DocNo.Text.Trim();
                                            objt_OrderFormDet.ItemCode = drow.Cells["Product Code"].Value.ToString();
                                            objt_OrderFormDet.Quntity = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                            objt_OrderFormDet.Barcode = drow.Cells["Product Code"].Value.ToString();
                                            objt_OrderFormDet.UnitPrice = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                            objt_OrderFormDet.CostPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                            objt_OrderFormDet.discper = commonFunctions.ToDecimal(drow.Cells["Disc%"].Value.ToString());
                                            objt_OrderFormDet.discount = commonFunctions.ToDecimal(drow.Cells["Disc Amt"].Value.ToString());
                                            objt_OrderFormDet.Unit = "PCS";
                                            objt_OrderFormDet.Amountx = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                            bal2.Savet_OrderFormDetSP(objt_OrderFormDet, 1);


                                            T_Stock stk = new T_Stock();
                                            T_StockDL stkdl = new T_StockDL();
                                            stk.StockCode = drow.Cells["Product Code"].Value.ToString();
                                            stk.Compcode = commonFunctions.GlobalCompany;
                                            stk.Locacode = commonFunctions.GlobalLocation;
                                            stk = stkdl.Selectt_Stock_ByStockCode(stk);
                                            decimal resstk = commonFunctions.ToDecimal(lbl_reserved.Text.Trim());
                                            resstk += objt_OrderFormDet.Quntity.Value;
                                            stk.ReservedStock = resstk;
                                            stkdl.SaveT_StockSP(stk, 3,1);

                                        }

                                    }

                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());



                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        objt_trnsferNote.Processed = 1;
                                        objt_trnsferNote.ProcessedDate = DateTime.Now;
                                        objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                        dl.Savet_OrderFormHeadSP(objt_trnsferNote, 3);


                                        CreateOrderTracking();

                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                        if (objt_trnsferNote.Processed == 1)
                                        {
                                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                PrintDoc(txt_DocNo.Text.Trim());
                                            }
                                        }
                                        else
                                        {

                                        }
                                    }


                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    dataGridView1.ReadOnly = false;
                                    //clear text fields
                                    textareaFunctions(true);
                                    FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    txt_DocNo.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_code.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_DocNo, "Order form number you have entered already processed.You cannot changed data now");
                            }
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_DocNo.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Default);
                        errorProvider1.Clear();
                        //clear text fields
                        textareaFunctions(true);
                        //clear Datagrid
                        dtx.Clear();
                        dataGridView1.Refresh();
                        dataGridView1.ReadOnly = false;
                        //txt_supplierId.Text = "";
                        //txt_remarks.Text = "";

                        lbl_processes.Visible = false;

                        break;
                    case xEnums.PerformanceType.Print:
                        if (txt_DocNo.Text.Trim() != "")
                        {
                            T_OrderFormHead objt_trnsferNoteS = new T_OrderFormHead();
                            objt_trnsferNoteS.DocNo = txt_DocNo.Text.Trim();
                            T_OrderFormHeadDL dlww = new T_OrderFormHeadDL();
                            objt_trnsferNoteS = dlww.Selectt_OrderFormHead(objt_trnsferNoteS);


                            if (objt_trnsferNoteS.Processed == 1)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    PrintDoc(txt_DocNo.Text.Trim());
                                }
                            }
                            else
                            {

                            }
                        }
                        else {
                            errorProvider1.SetError(txt_DocNo, "Please enter Order form number to print");
                            
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog("performButtons", "frm_purchaserequest", ex.Message.ToString());
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }
        }

        #endregion

        private void CreateOrderTracking()
        {
            try
            {
                T_OrderTracking objt_OrderTracking = new T_OrderTracking();
                objt_OrderTracking.OFNo = txt_DocNo.Text.Trim();
                objt_OrderTracking.CompCode = commonFunctions.GlobalCompany;
                objt_OrderTracking.LocaCode = commonFunctions.GlobalLocation;
                objt_OrderTracking.Customer = txt_Customer.Text.Trim();
                objt_OrderTracking.CustomerDIscRate = decimal.Zero;
                objt_OrderTracking.SalesMan = txt_RecivedBy.Text.Trim();
                objt_OrderTracking.OFApproved = 0;
                objt_OrderTracking.OFApprovedUser = "";
                objt_OrderTracking.OFApprovedDate = DateTime.Now;
                objt_OrderTracking.OFNoOfPrints = 0;
                objt_OrderTracking.OFPrintUser = "";
                objt_OrderTracking.InvCreated = 0;
                objt_OrderTracking.InvNo = "";
                objt_OrderTracking.InvAmount = decimal.Zero;
                objt_OrderTracking.InvApproved = 0;
                objt_OrderTracking.InvApprovedUser = "";
                objt_OrderTracking.InvApprovedDate = DateTime.Now;
                objt_OrderTracking.InvNoOfPrints = 0;
                objt_OrderTracking.InvPrintUser = "";
                objt_OrderTracking.DOCreated = 0;
                objt_OrderTracking.DONo = "";
                objt_OrderTracking.DOAmount = decimal.Zero;
                objt_OrderTracking.DOApproved = 0;
                objt_OrderTracking.DOApprovedUser = "";
                objt_OrderTracking.DOApprovedDate = DateTime.Now;
                objt_OrderTracking.DONoOfPrints = 0;
                objt_OrderTracking.DOvPrintUser = "";
                objt_OrderTracking.Audited = 0;
                objt_OrderTracking.AuditDate = DateTime.Now;
                objt_OrderTracking.AuditUser = "";
                objt_OrderTracking.Dispatched = 0;
                objt_OrderTracking.DispatchedDate = DateTime.Now;
                objt_OrderTracking.DispatchedUser = "";
                objt_OrderTracking.Handedover = 0;
                objt_OrderTracking.HandedoverUser = "";
                objt_OrderTracking.HandedoverDate = DateTime.Now;
                objt_OrderTracking.Completed = 0;
                objt_OrderTracking.CompletedUser = "";
                objt_OrderTracking.CompletedDate = DateTime.Now;
                objt_OrderTracking.PackingListCreated = 0;
                objt_OrderTracking.PackingListNo = "";
                objt_OrderTracking.PackingListDate = DateTime.Now;
                objt_OrderTracking.PackingListUser = "";
                objt_OrderTracking.Remarks = txt_Remarks11.Text.Trim();
                objt_OrderTracking.DOProcessed = 0;
                objt_OrderTracking.DOProcessedDate = DateTime.Now;
                objt_OrderTracking.DOProcessedUser = "";
                objt_OrderTracking.DOMultipleNO = "";
                objt_OrderTracking.HandOverLorry = "";
                objt_OrderTracking.CompleteRemark = "";
                objt_OrderTracking.OrderDate = DateTime.Now;
                objt_OrderTracking.InvoiceDate = DateTime.Now;
                objt_OrderTracking.Dodate = DateTime.Now;


                T_OrderTrackingDL bal = new T_OrderTrackingDL();
                bal.Savet_OrderTrackingSP(objt_OrderTracking, 1);
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

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
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
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

        #region textareaFunctions

        private void textareaFunctions(bool stype)
        {
            if (stype == true)
            {

                txt_Remarks11.Text = "";
                txt_Customer.Text = "";
                //txt_RecivedBy.Text = "";
                txt_Customer_name.Text = "";
                dte_date.Value = DateTime.Now;
                txt_discount.Text = "0.0";
                cmb_TRNType.SelectedIndex = 0;
                dtx.Clear();
                dataGridView1.Refresh();
                txt_code.Text = "";
                txt_qty.Text = "0";
                txt_amt.Text = "0.00";

                dte_date.Enabled = true;
                //txt_Remarks11.Enabled = true;
                txt_Locacode.Enabled = true;
                //txt_Customer.Enabled = true;
                txt_RecivedBy.Enabled = true;
                txt_RecivedBy_name.Enabled = true;
                txt_Customer_name.Enabled = true;
                //txt_subtotaldisc.Enabled = true;
                txt_additions.Enabled = true;
                txt_deductions.Enabled = true;
                dataGridView1.Enabled = true;
            }
            else
            {

                txt_Remarks11.Enabled = false;
                txt_Locacode.Enabled = false;
                //txt_Customer.Enabled = false;
                txt_RecivedBy.Enabled = false;
                txt_RecivedBy_name.Enabled = false;
                txt_Customer_name.Enabled = false;
                //txt_subtotaldisc.Enabled = false;
                txt_additions.Enabled = false;
                txt_deductions.Enabled = false;

                dte_date.Enabled = false;
                dataGridView1.Enabled = false;

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

        #region Detail functions

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_code.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductStockFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString() + " WHERE dbo.T_Stock.Locacode = '" + commonFunctions.GlobalLocation.Trim() +"'";

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

        private void GetStockdetails()
        {
            try
            {
                T_Stock stk = StockEngine.GetStockdetails(txt_code.Text);
                txt_cost.Text = StockEngine.GetProductCostPrice(stk.ProductId).ToString();
                txt_selling.Text = StockEngine.GetProductSellingPrice(stk.ProductId).ToString();
                lbl_name.Text = stk.Descr;
                lbl_phyQty.Text = stk.Stock.ToString();
                lbl_reserved.Text = stk.ReservedStock.ToString();
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
                decimal x = commonFunctions.ToDecimal(txt_qty.Text.Trim());
                if (x > 0)
                {
                    txt_discount.Text = "0.00";
                    txt_discount.Focus();
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
            txt_TotalDisc.Text = getGlobalDiscount().ToString();
            txt_NetTotal.Text = commonFunctions.GetNetAmountWIthDisc(dataGridView1, "0.00", "0.00",txt_TotalDisc.Text).ToString();
            txt_Subtotal.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
            txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
           
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
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

                            already = commonFunctions.IsExist(dataGridView1, txt_code.Text);

                            if (already == false)
                            {
                                decimal totamt = commonFunctions.ToDecimal(txt_selling.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                decimal discount = (totamt * commonFunctions.ToDecimal(txt_discount.Text.Trim())) / 100;
                                totamt = totamt - discount;
                                lbl_discountamt.Text = discount.ToString();
                                txt_amt.Text = totamt.ToString();
                                commonFunctions.AddRowDistribute(dtx, txt_code.Text, lbl_name.Text.Trim(), txt_cost.Text.Trim(), txt_selling.Text.Trim(), txt_qty.Text.Trim(), txt_discount.Text.Trim(), lbl_discountamt.Text, txt_amt.Text.Trim());
                                txt_TotalDisc.Text = getGlobalDiscount().ToString();
                                txt_NetTotal.Text = commonFunctions.GetNetAmountWIthDisc(dataGridView1, "0.00", "0.00", txt_TotalDisc.Text).ToString();
                                txt_Subtotal.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                txt_code.Focus();
                            }
                            else
                            {
                                decimal totamt = commonFunctions.ToDecimal(txt_selling.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                decimal discount = (totamt * commonFunctions.ToDecimal(txt_discount.Text.Trim())) / 100;
                                totamt = totamt - discount;
                                lbl_discountamt.Text = discount.ToString();
                                txt_amt.Text = totamt.ToString();
                                commonFunctions.AddRowtogridDistribute(dataGridView1, txt_code.Text.Trim(), txt_qty.Text.Trim(), totamt.ToString(), txt_discount.Text.Trim(), lbl_discountamt.Text.Trim());
                                txt_TotalDisc.Text = getGlobalDiscount().ToString();
                                txt_NetTotal.Text = commonFunctions.GetNetAmountWIthDisc(dataGridView1, "0.00", "0.00", txt_TotalDisc.Text).ToString();
                                txt_Subtotal.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
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


                txt_code.Focus();

            }


        }

        #endregion

        #region getGlobalDiscount

        private decimal getGlobalDiscount() {
            decimal gdisc = decimal.Zero;
            decimal gnet = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {

                    decimal dx = commonFunctions.ToDecimal(drow.Cells["Disc%"].Value.ToString());
                    decimal amt = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString()) * commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                    decimal dic = (amt * dx) / 100;
                    gnet += commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                    gdisc += dic;
                }
            }
            decimal totdisc = (gnet * commonFunctions.ToDecimal(txt_subtotaldisc.Text.Trim())) / 100;
            decimal final =gdisc + totdisc;
            return decimal.Round(final, 4);
        }

        #endregion

        #region Fotter Text Functions

        private void txt_subtotaldisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_TotalDisc.Text = getGlobalDiscount().ToString();
                txt_NetTotal.Text = commonFunctions.GetNetAmountWIthDisc(dataGridView1, "0.00", "0.00", txt_TotalDisc.Text).ToString();
                txt_Subtotal.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
            }
        }

        private void txt_subtotaldisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_additions_KeyDown(object sender, KeyEventArgs e)
        {
            txt_TotalDisc.Text = getGlobalDiscount().ToString();
            txt_NetTotal.Text = commonFunctions.GetNetAmountWIthDisc(dataGridView1, "0.00", "0.00", txt_TotalDisc.Text).ToString();
            txt_Subtotal.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
            txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
        }

        private void txt_additions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_deductions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_deductions_KeyDown(object sender, KeyEventArgs e)
        {
            txt_TotalDisc.Text = getGlobalDiscount().ToString();
            txt_NetTotal.Text = commonFunctions.GetNetAmountWIthDisc(dataGridView1, "0.00", "0.00", txt_TotalDisc.Text).ToString();
            txt_Subtotal.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
            txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
        }

        #endregion

        #region FindExisitingpo

        private void FindExisitingGRN(string GrnNo)
        {
            try
            {
                if (T_OrderFormHeadDL.ExistingT_OrderFormHead(GrnNo.Trim()))
                {
                    formMode = 3;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();
                    dataGridView1.ReadOnly = true;
                    //clear error fields
                    errorProvider1.Clear();

                    T_OrderFormHead cat = new T_OrderFormHead();
                    cat.DocNo = GrnNo.Trim();
                    T_OrderFormHeadDL dl = new T_OrderFormHeadDL();
                    cat = dl.Selectt_OrderFormHead(cat);

                    ////set the process message and mode to edit mode
                    if (cat.Processed == 0)
                    {
                        lbl_processes.Visible = false;
                        performButtons(xEnums.PerformanceType.Edit);
                    }
                    else
                    {
                        lbl_processes.Visible = true;
                        performButtons(xEnums.PerformanceType.Edit);

                    }

                    //load and disable the data fields

                    txt_Locacode.Text = cat.Locacode.Trim();
                    txt_Customer.Text = cat.Customer.Trim();
                    txt_RecivedBy.Text = cat.RecivedBy.Trim();
                    txt_Remarks11.Text = cat.Remarks;
                    dte_date.Value = cat.Datex.Value;
                    dte_RecivedDate.Value = cat.RecivedDate.Value;

                    textareaFunctions(false);

                    T_OrderFormDet req = new T_OrderFormDet();
                    req.Docno = GrnNo.Trim();
                    T_OrderFormDetDL tdl = new T_OrderFormDetDL();
                    List<T_OrderFormDet> requests = new List<T_OrderFormDet>();
                    requests = tdl.SelectT_OrderFormDetMulti(req);

                    foreach (T_OrderFormDet det in requests)
                    {

                        commonFunctions.AddRowDistribute(dtx, det.ItemCode, findExisting.FindExisitingStock(det.ItemCode).Trim(), det.CostPrice.ToString(), det.UnitPrice.ToString(), det.Quntity.ToString(), det.discper.ToString(), det.discount.ToString(), det.Amountx.ToString());
                    }

                    txt_TotalDisc.Text = cat.TotalDisc.ToString();
                    txt_subtotaldisc.Text = cat.DiscountPer.ToString();
                    txt_NetTotal.Text = commonFunctions.GetNetAmountWIthDisc(dataGridView1, "0.00", "0.00", txt_TotalDisc.Text).ToString();
                    txt_Subtotal.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                    txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                    txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();

                    //txt_locaname.Text = cat.Locaname;
                }
                else
                {
                    if (formMode != 1)
                    {
                        lbl_processes.Visible = false;
                        errorProvider1.SetError(txt_DocNo, "Order Form Number you have entered does not exists in the system.");
                    }
                }


            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

        #endregion

        private void PrintDoc(string DocNo)
        {
            try
            {
                string status = "ORIGINAL";
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                //rpt = ReportStrings.PrintDocWithstatus("Customer Order Form","Duplicate");
                rpt = ReportStrings.PrintDocWithstatus("Customer Order Form", status);
                rpt_t_orderform rptBank = new rpt_t_orderform();
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderPrintSTR(DocNo.Trim() , commonFunctions.GlobalLocation)));
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

        private void txt_DocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();

            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_DocNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["OrderFormUSFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["OrderFormUSSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["OrderFormUSField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
            FindExisitingGRN(txt_DocNo.Text.Trim());
        }

        private void txt_Locacode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmb_TRNType.Focus();
            }
        }

        private void cmb_TRNType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();
            }
        }

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                    ApplyDiscMeth();
                    dte_RecivedDate.Focus();
                }


                if (e.KeyCode == Keys.F2)
                {

                    if (ActiveControl.Name.Trim() == txt_Customer.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["CustFieldLength"]);
                        string[] strSearchField = new string[length];

                        string strSQL = ConfigurationManager.AppSettings["CustSQL"].ToString() + " WHERE SalesMan = '" +txt_RecivedBy.Text.Trim().ToUpper()+ "'";

                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["CustField" + m + ""].ToString();
                        }

                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }

                    txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                }

                if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() != "<Error!!!>".Trim())
                {
                    M_Customers cusx = new M_Customers();
                    cusx.CusID = txt_Customer.Text.Trim();
                    cusx = new M_CustomerDL().Selectm_Customer(cusx);
                    txt_subtotaldisc.Text = cusx.ApplyingDisc.ToString();
                    txt_os.Text = cusx.customerOS.ToString();

                    dataGridView2.DataSource = T_OrderFormHeadDL.GetInvoiceDetails(txt_Customer.Text.Trim());
                    dataGridView2.Columns[0].Width = 120;
                    dataGridView2.Columns[1].Width = 120;
                    dataGridView2.Columns[2].Width = 120;
                    dataGridView2.Columns[3].Width = 120;
                    dataGridView2.Refresh();



                    dataGridView3.DataSource = T_OrderFormHeadDL.GetCreditNoteItems(txt_Customer.Text.Trim());
                    dataGridView3.Columns[0].Width = 120;
                    dataGridView3.Columns[1].Width = 120;
                    dataGridView3.Columns[2].Width = 120;
                    dataGridView3.Columns[3].Width = 120;
                    dataGridView3.Refresh();




                }
                else
                {
                    txt_subtotaldisc.Text = ConfigurationManager.AppSettings["DefaultDiscRate"].ToString();
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }


        }

        private void txt_RecivedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_RecivedDate.Focus();
            }
            //if (e.KeyCode == Keys.F2)
            //{

            //    if (ActiveControl.Name.Trim() == txt_RecivedBy.Name.Trim())
            //    {
            //        int length = Convert.ToInt32(ConfigurationManager.AppSettings["SalesmanFieldLength"]);
            //        string[] strSearchField = new string[length];

            //        string strSQL = ConfigurationManager.AppSettings["SalesmanSQL"].ToString();

            //        for (int i = 0; i < length; i++)
            //        {
            //            string m;
            //            m = i.ToString();
            //            strSearchField[i] = ConfigurationManager.AppSettings["SalesmanField" + m + ""].ToString();
            //        }

            //        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
            //        find.ShowDialog(this);
            //    }

            //    txt_RecivedBy_name.Text = findExisting.FindExisitingSalesman(txt_RecivedBy.Text);
            //}
        }

        private void dte_RecivedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Remarks11.Focus();
            }
        }

        private void txt_Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
            }
        }

        private void btn_Invoices_Click(object sender, EventArgs e)
        {
            pnl_invoicedet.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_invoicedet.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnl_credinote.Visible = false;
        }

        private void btn_cndet_Click(object sender, EventArgs e)
        {
            pnl_credinote.Visible = true;
        }

        private void txt_Locacode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnl_cheque.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnl_cheque.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Customer.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() == "<Error!!!>".Trim())
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                DataTable dt3 = new DataTable();
                string str = "SELECT     dbo.T_RecDet.Docno AS [Receipt No], dbo.T_RecDet.Paytype, dbo.T_RecDet.CQno AS [Cheque No], dbo.T_RecDet.Bank, dbo.M_Bank.BANK_NAME AS [Bank Name],dbo.T_RecDet.BankBranch AS Branch, dbo.T_RecDet.BankDate AS [Bank Date], dbo.T_RecDet.isReconsile AS Reconsiled,dbo.T_RecDet.ReconsileDate AS [Rec Date] " +
                             "FROM         dbo.T_RecDet INNER JOIN dbo.M_Bank ON dbo.T_RecDet.Bank = dbo.M_Bank.BANK_CODE WHERE     (dbo.T_RecDet.Paytype = 'CQ') AND dbo.T_RecDet.customer = '" + txt_Customer.Text.Trim() + "'";
                dt3 = commonFunctions.GetDatatable(str);
                dte_cheques.DataSource = dt3;
                dte_cheques.Columns[0].Width = 100;
                dte_cheques.Columns[1].Width = 90;
                dte_cheques.Columns[2].Width = 100;
                dte_cheques.Columns[3].Width = 60;
                dte_cheques.Columns[4].Width = 160;
                dte_cheques.Columns[5].Width = 60;
                dte_cheques.Refresh();


            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Customer.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() == "<Error!!!>".Trim())
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                DataTable dt3 = new DataTable();
                string str = "SELECT     dbo.T_RecDet.Docno AS [Receipt No], dbo.T_RecDet.Paytype, dbo.T_RecDet.CQno AS [Cheque No], dbo.T_RecDet.Bank, dbo.M_Bank.BANK_NAME AS [Bank Name],dbo.T_RecDet.BankBranch AS Branch, dbo.T_RecDet.BankDate AS [Bank Date], dbo.T_RecDet.isReconsile AS Reconsiled,dbo.T_RecDet.ReconsileDate AS [Rec Date] " +
                             "FROM         dbo.T_RecDet INNER JOIN dbo.M_Bank ON dbo.T_RecDet.Bank = dbo.M_Bank.BANK_CODE WHERE     (dbo.T_RecDet.Paytype = 'CQ') AND dbo.T_RecDet.customer = '" + txt_Customer.Text.Trim() + "' AND isReconsile = 0";
                dt3 = commonFunctions.GetDatatable(str);
                dte_cheques.DataSource = dt3;
                dte_cheques.Columns[0].Width = 100;
                dte_cheques.Columns[1].Width = 90;
                dte_cheques.Columns[2].Width = 100;
                dte_cheques.Columns[3].Width = 60;
                dte_cheques.Columns[4].Width = 160;
                dte_cheques.Columns[5].Width = 60;
                dte_cheques.Refresh();


            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

        private void txt_Remarks11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
            }
        }

        private void cmb_TRNType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_RecivedBy_TextChanged(object sender, EventArgs e)
        {
            txt_RecivedBy_name.Text = findExisting.FindExisitingUSer(txt_RecivedBy.Text.Trim());
        }

        private void dte_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_RecivedDate.Focus();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadingData();
        }


        private void LoadingData()
        {

            DataTable dt3 = new DataTable();

            try
            {

                if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() == "<Error!!!>".Trim())
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                dt3 = T_RecDetDL.GetCQ(txt_Customer.Text.Trim(), rdo_daterange.Checked, rdo_post.Checked, rdo_retured.Checked, rdo_unrealized.Checked, rdo_realized.Checked, dte_to.Value, dte_from.Value);

                dte_cheques.DataSource = dt3;
                dte_cheques.Columns[0].Visible = false;
                dte_cheques.Columns[1].Width = 100;
                dte_cheques.Columns[3].Width = 100;
                dte_cheques.Columns[4].Width = 190;
                dte_cheques.Columns[5].Visible = false;
                dte_cheques.Columns[6].Width = 100;
                dte_cheques.Columns[9].Width = 260;

                dte_cheques.Columns[0].ReadOnly = true;
                dte_cheques.Columns[1].ReadOnly = true;
                dte_cheques.Columns[2].ReadOnly = true;
                dte_cheques.Columns[3].ReadOnly = true;
                dte_cheques.Columns[4].ReadOnly = true;
                dte_cheques.Columns[5].ReadOnly = true;

                dte_cheques.Refresh();




            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }
    }
}
