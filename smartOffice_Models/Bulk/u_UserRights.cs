//*************************************************************
//Developer  :Nilmini Paragahawaththage
//Date       :2013/11/28
//Description:u_UserRights properties
//Module Name: smartOffice
//*************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAnything
{
    public class u_UserRights
    {
        public u_UserRole Role { get; set; }
        public u_User User { get; set; }
        public u_MenuTag MenuTag { get; set; }
        public string strMenuRights { get; set; }
    }
}
