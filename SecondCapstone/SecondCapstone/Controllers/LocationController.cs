using Microsoft.AspNetCore.Mvc;
using SecondCapstone.Models;
using SecondCapstone.Repositories;

namespace SecondCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository LocationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            LocationRepository = locationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(LocationRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var location = LocationRepository.GetById(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost]
        public IActionResult Post(Location location)
        {
            LocationRepository.Add(location);
            return CreatedAtAction("Get", new { id = location.Id }, location);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            LocationRepository.Update(location);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            LocationRepository.Delete(id);
            return NoContent();
        }
    }
}
