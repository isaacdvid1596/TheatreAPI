using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theatre.MovieCatalogue.Models;

namespace Theatre.MovieCatalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieCatalogueController : ControllerBase
    {
        private static List<MovieCategoryDto> _categories = new List<MovieCategoryDto>
        {
            new MovieCategoryDto
            {
                CategoryId = new Guid("c2ae1165-74f2-41e0-a132-9976e701d5a8"),
                Name = "Anime"
            },
            new MovieCategoryDto
            {
                CategoryId = new Guid("a93113dc-9556-4e08-9104-7fbeacf898b2"),
                Name = "Drama"
            },
            new MovieCategoryDto
            {
                CategoryId = new Guid("fae1e574-da3c-4d3a-b50f-20d2d088c139"),
                Name = "Historical"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<MovieCategoryDto>> Get()
        {
            return Ok(_categories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<MovieCategoryDto> GetById(Guid categoryId)
        {
            return Ok(_categories.FirstOrDefault(c => c.CategoryId == categoryId));
        }
    }
}
