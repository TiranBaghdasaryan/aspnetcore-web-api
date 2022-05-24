using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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

        public void DeleteAuthorById(int authorId)
        {
            Author author = _context.Authors.FirstOrDefault(a => Equals(a.Id, authorId));

            if (!Equals(author, null))
            {
                _context.Authors.Remove(author);

                _context.SaveChanges();
                List<Book> RemovedBooks = new List<Book>();
 
                int[] bookIdsInPivot = _context.BookAuthor.Select(ba => ba.BookId).ToArray();

                int[] bookIds = _context.Books.Select(b => b.Id).ToArray();

                for (int i = 0; i < bookIds.Length; i++)
                {
                    if (!bookIdsInPivot.Contains(bookIds[i]))
                    {
                        var book = _context.Books.Single(b => Equals(b.Id, bookIds[i]));
                        if (!Equals(book, null))
                            RemovedBooks.Add(book);
                    }
                }

                _context.Books.RemoveRange(RemovedBooks);

                _context.SaveChanges();
            }
        }
    }
}