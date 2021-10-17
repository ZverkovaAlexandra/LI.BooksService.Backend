using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.DTO
{
    public class LoginUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginUserDTO(string UserName, string Password) {
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
