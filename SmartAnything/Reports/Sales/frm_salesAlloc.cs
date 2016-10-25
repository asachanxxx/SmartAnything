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
namespace SmartAnything.Reports.Sales
{
    public partial class frm_salesAlloc : Form
    {

        int formMode = 0;
        string formID = "A0080";
        string formHeadertext = "Sales Allocation";
        DataTable dtx = new DataTable();


        #region Loading one instance

        private static frm_salesAlloc objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_salesAlloc getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_salesAlloc();

            }
            return objSingleObject;

        }

        #endregion

        public frm_salesAlloc()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_salesAlloc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (rdo_salwise.Checked)
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                rpt = ReportStrings.PrintDoc("Sales Allocation".ToUpper());
                rpt_salealloc_salesman rptBank = new rpt_salealloc_salesman();

                if (rdo_fulldetails.Checked) // option 1 full view of order tracking
                {
                    rptBank.SetDataSource(ReportStrings.GetSalesAllocSalOnly(txt_salesman.Text.Trim(), "", 1));
                }

                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            else if (rdo_salcuswise.Checked)
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                rpt = ReportStrings.PrintDoc("Sales Allocation".ToUpper());
                rpt_salealloc_sale_customer rptBank = new rpt_salealloc_sale_customer();

                if (rdo_fulldetails.Checked) // option 1 full view of order tracking
                {
                    rptBank.SetDataSource(ReportStrings.GetSalesAlloc(txt_salesman.Text.Trim(), "", 1));
                }

                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
        }
    }
}
