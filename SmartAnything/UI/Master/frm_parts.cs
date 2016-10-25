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
    public partial class frm_parts : Form
    {

        int formMode = 0;
        string formID = "A0062";
        string formHeadertext = "Product Parts";

        #region Loading one instance

        private static frm_parts objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_parts getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_parts();

            }
            return objSingleObject;

        }

        #endregion


        public frm_parts()
        {
            InitializeComponent();
        }

        private void frm_parts_Load(object sender, EventArgs e)
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
                        txt_IDX.Enabled = true;
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
                        txt_IDX.Enabled = true;

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
                        txt_IDX.Enabled = false;
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
                        txt_IDX.Enabled = false;
                    }
                    break;
                case xEnums.PerformanceType.Exit:
                    break;
                case xEnums.PerformanceType.New:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = false;
                        //chk_pricelvl.Checked = false;
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
                        //chk_pricelvl.Checked = false;
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
                        txt_IDX.Enabled = true;
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
                        txt_IDX.Enabled = true;
                    }


                    break;
                case xEnums.PerformanceType.Cancel:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = true;
                        txt_IDX.Enabled = true;
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
                        txt_IDX.Enabled = true;

                    }
                    break;
            }

        }

        #endregion

        #region GetData

        private void GetData()
        {
            try
            {


                dataGridView1.DataSource = new M_ProductPartDL().SelectAllm_ProductPart();

                if (dataGridView1.DataSource != null)
                {
                    //dataGridView1.Columns[0].HeaderText = "Customer Code";
                    //dataGridView1.Columns[1].HeaderText = "Customer Name";
                    dataGridView1.Columns[0].Width = 120;
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[2].Width = 465;
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
                errorProvider1.Clear();
            }
        }

        #endregion


        #region performButtons Area

        private void performButtons(xEnums.PerformanceType xenum)
        {

            switch (xenum)
            {
                case xEnums.PerformanceType.View:

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    //txt_IDX.Text = commonFunctions.GetSerial("A0009");
                    formMode = 1;

                    //txt_subcat_name.Text = "";
                    //txt_subcat.Text = "";
                    //txt_suppliername.Text = "";
                    //txt_categoryName.Text = "";
                 
                    txt_UnitPrice.Text = "0.00";
                    txt_CostPrice.Text = "0.00";
                    txt_SKU.Text = "";
                    txt_MfctCode.Text = "";

                    txt_ModelNO.Text = "";

                    txt_SerialNo.Text = "";

                    txt_SellingPrice.Text = "0.00";
                    txt_IDX.Text = "";
                    txt_PartName.Text = "";


                    txt_IDX.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_IDX.Enabled = false;
                    txt_PartName.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    if (txt_IDX.Text.Trim() == "")
                    {

                        errorProvider1.SetError(txt_IDX, "Please enter a product code !");
                        return;
                    }


                    if (txt_PartName.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_PartName, "Please enter a part name !");
                        return;
                    }

                    if (formMode == 1)
                    {
                        if (M_ProductPartDL.ExistingM_ProductPart(txt_IDX.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_IDX, "The part code you have entered already exists!");
                            return;
                        }


                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {

                            using (var scope = new System.Transactions.TransactionScope())
                            {
                                //adding the product 
                                M_ProductParts objm_ProductPart = new M_ProductParts();
                                objm_ProductPart.IDX = txt_IDX.Text.Trim();
                                objm_ProductPart.PartNo = txt_PartNo.Text.Trim();
                                objm_ProductPart.PartName = txt_PartName.Text.Trim();
                                objm_ProductPart.ModelNO = txt_ModelNO.Text.Trim();
                                objm_ProductPart.SerialNo = txt_SerialNo.Text.Trim();
                                objm_ProductPart.SKU = txt_SKU.Text.Trim();
                                objm_ProductPart.SuppCode = "";// txt_SuppCode.Text.Trim();
                                objm_ProductPart.MfctCode = txt_MfctCode.Text.Trim();
                                objm_ProductPart.UnitOfMeasure = txt_UnitOfMeasure.Text.Trim();
                                objm_ProductPart.Color = txt_Color.Text.Trim();
                                objm_ProductPart.Brand = txt_SKU.Text.Trim();
                                objm_ProductPart.Capacity = "";
                                objm_ProductPart.UnitPrice = Convert.ToDecimal(txt_UnitPrice.Text.Trim());
                                objm_ProductPart.SellingPrice = Convert.ToDecimal(txt_SellingPrice.Text.Trim());
                                objm_ProductPart.CostPrice = Convert.ToDecimal(txt_CostPrice.Text.Trim());
                                objm_ProductPart.AvgPrice = Convert.ToDecimal(txt_CostPrice.Text.Trim());
                                objm_ProductPart.PackSize = 0;
                                objm_ProductPart.ReOrderLevel = 0;
                                objm_ProductPart.MinQty = 10;
                                objm_ProductPart.EOQty = 60;
                                objm_ProductPart.ReOrderQty = 50;
                                objm_ProductPart.CreateUser = commonFunctions.Loginuser;
                                objm_ProductPart.CreateDate = DateTime.Now;
                                objm_ProductPart.ModifyUser = commonFunctions.Loginuser;
                                objm_ProductPart.ModifyDate = DateTime.Now;
                                new M_ProductPartDL().Savem_ProductPartSP(objm_ProductPart, 1);
                                //commonFunctions.IncrementSerial("A0009");

                                scope.Complete();
                            }

                            GetData();

                            txt_IDX.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                        }
                    }
                    else if (formMode == 3)
                    {

                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {


                            using (var scope = new System.Transactions.TransactionScope())
                            {

                                M_ProductParts objm_ProductPart = new M_ProductParts();
                                objm_ProductPart.IDX = txt_IDX.Text.Trim();
                                objm_ProductPart.PartNo = txt_PartNo.Text.Trim();
                                objm_ProductPart = new M_ProductPartDL().Selectm_ProductPart(objm_ProductPart);
                                objm_ProductPart.PartName = txt_PartName.Text.Trim();
                                objm_ProductPart.ModelNO = txt_ModelNO.Text.Trim();
                                objm_ProductPart.SerialNo = txt_SerialNo.Text.Trim();
                                objm_ProductPart.SKU = txt_SKU.Text.Trim();
                                objm_ProductPart.SuppCode = "";// txt_SuppCode.Text.Trim();
                                objm_ProductPart.MfctCode = txt_MfctCode.Text.Trim();
                                objm_ProductPart.UnitOfMeasure = txt_UnitOfMeasure.Text.Trim();
                                objm_ProductPart.Color = txt_Color.Text.Trim();
                                objm_ProductPart.Brand = txt_SKU.Text.Trim();
                                objm_ProductPart.Capacity = "";
                                objm_ProductPart.UnitPrice = Convert.ToDecimal(txt_UnitPrice.Text.Trim());
                                objm_ProductPart.SellingPrice = Convert.ToDecimal(txt_SellingPrice.Text.Trim());
                                objm_ProductPart.CostPrice = Convert.ToDecimal(txt_CostPrice.Text.Trim());
                                objm_ProductPart.AvgPrice = Convert.ToDecimal(txt_CostPrice.Text.Trim());
                                objm_ProductPart.PackSize = 0;
                                objm_ProductPart.ReOrderLevel = 0;
                                objm_ProductPart.MinQty = 10;
                                objm_ProductPart.EOQty = 60;
                                objm_ProductPart.ReOrderQty = 50;
                                objm_ProductPart.ModifyUser = commonFunctions.Loginuser;
                                objm_ProductPart.ModifyDate = DateTime.Now;
                                new M_ProductPartDL().Savem_ProductPartSP(objm_ProductPart, 1);

                                scope.Complete();
                            }

                        }
                        GetData();
                        txt_IDX.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Save);
                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_IDX.Enabled = true;
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
                    errorProvider1.Clear();
                    break;


            }

        }
        #endregion


        private void txt_Color_KeyDown(object sender, KeyEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Color.Text = colorDialog1.Color.Name;
            }
        }

        #region  SetValues
        private void SetValues(String sm_ProductPart)
        {
            try
            {
                M_ProductPartDL objm_ProductPartDL = new M_ProductPartDL();
                if (sm_ProductPart != "")
                {
                    M_ProductParts objm_ProductPart = new M_ProductParts();
                    objm_ProductPart.IDX = sm_ProductPart.Trim();
                    objm_ProductPart = new M_ProductPartDL().Selectm_ProductPart(objm_ProductPart);

                    if (objm_ProductPart != null)
                    {
                        txt_IDX.Text = objm_ProductPart.IDX.ToString();
                        txt_PartNo.Text = objm_ProductPart.PartNo.ToString();
                        txt_PartName.Text = objm_ProductPart.PartName.ToString();
                        txt_ModelNO.Text = objm_ProductPart.ModelNO.ToString();
                        txt_SerialNo.Text = objm_ProductPart.SerialNo.ToString();
                        txt_SKU.Text = objm_ProductPart.SKU.ToString();
                        txt_MfctCode.Text = objm_ProductPart.MfctCode.ToString();
                        txt_UnitOfMeasure.Text = objm_ProductPart.UnitOfMeasure.ToString();
                        txt_Color.Text = objm_ProductPart.Color.ToString();
                        txt_UnitPrice.Text = objm_ProductPart.UnitPrice.ToString();
                        txt_SellingPrice.Text = objm_ProductPart.SellingPrice.ToString();
                        txt_CostPrice.Text = objm_ProductPart.CostPrice.ToString();
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

        private void txt_IDX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txt_PartName.Focus();
            }
        }

        private void txt_PartName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_PartNo.Focus();
            }
        }

        private void txt_PartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ModelNO.Focus();
            }
        }

        private void txt_ModelNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_MfctCode.Focus();
            }
        }

        private void txt_MfctCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SerialNo.Focus();
            }
        }

        private void txt_SerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_UnitOfMeasure.Focus();
            }
        }

        private void txt_UnitOfMeasure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SKU.Focus();
            }
        }

        private void txt_SKU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_CostPrice.Focus();
            }
        }

        private void txt_CostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_UnitPrice.Focus();
            }
        }

        private void txt_UnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SellingPrice.Focus();
            }
        }

        private void txt_SellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_IDX.Focus();
            }
        }

    }
}
