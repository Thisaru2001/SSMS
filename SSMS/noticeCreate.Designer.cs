namespace SSMS
{
    partial class noticeCreate
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
            btnClear = new Button();
            dtpNoticeDate = new DateTimePicker();
            rtbNotice = new RichTextBox();
            txtTitle = new TextBox();
            label3 = new Label();
            btnPublish = new Button();
            label2 = new Label();
            label1 = new Label();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(681, 520);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 40);
            btnClear.TabIndex = 19;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // dtpNoticeDate
            // 
            dtpNoticeDate.Format = DateTimePickerFormat.Short;
            dtpNoticeDate.Location = new Point(455, 407);
            dtpNoticeDate.Name = "dtpNoticeDate";
            dtpNoticeDate.Size = new Size(221, 25);
            dtpNoticeDate.TabIndex = 17;
            // 
            // rtbNotice
            // 
            rtbNotice.BorderStyle = BorderStyle.FixedSingle;
            rtbNotice.Font = new Font("Segoe UI", 10.18868F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbNotice.Location = new Point(456, 179);
            rtbNotice.Name = "rtbNotice";
            rtbNotice.Size = new Size(571, 186);
            rtbNotice.TabIndex = 16;
            rtbNotice.Text = "";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(456, 116);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(571, 25);
            txtTitle.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(338, 413);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 14;
            label3.Text = "Date :";
            // 
            // btnPublish
            // 
            btnPublish.BackColor = Color.FromArgb(46, 125, 50);
            btnPublish.FlatStyle = FlatStyle.Flat;
            btnPublish.ForeColor = Color.White;
            btnPublish.Location = new Point(455, 520);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(150, 40);
            btnPublish.TabIndex = 18;
            btnPublish.Text = "Publish Notice";
            btnPublish.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(338, 179);
            label2.Name = "label2";
            label2.Size = new Size(53, 17);
            label2.TabIndex = 13;
            label2.Text = "Notice :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(338, 124);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 12;
            label1.Text = "Title :";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.White;
            lblTitle.FlatStyle = FlatStyle.Flat;
            lblTitle.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(46, 125, 50);
            lblTitle.Location = new Point(557, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(146, 30);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Create Notice";
            // 
            // noticeCreate
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1084, 609);
            Controls.Add(btnClear);
            Controls.Add(dtpNoticeDate);
            Controls.Add(rtbNotice);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(btnPublish);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Name = "noticeCreate";
            Text = "noticeCreate";
            Load += noticeCreate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClear;
        private DateTimePicker dtpNoticeDate;
        private RichTextBox rtbNotice;
        private TextBox txtTitle;
        private Label label3;
        private Button btnPublish;
        private Label label2;
        private Label label1;
        private Label lblTitle;
    }
}