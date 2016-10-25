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
    public partial class frm_creditnotegroup : Form
    {
        int formMode = 0;
        string formID = "A0020";
        string formHeadertext = "Credit Note Grouping";
        DataTable dtx = new DataTable();
        DataTable dtxCN = new DataTable();
        bool already = false;
        M_Products gloproduct = new M_Products();
        bool invoiceProcced = false;
        bool invoiceapproved = false;
        bool qtyexceed = false;

        #region Loading one instance

        private static frm_creditnotegroup objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_creditnotegroup getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_creditnotegroup();

            }
            return objSingleObject;

        }

        #endregion

        public frm_creditnotegroup()
        {
            InitializeComponent();
        }

        private void frm_creditnotegroup_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                //FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

                performButtons(xEnums.PerformanceType.New);

                dtx = commonFunctions.CreateDatatableCNGroup();
                dtxCN = commonFunctions.CreateDatatableCNGroup2();

                dataGridView2.DataSource = dtxCN;
                commonFunctions.FormatDataGrid(dataGridView2);
                dataGridView2.Columns[0].Width = 110;
                dataGridView2.Columns[1].Width = 200;

                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[2].Width = 140;
                //dataGridView1.Columns[3].Width = 140;
                //txt_code.Focus();


                //txt_LocaCode.Text = commonFunctions.GlobalLocation;
                //txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_LocaCode.Text.Trim());
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void txt_DocNo_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingCN(txt_DocNo.Text.Trim());
                txt_code.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_DocNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CNHFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CNHSQLFOrCNGrouping"].ToString();

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

        #region FindExisitingCN

        private void FindExisitingCN(string GrnNo)
        {
            if (GrnNo.Trim() != "")
            {
                if (T_CreditNoteHeadDL.ExistingT_CreditNoteHead(GrnNo.Trim()))
                {

                    T_CreditNoteHead cat = new T_CreditNoteHead();
                    cat.DocNo = GrnNo.Trim();
                    cat = new T_CreditNoteHeadDL().Selectt_CreditNoteHead(cat);

                    if (cat.Grouped == true) {
                        lbl_processes.Text = "Grouped".ToUpper();
                        lbl_processes.Visible = true;
                        errorProvider1.SetError(txt_DocNo, "Credit Note is already grouped.");
                        commonFunctions.SetMDIStatusMessage("Credit Note is already grouped.", 1);
                        return;
                    }

                    dtx.Clear();
                    dataGridView1.Refresh();

                    dtxCN.Clear();
                    dataGridView2.Refresh();

                    //clear error fields
                    errorProvider1.Clear();

                  
                    txt_CNtypes.Text = cat.TypeX.Trim();
                    lbl_creditnotetype.Text = findExisting.FindExisitingCNType(txt_CNtypes.Text);
                    ////set the process message and mode to edit mode
                    if (cat.Processed == false)
                    {
                        lbl_processes.Text = "UnProcessed".ToUpper();
                        lbl_processes.Visible = true;
                        errorProvider1.SetError(txt_DocNo, "UnProcessed Credit Note.");
                        commonFunctions.SetMDIStatusMessage("UnProcessed Credit Note.", 1);
                        return;
                    }
                    else
                    {
                        if (cat.Grouped == true)
                        {
                            lbl_processes.Text = "Processed/Grouped".ToUpper();
                            lbl_processes.Visible = true;

                        }
                        else
                        {
                            lbl_processes.Text = "Processed".ToUpper();
                            lbl_processes.Visible = true;
                        }
                    }



                    //load and disable the data fields

                    txt_LocaCode.Text = cat.LocaCode.Trim();
                    txt_Customer.Text = cat.CustomerID.Trim();
                    txt_ManualID.Text = cat.ManualID.Trim();
                    txt_Remarks.Text = cat.Remarks;
                    dte_date.Value = cat.Datex.Value;
                    txt_InvNo.Text = cat.InvNo;

                    textareaFunctions(false);

                    T_CNBreak req = new T_CNBreak();
                    req.DocNo = GrnNo.Trim();
                    List<T_CNBreak> requests = new List<T_CNBreak>();
                    requests = new T_CNBreakDL().SelectT_CNBreakMulti(req);

                    foreach (T_CNBreak det in requests)
                    {

                        commonFunctions.AddRowCreditNoteGrouping(dtx, det.ItemCode, findExisting.FindExisitingStock(det.ItemCode).Trim(), det.QTY.ToString());
                    }

                    T_CNGrouping group = new T_CNGrouping();
                    group.Docno = GrnNo.Trim();
                    List<T_CNGrouping> groups = new List<T_CNGrouping>();
                    groups = new T_CNGroupingDL().SelectT_CNGroupingMulti(group);

                    foreach (T_CNGrouping detx in groups)
                    {
                        commonFunctions.AddRowCNGrouping(dtxCN, detx.ItemCode, findExisting.FindExisitingStock(detx.ItemCode).Trim(), detx.CNType, detx.CNReason, detx.CNQTY.ToString(), detx.BreakdownQTY.ToString(), detx.TagNumber);
                    }

                }
                else
                {
                    //if (formMode != 1)
                    //{
                    lbl_processes.Text = "Invalied".ToUpper();
                    lbl_processes.Visible = true;
                    errorProvider1.SetError(txt_DocNo, "Invalied Credit Note Number.");
                    commonFunctions.SetMDIStatusMessage("Invalied Credit Note Number.", 1);
                    //}
                }
            }
            else {
                lbl_processes.Text = "".ToUpper();
                lbl_processes.Visible = true;
                commonFunctions.SetMDIStatusMessage("Please Enter Credit Note Number.", 2);
            }


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
                        //txt_DocNo.Text = commonFunctions.GetSerial(formID.Trim());
                        //txt_DocNo.Focus();
                        txt_Remarks.Text = "";
                        txt_InvNo.Text = "";
                        //txt_LocaCode.Text = commonFunctions.GlobalLocation;
                        //txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_LocaCode.Text.Trim());
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
                            T_CreditNoteHead objt_CreditNoteHead = new T_CreditNoteHead();

                            if (formMode == 1)
                            {

                                if (!T_CreditNoteHeadDL.ExistingT_CreditNoteHead(txt_DocNo.Text.Trim()))
                                {
                                    errorProvider1.SetError(txt_DocNo, "Credit Note not exists on the system. ");
                                    commonFunctions.SetMDIStatusMessage("Credit Note not exists on the system. ", 1);
                                    return;
                                }

                                if (txt_DocNo.Text.Trim() == "")
                                {
                                    errorProvider1.SetError(dataGridView1, "Please enter a valied credit note number.");
                                    commonFunctions.SetMDIStatusMessage("Please enter a valied credit note number.", 1);
                                    return;
                                }
                                else
                                {
                                    objt_CreditNoteHead.DocNo = txt_DocNo.Text.Trim();
                                    new T_CreditNoteHeadDL().Selectt_CreditNoteHead(objt_CreditNoteHead);

                                    if (objt_CreditNoteHead.Processed == false)
                                    {
                                        errorProvider1.SetError(dataGridView1, "This credit note number not processed.");
                                        commonFunctions.SetMDIStatusMessage("This credit note number not processed.", 1);
                                        return;
                                    }
                                }

                                if (commonFunctions.GetNoofItemsIndexBase(dataGridView2) <= 0)
                                {
                                    errorProvider1.SetError(dataGridView2, "Please enter breakdown details");
                                    commonFunctions.SetMDIStatusMessage("Please enter breakdown details", 1);
                                    return;
                                }

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    try
                                    {
                                        //u_DBConnection.BeginTrans();
                                        //save header data

                                        //delete the records if grouped == true
                                        if (objt_CreditNoteHead.Grouped == false)
                                        {
                                            T_CNGrouping objt_CNGrouping1 = new T_CNGrouping();
                                            List<T_CNGrouping> groupsx = new List<T_CNGrouping>();
                                            objt_CNGrouping1.Docno = txt_DocNo.Text.Trim();
                                            groupsx = new T_CNGroupingDL().SelectT_CNGroupingMulti(objt_CNGrouping1);
                                            foreach (T_CNGrouping gr in groupsx)
                                            {
                                                new T_CNGroupingDL().Savet_CNGroupingSP(gr, 4);
                                            }

                                            T_CNBreak xxx1 = new T_CNBreak();
                                            xxx1.DocNo = txt_DocNo.Text.Trim();
                                            List<T_CNBreak> xxxs1 = new List<T_CNBreak>();
                                            xxxs1 = new T_CNBreakDL().SelectT_CNBreakMulti(xxx1);
                                            foreach (T_CNBreak xx in xxxs1)
                                            {
                                                xx.BalanceQty = decimal.Zero;
                                                new T_CNBreakDL().Savet_CNBreakSP(xx, 3);
                                            }


                                            //save details 
                                            foreach (DataGridViewRow drow in dataGridView2.Rows)
                                            {
                                                if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                                {
                                                    T_CNGrouping objt_CNGrouping = new T_CNGrouping();
                                                    objt_CNGrouping.Docno = txt_DocNo.Text.Trim();
                                                    objt_CNGrouping.ItemCode = drow.Cells["Product Code"].Value.ToString();
                                                    objt_CNGrouping.Name = drow.Cells["Product Name"].Value.ToString();
                                                    objt_CNGrouping.CNType = drow.Cells["CN Type"].Value.ToString();
                                                    objt_CNGrouping.CNReason = drow.Cells["Reason"].Value.ToString();
                                                    objt_CNGrouping.InvoiceQty = commonFunctions.ToDecimal(drow.Cells["CN QTY"].Value.ToString());
                                                    objt_CNGrouping.CNQTY = commonFunctions.ToDecimal(drow.Cells["CN QTY"].Value.ToString());
                                                    objt_CNGrouping.BreakdownQTY = commonFunctions.ToDecimal(drow.Cells["QTY"].Value.ToString());
                                                    objt_CNGrouping.TagNumber = drow.Cells["Tag NO"].Value.ToString();
                                                    objt_CNGrouping.Selected = false;
                                                    objt_CNGrouping.SelectedQTY = objt_CNGrouping.BreakdownQTY;
                                                    objt_CNGrouping.balanceQTY = objt_CNGrouping.CNQTY - objt_CNGrouping.BreakdownQTY;
                                                    objt_CNGrouping.Shipped = false;
                                                    objt_CNGrouping.ShippedDate = DateTime.Now;
                                                    objt_CNGrouping.ShippedDO = "";
                                                    objt_CNGrouping.PartEntered = false;
                                                    objt_CNGrouping.CNnumber = txt_DocNo.Text.Trim();
                                                    new T_CNGroupingDL().Savet_CNGroupingSP(objt_CNGrouping, 1);


                                                    //update cnbreakdown 
                                                    T_CNBreak breakx = new T_CNBreak();
                                                    breakx.DocNo = objt_CNGrouping.Docno;
                                                    breakx.ItemCode = objt_CNGrouping.ItemCode;
                                                    breakx = new T_CNBreakDL().Selectt_CNBreak(breakx);
                                                    if (!breakx.Grouped.Value)
                                                    {
                                                        breakx.BalanceQty += objt_CNGrouping.BreakdownQTY;
                                                        if (breakx.BalanceQty == breakx.QTY)
                                                        {
                                                            breakx.Grouped = true;
                                                        }
                                                        new T_CNBreakDL().Savet_CNBreakSP(breakx, 3);
                                                    }
                                                }

                                            }
                                        }
                                        //u_DBConnection.CommitTrans();
                                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);

                                        T_CNBreak xxx = new T_CNBreak();
                                        xxx.DocNo = txt_DocNo.Text.Trim();
                                        List<T_CNBreak> xxxs = new List<T_CNBreak>();
                                        xxxs = new T_CNBreakDL().SelectT_CNBreakMulti(xxx);
                                        bool alreadyx = true;
                                        foreach (T_CNBreak xx in xxxs) {
                                            if (xx.Grouped == false) {
                                                alreadyx = false;
                                            }
                                        }

                                        if (!alreadyx) {
                                            errorProvider1.SetError(dataGridView1, "Breakdown not completed.Please complete it before process.");
                                            commonFunctions.SetMDIStatusMessage("Breakdown not completed.Please complete it before process.", 1);
                                            return;
                                        }

                                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                        {



                                            objt_CreditNoteHead.Grouped = true;
                                            objt_CreditNoteHead.GroupedDate = DateTime.Now;
                                            objt_CreditNoteHead.GroupedUser = commonFunctions.Loginuser;
                                            new T_CreditNoteHeadDL().Savet_CreditNoteHeadSP(objt_CreditNoteHead, 3);


                                            UpdateStock(objt_CreditNoteHead.DocNo);

                                            UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                        }



                                        //clear data in data grid 
                                        dtx.Rows.Clear();
                                        dataGridView1.Refresh();
                                        //clear text fields
                                        textareaFunctions(true);

                                        FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    }
                                    catch (Exception ex)
                                    {
                                        LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                                        commonFunctions.SetMDIStatusMessage("Error on saving Header and details data", 1);
                                    }
                                    txt_DocNo.Focus();
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

                     
                        txt_Remarks.Text = "";
                        txt_InvNo.Text = "";
                        

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


        #region stockrelatedNEws

        bool UpdateDamagestock(string StockCode, decimal qty)
        {
            bool bl = false;

            if (T_StockDL.ExistingT_StockDamage_new(StockCode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
            {
                T_StockDamage objt_Stock = new T_StockDamage();
                objt_Stock.StockCode = StockCode;
                objt_Stock.Compcode = commonFunctions.GlobalCompany;
                objt_Stock.Locacode = commonFunctions.GlobalLocation;
                objt_Stock = new T_StockDL().Selectt_Stock_new(objt_Stock);
                objt_Stock.Stock += qty;

                new T_StockDL().Savet_StockDamageSP(objt_Stock, 3);
            }
            else {
                T_Stock objt_Stock = new T_Stock();
                objt_Stock.StockCode = StockCode;
                objt_Stock.Compcode = commonFunctions.GlobalCompany;
                objt_Stock.Locacode = commonFunctions.GlobalLocation;
                objt_Stock = new T_StockDL().Selectt_Stock_new(objt_Stock);
                objt_Stock.Stock = qty;
                new T_StockDL().SaveT_StockSP(objt_Stock, 1, 2);
            }
           



            return bl;
        }

        private void UpdateStock(string packno)
        {
            try
            {
                T_CNGrouping objt_OrderFormDet = new T_CNGrouping();
                T_CNGroupingDL bal2 = new T_CNGroupingDL();
                objt_OrderFormDet.Docno = packno;
                List<T_CNGrouping> list = new List<T_CNGrouping>();
                list = bal2.SelectT_CNGroupingMulti(objt_OrderFormDet);

                foreach (T_CNGrouping det in list)
                {
                    //updating Master Stock

                    T_Stock objt_Stock = new T_Stock();
                    objt_Stock.StockCode = det.ItemCode;
                    objt_Stock.Compcode = commonFunctions.GlobalCompany;
                    objt_Stock.Locacode = commonFunctions.GlobalLocation;
                    objt_Stock = new T_StockDL().Selectt_Stock_new(objt_Stock);

                    

                    M_CNReason reason = new M_CNReason();
                    reason.ID = det.CNReason;
                    reason = new M_CNReasonDL().Selectm_CNReason(reason);
                    if (reason.NeedToUpdateStock == true)
                    {
                        if (det.CNType.Trim().ToUpper() == "CRN")
                        {

                            if (reason.StockType.Trim().ToUpper() == "MST")
                            {
                                decimal currentst = decimal.Zero;
                                currentst = commonFunctions.ToDecimal(objt_Stock.Stock.ToString()) + commonFunctions.ToDecimal(det.BreakdownQTY.ToString());
                                objt_Stock.Stock = currentst;
                                new T_StockDL().SaveT_StockSP(objt_Stock, 3, 1);

                            }
                            else if (reason.StockType.Trim().ToUpper() == "DST")
                            {
                                UpdateDamagestock(det.ItemCode, commonFunctions.ToDecimal(det.BreakdownQTY.ToString()));
                            }
                        }
                        else if (det.CNType.Trim().ToUpper() == "RPL")
                        {
                            if (reason.StockType.Trim().ToUpper() == "MST")
                            {
                                decimal currentst = decimal.Zero;
                                currentst = commonFunctions.ToDecimal(objt_Stock.Stock.ToString()) + commonFunctions.ToDecimal(det.BreakdownQTY.ToString());
                                objt_Stock.Stock = currentst;
                                new T_StockDL().SaveT_StockSP(objt_Stock, 3, 1);

                            }
                            else if (reason.StockType.Trim().ToUpper() == "DST")
                            {
                                UpdateDamagestock(det.ItemCode, commonFunctions.ToDecimal(det.BreakdownQTY.ToString()));
                            }
                        }
                        
                    }
                  
                }
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

        #region textareaFunctions

        private void textareaFunctions(bool stype)
        {
            if (stype == true)
            {

                txt_Remarks.Text = "";
                txt_LocaCode.Text = "";
                txt_locationId_name.Text = "";
                txt_Customer.Text = "";

                txt_code.Text = "";
                txt_cntype.Text = "";
                txt_reason.Text = "";
                txt_tagno.Text = "";
                txt_CNqty.Text = "0";

                txt_Customer_name.Text = "";
                dte_date.Value = DateTime.Now;
                //txt_CNqty.Text = "0.0000";
                //cmb_TypeX.SelectedIndex = 0;
                dtx.Clear();
                dataGridView1.Refresh();

                dtxCN.Clear();
                dataGridView2.Refresh();

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

        private void txt_DocNo_TextChanged(object sender, EventArgs e)
        {
            FindExisitingCN(txt_DocNo.Text.Trim());
        }

        private void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
        }

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
                ProductDet();
            }
        }

        private void ProductDet() {

            try
            {
                if (T_StockDL.ExistingT_Stock_new(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                {
                    if (!commonFunctions.IsExist(dataGridView1, txt_code.Text))
                    {
                        errorProvider1.Clear();

                        GetStockdetails();
                        //txt_qty.Text = "0";
                        //txt_qty.Focus();
                        already = false;
                    }
                    else
                    {
                        already = true;
                        GetStockdetails();

                        DataGridViewRow drowx = new DataGridViewRow();
                        drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());
                        //txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();
                        //txt_qty.Focus();
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


        private void GetStockdetails()
        {
            try
            {

                if (!T_StockDL.ExistingT_Stock_new(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                {
                    errorProvider1.SetError(txt_code, "Product you have entered not exist in the bin card");
                    commonFunctions.SetMDIStatusMessage("Product you have entered not exist in the bin card", 1);
                    return;
                }
                if (!commonFunctions.IsExist(dataGridView1, txt_code.Text))
                {
                    errorProvider1.SetError(txt_code, "Product you have entered does not belong to this credit note");
                    commonFunctions.SetMDIStatusMessage("Product you have entered does not belong to this credit note", 2);
                    return;
                }

                T_Stock stk = new T_Stock();
                stk.Locacode = commonFunctions.GlobalLocation;
                stk.Compcode = commonFunctions.GlobalCompany;
                stk.StockCode = txt_code.Text;
                stk = new T_StockDL().Selectt_Stock_new(stk);

                //txt_cost.Text = stk.CostPrice.ToString();
                //txt_selling.Text = stk.SellingPrice.ToString();
                lbl_name.Text = stk.Descr;
                //lbl_available.Text = stk.Stock.ToString();
                DataGridViewRow drowx = new DataGridViewRow();
                drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                lbl_CNQTY.Text = drowx.Cells["QTY"].Value.ToString();


                decimal currentqty = GetGridQty(dataGridView2, txt_code.Text.Trim());
                decimal CNqty = commonFunctions.ToDecimal(lbl_CNQTY.Text.Trim());
                decimal allowed = CNqty - currentqty;
                lbl_entered.Text = currentqty.ToString();
                lbl_allowed.Text = allowed.ToString();

                txt_cntype.Focus();

            }
            catch (Exception ex)
            {
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                throw ex;
            }
        }

        private void FindProduct() {
            try
            {
                txt_code.Text = commonFunctions.GetProcutCode(txt_code.Text.Trim());
                gloproduct = new M_Products();
                gloproduct.IDX = txt_code.Text.Trim();
                gloproduct = new M_ProductDL().Selectm_Product(gloproduct);

                if (gloproduct == null)
                {
                    errorProvider1.SetError(txt_code, "Product you have entered not exist in the bin card");
                    commonFunctions.SetMDIStatusMessage("Product you have entered not exist in the bin card", 2);
                    return;
                }

                //check if the stock code esizts on the DTX loacal copy if DTX is null then no CN no entered

                if (T_StockDL.ExistingT_Stock(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                {
                    if (!commonFunctions.IsExist(dataGridView1, txt_code.Text))
                    {
                        errorProvider1.SetError(txt_code, "Product you have entered does not belong to this credit note");
                        commonFunctions.SetMDIStatusMessage("Product you have entered does not belong to this credit note", 2);
                    }
                    else
                    {
                        already = true;
                        T_Stock stk = new T_Stock();
                        stk.Locacode = commonFunctions.GlobalLocation;
                        stk.Compcode = commonFunctions.GlobalCompany;
                        stk.ProductId = txt_code.Text.Trim();
                        T_StockDL bal = new T_StockDL();
                        stk = bal.Selectt_Stock(stk);
                        lbl_name.Text = stk.Descr;

                        DataGridViewRow drowx = new DataGridViewRow();
                        drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                        lbl_CNQTY.Text = drowx.Cells["QTY"].Value.ToString();
                        //txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();
                        errorProvider1.Clear();

                        decimal currentqty = GetGridQty(dataGridView2, txt_code.Text.Trim());
                        decimal CNqty = commonFunctions.ToDecimal(lbl_CNQTY.Text.Trim());
                        decimal allowed = CNqty - currentqty;
                        lbl_entered.Text = currentqty.ToString();
                        lbl_allowed.Text = allowed.ToString();

                        txt_cntype.Focus();
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
            }
        }

        private void txt_cntype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_cntype.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CNTypeFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CNTypeSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CNTypeField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
                errorProvider1.Clear();
            }
            if (e.KeyCode == Keys.Enter) {
                lbl_cntype.Text = findExisting.FindExisitingCNType(txt_cntype.Text);
                txt_reason.Focus();
            }
        }

        private void txt_cntype_TextChanged(object sender, EventArgs e)
        {
            lbl_cntype.Text = findExisting.FindExisitingCNType(txt_cntype.Text);
        }

        private void txt_reason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_reason.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CNReasonFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CNReasonSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CNReasonField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
                errorProvider1.Clear();
            }

            if (e.KeyCode == Keys.Enter)
            {
                lbl_CNreason.Text = findExisting.FindExisitingCNReason(txt_reason.Text);
                txt_CNqty.Focus();
            }
        }

        private void txt_reason_TextChanged(object sender, EventArgs e)
        {
            lbl_CNreason.Text = findExisting.FindExisitingCNReason(txt_reason.Text);
        }

        private void txt_CNqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                decimal x = commonFunctions.ToDecimal(txt_CNqty.Text.Trim());
                if (x > 0)
                {
                    decimal currentqty = GetGridQty(dataGridView2, txt_code.Text.Trim());
                    decimal CNqty = commonFunctions.ToDecimal(lbl_CNQTY.Text.Trim());
                    decimal canqty = x + currentqty;
                    decimal allowed = CNqty - currentqty;
                    lbl_entered.Text = currentqty.ToString();
                    lbl_allowed.Text = allowed.ToString();

                    if ((canqty) > CNqty)
                    {
                        errorProvider1.SetError(txt_CNqty, "Cannot add anymore pieces of this item. Credit Note Qunitity exceeded. ");
                        qtyexceed = true;
                    }
                    else {
                        qtyexceed = false;
                        txt_tagno.Text = "";
                        txt_tagno.Focus();
                    }

                    txt_tagno.Text = commonFunctions.GetSerial("A0064");


                }
                else
                {
                    errorProvider1.SetError(txt_CNqty, "Please enter quntity more than zero");
                }
                
            }
        }

      

        public static decimal GetGridQty(DataGridView dataGridView1,string code)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Product Code"].Value != null)
                {
                    if (drow.Cells["Product Code"].Value.ToString() == code.ToUpper())
                    {
                        decimal dx = commonFunctions.ToDecimal(drow.Cells["QTY"].Value.ToString());
                        total += dx;
                    }
                }
            }
            return total;
        }

        private void txt_tagno_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_tagno.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_tagno, "Please enter tag number");
                }
                else {
                    AddrecordToGrid();
                    
                }
            }
        }

        public static bool IsExist(DataGridView dataGridView1, string product,string cntype, string cnreason,string commingqty ,string commingtag )
        {
            bool exx = false;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {

                if (drow.Cells[0].Value != null)
                {
                    if (drow.Cells[0].Value.ToString().ToUpper().Trim().Equals(product.ToUpper().Trim()))
                    {
                        if (drow.Cells[2].Value.ToString().ToUpper().Trim().Equals(cntype.ToUpper().Trim()))
                        {
                            if (drow.Cells[3].Value.ToString().ToUpper().Trim().Equals(cnreason.ToUpper().Trim()))
                            {
                                exx = true;
                                drow.Cells[5].Value = commingqty;
                                drow.Cells[6].Value = commingtag;
                            }
                        }
                    }
                }
            }
            return exx;
        }



        private void AddrecordToGrid()
        {
            if (txt_tagno.Text.Trim() != "")
            {
                if (qtyexceed == false)
                {

                    if (!IsExist(dataGridView2, txt_code.Text.Trim(), txt_cntype.Text.Trim(), txt_reason.Text.Trim(), txt_CNqty.Text.Trim(),txt_tagno.Text.Trim()))
                    {
                        commonFunctions.AddRowCNGrouping(dtxCN, txt_code.Text, lbl_name.Text.Trim(), txt_cntype.Text.Trim().ToUpper(), txt_reason.Text.Trim(), lbl_CNQTY.Text.Trim(), txt_CNqty.Text.Trim(), txt_tagno.Text.Trim());
                        commonFunctions.IncrementSerial("A0064");
                        txt_tagno.Text = string.Empty;
                        txt_code.Focus();
                    }
                   
                }
                else
                {
                    errorProvider1.SetError(txt_CNqty, "Please enter quntity");
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    txt_code.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txt_code.Focus();
                }

            }
            catch (Exception ex)
            {
                //LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
            }
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
            ProductDet();
        }
    }
}
