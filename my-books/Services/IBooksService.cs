using System.Collections.Generic;
using my_books.Data.Model;
using my_books.Data.ViewModels;

namespace my_books.Services
{
    public interface IBooksService
    {
        public void AddBook(BookVM book);
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(int bookId);
        public Book UpdateBookById(int bookId,BookVM book);

        public void DeleteBookById(int bookId);


    }
}