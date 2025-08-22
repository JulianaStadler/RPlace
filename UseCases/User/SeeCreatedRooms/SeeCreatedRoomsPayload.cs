using System.ComponentModel.DataAnnotations;

namespace RPlace.UseCases.User.SeeCreatedRooms;

public record SeeCreatedRoomsPayload
{
    [Required]
    public Guid PlayerId { get; init; }
}