using RPlace.Models;
namespace RPlace.UseCases.SeeUser;

public record SeeUserPayload
{
    public Guid id { get; init; }
}