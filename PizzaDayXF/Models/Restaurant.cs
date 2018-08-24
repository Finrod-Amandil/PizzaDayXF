using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDayXF.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Website { get; set; }
        public string Street { get; set; }
        public string Location { get; set; }
        public List<MenuItem> MenuItems { get; set; }

        public string ImageUri { get; set; }
    }
}
