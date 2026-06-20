namespace SSMS
{
    partial class Form1
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
            btnLogout = new Button();
            btnNoticeCreate = new Button();
            btnProfile = new Button();
            btnTeacherAttendance = new Button();
            btnTimetable = new Button();
            btnStudentRegister = new Button();
            btnTeacherRegister = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            cmbFilterClass = new ComboBox();
            label4 = new Label();
            cmbFilterDay = new ComboBox();
            dgvTimetable = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            Teacher = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            label5 = new Label();
            label6 = new Label();
            cmbAssignClass = new ComboBox();
            cmbAssignTeacher1 = new ComboBox();
            cmbAssignTeacher2 = new ComboBox();
            cmbAssignTeacher3 = new ComboBox();
            btnAssignTime = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTimetable).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnLogout.ImeMode = ImeMode.NoControl;
            btnLogout.Location = new Point(3, 431);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(280, 45);
            btnLogout.TabIndex = 17;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNoticeCreate
            // 
            btnNoticeCreate.BackColor = Color.White;
            btnNoticeCreate.FlatAppearance.BorderSize = 0;
            btnNoticeCreate.FlatStyle = FlatStyle.Flat;
            btnNoticeCreate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnNoticeCreate.ImeMode = ImeMode.NoControl;
            btnNoticeCreate.Location = new Point(3, 386);
            btnNoticeCreate.Name = "btnNoticeCreate";
            btnNoticeCreate.Size = new Size(280, 45);
            btnNoticeCreate.TabIndex = 16;
            btnNoticeCreate.Text = "Notice Create";
            btnNoticeCreate.TextAlign = ContentAlignment.MiddleLeft;
            btnNoticeCreate.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.White;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnProfile.ImeMode = ImeMode.NoControl;
            btnProfile.Location = new Point(3, 341);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(280, 45);
            btnProfile.TabIndex = 15;
            btnProfile.Text = "Profile";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnTeacherAttendance
            // 
            btnTeacherAttendance.BackColor = Color.White;
            btnTeacherAttendance.FlatAppearance.BorderSize = 0;
            btnTeacherAttendance.FlatStyle = FlatStyle.Flat;
            btnTeacherAttendance.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTeacherAttendance.ImeMode = ImeMode.NoControl;
            btnTeacherAttendance.Location = new Point(3, 296);
            btnTeacherAttendance.Name = "btnTeacherAttendance";
            btnTeacherAttendance.Size = new Size(280, 45);
            btnTeacherAttendance.TabIndex = 14;
            btnTeacherAttendance.Text = "Teacher Attendence";
            btnTeacherAttendance.TextAlign = ContentAlignment.MiddleLeft;
            btnTeacherAttendance.UseVisualStyleBackColor = false;
            // 
            // btnTimetable
            // 
            btnTimetable.BackColor = Color.White;
            btnTimetable.FlatAppearance.BorderSize = 0;
            btnTimetable.FlatStyle = FlatStyle.Flat;
            btnTimetable.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTimetable.ImeMode = ImeMode.NoControl;
            btnTimetable.Location = new Point(3, 251);
            btnTimetable.Name = "btnTimetable";
            btnTimetable.Size = new Size(280, 45);
            btnTimetable.TabIndex = 13;
            btnTimetable.Text = "Timetable";
            btnTimetable.TextAlign = ContentAlignment.MiddleLeft;
            btnTimetable.UseVisualStyleBackColor = false;
            // 
            // btnStudentRegister
            // 
            btnStudentRegister.BackColor = Color.FromArgb(225, 245, 230);
            btnStudentRegister.FlatAppearance.BorderSize = 0;
            btnStudentRegister.FlatStyle = FlatStyle.Flat;
            btnStudentRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnStudentRegister.ForeColor = Color.FromArgb(0, 120, 70);
            btnStudentRegister.ImageAlign = ContentAlignment.MiddleLeft;
            btnStudentRegister.ImeMode = ImeMode.NoControl;
            btnStudentRegister.Location = new Point(3, 206);
            btnStudentRegister.Name = "btnStudentRegister";
            btnStudentRegister.Size = new Size(280, 45);
            btnStudentRegister.TabIndex = 12;
            btnStudentRegister.Text = "Student Register";
            btnStudentRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnStudentRegister.UseVisualStyleBackColor = false;
            // 
            // btnTeacherRegister
            // 
            btnTeacherRegister.BackColor = Color.White;
            btnTeacherRegister.FlatAppearance.BorderSize = 0;
            btnTeacherRegister.FlatStyle = FlatStyle.Flat;
            btnTeacherRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTeacherRegister.ForeColor = Color.Black;
            btnTeacherRegister.ImageAlign = ContentAlignment.BottomLeft;
            btnTeacherRegister.ImeMode = ImeMode.NoControl;
            btnTeacherRegister.Location = new Point(3, 161);
            btnTeacherRegister.Name = "btnTeacherRegister";
            btnTeacherRegister.Size = new Size(280, 45);
            btnTeacherRegister.TabIndex = 10;
            btnTeacherRegister.Text = "Teacher Register";
            btnTeacherRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnTeacherRegister.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(90, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(40, 70);
            label2.Name = "label2";
            label2.Size = new Size(204, 20);
            label2.TabIndex = 11;
            label2.Text = "Welcome, Mr. John (Principal)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 120, 70);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(40, 35);
            label1.Name = "label1";
            label1.Size = new Size(454, 31);
            label1.TabIndex = 9;
            label1.Text = "SMART SCHOOL MANAGEMENT SYSTEM";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(btnLogout);
            splitContainer1.Panel1.Controls.Add(btnProfile);
            splitContainer1.Panel1.Controls.Add(btnNoticeCreate);
            splitContainer1.Panel1.Controls.Add(btnTeacherRegister);
            splitContainer1.Panel1.Controls.Add(btnStudentRegister);
            splitContainer1.Panel1.Controls.Add(btnTeacherAttendance);
            splitContainer1.Panel1.Controls.Add(btnTimetable);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(1150, 708);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 18;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(800, 35);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 45);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnAssignTime);
            panel1.Controls.Add(cmbAssignTeacher3);
            panel1.Controls.Add(cmbAssignTeacher2);
            panel1.Controls.Add(cmbAssignTeacher1);
            panel1.Controls.Add(cmbAssignClass);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dgvTimetable);
            panel1.Controls.Add(cmbFilterDay);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmbFilterClass);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(40, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 560);
            panel1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(40, 25);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 0;
            label3.Text = "Class";
            // 
            // cmbFilterClass
            // 
            cmbFilterClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterClass.FormattingEnabled = true;
            cmbFilterClass.Location = new Point(100, 20);
            cmbFilterClass.Name = "cmbFilterClass";
            cmbFilterClass.Size = new Size(180, 28);
            cmbFilterClass.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(300, 25);
            label4.Name = "label4";
            label4.Size = new Size(41, 23);
            label4.TabIndex = 2;
            label4.Text = "Day";
            // 
            // cmbFilterDay
            // 
            cmbFilterDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterDay.FormattingEnabled = true;
            cmbFilterDay.Location = new Point(350, 20);
            cmbFilterDay.Name = "cmbFilterDay";
            cmbFilterDay.Size = new Size(180, 28);
            cmbFilterDay.TabIndex = 3;
            // 
            // dgvTimetable
            // 
            dgvTimetable.BackgroundColor = Color.FromArgb(225, 245, 230);
            dgvTimetable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTimetable.Columns.AddRange(new DataGridViewColumn[] { Time, Subject, Teacher, Room });
            dgvTimetable.GridColor = Color.FromArgb(180, 220, 195);
            dgvTimetable.Location = new Point(40, 75);
            dgvTimetable.Name = "dgvTimetable";
            dgvTimetable.RowHeadersWidth = 51;
            dgvTimetable.Size = new Size(490, 460);
            dgvTimetable.TabIndex = 4;
            // 
            // Time
            // 
            Time.HeaderText = "Time";
            Time.MinimumWidth = 6;
            Time.Name = "Time";
            Time.Width = 125;
            // 
            // Subject
            // 
            Subject.HeaderText = "Subject";
            Subject.MinimumWidth = 6;
            Subject.Name = "Subject";
            Subject.Width = 125;
            // 
            // Teacher
            // 
            Teacher.HeaderText = "Teacher";
            Teacher.MinimumWidth = 6;
            Teacher.Name = "Teacher";
            Teacher.Width = 125;
            // 
            // Room
            // 
            Room.HeaderText = "Room";
            Room.MinimumWidth = 6;
            Room.Name = "Room";
            Room.Width = 125;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(560, 75);
            label5.Name = "label5";
            label5.Size = new Size(161, 23);
            label5.TabIndex = 5;
            label5.Text = "Modification Panel";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(560, 110);
            label6.Name = "label6";
            label6.Size = new Size(174, 23);
            label6.TabIndex = 6;
            label6.Text = "Assign selected time";
            // 
            // cmbAssignClass
            // 
            cmbAssignClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignClass.FormattingEnabled = true;
            cmbAssignClass.Location = new Point(560, 140);
            cmbAssignClass.Name = "cmbAssignClass";
            cmbAssignClass.Size = new Size(200, 28);
            cmbAssignClass.TabIndex = 7;
            // 
            // cmbAssignTeacher1
            // 
            cmbAssignTeacher1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignTeacher1.FormattingEnabled = true;
            cmbAssignTeacher1.Location = new Point(560, 190);
            cmbAssignTeacher1.Name = "cmbAssignTeacher1";
            cmbAssignTeacher1.Size = new Size(200, 28);
            cmbAssignTeacher1.TabIndex = 8;
            // 
            // cmbAssignTeacher2
            // 
            cmbAssignTeacher2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignTeacher2.FormattingEnabled = true;
            cmbAssignTeacher2.Location = new Point(560, 240);
            cmbAssignTeacher2.Name = "cmbAssignTeacher2";
            cmbAssignTeacher2.Size = new Size(200, 28);
            cmbAssignTeacher2.TabIndex = 9;
            // 
            // cmbAssignTeacher3
            // 
            cmbAssignTeacher3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignTeacher3.FormattingEnabled = true;
            cmbAssignTeacher3.Location = new Point(560, 290);
            cmbAssignTeacher3.Name = "cmbAssignTeacher3";
            cmbAssignTeacher3.Size = new Size(200, 28);
            cmbAssignTeacher3.TabIndex = 10;
            // 
            // btnAssignTime
            // 
            btnAssignTime.BackColor = Color.FromArgb(0, 135, 80);
            btnAssignTime.FlatAppearance.BorderSize = 0;
            btnAssignTime.FlatStyle = FlatStyle.Flat;
            btnAssignTime.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAssignTime.ForeColor = Color.White;
            btnAssignTime.Location = new Point(560, 345);
            btnAssignTime.Name = "btnAssignTime";
            btnAssignTime.Size = new Size(200, 42);
            btnAssignTime.TabIndex = 11;
            btnAssignTime.Text = "Assign Time list";
            btnAssignTime.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 708);
            Controls.Add(splitContainer1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTimetable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogout;
        private Button btnNoticeCreate;
        private Button btnProfile;
        private Button btnTeacherAttendance;
        private Button btnTimetable;
        private Button btnStudentRegister;
        private Button btnTeacherRegister;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private SplitContainer splitContainer1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Label label3;
        private ComboBox cmbFilterDay;
        private Label label4;
        private ComboBox cmbFilterClass;
        private DataGridView dgvTimetable;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn Teacher;
        private DataGridViewTextBoxColumn Room;
        private Label label5;
        private ComboBox cmbAssignClass;
        private Label label6;
        private ComboBox cmbAssignTeacher3;
        private ComboBox cmbAssignTeacher2;
        private ComboBox cmbAssignTeacher1;
        private Button btnAssignTime;
    }
}