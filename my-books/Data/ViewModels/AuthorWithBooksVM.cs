﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books.Data.ViewModels
{
    public class AuthorWithBooksVM
    {
        [Required] public string Name { get; set; }
        public List<BookWithAuthorsVM> Books { get; set; }
    }
}