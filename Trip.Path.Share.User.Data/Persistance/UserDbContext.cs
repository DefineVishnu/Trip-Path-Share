using Microsoft.EntityFrameworkCore;
using Trip.Path.Share.User.Data.Entity;

namespace Trip.Path.Share.Data.Persistance
{
    public class UserDbContext : DbContext
    {
        #region Ctor
        public UserDbContext(DbContextOptions<UserDbContext> options)
         : base(options)
        {
        }
        #endregion

        #region DbSet
        public DbSet<UserEntity> User { get; set; }
        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(/*Connection string */);
        }



        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        #endregion

    }
}
