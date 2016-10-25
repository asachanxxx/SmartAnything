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
    public partial class frm_ordertracking : Form
    {


        int formMode = 0;
        string formID = "A0080";
        string formHeadertext = "Order Tracking";
        DataTable dtx = new DataTable();

        public frm_ordertracking()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_ordertracking objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_ordertracking getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_ordertracking();

            }
            return objSingleObject;

        }

        #endregion

        private void frm_ordertracking_Load(object sender, EventArgs e)
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
                rpt = ReportStrings.PrintDoc("Order Tracking");
                rpt_OrderTrackingSummary rptBank = new rpt_OrderTrackingSummary();

                if (rdo_summary.Checked) //if summary cracked
                {
                    if (rdo_fulldetails.Checked) // option 1 full view of order tracking
                    {
                        if (rdo_pinv.Checked) //if pending invoice cracked
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary("", false,"", dtfrom.Value, dtto.Value, 1, 1)));
                        }
                        else if (rdo_pdo.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary("", false, "", dtfrom.Value, dtto.Value, 1, 2)));
                        }
                        else if (rdo_paudit.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary("", false, "", dtfrom.Value, dtto.Value, 1, 3)));
                        }
                        else if (rdo_pdispatch.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary("", false, "", dtfrom.Value, dtto.Value, 1, 4)));
                        }
                        else if (rdo_dilivery.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary("", false, "", dtfrom.Value, dtto.Value, 1, 5)));
                        }
                        else if (rdo_pconfirm.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary("", false, "", dtfrom.Value, dtto.Value, 1, 6)));
                        }

                    }
                    if (rdo_supp.Checked) // option 1 full view of order tracking
                    {

                        if (txt_Suplier.Text.Trim() == "")
                        {
                            commonFunctions.SetMDIStatusMessage("Please enter customer first", 1);
                            errorProvider1.SetError(txt_Suplier, "Please enter customer first");
                            return;
                        }

                        if (rdo_pinv.Checked) //if pending invoice cracked
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 1)));
                        }
                        else if (rdo_pdo.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 2)));
                        }
                        else if (rdo_paudit.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 3)));
                        }
                        else if (rdo_pdispatch.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 4)));
                        }
                        else if (rdo_dilivery.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 5)));
                        }
                        else if (rdo_pconfirm.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 6)));
                        }

                    }

                    if (rdo_cat.Checked) // option 1 full view of order tracking
                    {
                        string subcat = "";
                        int header = 3;
                        if (txt_Category.Text.Trim() == "")
                        {
                            commonFunctions.SetMDIStatusMessage("Please enter customer category first", 1);
                            errorProvider1.SetError(txt_Category, "Please enter customer category first");
                            return;
                        }

                        if (rdo_subcat.Checked)
                        {
                            if (txt_subcat.Text.Trim() == "")
                            {
                                commonFunctions.SetMDIStatusMessage("Please enter customer subcategory first", 1);
                                errorProvider1.SetError(txt_subcat, "Please enter customer subcategory first");
                                return;
                            }
                            subcat = txt_subcat.Text.Trim();
                            header = 4;
                        }

                        if (rdo_pinv.Checked) //if pending invoice cracked
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Category.Text.Trim(), false, subcat, dtfrom.Value, dtto.Value, header, 1)));
                        }
                        else if (rdo_pdo.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Category.Text.Trim(), false, "", dtfrom.Value, dtto.Value, header, 2)));
                        }
                        else if (rdo_paudit.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Category.Text.Trim(), false, "", dtfrom.Value, dtto.Value, header, 3)));
                        }
                        else if (rdo_pdispatch.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Category.Text.Trim(), false, "", dtfrom.Value, dtto.Value, header, 4)));
                        }
                        else if (rdo_dilivery.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Category.Text.Trim(), false, "", dtfrom.Value, dtto.Value, header, 5)));
                        }
                        else if (rdo_pconfirm.Checked) //
                        {
                            rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackSummary(txt_Category.Text.Trim(), false, "", dtfrom.Value, dtto.Value, header, 6)));
                        }

                    }
                   
                }
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();

                if (rdo_foroneorder.Checked)
                {
                    frm_reportViwer rpt1 = new frm_reportViwer();
                    rpt1.MdiParent = MDI_SMartAnything.ActiveForm;
                    rpt1 = ReportStrings.PrintDoc("Order Tracking Summary");
                    rpt_ordertracking rptBank1 = new rpt_ordertracking();
                    rptBank1.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetOrderTrackOne(textBox2.Text.Trim())));
                    rpt1.RepViewer.ReportSource = rptBank1;
                    rpt1.RepViewer.Refresh();
                    rpt1.Show();
                }

            }
            catch (Exception ex) { }
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == textBox2.Name.Trim())
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
        }
    }
}
