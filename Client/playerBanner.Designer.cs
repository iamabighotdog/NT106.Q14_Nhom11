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
            this.avatar.BackColor = System.Drawing.Color.Transparent;
            this.avatar.BorderRadius = 40;
            this.avatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.avatar.ImageRotate = 0F;
            this.avatar.Location = new System.Drawing.Point(110, 15);
            this.avatar.Name = "avatar";
            this.avatar.ShadowDecoration.BorderRadius = 40;
            this.avatar.ShadowDecoration.Depth = 10;
            this.avatar.ShadowDecoration.Enabled = true;
            this.avatar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.avatar.Size = new System.Drawing.Size(80, 80);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.username.Location = new System.Drawing.Point(220, 25);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(65, 29);
            this.username.TabIndex = 1;
            this.username.Text = "Name";
            // 
            // point
            // 
            this.point.BackColor = System.Drawing.Color.Transparent;
            this.point.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.point.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(30)))));
            this.point.Location = new System.Drawing.Point(950, 40);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(63, 32);
            this.point.TabIndex = 2;
            this.point.Text = "point";
            // 
            // rank
            // 
            this.rank.BackColor = System.Drawing.Color.Transparent;
            this.rank.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(50)))));
            this.rank.Location = new System.Drawing.Point(30, 35);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(54, 39);
            this.rank.TabIndex = 3;
            this.rank.Text = "rank";
            // 
            // playerBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.rank);
            this.Controls.Add(this.point);
            this.Controls.Add(this.username);
            this.Controls.Add(this.avatar);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "playerBanner";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1120, 110);
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