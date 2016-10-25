//**********************************************************************
//Developer  :PUBUDU
//Date       :2013/10/15
//Description:Interface Class
//Module Name: smartOffice
//**********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartOffice.Classes
{
    public interface IToolbarAction
    {
        void PerformButtonClick(string strCommand);
    }
}
