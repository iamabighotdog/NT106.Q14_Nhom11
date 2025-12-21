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
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
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
            this.guna2Panel1.Size = new System.Drawing.Size(1263, 674);
            this.guna2Panel1.TabIndex = 0;
            // 
            // quizName
            // 
            this.quizName.Controls.Add(this.questionCountBox);
            this.quizName.Controls.Add(this.lblQuestionCount);
            this.quizName.Controls.Add(this.quizBox);
            this.quizName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quizName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.quizName.Location = new System.Drawing.Point(23, 49);
            this.quizName.Name = "quizName";
            this.quizName.Size = new System.Drawing.Size(474, 118);
            this.quizName.TabIndex = 5;
            this.quizName.Text = "Tên bộ câu hỏi";
            // 
            // questionCountBox
            // 
            this.questionCountBox.AutoRoundedCorners = true;
            this.questionCountBox.BackColor = System.Drawing.Color.White;
            this.questionCountBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.questionCountBox.DefaultText = "10";
            this.questionCountBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.questionCountBox.Location = new System.Drawing.Point(110, 86);
            this.questionCountBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.questionCountBox.Name = "questionCountBox";
            this.questionCountBox.PlaceholderText = "";
            this.questionCountBox.SelectedText = "";
            this.questionCountBox.Size = new System.Drawing.Size(100, 28);
            this.questionCountBox.TabIndex = 6;
            // 
            // lblQuestionCount
            // 
            this.lblQuestionCount.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuestionCount.Location = new System.Drawing.Point(4, 90);
            this.lblQuestionCount.Name = "lblQuestionCount";
            this.lblQuestionCount.Size = new System.Drawing.Size(75, 22);
            this.lblQuestionCount.TabIndex = 5;
            this.lblQuestionCount.Text = "Số câu hỏi:";
            // 
            // quizBox
            // 
            this.quizBox.AutoRoundedCorners = true;
            this.quizBox.BackColor = System.Drawing.Color.White;
            this.quizBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quizBox.DefaultText = "";
            this.quizBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.quizBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.quizBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quizBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quizBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.quizBox.Font = new System.Drawing.Font("Segoe UI", 11.89565F);
            this.quizBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.quizBox.Location = new System.Drawing.Point(4, 49);
            this.quizBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.quizBox.Name = "quizBox";
            this.quizBox.PlaceholderText = "";
            this.quizBox.SelectedText = "";
            this.quizBox.Size = new System.Drawing.Size(466, 28);
            this.quizBox.TabIndex = 4;
            // 
            // back
            // 
            this.back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.back.FillColor = System.Drawing.Color.Green;
            this.back.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(121, 41);
            this.back.TabIndex = 12;
            this.back.Text = "Quay lại";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // save
            // 
            this.save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.save.FillColor = System.Drawing.Color.Green;
            this.save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(1054, 603);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(196, 60);
            this.save.TabIndex = 11;
            this.save.Text = "Lưu bộ câu hỏi và thoát";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // num
            // 
            this.num.BackColor = System.Drawing.Color.Transparent;
            this.num.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num.Location = new System.Drawing.Point(845, 558);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(14, 30);
            this.num.TabIndex = 10;
            this.num.Text = "1";
            // 
            // next
            // 
            this.next.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.next.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.next.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.next.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.next.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.next.ForeColor = System.Drawing.Color.White;
            this.next.Location = new System.Drawing.Point(965, 553);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(180, 32);
            this.next.TabIndex = 9;
            this.next.Text = "Câu kế tiếp";
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.previous.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.previous.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.previous.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.previous.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.previous.ForeColor = System.Drawing.Color.White;
            this.previous.Location = new System.Drawing.Point(558, 553);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(180, 32);
            this.previous.TabIndex = 8;
            this.previous.Text = "Câu trước";
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // add
            // 
            this.add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(965, 495);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(180, 32);
            this.add.TabIndex = 7;
            this.add.Text = "Lưu";
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.delete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Location = new System.Drawing.Point(558, 495);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(180, 32);
            this.delete.TabIndex = 6;
            this.delete.Text = "Xóa câu hỏi";
            // 
            // pic
            // 
            this.pic.Image = global::FormAppQuyt.Properties.Resources.istockphoto_1386740242_612x612;
            this.pic.ImageRotate = 0F;
            this.pic.Location = new System.Drawing.Point(558, 61);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(587, 405);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 6;
            this.pic.TabStop = false;
            // 
            // question
            // 
            this.question.Controls.Add(this.Time);
            this.question.Controls.Add(this.timeBox);
            this.question.Controls.Add(this.addPic);
            this.question.Controls.Add(this.quesBox);
            this.question.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.question.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.question.Location = new System.Drawing.Point(23, 173);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(474, 136);
            this.question.TabIndex = 5;
            this.question.Text = "Câu hỏi";
            // 
            // Time
            // 
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Segoe UI", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.Black;
            this.Time.Location = new System.Drawing.Point(14, 94);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(84, 30);
            this.Time.TabIndex = 6;
            this.Time.Text = "Thời gian";
            // 
            // timeBox
            // 
            this.timeBox.FormattingEnabled = true;
            this.timeBox.Location = new System.Drawing.Point(102, 94);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(133, 28);
            this.timeBox.TabIndex = 1;
            // 
            // addPic
            // 
            this.addPic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addPic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addPic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addPic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addPic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addPic.ForeColor = System.Drawing.Color.White;
            this.addPic.Location = new System.Drawing.Point(290, 94);
            this.addPic.Name = "addPic";
            this.addPic.Size = new System.Drawing.Size(180, 27);
            this.addPic.TabIndex = 5;
            this.addPic.Text = "Thêm ảnh";
            this.addPic.Click += new System.EventHandler(this.addPic_Click);
            // 
            // quesBox
            // 
            this.quesBox.AutoRoundedCorners = true;
            this.quesBox.BackColor = System.Drawing.Color.White;
            this.quesBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quesBox.DefaultText = "";
            this.quesBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.quesBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.quesBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quesBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quesBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.quesBox.Font = new System.Drawing.Font("Segoe UI", 11.89565F);
            this.quesBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.quesBox.Location = new System.Drawing.Point(4, 58);
            this.quesBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.quesBox.Name = "quesBox";
            this.quesBox.PlaceholderText = "";
            this.quesBox.SelectedText = "";
            this.quesBox.Size = new System.Drawing.Size(466, 28);
            this.quesBox.TabIndex = 4;
            // 
            // correct
            // 
            this.correct.Controls.Add(this.correctBox);
            this.correct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.correct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.correct.Location = new System.Drawing.Point(23, 315);
            this.correct.Name = "correct";
            this.correct.Size = new System.Drawing.Size(474, 118);
            this.correct.TabIndex = 2;
            this.correct.Text = "Câu trả lời đúng";
            // 
            // correctBox
            // 
            this.correctBox.AutoRoundedCorners = true;
            this.correctBox.BackColor = System.Drawing.Color.White;
            this.correctBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.correctBox.DefaultText = "";
            this.correctBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.correctBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.correctBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.correctBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.correctBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.correctBox.Font = new System.Drawing.Font("Segoe UI", 11.89565F);
            this.correctBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.correctBox.Location = new System.Drawing.Point(4, 58);
            this.correctBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.correctBox.Name = "correctBox";
            this.correctBox.PlaceholderText = "";
            this.correctBox.SelectedText = "";
            this.correctBox.Size = new System.Drawing.Size(466, 28);
            this.correctBox.TabIndex = 4;
            // 
            // wrong
            // 
            this.wrong.Controls.Add(this.wrongBox3);
            this.wrong.Controls.Add(this.wrongBox2);
            this.wrong.Controls.Add(this.wrongBox1);
            this.wrong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.wrong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.wrong.Location = new System.Drawing.Point(23, 439);
            this.wrong.Name = "wrong";
            this.wrong.Size = new System.Drawing.Size(474, 184);
            this.wrong.TabIndex = 2;
            this.wrong.Text = "Câu trả lời sai";
            // 
            // wrongBox3
            // 
            this.wrongBox3.AutoRoundedCorners = true;
            this.wrongBox3.BackColor = System.Drawing.Color.White;
            this.wrongBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wrongBox3.DefaultText = "";
            this.wrongBox3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.wrongBox3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.wrongBox3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wrongBox3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wrongBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wrongBox3.Font = new System.Drawing.Font("Segoe UI", 11.89565F);
            this.wrongBox3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wrongBox3.Location = new System.Drawing.Point(4, 132);
            this.wrongBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wrongBox3.Name = "wrongBox3";
            this.wrongBox3.PlaceholderText = "";
            this.wrongBox3.SelectedText = "";
            this.wrongBox3.Size = new System.Drawing.Size(466, 28);
            this.wrongBox3.TabIndex = 7;
            // 
            // wrongBox2
            // 
            this.wrongBox2.AutoRoundedCorners = true;
            this.wrongBox2.BackColor = System.Drawing.Color.White;
            this.wrongBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wrongBox2.DefaultText = "";
            this.wrongBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.wrongBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.wrongBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wrongBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wrongBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wrongBox2.Font = new System.Drawing.Font("Segoe UI", 11.89565F);
            this.wrongBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wrongBox2.Location = new System.Drawing.Point(4, 94);
            this.wrongBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wrongBox2.Name = "wrongBox2";
            this.wrongBox2.PlaceholderText = "";
            this.wrongBox2.SelectedText = "";
            this.wrongBox2.Size = new System.Drawing.Size(466, 28);
            this.wrongBox2.TabIndex = 6;
            // 
            // wrongBox1
            // 
            this.wrongBox1.AutoRoundedCorners = true;
            this.wrongBox1.BackColor = System.Drawing.Color.White;
            this.wrongBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wrongBox1.DefaultText = "";
            this.wrongBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.wrongBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.wrongBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wrongBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wrongBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wrongBox1.Font = new System.Drawing.Font("Segoe UI", 11.89565F);
            this.wrongBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wrongBox1.Location = new System.Drawing.Point(4, 56);
            this.wrongBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wrongBox1.Name = "wrongBox1";
            this.wrongBox1.PlaceholderText = "";
            this.wrongBox1.SelectedText = "";
            this.wrongBox1.Size = new System.Drawing.Size(466, 28);
            this.wrongBox1.TabIndex = 5;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1218, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // createQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 675);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "createQuiz";
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
    }
}