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
    public partial class frm_creditnoteApproval : Form
    {

        int formMode = 0;
        string formID = "A0036";
        string formHeadertext = "CreditNote Approval";
        DataTable dtx = new DataTable();
        bool already = false;
        string codex = "";


        #region Loading one instance

        private static frm_creditnoteApproval objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_creditnoteApproval getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_creditnoteApproval();

            }
            return objSingleObject;

        }

        #endregion

        public frm_creditnoteApproval()
        {
            InitializeComponent();
        }

        private void frm_creditnoteApproval_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
            //dtx = commonFunctions.CreateDatatableCNGroup();
            getProcessedInvoices();

            dtx = commonFunctions.CreateDatatableCNGroup();
            commonFunctions.FormatDataGrid(dataGridView1);
            commonFunctions.FormatDataGrid(dataGridView2);

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 150;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }
        private DataTable getProcessedInvoices()
        {

            DataTable dt = new DataTable();
            dataGridView1.DataSource = commonFunctions.GetDatatable("SELECT     dbo.T_CreditNoteHead.DocNo, dbo.T_CreditNoteHead.CustomerID, dbo.M_Customers.CustName, dbo.T_CreditNoteHead.Processed FROM dbo.T_CreditNoteHead INNER JOIN  dbo.M_Customers ON dbo.T_CreditNoteHead.CustomerID = dbo.M_Customers.CusID WHERE  (dbo.T_CreditNoteHead.Processed = 1 AND Approved = 0)");
            return dt;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                codex = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                T_CreditNoteHead cat = new T_CreditNoteHead();
                cat.DocNo = codex.Trim();
                cat = new T_CreditNoteHeadDL().Selectt_CreditNoteHead(cat); 

                txt_DocNo.Text = cat.DocNo;
                txt_Locacode.Text = cat.LocaCode.Trim();
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text);
                txt_Customer.Text = cat.CustomerID.Trim();
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                txt_Remarks.Text = cat.Remarks;
                txt_manualno.Text = cat.ManualID;
                txt_CNtypes.Text = cat.TypeX.Trim();
                lbl_creditnotetype.Text = findExisting.FindExisitingCNType(txt_CNtypes.Text);
                //dte_date.Value = cat.Datex.Value;
                //dte_RecivedDate.Value = cat.RecivedDate.Value;
                LoadDetails(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void LoadDetails(string code) {

            DataTable dt = new DataTable();
            dataGridView2.DataSource = commonFunctions.GetDatatable("SELECT ItemCode AS 'Item Code' , Namex AS 'Description' ,QTY AS 'Quntity' FROM T_CNBreak WHERE DocNo =  '" + code.Trim() + "'");
            dataGridView2.Columns[0].Width = 110;
            dataGridView2.Columns[1].Width = 300;
            dataGridView2.Refresh();

        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (codex.Trim() != "")
            {

                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Approve, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {

                    T_CreditNoteHead objt_trnsferNote = new T_CreditNoteHead();
                    objt_trnsferNote.DocNo = txt_DocNo.Text.Trim();

                    objt_trnsferNote = new T_CreditNoteHeadDL().Selectt_CreditNoteHead(objt_trnsferNote);

                    objt_trnsferNote.Approved = true;
                    objt_trnsferNote.ApprovedDate = DateTime.Now;
                    objt_trnsferNote.ApprovedUser = commonFunctions.Loginuser;
                    new T_CreditNoteHeadDL().Savet_CreditNoteHeadSP(objt_trnsferNote, 3);

                    //T_OrderTracking track = new T_OrderTracking();
                    //track.OFNo = objt_trnsferNote.OrderFormNo.Trim();
                    //track = new T_OrderTrackingDL().Selectt_OrderTracking(track, xEnums.OrderTrackingTypes.OrderNo);
                    //track.InvApproved = 1;
                    //track.InvApprovedDate = DateTime.Now;
                    //track.InvApprovedUser = commonFunctions.Loginuser;
                    //new T_OrderTrackingDL().Savet_OrderTrackingSP(track, 3);

                    getProcessedInvoices();
                    LoadDetails("");
                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                }
            }
            else
            {
                errorProvider1.SetError(dataGridView1, "Pelase select a order form from the list");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                codex = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                T_CreditNoteHead cat = new T_CreditNoteHead();
                cat.DocNo = codex.Trim();
                cat = new T_CreditNoteHeadDL().Selectt_CreditNoteHead(cat);
                txt_manualno.Text = cat.ManualID;
                txt_DocNo.Text = cat.DocNo;
                txt_Locacode.Text = cat.LocaCode.Trim();
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_Locacode.Text);
                txt_Customer.Text = cat.CustomerID.Trim();
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
                txt_Remarks.Text = cat.Remarks;
                txt_CNtypes.Text = cat.TypeX.Trim();
                lbl_creditnotetype.Text = findExisting.FindExisitingCNType(txt_CNtypes.Text);

                //dte_date.Value = cat.Datex.Value;
                //dte_RecivedDate.Value = cat.RecivedDate.Value;
                LoadDetails(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
