using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SSMS
{
    public partial class profile : Form
    {
        private string currentImagePath = "";
        private int _userId;
        private string _role;

        public profile(int userId, string role)
        {
            InitializeComponent();
            _userId = userId;
            _role = role;
            this.Load += Profile_Load;
            button2.Click += BtnUpload_Click;
            button1.Click += BtnSave_Click;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                if (_role.ToLower() == "principal")
                {
                    query = $"SELECT u.firstname, u.lastname, u.email, u.phone, u.nic, u.address, u.gender, u.date_of_birth, u.image_path, p.employee_id, p.qualification FROM users u LEFT JOIN principal p ON u.id = p.users_id WHERE u.id = {_userId}";
                }
                else if (_role.ToLower() == "principal_assistant")
                {
                    query = $"SELECT u.firstname, u.lastname, u.email, u.phone, u.nic, u.address, u.gender, u.date_of_birth, u.image_path, pa.employee_id, pa.qualification FROM users u LEFT JOIN principal_assistant pa ON u.id = pa.users_id WHERE u.id = {_userId}";
                }
                else if (_role.ToLower() == "teacher")
                {
                    query = $"SELECT u.firstname, u.lastname, u.email, u.phone, u.nic, u.address, u.gender, u.date_of_birth, u.image_path, t.employee_id, t.qualification FROM users u LEFT JOIN teacher t ON u.id = t.users_id WHERE u.id = {_userId}";
                }
                else
                {
                    query = $"SELECT u.firstname, u.lastname, u.email, u.phone, u.nic, u.address, u.gender, u.date_of_birth, u.image_path, s.student_id as employee_id, '' as qualification FROM users u LEFT JOIN student s ON u.id = s.users_id WHERE u.id = {_userId}";
                }

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    textBox1.Text = row["employee_id"].ToString();
                    textBox2.Text = row["firstname"].ToString() + " " + row["lastname"].ToString();
                    textBox3.Text = row["email"].ToString();
                    textBox4.Text = row["phone"].ToString();
                    
                    textBoxNIC.Text = row["nic"].ToString();
                    textBoxGender.Text = row["gender"].ToString();
                    if (row["date_of_birth"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["date_of_birth"].ToString()))
                    {
                        textBoxDOB.Text = Convert.ToDateTime(row["date_of_birth"]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        textBoxDOB.Text = "N/A";
                    }
                    textBoxAddress.Text = row["address"].ToString();
                    textBoxQual.Text = row["qualification"].ToString();

                    if (_role.ToLower() == "student")
                    {
                        labelQual.Visible = false;
                        textBoxQual.Visible = false;
                    }

                    currentImagePath = row["image_path"].ToString();
                    if (!string.IsNullOrEmpty(currentImagePath))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, currentImagePath);
                        if (File.Exists(fullPath))
                        {
                            pictureBox1.Image = Image.FromFile(fullPath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(ofd.FileName);
                        string newFileName = $"profile_{_userId}_{DateTime.Now.Ticks}{ext}";
                        string folder = Path.Combine(Application.StartupPath, "ProfileImages");
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string destPath = Path.Combine(folder, newFileName);
                        File.Copy(ofd.FileName, destPath, true);
                        
                        currentImagePath = $"ProfileImages/{newFileName}";
                        pictureBox1.Image = Image.FromFile(destPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error uploading image: " + ex.Message);
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                string query = $@"UPDATE users 
                                  SET email = '{textBox3.Text}', 
                                      phone = '{textBox4.Text}', 
                                      address = '{textBoxAddress.Text}', 
                                      image_path = '{currentImagePath}' 
                                  WHERE id = {_userId}";
                DatabaseHelper.ExecuteNonQuery(query);
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
