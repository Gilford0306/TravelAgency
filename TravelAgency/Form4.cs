using Dapper;
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

namespace TravelAgency
{
    public partial class Form4 : Form
    {
 
        int i = -1;
        string strConn = "Server=DESKTOP-N6GODSK;" +
                "Database=TravelBase;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";
        public Form4()
        {
            InitializeComponent();

        }

        public Form4(int z)
        {
            InitializeComponent();
            i = z;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Fill in the fields");
            }
            else if (i == -1)
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    Client client = new Client(0, textBox1.Text.ToString(), textBox2.Text.ToString()," ");
                    conn.Execute("INSERT INTO [Client]([Login],[Name],[CTours]) VALUES(@Login, @Name,@CTours)", new { client.Login, client.Name,client.CTours });

                }
                MessageBox.Show("Client is created");
                this.Close();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    Client client = new Client(0, textBox1.Text.ToString(), textBox2.Text.ToString(), " ");
                    conn.Execute("update [Client] set Login = @login, Name=@name where Id = @id", new { client.Login, client.Name, id = i });

                }
                MessageBox.Show("Client is updated");
                this.Close();
            }

        }
    }
}

