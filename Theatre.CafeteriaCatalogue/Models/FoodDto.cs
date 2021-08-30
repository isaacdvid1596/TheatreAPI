using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theatre.CafeteriaCatalogue.Models
{
    public class FoodDto
    {
        public Guid FoodId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}

