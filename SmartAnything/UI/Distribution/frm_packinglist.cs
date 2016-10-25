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
    public partial class frm_packinglist : Form
    {


        int formMode = 0;
        string formID = "A0041";
        string formHeadertext = "Packing List";
        DataTable dtx = new DataTable();
        M_Products gloproduct = new M_Products();
        bool invoiceProcced = false;
        bool invoiceapproved = false;

        #region Loading one instance

        private static frm_packinglist objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_packinglist getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_packinglist();

            }
            return objSingleObject;

        }
        #endregion
        
        public frm_packinglist()
        {
            InitializeComponent();
        }

        private void frm_packinglist_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);


                dtx = commonFunctions.CreateDatatablePacking();
                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[4].Width = 250;
                dataGridView1.Columns[6].Width = 230;


                txt_Locacode.Text = commonFunctions.GlobalLocation;
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text.Trim());
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
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
                        if (ActiveControl.Name.Trim() == txt_PackingNo.Name.Trim())
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
                        txt_PackingNo.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_PackingNo.Focus();

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
                                commonFunctions.SetMDIStatusMessage("", 2);
                                return;
                            }
                            if (!M_VehicleDL.ExistingM_Vehicle(txt_Vehicle.Text.Trim()))
                            {
                                 errorProvider1.SetError(txt_Vehicle, "Vehicle details does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Vehicle details does not exists on the system", 2);
                                return;
                            }
                            if (!U_UserxDL.ExistingU_User(txt_Driver.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_Driver, "Driver does not exists on the system ");
                                commonFunctions.SetMDIStatusMessage("Driver does not exists on the system", 2);
                               // return;
                            }
                            if (commonFunctions.GetNoofItems(dataGridView1,1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                commonFunctions.SetMDIStatusMessage("Please enter some items to the details grid", 2);
                                return;
                            }
                          
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {
                                    //u_DBConnection.BeginTrans();
                                    //save header data

                                    T_packinghead objt_packinghead = new T_packinghead();
                                    objt_packinghead.PackingNo = txt_PackingNo.Text.Trim();
                                    objt_packinghead.RefNumber = txt_RefNumber.Text.Trim();
                                    objt_packinghead.CompCode = commonFunctions.GlobalCompany;
                                    objt_packinghead.LocaCode = commonFunctions.GlobalLocation;
                                    objt_packinghead.Datex = DateTime.Now;
                                    objt_packinghead.NoOfCartons = commonFunctions.ToDecimal(txt_NoOfCartons.Text.Trim());
                                    objt_packinghead.Vehicle = txt_Vehicle.Text.Trim();
                                    objt_packinghead.Driver = txt_Driver.Text.Trim();
                                    objt_packinghead.CreatedUser = commonFunctions.Loginuser;
                                    objt_packinghead.CreatedTime = DateTime.Now;
                                    objt_packinghead.Processed = 0;
                                    objt_packinghead.ProcessedDate = DateTime.Now;
                                    objt_packinghead.ProcessedUser = commonFunctions.Loginuser;
                                    objt_packinghead.Glupdated = false;
                                    T_packingheadDL bal = new T_packingheadDL();
                                    bal.Savet_packingheadSP(objt_packinghead, 1);

                                    //save details 
                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Do Number"].Value.ToString().Trim() != null)
                                        {
                                            T_packingdet objt_packingdet = new T_packingdet();
                                            objt_packingdet.PackingNo = txt_PackingNo.Text.Trim();
                                            objt_packingdet.Dono = drow.Cells["Do Number"].Value.ToString();
                                            objt_packingdet.Customer = drow.Cells["Customer"].Value.ToString();
                                            objt_packingdet.Agent = drow.Cells["Agent"].Value.ToString();
                                            objt_packingdet.datex = DateTime.Now;
                                            objt_packingdet.TTLCartons = commonFunctions.ToDecimal(drow.Cells["Cartons"].Value.ToString());
                                            new T_packingdetDL().Savet_packingdetSP(objt_packingdet, 1);

                                        }

                                    }

                                    //increment the serial
                                    commonFunctions.IncrementSerial(formID);

                                    //u_DBConnection.CommitTrans();
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                              

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    T_packinghead objt_trnsferNote = new T_packinghead();
                                    objt_trnsferNote.PackingNo = txt_PackingNo.Text.Trim();
                                    new T_packingheadDL().Selectt_packinghead(objt_trnsferNote);
                                    

                                    objt_trnsferNote.Processed = 1;
                                    objt_trnsferNote.ProcessedDate = DateTime.Now;
                                    objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                    new T_packingheadDL().Savet_packingheadSP(objt_trnsferNote, 3);

                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Do Number"].Value.ToString().Trim() != null)
                                        {
                                          
                                            T_DIliveryHed dh = new T_DIliveryHed();
                                            dh.DoNo = drow.Cells["Do Number"].Value.ToString();
                                            dh.LocaCode = commonFunctions.GlobalLocation;
                                            new T_DIliveryHedDL().Selectt_DIliveryHed(dh,2);
                                            dh.Dispatched = 1;
                                            dh.DispatchedDate = DateTime.Now;
                                            dh.DispatchedUser = commonFunctions.Loginuser;
                                            new T_DIliveryHedDL().Savet_DIliveryHedSP(dh, 3);

                                            T_OrderTracking track = new T_OrderTracking();
                                            track.DONo = drow.Cells["Do Number"].Value.ToString();
                                            track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.DoNumber);
                                            track.Dispatched = 1;
                                            track.DispatchedUser = commonFunctions.Loginuser;
                                            track.DispatchedDate = DateTime.Now;
                                            track.PackingListCreated = 1;
                                            track.PackingListDate = DateTime.Now;
                                            track.PackingListNo = txt_PackingNo.Text.Trim();
                                            track.PackingListUser = commonFunctions.Loginuser;
                                            new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);
                                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);

                                            UpdateStock(drow.Cells["Do Number"].Value.ToString());



                                        }

                                    }
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                                }

                                performButtons(xEnums.PerformanceType.Print);
                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();
                                //clear text fields
                                textareaFunctions(true);

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_PackingNo.Text = commonFunctions.GetSerial(formID.Trim());
                                txt_Driver.Focus();

                                }
                                catch (Exception ex)
                                {
                                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                    commonFunctions.SetMDIStatusMessage("Genaral Error when approving the delivery order", 1);
                                }
                            }
                        }
                        else if (formMode == 3)
                        {
                            T_packinghead objt_trnsferNote = new T_packinghead();
                            objt_trnsferNote.PackingNo = txt_PackingNo.Text.Trim();
                            objt_trnsferNote = new T_packingheadDL().Selectt_packinghead(objt_trnsferNote);


                            if (objt_trnsferNote.Processed == 0)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    T_packingdet objt_OrderFormDet = new T_packingdet();
                                    objt_OrderFormDet.PackingNo = txt_PackingNo.Text;
                                    List<T_packingdet> list = new List<T_packingdet>();
                                    list = new T_packingdetDL().SelectT_packingdetMulti(objt_OrderFormDet);

                                    foreach (T_packingdet detx in list)
                                    {
                                        new T_packingdetDL().Savet_packingdetSP(detx, 4);
                                    }


                                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                                    {
                                        if (drow.Cells["Do Number"].Value.ToString().Trim() != null)
                                        {
                                            T_packingdet objt_packingdet = new T_packingdet();
                                            objt_packingdet.PackingNo = txt_PackingNo.Text.Trim();
                                            objt_packingdet.Dono = drow.Cells["Do Number"].Value.ToString();
                                            objt_packingdet.Customer = drow.Cells["Customer"].Value.ToString();
                                            objt_packingdet.Agent = drow.Cells["Agent"].Value.ToString();
                                            objt_packingdet.datex = DateTime.Now;
                                            objt_packingdet.TTLCartons = commonFunctions.ToDecimal(drow.Cells["Cartons"].Value.ToString());
                                            new T_packingdetDL().Savet_packingdetSP(objt_packingdet, 1);

                                        }

                                    }


                                    objt_trnsferNote.RefNumber = txt_RefNumber.Text.Trim();
                                    objt_trnsferNote.Vehicle = txt_Vehicle.Text.Trim();
                                    objt_trnsferNote.Driver = txt_Driver.Text.Trim();
                                    new T_packingheadDL().Savet_packingheadSP(objt_trnsferNote, 3);

                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());


                                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                       

                                        objt_trnsferNote.Processed = 1;
                                        objt_trnsferNote.ProcessedDate = DateTime.Now;
                                        objt_trnsferNote.ProcessedUser = commonFunctions.Loginuser;
                                        new T_packingheadDL().Savet_packingheadSP(objt_trnsferNote, 3);

                                        foreach (DataGridViewRow drow in dataGridView1.Rows)
                                        {
                                            if (drow.Cells["Do Number"].Value.ToString().Trim() != null)
                                            {

                                                T_DIliveryHed dh = new T_DIliveryHed();
                                                dh.DoNo = drow.Cells["Do Number"].Value.ToString();
                                                new T_DIliveryHedDL().Selectt_DIliveryHed(dh,2);
                                                dh.Dispatched = 1;
                                                dh.DispatchedDate = DateTime.Now;
                                                dh.DispatchedUser = commonFunctions.Loginuser;
                                                new T_DIliveryHedDL().Savet_DIliveryHedSP(dh, 3);

                                                T_OrderTracking track = new T_OrderTracking();
                                                track.DONo = drow.Cells["Do Number"].Value.ToString();
                                                track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.DoNumber);
                                                track.Dispatched = 1;
                                                track.DispatchedUser = commonFunctions.Loginuser;
                                                track.DispatchedDate = DateTime.Now;
                                                track.PackingListCreated = 1;
                                                track.PackingListDate = DateTime.Now;
                                                track.PackingListNo = txt_PackingNo.Text.Trim();
                                                track.PackingListUser = commonFunctions.Loginuser;
                                                new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);

                                                UpdateStock(drow.Cells["Do Number"].Value.ToString());

                                                commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);


                                            }

                                        }



                                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                                    }

                                    performButtons(xEnums.PerformanceType.Print);
                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    textareaFunctions(true);
                                    FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    txt_PackingNo.Text = commonFunctions.GetSerial(formID.Trim());

                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_PackingNo, "Invoice number you have entered already processed.You cannot changed data now");
                            }
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_PackingNo.Enabled = true;
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

                        if (txt_PackingNo.Text.Trim() != "")
                        {
                            T_packinghead objt_trnsferNoteS = new T_packinghead();
                            objt_trnsferNoteS.PackingNo = txt_PackingNo.Text.Trim();
                            objt_trnsferNoteS = new T_packingheadDL().Selectt_packinghead(objt_trnsferNoteS);
                            if (objt_trnsferNoteS == null)
                            {
                                errorProvider1.SetError(txt_PackingNo, "Invalid packing list number");
                                return;
                            }

                            if (objt_trnsferNoteS.Processed == 1)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    PrintDoc(txt_PackingNo.Text.Trim());
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_PackingNo, "Packing List is not processed");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_PackingNo, "Please enter Order form number to print");

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

        #region stockrelatedNEws

        private void UpdateStock(string donum)
        {
            try
            {
                T_DiliveryDet dodetlist = new T_DiliveryDet();
                dodetlist.DoNo = donum;
                List<T_DiliveryDet> dodet = new List<T_DiliveryDet>();
                dodet = new T_DiliveryDetDL().SelectT_DiliveryDetMulti(dodetlist);
                foreach (T_DiliveryDet det in dodet)
                {
                    T_Stock objt_Stock = new T_Stock();
                    objt_Stock.StockCode = det.Item;
                    objt_Stock.Compcode = commonFunctions.GlobalCompany;
                    objt_Stock.Locacode = commonFunctions.GlobalLocation;
                    objt_Stock = new T_StockDL().Selectt_Stock_new(objt_Stock);

                    decimal currentst = decimal.Zero;
                    currentst = commonFunctions.ToDecimal(objt_Stock.Stock.ToString()) - commonFunctions.ToDecimal(det.Qty.ToString());

                    objt_Stock.Stock = currentst;
                    objt_Stock.ReservedStock -= det.Qty;
                    new T_StockDL().SaveT_StockSP(objt_Stock, 3,1);
                }
            }
            catch (Exception ex)
            {
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                throw ex;
            }
        }

       #endregion

 

        private void PrintDoc(string DocNo)
        {
            string reporttitle = @"PACKING LIST\DISPATCH NOTE".ToUpper();
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

            string str = ReportStrings.GetPAckingPrintSTR(DocNo.Trim());
            rpt_packinglist rptBank = new rpt_packinglist();
            rptBank.SetDataSource(commonFunctions.GetDatatable(str));
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
                txt_Driver.Text = "";
                txt_Driver_name.Text = "";
                txt_Vehicle.Text = "";
                txt_Lorry_name.Text = "";
                dtx.Clear();
                dataGridView1.Refresh();
                txt_noOfPeaces.Text = "0";
                txt_noOfItems.Text = "0";

                txt_code.Text = "";
                txt_invoiceamt.Text = "";
                txt_customer.Text = "";
                txt_customer_name.Text = "";
                txt_agent.Text = "";
                txt_agent_name.Text = "";
                txt_ttlcartons.Text = "";

                txt_Remarks.Enabled = true;
                txt_Locacode.Enabled = true;
                txt_Driver.Enabled = true;
                txt_Driver_name.Enabled = true;

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

        #region FindExisitingOrder

        private void FindExisitingOrder(string GrnNo)
        {
            try
            {
                if (T_packingheadDL.ExistingT_packinghead(GrnNo.Trim()))
                {
                    formMode = 1;
                    //clear datagrid
                    dtx.Clear();
                    dataGridView1.Refresh();

                    performButtons(xEnums.PerformanceType.Edit);


                    T_packinghead cat = new T_packinghead();
                    cat.PackingNo = GrnNo.Trim();
                    cat = new T_packingheadDL().Selectt_packinghead(cat);

                    //load and disable the data fields

                    txt_Locacode.Text = cat.LocaCode.Trim();
                    txt_Driver.Text = cat.Driver.Trim();
                    txt_Vehicle.Text = cat.Vehicle;
                    txt_RefNumber.Text = cat.RefNumber;

                    textareaFunctions(false);

                    T_packingdet req = new T_packingdet();
                    req.PackingNo = GrnNo.Trim();
                    List<T_packingdet> requests = new List<T_packingdet>();
                    requests = new T_packingdetDL().SelectT_packingdetMulti(req);

                  
                    foreach (T_packingdet det in requests)
                    {
                        M_Customers cus = new M_Customers();
                        cus.CusID = det.Customer;
                        cus = new M_CustomerDL().Selectm_Customer(cus);

                        M_Agents age = new M_Agents();
                        age.AgentCode = det.Agent;
                        age = new M_AgentDL().Selectm_Agent(age);
                        commonFunctions.AddRowPacking(dtx, det.Dono, det.Customer, det.Agent, "0.00", cus.CustName, age.Namex, det.TTLCartons.ToString());

                    }

                }
                else
                {
                    if (formMode != 1)
                    {
                        lbl_processes.Visible = false;
                        errorProvider1.SetError(txt_PackingNo, "Invoice Number you have entered does not exists in the system.");
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

        private void txt_PackingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Locacode.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_PackingNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["PackingListFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["PackingListSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["PackingListField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingOrder(txt_PackingNo.Text.Trim());
            }
            FindExisitingOrder(txt_PackingNo.Text.Trim());

        }

        private void txt_Locacode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_RefNumber.Focus();
            }
        }

        private void txt_RefNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Vehicle.Focus();
            }
        }

        private void txt_Vehicle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Driver.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_Vehicle.Name.Trim())
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

        private void txt_Driver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Remarks.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_Driver.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["EMPFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["EMPSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["EMPField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
        }

        private void txt_Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
            }
        }

        private void txt_Vehicle_TextChanged(object sender, EventArgs e)
        {
            txt_Lorry_name.Text = findExisting.FindExisitingVehicle(txt_Vehicle.Text);
        }

        private void txt_Driver_TextChanged(object sender, EventArgs e)
        {
            txt_Driver_name.Text = findExisting.FindExisitingUSer(txt_Driver.Text);
        }

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_code.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_code, "Please enter Delivery order number to proceede");
                    return;
                }
                if (!T_DIliveryHedDL.ExistingT_DIliveryHed(txt_code.Text.Trim()))
                {
                    errorProvider1.SetError(txt_code, "Delivery order you have entered does not exist on the system");
                    return;
                }
                if (!IsExistDO(dataGridView1, txt_code.Text))
                {
                    T_DIliveryHed objt_trnsferNote = new T_DIliveryHed();
                    objt_trnsferNote.DoNo = txt_code.Text.Trim();
                    objt_trnsferNote.LocaCode = commonFunctions.GlobalLocation;
                    T_DIliveryHedDL balprocess = new T_DIliveryHedDL();
                    objt_trnsferNote = balprocess.Selectt_DIliveryHed(objt_trnsferNote,2);
                    if (objt_trnsferNote != null)
                    {
                        if (objt_trnsferNote.Audited == 0)
                        {
                            errorProvider1.SetError(txt_code, "Delivery order you have entered does not audited.");
                            return;
                        }



                        commonFunctions.AddRowPacking(dtx, txt_code.Text.Trim(), txt_customer.Text.Trim(), txt_agent.Text.Trim(), txt_invoiceamt.Text.Trim(), txt_customer_name.Text.Trim(), txt_agent_name.Text.Trim(), txt_ttlcartons.Text.Trim());
                    }
                    else {
                        errorProvider1.SetError(txt_code, "Delivery order you have entered already dispatched.");
                    }
                }
                //else {
                //    AddRowtogridDistribute(dataGridView1, txt_code.Text.Trim(), txt_customer.Text.Trim(), txt_agent.Text.Trim(), txt_invoiceamt.Text.Trim(), txt_customer_name.Text.Trim(), txt_agent_name.Text.Trim(), txt_ttlcartons.Text.Trim());
                //}
                txt_code.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_code.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["DOFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["DOSQL"].ToString() + " and Dispatched = 0";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["DOField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
        }


        public static bool IsExistDO(DataGridView dataGridView1, string codex)
        {
            bool exx = false;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Do Number"].Value != null)
                {
                    string s = drow.Cells["Do Number"].Value.ToString().Trim().ToUpper();
                    if (drow.Cells["Do Number"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        exx = true;
                    }
                }
            }
            return exx;
        }


        public void AddRowtogridDistribute(DataGridView dataGridView1, string donumber, string customer, string agent, string amount, string customername, string agentname, string ttl)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Do Number"].Value != null)
                {
                    if (drow.Cells["Do Number"].Value.ToString().Trim().ToUpper() == donumber.Trim().ToUpper())
                    {
                        drow.Cells["Customer"].Value = customer;
                        drow.Cells["Customer Name"].Value = customername;
                        drow.Cells["Agent"].Value = agent;
                        drow.Cells["Agent Name"].Value = agentname;
                        drow.Cells["Amount"].Value = amount;
                        drow.Cells["Cartons"].Value = ttl;
                    }
                }
            }
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_code.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_code, "Please enter Delivery order number to proceede");
                    return;
                }
                if (!T_DIliveryHedDL.ExistingT_DIliveryHed(txt_code.Text.Trim()))
                {
                    errorProvider1.SetError(txt_code, "Delivery order you have entered does not exist on the system");
                    return;
                }

                T_DIliveryHed delhed = new T_DIliveryHed();
                T_DIliveryHedDL deldl = new T_DIliveryHedDL();
                delhed.DoNo = txt_code.Text.Trim();
                delhed.LocaCode = commonFunctions.GlobalLocation;
                delhed = deldl.Selectt_DIliveryHed(delhed,2);

                txt_invoiceamt.Text = delhed.InvoiceAmount.ToString();
                txt_customer.Text = delhed.Customer;
                txt_agent.Text = delhed.Agent;
                txt_ttlcartons.Text = delhed.NoOfCartons.ToString();
            }
            catch (Exception ex) { }

        }

        private void txt_customer_TextChanged(object sender, EventArgs e)
        {
            if (txt_customer.Text.Trim() == "") {
                return;
            }
            txt_customer_name.Text = findExisting.FindExisitingCUstomer(txt_customer.Text.Trim());
        }

        private void txt_agent_TextChanged(object sender, EventArgs e)
        {
            if (txt_agent.Text.Trim() == "")
            {
                return;
            }
            txt_agent_name.Text = findExisting.FindExisitingAgent(txt_agent.Text.Trim());
        }

        private void txt_PackingNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //lbl_name.Text = e.ColumnIndex.ToString() + "     -    " + e.RowIndex.ToString();
            txt_NoOfCartons.Text = GetCumTotalCatorns(dataGridView1).ToString();
        }

        public static decimal GetCumTotalCatorns(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[0].Value != null)
                {
                    total += commonFunctions.ToDecimal(drow.Cells[2].Value.ToString());
                }
            }
            return total;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            txt_NoOfCartons.Text = GetCumTotalCatorns(dataGridView1).ToString();
        }

    }
}
