using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAnything
{
    public class UserDefineMessages
    {
               
        /// Main Messages        
        public static object[] Msg_Save_Sucess = { "Record Successfully Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information };
        public static object[] Msg_Process_Sucess = { "Record Successfully Processed!", MessageBoxButtons.OK, MessageBoxIcon.Information };
        public static object[] Msg_Update_Sucess  = {"Record Successfully Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information };
        public static object[] Msg_Delete_Sucess  = {"Record Successfully Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information };

        public static string Msg_Save_Sucess_string = "Record Successfully Saved!";
        public static string Msg_Process_Sucess_string =  "Record Successfully Processed!";
        public static string Msg_Update_Sucess_string =  "Record Successfully Updated!" ;
        public static string Msg_Delete_Sucess_string =  "Record Successfully Deleted!" ;
                
        /// Error Messages       
        public static object[] Msg_Error_Exception = {"Error has been occurred! ", MessageBoxButtons.OK, MessageBoxIcon.Error };
        public static object[] Msg_Error_Amount    = { "Please enter valid amount! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_common = { "System specific error occured..Please contact Retail Information Technologies help desk now! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_Loginfail = { "Login to the database was failed... Please check the network connection and Configuration file! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };


        /// Permission       
        public static object[] Msg_AccessGrant_Creat = { "You don't have rights to creation!", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_AccessGrant_Upddate = { "You don't have rights to update!", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        

        ///Perform Button
        public static object[] Msg_PerfmBtn_New  = {"Do you want to Reset?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Save = {"Do you want to Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Add = { "Do you want to Add record(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Edit = {"Do you want to Edit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Del  = {"Do you want to Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Prnt = {"Do you want to Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Exit = {"Do you want to Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Update = { "Do you want to Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Process = { "Do you want to Process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Approve = { "Do you want to Approve?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Cancel = { "Do you want to Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_PerfmBtn_Reject = { "Do you want to Reject?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_exit = { "Do you exit from the system?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_logoff = { "Do you log off from the system?", MessageBoxButtons.YesNo, MessageBoxIcon.Question };

        
        ///Account Type
        public static object[] Msg_Error_AcTypeCode  = {"Please enter account type! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcTypeDesc  = {"Please enter account Description! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcTypeStats = {"Please select account Status! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcTypeCodeValid = { "Entered account type is not valid! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        
        ///Account
        public static object[] Msg_Error_AcCode    = {"Please enter valid account code! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcName    = {"Please enter account name! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcHedDet  = {"Please select account is a header or detail! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcNomlBal = {"Please enter normal balance! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcDebCrd  = {"Please select Debtor / Creditor Type detail! ", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Error_AcSubAc   = {"Please enter sub account", MessageBoxButtons.OK, MessageBoxIcon.Warning };
             ///User
        public static object[] Msg_Error_UserExsist = { "Ented user code is already taken,Please retype a new user code", MessageBoxButtons.OK, MessageBoxIcon.Warning };
        

        ///Financial year is in correct 
        public static object[] Msg_Error_clsFinYerIncorect = { "Invalid Date or Date not with the Financial Period", MessageBoxButtons.OK, MessageBoxIcon.Warning };



        public static object[] Msg_Question = {MessageBoxButtons.OK, MessageBoxIcon.Question };
        public static object[] Msg_Warning = {MessageBoxButtons.OK, MessageBoxIcon.Warning };
        public static object[] Msg_Information = {MessageBoxButtons.OK, MessageBoxIcon.Information };
        public static object[] Msg_Exclamtion = {MessageBoxButtons.OK, MessageBoxIcon.Exclamation };

        public static object[] Msg_QuestionYESNO = { MessageBoxButtons.YesNo, MessageBoxIcon.Question };
        public static object[] Msg_WarningYESNO = { MessageBoxButtons.YesNo, MessageBoxIcon.Warning };
        public static object[] Msg_InformationYESNO = { MessageBoxButtons.YesNo, MessageBoxIcon.Information };
        public static object[] Msg_ExclamtionYESNO = { MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation };

        //______________________________________________________________________________________________________________________________



      //  /// <summary>
      ///// Display Message with form Name
      ///// </summary>
      ///// <param name="objMsg"></param>
      ///// <param name="strFormName"></param>
      //  public DialogResult ShowMsg(string strMessage, object[] objMsg, string strFormName)
      //  {
      //      try
      //       {
      //          object[] values = objMsg;
      //          string strMsg;
      //          MessageBoxButtons MsgBxBnt; //Message Box Button 
      //          MessageBoxIcon MsgBxIcon;   //Message Box Icon 

      //          strMsg    = Convert.ToString(values[0] + "\n"+ strMessage );
      //          MsgBxBnt  = (MessageBoxButtons)values[1];
      //          MsgBxIcon = (MessageBoxIcon)values[2];

      //          DialogResult result =  MessageBox.Show(strMsg, strFormName, MsgBxBnt, MsgBxIcon);   //Show Message 

      //          return result;
                                              
      //      }
      //      catch (Exception ex)
      //      {                
      //          throw ex;
      //      }
      //   }
        //Smart Distribution System
        public static DialogResult ShowMsg(string strMessage, object[] objMsg, string strFormName)
        {
            try
            {
                object[] values = objMsg;
                string strMsg;
                MessageBoxButtons MsgBxBnt; //Message Box Button 
                MessageBoxIcon MsgBxIcon;   //Message Box Icon 

                strMsg = Convert.ToString(values[0] + "\n" + strMessage);
                MsgBxBnt = (MessageBoxButtons)values[1];
                MsgBxIcon = (MessageBoxIcon)values[2];

                DialogResult result = MessageBox.Show(strMsg, strFormName, MsgBxBnt, MsgBxIcon);   //Show Message 

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DialogResult ShowMsg(string strMessage, object[] objMsg)
        {
            try
            {
                object[] values = objMsg;
                MessageBoxButtons MsgBxBnt; //Message Box Button 
                MessageBoxIcon MsgBxIcon;   //Message Box Icon 

                //strMsg = Convert.ToString(values[0] + "\n" + strMessage);
                MsgBxBnt = (MessageBoxButtons)values[0];
                MsgBxIcon = (MessageBoxIcon)values[1];

                DialogResult result = MessageBox.Show(strMessage, "Smart Distribution System", MsgBxBnt, MsgBxIcon);   //Show Message 

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DialogResult ShowMsg1(string strMessage, object[] objMsg, string strFormName)
        {
            try
            {
                object[] values = objMsg;
                string strMsg;
                MessageBoxButtons MsgBxBnt; //Message Box Button 
                MessageBoxIcon MsgBxIcon;   //Message Box Icon 

                MsgBxBnt = (MessageBoxButtons)values[1];
                MsgBxIcon = (MessageBoxIcon)values[2];

                DialogResult result = MessageBox.Show(strMessage, strFormName, MsgBxBnt, MsgBxIcon);   //Show Message 

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DialogResult ShowMsg1(string strMessage, object[] objMsg)
        {
            try
            {
                object[] values = objMsg;
                MessageBoxButtons MsgBxBnt; //Message Box Button 
                MessageBoxIcon MsgBxIcon;   //Message Box Icon 

                MsgBxBnt = (MessageBoxButtons)values[0];
                MsgBxIcon = (MessageBoxIcon)values[1];

                DialogResult result = MessageBox.Show(strMessage, "Smart Distribution System", MsgBxBnt, MsgBxIcon);   //Show Message 

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
