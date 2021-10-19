using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class ExchangeConfirmationService : IExchangeConfirmationService
    {
        private IExchangeConfirmationRepository _exchangeConfirmationRepository;

        /// <summary>
        /// подвтерждение варианта для обмена
        /// </summary>
        /// <returns></returns>
        public async Task<ExchangeConfirmationDTO> ConfirmExchangeAsync(ExchangeConfirmationDTO exchangeConfirmationDTO)
        {
            var exchangeConfirmation1 = await _exchangeConfirmationRepository.GetExchangeListId(exchangeConfirmationDTO.ExchangeList1Id);
            var exchangeConfirmation2 = await _exchangeConfirmationRepository.GetExchangeListId(exchangeConfirmationDTO.ExchangeList2Id);
            await _exchangeConfirmationRepository.UpdateAsync(exchangeConfirmation1);
            await _exchangeConfirmationRepository.UpdateAsync(exchangeConfirmation2);

            return exchangeConfirmationDTO;
        }
    }
}
