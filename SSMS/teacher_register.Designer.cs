namespace SSMS
{
    partial class teacher_register
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
            lblSystemTitle = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            pf = new PictureBox();
            label9 = new Label();
            txtAd = new RichTextBox();
            label6 = new Label();
            label1 = new Label();
            dtpDob = new DateTimePicker();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            txtLname = new TextBox();
            txtNic = new TextBox();
            nextBtn = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtFname = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            vid = new Label();
            gnsid = new Button();
            submitBtn = new Button();
            txtEmail = new TextBox();
            label8 = new Label();
            txtCn = new TextBox();
            label7 = new Label();
            openFileDialog1 = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pf).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            
            
            
            lblSystemTitle.AutoSize = true;
            lblSystemTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSystemTitle.ForeColor = Color.Green;
            lblSystemTitle.Location = new Point(490, 12);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(360, 46);
            lblSystemTitle.TabIndex = 5;
            lblSystemTitle.Text = "Teachers Registration";
            
            
            
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(12, 72);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1307, 642);
            tabControl1.TabIndex = 7;
            
            
            
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(panel1);
            tabPage1.ForeColor = Color.Green;
            tabPage1.Location = new Point(4, 40);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1299, 598);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "  Personal Info  ";
            
            
            
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pf);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtAd);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpDob);
            panel1.Controls.Add(rbFemale);
            panel1.Controls.Add(rbMale);
            panel1.Controls.Add(txtLname);
            panel1.Controls.Add(txtNic);
            panel1.Controls.Add(nextBtn);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtFname);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1287, 561);
            panel1.TabIndex = 5;
            
            
            
            pf.BorderStyle = BorderStyle.Fixed3D;
            pf.Location = new Point(948, 89);
            pf.Name = "pf";
            pf.Size = new Size(221, 206);
            pf.SizeMode = PictureBoxSizeMode.StretchImage;
            pf.TabIndex = 24;
            pf.TabStop = false;
            pf.Click += pf_Click;
            
            
            
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(977, 35);
            label9.Name = "label9";
            label9.Size = new Size(134, 28);
            label9.TabIndex = 23;
            label9.Text = "Profile Image";
            
            
            
            txtAd.Location = new Point(468, 298);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(340, 40);
            txtAd.TabIndex = 22;
            txtAd.Text = "";
            
            
            
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(468, 267);
            label6.Name = "label6";
            label6.Size = new Size(85, 28);
            label6.TabIndex = 21;
            label6.Text = "Address";
            
            
            
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(468, 145);
            label1.Name = "label1";
            label1.Size = new Size(45, 28);
            label1.TabIndex = 18;
            label1.Text = "NIC";
            
            
            
            dtpDob.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDob.Location = new Point(23, 185);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(387, 38);
            dtpDob.TabIndex = 17;
            
            
            
            rbFemale.AutoSize = true;
            rbFemale.Font = new Font("Segoe UI", 12F);
            rbFemale.Location = new Point(147, 306);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(95, 32);
            rbFemale.TabIndex = 16;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += f_CheckedChanged;
            
            
            
            rbMale.AutoSize = true;
            rbMale.Font = new Font("Segoe UI", 12F);
            rbMale.Location = new Point(23, 306);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(76, 32);
            rbMale.TabIndex = 15;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += m_CheckedChanged;
            
            
            
            txtLname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLname.Location = new Point(468, 66);
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(340, 38);
            txtLname.TabIndex = 14;
            
            
            
            txtNic.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNic.Location = new Point(468, 185);
            txtNic.Name = "txtNic";
            txtNic.Size = new Size(340, 38);
            txtNic.TabIndex = 13;
            
            
            
            nextBtn.BackColor = Color.FromArgb(0, 135, 80);
            nextBtn.FlatAppearance.BorderSize = 0;
            nextBtn.FlatStyle = FlatStyle.Flat;
            nextBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nextBtn.ForeColor = Color.White;
            nextBtn.Location = new Point(468, 429);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(340, 42);
            nextBtn.TabIndex = 11;
            nextBtn.Text = "Next";
            nextBtn.UseVisualStyleBackColor = false;
            nextBtn.Click += nextbtn_Click;
            
            
            
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(23, 145);
            label5.Name = "label5";
            label5.Size = new Size(129, 28);
            label5.TabIndex = 6;
            label5.Text = "Date of Birth";
            
            
            
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(23, 267);
            label4.Name = "label4";
            label4.Size = new Size(90, 31);
            label4.TabIndex = 4;
            label4.Text = "Gender";
            
            
            
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(468, 35);
            label3.Name = "label3";
            label3.Size = new Size(98, 28);
            label3.TabIndex = 2;
            label3.Text = "Last Nme";
            
            
            
            txtFname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFname.Location = new Point(23, 67);
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(340, 38);
            txtFname.TabIndex = 1;
            
            
            
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(23, 35);
            label2.Name = "label2";
            label2.Size = new Size(110, 28);
            label2.TabIndex = 0;
            label2.Text = "First Name";
            
            
            
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(vid);
            tabPage2.Controls.Add(gnsid);
            tabPage2.Controls.Add(submitBtn);
            tabPage2.Controls.Add(txtEmail);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(txtCn);
            tabPage2.Controls.Add(label7);
            tabPage2.Location = new Point(4, 40);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1299, 598);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "   Contact Info  ";
            
            
            
            vid.AutoSize = true;
            vid.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vid.ForeColor = Color.Black;
            vid.Location = new Point(529, 282);
            vid.Name = "vid";
            vid.Size = new Size(188, 28);
            vid.TabIndex = 31;
            vid.Text = "<<GENERATE ID>>";
            
            
            
            gnsid.BackColor = Color.FromArgb(0, 0, 192);
            gnsid.FlatAppearance.BorderSize = 0;
            gnsid.FlatStyle = FlatStyle.Flat;
            gnsid.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gnsid.ForeColor = Color.White;
            gnsid.Location = new Point(460, 189);
            gnsid.Name = "gnsid";
            gnsid.Size = new Size(340, 42);
            gnsid.TabIndex = 30;
            gnsid.Text = "Generate School ID";
            gnsid.UseVisualStyleBackColor = false;
            gnsid.Click += gnsid_Click;
            
            
            
            submitBtn.BackColor = Color.FromArgb(0, 135, 80);
            submitBtn.FlatAppearance.BorderSize = 0;
            submitBtn.FlatStyle = FlatStyle.Flat;
            submitBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitBtn.ForeColor = Color.White;
            submitBtn.Location = new Point(510, 438);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(235, 89);
            submitBtn.TabIndex = 29;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = false;
            submitBtn.Click += submitbtn_Click;
            
            
            
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(124, 95);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(340, 38);
            txtEmail.TabIndex = 28;
            
            
            
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(214, 47);
            label8.Name = "label8";
            label8.Size = new Size(139, 28);
            label8.TabIndex = 27;
            label8.Text = "Email Address";
            label8.Click += label8_Click;
            
            
            
            txtCn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCn.Location = new Point(787, 95);
            txtCn.Name = "txtCn";
            txtCn.Size = new Size(340, 38);
            txtCn.TabIndex = 26;
            
            
            
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(874, 47);
            label7.Name = "label7";
            label7.Size = new Size(162, 28);
            label7.TabIndex = 25;
            label7.Text = "Contact Number";
            
            
            
            openFileDialog1.FileName = "openFileDialog1";
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1331, 724);
            Controls.Add(tabControl1);
            Controls.Add(lblSystemTitle);
            Name = "teacher_register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher Registration";
            Load += teacher_register_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pf).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSystemTitle;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel1;
        private TextBox txtLname;
        private TextBox txtNic;
        private Button nextBtn;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtFname;
        private Label label2;
        private TabPage tabPage2;
        private DateTimePicker dtpDob;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private RichTextBox txtAd;
        private Label label6;
        private Label label1;
        private OpenFileDialog openFileDialog1;
        private TextBox txtEmail;
        private Label label8;
        private TextBox txtCn;
        private Label label7;
        private PictureBox pf;
        private Label label9;
        private Button submitBtn;
        private Button gnsid;
        private Label vid;
    }
}