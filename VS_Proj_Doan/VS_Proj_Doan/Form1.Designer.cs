namespace VS_Proj_Doan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pn_menu = new Panel();
            btn_acc = new Button();
            btn_pomo = new Button();
            btn_clock = new Button();
            btn_note = new Button();
            btn_aim = new Button();
            btn_tgb = new Button();
            pn_header = new Panel();
            button9 = new Button();
            button8 = new Button();
            label1 = new Label();
            button7 = new Button();
            pn_tgb = new Panel();
            pn_acc = new Panel();
            pn_pomo = new Panel();
            pn_clock = new Panel();
            pn_note = new Panel();
            pn_aim = new Panel();
            pn_menu.SuspendLayout();
            pn_header.SuspendLayout();
            pn_tgb.SuspendLayout();
            SuspendLayout();
            // 
            // pn_menu
            // 
            pn_menu.BackColor = Color.AliceBlue;
            pn_menu.BackgroundImageLayout = ImageLayout.Stretch;
            pn_menu.Controls.Add(btn_acc);
            pn_menu.Controls.Add(btn_pomo);
            pn_menu.Controls.Add(btn_clock);
            pn_menu.Controls.Add(btn_note);
            pn_menu.Controls.Add(btn_aim);
            pn_menu.Controls.Add(btn_tgb);
            pn_menu.Dock = DockStyle.Left;
            pn_menu.Location = new Point(0, 0);
            pn_menu.Name = "pn_menu";
            pn_menu.Size = new Size(246, 616);
            pn_menu.TabIndex = 1;
            // 
            // btn_acc
            // 
            btn_acc.BackColor = Color.Transparent;
            btn_acc.FlatAppearance.BorderColor = Color.White;
            btn_acc.FlatAppearance.BorderSize = 0;
            btn_acc.FlatStyle = FlatStyle.Flat;
            btn_acc.Font = new Font("Segoe UI", 14F);
            btn_acc.Location = new Point(0, 449);
            btn_acc.Name = "btn_acc";
            btn_acc.Size = new Size(246, 72);
            btn_acc.TabIndex = 5;
            btn_acc.Text = "Tài khoản";
            btn_acc.TextAlign = ContentAlignment.MiddleRight;
            btn_acc.UseVisualStyleBackColor = false;
            btn_acc.Click += btn_acc_Click;
            // 
            // btn_pomo
            // 
            btn_pomo.BackColor = Color.Transparent;
            btn_pomo.FlatAppearance.BorderColor = Color.White;
            btn_pomo.FlatAppearance.BorderSize = 0;
            btn_pomo.FlatStyle = FlatStyle.Flat;
            btn_pomo.Font = new Font("Segoe UI", 14F);
            btn_pomo.Location = new Point(0, 375);
            btn_pomo.Name = "btn_pomo";
            btn_pomo.Size = new Size(246, 72);
            btn_pomo.TabIndex = 4;
            btn_pomo.Text = "Pomodoro";
            btn_pomo.TextAlign = ContentAlignment.MiddleRight;
            btn_pomo.UseVisualStyleBackColor = false;
            btn_pomo.Click += btn_pomo_Click;
            // 
            // btn_clock
            // 
            btn_clock.BackColor = Color.Transparent;
            btn_clock.FlatAppearance.BorderColor = Color.White;
            btn_clock.FlatAppearance.BorderSize = 0;
            btn_clock.FlatStyle = FlatStyle.Flat;
            btn_clock.Font = new Font("Segoe UI", 14F);
            btn_clock.Location = new Point(0, 302);
            btn_clock.Name = "btn_clock";
            btn_clock.Size = new Size(246, 72);
            btn_clock.TabIndex = 3;
            btn_clock.Text = "Đồng hồ";
            btn_clock.TextAlign = ContentAlignment.MiddleRight;
            btn_clock.UseVisualStyleBackColor = false;
            btn_clock.Click += btn_clock_Click;
            // 
            // btn_note
            // 
            btn_note.BackColor = Color.Transparent;
            btn_note.FlatAppearance.BorderColor = Color.White;
            btn_note.FlatAppearance.BorderSize = 0;
            btn_note.FlatStyle = FlatStyle.Flat;
            btn_note.Font = new Font("Segoe UI", 14F);
            btn_note.Location = new Point(0, 229);
            btn_note.Name = "btn_note";
            btn_note.Size = new Size(246, 72);
            btn_note.TabIndex = 2;
            btn_note.Text = "Ghi chú";
            btn_note.TextAlign = ContentAlignment.MiddleRight;
            btn_note.UseVisualStyleBackColor = false;
            btn_note.Click += btn_note_Click;
            // 
            // btn_aim
            // 
            btn_aim.BackColor = Color.Transparent;
            btn_aim.FlatAppearance.BorderColor = Color.White;
            btn_aim.FlatAppearance.BorderSize = 0;
            btn_aim.FlatStyle = FlatStyle.Flat;
            btn_aim.Font = new Font("Segoe UI", 14F);
            btn_aim.Location = new Point(0, 156);
            btn_aim.Name = "btn_aim";
            btn_aim.Size = new Size(246, 72);
            btn_aim.TabIndex = 1;
            btn_aim.Text = "Mục tiêu";
            btn_aim.TextAlign = ContentAlignment.MiddleRight;
            btn_aim.UseVisualStyleBackColor = false;
            btn_aim.Click += btn_aim_Click;
            // 
            // btn_tgb
            // 
            btn_tgb.BackColor = Color.Transparent;
            btn_tgb.BackgroundImageLayout = ImageLayout.None;
            btn_tgb.FlatAppearance.BorderColor = Color.White;
            btn_tgb.FlatAppearance.BorderSize = 0;
            btn_tgb.FlatStyle = FlatStyle.Flat;
            btn_tgb.Font = new Font("Segoe UI", 14F);
            btn_tgb.ForeColor = SystemColors.ActiveCaptionText;
            btn_tgb.Location = new Point(0, 79);
            btn_tgb.Name = "btn_tgb";
            btn_tgb.Size = new Size(246, 72);
            btn_tgb.TabIndex = 0;
            btn_tgb.Text = "Thời gian biểu";
            btn_tgb.TextAlign = ContentAlignment.MiddleRight;
            btn_tgb.UseVisualStyleBackColor = false;
            btn_tgb.Click += btn_tgb_Click;
            // 
            // pn_header
            // 
            pn_header.BackColor = SystemColors.GradientInactiveCaption;
            pn_header.Controls.Add(button9);
            pn_header.Controls.Add(button8);
            pn_header.Controls.Add(label1);
            pn_header.Controls.Add(button7);
            pn_header.Dock = DockStyle.Top;
            pn_header.Location = new Point(246, 0);
            pn_header.Name = "pn_header";
            pn_header.Size = new Size(885, 70);
            pn_header.TabIndex = 2;
            // 
            // button9
            // 
            button9.Location = new Point(659, 16);
            button9.Name = "button9";
            button9.Size = new Size(45, 31);
            button9.TabIndex = 6;
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(604, 16);
            button8.Name = "button8";
            button8.Size = new Size(49, 35);
            button8.TabIndex = 5;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(773, 21);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // button7
            // 
            button7.Location = new Point(6, 12);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 3;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            // 
            // pn_tgb
            // 
            pn_tgb.Controls.Add(pn_acc);
            pn_tgb.Controls.Add(pn_pomo);
            pn_tgb.Controls.Add(pn_clock);
            pn_tgb.Controls.Add(pn_note);
            pn_tgb.Controls.Add(pn_aim);
            pn_tgb.Location = new Point(252, 76);
            pn_tgb.Name = "pn_tgb";
            pn_tgb.Size = new Size(879, 540);
            pn_tgb.TabIndex = 3;
            // 
            // pn_acc
            // 
            pn_acc.Location = new Point(514, 261);
            pn_acc.Name = "pn_acc";
            pn_acc.Size = new Size(250, 125);
            pn_acc.TabIndex = 3;
            // 
            // pn_pomo
            // 
            pn_pomo.Location = new Point(66, 325);
            pn_pomo.Name = "pn_pomo";
            pn_pomo.Size = new Size(250, 125);
            pn_pomo.TabIndex = 2;
            // 
            // pn_clock
            // 
            pn_clock.Location = new Point(567, 41);
            pn_clock.Name = "pn_clock";
            pn_clock.Size = new Size(250, 125);
            pn_clock.TabIndex = 1;
            // 
            // pn_note
            // 
            pn_note.Location = new Point(301, 41);
            pn_note.Name = "pn_note";
            pn_note.Size = new Size(206, 206);
            pn_note.TabIndex = 0;
            // 
            // pn_aim
            // 
            pn_aim.Location = new Point(18, 41);
            pn_aim.Name = "pn_aim";
            pn_aim.Size = new Size(237, 206);
            pn_aim.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1131, 616);
            Controls.Add(pn_tgb);
            Controls.Add(pn_header);
            Controls.Add(pn_menu);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            pn_menu.ResumeLayout(false);
            pn_header.ResumeLayout(false);
            pn_header.PerformLayout();
            pn_tgb.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_menu;
        private Button btn_pomo;
        private Button btn_clock;
        private Button btn_note;
        private Button btn_aim;
        private Button btn_tgb;
        private Button btn_acc;
        private Panel pn_header;
        private Button button9;
        private Button button8;
        private Label label1;
        private Button button7;
        private Panel pn_tgb;
        private Panel pn_aim;
        private Panel pn_note;
        private Panel pn_acc;
        private Panel pn_pomo;
        private Panel pn_clock;
    }
}
