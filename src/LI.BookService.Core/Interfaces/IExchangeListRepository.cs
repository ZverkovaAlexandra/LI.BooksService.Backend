using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IExchangeListRepository : IGenericRepository<ExchangeList>
    {
        Task<List<ExchangeList>> GetListByIdAsync(int exchangeListId);
        Task<List<ExchangeList>> GetExchangeListsAsync(List<OfferList> offerLists);
    }
}
