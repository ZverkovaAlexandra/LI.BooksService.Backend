using System;
using LI.BookService.Model.Entities;

namespace LI.BookService.Model.DTO
{
    public class ExchangeConfirmation2DTO
    {
        public int ExchangeListId { get; set; }
        public int OfferList1Id { get; set; }
        public int WishList1Id { get; set; }
        public int OfferList2Id { get; set; }
        public int WishList2Id { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsBoth { get; set; }
        public OfferList OfferList { get; set; }
        public WishList WishList { get; set; }
    }
}
