namespace SmartAnything.UI
{
    partial class frm_seccenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_seccenter));
            this.btn_exit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_userx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Customer_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_acc = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_set = new System.Windows.Forms.Button();
            this.chk_print = new System.Windows.Forms.CheckBox();
            this.chk_del = new System.Windows.Forms.CheckBox();
            this.chk_mod = new System.Windows.Forms.CheckBox();
            this.chk_create = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlUserDtl = new System.Windows.Forms.Panel();
            this.txtusergroup_name = new System.Windows.Forms.Label();
            this.txtusergroup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUCode = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblNormlBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.lblPw = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.lblUName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRePw = new System.Windows.Forms.TextBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlUserDtl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(138, 6);
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
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Location = new System.Drawing.Point(697, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(239, 47);
            this.panel4.TabIndex = 147;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(41, 6);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 467);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 56);
            this.panel1.TabIndex = 171;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(384, 328);
            this.dataGridView1.TabIndex = 170;
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
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1282, 45);
            this.pnl_header.TabIndex = 169;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.button1);
            this.panel7.Controls.Add(this.txt_userx);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.txt_Customer_name);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(12, 51);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(932, 35);
            this.panel7.TabIndex = 173;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(301, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 23);
            this.button4.TabIndex = 185;
            this.button4.Text = "Apply Default Rights";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(301, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 184;
            this.button1.Text = "Create User";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_userx
            // 
            this.txt_userx.BackColor = System.Drawing.Color.White;
            this.txt_userx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_userx.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userx.Location = new System.Drawing.Point(47, 6);
            this.txt_userx.MaxLength = 20;
            this.txt_userx.Name = "txt_userx";
            this.txt_userx.Size = new System.Drawing.Size(74, 21);
            this.txt_userx.TabIndex = 50;
            this.txt_userx.TextChanged += new System.EventHandler(this.txt_userx_TextChanged);
            this.txt_userx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_userx_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(11, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "User";
            // 
            // txt_Customer_name
            // 
            this.txt_Customer_name.BackColor = System.Drawing.Color.White;
            this.txt_Customer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer_name.Location = new System.Drawing.Point(125, 6);
            this.txt_Customer_name.Name = "txt_Customer_name";
            this.txt_Customer_name.ReadOnly = true;
            this.txt_Customer_name.Size = new System.Drawing.Size(170, 21);
            this.txt_Customer_name.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 174;
            this.label3.Text = "MENU RIGHTS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 17);
            this.label1.TabIndex = 175;
            this.label1.Text = "[ACMDP] – [A-Access] , [C-Create] , [M-Modify], [D-Delete], [P-Print]   ";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(425, 113);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(519, 311);
            this.dataGridView2.TabIndex = 176;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseClick);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 21);
            this.label2.TabIndex = 177;
            this.label2.Text = "APPLIED RIGHTS ";
            // 
            // chk_acc
            // 
            this.chk_acc.AutoSize = true;
            this.chk_acc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_acc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_acc.Location = new System.Drawing.Point(6, 6);
            this.chk_acc.Name = "chk_acc";
            this.chk_acc.Size = new System.Drawing.Size(61, 19);
            this.chk_acc.TabIndex = 178;
            this.chk_acc.Text = "Access";
            this.chk_acc.UseVisualStyleBackColor = true;
            this.chk_acc.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_set);
            this.panel2.Controls.Add(this.chk_print);
            this.panel2.Controls.Add(this.chk_del);
            this.panel2.Controls.Add(this.chk_mod);
            this.panel2.Controls.Add(this.chk_create);
            this.panel2.Controls.Add(this.chk_acc);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(425, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 31);
            this.panel2.TabIndex = 179;
            // 
            // btn_set
            // 
            this.btn_set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_set.Location = new System.Drawing.Point(439, 2);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(75, 23);
            this.btn_set.TabIndex = 183;
            this.btn_set.Text = "Apply";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // chk_print
            // 
            this.chk_print.AutoSize = true;
            this.chk_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_print.Location = new System.Drawing.Point(266, 6);
            this.chk_print.Name = "chk_print";
            this.chk_print.Size = new System.Drawing.Size(51, 19);
            this.chk_print.TabIndex = 182;
            this.chk_print.Text = "Print";
            this.chk_print.UseVisualStyleBackColor = true;
            this.chk_print.Visible = false;
            // 
            // chk_del
            // 
            this.chk_del.AutoSize = true;
            this.chk_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_del.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_del.Location = new System.Drawing.Point(202, 6);
            this.chk_del.Name = "chk_del";
            this.chk_del.Size = new System.Drawing.Size(58, 19);
            this.chk_del.TabIndex = 181;
            this.chk_del.Text = "Delete";
            this.chk_del.UseVisualStyleBackColor = true;
            this.chk_del.Visible = false;
            // 
            // chk_mod
            // 
            this.chk_mod.AutoSize = true;
            this.chk_mod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_mod.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_mod.Location = new System.Drawing.Point(138, 6);
            this.chk_mod.Name = "chk_mod";
            this.chk_mod.Size = new System.Drawing.Size(63, 19);
            this.chk_mod.TabIndex = 180;
            this.chk_mod.Text = "Modify";
            this.chk_mod.UseVisualStyleBackColor = true;
            this.chk_mod.Visible = false;
            // 
            // chk_create
            // 
            this.chk_create.AutoSize = true;
            this.chk_create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_create.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_create.Location = new System.Drawing.Point(73, 6);
            this.chk_create.Name = "chk_create";
            this.chk_create.Size = new System.Drawing.Size(59, 19);
            this.chk_create.TabIndex = 179;
            this.chk_create.Text = "Create";
            this.chk_create.UseVisualStyleBackColor = true;
            this.chk_create.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.pnlUserDtl);
            this.panel3.Location = new System.Drawing.Point(259, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 311);
            this.panel3.TabIndex = 180;
            this.panel3.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(254, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 312;
            this.button3.Text = "Create User";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(335, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 311;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlUserDtl
            // 
            this.pnlUserDtl.BackColor = System.Drawing.Color.Silver;
            this.pnlUserDtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserDtl.Controls.Add(this.txtusergroup_name);
            this.pnlUserDtl.Controls.Add(this.txtusergroup);
            this.pnlUserDtl.Controls.Add(this.label5);
            this.pnlUserDtl.Controls.Add(this.txtUCode);
            this.pnlUserDtl.Controls.Add(this.txtUserID);
            this.pnlUserDtl.Controls.Add(this.lblNormlBalance);
            this.pnlUserDtl.Controls.Add(this.label4);
            this.pnlUserDtl.Controls.Add(this.txtmobile);
            this.pnlUserDtl.Controls.Add(this.label7);
            this.pnlUserDtl.Controls.Add(this.txtLName);
            this.pnlUserDtl.Controls.Add(this.lblPw);
            this.pnlUserDtl.Controls.Add(this.txtFname);
            this.pnlUserDtl.Controls.Add(this.label8);
            this.pnlUserDtl.Controls.Add(this.txtUName);
            this.pnlUserDtl.Controls.Add(this.lblUName);
            this.pnlUserDtl.Controls.Add(this.label9);
            this.pnlUserDtl.Controls.Add(this.txtRePw);
            this.pnlUserDtl.Controls.Add(this.txtPw);
            this.pnlUserDtl.Location = new System.Drawing.Point(7, 3);
            this.pnlUserDtl.Name = "pnlUserDtl";
            this.pnlUserDtl.Size = new System.Drawing.Size(403, 265);
            this.pnlUserDtl.TabIndex = 310;
            // 
            // txtusergroup_name
            // 
            this.txtusergroup_name.AutoSize = true;
            this.txtusergroup_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusergroup_name.ForeColor = System.Drawing.Color.Black;
            this.txtusergroup_name.Location = new System.Drawing.Point(130, 237);
            this.txtusergroup_name.Name = "txtusergroup_name";
            this.txtusergroup_name.Size = new System.Drawing.Size(19, 14);
            this.txtusergroup_name.TabIndex = 317;
            this.txtusergroup_name.Text = "<>";
            // 
            // txtusergroup
            // 
            this.txtusergroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtusergroup.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusergroup.Location = new System.Drawing.Point(133, 211);
            this.txtusergroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtusergroup.MaxLength = 50;
            this.txtusergroup.Name = "txtusergroup";
            this.txtusergroup.Size = new System.Drawing.Size(241, 22);
            this.txtusergroup.TabIndex = 316;
            this.txtusergroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtusergroup_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 14);
            this.label5.TabIndex = 315;
            this.label5.Text = "User Code";
            // 
            // txtUCode
            // 
            this.txtUCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUCode.Location = new System.Drawing.Point(133, 14);
            this.txtUCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUCode.MaxLength = 50;
            this.txtUCode.Name = "txtUCode";
            this.txtUCode.Size = new System.Drawing.Size(149, 22);
            this.txtUCode.TabIndex = 2;
            this.txtUCode.TextChanged += new System.EventHandler(this.txtUCode_TextChanged);
            // 
            // txtUserID
            // 
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(91, 14);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserID.MaxLength = 50;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(37, 22);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.Visible = false;
            // 
            // lblNormlBalance
            // 
            this.lblNormlBalance.AutoSize = true;
            this.lblNormlBalance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormlBalance.ForeColor = System.Drawing.Color.Black;
            this.lblNormlBalance.Location = new System.Drawing.Point(9, 219);
            this.lblNormlBalance.Name = "lblNormlBalance";
            this.lblNormlBalance.Size = new System.Drawing.Size(68, 14);
            this.lblNormlBalance.TabIndex = 306;
            this.lblNormlBalance.Text = "User Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Last Name";
            // 
            // txtmobile
            // 
            this.txtmobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmobile.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmobile.Location = new System.Drawing.Point(133, 128);
            this.txtmobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmobile.MaxLength = 50;
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(241, 22);
            this.txtmobile.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "First Name";
            // 
            // txtLName
            // 
            this.txtLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLName.Location = new System.Drawing.Point(133, 186);
            this.txtLName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLName.MaxLength = 50;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(241, 22);
            this.txtLName.TabIndex = 8;
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPw.ForeColor = System.Drawing.Color.Black;
            this.lblPw.Location = new System.Drawing.Point(9, 73);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(59, 14);
            this.lblPw.TabIndex = 23;
            this.lblPw.Text = "Password";
            // 
            // txtFname
            // 
            this.txtFname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.Location = new System.Drawing.Point(133, 157);
            this.txtFname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFname.MaxLength = 50;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(241, 22);
            this.txtFname.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(9, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 14);
            this.label8.TabIndex = 308;
            this.label8.Text = "Mobile";
            // 
            // txtUName
            // 
            this.txtUName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUName.Location = new System.Drawing.Point(133, 42);
            this.txtUName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUName.MaxLength = 50;
            this.txtUName.Name = "txtUName";
            this.txtUName.Size = new System.Drawing.Size(241, 22);
            this.txtUName.TabIndex = 3;
            // 
            // lblUName
            // 
            this.lblUName.AutoSize = true;
            this.lblUName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUName.ForeColor = System.Drawing.Color.Black;
            this.lblUName.Location = new System.Drawing.Point(9, 44);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(67, 14);
            this.lblUName.TabIndex = 22;
            this.lblUName.Text = "User Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(9, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "Confirm Password";
            // 
            // txtRePw
            // 
            this.txtRePw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRePw.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRePw.Location = new System.Drawing.Point(133, 99);
            this.txtRePw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRePw.MaxLength = 50;
            this.txtRePw.Name = "txtRePw";
            this.txtRePw.PasswordChar = '*';
            this.txtRePw.Size = new System.Drawing.Size(241, 22);
            this.txtRePw.TabIndex = 5;
            // 
            // txtPw
            // 
            this.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPw.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPw.Location = new System.Drawing.Point(133, 70);
            this.txtPw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPw.MaxLength = 50;
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(241, 22);
            this.txtPw.TabIndex = 4;
            // 
            // frm_seccenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 535);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_seccenter";
            this.Text = "frm_seccenter";
            this.Load += new System.EventHandler(this.frm_seccenter_Load);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlUserDtl.ResumeLayout(false);
            this.pnlUserDtl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txt_userx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Customer_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox chk_acc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.CheckBox chk_print;
        private System.Windows.Forms.CheckBox chk_del;
        private System.Windows.Forms.CheckBox chk_mod;
        private System.Windows.Forms.CheckBox chk_create;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlUserDtl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUCode;
        public System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblNormlBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmobile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUName;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRePw;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label txtusergroup_name;
        private System.Windows.Forms.TextBox txtusergroup;
    }
}