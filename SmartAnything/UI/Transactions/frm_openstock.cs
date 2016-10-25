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


namespace SmartAnything.UI.Transactions
{
    public partial class frm_openstock : Form
    {

        int formMode = 0;
        string formID = "A0059";
        string formHeadertext = "Opening Stock";
        DataTable dtx = new DataTable();
        bool already = false;
        bool ismaintainstock = false;


        #region Loading one instance

        private static frm_openstock objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_openstock getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_openstock();

            }
            return objSingleObject;

        }

        #endregion

        public frm_openstock()
        {
            InitializeComponent();
        }

        private void frm_openstock_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = formHeadertext;
                FunctionButtonStatus(xEnums.PerformanceType.Default);
                commonFunctions.HandleTextBoxesInTransactions(panel3);
                commonFunctions.HandleHeaderPanelColor(pnl_header);
                commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, formHeadertext);


                dtx = commonFunctions.CreateDatatableGRN(1);
                dataGridView1.DataSource = dtx;
                commonFunctions.FormatDataGrid(dataGridView1);
                dataGridView1.Columns[0].Width = 120;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[8].Width = 80;
                dataGridView1.Columns[3].Width = 50;

                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;

                txt_code.Focus();
                dataGridView1.AllowUserToAddRows = false;

                txt_locationId.Text = commonFunctions.GlobalLocation;
                txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_locationId.Text.Trim());
                

            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
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
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;

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
                        btn_edit.Enabled = false;
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
                        // dataGridView1.Enabled = false;
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
                        //dataGridView1.Enabled = false;
                        //txt_IDX.Enabled = false;
                    }
                    break;
                case xEnums.PerformanceType.Exit:
                    break;
                case xEnums.PerformanceType.New:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = false;
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
                        //dataGridView1.Enabled = false;
                        //txt_IDX.Enabled = false;

                    }
                    break;
                case xEnums.PerformanceType.Default:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        btn_save.Enabled = false;
                        btn_cancel.Enabled = false;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = true;
                        btn_delete.Enabled = dtAllMenuItems.boolDelete;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = dtAllMenuItems.boolPrint;
                        //dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }


                    break;
                case xEnums.PerformanceType.Cancel:
                    if (dtAllMenuItems.boolCreate == false)
                    {
                        btn_new.Enabled = false;
                        dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;
                    }
                    else
                    {
                        btn_cancel.Enabled = false;
                        btn_save.Enabled = false;
                        btn_new.Enabled = false;
                        btn_delete.Enabled = false;
                        btn_edit.Enabled = false;
                        btn_print.Enabled = false;
                        dataGridView1.Enabled = true;
                        //txt_IDX.Enabled = true;

                    }
                    break;
            }

        }

        #endregion

        #region performButtons Area

        private void performButtons(xEnums.PerformanceType xenum)
        {

            try
            {
                switch (xenum)
                {
                    case xEnums.PerformanceType.View:
                        if (ActiveControl.Name.Trim() == txt_grnno.Name.Trim())
                        {
                            int length = Convert.ToInt32(ConfigurationManager.AppSettings["GrnRecallFieldLength"]);
                            string[] strSearchField = new string[length];

                            string strSQL = ConfigurationManager.AppSettings["GrnRecallSQL"].ToString();

                            for (int i = 0; i < length; i++)
                            {
                                string m;
                                m = i.ToString();
                                strSearchField[i] = ConfigurationManager.AppSettings["GrnRecallField" + m + ""].ToString();
                            }

                            frmU_Search find = new frmU_Search(strSQL, strSearchField, this);
                            find.ShowDialog(this);
                        }

                        break;

                    case xEnums.PerformanceType.New:
                        FunctionButtonStatus(xEnums.PerformanceType.New);
                        formMode = 1;
                        txt_grnno.Text = commonFunctions.GetSerial(formID.Trim());
                        txt_grnno.Focus();

                        txt_locationId.Text = commonFunctions.GlobalLocation;
                        txt_locationId_name.Text = findExisting.FindExisitingLoca(txt_locationId.Text.Trim());

                        errorProvider1.Clear();

                        lbl_processes.Visible = false;
                        break;

                    case xEnums.PerformanceType.Edit:
                        FunctionButtonStatus(xEnums.PerformanceType.Edit);

                        formMode = 3;
                        //txt_VehicleID.Enabled = false;
                        //txt_VehicleNo.Focus();
                        errorProvider1.Clear();
                        break;

                    case xEnums.PerformanceType.Save:
                        errorProvider1.Clear();
                        if (formMode == 1)
                        {

                            //if (!M_SupplierDL.ExistingM_Supplier(txt_supplierId.Text.Trim()))
                            //{
                            //    errorProvider1.SetError(txt_supplierId, "Selected supplier does not exists on the system ");
                            //    commonFunctions.SetMDIStatusMessage("Selected supplier does not exists on the system .", 1);
                            //    return;
                            //}

                            if (commonFunctions.GetNoofItems(dataGridView1) <= 0)
                            {
                                errorProvider1.SetError(dataGridView1, "Please enter some items to the details grid");
                                commonFunctions.SetMDIStatusMessage("Please enter some items to the details grid.", 1);
                                return;
                            }

                            if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Save, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                            {


                                T_OpenStkHead objt_OpenStkHead = new T_OpenStkHead();
                                objt_OpenStkHead.Docno = txt_grnno.Text.Trim();
                                objt_OpenStkHead.locationId = txt_locationId.Text.Trim();
                                objt_OpenStkHead.date = dte_date.Value;
                                objt_OpenStkHead.supplier = "";
                                objt_OpenStkHead.remarks = txt_remarks.Text.Trim();
                                objt_OpenStkHead.grossAmount = commonFunctions.ToDecimal(txt_grossAmount.Text.Trim());
                                objt_OpenStkHead.netAmount = commonFunctions.ToDecimal(txt_net.Text.Trim());
                                objt_OpenStkHead.isSaved = false;
                                objt_OpenStkHead.isProcessed = false;
                                objt_OpenStkHead.processDate = DateTime.Now;
                                objt_OpenStkHead.processUser = "";
                                objt_OpenStkHead.GLUpdate = false;
                                objt_OpenStkHead.triggerVal = 1;
                                T_OpenStkHeadDL bal = new T_OpenStkHeadDL();
                                bal.Savet_OpenStkHeadSP(objt_OpenStkHead, 1);
                                commonFunctions.IncrementSerial(formID);

                                //save details 
                                List<T_Stock_open> grnDets = new List<T_Stock_open>();
                                foreach (DataGridViewRow drow in dataGridView1.Rows)
                                {
                                    if (drow.Cells["Product Code"].Value.ToString().Trim() != null)
                                    {
                                        T_Stock_open objt_Stock = new T_Stock_open();
                                        M_Products pro = new M_Products();
                                        pro.IDX = drow.Cells["Product Code"].Value.ToString();
                                        pro = new M_ProductDL().Selectm_Product(pro);
                                        objt_Stock.DocNo = txt_grnno.Text.Trim();
                                        objt_Stock.Compcode = commonFunctions.GlobalCompany;
                                        objt_Stock.Locacode = commonFunctions.GlobalLocation;
                                        objt_Stock.Suppid = pro.Suplier;
                                        objt_Stock.ProductId = pro.IDX;
                                        objt_Stock.Stock = commonFunctions.ToInt(drow.Cells["Quntity"].Value.ToString()); 
                                        objt_Stock.OpnStock = commonFunctions.ToInt(drow.Cells["Quntity"].Value.ToString()); 
                                        objt_Stock.InitialStock = decimal.Zero;
                                        objt_Stock.ReservedStock = decimal.Zero;
                                        objt_Stock.CostPrice = commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString()); 
                                        objt_Stock.SellingPrice = pro.SellingPrice;
                                        objt_Stock.WholeSalePrice = pro.SellingPrice;
                                        objt_Stock.MrpPrice = pro.SellingPrice;
                                        objt_Stock.CompanyPrice = pro.SellingPrice;
                                        objt_Stock.AvgCost = pro.CostPrice;
                                        objt_Stock.InitialCost = pro.CostPrice;
                                        objt_Stock.Descr = pro.Namex;
                                        objt_Stock.FixedGP = decimal.Zero;
                                        objt_Stock.SIH = decimal.Zero;
                                        objt_Stock.EXPDate = DateTime.Now;
                                        objt_Stock.Usercode = commonFunctions.Loginuser;
                                        objt_Stock.DateCr = DateTime.Now;
                                        string PriceLvlIndex = "";
                                        if (M_ProductDL.GetMaintainStockLot(drow.Cells["Product Code"].Value.ToString()))
                                        {
                                            if (pro.IsMaintainStockLot.Value)
                                                PriceLvlIndex = "1";
                                            else
                                                PriceLvlIndex = "1";
                                            objt_Stock.StockCode = drow.Cells["Product Code"].Value.ToString().Trim() + "-" + PriceLvlIndex;
                                        }
                                        else
                                        {
                                            int maxID = Convert.ToInt32(M_ProductDL.getMaxStockCode(objt_Stock.ProductId.ToString(), commonFunctions.GlobalLocation));
                                            maxID++;
                                            objt_Stock.StockCode = drow.Cells["Product Code"].Value.ToString().Trim() + "-" + maxID.ToString();
                                        }


                                        new T_Stock_openDL().Savet_Stock_openSP(objt_Stock, 1);
                                    }
                                }
                                //save the grn 
                                //if (new T_grnDL().Savet_grnSP(objt_grn, grnDets, 1, formID))
                                //{
                                //    commonFunctions.SetMDIStatusMessage("GRN saved successfully.", 2);
                                //}

                                UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Save_Sucess, commonFunctions.Softwarename.Trim());

                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    StockUpdate();

                                    T_OpenStkHead objt_grn_Process = new T_OpenStkHead();
                                    objt_grn_Process.Docno = txt_grnno.Text.Trim();
                                    objt_grn_Process = new T_OpenStkHeadDL().Selectt_OpenStkHead(objt_grn_Process);

                                    objt_grn_Process.isProcessed = true;
                                    objt_grn_Process.processDate = DateTime.Now;
                                    objt_grn_Process.processUser = commonFunctions.Loginuser;
                                    new T_OpenStkHeadDL().Savet_OpenStkHeadSP(objt_grn_Process, 3);


                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());

                                }


                                //clear data in data grid 
                                dtx.Rows.Clear();
                                dataGridView1.Refresh();
                                //clear text fields
                                textareaFunctions(true);

                                FunctionButtonStatus(xEnums.PerformanceType.Save);
                                //increment the serial
                                txt_grnno.Text = commonFunctions.GetSerial(formID.Trim());
                                
                            }
                        }
                        else if (formMode == 3)
                        {

                            T_OpenStkHead objt_grn_Process = new T_OpenStkHead();
                            objt_grn_Process.Docno = txt_grnno.Text.Trim();
                            objt_grn_Process = new T_OpenStkHeadDL().Selectt_OpenStkHead(objt_grn_Process);
                            if (objt_grn_Process.isProcessed == false)
                            {
                                if (UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_PerfmBtn_Process, commonFunctions.Softwarename.Trim()) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    UpdateStock();
                                    objt_grn_Process.isProcessed = true;
                                    objt_grn_Process.processDate = DateTime.Now;
                                    objt_grn_Process.processUser = commonFunctions.Loginuser;
                                    new T_OpenStkHeadDL().Savet_OpenStkHeadSP(objt_grn_Process, 3);
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());


                                    //clear data in data grid 
                                    dtx.Rows.Clear();
                                    dataGridView1.Refresh();
                                    //clear text fields
                                    textareaFunctions(true);
                                    FunctionButtonStatus(xEnums.PerformanceType.Save);

                                    txt_grnno.Text = commonFunctions.GetSerial(formID.Trim());
                                    UserDefineMessages.ShowMsg("", UserDefineMessages.Msg_Update_Sucess, commonFunctions.Softwarename.Trim());
                                    

                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txt_grnno, "GRN Number you have entered already processed.");
                                commonFunctions.SetMDIStatusMessage("GRN Number you have entered already processed.", 1);
                            }
                        }
                        break;
                    case xEnums.PerformanceType.Cancel:
                        txt_grnno.Enabled = true;
                        FunctionButtonStatus(xEnums.PerformanceType.Default);
                        errorProvider1.Clear();
                        //clear text fields
                        textareaFunctions(true);
                        //clear Datagrid
                        dtx.Clear();
                        dataGridView1.Refresh();

                     

                        lbl_processes.Visible = false;

                        break;
                    case xEnums.PerformanceType.Print:
                        UserDefineMessages.ShowMsg1("Print still in process", UserDefineMessages.Msg_Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on updating data", 1);
            }
        }


        private void UpdateStockxx()
        {
            try
            {
                T_Stock_open detg = new T_Stock_open();
                detg.DocNo = txt_grnno.Text.Trim();
                List<T_Stock_open> grndets = new List<T_Stock_open>();
                grndets = new T_Stock_openDL().SelectT_Stock_openMulti(detg);

                foreach (T_Stock_open det in grndets)
                {
                    M_Products pro = new M_Products();
                    pro.IDX = det.ProductId;
                    pro = new M_ProductDL().Selectm_Product(pro);
                    string stockcode = "";
                    int x = pro.AutoIndex.Value;
                    x += 1;
                    stockcode = commonFunctions.GetStockCode(det.ProductId, x.ToString("0000"));
                    if (T_StockDL.ExistingT_Stock_new(stockcode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {

                        if (pro.IsMaintainStockLot == true)
                        {
                            //{
                            //    pricelevelindexstr = det.priceLevel;
                            //}
                            //stockcode = det.productId + "-" + pricelevelindexstr.Trim();
                        }
                        else
                        {
                            //int x = pro.AutoIndex.Value;
                            //x += 1;
                            //stockcode = commonFunctions.GetStockCode(det.ProductId, x.ToString("0000"));
                            pro.AutoIndex += 1;
                            new M_ProductDL().SaveM_ProductSP(pro, 3);
                        }

                        T_Stock objt_Stock = new T_Stock();
                        objt_Stock.StockCode = stockcode;
                        if (T_StockDL.ExistingT_Stock_new(stockcode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                        {
                            objt_Stock = new T_StockDL().Selectt_Stock_ByStockCode(objt_Stock);
                            objt_Stock.Stock += det.Stock;
                            objt_Stock.OpnStock = det.Stock;
                            objt_Stock.CostPrice = det.CostPrice;
                            objt_Stock.SellingPrice = det.SellingPrice;
                            objt_Stock.WholeSalePrice = det.SellingPrice;
                            objt_Stock.MrpPrice = det.SellingPrice;
                            objt_Stock.CompanyPrice = det.SellingPrice;
                            objt_Stock.AvgCost = det.CostPrice;
                            objt_Stock.InitialCost = det.CostPrice;
                            objt_Stock.Descr = pro.Namex;
                            objt_Stock.FixedGP = decimal.Zero;
                            objt_Stock.SIH = decimal.Zero;
                            objt_Stock.EXPDate = DateTime.Now;
                            objt_Stock.Usercode = commonFunctions.Loginuser;
                            objt_Stock.DateCr = DateTime.Now;
                            T_StockDL bal = new T_StockDL();
                            bal.SaveT_StockSP(objt_Stock, 3,1);
                        }
                        else
                        {
                            objt_Stock.Compcode = commonFunctions.GlobalCompany;
                            objt_Stock.Locacode = commonFunctions.GlobalLocation;
                            objt_Stock.Suppid = pro.Suplier;
                            objt_Stock.ProductId = det.ProductId;
                            objt_Stock.Stock = det.Stock;
                            objt_Stock.OpnStock = decimal.Zero;
                            objt_Stock.InitialStock = decimal.Zero;
                            objt_Stock.ReservedStock = decimal.Zero;
                            objt_Stock.CostPrice = det.CostPrice;
                            objt_Stock.SellingPrice = det.SellingPrice;
                            objt_Stock.WholeSalePrice = det.SellingPrice;
                            objt_Stock.MrpPrice = det.SellingPrice;
                            objt_Stock.CompanyPrice = det.SellingPrice;
                            objt_Stock.AvgCost = det.CostPrice;
                            objt_Stock.InitialCost = det.CostPrice;
                            objt_Stock.Descr = pro.Namex;
                            objt_Stock.FixedGP = decimal.Zero;
                            objt_Stock.SIH = decimal.Zero;
                            objt_Stock.EXPDate = DateTime.Now;
                            objt_Stock.Usercode = commonFunctions.Loginuser;
                            objt_Stock.DateCr = DateTime.Now;
                            T_StockDL bal = new T_StockDL();
                            bal.SaveT_StockSP(objt_Stock, 1,1);
                        }

                    }//if stock code not exists



                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }

        }


        public void StockUpdate()
        {
            try
            {
                T_Stock objStock = new T_Stock();
                T_Stock_open detg = new T_Stock_open();
                detg.DocNo = txt_grnno.Text.Trim();
                List<T_Stock_open> lstGRNDetail = new List<T_Stock_open>();
                lstGRNDetail = new T_Stock_openDL().SelectT_Stock_openMulti(detg);
            
                for (int i = 0; i < lstGRNDetail.Count; i++)
                {
                    //objStock.strStockCode=lstGRNDetail[i].strStockCode;
                    //intAvailableStock = (objStockBL.getExistingStockDetails(objStock)).intStock;
                    M_Products pro = new M_Products();
                    pro.IDX = lstGRNDetail[i].ProductId;
                    pro = new M_ProductDL().Selectm_Product(pro);

                    objStock.StockCode = lstGRNDetail[i].StockCode;
                    objStock.Locacode = commonFunctions.GlobalLocation;
                    objStock.ProductId = lstGRNDetail[i].ProductId;
                    objStock.Suppid = pro.Suplier;
                    objStock.Compcode = commonFunctions.GlobalCompany;
                    objStock.OpnStock = decimal.Zero;
                    objStock.InitialStock = decimal.Zero;
                    objStock.ReservedStock = decimal.Zero;
                    objStock.CostPrice = lstGRNDetail[i].CostPrice;
                    objStock.SellingPrice = lstGRNDetail[i].SellingPrice;
                    objStock.WholeSalePrice = lstGRNDetail[i].SellingPrice;
                    objStock.MrpPrice = lstGRNDetail[i].SellingPrice;
                    objStock.CompanyPrice = lstGRNDetail[i].SellingPrice;
                    objStock.InitialCost = lstGRNDetail[i].CostPrice;
                    objStock.Descr = pro.Namex;
                    objStock.FixedGP = decimal.Zero;
                    objStock.EXPDate = DateTime.Now;
                    objStock.Usercode = commonFunctions.Loginuser;
                    objStock.DateCr = DateTime.Now;
                    objStock.SellingPrice = lstGRNDetail[i].SellingPrice;
                    objStock.CostPrice = lstGRNDetail[i].CostPrice;

                    if (T_StockDL.ExistingT_Stock_new(objStock.StockCode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation) == false)
                    {
                        objStock.AvgCost = lstGRNDetail[i].CostPrice;
                        objStock.Stock = lstGRNDetail[i].Stock;
                        new T_StockDL().SaveT_StockSP(objStock, 1, 1);
                    }
                    else
                    {
                        objStock = new T_StockDL().Selectt_Stock_ByStockCode(objStock);
                        decimal intStock = decimal.Parse(objStock.Stock.ToString());
                        decimal decCostPrice = decimal.Parse(objStock.CostPrice.ToString());
                        decimal decPresentCost = intStock * decCostPrice;
                        decimal decNewCost = lstGRNDetail[i].CostPrice.Value * lstGRNDetail[i].Stock.Value;
                        decimal intAllStock = intStock + lstGRNDetail[i].Stock.Value;
                        objStock.AvgCost = (decPresentCost + decNewCost) / intAllStock;
                        objStock.Stock += lstGRNDetail[i].Stock;
                        new T_StockDL().SaveT_StockSP(objStock, 3, 1);
                    }
                }

            }
            catch (Exception ex)
            {

                // Globals.generateErrorMsg(ex.Message.ToString(), "StockUpdate");
                LogFile.WriteErrorLog("StockUpdate", "frmT_GReceivedNote", ex.Message.ToString());
                Globals.generateCommonErrorMsg();

            }

        }


        private void UpdateStock()
        {

            try
            {
                T_Stock_open detg = new T_Stock_open();
                detg.DocNo = txt_grnno.Text.Trim();
                List<T_Stock_open> grndets = new List<T_Stock_open>();
                grndets = new T_Stock_openDL().SelectT_Stock_openMulti(detg);

                foreach (T_Stock_open det in grndets)
                {
                    T_Stock objt_Stock = new T_Stock();
                    objt_Stock.StockCode = det.StockCode;
                    objt_Stock.Compcode = commonFunctions.GlobalCompany;
                    objt_Stock.Locacode = commonFunctions.GlobalLocation;

                    M_Products pro = new M_Products();
                    pro.IDX = det.ProductId;
                    pro = new M_ProductDL().Selectm_Product(pro);
                    //string stockcode = "";

                    /*
                     A LOGIC HAS TO IMPLEMENT HERE IS,
                     * IF (commonFunctions.Maintainstocklot == true)
                     * THEN HAS TO DO A LOT OF THINGS
                     * IF IT WAS FALSE
                     * THEN ... THERE IS ONE STOCK CODE FOR EVERY PRODUCT AND 
                     * AVARAGE COST METHOD MUST IMPLEMENT
                 
                     */
                    if (T_StockDL.ExistingT_Stock_new(det.StockCode, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {
                        objt_Stock = new T_StockDL().Selectt_Stock_ByStockCode(objt_Stock);

                        if (pro.IsMaintainStockLot.Value)
                        {
                           

                            ////objt_Stock.StockCode = stockcode;
                            //objt_Stock.Compcode = commonFunctions.GlobalCompany;
                            //objt_Stock.Locacode = commonFunctions.GlobalLocation;
                            //objt_Stock.Suppid = pro.Suplier;
                            //objt_Stock.ProductId = det.ProductId;
                            //objt_Stock.Stock = det.Stock;
                            //objt_Stock.OpnStock = decimal.Zero;
                            //objt_Stock.InitialStock = decimal.Zero;
                            //objt_Stock.ReservedStock = decimal.Zero;
                            //objt_Stock.CostPrice = det.CostPrice;
                            //objt_Stock.SellingPrice = det.SellingPrice;
                            //objt_Stock.WholeSalePrice = det.SellingPrice;
                            //objt_Stock.MrpPrice = det.SellingPrice;
                            //objt_Stock.CompanyPrice = det.SellingPrice;
                            //objt_Stock.AvgCost = det.CostPrice;
                            //objt_Stock.InitialCost = det.CostPrice;
                            //objt_Stock.Descr = pro.Namex;
                            //objt_Stock.FixedGP = decimal.Zero;
                            //objt_Stock.SIH = decimal.Zero;
                            //objt_Stock.EXPDate = DateTime.Now;
                            //objt_Stock.Usercode = commonFunctions.Loginuser;
                            //objt_Stock.DateCr = DateTime.Now;
                            //T_StockDL bal = new T_StockDL();
                            //bal.SaveT_StockSP(objt_Stock, 1, 1);
                        }
                        else
                        {
                           

                            //calculating avarage cost;
                            decimal commingtot = det.CostPrice.Value * det.Stock.Value;
                            objt_Stock.AvgCost = GetAvaragecost(objt_Stock.Stock.Value, objt_Stock.CostPrice.Value, commingtot, det.Stock.Value);

                            objt_Stock.Stock += det.Stock;
                            objt_Stock.OpnStock = decimal.Zero;
                            objt_Stock.InitialStock = decimal.Zero;
                            objt_Stock.ReservedStock = decimal.Zero;
                            objt_Stock.CostPrice = det.CostPrice;
                            objt_Stock.SellingPrice = det.SellingPrice;
                            objt_Stock.WholeSalePrice = det.SellingPrice;
                            objt_Stock.MrpPrice = det.SellingPrice;
                            objt_Stock.CompanyPrice = det.SellingPrice;
                            objt_Stock.InitialCost = det.CostPrice;
                            objt_Stock.Descr = pro.Namex;
                            objt_Stock.FixedGP = decimal.Zero;
                            objt_Stock.EXPDate = DateTime.Now;
                            objt_Stock.Usercode = commonFunctions.Loginuser;
                            objt_Stock.DateCr = DateTime.Now;
                            T_StockDL bal = new T_StockDL();
                            bal.SaveT_StockSP(objt_Stock, 3, 1);
                        }
                    }
                    else
                    {

                        //objt_Stock.StockCode = stockcode;
                        objt_Stock.Compcode = commonFunctions.GlobalCompany;
                        objt_Stock.Locacode = commonFunctions.GlobalLocation;
                        objt_Stock.Suppid = pro.Suplier;
                        objt_Stock.ProductId = det.ProductId;
                        objt_Stock.Stock = det.Stock;
                        objt_Stock.OpnStock = decimal.Zero;
                        objt_Stock.InitialStock = decimal.Zero;
                        objt_Stock.ReservedStock = decimal.Zero;
                        objt_Stock.CostPrice = det.CostPrice;
                        objt_Stock.SellingPrice = det.SellingPrice;
                        objt_Stock.WholeSalePrice = det.SellingPrice;
                        objt_Stock.MrpPrice = det.SellingPrice;
                        objt_Stock.CompanyPrice = det.SellingPrice;
                        objt_Stock.AvgCost = det.CostPrice;
                        objt_Stock.InitialCost = det.CostPrice;
                        objt_Stock.Descr = pro.Namex;
                        objt_Stock.FixedGP = decimal.Zero;
                        objt_Stock.SIH = decimal.Zero;
                        objt_Stock.EXPDate = DateTime.Now;
                        objt_Stock.Usercode = commonFunctions.Loginuser;
                        objt_Stock.DateCr = DateTime.Now;
                        T_StockDL bal = new T_StockDL();
                        bal.SaveT_StockSP(objt_Stock, 1, 1);
                    }





                    pro.CostPrice = det.CostPrice;
                    new M_ProductDL().SaveM_ProductSP(pro, 3);


                }
            }
            catch (Exception ex)
            {

                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on loading data", 1);
            }
        }


        private decimal GetAvaragecost(decimal curentstock, decimal cucost, decimal comingtotal, decimal comingqty)
        {
            decimal currentamt = curentstock * cucost;
            decimal figure = (currentamt + comingtotal) / (curentstock + comingqty);
            figure = decimal.Round(figure, 2);
            return figure;
        }

        #endregion

        #region textareaFunctions
        private void textareaFunctions(bool stype)
        {
            if (stype == true)
            {
                //txt_supplierId.Text = "";
                //txt_supplierId_name.Text = "";
                txt_remarks.Text = "";
                txt_locationId.Text = "";
                txt_locationId_name.Text = "";
                txt_net.Text = "0.00";
                dte_date.Value = DateTime.Now;

                txt_code.Text = "";
                txt_cost.Text = "0.00";
                txt_selling.Text = "0.00";
                txt_qty.Text = "0.00";
                txt_amt.Text = "0.00";

                //txt_supplierId.Enabled = true;
                //txt_remarks.Enabled = true;
                //txt_reqLocationId.Enabled = true;
                //txt_DLocationID.Enabled = true;
                //dte_date.Enabled = true;
                //dte_DeliveryDate.Enabled = true;

                dataGridView1.Enabled = true;
            }
            else
            {
                //txt_supplierId.Enabled = false;
                //txt_remarks.Enabled = false;
                //txt_reqLocationId.Enabled = false;
                //txt_DLocationID.Enabled = false;
                //dte_date.Enabled = false;
                //dte_DeliveryDate.Enabled = false;

                dataGridView1.Enabled = false;

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
                    txt_pricelevel.Text = "";
                    if (T_StockDL.ExistingT_Stock_Product(txt_code.Text, commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
                    {
                        if (!commonFunctions.IsExist(dataGridView1, txt_code.Text))
                        {
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk = new M_ProductDL().Selectm_Product(stk);

                            txt_cost.Text = stk.CostPrice.ToString();
                            txt_selling.Text = stk.SellingPrice.ToString();
                            lbl_name.Text = stk.Namex;


                            if (stk.IsMaintainStockLot == true)
                            {
                                ismaintainstock = true;
                                txt_pricelevel.ReadOnly = false;
                                lbl_stocklot.Visible = true; 
                                txt_qty.Focus();
                                //txt_pricelevel.Focus();
                            }
                            else
                            {
                                ismaintainstock = false;
                                txt_pricelevel.ReadOnly = true;
                                lbl_stocklot.Visible = false;
                                txt_qty.Text = "0";
                                txt_qty.Focus();
                            }
                            errorProvider1.Clear();
                            already = false;
                        }
                        else
                        {
                            already = true;
                            M_Products stk = new M_Products();
                            stk.Locacode = commonFunctions.GlobalLocation;
                            stk.Compcode = commonFunctions.GlobalCompany;
                            stk.IDX = txt_code.Text;
                            stk = new M_ProductDL().Selectm_Product(stk);

                            txt_cost.Text = stk.CostPrice.ToString();
                            txt_selling.Text = stk.SellingPrice.ToString();
                            lbl_name.Text = stk.Namex;

                            if (stk.IsMaintainStockLot == true)
                            {
                                ismaintainstock = true;
                                txt_pricelevel.ReadOnly = false;
                                lbl_stocklot.Visible = true;
                                txt_qty.Focus();
                            }
                            else
                            {
                                ismaintainstock = false;
                                txt_pricelevel.ReadOnly = true;
                                lbl_stocklot.Visible = false;
                                txt_qty.Focus();
                            }

                            DataGridViewRow drowx = new DataGridViewRow();
                            drowx = commonFunctions.GetRow(dataGridView1, txt_code.Text.Trim());

                            txt_qty.Text = drowx.Cells["Quntity"].Value.ToString();
                            txt_qty.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txt_code, "Product you have entered not exist in the bin card");
                    }
                }
                catch (Exception ex)
                {
                    LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                    commonFunctions.SetMDIStatusMessage("Genaral Error", 1);
                }
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal x = commonFunctions.ToDecimal(txt_qty.Text.Trim());
                if (x > 0)
                {
                    txt_cost.Focus();
                }
                else
                {
                    errorProvider1.SetError(txt_qty, "Please enter quntity");
                }
            }

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
                                decimal totamt = commonFunctions.ToDecimal(txt_cost.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                txt_amt.Text = totamt.ToString();
                                commonFunctions.AddRowGrn(dtx, txt_code.Text, lbl_name.Text.Trim(), txt_pricelevel.Text, "0", txt_cost.Text.Trim(), txt_selling.Text.Trim(), txt_qty.Text.Trim(), txt_amt.Text.Trim(), "0", "0");
                                txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, "0.00", "0.00").ToString();
                                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();
                                txt_code.Focus();
                            }
                            else
                            {
                                decimal totamt = commonFunctions.ToDecimal(txt_cost.Text.Trim()) * commonFunctions.ToDecimal(txt_qty.Text.Trim());
                                txt_amt.Text = totamt.ToString();
                                commonFunctions.AddRowtogridGRN(dataGridView1, txt_code.Text.Trim(), txt_qty.Text.Trim(), totamt.ToString(), "0.00");
                                txt_net.Text = commonFunctions.GetNetAmountGRn(dataGridView1, "0.00", "0.00").ToString();
                                txt_grossAmount.Text = commonFunctions.GetGrossAmount(dataGridView1).ToString();

                                txt_code.Focus();
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_qty, "Please enter quntity");
                            commonFunctions.SetMDIStatusMessage("Please enter quntity", 1);
                        }

                    }

                }
                else
                {
                    txt_amt.Text = "0.00";

                }


                txt_code.Focus();

            }

        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_grnno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                txt_locationId.Focus();
            }
        }

        private void txt_locationId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                dte_date.Focus();
            }
        }

        private void dte_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                txt_remarks.Focus();
            }
        }

        private void txt_remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                txt_code.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "DD_WHT001-0001";
            string xxx = str.Substring(str.IndexOf('-')+1, 4);
            int x = commonFunctions.ToInt(xxx);
            x += 1;
            string stockcode = commonFunctions.GetStockCode("ENC000001", x.ToString("0000"));

        }

    }
}
