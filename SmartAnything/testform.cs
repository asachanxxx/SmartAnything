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

namespace SmartAnything
{
    public partial class testform : Form
    {

        DataTable dtx = new DataTable();
        bool already = false;

        public testform()
        {
            InitializeComponent();
        }

        private void testform_Load(object sender, EventArgs e)
        {
            //GetData();
            //filldata();
            //dtx = commonFunctions.CreateDatatable(1);
            //dataGridView1.DataSource = dtx;
            //commonFunctions.FormatDataGrid(dataGridView1);
            //dataGridView1.Columns[0].Width = 120;
            //dataGridView1.Columns[1].Width = 280;
            //txt_code.Focus();
        }


        #region GetData

        private void GetData()
        {
            try
            {

                T_StockDL bdl = new T_StockDL();
                dataGridView1.DataSource = bdl.SelectAllt_Stock(2,commonFunctions.GlobalCompany,commonFunctions.GlobalLocation);

                if (dataGridView1.DataSource != null)
                {

                    dataGridView1.Columns[0].Width = 120;
                    dataGridView1.Columns[1].Width = 585;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void filldata() {
            T_StockDL bdl = new T_StockDL();
            DataTable dt = bdl.SelectAllt_Stock(2, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation);

            foreach (DataRow drow in dt.Rows) {
                txt_code.AutoCompleteCustomSource.Add(drow["ProductId"].ToString());
                listBox1.Items.Add(drow["ProductId"].ToString());
            }
            
        }
        #endregion

  
        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (T_StockDL.ExistingT_Stock(txt_code.Text.Trim(), commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                {
                    if (!commonFunctions.IsExist(dataGridView1, txt_code.Text.Trim()))
                    {
                        T_Stock stk = new T_Stock();
                        stk.Locacode = commonFunctions.GlobalLocation;
                        stk.Compcode = commonFunctions.GlobalCompany;
                        stk.ProductId = txt_code.Text.Trim();
                        T_StockDL bal = new T_StockDL();
                        stk = bal.Selectt_Stock(stk);

                        txt_cost.Text = stk.CostPrice.ToString();
                        txt_selling.Text = stk.SellingPrice.ToString();
                        lbl_name.Text = stk.Descr;

                        txt_qty.Text = "0";
                        txt_qty.Focus();

                        errorProvider1.Clear();
                        already = false;
                    }
                    else
                    {
                        already = true;
                        //errorProvider1.SetError(txt_code, "Already exists");
                        T_Stock stk = new T_Stock();
                        stk.Locacode = commonFunctions.GlobalLocation;
                        stk.Compcode = commonFunctions.GlobalCompany;
                        stk.ProductId = txt_code.Text.Trim();
                        T_StockDL bal = new T_StockDL();
                        stk = bal.Selectt_Stock(stk);

                        txt_cost.Text = stk.CostPrice.ToString();
                        txt_selling.Text = stk.SellingPrice.ToString();
                        lbl_name.Text = stk.Descr;

                        DataGridViewRow drowx = new DataGridViewRow();
                        drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                        txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();

                        txt_qty.Focus();


                    }
                }
                else {
                    errorProvider1.SetError(txt_code, "Product you have entered not exist in the bin card");
                }
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_selling.Text.Trim() != "")
                {
                    if (txt_qty.Text.Trim() != "")
                    {
                        if ((commonFunctions.ToDecimal(txt_qty.Text.Trim()) != decimal.Zero))
                        {

                            if (already == false)
                            {
                                decimal amount = commonFunctions.ToDecimal(txt_selling.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                txt_amt.Text = amount.ToString();
                                commonFunctions.AddRow(dtx, txt_code.Text.Trim(), lbl_name.Text.Trim(), txt_cost.Text.Trim(), txt_selling.Text.Trim(), txt_qty.Text.Trim(), txt_amt.Text.Trim());
                                txt_total.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_pices.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                txt_items.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                txt_code.Focus();
                            }
                            else
                            {
                                decimal amount = commonFunctions.ToDecimal(txt_selling.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                txt_amt.Text = amount.ToString();
                                commonFunctions.AddRowtogrid(dataGridView1, txt_code.Text.Trim(), txt_qty.Text.Trim(), amount.ToString());
                                txt_total.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_pices.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
                                txt_items.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();
                                txt_code.Focus();
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_qty, "Please enter quntity");
                        }

                    }

                }
                else
                {
                    txt_amt.Text = "0.00";
                    
                }
            }
        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            errorProvider1.Clear();
        }

        private void txt_amt_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


      

      


        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txt_total.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
            txt_pices.Text = commonFunctions.GetNoofPices(dataGridView1).ToString();
            txt_items.Text = commonFunctions.GetNoofItems(dataGridView1).ToString();

        }

        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_selling_KeyDown(object sender, KeyEventArgs e)
        {
           
            MessageBox.Show("KeyDown");
            

        }

        private void txt_selling_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("KeyPress");
        }

        private void txt_selling_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show("KeyUp");
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "150.00";
            decimal decGrossAmount = 0;
            if (decimal.TryParse(str, out decGrossAmount) == true)
            {
                decGrossAmount = commonFunctions.ToDecimal(str);
            }
            decGrossAmount = decimal.Round(decGrossAmount, 0);
            int x = int.Parse(decGrossAmount.ToString());
            MessageBox.Show(decGrossAmount.ToString());
        }
    }
}
