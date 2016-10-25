namespace SmartAnything.UI
{
    partial class frm_OrderFormApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_OrderFormApproval));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_creditPeriod = new System.Windows.Forms.Label();
            this.txt_creditlimit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.txt_Customer_name = new System.Windows.Forms.TextBox();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_locationId_name = new System.Windows.Forms.TextBox();
            this.txt_Locacode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_DocNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NetTotal = new System.Windows.Forms.TextBox();
            this.txt_subtotdisc = new System.Windows.Forms.TextBox();
            this.txt_subtotdiscper = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_TotalDisc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Subtotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_cndet = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_Invoices = new System.Windows.Forms.Button();
            this.txt_os = new System.Windows.Forms.TextBox();
            this.pnl_invoicedet = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.pnl_credinote = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnl_cheque = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rdo_realized = new System.Windows.Forms.RadioButton();
            this.rdo_daterange = new System.Windows.Forms.RadioButton();
            this.rdo_unrealized = new System.Windows.Forms.RadioButton();
            this.rdo_post = new System.Windows.Forms.RadioButton();
            this.rdo_retured = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.dte_to = new System.Windows.Forms.DateTimePicker();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dte_cheques = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pnl_invoicedet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.pnl_credinote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnl_cheque.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dte_cheques)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(316, 372);
            this.dataGridView1.TabIndex = 144;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
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
            this.pnl_header.Size = new System.Drawing.Size(1243, 45);
            this.pnl_header.TabIndex = 143;
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
            this.imageList1.Images.SetKeyName(9, "1449578166_Cancel.png");
            this.imageList1.Images.SetKeyName(10, "1449578306_Check.png");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Location = new System.Drawing.Point(467, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(443, 47);
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
            this.btn_exit.Location = new System.Drawing.Point(349, 6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.White;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.ImageIndex = 10;
            this.btn_edit.ImageList = this.imageList1;
            this.btn_edit.Location = new System.Drawing.Point(253, 6);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(91, 35);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.Text = "        Approve";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lbl_creditPeriod);
            this.panel2.Controls.Add(this.txt_creditlimit);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_Remarks);
            this.panel2.Controls.Add(this.txt_Customer_name);
            this.panel2.Controls.Add(this.txt_Customer);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_locationId_name);
            this.panel2.Controls.Add(this.txt_Locacode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_DocNo);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_NetTotal);
            this.panel2.Controls.Add(this.txt_subtotdisc);
            this.panel2.Controls.Add(this.txt_subtotdiscper);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txt_TotalDisc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_Subtotal);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(334, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 177);
            this.panel2.TabIndex = 148;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(504, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 18);
            this.label8.TabIndex = 140;
            this.label8.Text = "Days";
            // 
            // lbl_creditPeriod
            // 
            this.lbl_creditPeriod.AutoSize = true;
            this.lbl_creditPeriod.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_creditPeriod.ForeColor = System.Drawing.Color.Black;
            this.lbl_creditPeriod.Location = new System.Drawing.Point(479, 152);
            this.lbl_creditPeriod.Name = "lbl_creditPeriod";
            this.lbl_creditPeriod.Size = new System.Drawing.Size(15, 18);
            this.lbl_creditPeriod.TabIndex = 139;
            this.lbl_creditPeriod.Text = "0";
            // 
            // txt_creditlimit
            // 
            this.txt_creditlimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_creditlimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_creditlimit.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_creditlimit.ForeColor = System.Drawing.Color.Black;
            this.txt_creditlimit.Location = new System.Drawing.Point(482, 127);
            this.txt_creditlimit.Name = "txt_creditlimit";
            this.txt_creditlimit.ReadOnly = true;
            this.txt_creditlimit.Size = new System.Drawing.Size(102, 22);
            this.txt_creditlimit.TabIndex = 138;
            this.txt_creditlimit.Text = "0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(34, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 136;
            this.label13.Text = "Remarks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(412, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 137;
            this.label5.Text = "Credit Limit";
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.BackColor = System.Drawing.Color.White;
            this.txt_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Remarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Remarks.Location = new System.Drawing.Point(91, 71);
            this.txt_Remarks.Multiline = true;
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(283, 57);
            this.txt_Remarks.TabIndex = 135;
            // 
            // txt_Customer_name
            // 
            this.txt_Customer_name.BackColor = System.Drawing.Color.White;
            this.txt_Customer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer_name.Location = new System.Drawing.Point(185, 49);
            this.txt_Customer_name.Name = "txt_Customer_name";
            this.txt_Customer_name.ReadOnly = true;
            this.txt_Customer_name.Size = new System.Drawing.Size(189, 21);
            this.txt_Customer_name.TabIndex = 134;
            // 
            // txt_Customer
            // 
            this.txt_Customer.BackColor = System.Drawing.Color.White;
            this.txt_Customer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer.Location = new System.Drawing.Point(91, 49);
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.Size = new System.Drawing.Size(88, 21);
            this.txt_Customer.TabIndex = 132;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 14);
            this.label6.TabIndex = 133;
            this.label6.Text = "Customer";
            // 
            // txt_locationId_name
            // 
            this.txt_locationId_name.BackColor = System.Drawing.Color.White;
            this.txt_locationId_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_locationId_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_locationId_name.Location = new System.Drawing.Point(185, 27);
            this.txt_locationId_name.Name = "txt_locationId_name";
            this.txt_locationId_name.ReadOnly = true;
            this.txt_locationId_name.Size = new System.Drawing.Size(189, 21);
            this.txt_locationId_name.TabIndex = 131;
            // 
            // txt_Locacode
            // 
            this.txt_Locacode.BackColor = System.Drawing.Color.White;
            this.txt_Locacode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Locacode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Locacode.Location = new System.Drawing.Point(91, 27);
            this.txt_Locacode.Name = "txt_Locacode";
            this.txt_Locacode.ReadOnly = true;
            this.txt_Locacode.Size = new System.Drawing.Size(88, 21);
            this.txt_Locacode.TabIndex = 129;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(37, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 130;
            this.label4.Text = "Location";
            // 
            // txt_DocNo
            // 
            this.txt_DocNo.BackColor = System.Drawing.Color.White;
            this.txt_DocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DocNo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DocNo.Location = new System.Drawing.Point(91, 5);
            this.txt_DocNo.Name = "txt_DocNo";
            this.txt_DocNo.Size = new System.Drawing.Size(128, 21);
            this.txt_DocNo.TabIndex = 127;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(409, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 14);
            this.label17.TabIndex = 109;
            this.label17.Text = "Net Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 128;
            this.label2.Text = "Do No";
            // 
            // txt_NetTotal
            // 
            this.txt_NetTotal.BackColor = System.Drawing.Color.White;
            this.txt_NetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NetTotal.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_NetTotal.ForeColor = System.Drawing.Color.Black;
            this.txt_NetTotal.Location = new System.Drawing.Point(482, 103);
            this.txt_NetTotal.Name = "txt_NetTotal";
            this.txt_NetTotal.ReadOnly = true;
            this.txt_NetTotal.Size = new System.Drawing.Size(102, 22);
            this.txt_NetTotal.TabIndex = 108;
            this.txt_NetTotal.Text = "0.00";
            // 
            // txt_subtotdisc
            // 
            this.txt_subtotdisc.BackColor = System.Drawing.Color.White;
            this.txt_subtotdisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subtotdisc.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_subtotdisc.ForeColor = System.Drawing.Color.Black;
            this.txt_subtotdisc.Location = new System.Drawing.Point(482, 55);
            this.txt_subtotdisc.Name = "txt_subtotdisc";
            this.txt_subtotdisc.ReadOnly = true;
            this.txt_subtotdisc.Size = new System.Drawing.Size(102, 22);
            this.txt_subtotdisc.TabIndex = 126;
            this.txt_subtotdisc.Text = "0.00";
            // 
            // txt_subtotdiscper
            // 
            this.txt_subtotdiscper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            this.txt_subtotdiscper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subtotdiscper.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_subtotdiscper.ForeColor = System.Drawing.Color.Black;
            this.txt_subtotdiscper.Location = new System.Drawing.Point(482, 31);
            this.txt_subtotdiscper.Name = "txt_subtotdiscper";
            this.txt_subtotdiscper.Size = new System.Drawing.Size(102, 22);
            this.txt_subtotdiscper.TabIndex = 124;
            this.txt_subtotdiscper.Text = "0.00";
            this.txt_subtotdiscper.TextChanged += new System.EventHandler(this.txt_subtotdiscper_TextChanged);
            this.txt_subtotdiscper.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_subtotdiscper_KeyDown);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(399, 84);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 14);
            this.label28.TabIndex = 117;
            this.label28.Text = "Total Discount";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(436, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 14);
            this.label18.TabIndex = 123;
            this.label18.Text = "Disc %";
            // 
            // txt_TotalDisc
            // 
            this.txt_TotalDisc.BackColor = System.Drawing.Color.White;
            this.txt_TotalDisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TotalDisc.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_TotalDisc.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalDisc.Location = new System.Drawing.Point(482, 79);
            this.txt_TotalDisc.Name = "txt_TotalDisc";
            this.txt_TotalDisc.ReadOnly = true;
            this.txt_TotalDisc.Size = new System.Drawing.Size(102, 22);
            this.txt_TotalDisc.TabIndex = 116;
            this.txt_TotalDisc.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(400, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 125;
            this.label1.Text = "Sub Total Disc";
            // 
            // txt_Subtotal
            // 
            this.txt_Subtotal.BackColor = System.Drawing.Color.White;
            this.txt_Subtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Subtotal.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_Subtotal.ForeColor = System.Drawing.Color.Black;
            this.txt_Subtotal.Location = new System.Drawing.Point(482, 7);
            this.txt_Subtotal.Name = "txt_Subtotal";
            this.txt_Subtotal.ReadOnly = true;
            this.txt_Subtotal.Size = new System.Drawing.Size(102, 22);
            this.txt_Subtotal.TabIndex = 114;
            this.txt_Subtotal.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(399, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 115;
            this.label3.Text = "Gross Amount";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 56);
            this.panel1.TabIndex = 149;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.btn_cndet);
            this.panel7.Controls.Add(this.label21);
            this.panel7.Controls.Add(this.btn_Invoices);
            this.panel7.Controls.Add(this.txt_os);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(334, 236);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(593, 35);
            this.panel7.TabIndex = 150;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(493, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 144;
            this.button2.Text = "Cheques";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_cndet
            // 
            this.btn_cndet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cndet.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cndet.ForeColor = System.Drawing.Color.Maroon;
            this.btn_cndet.Location = new System.Drawing.Point(395, 5);
            this.btn_cndet.Name = "btn_cndet";
            this.btn_cndet.Size = new System.Drawing.Size(92, 23);
            this.btn_cndet.TabIndex = 143;
            this.btn_cndet.Text = "Credit Notes";
            this.btn_cndet.UseVisualStyleBackColor = true;
            this.btn_cndet.Click += new System.EventHandler(this.btn_cndet_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Maroon;
            this.label21.Location = new System.Drawing.Point(12, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 14);
            this.label21.TabIndex = 54;
            this.label21.Text = "OutStandings";
            // 
            // btn_Invoices
            // 
            this.btn_Invoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Invoices.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Invoices.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Invoices.Location = new System.Drawing.Point(297, 5);
            this.btn_Invoices.Name = "btn_Invoices";
            this.btn_Invoices.Size = new System.Drawing.Size(92, 23);
            this.btn_Invoices.TabIndex = 142;
            this.btn_Invoices.Text = "Invoice Details";
            this.btn_Invoices.UseVisualStyleBackColor = true;
            this.btn_Invoices.Click += new System.EventHandler(this.btn_Invoices_Click);
            // 
            // txt_os
            // 
            this.txt_os.BackColor = System.Drawing.Color.White;
            this.txt_os.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_os.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_os.Location = new System.Drawing.Point(91, 6);
            this.txt_os.Name = "txt_os";
            this.txt_os.ReadOnly = true;
            this.txt_os.Size = new System.Drawing.Size(99, 21);
            this.txt_os.TabIndex = 53;
            // 
            // pnl_invoicedet
            // 
            this.pnl_invoicedet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.pnl_invoicedet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_invoicedet.Controls.Add(this.button8);
            this.pnl_invoicedet.Controls.Add(this.dataGridView3);
            this.pnl_invoicedet.Location = new System.Drawing.Point(334, 214);
            this.pnl_invoicedet.Name = "pnl_invoicedet";
            this.pnl_invoicedet.Size = new System.Drawing.Size(498, 212);
            this.pnl_invoicedet.TabIndex = 153;
            this.pnl_invoicedet.Visible = false;
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.Maroon;
            this.button8.Location = new System.Drawing.Point(384, 181);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(109, 23);
            this.button8.TabIndex = 143;
            this.button8.Text = "Hide";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(8, 15);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(485, 160);
            this.dataGridView3.TabIndex = 140;
            // 
            // pnl_credinote
            // 
            this.pnl_credinote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.pnl_credinote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_credinote.Controls.Add(this.button3);
            this.pnl_credinote.Controls.Add(this.dataGridView2);
            this.pnl_credinote.Location = new System.Drawing.Point(93, 137);
            this.pnl_credinote.Name = "pnl_credinote";
            this.pnl_credinote.Size = new System.Drawing.Size(896, 289);
            this.pnl_credinote.TabIndex = 154;
            this.pnl_credinote.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Maroon;
            this.button3.Location = new System.Drawing.Point(782, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 143;
            this.button3.Text = "Hide";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 15);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(883, 240);
            this.dataGridView2.TabIndex = 140;
            // 
            // pnl_cheque
            // 
            this.pnl_cheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.pnl_cheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_cheque.Controls.Add(this.panel8);
            this.pnl_cheque.Controls.Add(this.button4);
            this.pnl_cheque.Controls.Add(this.dte_cheques);
            this.pnl_cheque.Location = new System.Drawing.Point(12, 137);
            this.pnl_cheque.Name = "pnl_cheque";
            this.pnl_cheque.Size = new System.Drawing.Size(977, 289);
            this.pnl_cheque.TabIndex = 155;
            this.pnl_cheque.Visible = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.rdo_realized);
            this.panel8.Controls.Add(this.rdo_daterange);
            this.panel8.Controls.Add(this.rdo_unrealized);
            this.panel8.Controls.Add(this.rdo_post);
            this.panel8.Controls.Add(this.rdo_retured);
            this.panel8.Controls.Add(this.label23);
            this.panel8.Controls.Add(this.dte_to);
            this.panel8.Controls.Add(this.dte_from);
            this.panel8.Controls.Add(this.button5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.ForeColor = System.Drawing.Color.Black;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(975, 35);
            this.panel8.TabIndex = 163;
            // 
            // rdo_realized
            // 
            this.rdo_realized.AutoSize = true;
            this.rdo_realized.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_realized.Location = new System.Drawing.Point(501, 8);
            this.rdo_realized.Name = "rdo_realized";
            this.rdo_realized.Size = new System.Drawing.Size(65, 17);
            this.rdo_realized.TabIndex = 154;
            this.rdo_realized.Text = "Realized";
            this.rdo_realized.UseVisualStyleBackColor = true;
            // 
            // rdo_daterange
            // 
            this.rdo_daterange.AutoSize = true;
            this.rdo_daterange.Checked = true;
            this.rdo_daterange.Location = new System.Drawing.Point(7, 8);
            this.rdo_daterange.Name = "rdo_daterange";
            this.rdo_daterange.Size = new System.Drawing.Size(80, 17);
            this.rdo_daterange.TabIndex = 153;
            this.rdo_daterange.TabStop = true;
            this.rdo_daterange.Text = "DateRange";
            this.rdo_daterange.UseVisualStyleBackColor = true;
            // 
            // rdo_unrealized
            // 
            this.rdo_unrealized.AutoSize = true;
            this.rdo_unrealized.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_unrealized.Location = new System.Drawing.Point(420, 9);
            this.rdo_unrealized.Name = "rdo_unrealized";
            this.rdo_unrealized.Size = new System.Drawing.Size(76, 17);
            this.rdo_unrealized.TabIndex = 152;
            this.rdo_unrealized.Text = "Unrealized";
            this.rdo_unrealized.UseVisualStyleBackColor = true;
            // 
            // rdo_post
            // 
            this.rdo_post.AutoSize = true;
            this.rdo_post.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_post.Location = new System.Drawing.Point(302, 9);
            this.rdo_post.Name = "rdo_post";
            this.rdo_post.Size = new System.Drawing.Size(40, 17);
            this.rdo_post.TabIndex = 148;
            this.rdo_post.Text = "PD ";
            this.rdo_post.UseVisualStyleBackColor = true;
            // 
            // rdo_retured
            // 
            this.rdo_retured.AutoSize = true;
            this.rdo_retured.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_retured.Location = new System.Drawing.Point(346, 9);
            this.rdo_retured.Name = "rdo_retured";
            this.rdo_retured.Size = new System.Drawing.Size(71, 17);
            this.rdo_retured.TabIndex = 147;
            this.rdo_retured.Text = "Returned ";
            this.rdo_retured.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(179, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 14);
            this.label23.TabIndex = 146;
            this.label23.Text = "To";
            // 
            // dte_to
            // 
            this.dte_to.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_to.Location = new System.Drawing.Point(203, 5);
            this.dte_to.Name = "dte_to";
            this.dte_to.Size = new System.Drawing.Size(87, 21);
            this.dte_to.TabIndex = 145;
            // 
            // dte_from
            // 
            this.dte_from.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_from.Location = new System.Drawing.Point(88, 5);
            this.dte_from.Name = "dte_from";
            this.dte_from.Size = new System.Drawing.Size(85, 21);
            this.dte_from.TabIndex = 144;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Maroon;
            this.button5.Location = new System.Drawing.Point(875, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 23);
            this.button5.TabIndex = 142;
            this.button5.Text = "Select";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Maroon;
            this.button4.Location = new System.Drawing.Point(859, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 143;
            this.button4.Text = "Hide";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // dte_cheques
            // 
            this.dte_cheques.AllowUserToAddRows = false;
            this.dte_cheques.AllowUserToDeleteRows = false;
            this.dte_cheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dte_cheques.Location = new System.Drawing.Point(8, 41);
            this.dte_cheques.Name = "dte_cheques";
            this.dte_cheques.ReadOnly = true;
            this.dte_cheques.Size = new System.Drawing.Size(960, 214);
            this.dte_cheques.TabIndex = 140;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 9;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(153, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 35);
            this.button1.TabIndex = 64;
            this.button1.Text = "        Reject";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_OrderFormApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 542);
            this.Controls.Add(this.pnl_cheque);
            this.Controls.Add(this.pnl_credinote);
            this.Controls.Add(this.pnl_invoicedet);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel1);
            this.Name = "frm_OrderFormApproval";
            this.Text = "frm_OrderFormApproval";
            this.Load += new System.EventHandler(this.frm_OrderFormApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.pnl_invoicedet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.pnl_credinote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnl_cheque.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dte_cheques)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_TotalDisc;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txt_Subtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NetTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_subtotdiscper;
        private System.Windows.Forms.TextBox txt_subtotdisc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.TextBox txt_Customer_name;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_locationId_name;
        private System.Windows.Forms.TextBox txt_Locacode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_DocNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_cndet;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_Invoices;
        private System.Windows.Forms.TextBox txt_os;
        private System.Windows.Forms.Panel pnl_invoicedet;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel pnl_credinote;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnl_cheque;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton rdo_realized;
        private System.Windows.Forms.RadioButton rdo_daterange;
        private System.Windows.Forms.RadioButton rdo_unrealized;
        private System.Windows.Forms.RadioButton rdo_post;
        private System.Windows.Forms.RadioButton rdo_retured;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dte_to;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dte_cheques;
        private System.Windows.Forms.TextBox txt_creditlimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_creditPeriod;
        private System.Windows.Forms.Button button1;
    }
}