namespace LI.BookService.Model.Entities
{
    public class BookLiterary : IEntityBase
    {
        public int IdBookLiterary { get; set; }
        public int IdAuthor { get; set; }
        public string BookName { get; set; }
        public string Note { get; set; }
        public Author Author { get; set; }
    }
}
