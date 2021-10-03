namespace LI.BookService.Model.Entities
{
    public interface IEntityBase
    {
        public int IdAutor { get; set; }
        public int IdBookLiterary { get; set; }
        //int IdOfferList { get; set; }
        public int IdUserList { get; set; }
        public int IdUserValueCategory { get; set; }
        public int IdCategory { get; set; }
        public int IdOfferList { get; set; }
        public int IdList { get; set; }
        public int IdWishList { get; set; }

    }
}
