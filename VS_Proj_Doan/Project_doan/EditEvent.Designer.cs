namespace Project_doan
{
    partial class EditEvent
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
            this.label5 = new System.Windows.Forms.Label();
            this.frequency = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.day_end = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.day_start = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_title = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_desc = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Ngày kết thúc";
            // 
            // frequency
            // 
            this.frequency.BackColor = System.Drawing.Color.Transparent;
            this.frequency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.frequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequency.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.frequency.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.frequency.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.frequency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.frequency.ItemHeight = 30;
            this.frequency.Items.AddRange(new object[] {
            "None",
            "Tuần",
            "2 Tuần",
            "Tháng",
            "Năm"});
            this.frequency.Location = new System.Drawing.Point(161, 222);
            this.frequency.Name = "frequency";
            this.frequency.Size = new System.Drawing.Size(265, 36);
            this.frequency.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Lặp lại";
            // 
            // day_end
            // 
            this.day_end.BorderRadius = 10;
            this.day_end.Checked = true;
            this.day_end.FillColor = System.Drawing.Color.White;
            this.day_end.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.day_end.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.day_end.Location = new System.Drawing.Point(160, 162);
            this.day_end.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.day_end.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.day_end.Name = "day_end";
            this.day_end.Size = new System.Drawing.Size(266, 36);
            this.day_end.TabIndex = 18;
            this.day_end.Value = new System.DateTime(2025, 12, 11, 2, 24, 55, 331);
            // 
            // day_start
            // 
            this.day_start.AutoRoundedCorners = true;
            this.day_start.BackColor = System.Drawing.Color.Transparent;
            this.day_start.BorderRadius = 17;
            this.day_start.Checked = true;
            this.day_start.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.day_start.FocusedColor = System.Drawing.Color.Black;
            this.day_start.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.day_start.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.day_start.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.day_start.Location = new System.Drawing.Point(161, 93);
            this.day_start.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.day_start.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.day_start.Name = "day_start";
            this.day_start.Size = new System.Drawing.Size(265, 36);
            this.day_start.TabIndex = 17;
            this.day_start.UseTransparentBackground = true;
            this.day_start.Value = new System.DateTime(2025, 12, 11, 2, 24, 50, 229);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ghi chú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tiêu đề";
            // 
            // tb_title
            // 
            this.tb_title.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_title.DefaultText = "";
            this.tb_title.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_title.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_title.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_title.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_title.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_title.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_title.Location = new System.Drawing.Point(149, 8);
            this.tb_title.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_title.Name = "tb_title";
            this.tb_title.PlaceholderText = "";
            this.tb_title.SelectedText = "";
            this.tb_title.Size = new System.Drawing.Size(277, 48);
            this.tb_title.TabIndex = 13;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(594, 405);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(134, 48);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Lưu";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_desc
            // 
            this.tb_desc.Location = new System.Drawing.Point(126, 296);
            this.tb_desc.Margin = new System.Windows.Forms.Padding(2);
            this.tb_desc.Name = "tb_desc";
            this.tb_desc.Size = new System.Drawing.Size(602, 105);
            this.tb_desc.TabIndex = 11;
            this.tb_desc.Text = "";
            // 
            // EditEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 463);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.frequency);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.day_end);
            this.Controls.Add(this.day_start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_title);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_desc);
            this.Name = "EditEvent";
            this.Text = "EditEvent";
            this.Load += new System.EventHandler(this.EditEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox frequency;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker day_end;
        private Guna.UI2.WinForms.Guna2DateTimePicker day_start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tb_title;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.RichTextBox tb_desc;
    }
}