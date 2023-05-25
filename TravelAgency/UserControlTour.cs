using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TravelAgency
{
    public partial class UserControlTour : UserControl
    {
        public UserControlTour()
        {
            InitializeComponent();
        }

        public UserControlTour(Tour tour) : this()
        {
            this.label3.Text = tour.Id.ToString();
            this.label1.Text = tour.Name.ToString();
            this.label2.Text = tour.Price.ToString();
        }

        private void UserControlTour_Load(object sender, EventArgs e)
        {

        }

        private void UserControlTour_Click(object sender, EventArgs e)
        {
           // Data.Value = Int32.Parse(this.label3.Text.ToString());
            //Data.Value = Convert.ToInt32(this.label3.Text.ToString());
            //this.BorderStyle = BorderStyle.FixedSingle;
            //this.BackColor = SystemColors.Window;
        }
    }
}
