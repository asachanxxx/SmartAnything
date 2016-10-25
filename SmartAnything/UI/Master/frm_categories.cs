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
    public partial class frm_categories : Form
    {

        int formMode = 0;
        string formID = "A0040";
        string formHeadertext = "Product Arrange";

        #region Loading one instance

        private static frm_categories objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_categories getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_categories();

            }
            return objSingleObject;

        }

        #endregion

        public frm_categories()
        {
            InitializeComponent();
        }

        private void frm_categories_Load(object sender, EventArgs e)
        {
            try
            {
                label6.Text = label6.Text.ToUpper();
                label21.Text = label21.Text.ToUpper();
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.FormatDataGrid(dataGridView1);
                commonFunctions.FormatDataGrid(dataGridView2);
                commonFunctions.HandleTextBoxes(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
                GetData();

            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on Loading data", 1);
            }

        }

        #region GetData

        private void GetData()
        {
            try
            {

                M_CategoryDL bdl = new M_CategoryDL();
                dataGridView1.DataSource = bdl.SelectAllm_Category();

                if (dataGridView1.DataSource != null)
                {

                    dataGridView1.Columns[0].Width = 120;
                    dataGridView1.Columns[1].Width = 260;
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

                    if (ActiveControl.Name.Trim() == txt_Codex.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["CategoryFieldLength"]);
                        string[] strSearchField = new string[length];

                        string strSQL = ConfigurationManager.AppSettings["CategorySQL"].ToString();

                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["CategoryField" + m + ""].ToString();
                        }

                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    formMode = 1;
                    txt_Codex.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_Codex.Enabled = false;
                    txt_Descr.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    try
                    {
                        if (formMode == 1)
                        {
                            if (M_CategoryDL.ExistingM_Category(txt_Codex.Text.Trim()))
                            {

                                errorProvider1.SetError(txt_Codex, "The category code you have entered already exists!");
                                return;
                            }

                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_Category objm_Category = new M_Category();
                                objm_Category.Codex = txt_Codex.Text.Trim();
                                objm_Category.Descr = txt_Descr.Text.Trim();
                                objm_Category.date = DateTime.Now;//txt_date.Text.Trim();
                                objm_Category.type = "";//txt_type.Text.Trim();
                                objm_Category.Lockedby = "";//txt_Lockedby.Text.Trim();
                                objm_Category.Locked = false; //txt_Locked.Text.Trim();
                                objm_Category.Userx = commonFunctions.Loginuser;
                                M_CategoryDL bal = new M_CategoryDL();
                                bal.SaveM_CategorySP(objm_Category, 1);

                                GetData();

                                txt_Codex.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                                
                            }
                        }
                        else if (formMode == 3)
                        {
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_Category objm_Category = new M_Category();
                                objm_Category.Codex = txt_Codex.Text.Trim();
                                objm_Category.Descr = txt_Descr.Text.Trim();
                                objm_Category.date = DateTime.Now;//txt_date.Text.Trim();
                                objm_Category.type = "";//txt_type.Text.Trim();
                                objm_Category.Lockedby = "";//txt_Lockedby.Text.Trim();
                                objm_Category.Locked = false; //txt_Locked.Text.Trim();
                                objm_Category.Userx = commonFunctions.Loginuser;
                                M_CategoryDL bal = new M_CategoryDL();
                                bal.SaveM_CategorySP(objm_Category, 3);



                                GetData();
                                txt_Codex.Enabled = true;
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
                    txt_Codex.Enabled = true;
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

        #region  SetValues
        private void SetValues(String sm_Category)
        {
            try
            {
                M_Category objm_Category = new M_Category();
                if (sm_Category != "")
                {
                    objm_Category.Codex = sm_Category;
                    objm_Category = new M_CategoryDL().Selectm_Category(objm_Category);
                    if (objm_Category != null)
                    {
                        txt_Codex.Text = objm_Category.Codex.ToString();
                        txt_Descr.Text = objm_Category.Descr.ToString();
                        chk_catlock.Checked = objm_Category.Locked.Value;
                        GetDataSUB(objm_Category.Codex.ToString());
                        formMode = 0;
                    }



                }
            }
            catch (Exception ex)
            {
               
            }
        }
        #endregion 

        #region GetDataSUB

        private void GetDataSUB(string catid)
        {
            try
            {

                dataGridView2.DataSource = new M_SubCategoryDL().SelectAllm_SubCategory(catid.Trim());

                if (dataGridView2.DataSource != null)
                {

                    dataGridView2.Columns[0].Width = 140;
                    dataGridView2.Columns[1].Width = 240;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void SetValuesSub(String sm_Category)
        {
            try
            {
                M_SubCategory objm_Category = new M_SubCategory();
                if (sm_Category != "")
                {
                    objm_Category.Codex = sm_Category;
                    objm_Category = new M_SubCategoryDL().Selectm_SubCategory(objm_Category);
                    if (objm_Category != null)
                    {
                        txt_subcatcode.Text = objm_Category.Codex.ToString();
                        txt_subcatname.Text = objm_Category.Descr.ToString();
                        chk_locksub.Checked = objm_Category.Locked.Value;
                        formMode = 0;
                    }



                }
            }
            catch (Exception ex)
            {
                
            }
        }


        private void txt_Codex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Descr.Focus();
            }
        }

        private void txt_Descr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Codex.Focus();
            }
        }

        private void btn_addCat_Click(object sender, EventArgs e)
        {

            if (txt_Descr.Text.Trim() == "")
            {

                errorProvider1.SetError(txt_Descr, "Please enter a category name !");
                return;
            }

            if (txt_Codex.Text.Trim() == "")
            {

                errorProvider1.SetError(txt_Codex, "Please enter a category code !");
                return;
            }

            lbl_new.Hide();
            try
            {
                if (M_CategoryDL.ExistingM_Category(txt_Codex.Text.Trim()))
                {
                    lbl_new.Hide();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        M_Category objm_Category = new M_Category();
                        objm_Category.Codex = txt_Codex.Text.Trim();
                        objm_Category.Descr = txt_Descr.Text.Trim();
                        objm_Category.date = DateTime.Now;//txt_date.Text.Trim();
                        objm_Category.type = "";//txt_type.Text.Trim();
                        objm_Category.Lockedby = commonFunctions.Loginuser;
                        objm_Category.Locked = chk_catlock.Checked; //txt_Locked.Text.Trim();
                        objm_Category.Userx = commonFunctions.Loginuser;
                        M_CategoryDL bal = new M_CategoryDL();
                        bal.SaveM_CategorySP(objm_Category,3);

                        GetData();

                        txt_Codex.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Save);
                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                    }
                }
                else
                {
                    lbl_new.Show();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        M_Category objm_Category = new M_Category();
                        objm_Category.Codex = txt_Codex.Text.Trim();
                        objm_Category.Descr = txt_Descr.Text.Trim();
                        objm_Category.date = DateTime.Now;//txt_date.Text.Trim();
                        objm_Category.type = "";//txt_type.Text.Trim();
                        objm_Category.Lockedby = commonFunctions.Loginuser;
                        objm_Category.Locked = chk_catlock.Checked; //txt_Locked.Text.Trim();
                        objm_Category.Userx = commonFunctions.Loginuser;
                        M_CategoryDL bal = new M_CategoryDL();
                        bal.SaveM_CategorySP(objm_Category, 1);

                        GetData();

                        txt_Codex.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Save);
                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                    }
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isnew = dataGridView1.Rows[e.RowIndex].IsNewRow;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                SetValues(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

            }
        }

        private void btn_addSub_Click(object sender, EventArgs e)
        {
            if (txt_subcatname.Text.Trim() == "")
            {
                errorProvider1.SetError(txt_subcatname, "Please enter a subcategory name !");
                return;
            }

            lbl_newsub.Hide();
            try
            {
                if (!M_SubCategoryDL.ExistingM_SubCategory(txt_Codex.Text, txt_subcatcode.Text.Trim()))
                {
                    lbl_newsub.Show();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {
                       
                        M_SubCategory objm_SubCategory = new M_SubCategory();
                        objm_SubCategory.Codex = txt_subcatcode.Text.Trim();
                        objm_SubCategory.CategoryID = txt_Codex.Text.Trim();
                        objm_SubCategory.Descr = txt_subcatname.Text.Trim();
                        objm_SubCategory.date = DateTime.Now;
                        objm_SubCategory.type = "";
                        objm_SubCategory.Lockedby = commonFunctions.Loginuser;
                        objm_SubCategory.Locked = chk_locksub.Checked;
                        objm_SubCategory.Userx = commonFunctions.Loginuser;
                         new M_SubCategoryDL().Savem_SubCategorySP(objm_SubCategory, 1);

                        GetData();

                        txt_Codex.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Save);
                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                    }
                }
                else
                {
                    lbl_newsub.Hide();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        M_SubCategory objm_SubCategory = new M_SubCategory();
                        objm_SubCategory.Codex = txt_subcatcode.Text.Trim();
                        objm_SubCategory.CategoryID = txt_Codex.Text.Trim();
                        objm_SubCategory.Descr = txt_subcatname.Text.Trim();
                        objm_SubCategory.date = DateTime.Now;
                        objm_SubCategory.type = "";
                        objm_SubCategory.Lockedby = commonFunctions.Loginuser;
                        objm_SubCategory.Locked = chk_locksub.Checked;
                        objm_SubCategory.Userx = commonFunctions.Loginuser;
                        new M_SubCategoryDL().Savem_SubCategorySP(objm_SubCategory, 3);

                        GetData();

                        txt_Codex.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Save);
                        UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                    }
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void txt_subcatcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_subcatname.Focus();
            }
        }

        private void txt_subcatname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_subcatcode.Focus();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            bool isnew = dataGridView2.Rows[e.RowIndex].IsNewRow;
            if (dataGridView2.Rows[e.RowIndex].IsNewRow == false)
            {
                SetValuesSub(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

            }
            }
            catch (Exception ex) { }
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool isnew = dataGridView2.Rows[e.RowIndex].IsNewRow;
                if (dataGridView2.Rows[e.RowIndex].IsNewRow == false)
                {
                    SetValuesSub(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

                }
            }
            catch (Exception ex) { }
        }

    }
}
