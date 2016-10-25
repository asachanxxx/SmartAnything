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
    public partial class frm_saleman : Form
    {

        int formMode = 0;
        string formID = "A0011";
        string formHeadertext = "Employees";


        #region Loading one instance

        private static frm_saleman objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_saleman getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_saleman();

            }
            return objSingleObject;

        }

        #endregion

        public frm_saleman()
        {
            InitializeComponent();
        }

        private void frm_saleman_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            FunctionButtonStatus(xEnums.PerformanceType.Default);
            commonFunctions.FormatDataGrid(dataGridView1);
            commonFunctions.HandleTextBoxes(panel3);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
            txt_paymeth.SelectedIndex = 0;
            GetData();
        }

        #region GetData

        private void GetData()
        {
            try
            {

                U_UserxDL bdl = new U_UserxDL();
                dataGridView1.DataSource = bdl.SelectAllu_User();

                if (dataGridView1.DataSource != null)
                {

                    dataGridView1.Columns[0].Width = 120;
                    dataGridView1.Columns[1].Width = 485;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  SetValues
        private void SetValues(String sm_SalesMan)
        {
            try
            {
                U_UserxDL bdl = new U_UserxDL();
                u_Userxcc objm_SalesMan = new u_Userxcc();
                if (sm_SalesMan != "")
                {
                    objm_SalesMan.userId = sm_SalesMan;
                    objm_SalesMan = new U_UserxDL().Selectu_User(objm_SalesMan);
                    if (objm_SalesMan != null)
                    {
                        txt_SalesmanID.Text = objm_SalesMan.userId.ToString();
                        txt_SalesmanName.Text = objm_SalesMan.userName.ToString();
                        txt_TP.Text = objm_SalesMan.TP.ToString();
                        txt_Fax.Text = objm_SalesMan.Fax.ToString();
                        txt_Email.Text = objm_SalesMan.Email.ToString();
                        txt_Address1.Text = objm_SalesMan.Address1.ToString();
                        txt_Address2.Text = objm_SalesMan.Address2.ToString();
                        txt_Address3.Text = objm_SalesMan.Address3.ToString();
                        txt_ContactPerson.Text = objm_SalesMan.ContactPerson.ToString();
                        txt_ContactPersonNo.Text = objm_SalesMan.ContactPersonNo.ToString();
                        txt_nic.Text = objm_SalesMan.NICNo;
                        txt_paymeth.Text = objm_SalesMan.Type;
                        txtusergroup.Text = objm_SalesMan.roleId;
                        //txt_CurrentStatus.Text = objm_SalesMan.CurrentStatus.ToString();
                        //txt_Gradex.Text = objm_SalesMan.Gradex.ToString();
                        formMode = 3;
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

                    if (ActiveControl.Name.Trim() == txt_SalesmanID.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["SalesmanFieldLength"]);
                        string[] strSearchField = new string[length];

                        string strSQL = ConfigurationManager.AppSettings["SalesmanSQL"].ToString();

                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["SalesmanField" + m + ""].ToString();
                        }

                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    //txt_IDX.Text = commonFunctions.GetSerial("A0009");
                    formMode = 1;
                    txt_SalesmanID.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_SalesmanID.Enabled = false;
                    txt_SalesmanName.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    errorProvider1.Clear();
                    if (txt_SalesmanID.Text.Trim().ToUpper() == "ADMIN")
                    {
                        errorProvider1.SetError(txt_SalesmanID, "This user is the system administrator. you cannot change the details.");
                        commonFunctions.SetMDIStatusMessage("This user is the system administrator. you cannot change the details.", 1);
                        return;
                    }

                    if (txt_SalesmanID.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_SalesmanID, "User code cannot be a null value.");
                        commonFunctions.SetMDIStatusMessage("User code cannot be a null value.", 1);
                        return;
                    }
                    if (txt_SalesmanID.Text.Trim().Length < 5)
                    {
                        errorProvider1.SetError(txt_SalesmanID, "User code must be more than 6 charactors.");
                        commonFunctions.SetMDIStatusMessage("User code must be more than 6 charactors", 1);
                        return;
                    }
                 
                    if (txt_SalesmanName.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_SalesmanName, "User name cannot be a null value.");
                        commonFunctions.SetMDIStatusMessage("User name cannot be a null value.", 1);
                        return;
                    }

                    if (txtPw.Text == "")
                    {
                        errorProvider1.SetError(txtPw, "Password cannot be a null value.");
                        commonFunctions.SetMDIStatusMessage("Password cannot be a null value.", 1);
                        return;
                    }
                    if (txtPw.Text != txtRePw.Text)
                    {
                        errorProvider1.SetError(txtPw, "Password and the confirmation password must be same");
                        commonFunctions.SetMDIStatusMessage("Password and the confirmation password must be same.", 1);
                        return;
                    }
                    if (!U_UserRolexDL.ExistingU_UserRole(txtusergroup.Text.Trim()))
                    {
                        errorProvider1.SetError(txtusergroup, "User group already exists.");
                        commonFunctions.SetMDIStatusMessage("User group already exists.", 1);
                        return;
                    }

                    if (txt_SalesmanName.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_SalesmanName, "Please enter a employee name !");
                        commonFunctions.SetMDIStatusMessage("Please enter a employee name.", 1);
                        return;
                    }

                    if (txt_SalesmanID.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_SalesmanID, "Please enter a employee name !");
                        commonFunctions.SetMDIStatusMessage("Please enter a employee name.", 1);
                        return;
                    } 

                    if (formMode == 1)
                    {

                        if (U_UserxDL.ExistingU_User(txt_SalesmanID.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_SalesmanID, "User code already exists.");
                            commonFunctions.SetMDIStatusMessage("User code already exists.", 1);
                            return;
                        }
                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {
                            u_Userxcc obju_User = new u_Userxcc();
                            obju_User.userId = txt_SalesmanID.Text.Trim();
                            obju_User.userName = txt_SalesmanName.Text.Trim();
                            obju_User.password = commonFunctions.CreateCheckPassword(true, txtPw.Text.Trim());
                            obju_User.roleId = txtusergroup.Text.Trim();
                            obju_User.userCreated = commonFunctions.Loginuser;
                            obju_User.dateCreated = DateTime.Now;
                            obju_User.userModified = "";
                            obju_User.dateModified = DateTime.Now;
                            obju_User.isActive = 1;
                            obju_User.Type = txt_paymeth.Text.Trim().ToUpper();
                            obju_User.Compcode = commonFunctions.GlobalCompany;
                            obju_User.Locacode = commonFunctions.GlobalLocation;
                            obju_User.TP = txt_TP.Text.Trim();
                            obju_User.Fax = txt_Fax.Text.Trim();
                            obju_User.Email = txt_Email.Text.Trim();
                            obju_User.Address1 = txt_Address1.Text.Trim();
                            obju_User.Address2 = txt_Address2.Text.Trim();
                            obju_User.Address3 = txt_Address3.Text.Trim();
                            obju_User.ContactPerson = txt_ContactPerson.Text.Trim();
                            obju_User.ContactPersonNo = txt_ContactPersonNo.Text.Trim();
                            obju_User.CurrentStatus = "Active";
                            obju_User.Gradex = "Good";
                            obju_User.NICNo = txt_nic.Text.Trim();
                            new U_UserxDL().Saveu_UserSP(obju_User, 1);

                            GetData();

                            txt_SalesmanID.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                            
                        }
                    }
                    else if (formMode == 3)
                    {
                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {
                            u_Userxcc obju_User = new u_Userxcc();
                            obju_User.userId = txt_SalesmanID.Text.Trim();
                            obju_User = new U_UserxDL().Selectu_User(obju_User);

                            obju_User.userId = txt_SalesmanID.Text.Trim();
                            obju_User.userName = txt_SalesmanName.Text.Trim();
                            obju_User.password = commonFunctions.CreateCheckPassword(true, txtPw.Text.Trim());
                            obju_User.roleId = txtusergroup.Text.Trim();
                            obju_User.userCreated = commonFunctions.Loginuser;
                            obju_User.dateCreated = DateTime.Now;
                            obju_User.userModified = "";
                            obju_User.dateModified = DateTime.Now;
                            obju_User.isActive = 1;
                            obju_User.Type = txt_paymeth.Text.Trim().ToUpper();
                            obju_User.Compcode = commonFunctions.GlobalCompany;
                            obju_User.Locacode = commonFunctions.GlobalLocation;
                            obju_User.TP = txt_TP.Text.Trim();
                            obju_User.Fax = txt_Fax.Text.Trim();
                            obju_User.Email = txt_Email.Text.Trim();
                            obju_User.Address1 = txt_Address1.Text.Trim();
                            obju_User.Address2 = txt_Address2.Text.Trim();
                            obju_User.Address3 = txt_Address3.Text.Trim();
                            obju_User.ContactPerson = txt_ContactPerson.Text.Trim();
                            obju_User.ContactPersonNo = txt_ContactPersonNo.Text.Trim();
                            obju_User.CurrentStatus = "Active";
                            obju_User.Gradex = "Good";
                            obju_User.NICNo = txt_nic.Text.Trim();
                            new U_UserxDL().Saveu_UserSP(obju_User, 3);


                            GetData();
                            txt_SalesmanID.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                        }

                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_SalesmanID.Enabled = true;
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
                    errorProvider1.Clear();
                    break;
                case xEnums.PerformanceType.Print:
                    UserDefineMessages.ShowMsg1("Print still in process", UserDefineMessages.Msg_Information);
                    break;


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

        private void txt_SalesmanID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SalesmanName.Focus();
            }
        }

        private void txt_SalesmanName_KeyDown(object sender, KeyEventArgs e)
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
                txt_nic.Focus();
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
                txt_SalesmanID.Focus();
            }
        }

        private void txt_nic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Email.Focus();
            }
        }

        private void txtusergroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtusergroup_name.Text = findExisting.FindExisitingRole(txtusergroup.Text.Trim());
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txtusergroup.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["UserroleFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["UserroleSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["UserroleField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
        }

        private void txt_paymeth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CS (Cash)
            if (txt_paymeth.SelectedIndex == 0)
            {
                lbltransDesc.Text = "Salesman";
            }
            //CQ (Cheque)
            else if (txt_paymeth.SelectedIndex == 1)
            {
                lbltransDesc.Text = "Drivers";
            }
            //DR (DR)
            else if (txt_paymeth.SelectedIndex == 2)
            {
                lbltransDesc.Text = "Others";
            }
        }




    }
}
