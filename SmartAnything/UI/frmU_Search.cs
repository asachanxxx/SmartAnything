//**********************************************************************
//Developer  :Peshala Rupasingha,Nilmini Paragahawaththage
//Date       :2013/10/01
//Description:Search and Load data
//Module Name: smartOffice
//**********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using smartOffice_Models;
using smartOffice_BL;
using System.Data.Sql;
using System.Data.SqlClient;
using smartOffice.Classes;

namespace SmartAnything
{
    public partial class frmU_Search : Form
    {
        string strSql; 
        string[] strArrsearch;
        Form frmParent;
        IDbDataAdapter adpSearch;
        int i = 0;
        public string strCheckFirst="false";
        public string strCheckAny = "false";
        public string strSelectedText;
        public bool X = false;

        public frmU_Search()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overloaded constructor sets values
        /// </summary>
        /// <param name="strSql">SQL Query</param>
        /// <param name="strArrsearch"> Array of Fields which SQL query returns </param>
        /// <param name="frmParent">The Parent Form which Search form loads</param>
        public frmU_Search(string strSql, string[] strArrsearch, Form frmParent,bool x=false)
        {
            this.strSql = strSql;
            this.strArrsearch = strArrsearch;
            this.frmParent = frmParent;
            this.X = x;
            InitializeComponent();
        }

        /// <summary>
        /// search Form loads with the relevant data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmU_Search_Load(object sender, EventArgs e)
        {

            commonFunctions.FormatDataGrid(dtgrdSearch);
            this.Text = commonFunctions.Softwarename;
            if(u_DBConnection.strDBType==DBEngine.MSSQL)
            {
                rbtnFirstLetter.Checked = true;
                SqlDataAdapter sqladpSearch;
                sqladpSearch = new SqlDataAdapter(strSql +" ORDER BY "+strArrsearch[i], (SqlConnection)u_DBConnection.getConnection());
                DataSet dsSearch = new DataSet();
                sqladpSearch.Fill(dsSearch);
                DataTable dtResult = dsSearch.Tables[0];

                dtgrdSearch.DataSource = dtResult;

                dtgrdSearch.Columns[0].Width = 130;
                dtgrdSearch.Columns[1].Width = 260;
                
            }

            
        }

        /// <summary>
        /// If press Enter, focus the first row of the data grid view
        /// If press escape, exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Dispose();
            if (e.KeyCode == Keys.Enter)
                dtgrdSearch.Focus();

        }

        /// <summary>
        /// Filter data according to the user enterd text in the txtSearch textbox
        /// If radio btn FirstLetter selected, search by first letter
        /// If radio btn Any where selected, search data which user enterd letter any where in the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strSql = "";

                if (u_DBConnection.strDBType == DBEngine.MSSQL)
                {

                    bool checkforwhere = this.strSql.ToUpper() .Contains("where".ToUpper());
                    if (!checkforwhere)
                    {
                        if (txtSearch.Text.Trim() != string.Empty)
                        {
                            if (strCheckFirst == "true")
                            {
                                strSql = this.strSql + " where " + strArrsearch[i] + " = '" + txtSearch.Text.Trim() + "' or " + strArrsearch[i] + " like '" + txtSearch.Text + "%' order by " + strArrsearch[i];
                            }
                            if (strCheckAny == "true")
                            {
                                strSql = this.strSql + " where " + strArrsearch[i] + " = '" + txtSearch.Text.Trim() + "' or " + strArrsearch[i] + " like '%" + txtSearch.Text + "%' order by " + strArrsearch[i];

                            }
                        }
                        else {
                            strSql = this.strSql + " order by " + strArrsearch[i];
                        }
                    }
                    else {
                        if (txtSearch.Text.Trim() != string.Empty)
                        {
                            if (strCheckFirst == "true")
                            {
                                strSql = this.strSql + " and " + strArrsearch[i] + " = '" + txtSearch.Text.Trim() + "' or " + strArrsearch[i] + " like '" + txtSearch.Text + "%' order by " + strArrsearch[i];
                            }
                            if (strCheckAny == "true")
                            {
                                strSql = this.strSql + " and " + strArrsearch[i] + " = '" + txtSearch.Text.Trim() + "' or " + strArrsearch[i] + " like '%" + txtSearch.Text + "%' order by " + strArrsearch[i];

                            }
                        }
                        else
                        {
                            strSql = this.strSql + " order by " + strArrsearch[i];
                        }
                    }
                    SqlDataAdapter sqladpSearch;
                    sqladpSearch = new SqlDataAdapter(strSql, (SqlConnection)u_DBConnection.getConnection());
                    DataSet dsSearch = new DataSet();
                    sqladpSearch.Fill(dsSearch);
                    DataTable dtResult = dsSearch.Tables[0];
                    dtgrdSearch.DataSource = dtResult;

                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog("txtSearch_TextChanged", "frmU_Search", ex.Message.ToString());
                Globals.generateCommonErrorMsg();
                //Globals.generateErrorMsg(ex.Message.ToString(), "txtSearch_TextChanged");
            }
        }

        /// <summary>
        /// Check whether radio button is checked or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnFirstLetter_CheckedChanged(object sender, EventArgs e)
        {
            strCheckFirst = "true";
            strCheckAny = "false"; 
            LblSrchType.Text = "FIRST LETTER";

        }

        /// <summary>
        /// Check whether radio button is checked or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnAnyWhere_CheckedChanged(object sender, EventArgs e)
        {
            strCheckAny = "true";
            strCheckFirst = "false";
            LblSrchType.Text = "ANY LETTER";
        }

        /// <summary>
        /// if press enter, the selected filed fills the text boxes in the parent form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int i;
                    i = dtgrdSearch.SelectedCells[0].RowIndex;


                    if (X)
                    {
                        frmParent.ActiveControl.Text = dtgrdSearch.Rows[i].Cells[0].Value.ToString();

                        strSelectedText = dtgrdSearch.Rows[i].Cells[0].Value.ToString();
                        foreach (Control s in frmParent.Controls)
                        {
                            if ((s.Name == "txtSourceLocation") || (s.Name == "txtLocation") || (s.Name == "txtLoc"))
                            {
                                s.Text = dtgrdSearch.Rows[i].Cells[3].Value.ToString();
                            }
                        }
                        this.Dispose();
                    }
                    else
                    {
                        frmParent.ActiveControl.Text = dtgrdSearch.Rows[i].Cells[0].Value.ToString();
                        strSelectedText = dtgrdSearch.Rows[i].Cells[0].Value.ToString();
                        this.Dispose();
                    }
                }


                //*Move to next row using arrow keys           
                if (e.KeyCode == Keys.Down)
                {
                    int Column = dtgrdSearch.CurrentCell.ColumnIndex;
                    int Row = dtgrdSearch.CurrentCell.RowIndex + 1;

                    if (Row < dtgrdSearch.Rows.Count)
                    {
                        dtgrdSearch.CurrentCell = dtgrdSearch[Column, Row];
                    }

                    e.SuppressKeyPress = e.Handled = true;
                }


                //* Move to next Column using CTRL keys 
                if (e.KeyCode == Keys.ControlKey)
                {
                    int Column = dtgrdSearch.CurrentCell.ColumnIndex + 1;
                    int Row = dtgrdSearch.CurrentCell.RowIndex;


                    if (Column >= dtgrdSearch.Columns.Count)
                    {
                        Row = Row + 1;
                        Column = 0;
                    }

                    if (Column < dtgrdSearch.Columns.Count && Row < dtgrdSearch.Rows.Count)
                    {
                        dtgrdSearch.CurrentCell = dtgrdSearch[Column, Row];
                    }

                    //** Display Column Heading,When Cursor Move

                    if (dtgrdSearch.RowCount > 0)
                    {
                        i = dtgrdSearch.CurrentCell.ColumnIndex;
                    }

                    //searchColumn = dgSearch.Columns[i].Name;
                    lblColumn.Text = dtgrdSearch.Columns[i].Name.ToString();

                    e.SuppressKeyPress = e.Handled = true;
                }
                if (e.KeyCode == Keys.Escape)
                {
                    this.Dispose();
                }

                if (e.KeyCode == Keys.ShiftKey)
                {
                    if (rbtnFirstLetter.Checked == false)
                    {
                        rbtnFirstLetter.Checked = true;

                    }
                    else if (rbtnAnyWhere.Checked == false)
                    {
                        rbtnAnyWhere.Checked = true;

                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, this.Name, ex.Message.ToString(), "Exception");
                commonFunctions.SetMDIStatusMessage("Genaral Error on processing data", 1);
            }

        }


        /// <summary>
        /// Loads when user double click on the grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdSearch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = dtgrdSearch.SelectedCells[0].RowIndex;


                if (X)
                {
                    frmParent.ActiveControl.Text = dtgrdSearch.Rows[i].Cells[0].Value.ToString();

                    strSelectedText = dtgrdSearch.Rows[i].Cells[0].Value.ToString();
                    foreach (Control s in frmParent.Controls)
                    {
                        if ((s.Name == "txtSourceLocation") || (s.Name == "txtLocation") || (s.Name == "txtLoc"))
                        {
                            s.Text = dtgrdSearch.Rows[i].Cells[3].Value.ToString();
                        }
                    }
                    this.Dispose();
                }
                else
                {
                    frmParent.ActiveControl.Text = dtgrdSearch.Rows[i].Cells[0].Value.ToString();
                    strSelectedText = dtgrdSearch.Rows[i].Cells[0].Value.ToString();
                    this.Dispose();
                }
            }
            catch (Exception ex) {
                //throw ex;
            }
        }

        private void dtgrdSearch_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //ASSIGN i AS SELECTED COLUMN INDEX
                i = e.ColumnIndex;
                lblColumn.Text = dtgrdSearch.Columns[e.ColumnIndex].HeaderText;

                //*** CHANGE SELECTED COLUMN COLOR ***

                //**SET ALL COLUMNS TO DEFAULT COLOR
                DataGridViewColumn firstColumn = dtgrdSearch.Columns[0];
                DataGridViewCellStyle DefaultCellStyle = new DataGridViewCellStyle();
                DataGridViewCellStyle SelectCellStyle = new DataGridViewCellStyle();
                DefaultCellStyle.BackColor = SystemColors.ButtonHighlight;
                SelectCellStyle.BackColor = SystemColors.GradientInactiveCaption;


                for (int x = 0; x < dtgrdSearch.ColumnCount; x++)
                {
                    dtgrdSearch.Columns[x].DefaultCellStyle.BackColor = SystemColors.ButtonHighlight; //DefaultCellStyle.BackColor;
                }

                //**CHANGE COLOR TO SELECTED COLUMN
                dtgrdSearch.Columns[i].DefaultCellStyle.BackColor = SelectCellStyle.BackColor;

            }
            catch (Exception ex)
            {
                throw ex;
            }             
        }

       



    }
}
