using BookApp.BL;
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
        BusinesLogic businesLogic;
        public BookController(IBookRepository<Book> bookRepository, IReservBookRepository<ReservBook> reservBookRepository)
        {
            _bookRepository = bookRepository;
            _reservBookRepository = reservBookRepository;
            businesLogic = new BusinesLogic(_bookRepository, _reservBookRepository);
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
            return Ok(businesLogic.ReserveBook(bookId, comment));
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
        [Route("api/GetReservedBooks")]
        public JsonResult GetAllReservBook()
        {
            return businesLogic.GetAllReservBook();
        }


        /// <summary>
        /// Список не зарезервированных книг
        /// </summary>  
        [HttpGet]
        [Route("api/GetNoReservedBooks")]
        public JsonResult GetAllNoReservBook()
        {
            return new JsonResult(businesLogic.GetAllNoReservBook());
        }
    }
}
