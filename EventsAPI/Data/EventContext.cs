using EventsAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        { }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }
        public DbSet<EventItem> EventItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<EventOrganizer>(e =>
            {
                e.Property(o => o.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(o => o.Organizer)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(300);

                e.Property(i => i.Price)
                .IsRequired();

                e.HasOne(t => t.EventType)
                .WithMany()
                .HasForeignKey(t => t.EventTypeId);

                e.HasOne(t => t.EventOrganizer)
                .WithMany()
                .HasForeignKey(t => t.EventOrganizer);
            });
        }
    }

}
