//*************************************************************
//Developer  :Nilmini Paragahawaththage
//Date       :2013/11/01
//Description:u_UserRoleRights properties
//Module Name: smartOffice
//*************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAnything
{
    public class u_UserRoleRights
    {
        public u_UserRole Role { get; set; }
        public u_MenuTag MenuTag { get; set; }
        public string strMenuRights { get; set; }
    }
}
