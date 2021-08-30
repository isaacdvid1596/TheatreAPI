using System;
using System.Collections.Generic;
using Theatre.ShoppingCart.Models;

namespace Theatre.ShoppingCart
{
    public static class Database
    {
        public static readonly List<CartDto> Carts = new List<CartDto>
        {
            new CartDto()
            {
                CartId = new Guid("2ef68852-f926-4f48-ab6c-44b0529ad094"),
                NumberOfItems = 0,
                UserId = new Guid("45c02a4b-80d0-4636-a4b4-e899db9c7136")
            }
        };

        public static readonly List<MovieDto> Movies = new List<MovieDto>();
        public static readonly List<CartLineDto> CartLines = new List<CartLineDto>();
    }
}
