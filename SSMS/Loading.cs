using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace SSMS
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Green;

            
            this.Enabled = false;

            
            label1.Text = "Loading...";
            label2.Text = "0%";
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;

            
            timer1.Interval = 50; 
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                
                Random rnd = new Random();
                int increment = rnd.Next(3, 9);

                
                int newValue = progressBar1.Value + increment;

                
                if (newValue > 100) newValue = 100;

                
                progressBar1.Value = newValue;

                
                label2.Text = progressBar1.Value.ToString() + "%";
                label2.ForeColor = Color.Green;

                
                UpdateStatusMessage(progressBar1.Value);
            }
            else
            {
                
                timer1.Stop();
                CompleteLoading();
            }
        }

        private void UpdateStatusMessage(int progress)
        {
            if (progress < 15)
            {
                label1.Text = "Loading configuration...";
            }
            else if (progress < 30)
            {
                label1.Text = "Connecting to database...";
            }
            else if (progress < 45)
            {
                label1.Text = "Fetching user data...";
            }
            else if (progress < 60)
            {
                label1.Text = "Loading settings...";
            }
            else if (progress < 75)
            {
                label1.Text = "Initializing components...";
            }
            else if (progress < 90)
            {
                label1.Text = "Preparing interface...";
            }
            else
            {
                label1.Text = "Finalizing load...";
            }
        }

        private void CompleteLoading()
        {
            
            progressBar1.Value = 100;
            label1.Text = "Loading complete!";
            label2.Text = "100%";
            label2.ForeColor = Color.Green;

            
            this.Enabled = true;

            
            System.Windows.Forms.Timer completionTimer = new System.Windows.Forms.Timer();
            completionTimer.Interval = 300;
            completionTimer.Tick += (s, timerEvent) =>
            {
                completionTimer.Stop();
                completionTimer.Dispose();

                
                HideLoadingScreen();
                GoToLogin();
            };
            completionTimer.Start();
        }

        private void HideLoadingScreen()
        {
            progressBar1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
        }

        private void GoToLogin()
        {
            
            Signin loginForm = new Signin();
            loginForm.Show();

            
            this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}