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
    public partial class frm_do : Form
    {

        int formMode = 0;
        string formID = "A0018";
        string formHeadertext = "Delivery order";
        DataTable dtx = new DataTable();
        M_Products gloproduct = new M_Products();
        bool invoiceProcced = false;
        bool invoiceapproved = false;

        #region Loading one instance

        private static frm_do objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_do getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_do();

            }
            return objSingleObject;

        }

        #endregion

        public frm_do()
        {
            InitializeComponent();
        }

        private void frm_do_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);


                dtx = commonFunctions.CreateDatatableDO();
                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                commonFunctions.FormatDataGrid(dataGridView2);
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[1].Width = 460;


                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;

                txt_InvNo.Focus();

                //txt_Locacode.Text = commonFunctions.GlobalLocation;
                //txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on loading", 1);
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
                        if (ActiveControl.Name.Trim() == txt_DoNo.Name.Trim())
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
                        txt_DoNo.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_DoNo.Focus();

                        //txt_Locacode.Text = commonFunctions.GlobalLocation;
                        //txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
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
                        try
                        {


                            errorProvider1.Clear();
                            if (formMode == 1)
                            {

                                //if (commonFunctions.ToDecimal(txt_NoOfCartons.Text.Trim()) <= 0)
                                //{
                                //    errorProvider1.SetError(txt_NoOfCartons, "Please enter current carton details");
                                //    commonFunctions.SetMDIStatusMessage("Please enter current carton details", 1);
                                //    return;
                                //}
                                if (invoiceProcced == false)
                                {
                                    errorProvider1.SetError(txt_InvNo, "Invoice number not processed");
                                    commonFunctions.SetMDIStatusMessage("Invoice number not processed", 1);
                                    return;
                                }
                                if (invoiceapproved == false)
                                {
                                    errorProvider1.SetError(txt_InvNo, "Invoice number not approved");
                                    commonFunctions.SetMDIStatusMessage("Invoice number not approved", 1);
                                    return;
                                }

                                if (!M_CustomerDL.ExistingM_Customer(txt_Customer.Text.Trim()))
                                {
                                    errorProvider1.SetError(txt_Customer, "Customer does not exists on the system ");
                                    commonFunctions.SetMDIStatusMessage("Customer does not exists on the system", 1);
                                    return;
                                }
                                if (!M_VehicleDL.ExistingM_Vehicle(txt_Lorry.Text.Trim()))
                                {
                                    errorProvider1.SetError(txt_Lorry, "Vehicle details does not exists on the system ");
                                    commonFunctions.SetMDIStatusMessage("Vehicle details does not exists on the system ", 1);
                                    
                                }
                                if (!M_AgentDL.ExistingM_Agent(txt_Agent.Text.Trim()))
                                {
                                    errorProvider1.SetError(txt_Agent, "Agent does not exists on the system ");
                                    commonFunctions.SetMDIStatusMessage("Agent does not exists on the system ", 1);
                                   
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
                                        //u_DBConnection.BeginTrans();

                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                T_DiliveryDet objt_DiliveryDet = new T_DiliveryDet();
                                                objt_DiliveryDet.DoNo = txt_DoNo.Text.Trim();
                                                objt_DiliveryDet.Item = drow.Cells["Product Code"].Value.ToString();
                                                objt_DiliveryDet.ItemNamex = findExisting.FindExisitingStock(drow.Cells["Product Code"].Value.ToString());
                                                objt_DiliveryDet.Unit = "PCS";
                                                objt_DiliveryDet.Qty = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_DiliveryDet.Carton = commonFunctions.ToDecimal(drow.Cells["Carton"].Value.ToString());
                                                objt_DiliveryDet.ActualCartons = 0;
                                                objt_DiliveryDet.Remarks = "";
                                                objt_DiliveryDet.Pass = false;
                                                if (drow.Cells["IsCNItem"].Value.ToString().ToUpper() == "1".ToUpper())
                                                {
                                                    objt_DiliveryDet.IsCNitem = true;
                                                    objt_DiliveryDet.CNNumber = drow.Cells[6].Value.ToString();
                                                }
                                                else {
                                                    objt_DiliveryDet.IsCNitem = false;
                                                    objt_DiliveryDet.CNNumber = "";
                                                }
                                                
                                                new T_DiliveryDetDL().Savet_DiliveryDetSP(objt_DiliveryDet, 1);
                                            }

                                        }

                                        //save header data
                                        T_DIliveryHed objt_DIliveryHed = new T_DIliveryHed();
                                        objt_DIliveryHed.DoNo = txt_DoNo.Text.Trim();
                                        objt_DIliveryHed.CompCode = commonFunctions.GlobalCompany;
                                        objt_DIliveryHed.LocaCode = commonFunctions.GlobalLocation;
                                        objt_DIliveryHed.InvNo = txt_InvNo.Text.Trim();
                                        objt_DIliveryHed.InvoiceAmount = commonFunctions.ToDecimal(txt_InvoiceAmount.Text.Trim());
                                        objt_DIliveryHed.Customer = txt_Customer.Text.Trim();
                                        objt_DIliveryHed.CustomerDIscRate = decimal.Zero;
                                        objt_DIliveryHed.Datex = dte_Datex.Value;
                                        objt_DIliveryHed.Agent = txt_Agent.Text.Trim();
                                        objt_DIliveryHed.Lorry = txt_Lorry.Text.Trim();
                                        objt_DIliveryHed.NoOfCartons = commonFunctions.ToDecimal(txt_NoOfCartons.Text.Trim());
                                        objt_DIliveryHed.Dispatched = 0;
                                        objt_DIliveryHed.DispatchedDate = DateTime.Now;
                                        objt_DIliveryHed.DispatchedUser = "";
                                        objt_DIliveryHed.Checked = 0;
                                        objt_DIliveryHed.CheckedUser = "";
                                        objt_DIliveryHed.Checkeddate = DateTime.Now;
                                        objt_DIliveryHed.Approved = 0;
                                        objt_DIliveryHed.ApprovedUser = "";
                                        objt_DIliveryHed.ApprovedDate = DateTime.Now;
                                        objt_DIliveryHed.Handovered = 0;
                                        objt_DIliveryHed.HandoverdUser = "";
                                        objt_DIliveryHed.HandoverDate = DateTime.Now;
                                        objt_DIliveryHed.HandoverCartons = commonFunctions.ToDecimal(txt_NoOfCartons.Text.Trim());
                                        objt_DIliveryHed.Delivered = 0;
                                        objt_DIliveryHed.DiliveredUser = "";
                                        objt_DIliveryHed.DiliveryDate = DateTime.Now;
                                        objt_DIliveryHed.Remarks = txt_Remarks.Text.Trim();
                                        objt_DIliveryHed.NoOfPrints = 0;
                                        objt_DIliveryHed.PrintUser = "";
                                        objt_DIliveryHed.Status = "";
                                        objt_DIliveryHed.Processed = 0;
                                        objt_DIliveryHed.ProcessedDate = DateTime.Now;
                                        objt_DIliveryHed.ProcessedUser = "";
                                        objt_DIliveryHed.Audited = 0;
                                        objt_DIliveryHed.AuditDate = DateTime.Now;
                                        objt_DIliveryHed.AuditUser = "";
                                        objt_DIliveryHed.Completed = 0;
                                        objt_DIliveryHed.CompletedDate = DateTime.Now;
                                        objt_DIliveryHed.PackingListCreated = 0;
                                        objt_DIliveryHed.PackingListDate = DateTime.Now;
                                        objt_DIliveryHed.PackingListUser = "";
                                        objt_DIliveryHed.PackingListNo = "";
                                        objt_DIliveryHed.ReportedProblems = "";
                                        objt_DIliveryHed.AuditRemarks = "";
                                        
                                        new T_DIliveryHedDL().Savet_DIliveryHedSP(objt_DIliveryHed, 1);

                                        //update the invoice header DO number so we can track if the DO created for the given invoice
                                        T_InvoiceHed head = new T_InvoiceHed();
                                        T_InvoiceHedDL invdl = new T_InvoiceHedDL();
                                        head.InvID = txt_InvNo.Text.Trim();
                                        head = invdl.Selectt_InvoiceHed(head);
                                        head.DONumber = txt_DoNo.Text.Trim();
                                        invdl.Savet_InvoiceHedSP(head, 3);

                                        //increment the serial
                                        commonFunctions.IncrementSerial(formID);

                                        //u_DBConnection.CommitTrans();
                                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                                    }
                                    catch (Exception ex)
                                    {
                                        // u_DBConnection.RollbackTrans();
                                        LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                        commonFunctions.SetMDIStatusMessage("Error on saving data", 1);
                                    }

                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        T_DIliveryHed objt_trnsferNote = new T_DIliveryHed();
                                        objt_trnsferNote.DoNo = txt_DoNo.Text.Trim();
                                        objt_trnsferNote.LocaCode = commonFunctions.GlobalLocation.Trim();
                                        new T_DIliveryHedDL().Selectt_DIliveryHed(objt_trnsferNote,2);

                                        objt_trnsferNote.Processed = 1;
                                        objt_trnsferNote.ProcessedDate = DateTime.Now;
                                        objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                        new T_DIliveryHedDL().Savet_DIliveryHedSP(objt_trnsferNote, 3);


                                        T_OrderTracking track = new T_OrderTracking();
                                        track.InvNo = txt_InvNo.Text.Trim();
                                        track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.InvoiceNO);
                                        track.DONo = txt_DoNo.Text.Trim();
                                        track.DOCreated = 1;
                                        track.DOAmount = objt_trnsferNote.InvoiceAmount;
                                        track.DOProcessed = 1;
                                        track.Dodate = dte_Datex.Value;
                                        track.DOProcessedDate = DateTime.Now;
                                        track.DOProcessedUser = commonFunctions.Loginuser;
                                        new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);

                                        //
                                        List<T_DiliveryDet> dets = new List<T_DiliveryDet>();
                                        T_DiliveryDet detx = new T_DiliveryDet();
                                        detx.DoNo = txt_DoNo.Text.Trim();
                                        dets = new T_DiliveryDetDL().SelectT_DiliveryDetMulti(detx);
                                        foreach (T_DiliveryDet det in dets) {
                                            if (det.IsCNitem == true) {
                                                if (det.CNNumber.Trim() != "") {
                                                    T_CNGrouping grp = new T_CNGrouping();
                                                    grp.CNnumber = det.CNNumber;
                                                    grp = new T_CNGroupingDL().Selectt_CNGrouping(grp,det.CNNumber, det.Item);
                                                    grp.Shipped = true;
                                                    grp.ShippedDate = DateTime.Now;
                                                    grp.ShippedDO = det.DoNo;
                                                    new T_CNGroupingDL().Savet_CNGroupingSP(grp, 3);
                                                }
                                            }
                                        }


                                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string,2);

                                        if (objt_trnsferNote.Processed == 1)
                                        {
                                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                PrintDoc(txt_DoNo.Text.Trim());
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
                                    txt_DoNo.Text = commonFunctions.GetSerial(formID.Trim());
                                    txt_Agent.Focus();
                                }
                            }
                            else if (formMode == 3)
                            {
                                T_DIliveryHed objt_trnsferNote = new T_DIliveryHed();
                                objt_trnsferNote.DoNo = txt_DoNo.Text.Trim();
                                objt_trnsferNote.LocaCode = commonFunctions.GlobalLocation.Trim();
                                T_DIliveryHedDL dl = new T_DIliveryHedDL();
                                objt_trnsferNote = dl.Selectt_DIliveryHed(objt_trnsferNote,2);


                                if (objt_trnsferNote.Processed == 0)
                                {
                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {

                                        T_DiliveryDet objt_OrderFormDet = new T_DiliveryDet();
                                        objt_OrderFormDet.DoNo = txt_DoNo.Text;
                                        List<T_DiliveryDet> list = new List<T_DiliveryDet>();
                                        list = new T_DiliveryDetDL().SelectT_DiliveryDetMulti(objt_OrderFormDet);
                                        foreach (T_DiliveryDet detx in list)
                                        {
                                            new T_DiliveryDetDL().Savet_DiliveryDetSP(detx, 4);
                                        }

                                        //save details 
                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                            {
                                                T_DiliveryDet objt_DiliveryDet = new T_DiliveryDet();
                                                objt_DiliveryDet.DoNo = txt_DoNo.Text.Trim();
                                                objt_DiliveryDet.Item = drow.Cells["Product Code"].Value.ToString();
                                                objt_DiliveryDet.ItemNamex = findExisting.FindExisitingProduct(drow.Cells["Product Code"].Value.ToString());
                                                objt_DiliveryDet.Unit = "PCS";
                                                objt_DiliveryDet.Qty = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString());
                                                objt_DiliveryDet.Carton = commonFunctions.ToDecimal(drow.Cells["Carton"].Value.ToString());
                                                objt_DiliveryDet.ActualCartons = 0;
                                                objt_DiliveryDet.Remarks = "";
                                                objt_DiliveryDet.Pass = false;
                                                if (drow.Cells["IsCNItem"].Value.ToString().ToUpper() == "1".ToUpper())
                                                {
                                                    objt_DiliveryDet.IsCNitem = true;
                                                    objt_DiliveryDet.CNNumber = drow.Cells[6].Value.ToString();
                                                }
                                                else
                                                {
                                                    objt_DiliveryDet.IsCNitem = false;
                                                    objt_DiliveryDet.CNNumber = "";
                                                }
                                                new T_DiliveryDetDL().Savet_DiliveryDetSP(objt_DiliveryDet, 1);
                                            }

                                        }

                                        T_DIliveryHed objt_DIliveryHed = new T_DIliveryHed();
                                        objt_DIliveryHed.DoNo = txt_DoNo.Text.Trim();
                                        objt_DIliveryHed.LocaCode = commonFunctions.GlobalLocation;
                                        objt_DIliveryHed = new T_DIliveryHedDL().Selectt_DIliveryHed(objt_DIliveryHed,2);
                                        objt_DIliveryHed.NoOfCartons = commonFunctions.ToDecimal(txt_NoOfCartons.Text.Trim());
                                        objt_DIliveryHed.Agent = txt_Agent.Text.Trim();
                                        objt_DIliveryHed.Lorry = txt_Lorry.Text.Trim();
                                        objt_DIliveryHed.NoOfCartons = commonFunctions.ToDecimal(txt_NoOfCartons.Text.Trim());
                                        objt_DIliveryHed.Remarks = txt_Remarks.Text.Trim();

                                        new T_DIliveryHedDL().Savet_DIliveryHedSP(objt_DIliveryHed, 3);
                                        
                                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);

                                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            objt_trnsferNote.Processed = 1;
                                            objt_trnsferNote.ProcessedDate = DateTime.Now;
                                            objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                            new T_DIliveryHedDL().Savet_DIliveryHedSP(objt_trnsferNote, 3);

                                            T_OrderTracking track = new T_OrderTracking();
                                            track.InvNo = txt_InvNo.Text.Trim();
                                            track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.InvoiceNO);
                                            track.DONo = txt_DoNo.Text.Trim();
                                            track.DOCreated = 1;
                                            track.DOAmount = objt_trnsferNote.InvoiceAmount;
                                            track.DOProcessed = 1;
                                            track.DOProcessedDate = DateTime.Now;
                                            track.DOProcessedUser = commonFunctions.Loginuser;
                                            new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);



                                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);


                                            if (objt_trnsferNote.Processed == 1)
                                            {
                                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                                {
                                                    PrintDoc(txt_DoNo.Text.Trim());
                                                }
                                            }

                                        }


                                        //clear data in data grid 
                                        dtx.Rows.Clear();
                                        dataGridView1.Refresh();
                                        //clear text fields
                                        textareaFunctions(true);
                                        FunctionButtonStatus(xEnums.PerformanceType.Save);

                                        txt_DoNo.Text = commonFunctions.GetSerial(formID.Trim());

                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txt_DoNo, "Invoice number you have entered already processed.You cannot changed data now");
                                    commonFunctions.SetMDIStatusMessage("Invoice number you have entered already processed.You cannot changed data now", 2);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                            commonFunctions.SetMDIStatusMessage("Genaral Error on modifying data", 1);
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_DoNo.Enabled = true;
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

                        if (txt_DoNo.Text.Trim() != "")
                        {
                            T_DIliveryHed objt_trnsferNoteS = new T_DIliveryHed();
                            objt_trnsferNoteS.DoNo = txt_DoNo.Text.Trim();
                            T_DIliveryHedDL dlww = new T_DIliveryHedDL();
                            objt_trnsferNoteS = dlww.Selectt_DIliveryHed(objt_trnsferNoteS,2);
                            if (objt_trnsferNoteS == null) {
                                errorProvider1.SetError(txt_DoNo, "Invalid Order form number");
                                commonFunctions.SetMDIStatusMessage("Invalid Order form number", 2);
                                return;
                            }

                            if (objt_trnsferNoteS.Processed == 1)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    PrintDoc(txt_DoNo.Text.Trim());
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_DoNo, "Delivery Order is not processed");
                                commonFunctions.SetMDIStatusMessage("Delivery Order is not processed", 2);
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_DoNo, "Please enter Order form number to print");
                            commonFunctions.SetMDIStatusMessage("Please enter Order form number to print", 2);

                        }



                        break;
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog("performButtons", "frm_purchaserequest", ex.Message.ToString());
                commonFunctions.SetMDIStatusMessage("Genaral error occured in updating data", 1);
            }
        }

        private void PrintDoc(string DocNo)
        {
            string reporttitle = "DELIVERY ORDER".ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramFields = commonFunctions.AddCrystalParams(reporttitle, commonFunctions.Loginuser.ToUpper());

            paramField.Name = "status";
            paramDiscreteValue.Value = "processed".ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

      

            rpt_t_do rptBank = new rpt_t_do();
            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetDOSTR(DocNo.Trim())));
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
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

            u_UserRights_DL dtAllMenuItems = commonFunctions.GetUserRightObj(formID, commonFunctions.Loginuser.Trim());

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
                txt_Agent.Text = "";
                txt_Agent_name.Text = "";
                txt_Lorry.Text = "";
                txt_Lorry_name.Text = "";
                txt_Customer.Text = "";
                txt_Customer_name.Text = "";
                dte_Datex.Value = DateTime.Now;
                dtx.Clear();
                dataGridView1.Refresh();
                txt_InvNo.Text = "";
                txt_InvoiceAmount.Text = "";


                dte_Datex.Enabled = true;
                txt_Remarks.Enabled = true;
                
                txt_Agent.Enabled = true;
                txt_Agent_name.Enabled = true;
               
            }
            else
            {

                //txt_Remarks.Enabled = false;
                //txt_Locacode.Enabled = false;
                //txt_Agent.Enabled = false;
                //txt_Agent_name.Enabled = false;
                //dte_Datex.Enabled = false;
               

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

        private void txt_InvNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
               
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["InvoiceFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["InvoiceRecallSQL"].ToString() + " AND Locacode = '" + commonFunctions.GlobalLocation.Trim() +"'";

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

        private void txt_InvNo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txt_InvNo_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        #region FindExisitingGRN

        private void FindExisitingGRN(string GrnNo)
        {
            try
            {
                if (T_InvoiceHedDL.ExistingT_InvoiceHed(GrnNo.Trim()))
                {
                    formMode = 1;
                    //clear datagrid

                    dtx.Clear();
                    dataGridView1.Refresh();

                    T_InvoiceHed cat = new T_InvoiceHed();
                    cat.InvID = GrnNo.Trim();
                    T_InvoiceHedDL dl = new T_InvoiceHedDL();
                    cat = dl.Selectt_InvoiceHed(cat);

                    //load and disable the data fields
                    txt_Customer.Text = cat.Customer.Trim();
                    txt_Remarks.Text = cat.Remarks;
                    //txt_noOfPeaces.Text = cat.NoOfPieces.ToString();
                    //txt_noOfItems.Text = cat.Noofitems.ToString();

                    textareaFunctions(false);

                    T_InvoiceDet req = new T_InvoiceDet();
                    req.InvNo = GrnNo.Trim();
                    T_InvoiceDetDL tdl = new T_InvoiceDetDL();
                    List<T_InvoiceDet> requests = new List<T_InvoiceDet>();
                    requests = tdl.SelectT_InvoiceDetMulti(req);

                    foreach (T_InvoiceDet det in requests)
                    {

                        commonFunctions.AddRowDO(dtx, det.ItemCode, findExisting.FindExisitingStock(det.ItemCode).Trim(), det.Qty.ToString(), "PCS", "0", "0", "");
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
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }
        }

        #endregion

        #region FindExisitingOrder

        private void FindExisitingOrder(string GrnNo)
        {
            try
            {
                if (T_DIliveryHedDL.ExistingT_DIliveryHed(GrnNo.Trim()))
                {
                    formMode = 1;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    performButtons(xEnums.PerformanceType.Edit);


                    T_DIliveryHed cat = new T_DIliveryHed();
                    cat.DoNo = GrnNo.Trim();
                    cat.LocaCode = commonFunctions.GlobalLocation.Trim();
                    T_DIliveryHedDL dl = new T_DIliveryHedDL();
                    cat = dl.Selectt_DIliveryHed(cat,2);

                    //load and disable the data fields
                    
                    txt_Customer.Text = cat.Customer.Trim();
                    txt_InvNo.Text = cat.InvNo;
                    txt_Lorry.Text = cat.Lorry;
                    txt_Agent.Text = cat.Agent;
                    txt_Remarks.Text = cat.Remarks;
                    txt_NoOfCartons.Text = cat.NoOfCartons.ToString();

                    textareaFunctions(false);

                    T_DiliveryDet req = new T_DiliveryDet();
                    req.DoNo = GrnNo.Trim();
                    T_DiliveryDetDL tdl = new T_DiliveryDetDL();
                    List<T_DiliveryDet> requests = new List<T_DiliveryDet>();
                    requests = tdl.SelectT_DiliveryDetMulti(req);

                    foreach (T_DiliveryDet det in requests)
                    {

                        commonFunctions.AddRowDO(dtx, det.Item, findExisting.FindExisitingStock(det.Item).Trim(), det.Qty.ToString(), "PCS", det.Carton.ToString(), det.IsCNitem.ToString(),det.CNNumber);
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
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }
        }

        #endregion

        private void txt_Locacode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_Datex.Focus();
            }
        }

        private void dte_Datex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();
            }
        }

        private void txt_Agent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                txt_Remarks.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_Agent.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["AgentFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["AgentSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["AgentField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }


        }

        private void txt_Lorry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                txt_Agent.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_Lorry.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["VehicleFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["VehicleSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["VehicleField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }

        }

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCNdetails();
                txt_Lorry.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {
                //if (ActiveControl.Name.Trim() == txt_Customer.Name.Trim())
                //{
                //    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CustFieldLength"]);
                //    string[] strSearchField = new string[length];

                //    string strSQL = ConfigurationManager.AppSettings["CustSQL"].ToString();

                //    for (int i = 0; i < length; i++)
                //    {
                //        string m;
                //        m = i.ToString();
                //        strSearchField[i] = ConfigurationManager.AppSettings["CustField" + m + ""].ToString();
                //    }
                //    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                //    find.ShowDialog(this);
                //}
            }


        }

        private void GetCNdetails() {
            try
            {
                dataGridView2.DataSource = T_OrderFormHeadDL.GetCreditNoteItems(txt_Customer.Text.Trim());
                dataGridView2.Columns[0].Width = 120;
                dataGridView2.Columns[1].Width = 120;
                dataGridView2.Columns[2].Width = 120;
                dataGridView2.Columns[3].Width = 120;
                dataGridView2.Columns[7].Width = 120;
                
                dataGridView2.Refresh();
            }
            catch (Exception ex)
            {

            }

        }

        private void txt_Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Remarks.Focus();
            }
        }

        private void txt_DoNo_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer.Focus();
                FindExisitingOrder(txt_DoNo.Text.Trim());
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_DoNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["DeliveryRecallFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["DeliveryRecallSQL"].ToString() + "AND Locacode = '" + commonFunctions.GlobalLocation.Trim() + "'";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["DeliveryRecallField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
           
        }


        #region Detail functions

   

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                
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
           
        }

      

        private void txt_Cartons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        #endregion


        private void txt_InvNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_InvoiceAmount.Text = findExisting.FindExisitingInvoice(txt_InvNo.Text);
                T_InvoiceHed invhead = findExisting.FindExisitingInvoiceAll(txt_InvNo.Text.Trim());
                if (invhead.Customer != null)
                {
                    if (invhead.Processed == 1)
                    {
                        invoiceProcced = true;

                        if (invhead.Approved == 1)
                        {
                            invoiceapproved = true;

                            if (invhead.DONumber.Trim() == "")
                            {

                                lbl_docreated.Visible = false;
                                txt_Customer.Text = invhead.Customer.Trim();
                                FindExisitingGRN(txt_InvNo.Text.Trim());

                            }
                            else
                            {
                                lbl_docreated.Visible = true;
                                lbl_docreated.Text = "DO CREATED".ToUpper();
                            }
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
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
            }
        }

        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
            GetCNdetails();
        }

        private void txt_Lorry_TextChanged(object sender, EventArgs e)
        {
            txt_Lorry_name.Text = findExisting.FindExisitingVehicle(txt_Lorry.Text);
        }

        private void txt_Agent_TextChanged(object sender, EventArgs e)
        {
            txt_Agent_name.Text = findExisting.FindExisitingAgent(txt_Agent.Text);
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_DoNo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //lbl_name.Text = e.ColumnIndex.ToString() + "     -    " + e.RowIndex.ToString();
           txt_NoOfCartons.Text =  GetCumTotalCatorns(dataGridView1).ToString();
        }

        public static decimal GetCumTotalCatorns(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[0].Value != null)
                {
                    total += commonFunctions.ToDecimal(drow.Cells["Carton"].Value.ToString());
                }
            }
            return total;
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //save details 
            //foreach (DataGridViewRow drow in dataGridView2.Rows)
            //{
            //    if (drow.Cells[0].Value.ToString().Trim() != null)
            //    {
                    
            //        commonFunctions.AddRowDO(dtx, drow.Cells[1].Value.ToString().Trim(), drow.Cells[2].Value.ToString().Trim(), drow.Cells[6].Value.ToString().Trim(), "PCS", "0");
            //    }

            //}

            DataGridViewRow drow = new DataGridViewRow();
            drow = dataGridView2.SelectedRows[0];
            if (drow != null)
            {
                commonFunctions.AddRowDO(dtx, drow.Cells[1].Value.ToString().Trim(), drow.Cells[2].Value.ToString().Trim(), drow.Cells[6].Value.ToString().Trim(), "PCS", "0", "1", drow.Cells[0].Value.ToString().Trim());
            }
        }

      

      

     
       


    }
}
