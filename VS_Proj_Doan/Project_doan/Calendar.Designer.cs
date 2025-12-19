using System.Windows.Forms;

namespace Project_doan
{
    partial class Calendar
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
            this.weekday = new System.Windows.Forms.TableLayoutPanel();
            this.pn_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_year = new System.Windows.Forms.Label();
            this.btn_nextmonth = new System.Windows.Forms.Button();
            this.lb_month = new System.Windows.Forms.Label();
            this.btn_premonth = new System.Windows.Forms.Button();
            this.pn_day = new System.Windows.Forms.TableLayoutPanel();
            this.btn_xuat = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pn_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // weekday
            // 
            this.weekday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(201)))), ((int)(((byte)(250)))));
            this.weekday.ColumnCount = 7;
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.Location = new System.Drawing.Point(0, 60);
            this.weekday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.weekday.Name = "weekday";
            this.weekday.RowCount = 1;
            this.weekday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.weekday.Size = new System.Drawing.Size(1125, 55);
            this.weekday.TabIndex = 3;
            // 
            // pn_header
            // 
            this.pn_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.pn_header.Controls.Add(this.btn_xuat);
            this.pn_header.Controls.Add(this.label1);
            this.pn_header.Controls.Add(this.lb_year);
            this.pn_header.Controls.Add(this.btn_nextmonth);
            this.pn_header.Controls.Add(this.lb_month);
            this.pn_header.Controls.Add(this.btn_premonth);
            this.pn_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_header.Location = new System.Drawing.Point(0, 0);
            this.pn_header.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pn_header.Name = "pn_header";
            this.pn_header.Size = new System.Drawing.Size(1125, 60);
            this.pn_header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "SCHEDULE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_year
            // 
            this.lb_year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_year.AutoSize = true;
            this.lb_year.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_year.Location = new System.Drawing.Point(867, 14);
            this.lb_year.Name = "lb_year";
            this.lb_year.Size = new System.Drawing.Size(65, 31);
            this.lb_year.TabIndex = 3;
            this.lb_year.Text = "year";
            this.lb_year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_nextmonth
            // 
            this.btn_nextmonth.AllowDrop = true;
            this.btn_nextmonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nextmonth.AutoSize = true;
            this.btn_nextmonth.BackColor = System.Drawing.Color.Transparent;
            this.btn_nextmonth.FlatAppearance.BorderSize = 0;
            this.btn_nextmonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nextmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nextmonth.Location = new System.Drawing.Point(691, 6);
            this.btn_nextmonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_nextmonth.Name = "btn_nextmonth";
            this.btn_nextmonth.Size = new System.Drawing.Size(93, 52);
            this.btn_nextmonth.TabIndex = 2;
            this.btn_nextmonth.Text = ">";
            this.btn_nextmonth.UseVisualStyleBackColor = false;
            this.btn_nextmonth.Click += new System.EventHandler(this.btn_nextmonth_Click);
            // 
            // lb_month
            // 
            this.lb_month.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_month.AutoSize = true;
            this.lb_month.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_month.Location = new System.Drawing.Point(521, 14);
            this.lb_month.Name = "lb_month";
            this.lb_month.Size = new System.Drawing.Size(93, 31);
            this.lb_month.TabIndex = 1;
            this.lb_month.Text = "month";
            this.lb_month.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_premonth
            // 
            this.btn_premonth.AllowDrop = true;
            this.btn_premonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_premonth.AutoSize = true;
            this.btn_premonth.BackColor = System.Drawing.Color.Transparent;
            this.btn_premonth.FlatAppearance.BorderSize = 0;
            this.btn_premonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_premonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_premonth.Location = new System.Drawing.Point(315, 6);
            this.btn_premonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_premonth.Name = "btn_premonth";
            this.btn_premonth.Size = new System.Drawing.Size(93, 52);
            this.btn_premonth.TabIndex = 0;
            this.btn_premonth.Text = "<";
            this.btn_premonth.UseVisualStyleBackColor = false;
            this.btn_premonth.Click += new System.EventHandler(this.btn_premonth_Click);
            // 
            // pn_day
            // 
            this.pn_day.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pn_day.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.pn_day.ColumnCount = 7;
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_day.Location = new System.Drawing.Point(0, 116);
            this.pn_day.Margin = new System.Windows.Forms.Padding(0);
            this.pn_day.Name = "pn_day";
            this.pn_day.RowCount = 6;
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.Size = new System.Drawing.Size(1125, 694);
            this.pn_day.TabIndex = 2;
            // 
            // btn_xuat
            // 
            this.btn_xuat.BorderRadius = 10;
            this.btn_xuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xuat.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xuat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(201)))), ((int)(((byte)(250)))));
            this.btn_xuat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuat.ForeColor = System.Drawing.Color.White;
            this.btn_xuat.Location = new System.Drawing.Point(988, 15);
            this.btn_xuat.Name = "btn_xuat";
            this.btn_xuat.Size = new System.Drawing.Size(116, 30);
            this.btn_xuat.TabIndex = 5;
            this.btn_xuat.Text = "Xuất file";
            this.btn_xuat.Click += new System.EventHandler(this.btn_xuat_Click);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_day);
            this.Controls.Add(this.weekday);
            this.Controls.Add(this.pn_header);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Calendar";
            this.Size = new System.Drawing.Size(1125, 810);
            this.Load += new System.EventHandler(this.Calendar_Load);
            this.pn_header.ResumeLayout(false);
            this.pn_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_header;
        private System.Windows.Forms.Button btn_premonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_year;
        private System.Windows.Forms.Button btn_nextmonth;
        private System.Windows.Forms.Label lb_month;
        private TableLayoutPanel pn_day;
        private TableLayoutPanel weekday;
        private Guna.UI2.WinForms.Guna2GradientButton btn_xuat;
    }
}
