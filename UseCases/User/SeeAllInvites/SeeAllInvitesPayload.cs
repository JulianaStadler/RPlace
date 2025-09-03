using System.ComponentModel.DataAnnotations;
namespace RPlace.UseCases.User.SeeAllInvites;

public record SeeAllInvitesPayload
{
    [Required]
    public Guid Id {get; init;}
}