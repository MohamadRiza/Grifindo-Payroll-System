using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace grifindoToys1new
{
    public partial class Form9 : Form
    {
        SqlConnection con = null;
        public Form9()
        {
            con = new SqlConnection("Data Source=DELL\\MSSQLSERVER01;Initial Catalog=grifindonew2;Integrated Security=True");//third3step
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

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindonew2DataSet6.employeetbl' table. You can move, or remove it, as needed.
            this.employeetblTableAdapter.Fill(this.grifindonew2DataSet6.employeetbl);

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            s_date.Text = "";
            s_emp_id.Text = "";
            s_emp_name.Text = "";
            s_addrss.Text = "";
            s_b_salary.Text = "";
            s_allowance.Text = "";
            s_ot_rate.Text = "";
            s_no_pay_value.Text = "";
            s_base_pay_value.Text = "";
            s_gross_pay_value.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            int emp_id = int.Parse(comboBox1.Text);
            string salary_date = dateTimePicker1.Value.ToString("yyyy-MM");

            try
            {
                con.Open();
                string query = "select r.date,e.id,e.name,e.address,e.month_salary,e.allowance,e.ot_ammount,r.no_pay_value,r.base_pay_value,r.gross_pay_value from employeetbl e INNER JOIN salary_reports r ON e.id=r.emp_id where e.id='" + emp_id+"' AND r.date like '%"+salary_date+"%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    s_date.Text = rdr[0].ToString();
                    s_emp_id.Text = rdr[1].ToString();
                    s_emp_name.Text = rdr[2].ToString();
                    s_addrss.Text = rdr[3].ToString();
                    s_b_salary.Text = rdr[4].ToString();
                    s_allowance.Text = rdr[5].ToString();
                    s_ot_rate.Text = rdr[6].ToString();
                    s_no_pay_value.Text = rdr[7].ToString();
                    s_base_pay_value.Text = rdr[8].ToString();
                    s_gross_pay_value.Text = rdr[9].ToString();

                    
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
