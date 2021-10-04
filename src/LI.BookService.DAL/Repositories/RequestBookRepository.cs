using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Repositories
{
    public class RequestBookRepository : GenericRepository<OfferList>, IRequestBookRepository
    {
        private readonly BookServiceDbContext _context;

        public RequestBookRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// достаем из бд заявку на полечение книги 
        /// </summary>
        /// <param name="bookRequest"></param>
        /// <returns></returns>
        public async Task<OfferList> GetOfferList(DtoRequestBook bookRequest)
        {
            var offerList = await _context.OfferLists.SingleOrDefaultAsync(x => x.ISBN == bookRequest.ISBN && x.YearPublishing == bookRequest.YearPublishing);
            return offerList;
        }

        /// <summary>
        /// получаем все заявки пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<OfferList>> GetAllRequestsUser(int id)
        {
            var list = await _context.OfferLists.Where(x => x.UserId == id).ToListAsync();
            return list;
        }
    }
}