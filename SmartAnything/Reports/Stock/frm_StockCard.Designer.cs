namespace SmartAnything.Reports
{
    partial class frm_StockCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StockCard));
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_print = new System.Windows.Forms.Button();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.rdo_stockCode = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo_location = new System.Windows.Forms.RadioButton();
            this.txt_loca_name = new System.Windows.Forms.TextBox();
            this.txt_loca = new System.Windows.Forms.TextBox();
            this.txt_itemcode1 = new System.Windows.Forms.TextBox();
            this.chk_all = new System.Windows.Forms.CheckBox();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(6, 157);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(607, 48);
            this.panel5.TabIndex = 157;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Location = new System.Drawing.Point(5, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(597, 47);
            this.panel4.TabIndex = 65;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(503, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 35);
            this.btn_exit.TabIndex = 63;
            this.btn_exit.Text = "       Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
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
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 5;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(406, 4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(91, 35);
            this.btn_print.TabIndex = 62;
            this.btn_print.Text = "       Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
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
            this.pnl_header.Size = new System.Drawing.Size(626, 45);
            this.pnl_header.TabIndex = 156;
            // 
            // rdo_stockCode
            // 
            this.rdo_stockCode.AutoSize = true;
            this.rdo_stockCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_stockCode.Location = new System.Drawing.Point(19, 44);
            this.rdo_stockCode.Name = "rdo_stockCode";
            this.rdo_stockCode.Size = new System.Drawing.Size(79, 18);
            this.rdo_stockCode.TabIndex = 162;
            this.rdo_stockCode.TabStop = true;
            this.rdo_stockCode.Text = "Stock Code";
            this.rdo_stockCode.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chk_all);
            this.panel1.Controls.Add(this.rdo_stockCode);
            this.panel1.Controls.Add(this.rdo_location);
            this.panel1.Controls.Add(this.txt_loca_name);
            this.panel1.Controls.Add(this.txt_loca);
            this.panel1.Controls.Add(this.txt_itemcode1);
            this.panel1.Location = new System.Drawing.Point(6, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 102);
            this.panel1.TabIndex = 158;
            // 
            // rdo_location
            // 
            this.rdo_location.AutoSize = true;
            this.rdo_location.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_location.Location = new System.Drawing.Point(19, 16);
            this.rdo_location.Name = "rdo_location";
            this.rdo_location.Size = new System.Drawing.Size(66, 18);
            this.rdo_location.TabIndex = 159;
            this.rdo_location.TabStop = true;
            this.rdo_location.Text = "Location";
            this.rdo_location.UseVisualStyleBackColor = true;
            // 
            // txt_loca_name
            // 
            this.txt_loca_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca_name.Location = new System.Drawing.Point(211, 14);
            this.txt_loca_name.Name = "txt_loca_name";
            this.txt_loca_name.Size = new System.Drawing.Size(271, 22);
            this.txt_loca_name.TabIndex = 156;
            // 
            // txt_loca
            // 
            this.txt_loca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_loca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_loca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loca.Location = new System.Drawing.Point(105, 14);
            this.txt_loca.Name = "txt_loca";
            this.txt_loca.Size = new System.Drawing.Size(100, 22);
            this.txt_loca.TabIndex = 155;
            this.txt_loca.TextChanged += new System.EventHandler(this.txt_loca_TextChanged);
            this.txt_loca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loca_KeyDown);
            // 
            // txt_itemcode1
            // 
            this.txt_itemcode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_itemcode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_itemcode1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemcode1.Location = new System.Drawing.Point(105, 42);
            this.txt_itemcode1.Name = "txt_itemcode1";
            this.txt_itemcode1.Size = new System.Drawing.Size(377, 22);
            this.txt_itemcode1.TabIndex = 52;
            this.txt_itemcode1.TextChanged += new System.EventHandler(this.txt_itemcode1_TextChanged);
            this.txt_itemcode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_itemcode1_KeyDown);
            // 
            // chk_all
            // 
            this.chk_all.AutoSize = true;
            this.chk_all.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_all.Location = new System.Drawing.Point(488, 16);
            this.chk_all.Name = "chk_all";
            this.chk_all.Size = new System.Drawing.Size(39, 18);
            this.chk_all.TabIndex = 163;
            this.chk_all.Text = "All";
            this.chk_all.UseVisualStyleBackColor = true;
            // 
            // frm_StockCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 214);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel1);
            this.Name = "frm_StockCard";
            this.Text = "frm_StockCard";
            this.Load += new System.EventHandler(this.frm_StockCard_Load);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.RadioButton rdo_stockCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_itemcode1;
        private System.Windows.Forms.RadioButton rdo_location;
        private System.Windows.Forms.TextBox txt_loca_name;
        private System.Windows.Forms.TextBox txt_loca;
        private System.Windows.Forms.CheckBox chk_all;
    }
}