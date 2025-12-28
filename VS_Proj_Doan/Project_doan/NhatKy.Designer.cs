namespace Project_doan
{
    partial class NhatKy
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
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.tb_title = new Guna.UI2.WinForms.Guna2TextBox();
            this.rtb_content = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.btn_open = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_new = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Checked = true;
            this.dtpDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(163)))), ((int)(((byte)(250)))));
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDate.Location = new System.Drawing.Point(4, 45);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(253, 29);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.Value = new System.DateTime(2025, 12, 14, 17, 32, 34, 605);
            // 
            // tb_title
            // 
            this.tb_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_title.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_title.DefaultText = "";
            this.tb_title.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_title.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_title.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_title.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_title.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_title.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_title.Location = new System.Drawing.Point(354, 45);
            this.tb_title.Margin = new System.Windows.Forms.Padding(4);
            this.tb_title.Name = "tb_title";
            this.tb_title.PlaceholderText = "";
            this.tb_title.SelectedText = "";
            this.tb_title.Size = new System.Drawing.Size(580, 29);
            this.tb_title.TabIndex = 2;
            // 
            // rtb_content
            // 
            this.rtb_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_content.Location = new System.Drawing.Point(4, 80);
            this.rtb_content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtb_content.Name = "rtb_content";
            this.rtb_content.Size = new System.Drawing.Size(929, 337);
            this.rtb_content.TabIndex = 3;
            this.rtb_content.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tiêu đề";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.BorderRadius = 10;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_save.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(163)))), ((int)(((byte)(250)))));
            this.btn_save.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(813, 421);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(121, 35);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_open
            // 
            this.btn_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_open.BorderRadius = 10;
            this.btn_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_open.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_open.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_open.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_open.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_open.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(163)))), ((int)(((byte)(250)))));
            this.btn_open.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open.ForeColor = System.Drawing.Color.White;
            this.btn_open.Location = new System.Drawing.Point(4, 421);
            this.btn_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(121, 35);
            this.btn_open.TabIndex = 6;
            this.btn_open.Text = "Back";
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(163)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(397, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "MY DIARY";
            // 
            // btn_new
            // 
            this.btn_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_new.BorderRadius = 10;
            this.btn_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_new.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_new.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_new.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_new.Enabled = false;
            this.btn_new.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(163)))), ((int)(((byte)(250)))));
            this.btn_new.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.ForeColor = System.Drawing.Color.White;
            this.btn_new.Location = new System.Drawing.Point(671, 421);
            this.btn_new.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(121, 35);
            this.btn_new.TabIndex = 7;
            this.btn_new.Text = "New";
            this.btn_new.Visible = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // NhatKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_content);
            this.Controls.Add(this.tb_title);
            this.Controls.Add(this.dtpDate);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NhatKy";
            this.Size = new System.Drawing.Size(945, 466);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Guna.UI2.WinForms.Guna2TextBox tb_title;
        private System.Windows.Forms.RichTextBox rtb_content;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private Guna.UI2.WinForms.Guna2Button btn_open;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_new;
    }
}