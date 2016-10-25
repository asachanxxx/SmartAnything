
using smartOffice.Classes;
using smartOffice_BL;
//using smartOffice.Classes;
using System.Windows.Forms;

namespace SmartAnything
{
    partial class frmU_Login
    {
        //CommonFont objCF;

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
            //DialogResult res = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (res == DialogResult.Yes)
            //{
            //    if (disposing && (components != null))
            //    {
            //        components.Dispose();
            //    }
            //    base.Dispose(disposing);
            //    //Application.Exit();
            //    //return;
            //}
            //if (res == DialogResult.No)
            //{
            //    txtPassword.Text = "";
            //    txtUserId.Text = "";
            //    txtUserId.Focus();
            //}


            //return;
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmU_Login));
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblErrormsg1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_loca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.ForeColor = System.Drawing.Color.White;
            this.lblUserId.Location = new System.Drawing.Point(24, 26);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(68, 15);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(33, 56);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 15);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.White;
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.ForeColor = System.Drawing.Color.Black;
            this.txtUserId.Location = new System.Drawing.Point(102, 24);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(206, 23);
            this.txtUserId.TabIndex = 2;
            this.txtUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserId_KeyDown);
            this.txtUserId.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserId_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(102, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(206, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(102, 111);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(206, 29);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "LOG IN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Validating += new System.ComponentModel.CancelEventHandler(this.btnLogin_Validating);
            // 
            // lblErrormsg1
            // 
            this.lblErrormsg1.AutoSize = true;
            this.lblErrormsg1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrormsg1.ForeColor = System.Drawing.Color.Red;
            this.lblErrormsg1.Location = new System.Drawing.Point(11, 150);
            this.lblErrormsg1.Name = "lblErrormsg1";
            this.lblErrormsg1.Size = new System.Drawing.Size(0, 14);
            this.lblErrormsg1.TabIndex = 8;
            this.lblErrormsg1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.panel1.Controls.Add(this.cmb_loca);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUserId);
            this.panel1.Controls.Add(this.lblErrormsg1);
            this.panel1.Controls.Add(this.lblUserId);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 187);
            this.panel1.TabIndex = 9;
            // 
            // cmb_loca
            // 
            this.cmb_loca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_loca.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmb_loca.FormattingEnabled = true;
            this.cmb_loca.Location = new System.Drawing.Point(102, 81);
            this.cmb_loca.Name = "cmb_loca";
            this.cmb_loca.Size = new System.Drawing.Size(206, 23);
            this.cmb_loca.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(89, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frmU_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 424);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmU_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartDistribution Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmU_Login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmU_Login_FormClosed);
            this.Load += new System.EventHandler(this.frmU_Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmU_Login_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private PictureBox pictureBox1;
        private Label lblErrormsg1;
        private Panel panel1;
        private ComboBox cmb_loca;
        private Label label1;
    }
}