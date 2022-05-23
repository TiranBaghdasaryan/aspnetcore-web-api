using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Model;

namespace my_books.Data
{
    public class AppDbInitialization
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book()
                        {
                            Title = "First Book Title",
                            Description = "First Book Description",
                            Rate = 4,
                            Genre = "Horror",
                            CoverUrl = "url1",
                            DateAdded = DateTime.Now
                        },
                        new Book()
                        {
                            Title = "Second Book Title",
                            Description = "Second Book Description",
                            Rate = 4,
                            Genre = "Fantastic",
                            CoverUrl = "url2",
                            DateAdded = DateTime.Now
                        });
                    context.SaveChanges(); 
                }
                
            }
        }
    }
}