using RPlace.Models;
namespace RPlace.UseCases.SeeUser;

public record SeeUserPayload
{
    public string UserName { get; init; }
}