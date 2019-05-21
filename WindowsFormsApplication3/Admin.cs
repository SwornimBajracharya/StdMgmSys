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
    public partial class Admin : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;Initial Catalog = students;User id = root; password=''");
        MySqlDataReader MyReader;
        int id = 0;
        

        public Admin()
        {
            InitializeComponent();
            GetAllAdmin();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Back to View All Menu
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAll fm = new ViewAll();
            fm.Show();
        }

        //Insert Operation
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string Query = "INSERT INTO admin(id, username, password) VALUES ('" + this.textBox1.Text +
                    "','" + this.textBox2.Text +
                    "','" + this.textBox3.Text + "');";
                
                MySqlCommand cmd = new MySqlCommand(Query, con);

                try
                {
                    con.Open();
                    MyReader = cmd.ExecuteReader();
                    MessageBox.Show("Saved");
                    while (MyReader.Read())
                    {
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter valid input");
            }
            con.Close();

            ClearData();
            GetAllAdmin();
        }
       
        //Update Operation
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    string Query = "update admin set username='" + this.textBox2.Text + "',password='" 
                        + this.textBox3.Text + "' where id='" + this.textBox1.Text + "';";
                    MySqlCommand cmd2 = new MySqlCommand(Query, con);

                    con.Open();
                    MyReader = cmd2.ExecuteReader();
                    MessageBox.Show("Data Updated");
                    while (MyReader.Read())
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Invalid entry");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            con.Close();
            
            ClearData();
            GetAllAdmin();
        }

        //Delete Operation
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "delete from admin where id='" + this.textBox1.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);

                con.Open();
                MyReader = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");

                while (MyReader.Read())
                {
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            con.Close();

            ClearData();
            GetAllAdmin();

        }

        //Refresh Operation
        private void button5_Click(object sender, EventArgs e)
        {
            GetAllAdmin();
        }

        //Fill Text Area when clicked on the row
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        //Display database
        private void GetAllAdmin()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from admin";
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
        
        //Clear data from text field
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }

}