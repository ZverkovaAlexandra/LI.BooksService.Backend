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
        
        private IOfferListRepository _requestBookRepository;

        public IncomingOffersMemdersController(IIncomingOffersMemders incomingOffersMemders, IOfferListRepository requestBookRepository)
        {
            _incomingOffersMemders = incomingOffersMemders;
            _requestBookRepository = requestBookRepository;
        }
    }
}
