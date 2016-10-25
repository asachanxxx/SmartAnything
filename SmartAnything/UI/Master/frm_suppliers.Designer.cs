namespace SmartAnything.UI
{
    partial class frm_suppliers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_suppliers));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_exit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_ContactPerson = new System.Windows.Forms.TextBox();
            this.txt_ContactPersonNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Fax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_TP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Address3 = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Address1 = new System.Windows.Forms.TextBox();
            this.txt_Address2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SupID = new System.Windows.Forms.TextBox();
            this.txt_suppName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(709, 236);
            this.dataGridView1.TabIndex = 81;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
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
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.pnl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_header.Controls.Add(this.lbl_headerpaneltext);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(730, 45);
            this.pnl_header.TabIndex = 80;
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
            this.panel4.Size = new System.Drawing.Size(688, 47);
            this.panel4.TabIndex = 65;
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
            this.panel5.Location = new System.Drawing.Point(12, 473);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(709, 65);
            this.panel5.TabIndex = 83;
            // 
            // txt_ContactPerson
            // 
            this.txt_ContactPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_ContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ContactPerson.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ContactPerson.Location = new System.Drawing.Point(110, 121);
            this.txt_ContactPerson.Name = "txt_ContactPerson";
            this.txt_ContactPerson.Size = new System.Drawing.Size(154, 21);
            this.txt_ContactPerson.TabIndex = 19;
            this.txt_ContactPerson.Text = "NA";
            this.txt_ContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ContactPerson_KeyDown);
            // 
            // txt_ContactPersonNo
            // 
            this.txt_ContactPersonNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_ContactPersonNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ContactPersonNo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ContactPersonNo.Location = new System.Drawing.Point(110, 144);
            this.txt_ContactPersonNo.Name = "txt_ContactPersonNo";
            this.txt_ContactPersonNo.Size = new System.Drawing.Size(154, 21);
            this.txt_ContactPersonNo.TabIndex = 20;
            this.txt_ContactPersonNo.Text = "NA";
            this.txt_ContactPersonNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ContactPersonNo_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 14);
            this.label12.TabIndex = 21;
            this.label12.Text = "Contact Person";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 14);
            this.label13.TabIndex = 22;
            this.label13.Text = "ContactPerson\'s No";
            // 
            // txt_Fax
            // 
            this.txt_Fax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Fax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Fax.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Fax.Location = new System.Drawing.Point(437, 145);
            this.txt_Fax.Name = "txt_Fax";
            this.txt_Fax.Size = new System.Drawing.Size(202, 21);
            this.txt_Fax.TabIndex = 17;
            this.txt_Fax.Text = "NA";
            this.txt_Fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Fax_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(389, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 18;
            this.label9.Text = "Fax No";
            // 
            // txt_TP
            // 
            this.txt_TP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_TP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TP.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TP.Location = new System.Drawing.Point(437, 122);
            this.txt_TP.Name = "txt_TP";
            this.txt_TP.Size = new System.Drawing.Size(202, 21);
            this.txt_TP.TabIndex = 15;
            this.txt_TP.Text = "NA";
            this.txt_TP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TP_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(374, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "Telephone";
            // 
            // txt_Address3
            // 
            this.txt_Address3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Address3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address3.Location = new System.Drawing.Point(110, 98);
            this.txt_Address3.Name = "txt_Address3";
            this.txt_Address3.Size = new System.Drawing.Size(236, 21);
            this.txt_Address3.TabIndex = 11;
            this.txt_Address3.Text = "NA";
            this.txt_Address3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Address3_KeyDown);
            // 
            // txt_Email
            // 
            this.txt_Email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Email.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.Location = new System.Drawing.Point(437, 99);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(202, 21);
            this.txt_Email.TabIndex = 12;
            this.txt_Email.Text = "NA";
            this.txt_Email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Email_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Address Line 3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(392, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "E-Mail";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_ContactPerson);
            this.panel3.Controls.Add(this.txt_ContactPersonNo);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txt_Fax);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txt_TP);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txt_Address3);
            this.panel3.Controls.Add(this.txt_Email);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txt_Address1);
            this.panel3.Controls.Add(this.txt_Address2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_SupID);
            this.panel3.Controls.Add(this.txt_suppName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 293);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 174);
            this.panel3.TabIndex = 82;
            // 
            // txt_Address1
            // 
            this.txt_Address1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Address1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address1.Location = new System.Drawing.Point(110, 52);
            this.txt_Address1.Name = "txt_Address1";
            this.txt_Address1.Size = new System.Drawing.Size(236, 21);
            this.txt_Address1.TabIndex = 7;
            this.txt_Address1.Text = "NA";
            this.txt_Address1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Address1_KeyDown);
            // 
            // txt_Address2
            // 
            this.txt_Address2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Address2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address2.Location = new System.Drawing.Point(110, 75);
            this.txt_Address2.Name = "txt_Address2";
            this.txt_Address2.Size = new System.Drawing.Size(236, 21);
            this.txt_Address2.TabIndex = 8;
            this.txt_Address2.Text = "NA";
            this.txt_Address2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Address2_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Address Line 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Address Line 2";
            // 
            // txt_SupID
            // 
            this.txt_SupID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_SupID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SupID.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SupID.Location = new System.Drawing.Point(110, 6);
            this.txt_SupID.Name = "txt_SupID";
            this.txt_SupID.Size = new System.Drawing.Size(154, 21);
            this.txt_SupID.TabIndex = 3;
            this.txt_SupID.Text = "NA";
            this.txt_SupID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SupID_KeyDown);
            // 
            // txt_suppName
            // 
            this.txt_suppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_suppName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_suppName.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_suppName.Location = new System.Drawing.Point(110, 29);
            this.txt_suppName.Name = "txt_suppName";
            this.txt_suppName.Size = new System.Drawing.Size(529, 21);
            this.txt_suppName.TabIndex = 4;
            this.txt_suppName.Text = "NA";
            this.txt_suppName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_suppName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Supplier Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 553);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Name = "frm_suppliers";
            this.Text = "frm_suppliers";
            this.Load += new System.EventHandler(this.frm_suppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_ContactPerson;
        private System.Windows.Forms.TextBox txt_ContactPersonNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Fax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Address3;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_Address1;
        private System.Windows.Forms.TextBox txt_Address2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SupID;
        private System.Windows.Forms.TextBox txt_suppName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}