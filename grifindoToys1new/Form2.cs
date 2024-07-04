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
    public partial class Form2 : Form
    {
        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 obj3 = new Form4();
            obj3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 obj4 = new Form3();
            obj4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 obj5 =new Form5();
            obj5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form6 obj6 = new Form6();
            obj6.Show();
        }
    }
}
