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
using SmartAnything.Reports.MasterRpt;

namespace SmartAnything.UI
{
    public partial class frm_suppliers : Form
    {

        int formMode = 0;
        string formID = "A0012";
        string formHeadertext = "Suppliers";


        #region Loading one instance

        private static frm_suppliers objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_suppliers getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_suppliers();

            }
            return objSingleObject;

        }

        #endregion

        public frm_suppliers()
        {
            InitializeComponent();
        }

        private void frm_suppliers_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            FunctionButtonStatus(xEnums.PerformanceType.Default);
            commonFunctions.FormatDataGrid(dataGridView1);
            commonFunctions.HandleTextBoxes(panel3);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
            GetData();
        }

        #region GetData

        private void GetData()
        {
            try
            {

                M_SupplierDL bdl = new M_SupplierDL();
                dataGridView1.DataSource = bdl.SelectAllm_Supplier();

                if (dataGridView1.DataSource != null)
                {

                    dataGridView1.Columns[0].Width = 120;
                    dataGridView1.Columns[1].Width = 585;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  SetValues
        private void SetValues(String sm_Supplier)
        {
            try
            {
                M_SupplierDL objm_SupplierDL = new M_SupplierDL();
                M_Suppliers objm_Supplier = new M_Suppliers();
                if (sm_Supplier != "")
                {
                    objm_Supplier.SupID = sm_Supplier;
                    objm_Supplier = objm_SupplierDL.Selectm_Supplier(objm_Supplier);
                    if (objm_Supplier != null)
                    {
                        txt_SupID.Text = objm_Supplier.SupID.ToString();
                        txt_suppName.Text = objm_Supplier.suppName.ToString();
                        txt_TP.Text = objm_Supplier.TP.ToString();
                        txt_Fax.Text = objm_Supplier.Fax.ToString();
                        txt_Email.Text = objm_Supplier.Email.ToString();
                        txt_Address1.Text = objm_Supplier.Address1.ToString();
                        txt_Address2.Text = objm_Supplier.Address2.ToString();
                        txt_Address3.Text = objm_Supplier.Address3.ToString();
                        txt_ContactPerson.Text = objm_Supplier.ContactPerson.ToString();
                        txt_ContactPersonNo.Text = objm_Supplier.ContactPersonNo.ToString();
                        formMode = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

            switch (xenum)
            {
                case xEnums.PerformanceType.View:

                    if (ActiveControl.Name.Trim() == txt_SupID.Name.Trim())
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

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    //txt_IDX.Text = commonFunctions.GetSerial("A0009");
                    formMode = 1;
                    txt_SupID.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_SupID.Enabled = false;
                    txt_suppName.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:


                    if (txt_suppName.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_suppName, "Please enter a supplier name !");
                        return;
                    }

                    if (txt_SupID.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_SupID, "Please enter a supplier code !");
                        commonFunctions.SetMDIStatusMessage("Please enter a supplier code.", 1);
                        return;
                    } 


                    if (formMode == 1)
                    {
                        if (M_SupplierDL.ExistingM_Supplier(txt_SupID.Text.Trim()))
                        {

                            errorProvider1.SetError(txt_SupID, "The supplier code you have entered already exists!");
                            return;
                        }



                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {
                            M_Suppliers objm_Supplier = new M_Suppliers();
                            objm_Supplier.SupID = txt_SupID.Text.Trim();
                            objm_Supplier.suppName = txt_suppName.Text.Trim();
                            objm_Supplier.CompCode = commonFunctions.GlobalCompany;
                            objm_Supplier.Locacode = commonFunctions.GlobalLocation;
                            objm_Supplier.TP = txt_TP.Text.Trim();
                            objm_Supplier.Fax = txt_Fax.Text.Trim();
                            objm_Supplier.Email = txt_Email.Text.Trim();
                            objm_Supplier.Address1 = txt_Address1.Text.Trim();
                            objm_Supplier.Address2 = txt_Address2.Text.Trim();
                            objm_Supplier.Address3 = txt_Address3.Text.Trim();
                            objm_Supplier.ContactPerson = txt_ContactPerson.Text.Trim();
                            objm_Supplier.ContactPersonNo = txt_ContactPersonNo.Text.Trim();
                            objm_Supplier.CurrentStatus = "";
                            M_SupplierDL bal = new M_SupplierDL();
                            bal.SaveM_SupplierSP(objm_Supplier, 1);

                            GetData();

                            txt_SupID.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                            
                        }
                    }
                    else if (formMode == 3)
                    {
                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {

                            M_Suppliers objm_Supplier = new M_Suppliers();
                            objm_Supplier.SupID = txt_SupID.Text.Trim();
                            objm_Supplier.suppName = txt_suppName.Text.Trim();
                            objm_Supplier.CompCode = commonFunctions.GlobalCompany;
                            objm_Supplier.Locacode = commonFunctions.GlobalLocation;
                            objm_Supplier.TP = txt_TP.Text.Trim();
                            objm_Supplier.Fax = txt_Fax.Text.Trim();
                            objm_Supplier.Email = txt_Email.Text.Trim();
                            objm_Supplier.Address1 = txt_Address1.Text.Trim();
                            objm_Supplier.Address2 = txt_Address2.Text.Trim();
                            objm_Supplier.Address3 = txt_Address3.Text.Trim();
                            objm_Supplier.ContactPerson = txt_ContactPerson.Text.Trim();
                            objm_Supplier.ContactPersonNo = txt_ContactPersonNo.Text.Trim();
                            objm_Supplier.CurrentStatus = "";
                            M_SupplierDL bal = new M_SupplierDL();
                            bal.SaveM_SupplierSP(objm_Supplier, 3);


                            GetData();
                            txt_SupID.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                        }

                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_SupID.Enabled = true;
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
                    errorProvider1.Clear();

                    
                    break;
                case xEnums.PerformanceType.Print:
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        string reporttitle = "List of All suppliers".ToUpper();
                        frm_reportViwer rpt = new frm_reportViwer();
                        rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                        rpt.FormHeadertext = reporttitle;

                        ParameterField paramField = new ParameterField();
                        ParameterFields paramFields = new ParameterFields();

                        paramFields = commonFunctions.AddCrystalParams(reporttitle, commonFunctions.Loginuser.ToUpper());

                        string str = "SELECT * FROM M_Suppliers";

                        rpt_m_suppliers rptBank = new rpt_m_suppliers();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(str));
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
                        //txt_IDX.Enabled = true;
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
                        dataGridView1.Enabled = false;
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
                        dataGridView1.Enabled = false;
                        //txt_IDX.Enabled = false;

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
                        //txt_IDX.Enabled = true;
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
                        btn_new.Enabled = true;
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

        private void txt_SupID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_suppName.Focus();
            }
        }

        private void txt_suppName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Address1.Focus();
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
                txt_Fax.Focus();
            }
        }

        private void txt_Fax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SupID.Focus();
            }
        }

      
    }
}
