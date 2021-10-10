using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// создание пользователя
        /// </summary>
        /// <param name="createUserDTO"></param>
        /// <returns></returns>
        public async Task<CreateUserDTO> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            User user = new User();
            MapEntityCreate(user, createUserDTO);
            await _userRepository.CreateAsync(user);

            return createUserDTO;
        }

        /// <summary>
        /// редактирование пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="editedUserDTO"></param>
        /// <returns></returns>
        public async Task<EditedUserDTO> EditUserAsync(EditedUserDTO editedUserDTO)
        {
            var user = await _userRepository.GetByIdAsync(editedUserDTO.UserId);
            MapEntityEdite(user, editedUserDTO);
            await _userRepository.UpdateAsync(user);

            return editedUserDTO;
        }


        /// <summary>
        /// хелпер для установки значения полей сущности адреса пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userDTO"></param>
        /// 
        public void MapEntityCreate(User user, CreateUserDTO userDTO)
        {
            user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                SecondName = userDTO.SecondName,
                Email = userDTO.Email,
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                UserAddresses = new List<UserAddress>()
            };
            user.UserAddresses.Add(new UserAddress()
            {
                AddrIndex = userDTO.AddrIndex,
                AddrSreet = userDTO.AddrSreet,
                AddrHouse = userDTO.AddrHouse,
                AddrStructure = userDTO.AddrStructure,
                AddrApart = userDTO.AddrApart
            });


        }
        public void MapEntityEdite(User user, EditedUserDTO userDTO)
        {
            user = new User()
            {
                UserId = userDTO.UserId,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                SecondName = userDTO.SecondName,
                Email = userDTO.Email,
                UserName = userDTO.UserName,
                Password = userDTO.Password,

            };
        }

        /// <summary>
        /// преобразование сущности в дто 
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>

        public async Task<GetUserDTO> GetUserAsync(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            var userDTO = new GetUserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                SecondName = user.SecondName,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                Rating = user.Rating,
                CreatedAt = user.CreatedAt,
                Enabled = user.Enabled,
                Avatar = user.Avatar,
                IsStaff = user.IsStaff,
                IsSuperAdmin = user.IsSuperAdmin,
                UserAddresses = user.UserAddresses,
            };

            return userDTO;
        }
    }
}







