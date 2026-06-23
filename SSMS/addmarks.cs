using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class addmarks : Form
    {
        private int _teacherId;

        public addmarks(int teacherId)
        {
            InitializeComponent();
            _teacherId = teacherId;
            this.Load += AddMarks_Load;
            cmbGrade.SelectedIndexChanged += CmbGrade_SelectedIndexChanged;
            btnSaveMarks.Click += BtnSaveMarks_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private class GradeItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; } = string.Empty;
            public override string ToString() => DisplayText;
        }

        private class SubjectItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; } = string.Empty;
            public override string ToString() => DisplayText;
        }

        private class ExamItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; } = string.Empty;
            public override string ToString() => DisplayText;
        }

        private void AddMarks_Load(object sender, EventArgs e)
        {
            LoadGrades();
            LoadSubjects();
            LoadExams();
            ConfigureGrid();
        }

        private void LoadGrades()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, grade_level_number, section FROM grade";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbGrade.Items.Clear();
                        while (reader.Read())
                        {
                            cmbGrade.Items.Add(new GradeItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                DisplayText = $"Grade {reader["grade_level_number"]} - {reader["section"]}"
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading grades: " + ex.Message);
                }
            }
        }

        private void LoadSubjects()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT DISTINCT s.id, s.subject_name 
                                     FROM subject s
                                     INNER JOIN teacher_subject ts ON s.id = ts.subject_id
                                     INNER JOIN teacher t ON ts.teacher_id = t.id
                                     WHERE t.users_id = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _teacherId);
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subjects: " + ex.Message);
                }
            }
        }

        private void LoadExams()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, exam_name FROM exam";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbExam.Items.Clear();
                        while (reader.Read())
                        {
                            cmbExam.Items.Add(new ExamItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                DisplayText = reader["exam_name"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading exams: " + ex.Message);
                }
            }
        }

        private void ConfigureGrid()
        {
            dataGridViewMarks.AllowUserToAddRows = false;
            dataGridViewMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMarks.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void CmbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrade.SelectedItem is GradeItem selectedGrade)
            {
                LoadStudentsForGrade(selectedGrade.Id);
            }
        }

        private void LoadStudentsForGrade(int gradeId)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT s.id AS StudentId, u.firstname AS FirstName, u.lastname AS LastName 
                                     FROM student s 
                                     JOIN users u ON s.users_id = u.id 
                                     WHERE s.grade_id = @gradeId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gradeId", gradeId);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dt.Columns.Add("Marks", typeof(decimal));
                            dt.Columns.Add("GradeLetter", typeof(string));
                            dt.Columns.Add("Remarks", typeof(string));

                            dataGridViewMarks.DataSource = dt;

                            dataGridViewMarks.Columns["StudentId"].ReadOnly = true;
                            dataGridViewMarks.Columns["FirstName"].ReadOnly = true;
                            dataGridViewMarks.Columns["LastName"].ReadOnly = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading students: " + ex.Message);
                }
            }
        }

        private void BtnSaveMarks_Click(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedItem == null || cmbExam.SelectedItem == null || cmbGrade.SelectedItem == null)
            {
                MessageBox.Show("Please select a Grade, Subject, and Exam.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int subjectId = ((SubjectItem)cmbSubject.SelectedItem).Id;
            int examId = ((ExamItem)cmbExam.SelectedItem).Id;

            int savedCount = 0;

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    int realTeacherId = 0;
                    string tQuery = "SELECT id FROM teacher WHERE users_id = @uid";
                    using (MySqlCommand tCmd = new MySqlCommand(tQuery, conn))
                    {
                        tCmd.Parameters.AddWithValue("@uid", _teacherId);
                        object res = tCmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) realTeacherId = Convert.ToInt32(res);
                    }
                    if (realTeacherId == 0)
                    {
                        MessageBox.Show("Teacher ID not found for the logged in user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (DataGridViewRow row in dataGridViewMarks.Rows)
                    {
                        if (row.Cells["StudentId"].Value == null || row.Cells["Marks"].Value == DBNull.Value) continue;

                        int studentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                        decimal marks = Convert.ToDecimal(row.Cells["Marks"].Value);
                        string gradeLetter = row.Cells["GradeLetter"].Value?.ToString() ?? "";
                        string remarks = row.Cells["Remarks"].Value?.ToString() ?? "";

                        string query = @"
                            INSERT INTO student_marks (student_id, exam_id, subject_id, marks, total_marks, grade_letter, remarks, added_by) 
                            VALUES (@sid, @eid, @subid, @marks, 100, @grade, @remarks, @addedBy)
                            ON DUPLICATE KEY UPDATE 
                                marks = @marks, grade_letter = @grade, remarks = @remarks, added_by = @addedBy";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@sid", studentId);
                            cmd.Parameters.AddWithValue("@eid", examId);
                            cmd.Parameters.AddWithValue("@subid", subjectId);
                            cmd.Parameters.AddWithValue("@marks", marks);
                            cmd.Parameters.AddWithValue("@grade", gradeLetter);
                            cmd.Parameters.AddWithValue("@remarks", remarks);
                            cmd.Parameters.AddWithValue("@addedBy", realTeacherId);
                            cmd.ExecuteNonQuery();
                            savedCount++;
                        }
                    }

                    MessageBox.Show($"Successfully saved marks for {savedCount} students.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving marks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addmarks_Load_1(object sender, EventArgs e)
        {

        }
    }
}
