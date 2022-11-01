namespace BookApp.Repositories.Abstract
{
    public interface IBookRepository<T>where T : class
    {
        Guid Create(T book);
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Update(Guid Id, T book);
    }
}
