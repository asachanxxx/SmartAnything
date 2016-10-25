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
namespace SmartAnything.UI.Transactions
{
    public partial class frm_liveStock : Form
    {

        int formMode = 0;
        string formID = "A0082";
        string formHeadertext = "Live Stock";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_liveStock objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_liveStock getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_liveStock();

            }
            return objSingleObject;

        }

        #endregion



        public frm_liveStock()
        {
            InitializeComponent();
        }

        private void frm_liveStock_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
            commonFunctions.FormatDataGrid(dataGridView1);

            
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

            chk_Allproduct.Checked = false;
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
            chk_Allproduct.Checked = false;
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

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (rdo_all.Checked)
            {
                dataGridView1.DataSource = commonFunctions.GetDatatable(ReportStrings.GetLiveStock(commonFunctions.GlobalLocation, 0, "", ""));
            }
            else if (rdo_location.Checked)
            {
                dataGridView1.DataSource = commonFunctions.GetDatatable(ReportStrings.GetLiveStock(commonFunctions.GlobalLocation,1, txt_loca1.Text, ""));
            }
            else if (rdo_product.Checked)
            {
                dataGridView1.DataSource = commonFunctions.GetDatatable(ReportStrings.GetLiveStock(commonFunctions.GlobalLocation, 2, txt_product1.Text, txt_product2.Text.Trim()));
            }
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[5].Width = 250;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      


        private void rdo_location_Click(object sender, EventArgs e)
        {
            rdo_all.Checked = false;
            rdo_product.Checked = false;
            rdo_productwise.Checked = false;
        }

        private void rdo_all_Click(object sender, EventArgs e)
        {
            rdo_location.Checked = false;
            rdo_product.Checked = false;
            rdo_productwise.Checked = false;
        }

        private void rdo_product_Click(object sender, EventArgs e)
        {
            rdo_all.Checked = false;
            rdo_location.Checked = false;
            rdo_productwise.Checked = true;
        }


        private void ExportToExcel(DataGridView dgvCityDetails)
        {
             //Creating a Excel object.
            //Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //try
            //{

            //    worksheet = workbook.ActiveSheet;
            //    worksheet.Name = "ExportedFromDatGrid";
            //    int cellRowIndex = 1;
            //    int cellColumnIndex = 1;

            //    //Loop through each row and read value from each column.
            //    for (int i = 0; i < dgvCityDetails.Rows.Count - 1; i++)
            //    {
            //        for (int j = 0; j < dgvCityDetails.Columns.Count; j++)
            //        {
            //            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
            //            if (cellRowIndex == 1)
            //            {
            //                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCityDetails.Columns[j].HeaderText;
            //            }
            //            else
            //            {
            //                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCityDetails.Rows[i].Cells[j].Value.ToString();
            //            }
            //            cellColumnIndex++;
            //        }
            //        cellColumnIndex = 1;
            //        cellRowIndex++;
            //    }

            //    //Getting the location and file name of the excel to save from user.
            //    SaveFileDialog saveDialog = new SaveFileDialog();
            //    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //    saveDialog.FilterIndex = 2;

            //    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        workbook.SaveAs(saveDialog.FileName);
            //        MessageBox.Show("Export Successful");
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    excel.Quit();
            //    workbook = null;
            //    excel = null;
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }
    }
}
