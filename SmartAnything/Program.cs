using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using smartOffice_Models;
using smartOffice_BL;
using smartOffice.Classes;
using System.IO;
using System.Configuration;
using System.Threading;

namespace SmartAnything
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            //try
            //{
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {


                if (!commonFunctions.ValidateMachineDateTimeFromat())
                { return; }

                u_DBConnection.getConnection();
                Globals.PopulateSysSetup();
                commonFunctions.LoadDefault();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new frm_reportViwer());

                string filePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();

                if (Directory.Exists(filePath))
                {
                    //MessageBox.Show(Application.CommonAppDataPath.Trim());
                    //MessageBox.Show(Application.ExecutablePath.Trim());
                    //MessageBox.Show(filePath);
                    Application.Run(new frmU_Login());
                    //Application.Run(new SmartAnything.UI.frm_seccenter());

                }
                else
                {
                    UserDefineMessages.ShowMsg("Log File Path   " + filePath.Trim() + "  not found. Application will configure a deferant path. Please Rerun the application.", UserDefineMessages.Msg_Information);
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    config.AppSettings.Settings.Remove("LogFilePath");
                    config.AppSettings.Settings.Add("LogFilePath", Application.LocalUserAppDataPath.Trim());
                    config.Save(ConfigurationSaveMode.Modified);
                    Application.Exit();
                    return;
                }
                //}
                //catch (System.Data.SqlClient.SqlException exsql) {
                //    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Error_Loginfail, commonFunctions.Softwarename.Trim());
                //}
                //catch (Exception ex)
                //{
                //    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Error_common, commonFunctions.Softwarename.Trim());
                //}
                mutex.ReleaseMutex();
            }
            else {
                UserDefineMessages.ShowMsg("One instance of the" + "Software" + "  is already running. Please look at the notification area", UserDefineMessages.Msg_Information);
            }


        }
    }
}
