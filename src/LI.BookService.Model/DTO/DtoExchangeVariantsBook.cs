namespace LI.BookService.Model.DTO
{
    public class DtoExchangeVariantsBook
    {
        /// <summary>
        /// название книги
        /// </summary>
        public string NameBook { get; set; }

        /// <summary>
        /// процент совпадения
        /// </summary>
        public double PercentCoincidence { get; set; }

        /// <summary>
        /// Id ExchangeList
        /// </summary>
        public int ExchangeListId { get; set; }
    }
}
