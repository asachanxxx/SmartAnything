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
    
    public partial class T_DIliveryAudit
    {
        public string Dono { get; set; }
        public string Item { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> DoQty { get; set; }
        public Nullable<decimal> ActualQTY { get; set; }
        public Nullable<decimal> Variance { get; set; }
        public Nullable<int> Pass { get; set; }
    }
}