using BookApp.Models;
using BookApp.Repositories.Abstract;
using System.Linq;

namespace BookApp.Repositories
{
    public class ReservBookRepository : IReservBookRepository<ReservBook>
    {
     
        // Зарезервировать книгу       
        public Guid Create(ReservBook item)
        {
            using (DataContext db = new DataContext())
            {
                db.ReservBooks.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

       
        // Удаление из резерва по ID книги
        public void Delete(Guid bookId)
        {
            using (DataContext db = new DataContext())
            {
                ReservBook reservBook = db.ReservBooks.Where(e => e.BookId == bookId).FirstOrDefault();
                if (reservBook != null)
                {
                    db.ReservBooks.Remove(reservBook);
                    db.SaveChanges();
                }
            }
        }
        
         
       
        // Получение списка всех зарезервированных книг      
        public IEnumerable<ReservBook> GetAllReserv()
        {
            using (DataContext db = new DataContext())
            {
                return db.ReservBooks.ToList();
            }
        }
    }
}
