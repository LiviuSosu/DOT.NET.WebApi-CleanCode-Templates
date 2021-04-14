using MediatR;
using System;

namespace Application.Handlers.Articles.Commands.Delete
{
    public class DeleteArticleCommand : ArticleBaseModel, IRequest
    {
        public Guid Id { get; set; }
    }
}
