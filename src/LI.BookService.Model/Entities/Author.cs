namespace LI.BookService.Model.Entities
{
    public class Author : IEntityBase
    {
        public int IdAuthor { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
