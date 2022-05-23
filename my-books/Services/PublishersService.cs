using System.Linq;
using my_books.Data;
using my_books.Data.Model;
using my_books.Data.ViewModels;

namespace my_books.Services
{
    public class PublishersService : IPublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            Publisher _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksVM GetPublisherWithBooksById(int id)
        {
            var result = _context.Publishers.Where(p => Equals(p.Id, id))
                .Select(p => new PublisherWithBooksVM()
                {
                    Name = p.Name,
                    Books = p.Books.Select(book => new BookWithAuthorsVM()
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