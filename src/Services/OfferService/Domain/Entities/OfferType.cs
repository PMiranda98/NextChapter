using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OfferType
    {
        Purchase,
        Exchange
    }
}
