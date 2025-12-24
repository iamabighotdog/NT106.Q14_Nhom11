namespace FormAppQuyt
{
    partial class PlayHostForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.rankPopup1 = new FormAppQuyt.RankPopup();
            this.ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.playBtn = new Guna.UI2.WinForms.Guna2Button();
            this.players = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.back = new Guna.UI2.WinForms.Guna2Button();
            this.answerD = new Guna.UI2.WinForms.Guna2Button();
            this.answerC = new Guna.UI2.WinForms.Guna2Button();
            this.answerB = new Guna.UI2.WinForms.Guna2Button();
            this.pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.question = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.answerA = new Guna.UI2.WinForms.Guna2Button();
            this.close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.rankPopup1);
            this.guna2GradientPanel1.Controls.Add(this.ProgressBar1);
            this.guna2GradientPanel1.Controls.Add(this.playBtn);
            this.guna2GradientPanel1.Controls.Add(this.players);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GradientPanel1.Controls.Add(this.ID);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel1.Controls.Add(this.back);
            this.guna2GradientPanel1.Controls.Add(this.answerD);
            this.guna2GradientPanel1.Controls.Add(this.answerC);
            this.guna2GradientPanel1.Controls.Add(this.answerB);
            this.guna2GradientPanel1.Controls.Add(this.pic);
            this.guna2GradientPanel1.Controls.Add(this.question);
            this.guna2GradientPanel1.Controls.Add(this.answerA);
            this.guna2GradientPanel1.Controls.Add(this.close);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1263, 675);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // rankPopup1
            // 
            this.rankPopup1.Location = new System.Drawing.Point(511, 0);
            this.rankPopup1.Name = "rankPopup1";
            this.rankPopup1.Size = new System.Drawing.Size(752, 672);
            this.rankPopup1.TabIndex = 19;
            this.rankPopup1.Visible = false;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(60)))));
            this.ProgressBar1.BorderRadius = 12;
            this.ProgressBar1.BorderThickness = 2;
            this.ProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.ProgressBar1.Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Bold);
            this.ProgressBar1.ForeColor = System.Drawing.Color.White;
            this.ProgressBar1.Location = new System.Drawing.Point(511, 560);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.ProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.ProgressBar1.ShowText = true;
            this.ProgressBar1.Size = new System.Drawing.Size(706, 35);
            this.ProgressBar1.TabIndex = 18;
            this.ProgressBar1.Text = "1000";
            this.ProgressBar1.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Custom;
            this.ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // playBtn
            // 
            this.playBtn.BackColor = System.Drawing.Color.Transparent;
            this.playBtn.BorderRadius = 15;
            this.playBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.playBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.playBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.playBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.playBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.playBtn.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.playBtn.ForeColor = System.Drawing.Color.White;
            this.playBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.playBtn.Location = new System.Drawing.Point(895, 602);
            this.playBtn.Name = "playBtn";
            this.playBtn.ShadowDecoration.BorderRadius = 15;
            this.playBtn.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.playBtn.ShadowDecoration.Depth = 15;
            this.playBtn.ShadowDecoration.Enabled = true;
            this.playBtn.Size = new System.Drawing.Size(322, 65);
            this.playBtn.TabIndex = 16;
            this.playBtn.Text = "Chơi";
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // players
            // 
            this.players.BackColor = System.Drawing.Color.Transparent;
            this.players.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold);
            this.players.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(100)))));
            this.players.Location = new System.Drawing.Point(239, 631);
            this.players.Name = "players";
            this.players.Size = new System.Drawing.Size(14, 32);
            this.players.TabIndex = 15;
            this.players.Text = "0";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Poppins", 10F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(170, 631);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(68, 32);
            this.guna2HtmlLabel2.TabIndex = 14;
            this.guna2HtmlLabel2.Text = "Players: ";
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.Transparent;
            this.ID.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold);
            this.ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(100)))));
            this.ID.Location = new System.Drawing.Point(95, 631);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(63, 32);
            this.ID.TabIndex = 13;
            this.ID.Text = "xxxxxx";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Poppins", 10F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 631);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(78, 32);
            this.guna2HtmlLabel1.TabIndex = 12;
            this.guna2HtmlLabel1.Text = "Room ID: ";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.BorderRadius = 15;
            this.back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.back.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.back.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.back.Location = new System.Drawing.Point(511, 602);
            this.back.Name = "back";
            this.back.ShadowDecoration.BorderRadius = 15;
            this.back.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.back.ShadowDecoration.Depth = 15;
            this.back.ShadowDecoration.Enabled = true;
            this.back.Size = new System.Drawing.Size(322, 65);
            this.back.TabIndex = 11;
            this.back.Text = "Quay lại";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // answerD
            // 
            this.answerD.BackColor = System.Drawing.Color.Transparent;
            this.answerD.BorderRadius = 15;
            this.answerD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.answerD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.answerD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.answerD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.answerD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.answerD.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold);
            this.answerD.ForeColor = System.Drawing.Color.White;
            this.answerD.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.answerD.Location = new System.Drawing.Point(30, 471);
            this.answerD.Name = "answerD";
            this.answerD.ShadowDecoration.BorderRadius = 15;
            this.answerD.ShadowDecoration.Depth = 10;
            this.answerD.ShadowDecoration.Enabled = true;
            this.answerD.Size = new System.Drawing.Size(460, 83);
            this.answerD.TabIndex = 9;
            this.answerD.Text = "D";
            this.answerD.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // answerC
            // 
            this.answerC.BackColor = System.Drawing.Color.Transparent;
            this.answerC.BorderRadius = 15;
            this.answerC.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.answerC.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.answerC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.answerC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.answerC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.answerC.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold);
            this.answerC.ForeColor = System.Drawing.Color.White;
            this.answerC.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.answerC.Location = new System.Drawing.Point(30, 351);
            this.answerC.Name = "answerC";
            this.answerC.ShadowDecoration.BorderRadius = 15;
            this.answerC.ShadowDecoration.Depth = 10;
            this.answerC.ShadowDecoration.Enabled = true;
            this.answerC.Size = new System.Drawing.Size(460, 83);
            this.answerC.TabIndex = 8;
            this.answerC.Text = "C";
            this.answerC.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // answerB
            // 
            this.answerB.BackColor = System.Drawing.Color.Transparent;
            this.answerB.BorderRadius = 15;
            this.answerB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.answerB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.answerB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.answerB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.answerB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.answerB.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold);
            this.answerB.ForeColor = System.Drawing.Color.White;
            this.answerB.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.answerB.Location = new System.Drawing.Point(30, 231);
            this.answerB.Name = "answerB";
            this.answerB.ShadowDecoration.BorderRadius = 15;
            this.answerB.ShadowDecoration.Depth = 10;
            this.answerB.ShadowDecoration.Enabled = true;
            this.answerB.Size = new System.Drawing.Size(460, 83);
            this.answerB.TabIndex = 7;
            this.answerB.Text = "B";
            this.answerB.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            this.pic.BorderRadius = 20;
            this.pic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.pic.Image = global::FormAppQuyt.Properties.Resources.istockphoto_1386740242_612x612;
            this.pic.ImageRotate = 0F;
            this.pic.Location = new System.Drawing.Point(511, 111);
            this.pic.Name = "pic";
            this.pic.ShadowDecoration.BorderRadius = 20;
            this.pic.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pic.ShadowDecoration.Depth = 20;
            this.pic.ShadowDecoration.Enabled = true;
            this.pic.Size = new System.Drawing.Size(706, 443);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 6;
            this.pic.TabStop = false;
            // 
            // question
            // 
            this.question.BackColor = System.Drawing.Color.Transparent;
            this.question.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold);
            this.question.ForeColor = System.Drawing.Color.White;
            this.question.Location = new System.Drawing.Point(12, 12);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(142, 55);
            this.question.TabIndex = 5;
            this.question.Text = "Question";
            // 
            // answerA
            // 
            this.answerA.BackColor = System.Drawing.Color.Transparent;
            this.answerA.BorderRadius = 15;
            this.answerA.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.answerA.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.answerA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.answerA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.answerA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.answerA.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold);
            this.answerA.ForeColor = System.Drawing.Color.White;
            this.answerA.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.answerA.Location = new System.Drawing.Point(30, 111);
            this.answerA.Name = "answerA";
            this.answerA.ShadowDecoration.BorderRadius = 15;
            this.answerA.ShadowDecoration.Depth = 10;
            this.answerA.ShadowDecoration.Enabled = true;
            this.answerA.Size = new System.Drawing.Size(460, 83);
            this.answerA.TabIndex = 1;
            this.answerA.Text = "A";
            this.answerA.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.BorderRadius = 8;
            this.close.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.close.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.close.IconColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(1210, 8);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(45, 35);
            this.close.TabIndex = 0;
            // 
            // PlayHostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 675);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayHostForm";
            this.Text = "Play";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox close;
        private Guna.UI2.WinForms.Guna2Button answerA;
        private Guna.UI2.WinForms.Guna2PictureBox pic;
        private Guna.UI2.WinForms.Guna2HtmlLabel question;
        private Guna.UI2.WinForms.Guna2Button answerD;
        private Guna.UI2.WinForms.Guna2Button answerC;
        private Guna.UI2.WinForms.Guna2Button answerB;
        private Guna.UI2.WinForms.Guna2Button back;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel ID;
        private Guna.UI2.WinForms.Guna2Button playBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel players;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBar1;
        private RankPopup rankPopup1;
    }
}