using Domain.Entities;
using MediatR;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Articles.Commands.Create
{
    public class CreateArticleCommandHandler : BaseHandler<CreateArticleCommand, Unit>, IRequestHandler<CreateArticleCommand, Unit>
    {
        public CreateArticleCommandHandler(AppDatabaseContext context) : base(context)
        {
        }

        public new async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            _repoWrapper.Article.Create(_mapper.Map<Article>(request));
            await _repoWrapper.SaveAsync();
            return Unit.Value;
        }
    }
}
