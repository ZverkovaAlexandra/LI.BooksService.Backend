using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LI.BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingOffersMemdersController : ControllerBase
    {
        private IIncomingOffersMemders _incomingOffersMemders;



        public IncomingOffersMemdersController(IIncomingOffersMemders incomingOffersMemders)
        {
            _incomingOffersMemders = incomingOffersMemders;

        }



        /// <summary>
        /// подтверждение варианта для обмена
        /// </summary>
        /// <param name="exchangeListDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ConfirmExchange([FromBody] ExchangeListDTO exchangeListDTO)
        {
            var exchangeConfirmation = await _incomingOffersMemders.ConfirmExchangeAsync(exchangeListDTO);
            return Ok(exchangeConfirmation);
        }
    }
}