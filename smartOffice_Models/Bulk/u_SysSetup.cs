using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartOffice_Models
{
    public class u_SysSetup
    {
        public string strCompany { get; set; }
        public string strAddress1 { get; set; }
        public string strAddress2 { get; set; }
        public string strAddress3 { get; set; }
        public string strTelephone1 { get; set; }
        public string strTelephone2 { get; set; }
        public string strFax { get; set; }
        public string strEmail { get; set; }
        public string strProLevel1 { get; set; }
        public string strProLevel2 { get; set; }
        public string strProLevel3 { get; set; }
        public string strProLevel4 { get; set; }
        public string strProLevel5 { get; set; }
        public string strProLevel6 { get; set; }
        public string strProLevel7 { get; set; }
        public string strProLevel8 { get; set; }
        public int intAutoProductCode { get; set; }
        public int intIsCusAutoGenerate { get; set; }
        public int intIsSupAutoGenerate { get; set; }
        public int intIsProAutoGenerate { get; set; }
        public int intIsWastageAutoGenerate { get; set; }
        public int intIsMaintainStockLot { get; set; }
    }
}
