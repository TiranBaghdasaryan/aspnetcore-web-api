using System;
using System.Collections.Generic;
using System.Linq;
using my_books.Data;
using my_books.Data.Model;
using my_books.Data.ViewModels;

namespace my_books.Services
{
    public class BooksService : IBooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            Book _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks() => _context.Books;
        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(x => Equals(x.Id, bookId));

        public Book UpdateBookById(int bookId, BookVM book)
        {
            Book _book = _context.Books.FirstOrDefault(x => Equals(x.Id, bookId));
            if (!_book.Equals(null))
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead : null;
                _book.Rate = book.IsRead ? book.Rate : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
            }

            _context.SaveChanges();

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            Book book = _context.Books.FirstOrDefault(x => Equals(x.Id, bookId));

            if (!Equals(book, null))
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}