
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
            this.Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.PhoneNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PhoneNumberLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Email = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.EmailLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.UsernameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Welcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Close = new Guna.UI2.WinForms.Guna2ControlBox();
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
            this.GradientPanel.Margin = new System.Windows.Forms.Padding(2);
            this.GradientPanel.Name = "GradientPanel";
            this.GradientPanel.Size = new System.Drawing.Size(768, 585);
            this.GradientPanel.TabIndex = 0;
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.PhoneNumber);
            this.Panel.Controls.Add(this.PhoneNumberLabel);
            this.Panel.Controls.Add(this.Email);
            this.Panel.Controls.Add(this.EmailLabel);
            this.Panel.Controls.Add(this.Username);
            this.Panel.Controls.Add(this.UsernameLabel);
            this.Panel.Controls.Add(this.Welcome);
            this.Panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel.Location = new System.Drawing.Point(234, 55);
            this.Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(300, 488);
            this.Panel.TabIndex = 1;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.PhoneNumber.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumber.Location = new System.Drawing.Point(129, 260);
            this.PhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(73, 23);
            this.PhoneNumber.TabIndex = 7;
            this.PhoneNumber.Text = "xxxxxxxxxx";
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumberLabel.Location = new System.Drawing.Point(31, 260);
            this.PhoneNumberLabel.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(97, 23);
            this.PhoneNumberLabel.TabIndex = 6;
            this.PhoneNumberLabel.Text = "Số điện thoại: ";
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.Transparent;
            this.Email.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(80, 200);
            this.Email.Margin = new System.Windows.Forms.Padding(2);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(128, 23);
            this.Email.TabIndex = 5;
            this.Email.Text = "Email@gmail.com";
            // 
            // EmailLabel
            // 
            this.EmailLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmailLabel.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(31, 200);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(44, 23);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email:";
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.Transparent;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(110, 144);
            this.Username.Margin = new System.Windows.Forms.Padding(2);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(74, 23);
            this.Username.TabIndex = 3;
            this.Username.Text = "Username";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(31, 144);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(77, 23);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username:";
            // 
            // Welcome
            // 
            this.Welcome.BackColor = System.Drawing.Color.Transparent;
            this.Welcome.Font = new System.Drawing.Font("Segoe UI Semibold", 18.15652F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome.Location = new System.Drawing.Point(32, 50);
            this.Welcome.Margin = new System.Windows.Forms.Padding(2);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(130, 34);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "Chào mừng";
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Close.HoverState.FillColor = System.Drawing.Color.Red;
            this.Close.IconColor = System.Drawing.Color.Black;
            this.Close.Location = new System.Drawing.Point(734, 0);
            this.Close.Margin = new System.Windows.Forms.Padding(2);
            this.Close.Name = "Close";
            this.Close.PressedColor = System.Drawing.Color.Red;
            this.Close.Size = new System.Drawing.Size(34, 24);
            this.Close.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 585);
            this.Controls.Add(this.GradientPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.GradientPanel.ResumeLayout(false);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel GradientPanel;
        private Guna.UI2.WinForms.Guna2Panel Panel;
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