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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 72);
            label1.Name = "label1";
            label1.Size = new Size(180, 35);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 150);
            label2.Name = "label2";
            label2.Size = new Size(118, 35);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // tb_usrname
            // 
            tb_usrname.Location = new Point(215, 66);
            tb_usrname.Name = "tb_usrname";
            tb_usrname.Size = new Size(391, 41);
            tb_usrname.TabIndex = 2;
            // 
            // tb_pass
            // 
            tb_pass.Location = new Point(215, 147);
            tb_pass.Name = "tb_pass";
            tb_pass.Size = new Size(391, 41);
            tb_pass.TabIndex = 3;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(215, 205);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(172, 46);
            btn_login.TabIndex = 4;
            btn_login.Text = "Đăng nhập";
            btn_login.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(29, 265);
            label3.Name = "label3";
            label3.Size = new Size(391, 28);
            label3.TabIndex = 5;
            label3.Text = " Nếu chưa có tài khoản, hãy đăng ký tại đây";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.Font = new Font("Segoe UI", 9F);
            button1.Location = new Point(426, 265);
            button1.Name = "button1";
            button1.Size = new Size(165, 29);
            button1.TabIndex = 6;
            button1.Text = "Đăng ký tài khoản";
            button1.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
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
    }
}