using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theatre.ShoppingCart.Models
{
    public class CartLineDto
    {
        public Guid CartLineId { get; set; }

        public Guid Cart { get; set; }

        public Guid MovieId { get; set; }

        public decimal Price { get; set; }

        public int TicketAmount { get; set; }

        public MovieDto Movie { get; set; }
    }
}
