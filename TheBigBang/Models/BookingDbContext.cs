using Microsoft.EntityFrameworkCore;

namespace TheBigBang.Models
{
    public class BookingDbContext:DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Hotels>()
                .HasMany(a => a.Room)
                .WithOne(b => b.Hotel)
                .HasForeignKey(p => p.Hid);
        }

    }
}