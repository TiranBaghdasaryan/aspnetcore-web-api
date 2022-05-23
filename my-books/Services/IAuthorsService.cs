using my_books.Data.ViewModels;

namespace my_books.Services
{
    public interface IAuthorsService
    {
        public void AddAuthor(AuthorVM author);
        public AuthorWithBooksVM GetAuthorWithBooks(int bookId);
    }
}