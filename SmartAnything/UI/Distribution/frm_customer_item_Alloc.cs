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


namespace SmartAnything.UI.Distribution
{
    public partial class frm_customer_item_Alloc : Form
    {

        int formMode = 0;
        string formID = "A0022";
        string formHeadertext = "Sales Customer Allocation";
        DataTable dtx = new DataTable();
        DataTable dtxCN = new DataTable();
        bool already = false;
        M_Products gloproduct = new M_Products();
        bool qtyexceed = false;

        public frm_customer_item_Alloc()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_customer_item_Alloc objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_customer_item_Alloc getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_customer_item_Alloc();

            }
            return objSingleObject;

        }

        #endregion
        private void frm_customer_item_Alloc_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
                commonFunctions.FormatDataGrid(dataGridView1);
                LoadData();

            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void LoadData()
        {
            try
            {
                string str = " SELECT     dbo.T_CustomerItemAlloc.Customer, dbo.M_Customers.CustName, dbo.T_CustomerItemAlloc.Item, dbo.M_Products.Namex AS Description, dbo.T_CustomerItemAlloc.AllocQTY AS Qauntity, dbo.T_CustomerItemAlloc.DateFrom, dbo.T_CustomerItemAlloc.Dateto " +
                             " FROM         dbo.M_Customers INNER JOIN dbo.T_CustomerItemAlloc ON dbo.M_Customers.CusID = dbo.T_CustomerItemAlloc.Customer INNER JOIN dbo.M_Products ON dbo.T_CustomerItemAlloc.Item = dbo.M_Products.IDX ";

                dtx = commonFunctions.GetDatatable(str);
                dataGridView1.DataSource = dtx;
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].Width = 150;
                //dataGridView1.Columns[4].Width = 80;
                //dataGridView1.Columns[6].Width = 80;
                //dataGridView1.Columns[6].DefaultCellStyle.ForeColor = Color.Green;
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_code.Focus();
                lbl_customer.Text = findExisting.FindExisitingCUstomer(txt_customer.Text);
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_customer.Name.Trim())
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
            }
        }

        private void txt_customer_TextChanged(object sender, EventArgs e)
        {
            lbl_customer.Text = findExisting.FindExisitingCUstomer(txt_customer.Text);
        }

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_code.Name.Trim())
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
                errorProvider1.Clear();
            }

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //txt_code.Text = commonFunctions.GetProcutCode(txt_code.Text.Trim());
                    if (T_StockDL.ExistingT_Stock_Product(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {
                        if (!commonFunctions.IsExistINV(dataGridView1, txt_code.Text))
                        {
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk = new M_ProductDL().Selectm_Product(stk);
                            txt_qty.Text = "0";
                            txt_qty.Focus();

                            errorProvider1.Clear();
                            already = false;
                        }
                        else
                        {
                            already = true;
                            //errorProvider1.SetError(txt_code, "Already exists");
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk = new M_ProductDL().Selectm_Product(stk);
                            DataGridViewRow drowx = new DataGridViewRow();
                            drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                            txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();

                            txt_qty.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txt_code, "Product you have entered not exist in the product master file");
                        commonFunctions.SetMDIStatusMessage("Product you have entered not exist in the product master file", 1);
                    }
                }
                catch (Exception ex)
                {

                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error", 2);
                }

            }

        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt_code.Text.Trim() != "")
                    {
                        if (txt_qty.Text.Trim() != "")
                        {
                            try
                            {
                                T_CustomerItemAlloc all = new T_CustomerItemAlloc();
                                all.Customer = txt_customer.Text.Trim();
                                all.Item = txt_code.Text.Trim();
                                all.DateFrom = dte_datefrom.Value;
                                all.Dateto = dte_dateto.Value;
                                all.Datex = DateTime.Now;
                                all.Userx = commonFunctions.Loginuser;
                                all.AllocQTY = commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                new T_CustomerItemAllocDL().Savet_CustomerItemAllocSP(all, 1);
                                LoadData();

                            }
                            catch (Exception ex)
                            {
                                errorProvider1.SetError(txt_customer, "Allocation details already exists...");
                                errorProvider1.SetError(txt_code, "Allocation details already exists...");
                                commonFunctions.SetMDIStatusMessage("Allocation details already exists...", 1);
                            }


                        }

                    }
                    else
                    {
                        errorProvider1.SetError(txt_qty, "Please enter item code");
                        commonFunctions.SetMDIStatusMessage("Please enter item code", 1);
                    }


                    txt_code.Focus();

                }


            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

    }
}
