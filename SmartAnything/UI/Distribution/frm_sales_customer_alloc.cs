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

namespace SmartAnything.UI
{
    public partial class frm_sales_customer_alloc : Form
    {

        int formMode = 0;
        string formID = "A0022";
        string formHeadertext = "Salesman Customer Allocation";
        DataTable dtx = new DataTable();
        DataTable dtxCN = new DataTable();
        bool already = false;
        M_Products gloproduct = new M_Products();
        bool qtyexceed = false;
        string selectedsalesman = "";
        string selectedcustomer = "";
        DataGridViewRow dcomming = new DataGridViewRow();
        
        #region Loading one instance

        private static frm_sales_customer_alloc objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_sales_customer_alloc getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_sales_customer_alloc();

            }
            return objSingleObject;

        }

        #endregion

        public frm_sales_customer_alloc()
        {
            InitializeComponent();
        }

        private void frm_sales_customer_alloc_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
                commonFunctions.FormatDataGrid(dgsalesman);
                commonFunctions.FormatDataGrid(dgsaved);
                commonFunctions.FormatDataGrid(dgcustomer);
                txt_salesman.Text = commonFunctions.Loginuser.ToUpper();
                txt_date.Text = DateTime.Now.ToShortDateString();
                LoadDataCus();
                LoadALLOCATIONS();
                LoadDataSavedALLOCATIONS();
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }


        private void LoadALLOCATIONS()
        {
            try
            {
               //string str2 = "SELECT     dbo.T_SalesAllocHead.Docno AS DocNo, dbo.T_SalesAllocHead.Salesman, dbo.T_SalesAllocHead.Item + '  -  ' + dbo.M_Products.Namex AS Item,dbo.T_SalesAllocHead.AllocQTY AS QTY, dbo.T_SalesAllocHead.DateFrom, dbo.T_SalesAllocHead.Dateto FROM         dbo.T_SalesAllocHead INNER JOIN dbo.M_Products ON dbo.T_SalesAllocHead.Item = dbo.M_Products.IDX";
                string str2 = GetSQL(dte_from.Value, dte_to.Value, 2);
                dgsalesman.DataSource = commonFunctions.GetDatatable(str2);
                dgsalesman.Columns[0].Width = 80;
                //dgsalesman.Columns[0].Visible = false;
                dgsalesman.Columns[1].Width = 80;
                dgsalesman.Columns[2].Width = 200;
                dgsalesman.Refresh();
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void LoadDataCus() {
            try
            {

                string str1 = "SELECT cusid AS 'Code' , CustName AS 'Name' ,'' AS 'Breakdown QTy'FROM dbo.M_Customers WHERE SalesMan = '"+ commonFunctions.Loginuser.Trim()  +"'";
                dgcustomer.DataSource = commonFunctions.GetDatatable(str1);
                dgcustomer.Columns[0].Width = 80;
                dgcustomer.Columns[1].Width = 205;
                dgcustomer.Columns[2].Width = 160;
                dgcustomer.Columns[0].ReadOnly = true;
                dgcustomer.Columns[1].ReadOnly = true;
                dgcustomer.Refresh();


                
            }
            catch (Exception ex) {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }


        private void LoadDataSavedALLOCATIONS()
        {
            try
            {


                string str2 = "SELECT     dbo.T_SalesAllocDet.Docno, dbo.T_SalesAllocDet.SalesMan, dbo.T_SalesAllocDet.Customer AS 'Customer Code', dbo.M_Customers.CustName AS 'Customer Name', dbo.T_SalesAllocDet.Item AS 'Item Code',dbo.T_SalesAllocDet.AllowedQTY, dbo.T_SalesAllocDet.AllocQTY FROM dbo.T_SalesAllocDet INNER JOIN dbo.M_Customers ON dbo.T_SalesAllocDet.Customer = dbo.M_Customers.CusID WHERE   dbo.T_SalesAllocDet.SalesMan = '" + commonFunctions.Loginuser.Trim() + "' ";
                dgsaved.DataSource = commonFunctions.GetDatatable(str2);
                dgsaved.Columns[0].Width = 80;
                dgsaved.Columns[1].Width = 100;
                dgsaved.Columns[2].Width = 120;
                dgsaved.Columns[3].Width = 260;
                dgsaved.Columns[4].Width = 120;
                dgsaved.Refresh();



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

     
     

     

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //try
            //{
            //    DataGridViewRow row = new DataGridViewRow();
            //    row = dataGridView1.Rows[e.RowIndex -1];

            //    MessageBox.Show("rows removed" + row.Cells[0].Value.ToString() + "- " + row.Cells[1].Value.ToString() + "- " + row.Cells[2].Value.ToString());
            //}
            //catch (Exception ex) { 
            
            //}
        }
        string selecteddoc = "";
        private void dgsalesman_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgsalesman.SelectedRows.Count > 0)
            {
                try
                {
                    txt_fullqty.Text = dgsalesman.SelectedRows[0].Cells[3].Value.ToString().Trim();
                    selecteddoc = dgsalesman.SelectedRows[0].Cells[0].Value.ToString().Trim(); ;
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_New, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {
                        LoadDataCus();
                    }
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (0 < commonFunctions.ToDecimal(txt_qtyremain.Text.Trim()))
            {
                errorProvider1.SetError(txt_fullqty, "You must allocate full amount for the selected customer.");
                commonFunctions.SetMDIStatusMessage("You must allocate full amount for the selected customer.", 1);
                return;
            }



            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    T_SalesAllocHead alloc = new T_SalesAllocHead();
                    alloc.Docno = selecteddoc;
                    alloc = new T_SalesAllocHeadDL().Selectt_SalesAllocHead(alloc);
                    decimal cumilative = decimal.Zero;

                    foreach (DataGridViewRow drow in dgcustomer.Rows)
                    {
                        cumilative = commonFunctions.ToDecimal(drow.Cells[2].Value.ToString());

                        T_SalesAllocDet objt_SalesAllocDet = new T_SalesAllocDet();
                        objt_SalesAllocDet.Docno = selecteddoc;
                        objt_SalesAllocDet.SalesMan = alloc.Salesman;
                        objt_SalesAllocDet.Customer = drow.Cells[0].Value.ToString();
                        objt_SalesAllocDet.Item = alloc.Item;
                        objt_SalesAllocDet.AllowedQTY = alloc.AllocQTY;
                        objt_SalesAllocDet.AllocQTY = commonFunctions.ToDecimal(cumilative.ToString());
                        objt_SalesAllocDet.DateFrom = alloc.DateFrom.Value;
                        objt_SalesAllocDet.Dateto = alloc.Dateto.Value;
                        objt_SalesAllocDet.Userx = commonFunctions.Loginuser;
                        objt_SalesAllocDet.Datex = DateTime.Now;
                        T_SalesAllocDetDL bal = new T_SalesAllocDetDL();
                        bal.Savet_SalesAllocDetSP(objt_SalesAllocDet, 1);
                    }
                    LoadDataSavedALLOCATIONS();
                }
                catch (Exception ex) { }

            }



        }

        private string GetSQL(DateTime datefrom, DateTime dateto, int option)
        {
            string str2 = "SELECT     dbo.T_SalesAllocHead.Docno AS DocNo, dbo.T_SalesAllocHead.Salesman, dbo.T_SalesAllocHead.Item + '  -  ' + dbo.M_Products.Namex AS Item,dbo.T_SalesAllocHead.AllocQTY AS QTY, dbo.T_SalesAllocHead.DateFrom, dbo.T_SalesAllocHead.Dateto FROM         dbo.T_SalesAllocHead INNER JOIN dbo.M_Products ON dbo.T_SalesAllocHead.Item = dbo.M_Products.IDX" + 
                          " WHERE dbo.T_SalesAllocHead.Salesman = '" +commonFunctions.Loginuser.Trim() + "' AND ";
                  str2 += " (GETDATE() BETWEEN CONVERT(DATETIME,dbo.T_SalesAllocHead.DateFrom, 103) AND CONVERT(DATETIME,dbo.T_SalesAllocHead.Dateto, 103))";
         
            return str2;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadALLOCATIONS();
        }

        private void updateGrid()
        {
            if (txt_fullqty.Text.Trim() == "")
            {
                errorProvider1.SetError(txt_fullqty, "Please select a allocation record first.");
                commonFunctions.SetMDIStatusMessage("Please select a allocation record first.", 1);
            }

            decimal total = commonFunctions.ToDecimal(txt_fullqty.Text);
            decimal cumilative = decimal.Zero;

            foreach (DataGridViewRow drow in dgcustomer.Rows)
            {
                cumilative += commonFunctions.ToDecimal(drow.Cells[2].Value.ToString());
            }

            txt_qtyremain.Text = (total - cumilative).ToString();

        
        }

        private void dgcustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateGrid();
        }

     
        private void dgsaved_RowsRemoved_1(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                T_SalesAllocDet det = new T_SalesAllocDet();
                det.Docno = dcomming.Cells[0].Value.ToString();
                det.SalesMan = dcomming.Cells[1].Value.ToString();
                det.Customer = dcomming.Cells[2].Value.ToString();
                det = new T_SalesAllocDetDL().Selectt_SalesAllocDet(det);
                ////new T_SalesAllocDetDL().Savet_SalesAllocDetSP(det, 4);
                ////LoadDataSavedALLOCATIONS();

                //if ((dgsaved.SelectedRows.Count == 0) || ((dgsaved.SelectedRows.Count == 1) && (dgsaved.SelectedRows[0].IsNewRow)))
                //{

                //    MessageBox.Show("Set of rows deleted" + dgsaved.SelectedRows[0].Cells[2].Value.ToString());
                //}

            }
            catch (Exception ex) { }
        }

        private void dgsaved_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dcomming = dgsaved.Rows[e.RowIndex];
                string str = dcomming.Cells[2].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {
                    string x = dgsaved.SelectedRows[0].Cells[0].Value.ToString();
                    T_SalesAllocDet det = new T_SalesAllocDet();
                    det.Docno = x.ToString();
                    List<T_SalesAllocDet> dets = new List<T_SalesAllocDet>();
                    dets = new T_SalesAllocDetDL().SelectT_SalesAllocDetMulti(det);
                    foreach (T_SalesAllocDet de in dets)
                    {
                        new T_SalesAllocDetDL().Savet_SalesAllocDetSP(de, 4);
                    }
                    LoadDataSavedALLOCATIONS();
                    UserDefineMessages.ShowMsg1("All allocation breakdown Detleted for header allocation NO: " + x, UserDefineMessages.Msg_Information);
                    
                }
            }
            catch (Exception ex) { }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

        }


    }
}
