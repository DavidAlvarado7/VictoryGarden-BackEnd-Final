using Microsoft.AspNetCore.Mvc;
using VictoryGarden_BackEnd.Models;
using VictoryGarden_BackEnd.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VictoryGarden_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly VictoryGardenDbContext _victoryGardenDbContext;

        public JournalController(VictoryGardenDbContext victoryGardenDbContext)
        {
            _victoryGardenDbContext = victoryGardenDbContext;
        }

        // GET: api/<JournalController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Journal> journalList = new List<Journal>();
            journalList = _victoryGardenDbContext.Journal.ToList();
            return Ok(journalList);
        }

        // GET api/<JournalController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var entry = _victoryGardenDbContext.Journal.Find(id);

            if (entry != null)
            {
                return Ok(entry.Notes);
            }

            return NotFound();
        }

        // POST api/<JournalController>
        [HttpPost]
        public IActionResult Post([FromBody] PostJournal submission)
        {
            var newentry = new Journal();
            newentry.Date = submission.Date;
            newentry.Gardener = submission.Gardener;
            newentry.Notes = submission.Notes;

            _victoryGardenDbContext.Journal.Add(newentry);
            _victoryGardenDbContext.SaveChanges();

            return Created($"/JournalController/{newentry.Id}", newentry);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var entry = _victoryGardenDbContext.Journal.Find(id);

            if (entry != null)
            {
                _victoryGardenDbContext.Journal.Remove(entry);
                _victoryGardenDbContext.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }
    }
}
