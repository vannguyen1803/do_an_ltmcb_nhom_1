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
            this.pn_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // weekday
            // 
            this.weekday.ColumnCount = 7;
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekday.Location = new System.Drawing.Point(0, 48);
            this.weekday.Name = "weekday";
            this.weekday.RowCount = 1;
            this.weekday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.weekday.Size = new System.Drawing.Size(976, 43);
            this.weekday.TabIndex = 3;
            // 
            // pn_header
            // 
            this.pn_header.BackColor = System.Drawing.Color.LightBlue;
            this.pn_header.Controls.Add(this.label1);
            this.pn_header.Controls.Add(this.lb_year);
            this.pn_header.Controls.Add(this.btn_nextmonth);
            this.pn_header.Controls.Add(this.lb_month);
            this.pn_header.Controls.Add(this.btn_premonth);
            this.pn_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_header.Location = new System.Drawing.Point(0, 0);
            this.pn_header.Name = "pn_header";
            this.pn_header.Size = new System.Drawing.Size(976, 48);
            this.pn_header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "SCHEDULE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_year
            // 
            this.lb_year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_year.AutoSize = true;
            this.lb_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_year.Location = new System.Drawing.Point(771, 11);
            this.lb_year.Name = "lb_year";
            this.lb_year.Size = new System.Drawing.Size(50, 25);
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
            this.btn_nextmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_nextmonth.Location = new System.Drawing.Point(485, 7);
            this.btn_nextmonth.Name = "btn_nextmonth";
            this.btn_nextmonth.Size = new System.Drawing.Size(188, 42);
            this.btn_nextmonth.TabIndex = 2;
            this.btn_nextmonth.Text = ">";
            this.btn_nextmonth.UseVisualStyleBackColor = false;
            // 
            // lb_month
            // 
            this.lb_month.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_month.AutoSize = true;
            this.lb_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_month.Location = new System.Drawing.Point(450, 11);
            this.lb_month.Name = "lb_month";
            this.lb_month.Size = new System.Drawing.Size(66, 25);
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
            this.btn_premonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_premonth.Location = new System.Drawing.Point(280, 7);
            this.btn_premonth.Name = "btn_premonth";
            this.btn_premonth.Size = new System.Drawing.Size(194, 42);
            this.btn_premonth.TabIndex = 0;
            this.btn_premonth.Text = "<";
            this.btn_premonth.UseVisualStyleBackColor = false;
            this.btn_premonth.Click += new System.EventHandler(this.btn_premonth_Click);
            // 
            // pn_day
            // 
            this.pn_day.ColumnCount = 7;
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pn_day.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_day.Location = new System.Drawing.Point(0, 92);
            this.pn_day.Name = "pn_day";
            this.pn_day.RowCount = 6;
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.pn_day.Size = new System.Drawing.Size(976, 535);
            this.pn_day.TabIndex = 2;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_day);
            this.Controls.Add(this.weekday);
            this.Controls.Add(this.pn_header);
            this.Name = "Calendar";
            this.Size = new System.Drawing.Size(976, 627);
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
    }
}
