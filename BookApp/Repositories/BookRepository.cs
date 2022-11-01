using BookApp.Models;
using BookApp.Repositories.Abstract;

namespace BookApp.Repositories
{
    public class BookRepository : IBookRepository<Book>
    {

        // Создать новую книгу
        public Guid Create(Book book)
        {
            using (DataContext db = new DataContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
                return book.Id;
            }
        }

        // Удалить книгу по ID
        public void Delete(Guid id)
        {
            using (DataContext db = new DataContext())
            {
                Book book = db.Books.Find(id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }

        // Получить книгу по ID
        public Book Get(Guid id)
        {
            using (DataContext db = new DataContext())
            {
                return db.Books.Find(id);
            }
        }

        // Получить список всех книг
        public IEnumerable<Book> GetAll()
        {
            using (DataContext db = new DataContext())
            {
                return db.Books.ToList();
            }
        }        

        // Отредактировать книгу
        public void Update(Guid Id, Book book)
        {
            using (DataContext db = new DataContext())
            {
                Book _book = db.Books.Find(Id);
                if (_book != null)
                {
                    _book.Author = book.Author;
                    _book.Name = book.Name;
                    
                    db.SaveChanges();
                }
            }
        }
    }
}
