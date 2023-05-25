using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TravelAgency
{
    public partial class Form1 : Form
    {
        List<Client> clients = new List<Client>();
        string strConn = "Server=DESKTOP-N6GODSK;" +
                            "Database=TravelBase;" +
                        "Trusted_Connection=True;" +
                      "TrustServerCertificate=True;";



        public Form1()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                clients = conn.Query<Client>("SELECT * FROM [Client];").ToList(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                Form2 newForm = new Form2();
                newForm.Show();
            }
            else
            {
                bool flag = false;
                foreach (Client client in clients)
                {
                    string str = client.Login;
                    str = str.Replace(" ", string.Empty);
                    if (textBox1.Text == str)
                    {
                        Form3 newForm = new Form3(client);
                        newForm.Show();
                        flag = true;
                    }

                }
                if (flag==false && textBox1.Text!=string.Empty)
                    MessageBox.Show("Login isn`t exist");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
