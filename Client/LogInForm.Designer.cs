namespace FormAppQuyt
{
    partial class LogInForm
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
            Guna.UI2.WinForms.Guna2GradientPanel GradientBackground1;
            this.Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ToSignUp = new Guna.UI2.WinForms.Guna2Button();
            this.HaveAccountLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ForgotPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LogInButton = new Guna.UI2.WinForms.Guna2Button();
            this.PasswordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EmailBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.LogInLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Logo = new Guna.UI2.WinForms.Guna2PictureBox();
            GradientBackground1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            GradientBackground1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // GradientBackground1
            // 
            GradientBackground1.Anchor = System.Windows.Forms.AnchorStyles.None;
            GradientBackground1.Controls.Add(this.Close);
            GradientBackground1.Controls.Add(this.Panel1);
            GradientBackground1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            GradientBackground1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            GradientBackground1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            GradientBackground1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            GradientBackground1.Location = new System.Drawing.Point(0, 0);
            GradientBackground1.Name = "GradientBackground1";
            GradientBackground1.ShadowDecoration.Depth = 25;
            GradientBackground1.Size = new System.Drawing.Size(1024, 720);
            GradientBackground1.TabIndex = 0;
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Close.HoverState.FillColor = System.Drawing.Color.Red;
            this.Close.IconColor = System.Drawing.Color.Black;
            this.Close.Location = new System.Drawing.Point(979, 0);
            this.Close.Name = "Close";
            this.Close.PressedColor = System.Drawing.Color.Red;
            this.Close.Size = new System.Drawing.Size(45, 30);
            this.Close.TabIndex = 5;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel1.Controls.Add(this.ToSignUp);
            this.Panel1.Controls.Add(this.HaveAccountLabel);
            this.Panel1.Controls.Add(this.ForgotPassword);
            this.Panel1.Controls.Add(this.LogInButton);
            this.Panel1.Controls.Add(this.PasswordBox);
            this.Panel1.Controls.Add(this.EmailBox);
            this.Panel1.Controls.Add(this.LogInLabel);
            this.Panel1.Controls.Add(this.Logo);
            this.Panel1.Location = new System.Drawing.Point(312, 60);
            this.Panel1.Name = "Panel1";
            this.Panel1.ShadowDecoration.BorderRadius = 1;
            this.Panel1.ShadowDecoration.Enabled = true;
            this.Panel1.Size = new System.Drawing.Size(400, 600);
            this.Panel1.TabIndex = 0;
            // 
            // ToSignUp
            // 
            this.ToSignUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ToSignUp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ToSignUp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ToSignUp.DisabledState.FillColor = System.Drawing.Color.DarkGray;
            this.ToSignUp.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.ToSignUp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ToSignUp.FocusedColor = System.Drawing.Color.Transparent;
            this.ToSignUp.Font = new System.Drawing.Font("Segoe UI", 10.01739F);
            this.ToSignUp.ForeColor = System.Drawing.Color.Black;
            this.ToSignUp.Location = new System.Drawing.Point(110, 502);
            this.ToSignUp.Name = "ToSignUp";
            this.ToSignUp.Size = new System.Drawing.Size(180, 45);
            this.ToSignUp.TabIndex = 7;
            this.ToSignUp.Text = "Đăng ký ngay";
            this.ToSignUp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ToSignUp.Click += new System.EventHandler(this.ToSignUp_Click);
            // 
            // HaveAccountLabel
            // 
            this.HaveAccountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HaveAccountLabel.BackColor = System.Drawing.Color.Transparent;
            this.HaveAccountLabel.Font = new System.Drawing.Font("Segoe UI", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HaveAccountLabel.Location = new System.Drawing.Point(120, 471);
            this.HaveAccountLabel.Name = "HaveAccountLabel";
            this.HaveAccountLabel.Size = new System.Drawing.Size(161, 23);
            this.HaveAccountLabel.TabIndex = 6;
            this.HaveAccountLabel.Text = "Bạn chưa có tài khoản?";
            // 
            // ForgotPassword
            // 
            this.ForgotPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.ForgotPassword.Font = new System.Drawing.Font("Segoe UI", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPassword.Location = new System.Drawing.Point(254, 374);
            this.ForgotPassword.Name = "ForgotPassword";
            this.ForgotPassword.Size = new System.Drawing.Size(121, 23);
            this.ForgotPassword.TabIndex = 5;
            this.ForgotPassword.Text = "Quên mật khẩu ?";
            this.ForgotPassword.Click += new System.EventHandler(this.ForgotPassword_Click);
            this.ForgotPassword.MouseEnter += new System.EventHandler(this.ForgotPassword_MouseEnter);
            this.ForgotPassword.MouseLeave += new System.EventHandler(this.ForgotPassword_MouseLeave);
            // 
            // LogInButton
            // 
            this.LogInButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogInButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LogInButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LogInButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LogInButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LogInButton.FillColor = System.Drawing.Color.Green;
            this.LogInButton.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInButton.ForeColor = System.Drawing.Color.White;
            this.LogInButton.Location = new System.Drawing.Point(110, 420);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(180, 45);
            this.LogInButton.TabIndex = 4;
            this.LogInButton.Text = "Đăng nhập";
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
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
            this.PasswordBox.Font = new System.Drawing.Font("Segoe UI", 8.765218F);
            this.PasswordBox.ForeColor = System.Drawing.Color.Gray;
            this.PasswordBox.HoverState.BorderColor = System.Drawing.Color.Green;
            this.PasswordBox.HoverState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.PasswordBox.Location = new System.Drawing.Point(25, 332);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.PasswordBox.PlaceholderText = "Mật khẩu";
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.Size = new System.Drawing.Size(350, 35);
            this.PasswordBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.PasswordBox.TabIndex = 3;
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
            this.EmailBox.Font = new System.Drawing.Font("Segoe UI", 8.765218F);
            this.EmailBox.ForeColor = System.Drawing.Color.Gray;
            this.EmailBox.HoverState.BorderColor = System.Drawing.Color.Green;
            this.EmailBox.HoverState.PlaceholderForeColor = System.Drawing.Color.Green;
            this.EmailBox.Location = new System.Drawing.Point(25, 255);
            this.EmailBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.EmailBox.PlaceholderText = "Email/Số điện thoại/Username";
            this.EmailBox.SelectedText = "";
            this.EmailBox.Size = new System.Drawing.Size(350, 35);
            this.EmailBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.EmailBox.TabIndex = 2;
            // 
            // LogInLabel
            // 
            this.LogInLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogInLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogInLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInLabel.Location = new System.Drawing.Point(91, 161);
            this.LogInLabel.Name = "LogInLabel";
            this.LogInLabel.Size = new System.Drawing.Size(248, 38);
            this.LogInLabel.TabIndex = 1;
            this.LogInLabel.Text = "Đăng nhập vào Quýt";
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.FillColor = System.Drawing.Color.Transparent;
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
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(GradientBackground1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogInForm";
            this.Text = "Form1";
            GradientBackground1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox Logo;
        private Guna.UI2.WinForms.Guna2HtmlLabel LogInLabel;
        private Guna.UI2.WinForms.Guna2TextBox EmailBox;
        private Guna.UI2.WinForms.Guna2TextBox PasswordBox;
        private Guna.UI2.WinForms.Guna2ControlBox Close;
        private Guna.UI2.WinForms.Guna2Button LogInButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel ForgotPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel HaveAccountLabel;
        private Guna.UI2.WinForms.Guna2Button ToSignUp;
    }
}

