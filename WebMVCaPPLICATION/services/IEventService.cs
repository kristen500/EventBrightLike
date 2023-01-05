using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVCaPPLICATION.Models;

namespace WebMVCaPPLICATION.services
{
    public interface IEventService
    {
        Task<Event> GetEventItemsAsync(int page, int size, int? brand, int? type);
        Task<IEnumerable<SelectListItem>> GetOrganizersAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();




    }
}
