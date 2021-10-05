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
        private IRequestBookRepository _requestBookRepository;

        public BookRequestController(IBookRequestService bookRequestService, IRequestBookRepository requestBookRepository)
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
            var listRequestUser = await _requestBookRepository.GetAllRequestsUser(userId);
            return Ok(listRequestUser);
        }

        /// <summary>
        /// создание заявки на получение книги
        /// </summary>
        /// <param name="dtoDemandBook"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateRequestBook([FromBody] DtoRequestBook bookRequest)
        {
            if (bookRequest != null)
            {
                var offer = _bookRequestService.CreateRequestBook(bookRequest);
                await _requestBookRepository.CreateAsync(offer);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        ///  редактирование заявки для получения книги
        /// </summary>
        /// <param name="requestEdit"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoRequestEdit>> UpdateGenreBook([FromBody] DtoRequestEdit requestEdit)
        {
            try
            {
                if (requestEdit != null)
                {
                    var offerEdit = await _requestBookRepository.GetByIdAsync(requestEdit.Id);
                    var updateRequestBook = _bookRequestService.EditRequestBook(offerEdit, requestEdit);
                    await _requestBookRepository.UpdateAsync(updateRequestBook);
                    return requestEdit;
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
