namespace Project_doan
{
    partial class Pomodoro
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lb_pomo = new System.Windows.Forms.Label();
            this.lb_break = new System.Windows.Forms.Label();
            this.cbb_option = new System.Windows.Forms.ComboBox();
            this.btn_pomo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_circle = new System.Windows.Forms.Panel();
            this.lb_timepomo = new System.Windows.Forms.Label();
            this.panel_circle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_pomo
            // 
            this.lb_pomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_pomo.AutoSize = true;
            this.lb_pomo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lb_pomo.ForeColor = System.Drawing.Color.Black;
            this.lb_pomo.Location = new System.Drawing.Point(71, 21);
            this.lb_pomo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_pomo.Name = "lb_pomo";
            this.lb_pomo.Size = new System.Drawing.Size(190, 46);
            this.lb_pomo.TabIndex = 0;
            this.lb_pomo.Text = "Pomodoro";
            // 
            // lb_break
            // 
            this.lb_break.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_break.AutoSize = true;
            this.lb_break.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lb_break.ForeColor = System.Drawing.Color.Black;
            this.lb_break.Location = new System.Drawing.Point(330, 21);
            this.lb_break.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_break.Name = "lb_break";
            this.lb_break.Size = new System.Drawing.Size(111, 46);
            this.lb_break.TabIndex = 1;
            this.lb_break.Text = "Break";
            // 
            // cbb_option
            // 
            this.cbb_option.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbb_option.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_option.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_option.FormattingEnabled = true;
            this.cbb_option.Location = new System.Drawing.Point(268, 419);
            this.cbb_option.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_option.Name = "cbb_option";
            this.cbb_option.Size = new System.Drawing.Size(154, 31);
            this.cbb_option.TabIndex = 3;
            this.cbb_option.SelectedIndexChanged += new System.EventHandler(this.cbb_option_SelectedIndexChanged);
            // 
            // btn_pomo
            // 
            this.btn_pomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_pomo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btn_pomo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pomo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btn_pomo.ForeColor = System.Drawing.Color.White;
            this.btn_pomo.Location = new System.Drawing.Point(172, 473);
            this.btn_pomo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pomo.Name = "btn_pomo";
            this.btn_pomo.Size = new System.Drawing.Size(138, 50);
            this.btn_pomo.TabIndex = 4;
            this.btn_pomo.Text = "Start";
            this.btn_pomo.UseVisualStyleBackColor = false;
            this.btn_pomo.Click += new System.EventHandler(this.btn_pomo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(75, 419);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pomodoro / Break:";
            // 
            // panel_circle
            // 
            this.panel_circle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_circle.Controls.Add(this.lb_timepomo);
            this.panel_circle.Location = new System.Drawing.Point(70, 84);
            this.panel_circle.Margin = new System.Windows.Forms.Padding(4);
            this.panel_circle.Name = "panel_circle";
            this.panel_circle.Size = new System.Drawing.Size(371, 316);
            this.panel_circle.TabIndex = 2;
            this.panel_circle.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_circle_Paint);
            // 
            // lb_timepomo
            // 
            this.lb_timepomo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_timepomo.BackColor = System.Drawing.Color.Transparent;
            this.lb_timepomo.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lb_timepomo.ForeColor = System.Drawing.Color.White;
            this.lb_timepomo.Location = new System.Drawing.Point(0, -1);
            this.lb_timepomo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_timepomo.Name = "lb_timepomo";
            this.lb_timepomo.Size = new System.Drawing.Size(371, 317);
            this.lb_timepomo.TabIndex = 0;
            this.lb_timepomo.Text = "00:00";
            this.lb_timepomo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pomodoro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_pomo);
            this.Controls.Add(this.cbb_option);
            this.Controls.Add(this.panel_circle);
            this.Controls.Add(this.lb_break);
            this.Controls.Add(this.lb_pomo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pomodoro";
            this.Size = new System.Drawing.Size(547, 572);
            this.Load += new System.EventHandler(this.Pomodoro_Load);
            this.panel_circle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lb_pomo;
        private System.Windows.Forms.Label lb_break;
        private System.Windows.Forms.ComboBox cbb_option;
        private System.Windows.Forms.Button btn_pomo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_circle;
        private System.Windows.Forms.Label lb_timepomo;
    }
}