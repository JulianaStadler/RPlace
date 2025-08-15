namespace RPlace.UseCases.Room.RemoveUser;
using System.ComponentModel.DataAnnotations;


public record RemoveUserPayload
{
    [Required]
    public Guid UserId {get; set;}
}