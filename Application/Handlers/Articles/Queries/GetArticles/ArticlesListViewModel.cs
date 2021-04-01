using System.Collections.Generic;

namespace Application.Handlers.Articles.Queries.GetArticles
{
    public class ArticlesListViewModel
    {
        public IList<ArticleLookupModel> Articles { get; set; }
    }
}
