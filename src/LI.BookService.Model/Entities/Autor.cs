using System.ComponentModel.DataAnnotations;

namespace LI.BookService.Model.Entities
{
    public class Autor : IEntityBase
    {
        [Required]
        [Key]
        public int IdAutor { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Максимальная  длина составляет 20 символов")]
        public string LastName { get; set; }
        [MaxLength(20, ErrorMessage = "Максимальная  длина составляет 20 символов")]
        public string FirstName { get; set; }
    }
}
