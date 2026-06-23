using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SSMS
{
    public partial class studentViewNotice : Form
    {
        public studentViewNotice()
        {
            InitializeComponent();
            this.Load += StudentViewNotice_Load;
            btnRefresh.Click += BtnRefresh_Click;
        }

        private string GetConnectionString()
        {
            return EnvironmentConfig.GetConnectionString();
        }

        private void StudentViewNotice_Load(object sender, EventArgs e)
        {
            LoadNotices();
            ConfigureGrid();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotices();
        }

        private void ConfigureGrid()
        {
            dgvNotices.AllowUserToAddRows = false;
            dgvNotices.ReadOnly = true;
            dgvNotices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotices.RowHeadersVisible = false;
            
            dgvNotices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvNotices.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dgvNotices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNotices.EnableHeadersVisualStyles = false;
            dgvNotices.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
        }

        private void LoadNotices()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            n.title AS 'Title', 
                            n.body AS 'Message', 
                            DATE_FORMAT(n.notice_date, '%Y-%m-%d') AS 'Date', 
                            u.firstname AS 'Posted By'
                        FROM notice n
                        JOIN users u ON n.posted_by = u.id
                        WHERE n.target_group IN ('All', 'Students')
                        ORDER BY n.created_at DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNotices.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading notices: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
