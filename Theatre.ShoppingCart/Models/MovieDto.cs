using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theatre.ShoppingCart.Models
{
    public class MovieDto
    {
        public Guid MovieId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime ShowDate { get; set; }
    }
}
