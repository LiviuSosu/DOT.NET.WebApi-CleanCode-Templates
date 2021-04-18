using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;

namespace Tests.Articles
{
    public class ArticlesTest
    {
        public AppDatabaseContext db;
        protected Guid firstArticleId = Guid.Parse("777ACF7F-DAF6-4DF2-B80B-F0A69248249A");
        protected Guid secondArticleId = Guid.Parse("BB13D499-FE99-4451-B632-04D7759BD6D4");
        protected Guid nonExistingArticleId = Guid.Parse("FEA44EA2-1D4C-49AC-92A0-1AD6899CA220");

        protected DbContextOptions<AppDatabaseContext> options;

        public ArticlesTest()
        {
            options = new DbContextOptionsBuilder<AppDatabaseContext>().
                UseInMemoryDatabase(databaseName: "AppDatabaseArticles").Options;

            db = new AppDatabaseContext(options);

            var article1 = new Article
            {
                Id = firstArticleId,
                Title = "Article 1"
            };

            var article2 = new Article
            {
                Id = secondArticleId,
                Title = "Article 2"
            };

            try
            {
                db.Articles.Add(article1);
                db.Articles.Add(article2);

                db.SaveChanges();
            }
            catch (ArgumentException)
            {
                db.Articles.RemoveRange(db.Articles);
            }
        }
    }
}
