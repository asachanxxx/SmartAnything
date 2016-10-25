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
    public partial class frm_customerliability : Form
    {

        int formMode = 0;
        string formID = "A0080";
        string formHeadertext = "CUSTOMER LIABILITY Report";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_customerliability objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_customerliability getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_customerliability();

            }
            return objSingleObject;

        }

        #endregion


        public frm_customerliability()
        {
            InitializeComponent();
        }

        private void frm_customerliability_Load(object sender, EventArgs e)
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

        private void txt_Suplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_customer1.Name.Trim())
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

                txt_customer1_name.Text = findExisting.FindExisitingCUstomer(txt_customer1.Text);
            }
        }

        private void txt_Suplier_TextChanged(object sender, EventArgs e)
        {
            txt_customer1_name.Text = findExisting.FindExisitingCUstomer(txt_customer1.Text);
            rdo_CusRange.Checked = true;
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_salesman.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["UserFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["UserSQL"].ToString() + " WHERE Type = 'SAL'";

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["UserField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                txt_salesman_name.Text = findExisting.FindExisitingUSer(txt_salesman.Text);
                rdo_salesman.Checked = true;
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                frm_reportViwer rpt = new frm_reportViwer();
                rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                rpt = ReportStrings.PrintDoc("CUSTOMER LIABILITY");
                rpt_cusliability rptBank = new rpt_cusliability();


                if (rdo_fulldetails.Checked) // option 1 full view of order tracking
                {

                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCusLiabilityDet("", false, "", dtfrom.Value, dtto.Value, 1, 1)));

                }
                if (rdo_CusRange.Checked) // option 1 full view of order tracking
                {

                    if (txt_customer1.Text.Trim() == "")
                    {
                        commonFunctions.SetMDIStatusMessage("Please enter customer first", 1);
                        errorProvider1.SetError(txt_customer1, "Please enter customer first");
                        return;
                    }
                    if (txt_customer2.Text.Trim() == "")
                    {
                        commonFunctions.SetMDIStatusMessage("Please enter customer first", 1);
                        errorProvider1.SetError(txt_customer2, "Please enter customer first");
                        return;
                    }

                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCusLiabilityDet(txt_customer1.Text, false, txt_customer2.Text, dtfrom.Value, dtto.Value, 1, 2)));
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

                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCusLiabilityDet(txt_customer1.Text, false, txt_customer2.Text, dtfrom.Value, dtto.Value, 1, header)));


                }
                if (rdo_salesman.Checked) // option 1 full view of order tracking
                {
                    if (txt_salesman.Text.Trim() == "")
                    {
                        commonFunctions.SetMDIStatusMessage("Please enter salesman first", 1);
                        errorProvider1.SetError(txt_Category, "Please enter salesman first");
                        return;
                    }

                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetCusLiabilityDet(txt_customer1.Text, false, txt_customer2.Text, dtfrom.Value, dtto.Value, 1, 5)));

                }


                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            catch (Exception ex) { }
        }

        private void txt_customer2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_customer2.Name.Trim())
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
                txt_customer2_name.Text = findExisting.FindExisitingCUstomer(txt_customer2.Text);
            }
        }

        private void txt_customer2_TextChanged(object sender, EventArgs e)
        {
            txt_customer2_name.Text = findExisting.FindExisitingCUstomer(txt_customer2.Text);
            rdo_CusRange.Checked = true;
        }
    }
}
