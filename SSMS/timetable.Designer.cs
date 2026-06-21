namespace SSMS
{
    partial class timetable
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label7 = new Label();
            label3 = new Label();
            cmbStartTime = new ComboBox();
            dgvTimetable = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            Teacher = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            cmbGrade = new ComboBox();
            btnSave = new Button();
            panel1 = new Panel();
            cmbRoom = new ComboBox();
            cmbEndTime = new ComboBox();
            cmbSubject = new ComboBox();
            cmbTeacher = new ComboBox();
            cnDay = new ComboBox();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTimetable).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(0, 120, 70);
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(394, 9);
            label7.Name = "label7";
            label7.Size = new Size(629, 50);
            label7.TabIndex = 14;
            label7.Text = "Timetable Creation - Relief Periods";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(651, 25);
            label3.Name = "label3";
            label3.Size = new Size(95, 38);
            label3.TabIndex = 0;
            label3.Text = "Grade";
            // 
            // cmbStartTime
            // 
            cmbStartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStartTime.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStartTime.FormattingEnabled = true;
            cmbStartTime.Location = new Point(811, 316);
            cmbStartTime.Name = "cmbStartTime";
            cmbStartTime.Size = new Size(198, 39);
            cmbStartTime.TabIndex = 1;
            cmbStartTime.SelectedIndexChanged += cmbFilterClass_SelectedIndexChanged;
            // 
            // dgvTimetable
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvTimetable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTimetable.BackgroundColor = Color.FromArgb(225, 245, 230);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTimetable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTimetable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTimetable.Columns.AddRange(new DataGridViewColumn[] { Time, Subject, Teacher, Room });
            dgvTimetable.GridColor = Color.FromArgb(180, 220, 195);
            dgvTimetable.Location = new Point(36, 38);
            dgvTimetable.Name = "dgvTimetable";
            dgvTimetable.RowHeadersWidth = 51;
            dgvTimetable.Size = new Size(555, 460);
            dgvTimetable.TabIndex = 4;
            dgvTimetable.CellContentClick += dgvTimetable_CellContentClick;
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
            // cmbGrade
            // 
            cmbGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrade.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGrade.FormattingEnabled = true;
            cmbGrade.Location = new Point(811, 27);
            cmbGrade.Name = "cmbGrade";
            cmbGrade.Size = new Size(200, 39);
            cmbGrade.TabIndex = 7;
            cmbGrade.SelectedIndexChanged += cmbAssignClass_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 135, 80);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1107, 402);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 70);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnAssignTime_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cmbRoom);
            panel1.Controls.Add(cmbEndTime);
            panel1.Controls.Add(cmbSubject);
            panel1.Controls.Add(cmbTeacher);
            panel1.Controls.Add(cnDay);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(cmbGrade);
            panel1.Controls.Add(dgvTimetable);
            panel1.Controls.Add(cmbStartTime);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 74);
            panel1.Name = "panel1";
            panel1.Size = new Size(1338, 574);
            panel1.TabIndex = 19;
            // 
            // cmbRoom
            // 
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(1107, 315);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(155, 39);
            cmbRoom.TabIndex = 23;
            cmbRoom.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // cmbEndTime
            // 
            cmbEndTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEndTime.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEndTime.FormattingEnabled = true;
            cmbEndTime.Location = new Point(809, 420);
            cmbEndTime.Name = "cmbEndTime";
            cmbEndTime.Size = new Size(200, 39);
            cmbEndTime.TabIndex = 22;
            cmbEndTime.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(809, 120);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(200, 39);
            cmbSubject.TabIndex = 21;
            cmbSubject.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // cmbTeacher
            // 
            cmbTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTeacher.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTeacher.FormattingEnabled = true;
            cmbTeacher.Location = new Point(809, 220);
            cmbTeacher.Name = "cmbTeacher";
            cmbTeacher.Size = new Size(200, 39);
            cmbTeacher.TabIndex = 20;
            cmbTeacher.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // cnDay
            // 
            cnDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cnDay.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cnDay.FormattingEnabled = true;
            cnDay.Location = new Point(1107, 120);
            cnDay.Name = "cnDay";
            cnDay.Size = new Size(200, 39);
            cnDay.TabIndex = 19;
            cnDay.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1107, 274);
            label8.Name = "label8";
            label8.Size = new Size(94, 38);
            label8.TabIndex = 17;
            label8.Text = "Room";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(651, 421);
            label6.Name = "label6";
            label6.Size = new Size(139, 38);
            label6.TabIndex = 16;
            label6.Text = "End Time";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(651, 316);
            label5.Name = "label5";
            label5.Size = new Size(154, 38);
            label5.TabIndex = 15;
            label5.Text = "Start Time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(651, 218);
            label4.Name = "label4";
            label4.Size = new Size(116, 38);
            label4.TabIndex = 14;
            label4.Text = "Teacher";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(651, 118);
            label2.Name = "label2";
            label2.Size = new Size(114, 38);
            label2.TabIndex = 13;
            label2.Text = "Subject";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1107, 79);
            label1.Name = "label1";
            label1.Size = new Size(68, 38);
            label1.TabIndex = 12;
            label1.Text = "Day";
            // 
            // timetable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1362, 675);
            Controls.Add(label7);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "timetable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += timetable_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTimetable).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private Label label3;
        private ComboBox cmbStartTime;
        private DataGridView dgvTimetable;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn Teacher;
        private DataGridViewTextBoxColumn Room;
        private ComboBox cmbGrade;
        private Button btnSave;
        private Panel panel1;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private ComboBox cmbRoom;
        private ComboBox cmbEndTime;
        private ComboBox cmbSubject;
        private ComboBox cmbTeacher;
        private ComboBox cnDay;
    }
}