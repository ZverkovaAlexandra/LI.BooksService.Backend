﻿using LI.BookService.Core.Interfaces;
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
        /// <summary>
        /// из списка офферлистов получаем названия книг
        /// </summary>
        /// <param name="offerLists"></param>
        /// <returns></returns>
        public async Task<List<BookLiterary>> GetBookLiterariesAsync(List<OfferList> offerLists)
        {
            List<BookLiterary> bookLiteraries = new List<BookLiterary>();

            foreach (var s in offerLists)
            {
                var bookLiterary = await _context.BookLiteraries.FirstOrDefaultAsync(x => x.BookLiteraryId == s.BookLiteraryId);
                if (bookLiterary != null)
                    bookLiteraries.Add(bookLiterary);
            }
            return bookLiteraries;
        }

    }
}