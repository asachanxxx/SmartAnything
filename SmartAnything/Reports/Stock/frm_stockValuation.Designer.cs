namespace SmartAnything.Reports
{
    partial class frm_stockValuation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stockValuation));
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo_subcat = new System.Windows.Forms.CheckBox();
            this.rdo_cat = new System.Windows.Forms.RadioButton();
            this.rdo_supp = new System.Windows.Forms.RadioButton();
            this.txt_subcat_name = new System.Windows.Forms.TextBox();
            this.txt_subcat = new System.Windows.Forms.TextBox();
            this.txt_categoryName = new System.Windows.Forms.TextBox();
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.txt_suppliername = new System.Windows.Forms.TextBox();
            this.txt_Suplier = new System.Windows.Forms.TextBox();
            this.rdo_full = new System.Windows.Forms.RadioButton();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnl_header.Size = new System.Drawing.Size(604, 45);
            this.pnl_header.TabIndex = 147;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(1, 186);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(594, 48);
            this.panel5.TabIndex = 151;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_print);
            this.panel4.Location = new System.Drawing.Point(4, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(583, 47);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdo_full);
            this.panel1.Controls.Add(this.rdo_subcat);
            this.panel1.Controls.Add(this.rdo_cat);
            this.panel1.Controls.Add(this.rdo_supp);
            this.panel1.Controls.Add(this.txt_subcat_name);
            this.panel1.Controls.Add(this.txt_subcat);
            this.panel1.Controls.Add(this.txt_categoryName);
            this.panel1.Controls.Add(this.txt_Category);
            this.panel1.Controls.Add(this.txt_suppliername);
            this.panel1.Controls.Add(this.txt_Suplier);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 129);
            this.panel1.TabIndex = 152;
            // 
            // rdo_subcat
            // 
            this.rdo_subcat.AutoSize = true;
            this.rdo_subcat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_subcat.Location = new System.Drawing.Point(13, 86);
            this.rdo_subcat.Name = "rdo_subcat";
            this.rdo_subcat.Size = new System.Drawing.Size(88, 18);
            this.rdo_subcat.TabIndex = 154;
            this.rdo_subcat.Text = "SubCategory";
            this.rdo_subcat.UseVisualStyleBackColor = true;
            // 
            // rdo_cat
            // 
            this.rdo_cat.AutoSize = true;
            this.rdo_cat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_cat.Location = new System.Drawing.Point(13, 54);
            this.rdo_cat.Name = "rdo_cat";
            this.rdo_cat.Size = new System.Drawing.Size(69, 18);
            this.rdo_cat.TabIndex = 153;
            this.rdo_cat.Text = "Category";
            this.rdo_cat.UseVisualStyleBackColor = true;
            // 
            // rdo_supp
            // 
            this.rdo_supp.AutoSize = true;
            this.rdo_supp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_supp.Location = new System.Drawing.Point(13, 27);
            this.rdo_supp.Name = "rdo_supp";
            this.rdo_supp.Size = new System.Drawing.Size(65, 18);
            this.rdo_supp.TabIndex = 51;
            this.rdo_supp.Text = "Supplier";
            this.rdo_supp.UseVisualStyleBackColor = true;
            // 
            // txt_subcat_name
            // 
            this.txt_subcat_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_subcat_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subcat_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subcat_name.Location = new System.Drawing.Point(193, 82);
            this.txt_subcat_name.Name = "txt_subcat_name";
            this.txt_subcat_name.Size = new System.Drawing.Size(366, 22);
            this.txt_subcat_name.TabIndex = 50;
            // 
            // txt_subcat
            // 
            this.txt_subcat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_subcat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subcat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subcat.Location = new System.Drawing.Point(107, 82);
            this.txt_subcat.Name = "txt_subcat";
            this.txt_subcat.Size = new System.Drawing.Size(80, 22);
            this.txt_subcat.TabIndex = 49;
            this.txt_subcat.TextChanged += new System.EventHandler(this.txt_subcat_TextChanged);
            this.txt_subcat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_subcat_KeyDown);
            // 
            // txt_categoryName
            // 
            this.txt_categoryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_categoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_categoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_categoryName.Location = new System.Drawing.Point(193, 54);
            this.txt_categoryName.Name = "txt_categoryName";
            this.txt_categoryName.Size = new System.Drawing.Size(366, 22);
            this.txt_categoryName.TabIndex = 47;
            // 
            // txt_Category
            // 
            this.txt_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Category.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category.Location = new System.Drawing.Point(107, 54);
            this.txt_Category.Name = "txt_Category";
            this.txt_Category.Size = new System.Drawing.Size(80, 22);
            this.txt_Category.TabIndex = 46;
            this.txt_Category.TextChanged += new System.EventHandler(this.txt_Category_TextChanged);
            this.txt_Category.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Category_KeyDown);
            // 
            // txt_suppliername
            // 
            this.txt_suppliername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_suppliername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_suppliername.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_suppliername.Location = new System.Drawing.Point(192, 26);
            this.txt_suppliername.Name = "txt_suppliername";
            this.txt_suppliername.Size = new System.Drawing.Size(367, 22);
            this.txt_suppliername.TabIndex = 44;
            // 
            // txt_Suplier
            // 
            this.txt_Suplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Suplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Suplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Suplier.Location = new System.Drawing.Point(107, 26);
            this.txt_Suplier.Name = "txt_Suplier";
            this.txt_Suplier.Size = new System.Drawing.Size(80, 22);
            this.txt_Suplier.TabIndex = 42;
            this.txt_Suplier.TextChanged += new System.EventHandler(this.txt_Suplier_TextChanged);
            this.txt_Suplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Suplier_KeyDown);
            // 
            // rdo_full
            // 
            this.rdo_full.AutoSize = true;
            this.rdo_full.Checked = true;
            this.rdo_full.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_full.Location = new System.Drawing.Point(13, 3);
            this.rdo_full.Name = "rdo_full";
            this.rdo_full.Size = new System.Drawing.Size(81, 18);
            this.rdo_full.TabIndex = 155;
            this.rdo_full.TabStop = true;
            this.rdo_full.Text = "Full Details";
            this.rdo_full.UseVisualStyleBackColor = true;
            // 
            // frm_stockValuation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 242);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_stockValuation";
            this.Text = "frm_stockValuation";
            this.Load += new System.EventHandler(this.frm_stockValuation_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_suppliername;
        private System.Windows.Forms.TextBox txt_Suplier;
        private System.Windows.Forms.TextBox txt_subcat_name;
        private System.Windows.Forms.TextBox txt_subcat;
        private System.Windows.Forms.TextBox txt_categoryName;
        private System.Windows.Forms.TextBox txt_Category;
        private System.Windows.Forms.CheckBox rdo_subcat;
        private System.Windows.Forms.RadioButton rdo_cat;
        private System.Windows.Forms.RadioButton rdo_supp;
        private System.Windows.Forms.RadioButton rdo_full;
    }
}