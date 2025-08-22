namespace RPlace.UseCases.Room.SeePlayers;
using System.ComponentModel.DataAnnotations;


public record SeePlayersPayload
{
    [Required]
    public Guid RoomId { get; init; }
}