using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAnything;


namespace smartOffice.UI
{
    public enum SmartOfficeMessageBoxIcon { ERROR, INFO, QUESTION ,CAUTION}
    public enum SmartOfficeMessageBoxBtn { OK, CANCEL_OK, YES_NO, YES_NO_CANCEL }
    public partial class smartOfficeMessageBox : Form
    {
        private static smartOfficeMessageBox singleton = null;
        public smartOfficeMessageBox()
        {
            InitializeComponent();
        }
        public static DialogResult ShowMsg(string msg, string caption, SmartOfficeMessageBoxBtn btn, SmartOfficeMessageBoxIcon icon)
        {
            
            if (msg.Length > 210) throw new Exception("Message Length should be less than 210 characters");
            if (singleton == null || singleton.IsDisposed)
                singleton = new smartOfficeMessageBox();
            switch (icon)
            {
                case SmartOfficeMessageBoxIcon.ERROR:
                    
                    //singleton.picBoxMessageBox.Image = Properties.Resources.MessageBoxHeaderError;
                    break;
                case SmartOfficeMessageBoxIcon.INFO:
                    //singleton.picBoxMessageBox.Image = Properties.Resources.MessageBoxHeaderInformation;
                    break;
                case SmartOfficeMessageBoxIcon.QUESTION:
                    //singleton.picBoxMessageBox.Image = Properties.Resources.MessageBoxHeaderQuestion;
                    break;
                case SmartOfficeMessageBoxIcon.CAUTION:
                    //singleton.picBoxMessageBox.Image = Properties.Resources.MessageBoxHeaderCaution;
                    break;
            }
            switch (btn)
            {
                case SmartOfficeMessageBoxBtn.OK:
                    singleton.btnOk.Visible = true;
                    singleton.btnCancel.Visible = false;
                    singleton.btnYes.Visible = false;
                    singleton.btnNo.Visible = false;
                    singleton.AcceptButton = singleton.btnOk;
                    break;
                case SmartOfficeMessageBoxBtn.CANCEL_OK:
                    singleton.btnOk.Visible = true;
                    singleton.btnCancel.Visible = true;
                    singleton.btnYes.Visible = false;
                    singleton.btnNo.Visible = false;
                    singleton.AcceptButton = singleton.btnOk;
                    break;
                case SmartOfficeMessageBoxBtn.YES_NO:
                    singleton.btnOk.Visible = false;
                    singleton.btnCancel.Visible = false;
                    singleton.btnYes.Visible = true;
                    singleton.btnNo.Visible = true;
                    singleton.AcceptButton = singleton.btnYes;
                    break;
                case SmartOfficeMessageBoxBtn.YES_NO_CANCEL:
                    singleton.btnOk.Visible = false;
                    singleton.btnCancel.Visible = true;
                    singleton.btnYes.Visible = true;
                    singleton.btnNo.Visible = true;
                    singleton.btnYes.Location = new System.Drawing.Point(125, 111);
                    singleton.btnNo.Location = new System.Drawing.Point(206, 111);
                    singleton.btnCancel.Location = new System.Drawing.Point(287, 111);
                    singleton.AcceptButton = singleton.btnYes;
                    break;
            }

            singleton.Text = caption;
            singleton.lblTxtMessage.Text = msg;
            return singleton.ShowDialog();
        }

        public static DialogResult ShowMsg(string msg)
        {
            if (singleton == null || singleton.IsDisposed)
                singleton = new smartOfficeMessageBox();
            return smartOfficeMessageBox.ShowMsg(msg, "Information", SmartOfficeMessageBoxBtn.OK, SmartOfficeMessageBoxIcon.INFO);
        }
        
        public static DialogResult ShowMsg(string msg, string caption)
        {
            if (singleton == null || singleton.IsDisposed)
                singleton = new smartOfficeMessageBox();
            return smartOfficeMessageBox.ShowMsg(msg, caption, SmartOfficeMessageBoxBtn.OK, SmartOfficeMessageBoxIcon.INFO);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Dispose();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Dispose();
        }
    }
}
