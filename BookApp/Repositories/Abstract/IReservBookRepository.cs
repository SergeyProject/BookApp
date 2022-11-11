using BookApp.Models;

namespace BookApp.Repositories.Abstract
{
    public interface IReservBookRepository<T>where T : class
    {
        Guid Create(T item);
        void Delete(Guid bookId);
        IEnumerable<T> GetAllReserv();
    }
}
