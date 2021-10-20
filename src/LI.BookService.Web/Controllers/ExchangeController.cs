using LI.BookService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LI.BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private IExchangeService _iExchangeService;

        public ExchangeController(IExchangeService iExchangeService)
        {
            _iExchangeService = iExchangeService;
        }

        /// <summary>
        /// Подбор вариантов для обмена системой
        /// </summary>
        /// <returns></returns>
        [HttpGet("{exchangeListId}")]
        public async Task<ActionResult> GetVariants(int exchangeListId)
        {
            var variantes = await _iExchangeService.GetVariantesAsync(exchangeListId);
            return Ok(variantes);

        }
    }
}
