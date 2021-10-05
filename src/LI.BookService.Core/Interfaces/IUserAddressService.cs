using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;


namespace LI.BookService.Core.Interfaces
{
    public interface IUserAddressService
    {
        /// <summary>
        /// создание адреса пользователя
        /// </summary>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        UserAddress CreateUserAddress(DtoUserAddress dtoUserAddress);

        /// <summary>
        /// редактирование адреса пользователя
        /// </summary>
        /// <param name="userAddress"></param>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        UserAddress EditUserAddress(UserAddress userAddress, DtoUserAddress dtoUserAddress);

        /// <summary>
        /// преобразование сущности адреса в дто для отправки пользователю
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        DtoUserAddress GetAddressUser(UserAddress userAddress);

    }
}
