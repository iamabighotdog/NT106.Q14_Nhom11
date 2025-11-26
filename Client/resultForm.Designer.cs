namespace FormAppQuyt
{
    partial class resultForm
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
            this.refresh = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.exitToMenu = new Guna.UI2.WinForms.Guna2Button();
            this.newGame = new Guna.UI2.WinForms.Guna2Button();
            this.leaderboard = new Guna.UI2.WinForms.Guna2GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.refresh.SuspendLayout();
            this.leaderboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // refresh
            // 
            this.refresh.Controls.Add(this.guna2Button1);
            this.refresh.Controls.Add(this.exitToMenu);
            this.refresh.Controls.Add(this.newGame);
            this.refresh.Controls.Add(this.leaderboard);
            this.refresh.Controls.Add(this.guna2ControlBox1);
            this.refresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.refresh.Location = new System.Drawing.Point(0, 0);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(1262, 677);
            this.refresh.TabIndex = 0;
            // 
            // exitToMenu
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Green;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(541, 603);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Làm mới";
            // 
            // exitToMenu
            // 
            this.exitToMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitToMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitToMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitToMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitToMenu.FillColor = System.Drawing.Color.Green;
            this.exitToMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitToMenu.ForeColor = System.Drawing.Color.White;
            this.exitToMenu.Location = new System.Drawing.Point(276, 603);
            this.exitToMenu.Name = "exitToMenu";
            this.exitToMenu.Size = new System.Drawing.Size(180, 45);
            this.exitToMenu.TabIndex = 3;
            this.exitToMenu.Text = "Thoát ra menu";
            // 
            // newGame
            // 
            this.newGame.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.newGame.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.newGame.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.newGame.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.newGame.FillColor = System.Drawing.Color.Green;
            this.newGame.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.newGame.ForeColor = System.Drawing.Color.White;
            this.newGame.Location = new System.Drawing.Point(806, 603);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(180, 45);
            this.newGame.TabIndex = 2;
            this.newGame.Text = "Chơi tiếp";
            // 
            // leaderboard
            // 
            this.leaderboard.Controls.Add(this.listView1);
            this.leaderboard.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.leaderboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.leaderboard.Font = new System.Drawing.Font("Segoe UI", 16.27826F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboard.ForeColor = System.Drawing.Color.Black;
            this.leaderboard.Location = new System.Drawing.Point(276, 80);
            this.leaderboard.Name = "leaderboard";
            this.leaderboard.Size = new System.Drawing.Size(710, 517);
            this.leaderboard.TabIndex = 1;
            this.leaderboard.Text = "Kết quả ";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(710, 477);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1217, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // resultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 675);
            this.Controls.Add(this.refresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "resultForm";
            this.Text = "resultForm";
            this.refresh.ResumeLayout(false);
            this.leaderboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel refresh;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2GroupBox leaderboard;
        private Guna.UI2.WinForms.Guna2Button exitToMenu;
        private Guna.UI2.WinForms.Guna2Button newGame;
        private System.Windows.Forms.ListView listView1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}