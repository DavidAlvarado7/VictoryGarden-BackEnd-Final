using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VictoryGarden_BackEnd.Models;
using VictoryGarden_BackEnd.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VictoryGarden_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotsController : ControllerBase
    {
        private readonly VictoryGardenDbContext _victoryGardenDbContext;

        public PlotsController(VictoryGardenDbContext victoryGardenDbContext)
        {
            _victoryGardenDbContext = victoryGardenDbContext;
        }

        // GET: api/<PlotsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Plot> plots = _victoryGardenDbContext.Plots.ToList();
            return Ok(plots);
        }

        // GET api/<PlotsController>/5
        [HttpGet("{plotId}")]
        public IActionResult Get([FromRoute] int plotId)
        {
            var plotContents = _victoryGardenDbContext.Plots
                .Where(p => p.PlotId == plotId)
                .ToList();

            if (plotContents != null && plotContents.Any())
            {
                return Ok(plotContents);
            }

            return NotFound();
        }

        // GET api/<PlotsController>/plotitem/5
        [HttpGet("plotitem/{id}")]
        public IActionResult GetPlotItem([FromRoute] int id)
        {
            Plot? plotContent = _victoryGardenDbContext.Plots.FirstOrDefault(p => p.Id == id);

            if (plotContent != null)
            {
                return Ok(plotContent);
            }

            return NotFound();
        }

        // PUT api/<PlotsController>
        [HttpPut("{plotSpaceId}/{plantId}")]
        public IActionResult Put([FromRoute] int plotSpaceId, int plantId)
        {
            Plot? plotItem = _victoryGardenDbContext.Plots.FirstOrDefault(p => p.Id == plotSpaceId);

            if (plotItem == null)
            {
                return NotFound();
            }

            Plant? plant = _victoryGardenDbContext.Plants.FirstOrDefault(p => p.ID == plantId);

            if (plant == null)
            {
                return NotFound();
            }


            plotItem.PlantId = plant.ID;
            plotItem.PlantName = plant.PlantName;

            _victoryGardenDbContext.Plots.Update(plotItem);
            _victoryGardenDbContext.SaveChanges();

            return NoContent();
        }
    }
}
