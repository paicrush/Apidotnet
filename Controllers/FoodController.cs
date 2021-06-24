using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoFood.Models;
using ContosoFood.Services;

namespace ContosoFood.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class FoodController : ControllerBase
    {
        public FoodController()
         {
        }

        [HttpGet]
        public ActionResult<List<Food>> GetAll() =>
        FoodService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Food> Get(int id)
        {
        var food = FoodService.Get(id);

        if(food == null)
            return NotFound();

        return food;
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {            
        FoodService.Add(food);
        return CreatedAtAction(nameof(Create), new { id = food.Id }, food);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Food food)
        {
        if (id != food.Id)
            return BadRequest();

        var existingFood = FoodService.Get(id);
        if(existingFood is null)
            return NotFound();

        FoodService.Update(food);           

        return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
        var food = FoodService.Get(id);

        if (food is null)
            return NotFound();

        FoodService.Delete(id);

        return NoContent();
        }
    }
}