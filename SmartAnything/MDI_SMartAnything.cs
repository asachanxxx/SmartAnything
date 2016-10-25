using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using smartOffice.Classes;
using smartOffice_BL;
using smartOffice_Models;
using SmartAnything;
using SmartAnything.UI;
using SmartAnything.UI.Distribution;
using SmartAnything.UI.Transactions;
using SmartAnything.Reports;
using SmartAnything.Reports.DistributionRpt;
using SmartAnything.Reports.SalesRpt;
using SmartAnything.Reports.StockRpt;
using SmartAnything.Reports.Stock;
using SmartAnything.Reports.Sales;

namespace SmartAnything
{
    public partial class MDI_SMartAnything : Form
    {

        
        
        bool wantexit = false;

        public bool Wantexit
        {
            get { return wantexit; }
            set { wantexit = value; }
        }
        private int childFormNumber = 0;
        private bool colswitch = false;
        int count = 0;

        public int CountEr
        {
            get { return count; }
            set { count = value; }
        }
        public MDI_SMartAnything()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();

           bool x =  ifExistsForm(this, "Form1");

            
        }

        #region Loading one instance

        private static MDI_SMartAnything objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static MDI_SMartAnything getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new MDI_SMartAnything();

            }
            return objSingleObject;

        }

        #endregion


        private bool ifExistsForm(Form mdiparant,string needed) {
            bool havex = false;
            foreach (Form form in mdiparant.MdiChildren)
            {
                if (form.Name.Trim() == needed.Trim())
                {
                    havex = true;
                }
            }
            return havex;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDI_SMartAnything_Load(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(this.tbl_status.Text.Length.ToString());
                MenuStripItemsVisible();
                notifyIcon1.Text = commonFunctions.Softwarename;
                this.WindowState = FormWindowState.Maximized;
                this.Text = commonFunctions.Softwarename.Trim();
                //txt_loginuser.Text = "Login User: ".ToUpper() + commonFunctions.Loginuser.Trim();
                //txt_date.Text = "SYstem Date: ".ToUpper() + DateTime.Now.Date.ToShortDateString().ToString();

                tbl_loginuser.Text = commonFunctions.Loginuser.Trim().ToUpper();
                tbl_date.Text = DateTime.Now.Date.ToShortDateString().ToString();
                tbl_Time.Text = DateTime.Now.Date.ToShortTimeString().ToString();
                FormatMenuItems();
                //timer1.Enabled = true;


                
                //tbl_status.Text = "Cannot login the system".ToUpper();
                commonFunctions.SetMDIStatusMessage("Ready",2);

            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");

            }
        }

        /// <summary>
        /// This will disable menues if they don't have acccess to incoming user searched by the Menu ID
        /// So when ever you change the text of the form will not effect to this method
        /// just put the tlStrpMenuItem_ +menu ID  to the menu name and all done
        /// </summary>
        public void MenuStripItemsVisible()
        {
            u_UserRights objUserRight = new u_UserRights();
            objUserRight.User = new u_User();
            objUserRight.MenuTag = new u_MenuTag();
            u_UserRights_BL objUserRghtsBL = new u_UserRights_BL();
            objUserRight.User.strUserID = Globals.g_strUser;
            objUserRight.MenuTag.strMenuID = Globals.g_MenuId;

            u_UserRights_DL objURightDL = new u_UserRights_DL();
            DataTable dtAllMenuItems = objURightDL.GetUserRights(objUserRight);
            //DataTable dtAllMenuItems = objUserRghtsBL.GetUserRights(objUserRight);


            if (Globals.g_strUser.Trim().ToUpper() != "ADMIN")
            {

                if (dtAllMenuItems.Rows.Count != 0)
                {
                    for (int i = 0; i < dtAllMenuItems.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dtAllMenuItems.Rows[i]["dtAccess"].ToString()) == false)
                        {
                            string strEditUIName = (dtAllMenuItems.Rows[i]["Code"].ToString()).Replace(" ", "");
                            string strtlStrpMenuItemName = strEditUIName;
                            List<ToolStripMenuItem> myItems = GetItems(this.menuStrip);
                            foreach (var item in myItems)
                            {
                                item.ForeColor = Color.FromArgb(126, 26, 29);
                                item.Text = item.Text.ToUpper();
                                if (item.Name == strtlStrpMenuItemName)
                                {
                                    item.Enabled = false;

                                }

                            }
                            foreach (ToolStripItem ctrl in this.toolStrip.Items)
                            {
                                ctrl.Text = ctrl.Text.ToUpper();
                                if (ctrl.Name.Trim().ToUpper() == "T" + strtlStrpMenuItemName.Trim().ToUpper())
                                {
                                    ctrl.Enabled = false;

                                }
                            }
                            foreach (ToolStripItem ctrl in this.contextMenuStrip1.Items)
                            {
                                ctrl.Text = ctrl.Text.ToUpper();
                                ctrl.ForeColor = Color.FromArgb(126, 26, 29);
                                if (ctrl.Name.Trim().ToUpper() == "C" + strtlStrpMenuItemName.Trim().ToUpper())
                                {
                                    ctrl.Enabled = false;

                                }
                            }
                        }
                        else
                        {
                            string strEditUIName = (dtAllMenuItems.Rows[i]["Code"].ToString()).Replace(" ", "");
                            string strtlStrpMenuItemName = strEditUIName;
                            List<ToolStripMenuItem> myItems = GetItems(this.menuStrip);
                            foreach (var item in myItems)
                            {
                                item.ForeColor = Color.FromArgb(126, 26, 29);
                                item.Text = item.Text.ToUpper();
                                if (item.Name == strtlStrpMenuItemName)
                                {
                                    item.Enabled = true;

                                }

                            }
                            foreach (ToolStripItem ctrl in this.toolStrip.Items)
                            {
                                ctrl.Text = ctrl.Text.ToUpper();
                                if (ctrl.Name.Trim().ToUpper() == "T" + strtlStrpMenuItemName.Trim().ToUpper())
                                {
                                    ctrl.Enabled = true;

                                }
                            }

                            foreach (ToolStripItem ctrl in this.contextMenuStrip1.Items)
                            {
                                ctrl.Text = ctrl.Text.ToUpper();
                                ctrl.ForeColor = Color.FromArgb(126, 26, 29);
                                if (ctrl.Name.Trim().ToUpper() == "C" + strtlStrpMenuItemName.Trim().ToUpper())
                                {
                                    ctrl.Enabled = true;

                                }
                            }
                        }
                    }
                }
                else
                {
                    //implement locking system
                    List<ToolStripMenuItem> myItems = GetItems(this.menuStrip);
                    foreach (var item in myItems)
                    {
                        item.ForeColor = Color.FromArgb(126, 26, 29);
                        item.Text = item.Text.ToUpper();
                        item.Enabled = false;
                    }
                    foreach (ToolStripItem ctrl in this.toolStrip.Items)
                    {
                        if (ctrl.Name.Trim().ToUpper() == "shutdown_ToolBar".Trim().ToUpper())
                        {

                        }
                        else
                        {
                            ctrl.Text = ctrl.Text.ToUpper();
                            ctrl.Enabled = false;
                        }
                   }

                    foreach (ToolStripItem ctrl in this.contextMenuStrip1.Items)
                    {
                        ctrl.Text = ctrl.Text.ToUpper();
                        ctrl.ForeColor = Color.FromArgb(126, 26, 29);
                        ctrl.Enabled = false;
                    }



                }

            }
            else
            {

                // if login user is administrator

            }




        }

        public void FormatMenuItems() {
            List<ToolStripMenuItem> myItems = GetItems(this.menuStrip);
            foreach (var item in myItems)
            {
                item.ForeColor = Color.FromArgb(126, 26, 29);
                item.Text = item.Text.ToUpper();
            }
        }


        public static List<ToolStripMenuItem> GetItems(MenuStrip menuStrip)
        {
            List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem i in menuStrip.Items)
            {
                GetMenuItems(i, myItems);
            }
            return myItems;
        }

        //public static List<ToolStripItem> GetItems(ToolStrip menuStrip)
        //{
        //    List<ToolStripItem> myItems = new List<ToolStripItem>();
        //    foreach (ToolStripItem i in menuStrip.Items)
        //    {
        //        GetMenuItems(i, myItems);
        //    }
        //    return myItems;
        //}

        private static void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items)
        {
            items.Add(item);
            foreach (ToolStripItem i in item.DropDownItems)
            {
                if (i is ToolStripMenuItem)
                {
                    GetMenuItems((ToolStripMenuItem)i, items);

                }
            }
        }

        private void salesItemAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_sales_itemalloc objSupp = frm_sales_itemalloc.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Show();
            objSupp.Activate();
        }

       

        private void A0003_Click(object sender, EventArgs e)
        {
            Banks objSupp = Banks.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Show();
            objSupp.Activate();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }


        public void addremoveWindow(string name, bool add)
        {
            

            //if (add)
            //{
            //    bool have = false;
            //    foreach (string itm in lst_windows.Items)
            //    {
            //        if (itm.Trim() == name.Trim())
            //        {
            //            have = true;
            //        }
            //    }
            //    if (have == false)
            //    {
            //        lst_windows.Items.Add(name);
            //    }

            //}
            //else
            //{

            //    foreach (string itm in lst_windows.Items)
            //    {
            //        if (itm.Trim() == name.Trim())
            //        {
            //            lst_windows.Items.Remove(itm);
            //        }
            //    }

            //}
        }

        int tillcount = 11;
        public int type = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tbl_Time.Text = DateTime.Now.ToString("hh:mm:ss tt");
            if (count < tillcount)
            {
                if (type == 1)
                {
                    tillcount = 11;
                    if (colswitch == false)
                    {
                        tbl_status.ForeColor = Color.Red;
                        colswitch = true;
                    }
                    else
                    {
                        tbl_status.BackColor = Color.FromArgb(43, 87, 154);
                        tbl_status.ForeColor = Color.White;
                        colswitch = false;
                    }
                }
                else
                {
                    tillcount = 12;
                    if (colswitch == false)
                    {
                        tbl_status.ForeColor = Color.White;
                        colswitch = true;
                    }
                    else
                    {
                        tbl_status.BackColor = Color.FromArgb(43, 87, 154);
                        tbl_status.ForeColor = Color.White;
                        colswitch = false;
                    }
                }


                count += 1;
            }
            else {
                tbl_status.BackColor = Color.FromArgb(43, 87, 154);
                tbl_status.ForeColor = Color.White;
                Errormessagepoper("Ready");
            }
            //if (u_DBConnection.getConnection().State != ConnectionState.Open) {
            //    notifyIcon1.ShowBalloonTip(3000, commonFunctions.Softwarename, "COnnection Fail", ToolTipIcon.Error);
            //}
            //notifyIcon1.ShowBalloonTip(3000, commonFunctions.Softwarename, u_DBConnection.getConnection().ConnectionString..ToString(), ToolTipIcon.Info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="type">1 -error 2 - info </param>
        public void Errormessagepoper(string error) {
           
            tbl_status.Text = error.ToUpper();
        }


        private void A0006_Click(object sender, EventArgs e)
        {
            frm_company objSupp = frm_company.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0008_Click(object sender, EventArgs e)
        {
            frm_locations objSupp = frm_locations.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0007_Click(object sender, EventArgs e)
        {
            frm_customers objSupp = frm_customers.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0009_Click(object sender, EventArgs e)
        {
            frm_products objSupp = frm_products.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0012_Click(object sender, EventArgs e)
        {
            frm_suppliers objSupp = frm_suppliers.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0011_Click(object sender, EventArgs e)
        {
            frm_saleman objSupp = frm_saleman.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();

        }

        private void A0001_Click(object sender, EventArgs e)
        {
            frm_agents objSupp = frm_agents.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0002_Click(object sender, EventArgs e)
        {
            frm_Area objSupp = frm_Area.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0013_Click(object sender, EventArgs e)
        {
            frm_terratory objSupp = frm_terratory.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0010_Click(object sender, EventArgs e)
        {
            frm_Route objSupp = frm_Route.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0040_Click(object sender, EventArgs e)
        {
            frm_categories objSupp = frm_categories.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0014_Click(object sender, EventArgs e)
        {
            frm_vehicles objSupp = frm_vehicles.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0042_Click(object sender, EventArgs e)
        {
            frm_purchaserequest objSupp = frm_purchaserequest.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            

        }

        private void A0024_Click(object sender, EventArgs e)
        {
            frm_po objSupp = frm_po.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0025_Click(object sender, EventArgs e)
        {
            frm_grn objSupp = frm_grn.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0028_Click(object sender, EventArgs e)
        {
            frm_returns objSupp = frm_returns.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void A0043_Click(object sender, EventArgs e)
        {
            frm_transferOut objSupp = frm_transferOut.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0044_Click(object sender, EventArgs e)
        {
            frm_transferin objSupp = frm_transferin.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0027_Click(object sender, EventArgs e)
        {
            frm_adjustment objSupp = frm_adjustment.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0046_Click(object sender, EventArgs e)
        {
            frm_damage objSupp = frm_damage.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0047_Click(object sender, EventArgs e)
        {
            frm_wastage objSupp = frm_wastage.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0048_Click(object sender, EventArgs e)
        {
            frm_staffusage objSupp = frm_staffusage.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0017_Click(object sender, EventArgs e)
        {
            frm_orderform objSupp = frm_orderform.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0019_Click(object sender, EventArgs e)
        {
            frm_invoice objSupp = frm_invoice.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0033_Click(object sender, EventArgs e)
        {
            frm_OrderFormApproval objSupp = frm_OrderFormApproval.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0005_Click(object sender, EventArgs e)
        {
            frm_cnReason objSupp = frm_cnReason.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0050_Click(object sender, EventArgs e)
        {
            frm_invoiceApproval objSupp = frm_invoiceApproval.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0018_Click(object sender, EventArgs e)
        {
            frm_do objSupp = frm_do.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void deliveryOrderTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_deliverytracking objSupp = frm_deliverytracking.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0041_Click(object sender, EventArgs e)
        {
            frm_packinglist objSupp = frm_packinglist.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0020_Click(object sender, EventArgs e)
        {
            frm_creditnote objSupp = frm_creditnote.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
            
        }

        private void A0034_Click(object sender, EventArgs e)
        {
            frm_doapprovals objSupp = frm_doapprovals.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void MDI_SMartAnything_Validated(object sender, EventArgs e)
        {

        }

        private void A0035_Click(object sender, EventArgs e)
        {
            frm_audit objSupp = frm_audit.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0056_Click(object sender, EventArgs e)
        {
            frm_creditnotegroup objSupp = frm_creditnotegroup.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0036_Click(object sender, EventArgs e)
        {
            frm_creditnoteApproval objSupp = frm_creditnoteApproval.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            

            
        }

        private void A0022_Click(object sender, EventArgs e)
        {
            frm_sales_customer_alloc objSupp = frm_sales_customer_alloc.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0021_Click(object sender, EventArgs e)
        {

            SmartAnything.UI.Distribution.frm_customer_item_Alloc objSupp = SmartAnything.UI.Distribution.frm_customer_item_Alloc.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0058_Click(object sender, EventArgs e)
        {
            frm_recipt objSupp = frm_recipt.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0038_Click(object sender, EventArgs e)
        {
            frm_users objSupp = frm_users.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0039_Click(object sender, EventArgs e)
        {
            frm_seccenter objSupp = frm_seccenter.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void openingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_openstock objSupp = frm_openstock.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void TA0007_Click(object sender, EventArgs e)
        {
            A0007_Click(sender, e);
        }

        private void TA0009_Click(object sender, EventArgs e)
        {
            A0009_Click(sender, e);
        }

        private void TA0012_Click(object sender, EventArgs e)
        {
            A0012_Click(sender, e);
        }

        private void TA0011_Click(object sender, EventArgs e)
        {
            A0011_Click(sender, e);
        }

        private void TA0003_Click(object sender, EventArgs e)
        {
            A0003_Click(sender, e);
        }

        private void TA0017_Click(object sender, EventArgs e)
        {
            A0017_Click(sender, e);
        }

        private void TA0018_Click(object sender, EventArgs e)
        {
            A0018_Click(sender, e);
        }

        private void TA0019_Click(object sender, EventArgs e)
        {
            A0019_Click(sender, e);
        }

        private void TA0020_Click(object sender, EventArgs e)
        {
            A0020_Click(sender, e);
        }

        private void TA0016_Click(object sender, EventArgs e)
        {
            A0016_Click(sender, e);
        }

        private void A0016_Click(object sender, EventArgs e)
        {
            frm_chequeHandling objSupp = frm_chequeHandling.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0060_Click(object sender, EventArgs e)
        {
            frm_packinglist objSupp = frm_packinglist.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void TA0060_Click(object sender, EventArgs e)
        {
            A0060_Click(sender, e);
        }

        private void TA0058_Click(object sender, EventArgs e)
        {
            A0058_Click(sender, e);
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void shutdown_ToolBar_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_exit, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                Wantexit = true;
                Application.Exit();
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            deliveryOrderTrackingToolStripMenuItem_Click(sender, e);
        }

        private void CA0033_Click(object sender, EventArgs e)
        {
            A0033_Click(sender, e);
        }

        private void CA0050_Click(object sender, EventArgs e)
        {
            A0050_Click(sender, e);
        }

        private void CA0034_Click(object sender, EventArgs e)
        {
            A0034_Click(sender, e);
        }

        private void CA0035_Click(object sender, EventArgs e)
        {
            A0035_Click(sender, e);
        }

        private void CA0036_Click(object sender, EventArgs e)
        {
            A0036_Click(sender, e);
        }

        private void CA0039_Click(object sender, EventArgs e)
        {
            A0039_Click(sender, e);
        }

        private void openSmartDistributorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ShutdownRIT_Click(object sender, EventArgs e)
        {
            Wantexit = true;
            Application.Exit();
        }

        private void LoggOFF_Click(object sender, EventArgs e)
        {
            //this.Close();
            //SmartAnything.frmU_Login.ActiveForm.Visible = true;
            //foreach (Form f in Application.OpenForms) {
            //    listBox1.Items.Add(f.Name);
            //}
            this.Hide();
            CheckIfFormIsOpen("frmU_Login").Visible = true;

        }

        public Form CheckIfFormIsOpen(string formname)
        {

            FormCollection fc = Application.OpenForms;
            Form f = new Form();
            foreach (Form frm in fc)
            {
                if (frm.Name == formname)
                {
                    f =  frm;
                }
            }
            return f;
            //bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == formname);
            //return formOpen;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }


        private void MinimzedTray()
        {
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Application;

            notifyIcon1.BalloonTipText = "Minimized";
            notifyIcon1.BalloonTipTitle = "Your Application is Running in BackGround";
            notifyIcon1.ShowBalloonTip(500);

        }

        private void MaxmizedFromTray()
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipText = "Maximized";
            notifyIcon1.BalloonTipTitle = "Application is Running in Foreground";
            notifyIcon1.ShowBalloonTip(500);


        }

        private void MDI_SMartAnything_Resize(object sender, EventArgs e)
        {
            //if (FormWindowState.Minimized == this.WindowState)
            //{
            //    MinimzedTray();
            //}
            //else if (FormWindowState.Normal == this.WindowState)
            //{

            //    MaxmizedFromTray();
            //}
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            notifyIcon1.BalloonTipText = "Normal";
            notifyIcon1.ShowBalloonTip(500);
        }
        private void MDI_SMartAnything_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Wantexit == false)
            {
                e.Cancel = true;
                notifyIcon1.BalloonTipText = "Retail IT SmartDistributor Minimize to tray";
                notifyIcon1.ShowBalloonTip(5000, commonFunctions.Softwarename, "Retail IT SmartDistributor Minimize to tray", ToolTipIcon.Info);
                this.Hide();
            }
            else
            {
                e.Cancel = false;
            }

            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    e.Cancel = true;
            //    //this.WindowState = FormWindowState.Minimized;
            //    //this.ShowInTaskbar = false;
            //    //this.Hide();
            //    notifyIcon1.BalloonTipText = "Retail IT SmartDistributor Minimize to tray";
            //    notifyIcon1.ShowBalloonTip(5000, commonFunctions.Softwarename, "Retail IT SmartDistributor Minimize to tray", ToolTipIcon.Info);
            //    MaxmizedFromTray();
            //}

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_logoff, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                CheckIfFormIsOpen("frmU_Login").Visible = true;
            }
        }

        private void MDI_SMartAnything_VisibleChanged(object sender, EventArgs e)
        {
            tbl_loginuser.Text = commonFunctions.Loginuser.Trim().ToUpper();
            Globals.g_strUser = commonFunctions.Loginuser.Trim().ToUpper();
            tbl_date.Text = DateTime.Now.Date.ToShortDateString().ToString();
            MenuStripItemsVisible();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pnl_pass.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnl_pass.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPw.Text == "")
            {
                errorProvider1.SetError(txtPw, "Password cannot be a null value.");
                commonFunctions.SetMDIStatusMessage("Password cannot be a null value.", 1);
                return;
            }
            if (txtPw.Text != txtRePw.Text)
            {
                errorProvider1.SetError(txtPw, "Password and the confirmation password must be same");
                commonFunctions.SetMDIStatusMessage("Password and the confirmation password must be same.", 1);
                return;
            }

            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
            {
                u_Userxcc obju_User = new u_Userxcc();
                obju_User.userId = commonFunctions.Loginuser;
                obju_User = new U_UserxDL().Selectu_User(obju_User);
                obju_User.password = commonFunctions.CreateCheckPassword(true, txtPw.Text.Trim());
                new U_UserxDL().Saveu_UserSP(obju_User, 3);
                pnl_pass.Visible = false;

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txtPw.Focus();
            }
        }

        private void txtPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRePw.Focus();
            }
        }

        private void txtRePw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus();
            }
        }

        private void A0080_Click(object sender, EventArgs e)
        {
            frm_stockValuation objSupp = frm_stockValuation.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0082_Click(object sender, EventArgs e)
        {
            frm_bincard objSupp = frm_bincard.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
           
        }

        private void A0061_Click(object sender, EventArgs e)
        {
            frm_customerArranger objSupp = frm_customerArranger.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void A0030_Click(object sender, EventArgs e)
        {
            SmartAnything.Reports.Distribution.frm_cartonMarking objSupp = SmartAnything.Reports.Distribution.frm_cartonMarking.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void A0031_Click(object sender, EventArgs e)
        {
            SmartAnything.UI.HouseKeeping.frm_backups objSupp = UI.HouseKeeping.frm_backups.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void reprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DistributionReporint objSupp = frm_DistributionReporint.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void pENDINGAPPROVALSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_pendingApprovals objSupp = frm_pendingApprovals.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            

        }

        private void orderTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ordertracking objSupp = frm_ordertracking.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
            
        }

        private void cUSTOMERLIABILITYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_customerliability objSupp = frm_customerliability.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();

        }

        private void postDatedChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Cheques objSupp = frm_Cheques.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddButtonsToMyChildren();
        }

        private void AddButtonsToMyChildren()
        {
            // If there are child forms in the parent form, add Button controls to them.
            for (int x = 0; x < this.MdiChildren.Length; x++)
            {
                // Create a temporary Button control to add to the child form.
                Button tempButton = new Button();
                // Set the location and text of the Button control.
                tempButton.Location = new Point(100, 100);
                tempButton.Text = "OK";
                // Create a temporary instance of a child form (Form 2 in this case).
                Form tempChild = (Form)this.MdiChildren[x];
                // Add the Button control to the control collection of the form.
                tempChild.Controls.Add(tempButton);
                toolStripComboBox1.Items.Add(tempChild.Name.Trim());
            }
        }

        private void stockCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_StockCard objSupp = frm_StockCard.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockBalanceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockBalance objSupp = frm_stockBalance.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void productPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_parts objSupp = frm_parts.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockBalanceDetailProductWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockBalance objSupp = frm_stockBalance.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockBalanceDetailStockWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockBalance objSupp = frm_stockBalance.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockValuationDetailProductWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockEvonew objSupp = frm_stockEvonew.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockValuationDetailStockWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockEvonew objSupp = frm_stockEvonew.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockValuationDetailProductCategoryWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockEvonew objSupp = frm_stockEvonew.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockValuationSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockEvonew objSupp = frm_stockEvonew.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void salesAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frm_salesAlloc objSupp = frm_salesAlloc.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void salesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_salessammaryNew objSupp = frm_salessammaryNew.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void salesAllocationVarianceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_salesAlloc objSupp = frm_salesAlloc.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockMovementFastMovingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockMovement objSupp = frm_stockMovement.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockVarianceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockvari objSupp = frm_stockvari.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockVarianceReportStockWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockvari objSupp = frm_stockvari.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockReorderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockreorder objSupp = frm_stockreorder.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockMovementSlowMovingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockMovement objSupp = frm_stockMovement.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockMovementNonMovingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockMovement objSupp = frm_stockMovement.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void stockAgeingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_stockAgin objSupp = frm_stockAgin.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void MDI_SMartAnything_Activated(object sender, EventArgs e)
        {
            lbl_loca.Text = commonFunctions.GlobalLocation +"-"+ findExisting.FindExisitingLoca(commonFunctions.GlobalLocation);
        }

        private void rEPLACEMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Distribution.frm_returns objSupp = Reports.Distribution.frm_returns.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void liveStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_liveStock objSupp = frm_liveStock.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void productPartsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_parts objSupp = frm_parts.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void addServicePartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_returnparts objSupp = frm_returnparts.getSingleton();
            objSupp.MdiParent = this;
            objSupp.Activate();
            objSupp.Show();
        }

        private void A0032_Click(object sender, EventArgs e)
        {

        }

        private void A0045_Click(object sender, EventArgs e)
        {

        }

        private void A0049_Click(object sender, EventArgs e)
        {

        }
    }
}
