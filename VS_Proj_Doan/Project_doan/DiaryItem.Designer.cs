namespace Project_doan
{
    partial class DiaryItem
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
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.lb_content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.BackColor = System.Drawing.Color.Transparent;
            this.lb_date.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_date.Location = new System.Drawing.Point(30, 19);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(51, 25);
            this.lb_date.TabIndex = 0;
            this.lb_date.Text = "date";
            this.lb_date.Click += new System.EventHandler(this.lb_date_Click);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.BackColor = System.Drawing.Color.Transparent;
            this.lb_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_title.Location = new System.Drawing.Point(30, 69);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(72, 25);
            this.lb_title.TabIndex = 1;
            this.lb_title.Text = "TITLE";
            this.lb_title.Click += new System.EventHandler(this.lb_title_Click);
            // 
            // lb_content
            // 
            this.lb_content.AutoSize = true;
            this.lb_content.BackColor = System.Drawing.Color.Transparent;
            this.lb_content.Location = new System.Drawing.Point(31, 119);
            this.lb_content.Name = "lb_content";
            this.lb_content.Size = new System.Drawing.Size(63, 20);
            this.lb_content.TabIndex = 2;
            this.lb_content.Text = "content";
            this.lb_content.Click += new System.EventHandler(this.lb_content_Click);
            // 
            // DiaryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lb_content);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.lb_date);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "DiaryItem";
            this.Size = new System.Drawing.Size(518, 365);
            this.Load += new System.EventHandler(this.DiaryItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label lb_content;
    }
}
