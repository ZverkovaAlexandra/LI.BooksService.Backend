using LI.BookService.Model.DTO;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IExchangeConfirmationService
    {
        /// <summary>
        /// подвтерждение варианта для обмена
        /// </summary>
        /// <param name="exchangeConfirmationDTO"></param>
        /// <returns></returns>
        Task<ExchangeConfirmationDTO> ConfirmExchangeAsync(ExchangeConfirmationDTO exchangeConfirmationDTO);
    }
}