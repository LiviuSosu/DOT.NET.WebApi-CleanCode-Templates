﻿using MediatR;

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
