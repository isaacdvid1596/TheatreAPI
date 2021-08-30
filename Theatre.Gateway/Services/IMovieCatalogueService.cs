using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theatre.Gateway.Models;

namespace Theatre.Gateway.Services
{
    public interface IMovieCatalogueService
    {
        Task<IEnumerable<MovieCategoryDto>> GetCategoriesAsync();

        Task<MovieDto> GetMovieByIdAsync(Guid id);

        Task<IEnumerable<MovieDto>> GetMoviesByCategoryAsync(Guid categoryId);
    }
}
