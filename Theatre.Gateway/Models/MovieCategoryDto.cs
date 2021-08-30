using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theatre.Gateway.Models
{
    public class MovieCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<MovieDto> Movies { get; set; }
    }
}
