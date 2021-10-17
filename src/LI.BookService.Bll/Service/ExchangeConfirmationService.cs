using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class ExchangeConfirmationService : IExchangeConfirmationService
    {
        public IExchangeConfirmationService _exchangeConfirmationService;

        /// <summary>
        /// получение предложения для обмена участника 1
        /// </summary>
        /// <param name="exchangeListId"></param>
        /// <returns></returns>
        public async Task<ExchangeConfirmation1DTO> GetExchangeList1IdAsync(int exchangeListId, int offerList1Id, int wishList1Id)
        {
            var exchangeList = await _exchangeConfirmationService.GetExchangeList1IdAsync(exchangeListId, offerList1Id, wishList1Id);
            var exchangeConfirmation1DTO = new ExchangeConfirmation1DTO()
            {
                ExchangeListId = exchangeList.ExchangeListId,
                OfferList1Id = exchangeList.OfferList1Id,
                WishList1Id = exchangeList.WishList1Id,
                OfferList = new OfferList(),
                WishList = new WishList()
            };

            return exchangeConfirmation1DTO;
        }

        /// <summary>
        /// получение предложения для обмена участника 2
        /// </summary>
        /// <param name="exchangeListId"></param>
        /// <returns></returns>
        public async Task<ExchangeConfirmation2DTO> GetExchangeList2IdAsync(int exchangeListId, int offerList1Id, int wishList1Id)
        {
            var exchangeList = await _exchangeConfirmationService.GetExchangeList2IdAsync(exchangeListId, offerList1Id, wishList1Id);
            var exchangeConfirmation2DTO = new ExchangeConfirmation2DTO()
            {
                ExchangeListId = exchangeList.ExchangeListId,
                OfferList1Id = exchangeList.OfferList1Id,
                WishList1Id = exchangeList.WishList1Id,
                OfferList = new OfferList(),
                WishList = new WishList()
            };

            return exchangeConfirmation2DTO;
        }

        /// <summary>
        /// выбор варианта для обмена
        /// </summary>
        /// <returns></returns>
        public async Task<ExchangeConfirmation1DTO> ChooseExchangeAsync(int offerList2Id, int wishList2Id)
        {
            var exchangeChoice = await _exchangeConfirmationService.ChooseExchangeAsync(offerList2Id, wishList2Id);
            var exchangeConfirmation1DTO = new ExchangeConfirmation1DTO()
            {
                OfferList2Id = exchangeChoice.OfferList2Id,
                WishList2Id = exchangeChoice.WishList2Id,
                CreateAt = DateTime.Now,
                OfferList = new OfferList(),
                WishList = new WishList()
            };

            return exchangeConfirmation1DTO;
        }

        /// <summary>
        /// подвтерждение варианта для обмена
        /// </summary>
        /// <returns></returns>
        public async Task<ExchangeConfirmation1DTO> ConfirmExchangeAsync(bool isBoth)
        {
            var exchangeConfirmation = await _exchangeConfirmationService.ConfirmExchangeAsync(isBoth);
            var exchangeConfirmation1DTO = new ExchangeConfirmation1DTO()
            {
                IsBoth = true
            };

            return exchangeConfirmation1DTO;
        }

    }
}
