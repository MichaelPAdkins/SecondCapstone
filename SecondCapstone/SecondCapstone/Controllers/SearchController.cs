using Microsoft.AspNetCore.Mvc;
using SecondCapstone.Repositories;
using SecondCapstone.Models;
using System.Collections.Generic;

namespace SecondCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IEntryRepository _entryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICameraRepository _cameraRepository;

        public SearchController(
            IEntryRepository entryRepository, 
            ITagRepository tagRepository, 
            ILocationRepository locationRepository, 
            ICameraRepository cameraRepository)
        {
            _entryRepository = entryRepository;
            _tagRepository = tagRepository;
            _locationRepository = locationRepository;
            _cameraRepository = cameraRepository;
        }

        // GET api/Search?query=something
        [HttpGet]
[HttpGet]
public IActionResult Search(string query)
{
    var entries = new List<Entry>();

    // Search for tags matching the query
    var tags = _tagRepository.GetBySearchQuery(query);
    foreach (var tag in tags)
    {
        var tagEntries = _entryRepository.GetEntriesByTagId(tag.Id);
        entries.AddRange(tagEntries);
    }

    // Search for locations matching the query
    var locations = _locationRepository.GetBySearchQuery(query);
    foreach (var location in locations)
    {
        var locationEntries = _entryRepository.GetEntriesByLocationId(location.Id);
        entries.AddRange(locationEntries);
    }

    // Search for cameras matching the query
    var cameras = _cameraRepository.GetBySearchQuery(query);
    foreach (var camera in cameras)
    {
        var cameraEntries = _entryRepository.GetEntriesByCameraId(camera.Id);
        entries.AddRange(cameraEntries);
    }

    // Ensure unique entries are returned (if an entry matches multiple conditions)
    var distinctEntries = entries.Distinct().ToList();

    // Return the populated entries
    return Ok(distinctEntries);
}
    }
}