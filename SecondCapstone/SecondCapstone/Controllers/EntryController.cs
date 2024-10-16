using Microsoft.AspNetCore.Mvc;
using SecondCapstone.Models;
using SecondCapstone.Repositories;

namespace SecondCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryRepository EntryRepository;

        public EntryController(IEntryRepository entryRepository)
        {
            EntryRepository = entryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EntryRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entry = EntryRepository.GetById(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        public IActionResult Post(Entry entry)
        {
            EntryRepository.Add(entry);
            return CreatedAtAction("Get", new { id = entry.Id }, entry);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Entry entry)
        {
            if (id != entry.Id)
            {
                return BadRequest();
            }

            EntryRepository.Update(entry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EntryRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("latest")]
        public IActionResult GetLastTenEntries()
        {
            var entries = EntryRepository.GetLastTenEntries();
            return Ok(entries);  // This will return the entries in JSON format
        }

    }
}
