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
    
    public partial class T_DIliveryHed
    {
        public string DoNo { get; set; }
        public string CompCode { get; set; }
        public string LocaCode { get; set; }
        public string InvNo { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public string Customer { get; set; }
        public Nullable<decimal> CustomerDIscRate { get; set; }
        public Nullable<System.DateTime> Datex { get; set; }
        public string Agent { get; set; }
        public string Lorry { get; set; }
        public Nullable<decimal> NoOfCartons { get; set; }
        public Nullable<int> Dispatched { get; set; }
        public Nullable<System.DateTime> DispatchedDate { get; set; }
        public string DispatchedUser { get; set; }
        public Nullable<int> Checked { get; set; }
        public string CheckedUser { get; set; }
        public Nullable<System.DateTime> Checkeddate { get; set; }
        public Nullable<int> Approved { get; set; }
        public string ApprovedUser { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<int> Handovered { get; set; }
        public string HandoverdUser { get; set; }
        public Nullable<System.DateTime> HandoverDate { get; set; }
        public Nullable<decimal> HandoverCartons { get; set; }
        public Nullable<int> Delivered { get; set; }
        public string DiliveredUser { get; set; }
        public Nullable<System.DateTime> DiliveryDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> NoOfPrints { get; set; }
        public string PrintUser { get; set; }
        public string Status { get; set; }
        public Nullable<int> Processed { get; set; }
        public Nullable<System.DateTime> ProcessedDate { get; set; }
        public string ProcessedUser { get; set; }
        public Nullable<int> Audited { get; set; }
        public Nullable<System.DateTime> AuditDate { get; set; }
        public string AuditUser { get; set; }
        public Nullable<int> Completed { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public Nullable<int> PackingListCreated { get; set; }
        public string PackingListNo { get; set; }
        public Nullable<System.DateTime> PackingListDate { get; set; }
        public string PackingListUser { get; set; }
        public string ReportedProblems { get; set; }
        public string AuditRemarks { get; set; }
    }
}
