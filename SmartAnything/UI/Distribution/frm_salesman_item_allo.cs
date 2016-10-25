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
    public partial class frm_salesman_item_allo : Form
    {
        public frm_salesman_item_allo()
        {
            InitializeComponent();
        }

        #region Loading one instance

        private static frm_salesman_item_allo objSingleObject = null;

        /// <summary>
        /// Singleton object creation method
        /// </summary>
        /// <returns>object of a frmM_Supplier</returns>
        public static frm_salesman_item_allo getSingleton()
        {
            if (objSingleObject == null || objSingleObject.IsDisposed)
            {
                objSingleObject = new frm_salesman_item_allo();

            }
            return objSingleObject;

        }

        #endregion

        private void frm_salesman_item_allo_Load(object sender, EventArgs e)
        {

        }
    }
}
