namespace Project_doan
{
    partial class Muc_tieu
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
            this.pn_list = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // pn_list
            // 
            this.pn_list.Location = new System.Drawing.Point(13, 66);
            this.pn_list.Name = "pn_list";
            this.pn_list.Size = new System.Drawing.Size(892, 522);
            this.pn_list.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.BorderRadius = 20;
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.Font = new System.Drawing.Font("Noto Sans SC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(741, 15);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(180, 45);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Tạo mục tiêu";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // Muc_tieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.pn_list);
            this.Name = "Muc_tieu";
            this.Size = new System.Drawing.Size(921, 607);
            this.Load += new System.EventHandler(this.Muc_tieu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pn_list;
        private Guna.UI2.WinForms.Guna2Button btn_add;
    }
}
