using System.ComponentModel.DataAnnotations;
namespace RPlace.UseCases.User.SeeInvite;

public record SeeInvitePayload
{
    [Required]
    public Guid Id { get; init; }
    [Required]
    public Guid IdInvite { get; init; }
}