using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System;

namespace LI.BookService.Bll.Service
{
    public class BookRequestService : IBookRequestService
    {
        public OfferList CreateRequestBook(DtoRequestBook requestBook)
        {
            OfferList newOffer = new OfferList();

            Author author = new Author() { FirstName = requestBook.AuthorFirstName, LastName = requestBook.AuthorLastName };
            BookLiterary bookLitherary = new BookLiterary() { Author = author, BookName = requestBook.BookName };

            newOffer.BookLiterary = bookLitherary;
            newOffer.YearPublishing = requestBook.YearPublishing;
            newOffer.CreateAt = DateTime.Now;
            newOffer.UpdateAt = DateTime.Now;

            return newOffer;
        }

        /// <summary>
        /// редактирование заявки на книгу
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        public OfferList EditRequestBook(OfferList offer, DtoRequestEdit requestEdit)
        {
            Author author = new Author() { FirstName = requestEdit.AuthorFirstName, LastName = requestEdit.AuthorLastName };
            BookLiterary bookLitherary = new BookLiterary() { Author = author, BookName = requestEdit.BookName };
            offer.BookLiterary = bookLitherary;
            offer.YearPublishing = requestEdit.YearPublishing;
            offer.UpdateAt = DateTime.Now;

            return offer;

        }


    }
}
