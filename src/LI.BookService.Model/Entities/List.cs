namespace LI.BookService.Model.Entities
{
    public class List:IEntityBase
    {
        public int IdList { get; set; }
        public int IdOfferList { get; set; }
        public int IdWishList { get; set; }

        public OfferList OfferList { get; set; }
        public WishList WishList { get; set; }
    }
}
