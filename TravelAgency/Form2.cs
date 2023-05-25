using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency
{
    public partial class Form2 : Form
    {
        List<Client> clients = new List<Client>();
        List<Tour> tours = new List<Tour>();
        int z = -1;
        string strConn = "Server=DESKTOP-N6GODSK;" +
"Database=TravelBase;" +
"Trusted_Connection=True;" +
"TrustServerCertificate=True;";
        public Form2()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                tours.Clear();
                conn.Open();
                tours = conn.Query<Tour>("SELECT * FROM [Tour];").ToList();
                clients = conn.Query<Client>("SELECT * FROM [Client];").ToList();
            }
            panel1.Controls.Clear();
            button6.Enabled = true; button7.Enabled = true; button8.Enabled = true;
            button3.Enabled = false; button4.Enabled = false; button5.Enabled = false;
            textBox1.Visible = true; textBox2.Visible = true;
            textBox3.Visible = false; textBox4.Visible = false;
            label1.Text = "Contry"; label2.Text = "Price";
            label1.Visible = true; label2.Visible = true;
            label3.Visible = true; label4.Visible = false;
            int y = 0;
            for (int i = 0; i < tours.Count; i++)

            {
                var item = new UserControlTour(tours[i]);
                item.Location = new Point(0, y);
                this.panel1.Controls.Add(item);
                y += item.Height;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            button6.Enabled = false; button7.Enabled = false; button8.Enabled = false;
            button3.Enabled = true; button4.Enabled = true; button5.Enabled = true;
            label1.Text = "Login"; label2.Text = "Name";
            label1.Visible = true; label2.Visible = true;
            label3.Visible = true; label4.Visible = true;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                tours.Clear();
                conn.Open();
                tours = conn.Query<Tour>("SELECT * FROM [Tour];").ToList();
                clients = conn.Query<Client>("SELECT * FROM [Client];").ToList();
            }
            textBox1.Visible = false; textBox2.Visible = false;
            textBox3.Visible = true; textBox4.Visible = true;
            int y = 0;
            for (int i = 0; i < clients.Count; i++)
            {
                var item = new UserControlClient(clients[i]);
                item.Location = new Point(0, y);
                this.panel1.Controls.Add(item);
                y += item.Height;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Owner = this;
            newForm.Show();
            panel1.Controls.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                bool flag = false;
                foreach (Tour tour in tours)
                {
                    if (int.Parse(textBox1.Text.ToString()) == tour.Id)
                    {
                        panel1.Controls.Clear();
                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            conn.Open();
                            conn.Execute("DELETE FROM Tour WHERE Id=@id", param: new { id = int.Parse(textBox1.Text.ToString()) });

                        }
                        flag = true;
                        MessageBox.Show("Tour is deleted");

                    }
                }
                if (flag == false)
                    MessageBox.Show("Tour isn`t exist");
                textBox1.Text = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty)
            {
                bool flag = false;
                foreach (Client client in clients)
                {
                    if (int.Parse(textBox4.Text.ToString()) == client.Id)
                    {
                        panel1.Controls.Clear();
                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            conn.Open();
                            conn.Execute("DELETE FROM Client WHERE Id=@id", param: new { id = int.Parse(textBox4.Text.ToString()) });

                        }
                        flag = true;
                        MessageBox.Show("Client is deleted");

                    }
                }
                if (flag == false)
                    MessageBox.Show("Client isn`t exist");
            }
            textBox4.Text = null;
        }

            private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Owner = this;
            newForm.Show();
            panel1.Controls.Clear();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try { z = Convert.ToInt32(textBox1.Text.ToString()) - 1; }
            catch
            {
                if (textBox1.Text != string.Empty)
                {
                    MessageBox.Show("Only number");
                    textBox1.Text = null;
                }

            }

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            int y = 0;
            for (int i = 0; i < tours.Count; i++)
            {
                var item = new UserControlTour(tours[i]);
                item.Location = new Point(0, y);
                this.panel1.Controls.Add(item);
                y += item.Height - 20;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { z = Convert.ToInt32(textBox2.Text.ToString()); }
            catch
            {
                if (textBox1.Text != string.Empty)
                {
                    MessageBox.Show("Only number");
                    textBox1.Text = null;
                }

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {
                bool flag = false;
                foreach (Client client in clients)
                {
                    if (int.Parse(textBox3.Text.ToString()) == client.Id)
                    {

                        Form4 newForm = new Form4(z);
                        newForm.Owner = this;
                        newForm.Show();
                        flag = true;


                    }
                    panel1.Controls.Clear();
                }
                if (flag == false)
                    MessageBox.Show("Client isn`t exist");
                textBox3.Text = null;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

          if(textBox2.Text != string.Empty)
            {
                bool flag = false;
                foreach (Tour tour in tours)
                {
                    if (int.Parse(textBox2.Text.ToString()) == tour.Id)
                    {

                        Form5 newForm = new Form5(z);
                        newForm.Owner = this;
                        newForm.Show();
                        flag = true;


                    }
                    panel1.Controls.Clear();
                }
                if (flag == false)
                    MessageBox.Show("Tour isn`t exist");
                textBox1.Text = null;

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { z = Convert.ToInt32(textBox4.Text.ToString()) ; }
            catch
            {
                if (textBox1.Text != string.Empty)
                {
                    MessageBox.Show("Only number");
                    textBox1.Text = null;
                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { z = Convert.ToInt32(textBox3.Text.ToString()); }
            catch
            {
                if (textBox1.Text != string.Empty)
                {
                    MessageBox.Show("Only number");
                    textBox1.Text = null;
                }

            }
        }
    }
}
