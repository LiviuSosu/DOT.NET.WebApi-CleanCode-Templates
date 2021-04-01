using Domain.Entities;

namespace Persistance.Repository.ArticleRepository
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(AppDatabaseContext careerTrackDbContext)
        : base(careerTrackDbContext)
        {
        }
    }
}
