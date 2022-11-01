namespace BookApp.Models.Resmodels
{
    
    // Модель для хранения читаемых данных
    // зарезервированной книги
   
    public class Reserv
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }
    }
}
