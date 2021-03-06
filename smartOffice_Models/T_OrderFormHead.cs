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
    
    public partial class T_OrderFormHead
    {
        public string DocNo { get; set; }
        public string Compcode { get; set; }
        public string Locacode { get; set; }
        public string TRNType { get; set; }
        public string SalesMan { get; set; }
        public string Customer { get; set; }
        public Nullable<System.DateTime> Datex { get; set; }
        public string RecivedBy { get; set; }
        public string CheckedBy { get; set; }
        public int Approved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<System.DateTime> RecivedDate { get; set; }
        public string Userx { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CQNO { get; set; }
        public Nullable<System.DateTime> CQDate { get; set; }
        public string BANK { get; set; }
        public string BRANCH { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public Nullable<decimal> DiscountPer { get; set; }
        public Nullable<decimal> SubtotalDisc { get; set; }
        public Nullable<decimal> ItemdiscTotal { get; set; }
        public Nullable<decimal> TotalDisc { get; set; }
        public Nullable<decimal> NetTotal { get; set; }
        public string Remarks { get; set; }
        public int Processed { get; set; }
        public Nullable<System.DateTime> ProcessedDate { get; set; }
        public string ProcessedUser { get; set; }
        public Nullable<int> InvCreated { get; set; }
        public Nullable<System.DateTime> InvCreatedDate { get; set; }
        public string INVCreatedUser { get; set; }
    }
}
