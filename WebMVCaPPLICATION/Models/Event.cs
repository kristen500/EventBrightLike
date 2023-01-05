namespace WebMVCaPPLICATION.Models
{
    public class Event
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<EventItem> Data { get; set; }


    }
}
