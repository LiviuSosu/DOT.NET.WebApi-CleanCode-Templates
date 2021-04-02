using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
