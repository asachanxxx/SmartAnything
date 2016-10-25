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
    public partial class frm_invoiceApproval : Form
    {

        int formMode = 0;
        string formID = "A0050";
        string formHeadertext = "Invoice Approval";
        DataTable dtx = new DataTable();
        bool already = false;
        string codex = "";

        #region Loading one instance

        private static frm_invoiceApproval objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_invoiceApproval getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_invoiceApproval();

            }
            return objSingleObject;

        }

        #endregion

        public frm_invoiceApproval()
        {
            InitializeComponent();
        }

        private void frm_invoiceApproval_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

            getProcessedInvoices();
            commonFunctions.FormatDataGrid(dataGridView1);
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 200;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private DataTable getProcessedInvoices()
        {

            DataTable dt = new DataTable();
            dataGridView1.DataSource = T_InvoiceHedDL.SelectAllt_InvoiceHedApproval();
            return dt;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                codex = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                T_InvoiceHed cat = new T_InvoiceHed();
                cat.InvID = codex.Trim();
                T_InvoiceHedDL dl = new T_InvoiceHedDL();
                cat = dl.Selectt_InvoiceHed(cat);

                txt_DocNo.Text = cat.InvID;
                txt_Locacode.Text = cat.LocaCode.Trim();
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text);
                txt_Customer.Text = cat.Customer.Trim();
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                txt_Remarks.Text = cat.Remarks;
                //dte_date.Value = cat.Datex.Value;
                //dte_RecivedDate.Value = cat.RecivedDate.Value;

                txt_NetTotal.Text = cat.NetAmt.ToString();
                txt_Subtotal.Text = cat.GrossAmt.ToString();
                txt_subtotdiscper.Text = cat.SubtotaldiscPer.ToString();
                txt_TotalDisc.Text = cat.TotalDisc.ToString();
                txt_subtotdisc.Text = cat.SubtotalDisc.ToString();



            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (codex.Trim() != "")
            {

                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Approve, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {

                    T_InvoiceHed objt_trnsferNote = new T_InvoiceHed();
                    objt_trnsferNote.InvID = txt_DocNo.Text.Trim();
                    T_InvoiceHedDL dl = new T_InvoiceHedDL();
                    objt_trnsferNote = dl.Selectt_InvoiceHed(objt_trnsferNote);

                    objt_trnsferNote.Approved = 1;
                    objt_trnsferNote.ApprovedDate = DateTime.Now;
                    objt_trnsferNote.AprrovedBy = commonFunctions.Loginuser;
                    dl.Savet_InvoiceHedSP(objt_trnsferNote, 3);

                    T_OrderTracking track = new T_OrderTracking();
                    track.OFNo = objt_trnsferNote.OrderFormNo.Trim();
                    track = new T_OrderTrackingDL().Selectt_OrderTracking(track,xEnums.OrderTrackingTypes.OrderNo);
                    track.InvApproved = 1;
                    track.InvApprovedDate = DateTime.Now;
                    track.InvApprovedUser = commonFunctions.Loginuser;
                    new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);

                    getProcessedInvoices();
                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                }
            }
            else
            {
                errorProvider1.SetError(dataGridView1, "Pelase select a order form from the list");
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Ava");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Ava Click");
            if (dataGridView1.SelectedRows.Count > 0)
            {
                codex = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                T_InvoiceHed cat = new T_InvoiceHed();
                cat.InvID = codex.Trim();
                T_InvoiceHedDL dl = new T_InvoiceHedDL();
                cat = dl.Selectt_InvoiceHed(cat);

                txt_DocNo.Text = cat.InvID;
                txt_Locacode.Text = cat.LocaCode.Trim();
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text);
                txt_Customer.Text = cat.Customer.Trim();
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                txt_Remarks.Text = cat.Remarks;
                //dte_date.Value = cat.Datex.Value;
                //dte_RecivedDate.Value = cat.RecivedDate.Value;

                txt_NetTotal.Text = cat.NetAmt.ToString();
                txt_Subtotal.Text = cat.GrossAmt.ToString();
                txt_subtotdiscper.Text = cat.SubtotaldiscPer.ToString();
                txt_TotalDisc.Text = cat.TotalDisc.ToString();
                txt_subtotdisc.Text = cat.SubtotalDisc.ToString();



            }

        }
    }
}
