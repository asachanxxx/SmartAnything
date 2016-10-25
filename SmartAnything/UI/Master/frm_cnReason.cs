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
    public partial class frm_cnReason : Form
    {

        int formMode = 0;
        string formID = "A0001";
        string formHeadertext = "Credit Note Reasons";


        #region Loading one instance

        private static frm_cnReason objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_cnReason getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_cnReason();

            }
            return objSingleObject;

        }

        #endregion

        public frm_cnReason()
        {
            InitializeComponent();
        }

        private void frm_cnReason_Load(object sender, EventArgs e)
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
                dataGridView1.DataSource = new M_CNReasonDL().SelectAllm_CNReason();

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

        #region performButtons Area

        private void performButtons(xEnums.PerformanceType xenum)
        {

            switch (xenum)
            {
                case xEnums.PerformanceType.View:

                    if (ActiveControl.Name.Trim() == txt_ID.Name.Trim())
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
                    txt_ID.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_ID.Enabled = false;
                    txt_Reason.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    try
                    {

                        if (txt_ID.Text.Trim() == "")
                        {

                            errorProvider1.SetError(txt_ID, "Please enter a credit note code !");
                            return;
                        }

                        if (txt_Reason.Text.Trim() == "")
                        {
                            errorProvider1.SetError(txt_Reason, "Please enter a subcategory name !");
                            return;
                        }
                        if (formMode == 1)
                        {
                            if (M_CNReasonDL.ExistingM_CNReason(txt_ID.Text.Trim()))
                            {

                                errorProvider1.SetError(txt_ID, "The credit note reason you have entered already exists!");
                                return;
                            }
                           
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_CNReason objm_CNReason = new M_CNReason();
                                objm_CNReason.ID = txt_ID.Text.Trim();
                                objm_CNReason.Reason = txt_Reason.Text.Trim();
                                objm_CNReason.NeedToUpdateStock = Chk_NeedToUpdateStock.Checked;
                                objm_CNReason.StockType = comboBox1.Text.Trim();
                                objm_CNReason.UserCode = commonFunctions.Loginuser;
                                objm_CNReason.Datex = DateTime.Now;
                                new M_CNReasonDL().Savem_CNReasonSP(objm_CNReason, 1);



                                GetData();

                                txt_ID.Enabled = true;
                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                                
                            }
                        }
                        else if (formMode == 3)
                        {
                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {

                                M_CNReason objm_CNReason = new M_CNReason();
                                objm_CNReason.ID = txt_ID.Text.Trim();
                                objm_CNReason.Reason = txt_Reason.Text.Trim();
                                objm_CNReason.NeedToUpdateStock = Chk_NeedToUpdateStock.Checked;
                                objm_CNReason.StockType = comboBox1.Text.Trim();
                                objm_CNReason.UserCode = commonFunctions.Loginuser;
                                objm_CNReason.Datex = DateTime.Now;
                                new M_CNReasonDL().Savem_CNReasonSP(objm_CNReason, 3);

                                GetData();
                                txt_ID.Enabled = true;
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
                    txt_ID.Enabled = true;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //CS (Cash)
                if (comboBox1.SelectedIndex == 0)
                {
                    lbl_stockName.Text = "Master Stock";
                }
                //CQ (Cheque)
                else if (comboBox1.SelectedIndex == 1)
                {
                    lbl_stockName.Text = "Damage Stock";
                }
                //DR (DR)
                else if (comboBox1.SelectedIndex == 2)
                {
                    lbl_stockName.Text = "No Stock";
                }
                txt_ID.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
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

        #region  SetValues
        private void SetValues(String sm_Area)
        {
            try
            {
                M_CNReason objm_CNReason = new M_CNReason();
                if (sm_Area != "")
                {
                    objm_CNReason.ID = sm_Area;
                    objm_CNReason = new M_CNReasonDL().Selectm_CNReason(objm_CNReason);
                    if (objm_CNReason != null)
                    {
                        txt_ID.Text = objm_CNReason.ID.ToString();
                        txt_Reason.Text = objm_CNReason.Reason.ToString();
                        Chk_NeedToUpdateStock.Checked = objm_CNReason.NeedToUpdateStock.Value;
                        comboBox1.Text = objm_CNReason.StockType.ToString();
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

        private void txt_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Reason.Focus();
            }
        }

        private void txt_Reason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

    }
}
