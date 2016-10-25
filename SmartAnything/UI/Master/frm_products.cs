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
using SmartAnything.Reports.MasterRpt;

namespace SmartAnything.UI
{
    public partial class frm_products : Form
    {

        int formMode = 0;
        string formID = "A0009";
        string formHeadertext = "Products";
        DataTable dtx = new DataTable();

        #region Loading one instance

        private static frm_products objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_products getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_products();

            }
            return objSingleObject;

        }

        #endregion

        public frm_products()
        {
            InitializeComponent();
        }

        private void frm_products_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            FunctionButtonStatus(xEnums.PerformanceType.Default);
            commonFunctions.FormatDataGrid(dataGridView1);
            commonFunctions.FormatDataGrid(dataGridView2);
            commonFunctions.HandleTextBoxes(panel3);
            commonFunctions.HandleHeaderPanelColor(pnl_header);
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);
            dtx = commonFunctions.CreateDatatableAgents();
            dataGridView2.DataSource = dtx;
            dataGridView2.Columns[0].Width = 110;
            dataGridView2.Columns[1].Width = 230;
            GetData();
        }

        #region GetData

        private void GetData()
        {
            try
            {

                M_ProductDL bdl = new M_ProductDL();
                dataGridView1.DataSource = bdl.SelectAllm_Product();

                if (dataGridView1.DataSource != null)
                {

                    //dataGridView1.Columns[0].HeaderText = "Customer Code";
                    //dataGridView1.Columns[1].HeaderText = "Customer Name";

                    dataGridView1.Columns[0].Width = 120;
                    dataGridView1.Columns[1].Width = 422;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  SetValues
        private void SetValues(String sm_Product)
        {
            try
            {
                M_ProductDL objm_ProductDL = new M_ProductDL();
                M_Products objm_Product = new M_Products();
                if (sm_Product != "")
                {
                    objm_Product.IDX = sm_Product;
                    objm_Product = objm_ProductDL.Selectm_Product(objm_Product);
                    if (objm_Product != null)
                    {
                        txt_IDX.Text = objm_Product.IDX.ToString();
                        txt_Namex.Text = objm_Product.Namex.ToString();
                        txt_PrintName.Text = objm_Product.PrintName.ToString();
                        txt_UnitPrice.Text = objm_Product.UnitPrice.ToString();
                        txt_SellingPrice.Text = objm_Product.SellingPrice.ToString();
                        txt_CostPrice.Text = objm_Product.CostPrice.ToString();
                        txt_Category.Text = objm_Product.Category.ToString();
                        txt_Make.Text = objm_Product.Make.ToString();
                        txt_Model.Text = objm_Product.Model.ToString();
                        txt_Brand.Text = objm_Product.Brand.ToString();
                        txt_Unitx.Text = objm_Product.Unitx.ToString();
                        txt_Suplier.Text = objm_Product.Suplier.ToString();
                        txt_ReorderQTY.Text = objm_Product.ReorderQTY.ToString();
                        txt_ReorderLevel.Text = objm_Product.ReorderLevel.ToString();
                        txt_LockItem.Checked = Convert.ToBoolean(objm_Product.LockItem);
                        txt_subcat.Text = objm_Product.SubCategory;
                        chk_pricelvl.Checked = objm_Product.IsMaintainStockLot.Value;
                        formMode = 0;
                    }

                    dtx.Clear();
                    dataGridView2.Refresh();
                    M_Product_Has_Parts req = new M_Product_Has_Parts();
                    req.productId = objm_Product.IDX.ToString();
                    List<M_Product_Has_Parts> requests = new List<M_Product_Has_Parts>();
                    requests = new M_Product_Has_PartDL().SelectM_Product_Has_PartMulti(req);

                    foreach (M_Product_Has_Parts det in requests)
                    {

                        commonFunctions.AddRowAgents(dtx, det.PartId, findExisting.FindExisitingParts(det.PartId));
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion 
			  
        #region FunctionButtonStatus Area
        /*FunctionButtonStatus Was created by Asanga Chandrakumara on 12:18 PM 6/24/2015*/
        /// <summary>
        /// THis function will enable and disable the button status as required
        /// </summary>
        /// <param name="typex">Enumaration to function type</param>
        public void FunctionButtonStatus(xEnums.PerformanceType typex)
        {

            u_UserRights objUserRight = new u_UserRights();
            objUserRight.User = new u_User();
            objUserRight.MenuTag = new u_MenuTag();
            objUserRight.User.strUserID = Globals.g_strUser;
            objUserRight.MenuTag.strMenuID = formID.Trim();

            u_UserRights_DL objURightDL = new u_UserRights_DL();
            u_UserRights_DL dtAllMenuItems = objURightDL.GetUserRightsForOneMenu(objUserRight);



            switch (typex)
            {
                case xEnums.PerformanceType.Save:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        dataGridView1.Enabled = true;
                        txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        dataGridView1.Enabled = true;
                        txt_IDX.Enabled = true;

                    }
                    break;
                case xEnums.PerformanceType.Delete: //when press the delete button
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;

                    }
                    break;
                case xEnums.PerformanceType.Existing: //enter existing item to system
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = false;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;

                    }
                    break;
                case xEnums.PerformanceType.Edit: //enter existing item to system and press edit
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = dtAllMenuItems.boolCreate;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        dataGridView1.Enabled = false;
                        txt_IDX.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = false;
                        txt_IDX.Enabled = false;
                    }
                    break;
                case xEnums.PerformanceType.Exit:
                    break;
                case xEnums.PerformanceType.New:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = false;
                        chk_pricelvl.Checked = false;
                        //txt_IDX.Enabled = false;
                    }
                    else
                    {
                        btn_cancel.Enabled = true;
                        btn_save.Enabled = true;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = false;
                        chk_pricelvl.Checked = false;
                        //txt_IDX.Enabled = false;

                    }
                    break;
                case xEnums.PerformanceType.Default:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        btn_save.Enabled = false;
                        btn_cancel.Enabled = false;
                        dataGridView1.Enabled = true;
                        txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = dtAllMenuItems.boolModify;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        dataGridView1.Enabled = true;
                        txt_IDX.Enabled = true;
                    }


                    break;
                case xEnums.PerformanceType.Cancel:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = true;
                        txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = true;
                        txt_IDX.Enabled = true;

                    }
                    break;
            }

        }

        #endregion

        #region buttons Click events

        private void btn_new_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.New);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Edit);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Delete);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Print);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Cancel);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            performButtons(xEnums.PerformanceType.Save);
        }

        #endregion

        #region performButtons Area

        private void performButtons(xEnums.PerformanceType xenum)
        {

            switch (xenum)
            {
                case xEnums.PerformanceType.View:

                    if (ActiveControl.Name.Trim() == txt_IDX.Name.Trim())
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

                    break;

                case xEnums.PerformanceType.New:
                    FunctionButtonStatus(xEnums.PerformanceType.New);
                    //txt_IDX.Text = commonFunctions.GetSerial("A0009");
                    formMode = 1;

                    txt_subcat_name.Text = "";
                    txt_subcat.Text = "";
                    txt_suppliername.Text = "";
                    txt_categoryName.Text = "";
                    txt_ReorderLevel.Text = "0";
                    txt_ReorderQTY.Text = "0";
                    txt_UnitPrice.Text = "0.00";
                    txt_CostPrice.Text = "0.00";
                    txt_Brand.Text = "";
                    txt_Unitx.Text = "";
                    txt_Suplier.Text = "";
                    txt_Model.Text = "";
                    txt_Category.Text = "";
                    txt_Make.Text = "";
                    txt_PrintName.Text = "";
                    txt_SellingPrice.Text = "0.00";
                    txt_IDX.Text = "";
                    txt_Namex.Text = "";

                    dtx.Clear();
                    dataGridView2.Refresh();

                    txt_IDX.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Edit:
                    FunctionButtonStatus(xEnums.PerformanceType.Edit);
                    formMode = 3;
                    txt_IDX.Enabled = false;
                    txt_Namex.Focus();
                    errorProvider1.Clear();
                    break;

                case xEnums.PerformanceType.Save:
                    if (txt_IDX.Text.Trim() == "")
                    {

                        errorProvider1.SetError(txt_IDX, "Please enter a product code !");
                        return;
                    }


                    if (txt_Namex.Text.Trim() == "")
                    {
                        errorProvider1.SetError(txt_Namex, "Please enter a product name !");
                        return;
                    }

                     if (!M_CategoryDL.ExistingM_Category(txt_Category.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_Category, "The category code you have entered is not exists!");
                            return;
                        }

                        if (!M_SubCategoryDL.ExistingM_SubCategory(txt_Category.Text.Trim(), txt_subcat.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_subcat, "The sub category code you have entered is not exists!");
                            return;
                        }

                        if (!M_SupplierDL.ExistingM_Supplier(txt_Suplier.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_suppliername, "The supplier code you have entered is not exists!");
                            return;
                        }


                    if (formMode == 1)
                    {
                        if (M_ProductDL.ExistingM_Product(txt_IDX.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_IDX, "The Product code you have entered already exists!");
                            return;
                        }
                       

                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {

                            using (var scope = new System.Transactions.TransactionScope())
                            {
                                //adding the product 
                                M_Products objm_Product = new M_Products();
                                objm_Product.IDX = txt_IDX.Text.Trim();
                                objm_Product.Compcode = commonFunctions.GlobalCompany; //txt_Compcode.Text.Trim();
                                objm_Product.Locacode = commonFunctions.GlobalLocation;//txt_Locacode.Text.Trim();
                                objm_Product.Namex = txt_Namex.Text.Trim();
                                objm_Product.PrintName = txt_PrintName.Text.Trim();
                                objm_Product.UnitPrice = commonFunctions.ToDecimal(txt_UnitPrice.Text.Trim());
                                objm_Product.SellingPrice = commonFunctions.ToDecimal(txt_SellingPrice.Text.Trim());
                                objm_Product.CostPrice = commonFunctions.ToDecimal(txt_CostPrice.Text.Trim());
                                objm_Product.Category = txt_Category.Text.Trim();
                                objm_Product.Make = txt_Make.Text.Trim();
                                objm_Product.Model = txt_Model.Text.Trim();
                                objm_Product.Brand = txt_Brand.Text.Trim();
                                objm_Product.Color = "";//txt_Color.Text.Trim();
                                objm_Product.Unitx = txt_Unitx.Text.Trim();
                                objm_Product.Suplier = txt_Suplier.Text.Trim();
                                objm_Product.ReorderQTY = commonFunctions.ToDecimal(txt_ReorderQTY.Text.Trim());
                                objm_Product.ReorderLevel = commonFunctions.ToDecimal(txt_ReorderLevel.Text.Trim());
                                objm_Product.LockItem = txt_LockItem.Checked;
                                objm_Product.MaxDisc = decimal.Zero;
                                objm_Product.MinDisc = decimal.Zero;
                                objm_Product.ApplyingDisc = decimal.Zero;
                                objm_Product.FrezzItem = false;
                                objm_Product.DiscountAllowed = false;
                                objm_Product.SalesCommAllowed = false;
                                objm_Product.NegativeQTY = false;
                                objm_Product.VatApplicable = false;
                                objm_Product.Norefundable = true;
                                objm_Product.OpenPrice = false;
                                objm_Product.StockLot = false;
                                objm_Product.WholesalePrice = commonFunctions.ToDecimal(txt_UnitPrice.Text.Trim());
                                objm_Product.isOpenPrice = false;
                                objm_Product.IsActive = false;
                                objm_Product.IsMaintainStockLot = chk_pricelvl.Checked;
                                objm_Product.SupplierWarrenty = decimal.Zero;
                                objm_Product.CustomerWarrenty = decimal.Zero;
                                objm_Product.CommissionAmount = decimal.Zero;
                                objm_Product.CommissionPer = decimal.Zero;
                                objm_Product.CreateUser = commonFunctions.Loginuser;
                                objm_Product.CreateDate = DateTime.Now;
                                objm_Product.ModifyUser = commonFunctions.Loginuser;
                                objm_Product.ModifyDate = DateTime.Now;
                                objm_Product.SubCategory = txt_subcat.Text;
                                objm_Product.AutoIndex = 0;
                                M_ProductDL bal = new M_ProductDL();
                                bal.SaveM_ProductSP(objm_Product, 1);
                                //commonFunctions.IncrementSerial("A0009");

                                foreach (DataGridViewRow drow in dataGridView2.Rows)
                                {
                                    if (drow.Cells[0].Value.ToString().Trim() != null)
                                    {
                                        M_Product_Has_Parts objm_CushasAgent = new M_Product_Has_Parts();
                                        objm_CushasAgent.PartId = drow.Cells[0].Value.ToString();
                                        objm_CushasAgent.productId = txt_IDX.Text;
                                        objm_CushasAgent.triggerVal = 1;
                                        new M_Product_Has_PartDL().Savem_Product_Has_PartSP(objm_CushasAgent, 1);
                                    }
                                }



                                scope.Complete();
                            }

                            GetData();

                            txt_IDX.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Save_Sucess_string, 2);
                        }
                    }
                    else if (formMode == 3)
                    {

                        if (!M_CategoryDL.ExistingM_Category(txt_Category.Text.Trim()))
                        {
                            errorProvider1.SetError(txt_Category, "The category code you have entered is not exists!");
                            return;
                        }


                        if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Update, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                        {


                            using (var scope = new System.Transactions.TransactionScope())
                            {

                                M_ProductDL bal4 = new M_ProductDL();

                                M_Products objm_Product_compaire = new M_Products();
                                objm_Product_compaire.IDX = txt_IDX.Text.Trim();
                                objm_Product_compaire = bal4.Selectm_Product(objm_Product_compaire);
                                M_Products objm_Product = new M_Products();
                                objm_Product.IDX = txt_IDX.Text.Trim();
                                objm_Product = bal4.Selectm_Product(objm_Product);

                                objm_Product.IDX = txt_IDX.Text.Trim();
                                objm_Product.Compcode = commonFunctions.GlobalCompany; //txt_Compcode.Text.Trim();
                                objm_Product.Locacode = commonFunctions.GlobalLocation;//txt_Locacode.Text.Trim();
                                objm_Product.Namex = txt_Namex.Text.Trim();
                                objm_Product.PrintName = txt_PrintName.Text.Trim();
                                objm_Product.UnitPrice = commonFunctions.ToDecimal(txt_UnitPrice.Text.Trim());
                                objm_Product.SellingPrice = commonFunctions.ToDecimal(txt_SellingPrice.Text.Trim());
                                objm_Product.CostPrice = commonFunctions.ToDecimal(txt_CostPrice.Text.Trim());
                                objm_Product.Category = txt_Category.Text.Trim();
                                objm_Product.Make = txt_Make.Text.Trim();
                                objm_Product.Model = txt_Model.Text.Trim();
                                objm_Product.Brand = txt_Brand.Text.Trim();
                                objm_Product.Color = "";//txt_Color.Text.Trim();
                                objm_Product.Unitx = txt_Unitx.Text.Trim();
                                objm_Product.Suplier = txt_Suplier.Text.Trim();
                                objm_Product.ReorderQTY = commonFunctions.ToDecimal(txt_ReorderQTY.Text.Trim());
                                objm_Product.ReorderLevel = commonFunctions.ToDecimal(txt_ReorderLevel.Text.Trim());
                                objm_Product.LockItem = txt_LockItem.Checked;//txt_LockItem.Text.Trim();
                                objm_Product.MaxDisc = decimal.Zero;
                                objm_Product.MinDisc = decimal.Zero;
                                objm_Product.ApplyingDisc = decimal.Zero;
                                objm_Product.IsActive = txt_LockItem.Checked;
                                objm_Product.FrezzItem = false;
                                objm_Product.DiscountAllowed = false;
                                objm_Product.SalesCommAllowed = false;
                                objm_Product.NegativeQTY = false;
                                objm_Product.VatApplicable = false;
                                objm_Product.Norefundable = true;
                                objm_Product.OpenPrice = false;
                                objm_Product.StockLot = false;
                                objm_Product.AutoIndex = 0;
                                objm_Product.IsMaintainStockLot = chk_pricelvl.Checked;
                                objm_Product.WholesalePrice = commonFunctions.ToDecimal(txt_UnitPrice.Text.Trim());


                                M_ProductDL bal = new M_ProductDL();
                                bal.SaveM_ProductSP(objm_Product, 3);

                                if ((objm_Product_compaire.CostPrice != objm_Product.CostPrice) || (objm_Product_compaire.SellingPrice != objm_Product.SellingPrice))
                                {

                                    //save data to price change
                                    M_ProductPriceChange objm_ProductPriceChange = new M_ProductPriceChange();
                                    objm_ProductPriceChange.Id = commonFunctions.GetSerial("A0029");
                                    objm_ProductPriceChange.Product = txt_IDX.Text.Trim();
                                    objm_ProductPriceChange.ChangedPlace = "PMS";
                                    objm_ProductPriceChange.Currentcost = objm_Product_compaire.CostPrice;
                                    objm_ProductPriceChange.NewCost = objm_Product.CostPrice;
                                    objm_ProductPriceChange.CurrentSelling = objm_Product_compaire.SellingPrice;
                                    objm_ProductPriceChange.NewSelling = objm_Product.SellingPrice;
                                    objm_ProductPriceChange.Userx = commonFunctions.Loginuser;
                                    objm_ProductPriceChange.Datex = DateTime.Now;
                                    M_ProductPriceChangeDL bal2 = new M_ProductPriceChangeDL();
                                    bal2.SaveM_ProductPriceChangeSP(objm_ProductPriceChange, 1);
                                    commonFunctions.IncrementSerial("A0029");


                                }



                                M_Product_Has_Parts xx = new M_Product_Has_Parts();
                                xx.productId = txt_IDX.Text.Trim();
                                List<M_Product_Has_Parts> agents = new List<M_Product_Has_Parts>();
                                agents = new M_Product_Has_PartDL().SelectM_Product_Has_PartMulti(xx);

                                foreach (M_Product_Has_Parts age in agents)
                                {
                                    new M_Product_Has_PartDL().Savem_Product_Has_PartSP(age, 4);
                                }

                                foreach (DataGridViewRow drow in dataGridView2.Rows)
                                {
                                    if (drow.Cells[0].Value.ToString().Trim() != null)
                                    {
                                        M_Product_Has_Parts objm_CushasAgent = new M_Product_Has_Parts();
                                        objm_CushasAgent.PartId = drow.Cells[0].Value.ToString();
                                        objm_CushasAgent.productId = txt_IDX.Text;
                                        objm_CushasAgent.triggerVal = 1;
                                        new M_Product_Has_PartDL().Savem_Product_Has_PartSP(objm_CushasAgent, 1);
                                    }
                                }
                                scope.Complete();
                            }


                            GetData();
                            txt_IDX.Enabled = true;
                            FunctionButtonStatus(xEnums.PerformanceType.Save);
                            commonFunctions.SetMDIStatusMessage(UserDefineMessages.Msg_Update_Sucess_string, 2);
                        }

                    }
                    break;
                case xEnums.PerformanceType.Cancel:
                    txt_IDX.Enabled = true;
                    FunctionButtonStatus(xEnums.PerformanceType.Default);
                    errorProvider1.Clear();
                    break;
                case xEnums.PerformanceType.Print:
                    if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Prnt, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                    {


                        string reporttitle = "List of All Products".ToUpper();
                        frm_reportViwer rpt = new frm_reportViwer();
                        rpt.MdiParent = MDI_SMartAnything.ActiveForm;
                        rpt.FormHeadertext = reporttitle;

                        ParameterField paramField = new ParameterField();
                        ParameterFields paramFields = new ParameterFields();

                        paramFields = commonFunctions.AddCrystalParams(reporttitle, commonFunctions.Loginuser.ToUpper());

                        string str = "SELECT     dbo.M_Products.IDX, dbo.M_Products.Namex, dbo.M_Products.UnitPrice, dbo.M_Products.CostPrice, dbo.M_Products.SellingPrice, dbo.M_Products.WholesalePrice," +
                       "dbo.M_Products.ApplyingDisc, dbo.M_Suppliers.SupID, dbo.M_Suppliers.suppName, dbo.M_Category.Codex, dbo.M_Category.Descr" +
                        " FROM         dbo.M_Products INNER JOIN dbo.M_Suppliers ON dbo.M_Products.Suplier = dbo.M_Suppliers.SupID INNER JOIN M_Category ON dbo.M_Products.Category = dbo.M_Category.Codex";

                        rpt_m_products rptBank = new rpt_m_products();
                        rptBank.SetDataSource(commonFunctions.GetDatatable(str));
                        rpt.RepViewer.ParameterFieldInfo = paramFields;
                        rpt.RepViewer.ReportSource = rptBank;
                        rpt.RepViewer.Refresh();
                        rpt.Show();
                    }
                    break;


            }

        }
        #endregion

        #region ProcessDialogKey events

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {

                case Keys.Control | Keys.N:
                    performButtons(xEnums.PerformanceType.New);
                    break;
                case Keys.Control | Keys.E:
                    performButtons(xEnums.PerformanceType.Edit);
                    break;
                case Keys.Control | Keys.S:
                    if (formMode == 1 || formMode == 3)
                    {
                        performButtons(xEnums.PerformanceType.Save);
                    }
                    break;
                case Keys.Escape:
                    performButtons(xEnums.PerformanceType.Exit);
                    break;
                case Keys.Control | Keys.P:
                    performButtons(xEnums.PerformanceType.Print);
                    break;
                case Keys.Control | Keys.C:
                    performButtons(xEnums.PerformanceType.Cancel);
                    break;
                case Keys.Control | Keys.D:
                    performButtons(xEnums.PerformanceType.Delete);
                    break;
            }


            return false;
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

       

        #region dataGridView1_RowEnter

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool isnew = dataGridView1.Rows[e.RowIndex].IsNewRow;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                SetValues(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                FindExisitingCategory();
                FindExisitingSupplier();
                FindExisitingsubCategory();
                errorProvider1.Clear();
            }
        }

        #endregion

        #region txt_KeyDown
        private void txt_IDX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                performButtons(xEnums.PerformanceType.View);
                SetValues(txt_IDX.Text.Trim());   
            }
            if (e.KeyCode == Keys.Enter)
            {
                SetValues(txt_IDX.Text.Trim());
                txt_Namex.Focus();
            }
        }

        private void txt_Namex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_PrintName.Focus();
            }
        }

        private void txt_PrintName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Suplier.Focus();
            }
        }

        private void txt_Category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_subcat.Focus();
                txt_categoryName.Text = findExisting.FindExisitingcategory(txt_Category.Text.Trim());
            }
            if (e.KeyCode == Keys.F2) {

                if (ActiveControl.Name.Trim() == txt_Category.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["CategoryFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["CategorySQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["CategoryField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                txt_categoryName.Text = findExisting.FindExisitingcategory(txt_Category.Text.Trim());
            }
        }

        private void txt_Suplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Make.Focus();
                FindExisitingSupplier();
            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_Suplier.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["SupplierFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["SupplierSQL"].ToString();

                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["SupplierField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                FindExisitingSupplier();
            }

        }

        private void txt_Make_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Model.Focus();
            }
        }

        private void txt_Model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Brand.Focus();
            }
        }

        private void txt_Brand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Unitx.Focus();
            }
        }

        private void txt_Unitx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Category.Focus();
            }
        }

        private void txt_CostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_UnitPrice.Focus();
            }
            //txt_UnitPrice.Text = txt_CostPrice.Text;
        }

        private void txt_UnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SellingPrice.Focus();
            }
        }

        private void txt_SellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ReorderQTY.Focus();
            }
        }

        private void txt_ReorderQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ReorderLevel.Focus();
            }
        }

        private void txt_ReorderLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_IDX.Focus();
            }
        }

        private void txt_CostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_SellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_ReorderQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_ReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void button3_Click_1(object sender, EventArgs e)
        {
             string str =   commonFunctions.GetSerial("A0001");
             commonFunctions.IncrementSerial("A0001");


        }

        private void txt_Namex_Validating(object sender, CancelEventArgs e)
        {
            txt_PrintName.Text = txt_Namex.Text.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_Category.Text.Trim() != "" && txt_categoryName.Text.Trim() != "")
            {
                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {

                    if (M_CategoryDL.ExistingM_Category(txt_Category.Text.Trim()))
                    {
                        M_Category cat = new M_Category();
                        cat.Codex = txt_Category.Text.Trim();
                        M_CategoryDL dl = new M_CategoryDL();
                        cat = dl.Selectm_Category(cat);
                        txt_Category.Text = cat.Codex.Trim();
                        txt_categoryName.Text = cat.Descr;
                    }
                    else
                    {

                        M_Category objm_Category = new M_Category();
                        objm_Category.Codex = txt_Category.Text.Trim();
                        objm_Category.Descr = txt_categoryName.Text.Trim();
                        objm_Category.date = DateTime.Now;
                        objm_Category.type = "";
                        objm_Category.Lockedby = "";
                        objm_Category.Locked = false;
                        objm_Category.Userx = commonFunctions.Loginuser; ;
                        M_CategoryDL bal = new M_CategoryDL();
                        bal.SaveM_CategorySP(objm_Category, 1);


                    }

                }
            }
        }

        private void txt_Category_Validating(object sender, CancelEventArgs e)
        {
           // FindExisitingCategory();
        }

        private void FindExisitingCategory() {
            try
            {
                if (M_CategoryDL.ExistingM_Category(txt_Category.Text.Trim()))
                {
                    //txt_Category.Text = "";
                    //txt_categoryName.Text = "";
                    M_Category cat = new M_Category();
                    cat.Codex = txt_Category.Text.Trim();
                    M_CategoryDL dl = new M_CategoryDL();
                    cat = dl.Selectm_Category(cat);
                    txt_Category.Text = cat.Codex.Trim();
                    txt_categoryName.Text = cat.Descr;
                }
                else
                {
                    txt_categoryName.Text = "<Category Not Exists.>";
                }
            }
            catch (Exception ex) { }
        }

        private void FindExisitingsubCategory()
        {
            if (M_SubCategoryDL.ExistingM_SubCategory(txt_Category.Text.Trim(),txt_subcat.Text.Trim()))
            {
                M_SubCategory cat = new M_SubCategory();
                cat.Codex = txt_subcat.Text.Trim();
                cat = new M_SubCategoryDL().Selectm_SubCategory(cat);
                txt_subcat.Text = cat.Codex.Trim();
                txt_subcat_name.Text = cat.Descr;
            }
            else
            {
                txt_categoryName.Text = "<Category Not Exists.>";
            }
        }

        private void FindExisitingSupplier()
        {
            if (M_SupplierDL.ExistingM_Supplier(txt_Suplier.Text.Trim()))
            {
                M_Suppliers cat = new M_Suppliers();
                cat.SupID = txt_Suplier.Text.Trim();
                M_SupplierDL dl = new M_SupplierDL();
                cat = dl.Selectm_Supplier(cat);
                txt_Suplier.Text = cat.SupID.Trim();
                txt_suppliername.Text = cat.suppName.Trim();
            }
            else
            {
                txt_suppliername.Text = "<Supplier Not Exists.>";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_Suplier.Text.Trim() != "" && txt_suppliername.Text.Trim() != "")
            {
                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                {

                    if (M_SupplierDL.ExistingM_Supplier(txt_Suplier.Text.Trim()))
                    {
                        M_Suppliers cat = new M_Suppliers();
                        cat.SupID = txt_Suplier.Text.Trim();
                        M_SupplierDL dl = new M_SupplierDL();
                        cat = dl.Selectm_Supplier(cat);
                        txt_Suplier.Text = cat.SupID.Trim();
                        txt_suppliername.Text = cat.suppName.Trim();
                    }
                    else
                    {


                        M_Suppliers objm_Supplier = new M_Suppliers();
                        objm_Supplier.SupID = txt_Suplier.Text.Trim();
                        objm_Supplier.suppName = txt_suppliername.Text.Trim();
                        objm_Supplier.CompCode = commonFunctions.GlobalCompany;
                        objm_Supplier.Locacode = commonFunctions.GlobalLocation;
                        objm_Supplier.TP = "";
                        objm_Supplier.Fax = "";
                        objm_Supplier.Email = "";
                        objm_Supplier.Address1 = "";
                        objm_Supplier.Address2 = "";
                        objm_Supplier.Address3 = "";
                        objm_Supplier.ContactPerson = "";
                        objm_Supplier.ContactPersonNo = "";
                        objm_Supplier.CurrentStatus = "";
                        M_SupplierDL bal = new M_SupplierDL();
                        bal.SaveM_SupplierSP(objm_Supplier, 1);


                    }

                }
            }
        }

        private void txt_subcat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_CostPrice.Focus();
                txt_subcat_name.Text = findExisting.FindExisitingsubcategory(txt_Category.Text.Trim(), txt_subcat.Text.Trim());
            }
            if (e.KeyCode == Keys.F2)
            {

                if (ActiveControl.Name.Trim() == txt_subcat.Name.Trim())
                {
                    int length = Convert.ToInt32(ConfigurationManager.AppSettings["SUBCategoryFieldLength"]);
                    string[] strSearchField = new string[length];

                    string strSQL = ConfigurationManager.AppSettings["SUBCategorySQL"].ToString() + " FROM dbo.M_SubCategory WHERE (CategoryID = '" + txt_Category.Text.Trim() + "')";
                    for (int i = 0; i < length; i++)
                    {
                        string m;
                        m = i.ToString();
                        strSearchField[i] = ConfigurationManager.AppSettings["SUBCategoryField" + m + ""].ToString();
                    }

                    frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                    find.ShowDialog(this);
                }

                txt_subcat_name.Text = findExisting.FindExisitingsubcategory(txt_Category.Text.Trim(), txt_subcat.Text.Trim());
            }
        }

        private void txt_Category_TextChanged(object sender, EventArgs e)
        {
            txt_categoryName.Text = findExisting.FindExisitingcategory(txt_Category.Text.Trim());
            txt_subcat.Text = "";
        }

        private void txt_subcat_TextChanged(object sender, EventArgs e)
        {
            txt_subcat_name.Text = findExisting.FindExisitingsubcategory(txt_Category.Text.Trim(), txt_subcat.Text.Trim());
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            commonFunctions.GetTextBoxnames(panel3);
        }

        private void txt_agents_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                if (!M_ProductPartDL.ExistingM_ProductPart(txt_agents.Text.Trim()))
                {
                    errorProvider1.SetError(txt_agents, "ProductPart does not exists on the system ");
                    return;
                }


                if (commonFunctions.IsExistINV(dataGridView2, txt_agents.Text))
                {
                    return;
                }
                commonFunctions.AddRowAgents(dtx, txt_agents.Text, txt_agents_name.Text.Trim());
            }

            if (e.KeyCode == Keys.F2)
            {
                int length = Convert.ToInt32(ConfigurationManager.AppSettings["PartsFieldLength"]);
                string[] strSearchField = new string[length];

                string strSQL = ConfigurationManager.AppSettings["PartsSQL"].ToString();

                for (int i = 0; i < length; i++)
                {
                    string m;
                    m = i.ToString();
                    strSearchField[i] = ConfigurationManager.AppSettings["PartsField" + m + ""].ToString();
                }
                frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                find.ShowDialog(this);
            }
        }

        private void txt_IDX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }
    }
}
