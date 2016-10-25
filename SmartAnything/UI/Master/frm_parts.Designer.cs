namespace SmartAnything.UI
{
    partial class frm_parts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_parts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_UnitPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.txt_CostPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_SKU = new System.Windows.Forms.TextBox();
            this.txt_MfctCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_ModelNO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SerialNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SellingPrice = new System.Windows.Forms.TextBox();
            this.txt_IDX = new System.Windows.Forms.TextBox();
            this.txt_PartName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Color = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_UnitOfMeasure = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PartNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnl_header.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(477, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 37;
            this.label9.Text = "Selling Price";
            // 
            // txt_UnitPrice
            // 
            this.txt_UnitPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_UnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UnitPrice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UnitPrice.Location = new System.Drawing.Point(553, 37);
            this.txt_UnitPrice.Name = "txt_UnitPrice";
            this.txt_UnitPrice.Size = new System.Drawing.Size(120, 22);
            this.txt_UnitPrice.TabIndex = 27;
            this.txt_UnitPrice.Text = "0";
            this.txt_UnitPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_UnitPrice_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(489, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "Unit Price";
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(729, 45);
            this.pnl_header.TabIndex = 84;
            // 
            // lbl_headerpaneltext
            // 
            this.lbl_headerpaneltext.AutoSize = true;
            this.lbl_headerpaneltext.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_headerpaneltext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(68)))), ((int)(((byte)(123)))));
            this.lbl_headerpaneltext.Location = new System.Drawing.Point(4, 1);
            this.lbl_headerpaneltext.Name = "lbl_headerpaneltext";
            this.lbl_headerpaneltext.Size = new System.Drawing.Size(299, 42);
            this.lbl_headerpaneltext.TabIndex = 0;
            this.lbl_headerpaneltext.Text = "COMPANY PROFILE";
            // 
            // txt_CostPrice
            // 
            this.txt_CostPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_CostPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CostPrice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CostPrice.Location = new System.Drawing.Point(553, 10);
            this.txt_CostPrice.Name = "txt_CostPrice";
            this.txt_CostPrice.Size = new System.Drawing.Size(120, 22);
            this.txt_CostPrice.TabIndex = 24;
            this.txt_CostPrice.Text = "0";
            this.txt_CostPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CostPrice_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(489, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 14);
            this.label11.TabIndex = 26;
            this.label11.Text = "Cost Price";
            // 
            // txt_SKU
            // 
            this.txt_SKU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_SKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SKU.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SKU.Location = new System.Drawing.Point(81, 111);
            this.txt_SKU.Name = "txt_SKU";
            this.txt_SKU.Size = new System.Drawing.Size(154, 22);
            this.txt_SKU.TabIndex = 19;
            this.txt_SKU.Text = "NA";
            this.txt_SKU.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SKU_KeyDown);
            // 
            // txt_MfctCode
            // 
            this.txt_MfctCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_MfctCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MfctCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MfctCode.Location = new System.Drawing.Point(317, 60);
            this.txt_MfctCode.Name = "txt_MfctCode";
            this.txt_MfctCode.Size = new System.Drawing.Size(154, 22);
            this.txt_MfctCode.TabIndex = 20;
            this.txt_MfctCode.Text = "NA";
            this.txt_MfctCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_MfctCode_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(247, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 14);
            this.label12.TabIndex = 21;
            this.label12.Text = "Manufactur";
            // 
            // txt_ModelNO
            // 
            this.txt_ModelNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_ModelNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ModelNO.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ModelNO.Location = new System.Drawing.Point(81, 60);
            this.txt_ModelNO.Name = "txt_ModelNO";
            this.txt_ModelNO.Size = new System.Drawing.Size(154, 22);
            this.txt_ModelNO.TabIndex = 15;
            this.txt_ModelNO.Text = "NA";
            this.txt_ModelNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ModelNO_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "SKU No";
            // 
            // txt_SerialNo
            // 
            this.txt_SerialNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_SerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SerialNo.Location = new System.Drawing.Point(81, 86);
            this.txt_SerialNo.Name = "txt_SerialNo";
            this.txt_SerialNo.Size = new System.Drawing.Size(154, 22);
            this.txt_SerialNo.TabIndex = 12;
            this.txt_SerialNo.Text = "NA";
            this.txt_SerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SerialNo_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Serial";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Model";
            // 
            // txt_SellingPrice
            // 
            this.txt_SellingPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_SellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SellingPrice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SellingPrice.Location = new System.Drawing.Point(553, 65);
            this.txt_SellingPrice.Name = "txt_SellingPrice";
            this.txt_SellingPrice.Size = new System.Drawing.Size(120, 22);
            this.txt_SellingPrice.TabIndex = 8;
            this.txt_SellingPrice.Text = "0";
            this.txt_SellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SellingPrice_KeyDown);
            // 
            // txt_IDX
            // 
            this.txt_IDX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_IDX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IDX.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IDX.Location = new System.Drawing.Point(81, 10);
            this.txt_IDX.MaxLength = 15;
            this.txt_IDX.Name = "txt_IDX";
            this.txt_IDX.Size = new System.Drawing.Size(154, 22);
            this.txt_IDX.TabIndex = 3;
            this.txt_IDX.Text = "NA";
            this.txt_IDX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_IDX_KeyDown);
            // 
            // txt_PartName
            // 
            this.txt_PartName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_PartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PartName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PartName.Location = new System.Drawing.Point(81, 35);
            this.txt_PartName.Name = "txt_PartName";
            this.txt_PartName.Size = new System.Drawing.Size(390, 22);
            this.txt_PartName.TabIndex = 4;
            this.txt_PartName.Text = "NA";
            this.txt_PartName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PartName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Product ID";
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
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
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
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
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
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
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
            this.panel4.Location = new System.Drawing.Point(14, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(688, 47);
            this.panel4.TabIndex = 65;
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
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(9, 497);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(708, 65);
            this.panel5.TabIndex = 87;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(9, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(708, 288);
            this.dataGridView1.TabIndex = 85;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_Color);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_UnitOfMeasure);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_PartNo);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txt_UnitPrice);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txt_CostPrice);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txt_SKU);
            this.panel3.Controls.Add(this.txt_MfctCode);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txt_ModelNO);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txt_SerialNo);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txt_SellingPrice);
            this.panel3.Controls.Add(this.txt_IDX);
            this.panel3.Controls.Add(this.txt_PartName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(9, 345);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(708, 146);
            this.panel3.TabIndex = 86;
            // 
            // txt_Color
            // 
            this.txt_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Color.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Color.Location = new System.Drawing.Point(317, 110);
            this.txt_Color.Name = "txt_Color";
            this.txt_Color.Size = new System.Drawing.Size(154, 22);
            this.txt_Color.TabIndex = 50;
            this.txt_Color.Text = "NA";
            this.txt_Color.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Color_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(276, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 51;
            this.label5.Text = "Color";
            // 
            // txt_UnitOfMeasure
            // 
            this.txt_UnitOfMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_UnitOfMeasure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UnitOfMeasure.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UnitOfMeasure.Location = new System.Drawing.Point(317, 85);
            this.txt_UnitOfMeasure.Name = "txt_UnitOfMeasure";
            this.txt_UnitOfMeasure.Size = new System.Drawing.Size(154, 22);
            this.txt_UnitOfMeasure.TabIndex = 48;
            this.txt_UnitOfMeasure.Text = "PCS";
            this.txt_UnitOfMeasure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_UnitOfMeasure_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(276, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 14);
            this.label4.TabIndex = 49;
            this.label4.Text = "Unit";
            // 
            // txt_PartNo
            // 
            this.txt_PartNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_PartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PartNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PartNo.Location = new System.Drawing.Point(317, 10);
            this.txt_PartNo.MaxLength = 15;
            this.txt_PartNo.Name = "txt_PartNo";
            this.txt_PartNo.Size = new System.Drawing.Size(154, 22);
            this.txt_PartNo.TabIndex = 46;
            this.txt_PartNo.Text = "NA";
            this.txt_PartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PartNo_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(267, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 14);
            this.label16.TabIndex = 47;
            this.label16.Text = "Part No";
            // 
            // frm_parts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 592);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Name = "frm_parts";
            this.Text = "frm_parts";
            this.Load += new System.EventHandler(this.frm_parts_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_UnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.TextBox txt_CostPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_SKU;
        private System.Windows.Forms.TextBox txt_MfctCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_ModelNO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_SerialNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SellingPrice;
        private System.Windows.Forms.TextBox txt_IDX;
        private System.Windows.Forms.TextBox txt_PartName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_PartNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Color;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_UnitOfMeasure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}