using Microsoft.EntityFrameworkCore;
using Trip.Path.Share.Data.Entity;

namespace Trip.Path.Share.Data.Persistance
{
    public class TripShareDbContext : DbContext
    {
        public TripShareDbContext(DbContextOptions<TripShareDbContext> options)
         : base(options)
        {
        }

        public DbSet<TripEntity> Trip { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(/*Connection string */);
        }



        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

    }
}
