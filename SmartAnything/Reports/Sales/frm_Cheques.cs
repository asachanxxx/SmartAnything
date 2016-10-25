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
    public partial class frm_Cheques : Form
    {

        int formMode = 0;
        string formID = "A0080";
        string formHeadertext = "Order Tracking";
        DataTable dtx = new DataTable();


        #region Loading one instance

        private static frm_Cheques objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_Cheques getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_Cheques();

            }
            return objSingleObject;

        }

        #endregion

        public frm_Cheques()
        {
            InitializeComponent();
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

        private void frm_Cheques_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                rpt = ReportStrings.PrintDoc("cheque details".ToUpper());
                rpt_allCQs rptBank = new rpt_allCQs();

                if (rdo_fulldetails.Checked) // option 1 full view of order tracking
                {
                    if (rdo_pd.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 1, 1)));
                    }
                    else if (rdo_returned.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 1, 2)));
                    }
                    else if (rdo_relize.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 1, 3)));
                    }
                    else if (rdo_unrealize.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 1, 4)));
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
                    if (rdo_pd.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 1)));
                    }
                    else if (rdo_returned.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 2)));
                    }
                    else if (rdo_relize.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 3)));
                    }
                    else if (rdo_unrealize.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Suplier.Text.Trim(), false, "", dtfrom.Value, dtto.Value, 2, 4)));
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
                    if (rdo_pd.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Category.Text.Trim(), false, subcat, dtfrom.Value, dtto.Value, header, 1)));
                    }
                    else if (rdo_returned.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Category.Text.Trim(), false, subcat, dtfrom.Value, dtto.Value, header, 2)));
                    }
                    else if (rdo_relize.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Category.Text.Trim(), false, subcat, dtfrom.Value, dtto.Value, header, 3)));
                    }
                    else if (rdo_unrealize.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCQDetails(txt_Category.Text.Trim(), false, subcat, dtfrom.Value, dtto.Value, header, 4)));
                    }


                }


                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            catch (Exception ex) { }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
