namespace Project_doan
{
    partial class Home
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
            this.pn_menu = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_cal = new System.Windows.Forms.Button();
            this.pn_header = new System.Windows.Forms.Panel();
            this.pn_content = new System.Windows.Forms.Panel();
            this.pn_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_menu
            // 
            this.pn_menu.Controls.Add(this.button6);
            this.pn_menu.Controls.Add(this.button5);
            this.pn_menu.Controls.Add(this.button4);
            this.pn_menu.Controls.Add(this.button3);
            this.pn_menu.Controls.Add(this.button2);
            this.pn_menu.Controls.Add(this.btn_cal);
            this.pn_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_menu.Location = new System.Drawing.Point(0, 0);
            this.pn_menu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_menu.Name = "pn_menu";
            this.pn_menu.Size = new System.Drawing.Size(307, 890);
            this.pn_menu.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(135, 524);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 34);
            this.button6.TabIndex = 5;
            this.button6.Text = "Tài khoản";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(85, 424);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 34);
            this.button5.TabIndex = 4;
            this.button5.Text = "Pomodoro";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(98, 360);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 38);
            this.button4.TabIndex = 3;
            this.button4.Text = "Đồng hồ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(98, 288);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ghi chú";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 207);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Mục tiêu";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_cal
            // 
            this.btn_cal.Location = new System.Drawing.Point(85, 128);
            this.btn_cal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cal.Name = "btn_cal";
            this.btn_cal.Size = new System.Drawing.Size(155, 34);
            this.btn_cal.TabIndex = 0;
            this.btn_cal.Text = "Thời gian biểu";
            this.btn_cal.UseVisualStyleBackColor = true;
            this.btn_cal.Click += new System.EventHandler(this.btn_cal_Click);
            // 
            // pn_header
            // 
            this.pn_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_header.Location = new System.Drawing.Point(307, 0);
            this.pn_header.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_header.Name = "pn_header";
            this.pn_header.Size = new System.Drawing.Size(1178, 76);
            this.pn_header.TabIndex = 1;
            // 
            // pn_content
            // 
            this.pn_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_content.Location = new System.Drawing.Point(307, 76);
            this.pn_content.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_content.Name = "pn_content";
            this.pn_content.Size = new System.Drawing.Size(1178, 814);
            this.pn_content.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 890);
            this.Controls.Add(this.pn_content);
            this.Controls.Add(this.pn_header);
            this.Controls.Add(this.pn_menu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.pn_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_menu;
        private System.Windows.Forms.Panel pn_header;
        private System.Windows.Forms.Panel pn_content;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_cal;
        private System.Windows.Forms.Button button6;
    }
}