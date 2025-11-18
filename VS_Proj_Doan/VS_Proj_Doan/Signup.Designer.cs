namespace VS_Proj_Doan
{
    partial class Signup
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            btn_signup = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(99, 146);
            label1.Name = "label1";
            label1.Size = new Size(99, 28);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(103, 218);
            label2.Name = "label2";
            label2.Size = new Size(93, 28);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(99, 301);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 2;
            label3.Text = "Full name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(125, 390);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(271, 146);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(406, 34);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(271, 218);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(406, 34);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(271, 301);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(406, 34);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 12F);
            textBox4.Location = new Point(271, 390);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(406, 34);
            textBox4.TabIndex = 9;
            // 
            // btn_signup
            // 
            btn_signup.BackColor = Color.LightCyan;
            btn_signup.CausesValidation = false;
            btn_signup.Font = new Font("Segoe UI", 14F);
            btn_signup.Location = new Point(232, 449);
            btn_signup.Name = "btn_signup";
            btn_signup.Size = new Size(173, 53);
            btn_signup.TabIndex = 10;
            btn_signup.Text = "Đăng ký ";
            btn_signup.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F);
            label5.Location = new Point(189, 54);
            label5.Name = "label5";
            label5.Size = new Size(303, 41);
            label5.TabIndex = 11;
            label5.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.theme;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(809, 567);
            Controls.Add(label5);
            Controls.Add(btn_signup);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Signup";
            Text = "Signup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button btn_signup;
        private Label label5;
    }
}