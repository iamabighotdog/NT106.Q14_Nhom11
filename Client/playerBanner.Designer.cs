namespace FormAppQuyt
{
    partial class playerBanner
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
            this.avatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.point = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.rank = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // avatar
            // 
            this.avatar.ImageRotate = 0F;
            this.avatar.Location = new System.Drawing.Point(97, 0);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(100, 125);
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Font = new System.Drawing.Font("Segoe UI Semibold", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(203, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(62, 32);
            this.username.TabIndex = 1;
            this.username.Text = "Name";
            // 
            // point
            // 
            this.point.BackColor = System.Drawing.Color.Transparent;
            this.point.Font = new System.Drawing.Font("Segoe UI Semibold", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.point.Location = new System.Drawing.Point(1010, 46);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(56, 32);
            this.point.TabIndex = 2;
            this.point.Text = "point";
            // 
            // rank
            // 
            this.rank.BackColor = System.Drawing.Color.Transparent;
            this.rank.Font = new System.Drawing.Font("Segoe UI Semibold", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank.Location = new System.Drawing.Point(3, 46);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(47, 32);
            this.rank.TabIndex = 3;
            this.rank.Text = "rank";
            // 
            // playerBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rank);
            this.Controls.Add(this.point);
            this.Controls.Add(this.username);
            this.Controls.Add(this.avatar);
            this.Name = "playerBanner";
            this.Size = new System.Drawing.Size(1075, 125);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox avatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel username;
        private Guna.UI2.WinForms.Guna2HtmlLabel point;
        private Guna.UI2.WinForms.Guna2HtmlLabel rank;
    }
}
