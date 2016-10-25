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
using SmartAnything.Reports.DistributionRpt;
using SmartAnything.Reports.SalesRpt;
using SmartAnything.Reports.StockRpt;

namespace SmartAnything.Reports
{
    public partial class frm_DistributionReporint : Form
    {

        int formMode = 0;
        string formID = "A0019";
        string formHeadertext = "Reprint";
        DataTable dtx = new DataTable();
        DataTable dtxpayment = new DataTable();


        #region Loading one instance

        private static frm_DistributionReporint objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_DistributionReporint getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_DistributionReporint();

            }
            return objSingleObject;

        }

        #endregion


        public frm_DistributionReporint()
        {
            InitializeComponent();
        }

        private void frm_DistributionReporint_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (txt_docno.Text == "") {
                errorProvider1.SetError(txt_docno, "Please enter invoice number to print");
                commonFunctions.SetMDIStatusMessage("Please enter invoice number to print", 1);
                return;
            }
            string status = "duplicate";

            if (rdo_order.Checked) {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                //rpt = ReportStrings.PrintDocWithstatus("Customer Order Form","Duplicate");
                rpt = ReportStrings.PrintDocWithstatus("Customer Order Form", status);
                rpt_t_orderform rptBank = new rpt_t_orderform();
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderPrintSTR(txt_docno.Text.Trim(),commonFunctions.GlobalLocation)));
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();

            }

            if (rdo_inv.Checked)
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                //rpt = ReportStrings.PrintDocWithstatus("Customer Order Form","Duplicate");
                rpt = ReportStrings.PrintDocWithstatus("Customer Invoice", status);
                rpt_invoicePrint rptBank = new rpt_invoicePrint();
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetInvoicePrintSTR(txt_docno.Text.Trim(), commonFunctions.GlobalLocation)));
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();

            }
            if (rdo_do.Checked)
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                //rpt = ReportStrings.PrintDocWithstatus("Customer Order Form","Duplicate");
                rpt = ReportStrings.PrintDocWithstatus("DELIVERY ORDER", status);
                rpt_t_do rptBank = new rpt_t_do();
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetDOSTR(txt_docno.Text.Trim())));
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();

            }
            if (rdo_rec.Checked)
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                //rpt = ReportStrings.PrintDocWithstatus("Customer Order Form","Duplicate");
                rpt = ReportStrings.PrintDocWithstatus("DELIVERY ORDER", status);
                rpt_receiptprint rptBank = new rpt_receiptprint();
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetReceiptSTR(txt_docno.Text.Trim())));
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
        }

        private void PrintDoc(string DocNo, string loca, string locaname)
        {
            string reporttitle = "Customer Invoice".ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramFields = commonFunctions.AddCrystalParamsWithLoca(reporttitle, commonFunctions.Loginuser.ToUpper(), loca, locaname);

            paramField.Name = "status";
            paramDiscreteValue.Value = "processed".ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            rpt_receiptprint rptBank = new rpt_receiptprint();
            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetReceiptSTR(DocNo.Trim())));
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
        }

        private void txt_docno_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                //txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);

            }
            if (e.KeyCode == Keys.F2)
            {
                if (rdo_inv.Checked)
                {
                    if (ActiveControl.Name.Trim() == txt_docno.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["InvoiceFieldLength"]);
                        string[] strSearchField = new string[length];
                        string strSQL = ConfigurationManager.AppSettings["InvoiceSQLProcessed"].ToString();
                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["InvoiceField" + m + ""].ToString();
                        }
                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }
                }
                if (rdo_rec.Checked)
                {
                    if (ActiveControl.Name.Trim() == txt_docno.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["ReceiptFieldLength"]);
                        string[] strSearchField = new string[length];
                        string strSQL = ConfigurationManager.AppSettings["ReceiptSQLProcessed"].ToString();
                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["ReceiptField" + m + ""].ToString();
                        }
                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }
                }

                if (rdo_order.Checked)
                {
                    if (ActiveControl.Name.Trim() == txt_docno.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["OrderFormReportsFieldLength"]);
                        string[] strSearchField = new string[length];
                        string strSQL = ConfigurationManager.AppSettings["OrderFormReportsUSSQL"].ToString();
                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["OrderFormReportsField" + m + ""].ToString();
                        }
                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }
                }
                if (rdo_do.Checked)
                {
                    if (ActiveControl.Name.Trim() == txt_docno.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["DOFieldLength"]);
                        string[] strSearchField = new string[length];
                        string strSQL = ConfigurationManager.AppSettings["DOSQL"].ToString();
                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["DOField" + m + ""].ToString();
                        }
                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }
                }




            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt = ReportStrings.PrintDoc("Order Tracking Summary");
            rpt_pendingapprovals rptBank = new rpt_pendingapprovals();
            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovaltSTR("")));
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
        }
    }
}
