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
    public partial class frm_audit : Form
    {

        int formMode = 0;
        string formID = "A0035";
        string formHeadertext = "Delivery order Audit";
        DataTable dtx = new DataTable();
        bool already = false;
        string codex = "";

        #region Loading one instance

        private static frm_audit objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_audit getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_audit();

            }
            return objSingleObject;

        }

        #endregion

        public frm_audit()
        {
            InitializeComponent();
        }

        private void frm_audit_Load(object sender, EventArgs e)
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
                commonFunctions.FormatDataGrid(dataGridView2);
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[1].Width = 110;
                dataGridView1.Columns[3].Width = 260;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on loading", 1);
            }
        }


        private DataTable getProcessedDOs()
        {
            DataTable dt = new DataTable();
            try
            {
                dataGridView1.DataSource = commonFunctions.GetDatatable("SELECT  dbo.T_DIliveryHed.DoNo, dbo.T_DIliveryHed.InvoiceAmount, dbo.T_DIliveryHed.Customer, dbo.M_Customers.CustName FROM dbo.T_DIliveryHed INNER JOIN  dbo.M_Customers ON dbo.T_DIliveryHed.Customer = dbo.M_Customers.CusID WHERE     (dbo.T_DIliveryHed.Processed = 1 AND Approved = 1 and Audited = 0 )");
                return dt;
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on getting processed current delivery orders", 2);
                return dt;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    getDetails(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    codex = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    T_DIliveryHed cat = new T_DIliveryHed();
                    cat.DoNo = codex.Trim();
                    cat.LocaCode = commonFunctions.GlobalLocation;
                    cat = new T_DIliveryHedDL().Selectt_DIliveryHed(cat,2);
                    GridPass();
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


        private DataTable getDetails(string code )
        {
            DataTable dt = new DataTable();
            try
            {
                dataGridView2.DataSource = commonFunctions.GetDatatable("SELECT     Item AS 'Item Code',b.Descr AS 'Item Name', Unit AS 'Unit', Qty AS 'Quntity',ActualCartons AS 'Actual',Carton AS 'Cartons' ,Pass , Remarks   FROM    dbo.T_DiliveryDet AS a INNER JOIN dbo.T_Stock AS b ON a.Item = b.StockCode WHERE DoNo ='" + code.Trim() + "'");
                commonFunctions.FormatDataGrid(dataGridView2);
                dataGridView2.Columns[0].Width = 110;
                dataGridView2.Columns[1].Width = 200;
                dataGridView2.Columns[2].Width = 50;
                dataGridView2.Columns[3].Width = 65;
                dataGridView2.Columns[7].Width = 250;
                dataGridView2.Columns[0].ReadOnly = true;
                dataGridView2.Columns[1].ReadOnly = true;
                dataGridView2.Columns[2].ReadOnly = true;
                dataGridView2.Columns[3].ReadOnly = true;
                //dataGridView2.Columns[4].ReadOnly = true;
                dataGridView2.Columns[6].ReadOnly = true;
                return dt;

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on getting processed current delivery orders", 2);
                return dt;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (txt_aremarks.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_aremarks, "Audit remarks cannot be empty.");
                    commonFunctions.SetMDIStatusMessage("Audit remarks cannot be empty.", 1);
                    return;
                }

                if (codex.Trim() == "")
                {
                    errorProvider1.SetError(dataGridView1, "Pelase select a delivery order from the list");
                    commonFunctions.SetMDIStatusMessage("Pelase select a delivery order from the list", 1);
                    return;
                }
               
                if (!GridPass()) {
                    errorProvider1.SetError(dataGridView2, "There is a variance in DO QTY and actual QTY");
                    commonFunctions.SetMDIStatusMessage("There is a variance in DO QTY and actual QTY", 1);
                    return;
                }
                if (!CartonChecking())
                {
                    errorProvider1.SetError(dataGridView2, "Invalied Carton details");
                    commonFunctions.SetMDIStatusMessage("Invalied Carton details", 1);
                    return;
                }
                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Approve, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {


                    T_DIliveryHed objt_trnsferNote = new T_DIliveryHed();
                    objt_trnsferNote.DoNo = txt_DocNo.Text.Trim();
                    objt_trnsferNote.LocaCode = commonFunctions.GlobalLocation;
                    objt_trnsferNote = new T_DIliveryHedDL().Selectt_DIliveryHed(objt_trnsferNote,2);

                    objt_trnsferNote.AuditRemarks = txt_aremarks.Text.Trim();
                    objt_trnsferNote.ReportedProblems = txt_repproblems.Text.Trim();
                    objt_trnsferNote.Audited = 1;
                    objt_trnsferNote.AuditDate = DateTime.Now;
                    objt_trnsferNote.AuditUser = commonFunctions.Loginuser;
                    new T_DIliveryHedDL().Savet_DIliveryHedSP(objt_trnsferNote, 3);

                    T_OrderTracking track = new T_OrderTracking();
                    track.DONo = txt_DocNo.Text.Trim();
                    track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.DoNumber);
                    track.Audited = 1;
                    track.AuditUser = commonFunctions.Loginuser;
                    track.AuditDate = DateTime.Now;
                    new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);
                   

                    foreach (DataGridViewRow drow in dataGridView2.Rows)
                    {
                        if (drow.Cells[0].Value.ToString().Trim() != null)
                        {
                            T_DiliveryDet det = new T_DiliveryDet();
                            det.DoNo = txt_DocNo.Text.Trim();
                            det.Item = drow.Cells[0].Value.ToString().Trim();
                            det = new T_DiliveryDetDL().Selectt_DiliveryDet(det);
                            det.Carton = commonFunctions.ToDecimal(drow.Cells[5].Value.ToString().Trim());
                            det.ActualCartons = commonFunctions.ToDecimal(drow.Cells[5].Value.ToString().Trim());
                            det.Remarks = drow.Cells[7].Value.ToString().Trim();
                            det.Pass = true;
                            new T_DiliveryDetDL().Savet_DiliveryDetSP(det, 3);
                        }
                    }
                    commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                    getProcessedDOs();
                    getDetails("");
                }

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error when approving the delivery order", 1);
            }
        }
        //3- qty
        //4 -actual 
        //5 - cartons

        bool CartonChecking() {
            bool pass = true;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow drow in dataGridView2.Rows)
                {
                    if (drow.Cells[0].Value.ToString().Trim() != null)
                    {
                        int ori = commonFunctions.ToInt(drow.Cells[5].Value.ToString());
                        if (ori <= 0)
                        {
                            pass = false;
                        }
                    }
                }
            }
            else {
                pass = false;
            }
            return pass;
        }

        private bool  GridPass() {
            bool pass = true;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow drow in dataGridView2.Rows)
                {
                    drow.DefaultCellStyle.BackColor = Color.Red;

                    if (drow.Cells[0].Value.ToString().Trim() != null)
                    {
                        int ori = commonFunctions.ToInt(drow.Cells[3].Value.ToString());
                        int Actual = commonFunctions.ToInt(drow.Cells[4].Value.ToString());
                        if (ori < Actual)
                        {
                            drow.Cells[4].Value = "0";
                            drow.Cells[7].Value = "Actual QTY cannot exceed do QTY".ToUpper();
                        }

                        if (ori == Actual)
                        {
                            drow.Cells[6].Value = true;
                            drow.Cells[7].Value = "";
                            drow.DefaultCellStyle.BackColor = Color.White;

                        }
                        else
                        {
                            drow.Cells[6].Value = false;
                            drow.Cells[7].Value = "Invalied QTY for auditing".ToUpper();
                            pass = false;
                        }
                    }

                }
            }
            else {
                pass = false;
            }
            return pass;
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            GridPass();
        }
    }
}
