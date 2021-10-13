using System;
using System.Collections.Generic;
using System.Text;
using LI.BookService.Model.Entities;

namespace LI.BookService.Model.DTO
{
  public class GetUserDTO 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; }
        public byte[] Avatar { get; set; }
        public bool IsStaff { get; set; }
        public bool IsSuperAdmin { get; set; }

        public List<OfferList> OfferLists { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
    }
}
