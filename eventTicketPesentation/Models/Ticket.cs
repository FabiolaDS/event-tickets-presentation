using System.Text.Json.Serialization;

namespace eventTicketPesentation.Models
{
    public class Ticket
    {
        [JsonPropertyName("buyerId")]
        public long BuyerId { get; set; }
        [JsonPropertyName("eventId")]
        public long EventId { get; set; }
        
        public string ticketNr { get; set; }
        public double price { get; set; }
        public int nrOfTickets { get; set; }
    }
}