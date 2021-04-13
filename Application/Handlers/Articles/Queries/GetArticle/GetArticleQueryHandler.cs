using MediatR;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Articles.Queries.GetArticle
{
    public class GetArticleQueryHandler : BaseHandler<GetArticleQuery, ArticleLookupModel>, IRequestHandler<GetArticleQuery, ArticleLookupModel>
    {
        public GetArticleQueryHandler(AppDatabaseContext context) : base(context)
        {
        }

        public new async Task<ArticleLookupModel> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var article = await _repoWrapper.Article.FindByIdAsync(request.ArticleId);

            return _mapper.Map<ArticleLookupModel>(article);
        }
    }
}
