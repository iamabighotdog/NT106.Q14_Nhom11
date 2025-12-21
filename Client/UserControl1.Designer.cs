namespace FormAppQuyt
{
    partial class RankPopup
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRankValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRankTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.lblRankTitle);
            this.guna2GradientPanel1.Controls.Add(this.lblRankValue);
            this.guna2GradientPanel1.Controls.Add(this.lblScore);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(403, 302);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Location = new System.Drawing.Point(172, 100);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(53, 18);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "lblScore";
            // 
            // lblRankValue
            // 
            this.lblRankValue.BackColor = System.Drawing.Color.Transparent;
            this.lblRankValue.Location = new System.Drawing.Point(147, 142);
            this.lblRankValue.Name = "lblRankValue";
            this.lblRankValue.Size = new System.Drawing.Size(84, 18);
            this.lblRankValue.TabIndex = 1;
            this.lblRankValue.Text = "lblRankValue";
            // 
            // lblRankTitle
            // 
            this.lblRankTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRankTitle.Location = new System.Drawing.Point(208, 182);
            this.lblRankTitle.Name = "lblRankTitle";
            this.lblRankTitle.Size = new System.Drawing.Size(75, 18);
            this.lblRankTitle.TabIndex = 2;
            this.lblRankTitle.Text = "lblRankTitle";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(403, 302);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRankTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRankValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblScore;
    }
}
