using Domain.Entities;

namespace Domain.DTOs.Output.Item;

public class ItemDto
{
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string LiteraryGenre { get; set; }
    public required int Year { get; set; }
    public required Photo Photo { get; set; }
}
