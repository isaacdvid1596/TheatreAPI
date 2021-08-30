using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theatre.Gateway.Models;

namespace Theatre.Gateway.Services
{
    public interface IShoppingCartService
    {
        Task<CartDto> GetCartByIdAsync(Guid id);

        Task<CartLineDto> AddEventToCartAsync(Guid cartId, CreateCartLineDto lineToAdd);
    }
}
