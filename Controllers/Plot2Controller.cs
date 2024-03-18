using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VictoryGarden_BackEnd.Models;
using VictoryGarden_BackEnd.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VictoryGarden_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plot2Controller : ControllerBase
    {
        private readonly VictoryGardenDbContext _victoryGardenDbContext;

        public Plot2Controller(VictoryGardenDbContext victoryGardenDbContext)
        {
            _victoryGardenDbContext = victoryGardenDbContext;
        }

        // GET: api/<Plot2Controller>
        [HttpGet]
        public IActionResult Get()
        {
            List<Plot2> plot2List = new List<Plot2>();
            plot2List = _victoryGardenDbContext.Plot2.ToList();
            return Ok(plot2List);
        }

        // GET api/<Plot2Controller>/5
        [HttpGet("{plotSpace}")]
        public IActionResult Get([FromRoute] int plotSpace)
        {
            var plot = _victoryGardenDbContext.Plot2.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot2.Contains(plot))
            {
                return Ok($"The plant in space {plotSpace} is {plot.PlantName}.");
            }

            return NotFound();
        }

        // POST api/<Plot2Controller>
        [HttpPost("{plotSpace}")]
        public IActionResult Post([FromRoute] int plotSpace, [FromBody] int plantID)
        {
            var plot = _victoryGardenDbContext.Plot2.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot2.Contains(plot))
            {
                return NoContent();
            }
            else
            {
                var plant = _victoryGardenDbContext.Plants.Find(plantID);

                var newplot = new Plot2();

                newplot.PlantID = plant.ID;
                newplot.PlantName = plant.PlantName;
                newplot.PlotSpace = plotSpace;

                _victoryGardenDbContext.Plot2.Add(newplot);
                _victoryGardenDbContext.SaveChanges();

                return Created($"/Plot2/{newplot.ID}", newplot);
            }
        }

        // PUT api/<Plot2Controller>/5
        [HttpPut("{plotSpace}")]
        public IActionResult Put([FromRoute] int plotSpace, [FromBody] int plantID)
        {
            var plot = _victoryGardenDbContext.Plot2.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot2.Contains(plot))
            {
                var plant = _victoryGardenDbContext.Plants.Find(plantID);

                plot.PlantID = plant.ID;
                plot.PlantName = plant.PlantName;

                _victoryGardenDbContext.Plot2.Update(plot);
                _victoryGardenDbContext.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/<Plot2Controller>/5
        [HttpDelete("{plotSpace}")]
        public IActionResult Delete([FromRoute] int plotSpace)
        {
            var plot = _victoryGardenDbContext.Plot2.Where(p => p.PlotSpace == plotSpace).FirstOrDefault();

            if (_victoryGardenDbContext.Plot2.Contains(plot))
            {
                _victoryGardenDbContext.Plot2.Remove(plot);
                _victoryGardenDbContext.SaveChanges();

                return NoContent();
            }

            return NotFound();

        }
    }
}
