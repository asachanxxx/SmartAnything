using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartAnything;
using SmartAnything_DL;
using smartOffice_Models;
using System.Configuration;


namespace SmartAnything
{
    public class findExisting
    {


        public static string FindExisitingLoca(string locacode)
        {
            string str = "";
            if (M_LocaDL.ExistingM_Loca(locacode.Trim()))
            {
                M_Loca cat = new M_Loca();
                cat.Locacode = locacode.Trim();
                M_LocaDL dl = new M_LocaDL();
                cat = dl.Selectm_Loca(cat);
                str = cat.Locaname;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingDriver(string locacode)
        {
            string str = "";
            if (M_EmployeeDL.ExistingM_Employee(locacode.Trim()))
            {
                M_Employees cat = new M_Employees();
                cat.EmpID = locacode.Trim();
                M_EmployeeDL dl = new M_EmployeeDL();
                cat = dl.Selectm_Employee(cat);
                str = cat.Name;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

      
        public static string FindExisitingProduct(string locacode)
        {
            string str = "";
            if (M_ProductDL.ExistingM_Product(locacode.Trim()))
            {
                M_Products cat = new M_Products();
                cat.IDX = locacode.Trim();
                M_ProductDL dl = new M_ProductDL();
                cat = dl.Selectm_Product(cat);
                str = cat.Namex;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingSupplier(string suppcode)
        {
            string str = "";
            if (M_SupplierDL.ExistingM_Supplier(suppcode.Trim()))
            {
                M_Suppliers cat = new M_Suppliers();
                cat.SupID = suppcode.Trim();
                M_SupplierDL dl = new M_SupplierDL();
                cat = dl.Selectm_Supplier(cat);
                str = cat.suppName;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingCUstomer(string suppcode)
        {
            string str = "";
            if (M_CustomerDL.ExistingM_Customer(suppcode.Trim()))
            {
                M_Customers cat = new M_Customers();
                cat.CusID = suppcode.Trim();
                M_CustomerDL dl = new M_CustomerDL();
                cat = dl.Selectm_Customer(cat);
                str = cat.CustName;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingCustomerCategory(string suppcode)
        {
            string str = "";
            if (M_CustomerCategoryDL.ExistingM_CustomerCategory(suppcode.Trim()))
            {
                M_CustomerCategory cat = new M_CustomerCategory();
                cat.CusCateID = suppcode.Trim();
                str = new M_CustomerCategoryDL().Selectm_CustomerCategory(cat).Description;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingCustomerSub(string catid,string subcatid)
        {
            string str = "";
            if (M_CustomerSubDL.ExistingM_CustomerSub(subcatid,catid.Trim()))
            {
                M_CustomerSub cat = new M_CustomerSub();
                cat.CatID = catid.Trim();
                cat.CussubID = subcatid.Trim();
                str = new M_CustomerSubDL().Selectm_CustomerSub(cat).Description;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }



        public static string FindExisitingUser(string suppcode)
        {
            string str = "Admin";
            //if (u_User.ExistingM_Customer(suppcode.Trim()))
            //{
            //    M_Customers cat = new M_Customers();
            //    cat.CusID = suppcode.Trim();
            //    M_CustomerDL dl = new M_CustomerDL();
            //    cat = dl.Selectm_Customer(cat);
            //    str = cat.CustName;
            //}
            //else
            //{
            //    str = "<Error!!!>";
            //}
            return str;
        }

        public static string FindExisitingVehicle(string suppcode)
        {
            string str = "";
            if (M_VehicleDL.ExistingM_Vehicle(suppcode.Trim()))
            {
                M_Vehicles cat = new M_Vehicles();
                cat.VehicleID = suppcode.Trim();
                M_VehicleDL dl = new M_VehicleDL();
                cat = dl.Selectm_Vehicle(cat);
                str = cat.VehicleNo;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingAgent(string suppcode)
        {
            string str = "";
            if (M_AgentDL.ExistingM_Agent(suppcode.Trim()))
            {
                M_Agents cat = new M_Agents();
                cat.AgentCode = suppcode.Trim();
                M_AgentDL dl = new M_AgentDL();
                cat = dl.Selectm_Agent(cat);
                str = cat.Namex.Trim();
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingParts(string suppcode)
        {
            string str = "";
            if (M_ProductPartDL.ExistingM_ProductPart(suppcode.Trim()))
            {
                M_ProductParts cat = new M_ProductParts();
                cat.IDX = suppcode.Trim();
                cat = new M_ProductPartDL().Selectm_ProductPart(cat);
                str = cat.PartName.Trim();
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingBank(string suppcode)
        {
            string str = "";
            if (M_BankDL.ExistingBank(suppcode.Trim()))
            {
                M_Bank cat = new M_Bank();
                cat.BANK_CODE = suppcode.Trim();
                M_BankDL dl = new M_BankDL();
                cat = dl.SelectBank(cat);
                str = cat.BANK_NAME;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingBankBranch(string bank,string branch)
        {
            string str = "";
            if (M_BankBranchDL.ExistingM_BankBranch(bank.Trim()))
            {
                M_BankBranch cat = new M_BankBranch();
                cat.BBRANCH_CODE = branch.Trim();
                cat.BBRANCH_BANK = bank.Trim();
                M_BankBranchDL dl = new M_BankBranchDL();
                cat = dl.Selectm_BankBranch(cat);
                if (cat != null)
                {
                    str = cat.BBRANCH_NAME;
                }
                else {
                    str = "<Error!!!>";
                }
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingSalesman(string suppcode)
        {
            string str = "";
            if (M_SalesManDL.ExistingM_SalesMan(suppcode.Trim()))
            {
                M_SalesMan cat = new M_SalesMan();
                cat.SalesmanID = suppcode.Trim();
                M_SalesManDL dl = new M_SalesManDL();
                cat = dl.Selectm_SalesMan(cat);
                str = cat.SalesmanName;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingInvoice(string suppcode)
        {
            string str = "";
            if (T_InvoiceHedDL.ExistingT_InvoiceHed(suppcode.Trim()))
            {
                T_InvoiceHed cat = new T_InvoiceHed();
                cat.InvID = suppcode.Trim();
                T_InvoiceHedDL dl = new T_InvoiceHedDL();
                cat = dl.Selectt_InvoiceHed(cat);
                str = cat.NetAmt.ToString();
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static T_InvoiceHed FindExisitingInvoiceAll(string suppcode)
        {
            string str = "";
            T_InvoiceHed cat = new T_InvoiceHed();
            if (T_InvoiceHedDL.ExistingT_InvoiceHed(suppcode.Trim()))
            {
                cat.InvID = suppcode.Trim();
                T_InvoiceHedDL dl = new T_InvoiceHedDL();
                cat = dl.Selectt_InvoiceHed(cat);
                str = cat.NetAmt.ToString();
            }
            else
            {
            }
            return cat;
        }

        public static string FindExisitingPaytype(string suppcode)
        {
            string str = "";
            if (M_PayModeDL.ExistingM_PayMode(suppcode.Trim()))
            {
                M_PayMode cat = new M_PayMode();
                cat.id = suppcode.Trim();
                str = new M_PayModeDL().Selectm_PayMode(cat).description;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingTerri(string suppcode)
        {
            string str = "";
            if (M_TerritoryDL.ExistingM_Territory(suppcode.Trim()))
            {
                M_Territory cat = new M_Territory();
                cat.TerritoryCode = suppcode.Trim();
                str = new M_TerritoryDL().Selectm_Territory(cat).Descr;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingCNType(string suppcode)
        {
            string str = "";
            if (M_CNTypeDL.ExistingM_CNType(suppcode.Trim()))
            {
                M_CNTypes cat = new M_CNTypes();
                cat.TypeID = suppcode.Trim();
                str = new M_CNTypeDL().Selectm_CNType(cat).TypeName;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingCNReason(string suppcode)
        {
            string str = "";
            if (M_CNReasonDL.ExistingM_CNReason(suppcode.Trim()))
            {
                M_CNReason cat = new M_CNReason();
                cat.ID = suppcode.Trim();
                str = new M_CNReasonDL().Selectm_CNReason(cat).Reason;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingUSer(string suppcode)
        {
            string str = "";
            if (U_UserxDL.ExistingU_User(suppcode.Trim()))
            {
                u_Userxcc cat = new u_Userxcc();
                cat.userId = suppcode.Trim();
                str = new U_UserxDL().Selectu_User(cat).userName;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingRole(string suppcode)
        {
            string str = "";
            if (U_UserRolexDL.ExistingU_UserRole(suppcode.Trim()))
            {
                u_UserRolex cat = new u_UserRolex();
                cat.roleId = suppcode.Trim();
                str = new U_UserRolexDL().Selectu_UserRole(cat).description;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }


        public static string FindExisitingStock(string suppcode)
        {
            string str = "";
            if (T_StockDL.ExistingT_Stock_new(suppcode.Trim(), commonFunctions.GlobalCompany, commonFunctions.GlobalLocation))
            {
                T_Stock cat = new T_Stock();
                cat.StockCode = suppcode.Trim();
                cat.Compcode = commonFunctions.GlobalCompany;
                cat.Locacode = commonFunctions.GlobalLocation;
                str = new T_StockDL().Selectt_Stock_ByStockCode(cat).Descr;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingcategory(string suppcode)
        {
            string str = "";
            if (M_CategoryDL.ExistingM_Category(suppcode.Trim()))
            {
                M_Category cat = new M_Category();
                cat.Codex = suppcode.Trim();
                str = new M_CategoryDL().Selectm_Category(cat).Descr;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }

        public static string FindExisitingsubcategory(string catecode,string subcatecode)
        {
            string str = "";
            if (M_SubCategoryDL.ExistingM_SubCategory(catecode.Trim(),subcatecode.Trim()))
            {
                M_SubCategory cat = new M_SubCategory();
                cat.Codex = subcatecode.Trim();
                cat.CategoryID = catecode.Trim();
                str = new M_SubCategoryDL().Selectm_SubCategory(cat).Descr;
            }
            else
            {
                str = "<Error!!!>";
            }
            return str;
        }
    }
}
