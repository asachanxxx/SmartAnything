using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAnything.UI
{
    public partial class frm_users : Form
    {

        int formMode = 0;
        string formID = "A0038";
        string formHeadertext = "System USers";

        #region Loading one instance

        private static frm_users objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_users getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_users();

            }
            return objSingleObject;

        }

        #endregion


        public frm_users()
        {
            InitializeComponent();
        }

        private void frm_users_Load(object sender, EventArgs e)
        {

        }
    }
}
