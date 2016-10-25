namespace SmartAnything.UI
{
    partial class frm_purchaserequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_purchaserequest));
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_processes = new System.Windows.Forms.Label();
            this.txt_locaname = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_suppliername = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Suplier = new System.Windows.Forms.TextBox();
            this.dte_dilivary = new System.Windows.Forms.DateTimePicker();
            this.dte_request = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_reqno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_amt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_selling = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_cost = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_items = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_pices = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_net = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_gross = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_header.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.pnl_header.Size = new System.Drawing.Size(839, 45);
            this.pnl_header.TabIndex = 89;
            // 
            // lbl_headerpaneltext
            // 
            this.lbl_headerpaneltext.AutoSize = true;
            this.lbl_headerpaneltext.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_headerpaneltext.ForeColor = System.Drawing.Color.White;
            this.lbl_headerpaneltext.Location = new System.Drawing.Point(4, 1);
            this.lbl_headerpaneltext.Name = "lbl_headerpaneltext";
            this.lbl_headerpaneltext.Size = new System.Drawing.Size(297, 42);
            this.lbl_headerpaneltext.TabIndex = 0;
            this.lbl_headerpaneltext.Text = "...............................";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl_processes);
            this.panel3.Controls.Add(this.txt_locaname);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.txt_suppliername);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txt_Suplier);
            this.panel3.Controls.Add(this.dte_dilivary);
            this.panel3.Controls.Add(this.dte_request);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txt_remark);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txt_location);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_reqno);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(12, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 124);
            this.panel3.TabIndex = 91;
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
            // txt_locaname
            // 
            this.txt_locaname.BackColor = System.Drawing.Color.White;
            this.txt_locaname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_locaname.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_locaname.Location = new System.Drawing.Point(211, 32);
            this.txt_locaname.Name = "txt_locaname";
            this.txt_locaname.ReadOnly = true;
            this.txt_locaname.Size = new System.Drawing.Size(168, 21);
            this.txt_locaname.TabIndex = 46;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(757, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txt_suppliername
            // 
            this.txt_suppliername.BackColor = System.Drawing.Color.White;
            this.txt_suppliername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_suppliername.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_suppliername.Location = new System.Drawing.Point(547, 32);
            this.txt_suppliername.Name = "txt_suppliername";
            this.txt_suppliername.Size = new System.Drawing.Size(204, 21);
            this.txt_suppliername.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(388, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 43;
            this.label13.Text = "Supplier";
            // 
            // txt_Suplier
            // 
            this.txt_Suplier.BackColor = System.Drawing.Color.White;
            this.txt_Suplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Suplier.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_Suplier.Location = new System.Drawing.Point(441, 32);
            this.txt_Suplier.Name = "txt_Suplier";
            this.txt_Suplier.Size = new System.Drawing.Size(100, 21);
            this.txt_Suplier.TabIndex = 42;
            this.txt_Suplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Suplier_KeyDown);
            // 
            // dte_dilivary
            // 
            this.dte_dilivary.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.dte_dilivary.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_dilivary.Location = new System.Drawing.Point(441, 58);
            this.dte_dilivary.Name = "dte_dilivary";
            this.dte_dilivary.Size = new System.Drawing.Size(100, 21);
            this.dte_dilivary.TabIndex = 28;
            this.dte_dilivary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dte_dilivary_KeyDown);
            // 
            // dte_request
            // 
            this.dte_request.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.dte_request.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_request.Location = new System.Drawing.Point(105, 57);
            this.dte_request.Name = "dte_request";
            this.dte_request.Size = new System.Drawing.Size(100, 21);
            this.dte_request.TabIndex = 27;
            this.dte_request.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dte_request_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(48, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 14);
            this.label10.TabIndex = 26;
            this.label10.Text = "Remarks";
            // 
            // txt_remark
            // 
            this.txt_remark.BackColor = System.Drawing.Color.White;
            this.txt_remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_remark.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_remark.Location = new System.Drawing.Point(105, 81);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(689, 21);
            this.txt_remark.TabIndex = 25;
            this.txt_remark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_remark_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(359, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Delivary Date";
            // 
            // txt_location
            // 
            this.txt_location.BackColor = System.Drawing.Color.White;
            this.txt_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_location.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_location.Location = new System.Drawing.Point(105, 32);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(100, 21);
            this.txt_location.TabIndex = 7;
            this.txt_location.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_location_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Request Location";
            // 
            // txt_reqno
            // 
            this.txt_reqno.BackColor = System.Drawing.Color.White;
            this.txt_reqno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_reqno.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txt_reqno.Location = new System.Drawing.Point(105, 8);
            this.txt_reqno.Name = "txt_reqno";
            this.txt_reqno.Size = new System.Drawing.Size(100, 21);
            this.txt_reqno.TabIndex = 3;
            this.txt_reqno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_reqno_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Request No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Request Date";
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
            this.panel1.Location = new System.Drawing.Point(12, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 66);
            this.panel1.TabIndex = 93;
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(814, 170);
            this.dataGridView1.TabIndex = 92;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(234, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 18);
            this.label15.TabIndex = 99;
            this.label15.Text = "NO OF ITEMS";
            // 
            // txt_items
            // 
            this.txt_items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_items.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_items.Location = new System.Drawing.Point(332, 3);
            this.txt_items.Name = "txt_items";
            this.txt_items.ReadOnly = true;
            this.txt_items.Size = new System.Drawing.Size(76, 23);
            this.txt_items.TabIndex = 98;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(7, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 18);
            this.label16.TabIndex = 97;
            this.label16.Text = "NO OF PIECES";
            // 
            // txt_pices
            // 
            this.txt_pices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pices.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pices.Location = new System.Drawing.Point(105, 3);
            this.txt_pices.Name = "txt_pices";
            this.txt_pices.ReadOnly = true;
            this.txt_pices.Size = new System.Drawing.Size(76, 23);
            this.txt_pices.TabIndex = 96;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(563, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 18);
            this.label17.TabIndex = 95;
            this.label17.Text = "NET AMOUNT";
            // 
            // txt_net
            // 
            this.txt_net.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_net.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_net.Location = new System.Drawing.Point(663, 30);
            this.txt_net.Name = "txt_net";
            this.txt_net.ReadOnly = true;
            this.txt_net.Size = new System.Drawing.Size(136, 23);
            this.txt_net.TabIndex = 94;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_gross);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_pices);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txt_net);
            this.panel2.Controls.Add(this.txt_items);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(12, 438);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 60);
            this.panel2.TabIndex = 100;
            // 
            // txt_gross
            // 
            this.txt_gross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_gross.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gross.Location = new System.Drawing.Point(663, 3);
            this.txt_gross.Name = "txt_gross";
            this.txt_gross.ReadOnly = true;
            this.txt_gross.Size = new System.Drawing.Size(136, 23);
            this.txt_gross.TabIndex = 100;
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
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(12, 504);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(814, 65);
            this.panel5.TabIndex = 101;
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
            this.panel4.Location = new System.Drawing.Point(119, 11);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(888, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 102;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_purchaserequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 573);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_purchaserequest";
            this.Text = "frm_purchaserequest";
            this.Load += new System.EventHandler(this.frm_purchaserequest_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_reqno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_amt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_selling;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_cost;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_items;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_pices;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_net;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dte_dilivary;
        private System.Windows.Forms.DateTimePicker dte_request;
        private System.Windows.Forms.TextBox txt_locaname;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_suppliername;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Suplier;
        private System.Windows.Forms.TextBox txt_gross;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_processes;
    }
}