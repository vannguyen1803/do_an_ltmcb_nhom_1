namespace Project_doan
{
    partial class ItemAim
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.rtb_mota = new System.Windows.Forms.RichTextBox();
            this.btn_xoa = new Guna.UI2.WinForms.Guna2Button();
            this.btn_complete = new Guna.UI2.WinForms.Guna2Button();
            this.lb_end = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_start = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_aim = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // rtb_mota
            // 
            this.rtb_mota.Location = new System.Drawing.Point(232, 46);
            this.rtb_mota.Name = "rtb_mota";
            this.rtb_mota.ReadOnly = true;
            this.rtb_mota.Size = new System.Drawing.Size(177, 61);
            this.rtb_mota.TabIndex = 58;
            this.rtb_mota.Text = "";
            // 
            // btn_xoa
            // 
            this.btn_xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xoa.BorderRadius = 20;
            this.btn_xoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xoa.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(505, 83);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(126, 45);
            this.btn_xoa.TabIndex = 57;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_complete
            // 
            this.btn_complete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_complete.BorderRadius = 20;
            this.btn_complete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_complete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_complete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_complete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_complete.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btn_complete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_complete.ForeColor = System.Drawing.Color.White;
            this.btn_complete.Location = new System.Drawing.Point(490, 27);
            this.btn_complete.Name = "btn_complete";
            this.btn_complete.Size = new System.Drawing.Size(152, 50);
            this.btn_complete.TabIndex = 48;
            this.btn_complete.Text = "Hoàn thành";
            this.btn_complete.Click += new System.EventHandler(this.btn_complete_Click);
            // 
            // lb_end
            // 
            this.lb_end.AutoSize = true;
            this.lb_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_end.Location = new System.Drawing.Point(228, 183);
            this.lb_end.Name = "lb_end";
            this.lb_end.Size = new System.Drawing.Size(0, 18);
            this.lb_end.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 18);
            this.label9.TabIndex = 55;
            this.label9.Text = "Ngày kết thúc: ";
            // 
            // lb_start
            // 
            this.lb_start.AutoSize = true;
            this.lb_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_start.Location = new System.Drawing.Point(228, 155);
            this.lb_start.Name = "lb_start";
            this.lb_start.Size = new System.Drawing.Size(0, 18);
            this.lb_start.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 18);
            this.label7.TabIndex = 53;
            this.label7.Text = "Ngày bắt đầu: ";
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.Location = new System.Drawing.Point(228, 122);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(0, 18);
            this.lb_status.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 51;
            this.label3.Text = "Mô tả: ";
            // 
            // lb_aim
            // 
            this.lb_aim.AutoSize = true;
            this.lb_aim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_aim.Location = new System.Drawing.Point(228, 14);
            this.lb_aim.Name = "lb_aim";
            this.lb_aim.Size = new System.Drawing.Size(0, 18);
            this.lb_aim.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "Mục tiêu: ";
            // 
            // ItemAim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.rtb_mota);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_complete);
            this.Controls.Add(this.lb_end);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_start);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_aim);
            this.Controls.Add(this.label1);
            this.Name = "ItemAim";
            this.Size = new System.Drawing.Size(680, 237);
            this.Click += new System.EventHandler(this.ItemAim_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.RichTextBox rtb_mota;
        private Guna.UI2.WinForms.Guna2Button btn_xoa;
        private Guna.UI2.WinForms.Guna2Button btn_complete;
        private System.Windows.Forms.Label lb_end;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_aim;
        private System.Windows.Forms.Label label1;
    }
}
