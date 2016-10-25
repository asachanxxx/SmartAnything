namespace SmartAnything.UI
{
    partial class frm_creditnoteApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_creditnoteApproval));
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.txt_Customer_name = new System.Windows.Forms.TextBox();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_manualno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_locationId_name = new System.Windows.Forms.TextBox();
            this.txt_Locacode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_DocNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.lbl_creditnotetype = new System.Windows.Forms.Label();
            this.txt_CNtypes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.pnl_header.Size = new System.Drawing.Size(882, 45);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Location = new System.Drawing.Point(447, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(408, 47);
            this.panel4.TabIndex = 147;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(11, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 136;
            this.label13.Text = "Remarks";
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.BackColor = System.Drawing.Color.White;
            this.txt_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Remarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Remarks.Location = new System.Drawing.Point(68, 73);
            this.txt_Remarks.Multiline = true;
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.ReadOnly = true;
            this.txt_Remarks.Size = new System.Drawing.Size(283, 48);
            this.txt_Remarks.TabIndex = 135;
            // 
            // txt_Customer_name
            // 
            this.txt_Customer_name.BackColor = System.Drawing.Color.White;
            this.txt_Customer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Customer_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Customer_name.Location = new System.Drawing.Point(162, 49);
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
            this.txt_Customer.Location = new System.Drawing.Point(68, 49);
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.ReadOnly = true;
            this.txt_Customer.Size = new System.Drawing.Size(88, 21);
            this.txt_Customer.TabIndex = 132;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbl_creditnotetype);
            this.panel2.Controls.Add(this.txt_CNtypes);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txt_manualno);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txt_Customer_name);
            this.panel2.Controls.Add(this.txt_Customer);
            this.panel2.Controls.Add(this.txt_Remarks);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_locationId_name);
            this.panel2.Controls.Add(this.txt_Locacode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_DocNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(334, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 128);
            this.panel2.TabIndex = 156;
            // 
            // txt_manualno
            // 
            this.txt_manualno.BackColor = System.Drawing.Color.White;
            this.txt_manualno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_manualno.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_manualno.Location = new System.Drawing.Point(279, 3);
            this.txt_manualno.Name = "txt_manualno";
            this.txt_manualno.ReadOnly = true;
            this.txt_manualno.Size = new System.Drawing.Size(128, 21);
            this.txt_manualno.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(212, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 138;
            this.label1.Text = "Manual No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 52);
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
            this.txt_locationId_name.Location = new System.Drawing.Point(162, 26);
            this.txt_locationId_name.Name = "txt_locationId_name";
            this.txt_locationId_name.ReadOnly = true;
            this.txt_locationId_name.Size = new System.Drawing.Size(148, 21);
            this.txt_locationId_name.TabIndex = 131;
            // 
            // txt_Locacode
            // 
            this.txt_Locacode.BackColor = System.Drawing.Color.White;
            this.txt_Locacode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Locacode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Locacode.Location = new System.Drawing.Point(68, 26);
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
            this.label4.Location = new System.Drawing.Point(14, 28);
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
            this.txt_DocNo.Location = new System.Drawing.Point(68, 3);
            this.txt_DocNo.Name = "txt_DocNo";
            this.txt_DocNo.ReadOnly = true;
            this.txt_DocNo.Size = new System.Drawing.Size(128, 21);
            this.txt_DocNo.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 128;
            this.label2.Text = "Invoice No";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(316, 335);
            this.dataGridView1.TabIndex = 155;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 56);
            this.panel1.TabIndex = 157;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(334, 185);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(536, 201);
            this.dataGridView2.TabIndex = 158;
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
            this.btn_edit.Image = global::SmartAnything.Properties.Resources.Accept;
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.Location = new System.Drawing.Point(208, 9);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(91, 35);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.Text = "        Approve";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // lbl_creditnotetype
            // 
            this.lbl_creditnotetype.AutoSize = true;
            this.lbl_creditnotetype.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_creditnotetype.ForeColor = System.Drawing.Color.Black;
            this.lbl_creditnotetype.Location = new System.Drawing.Point(357, 73);
            this.lbl_creditnotetype.Name = "lbl_creditnotetype";
            this.lbl_creditnotetype.Size = new System.Drawing.Size(19, 14);
            this.lbl_creditnotetype.TabIndex = 141;
            this.lbl_creditnotetype.Text = "<>";
            // 
            // txt_CNtypes
            // 
            this.txt_CNtypes.BackColor = System.Drawing.Color.White;
            this.txt_CNtypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CNtypes.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CNtypes.Location = new System.Drawing.Point(357, 49);
            this.txt_CNtypes.Name = "txt_CNtypes";
            this.txt_CNtypes.Size = new System.Drawing.Size(100, 21);
            this.txt_CNtypes.TabIndex = 140;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(354, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 14);
            this.label7.TabIndex = 139;
            this.label7.Text = "Customer Wish";
            // 
            // frm_creditnoteApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 460);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_creditnoteApproval";
            this.Text = "frm_creditnoteApproval";
            this.Load += new System.EventHandler(this.frm_creditnoteApproval_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.TextBox txt_Customer_name;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_locationId_name;
        private System.Windows.Forms.TextBox txt_Locacode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_DocNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txt_manualno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_creditnotetype;
        private System.Windows.Forms.TextBox txt_CNtypes;
        private System.Windows.Forms.Label label7;
    }
}