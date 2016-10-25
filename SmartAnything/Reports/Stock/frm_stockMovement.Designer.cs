namespace SmartAnything.Reports.Stock
{
    partial class frm_stockMovement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stockMovement));
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdo_qty = new System.Windows.Forms.RadioButton();
            this.rdo_value = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.Chk_allLoca = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_loca2 = new System.Windows.Forms.TextBox();
            this.txt_loca2_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_loca1 = new System.Windows.Forms.TextBox();
            this.txt_loca1_name = new System.Windows.Forms.TextBox();
            this.rdo_location = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdo_non = new System.Windows.Forms.RadioButton();
            this.rdo_fast = new System.Windows.Forms.RadioButton();
            this.rdo_slow = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.chk_AllCategory = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_supplier1 = new System.Windows.Forms.TextBox();
            this.txt_supplier1_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_supplier = new System.Windows.Forms.TextBox();
            this.txt_supplier_name = new System.Windows.Forms.TextBox();
            this.rdo_supplier = new System.Windows.Forms.RadioButton();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btn_print);
            this.panel5.Controls.Add(this.btn_exit);
            this.panel5.Location = new System.Drawing.Point(6, 244);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(651, 48);
            this.panel5.TabIndex = 160;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Chk_allLoca);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.rdo_location);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.chk_AllCategory);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.rdo_supplier);
            this.panel1.Location = new System.Drawing.Point(6, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 187);
            this.panel1.TabIndex = 161;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(189, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 169;
            this.label4.Text = "No OF records";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(272, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 22);
            this.textBox1.TabIndex = 168;
            this.textBox1.Text = "5";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdo_qty);
            this.panel2.Controls.Add(this.rdo_value);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(254, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 32);
            this.panel2.TabIndex = 167;
            // 
            // rdo_qty
            // 
            this.rdo_qty.AutoSize = true;
            this.rdo_qty.Checked = true;
            this.rdo_qty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_qty.Location = new System.Drawing.Point(88, 6);
            this.rdo_qty.Name = "rdo_qty";
            this.rdo_qty.Size = new System.Drawing.Size(62, 18);
            this.rdo_qty.TabIndex = 163;
            this.rdo_qty.TabStop = true;
            this.rdo_qty.Text = "Quntity";
            this.rdo_qty.UseVisualStyleBackColor = true;
            // 
            // rdo_value
            // 
            this.rdo_value.AutoSize = true;
            this.rdo_value.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_value.Location = new System.Drawing.Point(156, 6);
            this.rdo_value.Name = "rdo_value";
            this.rdo_value.Size = new System.Drawing.Size(52, 18);
            this.rdo_value.TabIndex = 162;
            this.rdo_value.Text = "Value";
            this.rdo_value.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(14, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 161;
            this.label3.Text = "Method";
            // 
            // Chk_allLoca
            // 
            this.Chk_allLoca.AutoSize = true;
            this.Chk_allLoca.Checked = true;
            this.Chk_allLoca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_allLoca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.Chk_allLoca.Location = new System.Drawing.Point(126, 8);
            this.Chk_allLoca.Name = "Chk_allLoca";
            this.Chk_allLoca.Size = new System.Drawing.Size(43, 18);
            this.Chk_allLoca.TabIndex = 166;
            this.Chk_allLoca.Text = "ALL";
            this.Chk_allLoca.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txt_loca2);
            this.panel4.Controls.Add(this.txt_loca2_name);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txt_loca1);
            this.panel4.Controls.Add(this.txt_loca1_name);
            this.panel4.Location = new System.Drawing.Point(20, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(608, 34);
            this.panel4.TabIndex = 165;
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
            // txt_loca2
            // 
            this.txt_loca2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca2.Location = new System.Drawing.Point(348, 4);
            this.txt_loca2.Name = "txt_loca2";
            this.txt_loca2.Size = new System.Drawing.Size(68, 22);
            this.txt_loca2.TabIndex = 156;
            this.txt_loca2.TextChanged += new System.EventHandler(this.txt_loca2_TextChanged);
            this.txt_loca2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loca2_KeyDown);
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
            // rdo_location
            // 
            this.rdo_location.AutoSize = true;
            this.rdo_location.Checked = true;
            this.rdo_location.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_location.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_location.Location = new System.Drawing.Point(20, 7);
            this.rdo_location.Name = "rdo_location";
            this.rdo_location.Size = new System.Drawing.Size(100, 18);
            this.rdo_location.TabIndex = 164;
            this.rdo_location.TabStop = true;
            this.rdo_location.Text = "Location Range";
            this.rdo_location.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.rdo_non);
            this.panel7.Controls.Add(this.rdo_fast);
            this.panel7.Controls.Add(this.rdo_slow);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(20, 134);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(228, 32);
            this.panel7.TabIndex = 163;
            // 
            // rdo_non
            // 
            this.rdo_non.AutoSize = true;
            this.rdo_non.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_non.Location = new System.Drawing.Point(171, 6);
            this.rdo_non.Name = "rdo_non";
            this.rdo_non.Size = new System.Drawing.Size(45, 18);
            this.rdo_non.TabIndex = 164;
            this.rdo_non.Text = "Non";
            this.rdo_non.UseVisualStyleBackColor = true;
            // 
            // rdo_fast
            // 
            this.rdo_fast.AutoSize = true;
            this.rdo_fast.Checked = true;
            this.rdo_fast.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_fast.Location = new System.Drawing.Point(59, 6);
            this.rdo_fast.Name = "rdo_fast";
            this.rdo_fast.Size = new System.Drawing.Size(46, 18);
            this.rdo_fast.TabIndex = 163;
            this.rdo_fast.TabStop = true;
            this.rdo_fast.Text = "Fast";
            this.rdo_fast.UseVisualStyleBackColor = true;
            // 
            // rdo_slow
            // 
            this.rdo_slow.AutoSize = true;
            this.rdo_slow.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_slow.Location = new System.Drawing.Point(116, 6);
            this.rdo_slow.Name = "rdo_slow";
            this.rdo_slow.Size = new System.Drawing.Size(49, 18);
            this.rdo_slow.TabIndex = 162;
            this.rdo_slow.Text = "Slow";
            this.rdo_slow.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(14, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 14);
            this.label8.TabIndex = 161;
            this.label8.Text = "Type";
            // 
            // chk_AllCategory
            // 
            this.chk_AllCategory.AutoSize = true;
            this.chk_AllCategory.Checked = true;
            this.chk_AllCategory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_AllCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_AllCategory.Location = new System.Drawing.Point(126, 70);
            this.chk_AllCategory.Name = "chk_AllCategory";
            this.chk_AllCategory.Size = new System.Drawing.Size(43, 18);
            this.chk_AllCategory.TabIndex = 161;
            this.chk_AllCategory.Text = "ALL";
            this.chk_AllCategory.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_supplier1);
            this.panel3.Controls.Add(this.txt_supplier1_name);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txt_supplier);
            this.panel3.Controls.Add(this.txt_supplier_name);
            this.panel3.Location = new System.Drawing.Point(20, 94);
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
            // txt_supplier1
            // 
            this.txt_supplier1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_supplier1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_supplier1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_supplier1.Location = new System.Drawing.Point(348, 4);
            this.txt_supplier1.Name = "txt_supplier1";
            this.txt_supplier1.Size = new System.Drawing.Size(68, 22);
            this.txt_supplier1.TabIndex = 156;
            this.txt_supplier1.TextChanged += new System.EventHandler(this.txt_supplier1_TextChanged);
            this.txt_supplier1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_supplier1_KeyDown);
            // 
            // txt_supplier1_name
            // 
            this.txt_supplier1_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_supplier1_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_supplier1_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_supplier1_name.Location = new System.Drawing.Point(422, 4);
            this.txt_supplier1_name.Name = "txt_supplier1_name";
            this.txt_supplier1_name.Size = new System.Drawing.Size(167, 22);
            this.txt_supplier1_name.TabIndex = 157;
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
            // txt_supplier
            // 
            this.txt_supplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_supplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_supplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_supplier.Location = new System.Drawing.Point(56, 4);
            this.txt_supplier.Name = "txt_supplier";
            this.txt_supplier.Size = new System.Drawing.Size(68, 22);
            this.txt_supplier.TabIndex = 42;
            this.txt_supplier.TextChanged += new System.EventHandler(this.txt_supplier_TextChanged);
            this.txt_supplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_supplier_KeyDown);
            // 
            // txt_supplier_name
            // 
            this.txt_supplier_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_supplier_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_supplier_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_supplier_name.Location = new System.Drawing.Point(130, 4);
            this.txt_supplier_name.Name = "txt_supplier_name";
            this.txt_supplier_name.Size = new System.Drawing.Size(167, 22);
            this.txt_supplier_name.TabIndex = 44;
            // 
            // rdo_supplier
            // 
            this.rdo_supplier.AutoSize = true;
            this.rdo_supplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_supplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_supplier.Location = new System.Drawing.Point(20, 70);
            this.rdo_supplier.Name = "rdo_supplier";
            this.rdo_supplier.Size = new System.Drawing.Size(99, 18);
            this.rdo_supplier.TabIndex = 159;
            this.rdo_supplier.Text = "Supplier Range";
            this.rdo_supplier.UseVisualStyleBackColor = true;
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
            this.pnl_header.Size = new System.Drawing.Size(666, 45);
            this.pnl_header.TabIndex = 159;
            // 
            // frm_stockMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 297);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_stockMovement";
            this.Text = "frm_stockMovement";
            this.Load += new System.EventHandler(this.frm_stockMovement_Load);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rdo_fast;
        private System.Windows.Forms.RadioButton rdo_slow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.CheckBox chk_AllCategory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_supplier1;
        private System.Windows.Forms.TextBox txt_supplier1_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_supplier;
        private System.Windows.Forms.TextBox txt_supplier_name;
        private System.Windows.Forms.RadioButton rdo_supplier;
        private System.Windows.Forms.CheckBox Chk_allLoca;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_loca2;
        private System.Windows.Forms.TextBox txt_loca2_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_loca1;
        private System.Windows.Forms.TextBox txt_loca1_name;
        private System.Windows.Forms.RadioButton rdo_location;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdo_qty;
        private System.Windows.Forms.RadioButton rdo_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdo_non;
    }
}