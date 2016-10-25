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
    public partial class frm_stockBalance : Form
    {

        int formMode = 0;
        string formID = "R0004";
        string formHeadertext = "Stock Balance";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_stockBalance objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_stockBalance getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_stockBalance();

            }
            return objSingleObject;

        }

        #endregion


        public frm_stockBalance()
        {
            InitializeComponent();
        }

        private void frm_stockBalance_Load(object sender, EventArgs e)
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
            int headeroption = 1;
            int middleoption = 1;
            int bottomoption = 1;

            string reporttitle = formHeadertext.ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramFields = commonFunctions.AddCrystalParamsWithLoca(reporttitle, commonFunctions.Loginuser.ToUpper(), commonFunctions.GlobalLocation, findExisting.FindExisitingLoca(commonFunctions.GlobalLocation));

            paramField.Name = "status";
            paramDiscreteValue.Value = "Original".ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);



            if (rdo_productwise.Checked)
            {
                rpt_stockbalance_product rptBank = new rpt_stockbalance_product();
                if (rdo_all.Checked)
                {
                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_loca1.Text, txt_loca2.Text, "", 1, 1, 1)));
                }
                else
                {
                    if (Chk_allLoca.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_loca1.Text, txt_loca2.Text, "", 1, 2, 1)));
                    }
                    else if (rdo_product.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_product1.Text, txt_product2.Text, "", 1, 3, 1)));
                    }
                    else if (rdo_category.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_Category.Text, txt_Category1.Text, "", 1, 4, 1)));
                    }
                }
                rpt.RepViewer.ParameterFieldInfo = paramFields;
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            else if (rdo_lotwise.Checked)
            {
                rpt_stockbalance_Stock rptBank = new rpt_stockbalance_Stock();
                if (rdo_all.Checked)
                {
                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_loca1.Text, txt_loca2.Text, "", 2, 1, 1)));
                }
                else
                {
                    if (rdo_location.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_loca1.Text, txt_loca2.Text, "", 2, 1, 1)));
                    }
                    else if (rdo_product.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_loca1.Text, txt_loca2.Text, "", 2, 1, 1)));
                    }
                    else if (rdo_category.Checked)
                    {
                        rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance(txt_loca1.Text, txt_loca2.Text, "", 2, 1, 1)));
                    }
                }
                rpt.RepViewer.ParameterFieldInfo = paramFields;
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }


        }

        private void PrintDoc(int headeroption, int middleoption, int bottomoption)
        {
            string reporttitle = formHeadertext.ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramFields = commonFunctions.AddCrystalParamsWithLoca(reporttitle, commonFunctions.Loginuser.ToUpper(), commonFunctions.GlobalLocation, findExisting.FindExisitingLoca(commonFunctions.GlobalLocation));

            paramField.Name = "status";
            paramDiscreteValue.Value = "Original".ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            rpt_StockCard rptBank = new rpt_StockCard();
            if (rdo_productwise.Checked)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockBalance("","","",headeroption,middleoption,bottomoption)));
            }
            else if (rdo_lotwise.Checked)
            {

            }

            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
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
            txt_loca1_name.Text = findExisting.FindExisitingLoca(txt_loca1.Text);

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

            txt_loca2_name.Text = findExisting.FindExisitingLoca(txt_loca2.Text);
        }

        private void txt_loca1_TextChanged(object sender, EventArgs e)
        {
            txt_loca1_name.Text = findExisting.FindExisitingLoca(txt_loca1.Text);
        }

        private void txt_loca2_TextChanged(object sender, EventArgs e)
        {
            txt_loca2_name.Text = findExisting.FindExisitingLoca(txt_loca2.Text);
        }

        private void txt_product1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (rdo_productwise.Checked)
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ProductField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
                else if (rdo_lotwise.Checked)
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductStockFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ProductStockField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
            if (rdo_productwise.Checked)
            {
                txt_product1_name.Text = findExisting.FindExisitingProduct(txt_product1.Text);
            }
            else if (rdo_productwise.Checked)
            {
                txt_product1_name.Text = findExisting.FindExisitingStock(txt_product1.Text);
            }
        }

        private void txt_product2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (rdo_productwise.Checked)
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ProductField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
                else if (rdo_lotwise.Checked)
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductStockFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["ProductStockField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
            if (rdo_productwise.Checked)
            {
                txt_product1_name.Text = findExisting.FindExisitingProduct(txt_product1.Text);
            }
            else if (rdo_productwise.Checked)
            {
                txt_product1_name.Text = findExisting.FindExisitingStock(txt_product1.Text);
            }
        }

        private void txt_product1_TextChanged(object sender, EventArgs e)
        {
            if (rdo_productwise.Checked)
            {
                txt_product1_name.Text = findExisting.FindExisitingProduct(txt_product1.Text);
            }
            else if (rdo_productwise.Checked)
            {
                txt_product1_name.Text = findExisting.FindExisitingStock(txt_product1.Text);
            }

            
        }

        private void txt_product2_TextChanged(object sender, EventArgs e)
        {
            if (rdo_productwise.Checked)
            {
                txt_product2_name.Text = findExisting.FindExisitingProduct(txt_product2.Text);
            }
            else if (rdo_productwise.Checked)
            {
                txt_product2_name.Text = findExisting.FindExisitingStock(txt_product2.Text);
            }
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

        private void txt_Category_TextChanged(object sender, EventArgs e)
        {
            txt_Category_name.Text = findExisting.FindExisitingcategory(txt_Category.Text);
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

        private void txt_Category1_TextChanged(object sender, EventArgs e)
        {
            txt_Category1_name.Text = findExisting.FindExisitingcategory(txt_Category1.Text);
        }

    }
}
