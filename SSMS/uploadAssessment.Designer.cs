namespace SSMS
{
    partial class uploadAssessment
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
            label3 = new Label();
            btnUpload = new Button();
            txtAssessmentTitle = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label4 = new Label();
            txtFilePath = new TextBox();
            label5 = new Label();
            cmbSubject = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            btnBrowse = new Button();
            panel1.SuspendLayout();
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
            panel1.Size = new Size(1084, 110);
            panel1.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.73585F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(100, 33);
            label2.Name = "label2";
            label2.Size = new Size(311, 45);
            label2.TabIndex = 1;
            label2.Text = "Upload Assessment";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(99, 71);
            label1.TabIndex = 0;
            label1.Text = "➜]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 134);
            label3.Name = "label3";
            label3.Size = new Size(143, 25);
            label3.TabIndex = 27;
            label3.Text = "Assessment Title";
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(46, 125, 50);
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 12.2264156F);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(300, 532);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(176, 40);
            btnUpload.TabIndex = 26;
            btnUpload.Text = "🢁  Upload";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // txtAssessmentTitle
            // 
            txtAssessmentTitle.Location = new Point(180, 140);
            txtAssessmentTitle.Name = "txtAssessmentTitle";
            txtAssessmentTitle.Size = new Size(274, 25);
            txtAssessmentTitle.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 211);
            label4.Name = "label4";
            label4.Size = new Size(70, 25);
            label4.TabIndex = 29;
            label4.Text = "Subject";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(180, 289);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(189, 25);
            txtFilePath.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(33, 289);
            label5.Name = "label5";
            label5.Size = new Size(103, 25);
            label5.TabIndex = 31;
            label5.Text = "Choose File";
            // 
            // cmbSubject
            // 
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(180, 211);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(274, 25);
            cmbSubject.TabIndex = 33;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(371, 289);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(83, 25);
            btnBrowse.TabIndex = 34;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // uploadAssessment
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1084, 609);
            Controls.Add(btnBrowse);
            Controls.Add(cmbSubject);
            Controls.Add(txtFilePath);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtAssessmentTitle);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(btnUpload);
            Name = "uploadAssessment";
            Text = "uploadAssessment";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button btnUpload;
        private TextBox txtAssessmentTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label4;
        private TextBox txtFilePath;
        private Label label5;
        private ComboBox cmbSubject;
        private OpenFileDialog openFileDialog1;
        private Button btnBrowse;
    }
}