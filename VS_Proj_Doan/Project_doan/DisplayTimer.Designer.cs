namespace Project_doan
{
    partial class DisplayTimer
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
            this.pomodoro1 = new Project_doan.UserControls.Pomodoro();
            this.pomodoro2 = new Project_doan.UserControls.Pomodoro();
            this.SuspendLayout();
            // 
            // pomodoro1
            // 
            this.pomodoro1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pomodoro1.Location = new System.Drawing.Point(0, 0);
            this.pomodoro1.Name = "pomodoro1";
            this.pomodoro1.Size = new System.Drawing.Size(476, 572);
            this.pomodoro1.TabIndex = 0;
            // 
            // pomodoro2
            // 
            this.pomodoro2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pomodoro2.Location = new System.Drawing.Point(0, 0);
            this.pomodoro2.Name = "pomodoro2";
            this.pomodoro2.Size = new System.Drawing.Size(476, 572);
            this.pomodoro2.TabIndex = 0;
            // 
            // DisplayTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 572);
            this.Controls.Add(this.pomodoro2);
            this.Name = "DisplayTimer";
            this.Text = "DispalyTimer";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Pomodoro pomodoro1;
        private UserControls.Pomodoro pomodoro2;
    }
}