using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Articles.Queries.GetArticles
{
    public class ArticlesListViewModel
    {
        public IList<ArticleLookupModel> Articles { get; set; }
    }
}
