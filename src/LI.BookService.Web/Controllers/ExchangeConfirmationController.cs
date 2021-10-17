using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LI.BookService.Model;
using LI.BookService.Core.Interfaces;
using System.Threading.Tasks;
using LI.BookService.Model.DTO;

namespace LI.BookService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeConfirmationController : ControllerBase
    {
        private IExchangeConfirmationService _exchangeConfirmationService;

        public ExchangeConfirmationController (IExchangeConfirmationService exchangeConfirmationService)
        {
            _exchangeConfirmationService = exchangeConfirmationService;
        }

        /// <summary>
        /// получение предложения для обмена участника 1
        /// </summary>
        /// <returns></returns>
        [HttpGet("{ExchangeListId}")]
        public async Task<ActionResult> GetExchangeList1Id (int exchangeListId, int offerList1Id, int wishList1Id)
        {
            var exchangeList = await _exchangeConfirmationService.GetExchangeList1IdAsync (exchangeListId, offerList1Id, wishList1Id);
            return Ok(exchangeList);
        }

        /// <summary>
        /// получение предложения для обмена участника 1
        /// </summary>
        /// <returns></returns>
        [HttpGet("{ExchangeListId}")]
        public async Task<ActionResult> GetExchangeList2Id(int exchangeListId, int offerList1Id, int wishList1Id)
        {
            var exchangeList = await _exchangeConfirmationService.GetExchangeList2IdAsync(exchangeListId, offerList1Id, wishList1Id);
            return Ok(exchangeList);
        }

        /// <summary>
        /// выбор варианта для обмена
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ChooseExchange([FromBody] ExchangeConfirmation1DTO exchangeConfirmation1DTO)
        {
            var exchangeChoice = await _exchangeConfirmationService.ChooseExchangeAsync(exchangeConfirmation1DTO.OfferList2Id, exchangeConfirmation1DTO.WishList2Id);
            return Ok(exchangeChoice);
        }


        /// <summary>
        /// подтверждение варианта для обмена
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> ConfirmExchange1([FromBody] ExchangeConfirmation1DTO exchangeConfirmation1DTO)
        {
            var exchangeConfirmation = await _exchangeConfirmationService.ConfirmExchangeAsync(exchangeConfirmation1DTO.IsBoth);
            return Ok(exchangeConfirmation);
        }
    }
}