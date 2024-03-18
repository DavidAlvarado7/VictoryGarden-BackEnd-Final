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
            List<Plants> plantsList = new List<Plants>();
            plantsList = _victoryGardenDbContext.Plants.ToList();
            return Ok(plantsList);
        }

        // GET api/<PlantsController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var plants = _victoryGardenDbContext.Plants.Find(id);

            if (_victoryGardenDbContext.Plants.Contains(plants))
            {
                return Ok($"You provided an ID of {id} - {plants.PlantName}.");
            }

            return NotFound();
        }


    }
}
