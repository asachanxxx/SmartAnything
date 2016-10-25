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
    public partial class frm_vehicles : Form
    {

        int formMode = 0;
        string formID = "A0014";
        string formHeadertext = "Vehicles";
        string incomingvehicle = "";

        #region Loading one instance

        private static frm_vehicles objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_vehicles getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_vehicles();

            }
            return objSingleObject;

        }

        #endregion

        public frm_vehicles()
        {
            InitializeComponent();
        }

        private void frm_vehicles_Load(object sender, EventArgs e)
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

                M_VehicleDL bdl = new M_VehicleDL();
                dataGridView1.DataSource = bdl.SelectAllm_Vehicle();

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
        private void SetValues(String sm_Vehicle)
        {
            try
            {
                M_VehicleDL objm_VehicleDL = new M_VehicleDL();
                M_Vehicles objm_Vehicle = new M_Vehicles();
                if (sm_Vehicle != "")
                {
                    objm_Vehicle.VehicleID = sm_Vehicle;
                    objm_Vehicle = objm_VehicleDL.Selectm_Vehicle(objm_Vehicle);
                    if (objm_Vehicle != null)
                    {
                        incomingvehicle = objm_Vehicle.VehicleNo.ToString(); 
                        txt_VehicleID.Text = objm_Vehicle.VehicleID.ToString();
                        txt_VehicleNo.Text = objm_Vehicle.VehicleNo.ToString();
                        //txt_CompCode.Text = objm_Vehicle.CompCode.ToString();
                        //txt_Locacode.Text = objm_Vehicle.Locacode.ToString();
                        txt_Make.Text = objm_Vehicle.Make.ToString();
                        txt_Model.Text = objm_Vehicle.Model.ToString();
                        txt_Driver.Text = objm_Vehicle.Driver.ToString();
                        txt_Milage.Text = objm_Vehicle.Milage.ToString();
                        txt_FuelEfficiency.Text = objm_Vehicle.FuelEfficiency.ToString();
                        txt_Status.Text = objm_Vehicle.Status.ToString();
                        txt_Route.Text = objm_Vehicle.Route.ToString();
                        //txt_Userx.Text = objm_Vehicle.Userx.ToString();
                        //txt_Datex.Text = objm_Vehicle.Datex.ToString();
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

                    if (ActiveControl.Name.Trim() == txt_VehicleID.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["VehicleFieldLength"]);
                        string[] strSearchField = new string[length];

                        string strSQL = ConfigurationManager.AppSettings["VehicleSQL"].ToString();

                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["VehicleField" + m + ""].ToString();
                        }

                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    formMode = 1;
                    txt_VehicleID.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_VehicleID.Enabled = false;
                    txt_VehicleNo.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    errorProvider1.Clear();
                    if (txt_VehicleNo.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_VehicleNo, "Please enter a vehicle number !");
                        return;
                    }

                    if (txt_VehicleID.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_VehicleID, "Please enter a vehicle ID !");
                        return;
                    }


                    if (incomingvehicle.Trim().ToUpper() != txt_VehicleNo.Text.Trim()) {
                        if (M_VehicleDL.ExistingM_VehicleNo(txt_VehicleNo.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_VehicleNo, "The vehicle number you have entered already exists!");
                            return;
                        }
                    }

                    if (formMode == 1)
                    {
                        if (M_VehicleDL.ExistingM_Vehicle(txt_VehicleID.Text.Trim()))
                        {

                            errorProvider1.SetError(txt_VehicleID, "The vehicle code you have entered already exists!");
                            return;
                        }

                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {
                            M_Vehicles objm_Vehicle = new M_Vehicles();
                            objm_Vehicle.VehicleID = txt_VehicleID.Text.Trim();
                            objm_Vehicle.VehicleNo = txt_VehicleNo.Text.Trim();
                            objm_Vehicle.CompCode = commonFunctions.GlobalCompany; //txt_CompCode.Text.Trim();
                            objm_Vehicle.Locacode = commonFunctions.GlobalLocation; //txt_Locacode.Text.Trim();
                            objm_Vehicle.Make = txt_Make.Text.Trim();
                            objm_Vehicle.Model = txt_Model.Text.Trim();
                            objm_Vehicle.Driver = txt_Driver.Text.Trim();
                            objm_Vehicle.Milage = txt_Milage.Text.Trim();
                            objm_Vehicle.FuelEfficiency = commonFunctions.ToDecimal(txt_FuelEfficiency.Text.Trim());
                            objm_Vehicle.Status = txt_Status.Text.Trim();
                            objm_Vehicle.Route = txt_Route.Text.Trim();
                            objm_Vehicle.Userx = commonFunctions.Loginuser;//txt_Userx.Text.Trim();
                            objm_Vehicle.Datex = DateTime.Now; //txt_Datex.Text.Trim();
                            M_VehicleDL bal = new M_VehicleDL();
                            bal.SaveM_VehicleSP(objm_Vehicle, 1);


                            GetData();

                            txt_VehicleID.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                        }
                    }
                    else if (formMode == 3)
                    {
                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {

                            M_Vehicles objm_Vehicle = new M_Vehicles();
                            objm_Vehicle.VehicleID = txt_VehicleID.Text.Trim();
                            objm_Vehicle.VehicleNo = txt_VehicleNo.Text.Trim();
                            objm_Vehicle.CompCode = commonFunctions.GlobalCompany; //txt_CompCode.Text.Trim();
                            objm_Vehicle.Locacode = commonFunctions.GlobalLocation; //txt_Locacode.Text.Trim();
                            objm_Vehicle.Make = txt_Make.Text.Trim();
                            objm_Vehicle.Model = txt_Model.Text.Trim();
                            objm_Vehicle.Driver = txt_Driver.Text.Trim();
                            objm_Vehicle.Milage = txt_Milage.Text.Trim();
                            objm_Vehicle.FuelEfficiency = commonFunctions.ToDecimal(txt_FuelEfficiency.Text.Trim());
                            objm_Vehicle.Status = txt_Status.Text.Trim();
                            objm_Vehicle.Route = txt_Route.Text.Trim();
                            objm_Vehicle.Userx = commonFunctions.Loginuser;//txt_Userx.Text.Trim();
                            objm_Vehicle.Datex = DateTime.Now; //txt_Datex.Text.Trim();
                            M_VehicleDL bal = new M_VehicleDL();
                            bal.SaveM_VehicleSP(objm_Vehicle, 3);


                            GetData();
                            txt_VehicleID.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                        }

                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_VehicleID.Enabled = true;
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

        private void txt_VehicleID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_VehicleNo.Focus();
            }
        }

        private void txt_VehicleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Make.Focus();
            }
        }

        private void txt_Make_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Model.Focus();
            }
        }

        private void txt_Model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Driver.Focus();
            }
        }

        private void txt_Driver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Status.Focus();
            }
        }

        private void txt_Status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Milage.Focus();
            }
        }

        private void txt_Milage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_FuelEfficiency.Focus();
            }

        }

        private void txt_FuelEfficiency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Route.Focus();
            }
        }

        private void txt_Route_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_VehicleID.Focus();
            }
        }

    }
}
