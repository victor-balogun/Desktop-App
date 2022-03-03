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
    public partial class Gaming : Form
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
        public Gaming()
        {
            InitializeComponent();
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cst = "datasource=127.0.0.1;port=3306;username=victor;password=ibk;database=foodprac;";
            string u = comboBox1.Text;
            string i = comboBox2.Text;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pi = Int32.Parse(textBox2.Text);
            int p2 = Int32.Parse(comboBox2.Text);

            int[] arr = { 1, 2, 3, 4, 5};
            for (int i = 0; i < arr.Length; i++)
            {
                if (comboBox2.Text == Convert.ToString(arr[i]))
                {
                    textBox2.Text = Convert.ToString(pi * p2);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(comboBox1.Text == "Headsets")
            {
                textBox2.Text = "97500";
            }
            if (comboBox1.Text == "Optical Mouses")
            {
                textBox2.Text = "46000";
            }
            if (comboBox1.Text == "Mechanical Keyboard")
            {
                textBox2.Text = "60000";
            }
            if (comboBox1.Text == "Mousepads")
            {
                textBox2.Text = "7000";
            }
            if (comboBox1.Text == "Monitors")
            {
                textBox2.Text = "500000";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
