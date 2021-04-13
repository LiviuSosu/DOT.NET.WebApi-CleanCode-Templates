﻿using MediatR;
using System;

namespace Application.Handlers.Articles.Queries.GetArticle
{
    public class GetArticleQuery : IRequest<ArticleLookupModel>
    {
        public Guid ArticleId { get; set; }

        public GetArticleQuery(Guid articleId)
        {
            ArticleId = articleId;
        }
    }
}
