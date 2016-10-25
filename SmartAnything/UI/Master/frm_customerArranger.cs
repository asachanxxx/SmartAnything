using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using SmartAnything;
using SmartAnything_DL;
using smartOffice_Models;
using System.Configuration;

namespace SmartAnything.UI
{
    public partial class frm_customerArranger : Form
    {


        int formMode = 0;
        string formID = "A0061";
        string formHeadertext = "Customer Arrange";

        #region Loading one instance

        private static frm_customerArranger objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_customerArranger getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_customerArranger();

            }
            return objSingleObject;

        }

        #endregion

        public frm_customerArranger()
        {
            InitializeComponent();
        }

        private void frm_customerArranger_Load(object sender, EventArgs e)
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

                dataGridView1.DataSource = new M_CustomerCategoryDL().SelectAllm_CustomerCategory();

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

        private void SetValuesSub(String sm_Category)
        {
            try
            {
                M_CustomerSub objm_Category = new M_CustomerSub();
                if (sm_Category != "")
                {
                    objm_Category.CussubID = sm_Category;
                    objm_Category = new M_CustomerSubDL().Selectm_CustomerSub(objm_Category);
                    if (objm_Category != null)
                    {
                        txt_subcatcode.Text = objm_Category.CussubID.ToString();
                        txt_subcatname.Text = objm_Category.Description.ToString();
                        chk_locksub.Checked = false;
                        formMode = 0;
                    }



                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
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
                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
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

        private void btn_addCat_Click(object sender, EventArgs e)
        {

            if (txt_Codex.Text.Trim() == "")
            {

                errorProvider1.SetError(txt_Codex, "Please enter a customer category code !");
                return;
            }

            if (txt_Descr.Text.Trim() == "")
            {

                errorProvider1.SetError(txt_Descr, "Please enter a customer category !");
                return;
            }

            lbl_new.Hide();
            try
            {
                if (M_CustomerCategoryDL.ExistingM_CustomerCategory(txt_Codex.Text.Trim()))
                {
                    lbl_new.Hide();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        M_CustomerCategory objm_Category = new M_CustomerCategory();
                        objm_Category.CusCateID = txt_Codex.Text.Trim();
                        objm_Category.Description = txt_Descr.Text.Trim();
                        objm_Category.Datex = DateTime.Now;//txt_date.Text.Trim();
                        objm_Category.Userx = commonFunctions.Loginuser;
                        new M_CustomerCategoryDL().Savem_CustomerCategorySP(objm_Category, 3);

                        GetData();

                        txt_Codex.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Save);
                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                        
                    }
                }
                else
                {
                    lbl_new.Show();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        M_CustomerCategory objm_Category = new M_CustomerCategory();
                        objm_Category.CusCateID = txt_Codex.Text.Trim();
                        objm_Category.Description = txt_Descr.Text.Trim();
                        objm_Category.Datex = DateTime.Now;//txt_date.Text.Trim();
                        objm_Category.Userx = commonFunctions.Loginuser;
                        new M_CustomerCategoryDL().Savem_CustomerCategorySP(objm_Category, 1);

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
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            bool isnew = dataGridView1.Rows[e.RowIndex].IsNewRow;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                SetValues(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

            }
        }

        #region  SetValues
        private void SetValues(String sm_Category)
        {
            try
            {
                M_CustomerCategory objm_Category = new M_CustomerCategory();
                if (sm_Category != "")
                {
                    objm_Category.CusCateID = sm_Category;
                    objm_Category = new M_CustomerCategoryDL().Selectm_CustomerCategory(objm_Category);
                    if (objm_Category != null)
                    {
                        txt_Codex.Text = objm_Category.CusCateID.ToString();
                        txt_Descr.Text = objm_Category.Description.ToString();
                        GetDataSUB(objm_Category.CusCateID.ToString());
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

                dataGridView2.DataSource = new M_CustomerSubDL().SelectAllm_CustomerSub(catid.Trim());

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

        private void txt_Codex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txt_Descr.Focus();
            }
        }

        private void txt_Descr_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Codex.Focus();
            }
        }

        private void btn_addSub_Click(object sender, EventArgs e)
        {
            if (txt_subcatcode.Text.Trim() == "")
            {

                errorProvider1.SetError(txt_subcatcode, "Please enter a customer subcategory code !");
                return;
            }

            if (txt_subcatname.Text.Trim() == "")
            {

                errorProvider1.SetError(txt_subcatname, "Please enter a customer subcategory !");
                return;
            }

            lbl_newsub.Hide();
            try
            {
                if (!M_CustomerSubDL.ExistingM_CustomerSub(txt_subcatcode.Text.Trim(),txt_Codex.Text))
                {
                    lbl_newsub.Show();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        M_CustomerSub objm_SubCategory = new M_CustomerSub();
                        objm_SubCategory.CussubID = txt_subcatcode.Text.Trim();
                        objm_SubCategory.CatID = txt_Codex.Text.Trim();
                        objm_SubCategory.Description = txt_subcatname.Text.Trim();
                        objm_SubCategory.Userx = commonFunctions.Loginuser;
                        objm_SubCategory.Datex = DateTime.Now;
                        new M_CustomerSubDL().Savem_CustomerSubSP(objm_SubCategory, 1);

                        GetData();

                        txt_Codex.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Save);
                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                        
                    }
                }
                else
                {
                    lbl_newsub.Hide();
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        M_CustomerSub objm_SubCategory = new M_CustomerSub();
                        objm_SubCategory.CussubID = txt_subcatcode.Text.Trim();
                        objm_SubCategory.CatID = txt_Codex.Text.Trim();
                        objm_SubCategory.Description = txt_subcatname.Text.Trim();
                        objm_SubCategory.Userx = commonFunctions.Loginuser;
                        objm_SubCategory.Datex = DateTime.Now;
                        new M_CustomerSubDL().Savem_CustomerSubSP(objm_SubCategory, 3);

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
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void dataGridView1_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            bool isnew = dataGridView1.Rows[e.RowIndex].IsNewRow;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                SetValues(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

            }
        }

        private void dataGridView2_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
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

        private void dataGridView2_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }



    }//end of class
} // end of namespace
