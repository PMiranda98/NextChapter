﻿using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Item;

public class CreateItemDto
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Author { get; set; }
    [Required]
    public required string LiteraryGenre { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public required string Image { get; set; }
}
