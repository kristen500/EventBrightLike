using EventsAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsAPI.Data

{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();

            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetEventTypes());
                context.SaveChanges();
            }

            if (!context.EventOrganizers.Any())
            {
                context.EventOrganizers.AddRange(GetEventOrganizers());
                context.SaveChanges();
            }

            if (!context.EventItem.Any())
            {
                context.EventItem.AddRange(GetEventItems());
                context.SaveChanges();

            }

        }

        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                 new EventType{Type="Holiday"},
                new EventType{Type="Sports&Fitness"},
                new EventType{Type="Music"},
                new EventType{Type="Food&Drink"}

            };
        }

        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>
            {
                new EventOrganizer{Organizer="SeattleFunEvents"},
                new EventOrganizer {Organizer="Run2BeFit" },
                new EventOrganizer { Organizer="AuroraBorealisEventCenter"},
                new EventOrganizer { Organizer="VisitBallard"}

            };
        }


        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            {

            new EventItem { EventTypeId = 1, EventOrganizerId = 1, Description = "Everyone is Santa all over Downtown Seattle to Drink, eat, dance, and be merry", Name = "SantaCon", Price = 15, PictureUrl = "http://externaleventbaseurltobereplaced/api/event1" },
            new EventItem { EventTypeId = 2, EventOrganizerId = 2, Description = "5k Run", Name = "ItsaRunderfulLife", Price = 25, PictureUrl = "http://externaleventbaseurltobereplaced/api/event2" },
            new EventItem { EventTypeId = 3, EventOrganizerId = 3, Description = "80s Party", Name = "NiteWave", Price = 20, PictureUrl = "http://externaleventbaseurltobereplaced/api/event3" },
            new EventItem { EventTypeId = 4, EventOrganizerId = 4, Description = "Enjoy handcrafted cocktails while exploring boutique shops ", Name = "BallardCocktailTrail", Price = 45, PictureUrl = "http://externaleventbaseurltobereplaced/api/event4" },

            };
        }
    }
}
     
  