﻿using System;
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
    public partial class frm_locations : Form
    {

        int formMode = 0;
        string formID = "A0008";
        string formHeadertext = "Company Locations";


        #region Loading one instance

        private static frm_locations objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_locations getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_locations();

            }
            return objSingleObject;

        }

        #endregion

        public frm_locations()
        {
            InitializeComponent();
        }

        private void frm_locations_Load(object sender, EventArgs e)
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
               
                M_LocaDL bdl = new M_LocaDL();
                dataGridView1.DataSource = bdl.SelectAllm_Loca();

                if (dataGridView1.DataSource != null)
                {

                    dataGridView1.Columns[0].HeaderText = "Location Code";
                    dataGridView1.Columns[1].HeaderText = "Location Name";

                    dataGridView1.Columns[0].Width = 180;
                    dataGridView1.Columns[1].Width = 525;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  SetValues
        private void SetValues(String sm_Loca)
        {
            try
            {
                M_LocaDL objm_LocaDL = new M_LocaDL();
                M_Loca objm_Loca = new M_Loca();
                if (sm_Loca != "")
                {
                    objm_Loca.Locacode = sm_Loca;
                    objm_Loca = objm_LocaDL.Selectm_Loca(objm_Loca);
                    if (objm_Loca != null)
                    {
                        txt_Locacode.Text = objm_Loca.Locacode.ToString();
                        txt_Locaname.Text = objm_Loca.Companycode.ToString();
                        //txt_StockCode.Text = objm_Loca.StockCode.ToString();
                        txt_Locaname.Text = objm_Loca.Locaname.ToString();
                        txt_Add1.Text = objm_Loca.Add1.ToString();
                        txt_Add2.Text = objm_Loca.Add2.ToString();
                        txt_Add3.Text = objm_Loca.Add3.ToString();
                        txt_Tpno.Text = objm_Loca.Tpno.ToString();
                        txt_Fax.Text = objm_Loca.Fax.ToString();
                        txt_Emailx.Text = objm_Loca.Emailx.ToString();
                        //txt_Userx.Text = objm_Loca.Userx.ToString();
                        //txt_Datex.Text = objm_Loca.Datex.ToString();
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

                    if (ActiveControl.Name.Trim() == txt_Locacode.Name.Trim())
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
                    txt_Locacode.Focus();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_Locacode.Enabled = false;
                    txt_Locaname.Focus();
                    break;

                case xEnums.PerformanceType.Save:

                    if (formMode == 1)
                    {
                        if (M_LocaDL.ExistingM_Loca(txt_Locacode.Text.Trim()))
                        {

                            UserDefineMessages.ShowMsg("The location code you have entered already exists!", UserDefineMessages.Msg_Warning);
                            return;
                        }

                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {
                            M_Loca objm_Loca = new M_Loca();
                            objm_Loca.Locacode = txt_Locacode.Text.Trim();
                            objm_Loca.Companycode = commonFunctions.GlobalCompany.Trim();
                            objm_Loca.StockCode = txt_Locacode.Text.Trim();
                            objm_Loca.Locaname = txt_Locaname.Text.Trim();
                            objm_Loca.Add1 = txt_Add1.Text.Trim();
                            objm_Loca.Add2 = txt_Add2.Text.Trim();
                            objm_Loca.Add3 = txt_Add3.Text.Trim();
                            objm_Loca.Tpno = txt_Tpno.Text.Trim();
                            objm_Loca.Fax = txt_Fax.Text.Trim();
                            objm_Loca.Emailx = txt_Emailx.Text.Trim();
                            objm_Loca.Userx = commonFunctions.Loginuser;
                            objm_Loca.Datex = DateTime.Now;
                            M_LocaDL bal = new M_LocaDL();
                            bal.SaveM_LocaSP(objm_Loca, 1);
                            GetData();

                            txt_Locacode.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                        }
                    }
                    else if (formMode == 3)
                    {
                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {

                            M_Loca objm_Loca = new M_Loca();
                            objm_Loca.Locacode = txt_Locacode.Text.Trim();
                            objm_Loca.Companycode = commonFunctions.GlobalCompany.Trim();
                            objm_Loca.StockCode = txt_Locacode.Text.Trim();
                            objm_Loca.Locaname = txt_Locaname.Text.Trim();
                            objm_Loca.Add1 = txt_Add1.Text.Trim();
                            objm_Loca.Add2 = txt_Add2.Text.Trim();
                            objm_Loca.Add3 = txt_Add3.Text.Trim();
                            objm_Loca.Tpno = txt_Tpno.Text.Trim();
                            objm_Loca.Fax = txt_Fax.Text.Trim();
                            objm_Loca.Emailx = txt_Emailx.Text.Trim();
                            objm_Loca.Userx = commonFunctions.Loginuser;
                            objm_Loca.Datex = DateTime.Now;
                            M_LocaDL bal = new M_LocaDL();
                            bal.SaveM_LocaSP(objm_Loca, 3);

                            GetData();
                            txt_Locacode.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                        }

                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_Locacode.Enabled = true;
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
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

        private void txt_Locacode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txt_Locaname.Focus();
            }

        }

        private void txt_Locaname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Add1.Focus();
            }
        }

        private void txt_Add1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Add2.Focus();
            }
        }

        private void txt_Add2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Add3.Focus();
            }
        }

        private void txt_Add3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Emailx.Focus();
            }
        }

        private void txt_Emailx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Tpno.Focus();
            }
        }

        private void txt_Tpno_KeyDown(object sender, KeyEventArgs e)
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
                txt_Locacode.Focus();
            }
        }



    }
}