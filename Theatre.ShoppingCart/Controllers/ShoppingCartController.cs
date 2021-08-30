using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theatre.ShoppingCart.Models;

namespace Theatre.ShoppingCart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet("{cartId}")]
        public ActionResult<CartDto> Get(Guid cartId)
        {
            var cart = Database.Carts.FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                return NotFound($"Cart with id {cartId} was not found");
            }

            return Ok(cart);
        }

        [HttpPost]
        public ActionResult<CartDto> Post([FromBody] CreateCartDto cartForCreation)
        {
            var cart = new CartDto()
            {
                UserId = cartForCreation.UserId,
                CartId = Guid.NewGuid()
            };

            Database.Carts.Add(cart);
            return Ok(cart);
        }
    }
}
