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
            this.pn_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_year = new System.Windows.Forms.Label();
            this.btn_nextmonth = new System.Windows.Forms.Button();
            this.lb_month = new System.Windows.Forms.Label();
            this.btn_premonth = new System.Windows.Forms.Button();
            this.pn_weekday = new System.Windows.Forms.Panel();
            this.lb_sun = new System.Windows.Forms.Label();
            this.lb_sat = new System.Windows.Forms.Label();
            this.lb_fri = new System.Windows.Forms.Label();
            this.lb_thu = new System.Windows.Forms.Label();
            this.lb_wed = new System.Windows.Forms.Label();
            this.lb_tue = new System.Windows.Forms.Label();
            this.lb_mon = new System.Windows.Forms.Label();
            this.pn_day = new System.Windows.Forms.Panel();
            this.pn_header.SuspendLayout();
            this.pn_weekday.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_header
            // 
            this.pn_header.Controls.Add(this.label1);
            this.pn_header.Controls.Add(this.lb_year);
            this.pn_header.Controls.Add(this.btn_nextmonth);
            this.pn_header.Controls.Add(this.lb_month);
            this.pn_header.Controls.Add(this.btn_premonth);
            this.pn_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_header.Location = new System.Drawing.Point(0, 0);
            this.pn_header.Name = "pn_header";
            this.pn_header.Size = new System.Drawing.Size(857, 51);
            this.pn_header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "SCHEDULE";
            // 
            // lb_year
            // 
            this.lb_year.AutoSize = true;
            this.lb_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_year.Location = new System.Drawing.Point(773, 8);
            this.lb_year.Name = "lb_year";
            this.lb_year.Size = new System.Drawing.Size(50, 25);
            this.lb_year.TabIndex = 3;
            this.lb_year.Text = "year";
            // 
            // btn_nextmonth
            // 
            this.btn_nextmonth.AllowDrop = true;
            this.btn_nextmonth.BackColor = System.Drawing.Color.Transparent;
            this.btn_nextmonth.FlatAppearance.BorderSize = 0;
            this.btn_nextmonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nextmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_nextmonth.Location = new System.Drawing.Point(479, 7);
            this.btn_nextmonth.Name = "btn_nextmonth";
            this.btn_nextmonth.Size = new System.Drawing.Size(75, 33);
            this.btn_nextmonth.TabIndex = 2;
            this.btn_nextmonth.Text = ">";
            this.btn_nextmonth.UseVisualStyleBackColor = false;
            // 
            // lb_month
            // 
            this.lb_month.AutoSize = true;
            this.lb_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_month.Location = new System.Drawing.Point(375, 8);
            this.lb_month.Name = "lb_month";
            this.lb_month.Size = new System.Drawing.Size(66, 25);
            this.lb_month.TabIndex = 1;
            this.lb_month.Text = "month";
            // 
            // btn_premonth
            // 
            this.btn_premonth.AllowDrop = true;
            this.btn_premonth.BackColor = System.Drawing.Color.Transparent;
            this.btn_premonth.FlatAppearance.BorderSize = 0;
            this.btn_premonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_premonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_premonth.Location = new System.Drawing.Point(280, 7);
            this.btn_premonth.Name = "btn_premonth";
            this.btn_premonth.Size = new System.Drawing.Size(75, 33);
            this.btn_premonth.TabIndex = 0;
            this.btn_premonth.Text = "<";
            this.btn_premonth.UseVisualStyleBackColor = false;
            // 
            // pn_weekday
            // 
            this.pn_weekday.Controls.Add(this.lb_sun);
            this.pn_weekday.Controls.Add(this.lb_sat);
            this.pn_weekday.Controls.Add(this.lb_fri);
            this.pn_weekday.Controls.Add(this.lb_thu);
            this.pn_weekday.Controls.Add(this.lb_wed);
            this.pn_weekday.Controls.Add(this.lb_tue);
            this.pn_weekday.Controls.Add(this.lb_mon);
            this.pn_weekday.Location = new System.Drawing.Point(0, 51);
            this.pn_weekday.Margin = new System.Windows.Forms.Padding(0);
            this.pn_weekday.Name = "pn_weekday";
            this.pn_weekday.Size = new System.Drawing.Size(857, 47);
            this.pn_weekday.TabIndex = 1;
            // 
            // lb_sun
            // 
            this.lb_sun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_sun.Location = new System.Drawing.Point(730, 6);
            this.lb_sun.Name = "lb_sun";
            this.lb_sun.Size = new System.Drawing.Size(121, 29);
            this.lb_sun.TabIndex = 5;
            this.lb_sun.Text = "SUN";
            this.lb_sun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_sat
            // 
            this.lb_sat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_sat.Location = new System.Drawing.Point(609, 6);
            this.lb_sat.Name = "lb_sat";
            this.lb_sat.Size = new System.Drawing.Size(121, 29);
            this.lb_sat.TabIndex = 3;
            this.lb_sat.Text = "SAT";
            this.lb_sat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_fri
            // 
            this.lb_fri.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_fri.Location = new System.Drawing.Point(488, 6);
            this.lb_fri.Name = "lb_fri";
            this.lb_fri.Size = new System.Drawing.Size(121, 29);
            this.lb_fri.TabIndex = 4;
            this.lb_fri.Text = "FRI";
            this.lb_fri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_thu
            // 
            this.lb_thu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_thu.Location = new System.Drawing.Point(367, 6);
            this.lb_thu.Name = "lb_thu";
            this.lb_thu.Size = new System.Drawing.Size(121, 29);
            this.lb_thu.TabIndex = 3;
            this.lb_thu.Text = "THU";
            this.lb_thu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_wed
            // 
            this.lb_wed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_wed.Location = new System.Drawing.Point(246, 6);
            this.lb_wed.Name = "lb_wed";
            this.lb_wed.Size = new System.Drawing.Size(121, 29);
            this.lb_wed.TabIndex = 2;
            this.lb_wed.Text = "WED";
            this.lb_wed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_tue
            // 
            this.lb_tue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_tue.Location = new System.Drawing.Point(125, 6);
            this.lb_tue.Name = "lb_tue";
            this.lb_tue.Size = new System.Drawing.Size(121, 29);
            this.lb_tue.TabIndex = 1;
            this.lb_tue.Text = "TUE";
            this.lb_tue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_mon
            // 
            this.lb_mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_mon.Location = new System.Drawing.Point(4, 6);
            this.lb_mon.Name = "lb_mon";
            this.lb_mon.Size = new System.Drawing.Size(121, 29);
            this.lb_mon.TabIndex = 0;
            this.lb_mon.Text = "MON";
            this.lb_mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pn_day
            // 
            this.pn_day.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_day.Location = new System.Drawing.Point(0, 98);
            this.pn_day.Margin = new System.Windows.Forms.Padding(0);
            this.pn_day.Name = "pn_day";
            this.pn_day.Size = new System.Drawing.Size(857, 444);
            this.pn_day.TabIndex = 2;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_day);
            this.Controls.Add(this.pn_weekday);
            this.Controls.Add(this.pn_header);
            this.Name = "Calendar";
            this.Size = new System.Drawing.Size(857, 542);
            this.pn_header.ResumeLayout(false);
            this.pn_header.PerformLayout();
            this.pn_weekday.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_header;
        private System.Windows.Forms.Panel pn_weekday;
        private System.Windows.Forms.Panel pn_day;
        private System.Windows.Forms.Button btn_premonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_year;
        private System.Windows.Forms.Button btn_nextmonth;
        private System.Windows.Forms.Label lb_month;
        private System.Windows.Forms.Label lb_mon;
        private System.Windows.Forms.Label lb_sun;
        private System.Windows.Forms.Label lb_sat;
        private System.Windows.Forms.Label lb_fri;
        private System.Windows.Forms.Label lb_thu;
        private System.Windows.Forms.Label lb_wed;
        private System.Windows.Forms.Label lb_tue;
    }
}
