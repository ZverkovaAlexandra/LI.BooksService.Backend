using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace LI.BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandBooksController : ControllerBase
    {
        private IDemandBookService _demandBookService;

        public DemandBooksController(IDemandBookService demandBookService)
        {
            _demandBookService = demandBookService;
        }

        /// <summary>
        /// создание заявки на получение книги
        /// </summary>
        /// <param name="dtoDemandBook"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateDemandBook(DtoDemandBook dtoDemandBook)
        {
            if (dtoDemandBook != null)
            {
                await _demandBookService.CreateDemand(dtoDemandBook);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
