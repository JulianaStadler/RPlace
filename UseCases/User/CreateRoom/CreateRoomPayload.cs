using System.ComponentModel.DataAnnotations;

namespace RPlace.UseCases.User.CreateRoom;

public record CreateRoomPayload
{
    [Required]
    public string Name { get; init; }

    [Required]
    [Range(1,1000)]
    public int Width { get; init; }

    [Required]
    [Range(1, 1000)]
    public int Height { get; init; }
}