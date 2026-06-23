namespace SSMS
{
    partial class Loading
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
            components = new System.ComponentModel.Container();
            progressBar1 = new ProgressBar();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            SuspendLayout();
            
            
            
            progressBar1.BackColor = Color.White;
            progressBar1.ForeColor = Color.Green;
            progressBar1.Location = new Point(232, 336);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(433, 29);
            progressBar1.TabIndex = 0;
            progressBar1.Click += progressBar1_Click;
            
            
            
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(323, 374);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 1;
            label1.Text = "<<details>>";
            
            
            
            timer1.Tick += timer1_Tick;
            
            
            
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(671, 336);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 2;
            label2.Text = "<<details>>";
            
            
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loading;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(909, 526);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Loading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading";
            Load += Loading_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
    }
}