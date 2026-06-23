namespace SSMS
{
    partial class addmarks
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
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbGrade = new ComboBox();
            cmbSubject = new ComboBox();
            cmbExam = new ComboBox();
            dataGridViewMarks = new DataGridView();
            btnSaveMarks = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1150, 106);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(427, 34);
            label2.Name = "label2";
            label2.Size = new Size(328, 46);
            label2.TabIndex = 2;
            label2.Text = "Add Student Marks";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 82);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(94, 158);
            label3.Name = "label3";
            label3.Size = new Size(83, 31);
            label3.TabIndex = 1;
            label3.Text = "Grade:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(458, 161);
            label4.Name = "label4";
            label4.Size = new Size(100, 31);
            label4.TabIndex = 2;
            label4.Text = "Subject:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(806, 162);
            label5.Name = "label5";
            label5.Size = new Size(78, 31);
            label5.TabIndex = 3;
            label5.Text = "Exam:";
            // 
            // cmbGrade
            // 
            cmbGrade.FormattingEnabled = true;
            cmbGrade.Location = new Point(181, 164);
            cmbGrade.Name = "cmbGrade";
            cmbGrade.Size = new Size(204, 28);
            cmbGrade.TabIndex = 4;
            // 
            // cmbSubject
            // 
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(565, 168);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(190, 28);
            cmbSubject.TabIndex = 5;
            // 
            // cmbExam
            // 
            cmbExam.FormattingEnabled = true;
            cmbExam.Location = new Point(904, 165);
            cmbExam.Name = "cmbExam";
            cmbExam.Size = new Size(194, 28);
            cmbExam.TabIndex = 6;
            // 
            // dataGridViewMarks
            // 
            dataGridViewMarks.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarks.GridColor = SystemColors.InactiveBorder;
            dataGridViewMarks.Location = new Point(140, 254);
            dataGridViewMarks.Name = "dataGridViewMarks";
            dataGridViewMarks.RowHeadersWidth = 51;
            dataGridViewMarks.Size = new Size(860, 344);
            dataGridViewMarks.TabIndex = 7;
            // 
            // btnSaveMarks
            // 
            btnSaveMarks.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveMarks.ForeColor = Color.Green;
            btnSaveMarks.Location = new Point(489, 636);
            btnSaveMarks.Name = "btnSaveMarks";
            btnSaveMarks.Size = new Size(205, 50);
            btnSaveMarks.TabIndex = 8;
            btnSaveMarks.Text = "Save Marks";
            btnSaveMarks.UseVisualStyleBackColor = true;
            // 
            // addmarks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1150, 708);
            Controls.Add(btnSaveMarks);
            Controls.Add(dataGridViewMarks);
            Controls.Add(cmbExam);
            Controls.Add(cmbSubject);
            Controls.Add(cmbGrade);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "addmarks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addmarks";
            Load += addmarks_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbGrade;
        private ComboBox cmbSubject;
        private ComboBox cmbExam;
        private DataGridView dataGridViewMarks;
        private Button btnSaveMarks;
    }
}