using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DatabaseContext(DbContextOptions<DbContext> options) : base(options)
        {          
        }
    }
}
