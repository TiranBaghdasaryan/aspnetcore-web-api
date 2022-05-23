using System.ComponentModel.DataAnnotations;

namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        [Required] public string Name { get; set; }
    }
}