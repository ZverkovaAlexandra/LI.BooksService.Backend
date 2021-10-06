using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.DAL.Repositories
{
    public class UserValueCategoryRepository : GenericRepository<UserValueCategory>, IUserValueCategoryRepository
    {
        private readonly BookServiceDbContext _context;

        public UserValueCategoryRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
