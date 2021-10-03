using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LI.BookService.Model.Entities
{
    public class BookLiterary : IEntityBase
    {
        [Required]
        [Key]
        public int IdBookLiterary { get; set; }
        [Required]
        public int IdAutor { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Максимальная  длина составляет 50 символов")]
        public string BookName { get; set; }
        [MaxLength(50, ErrorMessage = "Максимальная  длина составляет 50 символов")]
        public string Note { get; set; }
        [ForeignKey("IdAuthor")]
        public Autor Autor {get; set; }
}
    }
