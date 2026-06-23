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

            ClearAllInputs();


            LoadGrades();
            LoadAbsentTeachers();
            LoadSubjects();

            LoadPeriods();


            dgvTimetable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTimetable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTimetable.AllowUserToAddRows = false;
            dgvTimetable.ReadOnly = true;
            dgvTimetable.DataSource = null;
        }


        private void ClearAllInputs()
        {
            cmbGrade.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbTeacher.SelectedIndex = -1;
            cmbAbsentTeacher.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            cmbStartTime.SelectedIndex = -1;
            cmbEndTime.SelectedIndex = -1;

            dgvTimetable.DataSource = null;
        }


        private void LoadGrades()
        {
            cmbGrade.Items.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT CONCAT('Grade ', grade_level_number) AS grade_name FROM grade GROUP BY grade_level_number ORDER BY grade_level_number";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbGrade.Items.Add(reader["grade_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                for (int i = 1; i <= 13; i++)
                {
                    cmbGrade.Items.Add("Grade " + i);
                }
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

        private void LoadAbsentTeachers()
        {
            cmbAbsentTeacher.Items.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = @"SELECT t.id, u.firstname, u.lastname 
                                     FROM teacher t
                                     INNER JOIN users u ON t.users_id = u.id ORDER BY u.firstname";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbAbsentTeacher.Items.Add(new TeacherItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                DisplayText = reader["firstname"].ToString() + " " + reader["lastname"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading absent teachers: " + ex.Message); }
        }

        private void LoadRoomsForGrade(string gradeText)
        {
            cmbRoom.Items.Clear();
            if (string.IsNullOrWhiteSpace(gradeText)) return;
            string gradeNumber = gradeText.Replace("Grade ", "").Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT CONCAT(grade_level_number, '-', section) AS room_name FROM grade WHERE grade_level_number = @gn ORDER BY room_name";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gn", gradeNumber);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbRoom.Items.Add(reader["room_name"].ToString());
                            }
                        }
                    }
                }
                if (cmbRoom.Items.Count > 0) cmbRoom.SelectedIndex = 0;
            }
            catch (Exception)
            {
                cmbRoom.Items.Add(gradeNumber + "-A");
                if (cmbRoom.Items.Count > 0) cmbRoom.SelectedIndex = 0;
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


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedItem == null) return;

            var selectedSubject = (SubjectItem)cmbSubject.SelectedItem;

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT t.id, u.firstname, u.lastname,
                                       (SELECT COUNT(*) FROM timetable tt WHERE tt.teacher_id = t.id AND tt.day_of_week = DAYNAME(@dt)) +
                                       (SELECT COUNT(*) FROM relief_timetable rt WHERE rt.relief_teacher_id = t.id AND rt.relief_date = @dt) AS workload
                                     FROM teacher t
                                     INNER JOIN users u ON t.users_id = u.id
                                     INNER JOIN teacher_subject ts ON t.id = ts.teacher_id
                                     WHERE ts.subject_id = @subId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@subId", selectedSubject.Id);
                        cmd.Parameters.AddWithValue("@dt", dtpDate.Value.ToString("yyyy-MM-dd"));
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbTeacher.Items.Clear();
                            while (reader.Read())
                            {
                                cmbTeacher.Items.Add(new TeacherItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    DisplayText = $"{reader["firstname"]} {reader["lastname"]} (Workload: {reader["workload"]})"
                                });
                            }
                            if (cmbTeacher.Items.Count > 0) cmbTeacher.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error loading teachers: " + ex.Message); }
            }
        }


        private void btnAssignTime_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;


            string selectedGradeText = cmbGrade.Text;
            int gradeId = GetGradeIdFromDatabase(selectedGradeText);

            var subject = (SubjectItem)cmbSubject.SelectedItem;
            var teacher = (TeacherItem)cmbTeacher.SelectedItem;

            var absentTeacher = (TeacherItem)cmbAbsentTeacher.SelectedItem;

            TimeSpan startTime = DateTime.Parse(cmbStartTime.Text).TimeOfDay;
            TimeSpan endTime = DateTime.Parse(cmbEndTime.Text).TimeOfDay;

            if (startTime >= endTime)
            {
                MessageBox.Show("Start time must be before end time!");
                return;
            }


            if (HasConflict(gradeId, teacher.Id, dtpDate.Value.ToString("yyyy-MM-dd"), startTime, endTime, cmbRoom.Text)) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = @"INSERT INTO relief_timetable (relief_date, grade_id, subject_id, absent_teacher_id, relief_teacher_id, start_time, end_time, room)
                                     VALUES (@dt, @gid, @sid, @aid, @tid, @start, @end, @room)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dt", dtpDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@gid", gradeId);
                        cmd.Parameters.AddWithValue("@sid", subject.Id);
                        cmd.Parameters.AddWithValue("@aid", absentTeacher.Id);
                        cmd.Parameters.AddWithValue("@tid", teacher.Id);
                        cmd.Parameters.AddWithValue("@start", startTime);
                        cmd.Parameters.AddWithValue("@end", endTime);
                        cmd.Parameters.AddWithValue("@room", cmbRoom.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Saved successfully!", "Success");
                LoadTimetable();
            }
            catch (Exception ex) { MessageBox.Show("Error saving: " + ex.Message); }
        }


        private int GetGradeIdFromDatabase(string gradeDisplayText)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();

                string gradeNumber = gradeDisplayText.Replace("Grade ", "").Trim();

                string query = "SELECT id FROM grade WHERE grade_level_number = @gradeNumber LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gradeNumber", gradeNumber);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                        return 1;
                }
            }
        }


        private bool HasConflict(int gradeId, int teacherId, string date, TimeSpan start, TimeSpan end, string room)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                conn.Open();


                string query = "SELECT COUNT(*) FROM relief_timetable WHERE relief_teacher_id = @tid AND relief_date = @dt AND ((start_time < @end AND end_time > @start))";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tid", teacherId);
                    cmd.Parameters.AddWithValue("@dt", date);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Teacher is already assigned to a relief class at this time!");
                        return true;
                    }
                }

                query = "SELECT COUNT(*) FROM relief_timetable WHERE room = @room AND relief_date = @dt AND ((start_time < @end AND end_time > @start))";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room", room);
                    cmd.Parameters.AddWithValue("@dt", date);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Room is already booked for relief at this time!");
                        return true;
                    }
                }

                query = "SELECT COUNT(*) FROM relief_timetable WHERE grade_id = @gid AND relief_date = @dt AND ((start_time < @end AND end_time > @start))";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gid", gradeId);
                    cmd.Parameters.AddWithValue("@dt", date);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("This grade already has a relief class at this time!");
                        return true;
                    }
                }

                return false;
            }
        }


        private void LoadTimetable()
        {
            if (cmbGrade.SelectedItem == null)
            {
                dgvTimetable.DataSource = null;
                return;
            }


            string selectedGradeText = cmbGrade.Text;
            int gradeId = GetGradeIdFromDatabase(selectedGradeText);

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                            DATE_FORMAT(rt.relief_date, '%Y-%m-%d') AS 'DateCol',
                                            CONCAT(DATE_FORMAT(rt.start_time, '%h:%i %p'), ' - ', DATE_FORMAT(rt.end_time, '%h:%i %p')) AS 'Time',
                                            sub.subject_name AS 'Subject', 
                                            CONCAT_WS(' ', u_abs.firstname, u_abs.lastname) AS 'AbsentTeacherCol', 
                                            CONCAT_WS(' ', u_rel.firstname, u_rel.lastname) AS 'Teacher', 
                                            rt.room AS 'Room'
                                     FROM relief_timetable rt
                                     INNER JOIN subject sub ON rt.subject_id = sub.id
                                     INNER JOIN teacher t_abs ON rt.absent_teacher_id = t_abs.id
                                     INNER JOIN users u_abs ON t_abs.users_id = u_abs.id
                                     INNER JOIN teacher t_rel ON rt.relief_teacher_id = t_rel.id
                                     INNER JOIN users u_rel ON t_rel.users_id = u_rel.id
                                     WHERE rt.grade_id = @gid
                                     ORDER BY rt.relief_date, rt.start_time";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gid", gradeId);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvTimetable.AutoGenerateColumns = false;

                            if (dgvTimetable.Columns.Count >= 6)
                            {
                                dgvTimetable.Columns[0].DataPropertyName = "DateCol";
                                dgvTimetable.Columns[1].DataPropertyName = "Time";
                                dgvTimetable.Columns[2].DataPropertyName = "Subject";
                                dgvTimetable.Columns[3].DataPropertyName = "AbsentTeacherCol";
                                dgvTimetable.Columns[4].DataPropertyName = "Teacher";
                                dgvTimetable.Columns[5].DataPropertyName = "Room";
                            }

                            dgvTimetable.DataSource = dt;
                            dgvTimetable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error loading: " + ex.Message); }
            }
        }


        private bool ValidateInputs()
        {
            if (cmbGrade.SelectedItem == null) { MessageBox.Show("Please select a Grade."); return false; }
            if (cmbSubject.SelectedItem == null) { MessageBox.Show("Please select a Subject."); return false; }
            if (cmbTeacher.SelectedItem == null || cmbTeacher.Items.Count == 0) { MessageBox.Show("Please select a Relief Teacher."); return false; }
            if (cmbAbsentTeacher.SelectedItem == null || cmbAbsentTeacher.Items.Count == 0) { MessageBox.Show("Please select an Absent Teacher."); return false; }
            if (cmbRoom.SelectedItem == null || cmbRoom.Items.Count == 0) { MessageBox.Show("Please select a Room."); return false; }
            if (cmbStartTime.SelectedItem == null || cmbEndTime.SelectedItem == null) { MessageBox.Show("Please select time slots."); return false; }
            return true;
        }


        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            comboBox3_SelectedIndexChanged(null, null);
        }
        private void cmbAssignClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrade.SelectedItem != null)
            {
                LoadRoomsForGrade(cmbGrade.SelectedItem.ToString());
            }
            LoadTimetable();
        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbFilterClass_SelectedIndexChanged(object sender, EventArgs e) { }



        private class SubjectItem { public int Id { get; set; } public string DisplayText { get; set; } = string.Empty; public override string ToString() => DisplayText; }
        private class TeacherItem { public int Id { get; set; } public string DisplayText { get; set; } = string.Empty; public override string ToString() => DisplayText; }

        private void cmbAbsentTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}