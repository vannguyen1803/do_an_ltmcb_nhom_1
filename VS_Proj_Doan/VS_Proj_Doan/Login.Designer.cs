namespace VS_Proj_Doan
{
    partial class Login
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
            tb_usrname = new TextBox();
            tb_pass = new TextBox();
            btn_login = new Button();
            label3 = new Label();
            button1 = new Button();
            btn_forget_pass = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(29, 72);
            label1.Name = "label1";
            label1.Size = new Size(287, 54);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(91, 150);
            label2.Name = "label2";
            label2.Size = new Size(190, 54);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // tb_usrname
            // 
            tb_usrname.Location = new Point(330, 72);
            tb_usrname.Name = "tb_usrname";
            tb_usrname.Size = new Size(391, 61);
            tb_usrname.TabIndex = 2;
            // 
            // tb_pass
            // 
            tb_pass.Location = new Point(330, 146);
            tb_pass.Name = "tb_pass";
            tb_pass.Size = new Size(391, 61);
            tb_pass.TabIndex = 3;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(330, 213);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(260, 46);
            btn_login.TabIndex = 4;
            btn_login.Text = "Đăng nhập";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(29, 265);
            label3.Name = "label3";
            label3.Size = new Size(637, 45);
            label3.TabIndex = 5;
            label3.Text = " Nếu chưa có tài khoản, hãy đăng ký tại đây";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F);
            button1.Location = new Point(672, 268);
            button1.Name = "button1";
            button1.Size = new Size(184, 47);
            button1.TabIndex = 6;
            button1.Text = "Đăng ký tài khoản";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btn_forget_pass
            // 
            btn_forget_pass.Font = new Font("Segoe UI", 11F);
            btn_forget_pass.Location = new Point(330, 320);
            btn_forget_pass.Name = "btn_forget_pass";
            btn_forget_pass.Size = new Size(259, 55);
            btn_forget_pass.TabIndex = 7;
            btn_forget_pass.Text = "quên mật khẩu";
            btn_forget_pass.UseVisualStyleBackColor = true;
            btn_forget_pass.Click += btn_forget_pass_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(63, 316);
            label4.Name = "label4";
            label4.Size = new Size(261, 41);
            label4.TabIndex = 8;
            label4.Text = "Quên mật khẩu???";
            // 
            // Login
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.theme;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(927, 516);
            Controls.Add(label4);
            Controls.Add(btn_forget_pass);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(btn_login);
            Controls.Add(tb_pass);
            Controls.Add(tb_usrname);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_usrname;
        private TextBox tb_pass;
        private Button btn_login;
        private Label label3;
        private Button button1;
        private Button btn_forget_pass;
        private Label label4;
    }
}