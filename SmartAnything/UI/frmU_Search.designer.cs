namespace SmartAnything
{
    partial class frmU_Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.LblSrchType = new System.Windows.Forms.Label();
            this.lblColumn = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMsgHead = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rbtnAnyWhere = new System.Windows.Forms.RadioButton();
            this.rbtnFirstLetter = new System.Windows.Forms.RadioButton();
            this.dtgrdSearch = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.LblSrchType);
            this.pnlSearch.Controls.Add(this.lblColumn);
            this.pnlSearch.Controls.Add(this.lblDescription);
            this.pnlSearch.Controls.Add(this.lblMsgHead);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.rbtnAnyWhere);
            this.pnlSearch.Controls.Add(this.rbtnFirstLetter);
            this.pnlSearch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSearch.Location = new System.Drawing.Point(12, 8);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(395, 105);
            this.pnlSearch.TabIndex = 22;
            // 
            // LblSrchType
            // 
            this.LblSrchType.AutoSize = true;
            this.LblSrchType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSrchType.ForeColor = System.Drawing.Color.Blue;
            this.LblSrchType.Location = new System.Drawing.Point(86, 77);
            this.LblSrchType.Name = "LblSrchType";
            this.LblSrchType.Size = new System.Drawing.Size(78, 15);
            this.LblSrchType.TabIndex = 12;
            this.LblSrchType.Text = "Not Selected";
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumn.ForeColor = System.Drawing.Color.Blue;
            this.lblColumn.Location = new System.Drawing.Point(86, 59);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(181, 15);
            this.lblColumn.TabIndex = 11;
            this.lblColumn.Tag = "";
            this.lblColumn.Text = "Please Click on a column Header";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(5, 15);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(43, 15);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Search";
            // 
            // lblMsgHead
            // 
            this.lblMsgHead.AutoSize = true;
            this.lblMsgHead.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgHead.Location = new System.Drawing.Point(8, 59);
            this.lblMsgHead.Name = "lblMsgHead";
            this.lblMsgHead.Size = new System.Drawing.Size(59, 15);
            this.lblMsgHead.TabIndex = 10;
            this.lblMsgHead.Text = "Search By";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(61, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(313, 21);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // rbtnAnyWhere
            // 
            this.rbtnAnyWhere.AutoSize = true;
            this.rbtnAnyWhere.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAnyWhere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnAnyWhere.Location = new System.Drawing.Point(207, 38);
            this.rbtnAnyWhere.Name = "rbtnAnyWhere";
            this.rbtnAnyWhere.Size = new System.Drawing.Size(117, 19);
            this.rbtnAnyWhere.TabIndex = 9;
            this.rbtnAnyWhere.TabStop = true;
            this.rbtnAnyWhere.Text = "Match anywhere";
            this.rbtnAnyWhere.UseVisualStyleBackColor = true;
            this.rbtnAnyWhere.CheckedChanged += new System.EventHandler(this.rbtnAnyWhere_CheckedChanged);
            // 
            // rbtnFirstLetter
            // 
            this.rbtnFirstLetter.AutoSize = true;
            this.rbtnFirstLetter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFirstLetter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnFirstLetter.Location = new System.Drawing.Point(10, 38);
            this.rbtnFirstLetter.Name = "rbtnFirstLetter";
            this.rbtnFirstLetter.Size = new System.Drawing.Size(167, 19);
            this.rbtnFirstLetter.TabIndex = 8;
            this.rbtnFirstLetter.TabStop = true;
            this.rbtnFirstLetter.Text = "Match from the beginning";
            this.rbtnFirstLetter.UseVisualStyleBackColor = true;
            this.rbtnFirstLetter.CheckedChanged += new System.EventHandler(this.rbtnFirstLetter_CheckedChanged);
            // 
            // dtgrdSearch
            // 
            this.dtgrdSearch.AllowUserToAddRows = false;
            this.dtgrdSearch.AllowUserToDeleteRows = false;
            this.dtgrdSearch.AllowUserToOrderColumns = true;
            this.dtgrdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgrdSearch.Location = new System.Drawing.Point(12, 119);
            this.dtgrdSearch.Name = "dtgrdSearch";
            this.dtgrdSearch.ReadOnly = true;
            this.dtgrdSearch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgrdSearch.RowHeadersWidth = 30;
            this.dtgrdSearch.RowTemplate.Height = 20;
            this.dtgrdSearch.Size = new System.Drawing.Size(395, 318);
            this.dtgrdSearch.TabIndex = 20;
            this.dtgrdSearch.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgrdSearch_ColumnHeaderMouseClick);
            this.dtgrdSearch.DoubleClick += new System.EventHandler(this.dtgrdSearch_DoubleClick);
            this.dtgrdSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgrdSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Search Type";
            // 
            // frmU_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(416, 449);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dtgrdSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmU_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartOffice Search";
            this.Load += new System.EventHandler(this.frmU_Search_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label LblSrchType;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblMsgHead;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rbtnAnyWhere;
        private System.Windows.Forms.RadioButton rbtnFirstLetter;
        private System.Windows.Forms.DataGridView dtgrdSearch;
        private System.Windows.Forms.Label label1;

    }
}