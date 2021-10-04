
namespace LI.BookService.Model.Entities
{
    public class UserList : IEntityBase
    {
        public int UserListId { get; set; }
        public int TypeList { get; set; }
        public int ListId { get; set; }
        public List List { get; set; }
        
    }
}

