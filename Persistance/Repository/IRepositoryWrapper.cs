using Persistance.Repository.ArticleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public interface IRepositoryWrapper
    {
        IArticleRepository Article { get; }
    }
}
