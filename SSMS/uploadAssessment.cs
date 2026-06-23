using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class uploadAssessment : Form
    {
        private int _loggedInUserId;

        public uploadAssessment(int loggedInUserId)
        {
            _loggedInUserId = loggedInUserId;
            InitializeComponent();
            this.Load += UploadAssessment_Load;
            btnBrowse.Click += BtnBrowse_Click;
            btnUpload.Click += BtnUpload_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void UploadAssessment_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            cmbSubject.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, subject_name FROM subject";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbSubject.DataSource = dt;
                        cmbSubject.DisplayMember = "subject_name";
                        cmbSubject.ValueMember = "id";
                    }
                    if (cmbSubject.Items.Count > 0)
                        cmbSubject.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subjects: " + ex.Message);
                }
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Assessment File";
                ofd.Filter = "All Files (*.*)|*.*|PDF Files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAssessmentTitle.Text) ||
                string.IsNullOrWhiteSpace(cmbSubject.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Please fill all fields and select a file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    
                    
                    string getStudentQuery = "SELECT id FROM student WHERE users_id = @uid";
                    int studentId = 0;
                    using (MySqlCommand getCmd = new MySqlCommand(getStudentQuery, conn))
                    {
                        getCmd.Parameters.AddWithValue("@uid", _loggedInUserId);
                        object result = getCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            studentId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Error: Student record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    
                    string destFolder = System.IO.Path.Combine(Application.StartupPath, "Assessments");
                    if (!System.IO.Directory.Exists(destFolder))
                    {
                        System.IO.Directory.CreateDirectory(destFolder);
                    }
                    string ext = System.IO.Path.GetExtension(txtFilePath.Text);
                    string newFileName = $"Assessment_{studentId}_{DateTime.Now.Ticks}{ext}";
                    string destPath = System.IO.Path.Combine(destFolder, newFileName);
                    System.IO.File.Copy(txtFilePath.Text, destPath, true);

                    string query = "INSERT INTO assessment (student_id, subject_id, assessment_title, file_path) VALUES (@studentId, @subjectId, @title, @filePath)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@subjectId", Convert.ToInt32(cmbSubject.SelectedValue));
                        cmd.Parameters.AddWithValue("@title", txtAssessmentTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@filePath", "Assessments/" + newFileName);
                        
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Assessment uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        txtAssessmentTitle.Clear();
                        txtFilePath.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
