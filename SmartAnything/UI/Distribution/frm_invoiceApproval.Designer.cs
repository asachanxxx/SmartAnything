namespace SmartAnything.UI
{
    partial class frm_invoiceApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_invoiceApproval));
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.txt_Customer_name = new System.Windows.Forms.TextBox();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_locationId_name = new System.Windows.Forms.TextBox();
            this.txt_Locacode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_DocNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_subtotdisc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_subtotdiscper = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_TotalDisc = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txt_Subtotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NetTotal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(34, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 136;
            this.label13.Text = "Remarks";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(316, 292);
            this.dataGridView1.TabIndex = 151;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.BackColor = System.Drawing.Color.White;
            this.txt_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Remarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Remarks.Location = new System.Drawing.Point(91, 86);
            this.txt_Remarks.Multiline = true;
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(283, 46);
            this.txt_Remarks.TabIndex = 135;
            // 
            // txt_Customer_name
            // 
            this.txt_Customer_name.BackColor = System.Drawing.Color.White;
            this.txt_Customer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer_name.Location = new System.Drawing.Point(185, 59);
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
            this.txt_Customer.Location = new System.Drawing.Point(91, 59);
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.Size = new System.Drawing.Size(88, 21);
            this.txt_Customer.TabIndex = 132;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txt_Remarks);
            this.panel2.Controls.Add(this.txt_Customer_name);
            this.panel2.Controls.Add(this.txt_Customer);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_locationId_name);
            this.panel2.Controls.Add(this.txt_Locacode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_DocNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_subtotdisc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_subtotdiscper);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txt_TotalDisc);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.txt_Subtotal);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_NetTotal);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Location = new System.Drawing.Point(334, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 292);
            this.panel2.TabIndex = 152;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 62);
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
            this.txt_locationId_name.Location = new System.Drawing.Point(185, 32);
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
            this.txt_Locacode.Location = new System.Drawing.Point(91, 32);
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
            this.label4.Location = new System.Drawing.Point(37, 34);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 128;
            this.label2.Text = "Invoice No";
            // 
            // txt_subtotdisc
            // 
            this.txt_subtotdisc.BackColor = System.Drawing.Color.White;
            this.txt_subtotdisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subtotdisc.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_subtotdisc.ForeColor = System.Drawing.Color.Black;
            this.txt_subtotdisc.Location = new System.Drawing.Point(90, 167);
            this.txt_subtotdisc.Name = "txt_subtotdisc";
            this.txt_subtotdisc.ReadOnly = true;
            this.txt_subtotdisc.Size = new System.Drawing.Size(102, 22);
            this.txt_subtotdisc.TabIndex = 126;
            this.txt_subtotdisc.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 125;
            this.label1.Text = "Sub Total Disc";
            // 
            // txt_subtotdiscper
            // 
            this.txt_subtotdiscper.BackColor = System.Drawing.Color.White;
            this.txt_subtotdiscper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subtotdiscper.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_subtotdiscper.ForeColor = System.Drawing.Color.Black;
            this.txt_subtotdiscper.Location = new System.Drawing.Point(91, 138);
            this.txt_subtotdiscper.Name = "txt_subtotdiscper";
            this.txt_subtotdiscper.ReadOnly = true;
            this.txt_subtotdiscper.Size = new System.Drawing.Size(102, 22);
            this.txt_subtotdiscper.TabIndex = 124;
            this.txt_subtotdiscper.Text = "0.00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(45, 142);
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
            this.txt_TotalDisc.Location = new System.Drawing.Point(90, 196);
            this.txt_TotalDisc.Name = "txt_TotalDisc";
            this.txt_TotalDisc.ReadOnly = true;
            this.txt_TotalDisc.Size = new System.Drawing.Size(102, 22);
            this.txt_TotalDisc.TabIndex = 116;
            this.txt_TotalDisc.Text = "0.00";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(8, 200);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 14);
            this.label28.TabIndex = 117;
            this.label28.Text = "Total Discount";
            // 
            // txt_Subtotal
            // 
            this.txt_Subtotal.BackColor = System.Drawing.Color.White;
            this.txt_Subtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Subtotal.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_Subtotal.ForeColor = System.Drawing.Color.Black;
            this.txt_Subtotal.Location = new System.Drawing.Point(90, 225);
            this.txt_Subtotal.Name = "txt_Subtotal";
            this.txt_Subtotal.ReadOnly = true;
            this.txt_Subtotal.Size = new System.Drawing.Size(136, 22);
            this.txt_Subtotal.TabIndex = 114;
            this.txt_Subtotal.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 115;
            this.label3.Text = "Gross Amount";
            // 
            // txt_NetTotal
            // 
            this.txt_NetTotal.BackColor = System.Drawing.Color.White;
            this.txt_NetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NetTotal.Font = new System.Drawing.Font("Calibri", 9F);
            this.txt_NetTotal.ForeColor = System.Drawing.Color.Black;
            this.txt_NetTotal.Location = new System.Drawing.Point(90, 254);
            this.txt_NetTotal.Name = "txt_NetTotal";
            this.txt_NetTotal.ReadOnly = true;
            this.txt_NetTotal.Size = new System.Drawing.Size(136, 22);
            this.txt_NetTotal.TabIndex = 108;
            this.txt_NetTotal.Text = "0.00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(18, 258);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 14);
            this.label17.TabIndex = 109;
            this.label17.Text = "Net Amount";
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
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(121)))), ((int)(((byte)(142)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(734, 45);
            this.pnl_header.TabIndex = 150;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Location = new System.Drawing.Point(305, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(408, 47);
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
            this.btn_exit.Location = new System.Drawing.Point(305, 9);
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
            this.btn_edit.ImageIndex = 1;
            this.btn_edit.ImageList = this.imageList1;
            this.btn_edit.Location = new System.Drawing.Point(208, 9);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(91, 35);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.Text = "        Approve";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 56);
            this.panel1.TabIndex = 153;
            // 
            // frm_invoiceApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 420);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel1);
            this.Name = "frm_invoiceApproval";
            this.Text = "frm_invoiceApproval";
            this.Load += new System.EventHandler(this.frm_invoiceApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.TextBox txt_Customer_name;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_locationId_name;
        private System.Windows.Forms.TextBox txt_Locacode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_DocNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_subtotdisc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_subtotdiscper;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_TotalDisc;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txt_Subtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NetTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
    }
}