using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using LI.BookService.Bll.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace LI.BookService.Bll.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<GetUserDTO> Authenticate(LoginUserDTO model)
        {
            var user = await _userRepository.Authenticate(model.UserName, model.Password);
            user.Token = _configuration.GenerateJwtToken(user);
            return new GetUserDTO(user);
        }

        public async Task<GetUserDTO> Register(CreateUserDTO userModel)
        {
            await CreateUserAsync(userModel);
            return await this.Authenticate( new LoginUserDTO(userModel.UserName, userModel.Password) );
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

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.SecondName = userDTO.SecondName;
            user.Email = userDTO.Email;
            user.UserName = userDTO.UserName;
            user.Password = userDTO.Password;
        }

        /// <summary>
        /// преобразование сущности в дто 
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
    
        public async Task<GetUserDTO> GetUserAsync( int id)
        {
            var user = await _userRepository.GetUser(id);
            var userDTO = new GetUserDTO(user);
            
            return userDTO;
        }
    }
}







