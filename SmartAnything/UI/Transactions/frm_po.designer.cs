﻿namespace SmartAnything.UI
{
    partial class frm_po
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_po));
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_grossAmount = new System.Windows.Forms.TextBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_noOfPeaces = new System.Windows.Forms.TextBox();
            this.txt_net = new System.Windows.Forms.TextBox();
            this.txt_noOfItems = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.txt_amt = new System.Windows.Forms.TextBox();
            this.lbl_processes = new System.Windows.Forms.Label();
            this.txt_locationId_name = new System.Windows.Forms.TextBox();
            this.txt_supplierId_name = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_supplierId = new System.Windows.Forms.TextBox();
            this.dte_DeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_selling = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_cost = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_DLocationID_name = new System.Windows.Forms.TextBox();
            this.txt_DLocationID = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_pReqNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_reqLocationId_name = new System.Windows.Forms.TextBox();
            this.txt_reqLocationId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dte_date = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_locationId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_no = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(21, 523);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(814, 65);
            this.panel5.TabIndex = 108;
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
            this.panel4.Location = new System.Drawing.Point(111, 11);
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
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(121)))), ((int)(((byte)(142)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(851, 45);
            this.pnl_header.TabIndex = 103;
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
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.White;
            this.lbl_name.Location = new System.Drawing.Point(12, 46);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(19, 14);
            this.lbl_name.TabIndex = 10;
            this.lbl_name.Text = "....";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(640, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(534, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "Quntity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(545, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 101;
            this.label3.Text = "GROSS AMOUNT";
            // 
            // txt_grossAmount
            // 
            this.txt_grossAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_grossAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_grossAmount.Location = new System.Drawing.Point(663, 3);
            this.txt_grossAmount.Name = "txt_grossAmount";
            this.txt_grossAmount.ReadOnly = true;
            this.txt_grossAmount.Size = new System.Drawing.Size(136, 23);
            this.txt_grossAmount.TabIndex = 100;
            // 
            // txt_qty
            // 
            this.txt_qty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_qty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_qty.BackColor = System.Drawing.Color.White;
            this.txt_qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_qty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_qty.Location = new System.Drawing.Point(537, 23);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(100, 22);
            this.txt_qty.TabIndex = 6;
            this.txt_qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_qty_KeyDown);
            this.txt_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_qty_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(195, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 18);
            this.label15.TabIndex = 99;
            this.label15.Text = "NO OF ITEMS";
            // 
            // txt_noOfPeaces
            // 
            this.txt_noOfPeaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_noOfPeaces.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_noOfPeaces.Location = new System.Drawing.Point(105, 7);
            this.txt_noOfPeaces.Name = "txt_noOfPeaces";
            this.txt_noOfPeaces.ReadOnly = true;
            this.txt_noOfPeaces.Size = new System.Drawing.Size(76, 23);
            this.txt_noOfPeaces.TabIndex = 96;
            // 
            // txt_net
            // 
            this.txt_net.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_net.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_net.Location = new System.Drawing.Point(663, 28);
            this.txt_net.Name = "txt_net";
            this.txt_net.ReadOnly = true;
            this.txt_net.Size = new System.Drawing.Size(136, 23);
            this.txt_net.TabIndex = 94;
            // 
            // txt_noOfItems
            // 
            this.txt_noOfItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_noOfItems.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_noOfItems.Location = new System.Drawing.Point(293, 7);
            this.txt_noOfItems.Name = "txt_noOfItems";
            this.txt_noOfItems.ReadOnly = true;
            this.txt_noOfItems.Size = new System.Drawing.Size(76, 23);
            this.txt_noOfItems.TabIndex = 98;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(563, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 18);
            this.label17.TabIndex = 95;
            this.label17.Text = "NET AMOUNT";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(7, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 18);
            this.label16.TabIndex = 97;
            this.label16.Text = "NO OF PIECES";
            // 
            // txt_amt
            // 
            this.txt_amt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_amt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_amt.BackColor = System.Drawing.Color.White;
            this.txt_amt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_amt.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_amt.Location = new System.Drawing.Point(643, 23);
            this.txt_amt.Name = "txt_amt";
            this.txt_amt.ReadOnly = true;
            this.txt_amt.Size = new System.Drawing.Size(151, 22);
            this.txt_amt.TabIndex = 8;
            // 
            // lbl_processes
            // 
            this.lbl_processes.AutoSize = true;
            this.lbl_processes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_processes.ForeColor = System.Drawing.Color.Red;
            this.lbl_processes.Location = new System.Drawing.Point(240, 6);
            this.lbl_processes.Name = "lbl_processes";
            this.lbl_processes.Size = new System.Drawing.Size(102, 23);
            this.lbl_processes.TabIndex = 47;
            this.lbl_processes.Text = "PROCESSED";
            this.lbl_processes.Visible = false;
            // 
            // txt_locationId_name
            // 
            this.txt_locationId_name.BackColor = System.Drawing.Color.White;
            this.txt_locationId_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_locationId_name.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_locationId_name.Location = new System.Drawing.Point(199, 31);
            this.txt_locationId_name.Name = "txt_locationId_name";
            this.txt_locationId_name.ReadOnly = true;
            this.txt_locationId_name.Size = new System.Drawing.Size(182, 21);
            this.txt_locationId_name.TabIndex = 46;
            // 
            // txt_supplierId_name
            // 
            this.txt_supplierId_name.BackColor = System.Drawing.Color.White;
            this.txt_supplierId_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_supplierId_name.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_supplierId_name.Location = new System.Drawing.Point(199, 55);
            this.txt_supplierId_name.Name = "txt_supplierId_name";
            this.txt_supplierId_name.ReadOnly = true;
            this.txt_supplierId_name.Size = new System.Drawing.Size(182, 21);
            this.txt_supplierId_name.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(52, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 43;
            this.label13.Text = "Supplier";
            // 
            // txt_supplierId
            // 
            this.txt_supplierId.BackColor = System.Drawing.Color.White;
            this.txt_supplierId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_supplierId.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_supplierId.Location = new System.Drawing.Point(105, 55);
            this.txt_supplierId.Name = "txt_supplierId";
            this.txt_supplierId.Size = new System.Drawing.Size(88, 21);
            this.txt_supplierId.TabIndex = 42;
            this.txt_supplierId.TextChanged += new System.EventHandler(this.txt_supplierId_TextChanged);
            this.txt_supplierId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_supplierId_KeyDown);
            // 
            // dte_DeliveryDate
            // 
            this.dte_DeliveryDate.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.dte_DeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_DeliveryDate.Location = new System.Drawing.Point(322, 77);
            this.dte_DeliveryDate.Name = "dte_DeliveryDate";
            this.dte_DeliveryDate.Size = new System.Drawing.Size(128, 21);
            this.dte_DeliveryDate.TabIndex = 28;
            this.dte_DeliveryDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dte_DeliveryDate_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_grossAmount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_noOfPeaces);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txt_net);
            this.panel2.Controls.Add(this.txt_noOfItems);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(21, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 55);
            this.panel2.TabIndex = 107;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_amt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_qty);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_selling);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_cost);
            this.panel1.Controls.Add(this.txt_code);
            this.panel1.Controls.Add(this.label14);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(21, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 66);
            this.panel1.TabIndex = 106;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(412, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 14);
            this.label9.TabIndex = 5;
            this.label9.Text = "Selling Price";
            // 
            // txt_selling
            // 
            this.txt_selling.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_selling.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_selling.BackColor = System.Drawing.Color.White;
            this.txt_selling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_selling.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_selling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_selling.Location = new System.Drawing.Point(415, 23);
            this.txt_selling.Name = "txt_selling";
            this.txt_selling.ReadOnly = true;
            this.txt_selling.Size = new System.Drawing.Size(116, 22);
            this.txt_selling.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(290, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "Cost Price";
            // 
            // txt_cost
            // 
            this.txt_cost.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_cost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_cost.BackColor = System.Drawing.Color.White;
            this.txt_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cost.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_cost.Location = new System.Drawing.Point(293, 23);
            this.txt_cost.Name = "txt_cost";
            this.txt_cost.ReadOnly = true;
            this.txt_cost.Size = new System.Drawing.Size(116, 22);
            this.txt_cost.TabIndex = 2;
            // 
            // txt_code
            // 
            this.txt_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_code.BackColor = System.Drawing.Color.White;
            this.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_code.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_code.Location = new System.Drawing.Point(15, 23);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(272, 22);
            this.txt_code.TabIndex = 1;
            this.txt_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_code_KeyDown);
            this.txt_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_code_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(12, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Item Code";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(814, 195);
            this.dataGridView1.TabIndex = 105;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_DLocationID_name);
            this.panel3.Controls.Add(this.txt_DLocationID);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txt_pReqNo);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txt_reqLocationId_name);
            this.panel3.Controls.Add(this.txt_reqLocationId);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lbl_processes);
            this.panel3.Controls.Add(this.txt_locationId_name);
            this.panel3.Controls.Add(this.txt_supplierId_name);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txt_supplierId);
            this.panel3.Controls.Add(this.dte_DeliveryDate);
            this.panel3.Controls.Add(this.dte_date);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txt_remarks);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txt_locationId);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_no);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(21, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 135);
            this.panel3.TabIndex = 104;
            // 
            // txt_DLocationID_name
            // 
            this.txt_DLocationID_name.BackColor = System.Drawing.Color.White;
            this.txt_DLocationID_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DLocationID_name.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_DLocationID_name.Location = new System.Drawing.Point(612, 55);
            this.txt_DLocationID_name.Name = "txt_DLocationID_name";
            this.txt_DLocationID_name.ReadOnly = true;
            this.txt_DLocationID_name.Size = new System.Drawing.Size(182, 21);
            this.txt_DLocationID_name.TabIndex = 55;
            // 
            // txt_DLocationID
            // 
            this.txt_DLocationID.BackColor = System.Drawing.Color.White;
            this.txt_DLocationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DLocationID.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_DLocationID.Location = new System.Drawing.Point(518, 55);
            this.txt_DLocationID.Name = "txt_DLocationID";
            this.txt_DLocationID.Size = new System.Drawing.Size(88, 21);
            this.txt_DLocationID.TabIndex = 53;
            this.txt_DLocationID.TextChanged += new System.EventHandler(this.txt_DLocationID_TextChanged);
            this.txt_DLocationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DLocationID_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(421, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 14);
            this.label18.TabIndex = 54;
            this.label18.Text = "Delivery  Location";
            // 
            // txt_pReqNo
            // 
            this.txt_pReqNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txt_pReqNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pReqNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pReqNo.Location = new System.Drawing.Point(518, 6);
            this.txt_pReqNo.Name = "txt_pReqNo";
            this.txt_pReqNo.Size = new System.Drawing.Size(139, 22);
            this.txt_pReqNo.TabIndex = 51;
            this.txt_pReqNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pReqNo_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(453, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 14);
            this.label12.TabIndex = 52;
            this.label12.Text = "Request No";
            // 
            // txt_reqLocationId_name
            // 
            this.txt_reqLocationId_name.BackColor = System.Drawing.Color.White;
            this.txt_reqLocationId_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_reqLocationId_name.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_reqLocationId_name.Location = new System.Drawing.Point(612, 31);
            this.txt_reqLocationId_name.Name = "txt_reqLocationId_name";
            this.txt_reqLocationId_name.ReadOnly = true;
            this.txt_reqLocationId_name.Size = new System.Drawing.Size(182, 21);
            this.txt_reqLocationId_name.TabIndex = 50;
            // 
            // txt_reqLocationId
            // 
            this.txt_reqLocationId.BackColor = System.Drawing.Color.White;
            this.txt_reqLocationId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_reqLocationId.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_reqLocationId.Location = new System.Drawing.Point(518, 31);
            this.txt_reqLocationId.Name = "txt_reqLocationId";
            this.txt_reqLocationId.Size = new System.Drawing.Size(88, 21);
            this.txt_reqLocationId.TabIndex = 48;
            this.txt_reqLocationId.TextChanged += new System.EventHandler(this.txt_reqLocationId_TextChanged);
            this.txt_reqLocationId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_reqLocationId_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(426, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 49;
            this.label5.Text = "Request Location";
            // 
            // dte_date
            // 
            this.dte_date.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.dte_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_date.Location = new System.Drawing.Point(105, 78);
            this.dte_date.Name = "dte_date";
            this.dte_date.Size = new System.Drawing.Size(128, 21);
            this.dte_date.TabIndex = 27;
            this.dte_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dte_date_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(48, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 14);
            this.label10.TabIndex = 26;
            this.label10.Text = "Remarks";
            // 
            // txt_remarks
            // 
            this.txt_remarks.BackColor = System.Drawing.Color.White;
            this.txt_remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_remarks.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_remarks.Location = new System.Drawing.Point(105, 105);
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(689, 21);
            this.txt_remarks.TabIndex = 25;
            this.txt_remarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_remarks_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(240, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Delivary Date";
            // 
            // txt_locationId
            // 
            this.txt_locationId.BackColor = System.Drawing.Color.White;
            this.txt_locationId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_locationId.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_locationId.Location = new System.Drawing.Point(105, 31);
            this.txt_locationId.Name = "txt_locationId";
            this.txt_locationId.ReadOnly = true;
            this.txt_locationId.Size = new System.Drawing.Size(88, 21);
            this.txt_locationId.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(51, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Location";
            // 
            // txt_no
            // 
            this.txt_no.BackColor = System.Drawing.Color.White;
            this.txt_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_no.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_no.Location = new System.Drawing.Point(105, 8);
            this.txt_no.Name = "txt_no";
            this.txt_no.Size = new System.Drawing.Size(128, 21);
            this.txt_no.TabIndex = 3;
            this.txt_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_no_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Purchse Order No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Request Date";
            // 
            // frm_po
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 609);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Name = "frm_po";
            this.Text = "frm_po";
            this.Load += new System.EventHandler(this.frm_po_Load);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_grossAmount;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_noOfPeaces;
        private System.Windows.Forms.TextBox txt_net;
        private System.Windows.Forms.TextBox txt_noOfItems;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_amt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_selling;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_cost;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_processes;
        private System.Windows.Forms.TextBox txt_locationId_name;
        private System.Windows.Forms.TextBox txt_supplierId_name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_supplierId;
        private System.Windows.Forms.DateTimePicker dte_DeliveryDate;
        private System.Windows.Forms.DateTimePicker dte_date;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_locationId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_no;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_reqLocationId_name;
        private System.Windows.Forms.TextBox txt_reqLocationId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_pReqNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_DLocationID_name;
        private System.Windows.Forms.TextBox txt_DLocationID;
        private System.Windows.Forms.Label label18;
    }
}