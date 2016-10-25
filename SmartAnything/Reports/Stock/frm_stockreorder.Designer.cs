﻿namespace SmartAnything.Reports.Stock
{
    partial class frm_stockreorder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stockreorder));
            this.rdo_product = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.txt_loca2_name = new System.Windows.Forms.TextBox();
            this.Chk_allLoca = new System.Windows.Forms.CheckBox();
            this.txt_loca2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_loca1 = new System.Windows.Forms.TextBox();
            this.txt_loca1_name = new System.Windows.Forms.TextBox();
            this.txt_product2 = new System.Windows.Forms.TextBox();
            this.rdo_fast = new System.Windows.Forms.RadioButton();
            this.rdo_slow = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdo_location = new System.Windows.Forms.RadioButton();
            this.chk_AllCategory = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Category1 = new System.Windows.Forms.TextBox();
            this.txt_Category1_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.txt_Category_name = new System.Windows.Forms.TextBox();
            this.rdo_category = new System.Windows.Forms.RadioButton();
            this.chk_Allproduct = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_product2_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_product1 = new System.Windows.Forms.TextBox();
            this.txt_product1_name = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rdo_all = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo_lotwise = new System.Windows.Forms.RadioButton();
            this.rdo_productwise = new System.Windows.Forms.RadioButton();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdo_product
            // 
            this.rdo_product.AutoSize = true;
            this.rdo_product.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_product.Location = new System.Drawing.Point(20, 85);
            this.rdo_product.Name = "rdo_product";
            this.rdo_product.Size = new System.Drawing.Size(80, 18);
            this.rdo_product.TabIndex = 156;
            this.rdo_product.Text = "Product/lot";
            this.rdo_product.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btn_print);
            this.panel5.Controls.Add(this.btn_exit);
            this.panel5.Location = new System.Drawing.Point(6, 395);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(641, 48);
            this.panel5.TabIndex = 168;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(446, 5);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
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
            this.btn_exit.Location = new System.Drawing.Point(540, 5);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txt_loca2_name
            // 
            this.txt_loca2_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca2_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca2_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca2_name.Location = new System.Drawing.Point(422, 4);
            this.txt_loca2_name.Name = "txt_loca2_name";
            this.txt_loca2_name.Size = new System.Drawing.Size(167, 22);
            this.txt_loca2_name.TabIndex = 157;
            // 
            // Chk_allLoca
            // 
            this.Chk_allLoca.AutoSize = true;
            this.Chk_allLoca.Checked = true;
            this.Chk_allLoca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_allLoca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.Chk_allLoca.Location = new System.Drawing.Point(92, 24);
            this.Chk_allLoca.Name = "Chk_allLoca";
            this.Chk_allLoca.Size = new System.Drawing.Size(43, 18);
            this.Chk_allLoca.TabIndex = 155;
            this.Chk_allLoca.Text = "ALL";
            this.Chk_allLoca.UseVisualStyleBackColor = true;
            // 
            // txt_loca2
            // 
            this.txt_loca2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca2.Location = new System.Drawing.Point(348, 4);
            this.txt_loca2.Name = "txt_loca2";
            this.txt_loca2.Size = new System.Drawing.Size(68, 22);
            this.txt_loca2.TabIndex = 156;
            this.txt_loca2.Text = "001";
            this.txt_loca2.TextChanged += new System.EventHandler(this.txt_loca2_TextChanged);
            this.txt_loca2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loca2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(316, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 14);
            this.label2.TabIndex = 158;
            this.label2.Text = "To";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.txt_loca2);
            this.panel8.Controls.Add(this.txt_loca2_name);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.txt_loca1);
            this.panel8.Controls.Add(this.txt_loca1_name);
            this.panel8.Location = new System.Drawing.Point(20, 47);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(608, 34);
            this.panel8.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 14);
            this.label1.TabIndex = 155;
            this.label1.Text = "From";
            // 
            // txt_loca1
            // 
            this.txt_loca1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca1.Location = new System.Drawing.Point(56, 4);
            this.txt_loca1.Name = "txt_loca1";
            this.txt_loca1.Size = new System.Drawing.Size(68, 22);
            this.txt_loca1.TabIndex = 42;
            this.txt_loca1.Text = "001";
            this.txt_loca1.TextChanged += new System.EventHandler(this.txt_loca1_TextChanged);
            this.txt_loca1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loca1_KeyDown);
            // 
            // txt_loca1_name
            // 
            this.txt_loca1_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca1_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca1_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca1_name.Location = new System.Drawing.Point(130, 4);
            this.txt_loca1_name.Name = "txt_loca1_name";
            this.txt_loca1_name.Size = new System.Drawing.Size(167, 22);
            this.txt_loca1_name.TabIndex = 44;
            // 
            // txt_product2
            // 
            this.txt_product2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_product2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product2.Location = new System.Drawing.Point(348, 4);
            this.txt_product2.Name = "txt_product2";
            this.txt_product2.Size = new System.Drawing.Size(68, 22);
            this.txt_product2.TabIndex = 156;
            this.txt_product2.TextChanged += new System.EventHandler(this.txt_product2_TextChanged);
            this.txt_product2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_product2_KeyDown);
            // 
            // rdo_fast
            // 
            this.rdo_fast.AutoSize = true;
            this.rdo_fast.Checked = true;
            this.rdo_fast.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_fast.Location = new System.Drawing.Point(97, 6);
            this.rdo_fast.Name = "rdo_fast";
            this.rdo_fast.Size = new System.Drawing.Size(122, 18);
            this.rdo_fast.TabIndex = 163;
            this.rdo_fast.TabStop = true;
            this.rdo_fast.Text = "SIH < Reorder Level";
            this.rdo_fast.UseVisualStyleBackColor = true;
            // 
            // rdo_slow
            // 
            this.rdo_slow.AutoSize = true;
            this.rdo_slow.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_slow.Location = new System.Drawing.Point(97, 30);
            this.rdo_slow.Name = "rdo_slow";
            this.rdo_slow.Size = new System.Drawing.Size(122, 18);
            this.rdo_slow.TabIndex = 162;
            this.rdo_slow.Text = "SIH > Reorder Level";
            this.rdo_slow.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(14, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 14);
            this.label8.TabIndex = 161;
            this.label8.Text = "Item Range";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.radioButton1);
            this.panel7.Controls.Add(this.radioButton2);
            this.panel7.Controls.Add(this.rdo_fast);
            this.panel7.Controls.Add(this.rdo_slow);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(20, 216);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(608, 63);
            this.panel7.TabIndex = 163;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton1.Location = new System.Drawing.Point(225, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(122, 18);
            this.radioButton1.TabIndex = 165;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SIH = Reorder Level";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(225, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(38, 18);
            this.radioButton2.TabIndex = 164;
            this.radioButton2.Text = "All";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(316, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 14);
            this.label3.TabIndex = 158;
            this.label3.Text = "To";
            // 
            // rdo_location
            // 
            this.rdo_location.AutoSize = true;
            this.rdo_location.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_location.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_location.Location = new System.Drawing.Point(20, 23);
            this.rdo_location.Name = "rdo_location";
            this.rdo_location.Size = new System.Drawing.Size(66, 18);
            this.rdo_location.TabIndex = 51;
            this.rdo_location.Text = "Location";
            this.rdo_location.UseVisualStyleBackColor = true;
            // 
            // chk_AllCategory
            // 
            this.chk_AllCategory.AutoSize = true;
            this.chk_AllCategory.Checked = true;
            this.chk_AllCategory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_AllCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_AllCategory.Location = new System.Drawing.Point(92, 150);
            this.chk_AllCategory.Name = "chk_AllCategory";
            this.chk_AllCategory.Size = new System.Drawing.Size(43, 18);
            this.chk_AllCategory.TabIndex = 161;
            this.chk_AllCategory.Text = "ALL";
            this.chk_AllCategory.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdo_all);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.chk_AllCategory);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.rdo_category);
            this.panel2.Controls.Add(this.chk_Allproduct);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.rdo_product);
            this.panel2.Controls.Add(this.Chk_allLoca);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.rdo_location);
            this.panel2.Location = new System.Drawing.Point(6, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 287);
            this.panel2.TabIndex = 169;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_Category1);
            this.panel3.Controls.Add(this.txt_Category1_name);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txt_Category);
            this.panel3.Controls.Add(this.txt_Category_name);
            this.panel3.Location = new System.Drawing.Point(20, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(608, 34);
            this.panel3.TabIndex = 160;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(316, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 14);
            this.label5.TabIndex = 158;
            this.label5.Text = "To";
            // 
            // txt_Category1
            // 
            this.txt_Category1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Category1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Category1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category1.Location = new System.Drawing.Point(348, 4);
            this.txt_Category1.Name = "txt_Category1";
            this.txt_Category1.Size = new System.Drawing.Size(68, 22);
            this.txt_Category1.TabIndex = 156;
            this.txt_Category1.TextChanged += new System.EventHandler(this.txt_Category1_TextChanged);
            this.txt_Category1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Category1_KeyDown);
            // 
            // txt_Category1_name
            // 
            this.txt_Category1_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Category1_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Category1_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category1_name.Location = new System.Drawing.Point(422, 4);
            this.txt_Category1_name.Name = "txt_Category1_name";
            this.txt_Category1_name.Size = new System.Drawing.Size(167, 22);
            this.txt_Category1_name.TabIndex = 157;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(14, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 155;
            this.label6.Text = "From";
            // 
            // txt_Category
            // 
            this.txt_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Category.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category.Location = new System.Drawing.Point(56, 4);
            this.txt_Category.Name = "txt_Category";
            this.txt_Category.Size = new System.Drawing.Size(68, 22);
            this.txt_Category.TabIndex = 42;
            this.txt_Category.TextChanged += new System.EventHandler(this.txt_Category_TextChanged);
            this.txt_Category.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Category_KeyDown);
            // 
            // txt_Category_name
            // 
            this.txt_Category_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Category_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Category_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category_name.Location = new System.Drawing.Point(130, 4);
            this.txt_Category_name.Name = "txt_Category_name";
            this.txt_Category_name.Size = new System.Drawing.Size(167, 22);
            this.txt_Category_name.TabIndex = 44;
            // 
            // rdo_category
            // 
            this.rdo_category.AutoSize = true;
            this.rdo_category.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_category.Location = new System.Drawing.Point(20, 149);
            this.rdo_category.Name = "rdo_category";
            this.rdo_category.Size = new System.Drawing.Size(69, 18);
            this.rdo_category.TabIndex = 159;
            this.rdo_category.Text = "Category";
            this.rdo_category.UseVisualStyleBackColor = true;
            // 
            // chk_Allproduct
            // 
            this.chk_Allproduct.AutoSize = true;
            this.chk_Allproduct.Checked = true;
            this.chk_Allproduct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Allproduct.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_Allproduct.Location = new System.Drawing.Point(102, 86);
            this.chk_Allproduct.Name = "chk_Allproduct";
            this.chk_Allproduct.Size = new System.Drawing.Size(43, 18);
            this.chk_Allproduct.TabIndex = 158;
            this.chk_Allproduct.Text = "ALL";
            this.chk_Allproduct.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txt_product2);
            this.panel4.Controls.Add(this.txt_product2_name);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txt_product1);
            this.panel4.Controls.Add(this.txt_product1_name);
            this.panel4.Location = new System.Drawing.Point(20, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(608, 34);
            this.panel4.TabIndex = 157;
            // 
            // txt_product2_name
            // 
            this.txt_product2_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_product2_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product2_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product2_name.Location = new System.Drawing.Point(422, 4);
            this.txt_product2_name.Name = "txt_product2_name";
            this.txt_product2_name.Size = new System.Drawing.Size(167, 22);
            this.txt_product2_name.TabIndex = 157;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(14, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 155;
            this.label4.Text = "From";
            // 
            // txt_product1
            // 
            this.txt_product1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_product1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product1.Location = new System.Drawing.Point(56, 4);
            this.txt_product1.Name = "txt_product1";
            this.txt_product1.Size = new System.Drawing.Size(68, 22);
            this.txt_product1.TabIndex = 42;
            this.txt_product1.TextChanged += new System.EventHandler(this.txt_product1_TextChanged);
            this.txt_product1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_product1_KeyDown);
            // 
            // txt_product1_name
            // 
            this.txt_product1_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_product1_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product1_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product1_name.Location = new System.Drawing.Point(130, 4);
            this.txt_product1_name.Name = "txt_product1_name";
            this.txt_product1_name.Size = new System.Drawing.Size(167, 22);
            this.txt_product1_name.TabIndex = 44;
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
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(121)))), ((int)(((byte)(142)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(656, 45);
            this.pnl_header.TabIndex = 167;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.panel1);
            this.panel9.Location = new System.Drawing.Point(6, 47);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(641, 49);
            this.panel9.TabIndex = 170;
            // 
            // rdo_all
            // 
            this.rdo_all.AutoSize = true;
            this.rdo_all.Checked = true;
            this.rdo_all.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_all.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_all.Location = new System.Drawing.Point(20, 3);
            this.rdo_all.Name = "rdo_all";
            this.rdo_all.Size = new System.Drawing.Size(132, 18);
            this.rdo_all.TabIndex = 165;
            this.rdo_all.TabStop = true;
            this.rdo_all.Text = "No filtering(Show All)";
            this.rdo_all.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Purple;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdo_lotwise);
            this.panel1.Controls.Add(this.rdo_productwise);
            this.panel1.Location = new System.Drawing.Point(3, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 32);
            this.panel1.TabIndex = 164;
            // 
            // rdo_lotwise
            // 
            this.rdo_lotwise.AutoSize = true;
            this.rdo_lotwise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_lotwise.ForeColor = System.Drawing.Color.White;
            this.rdo_lotwise.Location = new System.Drawing.Point(124, 6);
            this.rdo_lotwise.Name = "rdo_lotwise";
            this.rdo_lotwise.Size = new System.Drawing.Size(73, 19);
            this.rdo_lotwise.TabIndex = 53;
            this.rdo_lotwise.Text = "Lot Wise";
            this.rdo_lotwise.UseVisualStyleBackColor = true;
            // 
            // rdo_productwise
            // 
            this.rdo_productwise.AutoSize = true;
            this.rdo_productwise.Checked = true;
            this.rdo_productwise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_productwise.ForeColor = System.Drawing.Color.White;
            this.rdo_productwise.Location = new System.Drawing.Point(20, 6);
            this.rdo_productwise.Name = "rdo_productwise";
            this.rdo_productwise.Size = new System.Drawing.Size(98, 19);
            this.rdo_productwise.TabIndex = 52;
            this.rdo_productwise.TabStop = true;
            this.rdo_productwise.Text = "Product Wise";
            this.rdo_productwise.UseVisualStyleBackColor = true;
            // 
            // frm_stockreorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 461);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_stockreorder";
            this.Text = "frm_stockreorder";
            this.Load += new System.EventHandler(this.frm_stockreorder_Load);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdo_product;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox txt_loca2_name;
        private System.Windows.Forms.CheckBox Chk_allLoca;
        private System.Windows.Forms.TextBox txt_loca2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_loca1;
        private System.Windows.Forms.TextBox txt_loca1_name;
        private System.Windows.Forms.TextBox txt_product2;
        private System.Windows.Forms.RadioButton rdo_fast;
        private System.Windows.Forms.RadioButton rdo_slow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdo_location;
        private System.Windows.Forms.CheckBox chk_AllCategory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Category1;
        private System.Windows.Forms.TextBox txt_Category1_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Category;
        private System.Windows.Forms.TextBox txt_Category_name;
        private System.Windows.Forms.RadioButton rdo_category;
        private System.Windows.Forms.CheckBox chk_Allproduct;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_product2_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_product1;
        private System.Windows.Forms.TextBox txt_product1_name;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton rdo_all;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdo_lotwise;
        private System.Windows.Forms.RadioButton rdo_productwise;
    }
}