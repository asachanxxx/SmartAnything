namespace SmartAnything.UI
{
    partial class frm_categories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_categories));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_Codex = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_catlock = new System.Windows.Forms.CheckBox();
            this.lbl_new = new System.Windows.Forms.Label();
            this.txt_Descr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_newsub = new System.Windows.Forms.Label();
            this.chk_locksub = new System.Windows.Forms.CheckBox();
            this.txt_subcatcode = new System.Windows.Forms.TextBox();
            this.txt_subcatname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_addSub = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_addCat = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
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
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(12, 455);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(788, 65);
            this.panel5.TabIndex = 77;
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
            this.panel4.Location = new System.Drawing.Point(9, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(771, 47);
            this.panel4.TabIndex = 65;
            // 
            // txt_Codex
            // 
            this.txt_Codex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Codex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Codex.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Codex.Location = new System.Drawing.Point(10, 22);
            this.txt_Codex.Name = "txt_Codex";
            this.txt_Codex.Size = new System.Drawing.Size(154, 22);
            this.txt_Codex.TabIndex = 3;
            this.txt_Codex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Codex_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chk_catlock);
            this.panel3.Controls.Add(this.lbl_new);
            this.panel3.Controls.Add(this.btn_addCat);
            this.panel3.Controls.Add(this.txt_Codex);
            this.panel3.Controls.Add(this.txt_Descr);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 330);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 119);
            this.panel3.TabIndex = 76;
            // 
            // chk_catlock
            // 
            this.chk_catlock.AutoSize = true;
            this.chk_catlock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_catlock.Location = new System.Drawing.Point(10, 92);
            this.chk_catlock.Name = "chk_catlock";
            this.chk_catlock.Size = new System.Drawing.Size(95, 18);
            this.chk_catlock.TabIndex = 62;
            this.chk_catlock.Text = "Lock Category";
            this.chk_catlock.UseVisualStyleBackColor = true;
            // 
            // lbl_new
            // 
            this.lbl_new.AutoSize = true;
            this.lbl_new.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_new.ForeColor = System.Drawing.Color.Red;
            this.lbl_new.Location = new System.Drawing.Point(170, 26);
            this.lbl_new.Name = "lbl_new";
            this.lbl_new.Size = new System.Drawing.Size(32, 14);
            this.lbl_new.TabIndex = 61;
            this.lbl_new.Text = "NEW";
            this.lbl_new.Visible = false;
            // 
            // txt_Descr
            // 
            this.txt_Descr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Descr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Descr.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Descr.Location = new System.Drawing.Point(10, 63);
            this.txt_Descr.Name = "txt_Descr";
            this.txt_Descr.Size = new System.Drawing.Size(260, 22);
            this.txt_Descr.TabIndex = 4;
            this.txt_Descr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Descr_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Category Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Category Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(391, 236);
            this.dataGridView1.TabIndex = 74;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // lbl_headerpaneltext
            // 
            this.lbl_headerpaneltext.AutoSize = true;
            this.lbl_headerpaneltext.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_headerpaneltext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(46)))), ((int)(((byte)(104)))));
            this.lbl_headerpaneltext.Location = new System.Drawing.Point(3, 2);
            this.lbl_headerpaneltext.Name = "lbl_headerpaneltext";
            this.lbl_headerpaneltext.Size = new System.Drawing.Size(118, 42);
            this.lbl_headerpaneltext.TabIndex = 0;
            this.lbl_headerpaneltext.Text = "BANKS";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(805, 45);
            this.pnl_header.TabIndex = 75;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(409, 88);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(391, 236);
            this.dataGridView2.TabIndex = 78;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowEnter);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_newsub);
            this.panel1.Controls.Add(this.chk_locksub);
            this.panel1.Controls.Add(this.btn_addSub);
            this.panel1.Controls.Add(this.txt_subcatcode);
            this.panel1.Controls.Add(this.txt_subcatname);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(409, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 119);
            this.panel1.TabIndex = 79;
            // 
            // lbl_newsub
            // 
            this.lbl_newsub.AutoSize = true;
            this.lbl_newsub.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_newsub.ForeColor = System.Drawing.Color.Red;
            this.lbl_newsub.Location = new System.Drawing.Point(170, 26);
            this.lbl_newsub.Name = "lbl_newsub";
            this.lbl_newsub.Size = new System.Drawing.Size(32, 14);
            this.lbl_newsub.TabIndex = 64;
            this.lbl_newsub.Text = "NEW";
            this.lbl_newsub.Visible = false;
            // 
            // chk_locksub
            // 
            this.chk_locksub.AutoSize = true;
            this.chk_locksub.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chk_locksub.Location = new System.Drawing.Point(10, 92);
            this.chk_locksub.Name = "chk_locksub";
            this.chk_locksub.Size = new System.Drawing.Size(113, 18);
            this.chk_locksub.TabIndex = 63;
            this.chk_locksub.Text = "Lock SubCategory";
            this.chk_locksub.UseVisualStyleBackColor = true;
            // 
            // txt_subcatcode
            // 
            this.txt_subcatcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_subcatcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subcatcode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subcatcode.Location = new System.Drawing.Point(10, 22);
            this.txt_subcatcode.Name = "txt_subcatcode";
            this.txt_subcatcode.Size = new System.Drawing.Size(154, 22);
            this.txt_subcatcode.TabIndex = 3;
            this.txt_subcatcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_subcatcode_KeyDown);
            // 
            // txt_subcatname
            // 
            this.txt_subcatname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_subcatname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_subcatname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subcatname.Location = new System.Drawing.Point(10, 63);
            this.txt_subcatname.Name = "txt_subcatname";
            this.txt_subcatname.Size = new System.Drawing.Size(260, 22);
            this.txt_subcatname.TabIndex = 4;
            this.txt_subcatname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_subcatname_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "SubCategory Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "SubCategory Name";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label21);
            this.panel7.Controls.Add(this.label6);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(11, 50);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(789, 35);
            this.panel7.TabIndex = 142;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(394, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 26);
            this.label21.TabIndex = 54;
            this.label21.Text = "SubCategories";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 26);
            this.label6.TabIndex = 51;
            this.label6.Text = "Categories";
            // 
            // btn_addSub
            // 
            this.btn_addSub.BackColor = System.Drawing.Color.White;
            this.btn_addSub.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addSub.ImageIndex = 6;
            this.btn_addSub.ImageList = this.imageList1;
            this.btn_addSub.Location = new System.Drawing.Point(292, 55);
            this.btn_addSub.Name = "btn_addSub";
            this.btn_addSub.Size = new System.Drawing.Size(91, 35);
            this.btn_addSub.TabIndex = 61;
            this.btn_addSub.Text = "     Save";
            this.btn_addSub.UseVisualStyleBackColor = false;
            this.btn_addSub.Click += new System.EventHandler(this.btn_addSub_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.White;
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
            this.btn_cancel.Visible = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.White;
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
            this.btn_new.Visible = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.ImageIndex = 2;
            this.btn_exit.ImageList = this.imageList1;
            this.btn_exit.Location = new System.Drawing.Point(677, 4);
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
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
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
            this.btn_print.Visible = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.White;
            this.btn_edit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.ImageIndex = 1;
            this.btn_edit.ImageList = this.imageList1;
            this.btn_edit.Location = new System.Drawing.Point(206, 4);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(91, 35);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.Text = "     Edit";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Visible = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.White;
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
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_addCat
            // 
            this.btn_addCat.BackColor = System.Drawing.Color.White;
            this.btn_addCat.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addCat.ImageIndex = 6;
            this.btn_addCat.ImageList = this.imageList1;
            this.btn_addCat.Location = new System.Drawing.Point(285, 54);
            this.btn_addCat.Name = "btn_addCat";
            this.btn_addCat.Size = new System.Drawing.Size(91, 35);
            this.btn_addCat.TabIndex = 60;
            this.btn_addCat.Text = "     Save";
            this.btn_addCat.UseVisualStyleBackColor = false;
            this.btn_addCat.Click += new System.EventHandler(this.btn_addCat_Click);
            // 
            // frm_categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 543);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_categories";
            this.Text = "frm_categories";
            this.Load += new System.EventHandler(this.frm_categories_Load);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_Codex;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_Descr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Button btn_addCat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_addSub;
        private System.Windows.Forms.TextBox txt_subcatcode;
        private System.Windows.Forms.TextBox txt_subcatname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_new;
        private System.Windows.Forms.CheckBox chk_catlock;
        private System.Windows.Forms.CheckBox chk_locksub;
        private System.Windows.Forms.Label lbl_newsub;
    }
}