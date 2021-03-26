using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.ArticleRepository
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext<Article> careerTrackDbContext)
        : base(careerTrackDbContext)
        {
        }
    }
}
