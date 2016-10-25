namespace SmartAnything.Reports
{
    partial class frm_DistributionReporint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DistributionReporint));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.rdo_order = new System.Windows.Forms.RadioButton();
            this.rdo_inv = new System.Windows.Forms.RadioButton();
            this.txt_docno = new System.Windows.Forms.TextBox();
            this.txt_docnoamt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo_rec = new System.Windows.Forms.RadioButton();
            this.rdo_cn = new System.Windows.Forms.RadioButton();
            this.rdo_packing = new System.Windows.Forms.RadioButton();
            this.rdo_do = new System.Windows.Forms.RadioButton();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Location = new System.Drawing.Point(12, 195);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(583, 47);
            this.panel4.TabIndex = 153;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 64;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(487, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(390, 4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
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
            this.pnl_header.Size = new System.Drawing.Size(609, 45);
            this.pnl_header.TabIndex = 154;
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
            // rdo_order
            // 
            this.rdo_order.AutoSize = true;
            this.rdo_order.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_order.Location = new System.Drawing.Point(67, 17);
            this.rdo_order.Name = "rdo_order";
            this.rdo_order.Size = new System.Drawing.Size(121, 18);
            this.rdo_order.TabIndex = 51;
            this.rdo_order.TabStop = true;
            this.rdo_order.Text = "Order Form Reprint";
            this.rdo_order.UseVisualStyleBackColor = true;
            // 
            // rdo_inv
            // 
            this.rdo_inv.AutoSize = true;
            this.rdo_inv.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_inv.Location = new System.Drawing.Point(67, 41);
            this.rdo_inv.Name = "rdo_inv";
            this.rdo_inv.Size = new System.Drawing.Size(99, 18);
            this.rdo_inv.TabIndex = 153;
            this.rdo_inv.TabStop = true;
            this.rdo_inv.Text = "Invoice Reprint";
            this.rdo_inv.UseVisualStyleBackColor = true;
            // 
            // txt_docno
            // 
            this.txt_docno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_docno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_docno.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_docno.Location = new System.Drawing.Point(67, 101);
            this.txt_docno.Name = "txt_docno";
            this.txt_docno.Size = new System.Drawing.Size(80, 22);
            this.txt_docno.TabIndex = 155;
            this.txt_docno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_docno_KeyDown);
            // 
            // txt_docnoamt
            // 
            this.txt_docnoamt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_docnoamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_docnoamt.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_docnoamt.Location = new System.Drawing.Point(153, 101);
            this.txt_docnoamt.Name = "txt_docnoamt";
            this.txt_docnoamt.Size = new System.Drawing.Size(366, 22);
            this.txt_docnoamt.TabIndex = 156;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdo_rec);
            this.panel1.Controls.Add(this.rdo_cn);
            this.panel1.Controls.Add(this.rdo_packing);
            this.panel1.Controls.Add(this.rdo_do);
            this.panel1.Controls.Add(this.txt_docnoamt);
            this.panel1.Controls.Add(this.txt_docno);
            this.panel1.Controls.Add(this.rdo_inv);
            this.panel1.Controls.Add(this.rdo_order);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 138);
            this.panel1.TabIndex = 155;
            // 
            // rdo_rec
            // 
            this.rdo_rec.AutoSize = true;
            this.rdo_rec.Checked = true;
            this.rdo_rec.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_rec.Location = new System.Drawing.Point(227, 65);
            this.rdo_rec.Name = "rdo_rec";
            this.rdo_rec.Size = new System.Drawing.Size(101, 18);
            this.rdo_rec.TabIndex = 160;
            this.rdo_rec.TabStop = true;
            this.rdo_rec.Text = "Reciept Reprint";
            this.rdo_rec.UseVisualStyleBackColor = true;
            // 
            // rdo_cn
            // 
            this.rdo_cn.AutoSize = true;
            this.rdo_cn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_cn.Location = new System.Drawing.Point(227, 41);
            this.rdo_cn.Name = "rdo_cn";
            this.rdo_cn.Size = new System.Drawing.Size(84, 18);
            this.rdo_cn.TabIndex = 159;
            this.rdo_cn.TabStop = true;
            this.rdo_cn.Text = "Credit Note ";
            this.rdo_cn.UseVisualStyleBackColor = true;
            // 
            // rdo_packing
            // 
            this.rdo_packing.AutoSize = true;
            this.rdo_packing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_packing.Location = new System.Drawing.Point(227, 17);
            this.rdo_packing.Name = "rdo_packing";
            this.rdo_packing.Size = new System.Drawing.Size(83, 18);
            this.rdo_packing.TabIndex = 158;
            this.rdo_packing.TabStop = true;
            this.rdo_packing.Text = "Packing List";
            this.rdo_packing.UseVisualStyleBackColor = true;
            // 
            // rdo_do
            // 
            this.rdo_do.AutoSize = true;
            this.rdo_do.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_do.Location = new System.Drawing.Point(67, 65);
            this.rdo_do.Name = "rdo_do";
            this.rdo_do.Size = new System.Drawing.Size(98, 18);
            this.rdo_do.TabIndex = 157;
            this.rdo_do.TabStop = true;
            this.rdo_do.Text = "Delivery Order";
            this.rdo_do.UseVisualStyleBackColor = true;
            // 
            // frm_DistributionReporint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 255);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_DistributionReporint";
            this.Text = "frm_DistributionReporint";
            this.Load += new System.EventHandler(this.frm_DistributionReporint_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdo_do;
        private System.Windows.Forms.TextBox txt_docnoamt;
        private System.Windows.Forms.TextBox txt_docno;
        private System.Windows.Forms.RadioButton rdo_inv;
        private System.Windows.Forms.RadioButton rdo_order;
        private System.Windows.Forms.RadioButton rdo_rec;
        private System.Windows.Forms.RadioButton rdo_cn;
        private System.Windows.Forms.RadioButton rdo_packing;
        private System.Windows.Forms.Button button1;
    }
}