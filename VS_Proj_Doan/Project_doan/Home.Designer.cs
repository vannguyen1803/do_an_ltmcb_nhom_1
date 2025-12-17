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
            this.btn_acc = new System.Windows.Forms.Button();
            this.btn_pomo = new System.Windows.Forms.Button();
            this.btn_diary = new System.Windows.Forms.Button();
            this.btn_note = new System.Windows.Forms.Button();
            this.btn_aim = new System.Windows.Forms.Button();
            this.btn_cal = new System.Windows.Forms.Button();
            this.pn_header = new System.Windows.Forms.Panel();
            this.pn_content = new System.Windows.Forms.Panel();
            this.pn_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_menu
            // 
            this.pn_menu.Controls.Add(this.btn_acc);
            this.pn_menu.Controls.Add(this.btn_pomo);
            this.pn_menu.Controls.Add(this.btn_diary);
            this.pn_menu.Controls.Add(this.btn_note);
            this.pn_menu.Controls.Add(this.btn_aim);
            this.pn_menu.Controls.Add(this.btn_cal);
            this.pn_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_menu.Location = new System.Drawing.Point(0, 0);
            this.pn_menu.Name = "pn_menu";
            this.pn_menu.Size = new System.Drawing.Size(223, 699);
            this.pn_menu.TabIndex = 0;
            // 
            
            // btn_acc
            // 
            this.btn_acc.Location = new System.Drawing.Point(58, 339);
            this.btn_acc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_acc.Name = "btn_acc";
            this.btn_acc.Size = new System.Drawing.Size(107, 26);
            this.btn_acc.TabIndex = 5;
            this.btn_acc.Text = "Tài khoản";
            this.btn_acc.UseVisualStyleBackColor = true;
            this.btn_acc.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_pomo
            // 
            this.btn_pomo.Location = new System.Drawing.Point(58, 294);
            this.btn_pomo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_pomo.Name = "btn_pomo";
            this.btn_pomo.Size = new System.Drawing.Size(107, 27);
            this.btn_pomo.TabIndex = 4;
            this.btn_pomo.Text = "Pomodoro";
            this.btn_pomo.UseVisualStyleBackColor = true;
            this.btn_pomo.Click += new System.EventHandler(this.btn_pomo_Click);
            // 
            // btn_diary
            // 
            this.btn_diary.Location = new System.Drawing.Point(58, 248);
            this.btn_diary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_diary.Name = "btn_diary";
            this.btn_diary.Size = new System.Drawing.Size(107, 30);
            this.btn_diary.TabIndex = 3;
            this.btn_diary.Text = "Nhật ký";
            this.btn_diary.UseVisualStyleBackColor = true;
            this.btn_diary.Click += new System.EventHandler(this.btn_diary_Click);
            // 
            // btn_note
            // 
            this.btn_note.Location = new System.Drawing.Point(58, 196);
            this.btn_note.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_note.Name = "btn_note";
            this.btn_note.Size = new System.Drawing.Size(107, 30);
            this.btn_note.TabIndex = 2;
            this.btn_note.Text = "Ghi chú";
            this.btn_note.UseVisualStyleBackColor = true;
            this.btn_note.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_aim
            // 
            this.btn_aim.Location = new System.Drawing.Point(58, 150);
            this.btn_aim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_aim.Name = "btn_aim";
            this.btn_aim.Size = new System.Drawing.Size(107, 28);
            this.btn_aim.TabIndex = 1;
            this.btn_aim.Text = "Mục tiêu";
            this.btn_aim.UseVisualStyleBackColor = true;
            this.btn_aim.Click += new System.EventHandler(this.btn_aim_Click);
            // 
            // btn_cal
            // 
            this.btn_cal.Location = new System.Drawing.Point(58, 102);
            this.btn_cal.Name = "btn_cal";
            this.btn_cal.Size = new System.Drawing.Size(107, 29);
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
            this.pn_header.Size = new System.Drawing.Size(994, 51);
            this.pn_header.TabIndex = 1;
            // 
            // pn_content
            // 
            this.pn_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_content.Location = new System.Drawing.Point(223, 51);
            this.pn_content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pn_content.Name = "pn_content";
            this.pn_content.Size = new System.Drawing.Size(994, 648);
            this.pn_content.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 699);
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
        private System.Windows.Forms.Button btn_pomo;
        private System.Windows.Forms.Button btn_diary;
        private System.Windows.Forms.Button btn_note;
        private System.Windows.Forms.Button btn_aim;
        private System.Windows.Forms.Button btn_cal;
        private System.Windows.Forms.Button btn_acc;
    }
}