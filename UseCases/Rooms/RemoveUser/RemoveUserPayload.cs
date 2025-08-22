namespace RPlace.UseCases.Rooms.RemoveUser;
using System.ComponentModel.DataAnnotations;


public record RemoveUserPayload
{
    [Required]
    public Guid UserId {get; set;}
}