using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class timetable : Form
    {
        public timetable()
        {
            InitializeComponent();
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void timetable_Load(object sender, EventArgs e)
        {
            // 1. Clear all inputs on startup
            ClearAllInputs();

            // 2. Load dropdown data sources
            LoadGrades();
            LoadDays();
            LoadSubjects();
            LoadRooms();
            LoadPeriods();

            // 3. Setup DataGridView - EMPTY at start
            dgvTimetable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTimetable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTimetable.AllowUserToAddRows = false;
            dgvTimetable.ReadOnly = true;
            dgvTimetable.DataSource = null;
        }

        // ==================== CLEAR ALL INPUTS ====================
        private void ClearAllInputs()
        {
            cmbGrade.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbTeacher.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cnDay.SelectedIndex = -1;
            cmbStartTime.SelectedIndex = -1;
            cmbEndTime.SelectedIndex = -1;

            dgvTimetable.DataSource = null;
        }

        // ==================== LOAD DROPDOWNS ====================
        private void LoadGrades()
        {
            cmbGrade.Items.Clear();

            // Hardcoded grades 1 through 13 (Just strings, no custom object)
            for (int i = 1; i <= 13; i++)
            {
                cmbGrade.Items.Add("Grade " + i);
            }

            cmbGrade.SelectedIndex = -1;
        }

        private void LoadSubjects()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT id, subject_name FROM subject ORDER BY subject_name";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbSubject.Items.Clear();
                        while (reader.Read())
                        {
                            cmbSubject.Items.Add(new SubjectItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                DisplayText = reader["subject_name"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading subjects: " + ex.Message); }
        }

        private void LoadDays()
        {
            cnDay.Items.Clear();
            cnDay.Items.Add("Monday");
            cnDay.Items.Add("Tuesday");
            cnDay.Items.Add("Wednesday");
            cnDay.Items.Add("Thursday");
            cnDay.Items.Add("Friday");
            cnDay.Items.Add("Saturday");
        }

        private void LoadRooms()
        {
            cmbRoom.Items.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT CONCAT(grade_name, '-', section) AS room_name FROM grade ORDER BY grade_name, section";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbRoom.Items.Add(reader["room_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                cmbRoom.Items.Add("1-A"); cmbRoom.Items.Add("1-B");
                cmbRoom.Items.Add("2-A"); cmbRoom.Items.Add("2-B");
                cmbRoom.Items.Add("3-A");
            }
        }

        private void LoadPeriods()
        {
            string[] periods = {
                "08:00 AM", "08:45 AM", "09:30 AM", "10:15 AM",
                "10:45 AM", "11:30 AM", "12:15 PM", "01:00 PM", "01:45 PM"
            };

            cmbStartTime.Items.Clear();
            cmbStartTime.Items.AddRange(periods);

            cmbEndTime.Items.Clear();
            cmbEndTime.Items.AddRange(periods);
        }

        // ==================== LOAD TEACHERS BY SUBJECT (ONLY FIRST NAME) ====================
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) // cmbSubject
        {
            if (cmbSubject.SelectedItem == null) return;

            var selectedSubject = (SubjectItem)cmbSubject.SelectedItem;

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    // ⬇️ CHANGED: Only select firstname
                    string query = @"SELECT t.id, u.firstname 
                                     FROM teacher t
                                     INNER JOIN users u ON t.users_id = u.id
                                     INNER JOIN teacher_subject ts ON t.id = ts.teacher_id
                                     WHERE ts.subject_id = @subId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@subId", selectedSubject.Id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbTeacher.Items.Clear();
                            while (reader.Read())
                            {
                                cmbTeacher.Items.Add(new TeacherItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    DisplayText = reader["firstname"].ToString() // Shows only First Name
                                });
                            }
                            if (cmbTeacher.Items.Count > 0) cmbTeacher.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error loading teachers: " + ex.Message); }
            }
        }

        // ==================== SAVE TIMETABLE ====================
        private void btnAssignTime_Click(object sender, EventArgs e) // btnSave
        {
            if (!ValidateInputs()) return;

            // ⬇️ FIXED: Get the Grade ID using the selected string
            string selectedGradeText = cmbGrade.Text;
            int gradeId = GetGradeIdFromDatabase(selectedGradeText);

            var subject = (SubjectItem)cmbSubject.SelectedItem;
            var teacher = (TeacherItem)cmbTeacher.SelectedItem;

            TimeSpan startTime = DateTime.Parse(cmbStartTime.Text).TimeOfDay;
            TimeSpan endTime = DateTime.Parse(cmbEndTime.Text).TimeOfDay;

            if (startTime >= endTime)
            {
                MessageBox.Show("Start time must be before end time!");
                return;
            }

            if (HasConflict(gradeId, teacher.Id, cnDay.Text, startTime, endTime, cmbRoom.Text)) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = @"INSERT INTO timetable (grade_id, subject_id, teacher_id, day_of_week, start_time, end_time, room)
                                     VALUES (@gid, @sid, @tid, @day, @start, @end, @room)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gid", gradeId);
                        cmd.Parameters.AddWithValue("@sid", subject.Id);
                        cmd.Parameters.AddWithValue("@tid", teacher.Id);
                        cmd.Parameters.AddWithValue("@day", cnDay.Text);
                        cmd.Parameters.AddWithValue("@start", startTime);
                        cmd.Parameters.AddWithValue("@end", endTime);
                        cmd.Parameters.AddWithValue("@room", cmbRoom.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Saved successfully!", "Success");
                LoadTimetable(); // Refresh grid
            }
            catch (Exception ex) { MessageBox.Show("Error saving: " + ex.Message); }
        }

        // ==================== HELPER TO GET GRADE ID ====================
        private int GetGradeIdFromDatabase(string gradeDisplayText)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();
                // Extract the number and reconstruct the database format
                string gradeNumber = gradeDisplayText.Replace("Grade ", "").Trim();
                string gradeName = "Grade " + gradeNumber;

                string query = "SELECT id FROM grade WHERE grade_name = @gradeName LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gradeName", gradeName);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                        return 1; // Fallback
                }
            }
        }

        // ==================== CONFLICT CHECKS ====================
        private bool HasConflict(int gradeId, int teacherId, string day, TimeSpan start, TimeSpan end, string room)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM timetable WHERE teacher_id = @tid AND day_of_week = @day AND ((start_time < @end AND end_time > @start))";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tid", teacherId);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Teacher is already booked at this time!");
                        return true;
                    }
                }

                query = "SELECT COUNT(*) FROM timetable WHERE room = @room AND day_of_week = @day AND ((start_time < @end AND end_time > @start))";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room", room);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Room is already booked at this time!");
                        return true;
                    }
                }

                query = "SELECT COUNT(*) FROM timetable WHERE grade_id = @gid AND day_of_week = @day AND ((start_time < @end AND end_time > @start))";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gid", gradeId);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("This grade already has a class at this time!");
                        return true;
                    }
                }

                return false;
            }
        }

        // ==================== LOAD TIMETABLE GRID ====================
        private void LoadTimetable()
        {
            if (cmbGrade.SelectedItem == null)
            {
                dgvTimetable.DataSource = null;
                return;
            }

            // ⬇️ FIXED: Get ID from the selected string
            string selectedGradeText = cmbGrade.Text;
            int gradeId = GetGradeIdFromDatabase(selectedGradeText);

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                            CONCAT(DATE_FORMAT(tt.start_time, '%h:%i %p'), ' - ', DATE_FORMAT(tt.end_time, '%h:%i %p')) AS 'Time',
                                            sub.subject_name AS 'Subject', 
                                            CONCAT(u.firstname, ' ', u.lastname) AS 'Teacher', 
                                            tt.room AS 'Room'
                                     FROM timetable tt
                                     INNER JOIN subject sub ON tt.subject_id = sub.id
                                     INNER JOIN teacher t ON tt.teacher_id = t.id
                                     INNER JOIN users u ON t.users_id = u.id
                                     WHERE tt.grade_id = @gid
                                     ORDER BY FIELD(tt.day_of_week, 'Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'), tt.start_time";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gid", gradeId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            dgvTimetable.Columns.Clear();
                            dgvTimetable.DataSource = dt;
                            dgvTimetable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error loading: " + ex.Message); }
            }
        }

        // ==================== VALIDATION ====================
        private bool ValidateInputs()
        {
            if (cmbGrade.SelectedItem == null) { MessageBox.Show("Please select a Grade."); return false; }
            if (cmbSubject.SelectedItem == null) { MessageBox.Show("Please select a Subject."); return false; }
            if (cmbTeacher.SelectedItem == null || cmbTeacher.Items.Count == 0) { MessageBox.Show("Please select a Teacher."); return false; }
            if (cnDay.SelectedItem == null) { MessageBox.Show("Please select a Day."); return false; }
            if (cmbStartTime.SelectedItem == null || cmbEndTime.SelectedItem == null) { MessageBox.Show("Please select Start and End times."); return false; }
            if (cmbRoom.SelectedItem == null) { MessageBox.Show("Please select a Room."); return false; }
            return true;
        }

        // ==================== EVENT HANDLERS ====================
        private void cmbAssignClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimetable();
        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbFilterClass_SelectedIndexChanged(object sender, EventArgs e) { }

        // ==================== HELPER CLASSES ====================
        // GradeItem is no longer used for cmbGrade, but kept for other potential uses
        private class SubjectItem { public int Id { get; set; } public string DisplayText { get; set; } public override string ToString() => DisplayText; }
        private class TeacherItem { public int Id { get; set; } public string DisplayText { get; set; } public override string ToString() => DisplayText; }
    }
}