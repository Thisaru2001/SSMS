using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSMS
{
    public partial class TeacherAttendance : Form
    {
        public TeacherAttendance()
        {
            InitializeComponent();
            this.Load += TeacherAttendance_Load;
            this.btnSaveAttendance.Click += BtnSaveAttendance_Click;
            this.btnReset.Click += BtnReset_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void TeacherAttendance_Load(object sender, EventArgs e)
        {
            
            cmbDate.Items.Add(DateTime.Now.ToString("yyyy-MM-dd"));
            cmbDate.SelectedIndex = 0;

            SetupDataGridView();
            LoadTeacherData();
        }

        private void SetupDataGridView()
        {
            dataGridViewAttendance.Columns.Clear();
            
            
            dataGridViewAttendance.BackgroundColor = Color.White;
            dataGridViewAttendance.BorderStyle = BorderStyle.None;
            dataGridViewAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAttendance.EnableHeadersVisualStyles = false;
            
            
            dataGridViewAttendance.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dataGridViewAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridViewAttendance.ColumnHeadersHeight = 45;
            dataGridViewAttendance.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            
            dataGridViewAttendance.DefaultCellStyle.BackColor = Color.White;
            dataGridViewAttendance.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewAttendance.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dataGridViewAttendance.DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewAttendance.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewAttendance.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 245, 238);
            dataGridViewAttendance.RowTemplate.Height = 40;
            dataGridViewAttendance.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewAttendance.GridColor = Color.LightGray;
            
            
            dataGridViewAttendance.RowHeadersVisible = false;
            dataGridViewAttendance.AllowUserToAddRows = false;

            dataGridViewAttendance.Columns.Add("teacher_id", "Teacher ID");
            dataGridViewAttendance.Columns["teacher_id"].Visible = false; 

            dataGridViewAttendance.Columns.Add("employee_id", "Employee ID");
            dataGridViewAttendance.Columns["employee_id"].ReadOnly = true;
            dataGridViewAttendance.Columns["employee_id"].FillWeight = 30;

            dataGridViewAttendance.Columns.Add("teacher_name", "Teacher Name");
            dataGridViewAttendance.Columns["teacher_name"].ReadOnly = true;
            dataGridViewAttendance.Columns["teacher_name"].FillWeight = 45;

            DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn();
            statusCol.Name = "status";
            statusCol.HeaderText = "Attendance Status";
            statusCol.Items.Add("Present");
            statusCol.Items.Add("Absent");
            statusCol.Items.Add("Late");
            statusCol.FillWeight = 25;
            statusCol.FlatStyle = FlatStyle.Flat; 
            dataGridViewAttendance.Columns.Add(statusCol);
        }

        private void LoadTeacherData()
        {
            dataGridViewAttendance.Rows.Clear();
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT t.id, t.employee_id, u.firstname, u.lastname 
                                     FROM teacher t 
                                     JOIN users u ON t.users_id = u.id 
                                     WHERE u.is_active = 1";
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int rowId = dataGridViewAttendance.Rows.Add();
                                DataGridViewRow row = dataGridViewAttendance.Rows[rowId];
                                row.Cells["teacher_id"].Value = reader["id"].ToString();
                                row.Cells["employee_id"].Value = reader["employee_id"].ToString();
                                row.Cells["teacher_name"].Value = reader["firstname"].ToString() + " " + reader["lastname"].ToString();
                                row.Cells["status"].Value = "Present"; 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading teachers: " + ex.Message);
                }
            }
        }

        private void BtnSaveAttendance_Click(object sender, EventArgs e)
        {
            if (cmbDate.SelectedItem == null)
            {
                MessageBox.Show("Please select a date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedDate = cmbDate.SelectedItem.ToString();
            int savedCount = 0;

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    using (MySql.Data.MySqlClient.MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dataGridViewAttendance.Rows)
                            {
                                if (row.IsNewRow) continue;

                                string teacherId = row.Cells["teacher_id"].Value.ToString();
                                string status = row.Cells["status"].Value.ToString();

                                
                                string checkQuery = "SELECT COUNT(*) FROM teacher_attendance WHERE teacher_id = @tid AND date = @date";
                                using (MySql.Data.MySqlClient.MySqlCommand checkCmd = new MySql.Data.MySqlClient.MySqlCommand(checkQuery, conn, trans))
                                {
                                    checkCmd.Parameters.AddWithValue("@tid", teacherId);
                                    checkCmd.Parameters.AddWithValue("@date", selectedDate);
                                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                                    if (exists > 0)
                                    {
                                        
                                        string updateQuery = "UPDATE teacher_attendance SET status = @status WHERE teacher_id = @tid AND date = @date";
                                        using (MySql.Data.MySqlClient.MySqlCommand updCmd = new MySql.Data.MySqlClient.MySqlCommand(updateQuery, conn, trans))
                                        {
                                            updCmd.Parameters.AddWithValue("@status", status);
                                            updCmd.Parameters.AddWithValue("@tid", teacherId);
                                            updCmd.Parameters.AddWithValue("@date", selectedDate);
                                            updCmd.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        
                                        string insertQuery = "INSERT INTO teacher_attendance (teacher_id, date, status, check_in) VALUES (@tid, @date, @status, NOW())";
                                        using (MySql.Data.MySqlClient.MySqlCommand insCmd = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, conn, trans))
                                        {
                                            insCmd.Parameters.AddWithValue("@tid", teacherId);
                                            insCmd.Parameters.AddWithValue("@date", selectedDate);
                                            insCmd.Parameters.AddWithValue("@status", status);
                                            insCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                savedCount++;
                            }
                            trans.Commit();
                            MessageBox.Show($"Attendance saved successfully for {savedCount} teachers!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewAttendance.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["status"].Value = "Present";
                }
            }
        }
    }
}
