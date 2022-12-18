using EventsAPI.Data;
using EventsAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventOrganizers()
        {
            var organizers = await _context.EventOrganizers.ToListAsync();
            return Ok(organizers);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 4)
            {
             var items = await _context.EventItem
              .OrderBy(e => e.Name)
              .Skip(pageIndex * pageSize)
              .Take(pageSize)
              .ToListAsync();

            items = ChangePictureUrl(items);
            return Ok(items);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item => item.PictureUrl = item.PictureUrl
                            .Replace("http://externaleventbaseurltobereplaced",
                            _config["ExternalBaseUrl"]));

            return items;
        }
    }
}
