using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace LI.BookService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookRequestController : ControllerBase
    {
        private IBookRequestService _bookRequestService;
        private IOfferListRepository _requestBookRepository;

        public BookRequestController(IBookRequestService bookRequestService, IOfferListRepository requestBookRepository)
        {
            _bookRequestService = bookRequestService;
            _requestBookRepository = requestBookRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return Ok("Привет мир!");
        }

        /// <summary>
        /// получение всех заявок пользователя для обмена книг
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetAllRequestBookUsers(int userId)
        {
            var listRequestUser = await _requestBookRepository.GetAllRequestsUserAsync(userId);
            return Ok(listRequestUser);
        }

        /// <summary>
        /// создание заявки на получение книги
        /// </summary>
        /// <param name="dtoNewRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateRequestBook([FromBody] DtoNewRequest dtoNewRequest)
        {
            if (dtoNewRequest != null)
            {
                var requestBook= await _bookRequestService.CreateRequestBook(dtoNewRequest);
                return Ok(requestBook);
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        ///  редактирование заявки для получения книги
        /// </summary>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoRequestBook>> UpdateGenreBook([FromBody] DtoRequestBook requestBook)
        {
            try
            {
                if (requestBook != null)
                {
                    var offer = await _bookRequestService.EditRequestBookAsync(requestBook);

                    return Ok(offer);
                }
                return BadRequest("некорректный id заявки");

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        /// <summary>
        /// удаление заявки для получения книги
        /// </summary>
        /// <param name="offerListId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int offerListId)
        {
            try
            {
                bool exists = await _requestBookRepository.ExistsAsync(offerListId);//проверяем,существет ли запись в бд
                if (exists)
                {
                    var requestBook = await _requestBookRepository.GetByIdAsync(offerListId);
                    await _requestBookRepository.DeleteAsync(requestBook);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }

}
