using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Theatre.ShoppingCart.Models;

namespace Theatre.ShoppingCart.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CartLinesController : ControllerBase
    {
        [HttpGet("/ShoppingCart/{cartId}/CartLines")]
        public ActionResult<IEnumerable<CartLineDto>> Get(Guid cartId)
        {
            var cart = Database.Carts.FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                return NotFound();
            }

            var cartLines = Database.CartLines.Where(c => c.Cart == cartId);

            return Ok(cartLines);
        }


        [HttpPost("/ShoppingCart/{cartId}/CartLines")]
        public async Task<ActionResult<CartLineDto>> Post(Guid cartId, [FromBody] CreateCartLineDto cartLineForCreation)
        {
            var cart = Database.Carts.FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                return NotFound($"Cart with id {cartId} was not found");
            }

            MovieDto movieData = null;

            if (Database.Movies.All(m => m.MovieId == cartLineForCreation.MovieId))
            {
                using(var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync($"http://localhost:1827/movies/{cartLineForCreation.MovieId}");
                    movieData = JsonConvert.DeserializeObject<MovieDto>(response);
                    Database.Movies.Add(movieData);
                }
            }

            if (movieData == null)
            {
                return NotFound($"Movie not found");
            }

            var cartLine = new CartLineDto
            {
                MovieId = cartLineForCreation.MovieId,
                Price = movieData.Price,
                Cart = cartLineForCreation.CartId,
                TicketAmount = cartLineForCreation.TicketQuantity,
                CartLineId = new Guid(),
                Movie = cartLineForCreation.Movie
            };

            Database.CartLines.Add(cartLine);
            return Ok(cartLine);
        }
    }
}
