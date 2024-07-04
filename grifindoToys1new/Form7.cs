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
using System.Data.Common;

namespace grifindoToys1new
{
    public partial class Form7 : Form
    {
        SqlConnection con = null;
        public Form7()
        {
            con = new SqlConnection("Data Source=DELL\\MSSQLSERVER01;Initial Catalog=grifindonew2;Integrated Security=True");//third3step
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindonew2DataSet7.employeetbl' table. You can move, or remove it, as needed.
            this.employeetblTableAdapter.Fill(this.grifindonew2DataSet7.employeetbl);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(Emp_id.Text);
            string startdate1 = startdate.Value.ToString("yyyy-MM-dd");
            string enddate = enddate22.Value.ToString("yyyy-MM-dd");

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select r.date as 'Date', e.id as 'Empoyee ID', e.name as 'Employee Name', e.month_salary as 'Basic Salary', e.allowance as 'Allowance',e.ot_ammount as 'OT Rate', r.no_pay_value as 'No Pay Value', r.base_pay_value as 'Base Pay Value', r.gross_pay_value as 'Gross Pay Value' from employeetbl e INNER JOIN salary_reports r ON e.id=r.emp_id where e.id=" + empid + " AND r.date BETWEEN '"+startdate1+"' AND '"+enddate+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                //dataGridView1.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }
    }
}
