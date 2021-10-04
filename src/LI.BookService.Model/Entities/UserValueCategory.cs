using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LI.BookService.Model.Entities
{
    public class UserValueCategory : IEntityBase
    {
        public int IdUserValueCategory { get; set; }
        public int IdUserList { get; set; }
        public int IdCategory { get; set; }
    
        public UserList UserList { get; set; }
        public Category Category { get; set; }
    }
}
