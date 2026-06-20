namespace SSMS
{
    partial class teacher_register
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
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            btnTeacherRegister = new Button();
            btnStudentRegister = new Button();
            btnTimetable = new Button();
            btnTeacherAttendance = new Button();
            btnProfile = new Button();
            btnNoticeCreate = new Button();
            btnLogout = new Button();
            lblSystemTitle = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            label2 = new Label();
            txtFirstName = new TextBox();
            label3 = new Label();
            txtLastName = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtPhone = new TextBox();
            label6 = new Label();
            cmbQualification = new ComboBox();
            button1 = new Button();
            btnRegisterTeacher = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnLogout);
            splitContainer1.Panel1.Controls.Add(btnNoticeCreate);
            splitContainer1.Panel1.Controls.Add(btnProfile);
            splitContainer1.Panel1.Controls.Add(btnTeacherAttendance);
            splitContainer1.Panel1.Controls.Add(btnTimetable);
            splitContainer1.Panel1.Controls.Add(btnStudentRegister);
            splitContainer1.Panel1.Controls.Add(btnTeacherRegister);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(245, 247, 245);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(lblSystemTitle);
            splitContainer1.Panel2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(0, 120, 70);
            splitContainer1.Size = new Size(1150, 708);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(90, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnTeacherRegister
            // 
            btnTeacherRegister.BackColor = Color.FromArgb(225, 245, 230);
            btnTeacherRegister.FlatAppearance.BorderSize = 0;
            btnTeacherRegister.FlatStyle = FlatStyle.Flat;
            btnTeacherRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTeacherRegister.ForeColor = Color.FromArgb(0, 120, 70);
            btnTeacherRegister.Location = new Point(0, 160);
            btnTeacherRegister.Name = "btnTeacherRegister";
            btnTeacherRegister.Size = new Size(280, 45);
            btnTeacherRegister.TabIndex = 1;
            btnTeacherRegister.Text = "Teacher Register";
            btnTeacherRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnTeacherRegister.UseVisualStyleBackColor = false;
            // 
            // btnStudentRegister
            // 
            btnStudentRegister.FlatAppearance.BorderSize = 0;
            btnStudentRegister.FlatStyle = FlatStyle.Flat;
            btnStudentRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudentRegister.Location = new Point(0, 205);
            btnStudentRegister.Name = "btnStudentRegister";
            btnStudentRegister.Size = new Size(280, 45);
            btnStudentRegister.TabIndex = 2;
            btnStudentRegister.Text = "Student Register";
            btnStudentRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnStudentRegister.UseVisualStyleBackColor = true;
            // 
            // btnTimetable
            // 
            btnTimetable.FlatAppearance.BorderSize = 0;
            btnTimetable.FlatStyle = FlatStyle.Flat;
            btnTimetable.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimetable.Location = new Point(0, 250);
            btnTimetable.Name = "btnTimetable";
            btnTimetable.Size = new Size(280, 45);
            btnTimetable.TabIndex = 3;
            btnTimetable.Text = "Timetable";
            btnTimetable.TextAlign = ContentAlignment.MiddleLeft;
            btnTimetable.UseVisualStyleBackColor = true;
            btnTimetable.Click += this.button1_Click;
            // 
            // btnTeacherAttendance
            // 
            btnTeacherAttendance.FlatAppearance.BorderSize = 0;
            btnTeacherAttendance.FlatStyle = FlatStyle.Flat;
            btnTeacherAttendance.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTeacherAttendance.Location = new Point(0, 295);
            btnTeacherAttendance.Name = "btnTeacherAttendance";
            btnTeacherAttendance.Size = new Size(280, 45);
            btnTeacherAttendance.TabIndex = 4;
            btnTeacherAttendance.Text = "Teacher Attendence";
            btnTeacherAttendance.TextAlign = ContentAlignment.MiddleLeft;
            btnTeacherAttendance.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProfile.Location = new Point(0, 340);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(280, 45);
            btnProfile.TabIndex = 5;
            btnProfile.Text = "Profile";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnNoticeCreate
            // 
            btnNoticeCreate.FlatAppearance.BorderSize = 0;
            btnNoticeCreate.FlatStyle = FlatStyle.Flat;
            btnNoticeCreate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNoticeCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnNoticeCreate.Location = new Point(0, 385);
            btnNoticeCreate.Name = "btnNoticeCreate";
            btnNoticeCreate.Size = new Size(280, 45);
            btnNoticeCreate.TabIndex = 6;
            btnNoticeCreate.Text = "Notice Create";
            btnNoticeCreate.TextAlign = ContentAlignment.MiddleLeft;
            btnNoticeCreate.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(0, 430);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(280, 45);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.AutoSize = true;
            lblSystemTitle.Location = new Point(40, 35);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(454, 31);
            lblSystemTitle.TabIndex = 0;
            lblSystemTitle.Text = "SMART SCHOOL MANAGEMENT SYSTEM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(40, 70);
            label1.Name = "label1";
            label1.Size = new Size(268, 25);
            label1.TabIndex = 1;
            label1.Text = "Welcome, Mr. John (Principal)";
            label1.Click += this.label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(800, 35);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 45);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnRegisterTeacher);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(cmbQualification);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtFirstName);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(40, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 560);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(40, 35);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 0;
            label2.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(40, 65);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(340, 38);
            txtFirstName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(420, 35);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 2;
            label3.Text = "Last Nme";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(420, 65);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(340, 38);
            txtLastName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(40, 125);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 4;
            label4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(40, 155);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(340, 38);
            txtEmail.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(420, 125);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 6;
            label5.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(420, 155);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(340, 38);
            txtPhone.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(40, 215);
            label6.Name = "label6";
            label6.Size = new Size(122, 25);
            label6.TabIndex = 8;
            label6.Text = "Qualification";
            // 
            // cmbQualification
            // 
            cmbQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQualification.FormattingEnabled = true;
            cmbQualification.Location = new Point(40, 245);
            cmbQualification.Name = "cmbQualification";
            cmbQualification.Size = new Size(340, 39);
            cmbQualification.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 135, 80);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(420, 240);
            button1.Name = "button1";
            button1.Size = new Size(340, 42);
            button1.TabIndex = 10;
            button1.Text = "Generate Employee ID";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnRegisterTeacher
            // 
            btnRegisterTeacher.BackColor = Color.FromArgb(0, 135, 80);
            btnRegisterTeacher.FlatAppearance.BorderSize = 0;
            btnRegisterTeacher.FlatStyle = FlatStyle.Flat;
            btnRegisterTeacher.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegisterTeacher.ForeColor = Color.White;
            btnRegisterTeacher.Location = new Point(420, 460);
            btnRegisterTeacher.Name = "btnRegisterTeacher";
            btnRegisterTeacher.Size = new Size(340, 42);
            btnRegisterTeacher.TabIndex = 11;
            btnRegisterTeacher.Text = "Register Teacher";
            btnRegisterTeacher.UseVisualStyleBackColor = false;
            // 
            // teacher_register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 708);
            Controls.Add(splitContainer1);
            Name = "teacher_register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnStudentRegister;
        private Button btnTeacherRegister;
        private PictureBox pictureBox1;
        private Button btnTeacherAttendance;
        private Button btnTimetable;
        private Button btnProfile;
        private Button btnLogout;
        private Button btnNoticeCreate;
        private Label lblSystemTitle;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label4;
        private TextBox txtLastName;
        private Label label3;
        private TextBox txtFirstName;
        private Label label2;
        private Label label6;
        private TextBox txtPhone;
        private Label label5;
        private TextBox txtEmail;
        private Button btnRegisterTeacher;
        private Button button1;
        private ComboBox cmbQualification;
    }
}