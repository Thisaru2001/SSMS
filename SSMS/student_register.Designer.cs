namespace SSMS
{
    partial class student_register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(student_register));
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            btnTeacherRegister = new Button();
            btnStudentRegister = new Button();
            btnTimetable = new Button();
            btnTeacherAttendance = new Button();
            btnProfile = new Button();
            btnNoticeCreate = new Button();
            btnLogout = new Button();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            txtStudentName = new TextBox();
            label4 = new Label();
            cmbClassGrade = new ComboBox();
            label5 = new Label();
            dtpDOB = new DateTimePicker();
            label6 = new Label();
            cmbSection = new ComboBox();
            label7 = new Label();
            txtGuardianName = new TextBox();
            label8 = new Label();
            txtContact = new TextBox();
            label9 = new Label();
            txtAddress = new TextBox();
            btnUploadPhoto = new Button();
            pbStudentPhoto = new PictureBox();
            btnSaveEnrollment = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStudentPhoto).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(btnLogout);
            splitContainer1.Panel1.Controls.Add(btnNoticeCreate);
            splitContainer1.Panel1.Controls.Add(btnProfile);
            splitContainer1.Panel1.Controls.Add(btnTeacherAttendance);
            splitContainer1.Panel1.Controls.Add(btnTimetable);
            splitContainer1.Panel1.Controls.Add(btnStudentRegister);
            splitContainer1.Panel1.Controls.Add(btnTeacherRegister);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Paint += this.splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(245, 247, 245);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
            splitContainer1.Panel2.Paint += this.splitContainer1_Panel2_Paint;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            pictureBox1.Click += this.pictureBox1_Click;
            // 
            // btnTeacherRegister
            // 
            btnTeacherRegister.BackColor = Color.White;
            btnTeacherRegister.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnTeacherRegister, "btnTeacherRegister");
            btnTeacherRegister.ForeColor = Color.Black;
            btnTeacherRegister.Name = "btnTeacherRegister";
            btnTeacherRegister.UseVisualStyleBackColor = false;
            btnTeacherRegister.Click += this.btnTeacherRegister_Click;
            // 
            // btnStudentRegister
            // 
            btnStudentRegister.BackColor = Color.FromArgb(225, 245, 230);
            btnStudentRegister.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnStudentRegister, "btnStudentRegister");
            btnStudentRegister.ForeColor = Color.FromArgb(0, 120, 70);
            btnStudentRegister.Name = "btnStudentRegister";
            btnStudentRegister.UseVisualStyleBackColor = false;
            btnStudentRegister.Click += this.btnStudentRegister_Click;
            // 
            // btnTimetable
            // 
            btnTimetable.BackColor = Color.White;
            btnTimetable.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnTimetable, "btnTimetable");
            btnTimetable.Name = "btnTimetable";
            btnTimetable.UseVisualStyleBackColor = false;
            // 
            // btnTeacherAttendance
            // 
            btnTeacherAttendance.BackColor = Color.White;
            btnTeacherAttendance.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnTeacherAttendance, "btnTeacherAttendance");
            btnTeacherAttendance.Name = "btnTeacherAttendance";
            btnTeacherAttendance.UseVisualStyleBackColor = false;
            btnTeacherAttendance.Click += this.btnTeacherAttendance_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.White;
            btnProfile.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnProfile, "btnProfile");
            btnProfile.Name = "btnProfile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += this.btnProfile_Click;
            // 
            // btnNoticeCreate
            // 
            btnNoticeCreate.BackColor = Color.White;
            btnNoticeCreate.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnNoticeCreate, "btnNoticeCreate");
            btnNoticeCreate.Name = "btnNoticeCreate";
            btnNoticeCreate.UseVisualStyleBackColor = false;
            btnNoticeCreate.Click += this.btnNoticeCreate_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnLogout, "btnLogout");
            btnLogout.Name = "btnLogout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += this.btnLogout_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(0, 120, 70);
            label1.Name = "label1";
            label1.Click += this.label1_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            label2.Click += this.label2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnSaveEnrollment);
            panel1.Controls.Add(pbStudentPhoto);
            panel1.Controls.Add(btnUploadPhoto);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtContact);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtGuardianName);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cmbSection);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dtpDOB);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cmbClassGrade);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtStudentName);
            panel1.Controls.Add(label3);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // txtStudentName
            // 
            resources.ApplyResources(txtStudentName, "txtStudentName");
            txtStudentName.Name = "txtStudentName";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // cmbClassGrade
            // 
            cmbClassGrade.FormattingEnabled = true;
            resources.ApplyResources(cmbClassGrade, "cmbClassGrade");
            cmbClassGrade.Name = "cmbClassGrade";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // dtpDOB
            // 
            dtpDOB.Format = DateTimePickerFormat.Short;
            resources.ApplyResources(dtpDOB, "dtpDOB");
            dtpDOB.Name = "dtpDOB";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // cmbSection
            // 
            cmbSection.AutoCompleteSource = AutoCompleteSource.AllUrl;
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.FormattingEnabled = true;
            resources.ApplyResources(cmbSection, "cmbSection");
            cmbSection.Name = "cmbSection";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // txtGuardianName
            // 
            resources.ApplyResources(txtGuardianName, "txtGuardianName");
            txtGuardianName.Name = "txtGuardianName";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // txtContact
            // 
            resources.ApplyResources(txtContact, "txtContact");
            txtContact.Name = "txtContact";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // txtAddress
            // 
            resources.ApplyResources(txtAddress, "txtAddress");
            txtAddress.Name = "txtAddress";
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.BackColor = Color.FromArgb(0, 135, 80);
            btnUploadPhoto.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnUploadPhoto, "btnUploadPhoto");
            btnUploadPhoto.ForeColor = Color.White;
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.UseVisualStyleBackColor = false;
            // 
            // pbStudentPhoto
            // 
            pbStudentPhoto.BackColor = Color.FromArgb(230, 230, 230);
            resources.ApplyResources(pbStudentPhoto, "pbStudentPhoto");
            pbStudentPhoto.Name = "pbStudentPhoto";
            pbStudentPhoto.TabStop = false;
            // 
            // btnSaveEnrollment
            // 
            btnSaveEnrollment.BackColor = Color.FromArgb(0, 135, 80);
            btnSaveEnrollment.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnSaveEnrollment, "btnSaveEnrollment");
            btnSaveEnrollment.ForeColor = Color.White;
            btnSaveEnrollment.Name = "btnSaveEnrollment";
            btnSaveEnrollment.UseVisualStyleBackColor = false;
            // 
            // student_register
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "student_register";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStudentPhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnStudentRegister;
        private Button btnTeacherRegister;
        private PictureBox pictureBox1;
        private Button btnProfile;
        private Button btnTeacherAttendance;
        private Button btnTimetable;
        private Button btnLogout;
        private Button btnNoticeCreate;
        private Label label1;
        private Panel panel1;
        private TextBox txtStudentName;
        private Label label3;
        private Label label2;
        private ComboBox cmbSection;
        private Label label6;
        private DateTimePicker dtpDOB;
        private Label label5;
        private ComboBox cmbClassGrade;
        private Label label4;
        private TextBox txtAddress;
        private Label label9;
        private TextBox txtContact;
        private Label label8;
        private TextBox txtGuardianName;
        private Label label7;
        private Button btnSaveEnrollment;
        private PictureBox pbStudentPhoto;
        private Button btnUploadPhoto;
    }
}