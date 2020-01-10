using DomainModel;

namespace Services
{
    interface IBookService
    {
        bool IsValidBook(Book book);
        bool AddNewBook(Book book);
    }
}
