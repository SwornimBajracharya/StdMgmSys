using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    public partial class ViewAll : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;Initial Catalog = students;User id = root; password=''");
        

        public ViewAll()
        {
            InitializeComponent();
            LoadAllList();
        }

        //Facilators Sections
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Facilators fm = new Facilators();
            fm.Show();
        }

        //Account Section
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account fm = new Account();
            fm.Show();
        }

        //Instructor Section
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instructor fm = new Instructor();
            fm.Show();
        }

        //Admin Section
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin fm = new Admin();
            fm.Show();
        }

        //Back to Login Page
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login fm = new Login();
            fm.Show();
        }

        //Refresh Button
        private void button4_Click(object sender, EventArgs e)
        {
            LoadAllList();
        }
        
        //Search Operation by id or name
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from tbl_std where Name ='" + textBox1.Text + "' or id ='" + textBox1.Text + "'"; ;
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadAllList() {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from tbl_std";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void ViewAll_Load(object sender, EventArgs e)
        {

        }
    }
}
