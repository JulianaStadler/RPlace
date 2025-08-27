using System.ComponentModel.DataAnnotations;

namespace RPlace.UseCases.User.SeeMyRooms;

public record SeeMyRoomsPayload
{
    [Required]
    public Guid PlayerId { get; init; }
}