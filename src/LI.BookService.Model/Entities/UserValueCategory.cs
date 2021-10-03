using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LI.BookService.Model.Entities
{
    public class UserValueCategory : IEntityBase
    {
        [Key]
        public int IdUserValueCategory { get; set; }
        public int IdUserList { get; set; }
        public int IdCategory { get; set; }
       
        public Category Category { get; set; }
        public UserList UserList { get; set; }

    }
}
