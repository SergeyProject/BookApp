using BookApp.Models;
using BookApp.Models.Resmodels;
using BookApp.Repositories.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository<Book> _bookRepository;
        private readonly IReservBookRepository<ReservBook> _reservBookRepository;
        public BookController(IBookRepository<Book> bookRepository, IReservBookRepository<ReservBook> reservBookRepository)
        {
            _bookRepository = bookRepository;
            _reservBookRepository = reservBookRepository;
        }

        /// <summary>
        /// Получить книгу по Id
        /// </summary>  
        [HttpGet]
        //[EnableCors("AllowOrigin")]
        [Route("api/GetBook")]
        public JsonResult GetBook(Guid id)
        {
            try
            {
                var responce = _bookRepository.Get(id);
                return new JsonResult(responce);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        /// <summary>
        /// Получить список всех книг
        /// </summary> 
        //[EnableCors("AllowOrigin")]
        [HttpGet]
        [Route("api/GetAllBooks")]
        public JsonResult GetAllBooks()
        {
            return new JsonResult(_bookRepository.GetAll());
        }


        /// <summary>
        /// Удалить книгу по Id
        /// </summary>  
        [HttpGet]
        [Route("api/DeleteBook")]
        public IActionResult DeleteBook(Guid id)
        {
            _bookRepository.Delete(id);
            _reservBookRepository.Delete(id);
            return Ok("Ok");

        }

        /// <summary>
        /// Создать новую книгу
        /// </summary>  
        [HttpPost]
        [Route("api/CreateBook")]
        public IActionResult CreateBook([FromBody] Book book)
        {
            return Ok(_bookRepository.Create(book));
        }


        /// <summary>
        /// Резервирование книги
        /// </summary>      
        [HttpPost]
        [Route("api/ReserveBook")]
        public IActionResult ReserveBook(Guid bookId, string comment)
        {
            foreach (var item in _reservBookRepository.GetAllReserv())
            {
                if (item.BookId == bookId)
                    return BadRequest();
            }

            ReservBook reservBook = new ReservBook()
            {
                BookId = bookId,
                Comment = comment
            };
            return Ok(_reservBookRepository.Create(reservBook));
        }

        /// <summary>
        /// Удаление зарезервированного статуса
        /// </summary>  
        [HttpPost]
        [Route("api/DelReserveBook")]
        public IActionResult DelReserveBook(Guid bookId)
        {
            _reservBookRepository.Delete(bookId);
            return Ok("OK!");
        }


        /// <summary>
        /// Список зарезервированных книг
        /// </summary>  
        [HttpGet]
        [Route("api/GetReservBooks")]
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


        /// <summary>
        /// Список не зарезервированных книг
        /// </summary>  
        [HttpGet]
        [Route("api/GetNoReservBooks")]
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
    }
}
