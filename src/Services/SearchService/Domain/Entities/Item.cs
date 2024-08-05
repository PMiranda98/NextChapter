namespace Domain.Entities
{
    public class Item
    {
        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string LiteraryGenre { get; set; }
        public required int Year { get; set; }
        public required Photo Photo { get; set; }
    }
}
