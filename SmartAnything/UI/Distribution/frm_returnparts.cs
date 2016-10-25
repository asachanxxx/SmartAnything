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
    public partial class frm_returnparts : Form
    {

        int formMode = 0;
        string formID = "A0020";
        string formHeadertext = "Credit Note Grouping";
        DataTable dtx = new DataTable();
        DataTable dtxCN = new DataTable();
        DataTable dtxsave = new DataTable();
        bool already = false;
        M_Products gloproduct = new M_Products();
        bool invoiceProcced = false;
        bool invoiceapproved = false;
        bool qtyexceed = false;
        string selecteddoc = "";
        DataGridViewRow drow;
        DataGridViewRow drowSaved;
        #region Loading one instance

        private static frm_returnparts objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_returnparts getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_returnparts();

            }
            return objSingleObject;

        }

        #endregion

        public frm_returnparts()
        {
            InitializeComponent();
        }

        private void frm_returnparts_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
               
                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                commonFunctions.FormatDataGrid(dataGridView2);
                commonFunctions.FormatDataGrid(dgsave);

                txt_DocNo.Focus();
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        DataTable GetCBBreakdowns(string code) {
            DataTable dt = new DataTable();
            string sql = "SELECT     T_CNGrouping.Docno, T_CNGrouping.TagNumber, T_CNGrouping.ItemCode, T_CNGrouping.Name,T_CNGrouping.BreakdownQTY as 'Qty', T_CNGrouping.CNType, M_CNReason.Reason " + 
                         "FROM       T_CNGrouping INNER JOIN T_CreditNoteHead ON T_CNGrouping.Docno = T_CreditNoteHead.DocNo INNER JOIN M_CNReason ON T_CNGrouping.CNReason = M_CNReason.ID " +
                         "WHERE     (T_CreditNoteHead.Grouped = 1)  AND T_CreditNoteHead.DocNo = '" + code.Trim() + "' AND dbo.T_CNGrouping.CNType != 'RTN' ";
            dt = commonFunctions.GetDatatable(sql);
            return dt;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_DocNo_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                FindExisitingCN(txt_DocNo.Text.Trim());
                //txt_code.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_DocNo.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CNHFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CNHSQLFOrCNGrouped"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CNHField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
        }

        #region FindExisitingCN

        private void FindExisitingCN(string GrnNo)
        {
            if (GrnNo.Trim() != "")
            {
                if (T_CreditNoteHeadDL.ExistingT_CreditNoteHead(GrnNo.Trim()))
                {

                    T_CreditNoteHead cat = new T_CreditNoteHead();
                    cat.DocNo = GrnNo.Trim();
                    cat = new T_CreditNoteHeadDL().Selectt_CreditNoteHead(cat);

                    if (cat.Grouped == true)
                    {
                        lbl_processes.Text = "Grouped".ToUpper();
                        lbl_processes.Visible = true;
                        //errorProvider1.SetError(txt_DocNo, "Credit Note is already grouped.");
                       // commonFunctions.SetMDIStatusMessage("Credit Note is already grouped.", 1);
                       // return;
                    }
                    dtxCN.Clear();
                    dataGridView2.Refresh();
                    //clear error fields
                    errorProvider1.Clear();
                    //load and disable the data fields
                    txt_LocaCode.Text = cat.LocaCode.Trim();
                    txt_Customer.Text = cat.CustomerID.Trim();
                    txt_ManualID.Text = cat.ManualID.Trim();

                    dtxCN = GetCBBreakdowns(GrnNo);
                    dataGridView2.DataSource = dtxCN;
                    commonFunctions.FormatDataGrid(dataGridView2);
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[1].Width = 90;
                    dataGridView2.Columns[2].Width = 100;
                    dataGridView2.Columns[4].Width = 90;
                    dataGridView2.Columns[5].Width = 50;
                    dataGridView2.Columns[6].Width = 200;

                    LoadPartSaved(GrnNo);

                }
                else
                {
                    //if (formMode != 1)
                    //{
                    lbl_processes.Text = "Invalied".ToUpper();
                    lbl_processes.Visible = true;
                    errorProvider1.SetError(txt_DocNo, "Invalied Credit Note Number.");
                    commonFunctions.SetMDIStatusMessage("Invalied Credit Note Number.", 1);
                    //}
                }
            }
            else
            {
                lbl_processes.Text = "".ToUpper();
                lbl_processes.Visible = true;
                commonFunctions.SetMDIStatusMessage("Please Enter Credit Note Number.", 2);
            }


        }

        #endregion

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_New, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        LoadDataCus(e.ColumnIndex,e.RowIndex);
                    }
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
                }
            }
        }

        private void LoadPartSaved(string cncode)
        {
            try
            {

                string str1 = "SELECT     dbo.T_CNParts.CNno AS [CN Number], dbo.T_CNParts.TagNumber AS [Tag Number], dbo.T_CNParts.ItemCode AS [Item Code], dbo.M_Products.Namex AS ProductName, dbo.T_CNParts.PartCode AS [Part Code], dbo.M_ProductParts.PartName AS [Part Name], dbo.T_CNParts.QTY  " +
                             "FROM dbo.T_CNParts INNER JOIN dbo.M_ProductParts ON dbo.T_CNParts.PartCode = dbo.M_ProductParts.IDX INNER JOIN dbo.M_Products ON SUBSTRING(dbo.T_CNParts.ItemCode ,0,CHARINDEX('-' ,dbo.T_CNParts.ItemCode )) = dbo.M_Products.IDX " +
                             "WHERE dbo.T_CNParts.CNno = '" + cncode.Trim() + "'";
 
                dtxsave = commonFunctions.GetDatatable(str1);
                dgsave.DataSource = dtxsave;

                dgsave.Columns[1].Width = 120;
                dgsave.Columns[3].Width = 200;
                dgsave.Columns[5].Width = 150;

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void LoadDataCus(int colum,int row)
        {
            try
            {
                drow = dataGridView2.SelectedRows[0];


                string str1 = "SELECT     dbo.M_Product_Has_Parts.PartId, dbo.M_ProductParts.PartName , '0' AS Qty FROM dbo.M_Product_Has_Parts INNER JOIN dbo.M_ProductParts ON dbo.M_Product_Has_Parts.PartId = dbo.M_ProductParts.IDX  " +
                              "WHERE M_Product_Has_Parts.productId =   SUBSTRING('" + drow.Cells[2].Value.ToString() + "',0,CHARINDEX('-' ,'" + drow.Cells[2].Value.ToString() + "')) ";
                dtxCN= commonFunctions.GetDatatable(str1);
                dataGridView1.DataSource = dtxCN;

                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 205;
                dataGridView1.Columns[2].Width = 160;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Refresh();



            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Add, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    T_CreditNoteHead alloc = new T_CreditNoteHead();
                    alloc.Dono = txt_DocNo.Text.Trim();
                    alloc = new T_CreditNoteHeadDL().Selectt_CreditNoteHead(alloc);
                    decimal cumilative = decimal.Zero;

                    foreach (DataGridViewRow drowx in dataGridView1.Rows)
                    {
                        if (commonFunctions.ToDecimal(drowx.Cells[2].Value.ToString().Trim()) != decimal.Zero)
                        {
                            if (!T_CNPartDL.ExistingT_CNPart(txt_DocNo.Text.Trim(),drow.Cells[1].Value.ToString().Trim(), drow.Cells[2].Value.ToString().Trim(), drowx.Cells[0].Value.ToString().Trim()))
                            {
                                T_CNParts part = new T_CNParts();
                                part.CNno = txt_DocNo.Text.Trim();
                                part.ItemCode = drow.Cells[2].Value.ToString().Trim();
                                part.PartCode = drowx.Cells[0].Value.ToString().Trim();
                                part.Processed = false;
                                part.ProcessedDate = DateTime.Now;
                                part.ProcessedUser = commonFunctions.Loginuser;
                                part.QTY = commonFunctions.ToDecimal(drowx.Cells[2].Value.ToString().Trim());
                                part.Saved = false;
                                part.TagNumber = drow.Cells[1].Value.ToString().Trim();
                                new T_CNPartDL().Savet_CNPartSP(part, 1);
                            }
                        }
                    }

                    LoadPartSaved(txt_DocNo.Text.Trim());
                }
                catch (System.Data.SqlClient.SqlException ex) {
                    commonFunctions.SetMDIStatusMessage("Data Already exists for selected record", 1);
                }
                catch (Exception ex)
                {
                    commonFunctions.SetMDIStatusMessage("Error when adding", 1);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    T_CreditNoteHead alloc = new T_CreditNoteHead();
                    alloc.Dono = txt_DocNo.Text.Trim();
                    alloc = new T_CreditNoteHeadDL().Selectt_CreditNoteHead(alloc);
                    decimal cumilative = decimal.Zero;

                    foreach (DataGridViewRow drowx in dgsave.Rows)
                    {
                        T_CNParts part = new T_CNParts();
                        part.CNno = drowx.Cells[0].Value.ToString().Trim();
                        part.ItemCode = drowx.Cells[2].Value.ToString().Trim();
                        part.PartCode = drowx.Cells[4].Value.ToString().Trim();
                        part.TagNumber = drowx.Cells[1].Value.ToString().Trim();

                        part = new T_CNPartDL().Selectt_CNPart(part);
                        part.Processed = true;
                        new T_CNPartDL().Savet_CNPartSP(part, 3);
                      
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {

        }

        private void dgsave_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgsave.SelectedRows.Count > 0)
            {
                try{

                    drowSaved = dgsave.SelectedRows[0];
                //{
                //    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_New, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                //    {

                //        LoadDataCus(e.ColumnIndex, e.RowIndex);
                //    }
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Del, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                if (drowSaved != null)
                {
                    if (drowSaved.Cells[0] != null)
                    {
                        T_CNParts ss = new T_CNParts();
                        ss.CNno = drowSaved.Cells[0].Value.ToString();
                        ss.ItemCode = drowSaved.Cells[2].Value.ToString();
                        ss.PartCode = drowSaved.Cells[4].Value.ToString();
                        ss.TagNumber = drowSaved.Cells[1].Value.ToString();
                        ss = new T_CNPartDL().Selectt_CNPart(ss);

                        if (!ss.Processed.Value)
                        {
                            //MessageBox.Show(drowSaved.Cells[2].Value.ToString());
                            T_CNPartDL.Delete_CNPart(drowSaved.Cells[0].Value.ToString(), drowSaved.Cells[2].Value.ToString(), drowSaved.Cells[4].Value.ToString(), drowSaved.Cells[1].Value.ToString());
                            LoadPartSaved(txt_DocNo.Text.Trim());
                        }
                        else
                        {
                            commonFunctions.SetMDIStatusMessage("Item already processed. cannot delete now", 1);
                        }
                    }
                }
            }
        }




    }
}
