namespace SSMS
{
    partial class pNoticeCreate
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
            pnlHeader = new Panel();
            lblPName = new Label();
            label2 = new Label();
            label1 = new Label();
            pnlContent = new Panel();
            btnPublish = new Button();
            rtbContent = new RichTextBox();
            label5 = new Label();
            txtTitle = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            chkTeachers = new CheckBox();
            chkStudents = new CheckBox();
            chkAll = new CheckBox();
            label3 = new Label();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblPName);
            pnlHeader.Controls.Add(label2);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(783, 137);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // lblPName
            // 
            lblPName.AutoSize = true;
            lblPName.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            lblPName.Location = new Point(159, 77);
            lblPName.Name = "lblPName";
            lblPName.Size = new Size(88, 25);
            lblPName.TabIndex = 2;
            lblPName.Text = "<Name>";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            label2.Location = new Point(54, 77);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 1;
            label2.Text = "Welcome,";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18.3396225F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(46, 125, 50);
            label1.Location = new Point(45, 20);
            label1.Name = "label1";
            label1.Size = new Size(535, 37);
            label1.TabIndex = 0;
            label1.Text = "SMART SCHOOL MANAGEMENT SYSTEM";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(btnPublish);
            pnlContent.Controls.Add(rtbContent);
            pnlContent.Controls.Add(label5);
            pnlContent.Controls.Add(txtTitle);
            pnlContent.Controls.Add(label4);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label3);
            pnlContent.Location = new Point(12, 159);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(745, 475);
            pnlContent.TabIndex = 1;
            // 
            // btnPublish
            // 
            btnPublish.BackColor = Color.FromArgb(46, 125, 50);
            btnPublish.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPublish.ForeColor = Color.White;
            btnPublish.Location = new Point(529, 414);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(162, 36);
            btnPublish.TabIndex = 9;
            btnPublish.Text = "Publish Notice";
            btnPublish.UseVisualStyleBackColor = false;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(43, 222);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(671, 186);
            rtbContent.TabIndex = 8;
            rtbContent.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 181);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 7;
            label5.Text = "Content";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(45, 132);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(593, 31);
            txtTitle.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 93);
            label4.Name = "label4";
            label4.Size = new Size(182, 25);
            label4.TabIndex = 5;
            label4.Text = "Notice Title/Subject";
            // 
            // panel1
            // 
            panel1.Controls.Add(chkTeachers);
            panel1.Controls.Add(chkStudents);
            panel1.Controls.Add(chkAll);
            panel1.Location = new Point(45, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(593, 38);
            panel1.TabIndex = 4;
            // 
            // chkTeachers
            // 
            chkTeachers.AutoSize = true;
            chkTeachers.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkTeachers.Location = new Point(201, 6);
            chkTeachers.Name = "chkTeachers";
            chkTeachers.Size = new Size(105, 29);
            chkTeachers.TabIndex = 2;
            chkTeachers.Text = "Teachers";
            chkTeachers.UseVisualStyleBackColor = true;
            // 
            // chkStudents
            // 
            chkStudents.AutoSize = true;
            chkStudents.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkStudents.Location = new Point(403, 6);
            chkStudents.Name = "chkStudents";
            chkStudents.Size = new Size(106, 29);
            chkStudents.TabIndex = 3;
            chkStudents.Text = "Students";
            chkStudents.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            chkAll.AutoSize = true;
            chkAll.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAll.Location = new Point(30, 6);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(54, 29);
            chkAll.TabIndex = 1;
            chkAll.Text = "All";
            chkAll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 0);
            label3.Name = "label3";
            label3.Size = new Size(206, 25);
            label3.TabIndex = 0;
            label3.Text = "Select Recipient Group";
            // 
            // pNoticeCreate
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(783, 687);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Name = "pNoticeCreate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoticeCreate";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label label1;
        private Label label2;
        private Label lblPName;
        private Panel pnlContent;
        private CheckBox chkStudents;
        private CheckBox chkTeachers;
        private CheckBox chkAll;
        private Label label3;
        private Button btnPublish;
        private RichTextBox rtbContent;
        private Label label5;
        private TextBox txtTitle;
        private Label label4;
        private Panel panel1;
    }
}