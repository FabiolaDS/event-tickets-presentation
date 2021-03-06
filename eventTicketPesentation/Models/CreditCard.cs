using System.Text.Json.Serialization;

namespace eventTicketPesentation.Models
{
    public class CreditCard
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        
        [JsonPropertyName("cardNumber")] public string CardNumber { get; set; }
        [JsonPropertyName("expiryMonth")] public int ExpiryMonth { get; set; }
        [JsonPropertyName("expiryYear")] public int ExpiryYear { get; set; }
        [JsonPropertyName("cvv")] public int Cvv { get; set; }
        [JsonPropertyName("cardOwnerName")] public string CardOwnerName { get; set; }
    }
}