using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using smartOffice.UI;
using SmartAnything;

namespace SmartAnything
{
    public class LogFile
    {
        public static void CreateLogFolder()
        {
            try
            {
                string subPath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"].ToString() + "logs";
                PermissionSet permissionSet = new PermissionSet(PermissionState.None);

                FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, subPath);

                permissionSet.AddPermission(writePermission);

                if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
                {
                    if (!Directory.Exists(subPath))
                    {
                        Directory.CreateDirectory(subPath);

                    }
                }
            }
            catch (Exception ex)
            {
                smartOfficeMessageBox.ShowMsg(ex.Message.ToString());
            }
        }

        public static void LogFileCreate()
        {
            try
            {
                string subPath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"].ToString() + "logs";
                DateTime today = DateTime.Today;
                string logFileName = "log_" + today.ToString("yyyy_MM_dd") + ".txt";
                string logFilePath = (subPath + "/" + logFileName).ToString();
                if (Directory.Exists(subPath))
                {

                    if (!File.Exists(logFilePath))
                    {
                        File.Create(logFilePath);
                    }
                }
                else
                {
                    CreateLogFolder();
                    LogFileCreate();
                }
            }
            catch (Exception ex)
            {
                smartOfficeMessageBox.ShowMsg(ex.Message.ToString());
            }
        }

        public static void WriteErrorLog(string methodName, string page, string message, string type = "Exception")
        {
            try
            {
                //EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
                string subPath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"].ToString() + "logs";
                DateTime today = DateTime.Today;
                DateTime now = DateTime.Now;
                string logFileName = "log_" + today.ToString("yyyy_MM_dd") + ".txt";
                string logFilePath = (subPath + "/" + logFileName).ToString();
                if (File.Exists(logFilePath))
                {
                    File.AppendAllLines(logFilePath, new[] { "[" + type + "][" + now.ToString() + "][Form: " + page + "][User: " + Globals.g_strUser + "][Method: " + methodName + "][Message: " + message + "]" });
                }
                else
                {
                    //waitHandle.WaitOne();
                    LogFileCreate();
                    //waitHandle.Set();
                    // waitHandle.WaitOne();
                    WriteErrorLog(methodName, message, type);
                    // waitHandle.Set();
                }
            }
            catch (Exception ex)
            {
                //smartOfficeMessageBox.ShowMsg(ex.Message.ToString());
            }
        }

        public static void WriteErrorLog(string methodName, string page, string message)
        {
            try
            {
                //EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
                string subPath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"].ToString() + "logs";
                DateTime today = DateTime.Today;
                DateTime now = DateTime.Now;
                string logFileName = "log_" + today.ToString("yyyy_MM_dd") + ".txt";
                string logFilePath = (subPath + "/" + logFileName).ToString();
                if (File.Exists(logFilePath))
                {
                    File.AppendAllLines(logFilePath, new[] { "[" + "" + "][" + now.ToString() + "][Form: " + page + "][User: " + Globals.g_strUser + "][Method: " + methodName + "][Message: " + message + "]" });
                }
                else
                {
                    //waitHandle.WaitOne();
                    LogFileCreate();
                    //waitHandle.Set();
                    // waitHandle.WaitOne();
                    WriteErrorLog(methodName, message, "");
                    // waitHandle.Set();
                }
            }
            catch (Exception ex)
            {
                smartOfficeMessageBox.ShowMsg(ex.Message.ToString());
            }
        }
    }
}
