namespace SmartAnything.UI
{
    partial class frm_deliverytracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_deliverytracking));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Order Form Approved"}, 2, System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Invoice Created"}, 2, System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Invoice Approved"}, 2, System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Delivery Order Created", 2);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Delivery Order Approved", 2);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Delivery Order Audited", 2);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Packing List Created", "--RefreshTooltip.png");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Dispatched", 2);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("HandedOver", 2);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Completed", 2);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lbl_headerpaneltext = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_process = new System.Windows.Forms.Button();
            this.btn_confirmdelivery = new System.Windows.Forms.Button();
            this.btn_hanoverdo = new System.Windows.Forms.Button();
            this.btn_dispatchdo = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Lorry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Agent_name = new System.Windows.Forms.TextBox();
            this.txt_Agent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_cremarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_header.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.pnl_header.Size = new System.Drawing.Size(910, 45);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(12, 493);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 46);
            this.panel2.TabIndex = 153;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_exit);
            this.panel4.Controls.Add(this.btn_process);
            this.panel4.Location = new System.Drawing.Point(17, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(863, 36);
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
            this.btn_exit.Location = new System.Drawing.Point(769, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(91, 33);
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
            // btn_process
            // 
            this.btn_process.BackColor = System.Drawing.Color.White;
            this.btn_process.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_process.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_process.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_process.Location = new System.Drawing.Point(663, 6);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(88, 27);
            this.btn_process.TabIndex = 60;
            this.btn_process.Text = "Process DO";
            this.btn_process.UseVisualStyleBackColor = false;
            this.btn_process.Visible = false;
            this.btn_process.Click += new System.EventHandler(this.btn_inscomplete_Click);
            // 
            // btn_confirmdelivery
            // 
            this.btn_confirmdelivery.BackColor = System.Drawing.Color.White;
            this.btn_confirmdelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirmdelivery.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirmdelivery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_confirmdelivery.Location = new System.Drawing.Point(256, 63);
            this.btn_confirmdelivery.Name = "btn_confirmdelivery";
            this.btn_confirmdelivery.Size = new System.Drawing.Size(97, 27);
            this.btn_confirmdelivery.TabIndex = 66;
            this.btn_confirmdelivery.Text = "Complete";
            this.btn_confirmdelivery.UseVisualStyleBackColor = false;
            this.btn_confirmdelivery.Click += new System.EventHandler(this.btn_confirmdelivery_Click);
            // 
            // btn_hanoverdo
            // 
            this.btn_hanoverdo.BackColor = System.Drawing.Color.White;
            this.btn_hanoverdo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hanoverdo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hanoverdo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hanoverdo.Location = new System.Drawing.Point(257, 63);
            this.btn_hanoverdo.Name = "btn_hanoverdo";
            this.btn_hanoverdo.Size = new System.Drawing.Size(96, 27);
            this.btn_hanoverdo.TabIndex = 65;
            this.btn_hanoverdo.Text = "HandedOver ";
            this.btn_hanoverdo.UseVisualStyleBackColor = false;
            this.btn_hanoverdo.Click += new System.EventHandler(this.btn_hanoverdo_Click);
            // 
            // btn_dispatchdo
            // 
            this.btn_dispatchdo.BackColor = System.Drawing.Color.White;
            this.btn_dispatchdo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dispatchdo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dispatchdo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dispatchdo.Location = new System.Drawing.Point(947, 311);
            this.btn_dispatchdo.Name = "btn_dispatchdo";
            this.btn_dispatchdo.Size = new System.Drawing.Size(95, 27);
            this.btn_dispatchdo.TabIndex = 64;
            this.btn_dispatchdo.Text = "Dispatch ";
            this.btn_dispatchdo.UseVisualStyleBackColor = false;
            this.btn_dispatchdo.Visible = false;
            this.btn_dispatchdo.Click += new System.EventHandler(this.btn_dispatchdo_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 51);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(887, 242);
            this.dataGridView2.TabIndex = 155;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // listView1
            // 
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.listView1.LargeImageList = this.imageList2;
            this.listView1.Location = new System.Drawing.Point(12, 299);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(887, 82);
            this.listView1.SmallImageList = this.imageList2;
            this.listView1.TabIndex = 161;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Actions-window-close-icon.png");
            this.imageList2.Images.SetKeyName(1, "Correct.ico");
            this.imageList2.Images.SetKeyName(2, "--RefreshTooltip.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt_Lorry);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_Agent_name);
            this.panel1.Controls.Add(this.txt_Agent);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_hanoverdo);
            this.panel1.Location = new System.Drawing.Point(158, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 100);
            this.panel1.TabIndex = 162;
            // 
            // txt_Lorry
            // 
            this.txt_Lorry.BackColor = System.Drawing.Color.White;
            this.txt_Lorry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Lorry.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Lorry.Location = new System.Drawing.Point(55, 34);
            this.txt_Lorry.Name = "txt_Lorry";
            this.txt_Lorry.Size = new System.Drawing.Size(298, 21);
            this.txt_Lorry.TabIndex = 77;
            this.txt_Lorry.TextChanged += new System.EventHandler(this.txt_Lorry_TextChanged);
            this.txt_Lorry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Lorry_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 78;
            this.label5.Text = "Vehicle";
            // 
            // txt_Agent_name
            // 
            this.txt_Agent_name.BackColor = System.Drawing.Color.White;
            this.txt_Agent_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Agent_name.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Agent_name.Location = new System.Drawing.Point(161, 7);
            this.txt_Agent_name.Name = "txt_Agent_name";
            this.txt_Agent_name.ReadOnly = true;
            this.txt_Agent_name.Size = new System.Drawing.Size(192, 21);
            this.txt_Agent_name.TabIndex = 68;
            // 
            // txt_Agent
            // 
            this.txt_Agent.BackColor = System.Drawing.Color.White;
            this.txt_Agent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Agent.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Agent.Location = new System.Drawing.Point(55, 7);
            this.txt_Agent.Name = "txt_Agent";
            this.txt_Agent.Size = new System.Drawing.Size(100, 21);
            this.txt_Agent.TabIndex = 66;
            this.txt_Agent.TextChanged += new System.EventHandler(this.txt_Agent_TextChanged);
            this.txt_Agent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Agent_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 14);
            this.label6.TabIndex = 67;
            this.label6.Text = "Agent";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_confirmdelivery);
            this.panel3.Controls.Add(this.txt_cremarks);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(531, 387);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(367, 100);
            this.panel3.TabIndex = 163;
            // 
            // txt_cremarks
            // 
            this.txt_cremarks.BackColor = System.Drawing.Color.White;
            this.txt_cremarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cremarks.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cremarks.Location = new System.Drawing.Point(70, 7);
            this.txt_cremarks.Multiline = true;
            this.txt_cremarks.Name = "txt_cremarks";
            this.txt_cremarks.Size = new System.Drawing.Size(283, 50);
            this.txt_cremarks.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 67;
            this.label2.Text = "Remarks";
            // 
            // frm_deliverytracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 551);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btn_dispatchdo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_header);
            this.Name = "frm_deliverytracking";
            this.Text = "frm_deliverytracking";
            this.Load += new System.EventHandler(this.frm_deliverytracking_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lbl_headerpaneltext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_confirmdelivery;
        private System.Windows.Forms.Button btn_hanoverdo;
        private System.Windows.Forms.Button btn_dispatchdo;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Agent_name;
        private System.Windows.Forms.TextBox txt_Agent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_cremarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Lorry;
        private System.Windows.Forms.Label label5;
    }
}