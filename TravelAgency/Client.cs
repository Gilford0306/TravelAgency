using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Client
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string CTours { get; set; }

        public Client()
        {
                
        }
        public Client(int id, string login, string name, string ctour)
        {
            Id = id;
            Login = login;
            Name = name;
            CTours = ctour;
        }
    }
}
