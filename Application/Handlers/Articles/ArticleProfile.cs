using Application.Handlers.Articles.Commands.Create;
using Application.Handlers.Articles.Commands.Delete;
using Application.Handlers.Articles.Commands.Update;
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
            CreateMap<CreateArticleCommand, Article>();
            CreateMap<UpdateArticleCommand, Article>();
            CreateMap<DeleteArticleCommand, Article>();
        }
    }
}
