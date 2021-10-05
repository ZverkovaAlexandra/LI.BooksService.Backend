using System;

namespace LI.BookService.Model.DTO
{
    /// <summary>
    /// заявка для обмена книги
    /// </summary>
    public class DtoRequestBook
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string BookName { get; set; }
        public DateTime YearPublishing { get; set; }
        public string ISBN { get; set; }
        public int[] Categories { get; set; }
    }

}
