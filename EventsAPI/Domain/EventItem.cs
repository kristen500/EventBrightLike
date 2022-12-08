namespace EventsAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }  
        public string PictureUrl { get; set; } 

        public int EventTypeId { get; set; }    
        public int EventOrganizerId { get; set; }   

        public virtual EventType EventType { get; set; }    
        public virtual EventOrganizer EventOrganizer { get; set; }  

    }
}
