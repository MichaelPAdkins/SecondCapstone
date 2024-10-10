using Microsoft.AspNetCore.Mvc;
using SecondCapstone.Models;
using SecondCapstone.Repositories;

namespace SecondCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository TagRepository;

        public TagController(ITagRepository tagRepository)
        {
            TagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TagRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tag = TagRepository.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        [HttpPost]
        public IActionResult Post(Tag tag)
        {
            TagRepository.Add(tag);
            return CreatedAtAction("Get", new { id = tag.Id }, tag);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            TagRepository.Update(tag);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TagRepository.Delete(id);
            return NoContent();
        }
    }
}
