namespace RPlace.UseCases.Room.ChangePermission;
using System.ComponentModel.DataAnnotations;
public record ChangePermissionPayload{

    [Required]
    public Guid RoomId {get; init;}
    
    [Required]
    public Guid UserId {get; init;}

    [Required]
    public Guid PermissionId {get; init;}

}