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
    public partial class frm_OrderFormApproval : Form
    {

        int formMode = 0;
        string formID = "A0033";
        string formHeadertext = "Customer Order Form Approval";
        DataTable dtx = new DataTable();
        bool already = false;
        string codex = "";
        T_OrderFormHead cat;

        #region Loading one instance

        private static frm_OrderFormApproval objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_OrderFormApproval getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_OrderFormApproval();

            }
            return objSingleObject;

        }

        #endregion

        public frm_OrderFormApproval()
        {
            InitializeComponent();
        }


        private void frm_OrderFormApproval_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            //FunctionButtonStatus(xEnums.PerformanceType.Default);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

            getProcessedOrderforms();
            commonFunctions.FormatDataGrid(dataGridView1);
            commonFunctions.FormatDataGrid(dataGridView2);
            commonFunctions.FormatDataGrid(dataGridView3);
            commonFunctions.FormatDataGrid(dte_cheques);
            
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 200;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private DataTable getProcessedOrderforms()
        {

            DataTable dt = new DataTable();
            dataGridView1.DataSource = T_OrderFormHeadDL.SelectAllt_OrderFormHeadApproval();
            return dt;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (codex.Trim() != "")
            {

                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Approve, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {

                    T_OrderFormHead objt_trnsferNote = new T_OrderFormHead();
                    objt_trnsferNote.DocNo = txt_DocNo.Text.Trim();
                    objt_trnsferNote = new T_OrderFormHeadDL().Selectt_OrderFormHead(objt_trnsferNote);


                    objt_trnsferNote.DiscountPer = commonFunctions.ToDecimal(txt_subtotdiscper.Text.Trim());
                    objt_trnsferNote.TotalDisc = commonFunctions.ToDecimal(txt_TotalDisc.Text.Trim());
                    objt_trnsferNote.NetTotal = commonFunctions.ToDecimal(txt_NetTotal.Text.Trim());
                    

                    objt_trnsferNote.Approved = 1;
                    objt_trnsferNote.ApprovedDate = DateTime.Now;
                    objt_trnsferNote.ApprovedBy = commonFunctions.Loginuser;
                    objt_trnsferNote.Remarks =  txt_Remarks.Text.Trim();
                    new T_OrderFormHeadDL().Savet_OrderFormHeadSP(objt_trnsferNote, 3);

                    T_OrderTracking track = new T_OrderTracking();
                    track.OFNo = objt_trnsferNote.DocNo.Trim();
                    track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.OrderNo);
                    track.OFApproved = 1;
                    track.OFApprovedUser = commonFunctions.Loginuser;
                    track.OFApprovedDate = DateTime.Now;
                    new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);

                    getProcessedOrderforms();
                   
                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                    
                }
            }
            else
            {
                errorProvider1.SetError(dataGridView1, "Pelase select a order form from the list");
                commonFunctions.SetMDIStatusMessage("Pelase select a order form from the list", 1);
            }

            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            commonFunctions.SetMDIStatusMessage("Set error on OFA" ,1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            LoadData();
        }

        private void LoadData()
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                codex = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cat = new T_OrderFormHead();
                cat.DocNo = codex.Trim();
                T_OrderFormHeadDL dl = new T_OrderFormHeadDL();
                cat = dl.Selectt_OrderFormHead(cat);

                txt_DocNo.Text = cat.DocNo;
                txt_Locacode.Text = cat.Locacode.Trim();
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text);
                txt_Customer.Text = cat.Customer.Trim();
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                txt_Remarks.Text = cat.Remarks;
                //dte_date.Value = cat.Datex.Value;
                //dte_RecivedDate.Value = cat.RecivedDate.Value;

                txt_NetTotal.Text = cat.NetTotal.ToString();
                txt_Subtotal.Text = cat.Subtotal.ToString();
                txt_subtotdiscper.Text = cat.DiscountPer.ToString();
                txt_TotalDisc.Text = cat.TotalDisc.ToString();
                txt_subtotdisc.Text = cat.SubtotalDisc.ToString();


                M_Customers cusx = new M_Customers();
                cusx.CusID = cat.Customer.Trim();
                cusx = new M_CustomerDL().Selectm_Customer(cusx);
                txt_os.Text = cusx.customerOS.ToString();
                txt_creditlimit.Text = cusx.CreditLimit.ToString();
                lbl_creditPeriod.Text = cusx.CreditPeriod.ToString();

                dataGridView2.DataSource = T_OrderFormHeadDL.GetCreditNoteItems(cat.Customer.Trim());
                dataGridView2.Columns[0].Width = 120;
                dataGridView2.Columns[1].Width = 120;
                dataGridView2.Columns[2].Width = 120;
                dataGridView2.Columns[3].Width = 120;
                dataGridView2.Refresh();

                dataGridView3.DataSource = T_OrderFormHeadDL.GetInvoiceDetails(cat.Customer.Trim());
                dataGridView3.Columns[0].Width = 120;
                dataGridView3.Columns[1].Width = 120;
                dataGridView3.Columns[2].Width = 120;
                dataGridView3.Columns[3].Width = 120;
                dataGridView3.Refresh();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pnl_invoicedet.Hide();
        }

        private void btn_Invoices_Click(object sender, EventArgs e)
        {
            pnl_invoicedet.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnl_cheque.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_cndet_Click(object sender, EventArgs e)
        {
            pnl_credinote.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnl_credinote.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnl_cheque.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Customer.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() == "<Error!!!>".Trim())
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                DataTable dt3 = new DataTable();
                string str = "SELECT     dbo.T_RecDet.Docno AS [Receipt No], dbo.T_RecDet.Paytype, dbo.T_RecDet.CQno AS [Cheque No], dbo.T_RecDet.Bank, dbo.M_Bank.BANK_NAME AS [Bank Name],dbo.T_RecDet.BankBranch AS Branch, dbo.T_RecDet.BankDate AS [Bank Date], dbo.T_RecDet.isReconsile AS Reconsiled,dbo.T_RecDet.ReconsileDate AS [Rec Date] " +
                             "FROM         dbo.T_RecDet INNER JOIN dbo.M_Bank ON dbo.T_RecDet.Bank = dbo.M_Bank.BANK_CODE WHERE     (dbo.T_RecDet.Paytype = 'CQ') AND dbo.T_RecDet.customer = '" + txt_Customer.Text.Trim() + "'";
                dt3 = commonFunctions.GetDatatable(str);
                dte_cheques.DataSource = dt3;
                dte_cheques.Columns[0].Width = 100;
                dte_cheques.Columns[1].Width = 90;
                dte_cheques.Columns[2].Width = 100;
                dte_cheques.Columns[3].Width = 60;
                dte_cheques.Columns[4].Width = 160;
                dte_cheques.Columns[5].Width = 60;
                dte_cheques.Refresh();


            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Customer.Text.Trim() == "")
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() == "<Error!!!>".Trim())
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                DataTable dt3 = new DataTable();
                string str = "SELECT     dbo.T_RecDet.Docno AS [Receipt No], dbo.T_RecDet.Paytype, dbo.T_RecDet.CQno AS [Cheque No], dbo.T_RecDet.Bank, dbo.M_Bank.BANK_NAME AS [Bank Name],dbo.T_RecDet.BankBranch AS Branch, dbo.T_RecDet.BankDate AS [Bank Date], dbo.T_RecDet.isReconsile AS Reconsiled,dbo.T_RecDet.ReconsileDate AS [Rec Date] " +
                             "FROM         dbo.T_RecDet INNER JOIN dbo.M_Bank ON dbo.T_RecDet.Bank = dbo.M_Bank.BANK_CODE WHERE     (dbo.T_RecDet.Paytype = 'CQ') AND dbo.T_RecDet.customer = '" + txt_Customer.Text.Trim() + "' AND isReconsile = 0";
                dt3 = commonFunctions.GetDatatable(str);
                dte_cheques.DataSource = dt3;
                dte_cheques.Columns[0].Width = 100;
                dte_cheques.Columns[1].Width = 90;
                dte_cheques.Columns[2].Width = 100;
                dte_cheques.Columns[3].Width = 60;
                dte_cheques.Columns[4].Width = 160;
                dte_cheques.Columns[5].Width = 60;
                dte_cheques.Refresh();


            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadingData();
        }

        private void LoadingData()
        {

            DataTable dt3 = new DataTable();

            try
            {

                if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() == "<Error!!!>".Trim())
                {
                    errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                    commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                    return;
                }

                dt3 = T_RecDetDL.GetCQ(txt_Customer.Text.Trim(), rdo_daterange.Checked, rdo_post.Checked, rdo_retured.Checked, rdo_unrealized.Checked, rdo_realized.Checked, dte_to.Value, dte_from.Value);

                dte_cheques.DataSource = dt3;
                dte_cheques.Columns[0].Visible = false;
                dte_cheques.Columns[1].Width = 100;
                dte_cheques.Columns[2].Width = 100;
                dte_cheques.Columns[3].Width = 190;
                dte_cheques.Columns[4].Visible = false;
                dte_cheques.Columns[5].Width = 100;
                dte_cheques.Columns[8].Width = 260;

                dte_cheques.Columns[0].ReadOnly = true;
                dte_cheques.Columns[1].ReadOnly = true;
                dte_cheques.Columns[2].ReadOnly = true;
                dte_cheques.Columns[3].ReadOnly = true;
                dte_cheques.Columns[4].ReadOnly = true;
                dte_cheques.Columns[5].ReadOnly = true;

                dte_cheques.Refresh();




            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            pnl_cheque.Hide();
        }

        private void txt_subtotdiscper_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txt_subtotdiscper.Text.Trim() == string.Empty)
            //{
            //    txt_subtotdiscper.Text = "0.00";
            //}
            if (e.KeyCode == Keys.Enter)
            {
                decimal gross = commonFunctions.ToDecimal(txt_Subtotal.Text);
                if (cat != null)
                {
                    decimal subtotdisc = (gross * commonFunctions.ToDecimal(txt_subtotdiscper.Text)) / 100;
                    decimal totdisc = subtotdisc + cat.ItemdiscTotal.Value;
                    decimal net = gross - totdisc;

                    txt_subtotdisc.Text = subtotdisc.ToString();
                    txt_TotalDisc.Text = totdisc.ToString();
                    txt_NetTotal.Text = net.ToString();
                }
            }
        }

        private void txt_subtotdiscper_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (codex.Trim() != "")
            {

                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Reject, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {

                    T_OrderFormHead objt_trnsferNote = new T_OrderFormHead();
                    objt_trnsferNote.DocNo = txt_DocNo.Text.Trim();
                    objt_trnsferNote = new T_OrderFormHeadDL().Selectt_OrderFormHead(objt_trnsferNote);


                    objt_trnsferNote.Approved = 2;
                    objt_trnsferNote.ApprovedDate = DateTime.Now;
                    objt_trnsferNote.ApprovedBy = commonFunctions.Loginuser;
                    objt_trnsferNote.Remarks = txt_Remarks.Text.Trim();
                    new T_OrderFormHeadDL().Savet_OrderFormHeadSP(objt_trnsferNote, 3);

                    T_OrderTracking track = new T_OrderTracking();
                    track.OFNo = objt_trnsferNote.DocNo.Trim();
                    track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.OrderNo);
                    track.OFApproved = 2;
                    track.OFApprovedUser = commonFunctions.Loginuser;
                    track.OFApprovedDate = DateTime.Now;
                    new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);

                    getProcessedOrderforms();

                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                }
            }
            else
            {
                errorProvider1.SetError(dataGridView1, "Pelase select a order form from the list");
                commonFunctions.SetMDIStatusMessage("Pelase select a order form from the list", 1);
            }
        }

    }
}
 