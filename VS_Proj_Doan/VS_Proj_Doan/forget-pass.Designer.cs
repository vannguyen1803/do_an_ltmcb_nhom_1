namespace VS_Proj_Doan
{
    partial class forget_pass
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
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(116, 141);
            label1.Name = "label1";
            label1.Size = new Size(145, 30);
            label1.TabIndex = 0;
            label1.Text = "Email của bạn";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(309, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 36);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(514, 135);
            button1.Name = "button1";
            button1.Size = new Size(189, 39);
            button1.TabIndex = 2;
            button1.Text = "Gửi mã xác nhận";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 13F);
            textBox2.Location = new Point(309, 208);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 36);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 13F);
            textBox3.Location = new Point(309, 283);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 36);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 13F);
            textBox4.Location = new Point(309, 353);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 36);
            textBox4.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(127, 211);
            label2.Name = "label2";
            label2.Size = new Size(134, 30);
            label2.TabIndex = 6;
            label2.Text = "Mã xác nhận";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(115, 286);
            label3.Name = "label3";
            label3.Size = new Size(146, 30);
            label3.TabIndex = 7;
            label3.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(66, 356);
            label4.Name = "label4";
            label4.Size = new Size(195, 30);
            label4.TabIndex = 8;
            label4.Text = "Xác nhận mật khẩu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(169, 46);
            label5.Name = "label5";
            label5.Size = new Size(168, 30);
            label5.TabIndex = 9;
            label5.Text = "Đặt lại mật khẩu";
            // 
            // forget_pass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "forget_pass";
            Text = "forget_pass";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}