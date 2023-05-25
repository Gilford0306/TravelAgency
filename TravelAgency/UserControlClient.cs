using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency
{
    public partial class UserControlClient : UserControl
    {
        public UserControlClient()
        {
            InitializeComponent();
        }
        public UserControlClient(Client client) : this()
        {
            this.label1.Text = client.Id.ToString();
            this.label2.Text = client.Login.ToString();
            this.label3.Text = client.Name.ToString();
            if (client.CTours.ToString() == null)
                this.label4.Text = string.Empty;
            
            else
                this.label4.Text = client.CTours.ToString();
        }
    }
}
