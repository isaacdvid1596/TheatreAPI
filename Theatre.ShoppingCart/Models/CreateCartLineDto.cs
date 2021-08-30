﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theatre.ShoppingCart.Models
{
    public class CreateCartLineDto
    {
        public Guid CartId { get; set; }

        public Guid MovieId { get; set; }

        public int TicketQuantity { get; set; }

        public decimal Price { get; set; }

        public MovieDto Movie { get; set; }
    }
}