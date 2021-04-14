using Domain.Entities;
using MediatR;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Articles.Commands.Delete
{
    public class DeleteArticleCommandHandler : BaseHandler<DeleteArticleCommand, Unit>, IRequestHandler<DeleteArticleCommand, Unit>
    {
        public DeleteArticleCommandHandler(AppDatabaseContext context) : base(context)
        {
        }

        public new async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            _repoWrapper.Article.Delete(_mapper.Map<Article>(request));
            await _repoWrapper.SaveAsync();
            return Unit.Value;
        }
    }
}
