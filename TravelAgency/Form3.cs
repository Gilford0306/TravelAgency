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
    public partial class Form3 : Form
    {
        List<Tour> tours = new List<Tour>();
        List<Client>clients = new List<Client>();   
        string strConn = "Server=DESKTOP-N6GODSK;" +
                            "Database=TravelBase;" +
                        "Trusted_Connection=True;" +
                      "TrustServerCertificate=True;";
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Client client)
        {
            Client = client;
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                tours.Clear();
                conn.Open();
                tours = conn.Query<Tour>("SELECT * FROM [Tour];").ToList();

            }
            int y = 0;
            for (int i = 0; i < tours.Count; i++)

            {
                var item = new UserControlTour(tours[i]);
                item.Location = new Point(0, y);
                this.panel1.Controls.Add(item);
                y += item.Height;
            }

        }

        public Client Client { get; }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = Client.CTours.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text != string.Empty)
                {
                    foreach (Tour tour in tours)
                    {
                        if (int.Parse(textBox1.Text.ToString()) == tour.Id)
                        {
                            using (SqlConnection conn = new SqlConnection(strConn))
                            {
                                conn.Open();
                                string str = Client.CTours.ToString();
                                str = str.Replace(" ", string.Empty);
                                str += ", "+ tour.Name.ToString();
                                conn.Execute("update [Client] set CTours=@str where Id = @id", param: new{str, id = Client.Id});
                            }
                            MessageBox.Show("Tour is adding to your account");
                        }
                    }
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        tours.Clear();
                        conn.Open();
                        clients = conn.Query<Client>("SELECT * FROM [Client];").ToList();

                    }
                    foreach (Client client in clients)
                    {
                        if (client.Id == Client.Id)
                        {
                            label2.Text = client.CTours.ToString();
                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            List<Tour> SortedList = tours.OrderBy(o => o.Name).ToList();
            int y = 0;
            foreach(Tour t in SortedList)
            {

                var item = new UserControlTour(t);
                item.Location = new Point(0, y);
                this.panel1.Controls.Add(item);
                y += item.Height;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<Tour> SortedList = tours.OrderBy(o => o.Price).ToList();
            int y = 0;
            foreach (Tour t in SortedList)
            {

                var item = new UserControlTour(t);
                item.Location = new Point(0, y);
                this.panel1.Controls.Add(item);
                y += item.Height;
            }
        }
    }
}
