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
            this.pn_menu.Name = "pn_menu";
            this.pn_menu.Size = new System.Drawing.Size(223, 593);
            this.pn_menu.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(98, 349);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Tài khoản";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(62, 283);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Pomodoro";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(71, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "Đồng hồ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(71, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ghi chú";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(71, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Mục tiêu";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_cal
            // 
            this.btn_cal.Location = new System.Drawing.Point(62, 85);
            this.btn_cal.Name = "btn_cal";
            this.btn_cal.Size = new System.Drawing.Size(113, 23);
            this.btn_cal.TabIndex = 0;
            this.btn_cal.Text = "Thời gian biểu";
            this.btn_cal.UseVisualStyleBackColor = true;
            this.btn_cal.Click += new System.EventHandler(this.btn_cal_Click);
            // 
            // pn_header
            // 
            this.pn_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_header.Location = new System.Drawing.Point(223, 0);
            this.pn_header.Name = "pn_header";
            this.pn_header.Size = new System.Drawing.Size(857, 51);
            this.pn_header.TabIndex = 1;
            // 
            // pn_content
            // 
            this.pn_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_content.Location = new System.Drawing.Point(223, 51);
            this.pn_content.Name = "pn_content";
            this.pn_content.Size = new System.Drawing.Size(857, 542);
            this.pn_content.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 593);
            this.Controls.Add(this.pn_content);
            this.Controls.Add(this.pn_header);
            this.Controls.Add(this.pn_menu);
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