
using System.Drawing;

namespace movec
{
    partial class LogInPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInPage));
            this.login_panel = new System.Windows.Forms.Panel();
            this.not_receive_code_lbl = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.message_info_lbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.password_detector_lbl = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.email_detector_lbl = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.sign_up_lbl = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.sign_up_info_lbl = new System.Windows.Forms.Label();
            this.sign_up_button = new System.Windows.Forms.Button();
            this.password_panel = new System.Windows.Forms.Panel();
            this.password_text = new System.Windows.Forms.TextBox();
            this.email_panel = new System.Windows.Forms.Panel();
            this.email_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minimize_img = new System.Windows.Forms.PictureBox();
            this.close_img = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.login_panel.SuspendLayout();
            this.password_panel.SuspendLayout();
            this.email_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_img)).BeginInit();
            this.SuspendLayout();
            // 
            // login_panel
            // 
            this.login_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_panel.Controls.Add(this.not_receive_code_lbl);
            this.login_panel.Controls.Add(this.textBox6);
            this.login_panel.Controls.Add(this.textBox5);
            this.login_panel.Controls.Add(this.message_info_lbl);
            this.login_panel.Controls.Add(this.textBox1);
            this.login_panel.Controls.Add(this.password_detector_lbl);
            this.login_panel.Controls.Add(this.textBox4);
            this.login_panel.Controls.Add(this.email_detector_lbl);
            this.login_panel.Controls.Add(this.textBox2);
            this.login_panel.Controls.Add(this.sign_up_lbl);
            this.login_panel.Controls.Add(this.textBox3);
            this.login_panel.Controls.Add(this.sign_up_info_lbl);
            this.login_panel.Controls.Add(this.sign_up_button);
            this.login_panel.Controls.Add(this.password_panel);
            this.login_panel.Controls.Add(this.email_panel);
            this.login_panel.Controls.Add(this.label1);
            this.login_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_panel.ForeColor = System.Drawing.Color.White;
            this.login_panel.Location = new System.Drawing.Point(383, 31);
            this.login_panel.Margin = new System.Windows.Forms.Padding(2);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(559, 720);
            this.login_panel.TabIndex = 2;
            this.login_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LogInPage_MouseDown);
            this.login_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LogInPage_MouseMove);
            this.login_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LogInPage_MouseUp);
            // 
            // not_receive_code_lbl
            // 
            this.not_receive_code_lbl.AutoSize = true;
            this.not_receive_code_lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.not_receive_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.not_receive_code_lbl.ForeColor = System.Drawing.Color.Red;
            this.not_receive_code_lbl.Location = new System.Drawing.Point(60, 652);
            this.not_receive_code_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.not_receive_code_lbl.Name = "not_receive_code_lbl";
            this.not_receive_code_lbl.Size = new System.Drawing.Size(236, 29);
            this.not_receive_code_lbl.TabIndex = 15;
            this.not_receive_code_lbl.Text = "Didn\'t receive code ?";
            this.not_receive_code_lbl.Click += new System.EventHandler(this.not_receive_code_lbl_Click);
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(442, 440);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.MaxLength = 1;
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(40, 60);
            this.textBox6.TabIndex = 14;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(370, 440);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.MaxLength = 1;
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(40, 60);
            this.textBox5.TabIndex = 13;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // message_info_lbl
            // 
            this.message_info_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.message_info_lbl.BackColor = System.Drawing.Color.Transparent;
            this.message_info_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_info_lbl.ForeColor = System.Drawing.Color.Red;
            this.message_info_lbl.Location = new System.Drawing.Point(60, 590);
            this.message_info_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.message_info_lbl.Name = "message_info_lbl";
            this.message_info_lbl.Size = new System.Drawing.Size(436, 91);
            this.message_info_lbl.TabIndex = 8;
            this.message_info_lbl.Text = "Your password must contain 8 and 32 characters.";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(75, 440);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 1;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 60);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // password_detector_lbl
            // 
            this.password_detector_lbl.BackColor = System.Drawing.Color.Transparent;
            this.password_detector_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_detector_lbl.ForeColor = System.Drawing.Color.Red;
            this.password_detector_lbl.Location = new System.Drawing.Point(68, 302);
            this.password_detector_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.password_detector_lbl.Name = "password_detector_lbl";
            this.password_detector_lbl.Size = new System.Drawing.Size(413, 78);
            this.password_detector_lbl.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(296, 440);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.MaxLength = 1;
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 60);
            this.textBox4.TabIndex = 12;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // email_detector_lbl
            // 
            this.email_detector_lbl.AutoSize = true;
            this.email_detector_lbl.BackColor = System.Drawing.Color.Transparent;
            this.email_detector_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_detector_lbl.ForeColor = System.Drawing.Color.Red;
            this.email_detector_lbl.Location = new System.Drawing.Point(68, 198);
            this.email_detector_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.email_detector_lbl.Name = "email_detector_lbl";
            this.email_detector_lbl.Size = new System.Drawing.Size(0, 29);
            this.email_detector_lbl.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(148, 440);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.MaxLength = 1;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 60);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // sign_up_lbl
            // 
            this.sign_up_lbl.AutoSize = true;
            this.sign_up_lbl.BackColor = System.Drawing.Color.Transparent;
            this.sign_up_lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sign_up_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_up_lbl.ForeColor = System.Drawing.Color.White;
            this.sign_up_lbl.Location = new System.Drawing.Point(339, 509);
            this.sign_up_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sign_up_lbl.Name = "sign_up_lbl";
            this.sign_up_lbl.Size = new System.Drawing.Size(155, 29);
            this.sign_up_lbl.TabIndex = 5;
            this.sign_up_lbl.Text = "Sign Up Now";
            this.sign_up_lbl.Click += new System.EventHandler(this.sign_up_lbl_Click);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(222, 440);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.MaxLength = 1;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 60);
            this.textBox3.TabIndex = 11;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // sign_up_info_lbl
            // 
            this.sign_up_info_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sign_up_info_lbl.AutoSize = true;
            this.sign_up_info_lbl.BackColor = System.Drawing.Color.Transparent;
            this.sign_up_info_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_up_info_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.sign_up_info_lbl.Location = new System.Drawing.Point(60, 509);
            this.sign_up_info_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sign_up_info_lbl.Name = "sign_up_info_lbl";
            this.sign_up_info_lbl.Size = new System.Drawing.Size(287, 29);
            this.sign_up_info_lbl.TabIndex = 3;
            this.sign_up_info_lbl.Text = "Not a member of Movec ?";
            // 
            // sign_up_button
            // 
            this.sign_up_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sign_up_button.BackColor = System.Drawing.Color.Red;
            this.sign_up_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sign_up_button.FlatAppearance.BorderSize = 0;
            this.sign_up_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_up_button.Location = new System.Drawing.Point(60, 384);
            this.sign_up_button.Margin = new System.Windows.Forms.Padding(2);
            this.sign_up_button.Name = "sign_up_button";
            this.sign_up_button.Size = new System.Drawing.Size(436, 50);
            this.sign_up_button.TabIndex = 4;
            this.sign_up_button.Text = "Sign In";
            this.sign_up_button.UseVisualStyleBackColor = false;
            this.sign_up_button.Click += new System.EventHandler(this.sign_up_button_Click);
            // 
            // password_panel
            // 
            this.password_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password_panel.Controls.Add(this.password_text);
            this.password_panel.Location = new System.Drawing.Point(60, 240);
            this.password_panel.Margin = new System.Windows.Forms.Padding(2);
            this.password_panel.Name = "password_panel";
            this.password_panel.Size = new System.Drawing.Size(436, 60);
            this.password_panel.TabIndex = 3;
            // 
            // password_text
            // 
            this.password_text.BackColor = System.Drawing.Color.White;
            this.password_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.password_text.Location = new System.Drawing.Point(13, 14);
            this.password_text.Margin = new System.Windows.Forms.Padding(2);
            this.password_text.MaxLength = 32;
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(408, 32);
            this.password_text.TabIndex = 0;
            this.password_text.Text = "Password";
            this.password_text.TextChanged += new System.EventHandler(this.password_text_TextChanged);
            this.password_text.Enter += new System.EventHandler(this.password_text_Enter);
            this.password_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.email_text_KeyDown);
            this.password_text.Leave += new System.EventHandler(this.password_text_Leave);
            // 
            // email_panel
            // 
            this.email_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.email_panel.Controls.Add(this.email_text);
            this.email_panel.Location = new System.Drawing.Point(60, 134);
            this.email_panel.Margin = new System.Windows.Forms.Padding(2);
            this.email_panel.Name = "email_panel";
            this.email_panel.Size = new System.Drawing.Size(436, 60);
            this.email_panel.TabIndex = 2;
            // 
            // email_text
            // 
            this.email_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.email_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.email_text.Location = new System.Drawing.Point(13, 14);
            this.email_text.Margin = new System.Windows.Forms.Padding(2);
            this.email_text.MaxLength = 32;
            this.email_text.Name = "email_text";
            this.email_text.Size = new System.Drawing.Size(408, 32);
            this.email_text.TabIndex = 0;
            this.email_text.Text = "Email";
            this.email_text.TextChanged += new System.EventHandler(this.email_text_TextChanged);
            this.email_text.Enter += new System.EventHandler(this.email_text_Enter);
            this.email_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.email_text_KeyDown);
            this.email_text.Leave += new System.EventHandler(this.email_text_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(53, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sign In";
            // 
            // minimize_img
            // 
            this.minimize_img.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize_img.Location = new System.Drawing.Point(38, 12);
            this.minimize_img.Margin = new System.Windows.Forms.Padding(2);
            this.minimize_img.Name = "minimize_img";
            this.minimize_img.Size = new System.Drawing.Size(20, 20);
            this.minimize_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimize_img.TabIndex = 1;
            this.minimize_img.TabStop = false;
            this.minimize_img.Click += new System.EventHandler(this.minimize_img_Click);
            this.minimize_img.MouseLeave += new System.EventHandler(this.minimize_img_MouseLeave);
            this.minimize_img.MouseHover += new System.EventHandler(this.minimize_img_MouseHover);
            // 
            // close_img
            // 
            this.close_img.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_img.Location = new System.Drawing.Point(12, 12);
            this.close_img.Margin = new System.Windows.Forms.Padding(2);
            this.close_img.Name = "close_img";
            this.close_img.Size = new System.Drawing.Size(20, 20);
            this.close_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.close_img.TabIndex = 0;
            this.close_img.TabStop = false;
            this.close_img.Click += new System.EventHandler(this.close_img_Click);
            this.close_img.MouseLeave += new System.EventHandler(this.close_img_MouseLeave);
            this.close_img.MouseHover += new System.EventHandler(this.close_img_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LogInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.login_panel);
            this.Controls.Add(this.minimize_img);
            this.Controls.Add(this.close_img);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "LogInPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movec";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LogInPage_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LogInPage_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LogInPage_MouseUp);
            this.login_panel.ResumeLayout(false);
            this.login_panel.PerformLayout();
            this.password_panel.ResumeLayout(false);
            this.password_panel.PerformLayout();
            this.email_panel.ResumeLayout(false);
            this.email_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox close_img;
        private System.Windows.Forms.PictureBox minimize_img;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label email_detector_lbl;
        public System.Windows.Forms.Label password_detector_lbl;
        public System.Windows.Forms.Panel login_panel;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button sign_up_button;
        public System.Windows.Forms.Label sign_up_info_lbl;
        public System.Windows.Forms.Label sign_up_lbl;
        public System.Windows.Forms.Label message_info_lbl;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label not_receive_code_lbl;
        public System.Windows.Forms.TextBox email_text;
        public System.Windows.Forms.Panel email_panel;
        public System.Windows.Forms.Panel password_panel;
        public System.Windows.Forms.TextBox password_text;
    }
}

