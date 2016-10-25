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
using Microsoft.VisualBasic;
using System.Globalization;

namespace SmartAnything
{
    public partial class commonFunctions
    {

        public enum MessageType
        {
            Error = 0,
            Message = 1,
            Exclamation = 2,
        }

        private static string softwarename = "Smart Dissdftribution System";
        private static string loginuser = "Admin";
        
        private static string globalCompany = "0";
        private static string globalLocation = "0";
        private static string gloDiscountmethod = "ITM";
        private static decimal glodreditperiod = 60;
        private static decimal gloinvoiceDiscrate = decimal.Parse("7.5");
        private static bool maintainstocklot = false;

        public static bool Maintainstocklot
        {
            get { return commonFunctions.maintainstocklot; }
            set { commonFunctions.maintainstocklot = value; }
        }


        public static decimal GloinvoiceDiscrate
        {
            get { return commonFunctions.gloinvoiceDiscrate; }
            set { commonFunctions.gloinvoiceDiscrate = value; }
        }

        public static decimal Glodreditperiod
        {
            get { return commonFunctions.glodreditperiod; }
            set { commonFunctions.glodreditperiod = value; }
        }

        public static string GloDiscountmethod
        {
            get { return commonFunctions.gloDiscountmethod; }
            set { commonFunctions.gloDiscountmethod = value; }
        }

        public static string GlobalLocation
        {
            get { return commonFunctions.globalLocation; }
            set { commonFunctions.globalLocation = value; }
        }

        public static string GlobalCompany
        {
            get { return commonFunctions.globalCompany; }
            set { commonFunctions.globalCompany = value; }
        }

        public static string Loginuser
        {
            get { return commonFunctions.loginuser; }
            set { commonFunctions.loginuser = value; }
        }

        public static string Softwarename
        {
            get { return softwarename; }
            set { softwarename = value; }
        }

        public static void SetMDIStatusMessage(string message , int type) {
            try
            {
                MDI_SMartAnything mdi = (MDI_SMartAnything)MDI_SMartAnything.ActiveForm;
                mdi.CountEr = 0;
                mdi.type = type;
                //mdi.tbl_status.Text = message;
                mdi.Errormessagepoper(message);
            }
            catch (Exception ex) {
                //throw ex;
            }
        }



        public static string GetStockCode(string productId, string pricelevelindexstr)
        {
            return productId.Trim() + "-" + pricelevelindexstr.Trim();
        }

        /// <summary>
        /// This funtion will Encript and Decript the password
        /// </summary>
        /// <param name="blnEncrypt"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static  string CreateCheckPassword(bool blnEncrypt, string strPassword)
        {
            try
            {
                string strHold = "";

                if (blnEncrypt == true) //ENCRYPT > EG : SAMAN :- ~@&@
                {
                    for (int intI = 1; intI <= strPassword.Length; intI++)
                    {
                        strHold = strHold + Strings.Chr(Strings.Asc(strPassword.Substring(intI - 1, 1)) + 96 + intI);
                    }
                }
                else //DECRYPT > EG : ~@&@ :- SAMAN 
                {

                    for (int intI = 1; intI < strPassword.Length; intI++)
                    {
                        strHold = strHold + Strings.Chr(Strings.Asc(strPassword.Substring(intI, 1)) - 96 - intI);
                    }
                }
                return strHold;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public static u_UserRights_DL GetUserRightObj(string formID, string user)
        {
            u_UserRights objUserRight = new u_UserRights();
            objUserRight.User = new u_User();
            objUserRight.MenuTag = new u_MenuTag();
            objUserRight.User.strUserID = Globals.g_strUser;
            objUserRight.MenuTag.strMenuID = formID.Trim();

            u_UserRights_DL objURightDL = new u_UserRights_DL();
            u_UserRights_DL dtAllMenuItems = objURightDL.GetUserRightsForOneMenu(objUserRight);

            return dtAllMenuItems;
        }



        public static void LoadDefault() {
            try
            {
                Softwarename = ConfigurationManager.AppSettings["softwarename"];
                GlobalCompany = ConfigurationManager.AppSettings["GlobalCompany"];
                GlobalLocation = ConfigurationManager.AppSettings["GlobalLocation"];
                Loginuser = ConfigurationManager.AppSettings["LoginUser"];
            }
            catch (Exception ex) {

                Softwarename = "Smart Distribution System";
                GlobalCompany = "001";
                GlobalLocation = "001";
                Loginuser = "Admin";
            }
        }

        public static ParameterFields AddCrystalParams(string reportTitle , string loginuser)
        {

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "strCompanyName";
            paramDiscreteValue.Value = new M_CompanyDL().SelectCompany(commonFunctions.GlobalCompany).Descr.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "strCompanyAddress";
            paramDiscreteValue.Value = new M_CompanyDL().SelectCompany(commonFunctions.GlobalCompany).Add1.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "strTitle";
            paramDiscreteValue.Value = reportTitle.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "strUser";
            paramDiscreteValue.Value = loginuser.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            return paramFields;
        }

        public static ParameterFields AddCrystalParamsWithLoca(string reportTitle, string loginuser,string loca,string locaname)
        {

            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            

            paramField.Name = "strCompanyName";
            paramDiscreteValue.Value = new M_CompanyDL().SelectCompany(commonFunctions.GlobalCompany).Descr;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "strCompanyAddress";
            paramDiscreteValue.Value = new M_CompanyDL().SelectCompany(commonFunctions.GlobalCompany).Add1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "strTitle";
            paramDiscreteValue.Value = reportTitle.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "strUser";
            paramDiscreteValue.Value = loginuser.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);


            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Locacode";
            paramDiscreteValue.Value = loca.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);


            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "LocaName";
            paramDiscreteValue.Value = locaname.ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            return paramFields;
        }

        #region FormatDataGrid

        public static void FormatDataGrid(DataGridView dataGridView)
        { 
            dataGridView.BackgroundColor = Color.FromArgb(242, 242, 242);
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersHeight = 20;
            dataGridView.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowHeadersVisible = false;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;


            dataGridView.DefaultCellStyle.Font = new Font("Calibri", 9);

            dataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 119, 174);

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 68, 68);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255,255,255);

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.AllowUserToAddRows = false;
        }

        #endregion

         //dt.Columns.Add("Product Code");
         //       dt.Columns.Add("Product Name");
         //       dt.Columns.Add("Cost Price");
         //       dt.Columns.Add("Selling Price");
         //       dt.Columns.Add("Quntity");
         //       dt.Columns.Add("Amount");

        #region Styling the form Control

        public static void HandleTextBoxes(Panel containerx)
        {

            foreach (var control in containerx.Controls.OfType<TextBox>())
            {
                control.Font = new Font("Calibri", 9);
                control.BorderStyle = BorderStyle.FixedSingle;
                control.BackColor = Color.FromArgb(217, 229, 242);

            }
        }

        public static void HandleTextBoxesInTransactions(Panel containerx)
        {

            foreach (var control in containerx.Controls.OfType<TextBox>())
            {
                control.Font = new Font("Calibri", 8);
                control.BorderStyle = BorderStyle.FixedSingle;
                control.BackColor = Color.FromArgb(255,255,255);

            }
        }

        public static void HandleHeaderPanelColor(Panel containerx)
        {

            //containerx.BackColor = Color.FromArgb(88, 155,225);
            containerx.BackColor = Color.FromArgb(43, 87, 154);
            
        }

        public static void ChangeHeaderTextAndColor(Label containerx,string Headertext)
        {

            //containerx.ForeColor = Color.FromArgb(15, 68, 123);
            containerx.ForeColor = Color.FromArgb(250, 250, 255);
            containerx.Text = Headertext.ToUpper().Trim();

        }

        public static void setFormProperties(Form frm)
        {
            applyTheme(frm);
            frm.BringToFront();
        }

        public static void applyTheme(Form frm)
        {
            frm.Left = 0;
            frm.Top = 0;
            frm.Width = 1024;
            frm.Height = 768;
            frm.BackColor = Color.FromArgb(231, 245, 235);

            foreach (Form form in frm.MdiParent.MdiChildren)
            {
                if (form != frm.MdiParent.ActiveMdiChild)
                {
                    form.Dock = DockStyle.Fill;
                    form.AutoScroll = true;
                }
                else
                {
                    frm.Dock = DockStyle.Fill;
                    frm.AutoScroll = true;
                }
            }
            foreach (Control c in frm.Controls)
            {
                if (c is Panel && c.Name == "hederPanel")
                {
                    c.Left = 0;
                    c.Top = 0;
                    c.Width = frm.MdiParent.Width;
                    c.Height = 76;
                    c.BackColor = Color.FromArgb(39, 174, 96);
                }
            }
        }

        #endregion

        #region ToDecimal

        public static decimal ToDecimal(string str) {
            decimal decGrossAmount = decimal.Zero;

            if (decimal.TryParse(str,out decGrossAmount) == true )
            {
                decGrossAmount = decimal.Parse(str);
            }

            return decimal.Round(decGrossAmount, 4); 
        }

        #endregion

        #region ToInt

        public static int ToInt(string str)
        {
            decimal decGrossAmount = 0;
            if (decimal.TryParse(str, out decGrossAmount) == true)
            {
                decGrossAmount = decimal.Parse(str);
            }
            decGrossAmount = decimal.Round(decGrossAmount, 0);

            int returnx = 0;
            if (int.TryParse(decGrossAmount.ToString(), out returnx) == true)
            {
                returnx = int.Parse(decGrossAmount.ToString());
                
            }
            return returnx;
        }
        #endregion

        #region Serial Increment and Serial No functions

        /// <summary>
        /// Get the 4 method specific serials
        /// 1.	Entirely system generated only digit serial numbers
        /// 2.	System generated formatted serial numbers
        /// 3.	Entirely manual serial numbers 
        /// 4.	location and prefix specific serial numbers
        /// </summary>
        /// <param name="screenname">Screen Name Like A0001</param>
        /// <returns></returns>
        public static string GetSerial(string screenname)
        {
            string strserial = string.Empty;

            P_AutoNumberDL pal = new P_AutoNumberDL();
            P_AutoNumber pauto = new P_AutoNumber();
            pauto.Screen = screenname;
            pauto = pal.Selectp_AutoNumber(pauto);

            if (pauto.Mode == 1)
            {
                decimal dec = (decimal)pauto.Serial;
                dec += 1;
                strserial = dec.ToString("0000000000");
            }
            else if (pauto.Mode == 2)
            {
                decimal dec = (decimal)pauto.Serial;
                dec += 1;
                strserial = dec.ToString("0000000000");
                strserial = pauto.Prefix.Trim() + "-" + strserial;
            }
            else if (pauto.Mode == 3)
            {
                strserial = "";
            }
            else if (pauto.Mode == 4)
            {
                decimal dec = (decimal)pauto.Serial;
                dec += 1;
                strserial = dec.ToString("0000000000");
                strserial = pauto.Prefix.Trim() + "-" + commonFunctions.GlobalLocation.Trim().ToUpper() +  "-" + strserial;
            }
            return strserial;

        }
        public static string GetSerial(string screenname,string loca , string form)
        {
            string strserial = string.Empty;

            P_AutoNumberDL pal = new P_AutoNumberDL();
            P_AutoNumber pauto = new P_AutoNumber();
            pauto.Screen = screenname;
            pauto = pal.Selectp_AutoNumber(pauto);
            decimal dec = (decimal)pauto.Serial;
            dec += 1;
            strserial = dec.ToString("00000000");

            strserial = form.Trim().ToUpper() + "-" + loca.Trim() + "-" + strserial;

            return strserial;

        }


        public static void IncrementSerial(string screenname)
        {
            P_AutoNumberDL pal = new P_AutoNumberDL();
            P_AutoNumber pauto = new P_AutoNumber();
            pauto.Screen = screenname;
            pauto = pal.Selectp_AutoNumber(pauto);
            pauto.Serial += 1;
            pal.SaveP_AutoNumberSP(pauto, 3);
        }

        #endregion

        #region DataGrid Fucntionalities and methods

        /// <summary>
        /// Thit function will initiate a data table to hold the tempary data
        /// </summary>
        /// <param name="typex">1 - Normal 2 - with discount</param>
        /// <returns></returns>
        public static DataTable CreateDatatable(int typex)
        {
            DataTable dt = new DataTable();
            if (typex == 1)
            {
                dt.Columns.Add("Product Code");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Cost Price");
                dt.Columns.Add("Selling Price");
                dt.Columns.Add("Quntity");
                dt.Columns.Add("Amount");
            }
            else {
                dt.Columns.Add("Product Code");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Cost Price");
                dt.Columns.Add("Selling Price");
                dt.Columns.Add("Discount%");
                dt.Columns.Add("Discount");
                dt.Columns.Add("Quntity");
                dt.Columns.Add("Amount");
            }
            return dt;
        }

        /// <summary>
        /// Thit function will initiate a data table to hold the tempary data
        /// </summary>
        /// <param name="typex">1 - Normal 2 - with discount</param>
        /// <returns></returns>
        public static DataTable CreateDatatableGRN(int typex)
        {
            DataTable dt = new DataTable();
            if (typex == 1)
            {
                dt.Columns.Add("Product Code");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Price Level");
                dt.Columns.Add("SIH");
                dt.Columns.Add("Quntity");
                dt.Columns.Add("Free Quntity");
                dt.Columns.Add("Cost Price");
                dt.Columns.Add("Discount%");
                dt.Columns.Add("Tax");
                dt.Columns.Add("Batch No");
                dt.Columns.Add("Selling Price");
                dt.Columns.Add("Amount");
            }
            else
            {
                dt.Columns.Add("Product Code");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Price Level");
                dt.Columns.Add("SIH");
                dt.Columns.Add("Quntity");
                dt.Columns.Add("Free Quntity");
                dt.Columns.Add("Cost Price");
                dt.Columns.Add("Discount%");
                dt.Columns.Add("Tax");
                dt.Columns.Add("Batch No");
                dt.Columns.Add("Selling Price");
                dt.Columns.Add("Amount");
            }
            return dt;
        }
        public static DataTable CreateDatatableDIstribution()
        {
            DataTable dt = new DataTable();
                dt.Columns.Add("Product Code");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Cost Price");
                dt.Columns.Add("Selling Price");
                dt.Columns.Add("Quntity");
                dt.Columns.Add("Disc%");
                dt.Columns.Add("Disc Amt");
                dt.Columns.Add("Amount");
            return dt;
        }
        public static DataTable CreateDatatableAgents()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            return dt;
        }
        public static DataTable CreateDatatableRecipt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("Description");
            dt.Columns.Add("TotalAmt");
            dt.Columns.Add("Amount");
            dt.Columns.Add("CQ No");
            dt.Columns.Add("Bank");
            dt.Columns.Add("Branch");
            dt.Columns.Add("Date");
            return dt;
        }

        public static DataTable CreateDatatableSettlement()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Invoice NO");
            dt.Columns.Add("Due Amt");
            dt.Columns.Add("Paid Amt");
            dt.Columns.Add("Inv Amt");
            dt.Columns.Add("Settlement");
            return dt;
        }

        public static DataTable CreateDatatableDO()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product Code");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Quntity");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Carton");
            dt.Columns.Add("IsCNItem");
            dt.Columns.Add("CNNo");
            return dt;
        }

        public static DataTable CreateDatatableINV()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PamentType");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Inv Amount");
            return dt;
        }

        public static DataTable CreateDatatableDIstributionApproval()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Document No");
            dt.Columns.Add("Net Total");
            return dt;
        }


        public static DataTable CreateDatatablePacking()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Do Number");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Cartons");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Customer Name");
            dt.Columns.Add("Agent");
            dt.Columns.Add("Agent Name");
            
            return dt;
        }

        public static DataTable CreateDatatableSalesCustItem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SalesMan");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Item");
            dt.Columns.Add("QTY");
            dt.Columns.Add("Date From");
            dt.Columns.Add("Date TO");
            

            return dt;
        }

        public static DataTable CreateDatatableCN()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product Code");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("INV QTY");
            dt.Columns.Add("C/N QTY");
            return dt;
        }

        public static DataTable CreateDatatableCNGroup()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product Code");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("QTY");
            return dt;
        }

    

        public static DataTable CreateDatatableCNGroup2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product Code");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("CN Type");
            dt.Columns.Add("Reason");
            dt.Columns.Add("CN QTY");
            dt.Columns.Add("QTY");
            dt.Columns.Add("Tag NO");
            return dt;
        }

        #region AddRowDistribute , AddRow ,AddRowGrn

        //DataTable dt = new DataTable();
        //    dt.Columns.Add("SalesMan");
        //    dt.Columns.Add("Customer");
        //    dt.Columns.Add("Item");
        //    dt.Columns.Add("QTY");
        //    dt.Columns.Add("Date From");
        //    dt.Columns.Add("Date TO");
            

        //    return dt;
  
        public static void AddRowCNGrouping(DataTable dtx, string code, string namex, string Cntype, string reason, string CNQty, string QTY, string Tag)
        {
            DataRow drow = dtx.NewRow();
            drow["Product Code"] = code;
            drow["Product Name"] = namex;
            drow["CN Type"] = Cntype;
            drow["Reason"] = reason;
            drow["CN QTY"] = CNQty;
            drow["QTY"] = QTY;
            drow["Tag NO"] = Tag;
            dtx.Rows.Add(drow);
        }

        public static void AddRowSales_custome_item(DataTable dtx, string salesman, string customer, string item, string qty, string datefrom, string dateto)
        {
            DataRow drow = dtx.NewRow();
            drow["SalesMan"] = salesman;
            drow["Customer"] = customer;
            drow["Item"] = item;
            drow["QTY"] = qty;
            drow["Date From"] = datefrom;
            drow["Date TO"] = dateto;
            dtx.Rows.Add(drow);
        }

        public static void AddRowDistribute(DataTable dtx, string code, string namex, string costp, string sellingp, string Qty,string discper,string disc ,string amt)
        {
            DataRow drow = dtx.NewRow();
            drow["Product Code"] = code;
            drow["Product Name"] = namex;
            drow["Cost Price"] = costp;
            drow["Selling Price"] = sellingp;
            drow["Quntity"] = Qty;
            drow["Disc%"] = discper;
            drow["Disc Amt"] = disc;
            drow["Amount"] = amt;
            dtx.Rows.Add(drow);
        }

        public static void AddRow(DataTable dtx, string code, string namex, string costp, string sellingp, string aty, string amt)
        {

            DataRow drow = dtx.NewRow();
            drow["Product Code"] = code;
            drow["Product Name"] = namex;
            drow["Cost Price"] = costp;
            drow["Selling Price"] = sellingp;
            drow["Quntity"] = aty;
            drow["Amount"] = amt;

            dtx.Rows.Add(drow);
        }

        public static void AddRowGrn(DataTable dtx, string code, string namex, string pricelevel,string SIH, string costp, string sellingp, string Qty, string amt,string freeqty,string disc)
        {

            DataRow drow = dtx.NewRow();
            drow["Product Code"] = code;
            drow["Product Name"] = namex;
            drow["Price Level"] = pricelevel;
            drow["SIH"] = SIH;
            drow["Quntity"] = Qty;
            drow["Free Quntity"] = freeqty;
            drow["Cost Price"] = costp;
            drow["Discount%"] = disc;
            drow["Tax"] = "";
            drow["Batch No"] = "";
            drow["Selling Price"] = sellingp;
            drow["Amount"] = amt;


            dtx.Rows.Add(drow);
        }

        public static void AddRowDO(DataTable dtx, string code, string namex, string QTY, string Unit, string cartons, string IsCNItem, string CNNo)
        {
            DataRow drow = dtx.NewRow();
            drow["Product Code"] = code;
            drow["Product Name"] = namex;
            drow["Quntity"] = QTY;
            drow["Unit"] = Unit;
            drow["Carton"] = cartons;
            drow["IsCNItem"] = IsCNItem;
            drow["CNNo"] = CNNo;
            
            dtx.Rows.Add(drow);
        }

        public static void AddRowCreditNote(DataTable dtx, string code, string namex, string invQTY, string CNQTY)
        {
            DataRow drow = dtx.NewRow();
            drow["Product Code"] = code;
            drow["Product Name"] = namex;
            drow["INV QTY"] = invQTY;
            drow["C/N QTY"] = CNQTY;
            dtx.Rows.Add(drow);
        }

            //        DataTable dt = new DataTable();
            //dt.Columns.Add("Agent Code");
            //dt.Columns.Add("Agent Name");
            //return dt;

        public static void AddRowCreditNoteGrouping(DataTable dtx, string code, string namex,  string CNQTY)
        {
            DataRow drow = dtx.NewRow();
            drow["Product Code"] = code;
            drow["Product Name"] = namex;
            drow["QTY"] = CNQTY;
            dtx.Rows.Add(drow);
        }

        public static void AddRowAgents(DataTable dtx, string code, string namex)
        {
            DataRow drow = dtx.NewRow();
            drow["Code"] = code;
            drow["Name"] = namex;
            dtx.Rows.Add(drow);
        }



            //dt.Columns.Add("CQ No");
            //dt.Columns.Add("Bank");
            //dt.Columns.Add("Branch");
            //dt.Columns.Add("Date");

        public static void AddRowReciptCal(DataTable dtx, string PaymentType, string Description, string TotalAmt, string Amount, string CQno, string bankx, string bbracnh, string datex)
        {
            DataRow drow = dtx.NewRow();
            drow["Type"] = PaymentType;
            drow["Description"] = Description;
            drow["TotalAmt"] = TotalAmt;
            drow["Amount"] = Amount;

            drow["CQ No"] = CQno;
            drow["Bank"] = bankx;
            drow["Branch"] = bbracnh;
            drow["Date"] = datex;
            dtx.Rows.Add(drow);
        }
       
        public static void AddRowPacking(DataTable dtx, string donumber, string customer, string agent, string amount, string customername, string agentname,string ttlcartons)
        {
            DataRow drow = dtx.NewRow();
            drow["Do Number"] = donumber;
            drow["Customer"] = customer;
            drow["Customer Name"] = customername;
            drow["Agent"] = agent;
            drow["Agent Name"] = agentname;
            drow["Amount"] = amount;
            drow["Cartons"] = ttlcartons;
            dtx.Rows.Add(drow);
        }

        public static void AddRowINVPayment(DataTable dtx, string paymenttype, string partamt, string totamt)
        {
            DataRow drow = dtx.NewRow();
            drow["PamentType"] = paymenttype;
            drow["Amount"] = partamt;
            drow["Inv Amount"] = totamt;
            dtx.Rows.Add(drow);
        }

        //DataTable dt = new DataTable();
        //    dt.Columns.Add("Invoice NO");
        //    dt.Columns.Add("Due Amt");
        //    dt.Columns.Add("Paid Amt");
        //    dt.Columns.Add("Inv Amt");
        //    dt.Columns.Add("Settlement");
        //    return dt;

        public static void AddRowLoadInvoices(DataTable dtx, string InvoiceNO, string DueAmt, string PaidAmt, string InvAmt, string Settlement)
        {
            DataRow drow = dtx.NewRow();
            drow["Invoice NO"] = InvoiceNO;
            drow["Due Amt"] = DueAmt;
            drow["Paid Amt"] = PaidAmt;
            drow["Inv Amt"] = InvAmt;
            drow["Settlement"] = Settlement;
            dtx.Rows.Add(drow);
        }

        #endregion

        #region IsExist

        public static bool IsExist(DataGridView dataGridView1, string codex)
        {
            bool exx = false;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                
                if (drow.Cells["Product Code"].Value != null)
                {
                    string s = drow.Cells["Product Code"].Value.ToString().Trim().ToUpper();
                    if (drow.Cells["Product Code"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        exx = true;
                    }
                }
            }
            return exx;
        }
        public static bool IsExistINV(DataGridView dataGridView1, string codex)
        {
            bool exx = false;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[0].Value != null)
                {
                    string s = drow.Cells[0].Value.ToString().Trim().ToUpper();
                    if (drow.Cells[0].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        exx = true;
                    }
                }
            }
            return exx;
        }

        public static bool IsExistCommon(DataGridView dataGridView1, string field, string valuetocheck)
        {
            bool exx = false;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[field].Value != null)
                {
                    string s = drow.Cells[field].Value.ToString().Trim().ToUpper();
                    if (drow.Cells[field].Value.ToString().Trim().ToUpper() == valuetocheck.Trim().ToUpper())
                    {
                        exx = true;
                    }
                }
            }
            return exx;
        }

        #endregion

        #region AddRowtogrid , AddRowtogridGRN ,AddRowtogridDistribute

        public static void AddRowtogridAlloc(DataGridView dataGridView1, string earchfield ,  string codex, string qty, string amt, string dicper, string disc)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[earchfield].Value != null)
                {
                    if (drow.Cells[earchfield].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        drow.Cells["SalesMan"].Value = qty;
                        drow.Cells["Customer"].Value = amt;
                        drow.Cells["Item"].Value = codex;
                        drow.Cells["QTY"].Value = disc;
                        drow.Cells["Date From"].Value = disc;
                        drow.Cells["Date TO"].Value = disc;
                    }
                }
            }
        }

         //drow["SalesMan"] = salesman;
         //   drow["Customer"] = customer;
         //   drow["Item"] = item;
         //   drow["QTY"] = qty;
         //   drow["Date From"] = datefrom;
         //   drow["Date TO"] = dateto;

        public static void AddRowtogrid(DataGridView dataGridView1, string codex, string qty, string amt)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Product Code"].Value != null)
                {
                    if (drow.Cells["Product Code"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        drow.Cells["Quntity"].Value = qty;
                        drow.Cells["Amount"].Value = amt;
                    }
                }
            }
        }

        public static void UpdateRowtogridINVPAY(DataGridView dataGridView1, string codex, string Payamt, string totamt)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["PamentType"].Value != null)
                {
                    if (drow.Cells["PamentType"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        drow.Cells["Amount"].Value = Payamt;
                        drow.Cells["Inv Amount"].Value = totamt;
                    }
                }
            }
        }

        public static void AddRowtogridGRN(DataGridView dataGridView1, string codex, string qty, string amt,string sic)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Product Code"].Value != null)
                {
                    if (drow.Cells["Product Code"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        drow.Cells["Quntity"].Value = qty;
                        drow.Cells["Amount"].Value = amt;
                        drow.Cells["Discount%"].Value = sic;
                    }
                }
            }
        }

        public static void AddRowtogridDistribute(DataGridView dataGridView1, string codex, string qty, string amt, string dicper,string disc)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Product Code"].Value != null)
                {
                    if (drow.Cells["Product Code"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        drow.Cells["Quntity"].Value = qty;
                        drow.Cells["Amount"].Value = amt;
                        drow.Cells["Disc%"].Value = dicper;
                        drow.Cells["Disc Amt"].Value = disc;
                    }
                }
            }
        }

        public static void AddRowtogridCN(DataGridView dataGridView1, string codex, string name, string Invqty,string qty)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Product Code"].Value != null)
                {
                    if (drow.Cells["Product Code"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        drow.Cells["Product Name"].Value = name;
                        drow.Cells["INV QTY"].Value = Invqty;
                        drow.Cells["C/N QTY"].Value = qty;
                    }
                }
            }
        }

     
        public static void AddRowtogridDO(DataGridView dataGridView1, string codex, string unit, string carton)
        {

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Product Code"].Value != null)
                {
                    if (drow.Cells["Product Code"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        drow.Cells["Unit"].Value = unit;
                        drow.Cells["Carton"].Value = carton;
                    }
                }
            }
        }
        #endregion

        #region GetRow

        public static DataGridViewRow GetRow(DataGridView dataGridView1, string codex)
        {
            DataGridViewRow drowreturn = new DataGridViewRow();
            bool exx = false;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Product Code"].Value != null)
                {
                    string s = drow.Cells["Product Code"].Value.ToString().Trim().ToUpper();
                    if (drow.Cells["Product Code"].Value.ToString().Trim().ToUpper() == codex.Trim().ToUpper())
                    {
                        exx = true;
                        drowreturn = drow;
                    }
                }
            }
            if (exx == true)
            {
                return drowreturn;
            }
            return drowreturn;
        }

        #endregion

        #region GetGrossAmount

        public static decimal GetGrossAmount(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {
                    decimal dx = ToDecimal(drow.Cells["Amount"].Value.ToString());
                    total += dx;
                }
            }
            return total;
        }

        #endregion

        #region GetNetAmount , GetNetAmountWIthDisc ,GetNetAmountGRn

        public static decimal GetCumTotal(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[0].Value != null)
                {
                    total += commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                }
            }
            return total;
        }


        public static decimal GetNetAmount(DataGridView dataGridView1,string deducts, string additions)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {
                    total += commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                }
            }
            return (total - commonFunctions.ToDecimal(deducts)) + commonFunctions.ToDecimal(additions);
        }

        public static decimal GetNetAmountWIthDisc(DataGridView dataGridView1, string deducts, string additions,string totdisc)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {
                    total += commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                }
            }
            return ((total - commonFunctions.ToDecimal(deducts)) + commonFunctions.ToDecimal(additions)) - commonFunctions.ToDecimal(totdisc);
        }

        public static decimal GetNetAmountGRn(DataGridView dataGridView1, string deducts, string additions)
        {
            decimal total = decimal.Zero;
            decimal totaldic = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {
                    total += commonFunctions.ToDecimal(drow.Cells["Amount"].Value.ToString());
                }
            }

            totaldic += GetTotalDisc(dataGridView1);
            return ((total - commonFunctions.ToDecimal(deducts))  +  commonFunctions.ToDecimal(additions)) - totaldic;
        }

        #endregion

        #region GetTotalDisc ,GetTotalDiscDistribute

        public static decimal GetTotalDisc(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Amount"].Value != null)
                {
                    
                    decimal dx = commonFunctions.ToDecimal(drow.Cells["Discount%"].Value.ToString());
                    decimal amt = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString()) * commonFunctions.ToDecimal(drow.Cells["Cost Price"].Value.ToString());
                    decimal dic = (amt * dx) / 100;
                    total += dic;
                }
            }
            return total;
        }


         public static decimal GetTotalDiscDistribute(DataGridView dataGridView1)
         {
             decimal total = decimal.Zero;
             foreach (DataGridViewRow drow in dataGridView1.Rows)
             {
                 if (drow.Cells["Amount"].Value != null)
                 {

                     decimal dx = commonFunctions.ToDecimal(drow.Cells["Disc%"].Value.ToString());
                     decimal amt = commonFunctions.ToDecimal(drow.Cells["Quntity"].Value.ToString()) * commonFunctions.ToDecimal(drow.Cells["Selling Price"].Value.ToString());
                     decimal dic = (amt * dx) / 100;
                     total += dic;
                 }
             }
             return total;
         }

        #endregion

        #region GetNoofPices , GetNoofItems

        public static decimal GetNoofPices(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Quntity"].Value != null)
                {
                    decimal dx = ToDecimal(drow.Cells["Quntity"].Value.ToString());
                    total += dx;
                }
            }
            return total;
        }

        public static decimal GetNoofItems(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["Quntity"].Value != null)
                {
                    total += 1;
                }
            }
            return total;
        }
        public static decimal GetNoofItemsIndexBase(DataGridView dataGridView1)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[0].Value != null)
                {
                    total += 1;
                }
            }
            return total;
        }
        public static decimal GetNoofItems(DataGridView dataGridView1,int mode)
        {
            decimal total = decimal.Zero;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells[0].Value != null)
                {
                    total += 1;
                }
            }
            return total;
        }

        #endregion

        public static string GetProcutCode(string productText)
        {
            string str = "";
            try
            {
                if (productText.Length == 8)
                {
                    str = productText;
                }
                else
                {
                    decimal dec = decimal.Zero;
                    dec = commonFunctions.ToDecimal(productText.Trim());
                    str = dec.ToString("00000000");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }


        #endregion

        #region FormatDate

        public static DateTime FormatDate(DateTime Value)
        {
            try
            {
                return DateTime.Parse(string.Format("{0:dd/MM/yyyy}", Value));
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        public static DateTime FormatDateTime(DateTime Value)
        {
            try
            {
                return DateTime.Parse(string.Format("{0:dd/MM/yyyy hh:mm:ss}", Value));
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        #endregion

        public static DataTable GetDatatable(string strquery)
        {
            try
            {
                DataTable dtm_Customer = u_DBConnection.ReturnDataTable(strquery, CommandType.Text);
                return dtm_Customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region validate Machine date time format
        public static bool ValidateMachineDateTimeFromat()
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            string[] SystemDateTimePatterns = new string[250];
            int i = 0;

            foreach (string name in dtfi.GetAllDateTimePatterns('d'))
            {
                SystemDateTimePatterns[i] = name;
                i++;
            }

            string[] myDateTimeFormat = { "dd/MM/yyyy" };
            if (!myDateTimeFormat[0].Equals(SystemDateTimePatterns[0]))
            {
                MessageBox.Show("Your Machine DateTime Format is: " + SystemDateTimePatterns[0] + ".\n" + "Required DateTime Format is: dd/MM/yyyy. \nPlease Change the Datetime Format.", "System Datetime Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        public  static List<Control> GetAllControls(Control container)
        {
            List<Control> ControlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                ControlList.Add(c);
                GetAllControls(c);
                //if (c is TextBox) 
            }
            return ControlList;
        }


        public static  void GetTextBoxnames(Control conx)
        {
            string path = @"D:\Out.txt";
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.Create(path);
            }
            System.IO.StreamWriter sr = new System.IO.StreamWriter(path);
            sr.Flush();
            List<Control> cons = commonFunctions.GetAllControls(conx);

            foreach (Control con in cons)
            {
                if (con is TextBox)
                {
                    sr.WriteLine(con.Name + @".Text = "";");
                }
            }
            sr.Close();
        }
    }
}
