using System.ComponentModel.DataAnnotations;

namespace PhantomChannel.Server.Application.Dtos;

public class TestDto
{
    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public required string[] Permissions { get; set; }
}