using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IOfferListRepository : IGenericRepository<OfferList>
    {

        /// <summary>
        /// получаем все заявки пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<OfferList>> GetAllRequestsUserAsync(int id);


        /// <summary>
        /// получаем категорию по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category> GetCategoryAsync(int id);
    }
}
