using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Theatre.CafeteriaCatalogue.Models;

namespace Theatre.CafeteriaCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private static List<FoodDto> _foodList = new List<FoodDto>
        {
            new FoodDto()
            {
                FoodId = new Guid("29e96e77-8409-4471-928d-c3f670b53656"),
                CategoryId = new Guid("77718a4c-07f2-44c2-b74a-00ad5badff98"),
                Name = "Hotdog",
                Price = 120,
                CategoryName = "Snacks"
            },
            new FoodDto()
            {
                FoodId = new Guid("c1c5c06e-3c6f-45b6-a113-850aa2cc9f56"),
                CategoryId = new Guid("77718a4c-07f2-44c2-b74a-00ad5badff98"),
                Name = "Popcorn",
                Price = 100,
                CategoryName = "Snacks"
            },
            new FoodDto()
            {
                FoodId = new Guid("2bd125cc-0f62-4213-8fc9-b6a7c6dc2760"),
                CategoryId = new Guid("45460539-23c7-4c94-a63b-33c2d5f3b46e"),
                Name = "Green Tea",
                Price = 70,
                CategoryName = "Drinks"
            },
            new FoodDto()
            {
                FoodId = new Guid("79e4337f-f907-4adc-b4ee-b17a2b150a2e"),
                CategoryId = new Guid("45460539-23c7-4c94-a63b-33c2d5f3b46e"),
                Name = "Coca-Cola",
                Price = 75,
                CategoryName = "Drinks"
            }
        };

        [HttpGet("{foodId}")]
        public ActionResult<FoodDto> GetById(Guid foodId)
        {
            return Ok(_foodList.FirstOrDefault(f => f.FoodId == foodId));
        }

        [HttpGet]
        public ActionResult<IEnumerable<FoodDto>> Get([FromQuery] Guid categoryId)
        {
            return Ok(_foodList.Where(f => f.CategoryId == categoryId));
        }
    }

}