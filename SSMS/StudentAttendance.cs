using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class studentAttendance : Form
    {
        private int _loggedInUserId;

        public studentAttendance(int userId)
        {
            InitializeComponent();
            _loggedInUserId = userId;
            this.Load += StudentAttendance_Load;
            
            
            cmbGrade.SelectedIndexChanged += CmbGrade_SelectedIndexChanged;
            cmbClass.SelectedIndexChanged += CmbClass_SelectedIndexChanged;
            cmbDate.SelectedIndexChanged += CmbDate_SelectedIndexChanged;
            btnSaveAttendance.Click += BtnSaveAttendance_Click;
            btnReset.Click += BtnReset_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void StudentAttendance_Load(object? sender, EventArgs e)
        {
            LoadDates();
            LoadGrades();
            SetupDataGridView();
        }

        private void LoadDates()
        {
            cmbDate.Items.Clear();
            
            for (int i = 0; i < 7; i++)
            {
                cmbDate.Items.Add(DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd"));
            }
            cmbDate.SelectedIndex = 0; 
        }

        private void LoadGrades()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT grade_level_number FROM grade ORDER BY grade_level_number";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbGrade.Items.Clear();
                        while (reader.Read())
                        {
                            cmbGrade.Items.Add(reader["grade_level_number"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading grades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmbGrade_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbGrade.SelectedItem == null) return;
            
            string selectedGrade = cmbGrade.SelectedItem.ToString();
            
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT section FROM grade WHERE grade_level_number = @grade ORDER BY section";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@grade", selectedGrade);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbClass.Items.Clear();
                            cmbClass.Text = "";
                            while (reader.Read())
                            {
                                cmbClass.Items.Add(reader["section"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading sections: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmbClass_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadStudents();
        }

        private void CmbDate_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadStudents();
        }

        private void SetupDataGridView()
        {
            dataGridViewAttendance.AutoGenerateColumns = false;
            dataGridViewAttendance.AllowUserToAddRows = false;
            dataGridViewAttendance.RowHeadersVisible = false;
            dataGridViewAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAttendance.BackgroundColor = Color.White;

            dataGridViewAttendance.Columns.Clear();

            
            dataGridViewAttendance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "student_id",
                HeaderText = "Student ID",
                DataPropertyName = "student_id",
                ReadOnly = true
            });

            
            dataGridViewAttendance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "db_student_id",
                HeaderText = "DB ID",
                DataPropertyName = "db_student_id",
                Visible = false
            });

            
            dataGridViewAttendance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "db_grade_id",
                HeaderText = "DB Grade ID",
                DataPropertyName = "db_grade_id",
                Visible = false
            });

            
            dataGridViewAttendance.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "student_name",
                HeaderText = "Student Name",
                DataPropertyName = "student_name",
                ReadOnly = true
            });

            
            dataGridViewAttendance.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "is_present",
                HeaderText = "Present?",
                DataPropertyName = "is_present",
                FalseValue = 0,
                TrueValue = 1
            });
            
            
            dataGridViewAttendance.EnableHeadersVisualStyles = false;
            dataGridViewAttendance.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dataGridViewAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void LoadStudents()
        {
            if (cmbGrade.SelectedItem == null || cmbClass.SelectedItem == null || cmbDate.SelectedItem == null)
            {
                return;
            }

            string selectedGrade = cmbGrade.SelectedItem.ToString();
            string selectedSection = cmbClass.SelectedItem.ToString();
            string selectedDate = cmbDate.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    
                    
                    
                    
                    string query = @"
                        SELECT s.id AS db_student_id, g.id AS db_grade_id, s.student_id, CONCAT(u.firstname, ' ', u.lastname) AS student_name,
                               IFNULL(sa.is_present, 1) AS is_present 
                        FROM student s
                        INNER JOIN users u ON s.users_id = u.id
                        INNER JOIN grade g ON s.grade_id = g.id
                        LEFT JOIN student_attendance sa 
                            ON sa.student_id = s.id AND sa.date = @date
                        WHERE g.grade_level_number = @grade AND g.section = @section AND s.status = 'Active'
                        ORDER BY u.firstname";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@grade", selectedGrade);
                        cmd.Parameters.AddWithValue("@section", selectedSection);
                        cmd.Parameters.AddWithValue("@date", selectedDate);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewAttendance.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveAttendance_Click(object? sender, EventArgs e)
        {
            if (cmbDate.SelectedItem == null)
            {
                MessageBox.Show("Please select a date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridViewAttendance.Rows.Count == 0)
            {
                MessageBox.Show("No students to save attendance for.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedDate = cmbDate.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    int teacherId = 0;
                    string tQuery = "SELECT id FROM teacher WHERE users_id = @uid";
                    using (MySqlCommand tCmd = new MySqlCommand(tQuery, conn))
                    {
                        tCmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        object res = tCmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) teacherId = Convert.ToInt32(res);
                    }
                    if (teacherId == 0)
                    {
                        MessageBox.Show("Teacher ID not found for the logged in user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    
                    
                    foreach (DataGridViewRow row in dataGridViewAttendance.Rows)
                    {
                        string studentId = row.Cells["db_student_id"].Value.ToString();
                        
                        string delQuery = "DELETE FROM student_attendance WHERE student_id = @sid AND date = @date";
                        using (MySqlCommand delCmd = new MySqlCommand(delQuery, conn))
                        {
                            delCmd.Parameters.AddWithValue("@sid", studentId);
                            delCmd.Parameters.AddWithValue("@date", selectedDate);
                            delCmd.ExecuteNonQuery();
                        }
                    }

                    
                    string insQuery = "INSERT INTO student_attendance (student_id, grade_id, date, is_present, marked_by) VALUES (@sid, @gid, @date, @present, @tid)";
                    
                    foreach (DataGridViewRow row in dataGridViewAttendance.Rows)
                    {
                        string studentId = row.Cells["db_student_id"].Value.ToString();
                        string gradeId = row.Cells["db_grade_id"].Value.ToString();
                        int isPresent = Convert.ToInt32(row.Cells["is_present"].Value ?? 0);

                        using (MySqlCommand insCmd = new MySqlCommand(insQuery, conn))
                        {
                            insCmd.Parameters.AddWithValue("@sid", studentId);
                            insCmd.Parameters.AddWithValue("@gid", gradeId);
                            insCmd.Parameters.AddWithValue("@date", selectedDate);
                            insCmd.Parameters.AddWithValue("@present", isPresent);
                            insCmd.Parameters.AddWithValue("@tid", teacherId);
                            insCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Attendance saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dataGridViewAttendance.Rows)
            {
                row.Cells["is_present"].Value = 1;
            }
        }
    }
}
