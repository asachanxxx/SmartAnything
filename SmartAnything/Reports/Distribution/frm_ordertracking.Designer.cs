namespace SmartAnything.Reports
{
    partial class frm_ordertracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ordertracking));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_pdo = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdo_pinv = new System.Windows.Forms.RadioButton();
            this.rdo_pconfirm = new System.Windows.Forms.RadioButton();
            this.rdo_dilivery = new System.Windows.Forms.RadioButton();
            this.rdo_pdispatch = new System.Windows.Forms.RadioButton();
            this.rdo_paudit = new System.Windows.Forms.RadioButton();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_docreated = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.rdo_subcat = new System.Windows.Forms.CheckBox();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.rdo_cat = new System.Windows.Forms.RadioButton();
            this.rdo_supp = new System.Windows.Forms.RadioButton();
            this.txt_subcat_name = new System.Windows.Forms.TextBox();
            this.txt_subcat = new System.Windows.Forms.TextBox();
            this.txt_categoryName = new System.Windows.Forms.TextBox();
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.txt_suppliername = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rdo_summary = new System.Windows.Forms.RadioButton();
            this.rdo_foroneorder = new System.Windows.Forms.RadioButton();
            this.txt_Suplier = new System.Windows.Forms.TextBox();
            this.rdo_fulldetails = new System.Windows.Forms.RadioButton();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(308, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 160;
            // 
            // rdo_pdo
            // 
            this.rdo_pdo.AutoSize = true;
            this.rdo_pdo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_pdo.Location = new System.Drawing.Point(141, 3);
            this.rdo_pdo.Name = "rdo_pdo";
            this.rdo_pdo.Size = new System.Drawing.Size(91, 18);
            this.rdo_pdo.TabIndex = 161;
            this.rdo_pdo.Text = "PENDING DO";
            this.rdo_pdo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdo_pinv);
            this.panel2.Controls.Add(this.rdo_pconfirm);
            this.panel2.Controls.Add(this.rdo_dilivery);
            this.panel2.Controls.Add(this.rdo_pdispatch);
            this.panel2.Controls.Add(this.rdo_paudit);
            this.panel2.Controls.Add(this.rdo_pdo);
            this.panel2.Location = new System.Drawing.Point(127, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 58);
            this.panel2.TabIndex = 162;
            // 
            // rdo_pinv
            // 
            this.rdo_pinv.AutoSize = true;
            this.rdo_pinv.Checked = true;
            this.rdo_pinv.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_pinv.Location = new System.Drawing.Point(9, 3);
            this.rdo_pinv.Name = "rdo_pinv";
            this.rdo_pinv.Size = new System.Drawing.Size(116, 18);
            this.rdo_pinv.TabIndex = 161;
            this.rdo_pinv.TabStop = true;
            this.rdo_pinv.Text = "PENDING INVOICE";
            this.rdo_pinv.UseVisualStyleBackColor = true;
            // 
            // rdo_pconfirm
            // 
            this.rdo_pconfirm.AutoSize = true;
            this.rdo_pconfirm.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_pconfirm.Location = new System.Drawing.Point(287, 27);
            this.rdo_pconfirm.Name = "rdo_pconfirm";
            this.rdo_pconfirm.Size = new System.Drawing.Size(154, 18);
            this.rdo_pconfirm.TabIndex = 161;
            this.rdo_pconfirm.Text = "PENDING CONFIRMATION";
            this.rdo_pconfirm.UseVisualStyleBackColor = true;
            // 
            // rdo_dilivery
            // 
            this.rdo_dilivery.AutoSize = true;
            this.rdo_dilivery.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_dilivery.Location = new System.Drawing.Point(141, 27);
            this.rdo_dilivery.Name = "rdo_dilivery";
            this.rdo_dilivery.Size = new System.Drawing.Size(150, 18);
            this.rdo_dilivery.TabIndex = 161;
            this.rdo_dilivery.Text = "PENDING FOR DELIVERY ";
            this.rdo_dilivery.UseVisualStyleBackColor = true;
            // 
            // rdo_pdispatch
            // 
            this.rdo_pdispatch.AutoSize = true;
            this.rdo_pdispatch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_pdispatch.Location = new System.Drawing.Point(9, 27);
            this.rdo_pdispatch.Name = "rdo_pdispatch";
            this.rdo_pdispatch.Size = new System.Drawing.Size(123, 18);
            this.rdo_pdispatch.TabIndex = 161;
            this.rdo_pdispatch.Text = "PENDING DISPATCH";
            this.rdo_pdispatch.UseVisualStyleBackColor = true;
            // 
            // rdo_paudit
            // 
            this.rdo_paudit.AutoSize = true;
            this.rdo_paudit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_paudit.Location = new System.Drawing.Point(287, 3);
            this.rdo_paudit.Name = "rdo_paudit";
            this.rdo_paudit.Size = new System.Drawing.Size(110, 18);
            this.rdo_paudit.TabIndex = 161;
            this.rdo_paudit.Text = "PENDING AUDIT ";
            this.rdo_paudit.UseVisualStyleBackColor = true;
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
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(12, 314);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(603, 48);
            this.panel5.TabIndex = 157;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(257, 124);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(100, 21);
            this.dtto.TabIndex = 159;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(233, 127);
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
            this.lbl_docreated.Location = new System.Drawing.Point(121, 128);
            this.lbl_docreated.Name = "lbl_docreated";
            this.lbl_docreated.Size = new System.Drawing.Size(0, 19);
            this.lbl_docreated.TabIndex = 157;
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(127, 126);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(100, 21);
            this.dtfrom.TabIndex = 156;
            // 
            // rdo_subcat
            // 
            this.rdo_subcat.AutoSize = true;
            this.rdo_subcat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_subcat.Location = new System.Drawing.Point(14, 95);
            this.rdo_subcat.Name = "rdo_subcat";
            this.rdo_subcat.Size = new System.Drawing.Size(108, 18);
            this.rdo_subcat.TabIndex = 154;
            this.rdo_subcat.Text = "Cus SubCategory";
            this.rdo_subcat.UseVisualStyleBackColor = true;
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
            this.pnl_header.Size = new System.Drawing.Size(622, 45);
            this.pnl_header.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 155;
            this.label2.Text = "Date From";
            // 
            // rdo_cat
            // 
            this.rdo_cat.AutoSize = true;
            this.rdo_cat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_cat.Location = new System.Drawing.Point(14, 63);
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
            this.rdo_supp.Location = new System.Drawing.Point(14, 36);
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
            this.txt_subcat_name.Location = new System.Drawing.Point(212, 91);
            this.txt_subcat_name.Name = "txt_subcat_name";
            this.txt_subcat_name.Size = new System.Drawing.Size(366, 22);
            this.txt_subcat_name.TabIndex = 50;
            // 
            // txt_subcat
            // 
            this.txt_subcat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_subcat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subcat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subcat.Location = new System.Drawing.Point(126, 91);
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
            this.txt_categoryName.Location = new System.Drawing.Point(212, 63);
            this.txt_categoryName.Name = "txt_categoryName";
            this.txt_categoryName.Size = new System.Drawing.Size(366, 22);
            this.txt_categoryName.TabIndex = 47;
            // 
            // txt_Category
            // 
            this.txt_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Category.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category.Location = new System.Drawing.Point(126, 63);
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
            this.txt_suppliername.Location = new System.Drawing.Point(211, 35);
            this.txt_suppliername.Name = "txt_suppliername";
            this.txt_suppliername.Size = new System.Drawing.Size(367, 22);
            this.txt_suppliername.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdo_fulldetails);
            this.panel1.Controls.Add(this.panel3);
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
            this.panel1.Size = new System.Drawing.Size(603, 257);
            this.panel1.TabIndex = 158;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.rdo_summary);
            this.panel3.Controls.Add(this.rdo_foroneorder);
            this.panel3.Location = new System.Drawing.Point(125, 217);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 28);
            this.panel3.TabIndex = 164;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(267, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 22);
            this.textBox1.TabIndex = 163;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(182, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 22);
            this.textBox2.TabIndex = 162;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // rdo_summary
            // 
            this.rdo_summary.AutoSize = true;
            this.rdo_summary.Checked = true;
            this.rdo_summary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_summary.Location = new System.Drawing.Point(9, 7);
            this.rdo_summary.Name = "rdo_summary";
            this.rdo_summary.Size = new System.Drawing.Size(73, 18);
            this.rdo_summary.TabIndex = 161;
            this.rdo_summary.TabStop = true;
            this.rdo_summary.Text = "Summary";
            this.rdo_summary.UseVisualStyleBackColor = true;
            // 
            // rdo_foroneorder
            // 
            this.rdo_foroneorder.AutoSize = true;
            this.rdo_foroneorder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_foroneorder.Location = new System.Drawing.Point(88, 7);
            this.rdo_foroneorder.Name = "rdo_foroneorder";
            this.rdo_foroneorder.Size = new System.Drawing.Size(95, 18);
            this.rdo_foroneorder.TabIndex = 161;
            this.rdo_foroneorder.Text = "For One Order";
            this.rdo_foroneorder.UseVisualStyleBackColor = true;
            // 
            // txt_Suplier
            // 
            this.txt_Suplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Suplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Suplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Suplier.Location = new System.Drawing.Point(126, 35);
            this.txt_Suplier.Name = "txt_Suplier";
            this.txt_Suplier.Size = new System.Drawing.Size(80, 22);
            this.txt_Suplier.TabIndex = 42;
            this.txt_Suplier.TextChanged += new System.EventHandler(this.txt_Suplier_TextChanged);
            this.txt_Suplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Suplier_KeyDown);
            // 
            // rdo_fulldetails
            // 
            this.rdo_fulldetails.AutoSize = true;
            this.rdo_fulldetails.Checked = true;
            this.rdo_fulldetails.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_fulldetails.Location = new System.Drawing.Point(14, 12);
            this.rdo_fulldetails.Name = "rdo_fulldetails";
            this.rdo_fulldetails.Size = new System.Drawing.Size(81, 18);
            this.rdo_fulldetails.TabIndex = 165;
            this.rdo_fulldetails.Text = "Full Details";
            this.rdo_fulldetails.UseVisualStyleBackColor = true;
            // 
            // frm_ordertracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 372);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel1);
            this.Name = "frm_ordertracking";
            this.Text = "frm_ordertracking";
            this.Load += new System.EventHandler(this.frm_ordertracking_Load);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo_pdo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdo_pinv;
        private System.Windows.Forms.RadioButton rdo_pconfirm;
        private System.Windows.Forms.RadioButton rdo_dilivery;
        private System.Windows.Forms.RadioButton rdo_pdispatch;
        private System.Windows.Forms.RadioButton rdo_paudit;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_docreated;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox rdo_subcat;
        private System.Windows.Forms.RadioButton rdo_cat;
        private System.Windows.Forms.RadioButton rdo_supp;
        private System.Windows.Forms.TextBox txt_subcat_name;
        private System.Windows.Forms.TextBox txt_subcat;
        private System.Windows.Forms.TextBox txt_categoryName;
        private System.Windows.Forms.TextBox txt_Category;
        private System.Windows.Forms.TextBox txt_suppliername;
        private System.Windows.Forms.TextBox txt_Suplier;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton rdo_summary;
        private System.Windows.Forms.RadioButton rdo_foroneorder;
        private System.Windows.Forms.RadioButton rdo_fulldetails;
    }
}