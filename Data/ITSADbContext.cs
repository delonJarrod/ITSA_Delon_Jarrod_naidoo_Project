
using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.EntityFrameworkCore;
namespace ITSA_Delon_Jarrod_naidoo.Data
{
    public class ITSADbContext : DbContext
    {
        public ITSADbContext(DbContextOptions<ITSADbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DBConnection",
                    options => options.EnableRetryOnFailure());
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Meter> Meters { get; set; }

     

    }
}
