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
using SmartAnything.Reports.MasterRpt;

namespace SmartAnything.UI
{
    public partial class frm_customers : Form
    {

        int formMode = 0;
        string formID = "A0007";
        string formHeadertext = "Customers";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_customers objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_customers getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_customers();

            }
            return objSingleObject;

        }

        #endregion

        public frm_customers()
        {
            InitializeComponent();
        }

        private void frm_customers_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.FormatDataGrid(dataGridView1);
                commonFunctions.FormatDataGrid(dataGridView2);
                commonFunctions.HandleTextBoxes(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
                dtx = commonFunctions.CreateDatatableAgents();
                dataGridView2.DataSource = dtx;
                dataGridView2.Columns[0].Width = 110;
                dataGridView2.Columns[1].Width = 230;
                GetData();
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }

    

      

        private bool discountHandling() {

            bool ok = false;
            bool ok2 = false;
            decimal min1 = decimal.Zero;
            decimal max1 = decimal.Zero;
            decimal appli1 = decimal.Zero;

            min1 = commonFunctions.ToDecimal(txt_MinDisc.Text.Trim());
            max1 = commonFunctions.ToDecimal(txt_MaxDisc.Text.Trim());
            appli1 = commonFunctions.ToDecimal(txt_ApplyingDisc.Text.Trim());

            if ((min1 > max1))
            {
                errorProvider1.SetError(txt_MinDisc,"Minimum discount shoud less than maximum Discount");
                errorProvider1.SetError(txt_MaxDisc, "Minimum discount shoud less than maximum Discount");
            }
            else {
                ok = true;
                errorProvider1.Clear();
            }

            if ((appli1 < max1) && (appli1 > min1))
            {
                ok2 = true;
                errorProvider1.Clear();
            }
            else {
                errorProvider1.SetError(txt_ApplyingDisc, "Applicable Discount should between Min and Max Discounts");
            }

            if (ok && ok2)
            {
                return true;
            }
            else {
                return false;
            }
            
        }

        #region GetData

        private void GetData()
        {
            try
            {

                M_CustomerDL bdl = new M_CustomerDL();

                DataTable dt = bdl.SelectAllm_Customer();
                dataGridView1.DataSource = dt;

                if (dataGridView1.DataSource != null)
                {

                    dataGridView1.Columns[0].HeaderText = "Customer Code";
                    dataGridView1.Columns[1].HeaderText = "Customer Name";

                    dataGridView1.Columns[0].Width = 180;
                    dataGridView1.Columns[1].Width = 540;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  SetValues
        private void SetValues(String sm_Customer)
        {
            try
            {
                M_CustomerDL objm_CustomerDL = new M_CustomerDL();
                M_Customers objm_Customer = new M_Customers();
                if (sm_Customer != "")
                {
                    objm_Customer.CusID = sm_Customer;
                    objm_Customer = objm_CustomerDL.Selectm_Customer(objm_Customer);
                    if (objm_Customer != null)
                    {
                        txt_CusID.Text = objm_Customer.CusID.ToString();
                        //txt_Compcode.Text = objm_Customer.Compcode.ToString();
                        //txt_CusID.Text = objm_Customer.Locacode.ToString();
                        txt_CustName.Text = objm_Customer.CustName.ToString();
                        txt_TP.Text = objm_Customer.TP.ToString();
                        txt_Fax.Text = objm_Customer.Fax.ToString();
                        txt_Email.Text = objm_Customer.Email.ToString();
                        txt_Address1.Text = objm_Customer.Address1.ToString();
                        txt_Address2.Text = objm_Customer.Address2.ToString();
                        txt_Address3.Text = objm_Customer.Address3.ToString();
                        txt_ContactPerson.Text = objm_Customer.ContactPerson.ToString();
                        txt_ContactPersonNo.Text = objm_Customer.ContactPersonNo.ToString();
                        //txt_CurrentStatus.Text = objm_Customer.CurrentStatus.ToString();
                        txt_Gradex.Text = objm_Customer.Gradex.ToString();
                        txt_CreditLimit.Text = objm_Customer.CreditLimit.ToString();
                        txt_CreditPeriod.Text = objm_Customer.CreditPeriod.ToString();
                        txt_MaxDisc.Text = objm_Customer.MaxDisc.ToString();
                        txt_MinDisc.Text = objm_Customer.MinDisc.ToString();
                        txt_ApplyingDisc.Text = objm_Customer.ApplyingDisc.ToString();
                        txt_salesman.Text = objm_Customer.SalesMan;
                        txt_AreaCode.Text = objm_Customer.Area;
                        txt_cat.Text = objm_Customer.cat;
                        txt_subcat.Text = objm_Customer.subcat;
                        formMode = 0;

                        dtx.Clear();
                        dataGridView2.Refresh();

                        M_CushasAgents req = new M_CushasAgents();
                        req.CustomerCode = objm_Customer.CusID.ToString();
                        List<M_CushasAgents> requests = new List<M_CushasAgents>();
                        requests = new M_CushasAgentDL().SelectM_CushasAgentMulti(req);

                        foreach (M_CushasAgents det in requests)
                        {

                            commonFunctions.AddRowAgents(dtx,det.AgentCode, findExisting.FindExisitingAgent(det.AgentCode));
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        dataGridView1.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        dataGridView1.Enabled = true;

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
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
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
                        dataGridView1.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = false;
                    }
                    break;
                case xEnums.PerformanceType.Exit:
                    break;
                case xEnums.PerformanceType.New:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = false;

                    }
                    break;
                case xEnums.PerformanceType.Default:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        btn_save.Enabled = false;
                        btn_cancel.Enabled = false;
                        dataGridView1.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        dataGridView1.Enabled = true;
                    }


                    break;
                case xEnums.PerformanceType.Cancel:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = true;

                    }
                    break;
            }

        }

        #endregion

        #region performButtons Area

        private void performButtons(xEnums.PerformanceType xenum)
        {

            switch (xenum)
            {
                case xEnums.PerformanceType.View:

                    if (ActiveControl.Name.Trim() == txt_CusID.Name.Trim())
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

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    formMode = 1;
                    txt_subcat_name.Text = "";
                    txt_subcat.Text = "";
                    txt_cat_name.Text = "";
                    txt_cat.Text = "";
                    txt_salesman_name.Text = "";
                    txt_salesman.Text = "";
                    txt_Areaname.Text = "";
                    txt_AreaCode.Text = "";
                    txt_ApplyingDisc.Text = "0.00";
                    txt_MinDisc.Text = "0.00";
                    txt_MaxDisc.Text = "0.00";
                    txt_CreditPeriod.Text = "0.00";
                    txt_CreditLimit.Text = "0.00";
                    txt_CusID.Text = "";
                    txt_CustName.Text = "";
                    txt_cat.Text = "";
                    txt_subcat.Text = "";
                    dtx.Clear();
                    dataGridView2.Refresh();

                    txt_ContactPerson.Text = "";
                    txt_ContactPersonNo.Text = "";
                    txt_Fax.Text = "";
                    txt_TP.Text = "";
                    txt_Address3.Text = "";
                    txt_Email.Text = "";
                    txt_Address1.Text = "";
                    txt_Address2.Text = "";


                    txt_CusID.Focus();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_CusID.Enabled = false;
                    txt_CustName.Focus();
                    break;

                case xEnums.PerformanceType.Save:

                    try
                    {
                        if (!discountHandling())
                        {
                            return;
                        }

                        if (txt_CusID.Text.Trim() == "")
                        {

                            errorProvider1.SetError(txt_CusID, "Please enter a customer code !");
                            return;
                        }

                        if (txt_CustName.Text.Trim() == "")
                        {
                            errorProvider1.SetError(txt_CustName, "Please enter a customer name !");
                            return;
                        }

                        if (formMode == 1)
                        {
                            if (M_CustomerDL.ExistingM_Customer(txt_CusID.Text.Trim()))
                            {

                                //UserDefineMessages.ShowMsg("The Customer code you have entered already exists!", UserDefineMessages.Msg_Warning);
                                errorProvider1.SetError(txt_CusID, "The Customer code you have entered already exists!");
                                return;
                            }

                            if (!M_AreaDL.ExistingM_Area(txt_AreaCode.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_AreaCode, "Area does not exists on the system ");
                                return;
                            }

                            if (!U_UserxDL.ExistingU_User(txt_salesman.Text.Trim()))
                            {
                                errorProvider1.SetError(txt_salesman, "Salesman does not exists on the system ");
                                return;
                            }

                            if (commonFunctions.GetNoofItemsIndexBase(dataGridView2) <= 0)
                            {
                                errorProvider1.SetError(dataGridView2, "Please asign some agents to this customer.");
                                return;
                            }



                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                M_Customers objm_Customer = new M_Customers();
                                objm_Customer.CusID = txt_CusID.Text.Trim();
                                objm_Customer.Compcode = commonFunctions.GlobalCompany;//txt_Compcode.Text.Trim();
                                objm_Customer.Locacode = commonFunctions.GlobalLocation;//txt_Locacode.Text.Trim();
                                objm_Customer.CustName = txt_CustName.Text.Trim();
                                objm_Customer.TP = txt_TP.Text.Trim();
                                objm_Customer.Fax = txt_Fax.Text.Trim();
                                objm_Customer.Email = txt_Email.Text.Trim();
                                objm_Customer.Address1 = txt_Address1.Text.Trim();
                                objm_Customer.Address2 = txt_Address2.Text.Trim();
                                objm_Customer.Address3 = txt_Address3.Text.Trim();
                                objm_Customer.ContactPerson = txt_ContactPerson.Text.Trim();
                                objm_Customer.ContactPersonNo = txt_ContactPersonNo.Text.Trim();
                                objm_Customer.CurrentStatus = "";// txt_CurrentStatus.Text.Trim();
                                objm_Customer.Gradex = txt_Gradex.Text.Trim();
                                objm_Customer.CreditLimit = commonFunctions.ToDecimal(txt_CreditLimit.Text.Trim());
                                objm_Customer.CreditPeriod = int.Parse(txt_CreditPeriod.Text.Trim());
                                objm_Customer.MaxDisc = commonFunctions.ToDecimal(txt_MaxDisc.Text.Trim());
                                objm_Customer.MinDisc = commonFunctions.ToDecimal(txt_MinDisc.Text.Trim());
                                objm_Customer.ApplyingDisc = commonFunctions.ToDecimal(txt_ApplyingDisc.Text.Trim());
                                objm_Customer.CusOpenBal = decimal.Zero;
                                objm_Customer.customerOS = decimal.Zero;
                                objm_Customer.CusCurBal = decimal.Zero;
                                objm_Customer.pointsEarned = decimal.Zero;
                                objm_Customer.controlAccountCode = "";
                                objm_Customer.customerAccountCode = "";
                                objm_Customer.GLUpdate = false;
                                objm_Customer.triggerVal = 1;
                                objm_Customer.Area = txt_AreaCode.Text.Trim();
                                objm_Customer.SalesMan = txt_salesman.Text;
                                objm_Customer.cat = txt_cat.Text;
                                objm_Customer.subcat = txt_subcat.Text;

                                M_CustomerDL bal = new M_CustomerDL();
                                bal.SaveM_CustomerSP(objm_Customer, 1);

                                foreach (DataGridViewRow drow in dataGridView2.Rows)
                                {
                                    if (drow.Cells[0].Value.ToString().Trim() != null)
                                    {
                                        M_CushasAgents objm_CushasAgent = new M_CushasAgents();
                                        objm_CushasAgent.AgentCode = drow.Cells[0].Value.ToString();
                                        objm_CushasAgent.CustomerCode = txt_CusID.Text;
                                        objm_CushasAgent.Datex = DateTime.Now;
                                        objm_CushasAgent.userx = commonFunctions.Loginuser;
                                        new M_CushasAgentDL().Savem_CushasAgentSP(objm_CushasAgent, 1);
                                    }
                                }



                                GetData();

                                txt_CusID.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                                

                            }
                        }
                        else if (formMode == 3)
                        {
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_Customers objm_Customer = new M_Customers();
                                objm_Customer.CusID = txt_CusID.Text.Trim();
                                objm_Customer = new M_CustomerDL().Selectm_Customer(objm_Customer);
                                objm_Customer.Compcode = commonFunctions.GlobalCompany;//txt_Compcode.Text.Trim();
                                objm_Customer.Locacode = commonFunctions.GlobalLocation;//txt_Locacode.Text.Trim();
                                objm_Customer.CustName = txt_CustName.Text.Trim();
                                objm_Customer.TP = txt_TP.Text.Trim();
                                objm_Customer.Fax = txt_Fax.Text.Trim();
                                objm_Customer.Email = txt_Email.Text.Trim();
                                objm_Customer.Address1 = txt_Address1.Text.Trim();
                                objm_Customer.Address2 = txt_Address2.Text.Trim();
                                objm_Customer.Address3 = txt_Address3.Text.Trim();
                                objm_Customer.ContactPerson = txt_ContactPerson.Text.Trim();
                                objm_Customer.ContactPersonNo = txt_ContactPersonNo.Text.Trim();
                                objm_Customer.CurrentStatus = "";// txt_CurrentStatus.Text.Trim();
                                objm_Customer.Gradex = txt_Gradex.Text.Trim();
                                objm_Customer.CreditLimit = commonFunctions.ToDecimal(txt_CreditLimit.Text.Trim());
                                objm_Customer.CreditPeriod = int.Parse(txt_CreditPeriod.Text.Trim());
                                objm_Customer.MaxDisc = commonFunctions.ToDecimal(txt_MaxDisc.Text.Trim());
                                objm_Customer.MinDisc = commonFunctions.ToDecimal(txt_MinDisc.Text.Trim());
                                objm_Customer.ApplyingDisc = commonFunctions.ToDecimal(txt_ApplyingDisc.Text.Trim());
                                objm_Customer.cat = txt_cat.Text;
                                objm_Customer.subcat = txt_subcat.Text;
                                objm_Customer.SalesMan = txt_salesman.Text;

                                new M_CustomerDL().SaveM_CustomerSP(objm_Customer, 3);

                                M_CushasAgents xx = new M_CushasAgents();
                                xx.CustomerCode = txt_CusID.Text.Trim();
                                List<M_CushasAgents> agents = new List<M_CushasAgents>();
                                agents = new M_CushasAgentDL().SelectM_CushasAgentMulti(xx);

                                foreach (M_CushasAgents age in agents) {
                                    new M_CushasAgentDL().Savem_CushasAgentSP(age, 4);
                                }

                                foreach (DataGridViewRow drow in dataGridView2.Rows)
                                {
                                    if (drow.Cells[0].Value.ToString().Trim() != null)
                                    {
                                        M_CushasAgents objm_CushasAgent = new M_CushasAgents();
                                        objm_CushasAgent.AgentCode = drow.Cells[0].Value.ToString();
                                        objm_CushasAgent.CustomerCode = txt_CusID.Text;
                                        objm_CushasAgent.Datex = DateTime.Now;
                                        objm_CushasAgent.userx = commonFunctions.Loginuser;
                                        new M_CushasAgentDL().Savem_CushasAgentSP(objm_CushasAgent, 1);
                                    }
                                }




                                GetData();
                                txt_CusID.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                
                                commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);

                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                        commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
                    }

                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_CusID.Enabled = true;
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
                    break;
                case xEnums.PerformanceType.Print:
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        string reporttitle = "List of All Customers".ToUpper();
                        frm_reportViwer rpt = new frm_reportViwer();
                        rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                        rpt.FormHeadertext = reporttitle;

                        ParameterField paramField = new ParameterField();
                        ParameterFields paramFields = new ParameterFields();

                        paramFields = commonFunctions.AddCrystalParams(reporttitle, commonFunctions.Loginuser.ToUpper());

                        rpt_m_Customers rptBank = new rpt_m_Customers();
                        M_CustomerDL bankdlx = new M_CustomerDL();
                        rptBank.SetDataSource(bankdlx.SelectAllm_CustomerAll());
                        rpt.RepViewer.ParameterFieldInfo = paramFields;
                        rpt.RepViewer.ReportSource = rptBank;
                        rpt.RepViewer.Refresh();
                        rpt.Show();
                    }

                    break;


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

        #region dataGridView1_RowEnter

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool isnew = dataGridView1.Rows[e.RowIndex].IsNewRow;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                SetValues(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

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

        #region txt__KeyDown events

        private void txt_CusID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                performButtons(xEnums.PerformanceType.View);
                SetValues(txt_CusID.Text.Trim());
            }
            if (e.KeyCode == Keys.Enter)
            {
                SetValues(txt_CusID.Text.Trim());
                txt_CustName.Focus();
            }
        }

        private void txt_CustName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_AreaCode.Focus();
            }
        }

        private void txt_Address1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Address2.Focus();
            }
        }

        private void txt_Address2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Address3.Focus();
            }
        }

        private void txt_Address3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Email.Focus();
            }
        }

        private void txt_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_TP.Focus();
            }
        }

        private void txt_TP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ContactPerson.Focus();
            }
        }

        private void txt_ContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ContactPersonNo.Focus();
            }
        }

        private void txt_ContactPersonNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Fax.Focus();
            }
        }

        private void txt_Fax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Gradex.Focus();
            }
        }

        private void txt_Gradex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_CreditLimit.Focus();
            }
        }

        private void txt_CreditLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_CreditPeriod.Focus();
            }
        }

        private void txt_CreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_MaxDisc.Focus();
            }
        }

        private void txt_MaxDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_MinDisc.Focus();
            }
        }

        private void txt_MinDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ApplyingDisc.Focus();
            }
        }

        private void txt_ApplyingDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Address1.Focus();
            }
        }
        #endregion

        private void txt_MaxDisc_Validating(object sender, CancelEventArgs e)
        {
            discountHandling();
        }

        private void txt_MinDisc_Validating(object sender, CancelEventArgs e)
        {
            discountHandling();
        }

        private void txt_ApplyingDisc_Validating(object sender, CancelEventArgs e)
        {
            discountHandling();
        }

        private void txt_CreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_CreditPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_MaxDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_MinDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_ApplyingDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_AreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingCategory();
                txt_salesman.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_AreaCode.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["AreaFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["AreaSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["AreaField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingCategory();
            }
        }

        private void FindExisitingCategory()
        {
            if (M_AreaDL.ExistingM_Area(txt_AreaCode.Text.Trim()))
            {
                M_Area cat = new M_Area();
                cat.AreaCode = txt_AreaCode.Text.Trim();
                M_AreaDL dl = new M_AreaDL();
                cat = dl.Selectm_Area(cat);
                txt_AreaCode.Text = cat.AreaCode.Trim();
                txt_Areaname.Text = cat.Descri;
            }
            else
            {
                txt_Areaname.Text = "<Area Not Exists.>";
            }
        }

        private void txt_agents_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                if (!M_AgentDL.ExistingM_Agent(txt_agents.Text.Trim()))
                {
                    errorProvider1.SetError(txt_agents, "Agent does not exists on the system ");
                    return;
                }

                
                if (commonFunctions.IsExistINV(dataGridView2, txt_agents.Text))
                {
                    return;
                }
                commonFunctions.AddRowAgents(dtx, txt_agents.Text, txt_agents_name.Text.Trim());
            }

            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_agents.Name.Trim())
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

        private void txt_agents_TextChanged(object sender, EventArgs e)
        {
            txt_agents_name.Text = findExisting.FindExisitingAgent(txt_agents.Text);
        }

        private void txt_salesman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_salesman_name.Text = findExisting.FindExisitingUSer(txt_salesman.Text);
                txt_cat.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_salesman.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["UserFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["UserSQL"].ToString() + " where  TYPE = 'SAL' ";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["UserField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                txt_salesman_name.Text = findExisting.FindExisitingUSer(txt_salesman.Text);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_subcat.Focus();
                txt_cat_name.Text = findExisting.FindExisitingCustomerCategory(txt_cat.Text);
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_cat.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CuscatFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CuscatSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CuscatField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                txt_cat_name.Text = findExisting.FindExisitingCustomerCategory(txt_cat.Text);
            }
        }

        private void txt_subcat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Gradex.Focus();
                txt_subcat_name.Text = findExisting.FindExisitingCustomerSub(txt_subcat.Text, txt_cat.Text);
            }

            if (e.KeyCode == Keys.F2)
            {
                if (txt_cat.Text.Trim() != "")
                {

                    if (ActiveControl.Name.Trim() == txt_subcat.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["CussubcatFieldLength"]);
                        string[] strSearchField = new string[length];

                        string strSQL = ConfigurationManager.AppSettings["CussubcatSQL"].ToString() + " WHERE CatID = '" + txt_cat.Text + "'";

                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["CussubcatField" + m + ""].ToString();
                        }

                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }
                }
                txt_subcat_name.Text = findExisting.FindExisitingCustomerSub(txt_subcat.Text, txt_cat.Text);

            }
        }

        private void txt_cat_TextChanged(object sender, EventArgs e)
        {
            txt_cat_name.Text = findExisting.FindExisitingCustomerCategory(txt_cat.Text);
        }

        private void txt_subcat_TextChanged(object sender, EventArgs e)
        {
            txt_subcat_name.Text = findExisting.FindExisitingCustomerSub(txt_cat.Text, txt_subcat.Text);
        }

        private void txt_Address1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Address2.Focus();
            }
        }

        private void txt_Address2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Address3.Focus();
            }
        }

        private void txt_Address3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Email.Focus();
            }
        }

        private void txt_Email_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ContactPerson.Focus();
            }
        }

        private void txt_ContactPerson_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ContactPersonNo.Focus();
            }
        }

        private void txt_ContactPersonNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_TP.Focus();
            }
        }

        private void txt_TP_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Fax.Focus();
            }
        }

        private void txt_Fax_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_CusID.Focus();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_AreaCode_TextChanged(object sender, EventArgs e)
        {
            FindExisitingCategory();
        }

        private void txt_salesman_TextChanged(object sender, EventArgs e)
        {
            txt_salesman_name.Text = findExisting.FindExisitingUSer(txt_salesman.Text);
        }

       

    }
}
