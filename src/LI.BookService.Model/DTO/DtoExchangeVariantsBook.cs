﻿namespace LI.BookService.Model.DTO
{
    public class DtoExchangeVariantsBook
    {
        /// <summary>
        /// название книги
        /// </summary>
        public string NameBook { get; set; }

        /// <summary>
        /// дто с вариантами и процентом совпадения
        /// </summary>
        public DtoVariantes DtoVariantes { get; set; }

        /// <summary>
        /// Id ExchangeList
        /// </summary>
        public int ExchangeListId { get; set; }
    }
}
