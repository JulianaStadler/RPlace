namespace RPlace.UseCases.Rooms.SeePlayers;
using System.ComponentModel.DataAnnotations;


public record SeePlayersPayload
{
    [Required]
    public Guid RoomId { get; init; }

    [Required]
    public Guid PlayerId { get; init; }
}