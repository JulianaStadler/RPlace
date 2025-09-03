using System.ComponentModel.DataAnnotations;

namespace RPlace.UseCases.Rooms.InviteUser;

public record InviteUserPayload{
    [Required]
    public Guid RoomId {get; init;}
    
    [Required]
    public Guid RequestUserId {get; init;}

}