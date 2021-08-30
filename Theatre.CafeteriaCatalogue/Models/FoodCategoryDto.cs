using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theatre.CafeteriaCatalogue.Models
{
    public class FoodCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<FoodDto> Food { get; set; }
    }
}
