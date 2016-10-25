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
    public partial class frm_sales_itemalloc : Form
    {


        int formMode = 0;
        string formID = "A0023";
        string formHeadertext = "Allocate items to Salesman";
        DataTable dtx = new DataTable();
        DataTable dtxCN = new DataTable();
        bool already = false;
        M_Products gloproduct = new M_Products();
        bool qtyexceed = false;
        string selectedsalesman = "";

        public frm_sales_itemalloc()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_sales_itemalloc objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_sales_itemalloc getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_sales_itemalloc();

            }
            return objSingleObject;

        }

        #endregion

        private void frm_sales_itemalloc_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
                commonFunctions.FormatDataGrid(dgitems);
                commonFunctions.FormatDataGrid(dgsaved);
                commonFunctions.FormatDataGrid(dgsalesman);
                LoadSalesmans();
                LoadData("",3);
                dte_dateto.Value = dte_datefrom.Value.AddDays(30);
                if (dgsalesman.SelectedRows.Count > 0)
                {
                    DataGridViewRow drow = new DataGridViewRow();
                    drow = dgsalesman.SelectedRows[0];
                    if (drow.Cells[0].Value.ToString().Trim() != "")
                    {
                        selectedsalesman = drow.Cells[0].Value.ToString();
                        GetAllocations(selectedsalesman);
                    }
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void LoadSalesmans()
        {
            try
            {
                string str1 = "select userId as 'Code',userName as 'Name' from u_User where Type = 'SAL'";
                dgsalesman.DataSource = commonFunctions.GetDatatable(str1);
                dgsalesman.Columns[0].Width = 80;
                dgsalesman.Columns[1].Width = 160;
                dgsalesman.Columns[0].ReadOnly = true;
                dgsalesman.Columns[1].ReadOnly = true;
                dgsalesman.Refresh();
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void LoadData(string code,int options)
        {
            try
            {
                string str = "";
                if (options == 1)
                {
                    str = " select IDX as 'Itemcode', Namex as 'ItemName', '0' as 'Qty' from M_Products WHERE IDX LIKE '%" + code.Trim() + "%' ";
                }
                else if (options == 2)
                {
                    str = " select IDX as 'Itemcode', Namex as 'ItemName', '0' as 'Qty' from M_Products WHERE Namex LIKE '%" + code.Trim() + "%' ";
                }
                else {
                    str = " select IDX as 'Itemcode', Namex as 'ItemName', '0' as 'Qty' from M_Products";
                }
                

                dtx = commonFunctions.GetDatatable(str);
                dgitems.DataSource = dtx;
                dgitems.Columns[0].Width = 80;
                dgitems.Columns[1].Width = 170;
                dgitems.Columns[2].Width = 80;

                dgitems.Columns[0].ReadOnly = true;
                dgitems.Columns[1].ReadOnly = true;

                dgitems.Refresh();

            
           
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }


        private void GetAllocations(string salesman) {
            try
            {
                if (rdo_showall.Checked)
                {
                    dgsaved.DataSource = commonFunctions.GetDatatable(GetSQL(DateTime.Now, DateTime.Now, 1, salesman));
                }
                else {
                    dgsaved.DataSource = commonFunctions.GetDatatable(GetSQL(dte_datefrom.Value, dte_dateto.Value, 2, salesman));
                }
                
                dgsaved.Columns[0].Width = 80;
                dgsaved.Columns[1].Visible = false;
                dgsaved.Columns[2].Width = 240;
                dgsaved.Refresh();
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
       }

        private string GetSQL(DateTime datefrom, DateTime dateto, int option,string salesman)
        {
            string str2 = "SELECT     dbo.T_SalesAllocHead.Docno AS DocNo, dbo.T_SalesAllocHead.Salesman, dbo.T_SalesAllocHead.Item + '  -  ' + dbo.M_Products.Namex AS Item,dbo.T_SalesAllocHead.AllocQTY AS QTY, CONVERT(date,dbo.T_SalesAllocHead.DateFrom) as DateFrom, CONVERT(date,dbo.T_SalesAllocHead.Dateto) as DateTo " +
                          " FROM         dbo.T_SalesAllocHead INNER JOIN dbo.M_Products ON dbo.T_SalesAllocHead.Item = dbo.M_Products.IDX " +
                          "WHERE dbo.T_SalesAllocHead.Salesman = '" + salesman.Trim() + "' AND ";
            if (option == 1)
            {
                str2 += "(dbo.T_SalesAllocHead.Dateto BETWEEN CONVERT(DATETIME,'" + DateTime.Now.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + DateTime.Now.AddYears(20).ToShortDateString() + "', 103))";
            }
            else if (option == 2)
            {
                str2 += "(dbo.T_SalesAllocHead.Dateto BETWEEN CONVERT(DATETIME,'" + datefrom.ToShortDateString() + "', 103) AND CONVERT(DATETIME, '" + dateto.ToShortDateString() + "', 103))";
            }


            return str2;
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_addrange_Click(object sender, EventArgs e)
        {
            string salesman = "";
            if (dgsalesman.SelectedRows.Count > 0)
            {
                if (dgsalesman.SelectedRows[0].Cells[0].Value.ToString() != "")
                {
                    salesman = dgsalesman.SelectedRows[0].Cells[0].Value.ToString();
                }
            }
            else {
                commonFunctions.SetMDIStatusMessage("Please select a salesman", 1);
                return;
            }

            //if (dgitem.SelectedRows.Count > 0)
            //{
            //    if (dgsalesman.SelectedRows[0].Cells[0].Value.ToString() != "")
            //    {
            //        salesman = dgsalesman.SelectedRows[0].Cells[0].Value.ToString();
            //    }
            //}
            //else
            //{
            //    commonFunctions.SetMDIStatusMessage("Please select a salesman", 1);
            //    return;
            //}

            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {


                foreach (DataGridViewRow drow in dgitems.Rows)
                {
                    if (drow.Cells[0].Value.ToString().Trim() != null)
                    {

                        if (commonFunctions.ToDecimal(drow.Cells[2].Value.ToString().Trim()) <= 0) {
                            continue;
                        }

                        T_SalesAllocHead objt_SalesAllocHead = new T_SalesAllocHead();
                        objt_SalesAllocHead.Docno = commonFunctions.GetSerial("A0062");
                        objt_SalesAllocHead.Salesman = salesman.Trim();
                        objt_SalesAllocHead.Item = drow.Cells[0].Value.ToString().Trim();
                        objt_SalesAllocHead.AllocQTY = commonFunctions.ToDecimal(drow.Cells[2].Value.ToString().Trim());
                        objt_SalesAllocHead.DateFrom = dte_datefrom.Value;
                        objt_SalesAllocHead.Dateto = dte_dateto.Value;
                        objt_SalesAllocHead.Userx = commonFunctions.Loginuser;
                        objt_SalesAllocHead.Datex = DateTime.Now;
                        new T_SalesAllocHeadDL().Savet_SalesAllocHeadSP(objt_SalesAllocHead, 1);
                        commonFunctions.IncrementSerial("A0062");

                    }
                }


            
                GetAllocations(selectedsalesman);
                LoadData("",3);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            GetAllocations(selectedsalesman);
        }

        private void dgsalesman_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgsalesman.SelectedRows.Count > 0) {
                DataGridViewRow drow = new DataGridViewRow();
                drow = dgsalesman.SelectedRows[0];
                if (drow.Cells[0].Value.ToString().Trim() != "") {
                    selectedsalesman = drow.Cells[0].Value.ToString();
                    GetAllocations(selectedsalesman);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdo_itemcode.Checked) {
                LoadData(txt_itemsearch.Text, 1);
            }

            if (rdo_itemname.Checked)
            {
                LoadData(txt_itemsearch.Text, 2);
            }

        }

        private void dte_datefrom_ValueChanged(object sender, EventArgs e)
        {
            dte_dateto.Value = dte_datefrom.Value.AddDays(30);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {

                    if (dgsaved.SelectedRows.Count > 0)
                    {
                        bool exists = false;
                        List<string> itemsx = new List<string>();
                        foreach (DataGridViewRow rowx in dgsaved.SelectedRows) {
                            string x = rowx.Cells[0].Value.ToString();
                            T_SalesAllocDet det = new T_SalesAllocDet();
                            det.Docno = x.ToString();
                            List<T_SalesAllocDet> dets = new List<T_SalesAllocDet>();
                            dets = new T_SalesAllocDetDL().SelectT_SalesAllocDetMulti(det);
                            if (dets.Count > 0)
                            {
                                itemsx.Add(x);
                                exists = true;
                            }
                            else
                            {
                                T_SalesAllocHead head = new T_SalesAllocHead();
                                head.Docno = rowx.Cells[0].Value.ToString();
                                head = new T_SalesAllocHeadDL().Selectt_SalesAllocHead(head);
                                new T_SalesAllocHeadDL().Savet_SalesAllocHeadSP(head, 4);
                            }
                        }
                        GetAllocations(selectedsalesman);
                        if (exists == true)
                        {
                            string numbers = "";
                            foreach (string x in itemsx) {
                                numbers += "\n"  + x ;
                            }

                            UserDefineMessages.ShowMsg1("Selected Allocation headers deleted except these  " + numbers + "  \nbecouse they have breakdowns", UserDefineMessages.Msg_Warning);
                        }
                        else
                        {
                            UserDefineMessages.ShowMsg1("Selected Allocation headers were deleted ", UserDefineMessages.Msg_Information);
                        }
                    }
                    else
                    {

                        string x = dgsaved.SelectedRows[0].Cells[0].Value.ToString();
                        T_SalesAllocDet det = new T_SalesAllocDet();
                        det.Docno = x.ToString();
                        List<T_SalesAllocDet> dets = new List<T_SalesAllocDet>();
                        dets = new T_SalesAllocDetDL().SelectT_SalesAllocDetMulti(det);
                        if (dets.Count > 0)
                        {
                            UserDefineMessages.ShowMsg1("Cannot delete the allocation master: " + x + ". becouse it has breakdowns ", UserDefineMessages.Msg_Warning);
                        }
                        else
                        {
                            T_SalesAllocHead head = new T_SalesAllocHead();
                            head.Docno = dgsaved.SelectedRows[0].Cells[0].Value.ToString();
                            head = new T_SalesAllocHeadDL().Selectt_SalesAllocHead(head);
                            new T_SalesAllocHeadDL().Savet_SalesAllocHeadSP(head, 4);
                            GetAllocations(selectedsalesman);
                            UserDefineMessages.ShowMsg1("Allocation header detleted NO: " + x, UserDefineMessages.Msg_Information);
                        }
                    }
                    

                }
            }
            catch (Exception ex) { }
        }

  

   

      
    }
}
