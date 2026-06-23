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
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            
            
            
            panel1.BackColor = Color.FromArgb(46, 125, 50);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;

            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1239, 129);
            panel1.TabIndex = 25;
            
            
            
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.73585F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(114, 39);
            label2.Name = "label2";
            label2.Size = new Size(359, 50);
            label2.TabIndex = 1;
            label2.Text = "Upload Assessment";
            
            
            
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(113, 81);
            label1.TabIndex = 0;
            label1.Text = "➜]";
            
            
            
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 16.2F);
            label3.Location = new Point(49, 194);
            label3.Name = "label3";
            label3.Size = new Size(223, 38);
            label3.TabIndex = 27;
            label3.Text = "Assessment Title";
            
            
            
            btnUpload.BackColor = Color.FromArgb(46, 125, 50);
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 12.2264156F);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(367, 504);
            btnUpload.Margin = new Padding(3, 4, 3, 4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(201, 47);
            btnUpload.TabIndex = 26;
            btnUpload.Text = "🢁  Upload";
            btnUpload.UseVisualStyleBackColor = false;
            
            
            
            txtAssessmentTitle.Font = new Font("Segoe UI", 16.2F);
            txtAssessmentTitle.Location = new Point(298, 191);
            txtAssessmentTitle.Margin = new Padding(3, 4, 3, 4);
            txtAssessmentTitle.Name = "txtAssessmentTitle";
            txtAssessmentTitle.Size = new Size(313, 43);
            txtAssessmentTitle.TabIndex = 28;
            
            
            
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 16.2F);
            label4.Location = new Point(164, 294);
            label4.Name = "label4";
            label4.Size = new Size(108, 38);
            label4.TabIndex = 29;
            label4.Text = "Subject";
            
            
            
            txtFilePath.Font = new Font("Segoe UI", 16.2F);
            txtFilePath.Location = new Point(298, 390);
            txtFilePath.Margin = new Padding(3, 4, 3, 4);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(215, 43);
            txtFilePath.TabIndex = 32;
            
            
            
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 16.2F);
            label5.Location = new Point(112, 393);
            label5.Name = "label5";
            label5.Size = new Size(160, 38);
            label5.TabIndex = 31;
            label5.Text = "Choose File";
            
            
            
            cmbSubject.Font = new Font("Segoe UI", 16.2F);
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(298, 290);
            cmbSubject.Margin = new Padding(3, 4, 3, 4);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(313, 45);
            cmbSubject.TabIndex = 33;
            
            
            
            openFileDialog1.FileName = "openFileDialog1";
            
            
            
            btnBrowse.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowse.Location = new Point(519, 391);
            btnBrowse.Margin = new Padding(3, 4, 3, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(92, 44);
            btnBrowse.TabIndex = 34;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            
            
            
            pictureBox1.BackgroundImage = Properties.Resources.ChatGPT_Image_Jun_23__2026__01_37_16_AM;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(703, 187);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(443, 364);
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1239, 716);
            Controls.Add(pictureBox1);
            Controls.Add(btnBrowse);
            Controls.Add(cmbSubject);
            Controls.Add(txtFilePath);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtAssessmentTitle);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(btnUpload);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uploadAssessment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "uploadAssessment";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}