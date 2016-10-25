//**********************************************************************
//Developer  :PUBUDU
//Date       :2013/10/04
//Description:Common Class
//Module Name: smartOffice
//**********************************************************************

using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using System;
using smartOffice_Models;
using smartOffice_BL;
using System.Data;
using smartOffice.UI;
using CrystalDecisions.CrystalReports.Engine;

namespace SmartAnything
{
    class Globals
    {

        public static string g_strUser;
        public static string g_strLocation;

        public static string g_strCompanyName;
        public static string g_strCompanyAdd1;
        public static string g_strCompanyAdd2;
        public static string g_strCompanyAdd3;
        public static string g_strCompanyFax;
        public static string g_strCompanyEmail;
        public static string g_strCompanyTel1;
        public static string g_strCompanyTel2;

        public static string g_strProLevel1;
        public static string g_strProLevel2;
        public static string g_strProLevel3;
        public static string g_strProLevel4;
        public static string g_strProLevel5;
        public static string g_strProLevel6;
        public static string g_strProLevel7;
        public static string g_strProLevel8;

        public static bool g_blLoyaltyActive;
        public static bool g_blGiftVoucherActive;
        public static bool g_blPromotionActive;
        public static bool g_blCreditorsActive;
        public static bool g_blDebtorsActive;

        public static bool g_blAutoProductCode;

        public static string g_MenuId;
        public static DataTable g_dtRights;

        public static string strCancelID;

        static u_MenuTag objMenutg = new u_MenuTag();
        static u_MenuTag_BL objMenuTgBL = new u_MenuTag_BL();
        public static ReportClass frmReport;

        /// <summary>
        /// Populate the system configuration parameters
        /// </summary>
        public static void PopulateSysSetup()
        {
            try
            {
                u_SysSetup objSetup = new u_SysSetup();
                objSetup = new u_SysSetup_BL().getSetupParams();

                u_SysSetup_BL objSetupBL = new u_SysSetup_BL();
                objSetup = objSetupBL.getDetails();

                g_strCompanyName = objSetup.strCompany;
                g_strCompanyAdd1 = objSetup.strAddress1;
                g_strCompanyAdd2 = objSetup.strAddress2;
                g_strCompanyAdd3 = objSetup.strAddress3;
                g_strCompanyFax = objSetup.strFax;
                g_strCompanyEmail = objSetup.strEmail;
                g_strCompanyTel1 = objSetup.strTelephone1;
                g_strCompanyTel2 = objSetup.strTelephone2;
                g_strProLevel1 = objSetup.strProLevel1;
                g_strProLevel2 = objSetup.strProLevel2;
                g_strProLevel3 = objSetup.strProLevel3;
                g_strProLevel4 = objSetup.strProLevel4;
                g_strProLevel5 = objSetup.strProLevel5;
                g_strProLevel6 = objSetup.strProLevel6;
                g_strProLevel7 = objSetup.strProLevel7;
                g_strProLevel8 = objSetup.strProLevel8;
                g_blAutoProductCode = (objSetup.intAutoProductCode == 1 ? true : false);
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// To ensure ' is not included in the input
        /// </summary>
        /// <param name="keyChar">Char value of the input</param>
        /// <returns>True if invalid input</returns>
        public static bool CheckString(char keyChar)
        {

            return true;
        }

        /// <summary>
        /// To format the Product Code to follow the pattern "0000000000". eg: 0000001A25
        /// Note : Product code is fixed to 10 digits.
        /// </summary>
        /// <param name="strCode">Text input received as the Product Code</param>
        /// <returns>Formatted Product code according to the pattern of 0000000000</returns>
        public static string FormatProduct(string strCode)
        {
            strCode = strCode.Replace(" ", "").Trim();
            strCode = strCode.PadLeft(10, '0');
            return strCode;
        }

        /// <summary>
        /// To change the color of the textbox when the focus is gained
        /// </summary>
        /// <param name="txt">Object of a textbox</param>
        public static void textboxGotFocus(TextBox txt)
        {
            txt.BackColor = Color.WhiteSmoke;
        }

        /// <summary>
        /// To ensure that only numeric inputs are accepted
        /// </summary>
        /// <param name="theCharacter">KeyChar of the keypress event</param>
        /// <param name="theTextBox">Active Textbox control</param>
        /// <returns></returns>
        public static bool CheckNumeric(char theCharacter, TextBox theTextBox)
        {
            // Only allow control characters, digits, plus and minus signs.
            // Only allow ONE plus sign.
            // Only allow ONE minus sign.
            // Only allow the plus or minus sign as the FIRST character.
            // Only allow ONE decimal point.
            // Do NOT allow decimal point or digits BEFORE any plus or minus sign.

            if (!char.IsControl(theCharacter) && !char.IsDigit(theCharacter) && (theCharacter != '.') && (theCharacter != '-'))
            {
                // Then it is NOT a character we want allowed in the text box.
                return false;
            }

            // Only allow one decimal point.
            if (theCharacter == '.' && theTextBox.Text.IndexOf('.') > -1)
            {
                // Then there is already a decimal point in the text box.
                return false;
            }

            // Only allow one minus sign.
            if (theCharacter == '-' && theTextBox.Text.IndexOf('-') > -1)
            {
                // Then there is already a minus sign in the text box.
                return false;
            }

            // Only allow a minus sign at the first character position.
            if (((theCharacter == '-')) && theTextBox.SelectionStart != 0)
            {
                // Then the user is trying to enter a minus sign at some position 
                // OTHER than the first character position in the text box.
                return false;
            }

            // Only allow digits and decimal point AFTER any existing plus or minus sign
            if ((char.IsDigit(theCharacter) || (theCharacter == '.')) && ((theTextBox.Text.IndexOf('-') > -1)) && theTextBox.SelectionStart == 0)
            {
                // Then the user is trying to enter a digit or decimal point in front of a minus or plus sign.
                return false;
            }

            // Otherwise the character is perfectly fine for a decimal value and the character
            // may indeed be placed at the current insertion position.
            return true;
        }

        /// <summary>
        /// To change the color of the textbox when the focus is lost
        /// </summary>
        /// <param name="txt">Object of a textbox</param>
        public static void textboxLostFocus(TextBox txt)
        {
            txt.BackColor = Color.White;
        }

        /// <summary>
        /// To make same look and feel for every interface
        /// </summary>
        /// <param name="frm">Object of the current form</param>
        public static void setFormProperties(Form frm)
        {
            //applyTheme(frm);
            //frm.BringToFront();
            //g_MenuId = objMenuTgBL.GetMenuID(frm.Text);
            //EnableOrDisable();
            


            //frm.Font = new System.Drawing.Font(CommonFont.StrFont(frm.Name.ToString()), 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        public static void applyTheme(Form frm)
        {
            frm.Left = 0;
            frm.Top = 0;
            frm.Width = 1024;
            frm.Height = 768;
            frm.BackColor = Color.FromArgb(231, 245, 235);

            foreach (Form form in frm.MdiParent.MdiChildren)
            {
                if (form != frm.MdiParent.ActiveMdiChild)
                {
                    form.Dock = DockStyle.Fill;
                    form.AutoScroll = true;
                }
                else
                {
                    frm.Dock = DockStyle.Fill;
                    frm.AutoScroll = true;
                }
            }
            foreach (Control c in frm.Controls)
            {
                if (c is Panel && c.Name == "hederPanel")
                {
                    c.Left = 0;
                    c.Top = 0;
                    c.Width = frm.MdiParent.Width;
                    c.Height = 76;
                    c.BackColor = Color.FromArgb(39, 174, 96);
                }
            }
        }
        /// <summary>
        /// To send custom error message to the user when an exception is cought
        /// </summary>
        /// <param name="strErrorMsg">Description of the exception</param>
        /// <param name="strProcedure">Name of the method where the error occurred</param>
        public static void generateErrorMsg(string strErrorMsg, string strProcedure)
        {
            MessageBox.Show("Error occurred..!\nError Description : " + strErrorMsg +
                                "\nProcedure : " + strProcedure
                                , Globals.g_strCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// To send custom error message to the user when an exception is cought
        /// </summary>
        /// <param name="strErrorMsg">Description of the exception</param>
        /// <param name="strProcedure">Name of the method where the error occurred</param>
        public static void generateCommonErrorMsg()
        {
            //smartOfficeMessageBox.ShowMsg(LanguageHandler.txt_common_error_msg, LanguageHandler.txt_exception, SmartOfficeMessageBoxBtn.OK, SmartOfficeMessageBoxIcon.ERROR);
        }
        /// <summary>
        /// To send error message to the user when a user doesn't have "ACCESS","CREATE","MODIFY","DELETE","PROCESS" 
        /// permissions to perform the current action
        /// </summary>
        /// <param name="strMenuRight">Can be either "A","C","D","M" or "P"</param>
        public static void generatePermissionErrors(string strMenuRight)
        {
            string strErrorStr = "";
            switch (strMenuRight)
            {
                case "A":
                    strErrorStr = "You do not have permission to access this feature..!";
                    break;
                case "C":
                    strErrorStr = "You do not have permission to create new entries..!";
                    break;
                case "M":
                    strErrorStr = "You do not have permission to edit this entry..!";
                    break;
                case "D":
                    strErrorStr = "You do not have permission to delete this entry..!";
                    break;
                case "P":
                    strErrorStr = "You do not have permission to process this entry..!";
                    break;
                default:
                    strErrorStr = "Invalid request. Please try again";
                    break;
            }
            MessageBox.Show(strErrorStr, Globals.g_strCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Check module rights
        /// </summary>
        public static void setModuleRights()
        {
            //code to check whether the rights are available
            g_blLoyaltyActive = false;
            g_blGiftVoucherActive = false;
            g_blPromotionActive = false;
            g_blCreditorsActive = false;
            g_blDebtorsActive = false;
        }


        public static bool getSystemActivation()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            rk.CreateSubKey("NAME");
            rk.Close();

            RegistryKey rk1 = Registry.LocalMachine.OpenSubKey("Software\\NAME", true);
            rk1.SetValue("MYNAME", "PUBUDU");
            rk1.Close();

            RegistryKey rk2 = Registry.LocalMachine.OpenSubKey("Software\\NAME", true);
            MessageBox.Show((string)rk2.GetValue("MYNAME"));

            return true;
        }

        /// <summary>
        /// Get MenuRights for each userId and MenuID
        /// </summary>
        /// <param name="UserID">Logged user id</param>
        /// <returns>DataTable filled with menu rights</returns>
        public static DataTable CheckMenuaccess(string UserID)
        {
            try
            {
                u_UserRights objUserRight = new u_UserRights();
                objUserRight.User = new u_User();
                objUserRight.MenuTag = new u_MenuTag();
                u_UserRights_BL objUserRghtsBL = new u_UserRights_BL();
                objUserRight.User.strUserID = UserID;
                objUserRight.MenuTag.strMenuID = g_MenuId;
                DataTable dt = objUserRghtsBL.GetUserRightsToMenuTag(objUserRight);
                return dt;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Enable or disable buttons according to the rights
        /// </summary>
        public static void EnableOrDisable()
        {
            //g_dtRights = CheckMenuaccess(g_strUser);
            //if (g_dtRights.Rows.Count != 0)
            //{
            //    MDI_smartOffice.BtnCtrl(Convert.ToBoolean(Globals.g_dtRights.Rows[0]["dtAccess"].ToString()), Convert.ToBoolean(Globals.g_dtRights.Rows[0]["dtCreate"].ToString()), Convert.ToBoolean(Globals.g_dtRights.Rows[0]["dtCreate"].ToString()), Convert.ToBoolean(Globals.g_dtRights.Rows[0]["dtModify"].ToString()), Convert.ToBoolean(Globals.g_dtRights.Rows[0]["dtDelete"].ToString()), Convert.ToBoolean(Globals.g_dtRights.Rows[0]["dtPrint"].ToString()), true);
            //}
            //else MDI_smartOffice.BtnCtrl(true, true, true, true, true, true, true);
        }

    }
}
