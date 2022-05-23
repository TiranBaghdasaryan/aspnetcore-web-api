using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class AuthorWithBooksVM
    {
        public string Name { get; set; }
        public List<BookWithAuthorsVM> Books { get; set; }
    }
}