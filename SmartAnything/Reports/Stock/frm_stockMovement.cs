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
    public partial class frm_stockMovement : Form
    {

        int formMode = 0;
        string formID = "R0009";
        string formHeadertext = "Stock Movement Report";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_stockMovement objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_stockMovement getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_stockMovement();

            }
            return objSingleObject;

        }

        #endregion

        public frm_stockMovement()
        {
            InitializeComponent();
        }

        private void frm_stockMovement_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void btn_exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, System.EventArgs e)
        {
            //if (rdo_gcustomer.Checked)
            //{
            //    PrintDoc(2, 1);
            //}
            //else
            //{
            //    PrintDoc(1, 1);
            //}
        }

        private void PrintDoc(int grouping, int typex)
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


            if (grouping == 1)
            {
                rpt_stockEvoNew rptBank = new rpt_stockEvoNew();
                if (typex == 1)
                {
                    rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockEvoNew("001", "", "", "", 1, 1)));
                }
                else if (typex == 2)
                {
                    // rptBank.SetDataSource(commonFunctions.GetDatatable(ReportEngine.GetStockEvoSTR(commonFunctions.GlobalLocation, typex, txt_Suplier.Text.Trim(), "")));
                }
                rpt.RepViewer.ParameterFieldInfo = paramFields;
                rpt.RepViewer.ReportSource = rptBank;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }
            else if (grouping == 2)
            {
                rpt_stockevonew_Groupcus rptgroupCat = new rpt_stockevonew_Groupcus();
                if (typex == 1)
                {
                    rptgroupCat.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockEvoNew("001", "", "", "", 1, 1)));
                }

                rpt.RepViewer.ParameterFieldInfo = paramFields;
                rpt.RepViewer.ReportSource = rptgroupCat;
                rpt.RepViewer.Refresh();
                rpt.Show();
            }


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

        private void txt_supplier_TextChanged(object sender, EventArgs e)
        {
            txt_supplier_name.Text = findExisting.FindExisitingSupplier(txt_supplier.Text);
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

        private void txt_supplier1_TextChanged(object sender, EventArgs e)
        {
            txt_supplier1_name.Text = findExisting.FindExisitingSupplier(txt_supplier1.Text);
        }
    }
}
