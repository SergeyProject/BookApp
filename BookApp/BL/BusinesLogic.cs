using BookApp.Models;
using BookApp.Models.Resmodels;
using BookApp.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.BL
{
    public class BusinesLogic
    {
        private readonly IBookRepository<Book> _bookRepository;
        private readonly IReservBookRepository<ReservBook> _reservBookRepository;
        public BusinesLogic(IBookRepository<Book> bookRepository, IReservBookRepository<ReservBook> reservBookRepository)
        {
            _bookRepository = bookRepository;
            _reservBookRepository = reservBookRepository;
        }
        public JsonResult GetAllNoReservBook()
        {
            bool isNoReserve = false;
            List<Book> books = new List<Book>();
            foreach (var book in _bookRepository.GetAll())
            {
                foreach (ReservBook resBook in _reservBookRepository.GetAllReserv())
                {
                    if (resBook.BookId == book.Id)
                    {
                        isNoReserve = false;
                        break;
                    }
                    else
                    {
                        isNoReserve = true;
                    }
                }
                if (isNoReserve)
                    books.Add(book);
            }
            return new JsonResult(books);

        }

        public JsonResult GetAllReservBook()
        {
            List<Book> books = new List<Book>();
            List<Reserv> reserv = new List<Reserv>();

            foreach (var book in _bookRepository.GetAll())
            {
                foreach (ReservBook item in _reservBookRepository.GetAllReserv())
                {
                    if (item.BookId == book.Id)
                    {
                        reserv.Add(new Reserv { BookId = book.Id, Name = book.Name, Author = book.Author, Comments = item.Comment });
                    }
                }
            }
            return new JsonResult(reserv);
        }

        public string ReserveBook(Guid bookId, string comment)
        {
            foreach (var item in _reservBookRepository.GetAllReserv())
            {
                if (item.BookId == bookId)
                    return "Error!";
            }

            ReservBook reservBook = new ReservBook()
            {
                BookId = bookId,
                Comment = comment
            };
            Guid Id = _reservBookRepository.Create(reservBook);
            return Id.ToString();
        }
    }
}


