namespace FormAppQuyt
{
    partial class CreateQuizForm
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnImportTxt = new Guna.UI2.WinForms.Guna2Button();
            this.quizName = new Guna.UI2.WinForms.Guna2GroupBox();
            this.questionCountBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblQuestionCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.quizBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.back = new Guna.UI2.WinForms.Guna2Button();
            this.save = new Guna.UI2.WinForms.Guna2Button();
            this.num = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.next = new Guna.UI2.WinForms.Guna2Button();
            this.previous = new Guna.UI2.WinForms.Guna2Button();
            this.add = new Guna.UI2.WinForms.Guna2Button();
            this.delete = new Guna.UI2.WinForms.Guna2Button();
            this.pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.question = new Guna.UI2.WinForms.Guna2GroupBox();
            this.Time = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timeBox = new System.Windows.Forms.ComboBox();
            this.addPic = new Guna.UI2.WinForms.Guna2Button();
            this.quesBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.correct = new Guna.UI2.WinForms.Guna2GroupBox();
            this.correctBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.wrong = new Guna.UI2.WinForms.Guna2GroupBox();
            this.wrongBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.wrongBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.wrongBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1.SuspendLayout();
            this.quizName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.question.SuspendLayout();
            this.correct.SuspendLayout();
            this.wrong.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guna2Panel1.Controls.Add(this.btnImportTxt);
            this.guna2Panel1.Controls.Add(this.quizName);
            this.guna2Panel1.Controls.Add(this.back);
            this.guna2Panel1.Controls.Add(this.save);
            this.guna2Panel1.Controls.Add(this.num);
            this.guna2Panel1.Controls.Add(this.next);
            this.guna2Panel1.Controls.Add(this.previous);
            this.guna2Panel1.Controls.Add(this.add);
            this.guna2Panel1.Controls.Add(this.delete);
            this.guna2Panel1.Controls.Add(this.pic);
            this.guna2Panel1.Controls.Add(this.question);
            this.guna2Panel1.Controls.Add(this.correct);
            this.guna2Panel1.Controls.Add(this.wrong);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 0;
            this.guna2Panel1.ShadowDecoration.Depth = 5;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Size = new System.Drawing.Size(1263, 674);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnImportTxt
            // 
            this.btnImportTxt.BorderRadius = 8;
            this.btnImportTxt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImportTxt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImportTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImportTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImportTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnImportTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportTxt.ForeColor = System.Drawing.Color.White;
            this.btnImportTxt.Location = new System.Drawing.Point(604, 605);
            this.btnImportTxt.Name = "btnImportTxt";
            this.btnImportTxt.Size = new System.Drawing.Size(220, 45);
            this.btnImportTxt.TabIndex = 14;
            this.btnImportTxt.Text = "Chọn file câu hỏi của bạn";
            this.btnImportTxt.Click += new System.EventHandler(this.btnImportTxt_Click);
            // 
            // quizName
            // 
            this.quizName.BorderRadius = 12;
            this.quizName.Controls.Add(this.questionCountBox);
            this.quizName.Controls.Add(this.lblQuestionCount);
            this.quizName.Controls.Add(this.quizBox);
            this.quizName.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.quizName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.quizName.ForeColor = System.Drawing.Color.White;
            this.quizName.Location = new System.Drawing.Point(40, 60);
            this.quizName.Name = "quizName";
            this.quizName.Size = new System.Drawing.Size(520, 130);
            this.quizName.TabIndex = 5;
            this.quizName.Text = "Tên bộ câu hỏi";
            // 
            // questionCountBox
            // 
            this.questionCountBox.BorderRadius = 6;
            this.questionCountBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.questionCountBox.DefaultText = "10";
            this.questionCountBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.questionCountBox.Location = new System.Drawing.Point(120, 85);
            this.questionCountBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.questionCountBox.Name = "questionCountBox";
            this.questionCountBox.PlaceholderText = "";
            this.questionCountBox.SelectedText = "";
            this.questionCountBox.Size = new System.Drawing.Size(100, 32);
            this.questionCountBox.TabIndex = 6;
            // 
            // lblQuestionCount
            // 
            this.lblQuestionCount.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuestionCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblQuestionCount.Location = new System.Drawing.Point(15, 90);
            this.lblQuestionCount.Name = "lblQuestionCount";
            this.lblQuestionCount.Size = new System.Drawing.Size(75, 22);
            this.lblQuestionCount.TabIndex = 5;
            this.lblQuestionCount.Text = "Số câu hỏi:";
            // 
            // quizBox
            // 
            this.quizBox.BorderRadius = 6;
            this.quizBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quizBox.DefaultText = "";
            this.quizBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.quizBox.Location = new System.Drawing.Point(15, 50);
            this.quizBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.quizBox.Name = "quizBox";
            this.quizBox.PlaceholderText = "";
            this.quizBox.SelectedText = "";
            this.quizBox.Size = new System.Drawing.Size(490, 32);
            this.quizBox.TabIndex = 4;
            // 
            // back
            // 
            this.back.BorderRadius = 8;
            this.back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.back.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.back.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(40, 15);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(130, 38);
            this.back.TabIndex = 12;
            this.back.Text = "Quay lại";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // save
            // 
            this.save.BorderRadius = 8;
            this.save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.save.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.save.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(1011, 605);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(227, 45);
            this.save.TabIndex = 11;
            this.save.Text = "Lưu bộ câu hỏi và thoát";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // num
            // 
            this.num.BackColor = System.Drawing.Color.Transparent;
            this.num.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.num.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.num.Location = new System.Drawing.Point(908, 555);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(16, 33);
            this.num.TabIndex = 10;
            this.num.Text = "1";
            // 
            // next
            // 
            this.next.BorderRadius = 8;
            this.next.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.next.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.next.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.next.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.next.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.next.ForeColor = System.Drawing.Color.White;
            this.next.Location = new System.Drawing.Point(1025, 555);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(200, 40);
            this.next.TabIndex = 9;
            this.next.Text = "Câu kế tiếp";
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.BorderRadius = 8;
            this.previous.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.previous.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.previous.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.previous.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.previous.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.previous.ForeColor = System.Drawing.Color.White;
            this.previous.Location = new System.Drawing.Point(615, 555);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(200, 40);
            this.previous.TabIndex = 8;
            this.previous.Text = "Câu trước";
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // add
            // 
            this.add.BorderRadius = 8;
            this.add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(1025, 505);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(200, 40);
            this.add.TabIndex = 7;
            this.add.Text = "Lưu";
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.BorderRadius = 8;
            this.delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Location = new System.Drawing.Point(615, 505);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(200, 40);
            this.delete.TabIndex = 6;
            this.delete.Text = "Xóa câu hỏi";
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            this.pic.Image = global::FormAppQuyt.Properties.Resources.istockphoto_1386740242_612x612;
            this.pic.ImageRotate = 0F;
            this.pic.Location = new System.Drawing.Point(615, 60);
            this.pic.Name = "pic";
            this.pic.ShadowDecoration.BorderRadius = 0;
            this.pic.ShadowDecoration.Enabled = true;
            this.pic.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.pic.Size = new System.Drawing.Size(610, 430);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 6;
            this.pic.TabStop = false;
            // 
            // question
            // 
            this.question.BorderRadius = 12;
            this.question.Controls.Add(this.Time);
            this.question.Controls.Add(this.timeBox);
            this.question.Controls.Add(this.addPic);
            this.question.Controls.Add(this.quesBox);
            this.question.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.question.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.question.ForeColor = System.Drawing.Color.White;
            this.question.Location = new System.Drawing.Point(40, 205);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(520, 145);
            this.question.TabIndex = 5;
            this.question.Text = "Câu hỏi";
            // 
            // Time
            // 
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Time.Location = new System.Drawing.Point(15, 100);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(65, 22);
            this.Time.TabIndex = 6;
            this.Time.Text = "Thời gian";
            // 
            // timeBox
            // 
            this.timeBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timeBox.FormattingEnabled = true;
            this.timeBox.Location = new System.Drawing.Point(110, 97);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(140, 28);
            this.timeBox.TabIndex = 1;
            // 
            // addPic
            // 
            this.addPic.BorderRadius = 6;
            this.addPic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addPic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addPic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addPic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addPic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.addPic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addPic.ForeColor = System.Drawing.Color.White;
            this.addPic.Location = new System.Drawing.Point(305, 95);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(200, 32);
            this.addPic.TabIndex = 5;
            this.addPic.Text = "Thêm ảnh";
            this.addPic.Click += new System.EventHandler(this.addPic_Click);
            // 
            // quesBox
            // 
            this.quesBox.BorderRadius = 6;
            this.quesBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quesBox.DefaultText = "";
            this.quesBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.quesBox.Location = new System.Drawing.Point(15, 50);
            this.quesBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.quesBox.Multiline = true;
            this.quesBox.Name = "quesBox";
            this.quesBox.PlaceholderText = "";
            this.quesBox.SelectedText = "";
            this.quesBox.Size = new System.Drawing.Size(490, 36);
            this.quesBox.TabIndex = 4;
            // 
            // correct
            // 
            this.correct.BorderRadius = 12;
            this.correct.Controls.Add(this.correctBox);
            this.correct.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.correct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.correct.ForeColor = System.Drawing.Color.White;
            this.correct.Location = new System.Drawing.Point(40, 365);
            this.correct.Name = "correct";
            this.correct.Size = new System.Drawing.Size(520, 100);
            this.correct.TabIndex = 2;
            this.correct.Text = "Câu trả lời đúng";
            // 
            // correctBox
            // 
            this.correctBox.BorderRadius = 6;
            this.correctBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.correctBox.DefaultText = "";
            this.correctBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.correctBox.Location = new System.Drawing.Point(15, 52);
            this.correctBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.correctBox.Name = "correctBox";
            this.correctBox.PlaceholderText = "";
            this.correctBox.SelectedText = "";
            this.correctBox.Size = new System.Drawing.Size(490, 32);
            this.correctBox.TabIndex = 4;
            // 
            // wrong
            // 
            this.wrong.BorderRadius = 12;
            this.wrong.Controls.Add(this.wrongBox3);
            this.wrong.Controls.Add(this.wrongBox2);
            this.wrong.Controls.Add(this.wrongBox1);
            this.wrong.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.wrong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.wrong.ForeColor = System.Drawing.Color.White;
            this.wrong.Location = new System.Drawing.Point(40, 480);
            this.wrong.Name = "wrong";
            this.wrong.Size = new System.Drawing.Size(520, 170);
            this.wrong.TabIndex = 2;
            this.wrong.Text = "Câu trả lời sai";
            // 
            // wrongBox3
            // 
            this.wrongBox3.BorderRadius = 6;
            this.wrongBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wrongBox3.DefaultText = "";
            this.wrongBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.wrongBox3.Location = new System.Drawing.Point(15, 125);
            this.wrongBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wrongBox3.Name = "wrongBox3";
            this.wrongBox3.PlaceholderText = "";
            this.wrongBox3.SelectedText = "";
            this.wrongBox3.Size = new System.Drawing.Size(490, 32);
            this.wrongBox3.TabIndex = 7;
            // 
            // wrongBox2
            // 
            this.wrongBox2.BorderRadius = 6;
            this.wrongBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wrongBox2.DefaultText = "";
            this.wrongBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.wrongBox2.Location = new System.Drawing.Point(15, 86);
            this.wrongBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wrongBox2.Name = "wrongBox2";
            this.wrongBox2.PlaceholderText = "";
            this.wrongBox2.SelectedText = "";
            this.wrongBox2.Size = new System.Drawing.Size(490, 32);
            this.wrongBox2.TabIndex = 6;
            // 
            // wrongBox1
            // 
            this.wrongBox1.BorderRadius = 6;
            this.wrongBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wrongBox1.DefaultText = "";
            this.wrongBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.wrongBox1.Location = new System.Drawing.Point(15, 47);
            this.wrongBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wrongBox1.Name = "wrongBox1";
            this.wrongBox1.PlaceholderText = "";
            this.wrongBox1.SelectedText = "";
            this.wrongBox1.Size = new System.Drawing.Size(490, 32);
            this.wrongBox1.TabIndex = 5;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 8;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(1210, 10);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 35);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // CreateQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 675);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateQuizForm";
            this.Text = "Form1";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.quizName.ResumeLayout(false);
            this.quizName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.question.ResumeLayout(false);
            this.question.PerformLayout();
            this.correct.ResumeLayout(false);
            this.wrong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2GroupBox correct;
        private Guna.UI2.WinForms.Guna2GroupBox wrong;
        private Guna.UI2.WinForms.Guna2TextBox correctBox;
        private Guna.UI2.WinForms.Guna2PictureBox pic;
        private Guna.UI2.WinForms.Guna2GroupBox question;
        private Guna.UI2.WinForms.Guna2TextBox quesBox;
        private Guna.UI2.WinForms.Guna2TextBox wrongBox3;
        private Guna.UI2.WinForms.Guna2TextBox wrongBox2;
        private Guna.UI2.WinForms.Guna2TextBox wrongBox1;
        private Guna.UI2.WinForms.Guna2Button next;
        private Guna.UI2.WinForms.Guna2Button previous;
        private Guna.UI2.WinForms.Guna2Button add;
        private Guna.UI2.WinForms.Guna2Button delete;
        private Guna.UI2.WinForms.Guna2Button addPic;
        private Guna.UI2.WinForms.Guna2Button save;
        private Guna.UI2.WinForms.Guna2HtmlLabel num;
        private Guna.UI2.WinForms.Guna2Button back;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GroupBox quizName;
        private Guna.UI2.WinForms.Guna2TextBox quizBox;
        private Guna.UI2.WinForms.Guna2TextBox questionCountBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel Time;
        private System.Windows.Forms.ComboBox timeBox;
        private Guna.UI2.WinForms.Guna2Button btnImportTxt;
    }
}