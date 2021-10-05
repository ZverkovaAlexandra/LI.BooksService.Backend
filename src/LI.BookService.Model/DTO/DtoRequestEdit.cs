using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.DTO
{
    /// <summary>
    /// дто редактирования заявки 
    /// </summary>
    public class DtoRequestEdit:DtoRequestBook
    {
        public int Id { get; set; }
    }
}
