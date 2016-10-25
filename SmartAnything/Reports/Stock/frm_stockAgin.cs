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


namespace SmartAnything.Reports.Stock
{
    public partial class frm_stockAgin : Form
    {
        int formMode = 0;
        string formID = "R0008";
        string formHeadertext = "Stock Aging";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_stockAgin objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_stockAgin getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_stockAgin();

            }
            return objSingleObject;

        }

        #endregion

        public frm_stockAgin()
        {
            InitializeComponent();
        }

        private void frm_stockAgin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void txt_loca1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                txt_loca1_name.Text = findExisting.FindExisitingLoca(txt_loca1.Text);

            }
            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["LocaFieldLength"]);
                string[] strSearchField = new string[length];
                string strSQL = ConfigurationManager.AppSettings["LocaSQL"].ToString();
                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["LocaField" + m + ""].ToString();
                }
                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);
            }

        }

        private void txt_loca2_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                txt_loca2_name.Text = findExisting.FindExisitingLoca(txt_loca2.Text);

            }
            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["LocaFieldLength"]);
                string[] strSearchField = new string[length];
                string strSQL = ConfigurationManager.AppSettings["LocaSQL"].ToString();
                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["LocaField" + m + ""].ToString();
                }
                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);
            }

        }

        private void txt_loca1_TextChanged(object sender, EventArgs e)
        {
            txt_loca1_name.Text = findExisting.FindExisitingLoca(txt_loca1.Text);
        }

        private void txt_loca2_TextChanged(object sender, EventArgs e)
        {
            txt_loca2_name.Text = findExisting.FindExisitingLoca(txt_loca2.Text);
        }

        private void txt_Category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Category_name.Text = findExisting.FindExisitingcategory(txt_Category.Text);
            }
            if (e.KeyCode == Keys.F2)
            {

                int length = Convert.ToInt32(ConfigurationManager.AppSettings["CategoryFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["CategorySQL"].ToString();

                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["CategoryField" + m + ""].ToString();
                }

                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);

            }
        }

        private void txt_Category1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Category1_name.Text = findExisting.FindExisitingcategory(txt_Category1.Text);
            }
            if (e.KeyCode == Keys.F2)
            {

                int length = Convert.ToInt32(ConfigurationManager.AppSettings["CategoryFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["CategorySQL"].ToString();

                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["CategoryField" + m + ""].ToString();
                }

                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);

            }
        }

        private void txt_Category_TextChanged(object sender, EventArgs e)
        {
            txt_Category_name.Text = findExisting.FindExisitingcategory(txt_Category.Text);
        }

        private void txt_Category1_TextChanged(object sender, EventArgs e)
        {
            txt_Category1_name.Text = findExisting.FindExisitingcategory(txt_Category1.Text);
        }

        private void txt_supplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["SupplierFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["SupplierSQL"].ToString();

                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["SupplierField" + m + ""].ToString();
                }

                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);
            }
            if (e.KeyCode == Keys.Enter)
            {
                txt_supplier_name.Text = findExisting.FindExisitingSupplier(txt_supplier.Text);
                errorProvider1.Clear();
            }
        }

        private void txt_supplier1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["SupplierFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["SupplierSQL"].ToString();

                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["SupplierField" + m + ""].ToString();
                }

                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);
            }
            if (e.KeyCode == Keys.Enter)
            {
                txt_supplier1_name.Text = findExisting.FindExisitingSupplier(txt_supplier1.Text);
                errorProvider1.Clear();
            }
        }

        private void txt_supplier_TextChanged(object sender, EventArgs e)
        {
            txt_supplier_name.Text = findExisting.FindExisitingSupplier(txt_supplier.Text);
        }

        private void txt_supplier1_TextChanged(object sender, EventArgs e)
        {
            txt_supplier1_name.Text = findExisting.FindExisitingSupplier(txt_supplier1.Text);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
