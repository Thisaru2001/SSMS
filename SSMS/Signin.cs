using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   
using DotNetEnv;            

namespace SSMS
{
    public partial class Signin : Form
    {
       
        private string connectionString;

        public Signin()
        {
            InitializeComponent();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
      
        }

      
        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            
        }

       
      

        // Checkbox for showing/hiding password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}