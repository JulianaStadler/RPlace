namespace RPlace.UseCases.Rooms.SeePixels;
using System.ComponentModel.DataAnnotations;


public record SeePixelsPayload
{
    [Required]
    public Guid RoomId { get; init; }
}