using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class ExchangeService : IExchangeService
    {
        private IExchangeListRepository _exchangeListRepository;
        private IOfferListRepository _offerListRepository;
        private IWishListRepository _wishListRepository;
        private IUserListRepository _userlistRepository;
        private IUserValueCategoryRepository _userValueCategory;
        public ExchangeService(IExchangeListRepository exchangeListRepository, IOfferListRepository offerListRepository, IWishListRepository wishListRepository, IUserListRepository userlistRepository, IUserValueCategoryRepository userValueCategory)
        {
            _exchangeListRepository = exchangeListRepository;
            _offerListRepository = offerListRepository;
            _wishListRepository = wishListRepository;
            _userlistRepository = userlistRepository;
            _userValueCategory = userValueCategory;
        }

        public async Task<List<DtoExchangeVariantsBook>> GetVariantesAsync(int exchangeListId)
        {
            var exchangeList = await _exchangeListRepository.GetByIdAsync(exchangeListId);

            var offerlist = await _offerListRepository.GetByIdAsync(exchangeList.OfferList1Id); 
            var wishList = await _wishListRepository.GetByIdAsync(exchangeList.WishList1Id);

            var userListOfferType = await _userlistRepository.GetUserListAsync(offerlist.OfferListId, UserListType.OfferList);
            var userListWishType = await _userlistRepository.GetUserListAsync(wishList.WishListId, UserListType.WishList);

            var userValueCategoryOffer = await _userValueCategory.GetCategoriesByUserListIdAsync(userListOfferType.UserListId);// нашел категории из офферлистов
            var userValueCategoryWish = await _userValueCategory.GetCategoriesByUserListIdAsync(userListWishType.UserListId);// нашел категории из вишлистов

            var allCategory = userValueCategoryOffer.Union(userValueCategoryWish).ToList();///общий список категорий

            var userValueCategories = await _userValueCategory.GetUserValueCategoryAsync(allCategory);//по списку категорий находим список сущностей UserValueCategory

            var userListCategory = await _userlistRepository.GetExchangeUserListAsync();//находим все UserList в бд


            //////////////// нужно уточнить у Александры
            List<UserList> variantesListFull = new List<UserList>(); ///лист с полным совпадением по категориям
            List<UserList> variantesListPart = new List<UserList>(); ///лист с частичным совпадением по категориям

            foreach (var s in userListCategory)
            {
                if (userValueCategories.All(x => s.UserValueCategories.Contains(x)))
                {
                    variantesListFull.Add(s);
                }
                else
                {
                    while (userValueCategories.Count != 0)
                    {
                        userValueCategories.RemoveAt(userValueCategories.Count - 1);

                        if (userValueCategories.All(x => s.UserValueCategories.Contains(x)))
                        {
                            variantesListPart.Add(s);
                        }
                    }
                }
            }
            //////////////////////////////////
            

            var selectOfferLists = await _userlistRepository.GetOfferListAsync(variantesListFull);//находим все offer-листы,содержащие книги с  выбранными категориями

            var selectBookLiteraries = await _offerListRepository.GetBookLiterariesAsync(selectOfferLists); //находим названия всех книг,которые содержатся в найденных офферлистах

            var selectExchangeLists = await _exchangeListRepository.GetExchangeListsAsync(selectOfferLists);///находим все exchange-листы по найденным offer-листам
            List<DtoExchangeVariantsBook> listVariantes = new List<DtoExchangeVariantsBook>();

            for (int i=0;i<selectBookLiteraries.Count();i++)
            {
                DtoExchangeVariantsBook dto = new DtoExchangeVariantsBook();
                dto.NameBook = selectBookLiteraries.ElementAt(i).BookName;
                dto.ExchangeListId = selectExchangeLists.ElementAt(i).ExchangeListId;
                listVariantes.Add(dto);
            }


            


            return listVariantes;
        }

    }
}
