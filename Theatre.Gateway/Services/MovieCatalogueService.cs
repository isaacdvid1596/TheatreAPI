using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theatre.Gateway.Models;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Theatre.Gateway.Services
{
    public class MovieCatalogueService : IMovieCatalogueService
    {
        private readonly HttpClient _httpClient;

        public MovieCatalogueService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MovieCategoryDto>> GetCategoriesAsync()
        {
            var categories = await _httpClient.GetStringAsync("MovieCatalogue");
            return JsonConvert.DeserializeObject<IEnumerable<MovieCategoryDto>>(categories);
        }

        public async Task<MovieDto> GetMovieByIdAsync(Guid id)
        {
            var movies = await _httpClient.GetStringAsync($"Movies/{id}");
            return JsonConvert.DeserializeObject<MovieDto>(movies);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByCategoryAsync(Guid categoryId)
        {
            var movies = await _httpClient.GetStringAsync($"Movies?categoryId={categoryId}");
            return JsonConvert.DeserializeObject<IEnumerable<MovieDto>>(movies);
        }
    }
}
