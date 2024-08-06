using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public record Movie
{
    [Key]
    public int Id { get; init; }

    [MaxLength(50)]
    public string? Name { get; init; }

    [MaxLength(50)]
    public string? UrlImage { get; init; }

    [MaxLength(50)]
    public string? AlternativeName1 { get; init; }
    [MaxLength(50)]
    public string? AlternativeName2 { get; init; }
}
