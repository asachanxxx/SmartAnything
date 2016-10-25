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

namespace SmartAnything.UI
{
    public partial class frm_seccenter : Form
    {
        int formMode = 0;
        string formID = "A0039";
        string formHeadertext = "Security Center";
        DataTable dtx = new DataTable();
        DataTable dtxRights = new DataTable();
        bool already = false;
        bool qtyexceed = false;


        #region Loading one instance

        private static frm_seccenter objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_seccenter getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_seccenter();

            }
            return objSingleObject;

        }

        #endregion

        public frm_seccenter()
        {
            InitializeComponent();
        }

        private void frm_seccenter_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
                commonFunctions.FormatDataGrid(dataGridView1);
                commonFunctions.FormatDataGrid(dataGridView2);
                LoadData();

            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }


        private void LoadData()
        {
            try
            {
                string str = "SELECT menuId AS 'Menu ID',description AS 'Menu',menuRights AS 'Default Rights'  FROM  dbo.u_MenuTag  ";

                dtx = commonFunctions.GetDatatable(str);
                dataGridView1.DataSource = dtx;
                dataGridView1.Columns[0].Width = 90;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 120;
                //dataGridView1.Columns[3].Width = 150;
                //dataGridView1.Columns[4].Width = 80;
                //dataGridView1.Columns[6].Width = 80;
                //dataGridView1.Columns[6].DefaultCellStyle.ForeColor = Color.Green;
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void LoadDataSecdetails()
        {
            try
            {

                txt_Customer_name.Text = findExisting.FindExisitingUSer(txt_userx.Text);
                DataTable dtccc = new DataTable();
                dtccc = new u_UserRights_DL().GetUserRightsSecCenter(txt_userx.Text.Trim());
                dtxRights = new u_UserRights_DL().GetUserRightsSecCenter(txt_userx.Text.Trim());
                //dataGridView3.DataSource = dtccc;
                dataGridView2.DataSource = dtxRights;
                dataGridView2.Columns[0].Width = 70;
                dataGridView2.Columns[1].Width = 120;
                dataGridView2.Columns[2].Width = 60;
                dataGridView2.Columns[3].Width = 60;
                dataGridView2.Columns[4].Width = 60;
                dataGridView2.Columns[5].Width = 60;
                dataGridView2.Columns[6].Width = 60;
                //dataGridView1.Columns[6].DefaultCellStyle.ForeColor = Color.Green;
                dataGridView2.Refresh();

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void txt_userx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataSecdetails();
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_userx.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["UserFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["UserSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["UserField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //string str = "row-" + e.RowIndex.ToString() + "  colum-" + e.ColumnIndex.ToString();
            //commonFunctions.SetMDIStatusMessage(str + "  -  " + dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), 1); 
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    string str = "row-" + e.RowIndex.ToString() + "  colum-" + e.ColumnIndex.ToString();

            //    commonFunctions.SetMDIStatusMessage(str + "  -  " + dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), 1); 
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // commonFunctions.SetMDIStatusMessage(str + "  -  " + dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), 1); 
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {

                foreach (DataGridViewRow rowx in dataGridView2.Rows)
                {
                    string strMenuRights = "";
                    if (Convert.ToBoolean(rowx.Cells[2].Value.ToString()) == true)
                    {
                        strMenuRights = strMenuRights + "A";
                    }
                    if (Convert.ToBoolean(rowx.Cells[3].Value.ToString()) == true)
                    {
                        strMenuRights = strMenuRights + "C";
                    }
                    if (Convert.ToBoolean(rowx.Cells[4].Value.ToString()) == true)
                    {
                        strMenuRights = strMenuRights + "M";
                    }
                    if (Convert.ToBoolean(rowx.Cells[5].Value.ToString()) == true)
                    {
                        strMenuRights = strMenuRights + "D";
                    }
                    if (Convert.ToBoolean(rowx.Cells[6].Value.ToString()) == true)
                    {
                        strMenuRights = strMenuRights + "P";
                    }

                    u_UserRights right = new u_UserRights();
                    new u_UserRights_DL().SaveUserRightsNEw(txt_userx.Text.Trim(), rowx.Cells[0].Value.ToString(), strMenuRights);
                    // MessageBox.Show(rowx.Cells[0].Value.ToString() + " - " + rowx.Cells[2].Value.ToString() + "   -  " + strMenuRights);
                }
                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtUCode.Text.Trim() == "")
            {
                errorProvider1.SetError(txtUCode, "User code cannot be a null value.");
                commonFunctions.SetMDIStatusMessage("User code cannot be a null value.", 1);
                return;
            }
            if (txtUCode.Text.Trim().Length < 5)
            {
                errorProvider1.SetError(txtUCode, "User code must be more than 6 charactors.");
                commonFunctions.SetMDIStatusMessage("User code must be more than 6 charactors", 1);
                return;
            }
            if (U_UserxDL.ExistingU_User(txtUserID.Text.Trim()))
            {
                errorProvider1.SetError(txtUCode, "User code already exists.");
                commonFunctions.SetMDIStatusMessage("User code already exists.", 1);
                return;
            }
            if (txtUName.Text.Trim() == "")
            {
                errorProvider1.SetError(txtUName, "User name cannot be a null value.");
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
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    //u_Userxcc obju_User = new u_Userxcc();
                    //obju_User.userId = txtUserID.Text.Trim();
                    //obju_User.userName = txtUCode.Text.Trim();
                    //obju_User.password = commonFunctions.CreateCheckPassword(true, txtPw.Text.Trim());
                    //obju_User.roleId = txtusergroup.Text.Trim();
                    //obju_User.userCreated = commonFunctions.Loginuser;
                    //obju_User.dateCreated = DateTime.Now;
                    //obju_User.userModified = "";
                    //obju_User.dateModified = DateTime.Now;
                    //obju_User.isActive = 1;
                    //obju_User.empId = "";
                    //obju_User.signOnTime = DateTime.Now;
                    //obju_User.signOnDate = DateTime.Now;
                    //obju_User.shiftNo = 1;
                    //obju_User.isSignOn = 1;
                    //obju_User.isSignOff = 1;
                    //obju_User.signOffDate = DateTime.Now;
                    //obju_User.signOffTime = DateTime.Now;
                    //obju_User.dateTimeFormat = "dd/MM/yyyy";
                    //obju_User.mobile = txtmobile.Text;
                    //obju_User.terminalID = "";
                    //obju_User.shiftOnLocation = commonFunctions.GlobalLocation;
                    //U_UserxDL bal = new U_UserxDL();
                    //bal.Saveu_UserSP(obju_User, 1);
                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                }
            }
        }

        private void txtUCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtUserID.Text = txtUCode.Text.Trim();
            }
            catch (Exception ex) { 
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void txt_userx_TextChanged(object sender, EventArgs e)
        {
            LoadDataSecdetails();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_userx.Text.Trim() == "")
            {
                errorProvider1.SetError(txt_userx, "User code cannot be a null value.");
                commonFunctions.SetMDIStatusMessage("User code cannot be a null value.", 1);
                return;
            }
            if (!U_UserxDL.ExistingU_User(txt_userx.Text.Trim()))
            {
                errorProvider1.SetError(txt_userx, "User code not exists.");
                commonFunctions.SetMDIStatusMessage("User code not exists.", 1);
                return;
            }
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {

                    U_UserxDL.DeleteAllrights(txt_userx.Text.Trim());
                    U_UserxDL.ApplyDefaultSec(txt_userx.Text.Trim());
                    LoadDataSecdetails();
                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());


                    //ApplyDefaultSec
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
                }
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
    }
}
