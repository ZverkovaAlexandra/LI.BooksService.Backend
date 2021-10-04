using System;

namespace LI.BookService.Model.Entities
{
    public class OfferList : IEntityBase
    {
        public int IdOfferList { get; set; }
        public int IdBookLiterary { get; set; }
        public int IdUser { get; set; }
        public string ISBN { get; set; }
        public DateTime YearPublishing { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int IdStatus { get; set; }
        public BookLiterary BookLiterary { get; set; }
        public User User { get; set; }
        //public Status Status { get; set; }
    }
}
