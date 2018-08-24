using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDayXF.Models
{
    public class Variation
    {
        public int VariationId { get; set; }
        public int OrderId { get; set; }
        public bool IsDefault { get; set; }
        public int MenuItemId { get; set; }
        public string Description { get; set; } //Add description, eg: "Add your size including measuring unit, eg: 400g or 30cm)
        public decimal Price { get; set; }
    }
}
