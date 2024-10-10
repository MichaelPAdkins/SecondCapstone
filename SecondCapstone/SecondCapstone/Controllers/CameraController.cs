using Microsoft.AspNetCore.Mvc;
using SecondCapstone.Models;
using SecondCapstone.Repositories;

namespace SecondCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraRepository CameraRepository;

        public CameraController(ICameraRepository cameraRepository)
        {
            CameraRepository = cameraRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CameraRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var camera = CameraRepository.GetById(id);
            if (camera == null)
            {
                return NotFound();
            }
            return Ok(camera);
        }

        [HttpPost]
        public IActionResult Post(Camera camera)
        {
            CameraRepository.Add(camera);
            return CreatedAtAction("Get", new { id = camera.Id }, camera);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Camera camera)
        {
            if (id != camera.Id)
            {
                return BadRequest();
            }

            CameraRepository.Update(camera);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CameraRepository.Delete(id);
            return NoContent();
        }
    }
}
