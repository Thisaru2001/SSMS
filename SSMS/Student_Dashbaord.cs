using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSMS
{
    public partial class Student_Dashbaord : Form
    {
        private int _loggedInUserId;

        public Student_Dashbaord(int userId)
        {
            InitializeComponent();
            _loggedInUserId = userId;

            
            this.Load += Student_Dashbaord_Load;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void Student_Dashbaord_Load(object sender, EventArgs e)
        {
            LoadName();
            LoadProfileImage();
            LoadAttendance();
            LoadNotices();
            AddAiAssistantButton();
        }

        private void AddAiAssistantButton()
        {
            Button btnAiAssistant = new Button();
            btnAiAssistant.BackColor = Color.Green;
            btnAiAssistant.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAiAssistant.ForeColor = Color.White;
            btnAiAssistant.Location = new Point(96, 139); 
            btnAiAssistant.Name = "btnAiAssistant";
            btnAiAssistant.Size = new Size(250, 59);
            btnAiAssistant.TabIndex = 20;
            btnAiAssistant.Text = "AI chatbot";
            btnAiAssistant.UseVisualStyleBackColor = false;
            btnAiAssistant.Click += BtnAiAssistant_Click;
            
            
            panel5.Controls.Add(btnAiAssistant);
            btnAiAssistant.BringToFront(); 
        }

        private void BtnAiAssistant_Click(object sender, EventArgs e)
        {
            try 
            {
                AiAssistantForm aiForm = new AiAssistantForm(_loggedInUserId);
                aiForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open AI Assistant:\n{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadName()
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT firstname, lastname FROM users WHERE id = @id";
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _loggedInUserId);
                        using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["firstname"].ToString();
                                string lastName = reader["lastname"].ToString();
                                label1.Text = $"{firstName} {lastName}";
                            }
                            else
                            {
                                label1.Text = "Student";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = "Welcome, Student";
                    MessageBox.Show("Error loading name: " + ex.Message);
                }
            }
        }

        private void LoadProfileImage()
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT image_path FROM users WHERE id = @id";
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _loggedInUserId);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string imagePath = result.ToString();
                            if (System.IO.File.Exists(imagePath))
                            {
                                pictureBox1.Image = Image.FromFile(imagePath);
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void LoadAttendance()
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    
                    string getStudentIdQuery = "SELECT id FROM student WHERE users_id = @id";
                    int studentId = 0;
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getStudentIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _loggedInUserId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            studentId = Convert.ToInt32(result);
                        }
                    }

                    if (studentId == 0)
                    {
                        label3.Text = "0%";
                        return;
                    }

                    
                    string query = @"SELECT ROUND((COUNT(CASE WHEN is_present = 1 THEN 1 END) / COUNT(*)) * 100, 0) 
                                     FROM student_attendance WHERE student_id = @sid";
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", studentId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            label3.Text = result.ToString() + "%";
                        }
                        else
                        {
                            label3.Text = "0%";
                        }
                    }
                }
                catch (Exception)
                {
                    label3.Text = "0%";
                }
            }
        }

        private void LoadNotices()
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM notice WHERE date = CURDATE()";
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            label5.Text = result.ToString();
                        }
                        else
                        {
                            label5.Text = "0";
                        }
                    }
                }
                catch (Exception)
                {
                    label5.Text = "0";
                }
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            profile profileForm = new profile(_loggedInUserId, "student");
            profileForm.ShowDialog();
            
            LoadName();
            LoadProfileImage();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            examResults examForm = new examResults(_loggedInUserId);
            examForm.ShowDialog();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            uploadAssessment uploadForm = new uploadAssessment(_loggedInUserId);
            uploadForm.Show();
        }


    }
}
