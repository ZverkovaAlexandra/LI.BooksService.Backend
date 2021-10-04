using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;

namespace LI.BookService.Bll.Service
{
    public class BookRequestService : IBookRequestService
    {
        public OfferList CreateRequestBook(DtoRequestBook requestBook)
        {
            OfferList newOffer = new OfferList();
            newOffer.ISBN = requestBook.ISBN;
            newOffer.YearPublishing = requestBook.YearPublishing;

            return newOffer;
        }

        /// <summary>
        /// редактирование заявки на книгу
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        public OfferList EditRequestBook(OfferList offer, DtoRequestBook requestBook)
        {
            offer.ISBN = requestBook.ISBN;
            offer.YearPublishing = requestBook.YearPublishing;
            return offer;
        }

    }
}
