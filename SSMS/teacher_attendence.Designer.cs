namespace SSMS
{
    partial class teacher_attendence
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            btnLogout = new Button();
            btnProfile = new Button();
            btnNoticeCreate = new Button();
            btnTeacherRegister = new Button();
            btnStudentRegister = new Button();
            btnTeacherAttendance = new Button();
            btnTimetable = new Button();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            adminContentPanel = new Panel();
            label3 = new Label();
            dtpAttendanceDate = new DateTimePicker();
            label4 = new Label();
            cmbFilterDepartment = new ComboBox();
            dgvAttendance = new DataGridView();
            Teacher_ID = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Check_In = new DataGridViewTextBoxColumn();
            Check_Out = new DataGridViewTextBoxColumn();
            pnlPresentSummary = new Panel();
            label5 = new Label();
            pnlAbsentSummary = new Panel();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            adminContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            pnlPresentSummary.SuspendLayout();
            pnlAbsentSummary.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(90, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnLogout.ImeMode = ImeMode.NoControl;
            btnLogout.Location = new Point(0, 445);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(280, 45);
            btnLogout.TabIndex = 28;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.White;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnProfile.ImeMode = ImeMode.NoControl;
            btnProfile.Location = new Point(0, 355);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(280, 45);
            btnProfile.TabIndex = 26;
            btnProfile.Text = "Profile";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnNoticeCreate
            // 
            btnNoticeCreate.BackColor = Color.White;
            btnNoticeCreate.FlatAppearance.BorderSize = 0;
            btnNoticeCreate.FlatStyle = FlatStyle.Flat;
            btnNoticeCreate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnNoticeCreate.ImeMode = ImeMode.NoControl;
            btnNoticeCreate.Location = new Point(0, 400);
            btnNoticeCreate.Name = "btnNoticeCreate";
            btnNoticeCreate.Size = new Size(280, 45);
            btnNoticeCreate.TabIndex = 27;
            btnNoticeCreate.Text = "Notice Create";
            btnNoticeCreate.TextAlign = ContentAlignment.MiddleLeft;
            btnNoticeCreate.UseVisualStyleBackColor = false;
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
            btnTeacherRegister.Location = new Point(0, 175);
            btnTeacherRegister.Name = "btnTeacherRegister";
            btnTeacherRegister.Size = new Size(280, 45);
            btnTeacherRegister.TabIndex = 20;
            btnTeacherRegister.Text = "Teacher Register";
            btnTeacherRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnTeacherRegister.UseVisualStyleBackColor = false;
            // 
            // btnStudentRegister
            // 
            btnStudentRegister.BackColor = Color.White;
            btnStudentRegister.FlatAppearance.BorderSize = 0;
            btnStudentRegister.FlatStyle = FlatStyle.Flat;
            btnStudentRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnStudentRegister.ForeColor = Color.Black;
            btnStudentRegister.ImageAlign = ContentAlignment.MiddleLeft;
            btnStudentRegister.ImeMode = ImeMode.NoControl;
            btnStudentRegister.Location = new Point(0, 220);
            btnStudentRegister.Name = "btnStudentRegister";
            btnStudentRegister.Size = new Size(280, 45);
            btnStudentRegister.TabIndex = 22;
            btnStudentRegister.Text = "Student Register";
            btnStudentRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnStudentRegister.UseVisualStyleBackColor = false;
            // 
            // btnTeacherAttendance
            // 
            btnTeacherAttendance.BackColor = Color.FromArgb(225, 245, 230);
            btnTeacherAttendance.FlatAppearance.BorderSize = 0;
            btnTeacherAttendance.FlatStyle = FlatStyle.Flat;
            btnTeacherAttendance.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTeacherAttendance.ForeColor = Color.FromArgb(0, 120, 70);
            btnTeacherAttendance.ImeMode = ImeMode.NoControl;
            btnTeacherAttendance.Location = new Point(0, 310);
            btnTeacherAttendance.Name = "btnTeacherAttendance";
            btnTeacherAttendance.Size = new Size(280, 45);
            btnTeacherAttendance.TabIndex = 25;
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
            btnTimetable.Location = new Point(0, 265);
            btnTimetable.Name = "btnTimetable";
            btnTimetable.Size = new Size(280, 45);
            btnTimetable.TabIndex = 24;
            btnTimetable.Text = "Timetable";
            btnTimetable.TextAlign = ContentAlignment.MiddleLeft;
            btnTimetable.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(800, 35);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 45);
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(40, 70);
            label2.Name = "label2";
            label2.Size = new Size(204, 20);
            label2.TabIndex = 21;
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
            label1.TabIndex = 19;
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
            splitContainer1.Panel1.Controls.Add(btnLogout);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(btnProfile);
            splitContainer1.Panel1.Controls.Add(btnNoticeCreate);
            splitContainer1.Panel1.Controls.Add(btnTimetable);
            splitContainer1.Panel1.Controls.Add(btnTeacherRegister);
            splitContainer1.Panel1.Controls.Add(btnTeacherAttendance);
            splitContainer1.Panel1.Controls.Add(btnStudentRegister);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(adminContentPanel);
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Paint += this.splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1150, 708);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 29;
            // 
            // adminContentPanel
            // 
            adminContentPanel.BackColor = Color.White;
            adminContentPanel.Controls.Add(pnlAbsentSummary);
            adminContentPanel.Controls.Add(pnlPresentSummary);
            adminContentPanel.Controls.Add(dgvAttendance);
            adminContentPanel.Controls.Add(cmbFilterDepartment);
            adminContentPanel.Controls.Add(label4);
            adminContentPanel.Controls.Add(dtpAttendanceDate);
            adminContentPanel.Controls.Add(label3);
            adminContentPanel.Location = new Point(40, 120);
            adminContentPanel.Name = "adminContentPanel";
            adminContentPanel.Size = new Size(800, 560);
            adminContentPanel.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(40, 25);
            label3.Name = "label3";
            label3.Size = new Size(48, 23);
            label3.TabIndex = 0;
            label3.Text = "Date";
            // 
            // dtpAttendanceDate
            // 
            dtpAttendanceDate.Format = DateTimePickerFormat.Short;
            dtpAttendanceDate.Location = new Point(100, 20);
            dtpAttendanceDate.Name = "dtpAttendanceDate";
            dtpAttendanceDate.Size = new Size(180, 27);
            dtpAttendanceDate.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(430, 25);
            label4.Name = "label4";
            label4.Size = new Size(108, 23);
            label4.TabIndex = 2;
            label4.Text = "Department";
            // 
            // cmbFilterDepartment
            // 
            cmbFilterDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterDepartment.FormattingEnabled = true;
            cmbFilterDepartment.Location = new Point(540, 20);
            cmbFilterDepartment.Name = "cmbFilterDepartment";
            cmbFilterDepartment.Size = new Size(180, 28);
            cmbFilterDepartment.TabIndex = 3;
            // 
            // dgvAttendance
            // 
            dataGridViewCellStyle3.BackColor = Color.White;
            dgvAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Columns.AddRange(new DataGridViewColumn[] { Teacher_ID, Name, Status, Check_In, Check_Out });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(225, 245, 230);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAttendance.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAttendance.GridColor = Color.FromArgb(180, 220, 195);
            dgvAttendance.Location = new Point(40, 75);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.Size = new Size(720, 330);
            dgvAttendance.TabIndex = 4;
            // 
            // Teacher_ID
            // 
            Teacher_ID.HeaderText = "Teacher_ID";
            Teacher_ID.MinimumWidth = 6;
            Teacher_ID.Name = "Teacher_ID";
            Teacher_ID.Width = 125;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.Width = 125;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // Check_In
            // 
            Check_In.HeaderText = "Check_In";
            Check_In.MinimumWidth = 6;
            Check_In.Name = "Check_In";
            Check_In.Width = 125;
            // 
            // Check_Out
            // 
            Check_Out.HeaderText = "Check_Out";
            Check_Out.MinimumWidth = 6;
            Check_Out.Name = "Check_Out";
            Check_Out.Width = 125;
            // 
            // pnlPresentSummary
            // 
            pnlPresentSummary.BackColor = Color.FromArgb(195, 240, 210);
            pnlPresentSummary.Controls.Add(label5);
            pnlPresentSummary.Location = new Point(40, 430);
            pnlPresentSummary.Name = "pnlPresentSummary";
            pnlPresentSummary.Size = new Size(340, 90);
            pnlPresentSummary.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 120, 70);
            label5.Location = new Point(60, 22);
            label5.Name = "label5";
            label5.Size = new Size(223, 46);
            label5.TabIndex = 0;
            label5.Text = "PRESENT: 82";
            // 
            // pnlAbsentSummary
            // 
            pnlAbsentSummary.BackColor = Color.FromArgb(195, 240, 210);
            pnlAbsentSummary.Controls.Add(label6);
            pnlAbsentSummary.Location = new Point(420, 430);
            pnlAbsentSummary.Name = "pnlAbsentSummary";
            pnlAbsentSummary.Size = new Size(340, 90);
            pnlAbsentSummary.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(0, 120, 70);
            label6.Location = new Point(59, 22);
            label6.Name = "label6";
            label6.Size = new Size(188, 46);
            label6.TabIndex = 1;
            label6.Text = "ABSENT: 6";
            // 
            // teacher_attendence
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 708);
            Controls.Add(splitContainer1);
            MaximizeBox = false;
            Name = "teacher_attendence";
            Text = "teacher_attendence";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            adminContentPanel.ResumeLayout(false);
            adminContentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            pnlPresentSummary.ResumeLayout(false);
            pnlPresentSummary.PerformLayout();
            pnlAbsentSummary.ResumeLayout(false);
            pnlAbsentSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnLogout;
        private Button btnProfile;
        private Button btnNoticeCreate;
        private Button btnTeacherRegister;
        private Button btnStudentRegister;
        private Button btnTeacherAttendance;
        private Button btnTimetable;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label1;
        private SplitContainer splitContainer1;
        private Panel adminContentPanel;
        private Label label4;
        private DateTimePicker dtpAttendanceDate;
        private Label label3;
        private DataGridView dgvAttendance;
        private DataGridViewTextBoxColumn Teacher_ID;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Check_In;
        private DataGridViewTextBoxColumn Check_Out;
        private ComboBox cmbFilterDepartment;
        private Panel pnlPresentSummary;
        private Label label5;
        private Panel pnlAbsentSummary;
        private Label label6;
    }
}