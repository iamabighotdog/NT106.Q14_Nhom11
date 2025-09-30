namespace FormAppQuyt
{
    partial class SignUpForm
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
            this.GradientBackGround2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SignUpPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.LogInLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.RewritePasswordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.PasswordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.UsernameBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EmailBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SignUpLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Logo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.GradientBackGround2.SuspendLayout();
            this.SignUpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // GradientBackGround2
            // 
            this.GradientBackGround2.Controls.Add(this.guna2ControlBox1);
            this.GradientBackGround2.Controls.Add(this.SignUpPanel);
            this.GradientBackGround2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.GradientBackGround2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.GradientBackGround2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.GradientBackGround2.Location = new System.Drawing.Point(0, 0);
            this.GradientBackGround2.Name = "GradientBackGround2";
            this.GradientBackGround2.Size = new System.Drawing.Size(1024, 720);
            this.GradientBackGround2.TabIndex = 0;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(979, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.PressedColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 30);
            this.guna2ControlBox1.TabIndex = 6;
            // 
            // SignUpPanel
            // 
            this.SignUpPanel.Controls.Add(this.LogInLabel);
            this.SignUpPanel.Controls.Add(this.guna2HtmlLabel1);
            this.SignUpPanel.Controls.Add(this.guna2Button1);
            this.SignUpPanel.Controls.Add(this.RewritePasswordBox);
            this.SignUpPanel.Controls.Add(this.PasswordBox);
            this.SignUpPanel.Controls.Add(this.UsernameBox);
            this.SignUpPanel.Controls.Add(this.EmailBox);
            this.SignUpPanel.Controls.Add(this.SignUpLabel);
            this.SignUpPanel.Controls.Add(this.Logo);
            this.SignUpPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SignUpPanel.Location = new System.Drawing.Point(312, 60);
            this.SignUpPanel.Name = "SignUpPanel";
            this.SignUpPanel.ShadowDecoration.BorderRadius = 1;
            this.SignUpPanel.ShadowDecoration.Enabled = true;
            this.SignUpPanel.Size = new System.Drawing.Size(400, 600);
            this.SignUpPanel.TabIndex = 0;
            // 
            // LogInLabel
            // 
            this.LogInLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogInLabel.Font = new System.Drawing.Font("Segoe UI", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInLabel.Location = new System.Drawing.Point(215, 574);
            this.LogInLabel.Name = "LogInLabel";
            this.LogInLabel.Size = new System.Drawing.Size(117, 23);
            this.LogInLabel.TabIndex = 8;
            this.LogInLabel.Text = "Đăng nhập ngay";
            this.LogInLabel.MouseEnter += new System.EventHandler(this.LogInLabel_MouseEnter);
            this.LogInLabel.MouseLeave += new System.EventHandler(this.LogInLabel_MouseLeave);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(60, 574);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(149, 23);
            this.guna2HtmlLabel1.TabIndex = 7;
            this.guna2HtmlLabel1.Text = "Bạn đã có tài khoản ?";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Green;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(110, 525);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "Đăng ký";
            // 
            // RewritePasswordBox
            // 
            this.RewritePasswordBox.BorderThickness = 3;
            this.RewritePasswordBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RewritePasswordBox.DefaultText = "";
            this.RewritePasswordBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.RewritePasswordBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.RewritePasswordBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RewritePasswordBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RewritePasswordBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RewritePasswordBox.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.RewritePasswordBox.FocusedState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.RewritePasswordBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RewritePasswordBox.ForeColor = System.Drawing.Color.Gray;
            this.RewritePasswordBox.HoverState.BorderColor = System.Drawing.Color.Green;
            this.RewritePasswordBox.HoverState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.RewritePasswordBox.Location = new System.Drawing.Point(25, 435);
            this.RewritePasswordBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RewritePasswordBox.Name = "RewritePasswordBox";
            this.RewritePasswordBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.RewritePasswordBox.PlaceholderText = "Nhập lại mật khẩu";
            this.RewritePasswordBox.SelectedText = "";
            this.RewritePasswordBox.Size = new System.Drawing.Size(350, 35);
            this.RewritePasswordBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.RewritePasswordBox.TabIndex = 5;
            // 
            // PasswordBox
            // 
            this.PasswordBox.BorderThickness = 3;
            this.PasswordBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordBox.DefaultText = "";
            this.PasswordBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PasswordBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PasswordBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PasswordBox.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.PasswordBox.FocusedState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.PasswordBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PasswordBox.ForeColor = System.Drawing.Color.Gray;
            this.PasswordBox.HoverState.BorderColor = System.Drawing.Color.Green;
            this.PasswordBox.HoverState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.PasswordBox.Location = new System.Drawing.Point(25, 375);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.PasswordBox.PlaceholderText = "Mật khẩu";
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.Size = new System.Drawing.Size(350, 35);
            this.PasswordBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.PasswordBox.TabIndex = 4;
            // 
            // UsernameBox
            // 
            this.UsernameBox.BorderThickness = 3;
            this.UsernameBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameBox.DefaultText = "";
            this.UsernameBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UsernameBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UsernameBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UsernameBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UsernameBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UsernameBox.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.UsernameBox.FocusedState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.UsernameBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UsernameBox.ForeColor = System.Drawing.Color.Gray;
            this.UsernameBox.HoverState.BorderColor = System.Drawing.Color.Green;
            this.UsernameBox.HoverState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.UsernameBox.Location = new System.Drawing.Point(25, 315);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.UsernameBox.PlaceholderText = "Tên tài khoản";
            this.UsernameBox.SelectedText = "";
            this.UsernameBox.Size = new System.Drawing.Size(350, 35);
            this.UsernameBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.UsernameBox.TabIndex = 3;
            // 
            // EmailBox
            // 
            this.EmailBox.BorderThickness = 3;
            this.EmailBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EmailBox.DefaultText = "";
            this.EmailBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EmailBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EmailBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.EmailBox.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.EmailBox.FocusedState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.EmailBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EmailBox.ForeColor = System.Drawing.Color.Gray;
            this.EmailBox.HoverState.BorderColor = System.Drawing.Color.Green;
            this.EmailBox.HoverState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.EmailBox.Location = new System.Drawing.Point(25, 255);
            this.EmailBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.EmailBox.PlaceholderText = "Email/Số điện thoại";
            this.EmailBox.SelectedText = "";
            this.EmailBox.Size = new System.Drawing.Size(350, 35);
            this.EmailBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.EmailBox.TabIndex = 2;
            // 
            // SignUpLabel
            // 
            this.SignUpLabel.BackColor = System.Drawing.Color.Transparent;
            this.SignUpLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpLabel.Location = new System.Drawing.Point(60, 162);
            this.SignUpLabel.Name = "SignUpLabel";
            this.SignUpLabel.Size = new System.Drawing.Size(283, 38);
            this.SignUpLabel.TabIndex = 1;
            this.SignUpLabel.Text = "Đăng ký tài khoản Quýt";
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = global::FormAppQuyt.Properties.Resources.ChatGPT_Image_Sep_29__2025__09_58_10_PM_removebg_preview;
            this.Logo.ImageRotate = 0F;
            this.Logo.Location = new System.Drawing.Point(125, 50);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(150, 150);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            this.Logo.UseTransparentBackground = true;
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.GradientBackGround2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUpForm";
            this.Text = "Form2";
            this.GradientBackGround2.ResumeLayout(false);
            this.SignUpPanel.ResumeLayout(false);
            this.SignUpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel GradientBackGround2;
        private Guna.UI2.WinForms.Guna2Panel SignUpPanel;
        private Guna.UI2.WinForms.Guna2PictureBox Logo;
        private Guna.UI2.WinForms.Guna2HtmlLabel SignUpLabel;
        private Guna.UI2.WinForms.Guna2TextBox EmailBox;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TextBox RewritePasswordBox;
        private Guna.UI2.WinForms.Guna2TextBox PasswordBox;
        private Guna.UI2.WinForms.Guna2TextBox UsernameBox;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel LogInLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}