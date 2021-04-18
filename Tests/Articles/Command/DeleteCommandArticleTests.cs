﻿using Application.Handlers.Articles.Commands.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Articles.Command
{
    public class DeleteCommandArticleTests : ArticlesTest
    {
        [Fact]
        public async Task DeleteArticleSuccessTest_Success()
        {
            db = new AppDatabaseContext(options);

            var sut = new DeleteArticleCommandHandler(db);
            var updatedArticleCommand = new DeleteArticleCommand
            {
                Id = secondArticleId
            };

            var result = await sut.Handle(updatedArticleCommand, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async Task DeleteArticleSuccessTest_Fail_When_Article_Does_Not_Exist()
        {
            var updateArticleCommand = new DeleteArticleCommand
            {
                Id = nonExistingArticleId,
            };

            var sut = new DeleteArticleCommandHandler(db);

            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => sut.Handle(updateArticleCommand, CancellationToken.None));
        }
    }
}
