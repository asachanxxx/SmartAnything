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
    public partial class frm_agents : Form
    {

        int formMode = 0;
        string formID = "A0001";
        string formHeadertext = "Agents";

        #region Loading one instance

        private static frm_agents objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_agents getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_agents();

            }
            return objSingleObject;

        }

        #endregion

        public frm_agents()
        {
            InitializeComponent();
        }

        private void frm_agents_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
            }
        }

        #region GetData

        private void GetData()
        {
            try
            {

                M_AgentDL bdl = new M_AgentDL();
                dataGridView1.DataSource = bdl.SelectAllm_Agent();

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
        private void SetValues(String sm_Agent)
        {
            try
            {
                M_AgentDL objm_AgentDL = new M_AgentDL();
                M_Agents objm_Agent = new M_Agents();
                if (sm_Agent != "")
                {
                    objm_Agent.AgentCode = sm_Agent;
                    objm_Agent = objm_AgentDL.Selectm_Agent(objm_Agent);
                    if (objm_Agent != null)
                    {
                        txt_AgentCode.Text = objm_Agent.AgentCode.ToString();
                        txt_Namex.Text = objm_Agent.Namex.ToString();
                        txt_Address1.Text = objm_Agent.Address1.ToString();
                        txt_Address2.Text = objm_Agent.Address2.ToString();
                        txt_Address3.Text = objm_Agent.Address3.ToString();
                        txt_TPOffice.Text = objm_Agent.TPOffice.ToString();
                        txt_TPPersonal.Text = objm_Agent.TPPersonal.ToString();
                        txt_Fax.Text = objm_Agent.Fax.ToString();
                        txt_Email.Text = objm_Agent.Email.ToString();
                        txt_AccNo.Text = objm_Agent.AccNo.ToString();
                        txt_NICno.Text = objm_Agent.NICno.ToString();
                        txt_PassportNo.Text = objm_Agent.PassportNo.ToString();
                        txt_remarks.Text = objm_Agent.Remarks;
                        txt_AreaCode.Text = objm_Agent.District;
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

                    if (ActiveControl.Name.Trim() == txt_AgentCode.Name.Trim())
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

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    formMode = 1;
                    txt_AgentCode.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_AgentCode.Enabled = false;
                    txt_Namex.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    errorProvider1.Clear();
                    try
                    {
                        if (txt_Namex.Text.Trim() == "")
                        {

                            errorProvider1.SetError(txt_Namex, "Please enter a agent name !");
                            return;
                        }
                        if (txt_AgentCode.Text.Trim() == "")
                        {

                            errorProvider1.SetError(txt_AgentCode, "Please enter a Agent Code !");
                            return;
                        }


                        if (formMode == 1)
                        {
                            if (M_AgentDL.ExistingM_Agent(txt_AgentCode.Text.Trim()))
                            {

                                errorProvider1.SetError(txt_AgentCode, "The agent code you have entered already exists!");
                                return;
                            }
                            if (!M_AreaDL.ExistingM_Area(txt_AreaCode.Text.Trim()))
                            {

                                errorProvider1.SetError(txt_AreaCode, "The area code you have entered already exists!");
                                return;
                            }

                           

                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {
                                M_Agents objm_Agent = new M_Agents();
                                objm_Agent.AgentCode = txt_AgentCode.Text.Trim();
                                objm_Agent.Namex = txt_Namex.Text.Trim();
                                objm_Agent.Address1 = txt_Address1.Text.Trim();
                                objm_Agent.Address2 = txt_Address2.Text.Trim();
                                objm_Agent.Address3 = txt_Address3.Text.Trim();
                                objm_Agent.TPOffice = txt_TPOffice.Text.Trim();
                                objm_Agent.TPPersonal = txt_TPPersonal.Text.Trim();
                                objm_Agent.Fax = txt_Fax.Text.Trim();
                                objm_Agent.Email = txt_Email.Text.Trim();
                                objm_Agent.AccNo = txt_AccNo.Text.Trim();
                                objm_Agent.NICno = txt_NICno.Text.Trim();
                                objm_Agent.PassportNo = txt_PassportNo.Text.Trim();
                                objm_Agent.Datex = DateTime.Now;// txt_Datex.Text.Trim();
                                objm_Agent.userx = commonFunctions.Loginuser;// txt_userx.Text.Trim();
                                objm_Agent.TimeFrom = dte_from.Value;
                                objm_Agent.TimeTo = dte_to.Value;
                                objm_Agent.District = txt_AreaCode.Text;
                                objm_Agent.Remarks = txt_remarks.Text;
                                M_AgentDL bal = new M_AgentDL();
                                bal.SaveM_AgentSP(objm_Agent, 1);


                                GetData();

                                txt_AgentCode.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                            }
                        }
                        else if (formMode == 3)
                        {
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_Agents objm_Agent = new M_Agents();
                                objm_Agent.AgentCode = txt_AgentCode.Text.Trim();
                                objm_Agent = new M_AgentDL().Selectm_Agent(objm_Agent);
                                objm_Agent.Namex = txt_Namex.Text.Trim();
                                objm_Agent.Address1 = txt_Address1.Text.Trim();
                                objm_Agent.Address2 = txt_Address2.Text.Trim();
                                objm_Agent.Address3 = txt_Address3.Text.Trim();
                                objm_Agent.TPOffice = txt_TPOffice.Text.Trim();
                                objm_Agent.TPPersonal = txt_TPPersonal.Text.Trim();
                                objm_Agent.Fax = txt_Fax.Text.Trim();
                                objm_Agent.Email = txt_Email.Text.Trim();
                                objm_Agent.AccNo = txt_AccNo.Text.Trim();
                                objm_Agent.NICno = txt_NICno.Text.Trim();
                                objm_Agent.PassportNo = txt_PassportNo.Text.Trim();
                                objm_Agent.Datex = DateTime.Now;// txt_Datex.Text.Trim();
                                objm_Agent.userx = commonFunctions.Loginuser;// txt_userx.Text.Trim();
                                objm_Agent.TimeFrom = dte_from.Value;
                                objm_Agent.TimeTo = dte_to.Value;
                                objm_Agent.District = txt_AreaCode.Text;
                                objm_Agent.Remarks = txt_remarks.Text;
                                M_AgentDL bal = new M_AgentDL();
                                bal.SaveM_AgentSP(objm_Agent, 3);


                                GetData();
                                txt_AgentCode.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                        commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_AgentCode.Enabled = true;
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
                    errorProvider1.Clear();
                    break;
                case xEnums.PerformanceType.Print:
                    UserDefineMessages.ShowMsg1("Print still in process", UserDefineMessages.Msg_Information);
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

        #region  txt_KeyDown

        private void txt_AgentCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Namex.Focus();
            }
        }

        private void txt_Namex_KeyDown(object sender, KeyEventArgs e)
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
                txt_AccNo.Focus();
            }
        }

        private void txt_AccNo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                txt_NICno.Focus();
            }
        }

        private void txt_NICno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_AreaCode.Focus();
            }
        }

        private void txt_PassportNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_remarks.Focus();
            }
        }

        private void txt_remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_AgentCode.Focus();
            }
        }


        private void txt_TPPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_TPOffice.Focus();
            }
        }

        private void txt_TPOffice_KeyDown(object sender, KeyEventArgs e)
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
                txt_Fax.Focus();
            }
        }

        private void txt_Fax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_from.Focus();
            }

        }

        private void dte_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dte_to.Focus();
            }
        }

        private void dte_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_PassportNo.Focus();
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

        private void txt_AreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_TPPersonal.Focus();
                FindExisitingCategory();
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
            try
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
            catch (Exception ex) { 
            
            }
        }

        private void txt_AreaCode_TextChanged(object sender, EventArgs e)
        {
            FindExisitingCategory();
        }

  
       
     
        

    }
}
