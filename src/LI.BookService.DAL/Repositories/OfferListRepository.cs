using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Repositories
{
    public class OfferListRepository : GenericRepository<OfferList>, IOfferListRepository
    {
        private readonly BookServiceDbContext _context;

        public OfferListRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// получаем все заявки пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<OfferList>> GetAllRequestsUserAsync(int id)
        {
            var list = await _context.OfferLists.Where(x => x.UserId == id).ToListAsync();
            return list;
        }

        /// <summary>
        /// получаем категорию по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            return category;
        }
    }
}