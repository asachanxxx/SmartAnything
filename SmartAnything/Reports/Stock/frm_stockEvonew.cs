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
    public partial class frm_stockEvonew : Form
    {

        int formMode = 0;
        string formID = "R0005";
        string formHeadertext = "Stock eveluation";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_stockEvonew objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_stockEvonew getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_stockEvonew();

            }
            return objSingleObject;

        }

        #endregion

        public frm_stockEvonew()
        {
            InitializeComponent();
        }

        private void frm_stockEvonew_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void btn_print_Click(object sender, System.EventArgs e)
        {
            //if (rdo_gcustomer.Checked)
            //{
            //    PrintDoc(2, 1);
            //}
            //else {
            //    PrintDoc(1, 1);
            //}


            PrintDoc2(2, 1);
        }

        private void PrintDoc2(int grouping, int typex)
        {
            string reporttitle = "Stock Evaluation".ToUpper();
            frm_reportViwer rpt = new frm_reportViwer();
            rpt.MdiParent = MDI_SMartAnything.ActiveForm;
            rpt.FormHeadertext = reporttitle;

            rpt_productsinhala rptBank = new rpt_productsinhala();
            string str = "SELECT        PRODUCT_CODE, PRODUCT_DESC, PRODUCT_OTHERNAME, PRODUCT_MRPPER, PRODUCT_WSPPER FROM            TBLM_PRODUCT";
            rptBank.SetDataSource(commonFunctions.GetDatatable(str.Trim()));
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();

        }


        private void PrintDoc(int grouping,int typex)
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

        private void btn_exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
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

            txt_product1_name.Text = findExisting.FindExisitingProduct(txt_product1.Text);

        }

        private void txt_product1_TextChanged(object sender, EventArgs e)
        {
            txt_product1_name.Text = findExisting.FindExisitingProduct(txt_product1.Text);
        }

        private void txt_product2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
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

            txt_product2_name.Text = findExisting.FindExisitingProduct(txt_product2.Text);
        }

        private void txt_product2_TextChanged(object sender, EventArgs e)
        {
            txt_product2_name.Text = findExisting.FindExisitingProduct(txt_product2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsComHandle cp;
            cp = new ClsComHandle();

            System.Threading.Thread.Sleep(100);
            if ("ClsGeneral.header.Trim().Length".Length > 0)
            {
                cp.printDOT(3, "ClsGeneral.header.Trim().Length");
            }
    
        }
    }
}
