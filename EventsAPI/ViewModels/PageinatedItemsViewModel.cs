using EventsAPI.Domain;

namespace EventsAPI.ViewModels
{
    public class PageinatedItemsViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; } 
        public IEnumerable<EventItem> Data { get; set; }
    }
}
