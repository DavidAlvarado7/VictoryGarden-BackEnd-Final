using Microsoft.AspNetCore.Mvc;
using VictoryGarden_BackEnd.Models;
using VictoryGarden_BackEnd.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VictoryGarden_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrefleController : ControllerBase
    {
        // GET api/<TrefleController>/5

        private readonly TrefleService _trefleService;

        public TrefleController(TrefleService trefleService)
        {
            _trefleService = trefleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var trefle = await _trefleService.GetTrefleData(id);
            
            return Ok(trefle);

        }
    }
}
