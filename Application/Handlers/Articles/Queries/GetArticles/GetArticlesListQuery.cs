using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Articles.Queries.GetArticles
{
    public class GetArticlesListQuery : IRequest<ArticlesListViewModel>
    {
        public PagingModel PagingModel { get; set; }

        public GetArticlesListQuery(PagingModel pagingModel)
        {
            PagingModel = pagingModel;
        }
    }
}
