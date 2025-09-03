using System.ComponentModel.DataAnnotations;
namespace RPlace.UseCases.User.SeeInvite;

public record SeeInvitePayload
{
    public Guid Id { get; init; }
}