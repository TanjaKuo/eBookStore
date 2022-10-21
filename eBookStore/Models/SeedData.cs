using System;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookDbContext>>()))
            {

                if (context.Book.Any())
                {
                    return;
                }

                context.Book.AddRange(
                    new Book
                    {
                        Id = new Guid("9b0896fa-3880-4c2e-bfd6-925c87f22878"),
                        Title = "CQRS for Dummies",
                        Reserve = false
                    },
                    new Book
                    {
                        Id = new Guid("0550818d-36ad-4a8d-9c3a-a715bf15de76"),
                        Title = "Visual Studio Tips",
                        Reserve = false
                    },
                    new Book
                    {
                        Id = new Guid("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1"),
                        Title = "NHibernate Cookbook",
                        Reserve = false
                    }
                );
                context.SaveChanges();
            }
        }

    }
}