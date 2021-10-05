using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IRequestBookRepository : IGenericRepository<OfferList>
    {

        /// <summary>
        /// получаем все заявки пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<OfferList>> GetAllRequestsUser(int id);
    }
}
