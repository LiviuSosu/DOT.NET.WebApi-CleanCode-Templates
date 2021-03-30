using Persistance.Repository.ArticleRepository;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDatabaseContext _careerTrackDbContext;
        private IArticleRepository _article;
        public RepositoryWrapper(AppDatabaseContext CareerTrackDbContext)
        {
            _careerTrackDbContext = CareerTrackDbContext;
        }
        public IArticleRepository Article
        {
            get
            {
                if (_article == null)
                {
                    _article = new ArticleRepository.ArticleRepository(_careerTrackDbContext);
                }

                return _article;
            }
        }

        public async Task SaveAsync()
        {
            await _careerTrackDbContext.SaveChangesAsync();
        }
    }
}
