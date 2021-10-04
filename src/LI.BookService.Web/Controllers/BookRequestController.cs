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
        [HttpGet]
        public async Task<ActionResult> GetAllRequestBookUsers(int id)
        {
            var listRequestUser = await _requestBookRepository.GetAllRequestsUser(id);
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
        /// редактирование заявки для получения книги
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoRequestBook>> UpdateGenreBook([FromBody] DtoRequestBook bookRequest)
        {
            try
            {
                if (bookRequest != null)
                {
                    var offerEdit = await _requestBookRepository.GetOfferList(bookRequest);
                    var updateRequestBook = _bookRequestService.EditRequestBook(offerEdit, bookRequest);
                    await _requestBookRepository.UpdateAsync(updateRequestBook);
                    return bookRequest;
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int offerListId)
        {
            try
            {
                bool exists = await _requestBookRepository.ExistsAsync(offerListId);
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
