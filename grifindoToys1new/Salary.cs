using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//1st
using System.Linq.Expressions;
using System.Xml.Linq;

namespace grifindoToys1new
{
    public partial class Form3 : Form
    {
        SqlConnection con = null;//2ndstep
        public Form3()
        {
            con = new SqlConnection("Data Source=DELL\\MSSQLSERVER01;Initial Catalog=grifindonew2;Integrated Security=True");//third3step
            InitializeComponent();
        }
        private void loadmntcmbo()
        {
            try
            {
                con.Open();

                //string query = "SELECT month FROM settingtbl";
                //SqlCommand cmd = new SqlCommand(query, con);
                //SqlDataReader rdr;
                //rdr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Columns.Add("month", typeof(string));
                //dt.Load(rdr);
                //comboBoxmonth.ValueMember = "month";
                //comboBoxmonth.DataSource = dt;



                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        private void loadnme()
        {
            try
            {
                con.Open();

                string query = "SELECT name FROM employeetbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("name",typeof(string));
                dt.Load(rdr);
                //comboBoxemployeename.DataSource = dt;
                //comboBoxemployeename.ValueMember = "name";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            //comboBoxmonth.ResetText();
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindonew2DataSet5.employeetbl' table. You can move, or remove it, as needed.
            this.employeetblTableAdapter.Fill(this.grifindonew2DataSet5.employeetbl);
            // TODO: This line of code loads data into the 'grifindonew2DataSet3.employeetbl' table. You can move, or remove it, as needed.
            //this.employeetblTableAdapter.Fill(this.grifindonew2DataSet3.employeetbl);


        }

        private void comboBoxemployeename_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxmonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            if (txtlvs.Text == "")
            {
                MessageBox.Show("Please enter the number of leaves");
            }
            else if ( txtothrs.Text == "")
            {
                MessageBox.Show("Please enter the OT Hours");
            }
            else
            {
                double abent_days = double.Parse(txtlvs.Text);
                double ot_hours = double.Parse(txtothrs.Text);
                double total_days = 0;
                double total_worked_days = 0;
                double no_pay = 0;
                double allowance = 0.0;
                double ot_rate = 0;
                double base_pay_value = 0;

                //now typed
                double tax_rate = 0.0;
                double grosspay = 0;

                double monthly_salary = 0.0;
                double salary_cycle_date_range = 0;

                DateTime start = dateTimePicker1.Value;
                DateTime end = dateTimePicker2.Value;
                string salary_date = dateTimePicker2.Value.ToShortDateString();

                string start_date_db = "";
                string end_date_db = "";
                string start_date = dateTimePicker1.Value.ToString("dd");
                string end_date = dateTimePicker2.Value.ToString("dd");

                int id = int.Parse(comboBoxempud.Text);

                try
                {
                    con.Open();
                    string query = "SELECT end_date,start_date FROM settingtbl where id=1";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        end_date_db = rdr[0].ToString();
                        start_date_db = rdr[1].ToString();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }

                if (!start_date_db.Equals(start_date))
                {
                    MessageBox.Show("The start date is not Valid. The valid start date should be '" + start_date_db + "'");
                }
                else if (!end_date_db.Equals(end_date))
                {
                    MessageBox.Show("The End date is not Valid. The valid start date should be '" + end_date_db + "'");
                }
                else if (dateTimePicker1.Value.CompareTo(dateTimePicker2.Value) > 0 || dateTimePicker1.Value.CompareTo(dateTimePicker2.Value) == 0 )
                {
                    MessageBox.Show("End can not be earlier or equal to start date. Please select a proper date");
                }
                else
                {        
                    try 
                    { 
                        con.Open();
                        string query = "SELECT month_salary,allowance,ot_ammount FROM employeetbl where id='"+id+"'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader rdr;
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            monthly_salary = double.Parse(rdr[0].ToString());
                            allowance = double.Parse(rdr[1].ToString());
                            ot_rate = double.Parse(rdr[2].ToString());
                        }
                        //MessageBox.Show("monthly salary= '" + monthly_salary + "'");
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }

                    
                    try
                    {
                        con.Open();
                        string query = "SELECT date_range,tax_rate FROM settingtbl where id=1";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader rdr;
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            salary_cycle_date_range = double.Parse(rdr[0].ToString());
                            tax_rate = double.Parse(rdr[1].ToString());




                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }

                    // Calculate No Pay value
                    TimeSpan t = end - start;
                    total_days = t.TotalDays;

                    total_worked_days = total_days - abent_days;

                    if (total_worked_days < salary_cycle_date_range)
                    {
                        no_pay = (monthly_salary / salary_cycle_date_range) * abent_days;
                    }
                    else
                    {
                        no_pay = 0;
                    }
                    base_pay_value = monthly_salary + allowance + (ot_rate * ot_hours);
                    //gross pay
                    grosspay = base_pay_value - no_pay + (base_pay_value * tax_rate);

                    //MessageBox.Show("INSERT INTO salary_reports(no_pay_value, base_pay_value, gross_pay_value, emp_id, date) VALUES('" + no_pay + "', '" + base_pay_value + "', '" + grosspay + "', '" + id + "', '" + salary_date + "')");

                    try
                    {

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO salary_reports (no_pay_value,base_pay_value,gross_pay_value,emp_id,date) VALUES ('" + no_pay + "','" + base_pay_value + "','" + grosspay + "','" + id + "','" + salary_date + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("salary calculate success ful...!");
                        txtlvs.Clear();
                        txtothrs.Clear();
                        comboBoxempud.ResetText();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error msg" + ex);
                    }
                }
            }
            
            
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            txtlvs.Clear();
            txtothrs.Clear();
            comboBoxempud.ResetText();
        }
    }
}