using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.Entities
{
   public class User : IEntityBase
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; }
        public bool[] Avatar { get; set; }
        public bool IsStaff { get; set; }
        public bool IsSuperAdmin { get; set; }


        public List<UserAddress> UserAddresses { get; set; }


    }
}
