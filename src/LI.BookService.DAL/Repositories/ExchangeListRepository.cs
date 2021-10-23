using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;

namespace LI.BookService.DAL.Repositories
{
    public class ExchangeListRepository : GenericRepository<ExchangeList>, IExchangeListRepository
    {
        private readonly BookServiceDbContext _context;

        public ExchangeListRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
