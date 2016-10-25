namespace SmartAnything.UI
{
    partial class frm_sales_customer_alloc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sales_customer_alloc));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.dte_to = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_date = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_salesman = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdo_fulldetails = new System.Windows.Forms.RadioButton();
            this.btn_search = new System.Windows.Forms.Button();
            this.dgsaved = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgsalesman = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fullqty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_qtyremain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgcustomer = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsaved)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsalesman)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcustomer)).BeginInit();
            this.panel5.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 549);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 56);
            this.panel1.TabIndex = 163;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Location = new System.Drawing.Point(683, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 47);
            this.panel4.TabIndex = 147;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(227, 6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
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
            this.btn_print.Location = new System.Drawing.Point(130, 6);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.White;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.ImageIndex = 1;
            this.btn_edit.ImageList = this.imageList1;
            this.btn_edit.Location = new System.Drawing.Point(31, 6);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(93, 35);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.Text = "        Save";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Visible = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(121)))), ((int)(((byte)(142)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Controls.Add(this.dte_from);
            this.pnl_header.Controls.Add(this.dte_to);
            this.pnl_header.Controls.Add(this.label7);
            this.pnl_header.Controls.Add(this.label6);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1037, 45);
            this.pnl_header.TabIndex = 160;
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
            // dte_from
            // 
            this.dte_from.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dte_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_from.Location = new System.Drawing.Point(409, 11);
            this.dte_from.Name = "dte_from";
            this.dte_from.Size = new System.Drawing.Size(76, 22);
            this.dte_from.TabIndex = 31;
            this.dte_from.Visible = false;
            // 
            // dte_to
            // 
            this.dte_to.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dte_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_to.Location = new System.Drawing.Point(516, 10);
            this.dte_to.Name = "dte_to";
            this.dte_to.Size = new System.Drawing.Size(78, 22);
            this.dte_to.TabIndex = 29;
            this.dte_to.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(491, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 14);
            this.label7.TabIndex = 30;
            this.label7.Text = "To";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(369, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "From";
            this.label6.Visible = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "user.png");
            this.imageList2.Images.SetKeyName(1, "user-chat.png");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txt_date);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.txt_salesman);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.rdo_fulldetails);
            this.panel6.Controls.Add(this.btn_search);
            this.panel6.ForeColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(14, 47);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(920, 27);
            this.panel6.TabIndex = 169;
            // 
            // txt_date
            // 
            this.txt_date.AutoSize = true;
            this.txt_date.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_date.Location = new System.Drawing.Point(278, 5);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(71, 15);
            this.txt_date.TabIndex = 170;
            this.txt_date.Text = "SALESMAN:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(240, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 15);
            this.label10.TabIndex = 169;
            this.label10.Text = "DATE:";
            // 
            // txt_salesman
            // 
            this.txt_salesman.AutoSize = true;
            this.txt_salesman.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_salesman.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_salesman.Location = new System.Drawing.Point(163, 5);
            this.txt_salesman.Name = "txt_salesman";
            this.txt_salesman.Size = new System.Drawing.Size(71, 15);
            this.txt_salesman.TabIndex = 168;
            this.txt_salesman.Text = "SALESMAN:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(95, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 167;
            this.label5.Text = "SALESMAN:";
            // 
            // rdo_fulldetails
            // 
            this.rdo_fulldetails.AutoSize = true;
            this.rdo_fulldetails.Checked = true;
            this.rdo_fulldetails.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_fulldetails.ForeColor = System.Drawing.Color.White;
            this.rdo_fulldetails.Location = new System.Drawing.Point(8, 4);
            this.rdo_fulldetails.Name = "rdo_fulldetails";
            this.rdo_fulldetails.Size = new System.Drawing.Size(81, 18);
            this.rdo_fulldetails.TabIndex = 166;
            this.rdo_fulldetails.TabStop = true;
            this.rdo_fulldetails.Text = "Full Details";
            this.rdo_fulldetails.UseVisualStyleBackColor = true;
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(844, 1);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 35;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dgsaved
            // 
            this.dgsaved.AllowUserToOrderColumns = true;
            this.dgsaved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsaved.Location = new System.Drawing.Point(14, 334);
            this.dgsaved.Name = "dgsaved";
            this.dgsaved.ReadOnly = true;
            this.dgsaved.Size = new System.Drawing.Size(920, 209);
            this.dgsaved.TabIndex = 172;
            this.dgsaved.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsaved_RowEnter);
            this.dgsaved.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgsaved_RowsRemoved_1);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.dgsalesman);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(14, 80);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(458, 250);
            this.panel7.TabIndex = 171;
            // 
            // dgsalesman
            // 
            this.dgsalesman.AllowUserToDeleteRows = false;
            this.dgsalesman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsalesman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsalesman.Location = new System.Drawing.Point(0, 26);
            this.dgsalesman.Name = "dgsalesman";
            this.dgsalesman.ReadOnly = true;
            this.dgsalesman.Size = new System.Drawing.Size(456, 222);
            this.dgsalesman.TabIndex = 167;
            this.dgsalesman.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgsalesman_CellMouseClick);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(456, 26);
            this.panel8.TabIndex = 166;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(376, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "Load Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "SELECT ALLOCATION";
            // 
            // txt_fullqty
            // 
            this.txt_fullqty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_fullqty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_fullqty.BackColor = System.Drawing.Color.White;
            this.txt_fullqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fullqty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fullqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(60)))), ((int)(((byte)(11)))));
            this.txt_fullqty.Location = new System.Drawing.Point(5, 26);
            this.txt_fullqty.Name = "txt_fullqty";
            this.txt_fullqty.ReadOnly = true;
            this.txt_fullqty.Size = new System.Drawing.Size(71, 22);
            this.txt_fullqty.TabIndex = 173;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 174;
            this.label1.Text = "Full QTY";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txt_qtyremain);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_fullqty);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(940, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(81, 496);
            this.panel2.TabIndex = 175;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(5, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 23);
            this.button3.TabIndex = 180;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(5, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 179;
            this.button1.Text = "Add>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_qtyremain
            // 
            this.txt_qtyremain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_qtyremain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_qtyremain.BackColor = System.Drawing.Color.White;
            this.txt_qtyremain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_qtyremain.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qtyremain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(60)))), ((int)(((byte)(11)))));
            this.txt_qtyremain.Location = new System.Drawing.Point(5, 71);
            this.txt_qtyremain.Name = "txt_qtyremain";
            this.txt_qtyremain.ReadOnly = true;
            this.txt_qtyremain.Size = new System.Drawing.Size(71, 22);
            this.txt_qtyremain.TabIndex = 177;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 14);
            this.label3.TabIndex = 178;
            this.label3.Text = "Remaining";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgcustomer);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(478, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(456, 248);
            this.panel3.TabIndex = 176;
            // 
            // dgcustomer
            // 
            this.dgcustomer.AllowUserToDeleteRows = false;
            this.dgcustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcustomer.Location = new System.Drawing.Point(0, 26);
            this.dgcustomer.Name = "dgcustomer";
            this.dgcustomer.Size = new System.Drawing.Size(454, 220);
            this.dgcustomer.TabIndex = 167;
            this.dgcustomer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgcustomer_CellValueChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(454, 26);
            this.panel5.TabIndex = 166;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "ENTER BREAKDOWN";
            // 
            // frm_sales_customer_alloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 620);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgsaved);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_sales_customer_alloc";
            this.Text = "frm_sales_customer_alloc";
            this.Load += new System.EventHandler(this.frm_sales_customer_alloc_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsaved)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsalesman)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcustomer)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dte_to;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_qtyremain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_fullqty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgsaved;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgsalesman;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgcustomer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdo_fulldetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txt_salesman;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label txt_date;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
    }
}