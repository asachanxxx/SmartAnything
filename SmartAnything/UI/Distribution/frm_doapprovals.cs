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

namespace SmartAnything.UI
{
    public partial class frm_doapprovals : Form
    {

        int formMode = 0;
        string formID = "A0034";
        string formHeadertext = "Delivery order approvals";
        DataTable dtx = new DataTable();
        bool already = false;
        string codex = "";

        #region Loading one instance

        private static frm_doapprovals objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_doapprovals getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_doapprovals();

            }
            return objSingleObject;

        }

        #endregion

        public frm_doapprovals()
        {
            InitializeComponent();
        }

        private void frm_doapprovals_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                //FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

                getProcessedDOs();
                commonFunctions.FormatDataGrid(dataGridView1);
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[1].Width = 200;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                }
            }
            catch (Exception ex) {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on loading", 1);
            }
        }

        private DataTable getProcessedDOs()
        {
            DataTable dt = new DataTable();
            try
            {
                dataGridView1.DataSource = commonFunctions.GetDatatable("SELECT  dbo.T_DIliveryHed.DoNo, dbo.T_DIliveryHed.InvoiceAmount, dbo.T_DIliveryHed.Customer, dbo.M_Customers.CustName FROM dbo.T_DIliveryHed INNER JOIN  dbo.M_Customers ON dbo.T_DIliveryHed.Customer = dbo.M_Customers.CusID WHERE     (dbo.T_DIliveryHed.Processed = 1 AND Approved = 0 )");
                return dt;  
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on getting processed current delivery orders", 2);
                return dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    codex = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    T_DIliveryHed cat = new T_DIliveryHed();
                    cat.DoNo = codex.Trim();
                    cat.LocaCode = commonFunctions.GlobalLocation;
                    cat = new T_DIliveryHedDL().Selectt_DIliveryHed(cat,2);

                    txt_DocNo.Text = cat.DoNo;
                    txt_Locacode.Text = cat.LocaCode.Trim();
                    txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text);
                    txt_Customer.Text = cat.Customer.Trim();
                    txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                    txt_Lorry.Text = cat.Lorry.Trim();
                    txt_Lorry_name.Text = findExisting.FindExisitingVehicle(txt_Lorry.Text);
                    txt_Agent.Text = cat.Agent.Trim();
                    txt_Agent_name.Text = findExisting.FindExisitingAgent(txt_Agent.Text);
                    txt_InvNo.Text = cat.InvNo.ToString();
                    txt_InvoiceAmount.Text = cat.InvoiceAmount.ToString();
                    txt_Remarks.Text = cat.Remarks;

                }

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (codex.Trim() != "")
                {

                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Approve, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {

                        T_DIliveryHed objt_trnsferNote = new T_DIliveryHed();
                        objt_trnsferNote.DoNo = txt_DocNo.Text.Trim();
                        objt_trnsferNote.LocaCode = commonFunctions.GlobalLocation;
                        objt_trnsferNote = new T_DIliveryHedDL().Selectt_DIliveryHed(objt_trnsferNote,2);

                        objt_trnsferNote.Approved = 1;
                        objt_trnsferNote.ApprovedDate = DateTime.Now;
                        objt_trnsferNote.ApprovedUser = commonFunctions.Loginuser;
                        new T_DIliveryHedDL().Savet_DIliveryHedSP(objt_trnsferNote, 3);

                        T_OrderTracking track = new T_OrderTracking();
                        track.DONo = txt_DocNo.Text.Trim();
                        //track.OFNo = txt_DocNo.Text.Trim();
                        track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.DoNumber);
                        track.DOApproved = 1;
                        track.DOApprovedUser = commonFunctions.Loginuser;
                        track.DOApprovedDate = DateTime.Now;
                        new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);
                        commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);

                        getProcessedDOs();
                        
                    }
                }
                else
                {
                    errorProvider1.SetError(dataGridView1, "Pelase select a delivery order from the list");
                    commonFunctions.SetMDIStatusMessage("Pelase select a delivery order from the list", 1);
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error when approving the delivery order",1);
            }
        }
    }
}
