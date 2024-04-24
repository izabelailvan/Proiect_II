using Adopta_O_Emotie_Virtuala.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Adopta_O_Emotie_Virtuala.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
