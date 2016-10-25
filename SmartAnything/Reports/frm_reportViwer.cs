using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAnything
{
    public partial class frm_reportViwer : Form
    {

        string formHeadertext = "ReportViewr";

        public string FormHeadertext
        {
            get { return formHeadertext; }
            set { formHeadertext = value; }
        }

        public frm_reportViwer()
        {
            InitializeComponent();
        }

        private void frm_reportViwer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = formHeadertext;
            commonFunctions.ChangeHeaderTextAndColor(lbl_headerpaneltext, FormHeadertext);

        }
    }
}
