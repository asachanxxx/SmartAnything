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
    public partial class frm_creditnote : Form
    {
        int formMode = 0;
        string formID = "A0020";
        string formHeadertext = "Credit Note";
        DataTable dtx = new DataTable();
        bool already = false;
        M_Products gloproduct = new M_Products();
        bool invoiceProcced = false;
        bool invoiceapproved = false;
        bool isrecall = false;

        #region Loading one instance

        private static frm_creditnote objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_creditnote getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_creditnote();

            }
            return objSingleObject;

        }

        #endregion

        public frm_creditnote()
        {
            InitializeComponent();
        }

        private void frm_creditnote_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            FunctionButtonStatus(xEnums.PerformanceType.Default);
            commonFunctions.HandleTextBoxesInTransactions(panel3);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);


            dtx = commonFunctions.CreateDatatableCN();
            dataGridView1.DataSource = dtx;
            commonFunctions.FormatDataGrid(dataGridView1);
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 140;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            txt_code.Focus();

            
            txt_LocaCode.Text = commonFunctions.GlobalLocation;
            txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_LocaCode.Text.Trim());


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
                        isrecall = false;
                        FunctionButtonStatus(xEnums.PerformanceType.New);
                        formMode = 1;
                        txt_DocNo.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_DocNo.Focus();

                        txt_AuditUser.Text = "";
                        txt_AuditUser_name.Text = "";
                        txt_OFNo.Text = "";
                        txt_Dono.Text = "";
                        txt_PackingList.Text = "";
                        txt_Remarks.Text = "";
                        txt_InvNo.Text = "";
                        txt_CNtypes.Text = "";

                        txt_LocaCode.Text = commonFunctions.GlobalLocation;
                        txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_LocaCode.Text.Trim());
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
                        try
                        {
                            if (formMode == 1)
                            {
                                if (txt_InvNo.Text.Trim() != "")
                                {
                                    if (!T_InvoiceHedDL.ExistingT_InvoiceHed(txt_InvNo.Text.Trim()))
                                    {
                                        errorProvider1.SetError(txt_InvNo, "Please enter a valied invoice number.");
                                        commonFunctions.SetMDIStatusMessage("Please enter a valied invoice number.", 1);
                                        return;
                                    }

                                    if (!invoiceProcced)
                                    {
                                        errorProvider1.SetError(txt_InvNo, "Invoice number not processed.");
                                        commonFunctions.SetMDIStatusMessage("Invoice number not processed.", 1);
                                        return;
                                    }
                                    if (!invoiceapproved)
                                    {
                                        errorProvider1.SetError(txt_InvNo, "Invoice number not approved.");
                                        commonFunctions.SetMDIStatusMessage("Invoice number not approved.", 1);
                                        return;
                                    }
                                }

                                if (!GridPass())
                                {
                                    errorProvider1.SetError(dataGridView1, "Credit note QTY cannot exceded the Invoice QTY");
                                    commonFunctions.SetMDIStatusMessage("Credit note QTY cannot exceded the Invoice QTY", 1);
                                    return;
                                }

                                if (!M_LocaDL.ExistingM_Loca(txt_LocaCode.Text.Trim()))
                                {
                                    errorProvider1.SetError(txt_LocaCode, "Location does not exists on the system ");
                                    commonFunctions.SetMDIStatusMessage("Location does not exists on the system", 1);
                                    return;
                                }

                                if (!M_CustomerDL.ExistingM_Customer(txt_Customer.Text.Trim()))
                                {
                                    errorProvider1.SetError(txt_Customer, "Customer does not exists on the system ");
                                    commonFunctions.SetMDIStatusMessage("Customer does not exists on the system ", 1);
                                    return;
                                }

                                if (!M_CNTypeDL.ExistingM_CNType(txt_CNtypes.Text.Trim()))
                                {
                                    errorProvider1.SetError(txt_CNtypes, "CreditNote Type not exists on the system ");
                                    commonFunctions.SetMDIStatusMessage("CreditNote Type not exists on the system ", 1);
                                    return;
                                }

                                if (commonFunctions.GetNoofItemsIndexBase(dataGridView1) <= 0)
                                {
                                    errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                    commonFunctions.SetMDIStatusMessage("Please enter some items to the details grid", 1);
                                    return;
                                }
                                
                                if (txt_ManualID.Text.Trim() == string.Empty)
                                {
                                    errorProvider1.SetError(txt_ManualID, "Please enter manual no");
                                    commonFunctions.SetMDIStatusMessage("Please enter manual no", 1);
                                    return;
                                }

                                

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    try
                                    {
                                        //u_DBConnection.BeginTrans();
                                        //save header data
                                        T_CreditNoteHead objt_CreditNoteHead = new T_CreditNoteHead();
                                        objt_CreditNoteHead.DocNo = txt_DocNo.Text.Trim();
                                        objt_CreditNoteHead.CompCode = commonFunctions.GlobalCompany;
                                        objt_CreditNoteHead.LocaCode = txt_LocaCode.Text.Trim();
                                        objt_CreditNoteHead.OFNo = txt_OFNo.Text.Trim();
                                        objt_CreditNoteHead.InvNo = txt_InvNo.Text.Trim();
                                        objt_CreditNoteHead.Dono = txt_Dono.Text.Trim();
                                        objt_CreditNoteHead.CustomerID = txt_Customer.Text.Trim();
                                        objt_CreditNoteHead.TypeX = txt_CNtypes.Text.Trim();
                                        objt_CreditNoteHead.AuditUser = txt_AuditUser.Text.Trim();
                                        objt_CreditNoteHead.Statusx = "";
                                        objt_CreditNoteHead.Datex = dte_date.Value;
                                        objt_CreditNoteHead.ManualID = txt_ManualID.Text.Trim();
                                        objt_CreditNoteHead.DeliveredDate = txt_DeliveredDate.Value;
                                        objt_CreditNoteHead.PackingList = txt_PackingList.Text.Trim();
                                        objt_CreditNoteHead.DeliveryStatus = "";
                                        objt_CreditNoteHead.AgentStatus = "";
                                        objt_CreditNoteHead.Remarks = txt_Remarks.Text.Trim();
                                        objt_CreditNoteHead.Processed = false;
                                        objt_CreditNoteHead.ProcessedDate = DateTime.Now;
                                        objt_CreditNoteHead.ProcessedUser = "";
                                        objt_CreditNoteHead.Grouped = false;
                                        objt_CreditNoteHead.GroupedDate = DateTime.Now;
                                        objt_CreditNoteHead.GroupedUser = "";
                                        objt_CreditNoteHead.Approved = false;
                                        objt_CreditNoteHead.ApprovedDate = DateTime.Now;
                                        objt_CreditNoteHead.ApprovedUser = "";
                                        T_CreditNoteHeadDL bal = new T_CreditNoteHeadDL();
                                        bal.Savet_CreditNoteHeadSP(objt_CreditNoteHead, 1);



                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                T_CNBreak objt_CNBreak = new T_CNBreak();
                                                objt_CNBreak.DocNo = txt_DocNo.Text.Trim();
                                                objt_CNBreak.ItemCode = drow.Cells["Product Code"].Value.ToString();
                                                objt_CNBreak.Namex = drow.Cells["Product Name"].Value.ToString();
                                                objt_CNBreak.InvQTY = commonFunctions.ToDecimal(drow.Cells["INV QTY"].Value.ToString());
                                                objt_CNBreak.QTY = commonFunctions.ToDecimal(drow.Cells["C/N QTY"].Value.ToString());
                                                objt_CNBreak.Datex = DateTime.Now;
                                                objt_CNBreak.Userx = commonFunctions.Loginuser;
                                                objt_CNBreak.Grouped = false; 
                                                objt_CNBreak.BalanceQty = decimal.Zero;
                                                T_CNBreakDL bal2 = new T_CNBreakDL();
                                                bal2.Savet_CNBreakSP(objt_CNBreak, 1);
                                            }
                                        }

                                        //increment the serial
                                        commonFunctions.IncrementSerial(formID);
                                        //u_DBConnection.CommitTrans();
                                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);

                                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            T_CreditNoteHead objt_trnsferNote = new T_CreditNoteHead();
                                            objt_trnsferNote.DocNo = txt_DocNo.Text.Trim();

                                            new T_CreditNoteHeadDL().Selectt_CreditNoteHead(objt_trnsferNote);
                                            

                                            objt_trnsferNote.Processed = true;
                                            objt_trnsferNote.ProcessedDate = DateTime.Now;
                                            objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                            new T_CreditNoteHeadDL().Savet_CreditNoteHeadSP(objt_trnsferNote, 3);
                                            UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                        commonFunctions.SetMDIStatusMessage("Error on saving Header and details data", 1);
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
                                T_CreditNoteHead objt_trnsferNote = new T_CreditNoteHead();
                                objt_trnsferNote.DocNo = txt_DocNo.Text.Trim();
                                T_CreditNoteHeadDL dl = new T_CreditNoteHeadDL();
                                objt_trnsferNote = dl.Selectt_CreditNoteHead(objt_trnsferNote);


                                if (objt_trnsferNote.Processed == false)
                                {
                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        T_CNBreak objt_OrderFormDet = new T_CNBreak();
                                        T_CNBreakDL bal2 = new T_CNBreakDL();
                                        objt_OrderFormDet.DocNo = txt_DocNo.Text;
                                        List<T_CNBreak> list = new List<T_CNBreak>();
                                        list = bal2.SelectT_CNBreakMulti(objt_OrderFormDet);

                                        foreach (T_CNBreak detx in list)
                                        {
                                            bal2.Savet_CNBreakSP(detx, 4);
                                        }

                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                T_CNBreak objt_CNBreak = new T_CNBreak();
                                                objt_CNBreak.DocNo = txt_DocNo.Text.Trim();
                                                objt_CNBreak.ItemCode = drow.Cells["Product Code"].Value.ToString();
                                                objt_CNBreak.Namex = drow.Cells["Product Name"].Value.ToString();
                                                objt_CNBreak.InvQTY = commonFunctions.ToDecimal(drow.Cells["INV QTY"].Value.ToString());
                                                objt_CNBreak.QTY = commonFunctions.ToDecimal(drow.Cells["C/N QTY"].Value.ToString());
                                                objt_CNBreak.Datex = DateTime.Now;
                                                objt_CNBreak.Userx = commonFunctions.Loginuser;
                                                objt_CNBreak.Grouped = false; 
                                                objt_CNBreak.BalanceQty = decimal.Zero;
                                                T_CNBreakDL bal2x = new T_CNBreakDL();
                                                bal2x.Savet_CNBreakSP(objt_CNBreak, 1);


                                            }

                                        }

                                        objt_trnsferNote.OFNo = txt_OFNo.Text.Trim();
                                        objt_trnsferNote.InvNo = txt_InvNo.Text.Trim();
                                        objt_trnsferNote.Dono = txt_Dono.Text.Trim();
                                        objt_trnsferNote.CustomerID = txt_Customer.Text.Trim();
                                        objt_trnsferNote.TypeX = txt_CNtypes.Text.Trim();
                                        objt_trnsferNote.PackingList = txt_PackingList.Text.Trim();
                                        objt_trnsferNote.Remarks = txt_Remarks.Text.Trim();
                                        dl.Savet_CreditNoteHeadSP(objt_trnsferNote, 3);


                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());


                                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            objt_trnsferNote.Processed = true;
                                            objt_trnsferNote.ProcessedDate = DateTime.Now;
                                            objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                            dl.Savet_CreditNoteHeadSP(objt_trnsferNote, 3);
                                            UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                        }

                                        //clear data in data grid 
                                        dtx.Rows.Clear();
                                        dataGridView1.Refresh();
                                        //clear text fields
                                        textareaFunctions(true);
                                        FunctionButtonStatus(xEnums.PerformanceType.Save);

                                        txt_DocNo.Text = commonFunctions.GetSerial(formID.Trim());

                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txt_DocNo, "Credit Note number number you have entered already processed.You cannot changed data now");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                            commonFunctions.SetMDIStatusMessage("Error on saving data", 1);
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

                        txt_AuditUser.Text = "";
                        txt_AuditUser_name.Text = "";
                        txt_OFNo.Text = "";
                        txt_Dono.Text = "";
                        txt_PackingList.Text = "";
                        txt_Remarks.Text = "";
                        txt_InvNo.Text = "";
                        txt_CNtypes.Text = "";

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

        private void PrintDoc(string DocNo, string loca, string locaname)
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

        #region textareaFunctions

        private void textareaFunctions(bool stype)
        {
            if (stype == true)
            {

                txt_Remarks.Text = "";
                txt_Customer.Text = "";
                txt_Customer_name.Text = "";
                dte_date.Value = DateTime.Now;
                txt_CNqty.Text = "0.0000";
                //cmb_TypeX.SelectedIndex = 0;
                dtx.Clear();
                dataGridView1.Refresh();
               

                dte_date.Enabled = true;
                txt_Remarks.Enabled = true;
                txt_LocaCode.Enabled = true;
                txt_Customer.Enabled = true;
                txt_Customer_name.Enabled = true;
                dataGridView1.Enabled = true;
            }
            else
            {
                //txt_AuditUser.ReadOnly = true;
                //txt_Remarks.Enabled = false;
                //txt_LocaCode.Enabled = false;
                //txt_Customer.Enabled = false;
                //txt_Customer_name.Enabled = false;
                //dte_date.Enabled = false;
                //dataGridView1.Enabled = false;

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
                            txt_CNqty.Text = "0";
                            txt_CNqty.Focus();

                            errorProvider1.Clear();
                            already = false;
                        }
                        else
                        {
                            already = true;
                            GetStockdetails();

                            DataGridViewRow drowx = new DataGridViewRow();
                            drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());
                            txt_CNqty.Text = drowx.Cells[3].Value.ToString();
                            txt_CNqty.Focus();
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
                    
                }
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
                //lbl_available.Text = stk.Stock.ToString();
            }
            catch (Exception ex)
            {
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                throw ex;
            }
        }

        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_CNqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_selling.Text.Trim() != "")
                {
                    if ((commonFunctions.ToDecimal(txt_CNqty.Text.Trim()) != decimal.Zero))
                    {
                        already = commonFunctions.IsExistINV(dataGridView1, txt_code.Text);
                        if (already == false)
                        {
                            commonFunctions.AddRowCreditNote(dtx, txt_code.Text, lbl_name.Text.Trim(), "0.00", txt_CNqty.Text.Trim());
                            txt_code.Focus();
                        }
                        else
                        {
                            commonFunctions.AddRowtogridCN(dataGridView1, txt_code.Text, lbl_name.Text.Trim(), "0.00", txt_CNqty.Text.Trim());
                            txt_code.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txt_CNqty, "Please enter quntity");
                        commonFunctions.SetMDIStatusMessage("Please enter quntity", 1);
                    }
                }
                else
                {
                    //txt_amt.Text = "0.00";

                }
                txt_code.Focus();

            }
        }

        private void txt_CNqty_KeyPress(object sender, KeyPressEventArgs e)
        {

        }







        private void txt_DocNo_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingCN(txt_DocNo.Text.Trim());
                txt_InvNo.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_DocNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CNHFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CNHSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CNHField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
            
        }


        #region FindExisitingGRN

        private void FindExisitingCN(string GrnNo)
        {

            if (T_CreditNoteHeadDL.ExistingT_CreditNoteHead(GrnNo.Trim()))
            {
                formMode = 3;
                //clear datagrid
                dtx.Clear();
                dataGridView1.Refresh();

                //clear error fields
                errorProvider1.Clear();

                T_CreditNoteHead cat = new T_CreditNoteHead();
                cat.DocNo = GrnNo.Trim();
                T_CreditNoteHeadDL dl = new T_CreditNoteHeadDL();
                cat = dl.Selectt_CreditNoteHead(cat);

                ////set the process message and mode to edit mode
                if (cat.Processed == false)
                {
                    lbl_processes.Visible = false;
                    performButtons(xEnums.PerformanceType.Edit);
                }
                else
                {
                    lbl_processes.Visible = true;


                }

                //load and disable the data fields

                txt_LocaCode.Text = cat.LocaCode.Trim();
                txt_Customer.Text = cat.CustomerID.Trim();
                txt_ManualID.Text = cat.ManualID.Trim();
                txt_Remarks.Text = cat.Remarks;
                dte_date.Value = cat.Datex.Value;
                txt_CNtypes.Text = cat.TypeX;
                txt_InvNo.Text = cat.InvNo;

                textareaFunctions(false);

                T_CNBreak req = new T_CNBreak();
                req.DocNo = GrnNo.Trim();
                T_CNBreakDL tdl = new T_CNBreakDL();
                List<T_CNBreak> requests = new List<T_CNBreak>();
                requests = tdl.SelectT_CNBreakMulti(req);

                foreach (T_CNBreak det in requests)
                {

                    commonFunctions.AddRowCreditNote(dtx, det.ItemCode, findExisting.FindExisitingStock(det.ItemCode).Trim(), det.InvQTY.ToString(), det.QTY.ToString());
                }

               
            }
            else
            {
                if (formMode != 1)
                {
                    lbl_processes.Visible = false;
                    errorProvider1.SetError(txt_DocNo, "Credit Note Number you have entered does not exists in the system.");
                    commonFunctions.SetMDIStatusMessage("Credit Note Number you have entered does not exists in the system.", 1);
                }
            }
        }

        #endregion
        private void txt_InvNo_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_LocaCode.Focus();
                LoadInvoice();
            }
            if (e.KeyCode == Keys.F2)
            {

                int length = Convert.ToInt32(ConfigurationManager.AppSettings["InvoiceFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["InvoiceSQLApproved"].ToString();   

                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["InvoiceField" + m + ""].ToString();
                }
                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);
            }
        }

        private void txt_LocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
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
                txt_AuditUser.Focus();
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

        private void txt_AuditUser_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_CNtypes.Focus();
            }
        }
        private void txt_CNtypes_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_ManualID.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["CNFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["CNSQL"].ToString() + " WHERE TypeID != 'RTN'";

                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["CNField" + m + ""].ToString();
                }
                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);
            }

        }

        private void txt_ManualID_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                dte_date.Focus();
            }
        }

        private void dte_date_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_DeliveredDate.Focus();
            }
        }

        private void txt_DeliveredDate_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_Remarks.Focus();
            }
        }

        private void txt_Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
            }
        }

        private void txt_InvNo_TextChanged(object sender, EventArgs e)
        {
            LoadInvoice();
        }

        private void LoadInvoice()
        {

            if (txt_InvNo.Text != "")
            {
                if (!T_InvoiceHedDL.ExistingT_InvoiceHed(txt_InvNo.Text.Trim()))
                {
                    lbl_docreated.Visible = true;
                    lbl_docreated.Text = "Invalied".ToUpper();
                    commonFunctions.SetMDIStatusMessage("Invalied invoice number", 1);
                    return;
                }
                T_InvoiceHed invhead = findExisting.FindExisitingInvoiceAll(txt_InvNo.Text.Trim());
                if (invhead.Customer != null)
                {
                    dte_invdate.Value = invhead.Datex.Value;
                    if (invhead.Processed == 1)
                    {
                        invoiceProcced = true;

                        if (invhead.Approved == 1)
                        {
                            invoiceapproved = true;
                            lbl_docreated.Visible = false;
                            txt_Customer.Text = invhead.Customer.Trim();
                            FindExisitingGRN(txt_InvNo.Text.Trim());
                        }
                        else
                        {
                            //if not approved
                            lbl_docreated.Visible = true;
                            lbl_docreated.Text = "not Approved".ToUpper();
                            invoiceapproved = false;
                        }
                    }
                    else
                    {
                        //if not processed
                        lbl_docreated.Visible = true;
                        lbl_docreated.Text = "not Processed".ToUpper();
                        invoiceProcced = false;
                    }

                }
                else
                {
                    dtx.Clear();
                    dataGridView1.Refresh();
                    errorProvider1.Clear();

                    txt_Customer.Text = "";
                    txt_Customer_name.Text = "";
                    lbl_docreated.Text = "Invalid".ToUpper();
                }
            }
            else { 
            
            }



        }


        private void FindExisitingGRN(string GrnNo)
        {


            if (T_InvoiceHedDL.ExistingT_InvoiceHed(GrnNo.Trim()))
            {
                formMode = 1;
                //clear datagrid
                dtx.Clear();
                dataGridView1.Refresh();

                isrecall = true;

                T_InvoiceHed cat = new T_InvoiceHed();
                cat.InvID = GrnNo.Trim();
                T_InvoiceHedDL dl = new T_InvoiceHedDL();
                cat = dl.Selectt_InvoiceHed(cat);

                //load and disable the data fields

                txt_LocaCode.Text = cat.LocaCode.Trim();
                txt_Customer.Text = cat.Customer.Trim();
                txt_AuditUser.Text = cat.AprrovedBy.Trim();
                //txt_Remarks.Text = cat.Remarks;
                txt_OFNo.Text = cat.OrderFormNo;
                txt_Dono.Text = cat.DONumber;
                txt_PackingList.Text = "";


                textareaFunctions(false);

                T_InvoiceDet req = new T_InvoiceDet();
                req.InvNo = GrnNo.Trim();
                T_InvoiceDetDL tdl = new T_InvoiceDetDL();
                List<T_InvoiceDet> requests = new List<T_InvoiceDet>();
                requests = tdl.SelectT_InvoiceDetMulti(req);

                foreach (T_InvoiceDet det in requests)
                {

                    commonFunctions.AddRowCreditNote(dtx, det.ItemCode, findExisting.FindExisitingStock(det.ItemCode).Trim(), det.Qty.ToString(), "0");
                }

            }
            else
            {
                if (formMode != 1)
                {
                    lbl_processes.Visible = false;
                    errorProvider1.SetError(txt_InvNo, "Invoice Number you have entered does not exists in the system.");
                }
            }
        }

        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
        }

        private void txt_AuditUser_TextChanged(object sender, EventArgs e)
        {
            txt_AuditUser_name.Text = findExisting.FindExisitingUser(txt_AuditUser.Text);
        }

        private void txt_DocNo_TextChanged(object sender, EventArgs e)
        {
            if (formMode != 1)
            {
                FindExisitingCN(txt_DocNo.Text.Trim());
            }
        }

        private void txt_CNtypes_TextChanged(object sender, EventArgs e)
        {
            lbl_creditnotetype.Text = findExisting.FindExisitingCNType(txt_CNtypes.Text);
        }

        private void txt_InvNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isrecall)
            {
                GridPass();
            }
        }


        private bool GridPass()
        {
            bool pass = true;

            if (isrecall)
            {
                foreach (DataGridViewRow drow in dataGridView1.Rows)
                {
                    if (drow.Cells[0].Value.ToString().Trim() != null)
                    {
                        int ori = commonFunctions.ToInt(drow.Cells[2].Value.ToString());
                        int Actual = commonFunctions.ToInt(drow.Cells[3].Value.ToString());
                        if (Actual <= 0)
                        {
                            commonFunctions.SetMDIStatusMessage("Credit note QTY cannot be zero", 1);
                            return false;
                        }
                        if (ori < Actual)
                        {
                            pass = false;
                            commonFunctions.SetMDIStatusMessage("Credit note QTY cannot exceded the Invoice QTY", 1);
                        }

                    }

                }
            }
            return pass;
        }

    }
}
