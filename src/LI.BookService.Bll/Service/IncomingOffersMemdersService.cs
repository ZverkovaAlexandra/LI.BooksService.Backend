using System;
using System.Collections.Generic;
using System.Text;
using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class IncomingOffersMemdersService : IIncomingOffersMemders
    {
        private IIncomingOffersMemders _incomingOffersMemders;
        public IncomingOffersMemdersService(IIncomingOffersMemders incomingOffersMemders)
        {
            _incomingOffersMemders = incomingOffersMemders;
        }

        public async Task СompareExchangeListIdAsync(ExchangeListDTO exchangeListDTO)
        {
            ExchangeList userList = new ExchangeList();

            var user = await _userRepository.GetByIdAsync(editedUserDTO.UserId);
            //User user = new User();
            //MapEntityCreate(user, createUserDTO);
            //await _userRepository.CreateAsync(user);

            //return createUserDTO;
        }

        //public async Task CreateUserValueCategory(DtoRequestBook requestBook)
        //{
        //    UserList userList = new UserList() { TypeList = UserListType.OfferList };

        //    foreach (var s in requestBook.Categories)
        //    {
        //        var category = await _offerListRepository.GetCategoryAsync(s);
        //        if (category != null)
        //        {
        //            UserValueCategory userValueCategory = new UserValueCategory() { CategoryId = s, UserList = userList };
        //            await _userValueCategoryRepository.CreateAsync(userValueCategory);
        //        }
        //    }
        //}
//____________________________________________________________________________________________________________________________________
//____________________________________________________________________________________________________________________________________
        //public async Task<CreateUserDTO> CreateUserAsync(CreateUserDTO createUserDTO)
        //{
        //    User user = new User();
        //    MapEntityCreate(user, createUserDTO);
        //    await _userRepository.CreateAsync(user);

        //    return createUserDTO;
        //}
    }
}
