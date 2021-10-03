using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LI.BookService.Model.Entities
{
    public class Category : IEntityBase
    { 
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public int IdParent { get; set; }
        public bool MultiSelect { get; set; }
        public Category Parent{ get; set; }
    }
}
