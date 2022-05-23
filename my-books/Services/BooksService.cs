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

        public void AddBookWithAuthors(BookVM book)
        {
            Book _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (int authorId in book.AuthorIds)
            {
                Book_Author bookAuthor = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = authorId
                };
                _context.BookAuthor.Add(bookAuthor);
            }

            _context.SaveChanges();
        }

        public IEnumerable<BookWithAuthorsVM> GetAllBooks()
        {
            IEnumerable<BookWithAuthorsVM> result =
                (from book in _context.Books
                    select new BookWithAuthorsVM()
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
                    });

            return result;
        }

        public BookWithAuthorsVM GetBookById(int bookId)
        {
            // BookWithAuthorsVM result = _context.Books
            //     .Where(book => Equals(book.Id, bookId))
            //     .Select(
            //         book => new BookWithAuthorsVM()
            //         {
            //             Title = book.Title,
            //             Description = book.Description,
            //             IsRead = book.IsRead,
            //             DateRead = book.IsRead ? book.DateRead : null,
            //             Rate = book.IsRead ? book.Rate : null,
            //             Genre = book.Genre,
            //             CoverUrl = book.CoverUrl,
            //             PublisherName = book.Publisher.Name,
            //             AuthorNames = book.BookAuthor.Select(n => n.Author.Name).ToList()
            //         })
            //     .FirstOrDefault();
            //
            // return result;

            BookWithAuthorsVM result =
                (from book in _context.Books
                    where book.Id == bookId
                    select new BookWithAuthorsVM()
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
                .FirstOrDefault();

            return result;
        }

        public Book UpdateBookById(int bookId, BookVM book)
        {
            Book _book = _context.Books.FirstOrDefault(x => Equals(x.Id, bookId));
            if (!_book.Equals(null))
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.PublisherId = book.PublisherId;
            }

            //_context.BookAuthor.Select(ba =>Equals(ba.BookId,bookId))
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