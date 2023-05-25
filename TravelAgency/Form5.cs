using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravelAgency
{

    public partial class Form5 : Form
    {
        int i = -1;
        string strConn = "Server=DESKTOP-N6GODSK;" +
                "Database=TravelBase;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";
        public Form5()
        {
            InitializeComponent();

        }

        public Form5(int z)
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

                    Tour tour = new Tour(0, textBox1.Text.ToString(), int.Parse(textBox2.Text.ToString()));
                    conn.Execute("INSERT INTO [Tour]([Name],[Price]) VALUES(@Name, @Price)", new { tour.Name, tour.Price });

                }
                MessageBox.Show("Tour is created");
                this.Close();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    Tour tour = new Tour(0, textBox1.Text.ToString(), int.Parse(textBox2.Text.ToString()));
                    //conn.Execute(" UPDATE [Tour] SET[Name] = tour.Name ,[Price]) VALUES(@Name, @Price)", new { tour.Name, tour.Price });
                    conn.Execute("update [Tour] set Name = @name, Price=@price where Id = @id", new {tour.Name, tour.Price,  id = i });

                }
                MessageBox.Show("Tour is updated");
                this.Close();
            }

        }
    }
}
