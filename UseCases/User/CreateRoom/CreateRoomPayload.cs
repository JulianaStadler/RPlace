using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RPlace.UseCases.User;

public record CreateRoomPayload
{
    [Required]
    [MinLength(5)]
    [MaxLength(40)]
    public string Name { get; set; }
    
    [Required]
    [Range(1, 256)]
    public int Width { get; set; }

    [Required]
    [Range(1, 256)]
    public int Height { get; set; }
}