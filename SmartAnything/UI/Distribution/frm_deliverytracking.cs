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

namespace SmartAnything.UI
{
    public partial class frm_deliverytracking : Form
    {

        int formMode = 0;
        string formID = "A0055";
        string formHeadertext = "Delivery Tracking";
        DataTable dtx = new DataTable();
        T_DIliveryHed cat = new T_DIliveryHed();
        string codex = "";
        T_OrderTracking head = new T_OrderTracking();

        #region Loading one instance

        private static frm_deliverytracking objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_deliverytracking getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_deliverytracking();

            }
            return objSingleObject;

        }

        #endregion


        public frm_deliverytracking()
        {
            InitializeComponent();
        }

        private void frm_deliverytracking_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);

                getProcessedOFs();
                commonFunctions.FormatDataGrid(dataGridView2);


                foreach (ListViewItem itm in listView1.Items)
                {
                    //itm.Text = itm.Text.Trim().ToUpper();
                    itm.ForeColor = Color.Black;
                    itm.ImageIndex = 2;
                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral error on loading", 2);
            }
        }

        private void getProcessedOFs()
        {
            try
            {
                //string sqlstr = "SELECT     dbo.T_OrderTracking.OFNo, dbo.T_OrderTracking.Customer, dbo.M_Customers.CustName, dbo.T_OrderTracking.SalesMan, dbo.M_SalesMan.SalesmanName,dbo.T_OrderTracking.OFApproved, dbo.T_OrderTracking.InvCreated, dbo.T_OrderTracking.InvNo, dbo.T_OrderTracking.InvApproved, dbo.T_OrderTracking.DOCreated,dbo.T_OrderTracking.DONo, dbo.T_OrderTracking.DOApproved, dbo.T_OrderTracking.Audited, dbo.T_OrderTracking.AuditUser, dbo.T_OrderTracking.Dispatched," +
                //" dbo.T_OrderTracking.Handedover, dbo.T_OrderTracking.Completed, dbo.T_OrderTracking.PackingListCreated, dbo.T_OrderTracking.PackingListNo,dbo.T_OrderTracking.Remarks " +
                // " FROM         dbo.T_OrderTracking INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID INNER JOIN dbo.M_SalesMan ON dbo.T_OrderTracking.SalesMan = dbo.M_SalesMan.SalesmanID ";


                string sqlstr = " SELECT     dbo.T_OrderTracking.OFNo AS [OF No], dbo.T_OrderTracking.Customer AS [Cus Code], dbo.M_Customers.CustName AS [Cus Name],dbo.T_OrderTracking.SalesMan AS [Salesman], dbo.T_OrderTracking.InvNo AS [INV No],dbo.T_OrderTracking.InvAmount AS [INV Amt], dbo.T_OrderTracking.DONo AS [DO No] ,PackingListNo  AS [Packing No] FROM         dbo.T_OrderTracking  INNER JOIN dbo.M_Customers ON dbo.T_OrderTracking.Customer = dbo.M_Customers.CusID  INNER JOIN dbo.u_User ON dbo.T_OrderTracking.SalesMan = dbo.u_User.userId " +
                                " WHERE Completed = 0 AND OFApproved != 2 and T_OrderTracking.LocaCode = '" + commonFunctions.GlobalLocation.Trim() + "'";


                dataGridView2.DataSource = commonFunctions.GetDatatable(sqlstr);
                dataGridView2.Columns[0].Width = 90;
                dataGridView2.Columns[1].Width = 90;
                dataGridView2.Columns[2].Width = 200;
                dataGridView2.Columns[3].Width =90;
                dataGridView2.Columns[4].Width = 90;
                dataGridView2.Columns[6].Width = 90;
                dataGridView2.Refresh();
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral error on loading data", 2);
            }
        }
    
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_inscomplete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                //lbl_message.Text = "";
                if (head.DOCreated == 1)
                {
                    if (cat.Processed == 1)
                    {
                        errorProvider1.SetError(btn_process, "This delivery order already processed.".ToUpper());
                        commonFunctions.SetMDIStatusMessage("This delivery order already processed.", 2);
                        return;
                    }

                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {


                        T_DIliveryHedDL dl = new T_DIliveryHedDL();
                        cat.Processed = 1;
                        cat.ProcessedDate = DateTime.Now;
                        cat.ProcessedUser = commonFunctions.Loginuser;

                        head.DOProcessed = 1;
                        head.DOProcessedDate= DateTime.Now;
                        head.DOProcessedUser = commonFunctions.Loginuser;

                        if (dl.Savet_DIliveryHedSP(cat, 3) && new T_OrderTrackingDL().Savet_OrderTrackingSP(head, 3))
                        {
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                        }
                    }
                }
                else
                {
                    commonFunctions.SetMDIStatusMessage("Delivery Order not created for this order", 1);
                }
            } 
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error", 2);
            }
        }

        #region FunctionButtonStatus Area
        /*FunctionButtonStatus Was created by Asanga Chandrakumara on 12:18 PM 6/24/2015*/
        /// <summary>
        /// THis function will enable and disable the button status as required
        /// </summary>
        /// <param name="typex">Enumaration to function type</param>
        public void FunctionButtonStatus(xEnums.PerformanceType typex)
        {

            u_UserRights_DL inspection = commonFunctions.GetUserRightObj("A0051", commonFunctions.Loginuser.Trim());
            u_UserRights_DL dispatch = commonFunctions.GetUserRightObj("A0052", commonFunctions.Loginuser.Trim());
            u_UserRights_DL handover = commonFunctions.GetUserRightObj("A0053", commonFunctions.Loginuser.Trim());
            u_UserRights_DL confirmation = commonFunctions.GetUserRightObj("A0054", commonFunctions.Loginuser.Trim());

            switch (typex)
            {
                case xEnums.PerformanceType.Default:
                    btn_process.Enabled = inspection.boolAccess;
                    btn_dispatchdo.Enabled = dispatch.boolAccess;
                    btn_hanoverdo.Enabled = handover.boolAccess;
                    btn_confirmdelivery.Enabled = confirmation.boolAccess;
                    break;
            }
          
            //dataGridView1.Enabled = true;
            //txt_IDX.Enabled = true;
        }

        #endregion

        private void btn_dispatchdo_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView1.Items) {
                itm.ForeColor = Color.Red;
                itm.ImageIndex = 1;
            }
        }

        private void btn_hanoverdo_Click(object sender, EventArgs e)
        {
            //lbl_message.Text = "";
            errorProvider1.Clear();
            if (head.Handedover == 1)
            {
                errorProvider1.SetError(btn_hanoverdo, "This delivery order already handovered.".ToUpper());
                commonFunctions.SetMDIStatusMessage("This delivery order already handovered.", 1);
                return;
            }

            if (head.Dispatched == 0)
            {
                errorProvider1.SetError(btn_hanoverdo, "This delivery order is not dispatched.".ToUpper());
                commonFunctions.SetMDIStatusMessage("This delivery order is not dispatched.", 1);
                return;
            }

            //if (!M_VehicleDL.ExistingM_Vehicle(txt_Lorry.Text.Trim()))
            //{
            //    errorProvider1.SetError(txt_Lorry, "Vehicle details does not exists on the system ");
            //    commonFunctions.SetMDIStatusMessage("Vehicle details does not exists on the system ", 1);
            //    return;
            //}
            if (!M_AgentDL.ExistingM_Agent(txt_Agent.Text.Trim()))
            {
                errorProvider1.SetError(txt_Agent, "Agent does not exists on the system ");
                commonFunctions.SetMDIStatusMessage("Agent does not exists on the system ", 1);
                return;
            }

            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                T_DIliveryHedDL dl = new T_DIliveryHedDL();

                cat = new T_DIliveryHed();
                cat.DoNo = head.DONo.Trim();
                cat.LocaCode = commonFunctions.GlobalLocation;
                cat = new T_DIliveryHedDL().Selectt_DIliveryHed(cat,1);


                cat.Handovered = 1;
                cat.HandoverDate = DateTime.Now;
                cat.HandoverdUser = commonFunctions.Loginuser;
                head.HandOverLorry = txt_Lorry.Text.Trim();

                head.Handedover = 1;
                head.HandedoverDate = DateTime.Now;
                head.HandedoverUser = commonFunctions.Loginuser;
                

                if (dl.Savet_DIliveryHedSP(cat, 3) && new T_OrderTrackingDL().Savet_OrderTrackingSP(head, 3))
                {
                    commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                }
                getProcessedOFs();
            } 
        }

        private void btn_handover_Click(object sender, EventArgs e)
        {

        }

        private void btn_confirmdelivery_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (cat.Completed == 1)
            {
                errorProvider1.SetError(btn_hanoverdo, "This delivery order already confirmed.".ToUpper());
                commonFunctions.SetMDIStatusMessage("This delivery order already confirmed.", 1);
                return;
            }

            if (cat.Handovered == 0)
            {
                errorProvider1.SetError(btn_hanoverdo, "This delivery order is not handovered.".ToUpper());
                commonFunctions.SetMDIStatusMessage("This delivery order is not handovered.", 1);
                return;
            }

            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                T_DIliveryHedDL dl = new T_DIliveryHedDL();
                cat.Completed = 1;
                cat.CompletedDate = DateTime.Now;

                head.Completed = 1;
                head.CompletedDate = DateTime.Now;
                head.CompletedUser = commonFunctions.Loginuser;
                head.CompleteRemark = txt_cremarks.Text.Trim();
                

                if (dl.Savet_DIliveryHedSP(cat, 3) && new T_OrderTrackingDL().Savet_OrderTrackingSP(head , 3))
                {
                    commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                    getProcessedOFs();
                }
            } 
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {

                    codex = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    head.OFNo = codex;
                    head = new T_OrderTrackingDL().Selectt_OrderTracking(head, xEnums.OrderTrackingTypes.OrderNo);

                    if (head.DONo.Trim() != "")
                    {
                        cat = new T_DIliveryHed();
                        cat.LocaCode = commonFunctions.GlobalLocation;
                        cat.DoNo = head.DONo.Trim();
                        cat = new T_DIliveryHedDL().Selectt_DIliveryHed(cat,1);
                    }

                    //new T_DIliveryHedDL().Selectt_DIliveryHed(

                    if (head.OFApproved == 1)
                    {
                        colorswitchx(true, 0);
                    }
                    else
                    {
                        colorswitchx(false, 0);
                    }
                    if (head.InvCreated == 1)
                    {
                        colorswitchx(true, 1);
                    }
                    else
                    {
                        colorswitchx(false, 1);
                    }
                    if (head.InvApproved == 1)
                    {
                        colorswitchx(true, 2);
                    }
                    else
                    {
                        colorswitchx(false, 2);
                    }

                    if (head.DOCreated == 1)
                    {
                        colorswitchx(true, 3);
                    }
                    else
                    {
                        colorswitchx(false, 3);
                    }


                    if (head.DOApproved == 1)
                    {
                        colorswitchx(true, 4);
                    }
                    else
                    {
                        colorswitchx(false, 4);
                    }

                    if (head.Audited == 1)
                    {
                        colorswitchx(true, 5);
                    }
                    else
                    {
                        colorswitchx(false, 5);
                    }

                    if (head.PackingListCreated == 1)
                    {
                        colorswitchx(true, 6);
                    }
                    else
                    {
                        colorswitchx(false, 6);
                    }

                    if (head.Dispatched == 1)
                    {
                        colorswitchx(true, 7);
                    }
                    else
                    {
                        colorswitchx(false, 7);
                    }

                    if (head.Handedover == 1)
                    {
                        colorswitchx(true, 8);
                    }
                    else
                    {
                        colorswitchx(false, 8);
                    }


                    if (head.Completed == 1)
                    {
                        colorswitchx(true, 9);
                    }
                    else
                    {
                        colorswitchx(false, 9);
                    }
                    //if(head.OFApproved 

                }
            }
            catch (Exception ex) { }
        }


        private void colorswitchx(bool status, int index) {
            if (status)
            {
                listView1.Items[index].ForeColor = Color.Green;
                listView1.Items[index].ImageIndex = 1;
            }
            else {
                listView1.Items[index].ForeColor = Color.Green;
                listView1.Items[index].ImageIndex = 0;
            }
        }

        private void txt_Agent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txt_Lorry.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_Agent.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["AgentFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["AgentSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["AgentField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
        }

        private void txt_Lorry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txt_Agent.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (ActiveControl.Name.Trim() == txt_Lorry.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["VehicleFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["VehicleSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["VehicleField" + m + ""].ToString();
                    }
                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }
            }
        }

        private void txt_Agent_TextChanged(object sender, EventArgs e)
        {
            txt_Agent_name.Text = findExisting.FindExisitingAgent(txt_Agent.Text);
        }

        private void txt_Lorry_TextChanged(object sender, EventArgs e)
        {
            //txt_Lorry_name.Text = findExisting.FindExisitingVehicle(txt_Lorry.Text);
        }



    }
}

