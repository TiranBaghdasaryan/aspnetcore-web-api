using my_books.Data.ViewModels;

namespace my_books.Services
{
    public interface IPublishersService
    {
        public void AddPublisher(PublisherVM publisher);
        public PublisherWithBooksVM GetPublisherWithBooksById(int id);
        public void DeletePublisherById(int id);
    }
}