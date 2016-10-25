namespace SmartAnything.UI
{
    partial class frm_chequeHandling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_chequeHandling));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dte_cheques = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdo_unrealized = new System.Windows.Forms.RadioButton();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.txt_Customer_name = new System.Windows.Forms.TextBox();
            this.rdo_post = new System.Windows.Forms.RadioButton();
            this.rdo_retured = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dte_to = new System.Windows.Forms.DateTimePicker();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.btn_Invoices = new System.Windows.Forms.Button();
            this.rdo_daterange = new System.Windows.Forms.RadioButton();
            this.rdo_realized = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dte_cheques)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
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
            this.pnl_header.Size = new System.Drawing.Size(984, 45);
            this.pnl_header.TabIndex = 158;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 431);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 56);
            this.panel2.TabIndex = 160;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(387, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(568, 47);
            this.panel3.TabIndex = 147;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 4;
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(241, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 35);
            this.button4.TabIndex = 64;
            this.button4.Text = "       Realize All";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 2;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(476, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 35);
            this.button1.TabIndex = 63;
            this.button1.Text = "       Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 1;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(357, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 35);
            this.button3.TabIndex = 60;
            this.button3.Text = "        Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dte_cheques
            // 
            this.dte_cheques.AllowUserToDeleteRows = false;
            this.dte_cheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dte_cheques.Location = new System.Drawing.Point(12, 92);
            this.dte_cheques.Name = "dte_cheques";
            this.dte_cheques.Size = new System.Drawing.Size(960, 333);
            this.dte_cheques.TabIndex = 161;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.rdo_realized);
            this.panel7.Controls.Add(this.rdo_daterange);
            this.panel7.Controls.Add(this.rdo_unrealized);
            this.panel7.Controls.Add(this.txt_Customer);
            this.panel7.Controls.Add(this.txt_Customer_name);
            this.panel7.Controls.Add(this.rdo_post);
            this.panel7.Controls.Add(this.rdo_retured);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.dte_to);
            this.panel7.Controls.Add(this.dte_from);
            this.panel7.Controls.Add(this.label31);
            this.panel7.Controls.Add(this.btn_Invoices);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(12, 51);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(960, 35);
            this.panel7.TabIndex = 162;
            // 
            // rdo_unrealized
            // 
            this.rdo_unrealized.AutoSize = true;
            this.rdo_unrealized.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_unrealized.Location = new System.Drawing.Point(703, 9);
            this.rdo_unrealized.Name = "rdo_unrealized";
            this.rdo_unrealized.Size = new System.Drawing.Size(76, 17);
            this.rdo_unrealized.TabIndex = 152;
            this.rdo_unrealized.Text = "Unrealized";
            this.rdo_unrealized.UseVisualStyleBackColor = true;
            // 
            // txt_Customer
            // 
            this.txt_Customer.BackColor = System.Drawing.Color.White;
            this.txt_Customer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer.Location = new System.Drawing.Point(57, 5);
            this.txt_Customer.MaxLength = 20;
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.Size = new System.Drawing.Size(74, 21);
            this.txt_Customer.TabIndex = 149;
            this.txt_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // txt_Customer_name
            // 
            this.txt_Customer_name.BackColor = System.Drawing.Color.White;
            this.txt_Customer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer_name.Location = new System.Drawing.Point(135, 5);
            this.txt_Customer_name.Name = "txt_Customer_name";
            this.txt_Customer_name.ReadOnly = true;
            this.txt_Customer_name.Size = new System.Drawing.Size(150, 21);
            this.txt_Customer_name.TabIndex = 151;
            // 
            // rdo_post
            // 
            this.rdo_post.AutoSize = true;
            this.rdo_post.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_post.Location = new System.Drawing.Point(585, 9);
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
            this.rdo_retured.Location = new System.Drawing.Point(629, 9);
            this.rdo_retured.Name = "rdo_retured";
            this.rdo_retured.Size = new System.Drawing.Size(71, 17);
            this.rdo_retured.TabIndex = 147;
            this.rdo_retured.Text = "Returned ";
            this.rdo_retured.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(462, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 14);
            this.label1.TabIndex = 146;
            this.label1.Text = "To";
            // 
            // dte_to
            // 
            this.dte_to.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_to.Location = new System.Drawing.Point(486, 5);
            this.dte_to.Name = "dte_to";
            this.dte_to.Size = new System.Drawing.Size(87, 21);
            this.dte_to.TabIndex = 145;
            // 
            // dte_from
            // 
            this.dte_from.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_from.Location = new System.Drawing.Point(371, 5);
            this.dte_from.Name = "dte_from";
            this.dte_from.Size = new System.Drawing.Size(85, 21);
            this.dte_from.TabIndex = 144;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(3, 10);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(54, 14);
            this.label31.TabIndex = 143;
            this.label31.Text = "Customer";
            // 
            // btn_Invoices
            // 
            this.btn_Invoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Invoices.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Invoices.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Invoices.Location = new System.Drawing.Point(856, 6);
            this.btn_Invoices.Name = "btn_Invoices";
            this.btn_Invoices.Size = new System.Drawing.Size(92, 23);
            this.btn_Invoices.TabIndex = 142;
            this.btn_Invoices.Text = "Select";
            this.btn_Invoices.UseVisualStyleBackColor = true;
            this.btn_Invoices.Click += new System.EventHandler(this.btn_Invoices_Click);
            // 
            // rdo_daterange
            // 
            this.rdo_daterange.AutoSize = true;
            this.rdo_daterange.Checked = true;
            this.rdo_daterange.Location = new System.Drawing.Point(290, 8);
            this.rdo_daterange.Name = "rdo_daterange";
            this.rdo_daterange.Size = new System.Drawing.Size(80, 17);
            this.rdo_daterange.TabIndex = 153;
            this.rdo_daterange.TabStop = true;
            this.rdo_daterange.Text = "DateRange";
            this.rdo_daterange.UseVisualStyleBackColor = true;
            // 
            // rdo_realized
            // 
            this.rdo_realized.AutoSize = true;
            this.rdo_realized.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_realized.Location = new System.Drawing.Point(784, 8);
            this.rdo_realized.Name = "rdo_realized";
            this.rdo_realized.Size = new System.Drawing.Size(65, 17);
            this.rdo_realized.TabIndex = 154;
            this.rdo_realized.Text = "Realized";
            this.rdo_realized.UseVisualStyleBackColor = true;
            // 
            // frm_chequeHandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 499);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.dte_cheques);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_chequeHandling";
            this.Text = "frm_chequeHandling";
            this.Load += new System.EventHandler(this.frm_chequeHandling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dte_cheques)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dte_cheques;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_Invoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dte_to;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.RadioButton rdo_post;
        private System.Windows.Forms.RadioButton rdo_retured;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.TextBox txt_Customer_name;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton rdo_unrealized;
        private System.Windows.Forms.RadioButton rdo_daterange;
        private System.Windows.Forms.RadioButton rdo_realized;
    }
}