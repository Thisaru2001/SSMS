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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(864, 350);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(385, 40);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(864, 459);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(385, 40);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.button;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(3, 33);
            button1.Name = "button1";
            button1.Size = new Size(467, 77);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Location = new Point(792, 575);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 181);
            panel1.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(800, 524);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(150, 29);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Remember Me";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1113, 526);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 5;
            label1.Text = "Forgot Password";
            // 
            // Signin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1405, 902);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(panel1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Signin";
            Text = "Signin";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Panel panel1;
        private CheckBox checkBox1;
        private Label label1;
    }
}