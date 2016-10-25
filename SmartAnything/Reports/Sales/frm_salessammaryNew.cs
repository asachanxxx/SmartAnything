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
    public partial class frm_salessammaryNew : Form
    {

        int formMode = 0;
        string formID = "A0080";
        string formHeadertext = "Sales Sammary";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_salessammaryNew objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_salessammaryNew getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_salessammaryNew();

            }
            return objSingleObject;

        }

        #endregion

        public frm_salessammaryNew()
        {
            InitializeComponent();
        }

        private void frm_salessammaryNew_Load(object sender, EventArgs e)
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
                rpt = ReportStrings.PrintDoc("Sales Sammary");
                rpt_salessmmary_new rptBank = new rpt_salessmmary_new();

                if (rdo_fulldetails.Checked) // option 1 full view of order tracking
                {
                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetSalesSammaryNew("", false, "", dtfrom.Value, dtto.Value, 1, 1)));
                }
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            catch (Exception ex) { }
        }
    }
}
