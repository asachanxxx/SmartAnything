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
    public partial class frm_invoice : Form
    {

        int formMode = 0;
        string formID = "A0019";
        string formHeadertext = "Customer Invoice";
        DataTable dtx = new DataTable();
        DataTable dtxpayment = new DataTable();
        
        bool already = false;
        string gloPaymethod = "CR";
        M_Products gloproduct = new M_Products();
        bool haspaytype = false;

        #region Loading one instance

        private static frm_invoice objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_invoice getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_invoice();

            }
            return objSingleObject;

        }

        #endregion

        public frm_invoice()
        {
            InitializeComponent();
        }

        private void frm_invoice_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            FunctionButtonStatus(xEnums.PerformanceType.Default);
            commonFunctions.HandleTextBoxesInTransactions(panel3);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

            ApplyRecallMethod();
            //LoadPaymeth();
            txt_paymeth.SelectedIndex = 0;
            dtx = commonFunctions.CreateDatatableDIstribution();
            dtxpayment = commonFunctions.CreateDatatableINV();
            dataGridView1.DataSource = dtx;
           

            commonFunctions.FormatDataGrid(dataGridView1);
            

            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[4].Width = 86;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 100;
            txt_code.Focus();

            //cmb_paymeth.SelectedIndex = 0;
            txt_Locacode.Text = commonFunctions.GlobalLocation;
            txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
            txt_subtotaldiscper.Text = commonFunctions.GloinvoiceDiscrate.ToString();
        }

        private void ApplyRecallMethod()
        {
            string discmeth = ConfigurationManager.AppSettings["RecallMethod"].ToString();
            switch (discmeth.Trim())
            {
                case "RO":
                    panel1.Enabled = false;
                    lbl_processes.Visible = true;
                    lbl_processes.Text = "Recall Only".ToUpper();
                    break;
                case "RN":
                    panel1.Enabled = true;
                    lbl_processes.Visible = false;
                    break;
            }
        }

        private void LoadPaymeth()
        {
            DataTable dt = commonFunctions.GetDatatable("SELECT  description as 'des' FROM m_paymode WHERE isActive = 1 AND isSubPaymode = 0 UNION SELECT  sub_payModeCode FROM m_payModeDetails WHERE isActive = 1");
            if (dt.Rows.Count > 0)
            {
                haspaytype = true;
                foreach (DataRow drow in dt.Rows)
                {
                    txt_paymeth.Items.Add(drow["des"]);
                }
                txt_paymeth.SelectedIndex = 0;
            }
            else {
                haspaytype = false;
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
                        if (ActiveControl.Name.Trim() == txt_InvID.Name.Trim())
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
                        txt_InvID.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_InvID.Focus();

                        txt_Locacode.Text = commonFunctions.GlobalLocation;
                        txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
                        textareaFunctions(true);
                        errorProvider1.Clear();

                        lbl_processes.Visible = false;
                        break;

                    case xEnums.PerformanceType.Edit:
                        //FunctionButtonStatus(xEnums.PerformanceType.Edit);
                        formMode = 3;
                        //txt_VehicleID.Enabled = false;
                        //txt_VehicleNo.Focus();
                        if (T_InvoiceHedDL.ExistingT_InvoiceHed(txt_InvID.Text.Trim()))
                        {
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Cancel, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                T_InvoiceHed objt_trnsferNote = new T_InvoiceHed();
                                objt_trnsferNote.InvID = txt_InvID.Text.Trim();
                                objt_trnsferNote = new T_InvoiceHedDL().Selectt_InvoiceHed(objt_trnsferNote);
                                objt_trnsferNote.Iscancelled = true;
                                objt_trnsferNote.CancelledUSer = commonFunctions.Loginuser;
                                objt_trnsferNote.CancelledDate = DateTime.Now;
                                new T_InvoiceHedDL().Savet_InvoiceHedSP(objt_trnsferNote, 3);
                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                            }
                        }
                        errorProvider1.Clear();
                        break;

                    case xEnums.PerformanceType.Save:
                        errorProvider1.Clear();
                        if (formMode == 1)
                        {


                            if (commonFunctions.ToDecimal(txt_creditperiod.Text.Trim()) < 1)
                            {
                                errorProvider1.SetError(txt_creditperiod, "Credit period must be not less than zero");
                                return;
                            }

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
                            if (commonFunctions.GetNoofItems(dataGridView1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                return;
                            }

                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {
                                    //u_DBConnection.BeginTrans();

                                    using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                    {
                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                T_InvoiceDet objt_InvoiceDet = new T_InvoiceDet();
                                                objt_InvoiceDet.InvNo = txt_InvID.Text.Trim();
                                                objt_InvoiceDet.ItemCode = drow.Cells["Product Code"].Value.ToString();
                                                objt_InvoiceDet.CostPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                objt_InvoiceDet.SellingPrice = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                                objt_InvoiceDet.Qty = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_InvoiceDet.Unitx = "PCS";
                                                objt_InvoiceDet.DiscountPer = commonFunctions.ToDecimal(drow.Cells["Disc%"].Value.ToString());
                                                objt_InvoiceDet.Discount = commonFunctions.ToDecimal(drow.Cells["Disc Amt"].Value.ToString());
                                                objt_InvoiceDet.Total = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                T_InvoiceDetDL bal2 = new T_InvoiceDetDL();
                                                bal2.Savet_InvoiceDetSP(objt_InvoiceDet, 1);

                                            }

                                        }


                                        //save header data
                                        T_InvoiceHed objt_InvoiceHed = new T_InvoiceHed();
                                        objt_InvoiceHed.InvID = txt_InvID.Text.Trim();
                                        objt_InvoiceHed.CompCode = commonFunctions.GlobalCompany;
                                        objt_InvoiceHed.LocaCode = commonFunctions.GlobalLocation;
                                        objt_InvoiceHed.Customer = txt_Customer.Text.Trim();
                                        objt_InvoiceHed.Paymeth = gloPaymethod;
                                        objt_InvoiceHed.RefNo = txt_RefNo.Text.Trim();
                                        objt_InvoiceHed.ManualNo = txt_ManualNo.Text.Trim();
                                        objt_InvoiceHed.OrderFormNo = txt_OrderFormNo.Text.Trim();
                                        objt_InvoiceHed.DONumber = "";
                                        objt_InvoiceHed.GrossAmt = commonFunctions.ToDecimal(txt_GrossAmt.Text.Trim());
                                        objt_InvoiceHed.SubtotaldiscPer = commonFunctions.ToDecimal(txt_subtotaldiscper.Text.Trim());
                                        objt_InvoiceHed.SubtotalDisc = commonFunctions.ToDecimal(txt_subtotaldiscamt.Text.Trim());
                                        objt_InvoiceHed.ItemdiscTotal = commonFunctions.ToDecimal(txt_ItemdiscTotal.Text.Trim());
                                        objt_InvoiceHed.TotalDisc = commonFunctions.ToDecimal(txt_TotalDiscount.Text.Trim());
                                        objt_InvoiceHed.CreditPeriod = commonFunctions.ToDecimal(txt_creditperiod.Text.ToString());
                                        objt_InvoiceHed.Tax = commonFunctions.ToDecimal(txt_Tax.Text.Trim());
                                        objt_InvoiceHed.Vatamt = commonFunctions.ToDecimal(txt_Vatamt.Text.Trim());
                                        objt_InvoiceHed.NetAmt = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                                        objt_InvoiceHed.Noofitems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                        objt_InvoiceHed.NoOfPieces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                        objt_InvoiceHed.Datex = dte_date.Value;
                                        objt_InvoiceHed.PrerairedBy = commonFunctions.Loginuser;
                                        objt_InvoiceHed.Checked = 0;
                                        objt_InvoiceHed.CheckedBy = "";
                                        objt_InvoiceHed.Approved = 0;
                                        objt_InvoiceHed.AprrovedBy = "";
                                        objt_InvoiceHed.ApprovedDate = DateTime.Now;
                                        objt_InvoiceHed.Remarks = txt_Remarks.Text.Trim();
                                        objt_InvoiceHed.CQNO = txt_CQNO.Text.Trim();
                                        objt_InvoiceHed.CQDate = dte_CQDate.Value.Date;
                                        objt_InvoiceHed.BANK = txt_BANK.Text.Trim();
                                        objt_InvoiceHed.BRANCH = txt_BRANCH.Text.Trim();
                                        objt_InvoiceHed.Processed = 0;
                                        objt_InvoiceHed.ProcessedDate = DateTime.Now;
                                        objt_InvoiceHed.ProcessedUser = "";
                                        objt_InvoiceHed.Glupdated = false;
                                        objt_InvoiceHed.MultipleDO = 0;
                                        objt_InvoiceHed.DueAmt = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                                        objt_InvoiceHed.PaidAmt = decimal.Zero;
                                        objt_InvoiceHed.IsSettled = false;
                                        objt_InvoiceHed.Iscancelled = false;
                                        objt_InvoiceHed.CancelledDate = DateTime.Now;
                                        objt_InvoiceHed.CancelledUSer = "";
                                        T_InvoiceHedDL bal = new T_InvoiceHedDL();
                                        bal.Savet_InvoiceHedSP(objt_InvoiceHed, 1);

                                        //increment the serial
                                        commonFunctions.IncrementSerial(formID);
                                        //u_DBConnection.CommitTrans();
                                        transaction.Complete();
                                    }
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());



                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {

                                        using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                        {
                                            UpdateProcess();
                                            transaction.Complete();
                                        }
                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                        T_InvoiceHed objt_trnsferNote = new T_InvoiceHed();
                                        objt_trnsferNote.InvID = txt_InvID.Text.Trim();
                                        objt_trnsferNote = new T_InvoiceHedDL().Selectt_InvoiceHed(objt_trnsferNote);


                                        if (objt_trnsferNote.Processed == 1)
                                        {
                                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                               
                                                PrintDoc(txt_InvID.Text.Trim(),"001" , "Head Office");
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // u_DBConnection.RollbackTrans();
                                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                    commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                                }

                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();
                                dataGridView1.ReadOnly = false;
                                //clear text fields
                                textareaFunctions(true);

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_InvID.Text = commonFunctions.GetSerial(formID.Trim());
                                txt_Customer.Focus();
                            }
                        }
                        else if (formMode == 3)
                        {
                            T_InvoiceHed objt_trnsferNote = new T_InvoiceHed();
                            objt_trnsferNote.InvID = txt_InvID.Text.Trim();
                            objt_trnsferNote = new T_InvoiceHedDL().Selectt_InvoiceHed(objt_trnsferNote);

                            if (objt_trnsferNote != null)
                            {

                                if (objt_trnsferNote.Processed == 0)
                                {
                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {

                                        using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                        {

                                            T_InvoiceHed objt_InvoiceHed = new T_InvoiceHed();
                                            objt_InvoiceHed.InvID = txt_InvID.Text.Trim();
                                            T_InvoiceHedDL invbalhed = new T_InvoiceHedDL();
                                            objt_InvoiceHed = invbalhed.Selectt_InvoiceHed(objt_InvoiceHed);

                                            objt_InvoiceHed.GrossAmt = commonFunctions.ToDecimal(txt_GrossAmt.Text.Trim());
                                            objt_InvoiceHed.SubtotaldiscPer = commonFunctions.ToDecimal(txt_subtotaldiscper.Text.Trim());
                                            objt_InvoiceHed.SubtotalDisc = commonFunctions.ToDecimal(txt_subtotaldiscamt.Text.Trim());
                                            objt_InvoiceHed.ItemdiscTotal = commonFunctions.ToDecimal(txt_ItemdiscTotal.Text.Trim());
                                            objt_InvoiceHed.TotalDisc = commonFunctions.ToDecimal(txt_TotalDiscount.Text.Trim());
                                            objt_InvoiceHed.CreditPeriod = commonFunctions.ToDecimal(txt_creditperiod.ToString());
                                            objt_InvoiceHed.Tax = commonFunctions.ToDecimal(txt_Tax.Text.Trim());
                                            objt_InvoiceHed.Vatamt = commonFunctions.ToDecimal(txt_Vatamt.Text.Trim());
                                            objt_InvoiceHed.NetAmt = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                                            objt_InvoiceHed.Noofitems = commonFunctions.ToDecimal(txt_noOfItems.Text.Trim());
                                            objt_InvoiceHed.NoOfPieces = commonFunctions.ToDecimal(txt_noOfPeaces.Text.Trim());
                                            T_InvoiceHedDL bal = new T_InvoiceHedDL();
                                            bal.Savet_InvoiceHedSP(objt_InvoiceHed, 3);


                                            T_InvoiceDet objt_OrderFormDet = new T_InvoiceDet();
                                            T_InvoiceDetDL bal2 = new T_InvoiceDetDL();
                                            objt_OrderFormDet.InvNo = txt_InvID.Text;
                                            List<T_InvoiceDet> list = new List<T_InvoiceDet>();
                                            list = bal2.SelectT_InvoiceDetMulti(objt_OrderFormDet);

                                            foreach (T_InvoiceDet detx in list)
                                            {
                                                bal2.Savet_InvoiceDetSP(detx, 4);
                                            }

                                            //save details 
                                            foreach (DataGridViewRow drow in dataGridView1.Rows)
                                            {
                                                if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                                {
                                                    T_InvoiceDet objt_InvoiceDet = new T_InvoiceDet();
                                                    objt_InvoiceDet.InvNo = txt_InvID.Text.Trim();
                                                    objt_InvoiceDet.ItemCode = drow.Cells["Product Code"].Value.ToString();
                                                    objt_InvoiceDet.CostPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                                                    objt_InvoiceDet.SellingPrice = commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                                                    objt_InvoiceDet.Qty = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                    objt_InvoiceDet.Unitx = "PCS";
                                                    objt_InvoiceDet.DiscountPer = commonFunctions.ToDecimal(drow.Cells["Disc%"].Value.ToString());
                                                    objt_InvoiceDet.Discount = commonFunctions.ToDecimal(drow.Cells["Disc Amt"].Value.ToString());
                                                    objt_InvoiceDet.Total = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                    T_InvoiceDetDL bal2det = new T_InvoiceDetDL();
                                                    bal2det.Savet_InvoiceDetSP(objt_InvoiceDet, 1);

                                                }

                                            }
                                            transaction.Complete();
                                        }
                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                            {

                                                UpdateProcess();
                                                transaction.Complete();
                                            }
                                            UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());


                                            if (objt_trnsferNote.Processed == 1)
                                            {
                                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                                {
                                                    PrintDoc(txt_InvID.Text.Trim(), "O1", "Head Office");
                                                }
                                            }
                                        }


                                        //clear data in data grid 
                                        dtx.Rows.Clear();
                                        dataGridView1.Refresh();
                                        dataGridView1.ReadOnly = false;
                                        //clear text fields
                                        textareaFunctions(true);
                                        FunctionButtonStatus(xEnums.PerformanceType.Save);

                                        txt_InvID.Text = commonFunctions.GetSerial(formID.Trim());
                                        txt_code.Focus();
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txt_InvID, "Invoice number you have entered already processed.You cannot changed data now");
                                    commonFunctions.SetMDIStatusMessage("Invoice number you have entered already processed.You cannot changed data now", 1);
                                }
                            }
                            else {
                                performButtons(xEnums.PerformanceType.Cancel);
                                performButtons(xEnums.PerformanceType.New);
                            }
                            txt_OrderFormNo.Text = string.Empty;
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_InvID.Enabled = true;
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
                        if (txt_InvID.Text.Trim() != "")
                        {
                            T_InvoiceHed objt_trnsferNoteS = new T_InvoiceHed();
                            objt_trnsferNoteS.InvID = txt_InvID.Text.Trim();
                            objt_trnsferNoteS = new T_InvoiceHedDL().Selectt_InvoiceHed(objt_trnsferNoteS);
                            if (objt_trnsferNoteS == null)
                            {
                                errorProvider1.SetError(txt_InvID, "Invalid Order form number");
                                commonFunctions.SetMDIStatusMessage("Invalid Order form number", 2);
                                return;
                            }

                            if (objt_trnsferNoteS.Processed == 1)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    PrintDoc(txt_InvID.Text.Trim(),"01", "Head Office");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_InvID, "Delivery Order is not processed");
                                commonFunctions.SetMDIStatusMessage("Delivery Order is not processed", 2);
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_InvID, "Please enter Order form number to print");
                            commonFunctions.SetMDIStatusMessage("Please enter Order form number to print", 2);

                        }
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

        private void PrintDoc(string DocNo,string loca ,string locaname)
        {
            string reporttitle = "Customer Invoice".ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramFields = commonFunctions.AddCrystalParamsWithLoca(reporttitle, commonFunctions.Loginuser.ToUpper(), loca, locaname);

            paramField.Name = "status";
            paramDiscreteValue.Value = "ORIGINAL".ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            rpt_invoicePrint rptBank = new rpt_invoicePrint();
            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetInvoicePrintSTR(DocNo.Trim(), commonFunctions.GlobalLocation)));
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
        }


        private void UpdateProcess()
        {
            
            T_InvoiceHed objt_trnsferNote = new T_InvoiceHed();
            objt_trnsferNote.InvID = txt_InvID.Text.Trim();

            //update the invoice process flag
            objt_trnsferNote = new T_InvoiceHedDL().Selectt_InvoiceHed(objt_trnsferNote);
            objt_trnsferNote.Processed = 1;
            objt_trnsferNote.ProcessedDate = DateTime.Now;
            objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
            new T_InvoiceHedDL().Savet_InvoiceHedSP(objt_trnsferNote, 3);

            //insert payment data
            t_invoice_payment payment = new t_invoice_payment();
            payment.invNo = txt_InvID.Text.Trim();
            payment.location = commonFunctions.GlobalLocation;
            payment.number = "";
            payment.paymodeId = txt_paymeth.Text.Trim();
            payment.subPayMode = "";
            payment.rate = decimal.Zero;
            payment.subPayAmount = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
            payment.teminalId = "";
            payment.totalAmount = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
            payment.voucherNumber = txt_InvID.Text.Trim();
            payment.datex = DateTime.Now;
            new T_invoice_paymentDL().Savet_invoice_paymentSP(payment, 1);



            //update customer outstandings

            M_Customers cus = new M_Customers();
            cus.CusID = txt_Customer.Text.Trim();
            cus = new M_CustomerDL().Selectm_Customer(cus);
            cus.customerOS += commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
            new M_CustomerDL().SaveM_CustomerSP(cus, 3);


            if (!T_CusSettleDL.ExistingT_CusSettle(txt_Customer.Text.Trim()))
            {
                T_CusSettle objt_CusSettle = new T_CusSettle();
                objt_CusSettle.DocNo = commonFunctions.GetSerial("A0061");
                objt_CusSettle.NetAmt = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                objt_CusSettle.Customer = txt_Customer.Text.Trim();
                objt_CusSettle.Type = "CUS";
                objt_CusSettle.RefNo = txt_RefNo.Text.Trim();
                objt_CusSettle.CompCode = commonFunctions.GlobalCompany;
                objt_CusSettle.LocaCode = commonFunctions.GlobalLocation;
                objt_CusSettle.PaidAmt = decimal.Zero;
                objt_CusSettle.DueAmt = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                objt_CusSettle.Settlement = decimal.Zero;
                objt_CusSettle.Datex = DateTime.Now;
                new T_CusSettleDL().Savet_CusSettleSP(objt_CusSettle, 1);
                commonFunctions.IncrementSerial("A0061");
            }
            else {
                T_CusSettle objt_CusSettle = new T_CusSettle();
                objt_CusSettle.Customer = txt_Customer.Text.Trim();
                objt_CusSettle = new T_CusSettleDL().Selectt_CusSettle(objt_CusSettle);
                objt_CusSettle.NetAmt += commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                objt_CusSettle.DueAmt += commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                objt_CusSettle.Datex = DateTime.Now;
                new T_CusSettleDL().Savet_CusSettleSP(objt_CusSettle, 3);
            }



            //update order tracking system's data
            T_OrderTracking track = new T_OrderTracking();
            track.OFNo = objt_trnsferNote.OrderFormNo.Trim();
            track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.OrderNo);
            track.InvCreated = 1;
            track.InvNo = objt_trnsferNote.InvID;
            track.InvAmount = objt_trnsferNote.NetAmt;
            track.InvoiceDate = dte_date.Value;
            new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);


            if (!T_AllocDL.ExistingT_Alloc(txt_Customer.Text.Trim()))
            {
                //add allocation details if not exisits for customer
                T_Alloc objt_Alloc = new T_Alloc();
                objt_Alloc.DocNo = txt_InvID.Text.Trim();
                objt_Alloc.locationId = txt_Locacode.Text.Trim();
                objt_Alloc.Datex = DateTime.Now;
                objt_Alloc.Customer = txt_Customer.Text.Trim();
                objt_Alloc.Type = "";
                objt_Alloc.RefNo = txt_RefNo.Text.Trim();
                objt_Alloc.InvNo = txt_InvID.Text.Trim();
                objt_Alloc.NetAmt = decimal.Zero;
                objt_Alloc.PaidAmt = decimal.Zero;
                objt_Alloc.Dueamt = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                T_AllocDL bal = new T_AllocDL();
                bal.Savet_AllocSP(objt_Alloc, 1);
            }
            else {
                //if exists for the customer update due with netamt
                T_Alloc objt_Alloc = new T_Alloc();
                objt_Alloc.Customer = txt_Customer.Text.Trim();
                objt_Alloc = new T_AllocDL().Selectt_Alloc(objt_Alloc);
                objt_Alloc.Dueamt = objt_Alloc.Dueamt + commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
                new T_AllocDL().Savet_AllocSP(objt_Alloc, 3);

            }



            //when invoice created for a give OF this flag will update
            T_OrderFormHead ofhead = new T_OrderFormHead();
            ofhead.DocNo = objt_trnsferNote.OrderFormNo.Trim();
            ofhead = new T_OrderFormHeadDL().Selectt_OrderFormHead(ofhead);
            ofhead.InvCreated = 1;
            ofhead.InvCreatedDate = DateTime.Now;
            ofhead.INVCreatedUser = commonFunctions.Loginuser;
            new T_OrderFormHeadDL().Savet_OrderFormHeadSP(ofhead, 3);

          

            


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
                        btn_print.Enabled = true;
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

                txt_Remarks.Text = "";
                txt_Customer.Text = "";
                txt_Customer_name.Text = "";
                dte_date.Value = DateTime.Now;
                txt_discount.Text = "0.0000";
                //cmb_paymeth.SelectedIndex = 0;
                dtx.Clear();
                dataGridView1.Refresh();
                txt_ItemdiscTotal.Text = "0.0000";
                txt_GrossAmt.Text = "0.0000";
                txt_TotalDiscount.Text = "0.0000";
                lbl_tax.Text = "0.0000";
                lbl_vat.Text = "0.0000";
                txt_NetAmt.Text = "0.0000";
                txt_noOfPeaces.Text = "0";
                txt_noOfItems.Text = "0";
                txt_Tax.Text = "0.0000";
                txt_Vatamt.Text = "0.0000";
                txt_subtotaldiscper.Text = commonFunctions.GloinvoiceDiscrate.ToString();
                txt_subtotaldiscamt.Text = "0.0000";

                dte_date.Enabled = true;
                txt_Remarks.Enabled = true;
                txt_Locacode.Enabled = true;
                txt_Customer.Enabled = true;
                txt_Customer_name.Enabled = true;
                dataGridView1.Enabled = true;
            }
            else
            {

                //txt_Remarks.Enabled = false;
                txt_Locacode.Enabled = false;
                txt_Customer.Enabled = false;
                txt_Customer_name.Enabled = false;
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

                    string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString();

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
                lbl_available.Text = stk.Stock.ToString();
            }
            catch (Exception ex)
            {
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                throw ex;
            }
        }

        #endregion

        private void txt_payamt_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    decimal totalamt = commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());
            //    decimal commingval = commonFunctions.ToDecimal(txt_payamt.Text.Trim());
                
                
            //    if (remainval >= 0)
            //    {
            //        if (!commonFunctions.IsExistINV(dataGridView2, txt_paymeth_part.Text.Trim()))
            //        {
            //            commonFunctions.AddRowINVPayment(dtxpayment, txt_paymeth_part.Text.Trim(), txt_payamt.Text.Trim(), txt_NetAmt.Text.Trim());
            //        }
            //        else
            //        {

            //        }
            //    }
            //    else
            //    {
            //        errorProvider1.SetError(txt_payamt, "Cumilative value is more than invoice amount");
            //    }
            //    decimal cumilative = commonFunctions.GetCumTotal(dataGridView2);
            //    decimal remainval = totalamt - cumilative;
            //    txt_paycum.Text = remainval.ToString();
            //}
            //save details 
            //foreach (DataGridViewRow drow in dataGridView2.Rows)
            //{
            //    if (drow.Cells["Inv NO"].Value.ToString().Trim() != null)
            //    {
            //        t_invoice_payment payment = new t_invoice_payment();
            //        payment.invNo = drow.Cells["Product Code"].Value.ToString();
            //        payment.location = commonFunctions.GlobalLocation;
            //        payment.number = "";
            //        payment.paymodeId = drow.Cells["PamentType"].Value.ToString();
            //        payment.subPayMode = "";
            //        payment.rate = decimal.Zero; 
            //        payment.subPayAmount = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
            //        payment.teminalId = ""; 
            //        payment.totalAmount = commonFunctions.ToDecimal(drow.Cells["Inv Amount"].Value.ToString());
            //        payment.voucherNumber = drow.Cells["Product Code"].Value.ToString();
            //        payment.datex = DateTime.Now;
            //        new T_invoice_paymentDL().Savet_invoice_paymentSP(payment, 1);
            //    }

            //}
        }


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
            CalculateFooter();
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
            decimal disc = commonFunctions.ToDecimal(txt_discount.Text.Trim());
            if ((disc < gloproduct.MinDisc) || (disc > gloproduct.MaxDisc)) {
                string str = "Discount must be grater than Min Discount of " + gloproduct.MinDisc.ToString() + "% and Less than Max Discount of" + gloproduct.MaxDisc.ToString() + "%";
                errorProvider1.SetError(txt_discount, str);
                return;
            }

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
                                decimal totamt = commonFunctions.ToDecimal(txt_selling.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                decimal discount = (totamt * commonFunctions.ToDecimal(txt_discount.Text.Trim())) / 100;
                                totamt = totamt - discount;
                                lbl_discountamt.Text = discount.ToString();
                                txt_amt.Text = totamt.ToString();
                                commonFunctions.AddRowDistribute(dtx, txt_code.Text, lbl_name.Text.Trim(), txt_cost.Text.Trim(), txt_selling.Text.Trim(), txt_qty.Text.Trim(), txt_discount.Text.Trim(), lbl_discountamt.Text, txt_amt.Text.Trim());
                                CalculateFooter();
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
                                CalculateFooter();
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

        private decimal getGlobalDiscount()
        {
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
            decimal totdisc = (gnet * commonFunctions.ToDecimal(txt_subtotaldiscper.Text.Trim())) / 100;
            decimal final = gdisc + totdisc;
            return decimal.Round(final, 4);
        }

        #endregion

        #region FindExisitingGRN

        private void FindExisitingGRN(string GrnNo)
        {

           if (T_InvoiceHedDL.ExistingT_InvoiceHed(GrnNo.Trim()))
            {
                formMode = 3;
                //clear datagrid
                dtx.Clear();
                dataGridView1.Refresh();

                //clear error fields
                errorProvider1.Clear();

                T_InvoiceHed cat = new T_InvoiceHed();
                cat.InvID = GrnNo.Trim();
                T_InvoiceHedDL dl = new T_InvoiceHedDL();
                cat = dl.Selectt_InvoiceHed(cat);

                ////set the process message and mode to edit mode
                if (cat.Processed == 0)
                {
                    lbl_processes.Visible = false;
                    performButtons(xEnums.PerformanceType.Edit);
                }
                else
                {
                    lbl_processes.Visible = true;
                    lbl_processes.Text = "PROCESSED";

                }

                //load and disable the data fields

                txt_Locacode.Text = cat.LocaCode.Trim();
                txt_Customer.Text = cat.Customer.Trim();
                txt_ManualNo.Text = cat.ManualNo.Trim();
                txt_RefNo.Text = cat.RefNo.Trim();
                txt_Remarks.Text = cat.Remarks;
                dte_date.Value = cat.Datex.Value;
                txt_paymeth.Text = cat.Paymeth.Trim();
                txt_ItemdiscTotal.Text = cat.ItemdiscTotal.ToString();
                txt_GrossAmt.Text = cat.GrossAmt.ToString();
                txt_subtotaldiscper.Text = cat.SubtotaldiscPer.ToString();
                txt_Tax.Text = cat.Tax.ToString();
                txt_Vatamt.Text = cat.Vatamt.ToString();
                txt_noOfPeaces.Text = cat.NoOfPieces.ToString();
                txt_noOfItems.Text = cat.Noofitems.ToString();
                txt_BANK.Text = cat.BANK.ToString();
                txt_CQNO.Text = cat.CQNO.ToString();
                txt_BRANCH.Text = cat.BRANCH.ToString();
                dte_CQDate.Value = cat.CQDate.Value;
                txt_creditperiod.Text = cat.CreditPeriod.ToString();


                textareaFunctions(false);

                T_InvoiceDet req = new T_InvoiceDet();
                req.InvNo = GrnNo.Trim();
                T_InvoiceDetDL tdl = new T_InvoiceDetDL();
                List<T_InvoiceDet> requests = new List<T_InvoiceDet>();
                requests = tdl.SelectT_InvoiceDetMulti(req);

                foreach (T_InvoiceDet det in requests)
                {

                    commonFunctions.AddRowDistribute(dtx, det.ItemCode, findExisting.FindExisitingStock(det.ItemCode).Trim(), det.CostPrice.ToString(), det.SellingPrice.ToString(), det.Qty.ToString(), det.DiscountPer.ToString(), det.Discount.ToString(), det.Total.ToString());
                }

                CalculateFooter();
            }
            else
            {
                if (formMode != 1)
                {
                    lbl_processes.Visible = false;
                    errorProvider1.SetError(txt_InvID, "Invoice Number you have entered does not exists in the system.");
                    commonFunctions.SetMDIStatusMessage("Invoice Number you have entered does not exists in the system.", 1);
                }
            }
        }

        #endregion

        private void txt_InvID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Locacode.Focus();
                FindExisitingGRN(txt_InvID.Text.Trim());
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_InvID.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["InvoiceFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["InvoiceSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["InvoiceField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
                FindExisitingGRN(txt_InvID.Text.Trim());
            }
            
        }

        private void txt_Locacode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_paymeth.Focus();
            }
        }

        private void cmb_paymeth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();
            }
        }

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_Remarks.Focus();
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_Customer.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CustFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CustSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CustField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }

            M_Customers cus = new M_Customers();
            M_CustomerDL cusdl = new M_CustomerDL();
            cus.CusID = txt_Customer.Text.Trim();
            cus = cusdl.Selectm_Customer(cus);
            if (cus != null)
            {
                if (cus.CreditPeriod > 0)
                {
                    txt_creditperiod.Text = cus.CreditPeriod.ToString();
                }
                else
                {
                    txt_creditperiod.Text = commonFunctions.Glodreditperiod.ToString();
                }
            }
            else
            {
                txt_creditperiod.Text = commonFunctions.Glodreditperiod.ToString();
            }
        }

        private void txt_Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                txt_RefNo.Focus();
            }
        }

        private void txt_RefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ManualNo.Focus();
            }
        }

        private void txt_ManualNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
            }
        }

        private void txt_subtotaldiscper_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateFooter();
            }
        }

        private void txt_Tax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateFooter();
            }
        }

        private void txt_Vatamt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateFooter();
            }
        }

        private void CalculateFooter() {
            decimal Subtotal = decimal.Zero;
            decimal Gross = decimal.Zero;
            decimal itemdisctotal = decimal.Zero;
            decimal subtotaldisc = decimal.Zero;
            decimal Totaldisc = decimal.Zero;
            decimal tax = decimal.Zero;
            decimal vat = decimal.Zero;
            decimal net = decimal.Zero;

            Subtotal = commonFunctions.GetGrossAmount(dataGridView1);

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {

                    decimal dx = commonFunctions.ToDecimal(drow.Cells["Disc%"].Value.ToString());
                    decimal amt = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString()) * commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                    itemdisctotal += (amt * dx) / 100;
                }
            }
            Gross = Subtotal - itemdisctotal;
            subtotaldisc = (Gross * commonFunctions.ToDecimal(txt_subtotaldiscper.Text.Trim())) / 100;
            Totaldisc = subtotaldisc + itemdisctotal;
            vat = (Gross * commonFunctions.ToDecimal(txt_Vatamt.Text.Trim())) / 100;
            tax = (Gross * commonFunctions.ToDecimal(txt_Tax.Text.Trim())) / 100;
            net = (Gross + vat + tax) - Totaldisc;

            txt_ItemdiscTotal.Text = decimal.Round(itemdisctotal,4).ToString();
            txt_subtotaldiscamt.Text = decimal.Round(subtotaldisc, 4).ToString();
            txt_GrossAmt.Text = decimal.Round(Gross, 4).ToString();
            txt_TotalDiscount.Text = decimal.Round(Totaldisc, 4).ToString();
            lbl_tax.Text = decimal.Round(tax, 4).ToString();
            lbl_vat.Text = decimal.Round(vat, 4).ToString();
            txt_NetAmt.Text = decimal.Round(net, 4).ToString();
            txt_noOfPeaces.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
            txt_noOfItems.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
            

        }
        //private string getpaymethFull(string code) {
        //    string str = string.Empty;
        //    switch(code){
        //        case "CR":
        //            str = "CR-[Credit]";
        //            break;
        //        case "CS":
        //            str = "CS-[Cash]";
        //            break;
        //        case "CQ":
        //            str = "CQ-[Cheques]";
        //            break;
        //        case "CU":
        //            str = "CU-[Coupon]";
        //            break;
        //        case "CC":
        //            str = "CC-[Credit Cards]";
        //            break;
        //        case "OT":
        //            str = "OT-[OtherTypes]";
        //            break;
        //    }
           
        //    return str;
        //}

        private void txt_subtotaldiscper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_Tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_Vatamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_creditperiod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_BANK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txt_BRANCH.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_BANK.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["BankFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["BankSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["BankField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }

            lbl_bank.Text = findExisting.FindExisitingBank(txt_BANK.Text);
        }

        private void txt_BRANCH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_CQNO.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_BRANCH.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["BankBranchFieldLength"]);
                    string[] strSearchField = new string[length];

                    //string strSQL = ConfigurationManager.AppSettings["BankSQL"].ToString();
                    string strSQL = "SELECT  M_BankBranch.BBRANCH_CODE,M_BankBranch.BBRANCH_NAME FROM    M_Bank INNER JOIN M_BankBranch ON M_Bank.BANK_CODE = M_BankBranch.BBRANCH_BANK WHERE M_Bank.BANK_CODE = '" + txt_BANK.Text.Trim() + "'";
                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["BankBranchField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
            lbl_branch.Text = findExisting.FindExisitingBankBranch(txt_BANK.Text.Trim(),txt_BRANCH.Text.Trim());
        }

        private void txt_CQNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_CQDate.Focus();
            }
        }

        private void dte_CQDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
            }
        }

        private void txt_OrderFormNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_OrderFormNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["OrderFormProcessedUSFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["OrderFormProcessedUSSQL"].ToString() + " AND Locacode = '" +commonFunctions.GlobalLocation.Trim() +"'";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["OrderFormProcessedUSField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingOF(txt_OrderFormNo.Text.Trim());
            }
            FindExisitingOF(txt_OrderFormNo.Text.Trim());
        }



        #region FindExisitingOF

        private void FindExisitingOF(string GrnNo)
        {
           
            if (T_OrderFormHeadDL.ExistingT_OrderFormHead(GrnNo.Trim()))
            {
                formMode = 1;
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

                if (cat.InvCreated == 1)
                {
                    errorProvider1.SetError(txt_OrderFormNo, "Invoice has already been created for the Order Form .");
                    commonFunctions.SetMDIStatusMessage("Invoice has already been created for the Order Form .", 1);
                    return;
                }

                
                ////set the process message and mode to edit mode
                //if (cat.Processed == 0)
                //{
                //    //lbl_processes.Visible = false;
                //    performButtons(xEnums.PerformanceType.Edit);
                //}
                //else
                //{
                //    lbl_processes.Visible = true;


                //}
                
                //load and disable the data fields

                txt_Locacode.Text = cat.Locacode.Trim();
                txt_Customer.Text = cat.Customer.Trim();
                txt_Remarks.Text = cat.Remarks;
                dte_date.Value = cat.Datex.Value;
                txt_subtotaldiscper.Text = cat.SubtotalDisc.ToString();
                txt_BANK.Text = cat.BANK.ToString();
                txt_CQNO.Text = cat.CQNO.ToString();
                txt_BRANCH.Text = cat.BRANCH.ToString();
                dte_CQDate.Value = cat.CQDate.Value;
                txt_creditperiod.Text = commonFunctions.Glodreditperiod.ToString();
                txt_subtotaldiscper.Text = cat.DiscountPer.ToString();

                textareaFunctions(false);

                T_OrderFormDet req = new T_OrderFormDet();
                req.Docno = GrnNo.Trim();
                T_OrderFormDetDL tdl = new T_OrderFormDetDL();
                List<T_OrderFormDet> requests = new List<T_OrderFormDet>();
                requests = tdl.SelectT_OrderFormDetMulti(req);

                foreach (T_OrderFormDet det in requests)
                {

                    commonFunctions.AddRowDistribute(dtx, det.ItemCode, T_StockDL.Get_ProductName(det.ItemCode,commonFunctions.GlobalCompany,commonFunctions.GlobalLocation).Trim(), det.CostPrice.ToString(), det.UnitPrice.ToString(), det.Quntity.ToString(), det.discper.ToString(), det.discount.ToString(), det.Amountx.ToString());
                }

                CalculateFooter();
            }
            else
            {
                if (formMode != 1)
                {
                    lbl_processes.Visible = false;
                    errorProvider1.SetError(txt_OrderFormNo, "Order Form Number you have entered does not exists in the system.");
                }
            }
        }

        #endregion

        private void frm_invoice_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txt_InvID_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void txt_paymeth_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();
                //txt_paymeth_name.Text = findExisting.FindExisitingPaytype(txt_paymeth.Text.Trim());
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_paymeth.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["PayTypeFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["PayTypeSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["PayTypeField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
            //txt_paymeth_name.Text = findExisting.FindExisitingPaytype(txt_paymeth.Text.Trim());

        }

        private void txt_NetAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_partpayment_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_payamt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim());
        }

        private void txt_paymeth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //CS (Cash)
                if (txt_paymeth.SelectedIndex == 0)
                {
                    lbltransDesc.Text = "Credit";
                }
                //CQ (Cheque)
                else if (txt_paymeth.SelectedIndex == 1)
                {
                    lbltransDesc.Text = "Cash";
                }
                //DR (DR)
                else if (txt_paymeth.SelectedIndex == 2)
                {
                    lbltransDesc.Text = "Cheque";
                }
                //DR (DR)
                else if (txt_paymeth.SelectedIndex == 3)
                {
                    lbltransDesc.Text = "DIrect";
                }
                txt_paymeth.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void txt_paymeth_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txt_Customer.Focus();
            }
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
           
        }

      
    }
}

