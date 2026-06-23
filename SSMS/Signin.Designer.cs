namespace SSMS
{
    partial class Signin
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
            txtStudentId = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            
            
            
            txtStudentId.BorderStyle = BorderStyle.None;
            txtStudentId.Font = new Font("Segoe UI", 16.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtStudentId.ForeColor = Color.Green;
            txtStudentId.Location = new Point(864, 350);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(385, 38);
            txtStudentId.TabIndex = 0;
            
            
            
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 16.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Green;
            txtPassword.Location = new Point(864, 459);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(385, 38);
            txtPassword.TabIndex = 1;
            
            
            
            btnLogin.BackgroundImage = Properties.Resources.button;
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(3, 33);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(467, 77);
            btnLogin.TabIndex = 2;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click_1;
            
            
            
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnLogin);
            panel1.Location = new Point(792, 575);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 181);
            panel1.TabIndex = 3;
            
            
            
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.White;
            checkBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = Color.Green;
            checkBox1.Location = new Point(800, 525);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(150, 29);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Remember Me";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            
            
            
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(1113, 526);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 5;
            label1.Text = "Forgot Password";
            label1.Click += label1_Click;
            
            
            
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(763, 47);
            label2.Name = "label2";
            label2.Size = new Size(187, 31);
            label2.TabIndex = 6;
            label2.Text = "<<Validation>>";
            
            
            
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Green;
            label3.Location = new Point(800, 305);
            label3.Name = "label3";
            label3.Size = new Size(111, 31);
            label3.TabIndex = 7;
            label3.Text = "SchoolID";
            
            
            
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(800, 415);
            label4.Name = "label4";
            label4.Size = new Size(114, 31);
            label4.TabIndex = 8;
            label4.Text = "Password";
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1405, 902);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(panel1);
            Controls.Add(txtPassword);
            Controls.Add(txtStudentId);
            Name = "Signin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Signin";
            Load += Signin_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStudentId;
        private TextBox txtPassword;
        private Button btnLogin;
        private Panel panel1;
        private CheckBox checkBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}