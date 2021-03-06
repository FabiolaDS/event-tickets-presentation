using System.Collections.Generic;
using System.Threading.Tasks;
using eventTicketPesentation.Models;
using eventTicketPesentation.Service.dto;
using RabbitMQ.Client;

namespace eventTicketPesentation.Service.MQ
{
    public class MQCreditCardService : MQService, ICreditCardService
    {
        public MQCreditCardService(IModel channel) : base(channel)
        {
        }

        public Task<CreditCard> AddCreditCardAsync(CreateCreditCardDTO creditCardDto)
        {
            return SendAndConvertAsync<CreditCard, CreateCreditCardDTO>("addCreditCard", creditCardDto);
        }

        public Task RemoveCreditCardAsync(CreditCard creditCard)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CreditCard>> GetCreditCardsForUserAsync(long ownerId)
        {
            return SendAndConvertAsync<List<CreditCard>, long>("getCreditCards", ownerId);
        }
    }
}