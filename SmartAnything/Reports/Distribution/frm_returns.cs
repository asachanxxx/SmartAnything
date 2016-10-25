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


namespace SmartAnything.Reports.Distribution
{
    public partial class frm_returns : Form
    {
        int formMode = 0;
        string formID = "A0080";
        string formHeadertext = "Customer Returns";
        DataTable dtx = new DataTable();

        public frm_returns()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_returns objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_returns getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_returns();

            }
            return objSingleObject;

        }

        #endregion

        private void frm_returns_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
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
