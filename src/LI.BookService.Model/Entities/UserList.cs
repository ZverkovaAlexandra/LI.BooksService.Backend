
using System.Collections.Generic;

namespace LI.BookService.Model.Entities
{
    public class UserList : IEntityBase
    {
        public int UserListId { get; set; }
        public UserListType TypeList { get; set; }
        public List<UserValueCategory> UserValueCategories { get; set; } = new List<UserValueCategory>();

    }

    public enum UserListType
    {
        OfferList,
        WishList
    }
}

