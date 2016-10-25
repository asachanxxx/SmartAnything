namespace SmartAnything.Reports
{
    partial class frm_pendingApprovals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_pendingApprovals));
            this.rdo_subcat = new System.Windows.Forms.CheckBox();
            this.rdo_cat = new System.Windows.Forms.RadioButton();
            this.rdo_supp = new System.Windows.Forms.RadioButton();
            this.txt_subcat_name = new System.Windows.Forms.TextBox();
            this.txt_subcat = new System.Windows.Forms.TextBox();
            this.txt_categoryName = new System.Windows.Forms.TextBox();
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.txt_suppliername = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdo_orderform = new System.Windows.Forms.RadioButton();
            this.rdo_invoice = new System.Windows.Forms.RadioButton();
            this.rdo_DO = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_docreated = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Suplier = new System.Windows.Forms.TextBox();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.rdo_fulldet = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdo_subcat
            // 
            this.rdo_subcat.AutoSize = true;
            this.rdo_subcat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_subcat.Location = new System.Drawing.Point(14, 97);
            this.rdo_subcat.Name = "rdo_subcat";
            this.rdo_subcat.Size = new System.Drawing.Size(108, 18);
            this.rdo_subcat.TabIndex = 154;
            this.rdo_subcat.Text = "Cus SubCategory";
            this.rdo_subcat.UseVisualStyleBackColor = true;
            // 
            // rdo_cat
            // 
            this.rdo_cat.AutoSize = true;
            this.rdo_cat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_cat.Location = new System.Drawing.Point(14, 65);
            this.rdo_cat.Name = "rdo_cat";
            this.rdo_cat.Size = new System.Drawing.Size(89, 18);
            this.rdo_cat.TabIndex = 153;
            this.rdo_cat.Text = "Cus Category";
            this.rdo_cat.UseVisualStyleBackColor = true;
            // 
            // rdo_supp
            // 
            this.rdo_supp.AutoSize = true;
            this.rdo_supp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_supp.Location = new System.Drawing.Point(14, 38);
            this.rdo_supp.Name = "rdo_supp";
            this.rdo_supp.Size = new System.Drawing.Size(72, 18);
            this.rdo_supp.TabIndex = 51;
            this.rdo_supp.Text = "Customer";
            this.rdo_supp.UseVisualStyleBackColor = true;
            // 
            // txt_subcat_name
            // 
            this.txt_subcat_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_subcat_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subcat_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subcat_name.Location = new System.Drawing.Point(212, 93);
            this.txt_subcat_name.Name = "txt_subcat_name";
            this.txt_subcat_name.Size = new System.Drawing.Size(366, 22);
            this.txt_subcat_name.TabIndex = 50;
            // 
            // txt_subcat
            // 
            this.txt_subcat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_subcat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subcat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subcat.Location = new System.Drawing.Point(126, 93);
            this.txt_subcat.Name = "txt_subcat";
            this.txt_subcat.Size = new System.Drawing.Size(80, 22);
            this.txt_subcat.TabIndex = 49;
            this.txt_subcat.TextChanged += new System.EventHandler(this.txt_subcat_TextChanged);
            this.txt_subcat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_subcat_KeyDown);
            // 
            // txt_categoryName
            // 
            this.txt_categoryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_categoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_categoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_categoryName.Location = new System.Drawing.Point(212, 65);
            this.txt_categoryName.Name = "txt_categoryName";
            this.txt_categoryName.Size = new System.Drawing.Size(366, 22);
            this.txt_categoryName.TabIndex = 47;
            // 
            // txt_Category
            // 
            this.txt_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Category.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category.Location = new System.Drawing.Point(126, 65);
            this.txt_Category.Name = "txt_Category";
            this.txt_Category.Size = new System.Drawing.Size(80, 22);
            this.txt_Category.TabIndex = 46;
            this.txt_Category.TextChanged += new System.EventHandler(this.txt_Category_TextChanged);
            this.txt_Category.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Category_KeyDown);
            // 
            // txt_suppliername
            // 
            this.txt_suppliername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_suppliername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_suppliername.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_suppliername.Location = new System.Drawing.Point(211, 37);
            this.txt_suppliername.Name = "txt_suppliername";
            this.txt_suppliername.Size = new System.Drawing.Size(367, 22);
            this.txt_suppliername.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdo_fulldet);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_docreated);
            this.panel1.Controls.Add(this.dtfrom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rdo_subcat);
            this.panel1.Controls.Add(this.rdo_cat);
            this.panel1.Controls.Add(this.rdo_supp);
            this.panel1.Controls.Add(this.txt_subcat_name);
            this.panel1.Controls.Add(this.txt_subcat);
            this.panel1.Controls.Add(this.txt_categoryName);
            this.panel1.Controls.Add(this.txt_Category);
            this.panel1.Controls.Add(this.txt_suppliername);
            this.panel1.Controls.Add(this.txt_Suplier);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 200);
            this.panel1.TabIndex = 155;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdo_orderform);
            this.panel2.Controls.Add(this.rdo_invoice);
            this.panel2.Controls.Add(this.rdo_DO);
            this.panel2.Location = new System.Drawing.Point(125, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 26);
            this.panel2.TabIndex = 162;
            // 
            // rdo_orderform
            // 
            this.rdo_orderform.AutoSize = true;
            this.rdo_orderform.Checked = true;
            this.rdo_orderform.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_orderform.Location = new System.Drawing.Point(9, 3);
            this.rdo_orderform.Name = "rdo_orderform";
            this.rdo_orderform.Size = new System.Drawing.Size(124, 18);
            this.rdo_orderform.TabIndex = 161;
            this.rdo_orderform.TabStop = true;
            this.rdo_orderform.Text = "Order Form Pending";
            this.rdo_orderform.UseVisualStyleBackColor = true;
            // 
            // rdo_invoice
            // 
            this.rdo_invoice.AutoSize = true;
            this.rdo_invoice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_invoice.Location = new System.Drawing.Point(132, 3);
            this.rdo_invoice.Name = "rdo_invoice";
            this.rdo_invoice.Size = new System.Drawing.Size(102, 18);
            this.rdo_invoice.TabIndex = 161;
            this.rdo_invoice.Text = "Invoice Pending";
            this.rdo_invoice.UseVisualStyleBackColor = true;
            // 
            // rdo_DO
            // 
            this.rdo_DO.AutoSize = true;
            this.rdo_DO.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_DO.Location = new System.Drawing.Point(240, 3);
            this.rdo_DO.Name = "rdo_DO";
            this.rdo_DO.Size = new System.Drawing.Size(83, 18);
            this.rdo_DO.TabIndex = 161;
            this.rdo_DO.Text = "DO Pending";
            this.rdo_DO.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(308, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 160;
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(257, 126);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(100, 21);
            this.dtto.TabIndex = 159;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(233, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 14);
            this.label3.TabIndex = 158;
            this.label3.Text = "To";
            // 
            // lbl_docreated
            // 
            this.lbl_docreated.AutoSize = true;
            this.lbl_docreated.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_docreated.ForeColor = System.Drawing.Color.Red;
            this.lbl_docreated.Location = new System.Drawing.Point(121, 130);
            this.lbl_docreated.Name = "lbl_docreated";
            this.lbl_docreated.Size = new System.Drawing.Size(0, 19);
            this.lbl_docreated.TabIndex = 157;
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(127, 128);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(100, 21);
            this.dtfrom.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 155;
            this.label2.Text = "Date From";
            // 
            // txt_Suplier
            // 
            this.txt_Suplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Suplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Suplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Suplier.Location = new System.Drawing.Point(126, 37);
            this.txt_Suplier.Name = "txt_Suplier";
            this.txt_Suplier.Size = new System.Drawing.Size(80, 22);
            this.txt_Suplier.TabIndex = 42;
            this.txt_Suplier.TextChanged += new System.EventHandler(this.txt_Suplier_TextChanged);
            this.txt_Suplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Suplier_KeyDown);
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
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(368, 4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(465, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(12, 257);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(603, 48);
            this.panel5.TabIndex = 154;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Location = new System.Drawing.Point(33, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(565, 44);
            this.panel4.TabIndex = 65;
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
            this.pnl_header.Size = new System.Drawing.Size(627, 45);
            this.pnl_header.TabIndex = 153;
            // 
            // rdo_fulldet
            // 
            this.rdo_fulldet.AutoSize = true;
            this.rdo_fulldet.Checked = true;
            this.rdo_fulldet.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_fulldet.Location = new System.Drawing.Point(14, 14);
            this.rdo_fulldet.Name = "rdo_fulldet";
            this.rdo_fulldet.Size = new System.Drawing.Size(81, 18);
            this.rdo_fulldet.TabIndex = 163;
            this.rdo_fulldet.TabStop = true;
            this.rdo_fulldet.Text = "Full Details";
            this.rdo_fulldet.UseVisualStyleBackColor = true;
            // 
            // frm_pendingApprovals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 317);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_pendingApprovals";
            this.Text = "frm_pendingApprovals";
            this.Load += new System.EventHandler(this.frm_pendingApprovals_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox rdo_subcat;
        private System.Windows.Forms.RadioButton rdo_cat;
        private System.Windows.Forms.RadioButton rdo_supp;
        private System.Windows.Forms.TextBox txt_subcat_name;
        private System.Windows.Forms.TextBox txt_subcat;
        private System.Windows.Forms.TextBox txt_categoryName;
        private System.Windows.Forms.TextBox txt_Category;
        private System.Windows.Forms.TextBox txt_suppliername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Suplier;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_docreated;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdo_invoice;
        private System.Windows.Forms.RadioButton rdo_DO;
        private System.Windows.Forms.RadioButton rdo_orderform;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdo_fulldet;
    }
}