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
using System.Xml.Linq;
using System.Data.SqlClient;//1
using System.Linq.Expressions;

namespace grifindoToys1new
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DELL\\MSSQLSERVER01;Initial Catalog=grifindonew2;Integrated Security=True");//2
        public Form5()
        {
            InitializeComponent();
            pictureBox7.Hide();
            lbldternge.Hide();
            lblenddte.Hide();
            lbllves.Hide();
            lblstrtdte.Hide();
            lbltaxrte.Hide();

            txtdternge.Hide();
            txtenddte.Hide();
            txtlves.Hide();
            txtstrtdte.Hide();
            txttexrte.Hide();
        }
        private void clear()
        {
            txttexrte.Clear();
            txtstrtdte.Clear();
            txtenddte.Clear();
            txtdternge.Clear();
            txtlves.Clear();
        }
        private void loadtable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT * FROM settingtbl";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            //pictureBox7.Show();
            lbldternge.Show();
            lblenddte.Show();
            lbllves.Show();
            lblstrtdte.Show();
            lbltaxrte.Show();

            txtdternge.Show();
            txtenddte.Show();
            txtlves.Show();
            txtstrtdte.Show();
            txttexrte.Show();

            pictureBox8.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindonew2DataSet4.settingtbl' table. You can move, or remove it, as needed.
            this.settingtblTableAdapter.Fill(this.grifindonew2DataSet4.settingtbl);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {//inst/==updte
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                string id = setting_id.Text;
                string texrate = txttexrte.Text;
                string startdate = txtstrtdte.Text;
                string enddate = txtenddte.Text;
                string datarange = txtdternge.Text;
                string leves = txtlves.Text;

                cmd.CommandText = "UPDATE settingtbl set tax_rate='"+texrate+"',start_date='"+startdate+"',end_date='"+enddate+"',date_range='"+datarange+"',no_leaves_a_year='"+leves+"' where id='" + id + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been updated!");
                clear();
                loadtable();
                pictureBox9.Hide();
                pictureBox7.Hide();
                pictureBox8.Show();
                lbldternge.Hide();
                lblenddte.Hide();
                lbllves.Hide();
                lblstrtdte.Hide();
                lbltaxrte.Hide();

                txtdternge.Hide();
                txtenddte.Hide();
                txtlves.Hide();
                txtstrtdte.Hide();
                txttexrte.Hide();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
                con.Close();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox7.Hide();
            lbldternge.Hide();
            lblenddte.Hide();
            lbllves.Hide();
            lblstrtdte.Hide();
            lbltaxrte.Hide();

            pictureBox8.Show();

            txtdternge.Hide();
            txtenddte.Hide();
            txtlves.Hide();
            txtstrtdte.Hide();
            txttexrte.Hide();

            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            setting_id.Text = selectedRow.Cells[0].Value.ToString();
            txttexrte.Text = selectedRow.Cells[1].Value.ToString();
            txtstrtdte.Text = selectedRow.Cells[2].Value.ToString();
            txtenddte.Text = selectedRow.Cells[3].Value.ToString();
            txtdternge.Text = selectedRow.Cells[4].Value.ToString();
            txtlves.Text = selectedRow.Cells[5].Value.ToString();

            pictureBox7.Show();
        }
    }
}
