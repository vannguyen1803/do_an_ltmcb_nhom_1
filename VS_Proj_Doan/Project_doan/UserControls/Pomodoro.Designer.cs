namespace Project_doan.UserControls
{
    partial class Pomodoro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pn_pomo = new System.Windows.Forms.Panel();
            this.cbb_option = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_pomo = new Guna.UI2.WinForms.Guna2Button();
            this.lb_break = new System.Windows.Forms.Label();
            this.lb_pomo = new System.Windows.Forms.Label();
            this.duongtron = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.lb_timepomo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pn_pomo.SuspendLayout();
            this.duongtron.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_pomo
            // 
            this.pn_pomo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pn_pomo.Controls.Add(this.cbb_option);
            this.pn_pomo.Controls.Add(this.label3);
            this.pn_pomo.Controls.Add(this.btn_pomo);
            this.pn_pomo.Controls.Add(this.lb_break);
            this.pn_pomo.Controls.Add(this.lb_pomo);
            this.pn_pomo.Controls.Add(this.duongtron);
            this.pn_pomo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_pomo.Location = new System.Drawing.Point(0, 0);
            this.pn_pomo.Name = "pn_pomo";
            this.pn_pomo.Size = new System.Drawing.Size(477, 573);
            this.pn_pomo.TabIndex = 9;
            // 
            // cbb_option
            // 
            this.cbb_option.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbb_option.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_option.FormattingEnabled = true;
            this.cbb_option.Location = new System.Drawing.Point(272, 458);
            this.cbb_option.Name = "cbb_option";
            this.cbb_option.Size = new System.Drawing.Size(78, 28);
            this.cbb_option.TabIndex = 11;
            this.cbb_option.SelectedIndexChanged += new System.EventHandler(this.cbb_option_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pomodoro/Break";
            // 
            // btn_pomo
            // 
            this.btn_pomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_pomo.BorderRadius = 15;
            this.btn_pomo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_pomo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_pomo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_pomo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_pomo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pomo.ForeColor = System.Drawing.Color.White;
            this.btn_pomo.Location = new System.Drawing.Point(168, 516);
            this.btn_pomo.Name = "btn_pomo";
            this.btn_pomo.Size = new System.Drawing.Size(134, 45);
            this.btn_pomo.TabIndex = 9;
            this.btn_pomo.Click += new System.EventHandler(this.btn_pomo_Click);
            // 
            // lb_break
            // 
            this.lb_break.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_break.AutoSize = true;
            this.lb_break.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_break.ForeColor = System.Drawing.Color.Black;
            this.lb_break.Location = new System.Drawing.Point(306, 40);
            this.lb_break.Name = "lb_break";
            this.lb_break.Size = new System.Drawing.Size(93, 32);
            this.lb_break.TabIndex = 8;
            this.lb_break.Text = "Break";
            // 
            // lb_pomo
            // 
            this.lb_pomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_pomo.AutoSize = true;
            this.lb_pomo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pomo.ForeColor = System.Drawing.Color.Black;
            this.lb_pomo.Location = new System.Drawing.Point(33, 40);
            this.lb_pomo.Name = "lb_pomo";
            this.lb_pomo.Size = new System.Drawing.Size(153, 32);
            this.lb_pomo.TabIndex = 7;
            this.lb_pomo.Text = "Pomodoro";
            // 
            // duongtron
            // 
            this.duongtron.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.duongtron.BackColor = System.Drawing.Color.LightSkyBlue;
            this.duongtron.Controls.Add(this.lb_timepomo);
            this.duongtron.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.duongtron.FillThickness = 2;
            this.duongtron.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.duongtron.ForeColor = System.Drawing.Color.White;
            this.duongtron.Location = new System.Drawing.Point(69, 106);
            this.duongtron.Minimum = 0;
            this.duongtron.Name = "duongtron";
            this.duongtron.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.duongtron.Size = new System.Drawing.Size(330, 330);
            this.duongtron.TabIndex = 2;
            // 
            // lb_timepomo
            // 
            this.lb_timepomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_timepomo.AutoSize = true;
            this.lb_timepomo.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_timepomo.ForeColor = System.Drawing.Color.White;
            this.lb_timepomo.Location = new System.Drawing.Point(85, 128);
            this.lb_timepomo.Name = "lb_timepomo";
            this.lb_timepomo.Size = new System.Drawing.Size(176, 81);
            this.lb_timepomo.TabIndex = 0;
            this.lb_timepomo.Text = "00:00";
            this.lb_timepomo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Pomodoro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_pomo);
            this.Name = "Pomodoro";
            this.Size = new System.Drawing.Size(477, 573);
            this.pn_pomo.ResumeLayout(false);
            this.pn_pomo.PerformLayout();
            this.duongtron.ResumeLayout(false);
            this.duongtron.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_pomo;
        private Guna.UI2.WinForms.Guna2CircleProgressBar duongtron;
        private System.Windows.Forms.Label lb_timepomo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_break;
        private System.Windows.Forms.Label lb_pomo;
        private Guna.UI2.WinForms.Guna2Button btn_pomo;
        private System.Windows.Forms.ComboBox cbb_option;
        private System.Windows.Forms.Label label3;
    }
}
