using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grifindoToys1new
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = txtusn.Text;
            string password = txtpsswd.Text;

            if (email=="grifindo" && password == "toys")
            {
                //MessageBox.Show("Welcome To Grifindo Payroll System!");
                this.Hide();
                Form2 obj = new Form2();
                obj.Show();
                
            }
            else
            {
                MessageBox.Show("Check Username and password");
            }
        }

        private void txtusn_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
