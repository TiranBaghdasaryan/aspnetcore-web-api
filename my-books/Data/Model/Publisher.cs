using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books.Data.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}