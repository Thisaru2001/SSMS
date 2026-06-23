namespace SSMS
{
    partial class studentAttendance
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
            label5 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbDate = new ComboBox();
            cmbGrade = new ComboBox();
            cmbClass = new ComboBox();
            dataGridViewAttendance = new DataGridView();
            btnSaveAttendance = new Button();
            btnReset = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).BeginInit();
            SuspendLayout();
            
            
            
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1150, 87);
            panel1.TabIndex = 0;
            
            
            
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(753, 30);
            label5.Name = "label5";
            label5.Size = new Size(201, 28);
            label5.TabIndex = 2;
            label5.Text = "Student Attendance";
            
            
            
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(119, 20);
            label1.Name = "label1";
            label1.Size = new Size(478, 38);
            label1.TabIndex = 1;
            label1.Text = "Smart School Management System";
            
            
            
            pictureBox1.Location = new Point(30, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(83, 79);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            
            
            
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 128);
            label2.Name = "label2";
            label2.Size = new Size(70, 31);
            label2.TabIndex = 1;
            label2.Text = "Date:";
            
            
            
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(448, 128);
            label3.Name = "label3";
            label3.Size = new Size(83, 31);
            label3.TabIndex = 2;
            label3.Text = "Grade:";
            
            
            
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(802, 128);
            label4.Name = "label4";
            label4.Size = new Size(73, 31);
            label4.TabIndex = 3;
            label4.Text = "Class:";
            
            
            
            cmbDate.FormattingEnabled = true;
            cmbDate.Location = new Point(177, 131);
            cmbDate.Name = "cmbDate";
            cmbDate.Size = new Size(220, 28);
            cmbDate.TabIndex = 4;
            
            
            
            cmbGrade.FormattingEnabled = true;
            cmbGrade.Location = new Point(537, 131);
            cmbGrade.Name = "cmbGrade";
            cmbGrade.Size = new Size(206, 28);
            cmbGrade.TabIndex = 5;
            
            
            
            cmbClass.FormattingEnabled = true;
            cmbClass.Location = new Point(881, 131);
            cmbClass.Name = "cmbClass";
            cmbClass.Size = new Size(217, 28);
            cmbClass.TabIndex = 6;
            
            
            
            dataGridViewAttendance.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAttendance.Location = new Point(128, 200);
            dataGridViewAttendance.Name = "dataGridViewAttendance";
            dataGridViewAttendance.RowHeadersWidth = 51;
            dataGridViewAttendance.Size = new Size(912, 383);
            dataGridViewAttendance.TabIndex = 7;
            
            
            
            btnSaveAttendance.BackColor = Color.FromArgb(192, 255, 192);
            btnSaveAttendance.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveAttendance.ForeColor = Color.DarkGreen;
            btnSaveAttendance.Location = new Point(331, 635);
            btnSaveAttendance.Name = "btnSaveAttendance";
            btnSaveAttendance.Size = new Size(235, 41);
            btnSaveAttendance.TabIndex = 8;
            btnSaveAttendance.Text = "Save Attendance";
            btnSaveAttendance.UseVisualStyleBackColor = false;
            
            
            
            btnReset.BackColor = Color.FromArgb(192, 255, 192);
            btnReset.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.DarkGreen;
            btnReset.Location = new Point(643, 635);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(232, 41);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1150, 708);
            Controls.Add(btnReset);
            Controls.Add(btnSaveAttendance);
            Controls.Add(dataGridViewAttendance);
            Controls.Add(cmbClass);
            Controls.Add(cmbGrade);
            Controls.Add(cmbDate);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "studentAttendance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentAttendance";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbDate;
        private ComboBox cmbGrade;
        private ComboBox cmbClass;
        private DataGridView dataGridViewAttendance;
        private Button btnSaveAttendance;
        private Button btnReset;
        private Label label5;
    }
}