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

namespace SmartAnything
{
    public partial class Banks : Form
    {


        int formMode =0;
        string formID = "A0003";
        string loginUSer = "Admin"; //this must be get from global data
        string formHeadertext = "Banks";


        private static Banks objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static Banks getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new Banks();

            }
            return objSingleObject;

        }




        public Banks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            M_Bank objbank = new M_Bank();
            objbank.BANK_CODE = txt_bankcode.Text.Trim();
            objbank.BANK_NAME = txt_name.Text.Trim().ToUpper();
            
            M_BankDL bal = new M_BankDL();
            bal.SaveBankSP(objbank, 1);
            GetData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            M_Bank objbank = new M_Bank();
            objbank.BANK_CODE = txt_bankcode.Text.Trim();
            objbank.BANK_NAME = txt_name.Text.Trim().ToUpper();

            M_BankDL bal = new M_BankDL();
            bal.SaveBankSP(objbank, 3);
            GetData();
        }

        private void GetData()
        {
            try
            {

                M_BankDL bdl = new M_BankDL();
                dataGridView1.DataSource = bdl.SelectAllBanks();

                if (dataGridView1.DataSource != null)
                {

                    dataGridView1.Columns[0].HeaderText = "Bank Code";
                    dataGridView1.Columns[1].HeaderText = "Bank Name";

                    dataGridView1.Columns[0].Width = 180;
                    dataGridView1.Columns[1].Width = 525;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Load the initial data
            GetData();
            this.WindowState = FormWindowState.Maximized;
            //adjust the button enable disable status according to functions and security
            FunctionButtonStatus(xEnums.PerformanceType.Default);
            //format the datagridview
            commonFunctions.FormatDataGrid(dataGridView1);
            //format the textboxes
            commonFunctions.HandleTextBoxes(panel3);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

   
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
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;

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
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;

                    }
                    break;
                case xEnums.PerformanceType.Exit:
                    break;
                case xEnums.PerformanceType.New:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;

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
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;

                    }


                    break;
                case xEnums.PerformanceType.Cancel:
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
            }

        }

        #endregion

        #region performButtons Area
        private void performButtons(xEnums.PerformanceType xenum)
        {

            switch (xenum)
            {
                case xEnums.PerformanceType.View:

                    if (ActiveControl.Name.Trim() == txt_bankcode.Name.Trim())
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
                    txt_bankcode.Focus();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 2;
                    txt_name.Focus();
                    break;

                case xEnums.PerformanceType.Save:

                    if (txt_bankcode.Text.Trim() == "")
                    {

                        errorProvider1.SetError(txt_bankcode, "Please enter a bank Code !");
                        return;
                    }
                    if (txt_name.Text.Trim() == "")
                    {

                        errorProvider1.SetError(txt_name, "Please enter a bank name !");
                        return;
                    }

                    if (formMode == 1)
                    {
                        if (M_BankDL.ExistingBank(txt_bankcode.Text.Trim()))
                        {

                            UserDefineMessages.ShowMsg("The bank code you have entered already exists!", UserDefineMessages.Msg_Warning);
                            return;
                        }

                       

                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {
                            M_Bank objbank = new M_Bank();
                            objbank.BANK_CODE = txt_bankcode.Text.Trim();
                            objbank.BANK_NAME = txt_name.Text.Trim().ToUpper();

                            M_BankDL bal = new M_BankDL();
                            bal.SaveBankSP(objbank, 1);
                            GetData();

                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                            
                        }
                    }
                    else if (formMode == 2)
                    {
                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {

                            M_Bank objbank = new M_Bank();
                            objbank.BANK_CODE = txt_bankcode.Text.Trim();
                            objbank.BANK_NAME = txt_name.Text.Trim().ToUpper();

                            M_BankDL bal = new M_BankDL();
                            bal.SaveBankSP(objbank, 3);
                            GetData();
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                        }

                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
                    break;
                case xEnums.PerformanceType.Print:

                    string reporttitle = "List of All Banks".ToUpper();
                    frm_reportViwer rpt = new frm_reportViwer();
                    rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                    rpt.FormHeadertext = reporttitle;

                    ParameterField paramField = new ParameterField();
                    ParameterFields paramFields = new ParameterFields();

                    paramFields = commonFunctions.AddCrystalParams(reporttitle , commonFunctions.Loginuser);

                    rpt_banks rptBank = new rpt_banks();
                    M_BankDL bankdlx = new M_BankDL();
                    rptBank.SetDataSource(bankdlx.SelectAllBanks());
                    rpt.RepViewer.ParameterFieldInfo = paramFields;
                    rpt.RepViewer.ReportSource = rptBank;
                    rpt.RepViewer.Refresh();
                    rpt.Show();


                    break;


            }

        }
        #endregion

        private void SetValues(String Bank)
        {
            try
            {
                M_BankDL objBankBL = new M_BankDL();
                M_Bank objBank = new M_Bank();

                if (Bank != "")
                {
                    objBank.BANK_CODE = Bank;
                    objBank = objBankBL.SelectBank(objBank);

                    if (objBank != null)
                    {
                        txt_bankcode.Text = objBank.BANK_CODE.ToString();
                        txt_name.Text = objBank.BANK_NAME.ToString();

                        //EnableCtrl(false);
                        formMode = 3;

                        //EnableMainContral(formMode, null); //Enable main Buton Contrals 0:NEW  3:EXSISTING RECORD 

                    }
                    else // IF object IS NULL CHECK USER CAN HAVE PERMITION SAVE,EDIT ,DELETE 
                    {
                        //EnableCtrl(true);
                        //if (AccessValidate("C") == true) //IN USER PERMITION 'C' CHECK USER HAVE PERMETION TO DO THE ACTION                  
                        //{
                        //    EnableMainContral(formMode, null); //Enable main Buton Contrals 0:NEW  3:EXSISTING RECORD 
                        //    txtName.Focus();
                        //}
                    }
                }
                else
                {
                    //EnableCtrl(true);

                    //if (intFlagOtherFrm == 0) // If record comes from other form Then Dont Call Enable contrall
                    //    EnableMainContral(formMode, null); //Enable main Buton Contrals 0:NEW  3:EXSISTING RECORD 
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), strFormName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool isnew = dataGridView1.Rows[e.RowIndex].IsNewRow;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                SetValues(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.New);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Edit);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Cancel);

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Save);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData) { 
            
                case Keys.Control | Keys.N:
                    performButtons(xEnums.PerformanceType.New);
                    break;
                case Keys.Control | Keys.E:
                    performButtons(xEnums.PerformanceType.Edit);
                    break;
                case Keys.Control | Keys.S:
                    performButtons(xEnums.PerformanceType.Save);
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

        private void btn_print_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Print);
        }

        private void txt_bankcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txt_name.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                performButtons(xEnums.PerformanceType.View);
            }

        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_bankcode.Focus();
            }

        }

        private void Banks_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void Banks_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        
    }
}
