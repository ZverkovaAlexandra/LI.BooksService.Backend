using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Bll.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// получение  пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUser(int userId)
        {
            var userDto = await _userService.GetUserAsync(userId);

            return Ok(userDto);
        }

        /// <summary>
        /// создание  пользователя
        /// </summary>
        /// <param name="createUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            if (createUserDTO != null)
            {
                var user = await _userService.CreateUserAsync(createUserDTO);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// редактирование пользователя
        /// </summary>
        /// <param name="editedUserDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoUserAddress>> UpdateUser([FromBody] EditedUserDTO editedUserDTO)
        {
            try
            {
                if (editedUserDTO != null)
                {
                    var user = await _userService.EditUserAsync(editedUserDTO);
                    return Ok(user);
                }
                return BadRequest("некорректный id адреса пользователя");

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }  
    }

