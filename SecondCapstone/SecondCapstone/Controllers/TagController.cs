using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SecondCapstone.Models;
using SecondCapstone.Repositories;
using System;

namespace SecondCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        // Constructor to inject the repository using dependency injection
        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // GET: api/tag
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tagRepository.GetAll());
        }

        // GET: api/tag/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tag = _tagRepository.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        // POST: api/tag
        [HttpPost]
        public IActionResult Post([FromBody] Tag tag)
        {
            if (tag == null || string.IsNullOrWhiteSpace(tag.Name))
            {
                return BadRequest("Tag name cannot be empty.");
            }

            try
            {
                _tagRepository.Add(tag);
                return CreatedAtAction(nameof(Get), new { id = tag.Id }, tag);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                Console.WriteLine("SQL Stack Trace: " + sqlEx.StackTrace);
                return StatusCode(500, "Database error occurred while creating the tag.");
            }
        }

        // PUT: api/tag/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest("Tag ID mismatch.");
            }

            try
            {
                _tagRepository.Update(tag);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating tag: " + ex.Message);
                return StatusCode(500, "An error occurred while updating the tag.");
            }
        }

        // DELETE: api/tag/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tagRepository.Delete(id);
            return NoContent();
        }
    }
}
