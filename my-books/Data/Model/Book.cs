using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Rate { get; set; }
        [Required] public string Genre { get; set; }
        [Required] public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        [Required] public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> BookAuthor { get; set; }
    }
}