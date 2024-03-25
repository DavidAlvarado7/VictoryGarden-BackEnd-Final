using Microsoft.AspNetCore.Mvc;
using VictoryGarden_BackEnd.Models;
using VictoryGarden_BackEnd.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VictoryGarden_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly VictoryGardenDbContext _victoryGardenDbContext;

        public PlantsController(VictoryGardenDbContext victoryGardenDbContext)
        {
            _victoryGardenDbContext = victoryGardenDbContext;
        }

        // GET: api/<PlantsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Plant> plantsList = _victoryGardenDbContext.Plants.ToList();
            return Ok(plantsList);
        }

        // GET api/<PlantsController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var plant = _victoryGardenDbContext.Plants.Find(id);

            // returning the single object here instead of a string so angular can use it
            if (plant != null)
            {
                return Ok(plant);
            }

            return NotFound();
        }

        // PUT api/<PlantsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Plant putPlant)
        {
            var plant = _victoryGardenDbContext.Plants.Find(id);

            if (plant != null)
            {
                plant.Quantity = putPlant.Quantity;

                _victoryGardenDbContext.Plants.Update(plant);
                _victoryGardenDbContext.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }
    }
}
