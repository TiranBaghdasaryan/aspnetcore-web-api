using System.Linq;
using my_books.Data;
using my_books.Data.Model;
using my_books.Data.ViewModels;

namespace my_books.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            Author _author = new Author()
            {
                Name = author.Name,
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var result = _context.Authors
                .Where(a => Equals(a.Id, authorId))
                .Select(a => new AuthorWithBooksVM()
                {
                    Name = a.Name,
                    Books = a.BookAuthor
                        .Select(ba => ba.Book)
                        .Select(book => new BookWithAuthorsVM()
                        {
                            Title = book.Title,
                            Description = book.Description,
                            IsRead = book.IsRead,
                            DateRead = book.IsRead ? book.DateRead : null,
                            Rate = book.IsRead ? book.Rate : null,
                            Genre = book.Genre,
                            CoverUrl = book.CoverUrl,
                            PublisherName = book.Publisher.Name,
                            AuthorNames = (
                                    from bookAuthor in book.BookAuthor
                                    select bookAuthor.Author.Name
                                )
                                .ToList()
                        })
                        .ToList()
                })
                .FirstOrDefault();
            return result;
        }
    }
}