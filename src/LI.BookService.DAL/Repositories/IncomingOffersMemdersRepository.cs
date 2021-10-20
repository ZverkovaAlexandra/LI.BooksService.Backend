using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LI.BookService.DAL.Repositories
{
    public class IncomingOfferMemderRepository : GenericRepository<ExchangeList>, IExchangeConfirmationRepository// использую интерфейс из 30 задачи 
    {
        private readonly BookServiceDbContext _context;

        public IncomingOfferMemderRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExchangeList> GetExchangeListId(int exchangeListId)
        {
            var exListId = await _context.ExchangeLists.SingleOrDefaultAsync(x => x.ExchangeListId == exchangeListId);
            return exListId;
        }
    }
}
