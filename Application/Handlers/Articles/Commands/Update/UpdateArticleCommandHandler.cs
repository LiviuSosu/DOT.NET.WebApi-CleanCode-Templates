using Domain.Entities;
using MediatR;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Articles.Commands.Update
{
    public class UpdateArticleCommandHandler : BaseHandler<UpdateArticleCommand, Unit>, IRequestHandler<UpdateArticleCommand, Unit>
    {
        public UpdateArticleCommandHandler(AppDatabaseContext context) : base(context)
        {
        }

        public new async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            _repoWrapper.Article.Update(_mapper.Map<Article>(request));
            await _repoWrapper.SaveAsync();
            return Unit.Value;
        }
    }
}
