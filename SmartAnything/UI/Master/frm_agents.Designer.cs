namespace SmartAnything.UI
{
    partial class frm_agents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_agents));
            this.txt_AccNo = new System.Windows.Forms.TextBox();
            this.txt_NICno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Fax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_TPOffice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Address3 = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.txt_Areaname = new System.Windows.Forms.TextBox();
            this.txt_AreaCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dte_to = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_docreated = new System.Windows.Forms.Label();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_PassportNo = new System.Windows.Forms.TextBox();
            this.txt_TPPersonal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Address1 = new System.Windows.Forms.TextBox();
            this.txt_Address2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AgentCode = new System.Windows.Forms.TextBox();
            this.txt_Namex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_AccNo
            // 
            this.txt_AccNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_AccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_AccNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccNo.Location = new System.Drawing.Point(110, 141);
            this.txt_AccNo.Name = "txt_AccNo";
            this.txt_AccNo.Size = new System.Drawing.Size(154, 22);
            this.txt_AccNo.TabIndex = 19;
            this.txt_AccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AccNo_KeyDown);
            // 
            // txt_NICno
            // 
            this.txt_NICno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_NICno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NICno.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NICno.Location = new System.Drawing.Point(110, 168);
            this.txt_NICno.Name = "txt_NICno";
            this.txt_NICno.Size = new System.Drawing.Size(154, 22);
            this.txt_NICno.TabIndex = 20;
            this.txt_NICno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_NICno_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(41, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 21;
            this.label12.Text = "Account No";
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(709, 221);
            this.dataGridView1.TabIndex = 85;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(63, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 14);
            this.label13.TabIndex = 22;
            this.label13.Text = "NIC No";
            // 
            // txt_Fax
            // 
            this.txt_Fax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Fax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Fax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Fax.Location = new System.Drawing.Point(453, 87);
            this.txt_Fax.Name = "txt_Fax";
            this.txt_Fax.Size = new System.Drawing.Size(202, 22);
            this.txt_Fax.TabIndex = 17;
            this.txt_Fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Fax_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(405, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 18;
            this.label9.Text = "Fax No";
            // 
            // txt_TPOffice
            // 
            this.txt_TPOffice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_TPOffice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TPOffice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TPOffice.Location = new System.Drawing.Point(453, 33);
            this.txt_TPOffice.Name = "txt_TPOffice";
            this.txt_TPOffice.Size = new System.Drawing.Size(202, 22);
            this.txt_TPOffice.TabIndex = 15;
            this.txt_TPOffice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TPOffice_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(390, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "Official TP";
            // 
            // txt_Address3
            // 
            this.txt_Address3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Address3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address3.Location = new System.Drawing.Point(110, 114);
            this.txt_Address3.Name = "txt_Address3";
            this.txt_Address3.Size = new System.Drawing.Size(236, 22);
            this.txt_Address3.TabIndex = 11;
            this.txt_Address3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Address3_KeyDown);
            // 
            // txt_Email
            // 
            this.txt_Email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Email.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.Location = new System.Drawing.Point(453, 60);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(202, 22);
            this.txt_Email.TabIndex = 12;
            this.txt_Email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Email_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Address Line 3";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(408, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "E-Mail";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Location = new System.Drawing.Point(12, 544);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(709, 65);
            this.panel5.TabIndex = 87;
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
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txt_remarks);
            this.panel3.Controls.Add(this.txt_Areaname);
            this.panel3.Controls.Add(this.txt_AreaCode);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.dte_to);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.lbl_docreated);
            this.panel3.Controls.Add(this.dte_from);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txt_PassportNo);
            this.panel3.Controls.Add(this.txt_TPPersonal);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txt_AccNo);
            this.panel3.Controls.Add(this.txt_NICno);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txt_Fax);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txt_TPOffice);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txt_Address3);
            this.panel3.Controls.Add(this.txt_Email);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txt_Address1);
            this.panel3.Controls.Add(this.txt_Address2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_AgentCode);
            this.panel3.Controls.Add(this.txt_Namex);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 277);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 261);
            this.panel3.TabIndex = 86;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(53, 226);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 14);
            this.label17.TabIndex = 75;
            this.label17.Text = "Remarks";
            // 
            // txt_remarks
            // 
            this.txt_remarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_remarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.Location = new System.Drawing.Point(110, 224);
            this.txt_remarks.Multiline = true;
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(545, 31);
            this.txt_remarks.TabIndex = 74;
            // 
            // txt_Areaname
            // 
            this.txt_Areaname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Areaname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Areaname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Areaname.Location = new System.Drawing.Point(270, 196);
            this.txt_Areaname.Name = "txt_Areaname";
            this.txt_Areaname.Size = new System.Drawing.Size(385, 22);
            this.txt_Areaname.TabIndex = 72;
            // 
            // txt_AreaCode
            // 
            this.txt_AreaCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_AreaCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_AreaCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AreaCode.Location = new System.Drawing.Point(110, 196);
            this.txt_AreaCode.Name = "txt_AreaCode";
            this.txt_AreaCode.Size = new System.Drawing.Size(154, 22);
            this.txt_AreaCode.TabIndex = 71;
            this.txt_AreaCode.TextChanged += new System.EventHandler(this.txt_AreaCode_TextChanged);
            this.txt_AreaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AreaCode_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(74, 198);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 14);
            this.label16.TabIndex = 70;
            this.label16.Text = "Area";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(447, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 19);
            this.label14.TabIndex = 69;
            // 
            // dte_to
            // 
            this.dte_to.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_to.Location = new System.Drawing.Point(453, 140);
            this.dte_to.Name = "dte_to";
            this.dte_to.Size = new System.Drawing.Size(100, 21);
            this.dte_to.TabIndex = 68;
            this.dte_to.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dte_to_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(398, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 14);
            this.label15.TabIndex = 67;
            this.label15.Text = "Date To";
            // 
            // lbl_docreated
            // 
            this.lbl_docreated.AutoSize = true;
            this.lbl_docreated.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_docreated.ForeColor = System.Drawing.Color.Red;
            this.lbl_docreated.Location = new System.Drawing.Point(449, 117);
            this.lbl_docreated.Name = "lbl_docreated";
            this.lbl_docreated.Size = new System.Drawing.Size(0, 19);
            this.lbl_docreated.TabIndex = 66;
            // 
            // dte_from
            // 
            this.dte_from.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dte_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dte_from.Location = new System.Drawing.Point(453, 115);
            this.dte_from.Name = "dte_from";
            this.dte_from.Size = new System.Drawing.Size(100, 21);
            this.dte_from.TabIndex = 65;
            this.dte_from.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dte_from_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(383, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 14);
            this.label11.TabIndex = 64;
            this.label11.Text = "Date From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(385, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 14);
            this.label10.TabIndex = 26;
            this.label10.Text = "Passport No";
            // 
            // txt_PassportNo
            // 
            this.txt_PassportNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_PassportNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PassportNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PassportNo.Location = new System.Drawing.Point(453, 168);
            this.txt_PassportNo.Name = "txt_PassportNo";
            this.txt_PassportNo.Size = new System.Drawing.Size(202, 22);
            this.txt_PassportNo.TabIndex = 25;
            this.txt_PassportNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PassportNo_KeyDown);
            // 
            // txt_TPPersonal
            // 
            this.txt_TPPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_TPPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TPPersonal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TPPersonal.Location = new System.Drawing.Point(453, 6);
            this.txt_TPPersonal.Name = "txt_TPPersonal";
            this.txt_TPPersonal.Size = new System.Drawing.Size(202, 22);
            this.txt_TPPersonal.TabIndex = 23;
            this.txt_TPPersonal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TPPersonal_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(383, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Personal TP";
            // 
            // txt_Address1
            // 
            this.txt_Address1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Address1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address1.Location = new System.Drawing.Point(110, 60);
            this.txt_Address1.Name = "txt_Address1";
            this.txt_Address1.Size = new System.Drawing.Size(236, 22);
            this.txt_Address1.TabIndex = 7;
            this.txt_Address1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Address1_KeyDown);
            // 
            // txt_Address2
            // 
            this.txt_Address2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Address2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address2.Location = new System.Drawing.Point(110, 87);
            this.txt_Address2.Name = "txt_Address2";
            this.txt_Address2.Size = new System.Drawing.Size(236, 22);
            this.txt_Address2.TabIndex = 8;
            this.txt_Address2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Address2_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Address Line 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Address Line 2";
            // 
            // txt_AgentCode
            // 
            this.txt_AgentCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_AgentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_AgentCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AgentCode.Location = new System.Drawing.Point(110, 6);
            this.txt_AgentCode.Name = "txt_AgentCode";
            this.txt_AgentCode.Size = new System.Drawing.Size(154, 22);
            this.txt_AgentCode.TabIndex = 3;
            this.txt_AgentCode.Text = "NA";
            this.txt_AgentCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AgentCode_KeyDown);
            // 
            // txt_Namex
            // 
            this.txt_Namex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(229)))), ((int)(((byte)(242)))));
            this.txt_Namex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Namex.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Namex.Location = new System.Drawing.Point(110, 33);
            this.txt_Namex.Name = "txt_Namex";
            this.txt_Namex.Size = new System.Drawing.Size(236, 22);
            this.txt_Namex.TabIndex = 4;
            this.txt_Namex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Namex_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Agent Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // frm_agents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 617);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel3);
            this.Name = "frm_agents";
            this.Text = "frm_agents";
            this.Load += new System.EventHandler(this.frm_agents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_AccNo;
        private System.Windows.Forms.TextBox txt_NICno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Fax;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.TextBox txt_TPOffice;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Address3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Address1;
        private System.Windows.Forms.TextBox txt_Address2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_AgentCode;
        private System.Windows.Forms.TextBox txt_Namex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TPPersonal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PassportNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dte_to;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_docreated;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.TextBox txt_Areaname;
        private System.Windows.Forms.TextBox txt_AreaCode;
        private System.Windows.Forms.Label label16;
    }
}