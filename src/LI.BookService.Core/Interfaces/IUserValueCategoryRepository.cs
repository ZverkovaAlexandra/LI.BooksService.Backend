﻿using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IUserValueCategoryRepository :IGenericRepository<UserValueCategory>
    {
        Task<List<Category>> GetCategoriesByUserListIdAsync(int userListId);
        Task<List<UserValueCategory>> GetUserValueCategoryAsync(List<Category> categories);
    }
}
