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

namespace pracforproject
{
    public partial class Comp : Form
    {
        public void display()
        {
            string cst = "datasource=127.0.0.1;port=3306;username=victor;password=ibk;database=foodprac;";
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(cst);
            try
            {
                con.Open();
                MySqlDataAdapter adpt = new MySqlDataAdapter("SELECT * FROM `fp` WHERE 1", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Comp()
        {
            InitializeComponent();
            display();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cst = "datasource=127.0.0.1;port=3306;username=victor;password=ibk;database=foodprac;";
            string u = comboBox1.Text;
            string i = textBox1.Text;
            int o = Int32.Parse(textBox2.Text);
            string q = "INSERT INTO fp VALUES (' " + u + "', ' " + i + "', ' " + o + "')";
            MySqlConnection con = new MySqlConnection(cst);
            MySqlCommand cmd = new MySqlCommand(q, con);
            cmd.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Successfully Bought");
                con.Close();
                display();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p;
            if(comboBox1.Text == "HP")
            {
                p = 25000;
                textBox2.Text = Convert.ToString(p * 2);
            }
            if (comboBox1.Text == "Dell")
            {
                p = 55000;
                textBox2.Text = Convert.ToString(p * 4);
            }
            if (comboBox1.Text == "Lenovo")
            {
                p = 210000;
                textBox2.Text = Convert.ToString(p * 2);
            }
            if (comboBox1.Text == "Asus")
            {
                p = 800000;
                textBox2.Text = Convert.ToString(p * 1);
            }
            if (comboBox1.Text == "Razer")
            {
                p = 700000;
                textBox2.Text = Convert.ToString(p * 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
