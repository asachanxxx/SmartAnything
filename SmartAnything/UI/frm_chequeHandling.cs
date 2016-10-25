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
using System.Reflection;


namespace SmartAnything.UI
{
    public partial class frm_chequeHandling : Form
    {

        int formMode = 0;
        string formID = "A0034";
        string formHeadertext = "Cheque Handling";
        DataTable dtx = new DataTable();
        bool already = false;
        string codex = "";


        #region Loading one instance

        private static frm_chequeHandling objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_chequeHandling getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_chequeHandling();

            }
            return objSingleObject;

        }

        #endregion


        public frm_chequeHandling()
        {
            InitializeComponent();
        }

        private void frm_chequeHandling_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                //FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

                //getProcessedDOs();
                commonFunctions.FormatDataGrid(dte_cheques);
                //dataGridView1.Columns[0].Width = 110;
                //dataGridView1.Columns[1].Width = 110;
                //dataGridView1.Columns[3].Width = 260;
                //if (dataGridView1.Rows.Count > 0)
                //{
                //    dataGridView1.Rows[0].Selected = true;
                //}
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on loading", 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Invoices_Click(object sender, EventArgs e)
        {
            DataTable dt3 = new DataTable();
            try
            {
                if (txt_Customer.Text.Trim() == "")
                {
                    dt3 = T_RecDetDL.GetCQ("", rdo_post.Checked, rdo_retured.Checked, dte_to.Value, dte_from.Value);
                    dte_cheques.DataSource = dt3;
                    dte_cheques.Columns[0].Width = 100;
                    dte_cheques.Columns[1].Width = 100;
                    dte_cheques.Columns[2].Width = 100;
                    dte_cheques.Columns[3].Width = 190;
                    dte_cheques.Columns[4].Width = 100;
                    dte_cheques.Columns[5].Width = 100;

                    dte_cheques.Columns[0].ReadOnly = true;
                    dte_cheques.Columns[1].ReadOnly = true;
                    dte_cheques.Columns[2].ReadOnly = true;
                    dte_cheques.Columns[3].ReadOnly = true;
                    dte_cheques.Columns[4].ReadOnly = true;
                    dte_cheques.Columns[5].ReadOnly = true;

                    dte_cheques.Refresh();

                }
                else
                {
                    if (findExisting.FindExisitingCUstomer(txt_Customer.Text.Trim()).Trim() == "<Error!!!>".Trim())
                    {
                        errorProvider1.SetError(txt_Customer, "Please enter valied customer id");
                        commonFunctions.SetMDIStatusMessage("Please enter valied customer id", 1);
                        return;
                    }

                    dt3 = T_RecDetDL.GetCQ(txt_Customer.Text.Trim(), rdo_post.Checked, rdo_retured.Checked, dte_to.Value, dte_from.Value);
                    dte_cheques.DataSource = dt3;
                    dte_cheques.Columns[0].Width = 100;
                    dte_cheques.Columns[1].Width = 100;
                    dte_cheques.Columns[2].Width = 100;
                    dte_cheques.Columns[3].Width = 190;
                    dte_cheques.Columns[4].Width = 100;
                    dte_cheques.Columns[5].Width = 100;

                    dte_cheques.Columns[0].ReadOnly = true;
                    dte_cheques.Columns[1].ReadOnly = true;
                    dte_cheques.Columns[2].ReadOnly = true;
                    dte_cheques.Columns[3].ReadOnly = true;
                    dte_cheques.Columns[4].ReadOnly = true;
                    dte_cheques.Columns[5].ReadOnly = true;

                    dte_cheques.Refresh();

                }



                


            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }






        }


        private DataTable getProcessedDOs()
        {
            DataTable dt = new DataTable();
            try
            {
                dte_cheques.DataSource = commonFunctions.GetDatatable("SELECT  dbo.T_DIliveryHed.DoNo, dbo.T_DIliveryHed.InvoiceAmount, dbo.T_DIliveryHed.Customer, dbo.M_Customers.CustName FROM dbo.T_DIliveryHed INNER JOIN  dbo.M_Customers ON dbo.T_DIliveryHed.Customer = dbo.M_Customers.CusID WHERE     (dbo.T_DIliveryHed.Processed = 1 AND Approved = 1 and Audited = 0 )");
                return dt;
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Error on getting processed current delivery orders", 2);
                return dt;
            }
        }

        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
            }


            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_Customer.Name.Trim())
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

                txt_Customer_name.Text = findExisting.FindExisitingCUstomer(txt_Customer.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dte_cheques.Rows)
                {
                    if (drow.Cells[0].Value.ToString().Trim() != null)
                    {
                        T_RecDet det = new T_RecDet();
                        det = new T_RecDetDL().Selectt_RecDet(det, drow.Cells[0].Value.ToString().Trim(), drow.Cells[1].Value.ToString().Trim());
                        if (det != null)
                        {

                            var val = drow.Cells[6].Value;
                            det.isReconsile = Convert.ToBoolean(drow.Cells[6].Value);
                            det.isreturned = Convert.ToBoolean(drow.Cells[7].Value);
                            new T_RecDetDL().Savet_RecDetSP(det, 3);
                        }


                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dte_cheques.Rows)
                {
                    if (drow.Cells[0].Value.ToString().Trim() != null)
                    {
                        T_RecDet det = new T_RecDet();
                        det = new T_RecDetDL().Selectt_RecDet(det, drow.Cells[0].Value.ToString().Trim(), drow.Cells[1].Value.ToString().Trim());
                        if (det != null)
                        {
                            det.isReconsile = Convert.ToBoolean(drow.Cells[6].Value);
                            det.isreturned = Convert.ToBoolean(drow.Cells[7].Value);
                            new T_RecDetDL().Savet_RecDetSP(det, 3);
                        }


                    }
                }
            }
        }


    }
}
