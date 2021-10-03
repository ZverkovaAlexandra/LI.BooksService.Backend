using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.Entities
{
   public class UserAddress : IEntityBase
    {
        public int IdUserAddress { get; set; }
        public int IdUser { get; set; }
        public string AddrIndex { get; set; }
        public string AddrCity { get; set; }
        public string AddrSreet { get; set; }
        public string AddrHouse { get; set; }
        public string AddrStructure { get; set; }
        public string AddrApart { get; set; }
        public bool IsDefault { get; set; }

        public User User { get; set; }
 
    }
}
