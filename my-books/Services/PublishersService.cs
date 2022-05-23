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
            PublisherWithBooksVM result = _context.Publishers.Where(p => Equals(p.Id, id))
                .Select(p => new PublisherWithBooksVM()
                {
                    Name = p.Name,
                    Books = p.Books.Select(book => new BookWithAuthorsVM()
                        {
                            Title = book.Title,
                            Description = book.Description,
                            Rate = book.Rate,
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

        public void DeletePublisherById(int id)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(p => Equals(p.Id, id));

            if (!Equals(publisher, null))
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }
    }
}