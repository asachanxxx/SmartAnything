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
    public partial class frm_stockValuation : Form
    {

        int formMode = 0;
        string formID = "R0001";
        string formHeadertext = "Stock Eveluation Report";
        DataTable dtx = new DataTable();


        #region Loading one instance

        private static frm_stockValuation objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_stockValuation getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_stockValuation();

            }
            return objSingleObject;

        }

        #endregion

        public frm_stockValuation()
        {
            InitializeComponent();
        }

        private void frm_stockValuation_Load(object sender, EventArgs e)
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
            if (rdo_supp.Checked) {
                PrintDoc(1);
            }
            else if (rdo_cat.Checked)
            {
                if (rdo_subcat.Checked)
                {
                    PrintDoc(3);
                }
                else
                {
                    PrintDoc(2);
                }
            }
            else if (rdo_full.Checked)
            {
                PrintDoc(0);
            }

            
        }


        private void PrintDoc(int typex)
        {
            string reporttitle = "Stock Evaluation".ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramFields = commonFunctions.AddCrystalParamsWithLoca(reporttitle, commonFunctions.Loginuser.ToUpper(), commonFunctions.GlobalLocation, findExisting.FindExisitingLoca(commonFunctions.GlobalLocation));

            paramField.Name = "status";
            paramDiscreteValue.Value = "processed".ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            Rpt_Stockevo rptBank = new Rpt_Stockevo();
            if (typex == 0)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportEngine.GetStockEvoSTR(commonFunctions.GlobalLocation, typex, "", "")));
            }
            else if (typex == 1)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportEngine.GetStockEvoSTR(commonFunctions.GlobalLocation, typex, txt_Suplier.Text.Trim(), "")));
            }
            else if (typex == 2)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportEngine.GetStockEvoSTR(commonFunctions.GlobalLocation, typex, txt_Category.Text, "")));
            }
            else if (typex == 3)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportEngine.GetStockEvoSTR(commonFunctions.GlobalLocation, typex, txt_Category.Text,txt_subcat.Text.Trim())));
            }
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
        }

        private void txt_Suplier_KeyDown(object sender, KeyEventArgs e)
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
                txt_suppliername.Text = findExisting.FindExisitingSupplier(txt_Suplier.Text);
                errorProvider1.Clear();
            }
        }
         private void txt_Suplier_TextChanged(object sender, EventArgs e)
        {
            txt_suppliername.Text = findExisting.FindExisitingSupplier(txt_Suplier.Text);
            rdo_supp.Checked = true;
        }

        private void txt_Category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_categoryName.Text = findExisting.FindExisitingcategory(txt_Category.Text);
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

        private void txt_subcat_KeyDown(object sender, KeyEventArgs e)
        {

            if (txt_Category.Text.Trim() == "") {
                commonFunctions.SetMDIStatusMessage("Please enter category first", 1);
                errorProvider1.SetError(txt_Category, "Please enter category first");
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                
                //FindExisitingsubCategory();
            }
            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["SUBCategoryFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["SUBCategorySQL"].ToString() + " FROM dbo.M_SubCategory WHERE (CategoryID = '" + txt_Category.Text.Trim() + "')";
                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["SUBCategoryField" + m + ""].ToString();
                }

                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);

                
            }


        }

       

        private void txt_subcat_TextChanged(object sender, EventArgs e)
        {
            txt_subcat_name.Text = findExisting.FindExisitingsubcategory(txt_Category.Text,txt_subcat.Text.Trim());
            rdo_subcat.Checked = true;
        }

        private void txt_Category_TextChanged(object sender, EventArgs e)
        {
            txt_categoryName.Text = findExisting.FindExisitingcategory(txt_Category.Text);
            rdo_cat.Checked = true;
        }
    }
}
