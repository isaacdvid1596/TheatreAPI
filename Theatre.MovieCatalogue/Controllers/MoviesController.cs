using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Theatre.MovieCatalogue.Models;

namespace Theatre.MovieCatalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private static List<MovieDto> _movies = new List<MovieDto>
        {
            new MovieDto
            {
                MovieId = new Guid("06ecccdf-8aba-448e-a718-f91930059c27"),
                Name = "Your Name",
                Director = "Makoto Shinkai",
                CategoryId = new Guid("c2ae1165-74f2-41e0-a132-9976e701d5a8"),
                ShowDate = DateTime.Now,
                Price = 500,
                CategoryName = "Anime",
                Description = "Two teenagers share a profound, magical connection upon discovering they are swapping bodies. " +
                              "Things manage to become even more complicated when the boy and girl decide to meet in person."
            },  
            new MovieDto
            {
                MovieId = new Guid("636bf7e7-7479-4fe8-97ff-65ebc3940cdd"),
                Name = "Demon Slayer: Mugen Train",
                Director = "Haruo Sotozaki",
                CategoryId = new Guid("c2ae1165-74f2-41e0-a132-9976e701d5a8"),
                ShowDate = DateTime.Now,
                Price = 600,
                CategoryName = "Anime",
                Description = "A boy raised by boars, who wears a boar's head, " +
                              "boards the Infinity Train on a new mission with the Flame Pillar along with another" +
                              " boy who reveals his true power when he sleeps"
            },  
            new MovieDto
            {
                MovieId = new Guid("e040cd8d-70ad-4c6b-bb56-22a4f3fdc11c"),
                Name = "1917",
                Director = "Sam Mendes",
                CategoryId = new Guid("fae1e574-da3c-4d3a-b50f-20d2d088c139"),
                ShowDate = DateTime.Now,
                Price = 400,
                CategoryName = "Historical",
                Description = "Two soldiers, assigned the task of delivering a critical message to another battalion, " +
                              "risk their lives for the job in order to prevent them from stepping right into a deadly ambush."
            }, 
            new MovieDto
            {
                MovieId = new Guid("b7d57186-9ca2-4421-8068-2ccadcaccf82"),
                Name = "Parasite",
                Director = "Bong Joon-ho",
                CategoryId = new Guid("a93113dc-9556-4e08-9104-7fbeacf898b2"),
                ShowDate = DateTime.Now,
                Price = 460,
                CategoryName = "Drama",
                Description = "The struggling Kim family sees an opportunity when the son starts working for the wealthy Park family." +
                              " Soon, all of them find a way to work within the same household and start living a parasitic life."
            }
        };

        [HttpGet("{movieId}")]
        public ActionResult<MovieDto> GetById(Guid movieId)
        {
            return Ok(_movies.FirstOrDefault(m => m.MovieId == movieId));
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> Get([FromQuery] Guid categoryId)
        {
            return Ok(_movies.Where(m => m.CategoryId == categoryId));
        }
    }
}
