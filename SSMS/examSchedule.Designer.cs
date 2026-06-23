namespace SSMS
{
    partial class examSchedule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblGrade = new Label();
            cmbGrade = new ComboBox();
            lblExamType = new Label();
            cmbExamType = new ComboBox();
            lblSubject = new Label();
            cmbSubject = new ComboBox();
            lblDate = new Label();
            dtpExamDate = new DateTimePicker();
            lblStartTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblEndTime = new Label();
            dtpEndTime = new DateTimePicker();
            lblVenue = new Label();
            txtVenue = new TextBox();
            btnSubmit = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(369, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Exam Schedule";
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(50, 100);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(49, 20);
            lblGrade.TabIndex = 1;
            lblGrade.Text = "Grade";
            // 
            // cmbGrade
            // 
            cmbGrade.FormattingEnabled = true;
            cmbGrade.Items.AddRange(new object[] { "Grade 1", "Grade 2", "Grade 3", "Grade 4", "Grade 5", "Grade 6", "Grade 7", "Grade 8", "Grade 9", "Grade 10", "Grade 11", "Grade 12", "Grade 13" });
            cmbGrade.Location = new Point(150, 97);
            cmbGrade.Name = "cmbGrade";
            cmbGrade.Size = new Size(250, 28);
            cmbGrade.TabIndex = 2;
            // 
            // lblExamType
            // 
            lblExamType.AutoSize = true;
            lblExamType.Location = new Point(50, 140);
            lblExamType.Name = "lblExamType";
            lblExamType.Size = new Size(80, 20);
            lblExamType.TabIndex = 3;
            lblExamType.Text = "Exam Type";
            // 
            // cmbExamType
            // 
            cmbExamType.FormattingEnabled = true;
            cmbExamType.Items.AddRange(new object[] { "Term Test", "Spot Test" });
            cmbExamType.Location = new Point(150, 137);
            cmbExamType.Name = "cmbExamType";
            cmbExamType.Size = new Size(250, 28);
            cmbExamType.TabIndex = 4;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(50, 180);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(58, 20);
            lblSubject.TabIndex = 5;
            lblSubject.Text = "Subject";
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(150, 177);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(250, 28);
            cmbSubject.TabIndex = 6;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(50, 220);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(81, 20);
            lblDate.TabIndex = 7;
            lblDate.Text = "Exam Date";
            // 
            // dtpExamDate
            // 
            dtpExamDate.Location = new Point(150, 217);
            dtpExamDate.Name = "dtpExamDate";
            dtpExamDate.Size = new Size(250, 27);
            dtpExamDate.TabIndex = 8;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(50, 260);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(77, 20);
            lblStartTime.TabIndex = 9;
            lblStartTime.Text = "Start Time";
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(150, 257);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(120, 27);
            dtpStartTime.TabIndex = 10;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(50, 300);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(71, 20);
            lblEndTime.TabIndex = 11;
            lblEndTime.Text = "End Time";
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(150, 297);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(120, 27);
            dtpEndTime.TabIndex = 12;
            // 
            // lblVenue
            // 
            lblVenue.AutoSize = true;
            lblVenue.Location = new Point(50, 340);
            lblVenue.Name = "lblVenue";
            lblVenue.Size = new Size(49, 20);
            lblVenue.TabIndex = 13;
            lblVenue.Text = "Venue";
            // 
            // txtVenue
            // 
            txtVenue.Location = new Point(150, 337);
            txtVenue.Name = "txtVenue";
            txtVenue.Size = new Size(250, 27);
            txtVenue.TabIndex = 14;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(0, 135, 80);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(150, 390);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(120, 40);
            btnSubmit.TabIndex = 15;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 135, 80);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 70);
            panel1.TabIndex = 0;
            // 
            // examSchedule
            // 
            ClientSize = new Size(480, 480);
            Controls.Add(btnSubmit);
            Controls.Add(txtVenue);
            Controls.Add(lblVenue);
            Controls.Add(dtpEndTime);
            Controls.Add(lblEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(lblStartTime);
            Controls.Add(dtpExamDate);
            Controls.Add(lblDate);
            Controls.Add(cmbSubject);
            Controls.Add(lblSubject);
            Controls.Add(cmbExamType);
            Controls.Add(lblExamType);
            Controls.Add(cmbGrade);
            Controls.Add(lblGrade);
            Controls.Add(panel1);
            Name = "examSchedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exam Schedule";
            Load += examSchedule_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.Label lblExamType;
        private System.Windows.Forms.ComboBox cmbExamType;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.Button btnSubmit;
    }
}
