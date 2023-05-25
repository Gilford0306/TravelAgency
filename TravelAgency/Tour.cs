using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Tour()
        {

        }
        public Tour(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
