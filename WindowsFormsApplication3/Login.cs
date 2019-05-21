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
    public partial class Login : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;Initial Catalog = students;User id = root; password=''");
        int i;
        public Login()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM admin where username ='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i != 0)
            {
                this.Hide();
                ViewAll fm = new ViewAll();
                fm.Show();
            }

            else
            {
                MessageBox.Show("Invalid Email or password");
                textBox1.Text = "";
                textBox2.Text = "";

            }

            con.Close();
        }
    }
}
