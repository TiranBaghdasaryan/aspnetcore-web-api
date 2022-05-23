using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books.Data.ViewModels
{
    public class BookVM
    {
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Rate { get; set; }
        [Required] public string Genre { get; set; }
        [Required] public string CoverUrl { get; set; }
        [Required] public int PublisherId { get; set; }
        [Required] public List<int> AuthorIds { get; set; }
    }
}