using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IExchangeService
    {
        Task<List<DtoExchangeVariantsBook>> GetVariantesAsync(int exchangeListId);
    }
}
