using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;


namespace LI.BookService.Core.Interfaces
{
    public interface IBookRequestService
    {
        /// <summary>
        /// создание заявки на книгу
        /// </summary>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        OfferList CreateRequestBook(DtoRequestBook requestBook);

        /// <summary>
        /// редактирование заявки на книгу
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="requestEdit"></param>
        /// <returns></returns>
        OfferList EditRequestBook(OfferList offer, DtoRequestEdit requestEdit);

    }
}
