using HouseRental.Shared;
using Microsoft.EntityFrameworkCore;

namespace HouseRental.API.Database
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<FeatureCard> FeatureCards => Set<FeatureCard>();
        public DbSet<DestinationCard> DestinationCards => Set<DestinationCard>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeatureCard>().HasKey(e => e.EntryID);
            modelBuilder.Entity<DestinationCard>().HasKey(e => e.EntryID);
        }
    }
}
