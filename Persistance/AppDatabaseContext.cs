using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public AppDatabaseContext(DbContextOptions<DbContext> options) : base(options)
        {          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
