namespace SmartAnything.UI
{
    partial class frm_do
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_do));
            this.txt_InvNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_processes = new System.Windows.Forms.Label();
            this.dte_Datex = new System.Windows.Forms.DateTimePicker();
            this.txt_DoNo = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NoOfCartons = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Customer_name = new System.Windows.Forms.TextBox();
            this.txt_Lorry_name = new System.Windows.Forms.TextBox();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.txt_Lorry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_docreated = new System.Windows.Forms.Label();
            this.txt_InvoiceAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.txt_Agent_name = new System.Windows.Forms.TextBox();
            this.txt_Agent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_InvNo
            // 
            this.txt_InvNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txt_InvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_InvNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_InvNo.Location = new System.Drawing.Point(440, 5);
            this.txt_InvNo.Name = "txt_InvNo";
            this.txt_InvNo.Size = new System.Drawing.Size(99, 22);
            this.txt_InvNo.TabIndex = 60;
            this.txt_InvNo.TextChanged += new System.EventHandler(this.txt_InvNo_TextChanged);
            this.txt_InvNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_InvNo_KeyDown);
            this.txt_InvNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_InvNo_KeyPress);
            this.txt_InvNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_InvNo_KeyUp);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(374, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 14);
            this.label20.TabIndex = 61;
            this.label20.Text = "Invoice No";
            // 
            // lbl_processes
            // 
            this.lbl_processes.AutoSize = true;
            this.lbl_processes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_processes.ForeColor = System.Drawing.Color.Red;
            this.lbl_processes.Location = new System.Drawing.Point(188, 4);
            this.lbl_processes.Name = "lbl_processes";
            this.lbl_processes.Size = new System.Drawing.Size(102, 23);
            this.lbl_processes.TabIndex = 47;
            this.lbl_processes.Text = "PROCESSED";
            this.lbl_processes.Visible = false;
            // 
            // dte_Datex
            // 
            this.dte_Datex.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte_Datex.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_Datex.Location = new System.Drawing.Point(737, 4);
            this.dte_Datex.Name = "dte_Datex";
            this.dte_Datex.Size = new System.Drawing.Size(100, 21);
            this.dte_Datex.TabIndex = 27;
            this.dte_Datex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dte_Datex_KeyDown);
            // 
            // txt_DoNo
            // 
            this.txt_DoNo.BackColor = System.Drawing.Color.White;
            this.txt_DoNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DoNo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DoNo.Location = new System.Drawing.Point(83, 6);
            this.txt_DoNo.Name = "txt_DoNo";
            this.txt_DoNo.Size = new System.Drawing.Size(99, 21);
            this.txt_DoNo.TabIndex = 3;
            this.txt_DoNo.TextChanged += new System.EventHandler(this.txt_DoNo_TextChanged);
            this.txt_DoNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DoNo_KeyDown);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "DO No";
            // 
            // txt_NoOfCartons
            // 
            this.txt_NoOfCartons.BackColor = System.Drawing.Color.White;
            this.txt_NoOfCartons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NoOfCartons.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txt_NoOfCartons.ForeColor = System.Drawing.Color.Black;
            this.txt_NoOfCartons.Location = new System.Drawing.Point(777, 3);
            this.txt_NoOfCartons.Name = "txt_NoOfCartons";
            this.txt_NoOfCartons.ReadOnly = true;
            this.txt_NoOfCartons.Size = new System.Drawing.Size(95, 22);
            this.txt_NoOfCartons.TabIndex = 127;
            this.txt_NoOfCartons.Text = "0.00";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 319);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(882, 139);
            this.dataGridView1.TabIndex = 148;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(12, 495);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(882, 48);
            this.panel5.TabIndex = 150;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_cancel);
            this.panel4.Controls.Add(this.btn_new);
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_save);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Controls.Add(this.btn_delete);
            this.panel4.Location = new System.Drawing.Point(183, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(688, 47);
            this.panel4.TabIndex = 65;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.White;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancel.ImageIndex = 8;
            this.btn_cancel.ImageList = this.imageList1;
            this.btn_cancel.Location = new System.Drawing.Point(497, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(91, 35);
            this.btn_cancel.TabIndex = 64;
            this.btn_cancel.Text = "       Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.White;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_new.ImageIndex = 4;
            this.btn_new.ImageList = this.imageList1;
            this.btn_new.Location = new System.Drawing.Point(12, 4);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(91, 35);
            this.btn_new.TabIndex = 58;
            this.btn_new.Text = "     New";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(594, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.White;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.ImageIndex = 6;
            this.btn_save.ImageList = this.imageList1;
            this.btn_save.Location = new System.Drawing.Point(109, 4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 35);
            this.btn_save.TabIndex = 59;
            this.btn_save.Text = "     Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(400, 4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.White;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.ImageIndex = 1;
            this.btn_edit.ImageList = this.imageList1;
            this.btn_edit.Location = new System.Drawing.Point(206, 4);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(91, 35);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.Text = "      Process";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.White;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.ImageIndex = 0;
            this.btn_delete.ImageList = this.imageList1;
            this.btn_delete.Location = new System.Drawing.Point(303, 4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(91, 35);
            this.btn_delete.TabIndex = 61;
            this.btn_delete.Text = "     Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(656, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Creation Date";
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
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(121)))), ((int)(((byte)(142)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(906, 45);
            this.pnl_header.TabIndex = 146;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_Customer_name);
            this.panel3.Controls.Add(this.txt_Lorry_name);
            this.panel3.Controls.Add(this.txt_Customer);
            this.panel3.Controls.Add(this.txt_Lorry);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txt_Remarks);
            this.panel3.Controls.Add(this.txt_Agent_name);
            this.panel3.Controls.Add(this.txt_Agent);
            this.panel3.Controls.Add(this.label6);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(12, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(882, 92);
            this.panel3.TabIndex = 147;
            // 
            // txt_Customer_name
            // 
            this.txt_Customer_name.BackColor = System.Drawing.Color.White;
            this.txt_Customer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer_name.Location = new System.Drawing.Point(196, 40);
            this.txt_Customer_name.Name = "txt_Customer_name";
            this.txt_Customer_name.ReadOnly = true;
            this.txt_Customer_name.Size = new System.Drawing.Size(182, 21);
            this.txt_Customer_name.TabIndex = 79;
            // 
            // txt_Lorry_name
            // 
            this.txt_Lorry_name.BackColor = System.Drawing.Color.White;
            this.txt_Lorry_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Lorry_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Lorry_name.Location = new System.Drawing.Point(196, 63);
            this.txt_Lorry_name.Name = "txt_Lorry_name";
            this.txt_Lorry_name.ReadOnly = true;
            this.txt_Lorry_name.Size = new System.Drawing.Size(182, 21);
            this.txt_Lorry_name.TabIndex = 76;
            // 
            // txt_Customer
            // 
            this.txt_Customer.BackColor = System.Drawing.Color.White;
            this.txt_Customer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer.Location = new System.Drawing.Point(90, 40);
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.ReadOnly = true;
            this.txt_Customer.Size = new System.Drawing.Size(100, 21);
            this.txt_Customer.TabIndex = 77;
            this.txt_Customer.TextChanged += new System.EventHandler(this.txt_Customer_TextChanged);
            this.txt_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // txt_Lorry
            // 
            this.txt_Lorry.BackColor = System.Drawing.Color.White;
            this.txt_Lorry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Lorry.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Lorry.Location = new System.Drawing.Point(90, 63);
            this.txt_Lorry.Name = "txt_Lorry";
            this.txt_Lorry.Size = new System.Drawing.Size(100, 21);
            this.txt_Lorry.TabIndex = 74;
            this.txt_Lorry.TextChanged += new System.EventHandler(this.txt_Lorry_TextChanged);
            this.txt_Lorry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Lorry_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(30, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 78;
            this.label7.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(42, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 75;
            this.label5.Text = "Vehicle";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_docreated);
            this.panel1.Controls.Add(this.txt_InvoiceAmount);
            this.panel1.Controls.Add(this.txt_DoNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_processes);
            this.panel1.Controls.Add(this.txt_InvNo);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.dte_Datex);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 33);
            this.panel1.TabIndex = 73;
            // 
            // lbl_docreated
            // 
            this.lbl_docreated.AutoSize = true;
            this.lbl_docreated.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_docreated.ForeColor = System.Drawing.Color.Red;
            this.lbl_docreated.Location = new System.Drawing.Point(731, 6);
            this.lbl_docreated.Name = "lbl_docreated";
            this.lbl_docreated.Size = new System.Drawing.Size(0, 19);
            this.lbl_docreated.TabIndex = 63;
            // 
            // txt_InvoiceAmount
            // 
            this.txt_InvoiceAmount.BackColor = System.Drawing.Color.White;
            this.txt_InvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_InvoiceAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_InvoiceAmount.Location = new System.Drawing.Point(545, 5);
            this.txt_InvoiceAmount.Name = "txt_InvoiceAmount";
            this.txt_InvoiceAmount.ReadOnly = true;
            this.txt_InvoiceAmount.Size = new System.Drawing.Size(104, 22);
            this.txt_InvoiceAmount.TabIndex = 62;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(390, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 59;
            this.label13.Text = "Remarks";
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.BackColor = System.Drawing.Color.White;
            this.txt_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Remarks.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Remarks.Location = new System.Drawing.Point(447, 63);
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(430, 21);
            this.txt_Remarks.TabIndex = 58;
            this.txt_Remarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Remarks_KeyDown);
            // 
            // txt_Agent_name
            // 
            this.txt_Agent_name.BackColor = System.Drawing.Color.White;
            this.txt_Agent_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Agent_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Agent_name.Location = new System.Drawing.Point(553, 40);
            this.txt_Agent_name.Name = "txt_Agent_name";
            this.txt_Agent_name.ReadOnly = true;
            this.txt_Agent_name.Size = new System.Drawing.Size(182, 21);
            this.txt_Agent_name.TabIndex = 52;
            // 
            // txt_Agent
            // 
            this.txt_Agent.BackColor = System.Drawing.Color.White;
            this.txt_Agent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Agent.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Agent.Location = new System.Drawing.Point(447, 40);
            this.txt_Agent.Name = "txt_Agent";
            this.txt_Agent.Size = new System.Drawing.Size(100, 21);
            this.txt_Agent.TabIndex = 50;
            this.txt_Agent.TextChanged += new System.EventHandler(this.txt_Agent_TextChanged);
            this.txt_Agent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Agent_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(405, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "Agent";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txt_NoOfCartons);
            this.panel6.ForeColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(12, 464);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(882, 29);
            this.panel6.TabIndex = 151;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(693, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 128;
            this.label4.Text = "Total Cartons";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 161);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(882, 152);
            this.dataGridView2.TabIndex = 152;
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // frm_do
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 555);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel3);
            this.Name = "frm_do";
            this.Text = "frm_do";
            this.Load += new System.EventHandler(this.frm_do_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_InvNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_processes;
        private System.Windows.Forms.DateTimePicker dte_Datex;
        private System.Windows.Forms.TextBox txt_DoNo;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.TextBox txt_Agent_name;
        private System.Windows.Forms.TextBox txt_Agent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_InvoiceAmount;
        private System.Windows.Forms.TextBox txt_Lorry_name;
        private System.Windows.Forms.TextBox txt_Lorry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_NoOfCartons;
        private System.Windows.Forms.TextBox txt_Customer_name;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbl_docreated;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}