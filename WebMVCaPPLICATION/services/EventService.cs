using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVCaPPLICATION.Models;

namespace WebMVCaPPLICATION.services
{
    public class EventService : IEventService
    {
        public Task<Event> GetEventItemsAsync(int page, int size, int? brand, int? type)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetOrganizersAsync()
        {
            APIPaths.
        }

        public Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
