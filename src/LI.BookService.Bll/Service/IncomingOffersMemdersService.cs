using System;
using System.Collections.Generic;
using System.Text;
using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;

using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class IncomingOffersMemdersService : IIncomingOffersMemders
    {

        private IExchangeConfirmationRepository _exchangeConfirmationRepository;
        public IncomingOffersMemdersService(IExchangeConfirmationRepository exchangeConfirmationRepository)
        {

            _exchangeConfirmationRepository = exchangeConfirmationRepository;
        }



        public async Task<ExchangeListDTO> ConfirmExchangeAsync(ExchangeListDTO exchangeListDTO)
        {
            var exchLists = await _exchangeConfirmationRepository.GetExchangeListId(exchangeListDTO.ExchangeListId);

            



            return exchangeListDTO;


        }

        
    }

   
}
         