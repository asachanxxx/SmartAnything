namespace SmartAnything.UI.Distribution
{
    partial class frm_customer_item_Alloc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_customer_item_Alloc));
            this.btn_print = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dte_datefrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dte_dateto = new System.Windows.Forms.DateTimePicker();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_customer = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.lbl_itemname = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_customer = new System.Windows.Forms.TextBox();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(250, 6);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(470, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "Date From";
            // 
            // dte_datefrom
            // 
            this.dte_datefrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dte_datefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_datefrom.Location = new System.Drawing.Point(473, 24);
            this.dte_datefrom.Name = "dte_datefrom";
            this.dte_datefrom.Size = new System.Drawing.Size(100, 22);
            this.dte_datefrom.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(589, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Date To";
            // 
            // dte_dateto
            // 
            this.dte_dateto.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dte_dateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_dateto.Location = new System.Drawing.Point(592, 23);
            this.dte_dateto.Name = "dte_dateto";
            this.dte_dateto.Size = new System.Drawing.Size(100, 22);
            this.dte_dateto.TabIndex = 29;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(347, 6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dte_datefrom);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dte_dateto);
            this.panel2.Controls.Add(this.lbl_customer);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.txt_qty);
            this.panel2.Controls.Add(this.lbl_itemname);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txt_code);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txt_customer);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(12, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 69);
            this.panel2.TabIndex = 168;
            // 
            // lbl_customer
            // 
            this.lbl_customer.AutoSize = true;
            this.lbl_customer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customer.ForeColor = System.Drawing.Color.White;
            this.lbl_customer.Location = new System.Drawing.Point(7, 46);
            this.lbl_customer.Name = "lbl_customer";
            this.lbl_customer.Size = new System.Drawing.Size(19, 14);
            this.lbl_customer.TabIndex = 20;
            this.lbl_customer.Text = "....";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(695, 5);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(79, 14);
            this.label27.TabIndex = 18;
            this.label27.Text = "Allocated Qty";
            // 
            // txt_qty
            // 
            this.txt_qty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_qty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            this.txt_qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_qty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txt_qty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(60)))), ((int)(((byte)(11)))));
            this.txt_qty.Location = new System.Drawing.Point(698, 23);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(81, 22);
            this.txt_qty.TabIndex = 17;
            this.txt_qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_qty_KeyDown);
            // 
            // lbl_itemname
            // 
            this.lbl_itemname.AutoSize = true;
            this.lbl_itemname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemname.ForeColor = System.Drawing.Color.White;
            this.lbl_itemname.Location = new System.Drawing.Point(260, 46);
            this.lbl_itemname.Name = "lbl_itemname";
            this.lbl_itemname.Size = new System.Drawing.Size(19, 14);
            this.lbl_itemname.TabIndex = 10;
            this.lbl_itemname.Text = "....";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(7, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 14);
            this.label9.TabIndex = 5;
            this.label9.Text = "Customer";
            // 
            // txt_code
            // 
            this.txt_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            this.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_code.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(60)))), ((int)(((byte)(11)))));
            this.txt_code.Location = new System.Drawing.Point(263, 24);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(204, 22);
            this.txt_code.TabIndex = 1;
            this.txt_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_code_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(258, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Item Code";
            // 
            // txt_customer
            // 
            this.txt_customer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_customer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            this.txt_customer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_customer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txt_customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.txt_customer.Location = new System.Drawing.Point(10, 24);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.Size = new System.Drawing.Size(247, 22);
            this.txt_customer.TabIndex = 4;
            this.txt_customer.TextChanged += new System.EventHandler(this.txt_customer_TextChanged);
            this.txt_customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_customer_KeyDown);
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
            this.pnl_header.Size = new System.Drawing.Size(814, 45);
            this.pnl_header.TabIndex = 165;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.White;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.ImageIndex = 1;
            this.btn_edit.ImageList = this.imageList1;
            this.btn_edit.Location = new System.Drawing.Point(134, 6);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(110, 35);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.Text = "        Audit Pass";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(792, 349);
            this.dataGridView1.TabIndex = 166;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Location = new System.Drawing.Point(343, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(442, 47);
            this.panel4.TabIndex = 147;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 56);
            this.panel1.TabIndex = 167;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_customer_item_Alloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 542);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_customer_item_Alloc";
            this.Text = "frm_customer_item_Alloc";
            this.Load += new System.EventHandler(this.frm_customer_item_Alloc_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dte_datefrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dte_dateto;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_customer;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label lbl_itemname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_customer;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}