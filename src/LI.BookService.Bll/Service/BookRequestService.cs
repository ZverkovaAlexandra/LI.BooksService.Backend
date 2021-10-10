using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class BookRequestService : IBookRequestService
    {
        private IOfferListRepository _offerListRepository;
        private IAuthorRepository _authorRepository;
        private IBookLiteraryRepository _bookLiteraryRepository;
        private IUserValueCategoryRepository _userValueCategoryRepository;

        public BookRequestService(IOfferListRepository offerListRepository, IAuthorRepository authorRepository, IBookLiteraryRepository bookLiteraryRepository, IUserValueCategoryRepository userValueCategoryRepository)
        {
            _offerListRepository = offerListRepository;
            _authorRepository = authorRepository;
            _bookLiteraryRepository = bookLiteraryRepository;
            _userValueCategoryRepository = userValueCategoryRepository;

        }
        /// <summary>
        /// создание заявки на книгу
        /// </summary>
        /// <param name="dtoNewRequest"></param>
        /// <returns></returns>
        public async Task<DtoNewRequest> CreateRequestBook(DtoNewRequest dtoNewRequest)
        {
            await CreateUserValueCategory(dtoNewRequest.DtoRequestBook);
            await CreateOfferListAsync(dtoNewRequest.DtoRequestBook);

            return dtoNewRequest;
        }
        public async Task<Author> CrerateAuthorAsync(DtoRequestBook requestBook)
        {
            Author author = new Author() { FirstName = requestBook.AuthorFirstName, LastName = requestBook.AuthorLastName };
            await _authorRepository.CreateAsync(author);
            var selectAuthor = await _authorRepository.GetAuthorByName(author.FirstName,author.LastName);

            return selectAuthor;
        }
        public async Task<BookLiterary> CreateBookLIteraryAsync(DtoRequestBook requestBook,Author author)
        {
            BookLiterary bookLitherary = new BookLiterary() { Author = author, BookName = requestBook.BookName };
            await _bookLiteraryRepository.CreateAsync(bookLitherary);
            var selectBookLiterary = await _bookLiteraryRepository.GetBookLiterary(requestBook, author);

            return selectBookLiterary;
        }
        public async Task CreateUserValueCategory(DtoRequestBook requestBook)
        {
            UserList userList = new UserList() { TypeList = UserListType.OfferList };

            foreach (var s in requestBook.Categories)
            {
                var category = await _offerListRepository.GetCategoryAsync(s);
                if (category != null)
                {
                    UserValueCategory userValueCategory = new UserValueCategory() { CategoryId = s, UserList = userList };
                    await _userValueCategoryRepository.CreateAsync(userValueCategory);
                }
            }
        }


        public async Task CreateOfferListAsync(DtoRequestBook requestBook)
        {
            var author = await CrerateAuthorAsync(requestBook);
            var bookLitherary =await  CreateBookLIteraryAsync(requestBook,author);

            OfferList newOffer = new OfferList();
            newOffer.BookLiterary = bookLitherary;
            newOffer.YearPublishing = requestBook.YearPublishing;
            newOffer.CreateAt = DateTime.Now;
            newOffer.UpdateAt = DateTime.Now;

            await _offerListRepository.CreateAsync(newOffer);
        }

        /// <summary>
        /// редактирование заявки на книгу
        /// </summary>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        public async Task<DtoRequestBook> EditRequestBookAsync(DtoRequestBook requestBook)
        {
            var author = await _authorRepository.GetAuthorByName(requestBook.AuthorFirstName, requestBook.AuthorLastName);
            var bookLiterary = await _bookLiteraryRepository.GetBookLiterary(requestBook, author);

            var offerList = await _offerListRepository.GetByIdAsync(requestBook.Id);

            offerList.BookLiteraryId = bookLiterary.BookLiteraryId;
            offerList.ISBN = requestBook.ISBN;
            offerList.UpdateAt = DateTime.Now;
            offerList.YearPublishing = requestBook.YearPublishing;

            await _offerListRepository.UpdateAsync(offerList);

            return requestBook;

        }


    }
}
