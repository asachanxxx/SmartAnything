//**********************************************************************
//Developer  :PUBUDU
//Date       :2013/10/04
//Description:Login
//edit by Peshala 2014/5/9
//Module Name: smartOffice
//**********************************************************************
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
using smartOffice.Classes;
using smartOffice_BL;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SmartAnything.Reports;
using SmartAnything.Reports.DistributionRpt;
using SmartAnything.Reports.SalesRpt;
using SmartAnything.Reports.StockRpt;
namespace SmartAnything
{
    public partial class frmU_Login : Form  
    {
        //System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
       // CommonFont objCommon = new CommonFont();
        string strFormName;

        public frmU_Login()
        {
            InitializeComponent();
            LogFile.LogFileCreate();
              
        }

        private static frmU_Login objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmT_WastageNote</returns>
        public static frmU_Login getSingleton()
        {
            if (objSingleObject == null)
            {
                objSingleObject = new frmU_Login();

            }
            return objSingleObject;

        }

        /// <summary>
        /// Clear all text fields in the form
        /// </summary>
        private void ClearData()
        {
            try
            {
                txtPassword.Text = "";
                txtUserId.Text = "";
                txtUserId.Focus();
            }
            catch (Exception ex)
            {
                Globals.generateErrorMsg(ex.Message, "ClearData");
            }
        }

        /// <summary>
        /// It Checks whether username and password are correct.If correct login success
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserId.Text == "" && txtPassword.Text == "")
                {
                    //MessageBox.Show("Please enter User Name and Password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblErrormsg1.Visible = true;
                    lblErrormsg1.Text = LanguageHandler.txt_enter_username_password;
                    txtUserId.Focus();
                    return;
                }
                if (txtUserId.Text == "" && txtPassword.Text != "")
                {
                    //MessageBox.Show("Please enter your User Name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblErrormsg1.Visible = true;
                    lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
                    txtUserId.Focus();
                    //lblErrormsg1.Visible = false;
                    return;
                }
                if (txtUserId.Text != "" && txtPassword.Text == "")
                {
                    lblErrormsg1.Visible = true;
                    lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
                    txtUserId.Focus();
                    return;
                }

                u_User_BL objUser_BL = new u_User_BL();
                u_User_BL.LoginStatus Authenticationstatus;

                Authenticationstatus = objUser_BL.CheckAuthentication(txtUserId.Text, txtPassword.Text);

                if (Authenticationstatus == u_User_BL.LoginStatus.InvalidUserId)
                {
                    lblErrormsg1.Visible = true;
                    txtUserId.Text = "";
                    txtPassword.Text = "";
                    lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
                    txtUserId.Focus();
                    return;
                }
                else if (Authenticationstatus == u_User_BL.LoginStatus.Invalidpassword)
                {
                    lblErrormsg1.Visible = true;
                    lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
                    txtPassword.Text = "";
                    txtUserId.Focus();
                    return;
                }


                else if (Authenticationstatus == u_User_BL.LoginStatus.RestrictedUser)
                {
                    //MessageBox.Show("Restricted user !", Globals.g_strCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //txtUserId.Focus();
                    //return;
                    lblErrormsg1.Visible = true;
                    lblErrormsg1.Text = LanguageHandler.txt_restricted_user;
                    txtUserId.Text = "";
                    txtPassword.Text = "";
                    txtUserId.Focus();
                    return;
                }
                else if (Authenticationstatus == u_User_BL.LoginStatus.Success)
                {
                    //frmU_MainScreen objMain = new frmU_MainScreen();

                    MDI_SMartAnything objMain =  MDI_SMartAnything.getSingleton();
                    Globals.g_strUser = txtUserId.Text;
                    commonFunctions.Loginuser = txtUserId.Text.Trim();
                    string str = cmb_loca.Text.Trim();
                    str = str.Substring(0,str.IndexOf('-'));
                    commonFunctions.GlobalLocation = str.Trim();
                    txtPassword.Text = "";
                    txtUserId.Text = "";
                    txtUserId.Focus();
                    this.Hide();
                    //objMain.MenuStripItemsVisible();
                    objMain.Activate();
                    objMain.Show();
                    LogFile.WriteErrorLog("btnLogin_Click","frmU_Login", "User login success", "INFO");
                    
                    
                }
                //else
                //{
                //    MessageBox.Show("Invalid login detail ! \n\r Please try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    ClearData();
                //    return;
                //}
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog("btnLogin_Click", "frmU_Login", ex.Message.ToString(), "Exception");

                Globals.generateCommonErrorMsg();
            }


        }

        /// <summary>
        /// Exit from the Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show(LanguageHandler.txt_sure_exit_confirm_msg, "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
            if (res == DialogResult.No)
            {
                txtPassword.Text = "";
                txtUserId.Text = "";
                txtUserId.Focus();
            }

            
            return;
        }

        /// <summary>
        /// It focus the password field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                txtPassword.Focus();
        }

        /// <summary>
        /// It focus the Login Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            
            //btnLogin.Focus();
            
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(btnLogin, EventArgs.Empty);
            

            }
           
            ////if (e.KeyCode == Keys.Return)
            //    //btnLogin.Focus();   
            //txtPassword.Focus();

        }

        private void frmU_Login_Load(object sender, EventArgs e)
        {
            //txtPassword.Text = "";
            //txtUserId.Text = "";

            try
            {
               DataTable dt = new M_LocaDL().SelectAllm_Loca();
               if (dt.Rows.Count > 0)
               {
                   foreach (DataRow drow in dt.Rows)
                   {
                       cmb_loca.Items.Add(drow[0].ToString() + " - " + drow[1].ToString());
                   }
                   cmb_loca.SelectedIndex = 0;
               }
               else { 
               
               }
            }
            catch (Exception ex) { 
            
            }

        }

        //private void frmU_Login_FormClosing(object sender, FormClosingEventArgs e)
        //{
           
        //}

        private void frmU_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmU_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //if (e.CloseReason == CloseReason.ApplicationExitCall) return;
            ////DialogResult res = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            ////if (res == DialogResult.Yes)
            ////{
            //    Application.Exit();
            //    //return;
            ////}
            ////else
            ////{
            //    txtPassword.Text = "";
            //    txtUserId.Text = "";
            //    txtUserId.Focus();
            ////}


            //return;
            //if (UserDefineMessages.ShowMsg("Do you want to exit from the system", UserDefineMessages.Msg_WarningYESNO) == System.Windows.Forms.DialogResult.Yes)
            //{
            //   Application.Exit();
            //}
            //else
            //{
            //    //e.Cancel = true;
            //}
        }

        private void txtUserId_Validating(object sender, CancelEventArgs e)
        {
            lblErrormsg1.Text = "";
            lblErrormsg1.Visible = false;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            //lblErrormsg1.Text = "";
            //lblErrormsg1.Visible = false;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
        //    lblErrormsg1.Text = "";
        //    lblErrormsg1.Visible = false;
        }

        private void btnLogin_Validating(object sender, CancelEventArgs e)
        {
            //var t = new Timer();
            //t.Interval = 10000;

            //lblErrormsg1.Hide();
            //t.Stop();

            //var t = new Timer();
            //t.Interval = 1000*3; // it will Tick in 10 seconds
            //t.Tick += (s, f) =>
            //{
            //    lblErrormsg1.Hide();
            //    t.Stop();
            //};
            //t.Start();
            //System.Threading.Thread.Sleep(5000);
            //lblErrormsg1.Hide();
        }




        public void PerformButtonClick(string strCommand)
        {
            throw new NotImplementedException();
        }

        private void frmU_Login_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //try
            //{
            //    if (txtUserId.Text == "" && txtPassword.Text == "")
            //    {
            //        //MessageBox.Show("Please enter User Name and Password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        lblErrormsg1.Visible = true;
            //        lblErrormsg1.Text = LanguageHandler.txt_enter_username_password;
            //        txtUserId.Focus();
            //        return true;
            //    }
            //    if (txtUserId.Text == "" && txtPassword.Text != "")
            //    {
            //        //MessageBox.Show("Please enter your User Name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        lblErrormsg1.Visible = true;
            //        lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
            //        txtUserId.Focus();
            //        //lblErrormsg1.Visible = false;
            //        return true;
            //    }
            //    if (txtUserId.Text != "" && txtPassword.Text == "")
            //    {
            //        lblErrormsg1.Visible = true;
            //        lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
            //        txtUserId.Focus();
            //        return true;
            //    }

            //    u_User_BL objUser_BL = new u_User_BL();
            //    u_User_BL.LoginStatus Authenticationstatus;

            //    Authenticationstatus = objUser_BL.CheckAuthentication(txtUserId.Text, txtPassword.Text);

            //    if (Authenticationstatus == u_User_BL.LoginStatus.InvalidUserId)
            //    {
            //        lblErrormsg1.Visible = true;
            //        txtUserId.Text = "";
            //        txtPassword.Text = "";
            //        lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
            //        txtUserId.Focus();
            //        return true;
            //    }
            //    else if (Authenticationstatus == u_User_BL.LoginStatus.Invalidpassword)
            //    {
            //        lblErrormsg1.Visible = true;
            //        lblErrormsg1.Text = LanguageHandler.txt_invalid_username_password;
            //        txtPassword.Text = "";
            //        txtUserId.Focus();
            //        return true;
            //    }


            //    else if (Authenticationstatus == u_User_BL.LoginStatus.RestrictedUser)
            //    {
            //        //MessageBox.Show("Restricted user !", Globals.g_strCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        //txtUserId.Focus();
            //        //return;
            //        lblErrormsg1.Visible = true;
            //        lblErrormsg1.Text = LanguageHandler.txt_restricted_user;
            //        txtUserId.Text = "";
            //        txtPassword.Text = "";
            //        txtUserId.Focus();
            //        return true;
            //    }
            //    else if (Authenticationstatus == u_User_BL.LoginStatus.Success)
            //    {
            //        //frmU_MainScreen objMain = new frmU_MainScreen();

            //        MDI_SMartAnything objMain = new MDI_SMartAnything();
            //        Globals.g_strUser = txtUserId.Text;
            //        commonFunctions.Loginuser = txtUserId.Text.Trim();
            //        txtPassword.Text = "";
            //        txtUserId.Text = "";
            //        txtUserId.Focus();
            //        this.Hide();
            //        //objMain.MenuStripItemsVisible();
            //        objMain.Activate();
            //        objMain.Show();
            //        LogFile.WriteErrorLog("btnLogin_Click", "frmU_Login", "User login success", "INFO");


            //    }
            //    //else
            //    //{
            //    //    MessageBox.Show("Invalid login detail ! \n\r Please try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //    ClearData();
            //    //    return;
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    LogFile.WriteErrorLog("btnLogin_Click", "frmU_Login", ex.Message.ToString(), "Exception");

            //    Globals.generateCommonErrorMsg();
            //}

            return base.ProcessDialogKey(keyData);
        }
    }
}
