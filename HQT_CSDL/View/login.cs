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
using HQT_CSDL.Data;

namespace HQT_CSDL.View
{
    public partial class login : Form
    {
        public static string name;
        public static string password;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool test = TestConn();
            if(test)
            {
                name = textBox1.Text;
                password = textBox2.Text;
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể thực hiện");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {      
            try
            {
                if (TestConn())
                {
                    
                    MessageBox.Show("Thanh Cong");
                }
                else
                {
                    MessageBox.Show("Fail");
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ket noi that bai");
            } 
        }
        public bool TestConn()
        {
            SqlConnection C = new SqlConnection("Data Source=.;Initial Catalog=QUANLYLUONGNV;User ID=" + textBox1.Text + ";Password=" + textBox2.Text + ";");
            try
            {
                C.Open();
                SqlCommand command = new SqlCommand("SELECT 1", C);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                C.Close();
                return true;
            }
            catch (Exception e)
            {
                C.Close();
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
