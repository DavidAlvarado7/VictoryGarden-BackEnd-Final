using Microsoft.AspNetCore.Mvc;
using VictoryGarden_BackEnd.Models;
using VictoryGarden_BackEnd.Services;


namespace VictoryGarden_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly TrefleService _trefleService;
        private readonly VictoryGardenDbContext _victoryGardenDbContext;

        public PlantsController(VictoryGardenDbContext victoryGardenDbContext, TrefleService trefleService)
        {
            _trefleService = trefleService;
            _victoryGardenDbContext = victoryGardenDbContext;
        }

        // GET: api/<PlantsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // This code gets the Plants info and the Trefle info and combines them into a dictionary so the front end can use everything at once.
            
            List<Plant> plantsList = _victoryGardenDbContext.Plants.ToList();

            var trefleUIs = new List<TrefleUI>();
            foreach (var plant in plantsList)
            {
                var trefleUI = await _trefleService.GetTrefleData(plant.TrefleID);
                trefleUIs.Add(trefleUI);
            }

        var plantDictionary = plantsList.ToDictionary(plant => plant.TrefleID);
            var results = trefleUIs.Where(trefle => trefle != null).Select(trefle =>
            {
                var plantInfo = plantDictionary.GetValueOrDefault(trefle.id);
                return new
                {
                    Id = plantInfo.ID,
                    PlantName = plantInfo.PlantName,
                    Quantity = plantInfo.Quantity,
                    CommonName = trefle.common_name,
                    ScientificName = trefle.scientific_name,
                    ImageURL = trefle.image_url,
                    Vegetable = trefle.vegetable
                };
            });

            return Ok(results);
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
