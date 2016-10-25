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
    public partial class frm_cartonMarking : Form
    {
        int formMode = 0;
        string formID = "A0015";
        string formHeadertext = "Carton Marking";

        #region Loading one instance

        private static frm_cartonMarking objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_cartonMarking getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_cartonMarking();

            }
            return objSingleObject;

        }

        #endregion

        public frm_cartonMarking()
        {
            InitializeComponent();
        }

        private void frm_cartonMarking_Load(object sender, EventArgs e)
        {
            commonFunctions.FormatDataGrid(dataGridView1);
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_do_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_loca1_name.Text = findExisting.FindExisitingCUstomer(txt_do.Text.Trim());
                dataGridView1.DataSource = commonFunctions.GetDatatable("SELECT     dbo.T_DIliveryHed.DoNo AS 'DO Number', dbo.T_DIliveryHed.Customer, dbo.M_Customers.CustName AS 'Customer Name', dbo.T_DIliveryHed.NoOfCartons AS 'No Of Cartons', dbo.T_DIliveryHed.Datex AS 'Date' FROM         dbo.T_DIliveryHed INNER JOIN dbo.M_Customers ON dbo.T_DIliveryHed.Customer = dbo.M_Customers.CusID " +
                    " WHERE     (dbo.T_DIliveryHed.Audited = 1) AND (dbo.T_DIliveryHed.Customer = '" + txt_do.Text.Trim() + "')");
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 120;
            }
            if (e.KeyCode == Keys.F2)
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
            txt_loca1_name.Text = findExisting.FindExisitingCUstomer(txt_do.Text.Trim());
        }



    }
}
