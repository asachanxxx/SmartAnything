namespace SmartAnything
{
    partial class testform
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_amt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cost = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_selling = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_pices = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_items = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(810, 233);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_amt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_qty);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_cost);
            this.panel1.Controls.Add(this.txt_code);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(22, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 66);
            this.panel1.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(12, 46);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(19, 14);
            this.lbl_name.TabIndex = 10;
            this.lbl_name.Text = "....";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(640, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Amount";
            // 
            // txt_amt
            // 
            this.txt_amt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_amt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_amt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_amt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_amt.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amt.ForeColor = System.Drawing.Color.White;
            this.txt_amt.Location = new System.Drawing.Point(643, 23);
            this.txt_amt.Name = "txt_amt";
            this.txt_amt.ReadOnly = true;
            this.txt_amt.Size = new System.Drawing.Size(151, 22);
            this.txt_amt.TabIndex = 8;
            this.txt_amt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_amt_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(534, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quntity";
            // 
            // txt_qty
            // 
            this.txt_qty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_qty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_qty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty.ForeColor = System.Drawing.Color.White;
            this.txt_qty.Location = new System.Drawing.Point(537, 23);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(100, 22);
            this.txt_qty.TabIndex = 6;
            this.txt_qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_qty_KeyDown);
            this.txt_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_qty_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(412, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Selling Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cost Price";
            // 
            // txt_cost
            // 
            this.txt_cost.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_cost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_cost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cost.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cost.ForeColor = System.Drawing.Color.White;
            this.txt_cost.Location = new System.Drawing.Point(293, 23);
            this.txt_cost.Name = "txt_cost";
            this.txt_cost.ReadOnly = true;
            this.txt_cost.Size = new System.Drawing.Size(116, 22);
            this.txt_cost.TabIndex = 2;
            // 
            // txt_code
            // 
            this.txt_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_code.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.ForeColor = System.Drawing.Color.White;
            this.txt_code.Location = new System.Drawing.Point(15, 23);
            this.txt_code.Name = "txt_code";
            this.txt_code.ReadOnly = true;
            this.txt_code.Size = new System.Drawing.Size(272, 22);
            this.txt_code.TabIndex = 1;
            this.txt_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_code_KeyDown);
            this.txt_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_code_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Code";
            // 
            // txt_selling
            // 
            this.txt_selling.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_selling.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_selling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(157)))), ((int)(((byte)(220)))));
            this.txt_selling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_selling.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_selling.ForeColor = System.Drawing.Color.White;
            this.txt_selling.Location = new System.Drawing.Point(449, 51);
            this.txt_selling.Name = "txt_selling";
            this.txt_selling.Size = new System.Drawing.Size(116, 22);
            this.txt_selling.TabIndex = 4;
            this.txt_selling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_selling_KeyDown);
            this.txt_selling.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_selling_KeyPress);
            this.txt_selling.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_selling_KeyUp);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(861, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(173, 134);
            this.listBox1.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txt_total
            // 
            this.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_total.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(711, 468);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(121, 23);
            this.txt_total.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(614, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Total Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(628, 418);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "No of Pices";
            // 
            // txt_pices
            // 
            this.txt_pices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pices.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pices.Location = new System.Drawing.Point(711, 416);
            this.txt_pices.Name = "txt_pices";
            this.txt_pices.Size = new System.Drawing.Size(121, 23);
            this.txt_pices.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(625, 444);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "No of items";
            // 
            // txt_items
            // 
            this.txt_items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_items.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_items.Location = new System.Drawing.Point(711, 442);
            this.txt_items.Name = "txt_items";
            this.txt_items.Size = new System.Drawing.Size(121, 23);
            this.txt_items.TabIndex = 7;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 571);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_items);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_pices);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.txt_selling);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "testform";
            this.Text = "testform";
            this.Load += new System.EventHandler(this.testform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_amt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_selling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cost;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_items;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_pices;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button1;
    }
}