//**********************************************************************
//Developer  :PUBUDU
//Date       :2013/10/04
//Description:Login Properties
//Module Name: smartOffice
//**********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAnything
{
    public class u_User
    {
        public string strUserID { get; set; }
        public string strUserName { get; set; }
        public string strPassword { get; set; }
        public int intIsActive { get; set; }
        public u_UserRole UserRole { get; set; }
        public string strEditUserID { get; set; }
        public u_Employee Employee { get; set; }
    }
}
