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
            label4 = new Label();
            comboBox1 = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            
            
            
            panel1.BackColor = Color.FromArgb(46, 125, 50);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Enabled = true;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1403, 129);
            panel1.TabIndex = 1;
            
            
            
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.73585F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(114, 39);
            label2.Name = "label2";
            label2.Size = new Size(248, 50);
            label2.TabIndex = 1;
            label2.Text = "Exam Results";
            
            
            
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(95, 81);
            label1.TabIndex = 0;
            label1.Text = "🗠";
            
            
            
            btnViewResults.BackColor = Color.FromArgb(46, 125, 50);
            btnViewResults.FlatStyle = FlatStyle.Flat;
            btnViewResults.Font = new Font("Segoe UI", 12.2264156F);
            btnViewResults.ForeColor = Color.White;
            btnViewResults.Location = new Point(1103, 155);
            btnViewResults.Margin = new Padding(3, 4, 3, 4);
            btnViewResults.Name = "btnViewResults";
            btnViewResults.Size = new Size(201, 47);
            btnViewResults.TabIndex = 19;
            btnViewResults.Text = "👁  View Results";
            btnViewResults.UseVisualStyleBackColor = false;
            
            
            
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 170);
            label3.Name = "label3";
            label3.Size = new Size(140, 30);
            label3.TabIndex = 20;
            label3.Text = "Select Grade :";
            
            
            
            cmbExam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbExam.FormattingEnabled = true;
            cmbExam.Location = new Point(165, 171);
            cmbExam.Margin = new Padding(3, 4, 3, 4);
            cmbExam.Name = "cmbExam";
            cmbExam.Size = new Size(155, 36);
            cmbExam.TabIndex = 21;
            
            
            
            dgvResults.BackgroundColor = Color.White;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.GridColor = Color.Silver;
            dgvResults.Location = new Point(18, 222);
            dgvResults.Margin = new Padding(3, 4, 3, 4);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 45;
            dgvResults.Size = new Size(1286, 360);
            dgvResults.TabIndex = 22;
            
            
            
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(453, 170);
            label4.Name = "label4";
            label4.Size = new Size(181, 30);
            label4.TabIndex = 23;
            label4.Text = "Select Exam type :";
            
            
            
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(640, 168);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(155, 36);
            comboBox1.TabIndex = 24;
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1403, 771);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(dgvResults);
            Controls.Add(cmbExam);
            Controls.Add(label3);
            Controls.Add(btnViewResults);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(3, 4, 3, 4);
            Name = "examResults";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exam Results";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
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
        private Label label4;
        private ComboBox comboBox1;
    }
}