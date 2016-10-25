using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;
using SmartAnything;
using SmartAnything_DL;
using smartOffice_Models;



namespace SmartAnything
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        private void reports_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ReportDocument rptDoc = new ReportDocument();
            //MasterData ds = new MasterData(); // .xsd file name
            //DataTable dt = new DataTable();

            //string path = System.IO.Path.Combine(ConfigurationManager.AppSettings["ReportFilePath"].Trim(), "rpt_banks.rpt");
            //// Your .rpt file path will be below
            //rptDoc.Load(path);

            ////rptDoc.FileName = "rpt_banks.rpt";
            ////rptDoc.Load(
            ////set dataset to the report viewer.
            //M_BankDL bankdlx = new M_BankDL();
            //rptDoc.SetDataSource(bankdlx.SelectAllBanks());
            //crystalReportViewer1.ReportSource = rptDoc;
        }

     }
}
