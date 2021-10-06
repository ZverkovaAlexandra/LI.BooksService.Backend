using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.DTO
{
    public class DtoNewRequest
    {
        public DtoRequestBook DtoRequestBook { get; set; }

        public int AddressId { get; set; }
    }
}
