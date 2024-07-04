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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 obj1 = new Form1();
            obj1.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 obj22 = new Form2();
            obj22.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7 obj227 = new Form7();
            obj227.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form9 obj2271 = new Form9();
            obj2271.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form11 obj227 = new Form11();
            obj227.Show();
        }
    }
}
