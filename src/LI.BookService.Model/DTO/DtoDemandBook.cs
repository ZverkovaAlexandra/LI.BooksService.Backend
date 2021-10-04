using System;

namespace LI.BookService.Model.DTO
{
    /// <summary>
    /// заявка для обмена книги
    /// </summary>
    public class DtoDemandBook
    {
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        public DateTimeOffset YearPublishing { get; set; }
        public string ISBN { get; set; }
        public int[] Categories { get; set; }
        public int AddressId { get; set; }
    }

}
