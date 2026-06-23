namespace SSMS
{
    partial class TeacherAttendance
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
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnReset = new Button();
            btnSaveAttendance = new Button();
            dataGridViewAttendance = new DataGridView();
            cmbDate = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).BeginInit();
            SuspendLayout();
            
            
            
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(402, 111);
            label2.Name = "label2";
            label2.Size = new Size(70, 31);
            label2.TabIndex = 11;
            label2.Text = "Date:";
            
            
            
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1073, 87);
            panel1.TabIndex = 10;
            
            
            
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(402, 26);
            label1.Name = "label1";
            label1.Size = new Size(259, 38);
            label1.TabIndex = 1;
            label1.Text = "Teacher Attndance";
            
            
            
            pictureBox1.Location = new Point(30, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(83, 79);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            
            
            
            btnReset.BackColor = Color.FromArgb(192, 255, 192);
            btnReset.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.DarkGreen;
            btnReset.Location = new Point(573, 595);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(232, 41);
            btnReset.TabIndex = 19;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            
            
            
            btnSaveAttendance.BackColor = Color.FromArgb(192, 255, 192);
            btnSaveAttendance.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveAttendance.ForeColor = Color.DarkGreen;
            btnSaveAttendance.Location = new Point(261, 594);
            btnSaveAttendance.Name = "btnSaveAttendance";
            btnSaveAttendance.Size = new Size(235, 41);
            btnSaveAttendance.TabIndex = 18;
            btnSaveAttendance.Text = "Save Attendance";
            btnSaveAttendance.UseVisualStyleBackColor = false;
            
            
            
            dataGridViewAttendance.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAttendance.Location = new Point(58, 174);
            dataGridViewAttendance.Name = "dataGridViewAttendance";
            dataGridViewAttendance.RowHeadersWidth = 51;
            dataGridViewAttendance.Size = new Size(912, 383);
            dataGridViewAttendance.TabIndex = 17;
            
            
            
            cmbDate.FormattingEnabled = true;
            cmbDate.Location = new Point(490, 115);
            cmbDate.Name = "cmbDate";
            cmbDate.Size = new Size(220, 28);
            cmbDate.TabIndex = 14;
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1073, 686);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnSaveAttendance);
            Controls.Add(dataGridViewAttendance);
            Controls.Add(cmbDate);
            Name = "TeacherAttendance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher Attendance";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnReset;
        private Button btnSaveAttendance;
        private DataGridView dataGridViewAttendance;
        private ComboBox cmbDate;
    }
}