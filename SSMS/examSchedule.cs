using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class examSchedule : Form
    {
        public examSchedule()
        {
            InitializeComponent();
            this.Load += ExamSchedule_Load;
            this.btnSubmit.Click += BtnSubmit_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void ExamSchedule_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();


                    string qSub = "SELECT id, subject_name FROM subject";
                    using (MySqlCommand cmd = new MySqlCommand(qSub, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbSubject.DataSource = dt;
                        cmbSubject.DisplayMember = "subject_name";
                        cmbSubject.ValueMember = "id";
                    }


                    string qGrade = "SELECT id, CONCAT('Grade ', grade_level_number, ' - ', section) AS grade_name FROM grade";
                    using (MySqlCommand cmd = new MySqlCommand(qGrade, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbGrade.Items.Clear();
                        cmbGrade.DataSource = dt;
                        cmbGrade.DisplayMember = "grade_name";
                        cmbGrade.ValueMember = "id";
                    }


                    string qExam = "SELECT id, exam_name FROM exam";
                    using (MySqlCommand cmd = new MySqlCommand(qExam, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbExamType.Items.Clear();
                        cmbExamType.DataSource = dt;
                        cmbExamType.DisplayMember = "exam_name";
                        cmbExamType.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            if (cmbGrade.SelectedItem == null || cmbExamType.SelectedItem == null || cmbSubject.SelectedValue == null || string.IsNullOrWhiteSpace(txtVenue.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = @"INSERT INTO exam_schedule (grade_id, exam_id, subject_id, exam_date, start_time, end_time, hall) 
                                     VALUES (@gradeId, @examId, @subjectId, @examDate, @startTime, @endTime, @venue)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gradeId", cmbGrade.SelectedValue);
                        cmd.Parameters.AddWithValue("@examId", cmbExamType.SelectedValue);
                        cmd.Parameters.AddWithValue("@subjectId", cmbSubject.SelectedValue);
                        cmd.Parameters.AddWithValue("@examDate", dtpExamDate.Value.Date);
                        cmd.Parameters.AddWithValue("@startTime", dtpStartTime.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@endTime", dtpEndTime.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@venue", txtVenue.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Exam Schedule created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void examSchedule_Load_1(object sender, EventArgs e)
        {

        }
    }
}
