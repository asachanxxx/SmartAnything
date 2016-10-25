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
    public partial class frm_pendingApprovals : Form
    {

        int formMode = 0;
        string formID = "A0080";
        string formHeadertext = "Pending Approvals";
        DataTable dtx = new DataTable();

        public frm_pendingApprovals()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_pendingApprovals objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_pendingApprovals getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_pendingApprovals();

            }
            return objSingleObject;

        }

        #endregion

        private void frm_pendingApprovals_Load(object sender, EventArgs e)
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


            try
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;

                if (rdo_fulldet.Checked)
                {
                    if (rdo_orderform.Checked)
                    {
                        rpt = ReportStrings.PrintDoc("PENDING Order Forms");
                        rpt_pendingOF rptBank = new rpt_pendingOF();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalOF(txt_Suplier.Text.Trim(), "", dtfrom.Value, dtto.Value, 4)));
                        rpt.RepViewer.ReportSource = rptBank;
                    }
                    if (rdo_invoice.Checked)
                    {
                        rpt = ReportStrings.PrintDoc("PENDING Invoices");
                        rpt_pendingInvoice rptBank = new rpt_pendingInvoice();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalInvoices(txt_Suplier.Text.Trim(), "", dtfrom.Value, dtto.Value, 4)));
                        rpt.RepViewer.ReportSource = rptBank;
                    }
                    if (rdo_DO.Checked)
                    {
                        rpt = ReportStrings.PrintDoc("PENDING Dilivery Orders");
                        rpt_penddingDos rptBank = new rpt_penddingDos();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovaldos(txt_Suplier.Text.Trim(), "", dtfrom.Value, dtto.Value, 4)));
                        rpt.RepViewer.ReportSource = rptBank;
                    }
                }


                if (rdo_supp.Checked)
                {
                    if (txt_Suplier.Text.Trim() == "")
                    {
                        commonFunctions.SetMDIStatusMessage("Please enter supplier first", 1);
                        errorProvider1.SetError(txt_Category, "Please enter supplier first");
                        return;
                    }
                    if (rdo_orderform.Checked)
                    {
                        rpt = ReportStrings.PrintDoc("PENDING Order Forms");
                        rpt_pendingOF rptBank = new rpt_pendingOF();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalOF(txt_Suplier.Text.Trim(), "", dtfrom.Value, dtto.Value, 1)));
                        rpt.RepViewer.ReportSource = rptBank;
                    }
                    if (rdo_invoice.Checked)
                    {
                        rpt = ReportStrings.PrintDoc("PENDING Invoices");
                        rpt_pendingInvoice rptBank = new rpt_pendingInvoice();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalInvoices(txt_Suplier.Text.Trim(), "", dtfrom.Value, dtto.Value, 1)));
                        rpt.RepViewer.ReportSource = rptBank;
                    }
                    if (rdo_DO.Checked)
                    {
                        rpt = ReportStrings.PrintDoc("PENDING Dilivery Orders");
                        rpt_penddingDos rptBank = new rpt_penddingDos();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovaldos(txt_Suplier.Text.Trim(), "", dtfrom.Value, dtto.Value, 1)));
                        rpt.RepViewer.ReportSource = rptBank;
                    }
                }

                if (rdo_cat.Checked)
                {
                    if (txt_Category.Text.Trim() == "")
                    {
                        commonFunctions.SetMDIStatusMessage("Please enter customer category first", 1);
                        errorProvider1.SetError(txt_Category, "Please enter customer category first");
                        return;
                    }

                    if (!rdo_subcat.Checked) //with subcategory
                    {

                        if (rdo_orderform.Checked)
                        {
                            rpt = ReportStrings.PrintDoc("PENDING Order Forms");
                            rpt_pendingOF rptBank = new rpt_pendingOF();
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalOF(txt_Category.Text.Trim(), "", dtfrom.Value, dtto.Value, 2)));
                            rpt.RepViewer.ReportSource = rptBank;
                        }
                        if (rdo_invoice.Checked)
                        {
                            rpt = ReportStrings.PrintDoc("PENDING Invoices");
                            rpt_pendingInvoice rptBank = new rpt_pendingInvoice();
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalInvoices(txt_Category.Text.Trim(), "", dtfrom.Value, dtto.Value, 2)));
                            rpt.RepViewer.ReportSource = rptBank;
                        }
                        if (rdo_DO.Checked)
                        {
                            rpt = ReportStrings.PrintDoc("PENDING Dilivery Orders");
                            rpt_penddingDos rptBank = new rpt_penddingDos();
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovaldos(txt_Category.Text.Trim(), "", dtfrom.Value, dtto.Value, 2)));
                            rpt.RepViewer.ReportSource = rptBank;

                        }
                    }
                    else
                    { //with no subcategory 
                        if (txt_subcat.Text.Trim() == "")
                        {
                            commonFunctions.SetMDIStatusMessage("Please enter customer subcategory first", 1);
                            errorProvider1.SetError(txt_subcat, "Please enter customer subcategory first");
                            return;
                        }
                        if (rdo_orderform.Checked)
                        {
                            rpt = ReportStrings.PrintDoc("PENDING Order Forms");
                            rpt_pendingOF rptBank = new rpt_pendingOF();
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalOF(txt_Category.Text.Trim(), txt_subcat.Text.Trim(), dtfrom.Value, dtto.Value, 3)));
                            rpt.RepViewer.ReportSource = rptBank;
                        }
                        if (rdo_invoice.Checked)
                        {
                            rpt = ReportStrings.PrintDoc("PENDING Invoices");
                            rpt_pendingInvoice rptBank = new rpt_pendingInvoice();
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovalInvoices(txt_Category.Text.Trim(), txt_subcat.Text.Trim(), dtfrom.Value, dtto.Value, 3)));
                            rpt.RepViewer.ReportSource = rptBank;
                        }
                        if (rdo_DO.Checked)
                        {
                            rpt = ReportStrings.PrintDoc("PENDING Dilivery Orders");
                            rpt_penddingDos rptBank = new rpt_penddingDos();
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetPendingApprovaldos(txt_Category.Text.Trim(), txt_subcat.Text.Trim(), dtfrom.Value, dtto.Value, 2)));
                            rpt.RepViewer.ReportSource = rptBank;

                        }
                    }
                }



                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            catch (Exception ex) { 
            
            }
        }

        private void txt_Suplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_Suplier.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CustFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CustSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CustField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                txt_suppliername.Text = findExisting.FindExisitingCUstomer(txt_Suplier.Text);
            }
        }

        private void txt_Suplier_TextChanged(object sender, EventArgs e)
        {
            txt_suppliername.Text = findExisting.FindExisitingCUstomer(txt_Suplier.Text);
            rdo_supp.Checked = true;
        }

        private void txt_Category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_Category.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CuscatFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CuscatSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CuscatField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                txt_categoryName.Text = findExisting.FindExisitingCustomerCategory(txt_Category.Text);
            }
        }

        private void txt_subcat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (txt_Category.Text.Trim() != "")
                {

                    if (ActiveControl.Name.Trim() == txt_subcat.Name.Trim())
                    {
                        int length = Convert.ToInt32(ConfigurationManager.AppSettings["CussubcatFieldLength"]);
                        string[] strSearchField = new string[length];

                        string strSQL = ConfigurationManager.AppSettings["CussubcatSQL"].ToString() + " WHERE CatID = '" + txt_Category.Text + "'";

                        for (int i = 0; i < length; i++)
                        {
                            string m;
                            m = i.ToString();
                            strSearchField[i] = ConfigurationManager.AppSettings["CussubcatField" + m + ""].ToString();
                        }

                        frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                        find.ShowDialog(this);
                    }
                }
                txt_subcat_name.Text = findExisting.FindExisitingCustomerSub(txt_Category.Text, txt_subcat.Text);
                rdo_subcat.Checked = true;
            }
        }

        private void txt_subcat_TextChanged(object sender, EventArgs e)
        {
            txt_subcat_name.Text = findExisting.FindExisitingCustomerSub(txt_Category.Text, txt_subcat.Text);
        }

        private void txt_Category_TextChanged(object sender, EventArgs e)
        {
            txt_categoryName.Text = findExisting.FindExisitingCustomerCategory(txt_Category.Text);
            rdo_cat.Checked = true;
        }
    }
}
