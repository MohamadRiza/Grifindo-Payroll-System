using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace grifindoToys1new
{
    
    public partial class Form11 : Form
    {
        SqlConnection con = null;
        public Form11()
        {
            con = new SqlConnection("Data Source=DELL\\MSSQLSERVER01;Initial Catalog=grifindonew2;Integrated Security=True");//third3step
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string to_date = todate.Value.ToString("yyyy-MM-dd");
            string from_date = fromdate.Value.ToString("yyyy-MM-dd");
            //MessageBox.Show("todate: '" + to_date + "', star_date: '" + from_date + "'");

            try
            {
                con.Open();
                string query = "select SUM(no_pay_value), SUM(base_pay_value), SUM(gross_pay_value) from salary_reports WHERE date BETWEEN '"+from_date+"' AND '"+to_date+"'";
                //MessageBox.Show(query);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    v_no_pay.Text = rdr[0].ToString();
                    v_base_pay.Text = rdr[1].ToString();
                    v_gross_pay.Text = rdr[2].ToString();                   
                    
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 obj22 = new Form2();
            obj22.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 obj1 = new Form1();
            obj1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
