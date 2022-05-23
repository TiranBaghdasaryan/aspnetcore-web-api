using System.ComponentModel.DataAnnotations;

namespace my_books.Data.ViewModels
{
    public class PublisherVM
    {
        [Required] public string Name { get; set; }
    }
}