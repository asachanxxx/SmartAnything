namespace SmartAnything.UI
{
    partial class frm_sales_itemalloc
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sales_itemalloc));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_addrange = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.dgitems = new System.Windows.Forms.DataGridView();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.dgsalesman = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dte_dateto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dte_datefrom = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdo_daterange = new System.Windows.Forms.RadioButton();
            this.rdo_showall = new System.Windows.Forms.RadioButton();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_itemsearch = new System.Windows.Forms.TextBox();
            this.dgsaved = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.rdo_itemname = new System.Windows.Forms.RadioButton();
            this.rdo_itemcode = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgitems)).BeginInit();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsalesman)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsaved)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Delete.png");
            this.imageList1.Images.SetKeyName(1, "Edit.png");
            this.imageList1.Images.SetKeyName(2, "Exit.png");
            this.imageList1.Images.SetKeyName(3, "Help.png");
            this.imageList1.Images.SetKeyName(4, "New.png");
            this.imageList1.Images.SetKeyName(5, "Print.png");
            this.imageList1.Images.SetKeyName(6, "Save.png");
            this.imageList1.Images.SetKeyName(7, "Search.png");
            this.imageList1.Images.SetKeyName(8, "1434730152_share-icon.png");
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(1041, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(86, 24);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(952, 3);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(83, 24);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.White;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.ImageIndex = 0;
            this.btn_save.ImageList = this.imageList1;
            this.btn_save.Location = new System.Drawing.Point(789, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(83, 28);
            this.btn_save.TabIndex = 60;
            this.btn_save.Text = "        Delete";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.btn_print);
            this.panel1.Location = new System.Drawing.Point(12, 559);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 32);
            this.panel1.TabIndex = 167;
            // 
            // btn_addrange
            // 
            this.btn_addrange.BackColor = System.Drawing.Color.White;
            this.btn_addrange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addrange.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addrange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addrange.ImageIndex = 6;
            this.btn_addrange.ImageList = this.imageList1;
            this.btn_addrange.Location = new System.Drawing.Point(211, 2);
            this.btn_addrange.Name = "btn_addrange";
            this.btn_addrange.Size = new System.Drawing.Size(111, 28);
            this.btn_addrange.TabIndex = 148;
            this.btn_addrange.Text = "        Add Range";
            this.btn_addrange.UseVisualStyleBackColor = false;
            this.btn_addrange.Click += new System.EventHandler(this.btn_addrange_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbl_headerpaneltext
            // 
            this.lbl_headerpaneltext.AutoSize = true;
            this.lbl_headerpaneltext.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_headerpaneltext.ForeColor = System.Drawing.Color.White;
            this.lbl_headerpaneltext.Location = new System.Drawing.Point(4, 1);
            this.lbl_headerpaneltext.Name = "lbl_headerpaneltext";
            this.lbl_headerpaneltext.Size = new System.Drawing.Size(153, 42);
            this.lbl_headerpaneltext.TabIndex = 0;
            this.lbl_headerpaneltext.Text = "...............";
            // 
            // dgitems
            // 
            this.dgitems.AllowUserToDeleteRows = false;
            this.dgitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgitems.Location = new System.Drawing.Point(267, 165);
            this.dgitems.Name = "dgitems";
            this.dgitems.Size = new System.Drawing.Size(323, 345);
            this.dgitems.TabIndex = 166;
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(121)))), ((int)(((byte)(142)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1162, 45);
            this.pnl_header.TabIndex = 165;
            // 
            // dgsalesman
            // 
            this.dgsalesman.AllowUserToDeleteRows = false;
            this.dgsalesman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsalesman.Location = new System.Drawing.Point(12, 108);
            this.dgsalesman.Name = "dgsalesman";
            this.dgsalesman.Size = new System.Drawing.Size(249, 440);
            this.dgsalesman.TabIndex = 167;
            this.dgsalesman.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgsalesman_CellMouseClick);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label4);
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(12, 78);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1138, 26);
            this.panel8.TabIndex = 166;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(598, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "ALLOCATIONS FOR SALESMAN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(251, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "ALLOCATE  PRODUCT QTY FOR SALESMAN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "SELECT SALESMAN";
            // 
            // dte_dateto
            // 
            this.dte_dateto.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dte_dateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_dateto.Location = new System.Drawing.Point(363, 1);
            this.dte_dateto.Name = "dte_dateto";
            this.dte_dateto.Size = new System.Drawing.Size(78, 22);
            this.dte_dateto.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(338, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "To";
            // 
            // dte_datefrom
            // 
            this.dte_datefrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dte_datefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_datefrom.Location = new System.Drawing.Point(247, 2);
            this.dte_datefrom.Name = "dte_datefrom";
            this.dte_datefrom.Size = new System.Drawing.Size(85, 22);
            this.dte_datefrom.TabIndex = 31;
            this.dte_datefrom.ValueChanged += new System.EventHandler(this.dte_datefrom_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdo_daterange);
            this.panel2.Controls.Add(this.rdo_showall);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.dte_datefrom);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dte_dateto);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(12, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1138, 27);
            this.panel2.TabIndex = 168;
            // 
            // rdo_daterange
            // 
            this.rdo_daterange.AutoSize = true;
            this.rdo_daterange.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdo_daterange.ForeColor = System.Drawing.Color.White;
            this.rdo_daterange.Location = new System.Drawing.Point(159, 4);
            this.rdo_daterange.Name = "rdo_daterange";
            this.rdo_daterange.Size = new System.Drawing.Size(81, 18);
            this.rdo_daterange.TabIndex = 37;
            this.rdo_daterange.Text = "Date From";
            this.rdo_daterange.UseVisualStyleBackColor = true;
            // 
            // rdo_showall
            // 
            this.rdo_showall.AutoSize = true;
            this.rdo_showall.Checked = true;
            this.rdo_showall.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdo_showall.ForeColor = System.Drawing.Color.White;
            this.rdo_showall.Location = new System.Drawing.Point(17, 4);
            this.rdo_showall.Name = "rdo_showall";
            this.rdo_showall.Size = new System.Drawing.Size(136, 18);
            this.rdo_showall.TabIndex = 36;
            this.rdo_showall.TabStop = true;
            this.rdo_showall.Text = "Show all allocations";
            this.rdo_showall.UseVisualStyleBackColor = true;
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(447, 1);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 35;
            this.btn_search.Text = "Filter";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_itemsearch
            // 
            this.txt_itemsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_itemsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_itemsearch.BackColor = System.Drawing.Color.White;
            this.txt_itemsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_itemsearch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemsearch.ForeColor = System.Drawing.Color.Black;
            this.txt_itemsearch.Location = new System.Drawing.Point(61, 5);
            this.txt_itemsearch.Name = "txt_itemsearch";
            this.txt_itemsearch.Size = new System.Drawing.Size(183, 22);
            this.txt_itemsearch.TabIndex = 34;
            // 
            // dgsaved
            // 
            this.dgsaved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsaved.Location = new System.Drawing.Point(596, 108);
            this.dgsaved.Name = "dgsaved";
            this.dgsaved.ReadOnly = true;
            this.dgsaved.Size = new System.Drawing.Size(554, 402);
            this.dgsaved.TabIndex = 170;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.rdo_itemname);
            this.panel3.Controls.Add(this.rdo_itemcode);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txt_itemsearch);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(267, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 51);
            this.panel3.TabIndex = 171;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(247, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdo_itemname
            // 
            this.rdo_itemname.AutoSize = true;
            this.rdo_itemname.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdo_itemname.ForeColor = System.Drawing.Color.White;
            this.rdo_itemname.Location = new System.Drawing.Point(144, 28);
            this.rdo_itemname.Name = "rdo_itemname";
            this.rdo_itemname.Size = new System.Drawing.Size(85, 18);
            this.rdo_itemname.TabIndex = 38;
            this.rdo_itemname.Text = "Item Name";
            this.rdo_itemname.UseVisualStyleBackColor = true;
            // 
            // rdo_itemcode
            // 
            this.rdo_itemcode.AutoSize = true;
            this.rdo_itemcode.Checked = true;
            this.rdo_itemcode.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdo_itemcode.ForeColor = System.Drawing.Color.White;
            this.rdo_itemcode.Location = new System.Drawing.Point(61, 28);
            this.rdo_itemcode.Name = "rdo_itemcode";
            this.rdo_itemcode.Size = new System.Drawing.Size(80, 18);
            this.rdo_itemcode.TabIndex = 37;
            this.rdo_itemcode.TabStop = true;
            this.rdo_itemcode.Text = "Item Code";
            this.rdo_itemcode.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Filter By";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_addrange);
            this.panel4.Controls.Add(this.btn_save);
            this.panel4.ForeColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(267, 513);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(883, 35);
            this.panel4.TabIndex = 172;
            // 
            // frm_sales_itemalloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 597);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgsalesman);
            this.Controls.Add(this.dgsaved);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgitems);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_sales_itemalloc";
            this.Text = "frm_sales_itemalloc";
            this.Load += new System.EventHandler(this.frm_sales_itemalloc_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgitems)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsalesman)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsaved)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgitems;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dte_datefrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dte_dateto;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_itemsearch;
        private System.Windows.Forms.DataGridView dgsaved;
        private System.Windows.Forms.Button btn_addrange;
        private System.Windows.Forms.DataGridView dgsalesman;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdo_daterange;
        private System.Windows.Forms.RadioButton rdo_showall;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdo_itemname;
        private System.Windows.Forms.RadioButton rdo_itemcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
    }
}