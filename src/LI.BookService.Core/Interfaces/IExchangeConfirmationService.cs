using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LI.BookService.Model.DTO;

namespace LI.BookService.Core.Interfaces
{
    public interface IExchangeConfirmationService
    {
        /// <summary>
        /// преобразование сущности в DTO 
        /// </summary>
        /// <param name="exchangeListId"></param>
        /// <returns></returns>
        Task<ExchangeConfirmation1DTO> GetExchangeList1IdAsync(int exchangeListId, int offerList1Id, int wishList1Id);
        Task<ExchangeConfirmation2DTO> GetExchangeList2IdAsync(int exchangeListId, int offerList1Id, int wishList1Id);

        // выбор варианта для обмена
        Task<ExchangeConfirmation1DTO> ChooseExchangeAsync(int offerList2Id, int wishList2Id);

        // подтверждение варианта для обмена
        Task<ExchangeConfirmation1DTO> ConfirmExchangeAsync(bool isBoth);
    }
}
