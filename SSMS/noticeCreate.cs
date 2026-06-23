using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class noticeCreate : Form
    {
        private int _loggedInUserId;

        public noticeCreate(int loggedInUserId)
        {
            _loggedInUserId = loggedInUserId;
            InitializeComponent();
            this.Load += noticeCreate_Load;
            btnPublish.Click += BtnPublish_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void noticeCreate_Load(object sender, EventArgs e)
        {
            dtpNoticeDate.Value = DateTime.Now;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string content = rtbNotice.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Please enter both a title and content for the notice.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    
                    string query = "INSERT INTO notice (title, body, target_group, posted_by, notice_date) VALUES (@Title, @Body, 'Students', @PostedBy, @NoticeDate)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Body", content);
                        cmd.Parameters.AddWithValue("@PostedBy", _loggedInUserId);
                        cmd.Parameters.AddWithValue("@NoticeDate", dtpNoticeDate.Value.Date);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Notice published successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error publishing notice: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            rtbNotice.Clear();
            dtpNoticeDate.Value = DateTime.Now;
        }
    }
}
