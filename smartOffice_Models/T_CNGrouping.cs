//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace smartOffice_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_CNGrouping
    {
        public string Docno { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string CNType { get; set; }
        public string CNReason { get; set; }
        public Nullable<decimal> InvoiceQty { get; set; }
        public Nullable<decimal> CNQTY { get; set; }
        public Nullable<decimal> BreakdownQTY { get; set; }
        public string TagNumber { get; set; }
        public Nullable<bool> Selected { get; set; }
        public Nullable<decimal> SelectedQTY { get; set; }
        public Nullable<decimal> balanceQTY { get; set; }
        public Nullable<bool> Shipped { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string ShippedDO { get; set; }
        public string CNnumber { get; set; }
        public Nullable<bool> PartEntered { get; set; }
    }
}
