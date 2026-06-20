namespace SSMS
{
    partial class CreateNotice
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTitle = new TextBox();
            rtbNotice = new RichTextBox();
            dtDate = new DateTimePicker();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1150, 97);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(24, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(106, 86);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(441, 21);
            label1.Name = "label1";
            label1.Size = new Size(236, 46);
            label1.TabIndex = 1;
            label1.Text = "Create Notice";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(150, 181);
            label2.Name = "label2";
            label2.Size = new Size(83, 38);
            label2.TabIndex = 1;
            label2.Text = "Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(150, 336);
            label3.Name = "label3";
            label3.Size = new Size(111, 38);
            label3.TabIndex = 2;
            label3.Text = "Notice:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(150, 510);
            label4.Name = "label4";
            label4.Size = new Size(87, 38);
            label4.TabIndex = 3;
            label4.Text = "Date:";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(320, 185);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(286, 34);
            txtTitle.TabIndex = 4;
            // 
            // rtbNotice
            // 
            rtbNotice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbNotice.Location = new Point(320, 336);
            rtbNotice.Name = "rtbNotice";
            rtbNotice.Size = new Size(425, 120);
            rtbNotice.TabIndex = 5;
            rtbNotice.Text = "";
            // 
            // dtDate
            // 
            dtDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtDate.Location = new Point(320, 510);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(325, 34);
            dtDate.TabIndex = 6;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Green;
            button1.Location = new Point(421, 615);
            button1.Name = "button1";
            button1.Size = new Size(209, 48);
            button1.TabIndex = 7;
            button1.Text = "Publish Notice";
            button1.UseVisualStyleBackColor = true;
            // 
            // CreateNotice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1150, 708);
            Controls.Add(button1);
            Controls.Add(dtDate);
            Controls.Add(rtbNotice);
            Controls.Add(txtTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateNotice";
            Text = "CreateNotice";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTitle;
        private RichTextBox rtbNotice;
        private DateTimePicker dtDate;
        private Button button1;
    }
}