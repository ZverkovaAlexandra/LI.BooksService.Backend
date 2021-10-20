using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Repositories
{
    public class ExchangeListRepository : GenericRepository<ExchangeList>, IExchangeListRepository
    {
        private readonly BookServiceDbContext _context;

        public ExchangeListRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ExchangeList>> GetListByIdAsync(int exchangeListId)
        {
            var list = await _context.ExchangeLists.Where(x => x.ExchangeListId == exchangeListId && x.IsBoth == true).ToListAsync();
            return list;
        }

        public async Task<List<ExchangeList>> GetExchangeListsAsync(List<OfferList> offerLists)
        {
            List<ExchangeList> exchangeLists = new List<ExchangeList>();

            foreach (var s in offerLists)
            {
                var exchangeList = await _context.ExchangeLists.FirstOrDefaultAsync(x => x.OfferList1Id == s.OfferListId);
                if (exchangeList != null)
                    exchangeLists.Add(exchangeList);
            }

            return exchangeLists;
        }
    }
}
