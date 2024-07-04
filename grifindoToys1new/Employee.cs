using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//1
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace grifindoToys1new
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DELL\\MSSQLSERVER01;Initial Catalog=grifindonew2;Integrated Security=True");//2
        public Form4()
        {
            
            InitializeComponent();
            pictureBox6.Hide();
            pictureBox7.Hide();
            pictureBox9.Hide();
        }
        private void loadtable()
        {
            try
            {
                con.Open();
                SqlCommand cmd  = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT * FROM employeetbl";
                cmd.ExecuteNonQuery();

                DataTable dt  = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource= dt;

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Delete.....!", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //delete custemer code
                    string id = txtempid.Text;

                    cmd.CommandText = "DELETE FROM employeetbl WHERE id = '" + id + "'";
                    cmd.ExecuteNonQuery();
                    //con close
                    con.Close();
                    //message box
                    MessageBox.Show("Data has been Deleted....!");
                    //load above table
                    clear();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {//update
            try
            {
                if (MessageBox.Show("Are you sure to Update?","Update Record",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    string id = txtempid.Text;
                    string name = txtname.Text;
                    string position = comboBoxempposition.SelectedItem.ToString();
                    string age = txtage.Text;
                    string address = txtadrs.Text;
                    string nic = txtnic.Text;
                    string email = txtmail.Text;

                    double msalary = Convert.ToDouble(txtmonthlyslry.Text);
                    double ota = Convert.ToDouble(txtotr.Text);
                    double allowance = Convert.ToDouble(txtallowances.Text);
                    double dedication = Convert.ToDouble(txtdeducationady.Text);

                    cmd.CommandText = "UPDATE employeetbl SET name='" + name + "',position='" + position + "',age='" + age + "',address='" + address + "',nic='" + nic + "',email='" + email + "',month_salary='" + msalary + "',ot_ammount='" + ota + "',allowance='" + allowance + "',deducation='" + dedication + "' where id='"+id+"'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated!");

                    clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                con.Close();
            }


        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {//insert
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                string id = txtempid.Text;
                string name = txtname.Text;
                string position = comboBoxempposition.SelectedItem.ToString();
                string age = txtage.Text;
                string address = txtadrs.Text;
                string nic = txtnic.Text;
                string email = txtmail.Text;

                double msalary = Convert.ToDouble(txtmonthlyslry.Text);
                double ota = Convert.ToDouble(txtotr.Text);
                double allowance = Convert.ToDouble(txtallowances.Text);
                double dedication = Convert.ToDouble(txtdeducationady.Text);
                
                
                cmd.CommandText = "INSERT INTO employeetbl (name,position,age,address,nic,email,month_salary,ot_ammount,allowance,deducation) VALUES ('" + name + "','" + position + "','" + age + "','" + address + "','" + nic + "','" + email + "','" + msalary + "','" + ota + "','" + allowance + "','" + dedication + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been inserted!");

                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                con.Close();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try//try ctch
            {
                int count = 0;
                con.Open();//sqlopn
                //cmds 
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string srchh = txtsearch.Text;
                cmd.CommandText = "SELECT * FROM employeetbl WHERE  id like  '%" + srchh + "%' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                con.Close();//sqlcls

                if (count == 0)
                {
                    MessageBox.Show("Record not found...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindonew2DataSet1.employeetbl' table. You can move, or remove it, as needed.
            this.employeetblTableAdapter.Fill(this.grifindonew2DataSet1.employeetbl);

        }

        public void clear()
        {
            txtempid.Clear();
            txtname.Clear();
            comboBoxempposition.ResetText();
            txtage.Clear();
            txtadrs.Clear();
            txtnic.Clear();
            txtmail.Clear();
            txtmonthlyslry.Clear();
            txtotr.Clear();
            txtallowances.Clear();
            txtdeducationady.Clear();
            pictureBox6.Hide();
            pictureBox7.Hide();
            pictureBox8.Show();
            pictureBox9.Hide();
            loadtable();
        }
        private void comboBoxempposition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            txtempid.Text = selectedRow.Cells[0].Value.ToString();
            txtname.Text = selectedRow.Cells[1].Value.ToString();
            comboBoxempposition.SelectedItem = selectedRow.Cells[2].Value.ToString();
            txtage.Text = selectedRow.Cells[3].Value.ToString();
            txtadrs.Text = selectedRow.Cells[4].Value.ToString();
            txtnic.Text = selectedRow.Cells[5].Value.ToString();
            txtmail.Text = selectedRow.Cells[6].Value.ToString();
            txtmonthlyslry.Text = selectedRow.Cells[7].Value.ToString();
            txtotr.Text = selectedRow.Cells[8].Value.ToString();
            txtallowances.Text = selectedRow.Cells[9].Value.ToString();
            txtdeducationady.Text = selectedRow.Cells[10].Value.ToString();



            pictureBox8.Hide();
            pictureBox7.Show();
            pictureBox6.Show();
            pictureBox9.Show();
        }

        private void txtempid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            pictureBox8.Show();
            pictureBox9.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            clear();
            pictureBox8.Show();
            pictureBox9.Hide();
        }
    }
}
