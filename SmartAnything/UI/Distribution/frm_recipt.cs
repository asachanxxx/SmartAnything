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
    public partial class frm_recipt : Form
    {
        int formMode = 0;
        string formID = "A0058";
        string formHeadertext = "receipt voucher";
        DataTable dtx = new DataTable();
        DataTable dtxsettlement = new DataTable();

        bool already = false;
        string gloPaymethod = "CR";
        M_Products gloproduct = new M_Products();
        bool haspaytype = false;

        #region Loading one instance

        private static frm_recipt objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_recipt getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_recipt();

            }
            return objSingleObject;

        }

        #endregion

        public frm_recipt()
        {
            InitializeComponent();
        }

        private void frm_recipt_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

                //ApplyRecallMethod();

                dtx = commonFunctions.CreateDatatableRecipt();
                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 110;
                dataGridView1.Columns[3].Width = 110;

                dtxsettlement = commonFunctions.CreateDatatableSettlement();
                dataGridView2.DataSource = dtxsettlement;
                commonFunctions.FormatDataGrid(dataGridView2);

                dataGridView2.Columns[1].Width = 90;
                dataGridView2.Columns[2].Width = 90;
                dataGridView2.Columns[3].Width = 95;
                dataGridView2.Columns[0].ReadOnly= true;
                dataGridView2.Columns[1].ReadOnly = true;
                dataGridView2.Columns[2].ReadOnly = true;
                dataGridView2.Columns[3].ReadOnly = true;


                txt_code.Focus();
                txt_Locacode.Text = commonFunctions.GlobalLocation;
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

        public void Loadinvoices()
        {
            try
            {
                dtxsettlement.Clear();
                dataGridView2.Refresh();
                if (txt_Customer.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_amt, "Please enter customer");
                    commonFunctions.SetMDIStatusMessage("Please enter customer", 1);
                    return;
                }

                List<T_InvoiceHed> heads = new List<T_InvoiceHed>();
                heads = new T_InvoiceHedDL().SelectT_InvoiceHedMulti(txt_Customer.Text.Trim());
                if (heads.Count == 0)
                {
                    panel1.Enabled = true;
                    errorProvider1.SetError(txt_amt, "Advance Payment not allowed.");
                    commonFunctions.SetMDIStatusMessage("Advance Payment not allowed.", 1);
                }
                else
                {
                    panel1.Enabled = true;
                    foreach (T_InvoiceHed head in heads)
                    {
                        commonFunctions.AddRowLoadInvoices(dtxsettlement, head.InvID, head.DueAmt.ToString(), head.PaidAmt.ToString(), head.NetAmt.ToString(), "0.00");
                    }
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
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
                        if (ActiveControl.Name.Trim() == txt_recno.Name.Trim())
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
                        txt_recno.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_recno.Focus();

                        txt_Locacode.Text = commonFunctions.GlobalLocation;
                        txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
                        textareaFunctions(true);
                        errorProvider1.Clear();

                        lbl_processes.Visible = false;
                        break;

                    case xEnums.PerformanceType.Edit:
                        FunctionButtonStatus(xEnums.PerformanceType.Edit);
                        formMode = 3;
                            T_RecHed objt_RecHed1 = new T_RecHed();
                            objt_RecHed1.Docno = txt_recno.Text.Trim();
                            objt_RecHed1 = new T_RecHedDL().Selectt_RecHed(objt_RecHed1);
                            if (objt_RecHed1 == null || objt_RecHed1.Docno == "")
                            {
                                errorProvider1.SetError(txt_recno, "Invalid Voucher Number ");
                                commonFunctions.SetMDIStatusMessage("Invalid Voucher Number", 1);
                                return;

                            }
                            if (objt_RecHed1.isProcessed.Value == false)
                            {
                                errorProvider1.SetError(txt_recno, "Voucher is not processed ");
                                commonFunctions.SetMDIStatusMessage("Voucher is not processed", 1);
                                return;
                            }
                            if (objt_RecHed1.iscancelled.Value == true)
                            {
                                errorProvider1.SetError(txt_recno, "Voucher already cancelled ");
                                commonFunctions.SetMDIStatusMessage("Voucher already cancelled ", 1);
                                return;
                            }
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Cancel, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                objt_RecHed1.iscancelled = true;
                                objt_RecHed1.CancelledUser = commonFunctions.Loginuser;
                                objt_RecHed1.CancelledDate = DateTime.Now;
                            }
                        errorProvider1.Clear();
                        break;

                    case xEnums.PerformanceType.Save:
                        errorProvider1.Clear();

                        if (!M_CustomerDL.ExistingM_Customer(txt_Customer.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_Customer, "Customer does not exists on the system ");
                            commonFunctions.SetMDIStatusMessage("Customer does not exists on the system ", 1);
                            txt_Customer.Focus();
                            return;
                        }
                        if (commonFunctions.ToDecimal(txt_totamount.Text.Trim()) < 1)
                        {
                            errorProvider1.SetError(txt_totamount, "Total amount must be not less than zero");
                            commonFunctions.SetMDIStatusMessage("Total amount must be not less than zero", 1);
                            txt_totamount.Focus();
                            return;
                        }
                        if (!M_LocaDL.ExistingM_Loca(txt_Locacode.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_Locacode, "Location does not exists on the system ");
                            commonFunctions.SetMDIStatusMessage("Location does not exists on the system ", 1);
                            return;
                        }
                        if (commonFunctions.ToDecimal(txt_totamount.Text.Trim()) != commonFunctions.ToDecimal(txt_gross.Text.Trim()))
                        {
                            errorProvider1.SetError(dataGridView1, "Breakdown not complete. gross amount must equal to the");
                            commonFunctions.SetMDIStatusMessage("Breakdown not complete. gross amount must equal to the", 1);
                            txt_code.Focus();
                            return;
                        }

                        if (commonFunctions.ToDecimal(txt_totamount.Text.Trim()) != commonFunctions.ToDecimal(txt_settlementtot.Text.Trim()))
                        {
                            errorProvider1.SetError(dataGridView2, "Full receipt amount must taly to settllement amount");
                            commonFunctions.SetMDIStatusMessage("Full receipt amount must taly to settllement amount ", 1);
                            dataGridView2.Focus();
                            return;
                        }
                        if (formMode == 1)
                        {

                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {
                                    //u_DBConnection.BeginTrans();

                                    using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                    {
                                        //save details 

                                        int x = 0;
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Type"].Value.ToString().Trim() != null)
                                            {
                                                T_RecDet objt_RecDet = new T_RecDet();
                                                objt_RecDet.Docno = txt_recno.Text.Trim();
                                                objt_RecDet.locationId = commonFunctions.GlobalLocation;
                                                objt_RecDet.Sequence = x;
                                                objt_RecDet.Paytype = drow.Cells["Type"].Value.ToString();
                                                objt_RecDet.HeadAmt = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                                                objt_RecDet.Amt = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                objt_RecDet.InvNo = "";
                                                objt_RecDet.Datex = DateTime.Now;
                                                objt_RecDet.CQno = drow.Cells["CQ No"].Value.ToString();
                                                objt_RecDet.Bank = drow.Cells["Bank"].Value.ToString();
                                                objt_RecDet.BankBranch = drow.Cells["Branch"].Value.ToString();
                                                objt_RecDet.BankDate = DateTime.Parse(drow.Cells["Date"].Value.ToString());
                                                objt_RecDet.isReconsile = false;
                                                objt_RecDet.ReconsileDate = DateTime.Now;
                                                objt_RecDet.Customer = txt_Customer.Text.Trim();
                                                objt_RecDet.isreturned = false;
                                                objt_RecDet.ReturnDate = DateTime.Now;
                                                objt_RecDet.ReturnUpdateUSer = "";
                                                objt_RecDet.ReasontoRtn = "";

                                                new T_RecDetDL().Savet_RecDetSP(objt_RecDet, 1);
                                                x++;
                                            }
                                        }
                                        //save header data
                                        T_RecHed objt_RecHed = new T_RecHed();
                                        objt_RecHed.Docno = txt_recno.Text.Trim();
                                        objt_RecHed.locationId = commonFunctions.GlobalLocation;
                                        objt_RecHed.Datex = DateTime.Now;
                                        objt_RecHed.Customer = txt_Customer.Text.Trim();
                                        objt_RecHed.Status = "";
                                        objt_RecHed.refNo = txt_RefNo.Text.Trim();
                                        objt_RecHed.Memo = txt_memo.Text.Trim();
                                        objt_RecHed.Recivedfrom = txt_recivedfrom.Text.Trim();
                                        objt_RecHed.remarks = txt_Remarks.Text.Trim();
                                        objt_RecHed.Amount = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                                        objt_RecHed.isProcessed = false;
                                        objt_RecHed.processDate = DateTime.Now;
                                        objt_RecHed.processUser = "";
                                        objt_RecHed.isSaved = false;
                                        objt_RecHed.GLUpdate = false;
                                        objt_RecHed.triggerVal = 1;
                                        objt_RecHed.iscancelled = false;
                                        objt_RecHed.CancelledUser = "";
                                        objt_RecHed.CancelledDate = DateTime.Now;
                                        new T_RecHedDL().Savet_RecHedSP(objt_RecHed, 1);

                                        //increment the serial
                                        commonFunctions.IncrementSerial(formID);
                                        //u_DBConnection.CommitTrans();
                                        transaction.Complete();
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
                                    try
                                    {
                                        using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                        {

                                            UpdateProcess();
                                            transaction.Complete();
                                        }

                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                       
                                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                            {

                                                PrintDoc(txt_recno.Text.Trim(), commonFunctions.GlobalLocation, "Head Office");
                                            }
                                       
                                    }
                                    catch (Exception ex)
                                    {
                                        LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                        commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
                                    }
                                }


                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();

                                dtxsettlement.Rows.Clear();
                                dataGridView2.Refresh();

                                //clear text fields
                                textareaFunctions(true);

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_recno.Text = commonFunctions.GetSerial(formID.Trim());
                                txt_Customer.Focus();
                            }
                        }
                        else if (formMode == 3)
                        {
                            T_RecHed objt_RecHed = new T_RecHed();
                            objt_RecHed.Docno = txt_recno.Text.Trim();
                            objt_RecHed = new T_RecHedDL().Selectt_RecHed(objt_RecHed);


                            if (objt_RecHed.isProcessed == false)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                    {

                                        objt_RecHed.Docno = txt_recno.Text.Trim();
                                        objt_RecHed.locationId = txt_Locacode.Text.Trim();
                                        objt_RecHed.Datex = DateTime.Now;
                                        objt_RecHed.Status = "";
                                        objt_RecHed.refNo = txt_RefNo.Text.Trim();
                                        objt_RecHed.Memo = txt_memo.Text.Trim();
                                        objt_RecHed.Recivedfrom = txt_recivedfrom.Text.Trim();
                                        objt_RecHed.remarks = txt_Remarks.Text.Trim();
                                        objt_RecHed.Amount = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                                        objt_RecHed.isProcessed = false;
                                        objt_RecHed.processDate = DateTime.Now;
                                        objt_RecHed.processUser = "";
                                        objt_RecHed.isSaved = false;
                                        objt_RecHed.GLUpdate = false;
                                        objt_RecHed.triggerVal = 1;
                                        objt_RecHed.iscancelled = false;
                                        objt_RecHed.CancelledUser = "";
                                        objt_RecHed.CancelledDate = DateTime.Now;

                                        new T_RecHedDL().Savet_RecHedSP(objt_RecHed, 3);


                                        T_RecDet objt_OrderFormDet = new T_RecDet();
                                        objt_OrderFormDet.Docno = txt_recno.Text;
                                        List<T_RecDet> list = new List<T_RecDet>();
                                        list = new T_RecDetDL().SelectT_RecDetMulti(objt_OrderFormDet);

                                        foreach (T_RecDet detx in list)
                                        {
                                            new T_RecDetDL().Savet_RecDetSP(detx, 4);
                                        }

                                        int x = 0;
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Type"].Value.ToString().Trim() != null)
                                            {
                                                T_RecDet objt_RecDet = new T_RecDet();
                                                objt_RecDet.Docno = txt_recno.Text.Trim();
                                                objt_RecDet.locationId = txt_locationId_name.Text.Trim();
                                                objt_RecDet.Sequence = x;
                                                objt_RecDet.Paytype = drow.Cells["Type"].Value.ToString();
                                                objt_RecDet.HeadAmt = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                                                objt_RecDet.Amt = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                                                objt_RecDet.InvNo = "";
                                                objt_RecDet.Datex = DateTime.Now;
                                                objt_RecDet.CQno = txt_CQNO.Text.Trim();
                                                objt_RecDet.Bank = txt_BANK.Text.Trim();
                                                objt_RecDet.BankBranch = txt_BRANCH.Text.Trim();
                                                objt_RecDet.BankDate = dte_CQDate.Value;
                                                objt_RecDet.isReconsile = false;
                                                objt_RecDet.ReconsileDate = DateTime.Now;
                                                objt_RecDet.Customer = txt_Customer.Text.Trim();
                                                objt_RecDet.isreturned = false;
                                                objt_RecDet.ReturnDate = DateTime.Now;
                                                objt_RecDet.ReturnUpdateUSer = "";
                                                objt_RecDet.ReasontoRtn = "";
                                                new T_RecDetDL().Savet_RecDetSP(objt_RecDet, 1);
                                                x++;
                                            }
                                        }

                                        transaction.Complete();
                                    }
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        try
                                        {
                                            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                            {

                                                UpdateProcess();
                                                transaction.Complete();
                                            }
                                            UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                                        }
                                        catch (Exception ex)
                                        {
                                            LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                            commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
                                        }

                                    }


                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    textareaFunctions(true);
                                    FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    txt_recno.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_code.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_recno, "Invoice number you have entered already processed.You cannot changed data now");
                                commonFunctions.SetMDIStatusMessage("Invoice number you have entered already processed.You cannot changed data now", 1);
                            }
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_recno.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Default);
                        errorProvider1.Clear();
                        //clear text fields
                        textareaFunctions(true);
                        //clear Datagrid
                        dtx.Clear();
                        dataGridView1.Refresh();

                        dtxsettlement.Clear();
                        dataGridView2.Refresh();

                        //txt_supplierId.Text = "";
                        //txt_remarks.Text = "";

                        lbl_processes.Visible = false;

                        break;
                    case xEnums.PerformanceType.Print:
                        if (txt_recno.Text.Trim() != "")
                        {
                            T_RecHed objt_trnsferNoteS = new T_RecHed();
                            objt_trnsferNoteS.Docno = txt_recno.Text.Trim();
                            objt_trnsferNoteS = new T_RecHedDL().Selectt_RecHed(objt_trnsferNoteS);
                            if (objt_trnsferNoteS == null)
                            {
                                errorProvider1.SetError(txt_recno, "Invalid receipt number");
                                commonFunctions.SetMDIStatusMessage("Invalid receipt number", 1);
                                return;
                            }

                            if (objt_trnsferNoteS.isProcessed == true)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    PrintDoc(txt_recno.Text.Trim(), "01", "Head Office");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_recno, "receipt is not processed");
                                commonFunctions.SetMDIStatusMessage("receipt is not processed", 2);
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_recno, "Please enter Order form number to print");
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


        private void PrintDoc(string DocNo, string loca, string locaname)
        {
            string reporttitle = "Receipt Voucher".ToUpper();
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

            rpt_receiptprint rptBank = new rpt_receiptprint();
            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetReceiptSTR(DocNo.Trim())));
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
        }



        private void UpdateProcess()
        {
            T_InvoiceHed rec = new T_InvoiceHed();
            T_Alloc objt_Alloc = new T_Alloc();
            M_Customers cus = new M_Customers();



            foreach (DataGridViewRow drow in dataGridView2.Rows)
            {
                if (drow.Cells["Invoice NO"].Value.ToString().Trim() != null)
                {
                    //commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                    rec.InvID = drow.Cells["Invoice NO"].Value.ToString();
                    rec = new T_InvoiceHedDL().Selectt_InvoiceHed(rec);
                    rec.Processed = 1;
                    rec.ProcessedDate = DateTime.Now;
                    rec.ProcessedUser = commonFunctions.Loginuser;
                    rec.PaidAmt += commonFunctions.ToDecimal(drow.Cells["Settlement"].Value.ToString());
                    rec.DueAmt -= commonFunctions.ToDecimal(drow.Cells["Settlement"].Value.ToString());
                    new T_InvoiceHedDL().Savet_InvoiceHedSP(rec, 3);

                    ////add allocation details if not exisits for customer
                    T_Settlement objt_Settlement = new T_Settlement();
                    objt_Settlement.Reciptno = txt_recno.Text.Trim();
                    objt_Settlement.InvNo = drow.Cells["Invoice NO"].Value.ToString();
                    objt_Settlement.CompCode = commonFunctions.GlobalCompany;
                    objt_Settlement.LocaCode = txt_Locacode.Text.Trim();
                    objt_Settlement.Customer = txt_Customer.Text.Trim();
                    objt_Settlement.InvAmt = commonFunctions.ToDecimal(drow.Cells["Inv Amt"].Value.ToString());
                    objt_Settlement.PaidAmt = commonFunctions.ToDecimal(drow.Cells["Settlement"].Value.ToString());
                    objt_Settlement.DueAmt = commonFunctions.ToDecimal(drow.Cells["Inv Amt"].Value.ToString()) - commonFunctions.ToDecimal(drow.Cells["Settlement"].Value.ToString());
                    objt_Settlement.Settlement = commonFunctions.ToDecimal(drow.Cells["Settlement"].Value.ToString());
                    objt_Settlement.Iscancelled = false;
                    new T_SettlementDL().Savet_SettlementSP(objt_Settlement, 1);

                }
            }

           //if we need a one shot customer os then use this.
            cus.CusID = txt_Customer.Text.Trim();
            cus = new M_CustomerDL().Selectm_Customer(cus);
            cus.customerOS -= commonFunctions.ToDecimal(txt_NetAmt.Text.Trim());

            if (T_CusSettleDL.ExistingT_CusSettle(txt_Customer.Text.Trim()))
            {
                T_CusSettle objt_CusSettle = new T_CusSettle();
                objt_CusSettle.Customer = txt_Customer.Text.Trim();
                objt_CusSettle = new T_CusSettleDL().Selectt_CusSettle(objt_CusSettle);
                objt_CusSettle.DueAmt -= commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                objt_CusSettle.PaidAmt += commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                objt_CusSettle.Datex = DateTime.Now;
                new T_CusSettleDL().Savet_CusSettleSP(objt_CusSettle, 3);
            }
          

            T_RecHed objt_RecHed = new T_RecHed();
            objt_RecHed.Docno = txt_recno.Text.Trim();
            objt_RecHed = new T_RecHedDL().Selectt_RecHed(objt_RecHed);
            objt_RecHed.isProcessed = true;
            objt_RecHed.processDate = DateTime.Now;
            objt_RecHed.processUser = commonFunctions.Loginuser;

            new T_RecHedDL().Savet_RecHedSP(objt_RecHed, 3);
            //new T_AllocDL().Savet_AllocSP(objt_Alloc, 3);
            new M_CustomerDL().SaveM_CustomerSP(cus, 3);

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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                        //btn_edit.Enabled = false;
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
                       // btn_edit.Enabled = false;
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
                txt_ManualNo.Text = "";
                txt_memo.Text = "";
                txt_RefNo.Text = "";
                txt_recivedfrom.Text = "";
                txt_Remarks.Text = "";
                
                dte_date.Value = DateTime.Now;

                dtx.Clear();
                dataGridView1.Refresh();

                txt_totamount.Text = "0.0000";
                txt_NetAmt.Text = "0.0000";
                txt_code.Text = "";
                txt_amt.Text = "0.00";
                txt_remaining.Text = "0.00";

                dte_date.Enabled = true;
                txt_Remarks.Enabled = true;
                txt_Locacode.Enabled = true;
                txt_Customer.Enabled = true;
                txt_Customer_name.Enabled = true;
                dataGridView1.Enabled = true;
            }
            else
            {

                txt_Remarks.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {

                if ((lbl_name.Text.Trim().ToUpper() == "<Error!!!>".ToUpper()) || txt_code.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_code, "Invalied payment method");
                    commonFunctions.SetMDIStatusMessage("Invalied payment method", 1);
                    return;
                }

                M_PayMode pay = new M_PayMode();
                pay.id = txt_code.Text;
                pay = new M_PayModeDL().Selectm_PayMode(pay);
                gloPaymethod = pay.id;
                if (pay.ischeque == 1)
                {
                    txt_BANK.Text = "";
                    txt_BRANCH.Text = "";
                    txt_CQNO.Text = "";
                    panel6.Visible = true;

                }
                else
                {
                    panel6.Visible = false;
                }

                lbl_name.Text = findExisting.FindExisitingPaytype(txt_code.Text);
                txt_BANK.Text = "";
                txt_BRANCH.Text = "";
                txt_CQNO.Text = "";
                txt_amt.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_code.Name.Trim())
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
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            commonFunctions.SetMDIStatusMessage("Ready.", 2);
            lbl_name.Text = findExisting.FindExisitingPaytype(txt_code.Text);
            if ((lbl_name.Text.Trim().ToUpper() == "<Error!!!>".ToUpper()) || txt_code.Text.Trim() == "")
            {
                errorProvider1.SetError(txt_code, "Invalied payment method");
                commonFunctions.SetMDIStatusMessage("Invalied payment method", 1);
                panel6.Visible = false;
                return;
            }

            M_PayMode pay = new M_PayMode();
            pay.id = txt_code.Text;
            pay = new M_PayModeDL().Selectm_PayMode(pay);
            gloPaymethod = pay.id;
            if (pay.ischeque == 1)
            {
                txt_BANK.Text = "";
                txt_BRANCH.Text = "";
                txt_CQNO.Text = "";
                panel6.Visible = true;

            }
            else {
                panel6.Visible = false;
            }

        }

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                txt_recivedfrom.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                Loadinvoices();
                txt_totamount.Focus();
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
        }

        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
            txt_recivedfrom.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
           
        }

        private void txt_InvID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_recno.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ReceiptFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ReceiptSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ReceiptField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingGRN(txt_recno.Text.Trim());
            }
            FindExisitingGRN(txt_recno.Text.Trim());
        }

        #region FindExisitingGRN

        private void FindExisitingGRN(string GrnNo)
        {
            try
            {
                
               if (T_RecHedDL.ExistingT_RecHed(GrnNo.Trim()))
                {
                    formMode = 3;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    dtxsettlement.Clear();
                    dataGridView2.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                    T_RecHed cat = new T_RecHed();
                    cat.Docno = GrnNo.Trim();
                    cat = new T_RecHedDL().Selectt_RecHed(cat);

                    textareaFunctions(false);

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

                    txt_Locacode.Text = cat.locationId.Trim();
                    txt_Customer.Text = cat.Customer.Trim();
                    txt_ManualNo.Text = cat.refNo.Trim();
                    txt_RefNo.Text = cat.refNo.Trim();
                    txt_Remarks.Text = cat.remarks;
                    dte_date.Value = cat.Datex.Value;
                    txt_totamount.Text = cat.Amount.ToString();
                    txt_memo.Text = cat.Memo;

                    Loadinvoices();

                    T_RecDet req = new T_RecDet();
                    req.Docno = GrnNo.Trim();
                    List<T_RecDet> requests = new List<T_RecDet>();
                    requests = new T_RecDetDL().SelectT_RecDetMulti(req);

                    foreach (T_RecDet det in requests)
                    {

                        commonFunctions.AddRowReciptCal(dtx, det.Paytype, findExisting.FindExisitingPaytype(det.Paytype), det.HeadAmt.ToString(), det.Amt.ToString(), det.CQno, det.Bank, det.BankBranch, det.BankDate.ToString());

                    }
                }
                else
                {
                    if (formMode != 1)
                    {
                        //lbl_processes.Visible = false;
                        //errorProvider1.SetError(txt_InvID, "Invoice Number you have entered does not exists in the system.");
                        //commonFunctions.SetMDIStatusMessage("Invoice Number you have entered does not exists in the system.", 1);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
            }

        }

        #endregion


        private void txt_recivedfrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Remarks.Focus();
            }

        }

        private void txt_Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_totamount.Focus();
            }

        }

        private void txt_totamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
           
        }

        private void txt_totamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (commonFunctions.ToDecimal(txt_totamount.Text.Trim()) <= decimal.Zero) {
                    errorProvider1.SetError(txt_totamount, "Receipt amount more than zero");
                    commonFunctions.SetMDIStatusMessage("Receipt amount more than zero", 1);
                    return;
                }

                if (commonFunctions.ToDecimal(txt_invtot.Text.Trim()) < commonFunctions.ToDecimal(txt_totamount.Text.Trim())) {
                    txt_totamount.Text = "0.00";
                    errorProvider1.SetError(txt_totamount, "Receipt amount cannot exceed than total due amount");
                    commonFunctions.SetMDIStatusMessage("Receipt amount cannot exceed than total due amount", 1);
                    return;
                }
                txt_remaining.Text = txt_totamount.Text;
                txt_code.Focus();
            }
        }


        private void Calculations()
        {
            try
            {
                decimal totalamt = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                decimal commingval = commonFunctions.ToDecimal(txt_amt.Text.Trim());
                decimal gridval = GetGrossAmount(dataGridView1);
                decimal remaining = totalamt - gridval;
                txt_remaining.Text = remaining.ToString();
                txt_gross.Text = gridval.ToString();
                txt_NetAmt.Text = gridval.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private bool commonpass() {
            bool pass = true;
            if (txt_Customer.Text.Trim() == "") {
                errorProvider1.SetError(txt_Customer, "Customer does not exists on the system ");
                commonFunctions.SetMDIStatusMessage("Customer does not exists on the system ", 1);
                return false;
            }

            if (!M_CustomerDL.ExistingM_Customer(txt_Customer.Text.Trim()))
            {
                errorProvider1.SetError(txt_Customer, "Customer does not exists on the system ");
                commonFunctions.SetMDIStatusMessage("Customer does not exists on the system ", 1);
                return false;
            }
            if (txt_totamount.Text.Trim() == "" || commonFunctions.ToDecimal(txt_totamount.Text.Trim()) < 0) {
                errorProvider1.SetError(txt_totamount, "Amount Cannot be a null value ");
                commonFunctions.SetMDIStatusMessage("Amount Cannot be a null value ", 1);
                return false;
            }

            return pass;
        }

        public decimal GetGrossAmount(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {
                    decimal dx = commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                    total += dx;
                }
            }
            return total;
        }

        public decimal GetTOTDUe(DataGridView dataGridView1)
        {

            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Due Amt"].Value != null)
                {
                    decimal dx = commonFunctions.ToDecimal(drow.Cells["Due Amt"].Value.ToString());
                    total += dx;
                }
            }
            return total;
        }

        public decimal GetSettlement(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Settlement"].Value != null)
                {
                    decimal dx = commonFunctions.ToDecimal(drow.Cells["Settlement"].Value.ToString());
                    total += dx;
                }
            }
            return total;
        }


        public decimal GetSettlement()
        {
            decimal total = decimal.Zero;

            total = commonFunctions.ToDecimal(txt_totamount.Text.Trim()) - commonFunctions.ToDecimal(txt_settlementtot.Text.Trim());


            return total;
        }

        private void txt_amt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (e.KeyCode == Keys.Enter)
                {
                    if ((lbl_name.Text.Trim().ToUpper() == "<Error!!!>".ToUpper()) || txt_code.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_code, "Invalied payment method");
                        commonFunctions.SetMDIStatusMessage("Invalied payment method", 1);
                        return;
                    }

                    if ((commonFunctions.ToDecimal(txt_amt.Text.Trim()) == decimal.Zero))
                    {
                        errorProvider1.SetError(txt_amt, "Please enter amount");
                        commonFunctions.SetMDIStatusMessage("Please enter amount", 1);
                        return;
                    }

                    //Calculations();

                    if (!commonpass())
                    {
                        return;
                    }

                    decimal grodval = GetGrossAmount(dataGridView1);
                    decimal total = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                    decimal comming = commonFunctions.ToDecimal(txt_amt.Text.Trim());

                    if ((grodval + comming) > total)
                    {
                        errorProvider1.SetError(txt_amt, "You cannot enter values more than Receipt amount");
                        commonFunctions.SetMDIStatusMessage("You cannot enter values more than Receipt amount", 1);
                        return;
                    }

                    if (gloPaymethod.ToUpper() != "CQ".ToUpper())
                    {
                        commonFunctions.AddRowReciptCal(dtx, txt_code.Text.Trim(), lbl_name.Text, txt_totamount.Text.Trim(), txt_amt.Text.Trim(), "", "", "", DateTime.Now.ToLongDateString());
                        txt_code.Focus();
                    }
                    else
                    {
                        txt_BANK.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
            }

        }

        private void txt_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Calculations();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Calculations();
        }

        private void chk_subtot_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if ((lbl_name.Text.Trim().ToUpper() == "<Error!!!>".ToUpper()) || txt_code.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_code, "Invalied payment method");
                    commonFunctions.SetMDIStatusMessage("Invalied payment method", 1);
                    return;
                }

                if ((commonFunctions.ToDecimal(txt_totamount.Text.Trim()) == decimal.Zero))
                {
                    errorProvider1.SetError(txt_totamount, "Please enter total amount to add breakdown");
                    commonFunctions.SetMDIStatusMessage("Please enter total amount to add breakdown", 1);
                    return;
                }

                if (chk_subtot.Checked)
                {
                    if (txt_code.Text.Trim().ToUpper() != "CQ")
                    {
                        commonFunctions.AddRowReciptCal(dtx, txt_code.Text.Trim(), lbl_name.Text, txt_totamount.Text.Trim(), txt_totamount.Text.Trim(), "", "", "", DateTime.Now.ToLongDateString());
                    }
                }
                else
                {
                    dtx.Clear();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
            }

        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (e.RowCount > 0)
                {
                    txt_invtot.Text = GetTOTDUe(dataGridView2).ToString();
                    txt_settlementtot.Text = GetSettlement(dataGridView2).ToString();
                    txt_remain.Text = GetSettlement().ToString();
                }
            }
            catch (Exception ex) { }
        }

        private void dataGridView2_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                txt_invtot.Text = GetTOTDUe(dataGridView2).ToString();
                txt_settlementtot.Text = GetSettlement(dataGridView2).ToString();
                txt_remain.Text = GetSettlement().ToString();

            }
            catch (Exception ex) { }
        }

        private void txt_BANK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
            lbl_branch.Text = findExisting.FindExisitingBankBranch(txt_BANK.Text.Trim(), txt_BRANCH.Text.Trim());
        }

        private void txt_CQNO_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Enter)
            {
                dte_CQDate.Focus();
            }


            //try
            //{
            //    errorProvider1.Clear();
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if ((lbl_name.Text.Trim().ToUpper() == "<Error!!!>".ToUpper()) || txt_code.Text.Trim() == "")
            //        {
            //            errorProvider1.SetError(txt_code, "Invalied payment method");
            //            commonFunctions.SetMDIStatusMessage("Invalied payment method", 1);
            //            return;
            //        }

            //        if ((commonFunctions.ToDecimal(txt_amt.Text.Trim()) == decimal.Zero))
            //        {
            //            errorProvider1.SetError(txt_amt, "Please enter amount");
            //            commonFunctions.SetMDIStatusMessage("Please enter amount", 1);
            //            return;
            //        }

            //        //Calculations();




            //        if (!commonpass())
            //        {
            //            return;
            //        }

            //        decimal grodval = GetGrossAmount(dataGridView1);
            //        decimal total = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
            //        decimal comming = commonFunctions.ToDecimal(txt_amt.Text.Trim());

            //        if ((grodval + comming) > total)
            //        {
            //            errorProvider1.SetError(txt_amt, "You cannot enter values more than Receipt amount");
            //            commonFunctions.SetMDIStatusMessage("You cannot enter values more than Receipt amount", 1);
            //            return;
            //        }

            //        if (gloPaymethod.ToUpper() == "CQ".ToUpper())
            //        {
            //            commonFunctions.AddRowReciptCal(dtx, txt_code.Text.Trim(), lbl_name.Text, txt_totamount.Text.Trim(), txt_amt.Text.Trim(), txt_CQNO.Text.Trim(), txt_BANK.Text.Trim(), txt_BRANCH.Text.Trim(), DateTime.Now.ToLongDateString());
            //            txt_code.Focus();
            //            panel6.Visible = false;

            //        }
            //        else
            //        {
            //            txt_BANK.Focus();
            //        }


            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
            //    commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                if ((lbl_name.Text.Trim().ToUpper() == "<Error!!!>".ToUpper()) || txt_code.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_code, "Invalied payment method");
                    commonFunctions.SetMDIStatusMessage("Invalied payment method", 1);
                    return;
                }

                if ((commonFunctions.ToDecimal(txt_amt.Text.Trim()) == decimal.Zero))
                {
                    errorProvider1.SetError(txt_amt, "Please enter amount");
                    commonFunctions.SetMDIStatusMessage("Please enter amount", 1);
                    return;
                }

                //Calculations();

                if (!commonpass())
                {
                    return;
                }

                decimal grodval = GetGrossAmount(dataGridView1);
                decimal total = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                decimal comming = commonFunctions.ToDecimal(txt_amt.Text.Trim());

                if ((grodval + comming) > total)
                {
                    errorProvider1.SetError(txt_amt, "You cannot enter values more than Receipt amount");
                    commonFunctions.SetMDIStatusMessage("You cannot enter values more than Receipt amount", 1);
                    return;
                }

                if (gloPaymethod.ToUpper() == "CQ".ToUpper())
                {
                    commonFunctions.AddRowReciptCal(dtx, txt_code.Text.Trim(), lbl_name.Text, txt_totamount.Text.Trim(), txt_amt.Text.Trim(), txt_CQNO.Text.Trim(), txt_BANK.Text.Trim(), txt_BRANCH.Text.Trim(), dte_CQDate.Value.ToShortDateString());
                    txt_code.Focus();
                    panel6.Visible = false;
                }
                else
                {
                    txt_BANK.Focus();
                }



            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
            }
        }

        private void txt_CQNO_KeyDown(object sender, EventArgs e)
        {
            
        }



        private bool GridPass(int index)
        {
            bool pass = true;
            decimal totrcptamt = commonFunctions.ToDecimal(txt_totamount.Text);

            foreach (DataGridViewRow drow in dataGridView2.Rows)
            {
                if (drow.Cells[0].Value.ToString().Trim() != null)
                {
                    decimal ori = commonFunctions.ToDecimal(drow.Cells[1].Value.ToString());
                    decimal Actual = commonFunctions.ToDecimal(drow.Cells[4].Value.ToString());
                    if (Actual >= ori)
                    {
                        pass = false;
                        drow.Cells[4].Value = ori;
                        
                        //commonFunctions.SetMDIStatusMessage("You cannot enter values more than due amount", 1);
                        
                    }

                }
            }
            dataGridView2.Refresh();
            return pass;
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            if (!GridPass(e.RowIndex))
            {
                errorProvider1.SetError(dataGridView2, "You cannot enter values more than due amount");
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            if (!GridPass(e.RowIndex))
            {
                errorProvider1.SetError(dataGridView2, "You cannot enter values more than due amount");
            }
        }

        private void dte_CQDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (e.KeyCode == Keys.Enter)
                {
                    if ((lbl_name.Text.Trim().ToUpper() == "<Error!!!>".ToUpper()) || txt_code.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_code, "Invalied payment method");
                        commonFunctions.SetMDIStatusMessage("Invalied payment method", 1);
                        return;
                    }

                    if ((commonFunctions.ToDecimal(txt_amt.Text.Trim()) == decimal.Zero))
                    {
                        errorProvider1.SetError(txt_amt, "Please enter amount");
                        commonFunctions.SetMDIStatusMessage("Please enter amount", 1);
                        return;
                    }

                    //Calculations();




                    if (!commonpass())
                    {
                        return;
                    }

                    decimal grodval = GetGrossAmount(dataGridView1);
                    decimal total = commonFunctions.ToDecimal(txt_totamount.Text.Trim());
                    decimal comming = commonFunctions.ToDecimal(txt_amt.Text.Trim());

                    if ((grodval + comming) > total)
                    {
                        errorProvider1.SetError(txt_amt, "You cannot enter values more than Receipt amount");
                        commonFunctions.SetMDIStatusMessage("You cannot enter values more than Receipt amount", 1);
                        return;
                    }

                    if (gloPaymethod.ToUpper() == "CQ".ToUpper())
                    {
                        commonFunctions.AddRowReciptCal(dtx, txt_code.Text.Trim(), lbl_name.Text, txt_totamount.Text.Trim(), txt_amt.Text.Trim(), txt_CQNO.Text.Trim(), txt_BANK.Text.Trim(), txt_BRANCH.Text.Trim(), dte_CQDate.Value.ToShortDateString());
                        txt_code.Focus();
                        panel6.Visible = false;

                    }
                    else
                    {
                        txt_BANK.Focus();
                    }


                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
            }
        }
    }
}
