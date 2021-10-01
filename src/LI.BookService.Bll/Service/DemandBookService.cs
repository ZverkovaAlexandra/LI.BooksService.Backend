using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class DemandBookService : IDemandBookService
    {
        /// <summary>
        /// создание заявки для обмена книги
        /// </summary>
        /// <param name="dtoDemandBook"></param>
        /// <returns></returns>
        public async Task CreateDemand(DtoDemandBook dtoDemandBook)
        {
            //создать функционал 
        }
        
    }
}
