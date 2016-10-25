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
    public partial class frm_StockCard : Form
    {

        int formMode = 0;
        string formID = "R0003";
        string formHeadertext = "Stock Card";
        DataTable dtx = new DataTable();

        public frm_StockCard()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_StockCard objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_StockCard getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_StockCard();

            }
            return objSingleObject;

        }

        #endregion

        private void btn_print_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(txt_loca.Text.Trim() == string.Empty){
                commonFunctions.SetMDIStatusMessage("Please enter location first", 1);
                errorProvider1.SetError(txt_loca, "Please enter location first");
                return;
            }
            if (txt_itemcode1.Text.Trim() == string.Empty)
            {
                commonFunctions.SetMDIStatusMessage("Please enter stock code first", 1);
                errorProvider1.SetError(txt_itemcode1, "Please enter stock code first");
                return;
            }
            if (chk_all.Checked)
            {
                PrintDoc(1);
            }
            else
            {
                PrintDoc(0);
            }
        }

        private void PrintDoc(int typex)
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
            if (typex == 0)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockCard(commonFunctions.GlobalLocation, typex, txt_itemcode1.Text.Trim(), txt_loca.Text.Trim())));
            }
            else if (typex == 1)
            {
                rptBank.SetDataSource(commonFunctions.GetDatatable(ReportStrings.GetStockCard(commonFunctions.GlobalLocation, typex, txt_itemcode1.Text.Trim(), "")));
            }
            rpt.RepViewer.ParameterFieldInfo = paramFields;
            rpt.RepViewer.ReportSource = rptBank;
            rpt.RepViewer.Refresh();
            rpt.Show();
        }

        private void frm_StockCard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void txt_itemcode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdo_stockCode.Checked = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["ProductStockFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["ProductStockSQL"].ToString() + " WHERE dbo.T_Stock.Locacode = '" + txt_loca.Text.Trim()  + "'";

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

        private void txt_itemcode1_TextChanged(object sender, EventArgs e)
        {
            rdo_stockCode.Checked = true;
        }

        private void txt_loca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_loca_name.Text = findExisting.FindExisitingLoca(txt_loca.Text);

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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_loca_TextChanged(object sender, EventArgs e)
        {
            txt_loca_name.Text = findExisting.FindExisitingLoca(txt_loca.Text);
            rdo_location.Checked = true;
        }
    }
}
