using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theatre.Gateway.Models
{
    public class MovieDto
    {
        public Guid MovieId { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public decimal Price { get; set; }

        public DateTime ShowDate { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
