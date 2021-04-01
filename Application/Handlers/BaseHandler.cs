using Application.Handlers.Articles;
using AutoMapper;
using MediatR;
using Persistance;
using Persistance.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class BaseHandler<TRequest, Unit> : IRequestHandler<TRequest, Unit> where TRequest : IRequest<Unit>
    {
        protected readonly IMapper _mapper;
        protected IRepositoryWrapper _repoWrapper;
        private readonly IRequestHandler<TRequest, Unit> _inner;

        public BaseHandler(AppDatabaseContext context)
        {
            _repoWrapper = new RepositoryWrapper(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArticleProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public Task<Unit> Handle(TRequest message, CancellationToken cancellationToken)
        {
            return _inner.Handle(message, cancellationToken);
        }
    }
}
