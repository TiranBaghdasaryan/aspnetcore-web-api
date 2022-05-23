using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books.Data.Model
{
    public class Author
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public List<Book_Author> BookAuthor { get; set; }
    }
}