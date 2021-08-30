using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Theatre.CafeteriaCatalogue.Models;

namespace Theatre.CafeteriaCatalogue.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CafeteriaCatalogueController : ControllerBase
    {
        private static List<FoodCategoryDto> _Foodcategories = new List<FoodCategoryDto>
        {
            new FoodCategoryDto()
            {
                CategoryId = new Guid("77718a4c-07f2-44c2-b74a-00ad5badff98"),
                Name = "Snacks"
            },
            new FoodCategoryDto()
            {
                CategoryId = new Guid("45460539-23c7-4c94-a63b-33c2d5f3b46e"),
                Name = "Drinks"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<FoodCategoryDto>> Get()
        {
            return Ok(_Foodcategories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<FoodCategoryDto> GetById(Guid categoryId)
        {
            return Ok(_Foodcategories.FirstOrDefault(c => c.CategoryId == categoryId));
        }
    }
}
