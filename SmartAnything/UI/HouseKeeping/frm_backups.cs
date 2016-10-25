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
using System.Reflection;
using System.IO;

namespace SmartAnything.UI.HouseKeeping
{
    public partial class frm_backups : Form
    {

        int formMode = 0;
        string formID = "A0031";
        string formHeadertext = "Backups";
        DataTable dtx = new DataTable();
        bool already = false;
        string pathx = "";

        #region Loading one instance

        private static frm_backups objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_backups getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_backups();

            }
            return objSingleObject;

        }

        #endregion

        public frm_backups()
        {
            InitializeComponent();
        }

        private void frm_backups_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                //FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

                pathx = ConfigurationManager.AppSettings["BackupPath"].ToString();
                lbl_Path.Text = pathx.Trim();
                if (Directory.Exists(pathx)) {
                    fbrowser.RootFolder = Environment.SpecialFolder.MyComputer;

                }
              
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on loading", 1);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fbrowser.ShowDialog() == System.Windows.Forms.DialogResult.Yes) {

                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("BackupPath");
                config.AppSettings.Settings.Add("BackupPath", fbrowser.SelectedPath);
                config.Save(ConfigurationSaveMode.Modified);
                commonFunctions.SetMDIStatusMessage("Successfully Configured..", 1);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (!Directory.Exists(pathx)) {
                        MessageBox.Show("Path not exists . please create path .......: \n" + pathx);
                        Directory.CreateDirectory(pathx);
                    }
                    
                    DateTime dt = DateTime.Now;
                    string backname = BuildBackupPathWithFilename(pathx, "RIT_AT");
                    string strsql = @"BACKUP DATABASE RIT_AT TO DISK = '" + backname.Trim() + "';";
                    int x = u_DBConnection.ExecuteNonQuery(strsql);
                    //MessageBox.Show(x.ToString());

                    //BackupService bs = new BackupService(u_DBConnection.g_DBConnection.ConnectionString,@"C:\");
                    //bs.BackupDatabase("RIT_AT");
                    MessageBox.Show("Backup Complete \n" + backname.Trim());
                }
                catch (Exception ex) {
                    MessageBox.Show("Backup Failed.......: \n" + ex.Message);
                }
            }
        }

        private string BuildBackupPathWithFilename(string _backupFolderFullPath ,string databaseName)
        {
            string filename = string.Format("{0}-{1}-{2}.bak", databaseName, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH_mm_ss.f"));

            return Path.Combine(_backupFolderFullPath, filename);
        }
    }
}
