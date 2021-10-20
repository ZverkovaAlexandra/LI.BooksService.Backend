
using LI.BookService.Model.DTO;
using System.Threading.Tasks;
namespace LI.BookService.Core.Interfaces
{
    public interface IIncomingOffersMemders
    {
        /// <summary>
        //
        /// </summary>
        /// <param name="exchangeListDTO"></param>
        /// <returns></returns>
        Task<ExchangeListDTO> ConfirmExchangeAsync(ExchangeListDTO exchangeListDTO);
    }
}
