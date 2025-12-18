namespace Project_doan
{
    partial class Schedule_day
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
            this.flp_events = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lb_date = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flp_events
            // 
            this.flp_events.Location = new System.Drawing.Point(1, 57);
            this.flp_events.Name = "flp_events";
            this.flp_events.Size = new System.Drawing.Size(800, 392);
            this.flp_events.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.BorderRadius = 20;
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btn_add.FillColor2 = System.Drawing.Color.SteelBlue;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(606, 6);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(180, 34);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Thêm sự kiện";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Location = new System.Drawing.Point(32, 15);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(44, 16);
            this.lb_date.TabIndex = 2;
            this.lb_date.Text = "label1";
            // 
            // Schedule_day
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.flp_events);
            this.Name = "Schedule_day";
            this.Text = "Schedule_day";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_events;
        private Guna.UI2.WinForms.Guna2GradientButton btn_add;
        private System.Windows.Forms.Label lb_date;
    }
}