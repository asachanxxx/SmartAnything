using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartOffice_Models
{
    public class t_purReq
    {
        public string strReqNo { get; set; }
        public DateTime dtReqDate { get; set; }
        public DateTime dtDeleveryDate { get; set; }
        public m_Location LocationId { get; set; }
        public m_Supplier SupplierId { get; set; }
        public decimal decGrossAmount { get; set; }
        public decimal decNoOfItem { get; set; }
        public decimal decNoOfPeaces { get; set; }
        public string strRemarks { get; set; }
        public int intIsSaved { get; set; }
        public int intIsProcessed { get; set; }
        public DateTime dtProcessDate { get; set; }
        public string strProcessUser { get; set; }

        public List<t_PurchaseReq_Detail> productId { get; set; }
       
    }
}
