using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theatre.Gateway.Models;

namespace Theatre.Gateway.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient _httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CartDto> GetCartByIdAsync(Guid id)
        {
            var cartResponse = await _httpClient.GetStringAsync($"ShoppingCart/{id}");
            var cartLinesResponse = await _httpClient.GetStringAsync($"ShoppingCart/{id}/CartLines");
            var cart = JsonConvert.DeserializeObject<CartDto>(cartResponse);
            var cartLine = JsonConvert.DeserializeObject<IEnumerable<CartLineDto>>(cartLinesResponse);
            cart.CartLines = cartLine;
            return cart;
        }

        public async Task<CartLineDto> AddEventToCartAsync(Guid cartId, CreateCartLineDto lineToAdd)
        {
            var requestBodyJson = JsonConvert.SerializeObject(lineToAdd);
            var basketLinesResponse = await _httpClient.PostAsync($"ShoppingCart/{cartId}/CartLines",
                new StringContent(requestBodyJson, Encoding.UTF8, "application/json"));

            var responseBody = await basketLinesResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CartLineDto>(responseBody);
        }
    }
}
