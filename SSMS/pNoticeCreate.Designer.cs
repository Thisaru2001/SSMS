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
            
            
            
            pnlHeader.Controls.Add(lblPName);
            pnlHeader.Controls.Add(label2);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(895, 161);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            
            
            
            lblPName.AutoSize = true;
            lblPName.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            lblPName.Location = new Point(182, 91);
            lblPName.Name = "lblPName";
            lblPName.Size = new Size(101, 30);
            lblPName.TabIndex = 2;
            lblPName.Text = "<Name>";
            
            
            
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold);
            label2.Location = new Point(62, 91);
            label2.Name = "label2";
            label2.Size = new Size(109, 30);
            label2.TabIndex = 1;
            label2.Text = "Welcome,";
            
            
            
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18.3396225F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(46, 125, 50);
            label1.Location = new Point(51, 24);
            label1.Name = "label1";
            label1.Size = new Size(619, 42);
            label1.TabIndex = 0;
            label1.Text = "SMART SCHOOL MANAGEMENT SYSTEM";
            
            
            
            pnlContent.Controls.Add(btnPublish);
            pnlContent.Controls.Add(rtbContent);
            pnlContent.Controls.Add(label5);
            pnlContent.Controls.Add(txtTitle);
            pnlContent.Controls.Add(label4);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(label3);
            pnlContent.Location = new Point(14, 187);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(851, 559);
            pnlContent.TabIndex = 1;
            
            
            
            btnPublish.BackColor = Color.FromArgb(46, 125, 50);
            btnPublish.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPublish.ForeColor = Color.White;
            btnPublish.Location = new Point(605, 487);
            btnPublish.Margin = new Padding(3, 4, 3, 4);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(185, 42);
            btnPublish.TabIndex = 9;
            btnPublish.Text = "Publish Notice";
            btnPublish.UseVisualStyleBackColor = false;
            btnPublish.Click += btnPublish_Click_1;
            
            
            
            rtbContent.Location = new Point(49, 261);
            rtbContent.Margin = new Padding(3, 4, 3, 4);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(766, 218);
            rtbContent.TabIndex = 8;
            rtbContent.Text = "";
            
            
            
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(33, 213);
            label5.Name = "label5";
            label5.Size = new Size(92, 30);
            label5.TabIndex = 7;
            label5.Text = "Content";
            
            
            
            txtTitle.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(51, 155);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(677, 35);
            txtTitle.TabIndex = 6;
            
            
            
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 109);
            label4.Name = "label4";
            label4.Size = new Size(209, 30);
            label4.TabIndex = 5;
            label4.Text = "Notice Title/Subject";
            
            
            
            panel1.Controls.Add(chkTeachers);
            panel1.Controls.Add(chkStudents);
            panel1.Controls.Add(chkAll);
            panel1.Location = new Point(51, 33);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 45);
            panel1.TabIndex = 4;
            
            
            
            chkTeachers.AutoSize = true;
            chkTeachers.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkTeachers.Location = new Point(230, 7);
            chkTeachers.Margin = new Padding(3, 4, 3, 4);
            chkTeachers.Name = "chkTeachers";
            chkTeachers.Size = new Size(118, 34);
            chkTeachers.TabIndex = 2;
            chkTeachers.Text = "Teachers";
            chkTeachers.UseVisualStyleBackColor = true;
            
            
            
            chkStudents.AutoSize = true;
            chkStudents.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkStudents.Location = new Point(461, 7);
            chkStudents.Margin = new Padding(3, 4, 3, 4);
            chkStudents.Name = "chkStudents";
            chkStudents.Size = new Size(121, 34);
            chkStudents.TabIndex = 3;
            chkStudents.Text = "Students";
            chkStudents.UseVisualStyleBackColor = true;
            
            
            
            chkAll.AutoSize = true;
            chkAll.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAll.Location = new Point(34, 7);
            chkAll.Margin = new Padding(3, 4, 3, 4);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(62, 34);
            chkAll.TabIndex = 1;
            chkAll.Text = "All";
            chkAll.UseVisualStyleBackColor = true;
            
            
            
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 0);
            label3.Name = "label3";
            label3.Size = new Size(236, 30);
            label3.TabIndex = 0;
            label3.Text = "Select Recipient Group";
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(895, 808);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
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