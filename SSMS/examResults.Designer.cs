namespace SSMS
{
    partial class examResults
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
            label1 = new Label();
            btnViewResults = new Button();
            label3 = new Label();
            cmbExam = new ComboBox();
            dgvResults = new DataGridView();
            panel2 = new Panel();
            label4 = new Label();
            label5 = new Label();
            lblPercentage = new Label();
            panel3 = new Panel();
            lblGrade = new Label();
            label8 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(46, 125, 50);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Enabled = false;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1228, 110);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.73585F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(100, 33);
            label2.Name = "label2";
            label2.Size = new Size(215, 45);
            label2.TabIndex = 1;
            label2.Text = "Exam Results";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(83, 71);
            label1.TabIndex = 0;
            label1.Text = "🗠";
            // 
            // btnViewResults
            // 
            btnViewResults.BackColor = Color.FromArgb(46, 125, 50);
            btnViewResults.FlatStyle = FlatStyle.Flat;
            btnViewResults.Font = new Font("Segoe UI", 12.2264156F);
            btnViewResults.ForeColor = Color.White;
            btnViewResults.Location = new Point(503, 135);
            btnViewResults.Name = "btnViewResults";
            btnViewResults.Size = new Size(176, 40);
            btnViewResults.TabIndex = 19;
            btnViewResults.Text = "👁  View Results";
            btnViewResults.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 146);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 20;
            label3.Text = "Select Exam :";
            // 
            // cmbExam
            // 
            cmbExam.FormattingEnabled = true;
            cmbExam.Location = new Point(153, 146);
            cmbExam.Name = "cmbExam";
            cmbExam.Size = new Size(260, 25);
            cmbExam.TabIndex = 21;
            // 
            // dgvResults
            // 
            dgvResults.BackgroundColor = Color.White;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.GridColor = Color.Silver;
            dgvResults.Location = new Point(16, 189);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 45;
            dgvResults.Size = new Size(1125, 306);
            dgvResults.TabIndex = 22;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblPercentage);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(100, 510);
            panel2.Name = "panel2";
            panel2.Size = new Size(253, 115);
            panel2.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 22);
            label4.Name = "label4";
            label4.Size = new Size(125, 17);
            label4.TabIndex = 0;
            label4.Text = "Average Percentage";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 27.8490562F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(46, 125, 50);
            label5.Location = new Point(22, 28);
            label5.Name = "label5";
            label5.Size = new Size(53, 55);
            label5.TabIndex = 1;
            label5.Text = "🗎";
            // 
            // lblPercentage
            // 
            lblPercentage.AutoSize = true;
            lblPercentage.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPercentage.ForeColor = Color.FromArgb(46, 125, 50);
            lblPercentage.Location = new Point(81, 58);
            lblPercentage.Name = "lblPercentage";
            lblPercentage.Size = new Size(124, 25);
            lblPercentage.TabIndex = 2;
            lblPercentage.Text = "<percentage>";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(lblGrade);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(454, 510);
            panel3.Name = "panel3";
            panel3.Size = new Size(253, 115);
            panel3.TabIndex = 24;
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGrade.ForeColor = Color.FromArgb(46, 125, 50);
            lblGrade.Location = new Point(81, 58);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(82, 25);
            lblGrade.TabIndex = 2;
            lblGrade.Text = "<grade>";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 27.8490562F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(46, 125, 50);
            label8.Location = new Point(22, 28);
            label8.Name = "label8";
            label8.Size = new Size(58, 55);
            label8.TabIndex = 1;
            label8.Text = "☆";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(90, 22);
            label9.Name = "label9";
            label9.Size = new Size(74, 17);
            label9.TabIndex = 0;
            label9.Text = "Final Grade";
            // 
            // examResults
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1228, 655);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(dgvResults);
            Controls.Add(cmbExam);
            Controls.Add(label3);
            Controls.Add(btnViewResults);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Name = "examResults";
            Text = "Exam Results";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button btnViewResults;
        private Label label3;
        private ComboBox cmbExam;
        private DataGridView dgvResults;
        private Panel panel2;
        private Label label5;
        private Label label4;
        private Label lblPercentage;
        private Panel panel3;
        private Label lblGrade;
        private Label label8;
        private Label label9;
    }
}