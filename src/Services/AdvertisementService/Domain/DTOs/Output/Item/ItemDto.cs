namespace Domain.DTOs.Output.Item;

public class ItemDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string LiteraryGenre { get; set; }
    public required int Year { get; set; }
    public string? ImageUrl { get; set; }
}
