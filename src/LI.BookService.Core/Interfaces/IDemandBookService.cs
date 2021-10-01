using LI.BookService.Model.DTO;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IDemandBookService 
    {
        /// <summary>
        /// создание заявки на получение книги
        /// </summary>
        /// <param name="dtoDemandBook"></param>
        /// <returns></returns>
        Task CreateDemand(DtoDemandBook dtoDemandBook);

    }
}
