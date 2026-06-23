using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class examResults : Form
    {
        private int _userId;

        public examResults(int userId)
        {
            InitializeComponent();
            _userId = userId;
            this.Load += ExamResults_Load;
            btnViewResults.Click += BtnViewResults_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void ExamResults_Load(object sender, EventArgs e)
        {
            
            cmbExam.Items.Clear();
            cmbExam.Items.AddRange(new string[] { "Grade 1", "Grade 2", "Grade 3", "Grade 4", "Grade 5", "Grade 6", "Grade 7", "Grade 8", "Grade 9", "Grade 10", "Grade 11", "Grade 12", "Grade 13" });
            if (cmbExam.Items.Count > 0)
                cmbExam.SelectedIndex = 0;

            
            comboBox1.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT exam_name FROM exam";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["exam_name"].ToString());
                        }
                    }
                }
                catch { } 
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            dgvResults.AllowUserToAddRows = false;
            dgvResults.ReadOnly = true;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnViewResults_Click(object sender, EventArgs e)
        {
            string selectedExam = comboBox1.SelectedItem?.ToString();
            
            if (string.IsNullOrEmpty(selectedExam))
            {
                MessageBox.Show("Please select an exam type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    
                    
                    
                    string query = @"
                        SELECT 
                            subj.subject_name AS 'Subject', 
                            sm.marks AS 'Marks', 
                            sm.total_marks AS 'Total', 
                            sm.grade_letter AS 'Grade', 
                            sm.remarks AS 'Remarks'
                        FROM student_marks sm
                        JOIN subject subj ON sm.subject_id = subj.id
                        JOIN exam e ON sm.exam_id = e.id
                        JOIN student s ON sm.student_id = s.id
                        WHERE s.users_id = @userId 
                          AND e.exam_name = @examName";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        cmd.Parameters.AddWithValue("@examName", selectedExam);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvResults.DataSource = dt;
                            
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No marks found for the selected exam.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading results: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
