using Persistance.Repository.ArticleRepository;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public interface IRepositoryWrapper
    {
        IArticleRepository Article { get; }

        Task SaveAsync();
    }
}
