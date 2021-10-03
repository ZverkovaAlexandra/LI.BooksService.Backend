using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LI.BookService.Model.Entities
{
    public class UserList : IEntityBase
    {
        
        [Key]
        public int IdUserList { get; set; }
        public int TypeList { get; set; }
        public int IdList { get; set; }
        [ForeignKey("IdList")]
        public List List { get; set; }
       
    }
}

