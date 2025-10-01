
namespace FormAppQuyt
{
    partial class Main
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
            this.GradientPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Welcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.UsernameWelcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.UsernameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.EmailLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Email = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PhoneNumberLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PhoneNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GradientPanel.SuspendLayout();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GradientPanel
            // 
            this.GradientPanel.Controls.Add(this.Panel);
            this.GradientPanel.Controls.Add(this.Close);
            this.GradientPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.GradientPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.GradientPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.GradientPanel.Location = new System.Drawing.Point(0, 0);
            this.GradientPanel.Name = "GradientPanel";
            this.GradientPanel.Size = new System.Drawing.Size(1024, 720);
            this.GradientPanel.TabIndex = 0;
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
            this.Close.Size = new System.Drawing.Size(45, 29);
            this.Close.TabIndex = 0;
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.PhoneNumber);
            this.Panel.Controls.Add(this.PhoneNumberLabel);
            this.Panel.Controls.Add(this.Email);
            this.Panel.Controls.Add(this.EmailLabel);
            this.Panel.Controls.Add(this.Username);
            this.Panel.Controls.Add(this.UsernameLabel);
            this.Panel.Controls.Add(this.UsernameWelcome);
            this.Panel.Controls.Add(this.Welcome);
            this.Panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel.Location = new System.Drawing.Point(312, 60);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(400, 600);
            this.Panel.TabIndex = 1;
            // 
            // Welcome
            // 
            this.Welcome.BackColor = System.Drawing.Color.Transparent;
            this.Welcome.Font = new System.Drawing.Font("Segoe UI Semibold", 18.15652F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome.Location = new System.Drawing.Point(51, 112);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(156, 42);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "Chào mừng";
            // 
            // UsernameWelcome
            // 
            this.UsernameWelcome.BackColor = System.Drawing.Color.Transparent;
            this.UsernameWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 18.15652F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameWelcome.Location = new System.Drawing.Point(213, 112);
            this.UsernameWelcome.Name = "UsernameWelcome";
            this.UsernameWelcome.Size = new System.Drawing.Size(135, 42);
            this.UsernameWelcome.TabIndex = 1;
            this.UsernameWelcome.Text = "Username";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(3, 198);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(92, 27);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username:";
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.Transparent;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(101, 198);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(88, 27);
            this.Username.TabIndex = 3;
            this.Username.Text = "Username";
            // 
            // EmailLabel
            // 
            this.EmailLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmailLabel.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(3, 231);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(53, 27);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email:";
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.Transparent;
            this.Email.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(62, 231);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(154, 27);
            this.Email.TabIndex = 5;
            this.Email.Text = "Email@gmail.com";
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumberLabel.Location = new System.Drawing.Point(3, 264);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(118, 27);
            this.PhoneNumberLabel.TabIndex = 6;
            this.PhoneNumberLabel.Text = "Số điện thoại: ";
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.PhoneNumber.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumber.Location = new System.Drawing.Point(127, 264);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(93, 27);
            this.PhoneNumber.TabIndex = 7;
            this.PhoneNumber.Text = "xxxxxxxxxx";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.GradientPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Main";
            this.GradientPanel.ResumeLayout(false);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.Main_Load);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel GradientPanel;
        private Guna.UI2.WinForms.Guna2Panel Panel;
        private Guna.UI2.WinForms.Guna2HtmlLabel UsernameWelcome;
        private Guna.UI2.WinForms.Guna2HtmlLabel Welcome;
        private Guna.UI2.WinForms.Guna2ControlBox Close;
        private Guna.UI2.WinForms.Guna2HtmlLabel PhoneNumber;
        private Guna.UI2.WinForms.Guna2HtmlLabel PhoneNumberLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel Email;
        private Guna.UI2.WinForms.Guna2HtmlLabel EmailLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel Username;
        private Guna.UI2.WinForms.Guna2HtmlLabel UsernameLabel;
    }
}