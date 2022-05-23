using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books.Data.ViewModels
{
    public class BookWithAuthorsVM
    {
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Rate { get; set; }
        [Required] public string Genre { get; set; }
        [Required] public string CoverUrl { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}