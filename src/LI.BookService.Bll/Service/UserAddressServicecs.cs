using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;

namespace LI.BookService.Bll.Service
{
    public class UserAddressServicecs : IUserAddressService
    {
        /// <summary>
        /// создание адреса пользователя
        /// </summary>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        public UserAddress CreateUserAddress(DtoUserAddress dtoUserAddress)
        {
            UserAddress userAddress = new UserAddress();
            AdressSetValue(userAddress, dtoUserAddress);

            return userAddress;
        }

        /// <summary>
        /// редактирование адреса пользователя
        /// </summary>
        /// <param name="userAddress"></param>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        public UserAddress EditUserAddress(UserAddress userAddress, DtoUserAddress dtoUserAddress)
        {
            AdressSetValue(userAddress, dtoUserAddress);

            return userAddress;
        }

        /// <summary>
        /// хелпер для установки значения полей сущности адреса пользователя
        /// </summary>
        /// <param name="userAddress"></param>
        /// <param name="dtoUserAddress"></param>
        public void AdressSetValue(UserAddress userAddress, DtoUserAddress dtoUserAddress)
        {
            userAddress.AddrApart = dtoUserAddress.AddrApart;
            userAddress.AddrCity = dtoUserAddress.AddrCity;
            userAddress.AddrHouse = dtoUserAddress.AddrHouse;
            userAddress.AddrIndex = dtoUserAddress.AddrIndex;
            userAddress.AddrSreet = dtoUserAddress.AddrStreet;
            userAddress.AddrStructure = dtoUserAddress.AddrStructure;
            userAddress.IsDefault = dtoUserAddress.IsDefault;
        }

        /// <summary>
        /// преобразование сущности адреса в дто для отправки пользователю
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        public DtoUserAddress GetAddressUser(UserAddress userAddress)
        {
            DtoUserAddress dtoUserAddress = new DtoUserAddress();
            dtoUserAddress.Id = userAddress.UserAddressId;
            dtoUserAddress.IsDefault = userAddress.IsDefault;
            dtoUserAddress.AddrApart = userAddress.AddrApart;
            dtoUserAddress.AddrCity = userAddress.AddrCity;
            dtoUserAddress.AddrHouse = userAddress.AddrHouse;
            dtoUserAddress.AddrIndex = userAddress.AddrIndex;
            dtoUserAddress.AddrStreet = userAddress.AddrSreet;
            dtoUserAddress.AddrStructure = userAddress.AddrStructure;

            return dtoUserAddress;
        }
    }
}
