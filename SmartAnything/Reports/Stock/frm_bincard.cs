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
    public partial class frm_bincard : Form
    {

        int formMode = 0;
        string formID = "R0002";
        string formHeadertext = "Bin Card Report";
        DataTable dtx = new DataTable();


        #region Loading one instance

        private static frm_bincard objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_bincard getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_bincard();

            }
            return objSingleObject;

        }

        #endregion

        public frm_bincard()
        {
            InitializeComponent();
        }

        private void frm_bincard_Load(object sender, EventArgs e)
        {
            //
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
            txt_loca1.Text = commonFunctions.GlobalLocation;
            txt_loca1_name.Text = findExisting.FindExisitingLoca(txt_loca1.Text);

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txt_subcat.Focus();
                txt_categoryName.Text = findExisting.FindExisitingcategory(txt_Category.Text);

            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_Category.Name.Trim())
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
        }

        private void txt_subcat_KeyDown(object sender, KeyEventArgs e)
        {

            if (txt_Category.Text.Trim() == "")
            {
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

                if (ActiveControl.Name.Trim() == txt_subcat.Name.Trim())
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


        }

        private void txt_subcat_TextChanged(object sender, EventArgs e)
        {
            txt_subcat_name.Text = findExisting.FindExisitingsubcategory(txt_Category.Text, txt_subcat.Text.Trim());
            rdo_subcat.Checked = true;
        }

        private void txt_Category_TextChanged(object sender, EventArgs e)
        {
            txt_categoryName.Text = findExisting.FindExisitingcategory(txt_Category.Text);
            rdo_cat.Checked = true;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            txt_loca1_name.Text = findExisting.FindExisitingLoca(txt_loca1.Text);
        
            if (rdo_full.Checked)
            {
                PrintDoc(0);
            }
            else if (rdo_cat.Checked)
            {
                if (rdo_subcat.Checked)
                {
                    PrintDoc(1);
                }
                else
                {
                    PrintDoc(2);
                }
            }
            else if (rdo_itemfrom.Checked) {
                PrintDoc(3);
            }
            else if (rdo_location.Checked)
            {
                PrintDoc(4);
            }
        }

        private void PrintDoc(int typex)
        {
            string reporttitle = "Bin Card Report".ToUpper();
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

            rpt_bincard rptBank = new rpt_bincard();
            if (typex == 0)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetBinCard(txt_loca1.Text.Trim(), typex, "", "")));
            }
            else if (typex == 1)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetBinCard(txt_loca1.Text.Trim(), typex, txt_Category.Text, txt_subcat.Text.Trim())));
            }
            else if (typex == 2)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetBinCard(txt_loca1.Text.Trim(), typex, txt_Category.Text, "")));
            }
            else if (typex == 3)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetBinCard(txt_loca1.Text.Trim(), typex, txt_itemcode1.Text.Trim(), txt_itemcode2.Text.Trim())));

            }
            else if (typex == 4)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetBinCard(txt_loca1.Text.Trim(), typex, txt_loca1.Text.Trim(), txt_loca2.Text.Trim())));

            }
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
        }

        private void txt_itemcode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_itemcode1_name.Text = findExisting.FindExisitingProduct(txt_itemcode1.Text);
                txt_itemcode2.Focus();

            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_itemcode1.Name.Trim())
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


            }
        }

        private void txt_itemcode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txt_subcat.Focus();
                txt_itemcode2_name.Text = findExisting.FindExisitingProduct(txt_itemcode2.Text);

            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_itemcode2.Name.Trim())
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


            }
        }

        private void txt_itemcode2_TextChanged(object sender, EventArgs e)
        {
            txt_itemcode2_name.Text = findExisting.FindExisitingProduct(txt_itemcode2.Text);
            rdo_itemfrom.Checked = true;
        }

        private void txt_itemcode1_TextChanged(object sender, EventArgs e)
        {
            txt_itemcode1_name.Text = findExisting.FindExisitingProduct(txt_itemcode1.Text);
            rdo_itemfrom.Checked = true;
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
            Chk_allLoca.Checked = false;
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
            Chk_allLoca.Checked = false;
        }

        private void txt_loca1_TextChanged(object sender, EventArgs e)
        {
            txt_loca1_name.Text = findExisting.FindExisitingLoca(txt_loca1.Text);
        }

        private void txt_loca2_TextChanged(object sender, EventArgs e)
        {
            txt_loca2_name.Text = findExisting.FindExisitingLoca(txt_loca2.Text);
        }
    }
}
