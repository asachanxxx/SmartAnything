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
    public partial class frm_Area : Form
    {

        int formMode = 0;
        string formID = "A0001";
        string formHeadertext = "Areas";


        #region Loading one instance

        private static frm_Area objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_Area getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_Area();

            }
            return objSingleObject;

        }

        #endregion

        public frm_Area()
        {
            InitializeComponent();
        }

        private void frm_Area_Load(object sender, EventArgs e)
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
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        #region GetData

        private void GetData()
        {
            try
            {

                M_AreaDL bdl = new M_AreaDL();
                dataGridView1.DataSource = bdl.SelectAllm_Area();

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
        private void SetValues(String sm_Area)
        {
            try
            {
                M_AreaDL objm_AreaDL = new M_AreaDL();
                M_Area objm_Area = new M_Area();
                if (sm_Area != "")
                {
                    objm_Area.AreaCode = sm_Area;
                    objm_Area = objm_AreaDL.Selectm_Area(objm_Area);
                    if (objm_Area != null)
                    {
                        txt_AreaCode.Text = objm_Area.AreaCode.ToString();
                        //txt_Compcode.Text = "";// objm_Area.Compcode.ToString();
                        //txt_Locacode.Text = objm_Area.Locacode.ToString();
                        txt_Descri.Text = objm_Area.Descri.ToString();
                        //txt_Datex.Text = objm_Area.Datex.ToString();
                        //txt_Userx.Text = objm_Area.Userx.ToString();
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

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    formMode = 1;
                    txt_AreaCode.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_AreaCode.Enabled = false;
                    txt_Descri.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    try
                    {
                        if (txt_AreaCode.Text.Trim() == "")
                        {

                            errorProvider1.SetError(txt_AreaCode, "Please enter a area Code !");
                            return;
                        }
                        if (txt_Descri.Text.Trim() == "")
                        {

                            errorProvider1.SetError(txt_Descri, "Please enter a area name !");
                            return;
                        }
                        if (formMode == 1)
                        {
                            if (M_AreaDL.ExistingM_Area(txt_AreaCode.Text.Trim()))
                            {

                                errorProvider1.SetError(txt_AreaCode, "The area code you have entered already exists!");
                                return;
                            }

                          

                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_Area objm_Area = new M_Area();
                                objm_Area.AreaCode = txt_AreaCode.Text.Trim();
                                objm_Area.Compcode = commonFunctions.GlobalCompany;// txt_Compcode.Text.Trim();
                                objm_Area.Locacode = commonFunctions.GlobalLocation; // txt_Locacode.Text.Trim();
                                objm_Area.Descri = txt_Descri.Text.Trim();
                                objm_Area.Datex = DateTime.Now; //txt_Datex.Text.Trim();
                                objm_Area.Userx = commonFunctions.Loginuser; // txt_Userx.Text.Trim();
                                M_AreaDL bal = new M_AreaDL();
                                bal.SaveM_AreaSP(objm_Area, 1);



                                GetData();

                                txt_AreaCode.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                            }
                        }
                        else if (formMode == 3)
                        {
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_Area objm_Area = new M_Area();
                                objm_Area.AreaCode = txt_AreaCode.Text.Trim();
                                objm_Area.Compcode = commonFunctions.GlobalCompany;// txt_Compcode.Text.Trim();
                                objm_Area.Locacode = commonFunctions.GlobalLocation; // txt_Locacode.Text.Trim();
                                objm_Area.Descri = txt_Descri.Text.Trim();
                                objm_Area.Datex = DateTime.Now; //txt_Datex.Text.Trim();
                                objm_Area.Userx = commonFunctions.Loginuser; // txt_Userx.Text.Trim();
                                M_AreaDL bal = new M_AreaDL();
                                bal.SaveM_AreaSP(objm_Area, 3);

                                GetData();
                                txt_AreaCode.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

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
                    txt_AreaCode.Enabled = true;
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

        private void txt_AreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Descri.Focus();
            }
        }

        private void txt_Descri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_AreaCode.Focus();
            }
        }

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
    }
}
