namespace SmartAnything.UI.Transactions
{
    partial class frm_liveStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_liveStock));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chk_excludezero = new System.Windows.Forms.CheckBox();
            this.chk_Allproduct = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rdo_lotwise = new System.Windows.Forms.RadioButton();
            this.txt_product2 = new System.Windows.Forms.TextBox();
            this.txt_product2_name = new System.Windows.Forms.TextBox();
            this.rdo_productwise = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_product1 = new System.Windows.Forms.TextBox();
            this.txt_product1_name = new System.Windows.Forms.TextBox();
            this.rdo_product = new System.Windows.Forms.RadioButton();
            this.Chk_allLoca = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_loca2 = new System.Windows.Forms.TextBox();
            this.txt_loca2_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_loca1 = new System.Windows.Forms.TextBox();
            this.txt_loca1_name = new System.Windows.Forms.TextBox();
            this.rdo_location = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdo_all = new System.Windows.Forms.RadioButton();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_print);
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.chk_Allproduct);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.rdo_product);
            this.panel1.Controls.Add(this.Chk_allLoca);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.rdo_location);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 112);
            this.panel1.TabIndex = 156;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::SmartAnything.Properties.Resources.Repeat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(913, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 35);
            this.button1.TabIndex = 165;
            this.button1.Text = "       Export";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(1010, 69);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 163;
            this.btn_print.Text = "       Show";
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
            this.btn_exit.Location = new System.Drawing.Point(1104, 69);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 164;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.checkBox4);
            this.panel6.Controls.Add(this.checkBox3);
            this.panel6.Controls.Add(this.checkBox2);
            this.panel6.Controls.Add(this.checkBox1);
            this.panel6.Controls.Add(this.chk_excludezero);
            this.panel6.Location = new System.Drawing.Point(3, 68);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(877, 32);
            this.panel6.TabIndex = 162;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox4.Location = new System.Drawing.Point(433, 8);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(39, 18);
            this.checkBox4.TabIndex = 160;
            this.checkBox4.Text = "All";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox3.Location = new System.Drawing.Point(379, 8);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 18);
            this.checkBox3.TabIndex = 159;
            this.checkBox3.Text = "Zero";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox2.Location = new System.Drawing.Point(291, 8);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(71, 18);
            this.checkBox2.TabIndex = 158;
            this.checkBox2.Text = "Negative";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(121, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(164, 18);
            this.checkBox1.TabIndex = 157;
            this.checkBox1.Text = "Including Zero and Negative";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chk_excludezero
            // 
            this.chk_excludezero.AutoSize = true;
            this.chk_excludezero.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_excludezero.Location = new System.Drawing.Point(17, 8);
            this.chk_excludezero.Name = "chk_excludezero";
            this.chk_excludezero.Size = new System.Drawing.Size(98, 18);
            this.chk_excludezero.TabIndex = 156;
            this.chk_excludezero.Text = "Excluding Zero";
            this.chk_excludezero.UseVisualStyleBackColor = true;
            // 
            // chk_Allproduct
            // 
            this.chk_Allproduct.AutoSize = true;
            this.chk_Allproduct.Checked = true;
            this.chk_Allproduct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Allproduct.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_Allproduct.Location = new System.Drawing.Point(553, 22);
            this.chk_Allproduct.Name = "chk_Allproduct";
            this.chk_Allproduct.Size = new System.Drawing.Size(43, 18);
            this.chk_Allproduct.TabIndex = 158;
            this.chk_Allproduct.Text = "ALL";
            this.chk_Allproduct.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rdo_lotwise);
            this.panel2.Controls.Add(this.txt_product2);
            this.panel2.Controls.Add(this.txt_product2_name);
            this.panel2.Controls.Add(this.rdo_productwise);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_product1);
            this.panel2.Controls.Add(this.txt_product1_name);
            this.panel2.Location = new System.Drawing.Point(641, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 61);
            this.panel2.TabIndex = 157;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(143, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 14);
            this.label3.TabIndex = 158;
            this.label3.Text = "To";
            // 
            // rdo_lotwise
            // 
            this.rdo_lotwise.AutoSize = true;
            this.rdo_lotwise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_lotwise.ForeColor = System.Drawing.Color.Maroon;
            this.rdo_lotwise.Location = new System.Drawing.Point(27, 31);
            this.rdo_lotwise.Name = "rdo_lotwise";
            this.rdo_lotwise.Size = new System.Drawing.Size(73, 19);
            this.rdo_lotwise.TabIndex = 53;
            this.rdo_lotwise.Text = "Lot Wise";
            this.rdo_lotwise.UseVisualStyleBackColor = true;
            // 
            // txt_product2
            // 
            this.txt_product2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_product2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product2.Location = new System.Drawing.Point(165, 31);
            this.txt_product2.Name = "txt_product2";
            this.txt_product2.Size = new System.Drawing.Size(89, 22);
            this.txt_product2.TabIndex = 156;
            this.txt_product2.TextChanged += new System.EventHandler(this.txt_product2_TextChanged);
            this.txt_product2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_product2_KeyDown);
            // 
            // txt_product2_name
            // 
            this.txt_product2_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_product2_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product2_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product2_name.Location = new System.Drawing.Point(260, 31);
            this.txt_product2_name.Name = "txt_product2_name";
            this.txt_product2_name.Size = new System.Drawing.Size(287, 22);
            this.txt_product2_name.TabIndex = 157;
            // 
            // rdo_productwise
            // 
            this.rdo_productwise.AutoSize = true;
            this.rdo_productwise.Checked = true;
            this.rdo_productwise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_productwise.ForeColor = System.Drawing.Color.Maroon;
            this.rdo_productwise.Location = new System.Drawing.Point(27, 7);
            this.rdo_productwise.Name = "rdo_productwise";
            this.rdo_productwise.Size = new System.Drawing.Size(98, 19);
            this.rdo_productwise.TabIndex = 52;
            this.rdo_productwise.TabStop = true;
            this.rdo_productwise.Text = "Product Wise";
            this.rdo_productwise.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(131, 10);
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
            this.txt_product1.Location = new System.Drawing.Point(165, 6);
            this.txt_product1.Name = "txt_product1";
            this.txt_product1.Size = new System.Drawing.Size(89, 22);
            this.txt_product1.TabIndex = 42;
            this.txt_product1.TextChanged += new System.EventHandler(this.txt_product1_TextChanged);
            this.txt_product1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_product1_KeyDown);
            // 
            // txt_product1_name
            // 
            this.txt_product1_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_product1_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product1_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product1_name.Location = new System.Drawing.Point(260, 6);
            this.txt_product1_name.Name = "txt_product1_name";
            this.txt_product1_name.Size = new System.Drawing.Size(287, 22);
            this.txt_product1_name.TabIndex = 44;
            // 
            // rdo_product
            // 
            this.rdo_product.AutoSize = true;
            this.rdo_product.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_product.Location = new System.Drawing.Point(553, 4);
            this.rdo_product.Name = "rdo_product";
            this.rdo_product.Size = new System.Drawing.Size(82, 18);
            this.rdo_product.TabIndex = 156;
            this.rdo_product.Text = "Product/Lot";
            this.rdo_product.UseVisualStyleBackColor = true;
            this.rdo_product.Click += new System.EventHandler(this.rdo_product_Click);
            // 
            // Chk_allLoca
            // 
            this.Chk_allLoca.AutoSize = true;
            this.Chk_allLoca.Checked = true;
            this.Chk_allLoca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_allLoca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.Chk_allLoca.Location = new System.Drawing.Point(7, 21);
            this.Chk_allLoca.Name = "Chk_allLoca";
            this.Chk_allLoca.Size = new System.Drawing.Size(43, 18);
            this.Chk_allLoca.TabIndex = 155;
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
            this.panel4.Location = new System.Drawing.Point(73, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(473, 60);
            this.panel4.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(16, 35);
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
            this.txt_loca2.Location = new System.Drawing.Point(38, 31);
            this.txt_loca2.Name = "txt_loca2";
            this.txt_loca2.Size = new System.Drawing.Size(80, 22);
            this.txt_loca2.TabIndex = 156;
            this.txt_loca2.Text = "001";
            this.txt_loca2.TextChanged += new System.EventHandler(this.txt_loca2_TextChanged);
            this.txt_loca2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loca2_KeyDown);
            // 
            // txt_loca2_name
            // 
            this.txt_loca2_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca2_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca2_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca2_name.Location = new System.Drawing.Point(122, 31);
            this.txt_loca2_name.Name = "txt_loca2_name";
            this.txt_loca2_name.Size = new System.Drawing.Size(334, 22);
            this.txt_loca2_name.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(-1, 8);
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
            this.txt_loca1.Location = new System.Drawing.Point(38, 4);
            this.txt_loca1.Name = "txt_loca1";
            this.txt_loca1.Size = new System.Drawing.Size(80, 22);
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
            this.txt_loca1_name.Location = new System.Drawing.Point(122, 4);
            this.txt_loca1_name.Name = "txt_loca1_name";
            this.txt_loca1_name.Size = new System.Drawing.Size(334, 22);
            this.txt_loca1_name.TabIndex = 44;
            // 
            // rdo_location
            // 
            this.rdo_location.AutoSize = true;
            this.rdo_location.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_location.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdo_location.Location = new System.Drawing.Point(7, 3);
            this.rdo_location.Name = "rdo_location";
            this.rdo_location.Size = new System.Drawing.Size(66, 18);
            this.rdo_location.TabIndex = 51;
            this.rdo_location.Text = "Location";
            this.rdo_location.UseVisualStyleBackColor = true;
            this.rdo_location.Click += new System.EventHandler(this.rdo_location_Click);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.panel8);
            this.panel9.Location = new System.Drawing.Point(12, 47);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1212, 29);
            this.panel9.TabIndex = 158;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Purple;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.rdo_all);
            this.panel8.Location = new System.Drawing.Point(3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1192, 24);
            this.panel8.TabIndex = 164;
            // 
            // rdo_all
            // 
            this.rdo_all.Checked = true;
            this.rdo_all.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_all.ForeColor = System.Drawing.Color.White;
            this.rdo_all.Location = new System.Drawing.Point(3, 1);
            this.rdo_all.Name = "rdo_all";
            this.rdo_all.Size = new System.Drawing.Size(132, 18);
            this.rdo_all.TabIndex = 165;
            this.rdo_all.TabStop = true;
            this.rdo_all.Text = "No filtering(Show All)";
            this.rdo_all.UseVisualStyleBackColor = true;
            this.rdo_all.Click += new System.EventHandler(this.rdo_all_Click);
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
            this.pnl_header.Size = new System.Drawing.Size(1240, 45);
            this.pnl_header.TabIndex = 157;
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
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(12, 208);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1212, 412);
            this.panel3.TabIndex = 159;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1201, 401);
            this.dataGridView1.TabIndex = 124;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_liveStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 626);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel1);
            this.Name = "frm_liveStock";
            this.Text = "frm_liveStock";
            this.Load += new System.EventHandler(this.frm_liveStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chk_excludezero;
        private System.Windows.Forms.CheckBox chk_Allproduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_product2;
        private System.Windows.Forms.TextBox txt_product2_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_product1;
        private System.Windows.Forms.TextBox txt_product1_name;
        private System.Windows.Forms.RadioButton rdo_product;
        private System.Windows.Forms.CheckBox Chk_allLoca;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_loca2;
        private System.Windows.Forms.TextBox txt_loca2_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_loca1;
        private System.Windows.Forms.TextBox txt_loca1_name;
        private System.Windows.Forms.RadioButton rdo_location;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton rdo_all;
        private System.Windows.Forms.RadioButton rdo_lotwise;
        private System.Windows.Forms.RadioButton rdo_productwise;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}