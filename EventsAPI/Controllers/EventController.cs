using EventsAPI.Data;
using EventsAPI.Domain;
using EventsAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
        //dependency injection
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        //global variable
        public EventController(EventContext context, IConfiguration config)
            // constructor for dependency injection    //inject configuration file
        {
            _context = context;
            _config = config;
            //set gloabal variable to local variable
        }

        [HttpGet("[action]")]
        //when you write a method in an APi-you write a route
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
            //catalog type information-convert to list and return back
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

            var itemsCount = _context.EventItem.LongCountAsync();
            var items = await _context.EventItem
              .OrderBy(e => e.Name)
              .Skip(pageIndex * pageSize)
              .Take(pageSize)
              .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PageinatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Data = items,
                Count = itemsCount.Result
            };
            return Ok(model);
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
