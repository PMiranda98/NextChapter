using System.Text.Json.Serialization;

namespace AdvertisementService.Domain.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AdvertisementStatus
{
    Live,
    Finished,
    Sold,
    Archived
}
