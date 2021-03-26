using Domain.Entities;
using Persistance.Repository.ArticleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DbContext<Article> _careerTrackDbContext;
        private IArticleRepository _article;
        public RepositoryWrapper(DbContext<Article> CareerTrackDbContext)
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
    }
}
