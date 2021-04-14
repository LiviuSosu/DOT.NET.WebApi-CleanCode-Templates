using MediatR;

namespace Application.Handlers.Articles.Commands.Create
{
    public class CreateArticleCommand : ArticleBaseModel, IRequest
    {
    }
}
