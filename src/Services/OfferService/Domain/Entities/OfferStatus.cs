using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OfferStatus
    {
        Live,
        Accepted,
        Rejected,
        Archived
    }
}
