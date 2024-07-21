namespace AdvertisementService.Domain.Entities;

public class Item
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string LiteraryGenre { get; set; }
    public required int Year { get; set; }
    public string? ImageUrl { get; set; }
    // navigation properties
    public Advertisement? Advertisement { get; set; }
    public Guid AdvertisementId { get; set; }
}
