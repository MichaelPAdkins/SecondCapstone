using Microsoft.AspNetCore.Mvc;
using SecondCapstone.Models;
using SecondCapstone.Repositories;
using Microsoft.Data.SqlClient;
using System;

namespace SecondCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: api/location
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_locationRepository.GetAll());
        }

        // GET: api/location/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var location = _locationRepository.GetById(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST: api/location
        [HttpPost]
        public IActionResult Post([FromBody] Location location)
        {
            if (location == null || string.IsNullOrWhiteSpace(location.Name))
            {
                return BadRequest("Location name cannot be empty.");
            }

            try
            {
                _locationRepository.Add(location);
                return CreatedAtAction(nameof(Get), new { id = location.Id }, location);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                return StatusCode(500, "Database error occurred while creating the location.");
            }
        }


        // PUT: api/location/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Location location)
        {
            if (id != location.Id)
            {
                return BadRequest("Location ID mismatch.");
            }

            try
            {
                _locationRepository.Update(location);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating location: " + ex.Message);
                return StatusCode(500, "An error occurred while updating the location.");
            }
        }

        // DELETE: api/location/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _locationRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting location: " + ex.Message);
                return StatusCode(500, "An error occurred while deleting the location.");
            }
        }
    }
}
