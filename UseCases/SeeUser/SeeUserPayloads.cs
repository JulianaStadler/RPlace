using RPlace.Models;
namespace RPlace.UseCases.SeeUsers;

public record SeeUserPayload
{
    public string UserName { get; init; }
}