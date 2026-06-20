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
            // Set Label colors
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Green;

            // Disable the form during loading
            this.Enabled = false;

            // Set initial values
            label1.Text = "Loading...";
            label2.Text = "0%";
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;

            // Start loading timer
            timer1.Interval = 50; // Update every 50ms
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                // Increase progress randomly (3-8% each tick)
                Random rnd = new Random();
                int increment = rnd.Next(3, 9);

                // Calculate new value but don't exceed 100
                int newValue = progressBar1.Value + increment;

                // Cap the value at 100
                if (newValue > 100) newValue = 100;

                // Update progress bar
                progressBar1.Value = newValue;

                // Update UI
                label2.Text = progressBar1.Value.ToString() + "%";
                label2.ForeColor = Color.Green;

                // Update status messages based on progress
                UpdateStatusMessage(progressBar1.Value);
            }
            else
            {
                // Loading complete
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
            // Set final values
            progressBar1.Value = 100;
            label1.Text = "Loading complete!";
            label2.Text = "100%";
            label2.ForeColor = Color.Green;

            // Enable the form
            this.Enabled = true;

            // Use timer to delay before hiding
            System.Windows.Forms.Timer completionTimer = new System.Windows.Forms.Timer();
            completionTimer.Interval = 300;
            completionTimer.Tick += (s, timerEvent) =>
            {
                completionTimer.Stop();
                completionTimer.Dispose();

                // Hide loading screen and go to Login form
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
            // Create and show the Login form
            Signin loginForm = new Signin();
            loginForm.Show();

            // Hide the current loading form
            this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}