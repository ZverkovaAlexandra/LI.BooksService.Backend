using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace LI.BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private IUserAddressService _userAddressService;
        private IUserAddressRepository _userAddressRepository;

        public UserAddressController(IUserAddressService userAddressService, IUserAddressRepository userAddressRepository)
        {
            _userAddressService = userAddressService;
            _userAddressRepository = userAddressRepository;
        }

        /// <summary>
        /// получение адреса пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserAddress(int userId)
        {
            var addressEntity = await _userAddressRepository.GetAddressUser(userId);
            var addressDto = _userAddressService.GetAddressUser(addressEntity);

            return Ok(addressDto);
        }

        /// <summary>
        /// создание адреса пользователя
        /// </summary>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateAddressUser([FromBody] DtoUserAddress dtoUserAddress)
        {
            if (dtoUserAddress != null)
            {
                var address = _userAddressService.CreateUserAddress(dtoUserAddress);
                await _userAddressRepository.CreateAsync(address);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// редактирование адреса пользователя
        /// </summary>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoUserAddress>> UpdateAddressUser([FromBody] DtoUserAddress dtoUserAddress)
        {
            try
            {
                if (dtoUserAddress != null)
                {
                    var adressEntity = await _userAddressRepository.GetByIdAsync(dtoUserAddress.Id);
                    var addressDto = _userAddressService.EditUserAddress(adressEntity, dtoUserAddress);

                    return Ok(addressDto);
                }
                return BadRequest("некорректный id адреса пользователя");

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        /// <summary>
        /// удаление адреса пользователя
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int addressId)
        {
            try
            {
                bool exists = await _userAddressRepository.ExistsAsync(addressId);//проверяем,существет ли запись в бд
                if (exists)
                {
                    var adressEntity = await _userAddressRepository.GetByIdAsync(addressId);
                    await _userAddressRepository.DeleteAsync(adressEntity);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
