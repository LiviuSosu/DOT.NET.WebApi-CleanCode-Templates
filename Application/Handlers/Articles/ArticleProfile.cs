using Application.Handlers.Articles.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Handlers.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleLookupModel>();
        }
    }
}
