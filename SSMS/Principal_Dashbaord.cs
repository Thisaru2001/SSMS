using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSMS
{
    public partial class Principal_Dashbaord : Form
    {
        public Principal_Dashbaord()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Principal_Dashbaord_Load(object sender, EventArgs e)
        {

        }

        private void btnTeacherRegister_Click(object sender, EventArgs e)
        {
            teacher_register teacher_Register = new teacher_register();
            teacher_Register.Show();
        }
    }
}
