using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LI.BookService.Model.Entities
{
    public class OfferList /*: IEntityBase*/
    {
        [Required]
        [Key]
        public int IdOfferList { get; set; }
        [Required]
        public int IdBookLiterary { get; set; }
        [Required]
        public int IdUser { get; set; }
        [MaxLength(13, ErrorMessage = "Максимальная  длина составляет 13 символов")]
        public string ISBN { get; set; }
        [Required]
        [MaxLength(4, ErrorMessage = "Максимальная  длина составляет 4 символа")]
        public DateTime YearPublishing { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        [Required]
        public DateTime UpdateAt { get; set; }
        [Required]
        public int IdStatus { get; set; }
        [ForeignKey("IdBookLiterary")]
        public BookLiterary BookLiterary { get; set; }
        //[ForeignKey("IdUser")]
        //public User User { get; set; }

    }
}
