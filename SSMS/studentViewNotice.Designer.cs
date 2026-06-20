namespace SSMS
{
    partial class studentViewNotice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnRefresh = new Button();
            label2 = new Label();
            label1 = new Label();
            dgvNotices = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotices).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(46, 125, 50);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Enabled = false;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1084, 110);
            panel1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.FromArgb(46, 125, 50);
            btnRefresh.Location = new Point(911, 38);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(148, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "⟳ Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.73585F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(100, 33);
            label2.Name = "label2";
            label2.Size = new Size(214, 45);
            label2.TabIndex = 1;
            label2.Text = "View Notices";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.73585F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(35, 33);
            label1.Name = "label1";
            label1.Size = new Size(49, 45);
            label1.TabIndex = 0;
            label1.Text = "🕭";
            // 
            // dgvNotices
            // 
            dgvNotices.BackgroundColor = Color.White;
            dgvNotices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotices.GridColor = Color.Silver;
            dgvNotices.Location = new Point(22, 127);
            dgvNotices.Name = "dgvNotices";
            dgvNotices.RowHeadersWidth = 45;
            dgvNotices.Size = new Size(1037, 454);
            dgvNotices.TabIndex = 1;
            // 
            // studentViewNotice
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1084, 609);
            Controls.Add(dgvNotices);
            Controls.Add(panel1);
            Name = "studentViewNotice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Notice";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRefresh;
        private Label label2;
        private Label label1;
        private DataGridView dgvNotices;
    }
}