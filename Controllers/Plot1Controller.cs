using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VictoryGarden_BackEnd.Models;
using VictoryGarden_BackEnd.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VictoryGarden_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plot1Controller : ControllerBase
    {
        private readonly VictoryGardenDbContext _victoryGardenDbContext;

        public Plot1Controller(VictoryGardenDbContext victoryGardenDbContext)
        {
            _victoryGardenDbContext = victoryGardenDbContext;
        }

        // GET: api/<Plot1Controller>
        [HttpGet]
        public IActionResult Get()
        {
            List<Plot1> plot1List = new List<Plot1>();
            plot1List = _victoryGardenDbContext.Plot1.ToList();
            return Ok(plot1List);
        }

        // GET api/<Plot1Controller>/5
        [HttpGet("{plotSpace}")]
        public IActionResult Get([FromRoute] int plotSpace)
        {
            var plot = _victoryGardenDbContext.Plot1.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot1.Contains(plot))
            {
                return Ok($"The plant in space {plotSpace} is {plot.PlantName}.");
            }

            return NotFound();
        }

        // POST api/<Plot1Controller>
        [HttpPost("{plotSpace}")]
        public IActionResult Post([FromRoute] int plotSpace, [FromBody] int plantID)
        {
            var plot = _victoryGardenDbContext.Plot1.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot1.Contains(plot))
            {
                return NoContent();
            }
            else
            {
                var plant = _victoryGardenDbContext.Plants.Find(plantID);

                var newplot = new Plot1();

                newplot.PlantID = plant.ID;
                newplot.PlantName = plant.PlantName;
                newplot.PlotSpace = plotSpace;

                _victoryGardenDbContext.Plot1.Add(newplot);
                _victoryGardenDbContext.SaveChanges();

                return Created($"/Plot1/{newplot.ID}", newplot);
            }
        }

        // PUT api/<Plot1Controller>/5
        [HttpPut("{plotSpace}")]
        public IActionResult Put([FromRoute] int plotSpace, [FromBody] int plantID)
        {
            var plot = _victoryGardenDbContext.Plot1.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot1.Contains(plot))
            {
                var plant = _victoryGardenDbContext.Plants.Find(plantID);

                plot.PlantID = plant.ID;
                plot.PlantName = plant.PlantName;

                _victoryGardenDbContext.Plot1.Update(plot);
                _victoryGardenDbContext.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/<Plot1Controller>/5
        [HttpDelete("{plotSpace}")]
        public IActionResult Delete([FromRoute] int plotSpace)
        {
            var plot = _victoryGardenDbContext.Plot1.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot1.Contains(plot))
            {
                _victoryGardenDbContext.Plot1.Remove(plot);
                _victoryGardenDbContext.SaveChanges();

                return NoContent();
            }

            return NotFound();

        }
    }
}
