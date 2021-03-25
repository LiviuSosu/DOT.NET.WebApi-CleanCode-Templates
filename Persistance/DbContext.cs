using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    public class DbContext<T> where T : class
    {
        public List<T> Entities { get; set; }
        public List<Article> Articles { get; set; }

        public DbContext()
        {
             
        }
    }
}
